using System.Collections.Generic;

namespace ShopNum1.TbBusinessEntity
{
    public class TbItemProp
    {
        private List<TbPropValue> list_0 = new List<TbPropValue>();
        private string string_0 = string.Empty;
        private string string_1 = string.Empty;
        private string string_2 = string.Empty;
        private string string_3 = string.Empty;
        private string string_4 = string.Empty;
        private string string_5 = string.Empty;
        private string string_6 = string.Empty;

        public bool child_template { get; set; }

        public string is_allow_alias
        {
            get { return string_6; }
            set { string_6 = value; }
        }

        public bool is_color_prop { get; set; }

        public bool is_enum_prop { get; set; }

        public bool is_input_prop { get; set; }

        public bool is_item_prop { get; set; }

        public bool is_key_prop { get; set; }

        public bool is_sale_prop { get; set; }

        public bool multi { get; set; }

        public bool must { get; set; }

        public string name
        {
            get { return string_2; }
            set { string_2 = value; }
        }

        public string parent_pid
        {
            get { return string_3; }
            set { string_3 = value; }
        }

        public string parent_vid
        {
            get { return string_4; }
            set { string_4 = value; }
        }

        public List<TbPropValue> prop_values
        {
            get { return list_0; }
            set { list_0 = value; }
        }

        public int sort_order { get; set; }

        public string status
        {
            get { return string_5; }
            set { string_5 = value; }
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