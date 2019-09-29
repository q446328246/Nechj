using System;
using System.Web;
using ShopNum1.Common;
using ShopNum1.BusinessLogic;
using System.Data;
using System.Text;
using ShopNum1.Factory;
using ShopNum1.ShopBusinessLogic;
using System.IO;
using ShopNum1.MultiBaseWebControl;

namespace ShopNum1.Deploy.Api.ShopAdmin
{
    /// <summary>
    /// S_AdminOpt 的摘要说明
    /// </summary>
    public class S_AdminOpt : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            string type = context.Request.QueryString["type"] == null ? "" : context.Request.QueryString["type"].ToString();
            string MemLoginID = context.Request.QueryString["ShopMemLoginID"] == null ? "" : context.Request.QueryString["ShopMemLoginID"].ToString();
            string shopName = context.Request.QueryString["ShopName"] == null ? "" : context.Request.QueryString["ShopName"].ToString();
            string FatherID = context.Request.QueryString["FatherID"] == null ? "" : context.Request.QueryString["FatherID"].ToString();
            string IdentityCard = context.Request.QueryString["IdentityCard"] == null ? "" : context.Request.QueryString["IdentityCard"].ToString();
            string Shopurl = context.Request.QueryString["Shopurl"] == null ? "" : context.Request.QueryString["Shopurl"].ToString();

