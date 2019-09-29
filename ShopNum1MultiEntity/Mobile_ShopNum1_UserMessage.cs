using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Data;


namespace ShopNum1MultiEntity
{
    public class Mobile_ShopNum1_UserMessage : INotifyPropertyChanging, INotifyPropertyChanged
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
        public virtual string Guid { get; set; }
        public virtual string ReceiveID { get; set; }
        public virtual string IsRead { get; set; }
        public virtual string SendTime { get; set; }
        public virtual string MessageInfoGuid { get; set; }
        public virtual string IsDeleted { get; set; }
        public virtual string Content { get; set; }
        public virtual string Title { get; set; }

        public static List<Mobile_ShopNum1_UserMessage> FromDataRow_ShopNum1_UserMessage(DataTable table)
        {
            List<Mobile_ShopNum1_UserMessage> Message = new List<Mobile_ShopNum1_UserMessage>();
            foreach (DataRow row in table.Rows)
            {
                Mobile_ShopNum1_UserMessage AllMessage = new Mobile_ShopNum1_UserMessage();
                AllMessage.Guid = Convert.ToString(row["Guid"]);
                AllMessage.ReceiveID = Convert.ToString(row["ReceiveID"]);
                AllMessage.IsRead = Convert.ToString(row["IsRead"]);
                AllMessage.SendTime = Convert.ToString(row["SendTime"]);
                AllMessage.MessageInfoGuid = Convert.ToString(row["MessageInfoGuid"]);
                AllMessage.IsDeleted = Convert.ToString(row["IsDeleted"]);
                AllMessage.Content = Convert.ToString(row["Content"]);
                AllMessage.Title = Convert.ToString(row["Title"]);



                Message.Add(AllMessage);
            }


            return Message;

        }


    }
}
