using System;
using System.Data;
using System.Web.SessionState;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class ShopCategoryAply_SearchDetail : PageBase, IRequiresSessionState
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                base.CheckLogin();
                string str = Page.Request.QueryString["Guid"].Replace("'", "");
                DataTable shopCategoryInfoByGuid =
                    ((ShopNum1_ShopInfoList_Action) LogicFactory.CreateShopNum1_ShopInfoList_Action())
                        .GetShopCategoryInfoByGuid("'" + str + "'");
                TextBoxShopName.Text = shopCategoryInfoByGuid.Rows[0]["ShopName"].ToString();
                TextBoxMemberLoginID.Text = shopCategoryInfoByGuid.Rows[0]["ShopID"].ToString();
                TextBoxOldShopCategory.Text = shopCategoryInfoByGuid.Rows[0]["OldShopCategoryName"].ToString();
                TextBoxOldShopBrand.Text = shopCategoryInfoByGuid.Rows[0]["OldBrandName"].ToString();
                TextBoxShopApplyCategory.Text = shopCategoryInfoByGuid.Rows[0]["ShopCategoryName"].ToString();
                TextBoxShopApplyBrand.Text = shopCategoryInfoByGuid.Rows[0]["BrandName"].ToString();
                TextBoxApplyTime.Text = shopCategoryInfoByGuid.Rows[0]["ApplyTime"].ToString();
                TextBoxComment.Text = shopCategoryInfoByGuid.Rows[0]["Remarks"].ToString();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        protected void ButtonBack_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("ShopCategoryAply_Audit.aspx");
        }
    }
}