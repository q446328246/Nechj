using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Data;

namespace ShopNum1MultiEntity
{
    public class GetShopIDAll_two : INotifyPropertyChanging, INotifyPropertyChanged
    {
        private static readonly PropertyChangingEventArgs propertyChangingEventArgs_0 =
          new PropertyChangingEventArgs(string.Empty);

        private string guid;
        public string Guid
        {
            get { return guid; }
            set { guid = value; }
        }
        private string name;
        public string NAME
        {
            get { return name; }
            set { name = value; }
        }
        private string shopname;
        public string Shopname
        {
            get { return shopname; }
            set { shopname = value; }
        }
        private string shopid;
        public string Shopid
        {
            get { return shopid; }
            set { shopid = value; }
        }
        private string shopurl;
        public string Shopurl
        {
            get { return shopurl; }
            set { shopurl = value; }
        }
        private string salesrange;
        public string Salesrange
        {
            get { return salesrange; }
            set { salesrange = value; }
        }


     

        private string ADDRESScode;
        public string addresscode
        {
            get { return ADDRESScode; }
            set { ADDRESScode = value; }
        }


      

        private string banner;
        public string Banner
        {
            get { return banner; }
            set { banner = value; }
        }


  


    

        private string memloginid;
        public string Memloginid
        {
            get { return memloginid; }
            set { memloginid = value; }
        }


       
  
   
      

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

        public static List<GetShopIDAll_two> FromDataRowGetProductByShop_category_id(DataTable table)
        {
            List<GetShopIDAll_two> products = new List<GetShopIDAll_two>();
            foreach (DataRow row in table.Rows)
            {
                GetShopIDAll_two M_ProducetAll = new GetShopIDAll_two();
                M_ProducetAll.Guid = Convert.ToString(row["Guid"]);
                M_ProducetAll.NAME = Convert.ToString(row["NAME"]);
                M_ProducetAll.Shopname = Convert.ToString(row["shopname"]);
                M_ProducetAll.Shopid = Convert.ToString(row["shopid"]);
                M_ProducetAll.Shopurl = Convert.ToString(row["Shopurl"]);
                M_ProducetAll.Salesrange = Convert.ToString(row["Salesrange"]);

                
                M_ProducetAll.addresscode = Convert.ToString(row["addresscode"]);
         
                M_ProducetAll.Banner = Convert.ToString(row["Banner"]);
              
          
            
             
          
                M_ProducetAll.Memloginid = Convert.ToString(row["Memloginid"]);
               
            
                

                products.Add(M_ProducetAll);
            }

            return products;

        }
    }
}
