using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.SessionState;
using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using ShopNum1.Common;
using System.Data;
using ShopNum1.Common.ShopNum1.Common;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class Order_Refuse : PageBase, IRequiresSessionState
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();

            string text = (this.Page.Request.QueryString["ShipState"] == null) ? "0" : this.Page.Request.QueryString["ShipState"].ToString();
            switch (text)
            {
                case "0":
                    this.method_6(this.LinkButtonAll);
                    break;
                
                case "1":
                    this.method_6(this.LinkButtonNopayment);
                    this.ShipNum1GridViewShow.Columns[6].Visible = true;
                    break;


                    
            }
            //if (!IsPostBack)
            //{
                Bind();
            //}
        }

        protected void  ButtonTui_Click(object sender, EventArgs e)
        {
            var action = (ShopNum1_OrdeComplaints_Action)LogicFactory.CreateShopNum1_OrdeComplaints_Action();
            string orderid = CheckGuid.Value;
            
            string[] arrStr = orderid.Split(',');
            for (int i = 0; i <arrStr.Length; i++)
            {
                JieKou_Tui(arrStr[i].Replace("'", " ").Trim());
            }
            
            Bind();
            
        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            var action = (ShopNum1_OrdeComplaints_Action)LogicFactory.CreateShopNum1_OrdeComplaints_Action();

            int c = action.UpdateOder(CheckGuid.Value);
            Bind();

        }

        protected void Bind()
        {
            string text = (this.Page.Request.QueryString["ShipState"] == null) ? "0" : this.Page.Request.QueryString["ShipState"].ToString();
            ShopNum1_MemberShip_Action action = (ShopNum1_MemberShip_Action)LogicFactory.CreateShopNum1_MemberShip_Action();
            ShipNum1GridViewShow.DataSource = action.selectAllOrder_Refuse(text);
            ShipNum1GridViewShow.DataBind();

        }
        private void method_6(LinkButton linkButton_0)
        {
            this.LinkButtonAll.CssClass = "";
            this.LinkButtonNopayment.CssClass = "";
            


            linkButton_0.CssClass = "cur";
        }
        protected void LinkButtonAll_Click(object sender, EventArgs e)
        {
            string id = "0";
            base.Response.Redirect("Order_Refuse.aspx?ShipState=" + id);
        }

        protected void ShipNum1GridViewShow_click(object sender, GridViewPageEventArgs e)
        {
            ShipNum1GridViewShow.PageIndex = e.NewPageIndex;
            ShipNum1GridViewShow.DataBind();
        }
          protected void LinkButtonNopayment_Click(object sender, EventArgs e)
        {
            string id = "1";
            base.Response.Redirect("Order_Refuse.aspx?ShipState=" + id);
        }
        protected void ButtonPassByShip_Click(object sender, EventArgs e)
        { 
            var button = (LinkButton)sender;
            string orderid = button.CommandArgument;
            ShopNum1_MemberShip_Action action = (ShopNum1_MemberShip_Action)LogicFactory.CreateShopNum1_MemberShip_Action();
            string str2 = string.Empty;
            HttpCookie cookie = Page.Request.Cookies["AdminLoginCookie"];
            str2 = HttpSecureCookie.Decode(cookie).Values["LoginID"];
            action.UpdateRefuseStatus_two(orderid, str2);
            Bind();
        }
        protected void LinkService_Click(object sender, EventArgs e)
        {
            var button1 = (LinkButton)sender;
            string orderid = button1.CommandArgument;
            JieKou_Tui(orderid);
            Bind();
        }
       
        protected void ButtonSearch_Click(object sender, EventArgs e)
        {

            string memloginid = Textmemloginid.Value;
            string mome = TextMome.Value;
            string orderid = txtMemLoginID.Value;

            ShopNum1_MemberShip_Action action = (ShopNum1_MemberShip_Action)LogicFactory.CreateShopNum1_MemberShip_Action();
            ShipNum1GridViewShow.DataSource = action.selectOrderByOrder_Refuse(orderid, memloginid, mome);
            ShipNum1GridViewShow.DataBind();
           
        }

        public  void JieKou_Tui(string orderid)
        {
        var orderaction = (ShopNum1_OrderInfo_Action)LogicFactory.CreateShopNum1_OrderInfo_Action();
            var memaction = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
            DataTable table = orderaction.SerchOrderInfoAll(orderid);
            if (table.Rows.Count == 0)
            {
                return;
            }
            string memid = table.Rows[0]["MemLoginID"].ToString();
            String Guid1 = memaction.GetGuidByMemLoginID(memid);
            DataTable tableTJ = memaction.SearchMemberGuid(Guid1);
            string MemNO = tableTJ.Rows[0]["MemLoginNO"].ToString();
            DataTable tablemember;
            if (MemNO.ToUpper().IndexOf("C") != -1)
            {

                tablemember = memaction.SearchMemberGuid(Guid1);
            }
            else
            {
                if (tableTJ.Rows[0]["Superior"].ToString() != null && tableTJ.Rows[0]["Superior"].ToString() != "")
                {
                    String TJGuid2 = memaction.GetGuidByMemLoginNO(tableTJ.Rows[0]["Superior"].ToString());
                    tablemember = memaction.SearchMemberGuid(TJGuid2);
                }
                else
                {
                    tablemember = memaction.SearchMemberGuid(Guid1);
                }
            }
            string OrderType = "1";//订单类型
            string OType = "1";
            if (Convert.ToInt32(table.Rows[0]["shop_category_id"]) == (int)CustomerCategory.BTC专区)
            {
                OrderType = "1";

            }
            if (Convert.ToInt32(table.Rows[0]["shop_category_id"]) == (int)CustomerCategory.大唐专区)
            {
                OType = "0";
                OrderType = "0";
            }
            if (Convert.ToInt32(table.Rows[0]["shop_category_id"]) == (int)CustomerCategory.VIP专区)
            {
                OrderType = "1";
            }
            if (Convert.ToInt32(table.Rows[0]["shop_category_id"]) == (int)CustomerCategory.区代专区1)
            {
                OType = "0";
                OrderType = "0";
            }
            if (Convert.ToInt32(table.Rows[0]["shop_category_id"]) == (int)CustomerCategory.区代专区2)
            {
                OrderType = "1";
            }
            if (Convert.ToInt32(table.Rows[0]["shop_category_id"]) == (int)CustomerCategory.社区店铺专区1)
            {
                OType = "0";
                OrderType = "0";
            }
            if (Convert.ToInt32(table.Rows[0]["shop_category_id"]) == (int)CustomerCategory.社区店铺专区2)
            {
                OrderType = "1";
            }
            #region 计算PV



            decimal GeneralPV = Convert.ToDecimal(table.Rows[0]["Score_pv_a"]) + (Convert.ToDecimal(table.Rows[0]["Score_pv_b"]) - Convert.ToDecimal(table.Rows[0]["Offset_pv_b"]));
            #endregion
            string TotalPV = GeneralPV.ToString();
            #region 计算Money
            decimal GeneralMoney = Convert.ToDecimal(table.Rows[0]["ShouldPayPrice"]) - Convert.ToDecimal(table.Rows[0]["Offset_pv_b"]);

            #endregion
            string TotalMoney = GeneralMoney.ToString();
            string CreateMan = tablemember.Rows[0]["MemLoginNO"].ToString();
            string nanme = tablemember.Rows[0]["RealName"].ToString();
            string OrderNO = table.Rows[0]["OrderNumber"].ToString();
            string CreateTime = DateTime.Now.ToString();

            TJAPIzl.MemberServiceSoapClient mms = new TJAPIzl.MemberServiceSoapClient();
            string md5_one = ShopNum1.Common.MD5JiaMi.MyMd5JiaMi;
            string privateKey_two = "Number=" + CreateMan.ToUpper().Trim() + "&Name=" + nanme.Trim() + "&OrderID=" + OrderNO.Trim() + "&TotalMoney=" + TotalMoney.Trim() + "&TotalPv=" + TotalPV.Trim() + "&IsAgain=" + OType.Trim() + "&OrderType=" + OrderType.Trim() + "&OrderDate=" + CreateTime.Trim() + md5_one;

            try
            {


                string md5Check_two = ShopNum1.Common.MD5JiaMi.Md5JiaMi(privateKey_two);
                string fh = mms.MemberOrder(CreateMan.ToUpper().Trim(), nanme.Trim(), OrderNO.Trim(), TotalMoney.Trim(), TotalPV.Trim(), OType.Trim(), OrderType.Trim(), CreateTime.Trim(), md5Check_two);
                if (fh.ToUpper() == "SUCCESS")
                {
                    ShopNum1_MemberShip_Action action = (ShopNum1_MemberShip_Action)LogicFactory.CreateShopNum1_MemberShip_Action();
                    string str2 = string.Empty;
                    HttpCookie cookie = Page.Request.Cookies["AdminLoginCookie"];
                    str2 = HttpSecureCookie.Decode(cookie).Values["LoginID"];
                    action.UpdateRefuseStatus_two(orderid, str2);
                    Response.Write("<script>alert('" + fh + "！');</script>");
                }
                else 
                {
                    
                    Response.Write("<script>alert('" + fh + "！');</script>");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
    }
}