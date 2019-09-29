using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Data;

namespace  ShopNum1MultiEntity
{
 public	class ShopNum1_M_two_product: INotifyPropertyChanging, INotifyPropertyChanged
	{

         private static readonly PropertyChangingEventArgs propertyChangingEventArgs_0 =
           new PropertyChangingEventArgs(string.Empty);
        

        public virtual string Name { get; set; } 

        public virtual int Id { get; set; } 

        public virtual string OriginalImage { get; set; } 

        
      public virtual decimal ShopPrice { get; set; }

        

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
            public static List<ShopNum1_M_two_product> FromDataRowGetProductByShop_category_id(DataTable table)
            {
                List<ShopNum1_M_two_product> products = new List<ShopNum1_M_two_product>();
                foreach (DataRow row in table.Rows)
                {
                    ShopNum1_M_two_product M_ProducetAll = new ShopNum1_M_two_product();
                    
                    M_ProducetAll.Id = Convert.ToInt32(row["Id"]);
                   
                    M_ProducetAll.Name = Convert.ToString(row["Name"]);
                    
                    M_ProducetAll.OriginalImage = Convert.ToString(row["OriginalImage"]);
                   
                    M_ProducetAll.ShopPrice = Convert.ToDecimal(row["ShopPrice"]);
                
                    products.Add(M_ProducetAll);
                }

                return products;

            }
	}
	}

