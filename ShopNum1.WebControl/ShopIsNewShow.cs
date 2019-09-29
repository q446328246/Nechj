using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;

namespace ShopNum1.WebControl
{
    [ParseChildren(true)]
    public class ShopIsNewShow : BaseWebControl
    {
        private Repeater RepeaterData;
        private string skinFilename = "ShopIsNewShow.ascx";

        public ShopIsNewShow()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public string ShowCount { get; set; }

        protected override void InitializeSkin(Control skin)
        {
            RepeaterData = (Repeater) skin.FindControl("RepeaterData");
            BindData();
        }

        protected void BindData()
        {
            DataTable newShopInfoByShowCount =
                ((ShopNum1_ShopInfoList_Action) LogicFactory.CreateShopNum1_ShopInfoList_Action())
                    .GetNewShopInfoByShowCount(ShowCount);
            if ((newShopInfoByShowCount != null) && (newShopInfoByShowCount.Rows.Count > 0))
            {
                RepeaterData.DataSource = newShopInfoByShowCount.DefaultView;
                RepeaterData.DataBind();
            }
        }
    }
}