using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

namespace ShopNum1.Common
{
    public static class MD5JiaMi
    {
        /**/
        /// <summary>
        /// MD5　32位加密
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns
        public static string Md5JiaMi(string strPwd)
        {

            string cl = strPwd;
            string pwd = "";
            MD5 md5 = new MD5CryptoServiceProvider();//实例化一个md5对像
            // 加密后是一个字节类型的数组，这里要注意编码UTF8/Unicode等的选择　
            byte[] s = md5.ComputeHash(Encoding.UTF8.GetBytes(cl));
            // 通过使用循环，将字节类型的数组转换为字符串，此字符串是常规字符格式化所得
            for (int i = 0; i < s.Length; i++)
            {
                // 将得到的字符串使用十六进制类型格式。格式后的字符是小写的字母，如果使用大写（X）则格式后的字符是大写字符 

                pwd += Convert.ToString(s[i], 16).PadLeft(2, '0');

            }



            return pwd.PadLeft(32, '0');


        }
        public static string ShopETHAddress = "0xf47e0e6cd02205e19411a46dd0960b4d23442798";
        public static string MyMd5JiaMi = "Kce123";
        public static string key = "C5hsYjd2";
        public static string secret = "ks7HDsid";
    }
}
