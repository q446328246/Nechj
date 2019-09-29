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
    public class M_SysMsg : BaseMemberWebControl
    {
        private Repeater RepMsg;
        private HtmlGenericControl pageDiv;
        private string skinFilename = "M_SysMsg.ascx";
        private string string_1;
        private string string_2;

        public M_SysMsg()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public int PageSize { get; set; }

        protected override void InitializeSkin(Control skin)
        {
            RepMsg = (Repeater) skin.FindControl("RepMsg");
            RepMsg.ItemDataBound += RepMsg_ItemDataBound;
            pageDiv = (HtmlGenericControl) skin.FindControl("pageDiv");
            string_1 = (Common.Common.ReqStr("PageID") == "") ? "1" : Common.Common.ReqStr("PageID");
            string_2 = (Common.Common.ReqStr("IsRead") == "") ? "0" : Common.Common.ReqStr("IsRead");
            BindData();
        }

        private void BindData()
        {
            var info = new ShopNum1_MessageInfo
            {
                IsRead = Convert.ToByte(string_2)
            };
            var action = (ShopNum1_MessageInfo_Action) LogicFactory.CreateShopNum1_MessageInfo_Action();
            var commonModel = new CommonPageModel
            {
                Condition =
                    " and IsDeleted=0  AND   ReceiveID='" + base.MemLoginID + "'    AND  IsRead='" + string_2 +
                    "'  ",
                Currentpage = string_1,
                Resultnum = "0",
                PageSize = PageSize.ToString()
            };
            DataTable table = action.SelectSysUserMsg_List(commonModel);
            var pl = new PageList1
            {
                PageSize = PageSize,
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
            pageDiv.InnerHtml = new PageListBll("main/member/M_sysMsg.aspx", true).GetPageListNew(pl);
            commonModel.Resultnum = "1";
            DataTable table2 = action.SelectSysUserMsg_List(commonModel);
            RepMsg.DataSource = table2.DefaultView;
            RepMsg.DataBind();
        }

        private void RepMsg_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
            {
                var label = (Label) e.Item.FindControl("LabelMessageInfoGuid");
                DataTable table =
                    ((ShopNum1_MessageInfo_Action) LogicFactory.CreateShopNum1_MessageInfo_Action()).Get_SysMsgTitle(
                        label.Text);
                if ((table != null) && (table.Rows.Count > 0))
                {
                    label.Text = table.Rows[0][0].ToString();
                }
            }
        }
    }
}