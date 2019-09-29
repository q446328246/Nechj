using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace ShopNum1.Deploy.Main
{
    public partial class _404 : System.Web.UI.Page
    {
        public string url;
        protected void Page_Load(object sender, EventArgs e)
        {
            var dataSet = new DataSet();
            dataSet.ReadXml(HttpContext.Current.Server.MapPath("~/Settings/ShopSetting.xml"));
            DataRow dataRow = dataSet.Tables["ShopSetting"].Rows[0];
            string INDEXURL = dataRow["CopyrightLink"].ToString();
            url = INDEXURL;

        }
    }
}