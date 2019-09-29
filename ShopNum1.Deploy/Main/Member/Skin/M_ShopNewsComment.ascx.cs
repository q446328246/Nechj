using System;
using System.Data;
using ShopNum1.Common;
using ShopNum1.Deploy.App_Code;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;
using ShopNum1MultiEntity;

namespace ShopNum1.Deploy.Main.Member.Skin
{
    public partial class M_ShopNewsComment : BaseMemberControl
    {
        public string pageid { get; set; }

        public string PageSize { get; set; }

        public string type { get; set; }

        protected void ButtonGet_Click(object sender, EventArgs e)
        {
            BindData();
        }

        public static string GetTitle(string guid)
        {
            string str = string.Empty;
            DataTable titleByGuid = ((Shop_News_Action) LogicFactory.CreateShop_News_Action()).GetTitleByGuid(guid);
            if ((titleByGuid != null) && (titleByGuid.Rows.Count > 0))
            {
                str = titleByGuid.Rows[0][0].ToString();
            }
            return str;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            pageid = (Common.Common.ReqStr("PageID") == "") ? "1" : Common.Common.ReqStr("PageID");

            type = (Common.Common.ReqStr("type") == "") ? "0" : Common.Common.ReqStr("type");
            BindData();
        }

        protected void BindData()
        {
            var action = (Shop_News_Action) LogicFactory.CreateShop_News_Action();
            string str = string.Empty;
            if (!string.IsNullOrEmpty(TextBoxSRegDate1.Text.Trim()))
            {
                str = str + "  AND  CommentTime>'" + TextBoxSRegDate1.Text.Trim() + "'   ";
            }
            if (!string.IsNullOrEmpty(TextBoxSRegDate2.Text.Trim()))
            {
                str = str + "   AND  CommentTime<'" + TextBoxSRegDate2.Text.Trim() + "'  ";
            }
            if (DropDownListIsAudit.SelectedValue != "-1")
            {
                str = str + "   AND  IsAudit = '" + DropDownListIsAudit.SelectedValue + "'  ";
            }
            var commonModel = new CommonPageModel
            {
                Condition = " and 0=0    " + str + "   AND  MemLoginID='" + base.MemLoginID + "'  ",
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
            pageDiv.InnerHtml = new PageListBll("main/member/M_Comment.aspx", true).GetPageListNew(pl);
            commonModel.Resultnum = "1";
            DataTable table2 = action.Select_List(commonModel);
            RepeaterShow.DataSource = table2.DefaultView;
            RepeaterShow.DataBind();
        }
    }
}