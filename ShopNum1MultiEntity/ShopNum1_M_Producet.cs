using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Data;

namespace ShopNum1MultiEntity
{
	public class ShopNum1_M_Producet: INotifyPropertyChanging, INotifyPropertyChanged
	{
        private static readonly PropertyChangingEventArgs propertyChangingEventArgs_0 =
           new PropertyChangingEventArgs(string.Empty);
         public virtual string AddressCode { get; set; } 

        public virtual string AddressValue { get; set; } 

        public virtual string agentId { get; set; } 

        public virtual object BrandGuid { get; set; } 

        public virtual string BrandName { get; set; } 

        public virtual int BuyCount { get; set; } 

        public virtual int ClickCount { get; set; } 

        public virtual int CollectCount { get; set; } 

        public virtual string Color { get; set; } 

        public virtual int CommentCount { get; set; }

        public virtual string CreateTime { get; set; } 

        public virtual string CreateUser { get; set; } 

        public virtual int Ctype { get; set; }

        public virtual string DeSaleTime { get; set; } 

        public virtual string Description { get; set; } 

        public virtual string Detail { get; set; } 

        public virtual decimal Ems_fee { get; set; } 

        public virtual string EndTime { get; set; } 

        public virtual decimal Express_fee { get; set; } 

        public virtual int FeeTemplateID { get; set; } 

        public virtual string FeeTemplateName { get; set; } 

        public virtual int FeeType { get; set; } 

        public virtual object Guid { get; set; } 

        public virtual int Id { get; set; } 

        public virtual string Instruction { get; set; } 

        public virtual int IsAudit { get; set; } 

        public virtual int IsBest { get; set; } 

        public virtual int IsDeleted { get; set; } 

        public virtual int IsHot { get; set; } 

        public virtual int IsNew { get; set; } 

        public virtual int IsPromotion { get; set; } 

        public virtual int IsReal { get; set; } 

        public virtual int IsRecommend { get; set; } 

        public virtual int IsSaled { get; set; } 

        public virtual int IsSell { get; set; } 

        public virtual int IsShopGood { get; set; } 

        public virtual int IsShopHot { get; set; } 

        public virtual int IsShopNew { get; set; } 

        public virtual int IsShopPromotion { get; set; } 

        public virtual int IsShopRecommend { get; set; } 

        public virtual string Keywords { get; set; } 

        public virtual string MemLoginID { get; set; } 

        public virtual decimal MinusFee { get; set; }

        public virtual string ModifyTime { get; set; } 

        public virtual string ModifyUser { get; set; } 

        public virtual int MonthSale { get; set; } 

        public virtual string MultiImages { get; set; } 

        public virtual string Name { get; set; } 

        public virtual int OrderID { get; set; } 

        public virtual string OriginalImage { get; set; } 

        public virtual decimal Post_fee { get; set; } 

        public virtual string ProductCategoryCode { get; set; } 

        public virtual string ProductCategoryName { get; set; } 

        public virtual string ProductNum { get; set; } 

        public virtual string ProductSeriesCode { get; set; } 

        public virtual string ProductSeriesName { get; set; } 

        public virtual int ProductState { get; set; } 

        public virtual int PulishType { get; set; } 

        public virtual int RepertoryAlertCount { get; set; } 

        public virtual int RepertoryCount { get; set; } 

        public virtual int SaleNumber { get; set; }

        public virtual string SaleTime { get; set; } 

        public virtual string Score { get; set; } 

        public virtual int SetStock { get; set; } 

        public virtual string ShopName { get; set; } 

        public virtual string Size { get; set; } 

        public virtual string SmallImage { get; set; }

        public virtual string StartTime { get; set; } 

        public virtual string ThumbImage { get; set; } 

        public virtual string UnitName { get; set; } 

        public virtual string Wap_desc { get; set; } 

        public virtual string Wap_detail_url { get; set; }

