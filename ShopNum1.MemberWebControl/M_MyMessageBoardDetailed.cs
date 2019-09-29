using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;

namespace ShopNum1.MemberWebControl
{
    [ParseChildren(true)]
    public class M_MyMessageBoardDetailed : BaseMemberWebControl
    {
        private Button ButtonBackList;
        private Repeater RepeaterShow;
        private string skinFilename = "M_MyMessageBoardDetailed.ascx";

        public M_MyMessageBoardDetailed()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public void BindData(string guid)
        {
            DataTable table =
                ((Shop_MessageBoard_Action) LogicFactory.CreateShop_MessageBoard_Action()).SearchMessageBoard(guid);
            if ((table != null) && (table.Rows.Count > 0))
            {
                RepeaterShow.DataSource = table.DefaultView;
                RepeaterShow.DataBind();
            }
        }

        private void ButtonBackList_Click(object sender, EventArgs e)
        {
            Page.Response.Redirect("M_MyMessageBoard.aspx");
        }

        protected override void InitializeSkin(Control skin)
        {
            RepeaterShow = (Repeater) skin.FindControl("RepeaterShow");
            ButtonBackList = (Button) skin.FindControl("ButtonBackList");
            ButtonBackList.Click += ButtonBackList_Click;
            if (Page.Request.QueryString["guid"] != null)
            {
                BindData(Page.Request.QueryString["guid"]);
            }
        }
    }
}