using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Data;

namespace ShopNum1MultiEntity
{

    public class KCENoticeContent : INotifyPropertyChanging, INotifyPropertyChanged
    {
        //public class LoginResult
        //{
        private static readonly PropertyChangingEventArgs propertyChangingEventArgs_0 =
       new PropertyChangingEventArgs(string.Empty);


        private string remark;

        public string Remark
        {
            get { return remark; }
            set { remark = value; }
        }
        private string createUser;

        public string CreateUser
        {
            get { return createUser; }
            set { createUser = value; }
        }
        private string createTime;

        public string CreateTime
        {
            get { return createTime; }
            set { createTime = value; }
        }
        private string title;

        public string Title
        {
            get { return title; }
            set { title = value; }
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

        public static KCENoticeContent FromDataRow1(DataRow row)
        {
            KCENoticeContent M_Member = new KCENoticeContent();
            M_Member.Title = row["Title"].ToString();
            M_Member.Remark = row["Remark"].ToString();
            M_Member.CreateUser = row["CreateUser"].ToString();
            M_Member.CreateTime = row["CreateTime"].ToString();

            return M_Member;
        }

    }
}
