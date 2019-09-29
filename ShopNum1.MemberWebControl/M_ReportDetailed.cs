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
    public class M_ReportDetailed : BaseMemberWebControl
    {
        private Button ButtonBackList;
        private Repeater RepeaterShow;
        private string skinFilename = "M_ReportDetailed.ascx";

        public M_ReportDetailed()
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

        private void ButtonBackList_Click(object sender, EventArgs e)
        {
            Page.Response.Redirect("M_MyReport.aspx");
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