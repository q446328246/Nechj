using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopNum1.Deploy.Service
{
    public class ProductShow
    {
        private string version;

        public string Version
        {
            get { return version; }
            set { version = value; }
        }
        private string path;

        public string Path
        {
            get { return path; }
            set { path = value; }
        }
        private string updeModel;

        public string UpdeModel
        {
            get { return updeModel; }
            set { updeModel = value; }
        }
        private string versionNumber2;

        public string VersionNumber2
        {
            get { return versionNumber2; }
            set { versionNumber2 = value; }
        }
        private string address;

        public string Address
        {
            get { return address; }
            set { address = value; }
        }


        public static List<ProductShow> FromDataRowVer(ProductShow row)
        {
            List<ProductShow> All_Entity = new List<ProductShow>();

            ProductShow Entity = new ProductShow();

            Entity.Version = Convert.ToString(row.Version);
            Entity.Path = Convert.ToString(row.Path);
            Entity.UpdeModel = Convert.ToString(row.UpdeModel);
            Entity.VersionNumber2 = Convert.ToString(row.VersionNumber2);
            Entity.Address = Convert.ToString(row.Address);



            All_Entity.Add(Entity);



            return All_Entity;
        }
    }
}