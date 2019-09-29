
namespace ShopNum1.Common
{
    [System.Serializable()]
    public class MMessage
    {
        private int result = 1;

        public int Result
        {
            get { return result; }
            set { result = value; }
        }
        private string error_code;

        public string Error_code
        {
            get { return error_code; }
            set { error_code = value; }
        }
        private string error_message;

        public string Error_message
        {
            get { return error_message; }
            set { error_message = value; }
        }
        private object data;

        public object Data
        {
            get { return data; }
            set { data = value; }
        }

        private object succeed_message;

        public object Succeed_message
        {
            get { return succeed_message; }
            set { succeed_message = value; }
        }

        private object hDFK;

        public object HDFK
        {
            get { return hDFK; }
            set { hDFK = value; }
        }

        private object postage;

        public object Postage
        {
            get { return postage; }
            set { postage = value; }
        }

        private object succeed_code;

        public object Succeed_code
        {
            get { return succeed_code; }
            set { succeed_code = value; }
        }

        private decimal firstHeavy;

        public decimal FirstHeavy
        {
            get { return firstHeavy; }
            set { firstHeavy = value; }
        }

        private decimal afterHeavyPrice;

        public decimal AfterHeavyPrice
        {
            get { return afterHeavyPrice; }
            set { afterHeavyPrice = value; }
        }

        private decimal firstHeavyPrice;

        public decimal FirstHeavyPrice
        {
            get { return firstHeavyPrice; }
            set { firstHeavyPrice = value; }
        }
    }
}
