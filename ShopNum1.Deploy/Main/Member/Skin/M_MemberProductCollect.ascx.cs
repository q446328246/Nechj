using System;
using System.Data;
using ShopNum1.Common;
using ShopNum1.Deploy.App_Code;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;
using ShopNum1MultiEntity;
using ShopNum1.Common.ShopNum1.Common;

namespace ShopNum1.Deploy.Main.Member.Skin
{
    public partial class M_MemberProductCollect : BaseMemberControl
    {
        public string pageid { get; set; }

        public string PageSize { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            pageid = (Common.Common.ReqStr("PageID") == "") ? "1" : Common.Common.ReqStr("PageID");
            BindData();
        }

        protected void BindData()
        {
            var action = (Shop_Collect_Action) LogicFactory.CreateShop_Collect_Action();
            var commonModel = new CommonPageModel
            {
                Condition = " and IsDeleted=0      AND  MemLoginID='" + base.MemLoginID + "'  ",
                Currentpage = pageid,
                Resultnum = "0",
                PageSize = PageSize
            };
            DataTable table = action.Select_ListMemberProductCollect(commonModel);
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
            pageDiv.InnerHtml = new PageListBll("main/member/M_MyCollect.aspx", true).GetPageListNew(pl);
            commonModel.Resultnum = "1";
            DataTable table2 = null;


            table2 = action.Select_ListMemberProductCollect(commonModel);
            RepeaterShow.DataSource = table2.DefaultView;
            RepeaterShow.DataBind();
        }
    }
}