using System.Data.Linq.Mapping;

namespace ShopNum1.TbLinq
{
    [Table(Name = "dbo.ShopNum1_TbAddress")]
    public class ShopNum1_TbAddress
    {
        private int? _Id;
        private string _mark;
        private string _name;
        private int? _parent_Id;
        private byte? _type;
        private string _zip;

        [Column(Storage = "_Id", DbType = "Int")]
        public int? Id
        {
            get { return _Id; }
            set
            {
                if (_Id != value)
                {
                    _Id = value;
                }
            }
        }

        [Column(Storage = "_mark", DbType = "VarChar(4)")]
        public string mark
        {
            get { return _mark; }
            set
            {
                if (_mark != value)
                {
                    _mark = value;
                }
            }
        }

        [Column(Storage = "_name", DbType = "NVarChar(50)")]
        public string name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                }
            }
        }

        [Column(Storage = "_parent_Id", DbType = "Int")]
        public int? parent_Id
        {
            get { return _parent_Id; }
            set
            {
                if (_parent_Id != value)
                {
                    _parent_Id = value;
                }
            }
        }

        [Column(Storage = "_type", DbType = "TinyInt")]
        public byte? type
        {
            get { return _type; }
            set
            {
                if (_type != value)
                {
                    _type = value;
                }
            }
        }

        [Column(Storage = "_zip", DbType = "NVarChar(50)")]
        public string zip
        {
            get { return _zip; }
            set
            {
                if (_zip != value)
                {
                    _zip = value;
                }
            }
        }
    }
}