using System;
using System.Data;
using ShopNum1.BusinessLogic;
using ShopNum1.Deploy.App_Code;
using ShopNum1.Factory;

namespace ShopNum1.Deploy.Main.Member.Skin
{
    public partial class M_ReportDetailed : BaseMemberControl
    {
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
            Page.Response.Redirect("M_MyReport.aspx");
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