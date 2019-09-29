using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;

namespace ShopNum1.ShopAdminWebControl
{
    [ParseChildren(true)]
    public class S_WelcomeShop : BaseShopWebControl
    {
        private Button ButtonGoPayFor;
        private Image ImagePic;
        private Image ImageShopReputation;
        private Image ImageShopSign;
        private Label LabelAdvancePayment;
        private Label LabelMemberReport;
        private Label LabelName;
        private Label LabelOrderComplaint;
        private Label LabelPayOrderIng;
        private Label LabelProductComment;
        private Label LabelReturnMoney;
        private Label LabelReturnProduct;
        private Label LabelSaleCount;
        private Label LabelSaleOnline;
        private Label LabelShopName;
        private Label LabelShopRank;
        private Label LabelShopReputation;
        private Label LabelSumComment;
        private Label LabelSumCommentCha;
        private Label LabelSumCommentGood;
        private Label LabelSumCommentZhong;
        private Label LabelVerifyTime;
        private Label LabelWaitGetProduct;
        private Label LabelWaitPayOrder;
        private Label LabelWaitPinjia;
        private Label LabelWaitSendProduct;
        private Label Label_MessageBoard;
        private Label Labelqtcj;
        private Label Labelqtje;
        private Label Labelqtorder;
        private Label Labelqtuser;
        private Label Labelqtzhl;
        private Label Labelztcj;
        private Label Labelztje;
        private Label Labelztorder;
        private Label Labelztuser;
        private Label Labelztzhl;
        private Repeater RepeaterAnnouncement;
        private HtmlInputHidden hidDetail;
        private HtmlInputHidden hidService;
        private HtmlInputHidden hidShopRate;
        private HtmlInputHidden hidSpeed;
        private HtmlImage imageCompany;
        private HtmlImage imageIdd;
        private HtmlAnchor shopUrlA;
        private string skinFilename = "S_Welcome.ascx";

        public S_WelcomeShop()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        protected void ButtonGoPayFor_Click(object sender, EventArgs e)
        {
            Page.Response.Redirect("S_ShowShopRank.aspx");
        }

        public void GetAnnouncement()
        {
            DataTable announcementByTypeName =
                ((ShopNum1_Article_Action)LogicFactory.CreateShopNum1_Article_Action()).GetAnnouncementByTypeName(
                    "店铺公告", 5);
            if ((announcementByTypeName != null) && (announcementByTypeName.Rows.Count > 0))
            {
                RepeaterAnnouncement.DataSource = announcementByTypeName.DefaultView;
                RepeaterAnnouncement.DataBind();
            }
        }

