using System.Data;
using System.Web.UI;
using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;

namespace ShopNum1.ShopWebControl
{
    [ParseChildren(true)]
    public class ProductProp : BaseWebControl
    {
        public static DataTable dt_Prop = null;
        private string skinFilename = "ProductProp.ascx";

        public ProductProp()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        protected string guid { get; set; }

        public static DataTable dt_SubPropv(string strPropID)
        {
            var action = (ShopNum1_ShopProRelateProp_Action) LogicFactory.CreateShopNum1_ShopProRelateProp_Action();
            return action.SelectPropByIdAndPid(strPropID, Common.Common.ReqStr("guid"));
        }

        public static string GetPropValue(string strID)
        {
            var action = new ShopNum1_ShopProductPropValue_Action();
            return action.GetPropValue(strID);
        }

        protected override void InitializeSkin(Control skin)
        {
            string text1 = (Page.Request.QueryString["ShopID"] == null) ? "0" : Page.Request.QueryString["ShopID"];
            if (!Page.IsPostBack)
            {
                guid = (Page.Request.QueryString["guid"] == null) ? "-1" : Page.Request.QueryString["guid"];
                if (guid != "-1")
                {
                    BindData();
                }
            }
        }

        protected void BindData()
        {
            dt_Prop =
                ((ShopNum1_ShopProductProp_Action) LogicFactory.CreateShopNum1_ShopProductProp_Action())
                    .SelectProByProductGuid(guid);
        }
    }
}