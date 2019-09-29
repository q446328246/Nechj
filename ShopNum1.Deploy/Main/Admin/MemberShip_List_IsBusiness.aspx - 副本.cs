using System;
using System.Data;
using System.Web;
using System.Web.SessionState;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1MultiEntity;
using System.Collections.Generic;

using System.Text;
using ShopNum1.Common.ShopNum1.Common;
using ShopNum1.Standard;
using ShopNum1.Webservice.CreateOrderTJ88;


namespace ShopNum1.Deploy.Main.Admin
{
 
    public partial class MemberShip_List_IsBusiness : PageBase, IRequiresSessionState
    {

        protected void BindGrid()
        {
            if (this.Page.Request.QueryString["ShipID"] != null)
            {
                this.ShipObjectDataSourceDate.SelectParameters["Shipstatu"].DefaultValue = this.Page.Request.QueryString["ShipID"].ToString();
            }
            ShipNum1GridViewShow.DataBind();
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();

            string text = (this.Page.Request.QueryString["ShipState"] == null) ? "1" : this.Page.Request.QueryString["ShipState"].ToString();
            switch (text)
            {
                case "1":
                    this.method_6(this.LinkButtonAll);
                    this.ShipNum1GridViewShow.Columns[8].Visible = false;

                    break;
                case "2":
                    this.method_6(this.LinkButtonPayment);
                    this.ShipNum1GridViewShow.Columns[7].Visible = false;
                    this.ShipNum1GridViewShow.Columns[3].Visible = false;
                    this.ShipNum1GridViewShow.Columns[4].Visible = false;
                    this.ShipNum1GridViewShow.Columns[8].Visible = false;

                    break;
                //case "3":
                //    this.method_6(this.LinkButtonNopayment);
                //    this.ShipNum1GridViewShow.Columns[8].Visible = false;


                //    break;
                //case "4":
                //    this.method_6(this.LinkButtonQDone);
                //    this.ShipNum1GridViewShow.Columns[7].Visible = false;
                //    this.ShipNum1GridViewShow.Columns[3].Visible = false;
                //    this.ShipNum1GridViewShow.Columns[4].Visible = false;

                //    break;
                case "0":
                    this.method_6(this.LinkButtonDeleted);
                    this.ShipNum1GridViewShow.Columns[8].Visible = false;
                    this.ShipNum1GridViewShow.Columns[7].Visible = false;
                    break;


            }


            BindGrid();

        }
        private void method_6(LinkButton linkButton_0)
        {
            this.LinkButtonAll.CssClass = "";
            //this.LinkButtonNopayment.CssClass = "";
            this.LinkButtonPayment.CssClass = "";


            linkButton_0.CssClass = "cur";
        }
        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            string shipidall = CheckShipID.Value;
            String[] id = shipidall.Split(new char[] { ',' });

            for (int i = 0; i < id.Length; i++)
            {
                var action = (ShopNum1_MemberShip_Action)LogicFactory.CreateShopNum1_MemberShip_Action();
                int num = action.Delete(id[i].ToString());

                if (num == -1)
                {
                    MessageBox.Show("没有此条记录！");
                }
                else if (num > 0)
                {
                    var operateLog = new ShopNum1_OperateLog
                    {
                        Record = "管理员删除会员等级申请列表",
                        OperatorID = base.ShopNum1LoginID,
                        IP = Globals.IPAddress,
                        PageName = "MemberShip_List.aspx",
                        Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                    };
                    base.OperateLog(operateLog);

                    BindGrid();
                    MesShow.ShowMessage("DelYes");
                    MesShow.Visible = true;
                }
                else
                {
                    MesShow.ShowMessage("DelNo");
                    MesShow.Visible = true;
                }
            }





        }

        protected void LinkButtonAll_Click(object sender, EventArgs e)
        {
            string id = "1";
            base.Response.Redirect("MemberShip_List.aspx?ShipState=" + id);
        }

        protected void LinkButtonNopayment_Click(object sender, EventArgs e)
        {
            string id = "3";
            base.Response.Redirect("MemberShip_List.aspx?ShipState=" + id);
        }

        protected void LinkButtonPayment_Click(object sender, EventArgs e)
        {
            string id = "2";
            base.Response.Redirect("MemberShip_List.aspx?ShipState=" + id);
        }

