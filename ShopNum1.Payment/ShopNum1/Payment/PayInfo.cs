namespace ShopNum1.Payment
{
    public class PayInfo
    {
        public string merchant_code { get; set; }
        public string service_type { get; set; }
        public string input_charset { get; set; }
        public string interface_version { get; set; }
        
        public string order_no { get; set; }
        public string order_time { get; set; }
        public string order_amount { get; set; }
        
        public string bank_code { get; set; }
        public string client_ip { get; set; }
        public string extend_param { get; set; }
        public string extra_return_param { get; set; }
        public string product_code { get; set; }
        public string product_desc { get; set; }
        public string product_num { get; set; }
        public string redo_flag { get; set; }

        
        

        public string BackUrl;
        public string BuyerContact;
        public string BuyerIp;
        public string Charset;
        public string Ext1;
        public string InstCode;
        public string MsgSender;
        public string NotifyUrl;
        public string OrderAmount;
        public string OrderNo;
        public string OrderTime;
        public string PName;
        public string PageUrl;
        public string PayChannel;
        public string PayType;
        public string SendTime;
        public string ShenPayName;
        public string SignMsg;
        public string SignTypeCheck;
        public string Version;
        private string a = "3";
  
        public string keyMer;

        public string PlatSupplierID { get; set; }
        public string Key { get; set; }
        public string SellerID { get; set; }
        public string BuyerID { get; set; }
        public string ProductName { get; set; }
        public string ProductPrice { get; set; }
        public string ProductType { get; set; }
        public string TransportType { get; set; }
        public string TransportPrice { get; set; }
        public string OrderNumber { get; set; }
        public string ShouldPayPrice { get; set; }
        public string Description { get; set; }

        public string Trade_Mode
        {
            get { return a; }
            set { a = value; }
        }

        public string UserIP { get; set; }
        public string Attach { get; set; }
        public string Aervice { get; set; }
        public string Gateway { get; set; }
        public string SignType { get; set; }
        public string Quantity { get; set; }
        public string SiglePrice { get; set; }
        public string FormID { get; set; }
        public string SellerRemark { get; set; }
        public string CreateTime { get; set; }
        public string ClientAddress { get; set; }
        public string ClientPostalcode { get; set; }
        public string ClientTel { get; set; }
        public string ClientEmail { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Postalcode { get; set; }
        public string Tel { get; set; }
        public string Email { get; set; }
        public string State { get; set; }
        public string Digestinfo { get; set; }
        public string Body { get; set; }
        public string Notify_url { get; set; }
        public string Return_url { get; set; }
        public string Show_url { get; set; }
        public string Seller_email { get; set; }
        public string Logistics_type { get; set; }
        public string Logistics_fee { get; set; }
        public string Logistics_payment { get; set; }
        public string Logistics_type_1 { get; set; }
        public string Logistics_fee_1 { get; set; }
        public string Logistics_payment_1 { get; set; }
        public string Payment_type { get; set; }
        public string ReturnSuccessfulUrl { get; set; }
        public string ReturnErrorUrl { get; set; }
        public string MerchantId { get; set; }
        public string TransType { get; set; }
        public string DesKey { get; set; }
        public string MerURL { get; set; }
        public string PostUrl { get; set; }
        public string Info1 { get; set; }
        public string Info2 { get; set; }
        public string MPK { get; set; }
        public string Wht_n { get; set; }
        public string Wht_e { get; set; }
        public string Mer_code { get; set; }
        public string Mer_key { get; set; }
        public string BillDate { get; set; }
        public string Currency_Type { get; set; }
        public string Gateway_Type { get; set; }
        public string Lang { get; set; }
        public string Merchanturl { get; set; }
        public string CCBMerchantID { get; set; }
        public string CCBPosID { get; set; }
        public string CCBBranchID { get; set; }
        public string CCBOrderID { get; set; }
        public string CCBPayMent { get; set; }
        public string CCBCurCode { get; set; }
        public string CCBRemark1 { get; set; }
        public string CCBRemark2 { get; set; }
        public string CCBTxCode { get; set; }
        public string ABCOrderNO { get; set; }
        public int ABCExpiredDate { get; set; }
        public string ABCBuyIP { get; set; }
        public string ABCOrderDate { get; set; }
        public string ABCOrderTime { get; set; }
        public double ABCOrderAmount { get; set; }
        public string ABCOrderURL { get; set; }
        public string ABCOrderDesc { get; set; }
        public string ABCProductType { get; set; }
        public string ABCPaymentType { get; set; }
        public string ABCPaymentLinkType { get; set; }
        public string ABCNotifyType { get; set; }
        public string ABCResultNotifyURL { get; set; }
        public string ABCMerchantRemarks { get; set; }
    }
}