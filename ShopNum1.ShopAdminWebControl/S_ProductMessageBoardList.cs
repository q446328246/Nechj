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
    public class S_ProductMessageBoardList : BaseShopWebControl
    {
        private Button ButtonSearch;
        private Repeater RepeaterShow;
        private TextBox TextBoxMemLoginID;
        private HtmlGenericControl pageDiv;
        private string skinFilename = "S_ProductMessageBoardList.ascx";

        public S_ProductMessageBoardList()
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

        public static string GetProductNameByGuid(string guid)
        {
            string str = Common.Common.GetNameById("Name", "ShopNum1_Shop_Product", "   AND  Guid ='" + guid + "'  ");
            if (!string.IsNullOrEmpty(str))
            {
                if (str.Length > 10)
                {
                    return (str.Substring(0, 10) + "...");
                }
                return str;
            }
            return "";
        }

        protected override void InitializeSkin(Control skin)
        {
            pageDiv = (HtmlGenericControl) skin.FindControl("pageDiv");
            pageid = (Common.Common.ReqStr("PageID") == "") ? "1" : Common.Common.ReqStr("PageID");
            TextBoxMemLoginID = (TextBox) skin.FindControl("TextBoxMemLoginID");
            ButtonSearch = (Button) skin.FindControl("ButtonSearch");
            ButtonSearch.Click += ButtonSearch_Click;
            RepeaterShow = (Repeater) skin.FindControl("RepeaterShow");
            BindData();
        }

        protected void BindData()
        {
            var action = (Shop_ProductConsult_Action) LogicFactory.CreateShop_ProductConsult_Action();
            string str = string.Empty;
            if (!string.IsNullOrEmpty(TextBoxMemLoginID.Text))
            {
                str = str + "  AND   MemLoginID  LIKE  '%" + TextBoxMemLoginID.Text.Trim() + "%'   ";
            }
            var commonModel = new CommonPageModel
            {
                Condition = "  AND   1=1   " + str + "     AND   ShopID='" + base.MemLoginID + "'  ",
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
                new PageListBll("Shop/ShopAdmin/S_ProductMessageBoardList.aspx", true).GetPageListNew(pl);
            commonModel.Resultnum = "1";
            DataTable table2 = action.Select_List(commonModel);
            RepeaterShow.DataSource = table2.DefaultView;
            RepeaterShow.DataBind();
        }
    }
}