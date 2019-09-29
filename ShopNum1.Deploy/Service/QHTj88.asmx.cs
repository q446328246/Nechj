using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using ShopNum1.BusinessLogic;
using ShopNum1.Factory;

namespace ShopNum1.Deploy.Service
{
    /// <summary>
    /// QHTj88 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    // [System.Web.Script.Services.ScriptService]
    public class QHTj88 : System.Web.Services.WebService
    {

        [WebMethod]
        public string ADDBV(string memloginNO, decimal bv, string md5)
        {
            string md5_one = ShopNum1.Common.MD5JiaMi.MyMd5JiaMi;
            string privateKey_two = "memloginNO=" + memloginNO + "&bv=" + bv + md5_one + "";
            string md5Check_two = ShopNum1.Common.MD5JiaMi.Md5JiaMi(privateKey_two);
            if (md5Check_two.ToUpper() == md5.ToUpper())
            {
                try
                {
                    int cc = ((ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action()).proaddAdvancePayment(memloginNO, bv);
                    if (cc == 2)
                    {
                        return "1";
                    }
                    else
                    {
                        return "0";
                    }

                }
                catch
                {

                    return "2";
                }
            }
            else
            {
                return "3";
            }
        }
    }
}
