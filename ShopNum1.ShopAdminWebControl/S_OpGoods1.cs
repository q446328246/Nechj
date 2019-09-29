using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;

namespace ShopNum1.ShopAdminWebControl
{
    [ParseChildren(true)]
    public class S_OpGoods1 : BaseShopWebControl
    {
        public static DataTable dt_Provalue = null;
        public static DataTable dt_Specvalue = null;

        private readonly ShopNum1_ShopProductProp_Action shopNum1_ShopProductProp_Action_0 =
            ((ShopNum1_ShopProductProp_Action) LogicFactory.CreateShopNum1_ShopProductProp_Action());

        private readonly ShopNum1_Spec_Action shopNum1_Spec_Action_0 = new ShopNum1_Spec_Action();
        private HtmlInputHidden hidCategoryName;
        private HiddenField hidSetsp;
        private Repeater repStockSet;

        private string skinFilename = "S_OpGoods1.ascx";
        private string string_1 = string.Empty;
        private string string_2 = string.Empty;

        public S_OpGoods1()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public static DataTable dt_SubPropv(string strPropID)
        {
            var action = new ShopNum1_ShopProductPropValue_Action();
            return action.dt_SubProp(strPropID, Common.Common.ReqStr("pid"));
        }

        public static DataTable dt_SubSpecv(string strSpecID)
        {
            var action = new ShopNum1_Spec_Action();
            return action.dt_SubSpec(strSpecID, Common.Common.ReqStr("pid"));
        }

        protected override void InitializeSkin(Control skin)
        {
            repStockSet = (Repeater) skin.FindControl("repStockSet");
            string_1 = Common.Common.ReqStr("pid");
            string_2 = Common.Common.ReqStr("ctype");
            hidSetsp = (HiddenField) skin.FindControl("hidSetsp");
            hidCategoryName = (HtmlInputHidden) skin.FindControl("hidCategoryName");
            new ShopNum1_CategoryType_Action();
            if (!Page.IsPostBack)
            {
                BindData();
                method_1();
                //if ((string_1 != "0") && (string_1 != ""))
                //{
                //    repStockSet.DataSource =
                //        ((ShopNum1_SpecProudct_Action) LogicFactory.CreateShopNum1_SpecProudct_Action()).dt_SpecProducts
                //            (string_1, string_2, "");
                //    repStockSet.DataBind();
                //}
                string threeType =
                    ((ShopNum1_ProductCategory_Action) LogicFactory.CreateShopNum1_ProductCategory_Action())
                        .GetThreeType(Common.Common.ReqStr("code"));
                if (threeType == "")
                {
                    threeType = "请重新选择分类";
                }
                hidCategoryName.Value = threeType;
            }
        }

        protected void BindData()
        {
            if ((string_2 != "0") || (string_2 != ""))
            {
                string str = Common.Common.ReqStr("ctype");
                if (!string.IsNullOrEmpty(str))
                {
                    dt_Specvalue = shopNum1_Spec_Action_0.dt_GetSp(str);
                    if (dt_Specvalue.Rows.Count == 0)
                    {
                        dt_Specvalue = null;
                    }
                }
            }
        }

        protected void method_1()
        {
            if ((string_2 != "0") || (string_2 != ""))
            {
                string str = Common.Common.ReqStr("ctype");
                if (!string.IsNullOrEmpty(str))
                {
                    dt_Provalue = shopNum1_ShopProductProp_Action_0.dt_GetPro(str);
                }
            }
        }
    }
}