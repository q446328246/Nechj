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
    public class M_RankScoreModifyLog : BaseMemberWebControl
    {
        private Button ButtonGet;
        private Repeater RepeaterShow;
        private TextBox TextBoxSRegDate1;
        private TextBox TextBoxSRegDate2;
        private HtmlGenericControl pageDiv;
        private string skinFilename = "M_RankScoreModifyLog.ascx";

        public M_RankScoreModifyLog()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public string pageid { get; set; }

        public string PageSize { get; set; }

        public string type { get; set; }

        private void ButtonGet_Click(object sender, EventArgs e)
        {
            BindData();
        }

        protected override void InitializeSkin(Control skin)
        {
            RepeaterShow = (Repeater) skin.FindControl("RepeaterShow");
            pageDiv = (HtmlGenericControl) skin.FindControl("pageDiv");
            pageid = (Common.Common.ReqStr("PageID") == "") ? "1" : Common.Common.ReqStr("PageID");
            TextBoxSRegDate1 = (TextBox) skin.FindControl("TextBoxSRegDate1");
            TextBoxSRegDate2 = (TextBox) skin.FindControl("TextBoxSRegDate2");
            ButtonGet = (Button) skin.FindControl("ButtonGet");
            ButtonGet.Click += ButtonGet_Click;
            type = (Common.Common.ReqStr("type") == "") ? "0" : Common.Common.ReqStr("type");
            if (type == "1")
            {
                BindData();
            }
        }

        private void BindData()
        {
            var action = (ShopNum1_RankScoreModifyLog_Action) LogicFactory.CreateShopNum1_RankScoreModifyLog_Action();
            string str = string.Empty;
            if (!string.IsNullOrEmpty(TextBoxSRegDate1.Text.Trim()))
            {
                str = str + "  AND  CreateTime>'" + TextBoxSRegDate1.Text.Trim() + "'   ";
            }
            if (!string.IsNullOrEmpty(TextBoxSRegDate2.Text.Trim()))
            {
                str = str + "   AND  CreateTime<'" + TextBoxSRegDate2.Text.Trim() + "'  ";
            }
            var commonModel = new CommonPageModel
            {
                Condition = " and IsDeleted=0    " + str + "     AND  MemLoginID='" + base.MemLoginID + "'  ",
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
            pageDiv.InnerHtml = new PageListBll("main/member/M_CreditDetails.aspx", true).GetPageListNew(pl);
            commonModel.Resultnum = "1";
            DataTable table2 = action.Select_List(commonModel);
            RepeaterShow.DataSource = table2.DefaultView;
            RepeaterShow.DataBind();
        }

        public static string Type(string operateType)
        {
            if (operateType == "1")
            {
                return "赠送红包";
            }
            if (operateType == "2")
            {
                return "转账红包";
            }
            if (operateType == "3")
            {
                return "兑换商品";
            }
            return "";
        }
    }
}