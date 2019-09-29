using System;
using System.Data;
using System.Text;
using System.Web;
using ShopNum1.BusinessLogic;
using ShopNum1.Factory;

namespace ShopNum1.Deploy.Api
{
    /// <summary>
    /// ProductCategory 的摘要说明
    /// </summary>
    public class ProductCategory : IHttpHandler
    {

        private string strCategoryID = ""; //关键词

        public bool IsReusable
        {
            get { throw new NotImplementedException(); }
        }

        public void ProcessRequest(HttpContext context)
        {
            strCategoryID = context.Request["id"] == null ? "" : context.Request["id"];
            string type = context.Request["type"];
            if (type == null)
            {
                return;
            }
            switch (type.ToLower())
            {
                //搜索商品分类
                case "getproductcategory":
                    context.Response.Write(BindData(strCategoryID));
                    break;
                default:
                    break;
            }
        }

        bool IHttpHandler.IsReusable
        {
            get { throw new NotImplementedException(); }
        }

        private string BindData(string CategoryID)
        {
            var sbuilder = new StringBuilder();
            //绑定商品分类
            var shopNum1_ProductCategory_Action =
                (ShopNum1_ProductCategory_Action)LogicFactory.CreateShopNum1_ProductCategory_Action();
            DataTable dataTable = shopNum1_ProductCategory_Action.Search(Convert.ToInt32(CategoryID), 0, "1000");
            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                sbuilder.Append("<div class=\"tag_sx\"></div><ul class=\"imgYujiazai\">");
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    sbuilder.Append("<li><div class=\"tagsub\"><a href='" +
                                    ShopUrlOperate.RetUrl("Search_productlist", dataTable.Rows[i]["Code"].ToString(), "code") +
                                    "'>");
                    sbuilder.Append(dataTable.Rows[i]["Name"] + "</a></div>");
                    sbuilder.Append("<div class=\"tagsan\">");

                    int twoid = Convert.ToInt32(dataTable.Rows[i]["id"].ToString());
                    DataTable datatabletwo = shopNum1_ProductCategory_Action.Search(twoid, 0, "1000");
                    for (int j = 0; j < datatabletwo.Rows.Count; j++)
                    {
                        sbuilder.Append("<a href='" +
                                        ShopUrlOperate.RetUrl("Search_productlist", datatabletwo.Rows[j]["Code"].ToString(),
                                                              "code") + "'>");
                        sbuilder.Append(datatabletwo.Rows[j]["Name"] + "</a>");
                    }
                    sbuilder.Append("</div>");
                    sbuilder.Append("<div class=\"clear\"></div>");
                    sbuilder.Append("</li>");
                }

                sbuilder.Append("</ul>");
                return sbuilder.ToString();
            }
            else
            {
                return "";
            }
        }
    }
}