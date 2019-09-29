using System;
using System.Data;
using System.Text;
using System.Web.SessionState;
using System.Web.UI;
using ShopNum1.Factory;

namespace ShopNum1.Deploy.Main.Api
{
    public partial class ShopCategoryOpreateJson : Page, IRequiresSessionState
    {
        private void method_0(string string_0)
        {
            DataTable list = LogicFactory.CreateShopNum1_ShopCategory_Action().GetList(string_0);
            var builder = new StringBuilder();
            if ((list != null) && (list.Rows.Count != 0))
            {
                builder.Append("[");
                for (int i = 0; i < list.Rows.Count; i++)
                {
                    builder.Append("{\"Name\":\"" + list.Rows[i]["Name"] + "\",\"Value\":\"" + list.Rows[i]["Code"] +
                                   "/" + list.Rows[i]["ID"] + "\"},");
                }
                builder.Remove(builder.Length - 1, 1);
                builder.Append("]");
                Page.Response.ContentType = "application/json";
                Page.Response.ContentEncoding = Encoding.UTF8;
                Page.Response.Write(builder.ToString());
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.Request["category"] == null)
            {
                base.Response.Write("notarget");
            }
            else
            {
                method_0(Page.Request["category"]);
            }
        }
    }
}