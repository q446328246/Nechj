using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.Deploy.App_Code;
using ShopNum1.BusinessLogic;
using System.Data;
using ShopNum1MultiEntity;
using ShopNum1.Common;
using ShopNum1.Factory;

namespace ShopNum1.Deploy.Main.Member.Skin
{
    public partial class M_LookOrder : BaseMemberControl
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



            ShopNum1_OrderInfo_Action action1 = (ShopNum1_OrderInfo_Action)LogicFactory.CreateShopNum1_OrderInfo_Action();
            ShopNum1_Member_Action action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
            string MemID = string.Empty;
            if (Page.Request.QueryString["MemNO"] != null && Page.Request.QueryString["MemNO"] != "")
            {
                
                DataTable membertable = action.GetMemInfoByNO(Page.Request.QueryString["MemNO"].ToString());
                MemID = membertable.Rows[0]["MemLoginID"].ToString();
            }
            //else
            //{
            //    DataTable membertable = action.GetMemInfo(base.MemLoginID);
            //    MemID = membertable.Rows[0]["MemLoginNO"].ToString();
            //}
            
            var commonModel = new CommonPageModel
            {
                Condition = " and a.PaymentStatus=1 and a.shop_category_id in (1,2,9) and CONVERT(varchar(100),[PayTime], 20)> (select Convert(nvarchar(10),DATEADD(day,-90 , GETDATE()),120))  AND  b.MemLoginID='" + MemID + "'  ",
                Currentpage = pageid,
                Resultnum = "0",
                PageSize = PageSize
            };
            DataTable table = action1.Select_ListOrder(commonModel);
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
            pageDiv.InnerHtml = new PageListBll("main/member/M_LookOrder.aspx", true).GetPageListNew(pl);
            commonModel.Resultnum = "1";
            DataTable table2 = null;
            table2 = action1.Select_ListOrder(commonModel);
            RepeaterShow.DataSource = table2.DefaultView;
            RepeaterShow.DataBind();

        }
    }
}