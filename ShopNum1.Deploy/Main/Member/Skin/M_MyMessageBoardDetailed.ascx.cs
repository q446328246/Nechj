using System;
using System.Data;
using ShopNum1.Deploy.App_Code;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;

namespace ShopNum1.Deploy.Main.Member.Skin
{
    public partial class M_MyMessageBoardDetailed : BaseMemberControl
    {
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

        protected void ButtonBackList_Click(object sender, EventArgs e)
        {
            Page.Response.Redirect("M_MyMessageBoard.aspx");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.Request.QueryString["guid"] != null)
            {
                BindData(Page.Request.QueryString["guid"]);
            }
        }
    }
}