using System;
using System.Data;
using System.IO;
using System.Threading;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;

namespace ShopNum1.ShopAdminWebControl
{
    [ParseChildren(true)]
    public class S_SkinBackup : BaseShopWebControl
    {
        private Image ImageCurrentSkin;
        private Label LabelDescriptionValue;
        private Label LabelFolderNameValue;
        private Label LabelNameValue;
        private LinkButton LinkButton_BackUp;
        private Repeater RepeaterShow;
        private DataTable dt;
        private string skinFilename = "S_SkinBackup.ascx";

        public S_SkinBackup()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
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
            column = new DataColumn
            {
                DataType = Type.GetType("System.String"),
                ColumnName = "SkinImage"
            };
            dt.Columns.Add(column);
            return dt;
        }

        protected string GetWebFilePath()
        {
            DataTable shopSimpleByMemID =
                ((Shop_ShopInfo_Action) LogicFactory.CreateShop_ShopInfo_Action()).GetShopSimpleByMemID(base.MemLoginID);
            string str = shopSimpleByMemID.Rows[0]["ShopID"].ToString();
            string str2 = DateTime.Parse(shopSimpleByMemID.Rows[0]["OpenTime"].ToString()).ToString("yyyy-MM-dd");
            string str3 = str2.Split(new[] {'-'})[0];
            string str4 = str2.Split(new[] {'-'})[1];
            string str5 = str2.Split(new[] {'-'})[2];
            return ("/shop/shop/" + str3 + "/" + str4 + "/" + str5 + "/shop" + str + "/");
        }

        protected override void InitializeSkin(Control skin)
        {
            RepeaterShow = (Repeater) skin.FindControl("RepeaterShow");
            RepeaterShow.ItemCommand += RepeaterShow_ItemCommand;
            LabelNameValue = (Label) skin.FindControl("LabelNameValue");
            LabelFolderNameValue = (Label) skin.FindControl("LabelFolderNameValue");
            LabelDescriptionValue = (Label) skin.FindControl("LabelDescriptionValue");
            ImageCurrentSkin = (Image) skin.FindControl("ImageCurrentSkin");
            LinkButton_BackUp = (LinkButton) skin.FindControl("LinkButton_BackUp");
            LinkButton_BackUp.Click += LinkButton_BackUp_Click;
            BindData();
            method_1();
        }

        protected void LinkButton_BackUp_Click(object sender, EventArgs e)
        {
            try
            {
                if (RepeaterShow.Items.Count >= 5)
                {
                    MessageBox.Show("您只能备份最近五次的模板,请删除以前的备份!");
                }
                else
                {
                    string webFilePath = GetWebFilePath();
                    string path = webFilePath + "Themes/Skin_Default/";
                    string str3 = webFilePath + "Themes/Skin_Default/Skin.xml";
                    string str5 =
                        XmlOperator.GetXmlData(Page.Server.MapPath(str3), "Skin").Tables[0].Rows[0]["name"].ToString();
                    string str6 = webFilePath + "BackUp/" + str5 + "(" + DateTime.Now.ToString("yyyy-MM-dd hh-mm-ss") +
                                  ").zip";
                    Thread.Sleep(20);
                    ShopNum1Zip.ZipFileDictory(Page.Server.MapPath(path), Page.Server.MapPath(str6), null);
                    MessageBox.Show("模板备份成功!");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("模板备份失败！");
            }
            finally
            {
                BindData();
            }
        }

        protected void BindData()
        {
            if (!Directory.Exists(Page.Server.MapPath(GetWebFilePath() + "BackUp/")))
            {
                try
                {
                    Directory.CreateDirectory(Page.Server.MapPath(GetWebFilePath() + "BackUp/"));
                }
                catch
                {
                    RepeaterShow.DataSource = null;
                    RepeaterShow.DataBind();
                    return;
                }
            }
            string[] files = Directory.GetFiles(Page.Server.MapPath(GetWebFilePath() + "BackUp/"), "*.Zip");
            DataTable table = CreateSkinTable();
            for (int i = 0; i < files.Length; i++)
            {
                DataRow row = table.NewRow();
                row["Guid"] = Guid.NewGuid();
                var info = new FileInfo(files[i]);
                row["createTime"] = info.CreationTime.ToString();
                row["Name"] = info.Name.Split(new[] {'.'})[0];
                row["SkinImage"] = GetWebFilePath() + "Themes/Skin_Default/skin.jpg";
                table.Rows.Add(row);
            }
            RepeaterShow.DataSource = table;
            RepeaterShow.DataBind();
        }

        protected void method_1()
        {
            DataTable memLoginInfo =
                ((Shop_ShopInfo_Action) LogicFactory.CreateShop_ShopInfo_Action()).GetMemLoginInfo(base.MemLoginID);
            string str = memLoginInfo.Rows[0]["ShopID"].ToString();
            string str2 = DateTime.Parse(memLoginInfo.Rows[0]["OpenTime"].ToString()).ToString("yyyy-MM-dd");
            string path = "~/Shop/Shop/" + str2.Replace("-", "/") + "/" + ShopSettings.GetValue("PersonShopUrl") + str +
                          "/Themes/Skin_Default/Skin.xml";
            string xmlPath = Page.Server.MapPath(path);
            try
            {
                foreach (DataRow row in XmlOperator.GetXmlData(xmlPath, "Skin").Tables[0].Rows)
                {
                    LabelNameValue.Text = row["name"].ToString().Trim();
                    LabelDescriptionValue.Text = row["description"].ToString().Trim();
                }
                ImageCurrentSkin.ImageUrl = "~/Shop/Shop/" + str2.Replace("-", "/") + "/" +
                                            ShopSettings.GetValue("PersonShopUrl") + str +
                                            "/Themes/Skin_Default/Skin.jpg";
            }
            catch
            {
            }
        }

        protected void RepeaterShow_ItemCommand(object sender, RepeaterCommandEventArgs e)
        {
            Label label;
            string str3;
            string webFilePath = GetWebFilePath();
            string dir = Page.Server.MapPath(webFilePath + "Themes/Skin_Default");
            if (e.CommandName == "select")
            {
                label = (Label) e.Item.FindControl("LabelNameValue");
                int num = 1;
                try
                {
                    Themes.DeleteFolder(dir);
                    Directory.CreateDirectory(dir);
                    if (Directory.Exists(dir))
                    {
                        str3 = webFilePath + "BackUp/" + label.Text + ".zip";
                        string path = webFilePath + "Themes/Skin_Default/";
                        string str5 = path + label.Text + ".zip";
                        if (!File.Exists(Page.Server.MapPath(str5)))
                        {
                            File.Copy(Page.Server.MapPath(str3), Page.Server.MapPath(str5));
                            Thread.Sleep(20);
                        }
                        ShopNum1UnZipClass.UnZip(Page.Server.MapPath(str5), Page.Server.MapPath(path), null);
                        File.Delete(Page.Server.MapPath(str5));
                    }
                }
                catch (Exception)
                {
                    num = -1;
                    MessageBox.Show("恢复模板失败！");
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
                str3 = webFilePath + "BackUp/" + label.Text + ".zip";
                try
                {
                    File.Delete(Page.Server.MapPath(str3));
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
    }
}