        public virtual string Shop_url { get; set; }



        public virtual string AgentId { get; set; }

        public virtual int id { get; set; }

        public virtual decimal MarketPrice { get; set; }

        public virtual int productId { get; set; }

        public virtual string remark { get; set; }

        public virtual decimal Score_bv { get; set; }

        public virtual decimal Score_cv { get; set; }

        public virtual decimal Score_dv { get; set; }

        public virtual decimal Score_hv { get; set; }

        public virtual decimal Score_max_hv { get; set; }

        public virtual decimal Score_pv_a { get; set; }

        public virtual decimal Score_pv_b { get; set; }

        public virtual decimal Score_pv_cv { get; set; }

        public virtual decimal Score_reduce_pv_cv { get; set; }

        public virtual decimal Score_rv { get; set; }

        public virtual decimal Score_sv { get; set; }

        public virtual int shop_category_id { get; set; }

        public virtual decimal ShopPrice { get; set; }
        public virtual decimal GoodsWeight { get; set; }
        public virtual string NewDetail { get; set; }
        public virtual int SuanLiDaySum { get; set; }
        public virtual decimal SuanLiUnitPrice { get; set; }

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
            public static List<ShopNum1_M_Producet> FromDataRowGetProductByShop_category_id(DataTable table)
            {
                List<ShopNum1_M_Producet> products = new List<ShopNum1_M_Producet>();
                foreach (DataRow row in table.Rows)
                {
                    ShopNum1_M_Producet M_ProducetAll = new ShopNum1_M_Producet();
                    M_ProducetAll.AddressCode = Convert.ToString(row["AddressCode"]);
                    M_ProducetAll.AddressValue = Convert.ToString(row["AddressValue"]);
                    M_ProducetAll.agentId = Convert.ToString(row["agentId"]);
                    M_ProducetAll.BrandGuid = Convert.ToString(row["BrandGuid"]);
                    M_ProducetAll.BrandName = Convert.ToString(row["BrandName"]);
                    M_ProducetAll.BuyCount = Convert.ToInt32(row["BuyCount"]);
                    M_ProducetAll.ClickCount = Convert.ToInt32(row["ClickCount"]);
                    M_ProducetAll.CollectCount = Convert.ToInt32(row["CollectCount"]);
                    M_ProducetAll.Color = Convert.ToString(row["Color"]);
                    M_ProducetAll.CommentCount = Convert.ToInt32(row["CommentCount"]);
                    M_ProducetAll.CreateTime = Convert.ToString(row["CreateTime"]);
                    M_ProducetAll.CreateUser = Convert.ToString(row["CreateUser"]);
                    M_ProducetAll.Ctype = Convert.ToInt32(row["Ctype"]);
                    M_ProducetAll.DeSaleTime = Convert.ToString(row["DeSaleTime"]);
                    M_ProducetAll.Description = Convert.ToString(row["Description"]);
                    M_ProducetAll.Detail = Convert.ToString(row["Detail"]);
                    M_ProducetAll.Shop_url = Convert.ToString(row["ShopUrl"]);
                    if (M_ProducetAll.Detail != null && M_ProducetAll.Detail!= "")
                    {
                        if (M_ProducetAll.Detail.Contains("http"))
                        {
                            M_ProducetAll.NewDetail = M_ProducetAll.Detail;
                        }
                        else 
                        {
                            //M_ProducetAll.NewDetail = M_ProducetAll.Detail.Replace("/ImgUpload/kindeditor/image/", "http://" + M_ProducetAll.Shop_url + ShopNum1.Common.ShopSettings.CookieDomain + "/ImgUpload/kindeditor/image/");
                            M_ProducetAll.NewDetail = M_ProducetAll.Detail.Replace("/ImgUpload/kindeditor/image/", "http://shop100000027.nec888.com/ImgUpload/kindeditor/image/");
                        }
                    }
                    M_ProducetAll.Ems_fee = Convert.ToInt32(row["Ems_fee"]);
                    M_ProducetAll.EndTime = Convert.ToString(row["EndTime"]);
                    M_ProducetAll.Express_fee = Convert.ToInt32(row["Express_fee"]);
                    M_ProducetAll.FeeTemplateID = Convert.ToInt32(row["FeeTemplateID"]);
                    M_ProducetAll.FeeTemplateName = Convert.ToString(row["FeeTemplateName"]);
                    M_ProducetAll.FeeType = Convert.ToInt32(row["FeeType"]);
                    M_ProducetAll.Guid = Convert.ToString(row["Guid"]);
                    M_ProducetAll.Id = Convert.ToInt32(row["Id"]);
                    M_ProducetAll.Instruction = Convert.ToString(row["Instruction"]);
                    M_ProducetAll.IsAudit = Convert.ToInt32(row["IsAudit"]);
                    M_ProducetAll.IsBest = Convert.ToInt32(row["IsBest"]);
                    M_ProducetAll.IsDeleted = Convert.ToInt32(row["IsDeleted"]);
                    M_ProducetAll.IsHot = Convert.ToInt32(row["IsHot"]);
                    M_ProducetAll.IsNew = Convert.ToInt32(row["IsNew"]);
                    M_ProducetAll.IsPromotion = Convert.ToInt32(row["IsPromotion"]);
                    M_ProducetAll.IsReal = Convert.ToInt32(row["IsReal"]);
                    M_ProducetAll.IsRecommend = Convert.ToInt32(row["IsRecommend"]);
                    M_ProducetAll.IsSaled = Convert.ToInt32(row["IsSaled"]);
                    M_ProducetAll.IsSell = Convert.ToInt32(row["IsSell"]);
                    M_ProducetAll.IsShopGood = Convert.ToInt32(row["IsShopGood"]);
                    M_ProducetAll.IsShopHot = Convert.ToInt32(row["IsShopHot"]);
                    M_ProducetAll.IsShopNew = Convert.ToInt32(row["IsShopNew"]);
                    M_ProducetAll.IsShopPromotion = Convert.ToInt32(row["IsShopPromotion"]);
                    M_ProducetAll.IsShopRecommend = Convert.ToInt32(row["IsShopRecommend"]);
                    M_ProducetAll.Keywords = Convert.ToString(row["Keywords"]);
                    M_ProducetAll.MemLoginID = Convert.ToString(row["MemLoginID"]);
                    M_ProducetAll.MinusFee = Convert.ToInt32(row["MinusFee"]);
                    M_ProducetAll.ModifyTime = Convert.ToString(row["ModifyTime"]);
                    M_ProducetAll.ModifyUser = Convert.ToString(row["ModifyUser"]);
                    M_ProducetAll.MonthSale = Convert.ToInt32(row["MonthSale"]);
                    string str = Convert.ToString(row["MultiImages"]);

                    //M_ProducetAll.MultiImages = str.Replace("/ImgUpload/", "http://" + M_ProducetAll.Shop_url + ShopNum1.Common.ShopSettings.CookieDomain + "/ImgUpload/");
                    M_ProducetAll.MultiImages = str.Replace("/ImgUpload/", "http://shop100000027.nec888.com/ImgUpload/");

                    M_ProducetAll.Name = Convert.ToString(row["Name"]);
                    

                    M_ProducetAll.OrderID = Convert.ToInt32(row["OrderID"]);
                    M_ProducetAll.OriginalImage = Convert.ToString(row["OriginalImage"]);
                    M_ProducetAll.Post_fee = Convert.ToInt32(row["Post_fee"]);
                    M_ProducetAll.ProductCategoryCode = Convert.ToString(row["ProductCategoryCode"]);
                    M_ProducetAll.ProductCategoryName = Convert.ToString(row["ProductCategoryName"]);
                    M_ProducetAll.ProductNum = Convert.ToString(row["ProductNum"]);
                    M_ProducetAll.ProductSeriesCode = Convert.ToString(row["ProductSeriesCode"]);
                    M_ProducetAll.ProductSeriesName = Convert.ToString(row["ProductSeriesName"]);
                    M_ProducetAll.ProductState = Convert.ToInt32(row["ProductState"]);


                    M_ProducetAll.PulishType = Convert.ToInt32(row["PulishType"]);
                    M_ProducetAll.RepertoryAlertCount = Convert.ToInt32(row["RepertoryAlertCount"]);
                    M_ProducetAll.RepertoryCount = Convert.ToInt32(row["RepertoryCount"]);
                    M_ProducetAll.SaleNumber = Convert.ToInt32(row["SaleNumber"]);
                    M_ProducetAll.SaleTime = Convert.ToString(row["SaleTime"]);
                    M_ProducetAll.Score = Convert.ToString(row["Score"]);
                    M_ProducetAll.SetStock = Convert.ToInt32(row["SetStock"]);
                    M_ProducetAll.ShopName = Convert.ToString(row["ShopName"]);
                    M_ProducetAll.Size = Convert.ToString(row["Size"]);
                    M_ProducetAll.SmallImage = Convert.ToString(row["SmallImage"]);
                    M_ProducetAll.StartTime = Convert.ToString(row["StartTime"]);
                    M_ProducetAll.ThumbImage = Convert.ToString(row["ThumbImage"]);
                    M_ProducetAll.UnitName = Convert.ToString(row["UnitName"]);
                    M_ProducetAll.Wap_desc = Convert.ToString(row["Wap_desc"]);
                    M_ProducetAll.Wap_detail_url = Convert.ToString(row["Wap_detail_url"]);

                    M_ProducetAll.AgentId = Convert.ToString(row["AgentId"]);
                    M_ProducetAll.id = Convert.ToInt32(row["id"]);
                    M_ProducetAll.MarketPrice = Convert.ToDecimal(row["MarketPrice"]);
                    M_ProducetAll.productId = Convert.ToInt32(row["productId"]);
                    M_ProducetAll.remark = Convert.ToString(row["remark"]);
                    M_ProducetAll.Score_bv = Convert.ToDecimal(row["Score_bv"]);
                    M_ProducetAll.Score_cv = Convert.ToDecimal(row["Score_cv"]);
                    M_ProducetAll.Score_dv = Convert.ToDecimal(row["Score_dv"]);
                    M_ProducetAll.Score_hv = Convert.ToDecimal(row["Score_hv"]);
                    M_ProducetAll.Score_max_hv = Convert.ToDecimal(row["Score_max_hv"]);
                    M_ProducetAll.Score_pv_a = Convert.ToDecimal(row["Score_pv_a"]);
                    M_ProducetAll.Score_pv_b = Convert.ToDecimal(row["Score_pv_b"]);
                    M_ProducetAll.Score_pv_cv = Convert.ToDecimal(row["Score_pv_cv"]);
                    M_ProducetAll.Score_reduce_pv_cv = Convert.ToDecimal(row["Score_reduce_pv_cv"]);
                    M_ProducetAll.Score_rv = Convert.ToDecimal(row["Score_rv"]);
                    M_ProducetAll.Score_sv = Convert.ToDecimal(row["Score_sv"]);
                    M_ProducetAll.shop_category_id = Convert.ToInt32(row["shop_category_id"]);
                    M_ProducetAll.ShopPrice = Convert.ToDecimal(row["ShopPrice"]);
                    M_ProducetAll.GoodsWeight = Convert.ToDecimal(row["GoodsWeight"]);
                    M_ProducetAll.SuanLiDaySum = 0;
                    M_ProducetAll.SuanLiUnitPrice = 0;
                    products.Add(M_ProducetAll);
                }

                return products;

            }
	}
    
}
