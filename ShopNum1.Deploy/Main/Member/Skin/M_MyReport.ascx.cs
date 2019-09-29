using System;
using System.Data;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Deploy.App_Code;
using ShopNum1.Factory;
using ShopNum1MultiEntity;

namespace ShopNum1.Deploy.Main.Member.Skin
{
    public partial class M_MyReport : BaseMemberControl
    {
        public string pageid { get; set; }

        public string PageSize { get; set; }

        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            BindData();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            pageid = (Common.Common.ReqStr("PageID") == "") ? "1" : Common.Common.ReqStr("PageID");

            BindData();
        }

        protected void BindData()
        {
            var action = (ShopNum1_MemberReport_Action) LogicFactory.CreateShopNum1_MemberReport_Action();
            string str = string.Empty;
            if (DropDownListType.SelectedValue != "-1")
            {
                str = str + "  AND  ReportType=  '" + DropDownListType.SelectedValue + "'   ";
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
            pageDiv.InnerHtml = new PageListBll("main/member/M_CreditDetails.aspx", true).GetPageListNew(pl);
            commonModel.Resultnum = "1";
            DataTable table2 = action.Select_List(commonModel);
            RepeaterShow.DataSource = table2.DefaultView;
            RepeaterShow.DataBind();
        }

        public static string ProcessingStatus(string ProcessingStatus)
        {
            if (ProcessingStatus == "0")
            {
                return "未处理";
            }
            if (ProcessingStatus == "1")
            {
                return "处理中";
            }
            if (ProcessingStatus == "2")
            {
                return "已处理";
            }
            return "";
        }
    }
}