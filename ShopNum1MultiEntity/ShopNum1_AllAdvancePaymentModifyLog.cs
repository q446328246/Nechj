using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Data;

namespace ShopNum1MultiEntity
{
    public class ShopNum1_AllAdvancePaymentModifyLog : INotifyPropertyChanging, INotifyPropertyChanged
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
        public virtual string  Guid { get; set; }
        public virtual string OperateType { get; set; }
        public virtual string CurrentAdvancePayment { get; set; }
        public virtual string OperateMoney { get; set; }
        public virtual string LastOperateMoney { get; set; }
        public virtual string Date { get; set; }
        public virtual string Memo { get; set; }
        public virtual string MemLoginID { get; set; }
        public virtual string CreateUser { get; set; }
        public virtual string CreateTime { get; set; }
        public virtual string IsDeleted { get; set; }
        public virtual string UserMemo { get; set; }
        public virtual string OrderNumber { get; set; }
        //public virtual string XiaoFei_YuanYou_hv { get; set; }
        //public virtual string XiaoFei_hv { get; set; }
        //public virtual string XiaoFei_Hou_hv { get; set; }
        //public virtual string XiaoFei_YuanYou_pv_a { get; set; }
        //public virtual string XiaoFei_pv_a { get; set; }
        //public virtual string XiaoFei_Hou_pv_a { get; set; }
        //public virtual string XiaoFei_YuanYou_pv_b { get; set; }
        //public virtual string XiaoFei_pv_b { get; set; }
        //public virtual string XiaoFei_Hou_pv_b { get; set; }
        //public virtual string HuoDe_YuanYou_hv { get; set; }
        //public virtual string HuoDe_hv { get; set; }
        //public virtual string Huo_DeHou_hv { get; set; }
        //public virtual string HuoDe_YuanYou_pv_a { get; set; }
        //public virtual string HuoDe_pv_a { get; set; }
        //public virtual string Huo_DeHou_pv_a { get; set; }
        //public virtual string HuoDe_YuanYou_pv_b { get; set; }
        //public virtual string HuoDe_pv_b { get; set; }
        //public virtual string Huo_DeHou_pv_b { get; set; }
        //public virtual string XiaoFei_YuanYou_rv { get; set; }
        //public virtual string XiaoFei_rv { get; set; }
        //public virtual string XiaoFei_Hou_rv { get; set; }
        //public virtual string HuoDe_YuanYou_dv { get; set; }
        //public virtual string HuoDe_dv { get; set; }
        //public virtual string Huo_DeHou_sdv { get; set; }
        //public virtual string DeDao_Qian_cv { get; set; }
        //public virtual string DeDao_cv { get; set; }
        //public virtual string DeDao_Hou_cv { get; set; }
        //public virtual string XiaoFei_Qian_cv { get; set; }
        //public virtual string XiaoFei_cv { get; set; }
        //public virtual string XiaoFei_Hou_cv { get; set; }
        //public virtual string DeDao_Qian_dv { get; set; }
        //public virtual string DeDao_dv { get; set; }
        //public virtual string DeDao_Hou_dv { get; set; }
        //public virtual string DeDao_YuanYou_rv { get; set; }
        //public virtual string DeDao_rv { get; set; }
        //public virtual string DeDao_Hou_rv { get; set; }
        //public virtual string HuoDe_YuanYou_DJ_BV { get; set; }
        //public virtual string HuoDe_DJ_BV { get; set; }
        //public virtual string Huo_DeHou_DJ_BV { get; set; }


