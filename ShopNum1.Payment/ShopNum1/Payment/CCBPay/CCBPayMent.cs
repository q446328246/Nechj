using System.Security.Cryptography;
using System.Text;
using System.Web.Security;

namespace ShopNum1.Payment.CCBPay
{
    public class CCBPayMent
    {
        public bool GetURLCCBPayMent(PayInfo payinfo, out string strUrl)
        {
            string text = "https://ibsbjstar.ccb.com.cn/app/ccbMain";
            string str = string.Concat(new[]
                {
                    "MERCHANTID=",
                    payinfo.CCBMerchantID.Trim(),
                    "&POSID=",
                    payinfo.CCBPosID.Trim(),
                    "&BRANCHID=",
                    payinfo.CCBBranchID.Trim(),
                    "&ORDERID=",
                    payinfo.CCBOrderID.Trim(),
                    "&PAYMENT=",
                    payinfo.CCBPayMent.Trim(),
                    "&CURCODE=",
                    payinfo.CCBCurCode.Trim(),
                    "&TXCODE=",
                    payinfo.CCBTxCode.Trim(),
                    "&REMARK1=",
                    payinfo.CCBRemark1.Trim(),
                    "&REMARK2=",
                    payinfo.CCBRemark2.Trim()
                });
            string text2 = str +
                           "&TYPE=1&PUB=cdb3a8ff352b02661e5ff96d020111&GATEWAY=&CLIENTIP=&REGINFO=&PROINFO=&REFERER=";
            string text3 = str + "&TYPE=1&GATEWAY=&CLIENTIP=&REGINFO=&PROINFO=&REFERER=";
            string text4 = ToMD5(text2.Trim()).ToLower().Trim();
            strUrl = string.Concat(new[]
                {
                    text,
                    "?",
                    text3.Trim(),
                    "&MAC=",
                    text4.Trim()
                });
            return true;
        }

        private string a(string A_0)
        {
            MD5 mD = new MD5CryptoServiceProvider();
            byte[] array = mD.ComputeHash(Encoding.Default.GetBytes(A_0));
            var stringBuilder = new StringBuilder(32);
            for (int i = 0; i < array.Length; i++)
            {
                stringBuilder.Append(array[i].ToString("x").PadLeft(2, '0'));
            }
            return stringBuilder.ToString();
        }

        public static string ToMD5(string str)
        {
            return FormsAuthentication.HashPasswordForStoringInConfigFile(str, "MD5");
        }
    }
}