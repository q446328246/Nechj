using System;
using System.ComponentModel;

namespace ShopNum1MultiEntity
{
    //[Table(Name = "dbo.ShopNum1_MemberShip")]
    public class ShopNum1_MemberShip : INotifyPropertyChanging, INotifyPropertyChanged
    {
        private static readonly PropertyChangingEventArgs propertyChangingEventArgs_0 =
            new PropertyChangingEventArgs(string.Empty);

        private int int_0;
        private int int_1;
        private string string_0;
        private string string_1;
        private string string_2;
        private string string_3;
        private string string_4;
        private string string_5;
        private string string_6;
        private string string_7;
        private string string_8;
        private string string_9;
        private string string_10;
        private string string_11;
        private string string_12;
        private string string_13;
        private string string_14;
        private string string_15;
        private string string_16;
        private string string_17;
        private string string_18;
        private string string_19;
        private string string_20;
        private string string_21;
        private string string_22;
        private string string_23;
        private string string_24;
        private string string_25;
        private string string_26;

        private string guid_0;
        private string guid_1;
        private DateTime? dateTime_0;
        private DateTime? dateTime_1;
        private DateTime? dateTime_2;
        private DateTime? dateTime_3;
        private DateTime? dateTime_4;
        private DateTime? dateTime_5;

        /// <summary>
        /// 开业门头照片附件地址
        /// </summary>
        public string OpeningImage
        {
            get { return string_26; }
            set
            {
                if (string_26 != value)
                {
                    SendPropertyChanging();
                    string_26 = value;
                    SendPropertyChanged("OpeningImage");
                }
            }
        }
        /// <summary>
        /// 店铺内部情况2附件地址
        /// </summary>
        public string ShopImagetwo
        {
            get { return string_25; }
            set
            {
                if (string_25 != value)
                {
                    SendPropertyChanging();
                    string_25 = value;
                    SendPropertyChanged("ShopImagetwo");
                }
            }
        }

        /// <summary>
        /// 店铺内部情况1附件地址
        /// </summary>
        public string ShopImageone
        {
            get { return string_24; }
            set
            {
                if (string_24 != value)
                {
                    SendPropertyChanging();
                    string_24 = value;
                    SendPropertyChanged("ShopImageone1");
                }
            }
        }
        /// <summary>
        /// 审批1时间
        /// </summary>

