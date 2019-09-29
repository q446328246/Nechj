using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;

namespace ShopNum1.MemberWebControl
{
    [ParseChildren(true)]
    public class M_ComplaintsDetailed : BaseMemberWebControl
    {
        private Button ButtonBackList;
        private Repeater RepeaterShow;
        private string skinFilename = "M_ComplaintsDetailed.ascx";

        public M_ComplaintsDetailed()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

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

        private void ButtonBackList_Click(object sender, EventArgs e)
        {
            Page.Response.Redirect("M_Complaints.aspx");
        }

        protected override void InitializeSkin(Control skin)
        {
            RepeaterShow = (Repeater) skin.FindControl("RepeaterShow");
            ButtonBackList = (Button) skin.FindControl("ButtonBackList");
            ButtonBackList.Click += ButtonBackList_Click;
            if (Page.Request.QueryString["ID"] != null)
            {
                BindData(Page.Request.QueryString["ID"]);
            }
        }
    }
}