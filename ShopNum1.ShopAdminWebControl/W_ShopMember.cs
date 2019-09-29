using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.WeiXinBusinessLogic;
using ShopNum1.WeiXinInterface;

namespace ShopNum1.ShopAdminWebControl
{
    [ParseChildren(true)]
    public class W_ShopMember : BaseShopWebControl
    {
        private LinkButton LinkDelete;
        private int PageSize = 10;
        private HiddenField hid_SelectVip;
        private HtmlGenericControl pageDiv;
        private Repeater rep_WeiXinUser;
        private string skinFilename = "W_ShopMember.ascx";

        public W_ShopMember()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        protected void BindMember()
        {
            if (PageSize.ToString() == "")
            {
                PageSize = 10;
            }
            string currentpage = Common.Common.ReqStr("PageID");
            if (currentpage == "")
            {
                currentpage = "1";
            }
            IShopNum1_Weixin_ShopMember_Active active = new ShopNum1_Weixin_ShopMember_Active();
            DataTable table = active.SelectActivity(PageSize.ToString(), currentpage, S_condition(), "0");
            var pl = new PageList1
            {
                PageSize = PageSize,
                PageID = Convert.ToInt32(currentpage)
            };
            if ((table != null) && (table.Rows.Count > 0))
            {
                pl.RecordCount = Convert.ToInt32(table.Rows[0][0]);
            }
            else
            {
                pl.RecordCount = 0;
            }
            pageDiv.InnerHtml = new PageListBll("shop/ShopAdmin/W_ShopMember.aspx", true).GetPageListNew(pl);
            DataTable table2 = active.SelectActivity(PageSize.ToString(), currentpage, S_condition(), "1");
            rep_WeiXinUser.DataSource = table2;
            rep_WeiXinUser.DataBind();
        }

        protected override void InitializeSkin(Control skin)
        {
            rep_WeiXinUser = (Repeater) skin.FindControl("rep_WeiXinUser");
            pageDiv = (HtmlGenericControl) skin.FindControl("pageDiv");
            LinkDelete = (LinkButton) skin.FindControl("LinkDelete");
            hid_SelectVip = (HiddenField) skin.FindControl("hid_SelectVip");
            LinkDelete.Click += LinkDelete_Click;
            BindMember();
        }

        protected void LinkDelete_Click(object sender, EventArgs e)
        {
            IShopNum1_Weixin_ShopMember_Active active = new ShopNum1_Weixin_ShopMember_Active();
            active.ChangeVipGroup(base.MemLoginID, hid_SelectVip.Value, 1);
            BindMember();
        }

        private string S_condition()
        {
            return string.Format(" AND ShopMemLoginId = '{0}'", base.MemLoginID);
        }
    }
}