using System;
using System.Data;
using System.Text;
using System.Web;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;

namespace ShopNum1.Deploy.Main.Api
{
    /// <summary>
    /// shopfeetemplate 的摘要说明
    /// </summary>
    public class shopfeetemplate : IHttpHandler
    {

        public delegate void GetJson(
         string path, string memlgoid, string postid, string regioncode, string type, bool ishavcache);

        //定义委托
        public void ProcessRequest(HttpContext context)
        {
            context.Response.Buffer = true;
            context.Response.ExpiresAbsolute = DateTime.Now.AddDays(-1);
            context.Response.Expires = 0;
            context.Response.CacheControl = "no-cache";
            //定义方法
            GetJson GetShopFeeTemplate = (a, m, b, c, d, g) =>
            {
                var sbuilder = new StringBuilder();

                //
                if (d == "fee")
                {
                    //prod

                    var FeeTemplate_Action = new ShopNum1.ShopFeeTemplate.Shop_FeeTemplate_Action();
                    string strerror = string.Empty; //错误提示
                    if (b.Length > 1)
                    {
                        b = "'" + b + "'";
                    }
                    DataTable datatableFee = FeeTemplate_Action.GetFeesByFrontCache(a, m, b, c, "-1", false);
                    if (datatableFee == null || datatableFee.Rows.Count == 0)
                    {
                        sbuilder.Append("[{}]");
                    }
                    else
                    {
                        sbuilder.Append("[");
                        for (int i = 0; i < datatableFee.Rows.Count; i++)
                        {
                            sbuilder.Append("{\"feetype\":\"" + datatableFee.Rows[i]["feetype"].ToString() +
                                            "\",\"fee\":\"" + Convert.ToDecimal(datatableFee.Rows[i]["fee"]) +
                                            "\",\"oneadd\":\"" + datatableFee.Rows[i]["oneadd"].ToString() + "\"},");
                        }

                        sbuilder.Remove(sbuilder.Length - 1, 1);
                        sbuilder.Append("]");
                    }
                }

                context.Response.ContentType = "application/json";
                context.Response.ContentEncoding = Encoding.UTF8;
                context.Response.Write(sbuilder.ToString());
            };

            ////验证合法性
            object getyz = context.Request["yz"]; //
            if (getyz == null || getyz.ToString() != "shopnum1ntbl")
            {
                context.Response.ContentType = "application/json";
                context.Response.ContentEncoding = Encoding.UTF8;
                context.Response.Write("[{}]");
                return;
            }
            ///要返回数据的类型
            string feetype = context.Request["type"];
            //传来地区处理数据
            if (feetype == "fee")
            {
                string path = context.Request["path"] + "xml/PostageTemplate.xml";
                string provincecode = context.Request["code"];
                string feetemplateid = context.Request["feetemplateid"];
                ///返回json数据
                GetShopFeeTemplate(HttpContext.Current.Server.MapPath(path), "", feetemplateid, provincecode, feetype, false);
            }
            ///处理模板名称
            else if (feetype == "feename")
            {
                string templatename = context.Request["templatename"];
                IsFeeNameSame(templatename);
            }
            else if (feetype == "GetFreeTemplate") //立即购买
            {
                #region 更改地区显示不同邮费

                string ProductGuid = context.Request["productguid"];
                var shopinfo_Action = (Shop_ShopInfo_Action)LogicFactory.CreateShop_ShopInfo_Action();
                DataTable dt = shopinfo_Action.GetShopOpentimeByProductGuid(ProductGuid);
                string shopUrl = string.Empty;
                string shoppath = string.Empty;
                if (null != dt && dt.Rows.Count > 0)
                {
                    shopUrl = dt.Rows[0]["ShopId"].ToString();
                    string openTime = DateTime.Parse(dt.Rows[0]["OpenTime"].ToString()).ToString("yyyy-MM-dd");
                    shoppath = "~/Shop/Shop/" + openTime.Replace("-", "/") + "/Shop" + shopUrl.Trim() + "/";
                }
                string path = shoppath + "xml/PostageTemplate.xml";
                string provincecode = context.Request["code"].Substring(0, 3);
                string feetemplateid = context.Request["feetemplateid"];
                ///返回json数据
                GetShopFeeTemplate(HttpContext.Current.Server.MapPath(path), "", feetemplateid, provincecode, "fee", false);

                #endregion
            }
            else if (feetype == "GetMoreFreeTemplate") //加入购物车
            {
                #region 更改地区显示不同邮费

                string MemloginId = context.Request["productguid"]; //多个店铺的MemloginId
                string provincecode = context.Request["code"].Substring(0, 3);
                string feetemplateid = context.Request["feetemplateid"];
                //feetemplateid,Express_fee,Ems_fee,Post_fee,BuyNumber

                string[] MemloginIdArry = MemloginId.Split(',');

                int IsFeeType = 0;
                decimal Post_fee = Convert.ToDecimal(0.00),
                        Express_fee = Convert.ToDecimal(0.00),
                        Ems_fee = Convert.ToDecimal(0.00);
                for (int i = 0; i < MemloginIdArry.Length; i++)
                {
                    var shopinfo_Action =
                        (ShopNum1_ShopInfoList_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_ShopInfoList_Action();
                    DataTable dt = shopinfo_Action.GetShopIDByMemLoginID(MemloginIdArry[i]);
                    string shopUrl = string.Empty;
                    string shoppath = string.Empty;
                    if (null != dt && dt.Rows.Count > 0)
                    {
                        shopUrl = dt.Rows[0]["ShopId"].ToString();
                        string openTime = DateTime.Parse(dt.Rows[0]["OpenTime"].ToString()).ToString("yyyy-MM-dd");
                        shoppath = "~/Shop/Shop/" + openTime.Replace("-", "/") + "/Shop" + shopUrl.Trim() + "/";
                    }
                    string path = shoppath + "xml/PostageTemplate.xml";

                    #region 首先判断是用邮费模版还是填写的邮费

                    string[] feetemplateArry = feetemplateid.Split('|');
                    for (int j = 0; j < feetemplateArry.Length; j++)
                    {
                        IsFeeType = 1;
                        //有邮费模版
                        if (feetemplateArry[j].Split(',')[0] != null && feetemplateArry[j].Split(',')[0] != "" &&
                            feetemplateArry[j].Split(',')[0] != "0")
                        {
                            var FeeTemplate_Action = new ShopNum1.ShopFeeTemplate.Shop_FeeTemplate_Action();
                            DataTable datatableFee =
                                FeeTemplate_Action.GetFeesByFrontCache(HttpContext.Current.Server.MapPath(path), "-1",
                                                                       "'" + feetemplateArry[j].Split(',')[0] + "'",
                                                                       provincecode, "-1", false);
                            if (datatableFee != null)
                            {
                                foreach (DataRow row in datatableFee.Rows)
                                {
                                    decimal Price = Convert.ToDecimal(row["fee"].ToString()) +
                                                    (int.Parse(feetemplateArry[j].Split(',')[4]) - 1) *
                                                    Convert.ToDecimal(row["oneadd"].ToString());
                                    if (row["feetype"].ToString() == "1")
                                    {
                                        Post_fee += Price;
                                    }
                                    else if (row["feetype"].ToString() == "2")
                                    {
                                        Express_fee += Price;
                                    }
                                    else if (row["feetype"].ToString() == "3")
                                    {
                                        Ems_fee += Price;
                                    }
                                }
                            }
                            else
                            {
                                if (!string.IsNullOrEmpty(feetemplateArry[j].Split(',')[1]))
                                {
                                    Express_fee += Convert.ToDecimal(feetemplateArry[j].Split(',')[1]);
                                }
                                if (!string.IsNullOrEmpty(feetemplateArry[j].Split(',')[2]))
                                {
                                    Ems_fee += Convert.ToDecimal(feetemplateArry[j].Split(',')[2]);
                                }
                                if (!string.IsNullOrEmpty(feetemplateArry[j].Split(',')[3]))
                                {
                                    Post_fee += Convert.ToDecimal(feetemplateArry[j].Split(',')[3]);
                                }
                            }
                        }
                        
                    }

                    #endregion
                }

                var strFeeTemplate = new StringBuilder();
                if (IsFeeType == 1)
                {
                    strFeeTemplate.Append("[{\"Express\":\"" + Express_fee + "\",\"Ems\":\"" + Ems_fee + "\",\"Post\":\"" +
                                          Post_fee + "\"}]");
                }
                else
                {
                    strFeeTemplate.Append("[{}]");
                }
                context.Response.ContentType = "application/json";
                context.Response.ContentEncoding = Encoding.UTF8;
                context.Response.Write(strFeeTemplate.ToString());

                #endregion
            }
        }

        public bool IsReusable
        {
            get { return false; }
        }

        /// <summary>
        ///   检查模板名称重复性
        /// </summary>
        /// <param name="feename"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public void IsFeeNameSame(string feename)
        {
            if (HttpContext.Current.Request.Cookies["MemberLoginCookie"] != null)
            {
                //退出

                HttpCookie cookieShopMemberLogin = HttpContext.Current.Request.Cookies["MemberLoginCookie"];
                HttpCookie decodedCookieShopMemberLogin = HttpSecureCookie.Decode(cookieShopMemberLogin);
                string MemberType = decodedCookieShopMemberLogin.Values["MemberType"];
                if (MemberType == "2")
                {
                    string memlogid = decodedCookieShopMemberLogin.Values["MemLoginID"];
                    var FeeTemplate_Action = new ShopNum1.ShopFeeTemplate.Shop_FeeTemplate_Action();
                    string path = GetFeeTemplatePath(memlogid); ///xml路径
                    if (FeeTemplate_Action.CheckTemplateName(feename, HttpContext.Current.Server.MapPath(path)))
                    {
                        HttpContext.Current.Response.Write("1");
                    }
                    else
                    {
                        HttpContext.Current.Response.Write("0");
                    }
                }
                //会员登录ID
                return;
            }
            HttpContext.Current.Response.Write("-1");
        }

        /// <summary>
        ///   调用邮费模板xml所在位置
        /// </summary>
        /// <returns></returns>
        private string GetFeeTemplatePath(string memlogid)
        {
            var shopInfo_Action = (Shop_ShopInfo_Action)LogicFactory.CreateShop_ShopInfo_Action();
            DataTable dataTable = shopInfo_Action.GetMemLoginInfo(memlogid);
            string shopid = dataTable.Rows[0]["ShopID"].ToString();
            string OpenTime = DateTime.Parse(dataTable.Rows[0]["OpenTime"].ToString()).ToString("yyyy-MM-dd");
            return "~/Shop/Shop/" + OpenTime.Replace("-", "/") + "/shop" + shopid + "/xml/PostageTemplate.xml";
        }
    }
}