using System;
using System.Configuration;
using System.Data;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.Interface;
using ShopNum1.MultiBaseWebControl;
using System.Collections.Generic;
using ShopNum1.Common.ShopNum1.Common;

namespace ShopNum1.WebControl
{
    [ParseChildren(true)]
    public class MiddleNavigation : BaseWebControl
    {
        private Label LabelMemLoginID;
        private LinkButton LinkButtonLoginOut;
        private Literal LiteralCartCount;
        private Repeater RepterNav;
        private Literal literLi;
        private HtmlGenericControl login;
        private HtmlGenericControl loginOut;
        private HtmlGenericControl shopcart1;
        private HtmlGenericControl shopcart2;
        private string skinFilename = "MiddleNavigation.ascx";

        public MiddleNavigation()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public string ShowCount { get; set; }

        public string GetOverrideUrlName()
        {
            if (ShopSettings.IsOverrideUrl)
            {
                return ShopSettings.overrideUrlName;
            }
            return ".aspx";
        }

        protected override void InitializeSkin(Control skin)
        {
            literLi = (Literal) skin.FindControl("literLi");
            LiteralCartCount = (Literal) skin.FindControl("LiteralCartCount");
            login = (HtmlGenericControl) skin.FindControl("login");
            loginOut = (HtmlGenericControl) skin.FindControl("loginOut");
            shopcart1 = (HtmlGenericControl) skin.FindControl("shopcart1");
            shopcart2 = (HtmlGenericControl) skin.FindControl("shopcart2");
            LabelMemLoginID = (Label) skin.FindControl("LabelMemLoginID");
            LinkButtonLoginOut = (LinkButton) skin.FindControl("LinkButtonLoginOut");
            LinkButtonLoginOut.Click += LinkButtonLoginOut_Click;
            RepterNav = (Repeater) skin.FindControl("RepterNav");
            if (HttpContext.Current.Request.Cookies["MemberLoginCookie"] == null)
            {
                login.Visible = true;
                loginOut.Visible = false;
                LinkButtonLoginOut.Visible = false;
                shopcart1.Visible = true;
                shopcart2.Visible = false;
            }
            else
            {
                HttpCookie cookie = HttpContext.Current.Request.Cookies["MemberLoginCookie"];
                HttpCookie cookie2 = HttpSecureCookie.Decode(cookie);
                LabelMemLoginID.Text = cookie2.Values["MemLoginID"];
                login.Visible = false;
                loginOut.Visible = true;
                shopcart1.Visible = false;
                shopcart2.Visible = true;
                method_1(LabelMemLoginID.Text.Trim());
            }
            BindData();
        }

        protected void LinkButtonLoginOut_Click(object sender, EventArgs e)
        {
            HttpCookie cookie = Page.Request.Cookies["MemberLoginCookie"];
            if (HttpContext.Current.Request.Cookies["MemberLoginCookie"] != null)
            {
                HttpContext.Current.Request.Cookies["MemberLoginCookie"].Expires =
                    Convert.ToDateTime(DateTime.Now.AddDays(-5.0).ToString("yyyy-MM-dd HH:mm:ss"));
                cookie.Domain = ConfigurationManager.AppSettings["CookieDomain"];
                HttpContext.Current.Response.Cookies.Add(HttpContext.Current.Request.Cookies["MemberLoginCookie"]);
            }
            string url = GetPageName.RetDomainUrl("login");
            Page.Response.Redirect(url);
        }

