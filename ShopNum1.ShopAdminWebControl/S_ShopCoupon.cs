using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;
using ShopNum1MultiEntity;

namespace ShopNum1.ShopAdminWebControl
{
    [ParseChildren(true)]
    public class S_ShopCoupon : BaseShopWebControl
    {
        private Button ButtonSearch;
        private DropDownList DropDownListIsAudit;
        private DropDownList DropDownListIsShow;
        private Repeater RepeaterShow;
        private TextBox TextBoxCouponName;
        private HtmlGenericControl pageDiv;
        private string skinFilename = "S_ShopCoupon.ascx";

        public S_ShopCoupon()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public string pageid { get; set; }

        public string PageSize { get; set; }

        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            BindData();
        }

        public static string GetNewsCategoryName(string string_3)
        {
            DataTable table =
                ((Shop_CouponType_Action) LogicFactory.CreateShop_CouponType_Action()).search(
                    Convert.ToInt32(string_3), -1);
            if ((table != null) && (table.Rows.Count > 0))
            {
                return table.Rows[0]["Name"].ToString();
            }
            return "";
        }

        protected override void InitializeSkin(Control skin)
        {
            pageDiv = (HtmlGenericControl) skin.FindControl("pageDiv");
            pageid = (Common.Common.ReqStr("PageID") == "") ? "1" : Common.Common.ReqStr("PageID");
            TextBoxCouponName = (TextBox) skin.FindControl("TextBoxCouponName");
            DropDownListIsAudit = (DropDownList) skin.FindControl("DropDownListIsAudit");
            DropDownListIsShow = (DropDownList) skin.FindControl("DropDownListIsShow");
            ButtonSearch = (Button) skin.FindControl("ButtonSearch");
            ButtonSearch.Click += ButtonSearch_Click;
            RepeaterShow = (Repeater) skin.FindControl("RepeaterShow");
            BindData();
        }

        protected void BindData()
        {
            var action = (Shop_Coupon_Action) LogicFactory.CreateShop_Coupon_Action();
            string str = string.Empty;
            if (DropDownListIsAudit.SelectedValue != "-1")
            {
                str = str + "  AND  IsAudit=  '" + DropDownListIsAudit.SelectedValue + "'   ";
            }
            if (!string.IsNullOrEmpty(TextBoxCouponName.Text))
            {
                str = str + "  AND  CouponName LIKE   '%" + TextBoxCouponName.Text.Trim() + "%'   ";
            }
            if (DropDownListIsShow.SelectedValue != "-1")
            {
                str = str + "  AND  IsShow=  '" + DropDownListIsShow.SelectedValue + "'   ";
            }
            var commonModel = new CommonPageModel
            {
                Condition = "  AND   1=1   " + str + "     AND  MemLoginID='" + base.MemLoginID + "'  ",
                Currentpage = pageid,
                Resultnum = "0",
                PageSize = PageSize
            };
            DataTable table = action.Select_List(commonModel);
            var pl = new PageList1
            {
                PageSize = Convert.ToInt32(PageSize),
                PageID = Convert.ToInt32(pageid)
            };
            if ((table != null) && (table.Rows.Count > 0))
            {
                pl.RecordCount = Convert.ToInt32(table.Rows[0][0]);
            }
            else
            {
                pl.RecordCount = 0;
            }
            pageDiv.InnerHtml = new PageListBll("Shop/ShopAdmin/S_ShopCoupon.aspx", true).GetPageListNew(pl);
            commonModel.Resultnum = "1";
            DataTable table2 = action.Select_List_two(commonModel);
            RepeaterShow.DataSource = table2.DefaultView;
            RepeaterShow.DataBind();
        }
    }
}