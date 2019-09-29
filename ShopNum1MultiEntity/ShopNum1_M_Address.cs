using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Data;

namespace ShopNum1MultiEntity
{
	public class ShopNum1_M_Address : INotifyPropertyChanging, INotifyPropertyChanged
	{
        private static readonly PropertyChangingEventArgs propertyChangingEventArgs_0 =
           new PropertyChangingEventArgs(string.Empty);

        public virtual string Address { get; set; }

        public virtual string AddressCode { get; set; }

        public virtual string AddressValue { get; set; }

        public virtual string Area { get; set; }

        public virtual string CreateTime { get; set; }

        public virtual string CreateUser { get; set; }

        public virtual string Email { get; set; }

        public virtual object Guid { get; set; }

        public virtual int IsDefault { get; set; }

        public virtual int IsDeleted { get; set; }

        public virtual string MemLoginID { get; set; }

        public virtual string Mobile { get; set; }

        public virtual string ModifyTime { get; set; }

        public virtual string ModifyUser { get; set; }

        public virtual string Name { get; set; }

        public virtual string Postalcode { get; set; }

        public virtual string Tel { get; set; } 



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

        public static List<ShopNum1_M_Address> FromDataRowGetAddressByMemloginID(DataTable table)
        {
            List<ShopNum1_M_Address> Address = new List<ShopNum1_M_Address>();
            foreach (DataRow row in table.Rows)
            {
                ShopNum1_M_Address M_address=new ShopNum1_M_Address ();
                M_address.Address = Convert.ToString(row["Address"]);
                M_address.AddressCode = Convert.ToString(row["AddressCode"]);
                M_address.AddressValue = Convert.ToString(row["AddressValue"]);
                M_address.Area = Convert.ToString(row["Area"]);
                M_address.CreateTime = Convert.ToString(row["CreateTime"]);
                M_address.CreateUser = Convert.ToString(row["CreateUser"]);
                M_address.Email = Convert.ToString(row["Email"]);
                M_address.Guid = Convert.ToString(row["Guid"]);
                M_address.IsDefault = Convert.ToInt32(row["IsDefault"]);
                M_address.IsDeleted = Convert.ToInt32(row["IsDeleted"]);
                M_address.MemLoginID = Convert.ToString(row["MemLoginID"]);
                M_address.Mobile = Convert.ToString(row["Mobile"]);
                M_address.ModifyTime = Convert.ToString(row["ModifyTime"]);
                M_address.ModifyUser = Convert.ToString(row["ModifyUser"]);
                M_address.Name = Convert.ToString(row["Name"]);
                M_address.Tel = Convert.ToString(row["Tel"]);
                M_address.Postalcode = Convert.ToString(row["Postalcode"]);
                Address.Add(M_address);
            }
            return Address;
        }
	}
}
