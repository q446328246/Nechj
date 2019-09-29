using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using System.Data;
using ShopNum1MultiEntity;
using ShopNum1.Factory;
using ShopNum1.Deploy.App_Code;
using ShopNum1.Common;

namespace ShopNum1.Deploy.Main.Member.Skin
{
    public partial class M_Cmember : BaseMemberControl
    {
        public string pageid { get; set; }

        public string PageSize { get; set; }

        public string type { get; set; }
        DataTable membertable;
        protected void Page_Load(object sender, EventArgs e)
        {
            pageid = (Common.Common.ReqStr("PageID") == "") ? "1" : Common.Common.ReqStr("PageID");

            type = (Common.Common.ReqStr("type") == "") ? "0" : Common.Common.ReqStr("type");
            if (type == "0")
            {
                BindData();
                if (base.MemLoginID   != membertable.Rows[0]["MemLoginID"].ToString())
                {
                    for (int i = 0; i < RepeaterShow.Items.Count; i++)
                    {
                        RepeaterShow.Items[i].FindControl("ss").Visible = false;
                    }
                }
            }
        }

        protected void BindData()
        {
            ShopNum1_Member_Action action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
            string MemID = string.Empty;
            if (Page.Request.QueryString["MemNO"] != null && Page.Request.QueryString["MemNO"] != "")
            {
                MemID = Page.Request.QueryString["MemNO"].ToString();
                 membertable = action.GetMemInfoByNO(MemID);
                
            }
            else 
            {
                membertable = action.GetMemInfo(base.MemLoginID);
                MemID = membertable.Rows[0]["MemLoginNO"].ToString();
                
            }
            #region

                var commonModel = new CommonPageModel
                {
                    Condition = " and a.IsDeleted=0 and a.MemberRankGuid!='197B6B51-3EB3-452E-BD03-D560577A34D2'  AND  Superior='" + MemID + "'  ",
                    Currentpage = pageid,
                    Resultnum = "0",
                    PageSize = PageSize
                };
                DataTable table = action.Select_ListC(commonModel);
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
                pageDiv.InnerHtml = new PageListBll("main/member/M_TJmember.aspx", true).GetPageListNew(pl);
                commonModel.Resultnum = "1";
                DataTable table2 = null;
                table2 = action.Select_ListC(commonModel);
                RepeaterShow.DataSource = table2.DefaultView;
                RepeaterShow.DataBind();

                #endregion
        }
    }
}