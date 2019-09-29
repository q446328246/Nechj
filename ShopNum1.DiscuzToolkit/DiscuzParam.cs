using System;
using System.Text;
using System.Web;

namespace ShopNum1.DiscuzToolkit
{
    public class DiscuzParam : IComparable
    {
        private readonly object object_0;
        private readonly string string_0;

        protected DiscuzParam(string name, object value)
        {
            string_0 = name;
            object_0 = value;
        }

        public string EncodedValue
        {
            get
            {
                if (object_0 is Array)
                {
                    return HttpUtility.UrlEncode(smethod_0(object_0 as Array));
                }
                return HttpUtility.UrlEncode(object_0.ToString());
            }
        }

        public string Name
        {
            get { return string_0; }
        }

        public string Value
        {
            get
            {
                if (object_0 is Array)
                {
                    return smethod_0(object_0 as Array);
                }
                return object_0.ToString();
            }
        }

        public int CompareTo(object target)
        {
            if (target is DiscuzParam)
            {
                return string_0.CompareTo((target as DiscuzParam).string_0);
            }
            return -1;
        }

        public static DiscuzParam Create(string name, object value)
        {
            return new DiscuzParam(name, value);
        }

        private static string smethod_0(Array array_0)
        {
            var builder = new StringBuilder();
            for (int i = 0; i < array_0.Length; i++)
            {
                if (i > 0)
                {
                    builder.Append(",");
                }
                builder.Append(array_0.GetValue(i));
            }
            return builder.ToString();
        }

        public string ToEncodedString()
        {
            return string.Format("{0}={1}", Name, EncodedValue);
        }

        public override string ToString()
        {
            return string.Format("{0}={1}", Name, Value);
        }
    }
}