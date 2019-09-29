using System.Web;

namespace ShopNum1.DiscuzCommon
{
    public class DisRequestObject
    {
        private readonly bool bool_0 = true;
        private readonly bool bool_1 = true;
        private readonly int int_0;
        private readonly int int_1;
        private readonly string string_0 = string.Empty;
        private readonly string string_1 = string.Empty;
        private readonly string string_2 = string.Empty;

        public DisRequestObject(HttpRequest dis_request)
        {
            string_0 = string.Empty;
            int_0 = 0;
            bool_1 = false;
            bool_0 = false;
            if (dis_request.QueryString.Count == 0)
            {
                bool_1 = true;
                bool_0 = true;
            }
            else
            {
                if (dis_request["action"] != null)
                {
                    bool_1 = false;
                    string_0 = dis_request["action"].Trim().ToLower();
                }
                if (dis_request["time"] != null)
                {
                    int_0 = DisRequestActions.StringToInt(dis_request["time"].Trim().ToLower());
                }
                if (dis_request["user_name"] != null)
                {
                    string_1 = dis_request["user_name"];
                }
                if (dis_request["uid"] != null)
                {
                    int_1 = DisRequestActions.StringToInt(dis_request["uid"].Trim().ToUpper());
                }
                if (dis_request["sig"] != null)
                {
                    string_2 = dis_request["sig"];
                }
                if ((DisRequestActions.UnixTimestamp() - int_0) > 0xe10)
                {
                    bool_0 = false;
                }
            }
        }

        public string Action
        {
            get { return string_0; }
        }

        public int Int32_0
        {
            get { return int_1; }
        }

        public bool IsAuthracationExpiried
        {
            get { return bool_0; }
        }

        public bool IsInvalidAction
        {
            get { return !DisRequestActions.IsValidAction(string_0); }
        }

        public bool IsInvalidRequest
        {
            get { return bool_1; }
        }

        public string Sig
        {
            get { return string_2; }
        }

        public int Timestamp
        {
            get { return int_0; }
        }

        public string user_name
        {
            get { return string_1; }
        }
    }
}