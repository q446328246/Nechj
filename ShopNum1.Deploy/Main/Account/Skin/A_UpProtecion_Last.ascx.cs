using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.Deploy.App_Code;
using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using ShopNum1.Common;
using ShopNum1.Deploy.Api;


namespace ShopNum1.Deploy.Main.Account.Skin
{
    public partial class A_UpProtecion_Last : BaseMemberControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
            string IsProtecion = action.SelectIsProtecionByMemerberloginID(base.MemLoginID).Rows[0]["IsProtecion"].ToString();
            if (IsProtecion=="0")
            {
                lableShow.Text = "您尚未开启，需要看起资金保护吗？";
            }
            else if (IsProtecion == "1")
            {
                lableShow.Text = "您已经开启，需要关闭资金保护吗？";
            }
            else
            {
                lableShow.Text = "程序异常请联系客服查询";
            }
        }

        protected void Button_Affirm_Click(object sender, EventArgs e)
        {
            var action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
            string key = Common.Common.ReqStr("key");
            string Mobile = Common.Common.ReqStr("Mobile");
           
            CheckInfo c = new CheckInfo();
            string cw = c.MemberMobileExec(key, Mobile);
            if (cw =="1")
            {
                string IsProtecion = action.SelectIsProtecionByMemerberloginID(base.MemLoginID).Rows[0]["IsProtecion"].ToString();
                if (IsProtecion == "0")
                {
                    action.UpdtateMemberIsProtecionStyle(base.MemLoginID, 1);
                    
                    if (action.SelectIsProtecionByMemerberloginID(base.MemLoginID).Rows[0]["IsProtecion"].ToString() == "1")
                    {

                        MessageBox.Show("设置成功");
                    }
                    else
                    {
                        MessageBox.Show("设置失败");
                    }
                }
                else if (IsProtecion == "1")
                {


                    action.UpdtateMemberIsProtecionStyle(base.MemLoginID, 0);
                    
                    if (action.SelectIsProtecionByMemerberloginID(base.MemLoginID).Rows[0]["IsProtecion"].ToString() == "0")
                    {

                        MessageBox.Show("设置成功");
                    }
                    else
                    {
                        MessageBox.Show("设置失败");
                    }
                }
                else
                {
                    Page.Response.Redirect("A_PwdSer.aspx");
                }
            }
            else
            {
                MessageBox.Show("设置失败");
            }
            
        }

        protected void Button_Cancel_Click(object sender, EventArgs e)
        {
            Page.Response.Redirect("A_PwdSer.aspx");
        }
    }
}