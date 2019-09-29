using System;
using System.Data;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Deploy.App_Code;
using ShopNum1.Factory;
using ShopNum1MultiEntity;

namespace ShopNum1.Deploy.Main.Member.Skin
{
    public partial class M_MySupply : BaseMemberControl
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

        public static string IsAudit(string IsAudit)
        {
            if (IsAudit == "0")
            {
                return "未审核";
            }
            if (IsAudit == "1")
            {
                return "审核中";
            }
            if (IsAudit == "2")
            {
                return "审核未通过";
            }
            if (IsAudit == "3")
            {
                return "审核通过";
            }
            return "";
        }

        protected void BindData()
        {
            PageList1 list;
            var action = (ShopNum1_SupplyDemandCheck_Action) LogicFactory.CreateShopNum1_SupplyDemandCheck_Action();
            string str = string.Empty;
            if (DropDownListIsAudit.SelectedValue != "-1")
            {
                str = str + "  AND  IsAudit=  '" + DropDownListIsAudit.SelectedValue + "'   ";
            }
            if (DropDownListType.SelectedValue != "-1")
            {
                str = str + "  AND  TradeType=  '" + DropDownListType.SelectedValue + "'   ";
            }
            var commonModel = new CommonPageModel
            {
                Condition = "  AND   1=1   " + str + "     AND  MemberID='" + base.MemLoginID + "'  ",
                Currentpage = pageid,
                Resultnum = "0",
                PageSize = PageSize
            };

            DataTable table = action.Select_List(commonModel);
            list = new PageList1
            {
                PageSize = Convert.ToInt32(PageSize),
                PageCount = Convert.ToInt32(table.Rows[0][0])/Convert.ToInt32(PageSize)
            };

            if (list.PageCount < ((list.RecordCount)/((double) list.PageSize)))
            {
                list.PageCount++;
            }
            if (list.PageID > list.PageCount)
            {
                list.PageID = list.PageCount;
            }
            commonModel.Currentpage = list.PageID.ToString();
            if ((table != null) && (table.Rows.Count > 0))
            {
                list.RecordCount = Convert.ToInt32(table.Rows[0][0]);
            }
            else
            {
                list.RecordCount = 0;
            }
            pageDiv.InnerHtml = new PageListBll("main/member/M_MySupply.aspx", true).GetPageListNew(list);
            commonModel.Resultnum = "1";
            DataTable table2 = action.Select_List(commonModel);
            RepeaterShow.DataSource = table2.DefaultView;
            RepeaterShow.DataBind();
        }
    }
}
