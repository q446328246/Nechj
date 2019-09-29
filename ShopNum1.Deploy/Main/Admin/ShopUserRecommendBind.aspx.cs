using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using ShopNum1.Interface;
using ShopNum1MultiEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class ShopUserRecommendBind : PageBase, IRequiresSessionState
    {
        
        protected void BindGrid()
        {
            CheckMemid.Value = base.Request.QueryString["memloginid"];

            lablehead.Text = CheckMemid.Value;
            Num1GridviewShow.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
           
            
            BindGrid();

            
        }

        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            var action = (ShopNum1_ShopUserRecommend_Action)LogicFactory.CreateShopNum1_ShopUserRecommend_Action();
            
                DataTable SearchProduct = action.SearchProduct(txtMemLoginID.Value);

                Num1GridviewShow.DataSourceID = null;
                Num1GridviewShow.DataSource = SearchProduct;
                Num1GridviewShow.DataBind();
            
        }

        protected void Num1GridviewShow_RowDataBound(object sender, GridViewRowEventArgs e)
        {
           


        }

        protected void ButtonConfirm_Click(object sender, EventArgs e)
        {
            string ProductIDAll = Checkid.Value;
            String[] id = ProductIDAll.Split(new char[] { ',' });
            for (int i = 0; i < id.Length; i++)
            {
                var action = (ShopNum1_ShopUserRecommend_Action)LogicFactory.CreateShopNum1_ShopUserRecommend_Action();
            }
        }

        protected void ButtonBindProduct_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("ShopUserRecommendBindProduct.aspx?memloginid=" + CheckMemid.Value);
        }
        protected void ButtonBindylink_Click(object sender, EventArgs e)
        {
            var action = (ShopNum1_ShopUserRecommend_Action)LogicFactory.CreateShopNum1_ShopUserRecommend_Action();
            LinkButton LinkBind = (LinkButton)sender;  //强转一下。
            string peoductid = LinkBind.CommandArgument.ToString();
            //string peoductid = this.LinkBind.Value.ToString();
            string memloginid = this.CheckMemid.Value.ToString();
            string datetime = DateTime.Now.ToString();
            ShopNum1_ShopUserRecommendBindProduct BindProduct=new ShopNum1_ShopUserRecommendBindProduct();
            BindProduct.Guid=Guid.NewGuid();
            BindProduct.MemLoginID=memloginid;
            BindProduct.ProductId=peoductid;
            BindProduct.ProduactBindDate=DateTime.Now;
            BindProduct.LastSettlementDate=null;
            BindProduct.IsDeleted=1;
            int s = action.SearchAddBindProduct(peoductid, memloginid,BindProduct,datetime);
            if (s == -1)
            {
                Response.Write("<Script Language=JavaScript>alert('商品已在绑定列表中！');</Script>");
            }
            else 
            {
                Response.Write("<Script Language=JavaScript>alert('绑定成功！');</Script>");
            }
        }

        protected void lablehead_Load(object sender, EventArgs e)
        {
            
        }
    }
}