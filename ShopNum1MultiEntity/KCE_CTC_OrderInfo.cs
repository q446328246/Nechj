using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Data;
using ShopNum1.Common;
namespace ShopNum1MultiEntity
{
    public class KCE_CTC_OrderInfo : INotifyPropertyChanging, INotifyPropertyChanged
    {
        private static readonly PropertyChangingEventArgs propertyChangingEventArgs_0 =
            new PropertyChangingEventArgs(string.Empty);
        private string string_5;
        private string string_6;
        private string string_7;
        private decimal decimal_0;
        private decimal decimal_1;
        private string string_0;
        private string string_1;
        private string string_2;
        private string string_3;
        private string string_4;
        private string string_8;
        private string string_9;



        public string Photo
        {
            get { return string_9; }
            set
            {
                if (string_9 != value)
                {
                    SendPropertyChanging();
                    string_9 = value;
                    SendPropertyChanged("Photo");
                }
            }
        }

        public string Name
        {
            get { return string_8; }
            set
            {
                if (string_8 != value)
                {
                    SendPropertyChanging();
                    string_8 = value;
                    SendPropertyChanged("Name");
                }
            }
        }
        public string PayTime
        {
            get { return string_5; }
            set
            {
                if (string_5 != value)
                {
                    SendPropertyChanging();
                    string_5 = value;
                    SendPropertyChanged("PayTime");
                }
            }
        }

        public string CreateTime
        {
            get { return string_6; }
            set
            {
                if (string_6 != value)
                {
                    SendPropertyChanging();
                    string_6 = value;
                    SendPropertyChanged("CreateTime");
                }
            }
        }

        public string ConfirmTime
        {
            get { return string_7; }
            set
            {
                if (string_7 != value)
                {
                    SendPropertyChanging();
                    string_7 = value;
                    SendPropertyChanged("ConfirmTime");
                }
            }
        }


        public string ServiceAgent
        {
            get { return string_4; }
            set
            {
                if (string_4 != value)
                {
                    SendPropertyChanging();
                    string_4 = value;
                    SendPropertyChanged("ServiceAgent");
                }
            }
        }
        public decimal Score_pv_b
        {
            get { return decimal_1; }
            set
            {
                if (decimal_1 != value)
                {
                    SendPropertyChanging();
                    decimal_1 = value;
                    SendPropertyChanged("Score_pv_b");
                }
            }
        }

        public decimal ShouldPayPrice
        {
            get { return decimal_0; }
            set
            {
                if (decimal_0 != value)
                {
                    SendPropertyChanging();
                    decimal_0 = value;
                    SendPropertyChanged("ShouldPayPrice");
                }
            }
        }

        public string ShipmentStatus
        {
            get { return string_3; }
            set
            {
                if (string_3 != value)
                {
                    SendPropertyChanging();
                    string_3 = value;
                    SendPropertyChanged("ShipmentStatus");
                }
            }
        }
        public string OderStatus
        {
            get { return string_2; }
            set
            {
                if (string_2 != value)
                {
                    SendPropertyChanging();
                    string_2 = value;
                    SendPropertyChanged("OderStatus");
                }
            }
        }

        public string OrderNumber
        {
            get { return string_1; }
            set
            {
                if (string_1 != value)
                {
                    SendPropertyChanging();
                    string_1 = value;
                    SendPropertyChanged("OrderNumber");
                }
            }
        }
        
        public string MemloginID
        {
            get { return string_0; }
            set
            {
                if (string_0 != value)
                {
                    SendPropertyChanging();
                    string_0 = value;
                    SendPropertyChanged("MemloginID");
                }
            }
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

        public static List<KCE_CTC_OrderInfo> BackCTC_OrderInfo(DataTable table)
        {
            List<KCE_CTC_OrderInfo> KCE_CTC_OrderInfo = new List<KCE_CTC_OrderInfo>();
            foreach (DataRow row in table.Rows)
            {
                KCE_CTC_OrderInfo kco = new KCE_CTC_OrderInfo();
                kco.MemloginID = Convert.ToString(row["MemloginID"]);
                kco.OrderNumber = Convert.ToString(row["OrderNumber"]);
                kco.OderStatus = Convert.ToString(row["OderStatus"]);
                kco.PayTime = Convert.ToString(row["PayTime"]);
                kco.Score_pv_b = Convert.ToDecimal(row["Score_pv_b"]);
                kco.ServiceAgent = Convert.ToString(row["ServiceAgent"]);
                kco.ShipmentStatus = Convert.ToString(row["ShipmentStatus"]);
                kco.ShouldPayPrice = Convert.ToDecimal(row["ShouldPayPrice"]);
                kco.CreateTime = Convert.ToString(row["CreateTime"]);
                kco.ConfirmTime = Convert.ToString(row["ConfirmTime"]);
                kco.Name = Convert.ToString(row["Name"]);
                if (Convert.ToString(row["Photo"]) != "")
                {
                    kco.Photo = ShopSettings.siteDomain + Convert.ToString(row["Photo"]);
                }
                else 
                {
                    kco.Photo = "";
                }
                KCE_CTC_OrderInfo.Add(kco);
            }
            return KCE_CTC_OrderInfo;
        }
    }
}
