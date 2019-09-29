using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Data;

namespace ShopNum1MultiEntity
{
    public class ShopNum1_M_UserMessage : INotifyPropertyChanging, INotifyPropertyChanged
    {
        private static readonly PropertyChangingEventArgs propertyChangingEventArgs_0 =
           new PropertyChangingEventArgs(string.Empty);


        public virtual object Guid { get; set; }

        public virtual int IsDeleted { get; set; }

        public virtual int IsRead { get; set; }

        public virtual object MessageInfoGuid { get; set; }

        public virtual string ReceiveID { get; set; }

        public virtual int ReceiveIsDeleted { get; set; }

        public virtual string ReplyContent { get; set; }

        public virtual string ReplyTime { get; set; }

        public virtual string SendID { get; set; }

        public virtual int SendIsDeleted { get; set; }

        public virtual string SendTime { get; set; }

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

        public static List<ShopNum1_M_UserMessage> FromDataRowGetUserMessage(DataTable table)
        {
            List<ShopNum1_M_UserMessage> UserMessage = new List<ShopNum1_M_UserMessage>();
            foreach (DataRow row in table.Rows)
            {
                ShopNum1_M_UserMessage GetUserMessage = new ShopNum1_M_UserMessage();
                GetUserMessage.Guid = Convert.ToString(row["Guid"]);
                GetUserMessage.IsDeleted = Convert.ToInt32(row["IsDeleted"]);
                GetUserMessage.IsRead = Convert.ToInt32(row["IsRead"]);

                GetUserMessage.MessageInfoGuid = Convert.ToString(row["MessageInfoGuid"]);

                GetUserMessage.ReceiveID = Convert.ToString(row["ReceiveID"]);
                GetUserMessage.ReceiveIsDeleted = Convert.ToInt32(row["ReceiveIsDeleted"]);
                GetUserMessage.ReplyContent = Convert.ToString(row["ReplyContent"]);
                GetUserMessage.ReplyTime = Convert.ToString(row["ReplyTime"]);
                GetUserMessage.SendID = Convert.ToString(row["SendID"]);
                GetUserMessage.SendIsDeleted = Convert.ToInt32(row["SendIsDeleted"]);
                GetUserMessage.SendTime = Convert.ToString(row["SendTime"]);

                UserMessage.Add(GetUserMessage);
            }
            return UserMessage;
        }
    }
}
