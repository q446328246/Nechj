using System;
using System.ComponentModel;
using System.Data.Linq.Mapping;

namespace ShopNum1.TbLinq
{
    [Table(Name = "dbo.ShopNum1_TbSellCat")]
    public class ShopNum1_TbSellCat : INotifyPropertyChanging, INotifyPropertyChanged
    {
        private static readonly PropertyChangingEventArgs emptyChangingEventArgs =
            new PropertyChangingEventArgs(string.Empty);

        private int _ID;
        private string _MemloginId;

        private decimal _cid;
        private DateTime? _created;
        private bool? _isTaobao;
        private DateTime? _modified;
        private string _name;
        private decimal _parent_cid;
        private string _pic_url;
        private string _shopname;
        private decimal? _site_cid;
        private decimal? _site_parent_cid;
        private decimal? _sort_order;

        [Column(Storage = "_cid", DbType = "Decimal(22,0) NOT NULL")]
        public decimal cid
        {
            get { return _cid; }
            set
            {
                if (_cid != value)
                {
                    SendPropertyChanging();
                    _cid = value;
                    SendPropertyChanged("cid");
                }
            }
        }

        [Column(Storage = "_created", DbType = "DateTime")]
        public DateTime? created
        {
            get { return _created; }
            set
            {
                if (_created != value)
                {
                    SendPropertyChanging();
                    _created = value;
                    SendPropertyChanged("created");
                }
            }
        }

        [Column(Storage = "_ID", AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true,
            IsDbGenerated = true)]
        public int ID
        {
            get { return _ID; }
            set
            {
                if (_ID != value)
                {
                    SendPropertyChanging();
                    _ID = value;
                    SendPropertyChanged("ID");
                }
            }
        }

        [Column(Storage = "_isTaobao", DbType = "Bit")]
        public bool? isTaobao
        {
            get { return _isTaobao; }
            set
            {
                if (_isTaobao != value)
                {
                    SendPropertyChanging();
                    _isTaobao = value;
                    SendPropertyChanged("isTaobao");
                }
            }
        }

        [Column(Storage = "_MemloginId", DbType = "VarChar(50) NOT NULL", CanBeNull = false)]
        public string MemloginId
        {
            get { return _MemloginId; }
            set
            {
                if (_MemloginId != value)
                {
                    SendPropertyChanging();
                    _MemloginId = value;
                    SendPropertyChanged("MemloginId");
                }
            }
        }

        [Column(Storage = "_modified", DbType = "DateTime")]
        public DateTime? modified
        {
            get { return _modified; }
            set
            {
                if (_modified != value)
                {
                    SendPropertyChanging();
                    _modified = value;
                    SendPropertyChanged("modified");
                }
            }
        }

        [Column(Storage = "_name", DbType = "NVarChar(200)")]
        public string name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    SendPropertyChanging();
                    _name = value;
                    SendPropertyChanged("name");
                }
            }
        }

        [Column(Storage = "_parent_cid", DbType = "Decimal(18,0) NOT NULL")]
        public decimal parent_cid
        {
            get { return _parent_cid; }
            set
            {
                if (_parent_cid != value)
                {
                    SendPropertyChanging();
                    _parent_cid = value;
                    SendPropertyChanged("parent_cid");
                }
            }
        }

        [Column(Storage = "_pic_url", DbType = "NVarChar(200)")]
        public string pic_url
        {
            get { return _pic_url; }
            set
            {
                if (_pic_url != value)
                {
                    SendPropertyChanging();
                    _pic_url = value;
                    SendPropertyChanged("pic_url");
                }
            }
        }

        [Column(Storage = "_shopname", DbType = "NVarChar(200)")]
        public string shopname
        {
            get { return _shopname; }
            set
            {
                if (_shopname != value)
                {
                    SendPropertyChanging();
                    _shopname = value;
                    SendPropertyChanged("shopname");
                }
            }
        }

        [Column(Storage = "_site_cid", DbType = "Decimal(22,0)")]
        public decimal? site_cid
        {
            get { return _site_cid; }
            set
            {
                decimal? nullable = _site_cid;
                decimal? nullable2 = value;
                if ((nullable.GetValueOrDefault() != nullable2.GetValueOrDefault()) ||
                    (nullable.HasValue != nullable2.HasValue))
                {
                    SendPropertyChanging();
                    _site_cid = value;
                    SendPropertyChanged("site_cid");
                }
            }
        }

        [Column(Storage = "_site_parent_cid", DbType = "Decimal(22,0)")]
        public decimal? site_parent_cid
        {
            get { return _site_parent_cid; }
            set
            {
                decimal? nullable = _site_parent_cid;
                decimal? nullable2 = value;
                if ((nullable.GetValueOrDefault() != nullable2.GetValueOrDefault()) ||
                    (nullable.HasValue != nullable2.HasValue))
                {
                    SendPropertyChanging();
                    _site_parent_cid = value;
                    SendPropertyChanged("site_parent_cid");
                }
            }
        }

        [Column(Storage = "_sort_order", DbType = "Decimal(18,0)")]
        public decimal? sort_order
        {
            get { return _sort_order; }
            set
            {
                decimal? nullable = _sort_order;
                decimal? nullable2 = value;
                if ((nullable.GetValueOrDefault() != nullable2.GetValueOrDefault()) ||
                    (nullable.HasValue != nullable2.HasValue))
                {
                    SendPropertyChanging();
                    _sort_order = value;
                    SendPropertyChanged("sort_order");
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