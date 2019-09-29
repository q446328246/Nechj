using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;

namespace ShopNum1.WebControl
{
    [ParseChildren(true)]
    public class AgentCountOfArea : BaseWebControl
    {
        private Repeater RepeaterData;
        protected char charSapce = '　';
        private string skinFilename = "AgentCountOfArea.ascx";
        protected string strSapce = "　　";

        public AgentCountOfArea()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        protected override void InitializeSkin(Control skin)
        {
            RepeaterData = (Repeater) skin.FindControl("RepeaterData");
            BindData();
        }

        protected void BindData()
        {
            DataTable table =
                ((ShopNum1_Member_Action) LogicFactory.CreateShopNum1_Member_Action()).SearchAgentCountOfAreacode();
            if ((table != null) && (table.Rows.Count > 0))
            {
                RepeaterData.DataSource = table;
                RepeaterData.DataBind();
            }
        }
    }
}