            string payPwd = context.Request.QueryString["payPwd"] == null ? "" : context.Request.QueryString["payPwd"].ToString();
            switch (type)
            {
                case "ShopLink":
                    context.Response.Write(IsExistUser(MemLoginID));
                    break;
                case "AdvancePayment":
                    context.Response.Write(AdvancePayment());
                    break;
                case "ShopName":
                    context.Response.Write(SameShopName(shopName));
                    break;
                case "ShopCategory":
                    context.Response.Write(GetShopCategory(FatherID));
                    break;
                case "IdentityCard"://验证身份证唯一
                    context.Response.Write(CheckIdentityCard(IdentityCard));
                    break;
                case "Shopurl"://域名单一性
                    context.Response.Write(CheckShopUrl(Shopurl));
                    break;
                case "paypwd"://交易密码
                    context.Response.Write(CheckPayPwd(payPwd));
                    break;
            }

        }
        /// <summary>
        /// 将datatable转换成json数组
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        private string GetJson(DataTable dt)
        {
            StringBuilder sbJson = new StringBuilder();
            if (dt.Rows.Count > 0)
            {
                sbJson.Append("[");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    sbJson.Append("{");
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        sbJson.Append("\"" + dt.Columns[j].ColumnName.ToLower() + "\":\"" + dt.Rows[i][j].ToString().Replace("~/", "/") + "\",");
                    }
                    sbJson.Remove(sbJson.Length - 1, 1);
                    sbJson.Append("},");
                }
                sbJson.Remove(sbJson.Length - 1, 1);
                sbJson.Append("]");
            }
            return sbJson.ToString();
        }
        public string IsExistUser(string MemLoginID)
        {
            Shop_ShopLink_Action ShopLink_Action = (Shop_ShopLink_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_ShopLink_Action();
            DataTable dataTable = ShopLink_Action.CheckMemLoginID(MemLoginID);
            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                if (!string.IsNullOrEmpty(dataTable.Rows[0][0].ToString()))
                {
                    return "ok";
                }
                return "no";
            }
            return "no";
        }

        public string AdvancePayment()
        {
            #region 获得当前的金币（BV）
            HttpCookie cookieShopMemberLogin = HttpContext.Current.Request.Cookies["MemberLoginCookie"];
            HttpCookie decodedCookieShopMemberLogin = HttpSecureCookie.Decode(cookieShopMemberLogin);
            //会员登录ID
            string MemberLoginID = decodedCookieShopMemberLogin.Values["MemLoginID"].ToString();
            string money = ShopNum1.Common.Common.GetNameById("AdvancePayment", "ShopNum1_Member", "  AND  MemLoginID='" + MemberLoginID + "'");
            if (!string.IsNullOrEmpty(money))
            {
                return money;
            }
            return "0";

            #endregion
        }

        /// <summary>
        /// 判断相同的店铺名称
        /// </summary>
        /// <param name="shopName"></param>
        /// <returns></returns>
        public string SameShopName(string shopName)
        {
            #region 获得当前的金币（BV）
            string guid = ShopNum1.Common.Common.GetNameById("Guid", "ShopNum1_ShopInfo", "  AND  ShopName='" + shopName + "'");
            if (!string.IsNullOrEmpty(guid))
            {
                return "true";
            }
            return "false";

            #endregion
        }

        /// <summary>
        /// 获得店铺分类
        /// </summary>
        /// <param name="FatherID"></param>
        /// <returns></returns>
        public string GetShopCategory(string FatherID)
        {
            ShopNum1_ShopCategory_Action shopNum1_ShopCategory_Action = (ShopNum1_ShopCategory_Action)LogicFactory.CreateShopNum1_ShopCategory_Action();
            DataTable dataTable = shopNum1_ShopCategory_Action.GetList(FatherID);
            string strString = string.Empty;
            return GetJson(dataTable);
            //strString = "<option value=\"-1\">-请选择-</option>";
            //if (dataTable != null && dataTable.Rows.Count > 0)
            //{
            //    foreach (DataRow dr in dataTable.Rows)
            //    {
            //        strString += "<option value=" + dr["ID"].ToString() + "|" + dr["Code"].ToString() + ">" + dr["Name"].ToString() + "</option>";
            //    }
            //}
            //return strString;
        }

        /// <summary>
        /// 身份证验证，唯一性
        /// </summary>
        /// <param name="IdentityCard"></param>
        /// <returns></returns>
        public string CheckIdentityCard(string IdentityCard)
        {
            string guid = ShopNum1.Common.Common.GetNameById("IdentityCard", "ShopNum1_ShopInfo", "  AND  IdentityCard='" + IdentityCard + "'");
            if (!string.IsNullOrEmpty(guid))
            {
                return "true";
            }
            return "false";
        }


        /// <summary>
        /// 检查域名单一
        /// </summary>
        /// <param name="ShopUrl"></param>
        /// <returns></returns>
        public string CheckShopUrl(string ShopUrl)
        {
            //在域名申请表中查询 是否有相同域名
            string DoMain = ShopNum1.Common.Common.GetNameById("DoMain", "ShopNum1_ShopURLManage", "  AND  DoMain='" + ShopUrl + "'");
            if (!string.IsNullOrEmpty(DoMain))
            {
                return "true";
            }
            //在店铺表中查询 是否有相同的域名
            string DoMain1 = ShopNum1.Common.Common.GetNameById("Guid", "ShopNum1_ShopInfo", "  AND  ShopUrl='" + ShopUrl + "'");
            if (!string.IsNullOrEmpty(DoMain1))
            {
                return "true";
            }

            return "false";
        }


        /// <summary>
        /// 检查交易密码
        /// </summary>
        /// <param name="payPwd">交易密码</param>
        /// <returns></returns>
        public string CheckPayPwd(string payPwd)
        {
            HttpCookie cookieShopMemberLogin = HttpContext.Current.Request.Cookies["MemberLoginCookie"];
            HttpCookie decodedCookieShopMemberLogin = HttpSecureCookie.Decode(cookieShopMemberLogin);
            //会员登录ID
            string MemberLoginID = decodedCookieShopMemberLogin.Values["MemLoginID"].ToString();
            string payPwd1 = ShopNum1.Common.Common.GetNameById("PayPwd", "ShopNum1_Member", "  AND  MemLoginID='" + MemberLoginID + "'");
            if (ShopNum1.Common.Encryption.GetMd5SecondHash(payPwd) == payPwd1)
            {
                return "true";
            }
            return "false";
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
     
    }
}