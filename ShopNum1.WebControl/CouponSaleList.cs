using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;

namespace ShopNum1.WebControl
{
    [ParseChildren(true)]
    public class CouponSaleList : BaseWebControl
    {
        private DropDownList DropDownListRegionCode1;
        private DropDownList DropDownListRegionCode2;
        private DropDownList DropDownListRegionCode3;
        private HiddenField HiddenFieldRegionCode;
        private Repeater RepeaterData;
        private string skinFilename = "CouponSaleList.ascx";

        public CouponSaleList()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public string ShowCount { get; set; }

        protected void CouponsDataBind()
        {
            SetShopRegionCode();
            try
            {
                int.Parse(ShowCount);
            }
            catch
            {
                ShowCount = "10";
            }
            DataTable couponTitleByAdressCode =
                ((ShopNum1_Coupon_Action) LogicFactory.CreateShopNum1_Coupon_Action()).GetCouponTitleByAdressCode(
                    HiddenFieldRegionCode.Value, ShowCount);
            if ((couponTitleByAdressCode != null) && (couponTitleByAdressCode.Rows.Count > 0))
            {
                RepeaterData.DataSource = couponTitleByAdressCode.DefaultView;
                RepeaterData.DataBind();
            }
            else
            {
                RepeaterData.DataSource = null;
                RepeaterData.DataBind();
            }
        }

        protected void DropDownListRegionCode3_SelectedIndexChanged(object sender, EventArgs e)
        {
            CouponsDataBind();
        }

        protected void DropDownListRegionCode1_SelectedIndexChanged(object sender, EventArgs e)
        {
            CouponsDataBind();
            DropDownListRegionCode2.Items.Clear();
            DropDownListRegionCode2.Items.Add(new ListItem("-市级-", "-1"));
            if (DropDownListRegionCode1.SelectedValue != "-1")
            {
                var action = (ShopNum1_ProductCategory_Action) LogicFactory.CreateShopNum1_ProductCategory_Action();
                action.TableName = "ShopNum1_Region";
                DataTable productCategoryName =
                    action.GetProductCategoryName(DropDownListRegionCode1.SelectedValue.Split(new[] {'/'})[1]);
                for (int i = 0; i < productCategoryName.Rows.Count; i++)
                {
                    DropDownListRegionCode2.Items.Add(new ListItem(productCategoryName.Rows[i]["Name"].ToString(),
                        productCategoryName.Rows[i]["Code"] + "/" +
                        productCategoryName.Rows[i]["ID"]));
                }
            }
            DropDownListRegionCode2_SelectedIndexChanged(null, null);
        }

        protected void DropDownListRegionCode1Bind()
        {
            DropDownListRegionCode1.Items.Clear();
            DropDownListRegionCode1.Items.Add(new ListItem("-省级-", "-1"));
            var action = (ShopNum1_ProductCategory_Action) LogicFactory.CreateShopNum1_ProductCategory_Action();
            action.TableName = "ShopNum1_Region";
            DataTable productCategoryName = action.GetProductCategoryName("0");
            for (int i = 0; i < productCategoryName.Rows.Count; i++)
            {
                DropDownListRegionCode1.Items.Add(new ListItem(productCategoryName.Rows[i]["Name"].ToString(),
                    productCategoryName.Rows[i]["Code"] + "/" +
                    productCategoryName.Rows[i]["ID"]));
            }
            DropDownListRegionCode1_SelectedIndexChanged(null, null);
        }

        protected void DropDownListRegionCode2_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownListRegionCode3.Items.Clear();
            DropDownListRegionCode3.Items.Add(new ListItem("-县级-", "-1"));
            if (DropDownListRegionCode2.SelectedValue != "-1")
            {
                CouponsDataBind();
                var action = (ShopNum1_ProductCategory_Action) LogicFactory.CreateShopNum1_ProductCategory_Action();
                action.TableName = "ShopNum1_Region";
                DataTable productCategoryName =
                    action.GetProductCategoryName(DropDownListRegionCode2.SelectedValue.Split(new[] {'/'})[1]);
                for (int i = 0; i < productCategoryName.Rows.Count; i++)
                {
                    DropDownListRegionCode3.Items.Add(new ListItem(productCategoryName.Rows[i]["Name"].ToString(),
                        productCategoryName.Rows[i]["Code"] + "/" +
                        productCategoryName.Rows[i]["ID"]));
                }
            }
        }

        protected override void InitializeSkin(Control skin)
        {
            DropDownListRegionCode1 = (DropDownList) skin.FindControl("DropDownListRegionCode1");
            DropDownListRegionCode1.SelectedIndexChanged += DropDownListRegionCode1_SelectedIndexChanged;
            DropDownListRegionCode2 = (DropDownList) skin.FindControl("DropDownListRegionCode2");
            DropDownListRegionCode2.SelectedIndexChanged += DropDownListRegionCode2_SelectedIndexChanged;
            DropDownListRegionCode3 = (DropDownList) skin.FindControl("DropDownListRegionCode3");
            DropDownListRegionCode3.SelectedIndexChanged += DropDownListRegionCode3_SelectedIndexChanged;
            RepeaterData = (Repeater) skin.FindControl("RepeaterData");
            HiddenFieldRegionCode = (HiddenField) skin.FindControl("HiddenFieldRegionCode");
            DropDownListRegionCode1Bind();
            if (!Page.IsPostBack)
            {
                CouponsDataBind();
            }
        }

        public void SetShopRegionCode()
        {
            if (DropDownListRegionCode3.SelectedValue != "-1")
            {
                HiddenFieldRegionCode.Value = DropDownListRegionCode3.SelectedValue.Split(new[] {'/'})[0];
            }
            else if (DropDownListRegionCode2.SelectedValue != "-1")
            {
                HiddenFieldRegionCode.Value = DropDownListRegionCode2.SelectedValue.Split(new[] {'/'})[0];
            }
            else if (DropDownListRegionCode1.SelectedValue != "-1")
            {
                HiddenFieldRegionCode.Value = DropDownListRegionCode1.SelectedValue.Split(new[] {'/'})[0];
            }
            else
            {
                HiddenFieldRegionCode.Value = "-1";
            }
        }
    }
}