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
    public class S_ZtcApply_Detail : BaseMemberWebControl
    {
        private Button ButtonBackList;
        private Repeater RepeaterShow;
        private string skinFilename = "S_ZtcApply_Detail.ascx";

        public S_ZtcApply_Detail()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        protected void ButtonBackList_Click(object sender, EventArgs e)
        {
            Page.Response.Redirect("S_ZtcApply_List.aspx");
        }

        public void GetDataInfo()
        {
            DataTable infoByGuid =
                ((ShopNum1_ZtcApply_Action) LogicFactory.CreateShopNum1_ZtcApply_Action()).GetInfoByGuid(
                    Page.Request.QueryString["guid"]);
            if ((infoByGuid != null) && (infoByGuid.Rows.Count > 0))
            {
                RepeaterShow.DataSource = infoByGuid.DefaultView;
                RepeaterShow.DataBind();
            }
        }

        protected override void InitializeSkin(Control skin)
        {
            ButtonBackList = (Button) skin.FindControl("ButtonBackList");
            ButtonBackList.Click += ButtonBackList_Click;
            RepeaterShow = (Repeater) skin.FindControl("RepeaterShow");
            if (Page.Request.QueryString["guid"] != null)
            {
                GetDataInfo();
            }
        }
    }
}