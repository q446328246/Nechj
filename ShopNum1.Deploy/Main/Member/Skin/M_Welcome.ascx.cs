using System;
using System.Data;
using ShopNum1.BusinessLogic;
using ShopNum1.Deploy.App_Code;
using ShopNum1.Factory;
using System.Web;
using ShopNum1.Common;
using ShopNum1.Common.ShopNum1.Common;

namespace ShopNum1.Deploy.Main.Member.Skin
{
    public partial class M_Welcome : BaseMemberControl
    {
        public void GetAnnouncement()
        {
            DataTable announcementByTypeName =
                ((ShopNum1_Article_Action) LogicFactory.CreateShopNum1_Article_Action()).GetAnnouncementByTypeName(
                    "会员公告", 3);
            if ((announcementByTypeName != null) && (announcementByTypeName.Rows.Count > 0))
            {
                RepeaterAnnouncement.DataSource = announcementByTypeName.DefaultView;
                RepeaterAnnouncement.DataBind();
            }
        }

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
            LabelDJ.Text = Common.Common.GetNameById("Score_pv_a", "ShopNum1_Member",
                " AND   MemLoginID ='" + base.MemLoginID + "'");
            LabelScore_dv.Text = Common.Common.GetNameById("Score_dv", "ShopNum1_Member",
               " AND   MemLoginID ='" + base.MemLoginID + "'");
            LabelScore_pv_bdd.Text = Common.Common.GetNameById("Score_pv_b*0.1 as a", "ShopNum1_Member",
               " AND   MemLoginID ='" + base.MemLoginID + "'");
            String yy = DateTime.Now.Year.ToString();

          String mm = DateTime.Now.Month.ToString();

          String days = DateTime.DaysInMonth(int.Parse(yy),int.Parse(mm)).ToString();

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


            if (Common.Common.GetNameById("sum(HuoDe_pv_b)-sum(XiaoFei_pv_b)", "ShopNum1_AdvancePaymentModifyLog",
               " AND   MemLoginID ='" + base.MemLoginID + "' and Date>'" + startMonth + "'") == "" ||Convert.ToDecimal( Common.Common.GetNameById("sum(HuoDe_pv_b)-sum(XiaoFei_pv_b)", "ShopNum1_AdvancePaymentModifyLog", " AND   MemLoginID ='" + base.MemLoginID + "' and Date>'" + startMonth + "'"))<0)
            {
                LabelScore_pv_b.Text = "0.00";
            }
            else
            {
                LabelScore_pv_b.Text = Common.Common.GetNameById("sum(HuoDe_pv_b)-sum(XiaoFei_pv_b)", "ShopNum1_AdvancePaymentModifyLog",
              " AND   MemLoginID ='" + base.MemLoginID + "' and Date>'" + startMonth + "'");
            }
            if (Common.Common.GetNameById("sum(HuoDe_pv_b)-sum(XiaoFei_pv_b)", "ShopNum1_AdvancePaymentModifyLog",
               " AND   MemLoginID ='" + base.MemLoginID + "' and Date<'" + startMonth + "' and Date>'" + beforeMouthOneDay + "'")==""||Convert.ToDecimal(Common.Common.GetNameById("sum(HuoDe_pv_b)-sum(XiaoFei_pv_b)", "ShopNum1_AdvancePaymentModifyLog",
               " AND   MemLoginID ='" + base.MemLoginID + "' and Date<'" + startMonth + "' and Date>'" + beforeMouthOneDay + "'"))<0)
            {
                //LabelScore_pv_b_last.Text = "0.00";
            }
            else
            {
              //  LabelScore_pv_b_last.Text = Common.Common.GetNameById("sum(HuoDe_pv_b)-sum(XiaoFei_pv_b)", "ShopNum1_AdvancePaymentModifyLog",
              //" AND   MemLoginID ='" + base.MemLoginID + "' and Date<'" + startMonth + "' and Date>'" + beforeMouthOneDay + "'");
            }


            LabelScore_pv_a.Text = Common.Common.GetNameById("Score_cvv", "ShopNum1_Member",
               " AND   MemLoginID ='" + base.MemLoginID + "'");
            LabelScore_rv.Text = Common.Common.GetNameById("Score_svv", "ShopNum1_Member",
               " AND   MemLoginID ='" + base.MemLoginID + "'");

