using System;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;

namespace UdpaySecurity
{
    public static class UdpayRsa
    {
        public static bool LoadSignKey()
        {
            bool result;
            try
            {
                var array = new char[256];
                var array2 = new char[6];
                var array3 = new char[256];
                var array4 = new char[128];
                var array5 = new char[128];
                var array6 = new char[128];
                var array7 = new char[128];
                var array8 = new char[128];
                a(SignKeyParams.MPK, array, array2, array3, array5, array4, array6, array7, array8);
                SignKeyParams.RSAParams1.Exponent = a(array2);
                SignKeyParams.RSAParams1.Modulus = a(array);
                SignKeyParams.RSAParams1.D = a(array3);
                SignKeyParams.RSAParams1.DP = a(array4);
                SignKeyParams.RSAParams1.DQ = a(array5);
                SignKeyParams.RSAParams1.InverseQ = a(array6);
                SignKeyParams.RSAParams1.P = a(array7);
                SignKeyParams.RSAParams1.Q = a(array8);
                int num = SignKeyParams.Wht_e.IndexOf("=", 0);
                int num2;
                if (SignKeyParams.Wht_e[num + 1].Equals(SignKeyParams.Wht_e[num + 2]) &&
                    SignKeyParams.Wht_e[num + 1].Equals('0'))
                {
                    num += 3;
                    num2 = SignKeyParams.Wht_e.Length - num;
                }
                else
                {
                    num++;
                    num2 = SignKeyParams.Wht_e.Length - num;
                }
                var array9 = new char[num2];
                SignKeyParams.Wht_e.CopyTo(num, array9, 0, num2);
                num = SignKeyParams.Wht_n.IndexOf("=", 0);
                if (SignKeyParams.Wht_n[num + 1].Equals(SignKeyParams.Wht_n[num + 2]) &&
                    SignKeyParams.Wht_n[num + 1].Equals('0'))
                {
                    num += 3;
                    num2 = SignKeyParams.Wht_n.Length - num;
                }
                else
                {
                    num++;
                    num2 = SignKeyParams.Wht_n.Length - num;
                }
                var array10 = new char[num2];
                SignKeyParams.Wht_n.CopyTo(num, array10, 0, num2);
                SignKeyParams.RSAParams2.Exponent = a(array9);
                SignKeyParams.RSAParams2.Modulus = a(array10);
                result = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("The key could not be read:");
                Console.WriteLine(ex.Message);
                result = false;
            }
            return result;
        }

        public static string GenerateSigature(string PText)
        {
            return a(PText);
        }

        public static int VerifySigature(string PText, string Sign)
        {
            int result;
            if (a(PText, Sign))
            {
                result = 0;
            }
            else
            {
                result = -1;
            }
            return result;
        }

        private static string a(string A_0)
        {
            Encoding encoding = Encoding.GetEncoding(936);
            byte[] bytes = encoding.GetBytes(A_0);
            var rSACryptoServiceProvider = new RSACryptoServiceProvider();
            rSACryptoServiceProvider.ImportParameters(SignKeyParams.RSAParams1);
            var halg = new MD5CryptoServiceProvider();
            byte[] a_ = rSACryptoServiceProvider.SignData(bytes, halg);
            return a(a_);
        }

        private static bool a(string A_0, string A_1)
        {
            Encoding encoding = Encoding.GetEncoding(936);
            byte[] bytes = encoding.GetBytes(A_0);
            var array = new char[A_1.Length];
            A_1 = A_1.ToUpper();
            A_1.CopyTo(0, array, 0, A_1.Length);
            byte[] signature = a(array);
            var rSACryptoServiceProvider = new RSACryptoServiceProvider();
            rSACryptoServiceProvider.ImportParameters(SignKeyParams.RSAParams2);
            var halg = new MD5CryptoServiceProvider();
            return rSACryptoServiceProvider.VerifyData(bytes, halg, signature);
        }

