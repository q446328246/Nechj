using System;
using System.Collections.Generic;

namespace ShopNum1.TbBusinessEntity
{
    public class TbTrade
    {
        private string string_0 = string.Empty;
        private string string_1 = string.Empty;
        private string string_2 = string.Empty;
        private string string_3 = string.Empty;
        private string string_4 = string.Empty;
        private string string_5 = string.Empty;
        private string string_6 = string.Empty;
        private string string_7 = string.Empty;
        private string string_8 = string.Empty;
        private string string_9 = string.Empty;
        private bool bool_0 = false;
        private bool bool_1 = false;
        private string string_10 = string.Empty;
        private string string_11 = string.Empty;
        private string string_12 = string.Empty;
        private string string_13 = string.Empty;
        private string string_14 = string.Empty;
        private string string_15 = string.Empty;
        private string string_16 = string.Empty;
        private string string_17 = string.Empty;
        private string string_18 = string.Empty;
        private string string_19 = string.Empty;
        private string string_20 = string.Empty;
        private string string_21 = string.Empty;
        private string string_22 = string.Empty;
        private string string_23 = string.Empty;
        private string string_24 = string.Empty;
        private string string_25 = string.Empty;
        private string string_26 = string.Empty;
        private string string_27 = string.Empty;
        private string string_28 = string.Empty;
        private int int_0 = 0;
        private string string_29 = string.Empty;
        private string string_30 = string.Empty;
        private string string_31 = string.Empty;
        private List<TbOrder> list_0 = new List<TbOrder>();
        private string string_32 = string.Empty;
        private string string_33 = string.Empty;
        private string string_34 = string.Empty;
        private string string_35 = string.Empty;
        private string string_36 = string.Empty;
        private string string_37 = string.Empty;
        private string string_38 = string.Empty;
        private string string_39 = string.Empty;
        private string string_40 = string.Empty;
        private string string_41 = string.Empty;
        private string string_42 = string.Empty;
        private string string_43 = string.Empty;
        private string string_44 = string.Empty;
        public string seller_nick
        {
            get
            {
                return this.string_0;
            }
            set
            {
                this.string_0 = value;
            }
        }
        public string buyer_nick
        {
            get
            {
                return this.string_1;
            }
            set
            {
                this.string_1 = value;
            }
        }
        public string title
        {
            get
            {
                return this.string_2;
            }
            set
            {
                this.string_2 = value;
            }
        }
        public string type
        {
            get
            {
                return this.string_3;
            }
            set
            {
                this.string_3 = value;
            }
        }
        public string typeText
        {
            get
            {
                string text = this.string_3;
                string result;
                switch (text)
                {
                    case "fixed":
                        result = "一口价";
                        return result;
                    case "auction":
                        result = "拍卖";
                        return result;
                    case "guarantee_trade":
                        result = "一口价拍卖";
                        return result;
                    case "auto_delivery":
                        result = "自动发货";
                        return result;
                    case "independent_simple_trade":
                        result = "旺店入门版交易";
                        return result;
                    case "independent_shop_trade":
                        result = "旺店标准版交易";
                        return result;
                    case "ec":
                        result = "直冲";
                        return result;
                    case "cod":
                        result = "货到付款";
                        return result;
                    case "fenxiao":
                        result = "分销";
                        return result;
                    case "game_equipment":
                        result = "游戏装备";
                        return result;
                    case "shopex_trade":
                        result = "ShopEX交易";
                        return result;
                    case "netcn_trade":
                        result = "万网交易";
                        return result;
                }
                result = "未知其它";
                return result;
            }
        }
        public string created
        {
            get
            {
                string result;
                try
                {
                    result = Convert.ToDateTime(this.string_4).ToString("yyyy-MM-dd HH:mm:ss");
                }
                catch
                {
                    result = ((this.string_4.Trim() != "") ? "1990-1-1 00:00:00" : string.Empty);
                }
                return result;
            }
            set
            {
                this.string_4 = value;
            }
        }
        public string tid
        {
            get
            {
                return this.string_5;
            }
            set
            {
                this.string_5 = value;
            }
        }
        public string num
        {
            get
            {
                return this.string_6;
            }
            set
            {
                this.string_6 = value;
            }
        }
        public string String_2
        {
            get
            {
                return this.string_7;
            }
            set
            {
                this.string_7 = value;
            }
        }
        public string status
        {
            get
            {
                return this.string_8;
            }
            set
            {
                this.string_8 = value;
            }
        }
        public string statusText
        {
            get
            {
                string result = string.Empty;
                string text = this.string_8;
                switch (text)
                {
                    case "TRADE_NO_CREATE_PAY":
                        result = "没有创建支付宝交易";
                        break;
                    case "WAIT_BUYER_PAY":
                        result = "等待付款";
                        break;
                    case "WAIT_SELLER_SEND_GOODS":
                        result = "买家已付款";
                        break;
                    case "WAIT_BUYER_CONFIRM_GOODS":
                        result = "待确认收货";
                        break;
                    case "TRADE_BUYER_SIGNED":
                        result = "买家已签收";
                        break;
                    case "TRADE_FINISHED":
                        result = "交易成功";
                        break;
                    case "TRADE_CLOSED":
                        result = "交易关闭";
                        break;
                    case "TRADE_CLOSED_BY_TAOBAO":
                        result = "被淘宝关闭";
                        break;
                    case "ALL_WAIT_PAY":
                        result = "ALL等待付款";
                        break;
                    case "ALL_CLOSED":
                        result = "ALL交易关闭";
                        break;
                }
                return result;
            }
        }
        public string statusHtml
        {
            get
            {
                return this.string_9;
            }
            set
            {
                this.string_9 = value;
            }
        }
        public bool seller_rate
        {
            get
            {
                return this.bool_0;
            }
            set
            {
                this.bool_0 = value;
            }
        }
        public bool buyer_rate
        {
            get
            {
                return this.bool_1;
            }
            set
            {
                this.bool_1 = value;
            }
        }
        public string received_payment
        {
            get
            {
                return this.string_10;
            }
            set
            {
                this.string_10 = value;
            }
        }
        public string payment
        {
            get
            {
                string result;
                try
                {
                    result = Convert.ToDouble(this.string_11).ToString("#.00");
                }
                catch
                {
                    result = "0.00";
                }
                return result;
            }
            set
            {
                this.string_11 = value;
            }
        }
        public string discount_fee
        {
            get
            {
                string result;
                try
                {
                    result = Convert.ToDouble(this.string_12).ToString("#.00");
                }
                catch
                {
                    result = "0.00";
                }
                return result;
            }
            set
            {
                this.string_12 = value;
            }
        }
        public string adjust_fee
        {
            get
            {
                string result;
                try
                {
                    result = Convert.ToDouble(this.string_13).ToString("#.00");
                }
                catch
                {
                    result = "0.00";
                }
                return result;
            }
            set
            {
                this.string_13 = value;
            }
        }
        public string post_fee
        {
            get
            {
                string result;
                try
                {
                    result = Convert.ToDouble(this.string_14).ToString("#.00");
                }
                catch
                {
                    result = "0.00";
                }
                return result;
            }
            set
            {
                this.string_14 = value;
            }
        }
        public string total_fee
        {
            get
            {
                string result;
                try
                {
                    result = Convert.ToDouble(this.string_15).ToString("#.00");
                }
                catch
                {
                    result = "0.00";
                }
                return result;
            }
            set
            {
                this.string_15 = value;
            }
        }
        public string pay_time
        {
            get
            {
                string result;
                try
                {
                    result = Convert.ToDateTime(this.string_16).ToString("yyyy-MM-dd HH:mm:ss");
                }
                catch
                {
                    result = "1990-1-1 00:00:00";
                }
                return result;
            }
            set
            {
                this.string_16 = value;
            }
        }
        public string end_time
        {
            get
            {
                string result;
                try
                {
                    result = Convert.ToDateTime(this.string_17).ToString("yyyy-MM-dd HH:mm:ss");
                }
                catch
                {
                    result = "1990-1-1 00:00:00";
                }
                return result;
            }
            set
            {
                this.string_17 = value;
            }
        }
        public string modified
        {
            get
            {
                string result;
                try
                {
                    result = Convert.ToDateTime(this.string_18).ToString("yyyy-MM-dd HH:mm:ss");
                }
                catch
                {
                    result = "1990-1-1 00:00:00";
                }
                return result;
            }
            set
            {
                this.string_18 = value;
            }
        }
        public string consign_time
        {
            get
            {
                string result;
                try
                {
                    result = Convert.ToDateTime(this.string_19).ToString("yyyy-MM-dd HH:mm:ss");
                }
                catch
                {
                    result = "1990-1-1 00:00:00";
                }
                return result;
            }
            set
            {
                this.string_19 = value;
            }
        }
        public string buyer_obtain_point_fee
        {
            get
            {
                string result;
                try
                {
                    result = Convert.ToDouble(this.string_20).ToString("#0");
                }
                catch
                {
                    result = "0";
                }
                return result;
            }
            set
            {
                this.string_20 = value;
            }
        }
        public string point_fee
        {
            get
            {
                string result;
                try
                {
                    result = Convert.ToDouble(this.string_21).ToString("#0");
                }
                catch
                {
                    result = "0";
                }
                return result;
            }
            set
            {
                this.string_21 = value;
            }
        }
        public string real_point_fee
        {
            get
            {
                string result;
                try
                {
                    result = Convert.ToDouble(this.string_22).ToString("#0");
                }
                catch
                {
                    result = "0";
                }
                return result;
            }
            set
            {
                this.string_22 = value;
            }
        }
        public string commission_fee
        {
            get
            {
                string result;
                try
                {
                    result = Convert.ToDouble(this.string_23).ToString("#0.00");
                }
                catch
                {
                    result = "0.00";
                }
                return result;
            }
            set
            {
                this.string_23 = value;
            }
        }
        public string buyer_memo
        {
            get
            {
                return this.string_24;
            }
            set
            {
                this.string_24 = value;
            }
        }
        public string seller_memo
        {
            get
            {
                return this.string_25;
            }
            set
            {
                this.string_25 = value;
            }
        }
        public string alipay_no
        {
            get
            {
                return this.string_26;
            }
            set
            {
                this.string_26 = value;
            }
        }
        public string buyer_message
        {
            get
            {
                return this.string_27;
            }
            set
            {
                this.string_27 = value;
            }
        }
        public string pic_path
        {
            get
            {
                return this.string_28;
            }
            set
            {
                this.string_28 = value;
            }
        }
        public int Int32_0
        {
            get
            {
                return this.int_0;
            }
            set
            {
                this.int_0 = value;
            }
        }
        public string price
        {
            get
            {
                string result;
                try
                {
                    result = Convert.ToDouble(this.string_29).ToString("#.00");
                }
                catch
                {
                    result = "0.00";
                }
                return result;
            }
            set
            {
                this.string_29 = value;
            }
        }
        public string cod_fee
        {
            get
            {
                string result;
                try
                {
                    result = Convert.ToDouble(this.string_30).ToString("#.00");
                }
                catch
                {
                    result = "0.00";
                }
                return result;
            }
            set
            {
                this.string_30 = value;
            }
        }
        public string shipping_type
        {
            get
            {
                return this.string_31;
            }
            set
            {
                this.string_31 = value;
            }
        }
        public string shipping_typeText
        {
            get
            {
                string text = this.string_31;
                string result;
                if (text != null)
                {
                    if (text == "free")
                    {
                        result = "卖家承担运费";
                        return result;
                    }
                    if (text == "post")
                    {
                        result = "平邮";
                        return result;
                    }
                    if (text == "express")
                    {
                        result = "快递";
                        return result;
                    }
                    if (text == "ems")
                    {
                        result = "EMS";
                        return result;
                    }
                    if (text == "virtual")
                    {
                        result = "虚拟物品";
                        return result;
                    }
                }
                result = "其它类型";
                return result;
            }
        }
        public List<TbOrder> orders
        {
            get
            {
                return this.list_0;
            }
            set
            {
                this.list_0 = value;
            }
        }
        public string receiver_name
        {
            get
            {
                return this.string_32;
            }
            set
            {
                this.string_32 = value;
            }
        }
        public string receiver_state
        {
            get
            {
                return this.string_33;
            }
            set
            {
                this.string_33 = value;
            }
        }
        public string receiver_city
        {
            get
            {
                return this.string_34;
            }
            set
            {
                this.string_34 = value;
            }
        }
        public string receiver_district
        {
            get
            {
                return this.string_35;
            }
            set
            {
                this.string_35 = value;
            }
        }
        public string receiver_address
        {
            get
            {
                return this.string_36;
            }
            set
            {
                this.string_36 = value;
            }
        }
        public string receiver_zip
        {
            get
            {
                return this.string_37;
            }
            set
            {
                this.string_37 = value;
            }
        }
        public string receiver_mobile
        {
            get
            {
                return this.string_38;
            }
            set
            {
                this.string_38 = value;
            }
        }
        public string receiver_phone
        {
            get
            {
                return this.string_39;
            }
            set
            {
                this.string_39 = value;
            }
        }
        public string num_iid
        {
            get
            {
                return this.string_40;
            }
            set
            {
                this.string_40 = value;
            }
        }
        public string buyer_alipay_no
        {
            get
            {
                return this.string_41;
            }
            set
            {
                this.string_41 = value;
            }
        }
        public string buyer_email
        {
            get
            {
                return this.string_42;
            }
            set
            {
                this.string_42 = value;
            }
        }
        public string trade_memo
        {
            get
            {
                return this.string_43;
            }
            set
            {
                this.string_43 = value;
            }
        }
        public string seller_name
        {
            get
            {
                return this.string_44;
            }
            set
            {
                this.string_44 = value;
            }
        }
    }
}