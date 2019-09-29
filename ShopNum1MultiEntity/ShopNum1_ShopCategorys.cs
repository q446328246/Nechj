using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Data;

namespace ShopNum1MultiEntity
{
	public class ShopNum1_ShopCategorys: INotifyPropertyChanging, INotifyPropertyChanged
	{

        private static readonly PropertyChangingEventArgs propertyChangingEventArgs_0 =
          new PropertyChangingEventArgs(string.Empty);

        public virtual string ID { get; set; }
        public virtual string Name { get; set; }
        public virtual string Keywords { get; set; }
        public virtual string Description { get; set; }
        public virtual string OrderID { get; set; }
        public virtual string IsShow { get; set; }
        public virtual string CategoryLevel { get; set; }
        public virtual string FatherID { get; set; }
        public virtual string Family { get; set; }
        public virtual string CreateUser { get; set; }
        public virtual string CreateTime { get; set; }
        public virtual string ModifyUser { get; set; }
        public virtual string ModifyTime { get; set; }
        public virtual string IsDeleted { get; set; }
        public virtual string Code { get; set; }
        public virtual string IsRecommend { get; set; }



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

        public static List<ShopNum1_ShopCategorys> FromDataRowGetAllShopCategorys(DataTable table)
        {
            List<ShopNum1_ShopCategorys> products = new List<ShopNum1_ShopCategorys>();
            foreach (DataRow row in table.Rows)
            {
                ShopNum1_ShopCategorys AllShopCategorys = new ShopNum1_ShopCategorys();
                AllShopCategorys.ID = Convert.ToString(row["ID"]);
                AllShopCategorys.Name = Convert.ToString(row["Name"]);
                AllShopCategorys.Keywords = Convert.ToString(row["Keywords"]);
                AllShopCategorys.Description = Convert.ToString(row["Description"]);
                AllShopCategorys.OrderID = Convert.ToString(row["OrderID"]);
                AllShopCategorys.IsShow = Convert.ToString(row["IsShow"]);
                AllShopCategorys.CategoryLevel = Convert.ToString(row["CategoryLevel"]);
                AllShopCategorys.FatherID = Convert.ToString(row["FatherID"]);
                AllShopCategorys.Family = Convert.ToString(row["Family"]);
                AllShopCategorys.CreateUser = Convert.ToString(row["CreateUser"]);
                AllShopCategorys.CreateTime = Convert.ToString(row["CreateTime"]);
                AllShopCategorys.ModifyUser = Convert.ToString(row["ModifyUser"]);
                AllShopCategorys.ModifyTime = Convert.ToString(row["ModifyTime"]);
                AllShopCategorys.IsDeleted = Convert.ToString(row["IsDeleted"]);
                AllShopCategorys.Code = Convert.ToString(row["Code"]);
                AllShopCategorys.IsRecommend = Convert.ToString(row["IsRecommend"]);

                products.Add(AllShopCategorys);
            }

            return products;

        }
	}
}
