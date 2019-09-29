using System;

//using System.Data.Linq.Mapping;

namespace ShopNum1MultiEntity
{
    //[Table(Name = "dbo.ShopNum1_MemberActivate")]
    public class ShopNum1_MemberActivate
    {
        private byte? byte_0;
        private byte? byte_1;
        private DateTime? dateTime_0;
        private Guid? guid_0;
        private string string_0;
        private string string_1;
        private string string_2;
        private string string_3;
        private string string_4;

        //[Column(Storage = "_Email", DbType = "NVarChar(50)")]
        public string Email
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

        //[Column(Storage = "_extireTime", DbType = "DateTime")]
        public DateTime? extireTime
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

        //[Column(Storage = "_Guid", DbType = "UniqueIdentifier")]
        public Guid? Guid
        {
            get { return guid_0; }
            set
            {
                if (guid_0 != value)
                {
                    guid_0 = value;
                }
            }
        }

        //[Column(Storage = "_isinvalid", DbType = "TinyInt")]
        public byte? isinvalid
        {
            get { return byte_0; }
            set
            {
                if (byte_0 != value)
                {
                    byte_0 = value;
                }
            }
        }

        //[Column(Storage = "_MemberID", DbType = "NVarChar(50)")]
        public string MemberID
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

        //[Column(Storage = "_Phone", DbType = "NVarChar(20)")]
        public string Phone
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

        // [Column(Name = "[key]", Storage = "_key", DbType = "NVarChar(50)")]
        public string Key
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

        //[Column(Storage = "_pwd", DbType = "NVarChar(50)")]
        public string Pwd
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

        //[Column(Storage = "_type", DbType = "TinyInt")]
        public byte? type
        {
            get { return byte_1; }
            set
            {
                if (byte_1 != value)
                {
                    byte_1 = value;
                }
            }
        }
    }
}