using System;
using System.Data;
using System.Text;
using System.Web.UI;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;

namespace ShopNum1.Deploy.Main
{
    public partial class T7 : Page
    {
        public string ShowCount { get; set; }

        public string ShowTwoCount { get; set; }

        public string GetOverrideUrlName()
        {
            if (ShopSettings.IsOverrideUrl)
            {
                return ShopSettings.overrideUrlName;
            }
            return ".aspx";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindData();
            }
        }

        private void BindData()
        {
            BindMenu();

            BindProductCategory();
        }


        private void BindMenu()
        {
            DataTable table = LogicFactory.CreateShopNum1_UserDefinedColumn_Action()
                .SearchMiddleNavigation("10", 1);
            if (table != null)
            {
                var builder = new StringBuilder();
                builder.AppendLine("<ul>");
                string str2 = string.Empty;
                if (Page.Request.QueryString["tag"] != null)
                {
                    str2 = Page.Request.QueryString["tag"];
                }
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    builder.AppendLine("<li>");
                    string str = table.Rows[i]["LinkAddress"].ToString();
                    if (str.Contains("http://"))
                    {
                        if (str.Contains("?"))
                        {
                            builder.Append(string.Concat(new object[] {"<a id=lia", i, " href='", str, "'"}));
                        }
                        else
                        {
                            builder.Append(string.Concat(new object[] {"<a id=lia", i, " href='", str, "'"}));
                        }
                    }
                    else
                    {
                        builder.Append(
                            string.Concat(new object[]
                            {
                                "<a id=lia", i, " href='http://", ShopSettings.siteDomain, "/", str,
                                GetOverrideUrlName(), "?tag=", i, "'"
                            }));
                    }
                    if ((str2 == string.Empty) && (Page.Request.RawUrl.ToLower().Contains("default") && (i == 0)))
                    {
                        builder.Append(" class=\"curr\" ");
                        builder.Append(" target='" + method_2(table.Rows[i]["IfOpen"].ToString()) + "'>");
                        builder.Append(table.Rows[i]["Name"] + "</a>");
                        builder.AppendLine("</li>");
                    }
                    else
                    {
                        if (str2 == i.ToString())
                        {
                            builder.Append(" class=\"curr\" ");
                        }
                        else
                        {
                            builder.Append(" style=''");
                        }
                        builder.Append(" target='" + method_2(table.Rows[i]["IfOpen"].ToString()) + "'>");
                        builder.Append(table.Rows[i]["Name"] + "</a>");
                        builder.AppendLine("</li>");
                    }
                }
                builder.AppendLine("</ul>");
                literLi.Text = builder.ToString();
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


        private void BindProductCategory()
        {
            DataTable table =
                ((ShopNum1_ProductCategory_Action) LogicFactory.CreateShopNum1_ProductCategory_Action()).Search(0, 0,
                    "100");
            if ((table != null) && (table.Rows.Count > 0))
            {
                //一级菜单开始
                var builder = new StringBuilder();
                builder.AppendLine("<ul>");

                var subBuilder = new StringBuilder();

                for (int i = 0; i < table.Rows.Count; i++)
                {
                    builder.AppendLine("<li>");
                    builder.AppendLine("<div class=\"cat_" + i + "_nav\">");
                    builder.AppendLine("<img src=\"" + Page.ResolveUrl(table.Rows[i]["logoimg"].ToString()) + "\">");
                    builder.AppendLine("<a href=\"" + ShopUrlOperate.RetUrl("Search_productlist", table.Rows[i]["code"].ToString(), "code") + "\">" + table.Rows[i]["Name"].ToString() + "</a>");
                    builder.AppendLine("</div>");
                    builder.AppendLine("</li>");

                    //二级菜单开始
                    subBuilder.AppendLine("<div class=\"cat_pannel clearfix\">");
                    subBuilder.AppendLine("<div class=\"fl cat_detail grid_col_" + i + "\">");
                   
                    if (i == 0)
                    {
                        subBuilder.AppendLine("<ul class=\"cat_label_list market_list clearfix\">");

                        //DataTable dt =
                        //    ((ShopNum1_ProductCategory_Action)LogicFactory.CreateShopNum1_ProductCategory_Action()).Search(
                        //        Convert.ToInt32(table.Rows[i]["Id"].ToString()), 0, "100");

                        //if (dt != null && dt.Rows.Count > 0)
                        //{
                        //    for (int j = 0; j < dt.Rows.Count; j++)
                        //    {
                        //        subBuilder.AppendLine("<li><a href=\"" +
                        //                              ShopUrlOperate.RetUrl("Search_productlist",
                        //                                  dt.Rows[j]["code"].ToString(),
                        //                                  "code") + "\">" + dt.Rows[j]["Name"] + "</a></li>");
                        //    }
                        //}
 
                        subBuilder.AppendLine("</ul>");
                    }
 
                    subBuilder.AppendLine("    <h3 class=\"cat_label_title\">" + table.Rows[i]["Name"].ToString() + "</h3>");

                    if (i == 0)
                    {
                        subBuilder.AppendLine("     <ul class=\"cat_label_list\">");

                        DataTable dt =
                            ((ShopNum1_ProductCategory_Action)LogicFactory.CreateShopNum1_ProductCategory_Action()).Search(
                                Convert.ToInt32(table.Rows[i]["Id"].ToString()), 0, "100");

                        if (dt != null && dt.Rows.Count > 0)
                        {
                            for (int j = 0; j < dt.Rows.Count; j++)
                            {
                                int k = j%2;

                                if (k == 0) 
                                {
                                    subBuilder.AppendLine("<li><a href=\"" +
                                                          ShopUrlOperate.RetUrl("Search_productlist",
                                                              dt.Rows[j]["code"].ToString(),
                                                              "code") + "\">" + dt.Rows[j]["Name"] + "</a></li>");
                                }
                                else
                                {
                                    subBuilder.AppendLine("<li class=\"second_label\"><a href=\"" +
                                                          ShopUrlOperate.RetUrl("Search_productlist",
                                                              dt.Rows[j]["code"].ToString(),
                                                              "code") + "\">" + dt.Rows[j]["Name"] + "</a></li>");
                                }
                            }
                        }
                        
                        subBuilder.AppendLine("     </ul>");
                        subBuilder.AppendLine("     <a class=\"market_banner\" href=\"http://www.datouwang.com/\">");
                        subBuilder.AppendLine("     <img src=\"images/0.png\" /></a>");
                    }
                    else
                    {
                        subBuilder.AppendLine("<ul class=\"cat_label_list clearfix\">");

                        DataTable dt =
                            ((ShopNum1_ProductCategory_Action)LogicFactory.CreateShopNum1_ProductCategory_Action()).Search(
                                Convert.ToInt32(table.Rows[i]["Id"].ToString()), 0, "100");

                        if (dt != null && dt.Rows.Count > 0)
                        {
                            for (int j = 0; j < dt.Rows.Count; j++)
                            {
                                int k = j % 2;

                                if (k == 0)
                                {
                                    subBuilder.AppendLine("<li><a href=\"" +
                                                          ShopUrlOperate.RetUrl("Search_productlist",
                                                              dt.Rows[j]["code"].ToString(),
                                                              "code") + "\">" + dt.Rows[j]["Name"] + "</a></li>");
                                }
                                else
                                {
                                    subBuilder.AppendLine("<li class=\"second_label\"><a href=\"" +
                                                          ShopUrlOperate.RetUrl("Search_productlist",
                                                              dt.Rows[j]["code"].ToString(),
                                                              "code") + "\">" + dt.Rows[j]["Name"] + "</a></li>");
                                }
                            }
                        }
                        
                        subBuilder.AppendLine("</ul>");
                          
                        subBuilder.AppendLine("<div class=\"cat_brand\">");
                            subBuilder.AppendLine("<ul class=\"cat_slide_brand\">");
                            subBuilder.AppendLine("<li><a href=\"http://www.datouwang.com/\"><img src=\"images/10.jpg\" width=\"90\" height=\"40\" /></a>");
                                    subBuilder.AppendLine("<a href=\"http://www.datouwang.com/\">");
                                        subBuilder.AppendLine("<img src=\"images/11.jpg\" width=\"90\" height=\"40\" /></a> </li>");
                                subBuilder.AppendLine("<li><a href=\"http://www.datouwang.com/\">");
                                    subBuilder.AppendLine("<img src=\"images/12.jpg\" width=\"90\" height=\"40\" /></a> <a href=\"http://www.datouwang.com/\">");
                                        subBuilder.AppendLine("<img src=\"images/13.jpg\" width=\"90\" height=\"40\" /></a> </li>");
                                subBuilder.AppendLine("<li><a href=\"http://www.datouwang.com/\">");
                                    subBuilder.AppendLine("<img src=\"images/14.jpg\" width=\"90\" height=\"40\" /></a> <a href=\"http://www.datouwang.com/\">");
                                        subBuilder.AppendLine("<img src=\"images/15.jpg\" width=\"90\" height=\"40\" /></a> </li>");
                            subBuilder.AppendLine("</ul>");
                            subBuilder.AppendLine("<ul class=\"cat_slide_nav\">");
                                subBuilder.AppendLine("<li>•</li>");
                                subBuilder.AppendLine("<li>•</li>");
                                subBuilder.AppendLine("<li>•</li>");
                            subBuilder.AppendLine("</ul>");
                            subBuilder.AppendLine("</div>");
                    }



                    subBuilder.AppendLine("     <div class=\"fl cat_banner\">");
                    subBuilder.AppendLine("    <ul class=\"cat_banner_pic\">");
                    subBuilder.AppendLine("      <li><a href=\"http://www.datouwang.com/\"><img src=\"images/1.jpg\" width=\"459\" height=\"482\" /></a></li>");
                    subBuilder.AppendLine("      <li><a href=\"http://www.datouwang.com/\"><img src=\"images/2.jpg\" width=\"459\" height=\"482\" /></a></li>");
                    subBuilder.AppendLine("      <li><a href=\"http://www.datouwang.com/\"><img src=\"images/3.jpg\" width=\"459\" height=\"482\" /></a></li>");
                    subBuilder.AppendLine("     </ul>");
                    subBuilder.AppendLine("    <a class=\"prev_pic\" href=\"javascript:void(0)\"></a><a class=\"next_pic\" href=\"javascript:void(0)\"></a>");
                    subBuilder.AppendLine("    <div class=\"num\">");
                    subBuilder.AppendLine("        <ul>");
                    subBuilder.AppendLine("       </ul>");
                    subBuilder.AppendLine("       </div>");
                    subBuilder.AppendLine("    </div>");
                    subBuilder.AppendLine("    <ul class=\"fl cat_small_banner\">");
                    subBuilder.AppendLine("     <li><a href=\"http://www.datouwang.com/\"><img src=\"images/21jpg.jpg\" width=\"190\" height=\"160\" /></a></li>");
                    subBuilder.AppendLine("      <li><a href=\"http://www.datouwang.com/\"><img src=\"images/22.jpg\" width=\"190\" height=\"160\" /></a></li>");
                    subBuilder.AppendLine("     <li><a href=\"http://www.datouwang.com/\"><img src=\"images/23.jpg\" width=\"190\" height=\"160\" /></a></li>");
                    subBuilder.AppendLine("    </ul>");

                    subBuilder.AppendLine("</div>");
                    subBuilder.AppendLine("</div>");

                    subBuilder.AppendLine("</div>");
                    subBuilder.AppendLine("</div>");
                    if (i == 2)
                    {
                        break;
                    }
                }

                lblSubProductCatogory.Text = subBuilder.ToString();
                //二级菜单结束

                builder.AppendLine("</ul>");
                ltlProductCategory.Text = builder.ToString();
                //一级菜单结束
            }
        }
    }
}