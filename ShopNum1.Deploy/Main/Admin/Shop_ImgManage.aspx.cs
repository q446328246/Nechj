using System;
using System.Data;
using System.IO;
using System.Text;
using System.Web;
using System.Web.SessionState;
using System.Web.UI.WebControls;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.ShopBusinessLogic;
using ShopNum1MultiEntity;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class Shop_ImgManage : PageBase, IRequiresSessionState
    {
        public string Name;
        public int pageID;
        public string strPageSize = "10";

        private string string_4 = string.Empty;
        private string string_7;
        public string ImageSpec { get; set; }

        public int ShowCount { get; set; }


        protected void BindImage()
        {
            if (pageID <= 0)
            {
                pageID = 1;
            }
            var pl = new PageList1
                {
                    PageSize = ShowCount,
                    PageID = pageID
                };
            var action = (Shop_Image_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_Image_Action();
            DataSet set = action.MangeShopImg(strPageSize, pageID.ToString(), BindData(), "0");
            if (set != null)
            {
                selectShop.Items.Clear();
                pl.RecordCount = Convert.ToInt32(set.Tables[0].Rows[0][0]);
                if (pl.RecordCount < 10)
                {
                    showpage.Visible = false;
                }
                lblCount.Text = (set.Tables[1].Rows[0][0].ToString() == "") ? "0" : set.Tables[1].Rows[0][0].ToString();
                DataTable table = set.Tables[2];
                var item2 = new ListItem
                    {
                        Text = "-全部-",
                        Value = "0"
                    };
                selectShop.Items.Add(item2);
                if (table.Rows.Count > 0)
                {
                    DataView defaultView = table.DefaultView;
                    var item = new ListItem();
                    foreach (DataRow row in defaultView.Table.Rows)
                    {
                        if ((row["createuser"].ToString() != "admin") && (row["shopid"].ToString().Trim() != ""))
                        {
                            item = new ListItem();
                            if (string_7 == row["shopid"].ToString())
                            {
                                item.Selected = true;
                            }
                            item.Text = row["createuser"].ToString().Trim();
                            item.Value = row["shopid"].ToString().Trim();
                            selectShop.Items.Add(item);
                        }
                    }
                }
            }
            else
            {
                showpage.Visible = false;
                pl.RecordCount = 0;
            }
            pageDiv.InnerHtml =
                new PageListBll(string_4.Replace(".aspx", ""), true, "2")
                    {
                        ShowRecordCount = true,
                        ShowPageCount = true,
                        ShowPageIndex = true,
                        ShowNoRecordInfo = false,
                        ShowNumListButton = true,
                        PrevPageText = "<<上一页",
                        NextPageText = "下一页>> "
                    }.GetPageListVk(pl);
            DataSet set2 = action.MangeShopImg(strPageSize, pageID.ToString(), BindData(), "1");
            DataListShow.DataSource = set2.Tables[0];
            DataListShow.DataBind();
        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            var action = (Shop_Image_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_Image_Action();
            string strID = CheckGuid.Value.Replace(",'on'", "");
            string str2 = CheckImgPath.Value;
            try
            {
                string str5;
                string str6;
                string str7;
                string str8;
                string str9;
                string path = string.Empty;
                if (str2.IndexOf(",") != -1)
                {
                    foreach (string str4 in str2.Split(new[] {','}))
                    {
                        path = base.Server.MapPath(str4);
                        str5 = str4 + "_25x25.jpg";
                        str6 = str4 + "_60x60.jpg";
                        str7 = str4 + "_100x100.jpg";
                        str8 = str4 + "_160x160.jpg";
                        str9 = str4 + "_300x300.jpg";
                        if (File.Exists(path))
                        {
                            File.Delete(path);
                            File.Delete(base.Server.MapPath(str5));
                            File.Delete(base.Server.MapPath(str6));
                            File.Delete(base.Server.MapPath(str7));
                            File.Delete(base.Server.MapPath(str8));
                            File.Delete(base.Server.MapPath(str9));
                        }
                    }
                }
                else
                {
                    path = str2;
                    str5 = str2 + "_25x25.jpg";
                    str6 = str2 + "_60x60.jpg";
                    str7 = str2 + "_100x100.jpg";
                    str8 = str2 + "_160x160.jpg";
                    str9 = str2 + "_300x300.jpg";
                    path = base.Server.MapPath(path);
                    if (File.Exists(path))
                    {
                        File.Delete(path);
                        File.Delete(base.Server.MapPath(str5));
                        File.Delete(base.Server.MapPath(str6));
                        File.Delete(base.Server.MapPath(str7));
                        File.Delete(base.Server.MapPath(str8));
                        File.Delete(base.Server.MapPath(str9));
                    }
                }
                var operateLog = new ShopNum1_OperateLog
                    {
                        Record = "管理员删除店铺图片",
                        OperatorID = base.ShopNum1LoginID,
                        IP = Globals.IPAddress,
                        PageName = "Shop_ImgManage.aspx",
                        Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                    };
                base.OperateLog(operateLog);
                MessageShow.ShowMessage("DelYes");
                MessageShow.Visible = true;
            }
            catch (Exception)
            {
                MessageShow.ShowMessage("DelNo");
                MessageShow.Visible = true;
            }
            action.DeleteShopImg(strID);
            BindImage();
        }

        protected void ButtonIndex_Click(object sender, EventArgs e)
        {
            try
            {
                int.TryParse(TextBoxIndex.Text.Trim(), out pageID);
            }
            catch
            {
                pageID = 1;
            }
            Page.Response.Redirect(
                string.Concat(new object[]
                    {string_4, "?name=", Name, "&shopid=", string_7, "&size=", ShowCount, "&pageid=", pageID.ToString()}));
        }

        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            Page.Response.Redirect(
                string.Concat(new object[]
                    {
                        string_4, "?name=", TextBoxSName.Text.Trim(), "&sid=", string_7, "&size=", ShowCount.ToString(),
                        "&pageid=", 1
                    }));
        }

        protected void DataListShow_ItemCommand(object sender, DataListCommandEventArgs e)
        {
            if (e.CommandName == "delete")
            {
                var field = (HiddenField) e.Item.FindControl("HiddenFieldGuid");
                var field2 = (HiddenField) e.Item.FindControl("HiddenFieldPath");
                var action = (Shop_Image_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_Image_Action();
                string path = field2.Value;
                string str2 = path.Substring(0, path.LastIndexOf("/") + 1);
                string str3 = path.Substring(path.LastIndexOf("/") + 1, (path.Length - path.LastIndexOf("/")) - 1);
                string str4 = str2 + "s_" + str3;
                int num = 1;
                try
                {
                    path = base.Server.MapPath(path);
                    str4 = base.Server.MapPath(str4);
                    if (File.Exists(path))
                    {
                        File.Delete(path);
                        File.Delete(str4);
                    }
                    var operateLog = new ShopNum1_OperateLog
                        {
                            Record = "管理员删除店铺图片",
                            OperatorID = base.ShopNum1LoginID,
                            IP = Globals.IPAddress,
                            PageName = "Shop_ImgManage.aspx",
                            Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                        };
                    base.OperateLog(operateLog);
                    MessageShow.ShowMessage("DelYes");
                    MessageShow.Visible = true;
                }
                catch (Exception)
                {
                    MessageShow.ShowMessage("删除失败,请检查文件权限！");
                    MessageShow.Visible = true;
                }
                if (num > 0)
                {
                    num = action.DeleteShopImg(field.Value);
                    BindImage();
                }
            }
        }

        protected void LinkButton10_Click(object sender, EventArgs e)
        {
            LinkButton10.CssClass = "cur";
            Page.Response.Redirect(
                string.Concat(new object[]
                    {string_4, "?name=", Name, "&sid=", string_7, "&size=", 10, "&pageid=", pageID}));
        }

        protected void LinkButton100_Click(object sender, EventArgs e)
        {
            LinkButton100.CssClass = "cur";
            Page.Response.Redirect(
                string.Concat(new object[]
                    {string_4, "?name=", Name, "&sid=", string_7, "&size=", 100, "&pageid=", pageID}));
        }

        protected void LinkButton20_Click(object sender, EventArgs e)
        {
            LinkButton20.CssClass = "cur";
            Page.Response.Redirect(
                string.Concat(new object[]
                    {string_4, "?name=", Name, "&sid=", string_7, "&size=", 20, "&pageid=", pageID}));
        }

        private string BindData()
        {
            var builder = new StringBuilder();
            string str = HttpUtility.HtmlDecode(Common.Common.ReqStr("name"));
            if (str != "")
            {
                builder.Append(" and name like '%" + str + "%'");
            }
            if (string_7 != "0")
            {
                builder.Append(" and shopid='" + string_7 + "'");
            }
            return builder.ToString();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            string_4 = base.Request.RawUrl;
            if (string_4.IndexOf("?") != -1)
            {
                string_4 = string_4.Split(new[] {'?'})[0];
            }
            pageID = (Page.Request.QueryString["pageid"] == null) ? 1 : int.Parse(Page.Request.QueryString["pageid"]);
            Name = (Page.Request.QueryString["name"] == null) ? "" : Page.Request.QueryString["name"];
            ShowCount = (Page.Request.QueryString["size"] == null) ? 10 : int.Parse(Page.Request.QueryString["size"]);
            string_7 = (Page.Request.QueryString["sid"] == null) ? "0" : Page.Request.QueryString["sid"];
            lblCount.Text = "0";
            this.strPageSize = (Common.Common.ReqStr("size") == "") ? "10" : Common.Common.ReqStr("size");
            string strPageSize = this.strPageSize;
            switch (strPageSize)
            {
                case null:
                    break;

                case "10":
                    LinkButton10.CssClass = "cur";
                    goto Label_020F;

                default:
                    if (!(strPageSize == "20"))
                    {
                        if (!(strPageSize == "100"))
                        {
                            break;
                        }
                        LinkButton100.CssClass = "cur";
                    }
                    else
                    {
                        LinkButton20.CssClass = "cur";
                    }
                    goto Label_020F;
            }
            LinkButton10.CssClass = "cur";
            Label_020F:
            if (!Page.IsPostBack)
            {
                TextBoxSName.Text = Common.Common.ReqStr("name");
                BindImage();
            }
        }
    }
}