using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;

namespace ShopNum1.ShopAdminWebControl
{
    [ParseChildren(true)]
    public class S_ReportDetailed : BaseShopWebControl
    {
        private Button ButtonBackList;
        private Repeater RepeaterShow;
        private string skinFilename = "S_ReportDetailed.ascx";

        public S_ReportDetailed()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public void BindData(string ID)
        {
            DataTable reportDetailByID =
                ((ShopNum1_MemberReport_Action) LogicFactory.CreateShopNum1_MemberReport_Action()).GetReportDetailByID(
                    ID);
            if ((reportDetailByID != null) && (reportDetailByID.Rows.Count > 0))
            {
                RepeaterShow.DataSource = reportDetailByID.DefaultView;
                RepeaterShow.DataBind();
            }
        }

        protected void ButtonBackList_Click(object sender, EventArgs e)
        {
            Page.Response.Redirect("S_MemberReport.aspx");
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