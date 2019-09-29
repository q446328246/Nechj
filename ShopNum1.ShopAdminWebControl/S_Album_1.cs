using System.Data;
using System.Web.UI;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;

namespace ShopNum1.ShopAdminWebControl
{
    [ParseChildren(true)]
    public class S_Album_1 : BaseShopWebControl
    {
        public static DataTable dt_Album = null;
        private string skinFilename = "S_Album_1.ascx";
        private string string_1;

        public S_Album_1()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        protected override void InitializeSkin(Control skin)
        {
            string_1 = Common.Common.ReqStr("sort");
            if (!Page.IsPostBack)
            {
                if (Common.Common.ReqStr("typeid") != "")
                {
                    BindData();
                }
                method_1();
            }
        }

        protected void BindData()
        {
            new Shop_ImageCategory_Action().Delete(Common.Common.ReqStr("typeid"));
        }

        protected void method_1()
        {
            dt_Album = new Shop_ImageCategory_Action().Select(string_1, base.MemLoginID);
        }
    }
}