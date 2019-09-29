using System;
using System.Web.Security;

namespace ShopNum1.Payment
{
    public class Nps
    {
        public bool Createurl(string M_ID, string MOrderID, string MOAmount, string MOCurrency, string M_URL,
                              string M_Language, string S_Name, string S_Address, string S_PostCode, string S_Telephone,
                              string S_Email, string R_Name, string R_Address, string R_PostCode, string R_Telephone,
                              string R_Email, string MOComment, string MODate, string State, string digestinfo,
                              string Key, out string url, out string sdigestinfo)
        {
            bool result = true;
            try
            {
                digestinfo = GetOrderMessage(M_ID, MOrderID, MOAmount, MOCurrency, M_URL, "1", S_PostCode, S_Telephone,
                                             S_Email, R_PostCode, R_Telephone, R_Email, MODate, Key);
                sdigestinfo = FormsAuthentication.HashPasswordForStoringInConfigFile("digestinfo", "MD5");
                url = "https://payment.nps.cn/VirReceiveMerchantAction.do?" + sdigestinfo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public string GetOrderMessage(string M_ID, string MOrderID, string MOAmount, string MOCurrency, string M_URL,
                                      string M_Languagestring, string S_PostCode, string S_Telephone, string S_Email,
                                      string R_PostCode, string R_Telephone, string R_Email, string MODate, string Key)
        {
            string result = "";
            try
            {
                M_Languagestring = "1";
                result = string.Concat(new[]
                    {
                        "M_ID=",
                        M_ID,
                        "&MOrderID=",
                        MOrderID,
                        "&MOAmount=",
                        MOAmount,
                        "&MOCurrency=",
                        MOCurrency,
                        "&M_URL=",
                        M_URL,
                        "&M_Languagestring=",
                        M_Languagestring,
                        "&S_PostCode=",
                        S_PostCode,
                        "&S_Telephone=",
                        S_Telephone,
                        "&S_Email=",
                        S_Email,
                        "&R_PostCode=",
                        R_PostCode,
                        "&R_Telephone=",
                        R_Telephone,
                        "&R_Email=",
                        R_Email,
                        "&MODate=",
                        MODate,
                        "&Key=",
                        Key
                    });
            }
            catch (Exception ex)
            {
                result = "创建加密认证时出错,错误信息:" + ex.Message;
            }
            return result;
        }

        public string GetUrl(string M_ID, string MOrderID, string MOAmount, string MOCurrency, string M_URL,
                             string M_Languagestring, string S_Name, string S_Address, string S_PostCode,
                             string S_Telephone, string S_Email, string R_Name, string R_Address, string R_PostCode,
                             string R_Telephone, string R_Email, string MOComment, string MODate, string State,
                             string Key, string digestinfo)
        {
            string result = string.Empty;
            try
            {
                result = string.Concat(new[]
                    {
                        "?M_ID=",
                        M_ID,
                        "&MOrderID=",
                        MOrderID,
                        "&MOAmount=",
                        MOAmount,
                        "&MOCurrency=",
                        MOCurrency,
                        "&M_URL=",
                        M_URL,
                        "&M_Languagestring=",
                        M_Languagestring,
                        "&S_Name=",
                        S_Name,
                        "&S_Address=",
                        S_Address,
                        "&S_PostCode=",
                        S_PostCode,
                        "&S_Telephone=",
                        S_Telephone,
                        "&S_Email=",
                        S_Email,
                        "&R_Name=",
                        R_Name,
                        "&R_Address=",
                        R_Address,
                        "&R_PostCode=",
                        R_PostCode,
                        "&R_Telephone=",
                        R_Telephone,
                        "&R_Email=",
                        R_Email,
                        "&MOComment=",
                        MOComment,
                        "&MODate=",
                        MODate,
                        "&State=",
                        State,
                        "&Key=",
                        Key,
                        "&digestinfo=",
                        digestinfo
                    });
            }
            catch (Exception ex)
            {
                result = "创建URL时出错,错误信息:" + ex.Message;
            }
            return result;
        }
    }
}