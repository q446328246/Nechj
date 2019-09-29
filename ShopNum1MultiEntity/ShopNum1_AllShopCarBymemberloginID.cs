using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Data;

namespace ShopNum1MultiEntity
{
	public class ShopNum1_AllShopCarBymemberloginID: INotifyPropertyChanging, INotifyPropertyChanged
	{
         private static readonly PropertyChangingEventArgs propertyChangingEventArgs_0 =
          new PropertyChangingEventArgs(string.Empty);

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
        public virtual string Guid { get; set; }
        public virtual string ProductGuId { get; set; }
        public virtual string LimitId { get; set; }
        public virtual string Name { get; set; }
        public virtual string MarketPrice { get; set; }
        public virtual string ShopPrice { get; set; }
        public virtual string BuyNumber { get; set; }
        public virtual string BuyPrice { get; set; }
        public virtual string OriginalImge { get; set; }
        public virtual string RepertoryNumber { get; set; }
        public virtual string IsShipment { get; set; }
        public virtual string IsReal { get; set; }
        public virtual string Attributes { get; set; }
        public virtual string ExtensionAttriutes { get; set; }
        public virtual string ParentGuid { get; set; }
        public virtual string IsJoinActivity { get; set; }
        public virtual string CartType { get; set; }
        public virtual string IsPresent { get; set; }
        public virtual string CreateTime { get; set; }
        public virtual string DetailedSpecifications { get; set; }
        public virtual string ShopID { get; set; }
        public virtual string FeeType { get; set; }
        public virtual string Post_fee { get; set; }
        public virtual string Express_fee { get; set; }
        public virtual string Ems_fee { get; set; }
        public virtual string SellName { get; set; }
        public virtual string SpecificationName { get; set; }
        public virtual string SpecificationValue { get; set; }
        public virtual string MemLoginId { get; set; }
        public virtual string AgentId { get; set; }
        public virtual string Score_dv { get; set; }
        public virtual string Score_pv_a { get; set; }
        public virtual string Score_pv_b { get; set; }
        public virtual string Score_hv { get; set; }
        public virtual string shop_category_id { get; set; }
        public virtual string Color { get; set; }
        public virtual string Size { get; set; }
        public virtual string Score_pv_cv { get; set; }
        public virtual string GoodsWeight { get; set; }

         public static List<ShopNum1_AllShopCarBymemberloginID> FromDataRowGetAllShopCategorys(DataTable table)
        {
            List<ShopNum1_AllShopCarBymemberloginID> products = new List<ShopNum1_AllShopCarBymemberloginID>();
            foreach (DataRow row in table.Rows)
            {
                ShopNum1_AllShopCarBymemberloginID AllShopCategorys = new ShopNum1_AllShopCarBymemberloginID();
                AllShopCategorys.Guid = Convert.ToString(row["Guid"]);
                AllShopCategorys.ProductGuId = Convert.ToString(row["ProductGuId"]);
                AllShopCategorys.LimitId = Convert.ToString(row["LimitId"]);
                AllShopCategorys.Name = Convert.ToString(row["Name"]);
                AllShopCategorys.MarketPrice = Convert.ToString(row["MarketPrice"]);
                AllShopCategorys.ShopPrice = Convert.ToString(row["ShopPrice"]);
                AllShopCategorys.BuyNumber = Convert.ToString(row["BuyNumber"]);
                AllShopCategorys.BuyPrice = Convert.ToString(row["BuyPrice"]);
                AllShopCategorys.OriginalImge = Convert.ToString(row["OriginalImge"]);
                AllShopCategorys.RepertoryNumber = Convert.ToString(row["RepertoryNumber"]);
                AllShopCategorys.IsShipment = Convert.ToString(row["IsShipment"]);
                AllShopCategorys.IsReal = Convert.ToString(row["IsReal"]);
                AllShopCategorys.Attributes = Convert.ToString(row["Attributes"]);
                AllShopCategorys.ExtensionAttriutes = Convert.ToString(row["ExtensionAttriutes"]);
                AllShopCategorys.ParentGuid = Convert.ToString(row["ParentGuid"]);
                AllShopCategorys.IsJoinActivity = Convert.ToString(row["IsJoinActivity"]);
                AllShopCategorys.CartType = Convert.ToString(row["CartType"]);
                AllShopCategorys.IsPresent = Convert.ToString(row["IsPresent"]);
                AllShopCategorys.CreateTime = Convert.ToString(row["CreateTime"]);
                AllShopCategorys.DetailedSpecifications = Convert.ToString(row["DetailedSpecifications"]);
                AllShopCategorys.ShopID = Convert.ToString(row["ShopID"]);
                AllShopCategorys.FeeType = Convert.ToString(row["FeeType"]);
                AllShopCategorys.Post_fee = Convert.ToString(row["Post_fee"]);
                AllShopCategorys.Express_fee = Convert.ToString(row["Express_fee"]);
                AllShopCategorys.Ems_fee = Convert.ToString(row["Ems_fee"]);
                AllShopCategorys.SellName = Convert.ToString(row["SellName"]);
                AllShopCategorys.SpecificationName = Convert.ToString(row["SpecificationName"]);
                AllShopCategorys.SpecificationValue = Convert.ToString(row["SpecificationValue"]);
                AllShopCategorys.MemLoginId = Convert.ToString(row["MemLoginId"]);
                AllShopCategorys.AgentId = Convert.ToString(row["AgentId"]);
                AllShopCategorys.Score_dv = Convert.ToString(row["Score_dv"]);
                AllShopCategorys.Score_pv_a = Convert.ToString(row["Score_pv_a"]);
                AllShopCategorys.Score_pv_b = Convert.ToString(row["Score_pv_b"]);
                AllShopCategorys.Score_hv = Convert.ToString(row["Score_hv"]);
                AllShopCategorys.shop_category_id = Convert.ToString(row["shop_category_id"]);
                AllShopCategorys.Color = Convert.ToString(row["Color"]);
                AllShopCategorys.Size = Convert.ToString(row["Size"]);
                AllShopCategorys.Score_pv_cv = Convert.ToString(row["Score_pv_cv"]);
                AllShopCategorys.GoodsWeight = Convert.ToString(row["GoodsWeight"]);
               
                products.Add(AllShopCategorys);
            }
          
    
            return products;

        }
	}
}
