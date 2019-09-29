using System;
using System.Data;
using ShopNum1.BusinessLogic;
using ShopNum1.Deploy.App_Code;
using ShopNum1.Factory;

namespace ShopNum1.Deploy.Main.Member.Skin
{
    public partial class M_ComplaintsDetailed : BaseMemberControl
    {
        public void BindData(string ID)
        {
            DataTable table =
                ((ShopNum1_OrderComplaintsReplyList_Action)
                    LogicFactory.CreateShopNum1_OrderComplaintsReplyList_Action()).SearchComplaint(ID);
            if ((table != null) && (table.Rows.Count > 0))
            {
                RepeaterShow.DataSource = table.DefaultView;
                RepeaterShow.DataBind();
            }
        }

        protected void ButtonBackList_Click(object sender, EventArgs e)
        {
            Page.Response.Redirect("M_Complaints.aspx");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.Request.QueryString["ID"] != null)
            {
                BindData(Page.Request.QueryString["ID"]);
            }
        }
    }
}