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
    public class S_ScoreOrder_List : BaseShopWebControl
    {
        private Button ButtonGetDate;
        private Repeater RepeaterShow;
        private TextBox TextBoxMemLoginID;
        private TextBox TextBoxOrderNumber;
        private HtmlGenericControl pageDiv;
        private string skinFilename = "S_ScoreOrder_List.ascx";

        public S_ScoreOrder_List()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public string pageid { get; set; }

        public string PageSize { get; set; }

        protected void ButtonGetDate_Click(object sender, EventArgs e)
        {
            BindData();
        }

        protected override void InitializeSkin(Control skin)
        {
            pageDiv = (HtmlGenericControl) skin.FindControl("pageDiv");
            pageid = (Common.Common.ReqStr("PageID") == "") ? "1" : Common.Common.ReqStr("PageID");
            TextBoxOrderNumber = (TextBox) skin.FindControl("TextBoxOrderNumber");
            TextBoxMemLoginID = (TextBox) skin.FindControl("TextBoxMemLoginID");
            ButtonGetDate = (Button) skin.FindControl("ButtonGetDate");
            ButtonGetDate.Click += ButtonGetDate_Click;
            RepeaterShow = (Repeater) skin.FindControl("RepeaterShow");
            BindData();
        }

        protected void BindData()
        {
            var action = (ShopNum1_ScoreOrderInfo_Action) LogicFactory.CreateShopNum1_ScoreOrderInfo_Action();
            string str = string.Empty;
            if (!string.IsNullOrEmpty(TextBoxOrderNumber.Text))
            {
                str = str + "  AND  OrderNumber=  '" + TextBoxOrderNumber.Text + "'   ";
            }
            if (!string.IsNullOrEmpty(TextBoxMemLoginID.Text))
            {
                str = str + "  AND  MemLoginID=  '" + TextBoxMemLoginID.Text + "'   ";
            }
            if (Page.Request.QueryString["OderStatus"] != null)
            {
                str = str + "  AND  OderStatus=  '" + Page.Request.QueryString["OderStatus"] + "'   ";
            }
            var commonModel = new CommonPageModel
            {
                Condition = "  AND   1=1   " + str + "     AND  ShopMemLoginID='" + base.MemLoginID + "'  ",
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
                new PageListBll("Shop/ShopAdmin/S_ScoreOrder_List.aspx", true).GetPageListNew(pl);
            commonModel.Resultnum = "1";
            DataTable table2 = action.Select_List(commonModel);
            RepeaterShow.DataSource = table2.DefaultView;
            RepeaterShow.DataBind();
        }
    }
}