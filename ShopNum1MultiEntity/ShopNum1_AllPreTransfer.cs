using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Data;

namespace ShopNum1MultiEntity
{
	public class ShopNum1_AllPreTransfer: INotifyPropertyChanging, INotifyPropertyChanged
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
        public virtual string OrderNumber { get; set; }
        public virtual string OperateMoney { get; set; }
        public virtual string Date { get; set; }
        public virtual string Memo { get; set; }
        public virtual string MemLoginID { get; set; }
        public virtual string RMemberID { get; set; }
        public virtual string YzCode { get; set; }
        public virtual string OperateStatus { get; set; }
        public virtual string IsDeleted { get; set; }
        public virtual string type { get; set; }


        public static List<ShopNum1_AllPreTransfer> FromDataRowGetAllShopCategorys(DataTable table)
        {
            List<ShopNum1_AllPreTransfer> products = new List<ShopNum1_AllPreTransfer>();
            foreach (DataRow row in table.Rows)
            {
                ShopNum1_AllPreTransfer AllShopCategorys = new ShopNum1_AllPreTransfer();
                AllShopCategorys.Guid = Convert.ToString(row["Guid"]);
                AllShopCategorys.OrderNumber = Convert.ToString(row["OrderNumber"]);
                AllShopCategorys.OperateMoney = Convert.ToString(row["OperateMoney"]);
                AllShopCategorys.Date = Convert.ToString(row["Date"]);
                AllShopCategorys.Memo = Convert.ToString(row["Memo"]);
                AllShopCategorys.MemLoginID = Convert.ToString(row["MemLoginID"]);
                AllShopCategorys.RMemberID = Convert.ToString(row["RMemberID"]);
                AllShopCategorys.YzCode = Convert.ToString(row["YzCode"]);

                AllShopCategorys.OperateStatus = Convert.ToString(row["OperateStatus"]);
                AllShopCategorys.IsDeleted = Convert.ToString(row["IsDeleted"]);
                AllShopCategorys.type = Convert.ToString(row["type"]);


                products.Add(AllShopCategorys);
            }


            return products;

        }
	}
}
