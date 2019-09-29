using System.ComponentModel;

////using System.Data.Linq.Mapping;

namespace ShopNum1MultiEntity
{
    // //[Table(Name = "dbo.ShopNum1_Weixin_ShopWeiXinConfig")]
    public class ShopNum1_Weixin_ShopWeiXinConfig : INotifyPropertyChanging, INotifyPropertyChanged
    {
        private static readonly PropertyChangingEventArgs propertyChangingEventArgs_0 =
            new PropertyChangingEventArgs(string.Empty);

        private bool? bool_0;
        private bool? bool_1;
        private int int_0;

        private string string_0;
        private string string_1;
        private string string_2;
        private string string_3;
        private string string_4;
        private string string_5;
        private string string_6;
        private string string_7;

        ////[Column(Storage = "_AppId", DbType = "VarChar(50)")]
        public string AppId
        {
            get { return string_4; }
            set
            {
                if (string_4 != value)
                {
                    SendPropertyChanging();
                    string_4 = value;
                    SendPropertyChanged("AppId");
                }
            }
        }

        // //[Column(Storage = "_AppSecret", DbType = "VarChar(50)")]
        public string AppSecret
        {
            get { return string_5; }
            set
            {
                if (string_5 != value)
                {
                    SendPropertyChanging();
                    string_5 = value;
                    SendPropertyChanged("AppSecret");
                }
            }
        }

        // //[Column(Storage = "_AttenRepKeys", DbType = "NVarChar(200)")]
        public string AttenRepKeys
        {
            get { return string_6; }
            set
            {
                if (string_6 != value)
                {
                    SendPropertyChanging();
                    string_6 = value;
                    SendPropertyChanged("AttenRepKeys");
                }
            }
        }

        ////[Column(Storage = "_ID", AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true,
        //    //IsDbGenerated = true)]
        public int ID
        {
            get { return int_0; }
            set
            {
                if (int_0 != value)
                {
                    SendPropertyChanging();
                    int_0 = value;
                    SendPropertyChanged("ID");
                }
            }
        }

        // //[Column(Storage = "_IsOpenAtten", DbType = "Bit")]
        public bool? IsOpenAtten
        {
            get { return bool_0; }
            set
            {
                if (bool_0 != value)
                {
                    SendPropertyChanging();
                    bool_0 = value;
                    SendPropertyChanged("IsOpenAtten");
                }
            }
        }

        // //[Column(Storage = "_IsOpenNotFindKey", DbType = "Bit")]
        public bool? IsOpenNotFindKey
        {
            get { return bool_1; }
            set
            {
                if (bool_1 != value)
                {
                    SendPropertyChanging();
                    bool_1 = value;
                    SendPropertyChanged("IsOpenNotFindKey");
                }
            }
        }

        // //[Column(Storage = "_NotFindKeys", DbType = "NVarChar(200)")]
        public string NotFindKeys
        {
            get { return string_7; }
            set
            {
                if (string_7 != value)
                {
                    SendPropertyChanging();
                    string_7 = value;
                    SendPropertyChanged("NotFindKeys");
                }
            }
        }

        //  //[Column(Storage = "_ShopMemLoginId", DbType = "NVarChar(50)")]
        public string ShopMemLoginId
        {
            get { return string_0; }
            set
            {
                if (string_0 != value)
                {
                    SendPropertyChanging();
                    string_0 = value;
                    SendPropertyChanged("ShopMemLoginId");
                }
            }
        }

        // //[Column(Storage = "_ShopWeiXinId", DbType = "NVarChar(50)")]
        public string ShopWeiXinId
        {
            get { return string_1; }
            set
            {
                if (string_1 != value)
                {
                    SendPropertyChanging();
                    string_1 = value;
                    SendPropertyChanged("ShopWeiXinId");
                }
            }
        }

        // //[Column(Storage = "_Token", DbType = "VarChar(50)")]
        public string Token
        {
            get { return string_3; }
            set
            {
                if (string_3 != value)
                {
                    SendPropertyChanging();
                    string_3 = value;
                    SendPropertyChanged("Token");
                }
            }
        }

        // //[Column(Storage = "_TokenURL", DbType = "VarChar(200)")]
        public string TokenURL
        {
            get { return string_2; }
            set
            {
                if (string_2 != value)
                {
                    SendPropertyChanging();
                    string_2 = value;
                    SendPropertyChanged("TokenURL");
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