        private static void a(string A_0, char[] A_1, char[] A_2, char[] A_3, char[] A_4, char[] A_5, char[] A_6,
                              char[] A_7, char[] A_8)
        {
            int num = A_0.IndexOf("02818100", 0);
            if (num == -1)
            {
                num = A_0.IndexOf("028180", 0) + 6;
            }
            else
            {
                num += 8;
            }
            A_0.CopyTo(num, A_1, 0, 256);
            num += 256;
            int num2 = num;
            num = A_0.IndexOf("02818100", num2, 30);
            if (num == -1)
            {
                num = A_0.IndexOf("028180", 0) - 6;
                num2 = num + 12;
            }
            else
            {
                num -= 6;
                num2 = num + 14;
            }
            A_0.CopyTo(num, A_2, 0, 6);
            A_0.CopyTo(num2, A_3, 0, 256);
            num = num2 + 256;
            num2 = num;
            num = A_0.IndexOf("0240", num2, 6);
            if (num == -1)
            {
                num = A_0.IndexOf("024100", num2, 6) + 6;
            }
            else
            {
                num += 4;
            }
            A_0.CopyTo(num, A_7, 0, 128);
            num += 128;
            num2 = num;
            num = A_0.IndexOf("0240", num2, 6);
            if (num == -1)
            {
                num = A_0.IndexOf("024100", num2, 6) + 6;
            }
            else
            {
                num += 4;
            }
            A_0.CopyTo(num, A_8, 0, 128);
            num += 128;
            num2 = num;
            num = A_0.IndexOf("0240", num2, 6);
            if (num == -1)
            {
                num = A_0.IndexOf("024100", num2, 6) + 6;
            }
            else
            {
                num += 4;
            }
            A_0.CopyTo(num, A_5, 0, 128);
            num += 128;
            num2 = num;
            num = A_0.IndexOf("0240", num2, 6);
            if (num == -1)
            {
                num = A_0.IndexOf("024100", num2, 6) + 6;
            }
            else
            {
                num += 4;
            }
            A_0.CopyTo(num, A_4, 0, 128);
            num += 128;
            num2 = num;
            num = A_0.IndexOf("0240", num2, 6);
            if (num == -1)
            {
                num = A_0.IndexOf("024100", num2, 6) + 6;
            }
            else
            {
                num += 4;
            }
            A_0.CopyTo(num, A_6, 0, 128);
        }

        private static byte[] a(char[] A_0)
        {
            var array = new byte[A_0.Length/2];
            for (int i = 0; i < A_0.Length/2; i++)
            {
                int num;
                if (A_0[2*i] <= '9')
                {
                    num = (Convert.ToInt16(A_0[2*i]) - 48);
                }
                else
                {
                    num = (Convert.ToInt16(A_0[2*i]) - 55);
                }
                int num2;
                if (A_0[2*i + 1] <= '9')
                {
                    num2 = (Convert.ToInt16(A_0[2*i + 1]) - 48);
                }
                else
                {
                    num2 = (Convert.ToInt16(A_0[2*i + 1]) - 55);
                }
                array[i] = Convert.ToByte(num*16 + num2);
            }
            return array;
        }

        private static string a(byte[] A_0)
        {
            string text = null;
            for (int i = 0; i < A_0.Length; i++)
            {
                int num = Convert.ToInt16(A_0[i]);
                int num2 = num/16;
                char value;
                if (num2 <= 9)
                {
                    value = Convert.ToChar(num2 + 48);
                }
                else
                {
                    value = Convert.ToChar(num2 + 55);
                }
                num2 = num%16;
                char value2;
                if (num2 <= 9)
                {
                    value2 = Convert.ToChar(num2 + 48);
                }
                else
                {
                    value2 = Convert.ToChar(num2 + 55);
                }
                text = text + Convert.ToString(value) + Convert.ToString(value2);
            }
            return text.ToLower();
        }

        [StructLayout(LayoutKind.Sequential, Size = 1)]
        public struct SignKeyParams
        {
            public static string MPK;
            public static string Wht_n;
            public static string Wht_e;
            public static string message;
            public static RSAParameters RSAParams1 = default(RSAParameters);
            public static RSAParameters RSAParams2 = default(RSAParameters);
        }
    }
}