        public void GetDataInfo(string rankGuid)
        {
            string category = "9";
            if (base.MemLoginID == "C0000001") 
            {
                category = "1";
            }
            try
            {
                string str = Common.Common.GetNameById("Banner", "ShopNum1_ShopInfo",
                    "   AND   MemLoginID='" + base.MemLoginID + "'");
                string str2 = Common.Common.GetNameById("ShopUrl", "ShopNum1_ShopInfo",
                    "   AND   MemLoginID='" + base.MemLoginID + "'");
                if (!string.IsNullOrEmpty(str2))
                {
                    string siteDomain = ShopSettings.siteDomain;
                    try
                    {
                        shopUrlA.HRef = "http://" + str2 + siteDomain.Substring(siteDomain.IndexOf('.', 0), siteDomain.Length - siteDomain.IndexOf('.', 0)) + "?category=" + category; 
                     //  shopUrlA.HRef = "http://" + str2 + siteDomain.Replace("www", "").Replace("mall", "");
                    }
                    catch (Exception)
                    {
                        shopUrlA.HRef = "http://" + siteDomain;
                    }
                }
                if (!string.IsNullOrEmpty(str))
                {
                    ImageShopSign.ImageUrl = str;
                }
                else
                {
                    ImageShopSign.ImageUrl = "~/ImgUpload/noImage.gif";
                }
                LabelName.Text = base.MemLoginID;
                if (
                    !string.IsNullOrEmpty(Common.Common.GetNameById("CardImage", "ShopNum1_ShopInfo",
                        " AND  MemLoginID='" + base.MemLoginID + "'")))
                {
                    imageIdd.Visible = true;
                }
                else
                {
                    imageIdd.Visible = false;
                }
                if (
                    !string.IsNullOrEmpty(Common.Common.GetNameById("BusinessLicense", "ShopNum1_ShopInfo",
                        " AND  MemLoginID='" + base.MemLoginID + "'")))
                {
                    imageCompany.Visible = true;
                }
                else
                {
                    imageCompany.Visible = false;
                }
                LabelShopReputation.Text = Common.Common.GetNameById("ShopReputation", "ShopNum1_ShopInfo",
                    " AND  MemLoginID='" + base.MemLoginID + "'");
                LabelShopName.Text = Common.Common.GetNameById("ShopName", "ShopNum1_ShopInfo",
                    " AND  MemLoginID='" + base.MemLoginID + "'");
                int num = Convert.ToInt32(LabelShopReputation.Text);
                DataTable table = Common.Common.GetTableById("minScore,maxScore,Pic", "ShopNum1_ShopReputation",
                    " AND  1=1 and isdeleted=0 ");
                if ((table != null) && (table.Rows.Count > 0))
                {
                    foreach (DataRow row in table.Rows)
                    {
                        if ((num >= Convert.ToInt32(row["minScore"].ToString())) &&
                            (num <= Convert.ToInt32(row["maxScore"].ToString())))
                        {
                            ImageShopReputation.ImageUrl = "~/" + row["Pic"];
                        }
                    }
                }
                LabelShopRank.Text = Common.Common.GetNameById("Name", "ShopNum1_ShopRank",
                    " AND  Guid='" + rankGuid + "'");
                ImagePic.ImageUrl = Common.Common.GetNameById("Pic", "ShopNum1_ShopRank",
                    " AND  Guid='" + rankGuid + "'");
                LabelSaleCount.Text = Common.Common.GetNameById("COUNT(Guid)", "ShopNum1_Shop_Product",
                    " AND  MemLoginID='" + base.MemLoginID +
                    "' and issell=0 and issaled=1 and isdeleted=0 and isaudit=1");
                LabelMemberReport.Text = Common.Common.GetNameById("COUNT(ID)", "ShopNum1_MemberReport",
                    "    AND    ReportShop='" + base.MemLoginID + "'");
                LabelSaleOnline.Text = Common.Common.GetNameById("COUNT(Guid)", "ShopNum1_Shop_Product",
                    " AND  MemLoginID='" + base.MemLoginID +
                    "' and issell=1 and issaled=1 and isdeleted=0 and isaudit=1");
                LabelAdvancePayment.Text = Common.Common.GetNameById("AdvancePayment", "ShopNum1_Member",
                    " AND  MemLoginID='" + base.MemLoginID + "'");
                Label_MessageBoard.Text = Common.Common.GetNameById("COUNT(Guid)", "ShopNum1_Shop_MessageBoard",
                    " AND  ReplyUser='" + base.MemLoginID + "'");
                LabelPayOrderIng.Text = Common.Common.GetNameById("COUNT(Guid)", "ShopNum1_OrderInfo",
                    " AND  OderStatus IN(0,1,2)  AND    shopid='" +
                    base.MemLoginID +
                    "' and isdeleted=0");
                LabelOrderComplaint.Text = Common.Common.GetNameById("COUNT(ID)", "ShopNum1_OrderComplaint",
                    " AND  ComplaintShop ='" + base.MemLoginID + "'");
                LabelWaitPayOrder.Text = Common.Common.GetNameById("COUNT(Guid)", "ShopNum1_OrderInfo",
                    " AND  PaymentStatus =0 AND  OderStatus =0  AND    shopid='" +
                    base.MemLoginID + "' and isdeleted=0   ");
                LabelWaitSendProduct.Text = Common.Common.GetNameById("COUNT(Guid)", "ShopNum1_OrderInfo",
                    " AND  OderStatus =1 And  ShipmentStatus=0 And paymentstatus=1  AND    shopid='" +
                    base.MemLoginID + "' and isdeleted=0  ");
                LabelWaitGetProduct.Text = Common.Common.GetNameById("COUNT(Guid)", "ShopNum1_OrderInfo",
                    " AND  OderStatus =2  And  ShipmentStatus=1 And paymentstatus=1 AND  shopid='" +
                    base.MemLoginID + "'  and isdeleted=0  ");
                LabelWaitPinjia.Text = Common.Common.GetNameById("COUNT(Guid)", "ShopNum1_OrderInfo",
                    " AND   IsBuyComment=0   AND   OderStatus=3 And  ShipmentStatus=2 And paymentstatus=1 AND isdeleted=0 and    shopid='" +
                    base.MemLoginID + "'   ");
                LabelReturnMoney.Text = Common.Common.GetNameById("COUNT(Guid)", "ShopNum1_OrderInfo",
                    " AND   paymentstatus=3   AND    shopid='" +
                    base.MemLoginID +
                    "' and isdeleted=0   ");
                LabelReturnProduct.Text = Common.Common.GetNameById("COUNT(Guid)", "ShopNum1_OrderInfo",
                    " AND   ShipmentStatus=4   AND    shopid='" +
                    base.MemLoginID +
                    "' and isdeleted=0   ");
                LabelProductComment.Text = Common.Common.GetNameById("COUNT(Guid)", "ShopNum1_Shop_ProductComment",
                    string.Concat(new object[]
                    {
                        " AND   CommentTime >='",
                        DateTime.Now.AddMonths(-1),
                        "'    AND    shoploginid='",
                        base.MemLoginID, "'   "
                    }));
                Labelztcj.Text = Common.Common.GetNameById("COUNT(Guid)", "ShopNum1_OrderInfo",
                    " AND    OderStatus=3   AND    shopid='" + base.MemLoginID +
                    "'  AND   datediff(day,ReceiptTime,getdate())=0 ");
                decimal num6 = 0M;
                string str7 = Common.Common.GetNameById("SUM(shouldpayprice)", "ShopNum1_OrderInfo",
                    " AND    OderStatus=3   AND    shopid='" + base.MemLoginID +
                    "'  AND  datediff(day,ReceiptTime,getdate())=0 and isdeleted=0  ");
                if (str7 != "")
                {
                    num6 = Convert.ToDecimal(str7);
                }
                Labelztje.Text = num6.ToString();
                int num16 = 0;
                string str8 = Common.Common.GetNameById("COUNT(MemLoginID)", "ShopNum1_OrderInfo",
                    " AND    OderStatus=3   AND    shopid='" + base.MemLoginID +
                    "'  AND  datediff(day,ReceiptTime,getdate())=0 and isdeleted=0    GROUP BY  MemLoginID  ");
                if (str8 != "")
                {
                    num16 = Convert.ToInt32(str8);
                }
                Labelztuser.Text = num16.ToString();
                int num7 = Convert.ToInt32(Labelztcj.Text);
                int num17 =
                    Convert.ToInt32(Common.Common.GetNameById("COUNT(Guid)", "ShopNum1_OrderInfo",
                        " AND    OderStatus<3   AND    shopid='" + base.MemLoginID +
                        "' and isdeleted=0    "));
                int num18 =
                    Convert.ToInt32(Common.Common.GetNameById("COUNT(Guid)", "ShopNum1_OrderInfo",
                        " AND    OderStatus<3   AND    shopid='" + base.MemLoginID +
                        "'  AND datediff(day,CreateTime,getdate())=0  and isdeleted=0   "));
                int num19 = num17 - num18;
                int num8 = num19 + num7;
                double num4 = 0.0;
                if ((num7 != 0) && (num8 != 0))
                {
                    num4 = Convert.ToDouble(num7)/Convert.ToDouble(num8);
                }
                Labelztzhl.Text = ((Convert.ToDouble(num4.ToString("0.00"))*100.0)) + "%";
                Labelztorder.Text = Common.Common.GetNameById("COUNT(*)", "shopnum1_refund",
                    " AND    shopid='" + base.MemLoginID +
                    "'  AND  datediff(day,applytime,getdate())=0 ");
                Labelqtcj.Text = Common.Common.GetNameById("COUNT(*)", "ShopNum1_OrderInfo",
                    " AND    OderStatus=3   AND    shopid='" + base.MemLoginID +
                    "'  AND datediff(day,ReceiptTime,getdate())=1 and isdeleted=0   ");
                decimal num2 = 0M;
                string str6 = Common.Common.GetNameById("SUM(shouldpayprice)", "ShopNum1_OrderInfo",
                    " AND    OderStatus=3   AND    shopid='" + base.MemLoginID +
                    "'  AND  datediff(day,ReceiptTime,getdate())=1  and isdeleted=0    ");
                if (str6 != "")
                {
                    num2 = Convert.ToDecimal(str6);
                }
                Labelqtje.Text = num2.ToString();
                int num3 = 0;
                string str4 = Common.Common.GetNameById("COUNT(*)", "ShopNum1_OrderInfo",
                    " AND    OderStatus=3   AND  shopid='" + base.MemLoginID +
                    "'  AND  datediff(day,ReceiptTime,getdate())=1  and isdeleted=0    GROUP BY  MemLoginID  ");
                if (str4 != "")
                {
                    num3 = Convert.ToInt32(str4);
                }
                Labelqtuser.Text = num3.ToString();
                int num9 = Convert.ToInt32(Labelqtcj.Text);
                int num10 =
                    Convert.ToInt32(Common.Common.GetNameById("COUNT(Guid)", "ShopNum1_OrderInfo",
                        " AND    OderStatus<3   AND    shopid='" + base.MemLoginID +
                        "'  and isdeleted=0    "));
                int num11 =
                    Convert.ToInt32(Common.Common.GetNameById("COUNT(Guid)", "ShopNum1_OrderInfo",
                        " AND    OderStatus<3   AND    shopid='" + base.MemLoginID +
                        "'  and isdeleted=0   AND datediff(day,ReceiptTime,getdate())=0 "));
                int num12 =
                    Convert.ToInt32(Common.Common.GetNameById("COUNT(Guid)", "ShopNum1_OrderInfo",
                        " AND    OderStatus<3   AND    shopid='" + base.MemLoginID +
                        "'  and isdeleted=0    AND datediff(day,CreateTime,getdate())=1"));
                int num13 = (num10 - num11) - num12;
                int num14 = num13 + num9;
                double num15 = 0.0;
                if ((num9 != 0) && (num14 != 0))
                {
                    num15 = Convert.ToDouble(num9)/Convert.ToDouble(num14);
                }
                Labelqtzhl.Text = ((Convert.ToDouble(num15.ToString("0.00"))*100.0)) + "%";
                Labelqtorder.Text = Common.Common.GetNameById("COUNT(*)", "shopnum1_refund",
                    " AND   shopid='" + base.MemLoginID +
                    "'  AND  datediff(day,applytime,getdate())=1 ");
                LabelSumComment.Text = Common.Common.GetNameById("COUNT(Guid)", "ShopNum1_Shop_ProductComment",
                    " AND  shoploginid='" + base.MemLoginID + "'   ");
                LabelSumCommentGood.Text = Common.Common.GetNameById("COUNT(Guid)", "ShopNum1_Shop_ProductComment",
                    " AND   shoploginid='" + base.MemLoginID +
                    "'   AND  commenttype=5   AND   CommentTime>=  '" +
                    DateTime.Now.AddDays(-30.0).ToString("yyyyMMdd") +
                    "'");
                LabelSumCommentZhong.Text = Common.Common.GetNameById("COUNT(Guid)", "ShopNum1_Shop_ProductComment",
                    " AND    shoploginid='" + base.MemLoginID +
                    "'   AND  commenttype=3  AND   CommentTime >=   '" +
                    DateTime.Now.AddDays(-30.0).ToString("yyyyMMdd") +
                    "' ");
                LabelSumCommentCha.Text = Common.Common.GetNameById("COUNT(Guid)", "ShopNum1_Shop_ProductComment",
                    " AND  shoploginid='" + base.MemLoginID +
                    "'   AND  commenttype=1  AND   CommentTime >=   '" +
                    DateTime.Now.AddDays(-30.0).ToString("yyyyMMdd") +
                    "' ");
            }
            catch (Exception)
            {
            }
        }

