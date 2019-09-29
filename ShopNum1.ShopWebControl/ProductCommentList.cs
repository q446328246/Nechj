using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;

namespace ShopNum1.ShopWebControl
{
    [ParseChildren(true)]
    public class ProductCommentList : BaseWebControl
    {
        private Label LabelPageMessage;
        private Repeater RepeaterStat;
        private HtmlInputHidden hidType;
        private Label lblBadCount;
        private Label lblContinue;
        private Label lblGoodCount;
        private Label lblMiddelCount;
        private Label lblTotal;
        private HyperLink lnkFirst;
        private HyperLink lnkLast;
        private HyperLink lnkNext;
        private HyperLink lnkPrev;
        private Literal lnkTo;
        private Repeater repeater_0;
        private string skinFilename = "ProductCommentList.ascx";

        public ProductCommentList()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public string MemLoginID { get; set; }

        public string ProductGuid { get; set; }

        public string Type { get; set; }

        protected override void InitializeSkin(Control skin)
        {
            lblGoodCount = (Label) skin.FindControl("lblGoodCount");
            lblMiddelCount = (Label) skin.FindControl("lblMiddelCount");
            lblBadCount = (Label) skin.FindControl("lblBadCount");
            lblTotal = (Label) skin.FindControl("lblTotal");
            lblContinue = (Label) skin.FindControl("lblContinue");
            lnkPrev = (HyperLink) skin.FindControl("lnkPrev");
            lnkFirst = (HyperLink) skin.FindControl("lnkFirst");
            lnkNext = (HyperLink) skin.FindControl("lnkNext");
            lnkLast = (HyperLink) skin.FindControl("lnkLast");
            LabelPageMessage = (Label) skin.FindControl("LabelPageMessage");
            lnkTo = (Literal) skin.FindControl("lnkTo");
            hidType = (HtmlInputHidden) skin.FindControl("hidType");
            hidType.Value = Type;
            string shopid = (Page.Request.QueryString["ShopID"] == null) ? "0" : Page.Request.QueryString["ShopID"];
            var action = (Shop_ShopInfo_Action) LogicFactory.CreateShop_ShopInfo_Action();
            MemLoginID = action.GetMemberLoginidByShopid(shopid);
            repeater_0 = (Repeater) skin.FindControl("RepeaterShow");
            ProductGuid = (Common.Common.ReqStr("guid") == "") ? "0" : Common.Common.ReqStr("guid");
            RepeaterStat = (Repeater) skin.FindControl("RepeaterStat");
            if (!Page.IsPostBack)
            {
                BindData();
            }
        }

        protected void BindData()
        {
            string s = ShopSettings.GetValue("ProductCommentPageCount");
            try
            {
                int.Parse(s);
            }
            catch
            {
                s = "10";
            }
            DataSet set =
                ((Shop_ProductComment_Action) LogicFactory.CreateShop_ProductComment_Action())
                    .ProductCommentListByGuidAndMemLoginID(ProductGuid, MemLoginID, Type);
            if (set.Tables[1].Rows.Count > 0)
            {
                RepeaterStat.DataSource = set.Tables[0];
                RepeaterStat.DataBind();
                if (set.Tables[1].Rows.Count > 0)
                {
                    string str2 = set.Tables[1].Rows[0]["py"].ToString();
                    lblTotal.Text = str2.Split(new[] {'-'})[0];
                    lblGoodCount.Text = str2.Split(new[] {'-'})[1];
                    lblMiddelCount.Text = str2.Split(new[] {'-'})[2];
                    lblBadCount.Text = str2.Split(new[] {'-'})[3];
                    lblContinue.Text = str2.Split(new[] {'-'})[4];
                }
            }
        }

        public static string SetNoNull(object value)
        {
            if (value.ToString() == "")
            {
                return "0";
            }
            return value.ToString();
        }
    }
}