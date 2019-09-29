using System.ComponentModel;
using System.Data.Linq.Mapping;

namespace ShopNum1.TbLinq
{
    [Table(Name = "dbo.ShopNum1_TbSystem")]
    public class ShopNum1_TbSystem : INotifyPropertyChanging, INotifyPropertyChanged
    {
        private static readonly PropertyChangingEventArgs emptyChangingEventArgs =
            new PropertyChangingEventArgs(string.Empty);

        private int _Id;
        private string _Memlogid;

        private bool? _hasTbOrder;
        private bool? _hasTbRate;
        private bool? _isOpen;
        private bool? _siteCount;
        private bool? _siteDesc;
        private bool? _siteImg;
        private bool? _siteItemName;
        private bool? _siteItemPrice;
        private bool? _siteSellCat;
        private bool? _tbCount;
        private bool? _tbDesc;
        private bool? _tbImg;
        private bool? _tbItemName;
        private bool? _tbItemPrice;
        private bool? _tbSellCat;
        private string _tbShopName;

        [Column(Storage = "_hasTbOrder", DbType = "Bit")]
        public bool? hasTbOrder
        {
            get { return _hasTbOrder; }
            set
            {
                if (_hasTbOrder != value)
                {
                    SendPropertyChanging();
                    _hasTbOrder = value;
                    SendPropertyChanged("hasTbOrder");
                }
            }
        }

        [Column(Storage = "_hasTbRate", DbType = "Bit")]
        public bool? hasTbRate
        {
            get { return _hasTbRate; }
            set
            {
                if (_hasTbRate != value)
                {
                    SendPropertyChanging();
                    _hasTbRate = value;
                    SendPropertyChanged("hasTbRate");
                }
            }
        }

        [Column(Storage = "_Id", AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true,
            IsDbGenerated = true)]
        public int Id
        {
            get { return _Id; }
            set
            {
                if (_Id != value)
                {
                    SendPropertyChanging();
                    _Id = value;
                    SendPropertyChanged("Id");
                }
            }
        }

        [Column(Storage = "_isOpen", DbType = "Bit")]
        public bool? isOpen
        {
            get { return _isOpen; }
            set
            {
                if (_isOpen != value)
                {
                    SendPropertyChanging();
                    _isOpen = value;
                    SendPropertyChanged("isOpen");
                }
            }
        }

        [Column(Storage = "_Memlogid", DbType = "VarChar(100) NOT NULL", CanBeNull = false)]
        public string Memlogid
        {
            get { return _Memlogid; }
            set
            {
                if (_Memlogid != value)
                {
                    SendPropertyChanging();
                    _Memlogid = value;
                    SendPropertyChanged("Memlogid");
                }
            }
        }

        [Column(Storage = "_siteCount", DbType = "Bit")]
        public bool? siteCount
        {
            get { return _siteCount; }
            set
            {
                if (_siteCount != value)
                {
                    SendPropertyChanging();
                    _siteCount = value;
                    SendPropertyChanged("siteCount");
                }
            }
        }

        [Column(Storage = "_siteDesc", DbType = "Bit")]
        public bool? siteDesc
        {
            get { return _siteDesc; }
            set
            {
                if (_siteDesc != value)
                {
                    SendPropertyChanging();
                    _siteDesc = value;
                    SendPropertyChanged("siteDesc");
                }
            }
        }

        [Column(Storage = "_siteImg", DbType = "Bit")]
        public bool? siteImg
        {
            get { return _siteImg; }
            set
            {
                if (_siteImg != value)
                {
                    SendPropertyChanging();
                    _siteImg = value;
                    SendPropertyChanged("siteImg");
                }
            }
        }

        [Column(Storage = "_siteItemName", DbType = "Bit")]
        public bool? siteItemName
        {
            get { return _siteItemName; }
            set
            {
                if (_siteItemName != value)
                {
                    SendPropertyChanging();
                    _siteItemName = value;
                    SendPropertyChanged("siteItemName");
                }
            }
        }

        [Column(Storage = "_siteItemPrice", DbType = "Bit")]
        public bool? siteItemPrice
        {
            get { return _siteItemPrice; }
            set
            {
                if (_siteItemPrice != value)
                {
                    SendPropertyChanging();
                    _siteItemPrice = value;
                    SendPropertyChanged("siteItemPrice");
                }
            }
        }

        [Column(Storage = "_siteSellCat", DbType = "Bit")]
        public bool? siteSellCat
        {
            get { return _siteSellCat; }
            set
            {
                if (_siteSellCat != value)
                {
                    SendPropertyChanging();
                    _siteSellCat = value;
                    SendPropertyChanged("siteSellCat");
                }
            }
        }

        [Column(Storage = "_tbCount", DbType = "Bit")]
        public bool? tbCount
        {
            get { return _tbCount; }
            set
            {
                if (_tbCount != value)
                {
                    SendPropertyChanging();
                    _tbCount = value;
                    SendPropertyChanged("tbCount");
                }
            }
        }

        [Column(Storage = "_tbDesc", DbType = "Bit")]
        public bool? tbDesc
        {
            get { return _tbDesc; }
            set
            {
                if (_tbDesc != value)
                {
                    SendPropertyChanging();
                    _tbDesc = value;
                    SendPropertyChanged("tbDesc");
                }
            }
        }

        [Column(Storage = "_tbImg", DbType = "Bit")]
        public bool? tbImg
        {
            get { return _tbImg; }
            set
            {
                if (_tbImg != value)
                {
                    SendPropertyChanging();
                    _tbImg = value;
                    SendPropertyChanged("tbImg");
                }
            }
        }

        [Column(Storage = "_tbItemName", DbType = "Bit")]
        public bool? tbItemName
        {
            get { return _tbItemName; }
            set
            {
                if (_tbItemName != value)
                {
                    SendPropertyChanging();
                    _tbItemName = value;
                    SendPropertyChanged("tbItemName");
                }
            }
        }

        [Column(Storage = "_tbItemPrice", DbType = "Bit")]
        public bool? tbItemPrice
        {
            get { return _tbItemPrice; }
            set
            {
                if (_tbItemPrice != value)
                {
                    SendPropertyChanging();
                    _tbItemPrice = value;
                    SendPropertyChanged("tbItemPrice");
                }
            }
        }

        [Column(Storage = "_tbSellCat", DbType = "Bit")]
        public bool? tbSellCat
        {
            get { return _tbSellCat; }
            set
            {
                if (_tbSellCat != value)
                {
                    SendPropertyChanging();
                    _tbSellCat = value;
                    SendPropertyChanged("tbSellCat");
                }
            }
        }

        [Column(Storage = "_tbShopName", DbType = "NVarChar(100) NOT NULL", CanBeNull = false)]
        public string tbShopName
        {
            get { return _tbShopName; }
            set
            {
                if (_tbShopName != value)
                {
                    SendPropertyChanging();
                    _tbShopName = value;
                    SendPropertyChanged("tbShopName");
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
                PropertyChanging(this, emptyChangingEventArgs);
            }
        }
    }
}