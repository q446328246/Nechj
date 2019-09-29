using com.hitrust.trustpay.client;
using com.hitrust.trustpay.client.b2c;

namespace ShopNum1.Payment.ABCPay
{
    public class ABCPayMent
    {
        public bool GetUrlABCPayMent(PayInfo payInfo, out string strUrl)
        {
            var order = new Order();
            order.OrderNo = payInfo.ABCOrderNO;
            order.ExpiredDate = payInfo.ABCExpiredDate;
            order.OrderDesc = payInfo.ABCOrderDesc;
            order.OrderDate = payInfo.ABCOrderDate;
            order.OrderTime = payInfo.ABCOrderTime;
            order.OrderAmount = payInfo.ABCOrderAmount;
            order.OrderURL = payInfo.ABCOrderURL;
            order.BuyIP = payInfo.ABCBuyIP;

            var paymentRequest = new PaymentRequest();
            paymentRequest.Order = order;
            paymentRequest.ProductType = payInfo.ABCProductType;
            paymentRequest.PaymentType = payInfo.ABCPaymentType;
            paymentRequest.PayLinkType = payInfo.ABCPaymentLinkType;
            paymentRequest.NotifyType = payInfo.ABCNotifyType;
            paymentRequest.ResultNotifyURL = payInfo.ABCResultNotifyURL;
            paymentRequest.MerchantRemarks = payInfo.ABCMerchantRemarks;
            TrxResponse trxResponse = paymentRequest.postRequest();
            strUrl = string.Empty;
            bool result;
            if (result = trxResponse.isSuccess())
            {
                strUrl = trxResponse.getValue("PaymentURL");
            }
            return result;
        }
    }
}