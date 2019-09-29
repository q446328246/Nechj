using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;

namespace ShopNum1.ShopNewWebControl
{
    [ParseChildren(true)]
    public class ProductPropV82 : BaseWebControl
    {
        public static DataTable dt_Prop = null;
        private HtmlGenericControl divDetials;
        private HtmlGenericControl divInstrunction;
        private string skinFilename = "ProductPropV82.ascx";

        public ProductPropV82()
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
            divInstrunction = (HtmlGenericControl) skin.FindControl("divInstrunction");
            divDetials = (HtmlGenericControl) skin.FindControl("divDetials");
            string text1 = (Page.Request.QueryString["ShopID"] == null) ? "0" : Page.Request.QueryString["ShopID"];
            guid = (Page.Request.QueryString["guid"] == null) ? "-1" : Page.Request.QueryString["guid"];
            if (guid != "-1")
            {
                BindData();
            }
        }

        protected void BindData()
        {
            dt_Prop =
                ((ShopNum1_ShopProductProp_Action) LogicFactory.CreateShopNum1_ShopProductProp_Action())
                    .SelectProByProductGuid(guid);
            DataTable table = Common.Common.GetTableById("Instruction,Detail", "shopnum1_shop_product",
                " And GuId='" + guid + "'");
            if (table.Rows.Count > 0)
            {
                divInstrunction.InnerHtml = table.Rows[0]["Instruction"].ToString();
                divDetials.InnerHtml = table.Rows[0]["Detail"].ToString();
            }
        }
    }
}