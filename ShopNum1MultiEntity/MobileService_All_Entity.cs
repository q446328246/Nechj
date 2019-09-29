using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Data;

namespace ShopNum1MultiEntity
{
    public class MobileService_All_Entity : INotifyPropertyChanging, INotifyPropertyChanged
    {


        #region 方法
        public static List<Mobile_ShopNum1_Bank> From_PayDecrease_Bank(Mobile_ShopNum1_Bank table)
        {
            List<Mobile_ShopNum1_Bank> All_Entity = new List<Mobile_ShopNum1_Bank>();
            
                Mobile_ShopNum1_Bank Entity = new Mobile_ShopNum1_Bank();

                Entity.Bank = table.Bank;
                Entity.BankAdress =table.BankAdress;
                Entity.BankName =table.BankName;
                Entity.BankNo = table.BankNo;


                All_Entity.Add(Entity);
            


            return All_Entity;

        }
        public static List<Mobile_ShopNum1_SelectOrderStatusNum> From_SelectOrderstatusByMemid(DataTable table)
        {
            List<Mobile_ShopNum1_SelectOrderStatusNum> All_Entity = new List<Mobile_ShopNum1_SelectOrderStatusNum>();
            foreach (DataRow row in table.Rows)
            {
                Mobile_ShopNum1_SelectOrderStatusNum Entity = new Mobile_ShopNum1_SelectOrderStatusNum();

                Entity.OrderStatus0 = Convert.ToString(row["a"]);
                Entity.OrderStatus1 = Convert.ToString(row["b"]);
                Entity.OrderStatus2 = Convert.ToString(row["c"]);



                All_Entity.Add(Entity);
            }


            return All_Entity;
        }

        public static List<Mobile_ShopNum1_ReMenSouSuo> From_SelectHot(DataTable table)
        {
            List<Mobile_ShopNum1_ReMenSouSuo> All_Entity = new List<Mobile_ShopNum1_ReMenSouSuo>();
            foreach (DataRow row in table.Rows)
            {
                Mobile_ShopNum1_ReMenSouSuo Entity = new Mobile_ShopNum1_ReMenSouSuo();

                Entity.MobileService_ReMenSouSuo__Id = Convert.ToString(row["Id"]);
                Entity.MobileService_ReMenSouSuo__SelectName = Convert.ToString(row["SelectName"]);
                Entity.MobileService_ReMenSouSuo__Shop_Category_ID = Convert.ToString(row["Shop_Category_ID"]);



                All_Entity.Add(Entity);
            }


            return All_Entity;

        }

        public static List<Mobile_ShopNum1_RelationSelect> From_RelationSelect(DataTable table)
        {
            List<Mobile_ShopNum1_RelationSelect> All_Entity = new List<Mobile_ShopNum1_RelationSelect>();
            foreach (DataRow row in table.Rows)
            {
                Mobile_ShopNum1_RelationSelect Entity = new Mobile_ShopNum1_RelationSelect();

                Entity.ShopNum1_ShopInfo__ShopName = Convert.ToString(row["ShopName"]);
                Entity.ShopNum1_Shop_Product__Name = Convert.ToString(row["ProductName"]);



                All_Entity.Add(Entity);
            }


            return All_Entity;

        }

        public static List<MobileService_All_Entity> From_RelationSelectShopInfo(DataTable table)
        {
            List<MobileService_All_Entity> All_Entity = new List<MobileService_All_Entity>();
            foreach (DataRow row in table.Rows)
            {
                MobileService_All_Entity Entity = new MobileService_All_Entity();

                Entity.ShopNum1_ShopInfo__ShopName = Convert.ToString(row["ShopName"]);
                Entity.ShopNum1_ShopInfo__Phone = Convert.ToString(row["Phone"]);
                Entity.ShopNum1_ShopInfo__AddressValue = Convert.ToString(row["AddressValue"]);
                Entity.ShopNum1_ShopInfo__Address = Convert.ToString(row["Address"]);
                Entity.ShopNum1_ShopInfo__Banner = Convert.ToString(row["Banner"]);
                Entity.ShopNum1_ShopInfo__MemLoginID = Convert.ToString(row["MemLoginID"]);
                Entity.ShopNum1_ShopInfo__MainGoods = Convert.ToString(row["MainGoods"]);



                All_Entity.Add(Entity);
            }


            return All_Entity;

        }
        public static List<Mobile_ShopNum1_FxUrl> From_FxUrl(Mobile_ShopNum1_FxUrl table)
        {
            List<Mobile_ShopNum1_FxUrl> All_Entity = new List<Mobile_ShopNum1_FxUrl>();

            Mobile_ShopNum1_FxUrl Entity = new Mobile_ShopNum1_FxUrl();

                Entity.FxUrl__share_title = Convert.ToString(table.FxUrl__share_title);
                Entity.FxUrl__share_url = Convert.ToString(table.FxUrl__share_url);
                Entity.FxUrl__share_icon = Convert.ToString(table.FxUrl__share_icon);
                Entity.FxUrl__share_description = Convert.ToString(table.FxUrl__share_description);
                



                All_Entity.Add(Entity);
            


            return All_Entity;

        }
        
        #endregion






        #region 参数申明



        public virtual string ShopNum1_ShopInfo__ShopName { get; set; }
        public virtual string ShopNum1_ShopInfo__Phone { get; set; }
        public virtual string ShopNum1_ShopInfo__AddressValue { get; set; }
        public virtual string ShopNum1_ShopInfo__Address { get; set; }
        public virtual string ShopNum1_ShopInfo__Banner { get; set; }
        public virtual string ShopNum1_ShopInfo__MemLoginID { get; set; }
        public virtual string ShopNum1_ShopInfo__MainGoods { get; set; }



        


        
        #endregion






        #region 封装
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

        #endregion


        
    }
}
