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
    public class S_ZtcApply_List : BaseShopWebControl
    {
        private Button ButtonSearch;
        private DropDownList DropDownListAuditState;
        private DropDownList DropDownListType;
        private Repeater RepeaterShow;
        private TextBox TextBoxProductName;
        private HtmlGenericControl pageDiv;
        private string skinFilename = "S_ZtcApply_List.ascx";

        public S_ZtcApply_List()
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

        protected override void InitializeSkin(Control skin)
        {
            pageDiv = (HtmlGenericControl) skin.FindControl("pageDiv");
            pageid = (Common.Common.ReqStr("PageID") == "") ? "1" : Common.Common.ReqStr("PageID");
            TextBoxProductName = (TextBox) skin.FindControl("TextBoxProductName");
            DropDownListAuditState = (DropDownList) skin.FindControl("DropDownListAuditState");
            DropDownListType = (DropDownList) skin.FindControl("DropDownListType");
            ButtonSearch = (Button) skin.FindControl("ButtonSearch");
            ButtonSearch.Click += ButtonSearch_Click;
            RepeaterShow = (Repeater) skin.FindControl("RepeaterShow");
            BindData();
        }

        protected void BindData()
        {
            var action = (ShopNum1_ZtcApply_Action) LogicFactory.CreateShopNum1_ZtcApply_Action();
            string str = string.Empty;
            if (DropDownListAuditState.SelectedValue != "-1")
            {
                str = str + "  AND  AuditState=  '" + DropDownListAuditState.SelectedValue + "'   ";
            }
            if (!string.IsNullOrEmpty(TextBoxProductName.Text))
            {
                str = str + "  AND  ProductName LIKE   '%" + TextBoxProductName.Text.Trim() + "%'   ";
            }
            if (DropDownListType.SelectedValue != "-1")
            {
                str = str + "  AND  Type=  '" + DropDownListType.SelectedValue + "'   ";
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
                new PageListBll("Shop/ShopAdmin/S_ZtcApply_List.aspx", true).GetPageListNew(pl);
            commonModel.Resultnum = "1";
            DataTable table2 = action.Select_List(commonModel);
            RepeaterShow.DataSource = table2.DefaultView;
            RepeaterShow.DataBind();
        }

        public static string shenhe(string shType)
        {
            if (shType == "0")
            {
                return "未审核";
            }
            if (shType == "1")
            {
                return "审核通过";
            }
            if (shType == "2")
            {
                return "审核未通过";
            }
            return "";
        }
    }
}