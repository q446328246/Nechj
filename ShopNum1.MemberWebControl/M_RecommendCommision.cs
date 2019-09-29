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
    public class M_RecommendCommision : BaseMemberWebControl
    {
        private Button ButtonSearch;
        private Repeater RepeaterShow;
        private TextBox TextBoxMemLoginID;
        private TextBox TextBoxOrderNumber;
        private HtmlGenericControl pageDiv;
        private string skinFilename = "M_RecommendCommision.ascx";

        public M_RecommendCommision()
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
            TextBoxMemLoginID = (TextBox) skin.FindControl("TextBoxMemLoginID");
            TextBoxOrderNumber = (TextBox) skin.FindControl("TextBoxOrderNumber");
            ButtonSearch = (Button) skin.FindControl("ButtonSearch");
            ButtonSearch.Click += ButtonSearch_Click;
            RepeaterShow = (Repeater) skin.FindControl("RepeaterShow");
            BindData();
        }

        private void BindData()
        {
            var action = (ShopNum1_Member_Action) LogicFactory.CreateShopNum1_Member_Action();
            string str = string.Empty;
            if (!string.IsNullOrEmpty(TextBoxMemLoginID.Text.Trim()))
            {
                str = str + "  AND  MemLoginID=  '" + TextBoxMemLoginID.Text.Trim() + "'   ";
            }
            if (!string.IsNullOrEmpty(TextBoxOrderNumber.Text.Trim()))
            {
                str = str + "  AND  OrderNumber=  '" + TextBoxOrderNumber.Text.Trim() + "'   ";
            }
            var commonModel = new CommonPageModel
            {
                Tablename =
                    "SELECT  MemLoginID,OrderNumber,RecommendCommision,ReceiptTime  FROM  ShopNum1_OrderInfo WHERE  MemLoginID IN ( SELECT  MemLoginID   FROM ShopNum1_Member  where   PromotionMemLoginID='" +
                    base.MemLoginID + "') AND  OderStatus=3  AND RecommendCommision>0",
                Condition = "  AND   1=1   " + str + "   ",
                Currentpage = pageid,
                Resultnum = "3",
                PageSize = PageSize
            };
            DataTable table = action.SelectRecommendCommision_List(commonModel);
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
                new PageListBll("main/member/M_RecommendCommision.aspx", true).GetPageListNew(pl);
            commonModel.Resultnum = "2";
            DataTable table2 = action.SelectRecommendCommision_List(commonModel);
            RepeaterShow.DataSource = table2.DefaultView;
            RepeaterShow.DataBind();
        }
    }
}