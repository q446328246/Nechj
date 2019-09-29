﻿using System;

//using System.Data.Linq.Mapping;

namespace ShopNum1MultiEntity
{
    //[Table(Name = "dbo.ShopNum1_ScoreOrderInfo")]
    public class ShopNum1_ScoreOrderInfo
    {
        private byte? byte_0;
        private byte? byte_1;
        private DateTime? dateTime_0;
        private DateTime? dateTime_1;
        private DateTime? dateTime_2;
        private Guid? guid_0;
        private int? int_0;
        private string string_0;
        private string string_1;
        private string string_10;
        private string string_11;
        private string string_2;
        private string string_3;
        private string string_4;
        private string string_5;
        private string string_6;
        private string string_7;
        private string string_8;
        private string string_9;

        //[Column(Storage = "_Address", DbType = "NVarChar(250)")]
        public string Address
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

        //[Column(Storage = "_ConfirmTime", DbType = "DateTime")]
        public DateTime? ConfirmTime
        {
            get { return dateTime_1; }
            set
            {
                if (dateTime_1 != value)
                {
                    dateTime_1 = value;
                }
            }
        }

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

        //[Column(Storage = "_Email", DbType = "NVarChar(100)")]
        public string Email
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

        //[Column(Storage = "_IsDeleted", DbType = "TinyInt")]
        public byte? IsDeleted
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

        //[Column(Storage = "_MemLoginID", DbType = "NVarChar(50)")]
        public string MemLoginID
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

        //[Column(Storage = "_Mobile", DbType = "NVarChar(20)")]
        public string Mobile
        {
            get { return string_9; }
            set
            {
                if (string_9 != value)
                {
                    string_9 = value;
                }
            }
        }

        //[Column(Storage = "_ModifyTime", DbType = "DateTime")]
        public DateTime? ModifyTime
        {
            get { return dateTime_2; }
            set
            {
                if (dateTime_2 != value)
                {
                    dateTime_2 = value;
                }
            }
        }

        //[Column(Storage = "_ModifyUser", DbType = "NVarChar(50)")]
        public string ModifyUser
        {
            get { return string_11; }
            set
            {
                if (string_11 != value)
                {
                    string_11 = value;
                }
            }
        }

        //[Column(Storage = "_Name", DbType = "NVarChar(50)")]
        public string Name
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

        //[Column(Storage = "_OderStatus", DbType = "TinyInt")]
        public byte? OderStatus
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

        //[Column(Storage = "_OrderNumber", DbType = "NVarChar(50)")]
        public string OrderNumber
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

        //[Column(Storage = "_Postalcode", DbType = "VarChar(20)")]
        public string Postalcode
        {
            get { return string_7; }
            set
            {
                if (string_7 != value)
                {
                    string_7 = value;
                }
            }
        }

        //[Column(Storage = "_ShopMemLoginID", DbType = "VarChar(50)")]
        public string ShopMemLoginID
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

        //[Column(Storage = "_ShopName", DbType = "NVarChar(100)")]
        public string ShopName
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

        //[Column(Storage = "_Tel", DbType = "NVarChar(20)")]
        public string Tel
        {
            get { return string_8; }
            set
            {
                if (string_8 != value)
                {
                    string_8 = value;
                }
            }
        }

        //[Column(Storage = "_TotalScore", DbType = "Int")]
        public int? TotalScore
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

        //[Column(Storage = "_UserMsg", DbType = "NVarChar(1000)")]
        public string UserMsg
        {
            get { return string_10; }
            set
            {
                if (string_10 != value)
                {
                    string_10 = value;
                }
            }
        }
    }
}