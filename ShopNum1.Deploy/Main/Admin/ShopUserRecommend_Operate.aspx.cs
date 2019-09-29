using System;
using System.Data;
using System.Web.SessionState;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1MultiEntity;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class ShopUserRecommend_Operate : PageBase, IRequiresSessionState
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonConfirm_Click(object sender, EventArgs e)
        {
            string memloginid = TextMemLoginID.Text;
            var memberaction = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
            DataTable date = memberaction.SearchMembertwoone(memloginid);
            var shopuseraction = (ShopNum1_ShopUserRecommend_Action)LogicFactory.CreateShopNum1_ShopUserRecommend_Action();
            DataTable date1 = shopuseraction.SearchMember(memloginid);
            if (Convert.ToInt32(date.Rows.Count.ToString()) > 0)
            {
                if (Convert.ToInt32(date1.Rows.Count.ToString()) > 0)
                {
                    MessageShow.ShowMessage("AddNo");
                    MessageShow.Visible = true;
                    Response.Write("<Script Language=JavaScript>alert('会员ID已存在于推荐列表中！');</Script>");

                }
                else
                {
                    ShopNum1_ShopUserRecommend shopuser = new ShopNum1_ShopUserRecommend();
                    shopuser.Guid = Guid.NewGuid();
                    shopuser.MemLoginID = memloginid;
                    shopuser.ProductId = "";
                    shopuser.Remark = "";
                    shopuser.LastSettlementDate = DateTime.Now;
                    shopuseraction.Add(shopuser);
                    MessageShow.ShowMessage("AddYes");
                    MessageShow.Visible = true;
                }
            }
            else
            {


                MessageShow.ShowMessage("AddNo");
                MessageShow.Visible = true;
                Response.Write("<Script Language=JavaScript>alert('会员ID不存在！');</Script>");

            }
        }
    }
}