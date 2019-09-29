using System;

namespace ShopNum1.TbBusinessEntity
{
    [Serializable]
    public class TbPromotionDetail
    {
        private decimal decimal_0;
        private string string_0;
        private string string_1;
        private string string_2;

        public decimal Decimal_0
        {
            get { return decimal_0; }
            set { decimal_0 = value; }
        }

        public string discount_fee
        {
            get { return string_1; }
            set { string_1 = value; }
        }

        public string gift_item_name
        {
            get { return string_2; }
            set { string_2 = value; }
        }

        public string promotion_name
        {
            get { return string_0; }
            set { string_0 = value; }
        }
    }
}