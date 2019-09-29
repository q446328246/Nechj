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
    public class M_Msg : BaseMemberWebControl
    {
        private Repeater RepMsg;
        private HtmlGenericControl pageDiv;
        private string skinFilename = "M_Msg.ascx";
        private string string_1;
        private string string_2;

        public M_Msg()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public string PageSize { get; set; }

        protected override void InitializeSkin(Control skin)
        {
            RepMsg = (Repeater) skin.FindControl("RepMsg");
            pageDiv = (HtmlGenericControl) skin.FindControl("pageDiv");
            string_1 = (Common.Common.ReqStr("PageID") == "") ? "1" : Common.Common.ReqStr("PageID");
            string_2 = (Common.Common.ReqStr("IsRead") == "") ? "0" : Common.Common.ReqStr("IsRead");
            RepMsg = (Repeater) skin.FindControl("RepMsg");
            BindData();
        }

        private void BindData()
        {
            var message = new ShopNum1_MemberMessage
            {
                IsRead = Convert.ToByte(string_2)
            };
            var action = (ShopNum1_MemberMessage_Action) LogicFactory.CreateShopNum1_MemberMessage_Action();
            var commonModel = new CommonPageModel();
            if (Common.Common.ReqStr("isread") == "2")
            {
                commonModel.Condition = " and isdeleted=0  AND  SendLoginID='" + base.MemLoginID + "'";
            }
            else
            {
                commonModel.Condition = " and isdeleted=0 and isread=" + string_2 + " AND   ReLoginID='" +
                                        base.MemLoginID + "'   ";
            }
            commonModel.Currentpage = string_1;
            commonModel.Resultnum = "0";
            commonModel.PageSize = PageSize;
            DataTable table = action.SelectMsg_List(commonModel);
            var pl = new PageList1
            {
                PageSize = Convert.ToInt32(PageSize),
                PageID = Convert.ToInt32(string_1)
            };
            if ((table != null) && (table.Rows.Count > 0))
            {
                pl.RecordCount = Convert.ToInt32(table.Rows[0][0]);
            }
            else
            {
                pl.RecordCount = 0;
            }
            pageDiv.InnerHtml = new PageListBll("main/member/M_Msg.aspx", true).GetPageListNew(pl);
            commonModel.Resultnum = "1";
            DataTable table2 = action.SelectMsg_List(commonModel);
            RepMsg.DataSource = table2.DefaultView;
            RepMsg.DataBind();
        }
    }
}