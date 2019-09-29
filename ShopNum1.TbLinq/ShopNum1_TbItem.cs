using System;
using System.ComponentModel;
using System.Data.Linq.Mapping;

namespace ShopNum1.TbLinq
{
    [Table(Name = "dbo.ShopNum1_TbItem")]
    public class ShopNum1_TbItem : INotifyPropertyChanging, INotifyPropertyChanged
    {
        private static readonly PropertyChangingEventArgs emptyChangingEventArgs =
            new PropertyChangingEventArgs(string.Empty);

        private int _ID;
        private string _Memlogid;
        private string _ShopName;

        private decimal? _after_sale_id;
        private string _approve_status;
        private decimal? _auction_point;
        private string _auto_fill;
        private decimal? _cid;
        private DateTime? _created;
        private DateTime? _delist_time;
        private string _desc;
        private decimal? _ems_fee;
        private decimal? _express_fee;
        private bool? _freight_payer;
        private bool? _has_discount;
        private bool? _has_invoice;
        private bool? _has_showcase;
        private bool? _has_warranty;
        private string _increment;
        private string _input_pids;
        private string _input_str;
        private bool? _isTaobao;
        private bool? _is_3D;
        private bool? _is_ex;
        private bool? _is_prepay;
        private bool? _is_taobao;
        private bool? _is_timing;
        private bool? _is_virtual;
        private decimal? _item_img_Id;
        private DateTime? _list_time;
        private int? _location_Id;
        private DateTime? _modified;
        private string _nick;
        private decimal? _num;
        private decimal? _num_iid;
        private bool? _one_station;
        private string _pic_url;
        private decimal? _post_fee;
        private decimal? _postage_id;
        private decimal? _price;
        private decimal? _product_id;
        private string _promoted_service;
        private decimal? _prop_imgs_Id;
        private string _property_alias;
        private string _props;
        private string _props_name;
        private decimal? _score;
        private string _second_kill;
        private string _seller_cids;
        private string _site_Id;
        private decimal? _site_skus_Id;
        private string _skus_Id;
        private string _stuff_status;
        private string _title;
        private string _type;
        private decimal? _valid_thru;
        private string _videos_Id;
        private bool? _violation;
        private decimal? _volume;
        private string _wap_desc;
        private string _wap_detail_url;
        private bool? _ww_status;

        [Column(Storage = "_after_sale_id", DbType = "Decimal(36,0)")]
        public decimal? after_sale_id
        {
            get { return _after_sale_id; }
            set
            {
                decimal? nullable = _after_sale_id;
                decimal? nullable2 = value;
                if ((nullable.GetValueOrDefault() != nullable2.GetValueOrDefault()) ||
                    (nullable.HasValue != nullable2.HasValue))
                {
                    SendPropertyChanging();
                    _after_sale_id = value;
                    SendPropertyChanged("after_sale_id");
                }
            }
        }

        [Column(Storage = "_approve_status", DbType = "NVarChar(50)")]
        public string approve_status
        {
            get { return _approve_status; }
            set
            {
                if (_approve_status != value)
                {
                    SendPropertyChanging();
                    _approve_status = value;
                    SendPropertyChanged("approve_status");
                }
            }
        }

        [Column(Storage = "_auction_point", DbType = "Decimal(18,0)")]
        public decimal? auction_point
        {
            get { return _auction_point; }
            set
            {
                decimal? nullable = _auction_point;
                decimal? nullable2 = value;
                if ((nullable.GetValueOrDefault() != nullable2.GetValueOrDefault()) ||
                    (nullable.HasValue != nullable2.HasValue))
                {
                    SendPropertyChanging();
                    _auction_point = value;
                    SendPropertyChanged("auction_point");
                }
            }
        }

        [Column(Storage = "_auto_fill", DbType = "NVarChar(50)")]
        public string auto_fill
        {
            get { return _auto_fill; }
            set
            {
                if (_auto_fill != value)
                {
                    SendPropertyChanging();
                    _auto_fill = value;
                    SendPropertyChanged("auto_fill");
                }
            }
        }

