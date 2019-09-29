using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Data;
using ShopNum1.Common;
namespace ShopNum1MultiEntity
{
    public class TEH_TxTable : INotifyPropertyChanging, INotifyPropertyChanged
    {
        private static readonly PropertyChangingEventArgs propertyChangingEventArgs_0 =
            new PropertyChangingEventArgs(string.Empty);

        private string OrderID_;
        private string TxTime_;
        private string Status_;
        private string ETH_;


        public string Status
        {
            get { return Status_; }
            set
            {
                if (Status_ != value)
                {
                    SendPropertyChanging();
                    Status_ = value;
                    SendPropertyChanged("Status");
                }
            }
        }
        public string ETH
        {
            get { return ETH_; }
            set
            {
                if (ETH_ != value)
                {
                    SendPropertyChanging();
                    ETH_ = value;
                    SendPropertyChanged("ETH");
                }
            }
        }

        public string OrderID
        {
            get { return OrderID_; }
            set
            {
                if (OrderID_ != value)
                {
                    SendPropertyChanging();
                    OrderID_ = value;
                    SendPropertyChanged("OrderID");
                }
            }
        }


        public string TxTime
        {
            get { return TxTime_; }
            set
            {
                if (TxTime_ != value)
                {
                    SendPropertyChanging();
                    TxTime_ = value;
                    SendPropertyChanged("TxTime");
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

        public static List<TEH_TxTable> SelectTxTable(DataTable table)
        {
            List<TEH_TxTable> KCE_CTC_OrderInfo = new List<TEH_TxTable>();
            foreach (DataRow row in table.Rows)
            {
                TEH_TxTable kco = new TEH_TxTable();
                kco.OrderID = Convert.ToString(row["OrderID"]);
                kco.Status = Convert.ToString(row["Status"]);
                kco.TxTime = Convert.ToString(row["TxTime"]);
                kco.ETH = Convert.ToString(row["ETH"]);
                

                KCE_CTC_OrderInfo.Add(kco);
            }
            return KCE_CTC_OrderInfo;
        }


    }

}
