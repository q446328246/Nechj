using System;

namespace ShopNum1.TbBusinessEntity
{
    [Serializable]
    public class TbPropImg
    {
        private string string_0 = string.Empty;
        private string string_1 = string.Empty;
        private string string_2 = string.Empty;
        private string string_3 = string.Empty;

        public string position
        {
            get { return string_3; }
            set { string_3 = value; }
        }

        public string properties
        {
            get { return string_2; }
            set { string_2 = value; }
        }

        public string String_0
        {
            get { return string_0; }
            set { string_0 = value; }
        }

        public string String_1
        {
            get { return string_1; }
            set { string_1 = value; }
        }
    }
}