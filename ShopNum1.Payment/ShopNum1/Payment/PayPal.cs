using System;
using System.Text;

namespace ShopNum1.Payment
{
    public class PayPal
    {
        public bool CreateUrl(string gatewayurl, string business, string item_name, string item_number, decimal amount,
                              string on0, string os0, string on1, string os1, string currency, string successful,
                              string error, out string url1)
        {
            bool result = true;
            try
            {
                var stringBuilder = new StringBuilder();
                stringBuilder.Append(gatewayurl);
                stringBuilder.Append("=" + business);
                stringBuilder.Append("&item_name=" + item_name + " Order " + item_number);
                stringBuilder.Append("&item_number=" + item_number);
                stringBuilder.Append("&amount=" + string.Format("{0:0.00}", amount));
                stringBuilder.Append("&on0=" + on0);
                stringBuilder.Append("&os0=" + os0);
                stringBuilder.Append("&on1=" + on1);
                stringBuilder.Append("&lang=" + os1);
                stringBuilder.Append("&currency=" + currency);
                stringBuilder.Append("&return=" + successful);
                stringBuilder.Append("&cancel_return=" + error);
                string text = stringBuilder.ToString();
                url1 = text;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
    }
}