        public DateTime? Upgrade_two_datatime
        {
            get { return dateTime_5; }
            set
            {
                if (dateTime_5 != value)
                {
                    SendPropertyChanging();
                    dateTime_5 = value;
                    SendPropertyChanged("Upgrade_two_datatime");
                }
            }
        }
        /// <summary>
        /// 审批2时间
        /// </summary>
        public DateTime? ExamineTime
        {
            get { return dateTime_4; }
            set
            {
                if (dateTime_4 != value)
                {
                    SendPropertyChanging();
                    dateTime_4 = value;
                    SendPropertyChanged("ExamineTime");
                }
            }
        }
        /// <summary>
        /// 会员税务登记附件地址
        /// </summary>
        public string RegistrationImage
        {
            get { return string_23; }
            set
            {
                if (string_23 != value)
                {
                    SendPropertyChanging();
                    string_23 = value;
                    SendPropertyChanged("RegistrationImage");
                }
            }
        }
        /// <summary>
        /// 行驶证
        /// </summary>
        public string OrganizationImage
        {
            get { return string_22; }
            set
            {
                if (string_22 != value)
                {
                    SendPropertyChanging();
                    string_22 = value;
                    SendPropertyChanged("OrganizationImage");
                }
            }
        }
        /// <summary>
        /// 驾驶证
        /// </summary>
        public string LicenseImage
        {
            get { return string_21; }
            set
            {
                if (string_21 != value)
                {
                    SendPropertyChanging();
                    string_21 = value;
                    SendPropertyChanged("LicenseImage");
                }
            }
        }
        /// <summary>
        /// 会员区代名称
        /// </summary>
        public string ShopNames
        {
            get { return string_20; }
            set
            {
                if (string_20 != value)
                {
                    SendPropertyChanging();
                    string_20 = value;
                    SendPropertyChanged("ShopNames");
                }
            }
        }
        /// <summary>
        /// 会员上级区代
        /// </summary>
        public string Belongs
        {
            get { return string_19; }
            set
            {
                if (string_19 != value)
                {
                    SendPropertyChanging();
                    string_19 = value;
                    SendPropertyChanged("Belongs");
                }
            }
        }
        /// <summary>
        /// 招商人居住地址
        /// </summary>
        public string REAdress
        {
            get { return string_18; }
            set
            {
                if (string_18 != value)
                {
                    SendPropertyChanging();
                    string_18 = value;
                    SendPropertyChanged("REAdress");
                }
            }
        }
        /// <summary>
        /// 招商人手机
        /// </summary>
        public string REMobile
        {
            get { return string_17; }
            set
            {
                if (string_17 != value)
                {
                    SendPropertyChanging();
                    string_17 = value;
                    SendPropertyChanged("REMobile");
                }
            }
        }
        /// <summary>
        /// 招商人电话
        /// </summary>
        public string REPhone
        {
            get { return string_16; }
            set
            {
                if (string_16 != value)
                {
                    SendPropertyChanging();
                    string_16 = value;
                    SendPropertyChanged("REPhone");
                }
            }
        }
        /// <summary>
        /// 招商人性别
        /// </summary>
        public string RESex
        {
            get { return string_15; }
            set
            {
                if (string_15 != value)
                {
                    SendPropertyChanging();
                    string_15 = value;
                    SendPropertyChanged("RESex");
                }
            }
        }
        /// <summary>
        /// 招商人身份证号
        /// </summary>
        public string REIdentityCard
        {
            get { return string_14; }
            set
            {
                if (string_14 != value)
                {
                    SendPropertyChanging();
                    string_14 = value;
                    SendPropertyChanged("REIdentityCard");
                }
            }
        }
        /// <summary>
        /// 招商人生日
        /// </summary>
        public DateTime? REBirthdayTime
        {
            get { return dateTime_3; }
            set
            {
                if (dateTime_3 != value)
                {
                    SendPropertyChanging();
                    dateTime_3 = value;
                    SendPropertyChanged("REBirthdayTime");
                }
            }
        }
        /// <summary>
        /// 招商人注册日期
        /// </summary>
        public DateTime? REAddTime
        {
            get { return dateTime_2; }
            set
            {
                if (dateTime_2 != value)
                {
                    SendPropertyChanging();
                    dateTime_2 = value;
                    SendPropertyChanged("REAddTime");
                }
            }
        }
        /// <summary>
        /// 招商人用户编号
        /// </summary>
        public string REMemLoginNO
        {
            get { return string_13; }
            set
            {
                if (string_13 != value)
                {
                    SendPropertyChanging();
                    string_13 = value;
                    SendPropertyChanged("REMemLoginNO");
                }
            }
        }
        /// <summary>
        /// 招商人姓名
        /// </summary>
        public string RERealName
        {
            get { return string_12; }
            set
            {
                if (string_12 != value)
                {
                    SendPropertyChanging();
                    string_12 = value;
                    SendPropertyChanged("RERealName");
                }
            }
        }
        /// <summary>
        /// 会员身份证附件地址
        /// </summary>
        public string IdentityCardImage
        {
            get { return string_11; }
            set
            {
                if (string_11 != value)
                {
                    SendPropertyChanging();
                    string_11 = value;
                    SendPropertyChanged("IdentityCardImage");
                }
            }
        }
        /// <summary>
        /// 曾从事职业
        /// </summary>
        public string Occupation
        {
            get { return string_10; }
            set
            {
                if (string_10 != value)
                {
                    SendPropertyChanging();
                    string_10 = value;
                    SendPropertyChanged("Occupation");
                }
            }
        }
        /// <summary>
        /// 会员拟申办区县代理的地址 省  市  区
        /// </summary>
        public string Area
        {
            get { return string_9; }
            set
            {
                if (string_9 != value)
                {
                    SendPropertyChanging();
                    string_9 = value;
                    SendPropertyChanged("Area");
                }
            }
        }
        /// <summary>
        /// 会员业务分部区域1 2 3 4
        /// </summary>
        public string BusinessArea
        {
            get { return string_8; }
            set
            {
                if (string_8 != value)
                {
                    SendPropertyChanging();
                    string_8 = value;
                    SendPropertyChanged("BusinessArea");
                }
            }
        }
        /// <summary>
        /// 会员居住地址
        /// </summary>
        public string Adress
        {
            get { return string_7; }
            set
            {
                if (string_7 != value)
                {
                    SendPropertyChanging();
                    string_7 = value;
                    SendPropertyChanged("Adress");
                }
            }
        }
        /// <summary>
        /// 会员手机
        /// </summary>
        public string Mobile
        {
            get { return string_6; }
            set
            {
                if (string_6 != value)
                {
                    SendPropertyChanging();
                    string_6 = value;
                    SendPropertyChanged("Mobile");
                }
            }
        }
        /// <summary>
        /// 会员电话
        /// </summary>
        public string Phone
        {
            get { return string_5; }
            set
            {
                if (string_5 != value)
                {
                    SendPropertyChanging();
                    string_5 = value;
                    SendPropertyChanged("Phone");
                }
            }
        }
        /// <summary>
        /// 会员性别
        /// </summary>
        public string Sex
        {
            get { return string_4; }
            set
            {
                if (string_4 != value)
                {
                    SendPropertyChanging();
                    string_4 = value;
                    SendPropertyChanged("Sex");
                }
            }
        }
        /// <summary>
        /// 会员身份证号
        /// </summary>
        public string IdentityCard
        {
            get { return string_3; }
            set
            {
                if (string_3 != value)
                {
                    SendPropertyChanging();
                    string_3 = value;
                    SendPropertyChanged("IdentityCard");
                }
            }
        }
        /// <summary>
        /// 会员生日
        /// </summary>
        public DateTime? BirthdayTime
        {
            get { return dateTime_1; }
            set
            {
                if (dateTime_1 != value)
                {
                    SendPropertyChanging();
                    dateTime_1 = value;
                    SendPropertyChanged("BirthdayTime");
                }
            }
        }
        /// <summary>
        /// 注册日期
        /// </summary>
        public DateTime? AddDate
        {
            get { return dateTime_0; }
            set
            {
                if (dateTime_0 != value)
                {
                    SendPropertyChanging();
                    dateTime_0 = value;
                    SendPropertyChanged("AddDate");
                }
            }
        }
        /// <summary>
        /// 用户姓名
        /// </summary>
        public string RealName
        {
            get { return string_2; }
            set
            {
                if (string_2 != value)
                {
                    SendPropertyChanging();
                    string_2 = value;
                    SendPropertyChanged("RealName");
                }
            }
        }


