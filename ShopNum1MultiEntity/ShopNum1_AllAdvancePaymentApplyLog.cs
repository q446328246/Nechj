using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Data;

namespace ShopNum1MultiEntity
{
    public class ShopNum1_AllAdvancePaymentApplyLog : INotifyPropertyChanging, INotifyPropertyChanged
	{

        private static readonly PropertyChangingEventArgs propertyChangingEventArgs_0 =
          new PropertyChangingEventArgs(string.Empty);

        public virtual string Guid { get; set; }
        public virtual string OperateType { get; set; }
        public virtual string OrderNumber { get; set; }
        public virtual string CurrentAdvancePayment { get; set; }
        public virtual string OperateMoney { get; set; }
        public virtual string Date { get; set; }
        public virtual string OperateStatus { get; set; }
        public virtual string Memo { get; set; }
        public virtual string UserMemo { get; set; }
        public virtual string MemLoginID { get; set; }
        public virtual string PaymentGuid { get; set; }
        public virtual string PaymentName { get; set; }
        public virtual string Bank { get; set; }
        public virtual string TrueName { get; set; }
        public virtual string Account { get; set; }
        public virtual string IsDeleted { get; set; }
        public virtual string ID { get; set; }
        public virtual string OrderStatus { get; set; }
        public virtual string BankCard { get; set; }
        public virtual string GetBamkCard { get; set; }
        public virtual string UserName { get; set; }
        public virtual string ModifyTime { get; set; }

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


        public static List<ShopNum1_AllAdvancePaymentApplyLog> FromDataRowGetAllShopCategorys(DataTable table)
        {
            List<ShopNum1_AllAdvancePaymentApplyLog> products = new List<ShopNum1_AllAdvancePaymentApplyLog>();
            foreach (DataRow row in table.Rows)
            {
                ShopNum1_AllAdvancePaymentApplyLog AllShopCategorys = new ShopNum1_AllAdvancePaymentApplyLog();
                AllShopCategorys.Guid = Convert.ToString(row["Guid"]);
                AllShopCategorys.OperateType = Convert.ToString(row["OperateType"]);
                AllShopCategorys.OrderNumber = Convert.ToString(row["OrderNumber"]);
                AllShopCategorys.CurrentAdvancePayment = Convert.ToString(row["CurrentAdvancePayment"]);
                AllShopCategorys.OperateMoney = Convert.ToString(row["OperateMoney"]);
                AllShopCategorys.Date = Convert.ToString(row["Date"]);
                AllShopCategorys.OperateStatus = Convert.ToString(row["OperateStatus"]);
                AllShopCategorys.Memo = Convert.ToString(row["Memo"]);
                AllShopCategorys.UserMemo = Convert.ToString(row["UserMemo"]);
                AllShopCategorys.MemLoginID = Convert.ToString(row["MemLoginID"]);
                AllShopCategorys.PaymentGuid = Convert.ToString(row["PaymentGuid"]);
                AllShopCategorys.PaymentName = Convert.ToString(row["PaymentName"]);
                AllShopCategorys.Bank = Convert.ToString(row["Bank"]);
                AllShopCategorys.TrueName = Convert.ToString(row["TrueName"]);
                AllShopCategorys.Account = Convert.ToString(row["Account"]);
                AllShopCategorys.IsDeleted = Convert.ToString(row["IsDeleted"]);
                AllShopCategorys.ID = Convert.ToString(row["ID"]);
                AllShopCategorys.OrderStatus = Convert.ToString(row["OrderStatus"]);
                AllShopCategorys.BankCard = Convert.ToString(row["BankCard"]);
                AllShopCategorys.GetBamkCard = Convert.ToString(row["GetBamkCard"]);
                AllShopCategorys.UserName = Convert.ToString(row["UserName"]);
                AllShopCategorys.ModifyTime = Convert.ToString(row["ModifyTime"]);


                products.Add(AllShopCategorys);
            }


            return products;

        }
	}
}
