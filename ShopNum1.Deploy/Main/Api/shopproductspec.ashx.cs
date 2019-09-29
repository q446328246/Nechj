using System.Data;
using System.Text;
using System.Web;
using ShopNum1.Factory;

namespace ShopNum1.Deploy.Main.Api
{
    /// <summary>
    /// shopproductspec 的摘要说明
    /// </summary>
    public class shopproductspec : IHttpHandler
    {

        public delegate void GetJson(string prodguid, string memloginid, string spec, string type);

        //定义委托
        public void ProcessRequest(HttpContext context)
        {
            //定义方法
            GetJson GetProdSpec = (a, b, c, d) =>
            {
                var sbuilder = new StringBuilder();

                //如果是返回规格多图
                if (d == "img")
                {
                    //规格prod
                    ShopNum1.Interface.IShopNum1_SpecProudctDetail_Action SpecProudctDetail_Action =
                        LogicFactory.CreateShopNum1_SpecProudctDetail_Action();
                    string strImg = SpecProudctDetail_Action.GetSpecImageBySpecId(a, c);
                    if (strImg == "")
                    {
                        sbuilder.Append("[{}]");
                    }
                    else
                    {
                        sbuilder.Append("[");
                        sbuilder.Append("{\"imgsrc\":\"" + strImg.Replace("~", "") + "\"}");
                        sbuilder.Append("]");
                    }
                }
                //操作商品 库存等信息
                else
                {
                    ShopNum1.Interface.IShopNum1_SpecProudct_Action SpecProudctAction =
                        LogicFactory.CreateShopNum1_SpecProudct_Action();
                    DataTable dataTableProd = SpecProudctAction.GetSpecificationByProduct(a,
                                                                                          c.Replace(":", ",")
                                                                                           .Replace(";", "|"));
                    if (dataTableProd == null || dataTableProd.Rows.Count == 0)
                        return;
                    else
                    {
                        sbuilder.Append("[");
                        sbuilder.Append("{\"price\":" + dataTableProd.Rows[0]["GoodsPrice"].ToString() +
                                        ",\"RepertoryCount\":" + dataTableProd.Rows[0]["Goodsstock"].ToString() +
                                        ",\"RepertoryNumber\":\"" + dataTableProd.Rows[0]["goodsnumber"].ToString() +
                                        "\"}");
                        sbuilder.Append("]");
                    }
                }
                context.Response.ContentType = "application/json";
                context.Response.ContentEncoding = Encoding.UTF8;
                context.Response.Write(sbuilder.ToString());
            };

            object getyz = context.Request["yz"];
            if (getyz == null || getyz.ToString() != "shopnum1ntbl")
            {
                context.Response.Write("error");
                return;
            }
            string prodguid = context.Request["prodguid"];
            string memloginid = HttpUtility.HtmlDecode(context.Request["loginid"]);
            string spec = HttpUtility.HtmlDecode(context.Request["spec"]);
            string spectype = context.Request["type"];
            ///返回json数据
            GetProdSpec(prodguid, memloginid, spec, spectype);
        }

        public bool IsReusable
        {
            get { return false; }
        }
    }
}