            //LabelScore.Text = Common.Common.GetNameById("Score_hv", "ShopNum1_Member",
            //    " AND   MemLoginID ='" + base.MemLoginID + "'");
            LabelWwcOrder.Text = Common.Common.GetNameById("COUNT(Guid)", "ShopNum1_OrderInfo",
                " AND   MemLoginID ='" + base.MemLoginID +
                "'  AND  OderStatus IN(0,2)  AND IsDeleted=0 ");
            LabelWaitPayOrder.Text = Common.Common.GetNameById("COUNT(Guid)", "ShopNum1_OrderInfo",
                " AND   MemLoginID ='" + base.MemLoginID +
                "'  AND  OderStatus=0    AND PaymentStatus=0  And FeeType!=2  AND IsDeleted=0");
            LabelWaitMakeSure.Text = Common.Common.GetNameById("COUNT(Guid)", "ShopNum1_OrderInfo",
                " AND   MemLoginID ='" + base.MemLoginID +
                "'  AND  OderStatus=2  And FeeType!=2   AND IsDeleted=0");
            try
            {
                lblLifeWaitPayOrder.Text = Common.Common.GetNameById("COUNT(Guid)", "ShopNum1_OrderInfo",
                    " AND   MemLoginID ='" + base.MemLoginID +
                    "'  AND  OderStatus=0 And FeeType=2  AND PaymentStatus=0   AND IsDeleted=0");
                lblLifeWaitMakeSure.Text = Common.Common.GetNameById("COUNT(Guid)", "ShopNum1_OrderInfo",
                    " AND   MemLoginID ='" + base.MemLoginID +
                    "'  AND  OderStatus=2 And FeeType=2  AND IsDeleted=0");
            }
            catch
            {
            }
        }

        //public void GetRecommend()
        //{
        //    DataTable table = Common.Common.GetTableById("  TOP 4  *", "ShopNum1_Shop_ProductPrice",
        //        "  AND   1=1 AND IsSaled =1 And isaudit=1 and issell=1  And IsRecommend =1 order by salenumber desc   ");
        //    if ((table != null) && (table.Rows.Count > 0))
        //    {
        //        RepeaterShowCai.DataSource = table.DefaultView;
        //        RepeaterShowCai.DataBind();
        //    }
        //}

        protected void Page_Load(object sender, EventArgs e)
        {
            var action = (ShopNum1_Member_Action) LogicFactory.CreateShopNum1_Member_Action();
            string dayTime = DateTime.Now.ToString("yyyy-MM-dd");
            DataTable table = action.CheckSignin(base.MemLoginID, dayTime);
            if (((table != null) && (table.Rows.Count != 0)) && (Convert.ToInt32(table.Rows[0]["count"]) > 0))
            {
                //ButtonSingin.Text = "已签到";
            }
            HttpCookie cookie = Page.Request.Cookies["MemberLoginCookie"];
            HttpCookie cookie2 = HttpSecureCookie.Decode(cookie);
            string MemRankGuid = cookie2.Values["MemRankGuid"].ToUpper();
            //if ( MemRankGuid == MemberLevel.NORMAL_Regular_Members.ToUpper())
            //{
            string membertype = Common.Common.GetNameById("MemberType", "ShopNum1_Member",
                "  AND  MemLoginID='" + base.MemLoginID + "'");

                guke.Visible = true;
                guke2.Visible = false;
                Tr1.Visible = false;
                if (membertype == "2") 
                {
                    guke2.Visible = true;
                }
            //}

            string str4 = Common.Common.GetNameById("MemberRankGuid", "ShopNum1_Member",
                "  AND  MemLoginID='" + base.MemLoginID + "'");
            string str2 = Guid.NewGuid().ToString();
            if (!string.IsNullOrEmpty(str4))
            {
                str2 = str4;
            }
            DataTable table2 =
                ((ShopNum1_MemberRank_Action) LogicFactory.CreateShopNum1_MemberRank_Action()).Search("'" + str2 + "'",
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
                string IsRetailersState = Common.Common.GetNameById("RetailersState", "ShopNum1_Member",
               "  AND  MemLoginID='" + base.MemLoginID + "'");
                if (IsRetailersState == "1")
                {
                    ImageRank.ToolTip = "零售商";
                }
                else
                {
                    ImageRank.ToolTip = table2.Rows[0]["Name"].ToString();
                }
               
            }
            GetDataInfo();
            GetAnnouncement();
            //GetRecommend();
        }


    }
}
