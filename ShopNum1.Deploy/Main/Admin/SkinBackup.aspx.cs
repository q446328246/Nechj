using System;
using System.Data;
using System.IO;
using System.Threading;
using System.Web.SessionState;
using System.Web.UI.WebControls;
using ShopNum1.Common;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class SkinBackup : PageBase, IRequiresSessionState
    {
        private DataTable dt;

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            if (!Page.IsPostBack)
            {
                BindData();
                method_6();
            }
        }

        protected void ButtonBackUp_Click(object sender, EventArgs e)
        {
            try
            {
                string path = "~/Main/Themes/" + Globals.SkinName;
                string str2 = path + "/Skin.xml";
                string str4 =
                    XmlOperator.GetXmlData(base.Server.MapPath(str2), "Skin").Tables[0].Rows[0]["name"].ToString();
                string str5 = "~/BackUp/" + str4 + "(" + DateTime.Now.ToString("yyyy-MM-dd hh-mm-ss") + ").zip";
                Thread.Sleep(200);
                ShopNum1Zip.ZipFileDictory(base.Server.MapPath(path), base.Server.MapPath(str5), null);
                MessageBox.Show("模板备份成功!");
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message + "请创建主目录BackUp");
            }
            finally
            {
                BindData();
            }
        }

        protected DataTable CreateSkinTable()
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
                    ColumnName = "Name"
                };
            dt.Columns.Add(column);
            column = new DataColumn
                {
                    DataType = Type.GetType("System.String"),
                    ColumnName = "createTime"
                };
            dt.Columns.Add(column);
            return dt;
        }

        protected void DataListShow_ItemCommand(object sender, DataListCommandEventArgs e)
        {
            Label label;
            Label label2;
            int num;
            string str;
            if (e.CommandName == "select")
            {
                label = (Label) e.Item.FindControl("LabelNameValue");
                label2 = (Label) e.Item.FindControl("LabelCreateTime");
                num = 1;
                try
                {
                    //Themes.DeleteFolder(base.Server.MapPath("~/Main/Themes/Skin_Default"));
                    Directory.CreateDirectory(base.Server.MapPath("~/Main/Themes/Skin_Default"));
                    if (Directory.Exists(base.Server.MapPath("~/Main/Themes/Skin_Default")))
                    {
                        str = "~/BackUp/" + label.Text + "(" + label2.Text + ").zip";
                        string zipedFolder = Page.Server.MapPath("~/Main/Themes/");
                        string path = Page.Server.MapPath("~/Main/Themes/Skin_Default/") + label.Text + "(" +
                                      label2.Text + ").zip";
                        if (!File.Exists(path))
                        {
                            File.Copy(Page.Server.MapPath(str), path);
                            Thread.Sleep(200);
                        }
                        ShopNum1UnZipClass.UnZip(path, zipedFolder, null);
                        File.Delete(path);
                    }
                }
                catch (Exception exception)
                {
                    num = -1;
                    MessageBox.Show(exception.Message);
                    BindData();
                }
                finally
                {
                    if (num == 1)
                    {
                        MessageBox.Show("恢复模板成功!");
                        BindData();
                    }
                }
            }
            else if (e.CommandName == "delete")
            {
                label = (Label) e.Item.FindControl("LabelNameValue");
                label2 = (Label) e.Item.FindControl("LabelCreateTime");
                num = 1;
                str = "~/BackUp/" + label.Text + "(" + label2.Text + ").zip";
                try
                {
                    File.Delete(Page.Server.MapPath(str));
                    MessageBox.Show("删除成功!");
                    BindData();
                }
                catch
                {
                    MessageBox.Show("删除失败!");
                    BindData();
                }
            }
        }

        private void BindData()
        {
            try
            {
                string[] files = Directory.GetFiles(base.Server.MapPath("~/BackUp/"), "*.Zip");
                DataTable table = CreateSkinTable();
                for (int i = 0; i < files.Length; i++)
                {
                    DataRow row = table.NewRow();
                    row["Guid"] = Guid.NewGuid();
                    var info = new FileInfo(files[i]);
                    row["createTime"] = info.CreationTime.ToString("yyyy-MM-dd hh-mm-ss");
                    row["Name"] = info.Name.Split(new[] {'.'})[0].Split(new[] {'('})[0];
                    table.Rows.Add(row);
                }
                DataListShow.DataSource = table;
                DataListShow.DataBind();
            }
            catch
            {
            }
        }

        private void method_6()
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

    }
}