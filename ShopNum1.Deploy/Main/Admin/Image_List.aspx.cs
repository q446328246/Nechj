using System;
using System.Data;
using System.IO;
using System.Web;
using System.Web.SessionState;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1MultiEntity;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class Image_List : PageBase, IRequiresSessionState
    {
        protected char charSapce = '　';

        private int int_0;
        protected string strSapce = "　　";

        private string string_4 = "Image_List.aspx";
        private string string_5;
        private string string_6 = string.Empty;
        private string string_7;
        public string ImageSpec { get; set; }

        public int ShowCount { get; set; }

        protected void BindImage()
        {
            if (int_0 <= 0)
            {
                int_0 = 1;
            }
            var pl = new PageList1
                {
                    PageSize = ShowCount,
                    PageID = int_0
                };
            var action = (ShopNum1_Image_Action)LogicFactory.CreateShopNum1_Image_Action();
            DataTable table = action.SearchImageByType(string_6, string_5, 0, string_7, ShowCount.ToString(),
                                                       int_0.ToString(), "1");
            if ((table != null) && (table.Rows.Count > 0))
            {
                pl.RecordCount = Convert.ToInt32(table.Rows[0][0]);
            }
            else
            {
                pl.RecordCount = 0;
            }
            pageDiv.InnerHtml =
                new PageListBll("main/admin/Image_List", true, "2")
                    {
                        ShowRecordCount = true,
                        ShowPageCount = true,
                        ShowPageIndex = true,
                        ShowNoRecordInfo = false,
                        ShowNumListButton = true,
                        PrevPageText = "<<上一页",
                        NextPageText = "下一页>> "
                    }.GetPageListVk(pl);
            DataTable table2 = action.SearchImageByType(string_6, string_5, 0, string_7, ShowCount.ToString(),
                                                        int_0.ToString(), "0");
            DataListShow.DataSource = table2;
            DataListShow.DataBind();
        }

        protected void BindImageCategory()
        {
            DropDownListImgCategory1.Items.Clear();
            var item = new ListItem
                {
                    Text = "-全部-",
                    Value = "0"
                };
            DropDownListImgCategory1.Items.Add(item);
            var action = (ShopNum1_ImageCategory_Action)LogicFactory.CreateShopNum1_ImageCategory_Action();
            foreach (DataRow row in action.Search(0).DefaultView.Table.Rows)
            {
                var item2 = new ListItem();
                if (Common.Common.ReqStr("category") == row["ID"].ToString())
                {
                    item2.Selected = true;
                }
                item2.Text = row["Name"].ToString().Trim();
                item2.Value = row["ID"].ToString().Trim();
                DropDownListImgCategory1.Items.Add(item2);
            }
        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            HttpCookie cookie = base.Request.Cookies["AdminLoginCookie"];
            HttpCookie cookie2 = HttpSecureCookie.Decode(cookie);
            var action = (ShopNum1_Image_Action)LogicFactory.CreateShopNum1_Image_Action();
            string guids = CheckGuid.Value.Replace(",'on'", "");
            string str2 = CheckImgPath.Value;
            try
            {
                ShopNum1_OperateLog log;
                string path = string.Empty;
                string str4 = string.Empty;
                string str5 = string.Empty;
                string str6 = string.Empty;
                if (str2.IndexOf(",") != -1)
                {
                    string[] strArray = str2.Split(new[] { ',' });
                    for (int i = 0; i < strArray.Length; i++)
                    {
                        path = base.Server.MapPath(strArray[i]);
                        str4 = path.Substring(0, path.LastIndexOf("/") + 1);
                        str5 = path.Substring(path.LastIndexOf("/") + 1, (path.Length - path.LastIndexOf("/")) - 1);
                        if (File.Exists(path))
                        {
                           

                            log = new ShopNum1_OperateLog
                                {
                                    Record = "删除图片成功",
                                    OperatorID = cookie2.Values["LoginID"].ToString(),
                                    IP = Globals.IPAddress,
                                    PageName = "Image_List.aspx",
                                    Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                                };
                            base.OperateLog(log);
                            File.Delete(path);
                            MessageShow.ShowMessage("DelYes");
                            MessageShow.Visible = true;
                        }
                        else
                        {
                            MessageShow.ShowMessage("DelNo");
                            MessageShow.Visible = false;
                        }
                    }
                }
                else
                {
                    path = str2;
                    str4 = path.Substring(0, path.LastIndexOf("/") + 1);
                    str5 = path.Substring(path.LastIndexOf("/") + 1, (path.Length - path.LastIndexOf("/")) - 1);
                    str6 = str4 + "s_" + str5;
                    path = base.Server.MapPath(path);
                    str6 = base.Server.MapPath(str6);
                    if (File.Exists(path))
                    {
                        log = new ShopNum1_OperateLog
                            {
                                Record = "删除图片成功",
                                OperatorID = cookie2.Values["LoginID"].ToString(),
                                IP = Globals.IPAddress,
                                PageName = "Image_List.aspx",
                                Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                            };
                        base.OperateLog(log);
                        File.Delete(path);
                        MessageShow.ShowMessage("DelYes");
                        MessageShow.Visible = true;
                    }
                    else
                    {
                        MessageShow.ShowMessage("DelNo");
                        MessageShow.Visible = false;
                    }
                }
            }
            catch (Exception)
            {
                MessageShow.ShowMessage("DelNo");
                MessageShow.Visible = true;
            }
            action.Delete(guids);
            BindImage();
        }

        protected void ButtonIndex_Click(object sender, EventArgs e)
        {
            try
            {
                int.TryParse(TextBoxIndex.Text.Trim(), out int_0);
            }
            catch
            {
                int_0 = 1;
            }
            Page.Response.Redirect(
                string.Concat(new object[]
                    {
                        string_4, "?name=", string_5, "&category=", string_7, "&size=", ShowCount, "&pageid=",
                        int_0.ToString()
                    }));
        }

        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            Page.Response.Redirect(
                string.Concat(new object[]
                    {
                        string_4, "?name=", TextBoxSName.Text.Trim(), "&category=", DropDownListImgCategory1.SelectedValue,
                        "&size=", ShowCount.ToString(), "&pageid=", 1
                    }));
        }

        protected void DataListShow_ItemCommand(object sender, DataListCommandEventArgs e)
        {
            HiddenField field;
            ShopNum1_Image_Action action;
            if (e.CommandName == "select")
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>loadwindow2(800,600);</script>",
                                                        false);
                field = (HiddenField)e.Item.FindControl("HiddenFieldGuid");
                action = (ShopNum1_Image_Action)LogicFactory.CreateShopNum1_Image_Action();
                DataTable table = action.Search("'" + field.Value.Replace(",'on'", "") + "'");
                if ((table != null) && (table.Rows.Count > 0))
                {
                    HiddenFieldBianji.Value = field.Value;
                }
            }
            else if (e.CommandName == "delete")
            {
                field = (HiddenField)e.Item.FindControl("HiddenFieldGuid");
                action = (ShopNum1_Image_Action)LogicFactory.CreateShopNum1_Image_Action();
                string path = HiddenFieldPath.Value;
                string str3 = path.Substring(0, path.LastIndexOf("/") + 1);
                string str4 = path.Substring(path.LastIndexOf("/") + 1, (path.Length - path.LastIndexOf("/")) - 1);
                string str2 = str3 + "s_" + str4;
                try
                {
                    path = base.Server.MapPath(path);
                    str2 = base.Server.MapPath(str2);
                    if (File.Exists(path))
                    {
                        File.Delete(path);
                        File.Delete(str2);
                    }
                    MessageShow.ShowMessage("DelYes");
                    MessageShow.Visible = true;
                }
                catch (Exception)
                {
                    MessageShow.ShowMessage("DelNo");
                    MessageShow.Visible = true;
                }
                action.Delete("'" + field.Value.Replace(",'on'", "") + "'");
                BindImage();
            }
        }

        protected void DropDownListImgCategory1_SelectedIndexChanged(object sender, EventArgs e)
        {
            base.Response.Redirect(string.Format("Image_List.aspx?category={0}&PageID=1",
                                                 DropDownListImgCategory1.SelectedValue));
        }

        protected void LinkButton10_Click(object sender, EventArgs e)
        {
            LinkButton10.CssClass = "cur";
            Page.Response.Redirect(
                string.Concat(new object[] { string_4, "?name=", string_5, "&category=", string_7, "&size=", 10, "&pageid=", int_0 }));
        }

        protected void LinkButton100_Click(object sender, EventArgs e)
        {
            LinkButton100.CssClass = "cur";
            Page.Response.Redirect(
                string.Concat(new object[] { string_4, "?name=", string_5, "&category=", string_7, "&size=", 100, "&pageid=", int_0 }));
        }

        protected void LinkButton20_Click(object sender, EventArgs e)
        {
            LinkButton20.CssClass = "cur";
            Page.Response.Redirect(
                string.Concat(new object[] { string_4, "?name=", string_5, "&category=", string_7, "&size=", 20, "&pageid=", int_0 }));
        }

        private void method_5(DataTable dt)
        {
            var action = (ShopNum1_ImageCategory_Action)LogicFactory.CreateShopNum1_ImageCategory_Action();
            foreach (DataRow row in dt.Rows)
            {
                var item = new ListItem();
                string str = string.Empty;
                for (int i = 0; i < (Convert.ToInt32(row["CategoryLevel"].ToString()) - 1); i++)
                {
                    str = str + strSapce;
                }
                str = str + row["Name"].ToString().Trim();
                item.Text = str;
                item.Value = row["ID"].ToString().Trim();
                DropDownListImgCategory1.Items.Add(item);
                DataTable table = action.Search(Convert.ToInt32(row["ID"].ToString().Trim()));
                if (table.Rows.Count > 0)
                {
                    method_5(table);
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            int_0 = (Page.Request.QueryString["pageid"] == null) ? 1 : int.Parse(Page.Request.QueryString["pageid"]);
            string_5 = (Page.Request.QueryString["name"] == null) ? "" : Page.Request.QueryString["name"];
            string_7 = (Page.Request.QueryString["category"] == null) ? "0" : Page.Request.QueryString["category"];
            ShowCount = (Page.Request.QueryString["size"] == null) ? 10 : int.Parse(Page.Request.QueryString["size"]);
            if (!Page.IsPostBack)
            {
                return;
            }
            BindImageCategory();
            BindImage();
            TextBoxSName.Text = Common.Common.ReqStr("name");
            string str2 = (Common.Common.ReqStr("size") == "") ? "10" : Common.Common.ReqStr("size");
            switch (str2)
            {
                case null:
                    break;

                case "10":
                    LinkButton10.CssClass = "cur";
                    goto Label_01E0;

                default:
                    if (!(str2 == "20"))
                    {
                        if (!(str2 == "100"))
                        {
                            break;
                        }
                        LinkButton100.CssClass = "cur";
                    }
                    else
                    {
                        LinkButton20.CssClass = "cur";
                    }
                    goto Label_01E0;
            }
            LinkButton10.CssClass = "cur";
        Label_01E0:
            if (Common.Common.ReqStr("id") != "")
            {
                ((ShopNum1_Image_Action)LogicFactory.CreateShopNum1_Image_Action()).UpdateName(
                    Common.Common.ReqStr("id"), HttpUtility.HtmlDecode(Common.Common.ReqStr("name")));
            }
        }
    }
}