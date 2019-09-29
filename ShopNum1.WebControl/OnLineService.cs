using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;

namespace ShopNum1.WebControl
{
    [ParseChildren(true)]
    public class OnLineService : BaseWebControl
    {
        private readonly ShopNum1_OnLineService_Action shopNum1_OnLineService_Action_0 =
            ((ShopNum1_OnLineService_Action) LogicFactory.CreateShopNum1_OnLineService_Action());

        private Repeater RepeaterHi;

        //private HtmlGenericControl RepeaterWW;
        private Repeater RepeaterMSN;
        private Repeater RepeaterQQ;
        private Repeater RepeaterWW;
        private HtmlGenericControl SpanMSN;
        private HtmlTableRow TRbaiduContent;
        private HtmlTableRow TRbaiduTitle;
        private HtmlTableRow TRmsnContent;
        private HtmlTableRow TRmsnTitle;
        private HtmlTableRow TRqqContent;
        private HtmlTableRow TRqqTitle;
        private HtmlTableRow TRwwContent;
        private HtmlTableRow TRwwTitle;

        private string skinFilename = "OnLineService.ascx";

        public OnLineService()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        protected override void InitializeSkin(Control skin)
        {
            RepeaterQQ = (Repeater) skin.FindControl("RepeaterQQ");
            RepeaterMSN = (Repeater) skin.FindControl("RepeaterMSN");
            RepeaterWW = (Repeater) skin.FindControl("RepeaterWW");
            RepeaterHi = (Repeater) skin.FindControl("RepeaterHi");
            //RepeaterWW = (HtmlGenericControl) skin.FindControl("RepeaterWW");
            SpanMSN = (HtmlGenericControl) skin.FindControl("SpanMSN");
            TRwwTitle = (HtmlTableRow) skin.FindControl("TRwwTitle");
            TRwwContent = (HtmlTableRow) skin.FindControl("TRwwContent");
            TRqqTitle = (HtmlTableRow) skin.FindControl("TRqqTitle");
            TRqqContent = (HtmlTableRow) skin.FindControl("TRqqContent");
            TRmsnTitle = (HtmlTableRow) skin.FindControl("TRmsnTitle");
            TRmsnContent = (HtmlTableRow) skin.FindControl("TRmsnContent");
            TRbaiduTitle = (HtmlTableRow) skin.FindControl("TRbaiduTitle");
            TRbaiduContent = (HtmlTableRow) skin.FindControl("TRbaiduContent");
            if (!Page.IsPostBack)
            {
            }
            BindData();
            method_1();
            if (RepeaterWW != null)
            {
                method_2();
                method_3();
            }
        }

        protected void BindData()
        {
            DataTable table;
            if (TRqqTitle != null)
            {
                if (shopNum1_OnLineService_Action_0.GetIsShowByID("1") == "1")
                {
                    TRqqTitle.Visible = true;
                    TRqqContent.Visible = true;
                    if (RepeaterQQ != null)
                    {
                        table = shopNum1_OnLineService_Action_0.SearchTypeInfo("QQ", 1);
                        RepeaterQQ.DataSource = table.DefaultView;
                        RepeaterQQ.DataBind();
                    }
                }
                else
                {
                    TRqqTitle.Visible = false;
                    TRqqContent.Visible = false;
                }
            }
            else if (RepeaterWW != null)
            {
                if (shopNum1_OnLineService_Action_0.GetIsShowByID("5") == "1")
                {
                    RepeaterWW.Visible = true;
                    if (RepeaterQQ != null)
                    {
                        table = shopNum1_OnLineService_Action_0.SearchTypeInfo("QQ", 1);
                        RepeaterQQ.DataSource = table.DefaultView;
                        RepeaterQQ.DataBind();
                    }
                }
                else
                {
                    RepeaterWW.Visible = false;
                }
            }
        }

        protected void method_1()
        {
            DataTable table;
            if (TRmsnTitle != null)
            {
                if (shopNum1_OnLineService_Action_0.GetIsShowByID("3") == "1")
                {
                    TRmsnTitle.Visible = true;
                    TRmsnContent.Visible = true;
                    if (RepeaterMSN != null)
                    {
                        table = shopNum1_OnLineService_Action_0.SearchTypeInfo("MSN", 1);
                        RepeaterMSN.DataSource = table.DefaultView;
                        RepeaterMSN.DataBind();
                    }
                }
                else
                {
                    TRmsnTitle.Visible = false;
                    TRmsnContent.Visible = false;
                }
            }
            else if (SpanMSN != null)
            {
                if (shopNum1_OnLineService_Action_0.GetIsShowByID("6") == "1")
                {
                    SpanMSN.Visible = true;
                    if (RepeaterMSN != null)
                    {
                        table = shopNum1_OnLineService_Action_0.SearchTypeInfo("MSN", 1);
                        RepeaterMSN.DataSource = table.DefaultView;
                        RepeaterMSN.DataBind();
                    }
                }
                else
                {
                    SpanMSN.Visible = false;
                }
            }
        }

        protected void method_2()
        {
            if (shopNum1_OnLineService_Action_0.GetIsShowByID("2") == "1")
            {
                TRwwTitle.Visible = true;
                TRwwContent.Visible = true;
                if (RepeaterWW != null)
                {
                    DataTable table = shopNum1_OnLineService_Action_0.SearchTypeInfo("WW", 1);
                    RepeaterWW.DataSource = table.DefaultView;
                    RepeaterWW.DataBind();
                }
            }
            else
            {
                TRwwTitle.Visible = false;
                TRwwContent.Visible = false;
            }
        }

        protected void method_3()
        {
            if (shopNum1_OnLineService_Action_0.GetIsShowByID("4") == "1")
            {
                TRbaiduTitle.Visible = true;
                TRbaiduContent.Visible = true;
                if (RepeaterHi != null)
                {
                    DataTable table = shopNum1_OnLineService_Action_0.SearchTypeInfo("HI", 1);
                    RepeaterHi.DataSource = table.DefaultView;
                    RepeaterHi.DataBind();
                }
            }
            else
            {
                TRbaiduTitle.Visible = false;
                TRbaiduContent.Visible = false;
            }
        }
    }
}