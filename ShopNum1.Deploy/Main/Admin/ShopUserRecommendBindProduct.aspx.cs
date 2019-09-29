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
    public partial class ShopUserRecommendBindProduct : PageBase, IRequiresSessionState
    {

        protected void BindGrid()
        {
            CheckMemid.Value = base.Request.QueryString["memloginid"];
            lablehead.Text = CheckMemid.Value;
            var action = (ShopNum1_ShopUserRecommend_Action)LogicFactory.CreateShopNum1_ShopUserRecommend_Action();
            DataTable SearchBindProduct = action.SearchBindProduct(CheckMemid.Value);
            Num1GridviewShow.DataSourceID = null;
            Num1GridviewShow.DataSource = SearchBindProduct;
            Num1GridviewShow.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            
            BindGrid();

        }

        protected void ButtonBindProduct_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("ShopUserRecommendBind.aspx?memloginid=" + CheckMemid.Value);
        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            string RecommendGuidAll = CheckGuid.Value;
            String[] id = RecommendGuidAll.Split(new char[] { ',' });
            for (int i = 0; i < id.Length; i++)
            {
                var action = (ShopNum1_ShopUserRecommend_Action)LogicFactory.CreateShopNum1_ShopUserRecommend_Action();
                int num = action.DeleteBindProduct(id[i]);

                 if (num > 0)
                {
                    
                    BindGrid();
                    MessageShow.ShowMessage("DelYes");
                    MessageShow.Visible = true;
                }
                else
                {
                    MessageShow.ShowMessage("DelNo");
                    MessageShow.Visible = true;
                }

            }
        }

        protected void LinkButtonDelete_Click(object sender, EventArgs e)
        {
            LinkButton LinkDelte = (LinkButton)sender;  //强转一下。
            string guid = LinkDelte.CommandArgument.ToString();
            
            
                var action = (ShopNum1_ShopUserRecommend_Action)LogicFactory.CreateShopNum1_ShopUserRecommend_Action();
                int num = action.DeleteBindProductone(guid);

                if (num > 0)
                {

                    BindGrid();
                    MessageShow.ShowMessage("DelYes");
                    MessageShow.Visible = true;
                }
                else
                {
                    MessageShow.ShowMessage("DelNo");
                    MessageShow.Visible = true;
                }

            
        }
    }
}