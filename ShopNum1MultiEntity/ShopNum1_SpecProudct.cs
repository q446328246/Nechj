using System;

//using System.Data.Linq.Mapping;

namespace ShopNum1MultiEntity
{
    //[Table(Name = "dbo.ShopNum1_SpecProudct")]
    public class ShopNum1_SpecProudct
    {
        private DateTime? dateTime_0;
        private decimal? decimal_0;
        private int? int_0;
        private int? int_1;
        private string string_0;
        private string string_1;
        private string string_2;
        private string string_3;
        private string string_4;
        private string string_5;
        private string string_6;

        //[Column(Storage = "_CreateTime", DbType = "DateTime")]
        public DateTime? CreateTime
        {
            get { return dateTime_0; }
            set
            {
                if (dateTime_0 != value)
                {
                    dateTime_0 = value;
                }
            }
        }

        //[Column(Storage = "_GoodColor", DbType = "VarChar(20)")]
        public string GoodColor
        {
            get { return string_4; }
            set
            {
                if (string_4 != value)
                {
                    string_4 = value;
                }
            }
        }

        //[Column(Storage = "_GoodsNumber", DbType = "VarChar(50)")]
        public string GoodsNumber
        {
            get { return string_3; }
            set
            {
                if (string_3 != value)
                {
                    string_3 = value;
                }
            }
        }

        //[Column(Storage = "_GoodsPrice", DbType = "Decimal(18,0)")]
        public decimal? GoodsPrice
        {
            get { return decimal_0; }
            set
            {
                decimal? nullable = decimal_0;
                decimal? nullable2 = value;
                if ((nullable.GetValueOrDefault() != nullable2.GetValueOrDefault()) ||
                    (nullable.HasValue != nullable2.HasValue))
                {
                    decimal_0 = value;
                }
            }
        }

        //[Column(Storage = "_GoodsStock", DbType = "Int")]
        public int? GoodsStock
        {
            get { return int_0; }
            set
            {
                if (int_0 != value)
                {
                    int_0 = value;
                }
            }
        }

        //[Column(Storage = "_ProductGuid", DbType = "VarChar(50)")]
        public string ProductGuid
        {
            get { return string_0; }
            set
            {
                if (string_0 != value)
                {
                    string_0 = value;
                }
            }
        }

        //[Column(Storage = "_SalesCount", DbType = "Int")]
        public int? SalesCount
        {
            get { return int_1; }
            set
            {
                if (int_1 != value)
                {
                    int_1 = value;
                }
            }
        }

        //[Column(Storage = "_ShopID", DbType = "VarChar(50)")]
        public string ShopID
        {
            get { return string_6; }
            set
            {
                if (string_6 != value)
                {
                    string_6 = value;
                }
            }
        }

        //[Column(Storage = "_SpecDetail", DbType = "VarChar(500)")]
        public string SpecDetail
        {
            get { return string_1; }
            set
            {
                if (string_1 != value)
                {
                    string_1 = value;
                }
            }
        }

        //[Column(Storage = "_SpecTotalId", DbType = "VarChar(50)")]
        public string SpecTotalId
        {
            get { return string_2; }
            set
            {
                if (string_2 != value)
                {
                    string_2 = value;
                }
            }
        }

        //[Column(Storage = "_TbProp", DbType = "VarChar(200)")]
        public string TbProp
        {
            get { return string_5; }
            set
            {
                if (string_5 != value)
                {
                    string_5 = value;
                }
            }
        }
    }
}