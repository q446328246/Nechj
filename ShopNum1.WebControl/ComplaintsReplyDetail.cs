using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;

namespace ShopNum1.WebControl
{
    [ParseChildren(true)]
    public class ComplaintsReplyDetail : BaseWebControl
    {
        private Repeater RepeaterData;
        private string skinFilename = "ComplaintsReplyDetail.ascx";

        public ComplaintsReplyDetail()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public string strGuid { get; set; }

        protected override void InitializeSkin(Control skin)
        {
            if (Page.Request.Cookies["MemberLoginCookie"] == null)
            {
                Page.Response.Write("<script> window.alert(\"对不起，请重新登陆！\");  window.location.href='Login.aspx'</script>");
            }
            RepeaterData = (Repeater) skin.FindControl("RepeaterData");
            strGuid = (Page.Request.QueryString["guid"] == null) ? "0" : Page.Request.QueryString["guid"];
            BindData();
        }

        protected void BindData()
        {
            DataSet complaintsManagementDetail =
                ((ShopNum1_ComplaintsManagement_Action) LogicFactory.CreateShopNum1_ComplaintsManagement_Action())
                    .GetComplaintsManagementDetail(strGuid);
            if (complaintsManagementDetail.Tables[0].Rows.Count > 0)
            {
                RepeaterData.DataSource = complaintsManagementDetail.Tables[0];
                RepeaterData.DataBind();
                if (complaintsManagementDetail.Tables[1].Rows.Count > 0)
                {
                    foreach (RepeaterItem item in RepeaterData.Items)
                    {
                        var repeater = (Repeater) item.FindControl("RepeaterShow");
                        repeater.DataSource = complaintsManagementDetail.Tables[1];
                        repeater.DataBind();
                    }
                }
            }
        }
    }
}