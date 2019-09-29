using System;
using System.Data;
using System.Text;
using System.Web;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.ShopBusinessLogic;

namespace ShopNum1.Deploy.Api
{
    /// <summary>
    /// ZtcProduct 的摘要说明
    /// </summary>
    public class ZtcProduct : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string Type = context.Request.QueryString["type"] == null ? "" : context.Request.QueryString["type"];
            string FatherID = context.Request.QueryString["FatherID"] == null ? "" : context.Request.QueryString["FatherID"];

            string code = context.Request.QueryString["code"] == null ? "" : context.Request.QueryString["code"];

            string textName = context.Request.QueryString["textName"] == null ? "" : context.Request.QueryString["textName"];

            string productGuid = context.Request.QueryString["productGuid"] == null
                                     ? ""
                                     : context.Request.QueryString["productGuid"];

            string Money = context.Request.QueryString["Money"] == null ? "" : context.Request.QueryString["Money"];


            string MemLoginID = string.Empty;

            if (HttpContext.Current.Request.Cookies["MemberLoginCookie"] != null)
            {
                HttpCookie cookieShopMemberLogin = HttpContext.Current.Request.Cookies["MemberLoginCookie"];
                HttpCookie decodedCookieShopMemberLogin = HttpSecureCookie.Decode(cookieShopMemberLogin);
                MemLoginID = decodedCookieShopMemberLogin.Values["MemLoginID"];
            }

            switch (Type)
            {
                case "fenlei":
                    context.Response.Write(GetShopCategory(FatherID, MemLoginID));
                    break;
                case "product":
                    context.Response.Write(GetProduct(code, textName, MemLoginID));
                    break;
                case "productImage":
                    context.Response.Write(GetProductImage(productGuid));
                    break;
                case "Money":
                    context.Response.Write(GetOrder(Money));
                    break;
                default:
                    ;
                    break;
            }
        }

        bool IHttpHandler.IsReusable
        {
            get { throw new NotImplementedException(); }
        }


        public string GetOrder(string money)
        {
            string strOrder = "1";
            var ZtcGoods_Action = (ShopNum1_ZtcGoods_Action)LogicFactory.CreateShopNum1_ZtcGoods_Action();
            DataTable dataOrder = ZtcGoods_Action.SearchProductOrder(money);
            if (dataOrder != null && dataOrder.Rows.Count > 0)
            {
                strOrder = (Convert.ToInt32(dataOrder.Rows[0][0].ToString()) + 1).ToString();
            }
            return strOrder;
        }


        public string GetProductImage(string guid)
        {
            string image = string.Empty;
            var ZtcGoods_Action = (ShopNum1_ZtcGoods_Action)LogicFactory.CreateShopNum1_ZtcGoods_Action();
            DataTable dataTable = ZtcGoods_Action.SearchProductImage(guid);
            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                image = dataTable.Rows[0]["OriginalImage"].ToString();
            }
            return image;
        }


        public string GetProduct(string code, string textName, string MemLoginID)
        {
            string codeString = code;
            if (code != "-1" && !string.IsNullOrEmpty(code) && code != "0")
            {
                string[] strCode = code.Split('/');
                if (strCode.Length > 0)
                {
                    codeString = strCode[1];
                }
            }


            var ZtcGoods_Action = (ShopNum1_ZtcGoods_Action)LogicFactory.CreateShopNum1_ZtcGoods_Action();
            DataTable dt = ZtcGoods_Action.GetProduct(50, codeString, textName, MemLoginID, 0, 1, 1, 1, 1);
            var sbJson = new StringBuilder();
            if (dt != null && dt.Rows.Count > 0)
            {
                sbJson.Append("[");
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        sbJson.Append("{");
                        for (int j = 0; j < dt.Columns.Count; j++)
                        {
                            sbJson.Append("\"" + dt.Columns[j].ColumnName.ToLower() + "\":\"" + dt.Rows[i][j] + "\",");
                        }
                        sbJson.Remove(sbJson.Length - 1, 1);
                        sbJson.Append("},");
                    }
                }
                sbJson.Remove(sbJson.Length - 1, 1);
                sbJson.Append("]");
            }
            return sbJson.ToString();
        }


        public string GetShopCategory(string FatherID, string MemLoginID)
        {
            var productCategory_Action =
                (Shop_ProductCategory_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_ProductCategory_Action();
            productCategory_Action.TableName = "ShopNum1_Shop_ProductCategory";
            DataTable dataTable = productCategory_Action.GetShopProductCategoryCode(FatherID, MemLoginID);
            string strCategory = string.Empty;
            strCategory = "<option value=\"-1\">-请选择-</option>";
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                //DropDownListCategoryCode.Items.Add(new ListItem(dataTable.Rows[i]["Name"].ToString(), dataTable.Rows[i]["Code"].ToString() + "/" + dataTable.Rows[i]["ID"].ToString()));
                strCategory += "<option value=\"" + dataTable.Rows[i]["ID"] + "/" + dataTable.Rows[i]["Code"] + "\">" +
                               dataTable.Rows[i]["Name"] + "</option>";
            }
            return strCategory;
        }
    }
}