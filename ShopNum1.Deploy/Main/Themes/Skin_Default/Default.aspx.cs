using System;
using System.Data;
using System.Text;
using System.Web.UI;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using System.Web;
using ShopNum1.Common.ShopNum1.Common;
using System.Collections.Generic;


namespace ShopNum1.Deploy.Main.Themes.Skin_Default
{
    //public partial class Default : System.Web.UI.Page
    //{
    //    public string ShowCount { get; set; }

    //    public string ShowTwoCount { get; set; }

    //    public string GetOverrideUrlName()
    //    {
    //        if (ShopSettings.IsOverrideUrl)
    //        {
    //            return ShopSettings.overrideUrlName;
    //        }
    //        return ".aspx";
    //    }

    //    protected void Page_Load(object sender, EventArgs e)
    //    {
    //        if (!Page.IsPostBack)
    //        {
    //            BindData();
                
    //        }
    //        HttpCookie cookie = new HttpCookie("category", Convert.ToInt32(CustomerCategory.大唐专区).ToString());
    //        cookie.Domain = ".bb.qhtj88.com";
    //        cookie.Path = @"/";
    //        cookie.Expires = DateTime.Now.AddDays(1);
    //        Response.Cookies.Add(cookie);
    //        ///Shop/Shop/2014/07/29/shop100000027/Default.aspx?shopId=100000027
            
            

    //    }

    //    private void BindData()
    //    {
    //        BindMenu();

    //        BindProductCategory();
    //    }


    //    private void BindMenu()
    //    {
    //        DataTable table = LogicFactory.CreateShopNum1_UserDefinedColumn_Action()
    //            .SearchMiddleNavigation("10", 1);
    //        HttpCookie cookie2 = HttpSecureCookie.Decode(Page.Request.Cookies["MemberLoginCookie"]);
    //        string MemRankGuid = null;
    //        string MemLinkCategory = null;
    //        if (cookie2 != null && cookie2.Values["MemRankGuid"] != null)
    //        {
    //            MemRankGuid = cookie2.Values["MemRankGuid"];
    //        }
    //        else
    //        {
    //            MemRankGuid = ShopNum1.Common.ShopNum1.Common.MemberLevel.VISITOR_MEMBER_ID;
    //        }
    //        DataTable linkCategory = LogicFactory.CreateMemberRank_LinkCategory_Action().GetRankLinkCategoryByID(MemRankGuid, "1");
    //        if (linkCategory.Rows.Count > 0)
    //        {
    //            MemLinkCategory = linkCategory.Rows[0]["Category_ID"].ToString();
    //        }
    //        if (table != null)
    //        {
    //            List<string> allowRead = new List<string>() { "0" };
    //            allowRead.AddRange(MemLinkCategory.Split(','));

    //            var builder = new StringBuilder();
    //            builder.AppendLine("<span id='MiddleNavigationControl_MiddleNavigation'>");
    //            builder.AppendLine("<div id='mallNav'>");
    //            builder.AppendLine("    <div class='mallNav_con'>");
    //            builder.AppendLine("<div id='allTextNav' class='clearfix'>");
    //            builder.AppendLine("<div class='mallNav_main nall_hid' id='NavJson'>");

    //            builder.AppendLine("<ul>");
    //            string str2 = string.Empty;
    //            if (Page.Request.QueryString["tag"] != null)
    //            {
    //                str2 = Page.Request.QueryString["tag"];
    //            }

    //            int isFirstRun = 0;
    //            foreach (string strCategory in allowRead)
    //            {
    //                int category = Convert.ToInt32(strCategory);
    //                UserDefinedColumnVisit visit = new UserDefinedColumnVisit();
    //                string cateGuid = visit.VisitColumns[category.ToString()];


    //                if ((category >= 4 && category <= 7) && isFirstRun == 0)
    //                {
    //                    category = 4;

    //                    builder.AppendLine("<li>");
    //                    DataRow tmpRow = table.Select(string.Format("GUID = '{0}'", cateGuid))[0];
    //                    string tmpStr = tmpRow["LinkAddress"].ToString();

