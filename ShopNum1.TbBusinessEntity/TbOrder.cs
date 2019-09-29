using System;

namespace ShopNum1.TbBusinessEntity
{
    public class TbOrder
    {
        private string string_0 = string.Empty;
        private string string_1 = string.Empty;
        private string string_2 = string.Empty;
        private int int_0 = 0;
        private string string_3 = string.Empty;
        private string string_4 = string.Empty;
        private string string_5 = string.Empty;
        private string string_6 = string.Empty;
        private string string_7 = string.Empty;
        private string string_8 = string.Empty;
        private string string_9 = string.Empty;
        private string string_10 = string.Empty;
        private string string_11 = string.Empty;
        private string string_12 = string.Empty;
        private string string_13 = string.Empty;
        private string string_14 = string.Empty;
        private string string_15 = string.Empty;
        private bool bool_0 = false;
        private bool bool_1 = false;
        private string string_16 = string.Empty;
        private string string_17 = string.Empty;
        public string title
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
        public string pic_path
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
        public string price
        {
            get
            {
                string result;
                try
                {
                    result = Convert.ToDouble(this.string_2).ToString("#.00");
                }
                catch
                {
                    result = "0.00";
                }
                return result;
            }
            set
            {
                this.string_2 = value;
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
        public string oid
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
        public string sku_id
        {
            get
            {
                return this.string_4;
            }
            set
            {
                this.string_4 = value;
            }
        }
        public string refund_status
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
        public string refund_statusText
        {
            get
            {
                string result = string.Empty;
                string text = this.string_5;
                switch (text)
                {
                    case "WAIT_SELLER_AGREE":
                        result = "买家已经申请退款，等待卖家同意";
                        return result;
                    case "WAIT_BUYER_RETURN_GOODS":
                        result = "卖家已经同意退款，等待买家退货";
                        return result;
                    case "WAIT_SELLER_CONFIRM_GOODS":
                        result = "买家已经退货，等待卖家确认收货";
                        return result;
                    case "SELLER_REFUSE_BUYER":
                        result = "卖家拒绝退款";
                        return result;
                    case "CLOSED":
                        result = "退款关闭";
                        return result;
                    case "SUCCESS":
                        result = "退款成功";
                        return result;
                }
                result = "";
                return result;
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
        public string total_fee
        {
            get
            {
                string result;
                try
                {
                    result = Convert.ToDouble(this.string_7).ToString("#.00");
                }
                catch
                {
                    result = "0.00";
                }
                return result;
            }
            set
            {
                this.string_7 = value;
            }
        }
        public string payment
        {
            get
            {
                string result;
                try
                {
                    result = Convert.ToDouble(this.string_8).ToString("#.00");
                }
                catch
                {
                    result = "0.00";
                }
                return result;
            }
            set
            {
                this.string_8 = value;
            }
        }
        public string discount_fee
        {
            get
            {
                string result;
                try
                {
                    result = Convert.ToDouble(this.string_9).ToString("#.00");
                }
                catch
                {
                    result = "0.00";
                }
                return result;
            }
            set
            {
                this.string_9 = value;
            }
        }
        public string adjust_fee
        {
            get
            {
                string result;
                try
                {
                    result = Convert.ToDouble(this.string_10).ToString("#.00");
                }
                catch
                {
                    result = "0.00";
                }
                return result;
            }
            set
            {
                this.string_10 = value;
            }
        }
        public string status
        {
            get
            {
                return this.string_11;
            }
            set
            {
                this.string_11 = value;
            }
        }
        public string statusText
        {
            get
            {
                string result = string.Empty;
                string text = this.string_11;
                switch (text)
                {
                    case "TRADE_NO_CREATE_PAY":
                        result = "没有创建支付宝交易";
                        break;
                    case "WAIT_BUYER_PAY":
                        result = "等待买家付款";
                        break;
                    case "WAIT_SELLER_SEND_GOODS":
                        result = "等待卖家发货,即:买家已付款";
                        break;
                    case "WAIT_BUYER_CONFIRM_GOODS":
                        result = "等待买家确认收货,即:卖家已发货";
                        break;
                    case "TRADE_BUYER_SIGNED":
                        result = "买家已签收,货到付款专用";
                        break;
                    case "TRADE_FINISHED":
                        result = "交易成功";
                        break;
                    case "TRADE_CLOSED":
                        result = "交易关闭";
                        break;
                    case "TRADE_CLOSED_BY_TAOBAO":
                        result = "交易被淘宝关闭";
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
        public string outer_iid
        {
            get
            {
                return this.string_12;
            }
            set
            {
                this.string_12 = value;
            }
        }
        public string outer_sku_id
        {
            get
            {
                return this.string_13;
            }
            set
            {
                this.string_13 = value;
            }
        }
        public string sku_properties_name
        {
            get
            {
                return this.string_14;
            }
            set
            {
                this.string_14 = value;
            }
        }
        public string item_meal_name
        {
            get
            {
                return this.string_15;
            }
            set
            {
                this.string_15 = value;
            }
        }
        public bool buyer_rate
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
        public bool seller_rate
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
        public string refund_id
        {
            get
            {
                return this.string_16;
            }
            set
            {
                this.string_16 = value;
            }
        }
        public string seller_type
        {
            get
            {
                return this.string_17;
            }
            set
            {
                this.string_17 = value;
            }
        }
    }
}