        protected override void InitializeSkin(Control skin)
        {
            Exception exception;
            ImageShopSign = (Image) skin.FindControl("ImageShopSign");
            shopUrlA = (HtmlAnchor) skin.FindControl("shopUrlA");
            hidShopRate = (HtmlInputHidden) skin.FindControl("hidShopRate");
            hidDetail = (HtmlInputHidden) skin.FindControl("hidDetail");
            hidService = (HtmlInputHidden) skin.FindControl("hidService");
            hidSpeed = (HtmlInputHidden) skin.FindControl("hidSpeed");
            ButtonGoPayFor = (Button) skin.FindControl("ButtonGoPayFor");
            //ButtonGoPayFor.Click += ButtonGoPayFor_Click;
            LabelVerifyTime = (Label) skin.FindControl("LabelVerifyTime");
            LabelShopName = (Label) skin.FindControl("LabelShopName");
            LabelName = (Label) skin.FindControl("LabelName");
            imageIdd = (HtmlImage) skin.FindControl("imageIdd");
            imageCompany = (HtmlImage) skin.FindControl("imageCompany");
            LabelShopRank = (Label) skin.FindControl("LabelShopRank");
            ImagePic = (Image) skin.FindControl("ImagePic");
            LabelSaleCount = (Label) skin.FindControl("LabelSaleCount");
            LabelMemberReport = (Label) skin.FindControl("LabelMemberReport");
            LabelSaleOnline = (Label) skin.FindControl("LabelSaleOnline");
            LabelAdvancePayment = (Label) skin.FindControl("LabelAdvancePayment");
            LabelPayOrderIng = (Label) skin.FindControl("LabelPayOrderIng");
            LabelOrderComplaint = (Label) skin.FindControl("LabelOrderComplaint");
            LabelWaitPayOrder = (Label) skin.FindControl("LabelWaitPayOrder");
            LabelWaitSendProduct = (Label) skin.FindControl("LabelWaitSendProduct");
            LabelWaitGetProduct = (Label) skin.FindControl("LabelWaitGetProduct");
            LabelWaitPinjia = (Label) skin.FindControl("LabelWaitPinjia");
            LabelReturnMoney = (Label) skin.FindControl("LabelReturnMoney");
            LabelReturnProduct = (Label) skin.FindControl("LabelReturnProduct");
            LabelShopReputation = (Label) skin.FindControl("LabelShopReputation");
            ImageShopReputation = (Image) skin.FindControl("ImageShopReputation");
            Label_MessageBoard = (Label) skin.FindControl("Label_MessageBoard");
            LabelProductComment = (Label) skin.FindControl("LabelProductComment");
            RepeaterAnnouncement = (Repeater) skin.FindControl("RepeaterAnnouncement");
            Labelztcj = (Label) skin.FindControl("Labelztcj");
            Labelztje = (Label) skin.FindControl("Labelztje");
            Labelztuser = (Label) skin.FindControl("Labelztuser");
            Labelztzhl = (Label) skin.FindControl("Labelztzhl");
            Labelztorder = (Label) skin.FindControl("Labelztorder");
            Labelqtcj = (Label) skin.FindControl("Labelqtcj");
            Labelqtje = (Label) skin.FindControl("Labelqtje");
            Labelqtuser = (Label) skin.FindControl("Labelqtuser");
            Labelqtzhl = (Label) skin.FindControl("Labelqtzhl");
            Labelqtorder = (Label) skin.FindControl("Labelqtorder");
            LabelSumComment = (Label) skin.FindControl("LabelSumComment");
            LabelSumCommentGood = (Label) skin.FindControl("LabelSumCommentGood");
            LabelSumCommentZhong = (Label) skin.FindControl("LabelSumCommentZhong");
            LabelSumCommentCha = (Label) skin.FindControl("LabelSumCommentCha");
            try
            {
                string rankGuid = Common.Common.GetNameById("ShopRank", "ShopNum1_ShopInfo",
                    "   AND   MemLoginID='" + base.MemLoginID + "'");
                if (Common.Common.GetNameById("IsDefault", "ShopNum1_ShopRank", "   AND     Guid='" + rankGuid + "'") ==
                    "0")
                {
                    //LabelVerifyTime.Text = "永久";
                    //ButtonGoPayFor.Text = "升级";
                }
                else
                {
                    //ButtonGoPayFor.Text = "续费";
                    //LabelVerifyTime.Text = Common.Common.GetNameById("VerifyTime", "ShopNum1_Shop_ApplyShopRank",
                    //    "  AND      RankGuid='" + rankGuid +
                    //    "'   AND  MemberLoginID='" + base.MemLoginID + "'");
                    try
                    {
                        /*DateTime time2 = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        DateTime time3 = Convert.ToDateTime(LabelVerifyTime.Text);
                        if (DateTime.Compare(time2, time3) == 1)
                        {
                            string shopRank = Common.Common.GetNameById("Guid", "ShopNum1_ShopRank",
                                "   AND     IsDefault=0  ");
                            var action = (Shop_Rank_Action) ShopFactory.LogicFactory.CreateShop_Rank_Action();
                            action.UpdateUserRank(shopRank, base.MemLoginID);
                            action.ClearApplyShopRank(base.MemLoginID);
                        }*/
                    }
                    catch (Exception exception1)
                    {
                        exception = exception1;
                    }
                }
                GetDataInfo(rankGuid);
                GetAnnouncement();
                if (!Page.IsPostBack)
                {
                    BindData();
                }
            }
            catch (Exception exception2)
            {
                exception = exception2;
                Page.Response.Write(exception.Message);
            }
        }

        protected void BindData()
        {
            string goodRate =
                ((Shop_ProductComment_Action) ShopFactory.LogicFactory.CreateShop_ProductComment_Action()).GetGoodRate(
                    base.MemLoginID, "4");
            if (goodRate != "")
            {
                hidShopRate.Value = goodRate.Split(new[] {'|'})[0];
                hidSpeed.Value = goodRate.Split(new[] {'|'})[1];
                hidDetail.Value = goodRate.Split(new[] {'|'})[2];
                hidService.Value = goodRate.Split(new[] {'|'})[3];
            }
        }
    }
}