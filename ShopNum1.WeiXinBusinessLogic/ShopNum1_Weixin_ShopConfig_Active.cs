using System.Collections.Generic;
using System.Data;
using System.Text;
using ShopNum1.DataAccess;
using ShopNum1.WeiXinInterface;
using ShopNum1MultiEntity;

namespace ShopNum1.WeiXinBusinessLogic
{
    public class ShopNum1_Weixin_ShopConfig_Active : IShopNum1_Weixin_ShopConfig_Active
    {
        public bool Add(List<ShopNum1_Weixin_ShopConfig> configlist, string shopid)
        {
            var builder = new StringBuilder();
            builder.AppendFormat(" SET XACT_ABORT ON", new object[0]).AppendLine();
            builder.AppendFormat(" BEGIN TRANSACTION", new object[0]).AppendLine();
            builder.AppendFormat("DELETE [dbo].[ShopNum1_Weixin_ShopConfig] WHERE ShopID = '{0}'", shopid).AppendLine();
            foreach (ShopNum1_Weixin_ShopConfig config in configlist)
            {
                builder.AppendFormat(
                    "INSERT INTO [dbo].[ShopNum1_Weixin_ShopConfig]\r\n                                      ([ShopID],[Value],[Url],[ConfigType]) \r\n                                      VALUES('{0}','{1}','{2}','{3}')",
                    new object[] {config.ShopID, config.Value, config.Url, config.ConfigType}).AppendLine();
            }
            builder.AppendFormat(" COMMIT TRANSACTION", new object[0]).AppendLine();
            return (DatabaseExcetue.RunNonQuery(builder.ToString()) > 0);
        }

        public DataTable Get_Config(string shopid)
        {
            return
                DatabaseExcetue.ReturnDataTable(
                    string.Format(
                        "SELECT [ID],[ShopID],[Value],[Url],[ConfigType] FROM [dbo].[ShopNum1_Weixin_ShopConfig]\r\n                                            WHERE ShopID = '{0}'",
                        shopid));
        }
    }
}