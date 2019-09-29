using System;
using System.Data;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Deploy.App_Code;
using ShopNum1.Factory;
using ShopNum1MultiEntity;

namespace ShopNum1.Deploy.Main.Member.Skin
{
    public partial class M_Msg : BaseMemberControl
    {
        private string string_1;
        private string string_2;


        public string PageSize { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            string_1 = (Common.Common.ReqStr("PageID") == "") ? "1" : Common.Common.ReqStr("PageID");
            string_2 = (Common.Common.ReqStr("IsRead") == "") ? "0" : Common.Common.ReqStr("IsRead");
            BindData();
        }

        protected void BindData()
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