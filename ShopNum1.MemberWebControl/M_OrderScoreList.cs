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

namespace ShopNum1.MemberWebControl
{
    [ParseChildren(true)]
    public class M_OrderScoreList : BaseMemberWebControl
    {
        private Button ButtonSearch;
        private Repeater RepeaterOrderNew;
        private TextBox TextBoxOrderNumber;
        private HtmlGenericControl pageDiv;
        private string skinFilename = "M_OrderScoreList.ascx";

        public M_OrderScoreList()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public string pageid { get; set; }

        public string PageSize { get; set; }

        private void ButtonSearch_Click(object sender, EventArgs e)
        {
            BindData();
        }

        protected override void InitializeSkin(Control skin)
        {
            pageDiv = (HtmlGenericControl) skin.FindControl("pageDiv");
            pageid = (Common.Common.ReqStr("PageID") == "") ? "1" : Common.Common.ReqStr("PageID");
            RepeaterOrderNew = (Repeater) skin.FindControl("RepeaterOrderNew");
            TextBoxOrderNumber = (TextBox) skin.FindControl("TextBoxOrderNumber");
            ButtonSearch = (Button) skin.FindControl("ButtonSearch");
            ButtonSearch.Click += ButtonSearch_Click;
            BindData();
        }

        private void BindData()
        {
            var action = (ShopNum1_ScoreOrderInfo_Action) LogicFactory.CreateShopNum1_ScoreOrderInfo_Action();
            string str = string.Empty;
            if (!string.IsNullOrEmpty(TextBoxOrderNumber.Text))
            {
                str = str + "  AND  OrderNumber=  '" + TextBoxOrderNumber.Text + "'   ";
            }
            if (Page.Request.QueryString["OderStatus"] != null)
            {
                str = str + "  AND  OderStatus=  '" + Page.Request.QueryString["OderStatus"] + "'   ";
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
            pageDiv.InnerHtml =
                new PageListBll("main/member/M_OrderScoreList.aspx", true).GetPageListNew(pl);
            commonModel.Resultnum = "1";
            DataTable table2 = action.Select_List(commonModel);
            RepeaterOrderNew.DataSource = table2.DefaultView;
            RepeaterOrderNew.DataBind();
        }
    }
}