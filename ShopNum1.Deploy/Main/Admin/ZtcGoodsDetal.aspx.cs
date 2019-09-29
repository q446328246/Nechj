using System;
using System.Data;
using System.Web.SessionState;
using ShopNum1.BusinessLogic;
using ShopNum1.Factory;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class ZtcGoodsDetal : PageBase, IRequiresSessionState
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                hiddenFieldGuid.Value = Page.Request.QueryString["ID"].Replace("'", "");
            }
            GetData();
        }

        public void GetData()
        {
            DataTable infoByGuid =
                ((ShopNum1_ZtcGoods_Action) LogicFactory.CreateShopNum1_ZtcGoods_Action()).GetInfoByGuid(
                    hiddenFieldGuid.Value);
            if ((infoByGuid != null) && (infoByGuid.Rows.Count > 0))
            {
                RepeaterShow.DataSource = infoByGuid.DefaultView;
                RepeaterShow.DataBind();
            }
        }

        protected void ButtonBack_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("ZtcGoods_List.aspx");
        }
    }
}