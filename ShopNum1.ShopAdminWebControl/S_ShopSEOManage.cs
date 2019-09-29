using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.Factory;
using ShopNum1.Interface;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;

namespace ShopNum1.ShopAdminWebControl
{
    [ParseChildren(true)]
    public class S_ShopSEOManage : BaseShopWebControl
    {
        private Repeater RepeaterShow;
        private string skinFilename = "S_ShopSEOManage.ascx";

        public S_ShopSEOManage()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public string xmlmetopath { get; set; }

        public void GetData()
        {
            IShopNum1_ExtendSiteMota_Action action = LogicFactory.CreateShopNum1_ExtendSiteMota_Action();
            DataTable memLoginInfo =
                ((Shop_ShopInfo_Action) ShopFactory.LogicFactory.CreateShop_ShopInfo_Action()).GetMemLoginInfo(
                    base.MemLoginID);
            string str = memLoginInfo.Rows[0]["ShopID"].ToString();
            string str2 = DateTime.Parse(memLoginInfo.Rows[0]["OpenTime"].ToString()).ToString("yyyy-MM-dd");
            xmlmetopath = "~/Shop/Shop/" + str2.Replace("-", "/") + "/shop" + str + "/xml/SetMeto.xml";
            DataTable table2 = action.SearchMetoList("", xmlmetopath);
            if ((table2 != null) && (table2.Rows.Count > 0))
            {
                RepeaterShow.DataSource = table2.DefaultView;
                RepeaterShow.DataBind();
            }
        }

        protected override void InitializeSkin(Control skin)
        {
            RepeaterShow = (Repeater) skin.FindControl("RepeaterShow");
            GetData();
        }
    }
}