using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1MultiEntity;
using System.Web.SessionState;
using System.Data;
using ShopNum1.Common.ShopNum1.Common;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class NewSelect_Money_All : PageBase, IRequiresSessionState
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //base.CheckLogin();
            if (!Page.IsPostBack)
            {
                BindGrid();
            }
        }
        protected void BindGrid()
        {
            ShopNum1_MemberRank_Action action = (ShopNum1_MemberRank_Action)LogicFactory.CreateShopNum1_MemberRank_Action();
            ShipNum1GridViewShow.DataSource = action.NewDailyMoney();
            ShipNum1GridViewShow.DataBind();
        }
        protected void ShipNum1GridViewShow_click(object sender, GridViewPageEventArgs e)
        {
            ShipNum1GridViewShow.PageIndex = e.NewPageIndex;
            if (TextBoxSDate1.Text.ToString() != "" && TextBoxSDate2.Text.ToString() != "")
            {
                BindGrid2();
            }
            else
            {
                BindGrid();
            }
             
            
        }
        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            BindGrid2();
        }
        protected void BindGrid2()
        {
            ShopNum1_MemberRank_Action action = (ShopNum1_MemberRank_Action)LogicFactory.CreateShopNum1_MemberRank_Action();
            ShipNum1GridViewShow.DataSource = action.DailyMoneyByTime(TextBoxSDate1.Text.ToString(), TextBoxSDate2.Text.ToString());
            ShipNum1GridViewShow.DataBind();
        }
    }
}