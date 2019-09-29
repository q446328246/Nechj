using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace ShopNum1MultiEntity
{
	public class ShopNum1_Mobile_Order : ShopNum1_M_Order
	{
        private List<ShopNum1_M_OrderProduct> orderProduct = new List<ShopNum1_M_OrderProduct>();

        public List<ShopNum1_M_OrderProduct> OrderProduct
        {
            get { return orderProduct; }
            set { orderProduct = value; }
        }

        public new static List<ShopNum1_Mobile_Order> FromDataRowGetOrder(DataTable table)
        {
            List<ShopNum1_Mobile_Order> UserMessage = new List<ShopNum1_Mobile_Order>();
            foreach (DataRow row in table.Rows)
            {
                ShopNum1_Mobile_Order GetUserMessage = new ShopNum1_Mobile_Order();
                GetUserMessage.Guid = Convert.ToString(row["Guid"]);
                GetUserMessage.MemLoginID = Convert.ToString(row["MemLoginID"]);
                GetUserMessage.OrderNumber = Convert.ToString(row["OrderNumber"]);
                GetUserMessage.TradeID = Convert.ToString(row["TradeID"]);
                GetUserMessage.OderStatus = Convert.ToString(row["OderStatus"]);
                GetUserMessage.ShipmentStatus = Convert.ToString(row["ShipmentStatus"]);
                GetUserMessage.PaymentStatus = Convert.ToString(row["PaymentStatus"]);
                GetUserMessage.refundStatus = Convert.ToString(row["refundStatus"]);
                GetUserMessage.Name = Convert.ToString(row["Name"]);
                GetUserMessage.Email = Convert.ToString(row["Email"]);
                GetUserMessage.Address = Convert.ToString(row["Address"]);
                GetUserMessage.Postalcode = Convert.ToString(row["Postalcode"]);
                GetUserMessage.Tel = Convert.ToString(row["Tel"]);
                GetUserMessage.Mobile = Convert.ToString(row["Mobile"]);
                GetUserMessage.ClientToSellerMsg = Convert.ToString(row["ClientToSellerMsg"]);
                GetUserMessage.SellerToClientMsg = Convert.ToString(row["SellerToClientMsg"]);
                GetUserMessage.PaymentGuid = Convert.ToString(row["PaymentGuid"]);
                GetUserMessage.PaymentName = Convert.ToString(row["PaymentName"]);
                GetUserMessage.ProductPrice = Convert.ToString(row["ProductPrice"]);
                GetUserMessage.ProductPv_b = Convert.ToString(row["ProductPv_b"]);
                GetUserMessage.ProductLastPrice = Convert.ToString(row["ProductLastPrice"]);
                GetUserMessage.DispatchPrice = Convert.ToString(row["DispatchPrice"]);
                GetUserMessage.PaymentPrice = Convert.ToString(row["PaymentPrice"]);
                GetUserMessage.ScorePrice = Convert.ToString(row["ScorePrice"]);
                GetUserMessage.ShouldPayPrice = Convert.ToString(row["ShouldPayPrice"]);
                GetUserMessage.FromAd = Convert.ToString(row["FromAd"]);
                GetUserMessage.FromUrl = Convert.ToString(row["FromUrl"]);
                GetUserMessage.CreateTime = Convert.ToString(row["CreateTime"]);
                GetUserMessage.ConfirmTime = Convert.ToString(row["ConfirmTime"]);
                GetUserMessage.PayTime = Convert.ToString(row["PayTime"]);
                GetUserMessage.DispatchType = Convert.ToString(row["DispatchType"]);
                GetUserMessage.IsLogistics = Convert.ToString(row["IsLogistics"]);
                GetUserMessage.LogisticsCompany = Convert.ToString(row["LogisticsCompany"]);
                GetUserMessage.LogisticsCompanyCode = Convert.ToString(row["LogisticsCompanyCode"]);
                GetUserMessage.ShipmentNumber = Convert.ToString(row["ShipmentNumber"]);
                GetUserMessage.BuyType = Convert.ToString(row["BuyType"]);
                GetUserMessage.ActivityGuid = Convert.ToString(row["ActivityGuid"]);
                GetUserMessage.PayMemo = Convert.ToString(row["PayMemo"]);
                GetUserMessage.ShopID = Convert.ToString(row["ShopID"]);
                GetUserMessage.CancelReason = Convert.ToString(row["CancelReason"]);
                GetUserMessage.EndTime = Convert.ToString(row["EndTime"]);
                GetUserMessage.OutOfStockOperate = Convert.ToString(row["OutOfStockOperate"]);
                GetUserMessage.PackGuid = Convert.ToString(row["PackGuid"]);
                GetUserMessage.PackName = Convert.ToString(row["PackName"]);
                GetUserMessage.BlessCardGuid = Convert.ToString(row["BlessCardGuid"]);
                GetUserMessage.BlessCardName = Convert.ToString(row["BlessCardName"]);
                GetUserMessage.BlessCardContent = Convert.ToString(row["BlessCardContent"]);
                GetUserMessage.InvoiceTitle = Convert.ToString(row["InvoiceTitle"]);
                GetUserMessage.InvoiceContent = Convert.ToString(row["InvoiceContent"]);
                GetUserMessage.PackPrice = Convert.ToString(row["PackPrice"]);
                GetUserMessage.BlessCardPrice = Convert.ToString(row["BlessCardPrice"]);
                GetUserMessage.AlreadPayPrice = Convert.ToString(row["AlreadPayPrice"]);
                GetUserMessage.SurplusPrice = Convert.ToString(row["SurplusPrice"]);
                GetUserMessage.UseScore = Convert.ToString(row["UseScore"]);
                GetUserMessage.InvoiceType = Convert.ToString(row["InvoiceType"]);
                GetUserMessage.InvoiceTax = Convert.ToString(row["InvoiceTax"]);
                GetUserMessage.Discount = Convert.ToString(row["Discount"]);
                GetUserMessage.Deposit = Convert.ToString(row["Deposit"]);
                GetUserMessage.RegionCode = Convert.ToString(row["RegionCode"]);
                GetUserMessage.JoinActiveType = Convert.ToString(row["JoinActiveType"]);
                GetUserMessage.ActvieContent = Convert.ToString(row["ActvieContent"]);
                GetUserMessage.UsedFavourTicket = Convert.ToString(row["UsedFavourTicket"]);
                GetUserMessage.DispatchTime = Convert.ToString(row["DispatchTime"]);
                GetUserMessage.ShopName = Convert.ToString(row["ShopName"]);
                GetUserMessage.FeeType = Convert.ToString(row["FeeType"]);
                GetUserMessage.IsBuyComment = Convert.ToString(row["IsBuyComment"]);
                GetUserMessage.IsSellComment = Convert.ToString(row["IsSellComment"]);
                GetUserMessage.BuyIsDeleted = Convert.ToString(row["BuyIsDeleted"]);
                GetUserMessage.SellIsDeleted = Convert.ToString(row["SellIsDeleted"]);
                GetUserMessage.IsDeleted = Convert.ToString(row["IsDeleted"]);
                GetUserMessage.OrderType = Convert.ToString(row["OrderType"]);
                GetUserMessage.ReceiptTime = Convert.ToString(row["ReceiptTime"]);
                GetUserMessage.PayMentMemLoginID = Convert.ToString(row["PayMentMemLoginID"]);
                GetUserMessage.IsMinus = Convert.ToString(row["IsMinus"]);
                GetUserMessage.ReceivedDays = Convert.ToString(row["ReceivedDays"]);
                GetUserMessage.IsMemdelay = Convert.ToString(row["IsMemdelay"]);
                GetUserMessage.RecommendCommision = Convert.ToString(row["RecommendCommision"]);
                GetUserMessage.AlipayTradeId = Convert.ToString(row["AlipayTradeId"]);
                GetUserMessage.identifycode = Convert.ToString(row["identifycode"]);
                GetUserMessage.Score_pv_b = Convert.ToString(row["Score_pv_b"]);
                GetUserMessage.Score_hv = Convert.ToString(row["Score_hv"]);
                GetUserMessage.Score_dv = Convert.ToString(row["Score_dv"]);
                GetUserMessage.Score_pv_a = Convert.ToString(row["Score_pv_a"]);
                GetUserMessage.agentId = Convert.ToString(row["agentId"]);
                GetUserMessage.Score_cv = Convert.ToString(row["Score_cv"]);
                GetUserMessage.Score_max_hv = Convert.ToString(row["Score_max_hv"]);
                GetUserMessage.score_reduce_pv_b = Convert.ToString(row["score_reduce_pv_b"]);
                GetUserMessage.score_reduce_hv = Convert.ToString(row["score_reduce_hv"]);
                GetUserMessage.score_reduce_dv = Convert.ToString(row["score_reduce_dv"]);
                GetUserMessage.score_reduce_pv_a = Convert.ToString(row["score_reduce_pv_a"]);
                GetUserMessage.shop_category_id = Convert.ToString(row["shop_category_id"]);
                GetUserMessage.ServiceAgent = Convert.ToString(row["ServiceAgent"]);
                GetUserMessage.score_reduce_pv_cv = Convert.ToString(row["score_reduce_pv_cv"]);
                GetUserMessage.score_pv_cv = Convert.ToString(row["score_pv_cv"]);
                GetUserMessage.Offset_pv_b = Convert.ToString(row["Offset_pv_b"]);
                GetUserMessage.IsRefundStatus = Convert.ToString(row["IsRefundStatus"]);
                GetUserMessage.remark = Convert.ToString(row["remark"]);
                GetUserMessage.Deduction_hv = Convert.ToString(row["Deduction_hv"]);
                GetUserMessage.SuperiorRank = Convert.ToString(row["SuperiorRank"]);


                UserMessage.Add(GetUserMessage);
            }
            return UserMessage;
        }
	}
}
