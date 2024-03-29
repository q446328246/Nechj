using System;
using System.Data;
using ShopNum1.BusinessLogic;
using ShopNum1.Deploy.App_Code;
using ShopNum1.Factory;

namespace ShopNum1.Deploy.Main.Member.Skin
{
    public partial class M_SupplyDemandCommentDetail : BaseMemberControl
    {
        protected void ButtonGoBack_Click(object sender, EventArgs e)
        {
            Page.Response.Redirect("M_Comment.aspx?type=0&pageid=1");
        }

        public void GetData(string guid)
        {
            DataTable table =
                ((ShopNum1_SupplyDemandComment_Action) LogicFactory.CreateShopNum1_SupplyDemandComment_Action())
                    .SearchByGuid("'" + guid + "'");
            if ((table != null) && (table.Rows.Count > 0))
            {
                RepeaterShow.DataSource = table.DefaultView;
                RepeaterShow.DataBind();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.Request.QueryString["guid"] != null)
            {
                GetData(Page.Request.QueryString["guid"]);
            }
        }
    }
}