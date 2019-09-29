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
    public class S_ShopNews : BaseMemberWebControl
    {
        private Button ButtonSearch;
        private DropDownList DropDownListType;
        private Repeater RepeaterShow;
        private TextBox TextBoxTitle;
        private HtmlGenericControl pageDiv;
        private string skinFilename = "S_ShopNews.ascx";

        public S_ShopNews()
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

        public static string GetNewsCategoryName(string Guid)
        {
            DataTable newsCategory =
                ((Shop_NewsCategory_Action) LogicFactory.CreateShop_NewsCategory_Action()).GetNewsCategory(Guid);
            if ((newsCategory != null) && (newsCategory.Rows.Count > 0))
            {
                return newsCategory.Rows[0]["Name"].ToString();
            }
            return "";
        }

        protected override void InitializeSkin(Control skin)
        {
            pageDiv = (HtmlGenericControl) skin.FindControl("pageDiv");
            pageid = (Common.Common.ReqStr("PageID") == "") ? "1" : Common.Common.ReqStr("PageID");
            DropDownListType = (DropDownList) skin.FindControl("DropDownListType");
            ButtonSearch = (Button) skin.FindControl("ButtonSearch");
            ButtonSearch.Click += ButtonSearch_Click;
            RepeaterShow = (Repeater) skin.FindControl("RepeaterShow");
            TextBoxTitle = (TextBox) skin.FindControl("TextBoxTitle");
            BindData();
        }

        public static string IsAudit(string IsAudit)
        {
            if (IsAudit == "0")
            {
                return "未审核";
            }
            if (IsAudit == "1")
            {
                return "审核通过";
            }
            if (IsAudit == "2")
            {
                return "审核未通过";
            }
            return "";
        }

        protected void BindData()
        {
            var action = (Shop_News_Action) LogicFactory.CreateShop_News_Action();
            string str = string.Empty;
            if (DropDownListType.SelectedValue != "-1")
            {
                str = str + "  AND  IsAudit=  '" + DropDownListType.SelectedValue + "'   ";
            }
            if (!string.IsNullOrEmpty(TextBoxTitle.Text))
            {
                str = str + "  AND  Title LIKE   '%" + TextBoxTitle.Text.Trim() + "%'   ";
            }
            var commonModel = new CommonPageModel
            {
                Condition = "  AND   1=1   " + str + "     AND  MemLoginID='" + base.MemLoginID + "'  ",
                Currentpage = pageid,
                Resultnum = "0",
                PageSize = PageSize
            };
            DataTable table = action.SelectNews_List(commonModel);
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
            pageDiv.InnerHtml = new PageListBll("Shop/ShopAdmin/S_ShopNews.aspx", true).GetPageListNew(pl);
            commonModel.Resultnum = "1";
            DataTable table2 = action.SelectNews_List(commonModel);
            RepeaterShow.DataSource = table2.DefaultView;
            RepeaterShow.DataBind();
        }
    }
}