using System.ComponentModel;

////using System.Data.Linq.Mapping;

namespace ShopNum1MultiEntity
{
    ////[Table(Name = "dbo.ShopNum1_Weixin_ReplyRuleContent")]
    public class ShopNum1_Weixin_ReplyRuleContent : INotifyPropertyChanging, INotifyPropertyChanged
    {
        private static readonly PropertyChangingEventArgs propertyChangingEventArgs_0 =
            new PropertyChangingEventArgs(string.Empty);

        private int int_0;
        private int? int_1;

        private string string_0;
        private string string_1;
        private string string_2;
        private string string_3;

        ////[Column(Storage = "_Description", DbType = "NVarChar(200)")]
        public string Description
        {
            get { return string_2; }
            set
            {
                if (string_2 != value)
                {
                    SendPropertyChanging();
                    string_2 = value;
                    SendPropertyChanged("Description");
                }
            }
        }

        // //[Column(Storage = "_ID", AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true,
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

        // //[Column(Storage = "_ImgSrc", DbType = "VarChar(200)")]
        public string ImgSrc
        {
            get { return string_3; }
            set
            {
                if (string_3 != value)
                {
                    SendPropertyChanging();
                    string_3 = value;
                    SendPropertyChanged("ImgSrc");
                }
            }
        }

        // //[Column(Storage = "_RepMsgContent", DbType = "NVarChar(300)")]
        public string RepMsgContent
        {
            get { return string_0; }
            set
            {
                if (string_0 != value)
                {
                    SendPropertyChanging();
                    string_0 = value;
                    SendPropertyChanged("RepMsgContent");
                }
            }
        }

        // //[Column(Storage = "_RuleId", DbType = "Int")]
        public int? RuleId
        {
            get { return int_1; }
            set
            {
                if (int_1 != value)
                {
                    SendPropertyChanging();
                    int_1 = value;
                    SendPropertyChanged("RuleId");
                }
            }
        }

        // //[Column(Storage = "_Title", DbType = "NVarChar(50)")]
        public string Title
        {
            get { return string_1; }
            set
            {
                if (string_1 != value)
                {
                    SendPropertyChanging();
                    string_1 = value;
                    SendPropertyChanged("Title");
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