using System;
using System.Data;
using System.Web.SessionState;
using ShopNum1.Common;
using ShopNum1.ShopBusinessLogic;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class Limit_Product : PageBase, IRequiresSessionState
    {
        private readonly Shop_LimtProduct_Action shop_LimtProduct_Action_0 = new Shop_LimtProduct_Action();
        public DataTable dt_Lp = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindData();
            }
        }

        private void BindData()
        {
            string condition = " and lid='" + Common.Common.ReqStr("lid") + "'";
            int num = 1;
            int num2 = 10;
            if (Common.Common.ReqStr("pageid") != "")
            {
                num = Convert.ToInt32(Common.Common.ReqStr("pageid"));
            }
            int num3 =
                Convert.ToInt32(
                    shop_LimtProduct_Action_0.SelectLimtProdcut(num2.ToString(), num.ToString(), condition, "3").Rows[0]
                        [0]);
            var bll = new PageListBll("shop/ShopAdmin/S_Limit_ProductList.aspx", true);
            var pl = new PageList1
                {
                    PageSize = num2,
                    PageID = num,
                    RecordCount = num3
                };
            if ((pl.PageSize > num3) || (pl.PageCount == 1))
            {
                this.pageShow.Visible = false;
            }
            else
            {
                this.pageShow.Visible = true;
            }
            pageDiv.InnerHtml = bll.GetPageListNew(pl);
            dt_Lp = shop_LimtProduct_Action_0.SelectLimtProdcut(num2.ToString(), num.ToString(), condition, "2");
            if (dt_Lp.Rows.Count == 0)
            {
                dt_Lp = null;
            }
        }


    }
}