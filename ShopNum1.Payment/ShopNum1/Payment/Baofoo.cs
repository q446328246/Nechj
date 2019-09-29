using System.Security.Cryptography;
using System.Text;

namespace ShopNum1.Payment
{
    public class Baofoo
    {
        public static string Md5Encrypt(string strToBeEncrypt)
        {
            MD5 mD = new MD5CryptoServiceProvider();
            byte[] bytes = Encoding.GetEncoding("utf-8").GetBytes(strToBeEncrypt);
            byte[] array = mD.ComputeHash(bytes);
            string text = "";
            for (int i = 0; i < array.Length; i++)
            {
                text += array[i].ToString("x2");
            }
            return text.ToLower();
        }

        public static string GetErrorInfo(string result, string resultDesc)
        {
            string result2;
            if (result == "1")
            {
                result2 = "支付成功";
            }
            else
            {
                string text;
                switch (resultDesc)
                {
                    case "0000":
                        text = "充值失败";
                        goto IL_1D3;
                    case "0001":
                        text = "系统错误";
                        goto IL_1D3;
                    case "0002":
                        text = "订单超时";
                        goto IL_1D3;
                    case "0003":
                        text = "订单状态异常";
                        goto IL_1D3;
                    case "0004":
                        text = "无效商户";
                        goto IL_1D3;
                    case "0015":
                        text = "卡号或卡密错误";
                        goto IL_1D3;
                    case "0016":
                        text = "不合法的IP地址";
                        goto IL_1D3;
                    case "0018":
                        text = "卡密已被使用";
                        goto IL_1D3;
                    case "0019":
                        text = "订单金额错误";
                        goto IL_1D3;
                    case "0020":
                        text = "支付的类型错误";
                        goto IL_1D3;
                    case "0021":
                        text = "卡类型有误";
                        goto IL_1D3;
                    case "0022":
                        text = "卡信息不完整";
                        goto IL_1D3;
                    case "0023":
                        text = "卡号，卡密，金额不正确";
                        goto IL_1D3;
                    case "0024":
                        text = "不能用此卡继续做交易";
                        goto IL_1D3;
                    case "0025":
                        text = "订单无效";
                        goto IL_1D3;
                }
                text = "支付失败";
                IL_1D3:
                result2 = text;
            }
            return result2;
        }
    }
}