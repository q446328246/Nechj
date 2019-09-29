using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Configuration;

namespace ShopNum1.Deploy.Service
{
    /// <summary>
    /// BackspaceString 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
     [System.Web.Script.Services.ScriptService]
    public class BackspaceString : System.Web.Services.WebService
    {

        [WebMethod]
        public void BackspaceString_two()
        {
            string VersionNumber = ConfigurationManager.AppSettings["VersionNumber"];

            string Path = ConfigurationManager.AppSettings["Path"];


            Producthow product = new Producthow();
            product.Version = VersionNumber;
            product.Path = Path;
            // Serialize(ContentType);

            Context.Response.Write(ServiceHelper.GetJSON<Producthow>(product));
            Context.Response.End();
        }


       


       
    }

    public class Producthow
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
    }
}
