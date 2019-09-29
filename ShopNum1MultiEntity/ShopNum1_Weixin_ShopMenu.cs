using System.ComponentModel;

////using System.Data.Linq.Mapping;

namespace ShopNum1MultiEntity
{
    ////[Table(Name = "dbo.ShopNum1_Weixin_ShopMenu")]
    public class ShopNum1_Weixin_ShopMenu : INotifyPropertyChanging, INotifyPropertyChanged
    {
        private static readonly PropertyChangingEventArgs propertyChangingEventArgs_0 =
            new PropertyChangingEventArgs(string.Empty);

        private int int_0;
        private int? int_1;
        private int? int_2;

        private string string_0;
        private string string_1;
        private string string_2;

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

        // //[Column(Storage = "_Name", DbType = "VarChar(16)")]
        public string Name
        {
            get { return string_1; }
            set
            {
                if (string_1 != value)
                {
                    SendPropertyChanging();
                    string_1 = value;
                    SendPropertyChanged("Name");
                }
            }
        }

        // //[Column(Storage = "_PId", DbType = "Int")]
        public int? PId
        {
            get { return int_1; }
            set
            {
                if (int_1 != value)
                {
                    SendPropertyChanging();
                    int_1 = value;
                    SendPropertyChanged("PId");
                }
            }
        }

        // //[Column(Storage = "_ShopMemLoginId", DbType = "NVarChar(50)")]
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

        // //[Column(Storage = "_Sort", DbType = "Int")]
        public int? Sort
        {
            get { return int_2; }
            set
            {
                if (int_2 != value)
                {
                    SendPropertyChanging();
                    int_2 = value;
                    SendPropertyChanged("Sort");
                }
            }
        }

        ////[Column(Storage = "_value", DbType = "VarChar(50)")]
        public string value
        {
            get { return string_2; }
            set
            {
                if (string_2 != value)
                {
                    SendPropertyChanging();
                    string_2 = value;
                    SendPropertyChanged("value");
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