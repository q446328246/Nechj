using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Factory;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class Order_Refund_two : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DateBind();
        }
        protected void DateBind()
        {
            ShopNum1_MemberShip_Action action = (ShopNum1_MemberShip_Action)LogicFactory.CreateShopNum1_MemberShip_Action();
            ShipNum1GridViewShow.DataSource = action.selectAllOrderbypaymentstatus();
            ShipNum1GridViewShow.DataBind();
        }
        protected void ShipNum1GridViewShow_click(object sender, GridViewPageEventArgs e)
        {
            ShipNum1GridViewShow.PageIndex = e.NewPageIndex;
            ShipNum1GridViewShow.DataBind();
        }
        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            string orderid = txtMemLoginID.Value;
            ShopNum1_MemberShip_Action action = (ShopNum1_MemberShip_Action)LogicFactory.CreateShopNum1_MemberShip_Action();
            ShipNum1GridViewShow.DataSource = action.selectAllOrderinfoBYOderID(orderid);
            ShipNum1GridViewShow.DataBind();  
        } 

        protected void ButtonPassByShip_Click(object sender, EventArgs e)
        {
            var button = (LinkButton)sender;
            string orderid = button.CommandArgument;
            ShopNum1_MemberShip_Action action = (ShopNum1_MemberShip_Action)LogicFactory.CreateShopNum1_MemberShip_Action();
            action.UpdateOrderInfoStustes(orderid);
            DateBind();
        }

        
    }
}