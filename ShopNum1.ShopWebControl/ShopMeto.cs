using System;
using System.Data;
using System.Web.UI;
using ShopNum1.BusinessLogic;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;

namespace ShopNum1.ShopWebControl
{
    [ParseChildren(true)]
    public class ShopMeto : BaseWebControl
    {
        private string skinFilename = "ShopMeto.ascx";

        public ShopMeto()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        protected string SetPath { get; set; }

        protected string ShopID { get; set; }

        protected override void InitializeSkin(Control skin)
        {
            ShopID = (Page.Request.QueryString["ShopID"] == null) ? "0" : Page.Request.QueryString["ShopID"];
            if (ShopID != "0")
            {
                DataTable openTimeByShopID =
                    ((Shop_ShopInfo_Action) LogicFactory.CreateShop_ShopInfo_Action()).GetOpenTimeByShopID(ShopID);
                if ((openTimeByShopID != null) && (openTimeByShopID.Rows.Count > 0))
                {
                    string str = DateTime.Parse(openTimeByShopID.Rows[0]["OpenTime"].ToString()).ToString("yyyy-MM-dd");
                    SetPath = "~/Shop/Shop/" + str.Replace("-", "/") + "/Shop" + ShopID + "/xml/SetMeto.xml";
                }
            }
        }

        protected override void Render(HtmlTextWriter writer)
        {
            string str = string.Empty;
            string physicalPath = Page.Request.PhysicalPath;
            string pageName = physicalPath.Substring(physicalPath.LastIndexOf(@"\") + 1);
            DataTable table = SelectByID(pageName);
            if ((table == null) || (table.Rows.Count == 0))
            {
                str = (("\n<title>" + string.Empty + "</title>\r\n") + "<meta name=keywords content=\"" +
                       string.Empty + "\">\r\n") + "<meta name=\"description\" content=\"" +
                      string.Empty + "\">\r\n";
            }
            else
            {
                str = "\n<title>" + table.Rows[0]["Title"] + string.Empty + "</title>\r\n";
                str = str + "<meta name=keywords content=\"" + table.Rows[0]["KeyWords"] + string.Empty +
                      "\">\r\n";
                str = str + "<meta name=\"description\" content=\"" + table.Rows[0]["Description"] +
                      string.Empty + "\">\r\n";
            }
            writer.Write(str);
        }

        public DataTable SelectByID(string PageName)
        {
            var action = (ShopNum1_ExtendSiteMota_Action) Factory.LogicFactory.CreateShopNum1_ExtendSiteMota_Action();
            return action.SelectByName(PageName, SetPath);
        }
    }
}