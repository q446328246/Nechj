using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Data;

namespace ShopNum1MultiEntity
{
    public class ShopNum1_M_Order : INotifyPropertyChanging, INotifyPropertyChanged
	{
        private static readonly PropertyChangingEventArgs propertyChangingEventArgs_0 =
           new PropertyChangingEventArgs(string.Empty);



        public virtual string Guid { get; set; }

        public virtual string MemLoginID { get; set; }

        public virtual string OrderNumber { get; set; }

        public virtual string TradeID { get; set; }

        public virtual string OderStatus { get; set; }

        public virtual string ShipmentStatus { get; set; }

        public virtual string PaymentStatus { get; set; }

        public virtual string refundStatus { get; set; }

        public virtual string Name { get; set; }

        public virtual string Email { get; set; }

        public virtual string Address { get; set; }

        public virtual string Postalcode { get; set; }

        public virtual string Tel { get; set; }

        public virtual string Mobile { get; set; }

        public virtual string ClientToSellerMsg { get; set; }

        public virtual string SellerToClientMsg { get; set; }

        public virtual object PaymentGuid { get; set; }

        public virtual string PaymentName { get; set; }

        public virtual string ProductPrice { get; set; }

        public virtual string ProductPv_b { get; set; }

        public virtual string ProductLastPrice { get; set; }

        public virtual string DispatchPrice { get; set; }

        public virtual string PaymentPrice { get; set; }

        public virtual string ScorePrice { get; set; }

        public virtual string ShouldPayPrice { get; set; }

        public virtual object FromAd { get; set; }

        public virtual string FromUrl { get; set; }

        public virtual string CreateTime { get; set; }

        public virtual string ConfirmTime { get; set; }

        public virtual string PayTime { get; set; }

        public virtual string DispatchType { get; set; }

        public virtual string IsLogistics { get; set; }

        public virtual string LogisticsCompany { get; set; }

        public virtual string LogisticsCompanyCode { get; set; }

        public virtual string ShipmentNumber { get; set; }

        public virtual string BuyType { get; set; }

        public virtual object ActivityGuid { get; set; }

        public virtual string PayMemo { get; set; }

        public virtual string ShopID { get; set; }

        public virtual string CancelReason { get; set; }

        public virtual string EndTime { get; set; }

        public virtual string OutOfStockOperate { get; set; }

        public virtual object PackGuid { get; set; }

        public virtual string PackName { get; set; }

        public virtual object BlessCardGuid { get; set; }

        public virtual string BlessCardName { get; set; }

        public virtual string BlessCardContent { get; set; }

        public virtual string InvoiceContent { get; set; }
        
        public virtual string PackPrice { get; set; }

        public virtual string BlessCardPrice { get; set; }

        public virtual string AlreadPayPrice { get; set; }

        public virtual string SurplusPrice { get; set; }

        public virtual string UseScore { get; set; }

        public virtual string InvoiceType { get; set; }

        public virtual string InvoiceTax { get; set; }

        public virtual string Discount { get; set; }

        public virtual string Deposit { get; set; }




        public virtual string RegionCode { get; set; }

        public virtual string JoinActiveType { get; set; }

        public virtual string ActvieContent { get; set; }

        public virtual string UsedFavourTicket { get; set; }

        public virtual string DispatchTime { get; set; }

        public virtual string ShopName { get; set; }

        public virtual string FeeType { get; set; }

        public virtual string IsBuyComment { get; set; }

        public virtual string IsSellComment { get; set; }



        public virtual string BuyIsDeleted { get; set; }

        public virtual string SellIsDeleted { get; set; }

        public virtual string IsDeleted { get; set; }

        public virtual string OrderType { get; set; }

        public virtual string ReceiptTime { get; set; }

        public virtual string PayMentMemLoginID { get; set; }

        public virtual string IsMinus { get; set; }

        public virtual string ReceivedDays { get; set; }

        public virtual string IsMemdelay { get; set; }


        public virtual string RecommendCommision { get; set; }

        public virtual string AlipayTradeId { get; set; }

        public virtual string identifycode { get; set; }

        public virtual string Score_pv_b { get; set; }

        public virtual string Score_hv { get; set; }

        public virtual string Score_dv { get; set; }

        public virtual string Score_pv_a { get; set; }

        public virtual string agentId { get; set; }

        public virtual string Score_cv { get; set; }


        public virtual string Score_max_hv { get; set; }

        public virtual string score_reduce_pv_b { get; set; }

        public virtual string score_reduce_hv { get; set; }

        public virtual string score_reduce_dv { get; set; }

        public virtual string score_reduce_pv_a { get; set; }

        public virtual string shop_category_id { get; set; }

        public virtual string ServiceAgent { get; set; }

        public virtual string score_reduce_pv_cv { get; set; }

        public virtual string score_pv_cv { get; set; }


        public virtual string Offset_pv_b { get; set; }

        public virtual string IsRefundStatus { get; set; }

        public virtual string remark { get; set; }

        public virtual string Deduction_hv { get; set; }

        public virtual object SuperiorRank { get; set; }
         public virtual string InvoiceTitle { get; set; }
        

        public event PropertyChangedEventHandler PropertyChanged;

        public event PropertyChangingEventHandler PropertyChanging;

        protected virtual void SendPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        protected virtual void SendPropertyChanging()
        {
            if (PropertyChanging != null)
            {
                PropertyChanging(this, propertyChangingEventArgs_0);
            }
        }

        public static List<ShopNum1_M_Order> FromDataRowGetOrder(DataTable table)
        {
            List<ShopNum1_M_Order> UserMessage = new List<ShopNum1_M_Order>();
            foreach (DataRow row in table.Rows)
            {
                ShopNum1_M_Order GetUserMessage = new ShopNum1_M_Order();
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
