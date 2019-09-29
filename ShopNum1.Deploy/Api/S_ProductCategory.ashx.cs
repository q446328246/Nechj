
using System;
using System.Data;
using System.Text;
using System.Web;
using ShopNum1.Common;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;

namespace ShopNum1.Deploy.Api
{
    /// <summary>
    /// S_ProductCategory 的摘要说明
    /// </summary>
    public class S_ProductCategory : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.Buffer = true;
            context.Response.ExpiresAbsolute = DateTime.Now.AddDays(-1);
            context.Response.Expires = 0;
            context.Response.CacheControl = "no-cache";
            var shop_ProductCategory_Action = (Shop_ProductCategory_Action)LogicFactory.CreateShop_ProductCategory_Action();
            if (ShopNum1.Common.Common.ReqStr("parentid") != "")
            {
                //获取子栏目数据操作
                string strid = ShopNum1.Common.Common.ReqStr("parentid");
                DataTable dataTable = shop_ProductCategory_Action.Search(Convert.ToInt32(strid), GetMemLoginId());
                context.Response.Write(GetJson(dataTable));
            }
            else if (ShopNum1.Common.Common.ReqStr("isshow") != "")
            {
                //是否显示操作
                string strreq = ShopNum1.Common.Common.ReqStr("isshow");
                int i = shop_ProductCategory_Action.UpdateIsshow(strreq.Split('-')[1], strreq.Split('-')[0]);
                context.Response.Write(i.ToString());
            }
            else if (ShopNum1.Common.Common.ReqStr("batch") != "")
            {
                string strreq = ShopNum1.Common.Common.ReqStr("batch");
                shop_ProductCategory_Action.DeleteRecId(strreq);
                context.Response.Write("ok");
            }
            else if (ShopNum1.Common.Common.ReqStr("vd") != "")
            {
                //批量保存分类名称和排序编号操作
                string strreq = HttpUtility.HtmlDecode(ShopNum1.Common.Common.ReqStr("vd"));
                if (strreq.IndexOf(",") != -1)
                {
                    string[] str = strreq.Split(',');
                    for (int i = 0; i < str.Length; i++)
                    {
                        shop_ProductCategory_Action.UpdateOrderName(str[i].Split('|')[1], str[i].Split('|')[2],
                                                                    str[i].Split('|')[0]);
                    }
                }
                else
                {
                    shop_ProductCategory_Action.UpdateOrderName(strreq.Split('|')[1], strreq.Split('|')[2],
                                                                strreq.Split('|')[0]);
                }
                context.Response.Write("ok");
            }
            else if (ShopNum1.Common.Common.ReqStr("savedata") != "")
            {
                //保存分类操作
                string strreq = HttpUtility.HtmlDecode(ShopNum1.Common.Common.ReqStr("savedata")).Replace("%2f", "/");
                shop_ProductCategory_Action.UpdateOrderName(strreq.Split('|')[0], strreq.Split('|')[2], strreq.Split('|')[1]);
                context.Response.Write("ok");
            }
            else if (ShopNum1.Common.Common.ReqStr("delectid") != "")
            {
                try
                {
                    //删除分类操作
                    shop_ProductCategory_Action.DeleteType(ShopNum1.Common.Common.ReqStr("delectid"));
                    context.Response.Write("ok|0");
                }
                catch
                {
                    context.Response.Write("deny|0");
                }
            }
        }

        public bool IsReusable
        {
            get { return false; }
        }

        //获取登录用户方法
        private string GetMemLoginId()
        {
            string name = "jely";
            if (HttpContext.Current.Request.Cookies["MemberLoginCookie"] != null)
            {
                HttpCookie cookieShopNum1MemberLogin = HttpContext.Current.Request.Cookies["MemberLoginCookie"];
                HttpCookie decodedCookieShopNum1MemberLogin = HttpSecureCookie.Decode(cookieShopNum1MemberLogin);
                name = decodedCookieShopNum1MemberLogin.Values["MemLoginID"];
            }
            return name;
        }

        /// <summary>
        ///   将datatable转换成json数组
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        private string GetJson(DataTable dt)
        {
            var sbJson = new StringBuilder();
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
            return sbJson.ToString();
        }
    }
}