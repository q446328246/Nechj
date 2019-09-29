using System;
using System.Data;
using ShopNum1.BusinessLogic;
using ShopNum1.Deploy.App_Code;
using ShopNum1.Factory;

namespace ShopNum1.Deploy.Main.Account.Skin
{
    public partial class A_Welcome : BaseMemberControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindData();
            }
        }

        private void BindData()
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