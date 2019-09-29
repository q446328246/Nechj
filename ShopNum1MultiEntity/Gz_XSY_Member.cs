using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Data;

namespace ShopNum1MultiEntity
{
    public class Gz_XSY_Member : INotifyPropertyChanging, INotifyPropertyChanged
    {
        private static readonly PropertyChangingEventArgs propertyChangingEventArgs_0 =
       new PropertyChangingEventArgs(string.Empty);

        private string memLoginID;

        public string MemLoginID
        {
            get { return memLoginID; }
            set { memLoginID = value; }
        }

        private string email;

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        private string identityCard;

        public string IdentityCard
        {
            get { return identityCard; }
            set { identityCard = value; }
        }
        private string realName;

        public string RealName
        {
            get { return realName; }
            set { realName = value; }
        }

        private string sex;

        public string Sex
        {
            get { return sex; }
            set { sex = value; }
        }

        private string mobile;

        public string Mobile
        {
            get { return mobile; }
            set { mobile = value; }
        }
           private string superior;
        public string Superior
        {
            get { return superior; }
            set { superior = value; }
        }

        private string photo;
        public string Photo
        {
            get { return photo; }
            set { photo = value; }
        }

        private string memberCate;
        public string MemberCate
        {
            get { return memberCate; }
            set { memberCate = value; }
        }

        public static Gz_XSY_Member FromDataRow(DataRow row)
        {
            Gz_XSY_Member M_Member = new Gz_XSY_Member();
            M_Member.MemLoginID = row["MemLoginID"].ToString();
            M_Member.Email = row["Email"].ToString();
            M_Member.IdentityCard = row["IdentityCard"].ToString();
            M_Member.RealName = row["RealName"].ToString();
            M_Member.Sex = row["Sex"].ToString();
            M_Member.Mobile = row["Mobile"].ToString();
            M_Member.Superior = row["Superior"].ToString();
             string str =row["Photo"].ToString();
             M_Member.Photo = str.Replace("/ImgUpload/", "http://www.tj88.ren/ImgUpload/");
             M_Member.MemberCate = row["MemberCate"].ToString();
            return M_Member;
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
