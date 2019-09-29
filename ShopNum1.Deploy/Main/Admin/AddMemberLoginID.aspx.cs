using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using ShopNum1.Common;
using ShopNum1.Deploy.comweb;
using System.Data;
using ShopNum1MultiEntity;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class AddMemberLoginID : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            var action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();

            if (!string.IsNullOrEmpty(TextBoxMemLoginID.Text.Trim()))
            {
                if (action.CheckmemLoginID(TextBoxMemLoginID.Text.Trim()) > 0)
                {
                   
                    Label1.Text="用户名已经被注册过了,请换一个用户名!";
                    return;
                }

            }
            MobileService sraw = new MobileService();
            string md5_one = ShopNum1.Common.MD5JiaMi.MyMd5JiaMi;
           string privateKey_two = "MemberLongiNO=" + TextBoxMemLoginID.Text.Trim() + md5_one + "";
           string md5Check_two = ShopNum1.Common.MD5JiaMi.Md5JiaMi(privateKey_two);
           DataTable MemberTavble=sraw.LoginidGetAllMember(TextBoxMemLoginID.Text.Trim(), md5Check_two);
           if (MemberTavble!=null && MemberTavble.Rows.Count>0)
           {
               var member = new ShopNum1_Member();

               member.MemLoginID = MemberTavble.Rows[0]["MemLoginNO"].ToString();
               member.Mobile = MemberTavble.Rows[0]["Mobile"].ToString();
                 member.RealName=MemberTavble.Rows[0]["RealName"].ToString();
                 member.Email = MemberTavble.Rows[0]["Email"].ToString();
               member.IsForbid = 0;
               member.MemberType = 1;
               member.IdentityCard = MemberTavble.Rows[0]["IdentityCard"].ToString();//用户身份证号
                member.MemLoginNO = MemberTavble.Rows[0]["MemLoginNO"].ToString();
                member.Pwd = MemberTavble.Rows[0]["Pwd"].ToString();
                member.Guid = Guid.NewGuid();
                member.AdvancePayment = 0;
                member.AddressValue = "";
                member.AddressCode = "";
                member.RegeDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                member.LoginDate = null;
                member.IsMobileActivation = 0;
                member.IsEmailActivation = "0";
                member.Superior = "";
                member.Score_hv = 0;
                member.PromotionMemLoginID = "";
                member.IsMailActivation = 1;
               member.MemberRank = 0;
               member.MemberRankGuid =new Guid("575B91F2-1B30-4ABD-AD2B-5EF33A36F9C0");

                member.Score = 0;

                member.LastLoginIP = null;
                member.LoginTime = 1;
                member.AdvancePayment = 0;
                member.LockAdvancePayment = 0;
                member.LockSocre = 0;
                member.CostMoney = 0;
                
                member.Score1 = 0;
                member.Score2 = 0;
                member.Score3 = 0;
                member.Score4 = 0;
                member.Score5 = 0;
                member.Score6 = 0;
               if (action.Add(member) == 1)
                {
                     Label1.Text="注册成功！";
                    return;
               }





           }
            else
	           {
                Label1.Text="TJ88里没有这个人！";
                    return;
	         }

        }
    }
}