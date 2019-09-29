using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Data;

namespace ShopNum1MultiEntity
{
    public class ShopNum1_SerchTwo : INotifyPropertyChanging, INotifyPropertyChanged
	{

        private static readonly PropertyChangingEventArgs propertyChangingEventArgs_0 =
          new PropertyChangingEventArgs(string.Empty);


        public virtual string Guid { get; set; }

        public virtual string Name { get; set; }

        public virtual string Memo { get; set; }


        public virtual string Charge { get; set; }
        public virtual string IsPercent { get; set; }
        public virtual string PaymentType { get; set; }


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
        public static List<ShopNum1_SerchTwo> FromDataRowGetProductByShop_category_id(DataTable table)
        {
            List<ShopNum1_SerchTwo> products = new List<ShopNum1_SerchTwo>();
            foreach (DataRow row in table.Rows)
            {
                ShopNum1_SerchTwo M_ProducetAll = new ShopNum1_SerchTwo();

                M_ProducetAll.Guid = Convert.ToString(row["Guid"]);

                M_ProducetAll.Name = Convert.ToString(row["Name"]);

                M_ProducetAll.Memo = Convert.ToString(row["Memo"]);

                M_ProducetAll.Charge = Convert.ToString(row["Charge"]);
                M_ProducetAll.IsPercent = Convert.ToString(row["IsPercent"]);
                M_ProducetAll.PaymentType = Convert.ToString(row["PaymentType"]);
                products.Add(M_ProducetAll);
            }

            return products;

        }
	}
}
