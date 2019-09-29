using System;
using System.Data;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;

namespace ShopNum1.WebControl
{
    [ParseChildren(true)]
    public class Coupons : BaseWebControl
    {
        private Button ButtonGo;
        private DropDownList DropDownListCouponCategory;
        private Label LabelPageCount;
        private Label LabelPageIndex;
        private LinkButton LinkButtonEnd;
        private LinkButton LinkButtonFirst;
        private LinkButton LinkButtonLast;
        private LinkButton LinkButtonNext;
        private Repeater RepeaterData;

        private TextBox TextBoxPageNum;
        private HtmlImage htmlImage_0;
        private string skinFilename = "Coupons.ascx";

        public Coupons()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public string ShowCount { get; set; }

        protected void ButtonGo_Click(object sender, EventArgs e)
        {
            LabelPageIndex.Text = TextBoxPageNum.Text;
            CouponsDataBind();
        }

        protected void CouponsDataBind()
        {
            try
            {
                int.Parse(ShowCount);
            }
            catch
            {
                ShowCount = "9";
            }
            var action1 = (ShopNum1_Common_Action) LogicFactory.CreateShopNum1_Common_Action();
            var action = new ShopNum1_Coupon_Action();
            if (DropDownListCouponCategory.SelectedValue != "-1")
            {
                string text1 = "Type=" + DropDownListCouponCategory.SelectedValue;
            }
            LabelPageCount.Text =
                action.SearchCouponByCategory(DropDownListCouponCategory.SelectedValue, ShowCount, LabelPageIndex.Text)
                    .Tables[1].Rows[0][0
                    ].ToString();
            if (LabelPageCount.Text == "0")
            {
                LabelPageIndex.Text = "0";
                RepeaterData.DataSource = null;
                RepeaterData.DataBind();
            }
            else
            {
                if ((LabelPageCount.Text != "0") && (LabelPageIndex.Text == "0"))
                {
                    LabelPageIndex.Text = "1";
                }
                DataTable table =
                    action.SearchCouponByCategory(DropDownListCouponCategory.SelectedValue, ShowCount,
                        LabelPageIndex.Text).Tables[0];
                if ((table != null) && (table.Rows.Count > 0))
                {
                    RepeaterData.DataSource = table.DefaultView;
                    RepeaterData.DataBind();
                    for (int i = 0; i < RepeaterData.Items.Count; i++)
                    {
                        htmlImage_0 = (HtmlImage) RepeaterData.Items[i].FindControl("imgCoupon");
                        htmlImage_0.Src =
                            Page.ResolveUrl(GetWebFilePath(table.Rows[i]["ShopID"].ToString()) +
                                            table.Rows[i]["ImgPath"]);
                    }
                }
                LinkButtonFirst.Enabled = true;
                LinkButtonLast.Enabled = true;
                LinkButtonNext.Enabled = true;
                LinkButtonEnd.Enabled = true;
                if (LabelPageIndex.Text == "0")
                {
                    LinkButtonFirst.Enabled = true;
                    LinkButtonLast.Enabled = true;
                    LinkButtonNext.Enabled = true;
                    LinkButtonEnd.Enabled = true;
                }
                if (LabelPageIndex.Text == "1")
                {
                    LinkButtonFirst.Enabled = false;
                    LinkButtonLast.Enabled = false;
                }
                if (LabelPageIndex.Text == LabelPageCount.Text)
                {
                    LinkButtonNext.Enabled = false;
                    LinkButtonEnd.Enabled = false;
                }
            }
        }

        protected void DropDownListCouponCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            CouponsDataBind();
        }

        protected void DropDownListCouponCategoryBind()
        {
            DropDownListCouponCategory.Items.Clear();
            DropDownListCouponCategory.Items.Add(new ListItem("-全部-", "-1"));
            DataTable table = new ShopNum1_CouponType_Action().search(-1, 1);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                DropDownListCouponCategory.Items.Add(new ListItem(table.Rows[i]["Name"].ToString(),
                    table.Rows[i]["ID"].ToString()));
            }
        }

        protected string GetWebFilePath(string ShopID)
        {
            var action = (ShopNum1_ShopInfoList_Action) LogicFactory.CreateShopNum1_ShopInfoList_Action();
            string str =
                DateTime.Parse(action.GetOpenTimeByShopID(ShopID).Rows[0]["OpenTime"].ToString()).ToString("yyyy-MM-dd");
            string path = "/ImgUpload/" + str.Replace("-", "/") + "/shop" + ShopID + "/Coupon/";
            if (!Directory.Exists(HttpContext.Current.Server.MapPath(path)))
            {
                Directory.CreateDirectory(HttpContext.Current.Server.MapPath(path));
            }
            return path;
        }

        protected override void InitializeSkin(Control skin)
        {
            DropDownListCouponCategory = (DropDownList) skin.FindControl("DropDownListCouponCategory");
            DropDownListCouponCategory.SelectedIndexChanged += DropDownListCouponCategory_SelectedIndexChanged;
            RepeaterData = (Repeater) skin.FindControl("RepeaterData");
            LinkButtonFirst = (LinkButton) skin.FindControl("LinkButtonFirst");
            LinkButtonLast = (LinkButton) skin.FindControl("LinkButtonLast");
            LinkButtonNext = (LinkButton) skin.FindControl("LinkButtonNext");
            LinkButtonEnd = (LinkButton) skin.FindControl("LinkButtonEnd");
            LabelPageIndex = (Label) skin.FindControl("LabelPageIndex");
            LabelPageCount = (Label) skin.FindControl("LabelPageCount");
            TextBoxPageNum = (TextBox) skin.FindControl("TextBoxPageNum");
            ButtonGo = (Button) skin.FindControl("ButtonGo");
            LinkButtonFirst.Click += LinkButtonFirst_Click;
            LinkButtonLast.Click += LinkButtonLast_Click;
            LinkButtonNext.Click += LinkButtonNext_Click;
            LinkButtonEnd.Click += LinkButtonEnd_Click;
            ButtonGo.Click += ButtonGo_Click;
            DropDownListCouponCategoryBind();
            CouponsDataBind();
        }

        protected void LinkButtonFirst_Click(object sender, EventArgs e)
        {
            LabelPageIndex.Text = "1";
            CouponsDataBind();
        }

        protected void LinkButtonLast_Click(object sender, EventArgs e)
        {
            LabelPageIndex.Text = (int.Parse(LabelPageIndex.Text) - 1).ToString();
            CouponsDataBind();
        }

        protected void LinkButtonNext_Click(object sender, EventArgs e)
        {
            LabelPageIndex.Text = (int.Parse(LabelPageIndex.Text) + 1).ToString();
            CouponsDataBind();
        }

        protected void LinkButtonEnd_Click(object sender, EventArgs e)
        {
            LabelPageIndex.Text = LabelPageCount.Text;
            CouponsDataBind();
        }
    }
}