        protected void LinkButtonQDone_Click(object sender, EventArgs e)
        {
            string id = "4";
            base.Response.Redirect("MemberShip_List.aspx?ShipState=" + id);
        }
        protected void LinkButtonDeleted_Click(object sender, EventArgs e)
        {
            string id = "0";
            base.Response.Redirect("MemberShip_List.aspx?ShipState=" + id);
        }



        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            string text = (this.Page.Request.QueryString["ShipState"] == null) ? "1" : this.Page.Request.QueryString["ShipState"].ToString();
            int shipStaue = Convert.ToInt32(text);
            var action = (ShopNum1_MemberShip_Action)LogicFactory.CreateShopNum1_MemberShip_Action();
            if (txtMemLoginID.Value == "")
            {
                Response.Write("<Script Language=JavaScript>alert('请输入用户编号！');</Script>");
            }
            else
            {

                DataTable SearchShip = action.SearchShipMemLoginNO(txtMemLoginID.Value, shipStaue);

                ShipNum1GridViewShow.DataSourceID = null;
                ShipNum1GridViewShow.DataSource = SearchShip;
                ShipNum1GridViewShow.DataBind();





            }
        }
        protected void ButtonPassByShip_Click(object sender, EventArgs e)
        {
            var button = (LinkButton)sender;
            string ShipID = button.CommandArgument;
            ShopNum1_Member_Action Memaction = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
            ShopNum1_MemberShip_Action action = (ShopNum1_MemberShip_Action)LogicFactory.CreateShopNum1_MemberShip_Action();
            DataTable table = action.SearchShipID(ShipID);
            
                        if (table != null && table.Rows.Count > 0)
            {
                string MemLoginID = table.Rows[0]["MemLoginID"].ToString();


                int UpdateRefuseStatusNEC_member1 = action.UpdateRefuseStatusNEC_Status2(ShipID);
                if (UpdateRefuseStatusNEC_member1 > 0)
                {
                    Response.Write("<Script Language=JavaScript>alert('拒绝成功！');</Script>");
                }
                else
                {
                    Response.Write("<Script Language=JavaScript>alert('拒绝失败，请联系管理员！');</Script>");
                }

            }
            else
            {
                Response.Write("<Script Language=JavaScript>alert('未查询到该数据！');</Script>");
            }

                BindGrid();
 

        }

        protected void ButtonRefuseByShip_Click(object sender, EventArgs e)
        {
            var button = (LinkButton)sender;
            string ShipID = button.CommandArgument;
            var action = (ShopNum1_MemberShip_Action)LogicFactory.CreateShopNum1_MemberShip_Action();
            DataTable table = action.SearchShipID(ShipID);
            if (table != null && table.Rows.Count > 0)
            {
                string MemLoginID = table.Rows[0]["MemLoginID"].ToString();


                int UpdateRefuseStatusNEC_member1 = action.UpdateRefuseStatusNEC_Status2(ShipID);
                if (UpdateRefuseStatusNEC_member1 > 0)
                {
                    Response.Write("<Script Language=JavaScript>alert('拒绝成功！');</Script>");
                }
                else
                {
                    Response.Write("<Script Language=JavaScript>alert('拒绝失败，请联系管理员！');</Script>");
                }

            }
            else
            {
                Response.Write("<Script Language=JavaScript>alert('未查询到该数据！');</Script>");
            }
            BindGrid();
        }

        //protected void ButtonSelcet_Click(object sender, EventArgs e)
        //{
        //    Int32 selectSatue = Convert.ToInt32(SelectSatue.Value);
        //    var action = (ShopNum1_MemberShip_Action)LogicFactory.CreateShopNum1_MemberShip_Action();
        //    DataTable SearchShip = action.SearchShipStatu( selectSatue);

        //    ShipNum1GridViewShow.DataSourceID = null;
        //    ShipNum1GridViewShow.DataSource = SearchShip;
        //    ShipNum1GridViewShow.DataBind();

        //    int text =Convert.ToInt32(SearchShip.Rows[0]["ShipStatus"]);
        //    switch (text)
        //    {
        //        case 0:
        //            //this.method_6(this.LinkButtonAll);
        //            this.ShipNum1GridViewShow.Columns[7].Visible = false;
        //            break;
        //        case 4:
        //            //this.method_6(this.LinkButtonNopayment);
        //            this.ShipNum1GridViewShow.Columns[7].Visible = false;

        //            break;
        //        case 2:
        //            //this.method_6(this.LinkButtonPayment);
        //            this.ShipNum1GridViewShow.Columns[7].Visible = false;
        //            break;
        //    }

        //}



    }
}