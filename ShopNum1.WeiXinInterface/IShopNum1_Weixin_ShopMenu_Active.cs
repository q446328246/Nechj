using System.Collections.Generic;
using System.Data;
using ShopNum1.WeiXinCommon.model;

namespace ShopNum1.WeiXinInterface
{
    public interface IShopNum1_Weixin_ShopMenu_Active
    {
        string Add_menu(string menu_name, string menu_pid, string shopmemloginid);
        bool Add_Menu(List<MenuButton> menulist, string shopmemloginid);
        bool Del_menu(string id);
        bool Edit_menu(string menu_name, string id);
        DataTable Get_menubyid(string shopmemloginid, string id);
        DataTable Get_menubypid(string shopmemloginid, string pid);
        DataTable GetAllMenu(string shopmemloginid);
        DataTable Select_AllMenu(string shopmemloginid);
        DataTable Select_MenuByPid(string shopmemloginid, int pid);
        bool UpdateView(string id, string url);
    }
}