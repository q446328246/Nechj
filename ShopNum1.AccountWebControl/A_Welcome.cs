using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;

namespace ShopNum1.AccountWebControl
{
    [ParseChildren(true)]
    public class A_Welcome : BaseMemberWebControl
    {
        private Repeater Rep_AoccountDetail;
        private string skinFilename = "A_Welcome.cs";

        public A_Welcome()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        protected override void InitializeSkin(Control skin)
        {
            Rep_AoccountDetail = (Repeater) skin.FindControl("Rep_AoccountDetail");
            if (!Page.IsPostBack)
            {
                method_0();
            }
        }

        private void method_0()
        {
            DataTable memberAccount =
                ((ShopNum1_Member_Action) LogicFactory.CreateShopNum1_Member_Action()).GetMemberAccount(base.MemLoginID);
            try
            {
                if (memberAccount.Rows.Count > 0)
                {
                    Rep_AoccountDetail.DataSource = memberAccount;
                    Rep_AoccountDetail.DataBind();
                }
            }
            catch
            {
            }
        }
    }
}