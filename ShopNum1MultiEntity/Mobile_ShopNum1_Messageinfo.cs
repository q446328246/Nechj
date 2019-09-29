using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Data;


namespace ShopNum1MultiEntity
{
    public class Mobile_ShopNum1_MessageInfo : INotifyPropertyChanging, INotifyPropertyChanged
    {
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
        public virtual string Title { get; set; }
        public virtual string Content { get; set; }
        public virtual string MemLoginID { get; set; }
        public virtual string SendTime { get; set; }


        public static List<Mobile_ShopNum1_MessageInfo> FromDataRow_ShopNum1_MessageInfo(DataTable table)
        {
            List<Mobile_ShopNum1_MessageInfo> MessageInfo = new List<Mobile_ShopNum1_MessageInfo>();
            foreach (DataRow row in table.Rows)
            {
                Mobile_ShopNum1_MessageInfo AllMessageInfo = new Mobile_ShopNum1_MessageInfo();

                AllMessageInfo.Title = Convert.ToString(row["Title"]);
                AllMessageInfo.Content = Convert.ToString(row["Content"]);
                AllMessageInfo.MemLoginID = Convert.ToString(row["MemLoginID"]);
                AllMessageInfo.SendTime = Convert.ToString(row["SendTime"]);



                MessageInfo.Add(AllMessageInfo);
            }


            return MessageInfo;

        }

    }
}
