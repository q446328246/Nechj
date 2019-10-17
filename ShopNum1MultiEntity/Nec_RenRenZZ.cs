
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Data;
using ShopNum1.Common;
namespace ShopNum1MultiEntity
{
    public class Nec_RenRenZZT { 
        public string ID { get; set; }
        public string ChongZhiID { get; set; }
        public string NEC { get; set; }
        public string AddTime { get; set; }
        public string Status { get; set; }
        public string RenType { get; set; }
    }

    public class Nec_RenRenZZ : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static readonly PropertyChangingEventArgs propertyChangingEventArgs_0 =
           new PropertyChangingEventArgs(string.Empty);

        private string ID_;

        public string ID
        {
            get { return ID_; }
            set
            {
                if (ID_ != value)
                {
                    SendPropertyChanging();
                    ID_ = value;
                    SendPropertyChanged("ID");
                }
            }
        }



        private string NEC_;

        public string NEC
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

        private string ChongZhiID_;

        public string ChongZhiID
        {
            get { return ChongZhiID_; }
            set
            {
                if (ChongZhiID_ != value)
                {
                    SendPropertyChanging();
                    ChongZhiID_ = value;
                    SendPropertyChanged("ChongZhiID");
                }
            }
        }

        private string AddTime_;

        public string AddTime
        {
            get { return AddTime_; }
            set
            {
                if (AddTime_ != value)
                {
                    SendPropertyChanging();
                    AddTime_ = value;
                    SendPropertyChanged("AddTime");
                }
            }
        }


        private string Status_;

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
        private string RenType_;

      

        public string RenType
        {
            get { return RenType_; }
            set
            {
                if (RenType_ != value)
                {
                    SendPropertyChanging();
                    RenType_ = value;
                    SendPropertyChanged("RenType");
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
        public static List<Nec_RenRenZZ> FromDataRowNec_RenRenZZ(DataTable table)
        {
            List<Nec_RenRenZZ> KCE_CTC_OrderInfo = new List<Nec_RenRenZZ>();
            foreach (DataRow row in table.Rows)
            {
                Nec_RenRenZZ kco = new Nec_RenRenZZ();

                kco.ID = Convert.ToString(row["ID"]);
                kco.NEC = Convert.ToString(row["NEC"]);
                kco.ChongZhiID = Convert.ToString(row["ChongZhiID"]);
                kco.AddTime = Convert.ToString(row["AddTime"]);
                kco.Status = Convert.ToString(row["Status"]);
                kco.RenType = Convert.ToString(row["RenType"]);
                KCE_CTC_OrderInfo.Add(kco);
            }
            return KCE_CTC_OrderInfo;
        }
    }
}

