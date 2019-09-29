using System;
using System.Data;
using System.IO;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;
using System.Web;

namespace ShopNum1.ShopAdminWebControl
{
    [ParseChildren(true)]
    public class S_SkinSelect : BaseShopWebControl
    {
        private Image ImageCurrentSkin;
        private Label LabelDescriptionValue;
        private Label LabelFolderNameValue;
        private Label LabelNameValue;
        private Repeater Rep_SkinSelect;
        private DataTable dt;
        private string skinFilename = "S_SkinSelect.ascx";

        public S_SkinSelect()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        protected string openTime { get; set; }

        protected string shopid { get; set; }

        protected string ShopRank { get; set; }

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

        public void GetAllSkins()
        {

            //HttpCookie cookie = Page.Request.Cookies["MemberLoginCookie"];
            //HttpCookie cookie2 = HttpSecureCookie.Decode(cookie);
            //string  MemberLoginID = cookie2.Values["MemLoginID"];
            //DataTable menlgoin =
            //    ((Shop_Rank_Action)LogicFactory.CreateShop_Rank_Action()).SlecetLeveleIDByMengoinID(MemberLoginID);
            //int levelID = Convert.ToInt32(menlgoin.Rows[0]["LevelID"]);
            DataTable templateByRankGuid =
                ((Shop_Rank_Action) LogicFactory.CreateShop_Rank_Action()).GetTemplateByRankGuid(ShopRank);
            if ((templateByRankGuid != null) && (templateByRankGuid.Rows.Count > 0))
            {
                Rep_SkinSelect.DataSource = templateByRankGuid.DefaultView;
                Rep_SkinSelect.DataBind();
            }
        }

        protected string GetWebFilePath()
        {
            string str = openTime.Split(new[] {'-'})[0];
            string str2 = openTime.Split(new[] {'-'})[1];
            string str3 = openTime.Split(new[] {'-'})[2];
            return ("~/shop/shop/" + str + "/" + str2 + "/" + str3 + "/shop" + shopid + "/Themes/Skin_Default/");
        }

        protected override void InitializeSkin(Control skin)
        {
            LabelFolderNameValue = (Label) skin.FindControl("LabelFolderNameValue");
            LabelNameValue = (Label) skin.FindControl("LabelNameValue");
            LabelDescriptionValue = (Label) skin.FindControl("LabelDescriptionValue");
            ImageCurrentSkin = (Image) skin.FindControl("ImageCurrentSkin");
            Rep_SkinSelect = (Repeater) skin.FindControl("Rep_SkinSelect");
            Rep_SkinSelect.ItemCommand += Rep_SkinSelect_ItemCommand;
            try
            {
                DataTable shopSimpleByMemID =
                    ((Shop_ShopInfo_Action) LogicFactory.CreateShop_ShopInfo_Action()).GetShopSimpleByMemID(
                        base.MemLoginID);
                shopid = shopSimpleByMemID.Rows[0]["ShopID"].ToString();
                openTime = DateTime.Parse(shopSimpleByMemID.Rows[0]["OpenTime"].ToString()).ToString("yyyy-MM-dd");
                ShopRank = shopSimpleByMemID.Rows[0]["ShopRank"].ToString();
                CreateSkinTable();
                BindData();
                GetAllSkins();
            }
            catch (Exception exception)
            {
                Page.Response.Write(exception.Message);
            }
        }

        protected void BindData()
        {
            string xmlPath = Page.Server.MapPath(GetWebFilePath()) + "Skin.xml";
            DataSet xmlData = XmlOperator.GetXmlData(xmlPath, "Skin");
            if (File.Exists(xmlPath))
            {
                foreach (DataRow row in xmlData.Tables[0].Rows)
                {
                    LabelNameValue.Text = row["name"].ToString().Trim();
                    LabelDescriptionValue.Text = row["description"].ToString().Trim();
                    LabelFolderNameValue.Text = row["description"].ToString().Trim();
                }
                ImageCurrentSkin.ImageUrl = GetWebFilePath() + "Skin.jpg";
            }
        }

        protected void method_1(string string_4)
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
                        method_1(str);
                    }
                }
                Directory.Delete(string_4, true);
            }
        }

        protected void Rep_SkinSelect_ItemCommand(object sender, RepeaterCommandEventArgs e)
        {
            try
            {
                Label label;
                Label label2;
                int num;
                Exception exception;
                if (e.CommandName == "select")
                {
                    label = (Label) e.Item.FindControl("LabelNameValue");
                    label2 = (Label) e.Item.FindControl("LabelDescriptionValue");
                    var label1 = (Label) e.Item.FindControl("LabelSkinNameValue");
                    var hidden = (HtmlInputHidden) e.Item.FindControl("hidPath");
                    num = 1;
                    //if (label.Text == LabelNameValue.Text)
                    //{
                    //    MessageBox.Show("正在使用该模版！");
                    //}
                    //else
                    //{
                        try
                        {
                            if (!File.Exists(Page.Server.MapPath("/Template/ShopTemplate/" + hidden.Value) + "zz"))
                            {
                                num = -1;
                                MessageBox.Show("当前模板不存在，请检查服务器文件！");
                                return;
                            }
                            string webFilePath = GetWebFilePath();
                            method_1(Page.Server.MapPath(webFilePath));
                            if (!Directory.Exists(Page.Server.MapPath(webFilePath)))
                            {
                                Directory.CreateDirectory(Page.Server.MapPath(webFilePath));
                            }
                            string path = GetWebFilePath().Replace("Skin_Default", "backUp");
                            if (!Directory.Exists(Page.Server.MapPath(path)))
                            {
                                Directory.CreateDirectory(Page.Server.MapPath(path));
                            }
                            path = path + hidden.Value + "zz";
                            if (File.Exists(Page.Server.MapPath(path)))
                            {
                                File.Delete(Page.Server.MapPath(path));
                            }
                            if (!File.Exists(Page.Server.MapPath(path)))
                            {
                                File.Copy(Page.Server.MapPath("/Template/ShopTemplate/" + hidden.Value) + "zz",
                                    Page.Server.MapPath(path));
                            }
                            ShopNum1UnZipClass.UnZip(Page.Server.MapPath(path), Page.Server.MapPath(webFilePath), "");
                            File.Delete(Page.Server.MapPath(path));
                        }
                        catch (Exception exception1)
                        {
                            exception = exception1;
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
              //  }
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
                            method_1(Page.Server.MapPath("~/Main/Skin/Master/" + label2.Text.Trim() + "/"));
                            GetAllSkins();
                        }
                        catch (Exception exception2)
                        {
                            exception = exception2;
                            MessageBox.Show(exception.Message);
                            MessageBox.Show("应用模板失败！");
                        }
                    }
                }
            }
            catch
            {
            }
        }
    }
}