using System;

namespace ShopNum1.Common
{
    public class Order
    {
        public string CreateOrderNumber()
        {
            lock (this)
            {
                string str = DateTime.Today.Year.ToString();
                string str2 = DateTime.Today.Month.ToString();
                if (str2.Length == 1)
                {
                    str2 = "0" + str2;
                }
                string str3 = DateTime.Today.Day.ToString();
                if (str3.Length == 1)
                {
                    str3 = "0" + str3;
                }
                string str4 = DateTime.Now.Minute.ToString();
                if (str4.Length == 1)
                {
                    str4 = "0" + str4;
                }
                string str5 = DateTime.Now.Second.ToString();
                if (str5.Length == 1)
                {
                    str5 = "0" + str5;
                }
                string str6 = DateTime.Now.Millisecond.ToString();
                if (str6.Length == 1)
                {
                    str6 = "00" + str6;
                }
                else if (str6.Length == 2)
                {
                    str6 = "0" + str6;
                }



                return (str + str2 + str3 + str4 + str5 + str6 );
            }
        }



        public string CreateOrderNumberDD(string memberid)
        {
            lock (this)
            {
                string str = DateTime.Today.Year.ToString();
                string str2 = DateTime.Today.Month.ToString();
                if (str2.Length == 1)
                {
                    str2 = "0" + str2;
                }
                string str3 = DateTime.Today.Day.ToString();
                if (str3.Length == 1)
                {
                    str3 = "0" + str3;
                }
                string str4 = DateTime.Now.Minute.ToString();
                if (str4.Length == 1)
                {
                    str4 = "0" + str4;
                }
                string str5 = DateTime.Now.Second.ToString();
                if (str5.Length == 1)
                {
                    str5 = "0" + str5;
                }
                string str6 = DateTime.Now.Millisecond.ToString();
                if (str6.Length == 1)
                {
                    str6 = "00" + str6;
                }
                else if (str6.Length == 2)
                {
                    str6 = "0" + str6;
                }

                string str7 = memberid.Substring(memberid.Length - 3);


                return (str + str2 + str3 + str4 + str5 + str7 + str6);
            }
        }
    }
}