        public static List<ShopNum1_AllAdvancePaymentModifyLog> FromDataRowGetAllShopCategorys(DataTable table)
        {
            List<ShopNum1_AllAdvancePaymentModifyLog> products = new List<ShopNum1_AllAdvancePaymentModifyLog>();
            foreach (DataRow row in table.Rows)
            {
                ShopNum1_AllAdvancePaymentModifyLog AllShopCategorys = new ShopNum1_AllAdvancePaymentModifyLog();
                AllShopCategorys.Guid = Convert.ToString(row["Guid"]);
                AllShopCategorys.OperateType = Convert.ToString(row["OperateType"]);
                AllShopCategorys.CurrentAdvancePayment = Convert.ToString(row["money_first"]);
                AllShopCategorys.OperateMoney = Convert.ToString(row["money_two"]);
                AllShopCategorys.LastOperateMoney = Convert.ToString(row["money_free"]);
                AllShopCategorys.Date = Convert.ToString(row["Date"]);
                AllShopCategorys.Memo = Convert.ToString(row["Memo"]);
                AllShopCategorys.MemLoginID = Convert.ToString(row["MemLoginID"]);
                AllShopCategorys.CreateUser = Convert.ToString(row["CreateUser"]);
                AllShopCategorys.CreateTime = Convert.ToString(row["CreateTime"]);
                AllShopCategorys.IsDeleted = Convert.ToString(row["IsDeleted"]);
                AllShopCategorys.UserMemo = Convert.ToString(row["UserMemo"]);
                AllShopCategorys.OrderNumber = Convert.ToString(row["OrderNumber"]);
                //AllShopCategorys.XiaoFei_YuanYou_hv = Convert.ToString(row["XiaoFei_YuanYou_hv"]);
                //AllShopCategorys.XiaoFei_hv = Convert.ToString(row["XiaoFei_hv"]);
                //AllShopCategorys.XiaoFei_Hou_hv = Convert.ToString(row["XiaoFei_Hou_hv"]);
                //AllShopCategorys.XiaoFei_YuanYou_pv_a = Convert.ToString(row["XiaoFei_YuanYou_pv_a"]);
                //AllShopCategorys.XiaoFei_pv_a = Convert.ToString(row["XiaoFei_pv_a"]);
                //AllShopCategorys.XiaoFei_Hou_pv_a = Convert.ToString(row["XiaoFei_Hou_pv_a"]);
                //AllShopCategorys.XiaoFei_YuanYou_pv_b = Convert.ToString(row["XiaoFei_YuanYou_pv_b"]);
                //AllShopCategorys.XiaoFei_pv_b = Convert.ToString(row["XiaoFei_pv_b"]);
                //AllShopCategorys.XiaoFei_Hou_pv_b = Convert.ToString(row["XiaoFei_Hou_pv_b"]);
                //AllShopCategorys.HuoDe_YuanYou_hv = Convert.ToString(row["HuoDe_YuanYou_hv"]);
                //AllShopCategorys.HuoDe_hv = Convert.ToString(row["HuoDe_hv"]);
                //AllShopCategorys.Huo_DeHou_hv = Convert.ToString(row["Huo_DeHou_hv"]);
                //AllShopCategorys.HuoDe_YuanYou_pv_a = Convert.ToString(row["HuoDe_YuanYou_pv_a"]);
                //AllShopCategorys.HuoDe_pv_a = Convert.ToString(row["HuoDe_pv_a"]);
                //AllShopCategorys.Huo_DeHou_pv_a = Convert.ToString(row["Huo_DeHou_pv_a"]);
                //AllShopCategorys.HuoDe_YuanYou_pv_b = Convert.ToString(row["HuoDe_YuanYou_pv_b"]);
                //AllShopCategorys.HuoDe_pv_b = Convert.ToString(row["HuoDe_pv_b"]);
                //AllShopCategorys.Huo_DeHou_pv_b = Convert.ToString(row["Huo_DeHou_pv_b"]);
                //AllShopCategorys.XiaoFei_YuanYou_rv = Convert.ToString(row["XiaoFei_YuanYou_rv"]);
                //AllShopCategorys.XiaoFei_rv = Convert.ToString(row["XiaoFei_rv"]);
                //AllShopCategorys.XiaoFei_Hou_rv = Convert.ToString(row["XiaoFei_Hou_rv"]);
                //AllShopCategorys.HuoDe_YuanYou_dv = Convert.ToString(row["HuoDe_YuanYou_dv"]);
                //AllShopCategorys.HuoDe_dv = Convert.ToString(row["HuoDe_dv"]);
                //AllShopCategorys.Huo_DeHou_sdv = Convert.ToString(row["Huo_DeHou_sdv"]);
                //AllShopCategorys.DeDao_Qian_cv = Convert.ToString(row["DeDao_Qian_cv"]);
                //AllShopCategorys.DeDao_cv = Convert.ToString(row["DeDao_cv"]);
                //AllShopCategorys.DeDao_Hou_cv = Convert.ToString(row["DeDao_Hou_cv"]);
                //AllShopCategorys.XiaoFei_Qian_cv = Convert.ToString(row["XiaoFei_Qian_cv"]);
                //AllShopCategorys.XiaoFei_cv = Convert.ToString(row["XiaoFei_cv"]);
                //AllShopCategorys.XiaoFei_Hou_cv = Convert.ToString(row["XiaoFei_Hou_cv"]);
                //AllShopCategorys.DeDao_Qian_dv = Convert.ToString(row["DeDao_Qian_dv"]);
                //AllShopCategorys.DeDao_dv = Convert.ToString(row["DeDao_dv"]);
                //AllShopCategorys.DeDao_Hou_dv = Convert.ToString(row["DeDao_Hou_dv"]);
                //AllShopCategorys.DeDao_YuanYou_rv = Convert.ToString(row["DeDao_YuanYou_rv"]);
                //AllShopCategorys.DeDao_rv = Convert.ToString(row["DeDao_rv"]);
                //AllShopCategorys.DeDao_Hou_rv = Convert.ToString(row["DeDao_Hou_rv"]);
                //AllShopCategorys.HuoDe_YuanYou_DJ_BV = Convert.ToString(row["HuoDe_YuanYou_DJ_BV"]);
                //AllShopCategorys.HuoDe_DJ_BV = Convert.ToString(row["HuoDe_DJ_BV"]);
                //AllShopCategorys.Huo_DeHou_DJ_BV = Convert.ToString(row["Huo_DeHou_DJ_BV"]);



                products.Add(AllShopCategorys);
            }


            return products;

        }
	}
}
