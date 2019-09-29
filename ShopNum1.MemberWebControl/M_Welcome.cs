using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;

namespace ShopNum1.MemberWebControl
{
    [ParseChildren(true)]
    public class M_Welcome : BaseMemberWebControl
    {
        private Button ButtonSingin;
        private Image ImageRank;
        private Label LabelAdvancePayment;
        private Label LabelLastLoginTime;
        private Label LabelLoginTime;
        private Label LabelMemLoginID;
        private Label LabelScore;
        private Label LabelShowShang;
        private Label LabelWaitMakeSure;
        private Label LabelWaitPayOrder;
        private Label LabelWwcOrder;
        private Repeater RepeaterAnnouncement;
        private Repeater RepeaterShowCai;
        private HtmlAnchor Sjwyz;
        private HtmlAnchor Sjyz;
        private HtmlAnchor Yxwyz;
        private HtmlAnchor Yxyz;
        //private HtmlAnchor Hysj;
        private Label lblLifeWaitMakeSure;
        private Label lblLifeWaitPayOrder;
        private string skinFilename = "M_Welcome.ascx";

        public M_Welcome()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

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
            LabelScore.Text = Common.Common.GetNameById("Score", "ShopNum1_Member",
                " AND   MemLoginID ='" + base.MemLoginID + "'");
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

        public void GetRecommend()
        {
            DataTable table = Common.Common.GetTableById("  TOP 4  *", "ShopNum1_Shop_Product",
                "  AND   1=1 AND IsSaled =1 And isaudit=1 and issell=1  And IsRecommend =1 order by salenumber desc   ");
            if ((table != null) && (table.Rows.Count > 0))
            {
                RepeaterShowCai.DataSource = table.DefaultView;
                RepeaterShowCai.DataBind();
            }
        }

        protected override void InitializeSkin(Control skin)
        {
            Sjwyz = (HtmlAnchor) skin.FindControl("Sjwyz");
            Yxwyz = (HtmlAnchor) skin.FindControl("Yxwyz");
            //Hysj = (Label)skin.FindControl("LabelMemLoginID");
            LabelShowShang = (Label) skin.FindControl("LabelShowShang");
            ButtonSingin = (Button) skin.FindControl("ButtonSingin");
            var action = (ShopNum1_Member_Action) LogicFactory.CreateShopNum1_Member_Action();
            string dayTime = DateTime.Now.ToString("yyyy-MM-dd");
            DataTable table = action.CheckSignin(base.MemLoginID, dayTime);
            if (((table != null) && (table.Rows.Count != 0)) && (Convert.ToInt32(table.Rows[0]["count"]) > 0))
            {
                ButtonSingin.Text = "已签到";
            }
            LabelMemLoginID = (Label) skin.FindControl("LabelMemLoginID");
            LabelLoginTime = (Label) skin.FindControl("LabelLoginTime");
            LabelLastLoginTime = (Label) skin.FindControl("LabelLastLoginTime");
            Sjyz = (HtmlAnchor) skin.FindControl("Sjyz");
            Yxyz = (HtmlAnchor)skin.FindControl("Yxyz");
            LabelAdvancePayment = (Label) skin.FindControl("LabelAdvancePayment");
            LabelScore = (Label) skin.FindControl("LabelScore");
            RepeaterAnnouncement = (Repeater) skin.FindControl("RepeaterAnnouncement");
            RepeaterShowCai = (Repeater) skin.FindControl("RepeaterShowCai");
            LabelWwcOrder = (Label) skin.FindControl("LabelWwcOrder");
            LabelWaitPayOrder = (Label) skin.FindControl("LabelWaitPayOrder");
            LabelWaitMakeSure = (Label) skin.FindControl("LabelWaitMakeSure");
            lblLifeWaitPayOrder = (Label) skin.FindControl("lblLifeWaitPayOrder");
            lblLifeWaitMakeSure = (Label) skin.FindControl("lblLifeWaitMakeSure");
            ImageRank = (Image) skin.FindControl("ImageRank");
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
                ImageRank.ToolTip = table2.Rows[0]["Name"].ToString();
            }
            GetDataInfo();
            GetAnnouncement();
            GetRecommend();
        }
    }
}