    //                    if (tmpStr.Contains("http://"))
    //                    {
    //                        if (tmpStr.Contains("?"))
    //                        {
    //                            builder.Append(string.Concat(new object[] { "<a id=lia style='font-size:20px;font-family:黑体;' ", category, " href='", tmpStr, "'" }));
    //                        }
    //                        else
    //                        {
    //                            builder.Append(string.Concat(new object[] { "<a id=lia  style='font-size:20px;font-family:黑体;' ", category, " href='", tmpStr, "'" }));
    //                        }
    //                    }
    //                    else
    //                    {
    //                        builder.Append(
    //                            string.Concat(new object[]
    //                        {
    //                            "<a id=lia  style='font-size:20px;font-family:黑体;' ", category, " href='http://", ShopSettings.siteDomain, "/", tmpStr,
    //                            GetOverrideUrlName(), "?tag=", category, "'"
    //                        }));
    //                    }
    //                    if ((str2 == string.Empty) && (Page.Request.RawUrl.ToLower().Contains("default") && (category == 0)))
    //                    {
    //                        builder.Append(" class=\"curr\" ");
    //                        builder.Append("  style='font-size:20px;font-family:黑体;' target='" + method_2(tmpRow["IfOpen"].ToString()) + "'>");
    //                        builder.Append(tmpRow["Name"] + "</a>");
    //                        builder.AppendLine("</li>");
    //                    }
    //                    else
    //                    {
    //                        if (str2 == category.ToString())
    //                        {
    //                            builder.Append(" class=\"curr\" ");
    //                        }
    //                        else
    //                        {
    //                            builder.Append("  style='font-size:20px;font-family:黑体;'");
    //                        }
    //                        builder.Append(" target='" + method_2(tmpRow["IfOpen"].ToString()) + "'>");
    //                        builder.Append(tmpRow["Name"] + "</a>");
    //                        builder.AppendLine("</li>");
    //                    }
    //                    isFirstRun = category;
    //                }
    //                else if (category < 4 || category > 7)
    //                {
    //                    builder.AppendLine("<li>");
    //                    DataRow row = table.Select(string.Format("GUID = '{0}'", cateGuid))[0];
    //                    string str = row["LinkAddress"].ToString();

    //                    if (str.Contains("http://"))
    //                    {
    //                        if (str.Contains("?"))
    //                        {
    //                            builder.Append(string.Concat(new object[] { "<a id=lia  style='font-size:20px;font-family:黑体;' ", category, " href='", str, "'" }));
    //                        }
    //                        else
    //                        {
    //                            builder.Append(string.Concat(new object[] { "<a id=lia  style='font-size:20px;font-family:黑体;' ", category, " href='", str, "'" }));
    //                        }
    //                    }
    //                    else
    //                    {
    //                        builder.Append(
    //                            string.Concat(new object[]
    //                        {
    //                            "<a id=lia  style='font-size:20px;font-family:黑体;' ", category, " href='http://", ShopSettings.siteDomain, "/", str,
    //                            GetOverrideUrlName(), "?tag=", category, "'"
    //                        }));
    //                    }
    //                    if ((str2 == string.Empty) && (Page.Request.RawUrl.ToLower().Contains("default") && (category == 0)))
    //                    {
    //                        builder.Append(" class=\"curr\" ");
    //                        builder.Append(" target='" + method_2(row["IfOpen"].ToString()) + "'>");
    //                        builder.Append(row["Name"] + "</a>");
    //                        builder.AppendLine("</li>");
    //                    }
    //                    else
    //                    {
    //                        if (str2 == category.ToString())
    //                        {
    //                            builder.Append(" class=\"curr\" ");
    //                        }
    //                        else
    //                        {
    //                            builder.Append(" style='font-size:20px;font-family:黑体;'");
    //                        }
    //                        builder.Append(" target='" + method_2(row["IfOpen"].ToString()) + "'>");
    //                        builder.Append(row["Name"] + "</a>");
    //                        builder.AppendLine("</li>");
    //                    }
    //                }
    //            }
    //            var dataSet = new DataSet();
    //            dataSet.ReadXml(HttpContext.Current.Server.MapPath("~/Settings/ShopSetting.xml"));
    //            DataRow dataRow = dataSet.Tables["ShopSetting"].Rows[0];
    //            string INDEXURL = dataRow["OverrideDomain"].ToString();
                
    //          //  builder.AppendLine("<li><a  href='" + INDEXURL + "/MoreShop.aspx' style='font-size:20px;font-family:黑体;' target='_self'>O2O专区222</a></li>");
                

