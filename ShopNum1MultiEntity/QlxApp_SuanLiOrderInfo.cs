using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Data;
using ShopNum1.Common;
namespace ShopNum1MultiEntity
{
    public class QlxApp_SuanLiOrderInfo : INotifyPropertyChanging, INotifyPropertyChanged
    {
        private static readonly PropertyChangingEventArgs propertyChangingEventArgs_0 =
            new PropertyChangingEventArgs(string.Empty);

        private string PayTime_;
        private string ProductImg_;
        private string ProductName_;
        private string ordernumber_;
        private int Day_;
        private int BuyNumber_;
        private decimal SuanLiGet_;
        private decimal NEC_;
        private int SuanLiDaySum_;
        private string suanlizhi_;


        public string suanlizhi
        {
            get { return suanlizhi_; }
            set
            {
                if (suanlizhi_ != value)
                {
                    SendPropertyChanging();
                    suanlizhi_ = value;
                    SendPropertyChanged("suanlizhi");
                }
            }
        }

        public int SuanLiDaySum
        {
            get { return SuanLiDaySum_; }
            set
            {
                if (SuanLiDaySum_ != value)
                {
                    SendPropertyChanging();
                    SuanLiDaySum_ = value;
                    SendPropertyChanged("SuanLiDaySum");
                }
            }
        }


        public decimal NEC
        {
            get { return NEC_; }
            set
            {
                if (NEC_ != value)
                {
                    SendPropertyChanging();
                    NEC_ = value;
                    SendPropertyChanged("NEC");
                }
            }
        }

        public string OrderNumber
        {
            get { return ordernumber_; }
            set
            {
                if (ordernumber_ != value)
                {
                    SendPropertyChanging();
                    ordernumber_ = value;
                    SendPropertyChanged("OrderNumber");
                }
            }
        }

        public decimal SuanLiGet
        {
            get { return SuanLiGet_; }
            set
            {
                if (SuanLiGet_ != value)
                {
                    SendPropertyChanging();
                    SuanLiGet_ = value;
                    SendPropertyChanged("SuanLiGet");
                }
            }
        }


        public int BuyNumber
        {
            get { return BuyNumber_; }
            set
            {
                if (BuyNumber_ != value)
                {
                    SendPropertyChanging();
                    BuyNumber_ = value;
                    SendPropertyChanged("BuyNumber");
                }
            }
        }



        public int Day
        {
            get { return Day_; }
            set
            {
                if (Day_ != value)
                {
                    SendPropertyChanging();
                    Day_ = value;
                    SendPropertyChanged("Day");
                }
            }
        }


        public string ProductName
        {
            get { return ProductName_; }
            set
            {
                if (ProductName_ != value)
                {
                    SendPropertyChanging();
                    ProductName_ = value;
                    SendPropertyChanged("ProductName");
                }
            }
        }


        public string ProductImg
        {
            get { return ProductImg_; }
            set
            {
                if (ProductImg_ != value)
                {
                    SendPropertyChanging();
                    ProductImg_ = value;
                    SendPropertyChanged("ProductImg");
                }
            }
        }


        public string PayTime
        {
            get { return PayTime_; }
            set
            {
                if (PayTime_ != value)
                {
                    SendPropertyChanging();
                    PayTime_ = value;
                    SendPropertyChanged("PayTime");
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


        public static List<QlxApp_SuanLiOrderInfo> SlectZuLinOrder(DataTable table)
        {
            List<QlxApp_SuanLiOrderInfo> KCE_CTC_OrderInfo = new List<QlxApp_SuanLiOrderInfo>();
            foreach (DataRow row in table.Rows)
            {
                QlxApp_SuanLiOrderInfo kco = new QlxApp_SuanLiOrderInfo();
                kco.SuanLiGet = Convert.ToDecimal(row["SuanLiGet"]);
                kco.BuyNumber = Convert.ToInt32(row["BuyNumber"]);
                kco.Day = Convert.ToInt32(row["Day"]);
                kco.PayTime = Convert.ToString(row["PayTime"]);
                kco.ProductName = Convert.ToString(row["ProductName"]);
                kco.ProductImg = Convert.ToString(row["ProductImg"]);
                kco.OrderNumber = Convert.ToString(row["OrderNumber"]);
                kco.SuanLiDaySum = Convert.ToInt32(row["SuanLiDaySum"]);
                kco.NEC = Convert.ToDecimal(row["NEC"]);
                //kco.suanlizhi=kco.ProductName.Substring(1,kco.ProductName.IndexOf("G"));
                kco.suanlizhi = (kco.NEC / 1000).ToString();
                if (Convert.ToString(row["ProductImg"]) != "")
                {
                    kco.ProductImg = "http://" + ShopSettings.siteDomain + Convert.ToString(row["ProductImg"]);
                }
                
                KCE_CTC_OrderInfo.Add(kco);
            }
            return KCE_CTC_OrderInfo;
        }
    }
}
