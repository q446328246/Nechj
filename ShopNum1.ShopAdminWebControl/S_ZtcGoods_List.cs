using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;
using ShopNum1MultiEntity;

namespace ShopNum1.ShopAdminWebControl
{
    [ParseChildren(true)]
    public class S_ZtcGoods_List : BaseShopWebControl
    {
        private Button ButtonSearch;
        private DropDownList DropDownListState;
        private Repeater RepeaterShow;
        private TextBox TextBoxName;
        private HtmlGenericControl pageDiv;
        private string skinFilename = "S_ZtcGoods_List.ascx";

        public S_ZtcGoods_List()
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

        public static string Expire(string strTime, string money)
        {
            decimal num = Convert.ToDecimal(ShopSettings.GetValue("ZtcMoney"));
            if (Convert.ToDecimal(money) < num)
            {
                return "余额不足";
            }
            if (Convert.ToDateTime(strTime) > DateTime.Now.ToLocalTime())
            {
                return "尚未开始";
            }
            return "显示中";
        }

        protected override void InitializeSkin(Control skin)
        {
            pageDiv = (HtmlGenericControl) skin.FindControl("pageDiv");
            pageid = (Common.Common.ReqStr("PageID") == "") ? "1" : Common.Common.ReqStr("PageID");
            TextBoxName = (TextBox) skin.FindControl("TextBoxName");
            DropDownListState = (DropDownList) skin.FindControl("DropDownListState");
            ButtonSearch = (Button) skin.FindControl("ButtonSearch");
            ButtonSearch.Click += ButtonSearch_Click;
            RepeaterShow = (Repeater) skin.FindControl("RepeaterShow");
            BindData();
        }

        protected void BindData()
        {
            var action = (ShopNum1_ZtcGoods_Action) LogicFactory.CreateShopNum1_ZtcGoods_Action();
            string str = string.Empty;
            if (!string.IsNullOrEmpty(TextBoxName.Text))
            {
                str = str + "  AND  ZtcName LIKE   '%" + TextBoxName.Text.Trim() + "%'   ";
            }
            if (DropDownListState.SelectedValue != "-1")
            {
                str = str + "  AND  State=  '" + DropDownListState.SelectedValue + "'   ";
            }
            var commonModel = new CommonPageModel
            {
                Condition = "  AND   1=1   " + str + "     AND   MemberID='" + base.MemLoginID + "'  ",
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
            pageDiv.InnerHtml =
                new PageListBll("Shop/ShopAdmin/S_ZtcGoods_List.aspx", true).GetPageListNew(pl);
            commonModel.Resultnum = "1";
            DataTable table2 = action.Select_List(commonModel);
            RepeaterShow.DataSource = table2.DefaultView;
            RepeaterShow.DataBind();
        }
    }
}