using System.Security.Cryptography;
using System.Text;

namespace ShopNum1.Payment
{
    public class ShengPayMent
    {
        public bool CreateUrl(PayInfo p, out string strUrl)
        {
            var stringBuilder = new StringBuilder();
            string s = string.Concat(new[]
                {
                    p.ShenPayName,
                    p.Version,
                    p.Charset,
                    p.MsgSender,
                    p.SendTime,
                    p.OrderNo,
                    p.OrderAmount,
                    p.OrderTime,
                    p.PayType,
                    p.InstCode,
                    p.PageUrl,
                    p.NotifyUrl,
                    p.PName,
                    p.BuyerContact,
                    p.BuyerIp,
                    p.Ext1,
                    p.SignType,
                    p.keyMer
                });
            MD5 mD = new MD5CryptoServiceProvider();
            byte[] signed = mD.ComputeHash(Encoding.GetEncoding("gbk").GetBytes(s));
            string text = byte2mac(signed);
            p.SignMsg = text.ToUpper();
            stringBuilder.Append(
                "<html><head> \r\n<script type=\"text/javascript\">window.onload = function() { form1.submit(); }</script>\r\n</head>\r\n<body>");
            stringBuilder.Append(
                " <form id=\"form1\" method=\"post\" action=\"http://mas.sdo.com/web-acquire-channel/cashier.htm\">");
            stringBuilder.Append(" <input name=\"Name\" type=\"hidden\" id=\"Name\" value=\"" + p.ShenPayName + "\" />");
            stringBuilder.Append(" <input name=\"Version\" type=\"hidden\" id=\"Version\" value=\"" + p.Version +
                                 "\" />");
            stringBuilder.Append(" <input name=\"Charset\" type=\"hidden\" id=\"Charset\" value=\"" + p.Charset +
                                 "\" />");
            stringBuilder.Append(" <input name=\"MsgSender\" type=\"hidden\" id=\"MsgSender\" value=\"" + p.MsgSender +
                                 "\" />");
            stringBuilder.Append(" <input name=\"SendTime\" type=\"hidden\" id=\"SendTime\" value=\"" + p.SendTime +
                                 "\" />");
            stringBuilder.Append(" <input name=\"OrderNo\" type=\"hidden\" id=\"OrderNo\" value=\"" + p.OrderNo +
                                 "\" />");
            stringBuilder.Append(" <input name=\"OrderAmount\" type=\"hidden\" id=\"OrderAmount\" value=\"" +
                                 p.OrderAmount + "\" />");
            stringBuilder.Append(" <input name=\"OrderTime\" type=\"hidden\" id=\"OrderTime\" value=\"" + p.OrderTime +
                                 "\" />");
            stringBuilder.Append("  <input name=\"PayType\" type=\"hidden\" id=\"PayType\" value=\"" + p.PayType +
                                 "\" />");
            stringBuilder.Append("  <input name=\"payChannel\" type=\"text\" id=\"payChannel\" value=\"" + p.PayChannel +
                                 "\"/>");
            stringBuilder.Append("  <input name=\"InstCode\" type=\"hidden\" id=\"InstCode\" value=\"" + p.InstCode +
                                 "\" />");
            stringBuilder.Append(" <input name=\"PageUrl\" type=\"hidden\" id=\"PageUrl\" value=\"" + p.PageUrl +
                                 "\" />");
            stringBuilder.Append(" <input name=\"NotifyUrl\" type=\"hidden\" id=\"NotifyUrl\" value=\"" + p.NotifyUrl +
                                 "\" />");
            stringBuilder.Append(" <input name=\"ProductName\" type=\"hidden\" id=\"ProductName\" value=\"" + p.PName +
                                 "\" />");
            stringBuilder.Append(" <input name=\"BuyerContact\" type=\"hidden\" id=\"BuyerContact\" value=\"" +
                                 p.BuyerContact + "\" />");
            stringBuilder.Append(" <input name=\"BuyerIp\" type=\"hidden\" id=\"BuyerIp\" value=\"" + p.BuyerIp +
                                 "\" />");
            stringBuilder.Append(" <input name=\"Ext1\" type=\"hidden\" id=\"Ext1\" value=\"" + p.Ext1 + "\" />");
            stringBuilder.Append(" <input name=\"SignType\" type=\"hidden\" id=\"SignType\" value=\"" + p.SignType +
                                 "\" />");
            stringBuilder.Append(" <input name=\"SignMsg\" type=\"hidden\" id=\"SignMsg\" value=\"" + p.SignMsg +
                                 "\" />");
            stringBuilder.Append(" </form>");
            stringBuilder.Append("\r\n</body>");
            stringBuilder.Append("</html>");
            strUrl = stringBuilder.ToString();
            return true;
        }

        public static string byte2mac(byte[] signed)
        {
            var stringBuilder = new StringBuilder();
            for (int i = 0; i < signed.Length; i++)
            {
                byte b = signed[i];
                stringBuilder.AppendFormat("{0:x2}", b);
            }
            return stringBuilder.ToString();
        }
    }
}