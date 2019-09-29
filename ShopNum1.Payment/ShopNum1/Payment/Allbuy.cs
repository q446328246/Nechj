using System;

namespace ShopNum1.Payment
{
    public class Allbuy
    {
        public bool Createurl(string merchant, string BillNo, string amount, string Date, string Remark, string BackUrl,
                              out string url)
        {
            bool result = true;
            try
            {
                url = "http://www.allbuy.cn/newpayment/iepayment2.asp" +
                      a(merchant, BillNo, amount, Date, Remark, BackUrl);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        private string a(string A_0, string A_1, string A_2, string A_3, string A_4, string A_5)
        {
            string result = "";
            try
            {
                result = string.Concat(new[]
                    {
                        "?merchant=",
                        A_0,
                        "&BillNo=",
                        A_1,
                        "&amount=",
                        A_2,
                        "&Date=",
                        A_3,
                        "&Remark=",
                        A_4,
                        "&BackUrl=",
                        A_5
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