    //            builder.AppendLine("</ul>");
    //            builder.AppendLine("</div>");
    //            builder.AppendLine("</div>");
    //            builder.AppendLine("</div>");
    //            builder.AppendLine("</div>");
    //            builder.AppendLine("</span>");
    //            literLi.Text = builder.ToString();
    //        }
    //    }

    //    private string method_2(string string_2)
    //    {
    //        if (string_2 == "0")
    //        {
    //            string_2 = "_self";
    //            return string_2;
    //        }
    //        if (string_2 == "1")
    //        {
    //            string_2 = "_blank";
    //        }
    //        return string_2;
    //    }

    //    private void BindProductCategory()
    //    {
    //        DataTable table =
    //            ((ShopNum1_ProductCategory_Action)LogicFactory.CreateShopNum1_ProductCategory_Action()).Search(0, 0,
    //                "16");
    //        if ((table != null) && (table.Rows.Count > 0))
    //        {
    //            //一级菜单开始
    //            var builder = new StringBuilder();
    //            builder.AppendLine("<ul class=\"cate_nav\">");

    //            var subBuilder = new StringBuilder();

    //            for (int i = 0; i < table.Rows.Count; i++)
    //            {
    //                builder.AppendLine("<li>");
    //                builder.AppendLine("<div class=\"cat_" + i + "_nav\">");
    //                builder.AppendLine("<img src=\"" + Page.ResolveUrl(table.Rows[i]["logoimg"].ToString()) + "\">");
    //                builder.AppendLine("<a href=\"" +
    //                                   ShopUrlOperate.RetUrl("Search_productlist", table.Rows[i]["code"].ToString(),
    //                                       "code") + "\">" + table.Rows[i]["Name"].ToString() + "</a>");
    //                builder.AppendLine("</div>");
    //                builder.AppendLine("</li>");

    //                //二级菜单开始

    //                subBuilder.AppendLine("<div class=\"cat_pannel clearfix\">");
    //                subBuilder.AppendLine("<div class=\"fl cat_detail grid_col_" + i + "\">");
    //                subBuilder.AppendLine("    <h3 class=\"cat_label_title\">" + table.Rows[i]["Name"].ToString() + "</h3>");
    //                subBuilder.AppendLine("<ul class=\"cat_label_list clearfix\">");

    //                DataTable dt =
    //                    ((ShopNum1_ProductCategory_Action)LogicFactory.CreateShopNum1_ProductCategory_Action()).Search(
    //                        Convert.ToInt32(table.Rows[i]["Id"].ToString()), 0, "100");

    //                if (dt != null && dt.Rows.Count > 0)
    //                {
    //                    for (int j = 0; j < dt.Rows.Count; j++)
    //                    {
    //                        int k = j % 2;

    //                        if (k == 0)
    //                        {
    //                            subBuilder.AppendLine("<li><a href=\"" +
    //                                                  ShopUrlOperate.RetUrl("Search_productlist",
    //                                                      dt.Rows[j]["code"].ToString(),
    //                                                      "code") +  "\">" + dt.Rows[j]["Name"] + "</a></li>");
    //                        }
    //                        else
    //                        {
    //                            subBuilder.AppendLine("<li class=\"second_label\"><a href=\"" +
    //                                                  ShopUrlOperate.RetUrl("Search_productlist",
    //                                                      dt.Rows[j]["code"].ToString(),
    //                                                      "code") +  "\">" + dt.Rows[j]["Name"] + "</a></li>");
    //                        }
    //                    }
    //                }

    //                var dataSet = new DataSet();
    //                dataSet.ReadXml(HttpContext.Current.Server.MapPath("~/Settings/ShopSetting.xml"));
    //                DataRow dataRow = dataSet.Tables["ShopSetting"].Rows[0];
    //                string INDEXURL = dataRow["CopyrightLink"].ToString();
    //                string ShopGodds_one = dataRow["ShopGodds_one"].ToString();
    //                string ShopGodds_two = dataRow["ShopGodds_two"].ToString();
    //                string ShopGodds_free = dataRow["ShopGodds_free"].ToString();

