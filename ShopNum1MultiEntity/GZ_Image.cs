using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Data;

namespace ShopNum1MultiEntity
{
    public class GZ_Image : INotifyPropertyChanging, INotifyPropertyChanged
    {
        private static readonly PropertyChangingEventArgs propertyChangingEventArgs_0 =
            new PropertyChangingEventArgs(string.Empty);
        private string string_0;
        private string string_1;
        private string string_2;
        private string string_3;

        public string Image4
        {
            get { return string_0; }
            set
            {
                if (string_0 != value)
                {
                    SendPropertyChanging();
                    string_0 = value;
                    SendPropertyChanged("Image4");
                }
            }
        }
        public string Image3
        {
            get { return string_3; }
            set
            {
                if (string_3 != value)
                {
                    SendPropertyChanging();
                    string_3 = value;
                    SendPropertyChanged("Image3");
                }
            }
        }

        public string Image2
        {
            get { return string_2; }
            set
            {
                if (string_2 != value)
                {
                    SendPropertyChanging();
                    string_2 = value;
                    SendPropertyChanged("Image2");
                }
            }
        }
        public string Image1
        {
            get { return string_1; }
            set
            {
                if (string_1 != value)
                {
                    SendPropertyChanging();
                    string_1 = value;
                    SendPropertyChanged("Image1");
                }
            }
        }


        public static List<GZ_Image> FromDataRow(GZ_Image row)
        {
            List<GZ_Image> All_Entity = new List<GZ_Image>();

            GZ_Image Entity = new GZ_Image();

            Entity.Image1 = Convert.ToString(row.Image1);
            Entity.Image2 = Convert.ToString(row.Image2);
            Entity.Image3 = Convert.ToString(row.Image3);
            Entity.Image4 = Convert.ToString(row.Image4);




            All_Entity.Add(Entity);



            return All_Entity;
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
