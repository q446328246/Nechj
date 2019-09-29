using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Data;
using ShopNum1.Common;
namespace ShopNum1MultiEntity
{
    public class NEC_LiCaiJiJinOrderInfo : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static readonly PropertyChangingEventArgs propertyChangingEventArgs_0 =
           new PropertyChangingEventArgs(string.Empty);

        private string Profit_;
        private string CalculationTime_;
        private string CalculationEndTime_;
        private string ProductName_;
        private string ordernumber_;
        private int Day_;
        private int DaySum_;
        private int OrderStatus_;
        private decimal ShouldPayPrice_;



        public int DaySum
        {
            get { return DaySum_; }
            set
            {
                if (DaySum_ != value)
                {
                    SendPropertyChanging();
                    DaySum_ = value;
                    SendPropertyChanged("DaySum");
                }
            }
        }

        public string CalculationEndTime
        {
            get { return CalculationEndTime_; }
            set
            {
                if (CalculationEndTime_ != value)
                {
                    SendPropertyChanging();
                    CalculationEndTime_ = value;
                    SendPropertyChanged("CalculationEndTime");
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

        public decimal ShouldPayPrice
        {
            get { return ShouldPayPrice_; }
            set
            {
                if (ShouldPayPrice_ != value)
                {
                    SendPropertyChanging();
                    ShouldPayPrice_ = value;
                    SendPropertyChanged("ShouldPayPrice");
                }
            }
        }


        public int OrderStatus
        {
            get { return OrderStatus_; }
            set
            {
                if (OrderStatus_ != value)
                {
                    SendPropertyChanging();
                    OrderStatus_ = value;
                    SendPropertyChanged("OrderStatus");
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


        public string CalculationTime
        {
            get { return CalculationTime_; }
            set
            {
                if (CalculationTime_ != value)
                {
                    SendPropertyChanging();
                    CalculationTime_ = value;
                    SendPropertyChanged("CalculationTime");
                }
            }
        }


        public string Profit
        {
            get { return Profit_; }
            set
            {
                if (Profit_ != value)
                {
                    SendPropertyChanging();
                    Profit_ = value;
                    SendPropertyChanged("Profit");
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

        public static List<NEC_LiCaiJiJinOrderInfo> SlectLiCaiOrderInfo(DataTable table)
        {
            List<NEC_LiCaiJiJinOrderInfo> KCE_CTC_OrderInfo = new List<NEC_LiCaiJiJinOrderInfo>();
            foreach (DataRow row in table.Rows)
            {
                NEC_LiCaiJiJinOrderInfo kco = new NEC_LiCaiJiJinOrderInfo();
                decimal baifenbi = Convert.ToDecimal(row["Profit"]);
                kco.Profit = baifenbi.ToString("P");

                kco.CalculationTime = Convert.ToString(row["CalculationTime"]);
                kco.Day = Convert.ToInt32(row["Day"]);
                kco.DaySum = Convert.ToInt32(row["DaySum"]);
                kco.CalculationEndTime = Convert.ToString(row["CalculationEndTime"]);
                kco.ProductName = Convert.ToString(row["ProductName"]);
                kco.ShouldPayPrice = Convert.ToDecimal(row["ShouldPayPrice"]);
                kco.OrderNumber = Convert.ToString(row["OrderNumber"]);
                kco.OrderStatus = Convert.ToInt32(row["OderStatus"]);


                KCE_CTC_OrderInfo.Add(kco);
            }
            return KCE_CTC_OrderInfo;
        }

    }
}
