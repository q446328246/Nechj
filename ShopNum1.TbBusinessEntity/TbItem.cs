using System;
using System.Collections.Generic;

namespace ShopNum1.TbBusinessEntity
{
    public class TbItem
    {
        private List<TbItemImg> list_0 = new List<TbItemImg>();
        private List<TbPropImg> list_1 = new List<TbPropImg>();
        private List<TbSku> list_2 = new List<TbSku>();
        private string string_0 = string.Empty;
        private string string_1 = string.Empty;
        private string string_10 = string.Empty;
        private string string_11 = string.Empty;
        private string string_12 = string.Empty;
        private string string_13 = string.Empty;
        private string string_14 = string.Empty;
        private string string_15 = string.Empty;
        private string string_16 = string.Empty;
        private string string_17 = string.Empty;
        private string string_18 = "0.00";
        private string string_19 = "0.00";
        private string string_2 = string.Empty;
        private string string_20 = "0.00";
        private string string_21 = "0.00";
        private string string_22 = string.Empty;
        private string string_23 = string.Empty;
        private string string_24 = string.Empty;
        private string string_25 = string.Empty;
        private string string_26 = string.Empty;
        private string string_27 = string.Empty;
        private string string_28 = string.Empty;
        private string string_29 = string.Empty;
        private string string_3 = string.Empty;
        private string string_30 = string.Empty;
        private string string_31 = string.Empty;
        private string string_32 = string.Empty;
        private string string_33 = string.Empty;
        private string string_34 = string.Empty;
        private string string_35 = string.Empty;
        private string string_36 = string.Empty;
        private string string_37 = string.Empty;
        private string string_38 = string.Empty;
        private string string_4 = string.Empty;
        private string string_5 = string.Empty;
        private string string_6 = string.Empty;
        private string string_7 = string.Empty;
        private string string_8 = string.Empty;
        private string string_9 = string.Empty;
        private TbLocationItem tbLocationItem_0 = new TbLocationItem();

        public string approve_status
        {
            get { return string_30; }
            set { string_30 = value; }
        }

        public string auction_point
        {
            get { return string_33; }
            set { string_33 = value; }
        }

        public string auto_repost
        {
            get { return string_29; }
            set { string_29 = value; }
        }

        public string delist_time
        {
            get
            {
                try
                {
                    return (string_16 = Convert.ToDateTime(string_16).ToString("yyyy-MM-dd HH:mm:ss"));
                }
                catch
                {
                    return ((string_16 == string.Empty) ? "1990-1-1 00:00:00" : "1990-1-1 00:00:00");
                }
            }
            set { string_16 = value; }
        }

        public string desc
        {
            get { return string_11; }
            set { string_11 = value; }
        }

        public string detail_url
        {
            get { return string_1; }
            set { string_1 = value; }
        }

        public string ems_fee
        {
            get
            {
                try
                {
                    return Convert.ToDouble(string_21).ToString(".00");
                }
                catch
                {
                    return ((string_21 != string.Empty) ? "0.00" : "");
                }
            }
            set { string_21 = value; }
        }

        public string express_fee
        {
            get
            {
                try
                {
                    return Convert.ToDouble(string_20).ToString(".00");
                }
                catch
                {
                    return ((string_20 != string.Empty) ? "0.00" : "");
                }
            }
            set { string_20 = value; }
        }

        public string freight_payer
        {
            get { return string_23; }
            set { string_23 = value; }
        }

        public string has_discount
        {
            get { return string_22; }
            set { string_22 = value; }
        }

        public string has_invoice
        {
            get { return string_24; }
            set { string_24 = value; }
        }

        public string has_showcase
        {
            get { return string_26; }
            set { string_26 = value; }
        }

        public string has_warranty
        {
            get { return string_25; }
            set { string_25 = value; }
        }

        public string increment
        {
            get { return string_28; }
            set { string_28 = value; }
        }

        public string input_pids
        {
            get { return string_9; }
            set { string_9 = value; }
        }

        public string input_str
        {
            get { return string_10; }
            set { string_10 = value; }
        }

        public string is_ex
        {
            get { return string_38; }
            set { string_38 = value; }
        }

        public string is_taobao
        {
            get { return string_37; }
            set { string_37 = value; }
        }

        public string is_virtural
        {
            get { return string_36; }
            set { string_36 = value; }
        }

        public List<TbItemImg> item_imgs
        {
            get { return list_0; }
            set { list_0 = value; }
        }

        public string list_time
        {
            get
            {
                try
                {
                    return (string_15 = Convert.ToDateTime(string_15).ToString("yyyy-MM-dd HH:mm:ss"));
                }
                catch
                {
                    return ((string_15 == string.Empty) ? "1990-1-1 00:00:00" : "1990-1-1 00:00:00");
                }
            }
            set { string_15 = value; }
        }

        public TbLocationItem location
        {
            get { return tbLocationItem_0; }
            set { tbLocationItem_0 = value; }
        }

        public string modified
        {
            get
            {
                try
                {
                    return Convert.ToDateTime(string_27).ToString("yyyy-MM-dd HH:mm:ss");
                }
                catch
                {
                    return ((string_27.Trim() != "") ? "1990-1-1 00:00:00" : "1990-1-1 00:00:00");
                }
            }
            set { string_27 = value; }
        }

        public string nick
        {
            get { return string_4; }
            set { string_4 = value; }
        }

        public string num_iid
        {
            get { return string_2; }
            set { string_2 = value; }
        }

        public string outer_id
        {
            get { return string_35; }
            set { string_35 = value; }
        }

        public string pic_url
        {
            get { return string_12; }
            set { string_12 = value; }
        }

        public string post_fee
        {
            get
            {
                try
                {
                    return Convert.ToDouble(string_19).ToString(".00");
                }
                catch
                {
                    return ((string_19 != string.Empty) ? "0.00" : "");
                }
            }
            set { string_19 = value; }
        }

        public string postage_id
        {
            get { return string_31; }
            set { string_31 = value; }
        }

        public string price
        {
            get
            {
                try
                {
                    return Convert.ToDouble(string_18).ToString("#.00");
                }
                catch
                {
                    return ((string_18 != string.Empty) ? "0.00" : "");
                }
            }
            set { string_18 = value; }
        }

        public string product_id
        {
            get { return string_32; }
            set { string_32 = value; }
        }

        public List<TbPropImg> prop_imgs
        {
            get { return list_1; }
            set { list_1 = value; }
        }

        public string property_alias
        {
            get { return string_34; }
            set { string_34 = value; }
        }

        public string props
        {
            get { return string_8; }
            set { string_8 = value; }
        }

        public string seller_cids
        {
            get { return string_7; }
            set { string_7 = value; }
        }

        public List<TbSku> skus
        {
            get { return list_2; }
            set { list_2 = value; }
        }

        public string String_0
        {
            get { return string_0; }
            set { string_0 = value; }
        }

        public string num
        {
            get { return string_6; }
            set { string_6 = value; }
        }

        public string String_2
        {
            get { return string_13; }
            set { string_13 = value; }
        }

        public string stuff_status
        {
            get { return string_17; }
            set { string_17 = value; }
        }

        public string title
        {
            get { return string_3; }
            set { string_3 = value; }
        }

        public string type
        {
            get { return string_5; }
            set { string_5 = value; }
        }

        public string valid_thru
        {
            get { return string_14; }
            set { string_14 = value; }
        }
    }
}