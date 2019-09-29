using System;
using ShopNum1.Deploy.App_Code;
using System.Web;
using ShopNum1.Common;
using ShopNum1.BusinessLogic;
using ShopNum1.ShopFactory;
using ShopNum1.Factory;
using ShopNum1.Common.ShopNum1.Common;
using System.Data;

namespace ShopNum1.Deploy.Main.Member.Skin
{
    public partial class M_Left : BaseMemberControl
    {
        private string upgrade;

        public string Upgrade
        {
            get { return upgrade; }
            set { upgrade = value; }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            ShopNum1_Member_Action Member_Action = (ShopNum1_Member_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Member_Action();

            HttpCookie cookieShopMemberLogin = HttpContext.Current.Request.Cookies["MemberLoginCookie"];
            HttpCookie decodedCookieShopMemberLogin = HttpSecureCookie.Decode(cookieShopMemberLogin);
            //»áÔ±µÇÂ¼ID
            string MemberLoginID = decodedCookieShopMemberLogin.Values["MemLoginID"];
            DataTable table = Member_Action.SearchMembertwo(MemberLoginID);


            if (table.Rows[0]["deviceType"].ToString() == "0")
            {
                ti10.Visible = false;
                te10.Visible = false;
            }
            else 
            {
                ti09.Visible = false;
                te09.Visible = false;
            }




            //String memberGuid = memberrankguid_Action.GetCurrentMemberRankGuid(MemberLoginID);

            //if (memberGuid.ToLower().Equals(MemberLevel.NORMAL_Regular_Members.ToLower()))
            //{
            //    upgrade = "M_MemberUpgrade1.aspx";
            //    ti03.Visible=false;
            //    te03.Visible = false;
            //    ti10.Visible = false;
            //    te10.Visible = false;
            //    ti09.Visible = false;
            //    te09.Visible = false;

            //}
            //else if (memberGuid.ToLower().Equals(MemberLevel.NORMAL_MEMBER_ID.ToLower()))
            //{
            //    upgrade = "M_MemberUpgrade1.aspx";
            //    //ywy.Visible = false;
            //    ti09.Visible = false;
            //    te09.Visible = false;
            //    ti10.Visible = false;
            //    te10.Visible = false;

            //}
            //else if (memberGuid.ToLower().Equals(MemberLevel.VIP_MEMBER_ID.ToLower()))
            //{
            //    upgrade = "M_MemberUpgrade3.aspx";
            //    //ywy.Visible = false;
            //    ti10.Visible = false;
            //    te10.Visible = false;
            //}
            //else if (memberGuid.ToLower().Equals(MemberLevel.VIP_MEMBER_ID_two.ToLower()))
            //{
            //    upgrade = "M_MemberUpgrade5.aspx";
            //    ti10.Visible = false;
            //    te10.Visible = false;
            //}
            //else if (memberGuid.ToLower().Equals(MemberLevel.AGENT_MEMBER_ID.ToLower()))
            //{

            //    upgrade = "M_MemberUpgrade6.aspx";
            //    ti10.Visible = false;
            //    te10.Visible = false;
            //}
            //else if (memberGuid.ToLower().Equals(MemberLevel.COMMUNITY_MEMBER_ID.ToLower()))
            //{

            //    upgrade = "M_MemberUpgrade6.aspx";
            //    ti10.Visible = false;
            //    te10.Visible = false;
            //}
            //else if (memberGuid.ToLower().Equals(MemberLevel.COMMUNITY_MEMBER_ID_two.ToLower()))
            //{

            //    upgrade = "M_MemberUpgrade2.aspx";
            //}
            //else if (memberGuid.ToLower().Equals(MemberLevel.AGENT_MEMBER_ID_two.ToLower()))
            //{

            //    upgrade = "M_MemberUpgrade2.aspx";
            //}
            //else if (memberGuid.ToLower().Equals(MemberLevel.AGENT_MEMBER_ID_three.ToLower()))
            //{

            //    upgrade = "M_MemberUpgrade4.aspx";
            //}
            //else if (memberGuid.ToLower().Equals(MemberLevel.COMMUNITY_MEMBER_ID_three.ToLower()))
            //{

            //    upgrade = "M_MemberUpgrade4.aspx";
            //}
        }
    }
}