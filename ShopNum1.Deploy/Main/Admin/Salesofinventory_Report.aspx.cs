using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using System;
using System.Data;
using System.Text;
using System.Web.SessionState;
using System.Web.UI;


namespace ShopNum1.Deploy.Main.Admin
{
    public partial class Salesofinventory_Report : PageBase, IRequiresSessionState
    {
        private void BindData()
        {
            var action = (ShopNum1_Shop_Product_Action)LogicFactory.CreateShopNum1_Shop_Product_Action();
            string startdate = (Page.Request.QueryString["DispatchTime1"] == "")
                                   ? ""
                                   : Page.Request.QueryString["DispatchTime1"];
            string enddate = (Page.Request.QueryString["DispatchTime2"] == "")
                                 ? ""
                                 : Page.Request.QueryString["DispatchTime2"];
            DataTable table = action.GetProductSalesOfFinventory(Page.Request.QueryString["productid"],
                                                          startdate, enddate);
            if ((table != null) && (table.Rows.Count > 0))
            {
                base.Response.Write("<table width=\"100%\">");
                base.Response.Write("<tr bgcolor=\"#6699cc\">");
                base.Response.Write(" <td align=\"center\" width=\"300\">产品编号</td>");
                base.Response.Write("<td align=\"center\">产品名称</td>");
                base.Response.Write("<td align=\"center\">库存</td>");
                base.Response.Write("<td align=\"center\">销量</td>");
                base.Response.Write("<td align=\"center\">确认时间</td>");
                
                base.Response.Write("</tr>");
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    base.Response.Write("<tr>");
                    base.Response.Write("<td align=\"center\" width=\"300\"> 编号-{Id}</td>".Replace("{Id}", table.Rows[i]["Id"].ToString()));
                    base.Response.Write("<td align=\"center\" width=\"100\"> {Name}</td>".Replace("{Name}", table.Rows[i]["Name"].ToString()));
                    base.Response.Write("<td align=\"center\" width=\"150\"> {UnitName}</td>".Replace("{UnitName}", table.Rows[i]["UnitName"].ToString()));
                    base.Response.Write("<td align=\"center\" width=\"100\"> {SaleNumber}</td>".Replace("{SaleNumber}", table.Rows[i]["SaleNumber"].ToString()));
                    base.Response.Write("<td align=\"center\" width=\"100\"> {ModifyTime}</td>".Replace("{ModifyTime}", table.Rows[i]["ModifyTime"].ToString()));
                    
                    base.Response.Write("</tr>");
                }
                base.Response.Write("</table>");
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            if (!Page.IsPostBack && ((Page.Request["DispatchTime1"] != null) && (Page.Request["DispatchTime2"] != null)))
            {
                base.Response.Clear();
                string str = base.Request.QueryString["Type"];
                if (str == "xls")
                {
                    base.Response.Charset = "UTF-8";
                    base.Response.ContentEncoding = Encoding.GetEncoding("utf-8");
                    base.Response.ContentType = "Application/ms-excel";
                }
                else
                {
                    base.Response.ContentEncoding = Encoding.GetEncoding("gb2312");
                }
                base.Response.AppendHeader("Content-Disposition", "attachment;filename=\"SalesofinventoryReport_" + DateTime.Now.ToString("yyyymmddhhmm") + "." + str + "\"");
                BindData();
                base.Response.Flush();
                base.Response.Close();
                base.Response.End();
            }
        }
    }
}