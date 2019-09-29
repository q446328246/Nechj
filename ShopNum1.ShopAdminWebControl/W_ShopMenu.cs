using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.WeiXinBusinessLogic;
using ShopNum1.WeiXinInterface;

namespace ShopNum1.ShopAdminWebControl
{
    [ParseChildren(true)]
    public class W_ShopMenu : BaseShopWebControl
    {
        private Repeater rep_menu;
        private string skinFilename = "W_ShopMenu.ascx";

        public W_ShopMenu()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        protected void BindMenu()
        {
            IShopNum1_Weixin_ShopMenu_Active active = new ShopNum1_Weixin_ShopMenu_Active();
            rep_menu.DataSource = active.Select_MenuByPid(base.MemLoginID, 0);
            rep_menu.DataBind();
        }

        protected override void InitializeSkin(Control skin)
        {
            rep_menu = (Repeater) skin.FindControl("rep_menu");
            rep_menu.ItemDataBound += rep_menu_ItemDataBound;
            BindMenu();
        }

        protected void rep_menu_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
            {
                var repeater = (Repeater) e.Item.FindControl("rep_chirldmenu");
                int pid = Convert.ToInt32((e.Item.DataItem as DataRowView).Row["ID"]);
                IShopNum1_Weixin_ShopMenu_Active active = new ShopNum1_Weixin_ShopMenu_Active();
                repeater.DataSource = active.Select_MenuByPid(base.MemLoginID, pid);
                repeater.DataBind();
            }
        }
    }
}