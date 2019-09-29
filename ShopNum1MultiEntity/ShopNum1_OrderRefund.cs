using System;
using System.ComponentModel;

namespace ShopNum1MultiEntity
{
    public class ShopNum1_OrderRefund : INotifyPropertyChanging, INotifyPropertyChanged
    {
        private static readonly PropertyChangingEventArgs propertyChangingEventArgs_0 =
            new PropertyChangingEventArgs(string.Empty);

        private string GZOrdernumber;
        private string GZMemloginID;
        private decimal GZ_Score_hv;
        private decimal GZ_Score_pv_a;
        private decimal GZ_Score_pv_b;
        private decimal GZ_Score_pv_cv;
        private decimal GZ_Score_dv;
        private decimal GZ_PaymentPrice;
        private decimal GZ_reduce_score_hv;
        private decimal GZ_reduce_score_pv_a;
        private decimal GZ_reduce_score_pv_b;
        private decimal GZ_reduce_score_pv_cv;
        private decimal GZ_reduce_score_dv;
        private decimal GZ_reduce_PaymentPrice;
        private decimal GZ_reduce_score_tj_hv;
        private string GZ_reduce_score_tjid;


        public string TJMemloginID
        {
            get { return GZ_reduce_score_tjid; }
            set
            {
                if (GZ_reduce_score_tjid != value)
                {
                    SendPropertyChanging();
                    GZ_reduce_score_tjid = value;
                    SendPropertyChanged("reduce_score_tjid");
                }
            }
        }


        public decimal reduce_TJhv
        {
            get { return GZ_reduce_score_tj_hv; }
            set
            {
                if (GZ_reduce_score_tj_hv != value)
                {
                    SendPropertyChanging();
                    GZ_reduce_score_tj_hv = value;
                    SendPropertyChanged("reduce_score_tj_hv");
                }
            }
        }

        public decimal reduce_PaymentPrice
        {
            get { return GZ_reduce_PaymentPrice; }
            set
            {
                if (GZ_reduce_PaymentPrice != value)
                {
                    SendPropertyChanging();
                    GZ_reduce_PaymentPrice = value;
                    SendPropertyChanged("reduce_PaymentPrice");
                }
            }
        }



        public decimal reduce_score_dv
        {
            get { return GZ_reduce_score_dv; }
            set
            {
                if (GZ_reduce_score_dv != value)
                {
                    SendPropertyChanging();
                    GZ_reduce_score_dv = value;
                    SendPropertyChanged("reduce_score_dv");
                }
            }
        }




        public decimal reduce_score_pv_cv
        {
            get { return GZ_reduce_score_pv_cv; }
            set
            {
                if (GZ_reduce_score_pv_cv != value)
                {
                    SendPropertyChanging();
                    GZ_reduce_score_pv_cv = value;
                    SendPropertyChanged("reduce_score_pv_cv");
                }
            }
        }



        public decimal reduce_score_pv_b
        {
            get { return GZ_reduce_score_pv_b; }
            set
            {
                if (GZ_reduce_score_pv_b != value)
                {
                    SendPropertyChanging();
                    GZ_reduce_score_pv_b = value;
                    SendPropertyChanged("reduce_score_pv_b");
                }
            }
        }


        public decimal reduce_score_pv_a
        {
            get { return GZ_reduce_score_pv_a; }
            set
            {
                if (GZ_reduce_score_pv_a != value)
                {
                    SendPropertyChanging();
                    GZ_reduce_score_pv_a = value;
                    SendPropertyChanged("reduce_score_pv_a");
                }
            }
        }



        public decimal reduce_score_hv
        {
            get { return GZ_reduce_score_hv; }
            set
            {
                if (GZ_reduce_score_hv != value)
                {
                    SendPropertyChanging();
                    GZ_reduce_score_hv = value;
                    SendPropertyChanged("reduce_score_hv");
                }
            }
        }



        public decimal PaymentPrice
        {
            get { return GZ_PaymentPrice; }
            set
            {
                if (GZ_PaymentPrice != value)
                {
                    SendPropertyChanging();
                    GZ_PaymentPrice = value;
                    SendPropertyChanged("PaymentPrice");
                }
            }
        }


        public decimal Score_dv
        {
            get { return GZ_Score_dv; }
            set
            {
                if (GZ_Score_dv != value)
                {
                    SendPropertyChanging();
                    GZ_Score_dv = value;
                    SendPropertyChanged("Score_dv");
                }
            }
        }


        public decimal Score_pv_cv
        {
            get { return GZ_Score_pv_cv; }
            set
            {
                if (GZ_Score_pv_cv != value)
                {
                    SendPropertyChanging();
                    GZ_Score_pv_cv = value;
                    SendPropertyChanged("Score_pv_cv");
                }
            }
        }



        public decimal Score_pv_b
        {
            get { return GZ_Score_pv_b; }
            set
            {
                if (GZ_Score_pv_b != value)
                {
                    SendPropertyChanging();
                    GZ_Score_pv_b = value;
                    SendPropertyChanged("Score_pv_b");
                }
            }
        }




        public decimal Score_pv_a
        {
            get { return GZ_Score_pv_a; }
            set
            {
                if (GZ_Score_pv_a != value)
                {
                    SendPropertyChanging();
                    GZ_Score_pv_a = value;
                    SendPropertyChanged("Score_pv_a");
                }
            }
        }

        public decimal Score_hv
        {
            get { return GZ_Score_hv; }
            set
            {
                if (GZ_Score_hv != value)
                {
                    SendPropertyChanging();
                    GZ_Score_hv = value;
                    SendPropertyChanged("Score_hv");
                }
            }
        }


        public string MemloginID
        {
            get { return GZMemloginID; }
            set
            {
                if (GZMemloginID != value)
                {
                    SendPropertyChanging();
                    GZMemloginID = value;
                    SendPropertyChanged("MemloginID");
                }
            }
        }

        public string Ordernumber
        {
            get { return GZOrdernumber; }
            set
            {
                if (GZOrdernumber != value)
                {
                    SendPropertyChanging();
                    GZOrdernumber = value;
                    SendPropertyChanged("Ordernumber");
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
    }
}