    //                string ShopGodds_five = dataRow["ShopGodds_five"].ToString();
    //                string ShopGodds_six = dataRow["ShopGodds_six"].ToString();
    //                string ShopGodds_seven = dataRow["ShopGodds_seven"].ToString();
    //                subBuilder.AppendLine("</ul>");

    //                subBuilder.AppendLine("<div class=\"cat_brand\">");
    //                subBuilder.AppendLine("<ul class=\"cat_slide_brand\">");

    //                subBuilder.AppendLine("<li>");
    //                subBuilder.AppendLine("<a href=" + INDEXURL + "><img src=\"images/10.jpg\" width=\"90\" height=\"40\" /></a>");
    //                subBuilder.AppendLine("<a href=" + INDEXURL + "><img src=\"images/11.jpg\" width=\"90\" height=\"40\" /></a>");
    //                subBuilder.AppendLine("</li>");
    //                subBuilder.AppendLine("<li>");
    //                subBuilder.AppendLine("<a href=" + INDEXURL + "><img src=\"images/12.jpg\" width=\"90\" height=\"40\" /></a>");
    //                subBuilder.AppendLine("<a href=" + INDEXURL + "><img src=\"images/13.jpg\" width=\"90\" height=\"40\" /></a>");
    //                subBuilder.AppendLine("</li>");
    //                subBuilder.AppendLine("<li>");
    //                subBuilder.AppendLine("<a href=" + INDEXURL + "><img src=\"images/14.jpg\" width=\"90\" height=\"40\" /></a>");
    //                subBuilder.AppendLine("<a href=" + INDEXURL + "><img src=\"images/15.jpg\" width=\"90\" height=\"40\" /></a>");
    //                subBuilder.AppendLine("</li>");
    //                subBuilder.AppendLine("</ul>");

    //                subBuilder.AppendLine("<ul class=\"cat_slide_nav\">");
    //                subBuilder.AppendLine("<li>•</li>");
    //                subBuilder.AppendLine("<li>•</li>");
    //                subBuilder.AppendLine("<li>•</li>");
    //                subBuilder.AppendLine("</ul>");

    //                subBuilder.AppendLine("</div>");

    //                subBuilder.AppendLine("</div>");

    //                subBuilder.AppendLine("<div class=\"fl cat_banner\">");
    //                subBuilder.AppendLine("<ul class=\"cat_banner_pic\">");
    //                subBuilder.AppendLine("<li><a href=" + ShopGodds_one + "><img src=\"images/1.jpg\" width=\"459\" height=\"482\" /></a></li>");
    //                subBuilder.AppendLine("<li><a href=" + ShopGodds_two + " ><img src=\"images/2.jpg\" width=\"459\" height=\"482\" /></a></li>");
    //                subBuilder.AppendLine("<li><a href=" + ShopGodds_free + "><img src=\"images/3.jpg\" width=\"459\" height=\"482\" /></a></li>");
    //                subBuilder.AppendLine("</ul>");
    //                subBuilder.AppendLine("<a class=\"prev_pic\" href=\"javascript:void(0)\"></a><a class=\"next_pic\" href=\"javascript:void(0)\"></a>");
    //                subBuilder.AppendLine("<div class=\"num\">");
    //                subBuilder.AppendLine("<ul>");
    //                subBuilder.AppendLine("</ul>");
    //                subBuilder.AppendLine("</div>");

    //                subBuilder.AppendLine("</div>");

    //                subBuilder.AppendLine("<ul class=\"fl cat_small_banner\">");
    //                subBuilder.AppendLine("<li><a href=" + ShopGodds_five + "><img src=\"images/21jpg.jpg\" width=\"190\" height=\"160\" /></a></li>");
    //                subBuilder.AppendLine("<li><a href=" + ShopGodds_six + "><img src=\"images/22.jpg\" width=\"190\" height=\"160\" /></a></li>");
    //                subBuilder.AppendLine("<li><a href=" + ShopGodds_seven + "><img src=\"images/23.jpg\" width=\"190\" height=\"160\" /></a></li>");
    //                subBuilder.AppendLine("</ul>");
    //                subBuilder.AppendLine("</div>");
    //            }

    //            lblSubProductCatogory.Text = subBuilder.ToString();
    //            //二级菜单结束

    //            builder.AppendLine("</ul>");
    //            ltlProductCategory.Text = builder.ToString();
    //            //一级菜单结束
    //        }

    //    }
    //}
}
