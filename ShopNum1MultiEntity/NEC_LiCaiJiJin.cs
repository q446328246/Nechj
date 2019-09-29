using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Data;
using ShopNum1.Common;
namespace ShopNum1MultiEntity
{
    public class NEC_LiCaiJiJin : INotifyPropertyChanging, INotifyPropertyChanged
    {
        private static readonly PropertyChangingEventArgs propertyChangingEventArgs_0 =
            new PropertyChangingEventArgs(string.Empty);

        private int ProductId_;
        private string ProductName_;
        private string Profit_;
        private int BuyLimited_;
        private int WorkDay_;
        private decimal Total_;
        private decimal SurplusTotal_;
        private string IssueTime_;
        private int BuyEndTime_;
        private string CalculationTime_;
        private string CalculationEndTime_;
        private int Status_;
        private string BFB_;
        public string BFB
        {
            get { return BFB_; }
            set
            {
                if (BFB_ != value)
                {
                    SendPropertyChanging();
                    BFB_ = value;
                    SendPropertyChanged("BFB");
                }
            }
        }
        public int Status
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
        public int BuyEndTime
        {
            get { return BuyEndTime_; }
            set
            {
                if (BuyEndTime_ != value)
                {
                    SendPropertyChanging();
                    BuyEndTime_ = value;
                    SendPropertyChanged("BuyEndTime");
                }
            }
        }
        public string IssueTime
        {
            get { return IssueTime_; }
            set
            {
                if (IssueTime_ != value)
                {
                    SendPropertyChanging();
                    IssueTime_ = value;
                    SendPropertyChanged("IssueTime");
                }
            }
        }



        public int ProductId
        {
            get { return ProductId_; }
            set
            {
                if (ProductId_ != value)
                {
                    SendPropertyChanging();
                    ProductId_ = value;
                    SendPropertyChanged("ProductId");
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



        public int BuyLimited
        {
            get { return BuyLimited_; }
            set
            {
                if (BuyLimited_ != value)
                {
                    SendPropertyChanging();
                    BuyLimited_ = value;
                    SendPropertyChanged("BuyLimited");
                }
            }
        }


        public int WorkDay
        {
            get { return WorkDay_; }
            set
            {
                if (WorkDay_ != value)
                {
                    SendPropertyChanging();
                    WorkDay_ = value;
                    SendPropertyChanged("WorkDay");
                }
            }
        }


        public decimal Total
        {
            get { return Total_; }
            set
            {
                if (Total_ != value)
                {
                    SendPropertyChanging();
                    Total_ = value;
                    SendPropertyChanged("Total");
                }
            }
        }


        public decimal SurplusTotal
        {
            get { return SurplusTotal_; }
            set
            {
                if (SurplusTotal_ != value)
                {
                    SendPropertyChanging();
                    SurplusTotal_ = value;
                    SendPropertyChanged("SurplusTotal");
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

        public static List<NEC_LiCaiJiJin> SlectLiCaiOrder(DataTable table)
        {
            List<NEC_LiCaiJiJin> NEC_LiCaiJiJinInfo = new List<NEC_LiCaiJiJin>();
            foreach (DataRow row in table.Rows)
            {
                NEC_LiCaiJiJin kco = new NEC_LiCaiJiJin();
                kco.ProductId = Convert.ToInt32(row["ProductId"]);
                kco.ProductName = Convert.ToString(row["ProductName"]);
                decimal baifenbi = Convert.ToDecimal(row["Profit"]);
                kco.Profit = baifenbi.ToString("P");
                kco.BuyLimited = Convert.ToInt32(row["BuyLimited"]);
                kco.WorkDay = Convert.ToInt32(row["WorkDay"]);
                kco.Total = Convert.ToDecimal(row["Total"]);
                kco.SurplusTotal = Convert.ToDecimal(row["SurplusTotal"]);
                kco.IssueTime = Convert.ToString(row["IssueTime"]);

                kco.BuyEndTime = ConvertDateTimeInt(Convert.ToDateTime(row["BuyEndTime"]));

               

                kco.CalculationTime = Convert.ToString(row["CalculationTime"]);
                kco.CalculationEndTime = Convert.ToString(row["CalculationEndTime"]);
                kco.Status = Convert.ToInt32(row["Status"]);
                decimal ChuShoubaifenbi = Convert.ToDecimal(row["BFB"]);
                kco.BFB = ChuShoubaifenbi.ToString("p2");
                NEC_LiCaiJiJinInfo.Add(kco);
            }
            return NEC_LiCaiJiJinInfo;
        }

        public static int ConvertDateTimeInt(System.DateTime time)
        {
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
            return (int)(time - startTime).TotalSeconds;
        }
    }
}
