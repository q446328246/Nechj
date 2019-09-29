using System;
using System.Data;
using System.IO;
using System.Web.SessionState;
using System.Web.UI.WebControls;
using ShopNum1.Common;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class SkinSelect : PageBase, IRequiresSessionState
    {
        private DataTable dt;

        public string CheckSkinBackup()
        {
            return ShopSettings.GetValue("SkinBackup");
        }

        protected void CreateSkinTable()
        {
            dt = new DataTable();
            dt.Rows.Clear();
            var column = new DataColumn
                {
                    DataType = Type.GetType("System.Guid"),
                    ColumnName = "Guid"
                };
            dt.Columns.Add(column);
            column = new DataColumn
                {
                    DataType = Type.GetType("System.String"),
                    ColumnName = "FolderName"
                };
            dt.Columns.Add(column);
            column = new DataColumn
                {
                    DataType = Type.GetType("System.String"),
                    ColumnName = "Name"
                };
            dt.Columns.Add(column);
            column = new DataColumn
                {
                    DataType = Type.GetType("System.String"),
                    ColumnName = "Description"
                };
            dt.Columns.Add(column);
            column = new DataColumn
                {
                    DataType = Type.GetType("System.String"),
                    ColumnName = "SkinImage"
                };
            dt.Columns.Add(column);
            column = new DataColumn
                {
                    DataType = Type.GetType("System.String"),
                    ColumnName = "SkinName"
                };
            dt.Columns.Add(column);
            ViewState["dataTableSkin"] = dt;
        }

        protected void DataListShow_ItemCommand(object sender, DataListCommandEventArgs e)
        {
            Label label;
            Label label2;
            int num;
            Exception exception;
            if (e.CommandName == "select")
            {
                label = (Label) e.Item.FindControl("LabelNameValue");
                label2 = (Label) e.Item.FindControl("LabelFolderNameValue");
                var label1 = (Label) e.Item.FindControl("LabelSkinNameValue");
                num = 1;
                if (label.Text == LabelNameValue.Text)
                {
                    MessageBox.Show("正在使用该模版！");
                }
                else
                {
                    try
                    {
                        if (
                            File.Exists(
                                Page.Server.MapPath("~/Skin/Master/" + label2.Text.Trim() + "/" + label.Text.Trim()) +
                                ".zip"))
                        {
                            if (CheckSkinBackup() == "1")
                            {
                                string fileToZip = Page.Server.MapPath("~/Main/Themes/Skin_Default/");
                                string str3 = DateTime.Now.ToString("yyyyMMddHHmmss");
                                string zipedFile = Page.Server.MapPath("~/BackUp/" + str3 + ".zip");
                                ShopNum1Zip.Zip(fileToZip, zipedFile, null);
                            }
                            try
                            {
                            }
                            catch (Exception exception1)
                            {
                                exception = exception1;
                                MessageBox.Show(exception.Message);
                            }
                        }
                        else
                        {
                            MessageBox.Show("该模板文件不存在！");
                        }
                        return;
                    }
                    catch (Exception exception2)
                    {
                        exception = exception2;
                        num = -1;
                        MessageBox.Show(exception.Message);
                        MessageBox.Show("应用模板失败！");
                    }
                    finally
                    {
                        if (num == 1)
                        {
                            BindData();
                            MessageBox.Show("应用模板成功");
                        }
                    }
                }
            }
            if (e.CommandName == "delete")
            {
                label = (Label) e.Item.FindControl("LabelNameValue");
                label2 = (Label) e.Item.FindControl("LabelFolderNameValue");
                var label3 = (Label) e.Item.FindControl("LabelSkinNameValue");
                num = 1;
                if (label.Text == LabelNameValue.Text)
                {
                    MessageBox.Show("正在使用该模版！");
                }
                else
                {
                    try
                    {
                        method_7(Page.Server.MapPath("~/Skin/Master/" + label2.Text.Trim() + "/"));
                        method_6();
                    }
                    catch (Exception exception3)
                    {
                        exception = exception3;
                        MessageBox.Show(exception.Message);
                        MessageBox.Show("应用模板失败！");
                    }
                }
            }
        }

        private void BindData()
        {
            string skinName = string.Empty;
            skinName = Globals.SkinName;
            LabelFolderNameValue.Text = skinName;
            string str2 = "Themes/" + skinName + "/Skin.xml";
            foreach (DataRow row in XmlOperator.GetXmlData(base.Server.MapPath("../" + str2), "Skin").Tables[0].Rows)
            {
                LabelNameValue.Text = row["name"].ToString().Trim();
                LabelDescriptionValue.Text = row["description"].ToString().Trim();
            }
            ImageCurrentSkin.ImageUrl = Globals.SkinPath + "/Skin.jpg";
        }

        private void method_6()
        {
            string path = base.Server.MapPath("~/Template/Master");
            try
            {
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
            }
            catch
            {
            }
            DirectoryInfo[] directories = new DirectoryInfo(path).GetDirectories();
            var table = (DataTable) ViewState["dataTableSkin"];
            DirectoryInfo[] infoArray = directories;
            int index = 0;
            while (true)
            {
                if (index >= infoArray.Length)
                {
                    break;
                }
                DirectoryInfo info = infoArray[index];
                try
                {
                    DataRow row = table.NewRow();
                    row["Guid"] = Guid.NewGuid();
                    row["FolderName"] = info.Name;
                    string str2 = info.Name + "/Skin.xml";
                    foreach (
                        DataRow row2 in
                            XmlOperator.GetXmlData(base.Server.MapPath("~/Template/Master/" + str2), "Skin").Tables[0]
                                .Rows)
                    {
                        row["Name"] = row2["name"].ToString().Trim();
                        row["Description"] = row2["description"].ToString().Trim();
                        row["SkinImage"] = "~/Template/Master/" + info.Name + "/Skin.jpg";
                    }
                    table.Rows.Add(row);
                }
                catch
                {
                }
                index++;
            }
            DataListShow.DataSource = table.DefaultView;
            DataListShow.DataBind();
        }

        private void method_7(string string_4)
        {
            if (Directory.Exists(string_4))
            {
                foreach (string str in Directory.GetFileSystemEntries(string_4))
                {
                    if (File.Exists(str))
                    {
                        File.Delete(str);
                    }
                    else
                    {
                        method_7(str);
                    }
                }
                Directory.Delete(string_4, true);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            CreateSkinTable();
            if (!Page.IsPostBack)
            {
                BindData();
                method_6();
            }
        }
    }
}