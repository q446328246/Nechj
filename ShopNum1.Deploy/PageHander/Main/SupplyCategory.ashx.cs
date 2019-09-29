using System.Data;
using System.Web;
using ShopNum1.BusinessLogic;
using ShopNum1.Factory;

namespace ShopNum1.Deploy.PageHander.Main
{
    /// <summary>
    /// SupplyCategory 的摘要说明
    /// </summary>
    public class SupplyCategory : IHttpHandler
    {

        private string type;

        public void ProcessRequest(HttpContext context)
        {
            type = context.Request["type"];
            if (type == null)
            {
                return;
            }
            switch (type.ToLower().Trim())
            {
                //查询供求分类 
                case "search":
                    string cityid = context.Request["cityid"].Trim();
                    context.Response.Write(Search(cityid));
                    break;
                default:
                    break;
            }
        }

        public bool IsReusable
        {
            get { return false; }
        }

        /// <summary>
        ///   查询
        /// </summary>
        /// <returns></returns>
        private string Search(string cityid)
        {
            string all_data = string.Empty;

            var shopNum1_ProductCategory_Action =
                (ShopNum1_ProductCategory_Action)LogicFactory.CreateShopNum1_ProductCategory_Action();
            shopNum1_ProductCategory_Action.TableName = "ShopNum1_SupplyDemandCategory";
            DataTable dataTable = shopNum1_ProductCategory_Action.GetProductCategoryName(cityid);

            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                for (int j = 0; j < dataTable.Rows.Count; j++)
                {
                    all_data += "<li><a href='" +
                                ShopUrlOperate.RetUrl("SupplyDemandListSearch", dataTable.Rows[j]["Code"].ToString(), "Code") +
                                "'>" + dataTable.Rows[j]["Name"] + "</a> </li>";
                }

                return all_data;
            }
            else
            {
                return "";
            }
        }
    }
}