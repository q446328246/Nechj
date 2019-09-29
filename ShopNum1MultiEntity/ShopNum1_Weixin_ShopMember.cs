using System.ComponentModel;

////using System.Data.Linq.Mapping;

namespace ShopNum1MultiEntity
{
    // //[Table(Name = "dbo.ShopNum1_Weixin_ShopMember")]
    public class ShopNum1_Weixin_ShopMember : INotifyPropertyChanging, INotifyPropertyChanged
    {
        private static readonly PropertyChangingEventArgs propertyChangingEventArgs_0 =
            new PropertyChangingEventArgs(string.Empty);

        private byte? byte_0;
        private int int_0;

        private string string_0;
        private string string_1;

        // [Column(Name = "[Group]", Storage = "_Group", DbType = "TinyInt")]
        public byte? Group
        {
            get { return byte_0; }
            set
            {
                if (byte_0 != value)
                {
                    SendPropertyChanging();
                    byte_0 = value;
                    SendPropertyChanged("Group");
                }
            }
        }

        // //[Column(Storage = "_ID", AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true,
        //     //IsDbGenerated = true)]
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

        // //[Column(Storage = "_MemLoginId", DbType = "NVarChar(50)")]
        public string MemLoginId
        {
            get { return string_1; }
            set
            {
                if (string_1 != value)
                {
                    SendPropertyChanging();
                    string_1 = value;
                    SendPropertyChanged("MemLoginId");
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