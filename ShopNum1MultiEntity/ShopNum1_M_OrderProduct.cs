using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Data;

namespace ShopNum1MultiEntity
{
	public class ShopNum1_M_OrderProduct: INotifyPropertyChanging, INotifyPropertyChanged
	{

        private static readonly PropertyChangingEventArgs propertyChangingEventArgs_0 =
           new PropertyChangingEventArgs(string.Empty);

        public virtual string Guid { get; set; }
        public virtual string OrderInfoGuid { get; set; }
        public virtual string ProductGuid { get; set; }
        public virtual string ProductName { get; set; }
        public virtual string RepertoryNumber { get; set; }
        public virtual string ProductImg { get; set; }
        public virtual string BuyNumber { get; set; }
        public virtual string MarketPrice { get; set; }
        public virtual string BuyPrice { get; set; }
        public virtual string OrderType { get; set; }
        public virtual string Attributes { get; set; }
        public virtual string ExtensionAttriutes { get; set; }
        public virtual string IsJoinActivity { get; set; }
        public virtual string ShopID { get; set; }
        public virtual string MemLoginID { get; set; }
        public virtual string CreateTime { get; set; }
        public virtual string ShopPrice { get; set; }
        public virtual string IsShipment { get; set; }
        public virtual string IsReal { get; set; }
        public virtual string DetailedSpecifications { get; set; }
        public virtual string ConsumptionScore { get; set; }
        public virtual string RankScore { get; set; }
        public virtual string GroupPrice { get; set; }
        public virtual string SpecificationName { get; set; }
        public virtual string SpecificationValue { get; set; }
        public virtual string BuyerGetProfit { get; set; }
        public virtual string shop_category_id { get; set; }
        public virtual string Size { get; set; }
        public virtual string Color { get; set; }

        
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

        public static List<ShopNum1_M_OrderProduct> FromDataRowOrderProduct(DataTable table)
        {
            List<ShopNum1_M_OrderProduct> UserMessage = new List<ShopNum1_M_OrderProduct>();
            foreach (DataRow row in table.Rows)
            {
                ShopNum1_M_OrderProduct GetUserMessage = new ShopNum1_M_OrderProduct();

                GetUserMessage.Guid = Convert.ToString(row["Guid"]);
                GetUserMessage.OrderInfoGuid = Convert.ToString(row["OrderInfoGuid"]);
                GetUserMessage.ProductGuid = Convert.ToString(row["ProductGuid"]);
                GetUserMessage.ProductName = Convert.ToString(row["ProductName"]);
                GetUserMessage.RepertoryNumber = Convert.ToString(row["RepertoryNumber"]);
                GetUserMessage.ProductImg = Convert.ToString(row["ProductImg"]);
                GetUserMessage.BuyNumber = Convert.ToString(row["BuyNumber"]);
                GetUserMessage.MarketPrice = Convert.ToString(row["MarketPrice"]);
                GetUserMessage.BuyPrice = Convert.ToString(row["BuyPrice"]);
                GetUserMessage.OrderType = Convert.ToString(row["OrderType"]);
                GetUserMessage.Attributes = Convert.ToString(row["Attributes"]);
                GetUserMessage.ExtensionAttriutes = Convert.ToString(row["ExtensionAttriutes"]);
                GetUserMessage.IsJoinActivity = Convert.ToString(row["IsJoinActivity"]);
                GetUserMessage.ShopID = Convert.ToString(row["ShopID"]);
                GetUserMessage.MemLoginID = Convert.ToString(row["MemLoginID"]);
                GetUserMessage.CreateTime = Convert.ToString(row["CreateTime"]);
                GetUserMessage.ShopPrice = Convert.ToString(row["ShopPrice"]);
                GetUserMessage.IsShipment = Convert.ToString(row["IsShipment"]);
                GetUserMessage.IsReal = Convert.ToString(row["IsReal"]);
                GetUserMessage.DetailedSpecifications = Convert.ToString(row["DetailedSpecifications"]);
                GetUserMessage.ConsumptionScore = Convert.ToString(row["ConsumptionScore"]);
                GetUserMessage.RankScore = Convert.ToString(row["RankScore"]);
                GetUserMessage.GroupPrice = Convert.ToString(row["GroupPrice"]);
                GetUserMessage.SpecificationName = Convert.ToString(row["SpecificationName"]);
                GetUserMessage.SpecificationValue = Convert.ToString(row["SpecificationValue"]);
                GetUserMessage.BuyerGetProfit = Convert.ToString(row["BuyerGetProfit"]);
                GetUserMessage.shop_category_id = Convert.ToString(row["shop_category_id"]);
                GetUserMessage.Size = Convert.ToString(row["Size"]);
                GetUserMessage.Color = Convert.ToString(row["Color"]);

                UserMessage.Add(GetUserMessage);
            }
            return UserMessage;
        }
	}
}
