using System.Collections.Generic;
using System.Data;
using System.Text;
using ShopNum1.DataAccess;
using ShopNum1.WeiXinCommon.model;
using ShopNum1.WeiXinInterface;

namespace ShopNum1.WeiXinBusinessLogic
{
    public class ShopNum1_Weixin_ShopMenu_Active : IShopNum1_Weixin_ShopMenu_Active
    {
        public string Add_menu(string menu_name, string menu_pid, string shopmemloginid)
        {
            return
                DatabaseExcetue.ReturnString(
                    string.Format(
                        "Insert into ShopNum1_Weixin_ShopMenu(Name,PId,ShopMemLoginId)\r\n                                            values('{0}','{1}','{2}');SELECT @@IDENTITY",
                        menu_name, menu_pid, shopmemloginid));
        }

        public bool Add_Menu(List<MenuButton> menulist, string shopmemloginid)
        {
            var builder = new StringBuilder();
            builder.AppendFormat(" SET XACT_ABORT ON", new object[0]).AppendLine();
            builder.AppendFormat(" BEGIN TRANSACTION", new object[0]).AppendLine();
            builder.AppendFormat("DELETE [dbo].[ShopNum1_Weixin_ShopMenu] WHERE [ShopMemLoginId] = '{0}'",
                shopmemloginid).AppendLine();
            builder.AppendFormat("DECLARE @pid  int;", new object[0]).AppendLine();
            foreach (MenuButton button in menulist)
            {
                builder.AppendFormat(
                    "INSERT INTO [dbo].[ShopNum1_Weixin_ShopMenu]([ShopMemLoginId],[Name],[PId],[value],[Sort])\r\n                                      VALUES('{0}','{1}',0,'{2}','{3}')",
                    new object[] {shopmemloginid, button.Name, button.Value, button.Sort}).AppendLine();
                builder.AppendFormat("SELECT @pid = @@IDENTITY", new object[0]).AppendLine();
                foreach (MenuButton button2 in button.SubButton)
                {
                    builder.AppendFormat(
                        "INSERT INTO [dbo].[ShopNum1_Weixin_ShopMenu]([ShopMemLoginId],[Name],[PId],[value],[Sort])\r\n                                      VALUES('{0}','{1}',@pid,'{2}','{3}')",
                        new object[] {shopmemloginid, button2.Name, button2.Value, button2.Sort}).AppendLine();
                }
            }
            builder.AppendFormat(" COMMIT TRANSACTION", new object[0]).AppendLine();
            return (DatabaseExcetue.RunNonQuery(builder.ToString()) > 0);
        }

        public bool Del_menu(string id)
        {
            return
                (DatabaseExcetue.RunNonQuery(
                    string.Format(
                        "delete dbo.ShopNum1_Weixin_ReplyRule where Id in (select ruleid from ShopNum1_Weixin_ReplyRuleKey where keyword in (select [key] from ShopNum1_Weixin_ShopMenu where ID = '{0}' or [PId] = '{0}'))\r\n                                            delete dbo.ShopNum1_Weixin_ReplyRuleContent where ruleid in (select ruleid from ShopNum1_Weixin_ReplyRuleKey where keyword in (select [key] from ShopNum1_Weixin_ShopMenu where ID = '{0}' or [PId] = '{0}')) \r\n                                            delete dbo.ShopNum1_Weixin_ReplyRuleKey where ruleid in (select ruleid from ShopNum1_Weixin_ReplyRuleKey where keyword in (select [key] from ShopNum1_Weixin_ShopMenu where ID = '{0}' or [PId] = '{0}')) \r\n                                            delete  ShopNum1_Weixin_ShopMenu where ID = '{0}' or [PId] = '{0}';",
                        id)) > 0);
        }

        public bool Edit_menu(string menu_name, string id)
        {
            return
                (DatabaseExcetue.RunNonQuery(
                    string.Format("update  ShopNum1_Weixin_ShopMenu set Name = '{0}' where ID = '{1}'", menu_name, id)) >
                 0);
        }

        public DataTable Get_menubyid(string shopmemloginid, string id)
        {
            return
                DatabaseExcetue.ReturnDataTable(
                    string.Format(
                        "with tab as\r\n                                            (\r\n                                            SELECT [ID],[ShopMemLoginId],[Name],[PId],[Type],[Sort],[Key],[Url]\r\n                                            FROM [dbo].[ShopNum1_Weixin_ShopMenu] Where ShopMemLoginId = '{0}' and ID = '{1}'\r\n                                            ) \r\n\r\n                                            select tab.[ID],[ShopMemLoginId],[Name],[PId],[Sort],IsNull([type],'') as [type],IsNull([key],'') as [key],IsNull(url,'') as url,IsNull(taba.ruleid,'0') as ruleid from tab \r\n                                            left join dbo.ShopNum1_Weixin_ReplyRuleKey as taba on tab.[key]=taba.keyword",
                        shopmemloginid, id));
        }

        public DataTable Get_menubypid(string shopmemloginid, string pid)
        {
            return
                DatabaseExcetue.ReturnDataTable(
                    string.Format(
                        "with tab as\r\n                                            (\r\n                                            SELECT [ID],[ShopMemLoginId],[Name],[PId],[Type],[Sort],[Key],[Url]\r\n                                            FROM [dbo].[ShopNum1_Weixin_ShopMenu] Where ShopMemLoginId = '{0}' and PId = '{1}'\r\n                                            ) \r\n\r\n                                            select tab.[ID],[ShopMemLoginId],[Name],[PId],[Sort],IsNull([type],'') as [type],IsNull([key],'') as [key],IsNull(url,'') as url,IsNull(taba.ruleid,'0') as ruleid from tab \r\n                                            left join dbo.ShopNum1_Weixin_ReplyRuleKey as taba on tab.[key]=taba.keyword",
                        shopmemloginid, pid));
        }

        public DataTable GetAllMenu(string shopmemloginid)
        {
            return
                DatabaseExcetue.ReturnDataTable(
                    string.Format(
                        "select id,[name],pid,IsNull([type],'') as [type],IsNull([key],'') as [key],IsNull(url,'') as url from dbo.ShopNum1_Weixin_ShopMenu where shopmemloginid = '{0}'",
                        shopmemloginid));
        }

        public DataTable Select_AllMenu(string shopmemloginid)
        {
            return
                DatabaseExcetue.ReturnDataTable(
                    string.Format(
                        "SELECT [ID],[ShopMemLoginId],[Name],[PId],[value],[Sort] FROM [dbo].[ShopNum1_Weixin_ShopMenu] WHERE ShopMemLoginId = '{0}' Order by Sort",
                        shopmemloginid));
        }

        public DataTable Select_MenuByPid(string shopmemloginid, int pid)
        {
            return
                DatabaseExcetue.ReturnDataTable(
                    string.Format(
                        "SELECT [ID],[ShopMemLoginId],[Name],[PId],[value],[Sort] FROM [dbo].[ShopNum1_Weixin_ShopMenu] WHERE ShopMemLoginId = '{0}' AND PId = '{1}' Order by Sort",
                        shopmemloginid, pid));
        }

        public bool UpdateView(string id, string url)
        {
            return
                (DatabaseExcetue.RunNonQuery(
                    string.Format("update [ShopNum1_Weixin_ShopMenu] set Type = 'view',url='{0}' where id = '{1}'", url,
                        id)) > 0);
        }
    }
}