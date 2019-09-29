using System;
using System.Data;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;

namespace ShopNum1.ShopNewWebControl
{
    [ParseChildren(true)]
    public class CouponList : BaseWebControl
    {
        private readonly string string_1 = GetPageName.AgentGetPage("");
        private Button ButtonSure;
        private Label LabelPageCount;
        private Panel PanelNoFind;
        private TextBox TextBoxIndex;
        private HtmlImage htmlImage_0;
        private HtmlImage htmlImage_1;
        private int int_0;
        private HtmlGenericControl pageDiv;

        private Repeater repeater_0;
        private string skinFilename = "CouponListNew.ascx";

        public CouponList()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        private string MemLoginID { get; set; }

        public string ordername { get; set; }

        private string ShopID { get; set; }

        public int ShowCount { get; set; }

        public string soft { get; set; }

        protected void ButtonSure_Click(object sender, EventArgs e)
        {
            string str = TextBoxIndex.Text.Trim();
            Page.Response.Redirect(string_1 + "?sort=" + soft + "&ordername=" + ordername + "&pageid=" + str);
        }

        protected string GetWebFilePath()
        {
            var action = (Shop_ShopInfo_Action) LogicFactory.CreateShop_ShopInfo_Action();
            string str =
                DateTime.Parse(action.GetOpenTimeByShopID(ShopID).Rows[0]["OpenTime"].ToString()).ToString("yyyy-MM-dd");
            string path = "~/ImgUpload/" + str.Replace("-", "/") + "/shop" + ShopID + "/Coupon/";
            if (!Directory.Exists(HttpContext.Current.Server.MapPath(path)))
            {
                Directory.CreateDirectory(HttpContext.Current.Server.MapPath(path));
            }
            return path;
        }

        protected override void InitializeSkin(Control skin)
        {
            pageDiv = (HtmlGenericControl) skin.FindControl("pageDiv");
            LabelPageCount = (Label) skin.FindControl("LabelPageCount");
            TextBoxIndex = (TextBox) skin.FindControl("TextBoxIndex");
            ButtonSure = (Button) skin.FindControl("ButtonSure");
            ButtonSure.Click += ButtonSure_Click;
            PanelNoFind = (Panel) skin.FindControl("PanelNoFind");
            int_0 = 1;
            try
            {
                int_0 = int.Parse(Page.Request.QueryString["PageID"]);
            }
            catch
            {
                int_0 = 1;
            }
            ordername = (Page.Request.QueryString["ordername"] == null) ? "guid" : Page.Request.QueryString["ordername"];
            soft = (Page.Request.QueryString["sort"] == null) ? "desc" : Page.Request.QueryString["sort"];
            ShopID = (Page.Request.QueryString["ShopID"] == null) ? "0" : Page.Request.QueryString["ShopID"];
            var action = (Shop_ShopInfo_Action) LogicFactory.CreateShop_ShopInfo_Action();
            MemLoginID = action.GetMemberLoginidByShopid(ShopID);
            repeater_0 = (Repeater) skin.FindControl("RepeaterData");
            BindData();
        }

        protected void BindData()
        {
            var action = (Shop_Coupon_Action) LogicFactory.CreateShop_Coupon_Action();
            var pl = new PageList1
            {
                PageSize = ShowCount,
                PageID = int_0
            };
            DataSet set = action.SearchCouponByMemloginID(MemLoginID, ordername, soft, ShowCount.ToString(),
                int_0.ToString(), "1");
            if ((set != null) && (set.Tables[0].Rows.Count > 0))
            {
                pl.RecordCount = Convert.ToInt32(set.Tables[0].Rows[0][0]);
            }
            else
            {
                pl.RecordCount = 0;
            }
            var bll = new PageListBll("CouponList", true)
            {
                ShowPageCount = false,
                ShowPageIndex = false,
                ShowRecordCount = false,
                ShowNoRecordInfo = false,
                ShowNumListButton = true,
                PrevPageText = "上一页",
                NextPageText = "下一页 "
            };
            TextBoxIndex.Text = int_0.ToString();
            pageDiv.InnerHtml = bll.GetPageListVk(pl);
            LabelPageCount.Text = pl.PageCount.ToString();
            DataSet set2 = action.SearchCouponByMemloginID(MemLoginID, ordername, soft, ShowCount.ToString(),
                int_0.ToString(), "0");
            if ((set2.Tables[0] == null) || (set2.Tables[0].Rows.Count == 0))
            {
                PanelNoFind.Visible = true;
            }
            else
            {
                repeater_0.DataSource = set2.Tables[0];
                repeater_0.DataBind();
                for (int i = 0; i < repeater_0.Items.Count; i++)
                {
                    htmlImage_1 = (HtmlImage) repeater_0.Items[i].FindControl("ImgCoupon");
                    htmlImage_1.Src = Page.ResolveUrl(set2.Tables[0].Rows[i]["ImgPath"].ToString());
                    htmlImage_0 = (HtmlImage) repeater_0.Items[i].FindControl("imgIsEffective");
                    if ((set2.Tables[0].Rows[i]["IsEffective"].ToString() == "0") ||
                        (Convert.ToDateTime(set2.Tables[0].Rows[i]["EndTime"].ToString()) < DateTime.Now))
                    {
                        htmlImage_0.Src = "../Images/unineffect.gif";
                    }
                    else
                    {
                        htmlImage_0.Src = "../Images/ineffect.gif";
                    }
                }
            }
        }
    }
}