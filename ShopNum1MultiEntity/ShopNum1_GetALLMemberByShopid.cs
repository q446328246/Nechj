using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Data;

namespace ShopNum1MultiEntity
{
	public class ShopNum1_GetALLMemberByShopid : INotifyPropertyChanging, INotifyPropertyChanged
	{
        private static readonly PropertyChangingEventArgs propertyChangingEventArgs_0 =
          new PropertyChangingEventArgs(string.Empty);

        private string guid;
        public string Guid
        {
            get { return guid; }
            set { guid = value; }
        }
        private string memloginid;
        public string Memloginid
        {
            get { return memloginid; }
            set { memloginid = value; }
        }
        private string email;
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        private string realname;
        public string Realname
        {
            get { return realname; }
            set { realname = value; }
        }
        private string addressvalue;
        public string Addressvalue
        {
            get { return addressvalue; }
            set { addressvalue = value; }
        }
        private string mobile;
        public string Mobile
        {
            get { return mobile; }
            set { mobile = value; }
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

            public static ShopNum1_GetALLMemberByShopid GetALLMemberByShopid(DataRow row)
            {
                ShopNum1_GetALLMemberByShopid GetALLMemberByShopid = new ShopNum1_GetALLMemberByShopid();
                GetALLMemberByShopid.guid = row["guid"].ToString();
                GetALLMemberByShopid.memloginid = row["memloginid"].ToString();
                GetALLMemberByShopid.email = row["email"].ToString();
                GetALLMemberByShopid.realname = row["realname"].ToString();
                GetALLMemberByShopid.addressvalue = row["addressvalue"].ToString();
                GetALLMemberByShopid.mobile = row["mobile"].ToString();
                return GetALLMemberByShopid;
            }
	}
}