        protected void BindData()
        {
            DataTable table = LogicFactory.CreateShopNum1_UserDefinedColumn_Action()
                .SearchMiddleNavigation("10", 1);
            HttpCookie cookie2 = HttpSecureCookie.Decode(Page.Request.Cookies["MemberLoginCookie"]);
            string MemRankGuid = null;
            string MemLinkCategory = null;
            if (cookie2 != null && cookie2.Values["MemRankGuid"] != null)
            {
                MemRankGuid = cookie2.Values["MemRankGuid"];
            }
            else
            {
                MemRankGuid = ShopNum1.Common.ShopNum1.Common.MemberLevel.NORMAL_MEMBER_ID;
            }
            DataTable linkCategory = LogicFactory.CreateMemberRank_LinkCategory_Action().GetRankLinkCategoryByID(MemRankGuid, "1");
            if (linkCategory.Rows.Count > 0)
            {
                MemLinkCategory = linkCategory.Rows[0]["Category_ID"].ToString();
            }
            if (table != null)
            {
                List<string> allowRead = new List<string>() { "0" };
                allowRead.AddRange(MemLinkCategory.Split(','));

                var builder = new StringBuilder();

                builder.AppendLine("<ul>");
                string str2 = string.Empty;
                if (Page.Request.QueryString["tag"] != null)
                {
                    str2 = Page.Request.QueryString["tag"];
                }

                int isFirstRun = 0;
                //foreach (string strCategory in allowRead)
                //{
                    int category = Convert.ToInt32(0);
                    UserDefinedColumnVisit visit = new UserDefinedColumnVisit();
                    string cateGuid = visit.VisitColumns[category.ToString()];


                    if ((category >= 4 && category <= 7) && isFirstRun == 0)
                    {
                        category = 4;

                        builder.AppendLine("<li>");
                        DataRow tmpRow = table.Select(string.Format("GUID = '{0}'", cateGuid))[0];
                        string tmpStr = tmpRow["LinkAddress"].ToString();

                        if (tmpStr.Contains("http://"))
                        {
                            if (tmpStr.Contains("?"))
                            {
                                builder.Append(string.Concat(new object[] { "<a id=lia style='font-size:20px;font-family:黑体;' ", category, " href='", tmpStr, "'" }));
                            }
                            else
                            {
                                builder.Append(string.Concat(new object[] { "<a id=lia  style='font-size:20px;font-family:黑体;' ", category, " href='", tmpStr, "'" }));
                            }
                        }
                        else
                        {
                            builder.Append(
                                string.Concat(new object[]
                            {
                                "<a id=lia  style='font-size:20px;font-family:黑体;' ", category, " href='http://", ShopSettings.siteDomain, "/", tmpStr,
                                GetOverrideUrlName(), "?tag=", category, "'"
                            }));
                        }
                        if ((str2 == string.Empty) && (Page.Request.RawUrl.ToLower().Contains("default") && (category == 0)))
                        {
                            builder.Append(" class=\"curr\" ");
                            builder.Append("  style='font-size:20px;font-family:黑体;' target='" + method_2(tmpRow["IfOpen"].ToString()) + "'>");
                            builder.Append(tmpRow["Name"] + "</a>");
                            builder.AppendLine("</li>");
                        }
                        else
                        {
                            if (str2 == category.ToString())
                            {
                                builder.Append(" class=\"curr\" ");
                            }
                            else
                            {
                                builder.Append("  style='font-size:20px;font-family:黑体;'");
                            }
                            builder.Append(" target='" + method_2(tmpRow["IfOpen"].ToString()) + "'>");
                            builder.Append(tmpRow["Name"] + "</a>");
                            builder.AppendLine("</li>");
                        }
                        isFirstRun = category;
                    }
                    else if (category < 4 || category > 7)
                    {
                        builder.AppendLine("<li>");
                        DataRow row = table.Select(string.Format("GUID = '{0}'", cateGuid))[0];
                        string str = row["LinkAddress"].ToString();

                        if (str.Contains("http://"))
                        {
                            if (str.Contains("?"))
                            {
                                builder.Append(string.Concat(new object[] { "<a id=lia  style='font-size:20px;font-family:黑体;' ", category, " href='", str, "'" }));
                            }
                            else
                            {
                                builder.Append(string.Concat(new object[] { "<a id=lia  style='font-size:20px;font-family:黑体;' ", category, " href='", str, "'" }));
                            }
                        }
                        else
                        {
                            builder.Append(
                                string.Concat(new object[]
                            {
                                "<a id=lia  style='font-size:20px;font-family:黑体;' ", category, " href='http://", ShopSettings.siteDomain, "/", str,
                                GetOverrideUrlName(), "?tag=", category, "'"
                            }));
                        }
                        if ((str2 == string.Empty) && (Page.Request.RawUrl.ToLower().Contains("default") && (category == 0)))
                        {
                            builder.Append(" class=\"curr\" ");
                            builder.Append(" target='" + method_2(row["IfOpen"].ToString()) + "'>");
                            builder.Append(row["Name"] + "</a>");
                            builder.AppendLine("</li>");
                        }
                        else
                        {
                            if (str2 == category.ToString())
                            {
                                builder.Append(" class=\"curr\" ");
                            }
                            else
                            {
                                builder.Append(" style='font-size:20px;font-family:黑体;'");
                            }
                            builder.Append(" target='" + method_2(row["IfOpen"].ToString()) + "'>");
                            builder.Append(row["Name"] + "</a>");
                            builder.AppendLine("</li>");
                        }
                    }
                //}
                var dataSet = new DataSet();
                dataSet.ReadXml(HttpContext.Current.Server.MapPath("~/Settings/ShopSetting.xml"));
                DataRow dataRow = dataSet.Tables["ShopSetting"].Rows[0];
                string INDEXURL = dataRow["CopyrightLink"].ToString();

                //builder.AppendLine("<li><a  href='" + INDEXURL + "/MoreShop.aspx' style='font-size:20px;font-family:黑体;' target='_self'>会员网店</a></li>");


                builder.AppendLine("</ul>");
                literLi.Text = builder.ToString();
            }
        }

        protected void method_1(string string_2)
        {
            if (LiteralCartCount != null)
            {
                IShopNum1_Cart_Action action = LogicFactory.CreateShopNum1_Cart_Action();
                LiteralCartCount.Text = action.GetMemCartCount(string_2).ToString();
            }
        }

        private string method_2(string string_2)
        {
            if (string_2 == "0")
            {
                string_2 = "_self";
                return string_2;
            }
            if (string_2 == "1")
            {
                string_2 = "_blank";
            }
            return string_2;
        }
    }
}