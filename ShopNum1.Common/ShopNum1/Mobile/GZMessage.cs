
namespace ShopNum1.Common
{
    [System.Serializable()]
    public class GZMessage
    {
        private int result = 1;

        public int Result
        {
            get { return result; }
            set { result = value; }
        }
        private string code;

        public string Code
        {
            get { return code; }
            set { code = value; }
        }
        private string message;

        public string Message
        {
            get { return message; }
            set { message = value; }
        }
        private object data;

        public object Data
        {
            get { return data; }
            set { data = value; }
        }



  









    
    }
}