        [Column(Storage = "_cid", DbType = "Decimal(22,0)")]
        public decimal? cid
        {
            get { return _cid; }
            set
            {
                decimal? nullable = _cid;
                decimal? nullable2 = value;
                if ((nullable.GetValueOrDefault() != nullable2.GetValueOrDefault()) ||
                    (nullable.HasValue != nullable2.HasValue))
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

        [Column(Storage = "_delist_time", DbType = "DateTime")]
        public DateTime? delist_time
        {
            get { return _delist_time; }
            set
            {
                if (_delist_time != value)
                {
                    SendPropertyChanging();
                    _delist_time = value;
                    SendPropertyChanged("delist_time");
                }
            }
        }

        [Column(Name = "[desc]", Storage = "_desc", DbType = "NText", UpdateCheck = UpdateCheck.Never)]
        public string desc
        {
            get { return _desc; }
            set
            {
                if (_desc != value)
                {
                    SendPropertyChanging();
                    _desc = value;
                    SendPropertyChanged("desc");
                }
            }
        }

        [Column(Storage = "_ems_fee", DbType = "Decimal(18,2)")]
        public decimal? ems_fee
        {
            get { return _ems_fee; }
            set
            {
                decimal? nullable = _ems_fee;
                decimal? nullable2 = value;
                if ((nullable.GetValueOrDefault() != nullable2.GetValueOrDefault()) ||
                    (nullable.HasValue != nullable2.HasValue))
                {
                    SendPropertyChanging();
                    _ems_fee = value;
                    SendPropertyChanged("ems_fee");
                }
            }
        }

        [Column(Storage = "_express_fee", DbType = "Decimal(18,2)")]
        public decimal? express_fee
        {
            get { return _express_fee; }
            set
            {
                decimal? nullable = _express_fee;
                decimal? nullable2 = value;
                if ((nullable.GetValueOrDefault() != nullable2.GetValueOrDefault()) ||
                    (nullable.HasValue != nullable2.HasValue))
                {
                    SendPropertyChanging();
                    _express_fee = value;
                    SendPropertyChanged("express_fee");
                }
            }
        }

        [Column(Storage = "_freight_payer", DbType = "Bit")]
        public bool? freight_payer
        {
            get { return _freight_payer; }
            set
            {
                if (_freight_payer != value)
                {
                    SendPropertyChanging();
                    _freight_payer = value;
                    SendPropertyChanged("freight_payer");
                }
            }
        }

        [Column(Storage = "_has_discount", DbType = "Bit")]
        public bool? has_discount
        {
            get { return _has_discount; }
            set
            {
                if (_has_discount != value)
                {
                    SendPropertyChanging();
                    _has_discount = value;
                    SendPropertyChanged("has_discount");
                }
            }
        }

        [Column(Storage = "_has_invoice", DbType = "Bit")]
        public bool? has_invoice
        {
            get { return _has_invoice; }
            set
            {
                if (_has_invoice != value)
                {
                    SendPropertyChanging();
                    _has_invoice = value;
                    SendPropertyChanged("has_invoice");
                }
            }
        }

        [Column(Storage = "_has_showcase", DbType = "Bit")]
        public bool? has_showcase
        {
            get { return _has_showcase; }
            set
            {
                if (_has_showcase != value)
                {
                    SendPropertyChanging();
                    _has_showcase = value;
                    SendPropertyChanged("has_showcase");
                }
            }
        }

        [Column(Storage = "_has_warranty", DbType = "Bit")]
        public bool? has_warranty
        {
            get { return _has_warranty; }
            set
            {
                if (_has_warranty != value)
                {
                    SendPropertyChanging();
                    _has_warranty = value;
                    SendPropertyChanged("has_warranty");
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

        [Column(Storage = "_increment", DbType = "NVarChar(50)")]
        public string increment
        {
            get { return _increment; }
            set
            {
                if (_increment != value)
                {
                    SendPropertyChanging();
                    _increment = value;
                    SendPropertyChanged("increment");
                }
            }
        }

        [Column(Storage = "_input_pids", DbType = "NVarChar(100)")]
        public string input_pids
        {
            get { return _input_pids; }
            set
            {
                if (_input_pids != value)
                {
                    SendPropertyChanging();
                    _input_pids = value;
                    SendPropertyChanged("input_pids");
                }
            }
        }

        [Column(Storage = "_input_str", DbType = "NVarChar(100)")]
        public string input_str
        {
            get { return _input_str; }
            set
            {
                if (_input_str != value)
                {
                    SendPropertyChanging();
                    _input_str = value;
                    SendPropertyChanged("input_str");
                }
            }
        }

        [Column(Storage = "_is_3D", DbType = "Bit")]
        public bool? is_3D
        {
            get { return _is_3D; }
            set
            {
                if (_is_3D != value)
                {
                    SendPropertyChanging();
                    _is_3D = value;
                    SendPropertyChanged("is_3D");
                }
            }
        }

        [Column(Storage = "_is_ex", DbType = "Bit")]
        public bool? is_ex
        {
            get { return _is_ex; }
            set
            {
                if (_is_ex != value)
                {
                    SendPropertyChanging();
                    _is_ex = value;
                    SendPropertyChanged("is_ex");
                }
            }
        }

        [Column(Storage = "_is_prepay", DbType = "Bit")]
        public bool? is_prepay
        {
            get { return _is_prepay; }
            set
            {
                if (_is_prepay != value)
                {
                    SendPropertyChanging();
                    _is_prepay = value;
                    SendPropertyChanged("is_prepay");
                }
            }
        }

        [Column(Storage = "_is_taobao", DbType = "Bit")]
        public bool? is_taobao
        {
            get { return _is_taobao; }
            set
            {
                if (_is_taobao != value)
                {
                    SendPropertyChanging();
                    _is_taobao = value;
                    SendPropertyChanged("is_taobao");
                }
            }
        }

        [Column(Storage = "_is_timing", DbType = "Bit")]
        public bool? is_timing
        {
            get { return _is_timing; }
            set
            {
                if (_is_timing != value)
                {
                    SendPropertyChanging();
                    _is_timing = value;
                    SendPropertyChanged("is_timing");
                }
            }
        }

        [Column(Storage = "_is_virtual", DbType = "Bit")]
        public bool? is_virtual
        {
            get { return _is_virtual; }
            set
            {
                if (_is_virtual != value)
                {
                    SendPropertyChanging();
                    _is_virtual = value;
                    SendPropertyChanged("is_virtual");
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

        [Column(Storage = "_item_img_Id", DbType = "Decimal(18,0)")]
        public decimal? item_img_Id
        {
            get { return _item_img_Id; }
            set
            {
                decimal? nullable = _item_img_Id;
                decimal? nullable2 = value;
                if ((nullable.GetValueOrDefault() != nullable2.GetValueOrDefault()) ||
                    (nullable.HasValue != nullable2.HasValue))
                {
                    SendPropertyChanging();
                    _item_img_Id = value;
                    SendPropertyChanged("item_img_Id");
                }
            }
        }

        [Column(Storage = "_list_time", DbType = "DateTime")]
        public DateTime? list_time
        {
            get { return _list_time; }
            set
            {
                if (_list_time != value)
                {
                    SendPropertyChanging();
                    _list_time = value;
                    SendPropertyChanged("list_time");
                }
            }
        }

        [Column(Storage = "_location_Id", DbType = "Int")]
        public int? location_Id
        {
            get { return _location_Id; }
            set
            {
                if (_location_Id != value)
                {
                    SendPropertyChanging();
                    _location_Id = value;
                    SendPropertyChanged("location_Id");
                }
            }
        }

        [Column(Storage = "_Memlogid", DbType = "VarChar(50) NOT NULL", CanBeNull = false)]
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

        [Column(Storage = "_nick", DbType = "NVarChar(50)")]
        public string nick
        {
            get { return _nick; }
            set
            {
                if (_nick != value)
                {
                    SendPropertyChanging();
                    _nick = value;
                    SendPropertyChanged("nick");
                }
            }
        }

        [Column(Storage = "_num", DbType = "Decimal(18,0)")]
        public decimal? num
        {
            get { return _num; }
            set
            {
                decimal? nullable = _num;
                decimal? nullable2 = value;
                if ((nullable.GetValueOrDefault() != nullable2.GetValueOrDefault()) ||
                    (nullable.HasValue != nullable2.HasValue))
                {
                    SendPropertyChanging();
                    _num = value;
                    SendPropertyChanged("num");
                }
            }
        }

        [Column(Storage = "_num_iid", DbType = "Decimal(36,0)")]
        public decimal? num_iid
        {
            get { return _num_iid; }
            set
            {
                decimal? nullable = _num_iid;
                decimal? nullable2 = value;
                if ((nullable.GetValueOrDefault() != nullable2.GetValueOrDefault()) ||
                    (nullable.HasValue != nullable2.HasValue))
                {
                    SendPropertyChanging();
                    _num_iid = value;
                    SendPropertyChanged("num_iid");
                }
            }
        }

        [Column(Storage = "_one_station", DbType = "Bit")]
        public bool? one_station
        {
            get { return _one_station; }
            set
            {
                if (_one_station != value)
                {
                    SendPropertyChanging();
                    _one_station = value;
                    SendPropertyChanged("one_station");
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

        [Column(Storage = "_post_fee", DbType = "Decimal(18,2)")]
        public decimal? post_fee
        {
            get { return _post_fee; }
            set
            {
                decimal? nullable = _post_fee;
                decimal? nullable2 = value;
                if ((nullable.GetValueOrDefault() != nullable2.GetValueOrDefault()) ||
                    (nullable.HasValue != nullable2.HasValue))
                {
                    SendPropertyChanging();
                    _post_fee = value;
                    SendPropertyChanged("post_fee");
                }
            }
        }

        [Column(Storage = "_postage_id", DbType = "Decimal(18,0)")]
        public decimal? postage_id
        {
            get { return _postage_id; }
            set
            {
                decimal? nullable = _postage_id;
                decimal? nullable2 = value;
                if ((nullable.GetValueOrDefault() != nullable2.GetValueOrDefault()) ||
                    (nullable.HasValue != nullable2.HasValue))
                {
                    SendPropertyChanging();
                    _postage_id = value;
                    SendPropertyChanged("postage_id");
                }
            }
        }

        [Column(Storage = "_price", DbType = "Decimal(18,2)")]
        public decimal? price
        {
            get { return _price; }
            set
            {
                decimal? nullable = _price;
                decimal? nullable2 = value;
                if ((nullable.GetValueOrDefault() != nullable2.GetValueOrDefault()) ||
                    (nullable.HasValue != nullable2.HasValue))
                {
                    SendPropertyChanging();
                    _price = value;
                    SendPropertyChanged("price");
                }
            }
        }

        [Column(Storage = "_product_id", DbType = "Decimal(36,0)")]
        public decimal? product_id
        {
            get { return _product_id; }
            set
            {
                decimal? nullable = _product_id;
                decimal? nullable2 = value;
                if ((nullable.GetValueOrDefault() != nullable2.GetValueOrDefault()) ||
                    (nullable.HasValue != nullable2.HasValue))
                {
                    SendPropertyChanging();
                    _product_id = value;
                    SendPropertyChanged("product_id");
                }
            }
        }

        [Column(Storage = "_promoted_service", DbType = "NVarChar(200)")]
        public string promoted_service
        {
            get { return _promoted_service; }
            set
            {
                if (_promoted_service != value)
                {
                    SendPropertyChanging();
                    _promoted_service = value;
                    SendPropertyChanged("promoted_service");
                }
            }
        }

        [Column(Storage = "_prop_imgs_Id", DbType = "Decimal(18,0)")]
        public decimal? prop_imgs_Id
        {
            get { return _prop_imgs_Id; }
            set
            {
                decimal? nullable = _prop_imgs_Id;
                decimal? nullable2 = value;
                if ((nullable.GetValueOrDefault() != nullable2.GetValueOrDefault()) ||
                    (nullable.HasValue != nullable2.HasValue))
                {
                    SendPropertyChanging();
                    _prop_imgs_Id = value;
                    SendPropertyChanged("prop_imgs_Id");
                }
            }
        }

        [Column(Storage = "_property_alias", DbType = "NVarChar(50)")]
        public string property_alias
        {
            get { return _property_alias; }
            set
            {
                if (_property_alias != value)
                {
                    SendPropertyChanging();
                    _property_alias = value;
                    SendPropertyChanged("property_alias");
                }
            }
        }

        [Column(Storage = "_props", DbType = "NVarChar(200)")]
        public string props
        {
            get { return _props; }
            set
            {
                if (_props != value)
                {
                    SendPropertyChanging();
                    _props = value;
                    SendPropertyChanged("props");
                }
            }
        }

        [Column(Storage = "_props_name", DbType = "NVarChar(50)")]
        public string props_name
        {
            get { return _props_name; }
            set
            {
                if (_props_name != value)
                {
                    SendPropertyChanging();
                    _props_name = value;
                    SendPropertyChanged("props_name");
                }
            }
        }

        [Column(Storage = "_score", DbType = "Decimal(18,0)")]
        public decimal? score
        {
            get { return _score; }
            set
            {
                decimal? nullable = _score;
                decimal? nullable2 = value;
                if ((nullable.GetValueOrDefault() != nullable2.GetValueOrDefault()) ||
                    (nullable.HasValue != nullable2.HasValue))
                {
                    SendPropertyChanging();
                    _score = value;
                    SendPropertyChanged("score");
                }
            }
        }

        [Column(Storage = "_second_kill", DbType = "NVarChar(50)")]
        public string second_kill
        {
            get { return _second_kill; }
            set
            {
                if (_second_kill != value)
                {
                    SendPropertyChanging();
                    _second_kill = value;
                    SendPropertyChanged("second_kill");
                }
            }
        }

        [Column(Storage = "_seller_cids", DbType = "NVarChar(200)")]
        public string seller_cids
        {
            get { return _seller_cids; }
            set
            {
                if (_seller_cids != value)
                {
                    SendPropertyChanging();
                    _seller_cids = value;
                    SendPropertyChanged("seller_cids");
                }
            }
        }

        [Column(Storage = "_ShopName", DbType = "NVarChar(200)")]
        public string ShopName
        {
            get { return _ShopName; }
            set
            {
                if (_ShopName != value)
                {
                    SendPropertyChanging();
                    _ShopName = value;
                    SendPropertyChanged("ShopName");
                }
            }
        }

        [Column(Storage = "_site_Id", DbType = "NVarChar(200)")]
        public string site_Id
        {
            get { return _site_Id; }
            set
            {
                if (_site_Id != value)
                {
                    SendPropertyChanging();
                    _site_Id = value;
                    SendPropertyChanged("site_Id");
                }
            }
        }

        [Column(Storage = "_site_skus_Id", DbType = "Decimal(18,0)")]
        public decimal? site_skus_Id
        {
            get { return _site_skus_Id; }
            set
            {
                decimal? nullable = _site_skus_Id;
                decimal? nullable2 = value;
                if ((nullable.GetValueOrDefault() != nullable2.GetValueOrDefault()) ||
                    (nullable.HasValue != nullable2.HasValue))
                {
                    SendPropertyChanging();
                    _site_skus_Id = value;
                    SendPropertyChanged("site_skus_Id");
                }
            }
        }

        [Column(Storage = "_skus_Id", DbType = "NVarChar(100)")]
        public string skus_Id
        {
            get { return _skus_Id; }
            set
            {
                if (_skus_Id != value)
                {
                    SendPropertyChanging();
                    _skus_Id = value;
                    SendPropertyChanged("skus_Id");
                }
            }
        }

        [Column(Storage = "_stuff_status", DbType = "NVarChar(20)")]
        public string stuff_status
        {
            get { return _stuff_status; }
            set
            {
                if (_stuff_status != value)
                {
                    SendPropertyChanging();
                    _stuff_status = value;
                    SendPropertyChanged("stuff_status");
                }
            }
        }

        [Column(Storage = "_title", DbType = "NVarChar(60)")]
        public string title
        {
            get { return _title; }
            set
            {
                if (_title != value)
                {
                    SendPropertyChanging();
                    _title = value;
                    SendPropertyChanged("title");
                }
            }
        }

        [Column(Storage = "_type", DbType = "NVarChar(20)")]
        public string type
        {
            get { return _type; }
            set
            {
                if (_type != value)
                {
                    SendPropertyChanging();
                    _type = value;
                    SendPropertyChanged("type");
                }
            }
        }

        [Column(Storage = "_valid_thru", DbType = "Decimal(18,0)")]
        public decimal? valid_thru
        {
            get { return _valid_thru; }
            set
            {
                decimal? nullable = _valid_thru;
                decimal? nullable2 = value;
                if ((nullable.GetValueOrDefault() != nullable2.GetValueOrDefault()) ||
                    (nullable.HasValue != nullable2.HasValue))
                {
                    SendPropertyChanging();
                    _valid_thru = value;
                    SendPropertyChanged("valid_thru");
                }
            }
        }

        [Column(Storage = "_videos_Id", DbType = "NVarChar(50)")]
        public string videos_Id
        {
            get { return _videos_Id; }
            set
            {
                if (_videos_Id != value)
                {
                    SendPropertyChanging();
                    _videos_Id = value;
                    SendPropertyChanged("videos_Id");
                }
            }
        }

        [Column(Storage = "_violation", DbType = "Bit")]
        public bool? violation
        {
            get { return _violation; }
            set
            {
                if (_violation != value)
                {
                    SendPropertyChanging();
                    _violation = value;
                    SendPropertyChanged("violation");
                }
            }
        }

        [Column(Storage = "_volume", DbType = "Decimal(18,0)")]
        public decimal? volume
        {
            get { return _volume; }
            set
            {
                decimal? nullable = _volume;
                decimal? nullable2 = value;
                if ((nullable.GetValueOrDefault() != nullable2.GetValueOrDefault()) ||
                    (nullable.HasValue != nullable2.HasValue))
                {
                    SendPropertyChanging();
                    _volume = value;
                    SendPropertyChanged("volume");
                }
            }
        }

        [Column(Storage = "_wap_desc", DbType = "NText", UpdateCheck = UpdateCheck.Never)]
        public string wap_desc
        {
            get { return _wap_desc; }
            set
            {
                if (_wap_desc != value)
                {
                    SendPropertyChanging();
                    _wap_desc = value;
                    SendPropertyChanged("wap_desc");
                }
            }
        }

        [Column(Storage = "_wap_detail_url", DbType = "NVarChar(200)")]
        public string wap_detail_url
        {
            get { return _wap_detail_url; }
            set
            {
                if (_wap_detail_url != value)
                {
                    SendPropertyChanging();
                    _wap_detail_url = value;
                    SendPropertyChanged("wap_detail_url");
                }
            }
        }

        [Column(Storage = "_ww_status", DbType = "Bit")]
        public bool? ww_status
        {
            get { return _ww_status; }
            set
            {
                if (_ww_status != value)
                {
                    SendPropertyChanging();
                    _ww_status = value;
                    SendPropertyChanged("ww_status");
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