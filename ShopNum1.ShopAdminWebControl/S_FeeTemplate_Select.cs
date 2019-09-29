using System;
using System.Data;
using System.Web.UI;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopFactory;
using ShopNum1.ShopFeeTemplate;

namespace ShopNum1.ShopAdminWebControl
{
    [ParseChildren(true)]
    public class S_FeeTemplate_Select : BaseShopWebControl
    {
        public static DataTable dt_FeeTemplate = null;
        private string skinFilename = "S_FeeTemplate_Select.ascx";

        public S_FeeTemplate_Select()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        protected override void InitializeSkin(Control skin)
        {
            var action = new Shop_FeeTemplate_Action();
            DataTable shopIDAndOpenTimeByMemLoginID =
                LogicFactory.CreateShop_ShopInfo_Action().GetShopIDAndOpenTimeByMemLoginID(base.MemLoginID);
            if ((shopIDAndOpenTimeByMemLoginID != null) && (shopIDAndOpenTimeByMemLoginID.Rows.Count > 0))
            {
                string str =
                    DateTime.Parse(shopIDAndOpenTimeByMemLoginID.Rows[0]["OpenTime"].ToString()).ToString("yyyy-MM-dd");
                string str2 = shopIDAndOpenTimeByMemLoginID.Rows[0]["ShopID"].ToString();
                string str3 = str.Split(new[] {'-'})[0];
                string str4 = str.Split(new[] {'-'})[1];
                string str5 = str.Split(new[] {'-'})[2];
                string path = "~/Shop/Shop/" + str3 + "/" + str4 + "/" + str5 + "/shop" + str2 +
                              "/xml/PostageTemplate.xml";
                string strerror = string.Empty;
                DataTable table = action.GetFeesByIDRegion(Page.Server.MapPath(path), "-1", "000", "-1", out strerror);
                if (table != null)
                {
                    dt_FeeTemplate = new DataView(table).ToTable(true,
                        new[] {"templateid", "templatename", "createtime"});
                }
            }
        }
    }
}