using System;
using com.yeepay;

namespace ShopNum1.Payment
{
    public class YeepaySZX
    {
        public bool CreateUrl(string p1_MerId, string keyValue, string p2_Order, string p3_Amt, string p4_Cur,
                              string p5_Pid, string p6_Pcat, string p7_Pdesc, string p8_Url, string p9_SAF, string pa_MP,
                              string pd_FrpId, string pr_NeedResponse, string formID, out string url,
                              out string htmlCodePost)
        {
            bool result = true;
            try
            {
                htmlCodePost = SZX.CreateForm(p1_MerId, keyValue, p2_Order, p3_Amt, p4_Cur, p5_Pid, p6_Pcat, p7_Pdesc,
                                              p8_Url, p9_SAF, pa_MP, pr_NeedResponse, formID);
                url = SZX.CreateUrl(p1_MerId, keyValue, p2_Order, p3_Amt, p4_Cur, p5_Pid, p6_Pcat, p7_Pdesc, p8_Url,
                                    p9_SAF, pa_MP, pr_NeedResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
    }
}