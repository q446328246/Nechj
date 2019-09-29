using System;
using System.Data;
using System.Text;
using System.Web.SessionState;
using System.Web.UI;
using ShopNum1.BusinessLogic;
using ShopNum1.Factory;

namespace ShopNum1.Deploy.Main.Api
{
    public partial class AddressOpreateJson : Page, IRequiresSessionState
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.Request["cityid"] == null)
            {
                base.Response.Write("notarget");
            }
            else
            {
                method_0(Page.Request["cityid"]);
            }
        }

        private void method_0(string string_0)
        {
            ShopNum1_DispatchRegion_Action action = (ShopNum1_DispatchRegion_Action)LogicFactory.CreateShopNum1_DispatchRegion_Action();
            action.TableName = "ShopNum1_DispatchRegion";
            DataTable dispatchRegionName = action.GetDispatchRegionName(string_0);
            var builder = new StringBuilder();
            if ((dispatchRegionName != null) && (dispatchRegionName.Rows.Count != 0))
            {
                builder.Append("[");
                for (int i = 0; i < dispatchRegionName.Rows.Count; i++)
                {
                    builder.Append("{\"Name\":\"" + dispatchRegionName.Rows[i]["Name"] + "\",\"Value\":\"" +
                                   dispatchRegionName.Rows[i]["Code"] + "/" + dispatchRegionName.Rows[i]["ID"] + "\"},");
                }
                builder.Remove(builder.Length - 1, 1);
                builder.Append("]");
                Page.Response.ContentType = "application/json";
                Page.Response.ContentEncoding = Encoding.UTF8;
                Page.Response.Write(builder.ToString());
            }
        }
    }
}