        /// <summary>
        /// 用户编号
        /// </summary>
        public string MemLoginNO
        {
            get { return string_1; }
            set
            {
                if (string_1 != value)
                {
                    SendPropertyChanging();
                    string_1 = value;
                    SendPropertyChanged("MemLoginNO");
                }
            }
        }



        /// <summary>
        /// 自增区代申请表编号
        /// </summary>
        public int MembershipID
        {
            get { return int_0; }
            set
            {
                if (int_0 != value)
                {
                    SendPropertyChanging();
                    int_0 = value;
                    SendPropertyChanged("MembershipID");
                }
            }
        }
        /// <summary>
        /// 区代申请表状态 0-申请  1-通过   2-拒绝
        /// </summary>
        public int ShipStatus
        {
            get { return int_1; }
            set
            {
                if (int_1 != value)
                {
                    SendPropertyChanging();
                    int_1 = value;
                    SendPropertyChanged("ShipStatus");
                }
            }
        }
        /// <summary>
        /// 会员编号
        /// </summary>
        public string MemLoginID
        {
            get { return string_0; }
            set
            {
                if (string_0 != value)
                {
                    SendPropertyChanging();
                    string_0 = value;
                    SendPropertyChanged("MemLoginID");
                }
            }
        }

        //现在的会员等级
        public string LastRankID
        {
            get { return guid_0; }
            set
            {
                if (guid_0 != value)
                {
                    SendPropertyChanging();
                    guid_0 = value;
                    SendPropertyChanged("LastRankID");
                }
            }
        }
        //申请的会员等级
        public string NewRankID
        {
            get { return guid_1; }
            set
            {
                if (guid_1 != value)
                {
                    SendPropertyChanging();
                    guid_1 = value;
                    SendPropertyChanged("NewRankID");
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
