using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using ShopNum1.Deploy.App_Code;
using ShopNum1.Common;

namespace ShopNum1.Deploy.Main.Bourse.Skin
{
    public partial class B_Welcome : BaseMemberControl
    {
        public void GetDataInfo()
        {
            LabelMemLoginID.Text = base.MemLoginID;
            LabelLoginTime.Text = Common.Common.GetNameById("LoginTime", "ShopNum1_Member",
                " AND   MemLoginID ='" + base.MemLoginID + "'");
            LabelLastLoginTime.Text = Common.Common.GetNameById("LoginDate", "ShopNum1_Member",
                " AND   MemLoginID ='" + base.MemLoginID + "'");
            if (Convert.ToDateTime("1900-1-1").ToString() == LabelLastLoginTime.Text)
            {
                LabelShowShang.Visible = false;
                LabelLastLoginTime.Text = "";
            }
            if (
                Common.Common.GetNameById("IsMobileActivation", "ShopNum1_Member",
                    " AND   MemLoginID ='" + base.MemLoginID + "'") == "1")
            {
                Sjyz.Visible = true;
                Sjwyz.Visible = false;
            }
            else
            {
                Sjwyz.Visible = true;
                Sjyz.Visible = false;
            }
            if (
                Common.Common.GetNameById("IsEmailActivation", "ShopNum1_Member",
                    " AND   MemLoginID ='" + base.MemLoginID + "'") == "1")
            {
                Yxyz.Visible = true;
                Yxwyz.Visible = false;
            }
            else
            {
                Yxyz.Visible = false;
                Yxwyz.Visible = true;
            }
            LabelAdvancePayment.Text = Common.Common.GetNameById("AdvancePayment", "ShopNum1_Member",
                " AND   MemLoginID ='" + base.MemLoginID + "'");

            LabelScore_dv.Text = Common.Common.GetNameById("Score_dv", "ShopNum1_Member",
               " AND   MemLoginID ='" + base.MemLoginID + "'");
            String yy = DateTime.Now.Year.ToString();

            String mm = DateTime.Now.Month.ToString();

            String days = DateTime.DaysInMonth(int.Parse(yy), int.Parse(mm)).ToString();

            DateTime startMonth = DateTime.Parse(yy + "/" + mm + "/1");

            int year = DateTime.Now.Year;//当前年  
            int mouth = DateTime.Now.Month;//当前月  

            int beforeYear = 0;
            int beforeMouth = 0;
            if (mouth <= 1)//如果当前月是一月，那么年份就要减1  
            {
                beforeYear = year - 1;
                beforeMouth = 12;//上个月  
            }
            else
            {
                beforeYear = year;
                beforeMouth = mouth - 1;//上个月  
            }
            DateTime beforeMouthOneDay = Convert.ToDateTime(beforeYear + "-" + beforeMouth + "-" + 1);//上个月第一天  


           
           


        }

        protected void Page_Load(object sender, EventArgs e)
        {
            var action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
            string dayTime = DateTime.Now.ToString("yyyy-MM-dd");
           
            HttpCookie cookie = Page.Request.Cookies["MemberLoginCookie"];
            HttpCookie cookie2 = HttpSecureCookie.Decode(cookie);
            string MemRankGuid = cookie2.Values["MemRankGuid"].ToUpper();
           
            string membertype = Common.Common.GetNameById("MemberType", "ShopNum1_Member",
                "  AND  MemLoginID='" + base.MemLoginID + "'");

         
          
           

            string str4 = Common.Common.GetNameById("MemberRankGuid", "ShopNum1_Member",
                "  AND  MemLoginID='" + base.MemLoginID + "'");
            string str2 = Guid.NewGuid().ToString();
            if (!string.IsNullOrEmpty(str4))
            {
                str2 = str4;
            }
            DataTable table2 =
                ((ShopNum1_MemberRank_Action)LogicFactory.CreateShopNum1_MemberRank_Action()).Search("'" + str2 + "'",
                    0);
            if ((table2 != null) && (table2.Rows.Count > 0))
            {
                string str3 = table2.Rows[0]["Pic"].ToString();
                if (str3.StartsWith("/"))
                {
                    ImageRank.ImageUrl = str3;
                }
                else
                {
                    ImageRank.ImageUrl = "/" + str3;
                }
              
                    ImageRank.ToolTip = table2.Rows[0]["Name"].ToString();
                

            }
            GetDataInfo();
            
          
        }
    }
}