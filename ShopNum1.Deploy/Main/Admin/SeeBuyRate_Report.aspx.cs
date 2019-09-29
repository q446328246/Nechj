using System;
using System.Data;
using System.Text;
using System.Web.SessionState;
using ShopNum1.BusinessLogic;
using ShopNum1.Factory;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class SeeBuyRate_Report : PageBase, IRequiresSessionState
    {
        private void method_5()
        {
            string str = this.Page.Request["ShopPrice1"].ToString();
            string str2 = this.Page.Request["ShopPrice2"].ToString();
            string str3 = this.Page.Request["MarketPrice1"].ToString();
            string str4 = this.Page.Request["MarketPrice2"].ToString();
            ShopNum1_Report_Action action = (ShopNum1_Report_Action)LogicFactory.CreateShopNum1_Report_Action();
            if (str == "")
            {
                str = "0";
            }
            if (str2 == "")
            {
                str2 = "0";
            }
            if (str3 == "")
            {
                str3 = "0";
            }
            if (str4 == "")
            {
                str4 = "0";
            }
            DataTable table = action.SearchSeeBuyRate(this.Page.Request["name"].ToString(), this.Page.Request["ProductCategoryCode1"].ToString().Trim(), this.Page.Request["ProductCategoryCode2"].ToString().Trim(), this.Page.Request["ProductCategoryCode3"].ToString().Trim(), this.Page.Request["BrandGuid"].ToString(), Convert.ToDecimal(str), Convert.ToDecimal(str2), Convert.ToDecimal(str3), Convert.ToDecimal(str4));
            if ((table != null) && (table.Rows.Count > 0))
            {
                base.Response.Write("<table width=\"100%\">");
                base.Response.Write("<tr bgcolor=\"#6699cc\">");
                base.Response.Write(" <td align=\"center\">商品名称</td>");
                base.Response.Write("<td align=\"center\">商品分类</td>");
                base.Response.Write("<td align=\"center\">品牌分类</td>");
                base.Response.Write("<td align=\"center\">访问量</td>");
                base.Response.Write("<td align=\"center\">销售量</td>");
                base.Response.Write("<td align=\"center\">访问购买率</td>");
                base.Response.Write("</tr>");
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    base.Response.Write("<tr>");
                    base.Response.Write("<td align=\"left\" width=\"100\"> {Name}</td>".Replace("{Name}", table.Rows[i]["Name"].ToString()));
                    base.Response.Write("<td align=\"left\" width=\"200\"> {Ptype}</td>".Replace("{Ptype}", table.Rows[i]["productcategoryname"].ToString()));
                    base.Response.Write("<td align=\"left\" width=\"100\"> {Btype}</td>".Replace("{Btype}", table.Rows[i]["brandname"].ToString()));
                    base.Response.Write("<td align=\"left\" width=\"50\"> {ClickCount}</td>".Replace("{ClickCount}", table.Rows[i]["ClickCount"].ToString()));
                    base.Response.Write("<td align=\"left\" width=\"50\"> {SaleNumber}</td>".Replace("{SaleNumber}", table.Rows[i]["SaleNumber"].ToString()));
                    base.Response.Write("<td align=\"left\" width=\"50\"> {BuyRate}</td>".Replace("{BuyRate}", table.Rows[i]["BuyRate"].ToString()));
                    base.Response.Write("</tr>");
                }
                base.Response.Write("</table>");
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            if (!this.Page.IsPostBack && ((this.Page.Request["ProductCategoryCode1"] != null) && (this.Page.Request["BrandGuid"] != null)))
            {
                base.Response.Clear();
                string str = base.Request.QueryString["Type"].ToString();
                if (str == "xls")
                {
                    base.Response.Charset = "UTF-8";
                    this.Page.Response.ContentEncoding = Encoding.GetEncoding("gbk");
                    this.Page.Response.ContentType = "Application/ms-excel";
                }
                else
                {
                    base.Response.ContentEncoding = Encoding.GetEncoding("gb2312");
                }
                base.Response.AppendHeader("Content-Disposition", "attachment;filename=\"SeeBuyRateReport_" + DateTime.Now.ToString("yyyymmddhhmm") + "." + str + "\"");
                this.method_5();
                base.Response.Flush();
                base.Response.Close();
                base.Response.End();
            }
        }

    }
}