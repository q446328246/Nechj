using System.Data;
using ShopNum1.DataAccess;
using ShopNum1.ShopInterface;
using ShopNum1MultiEntity;

namespace ShopNum1.ShopBusinessLogic
{
    public class Shop_URLManage_Action : IShop_URLManage_Action
    {
        public int AddURLManage(ShopNum1_ShopURLManage shopURLManage)
        {
            var paraName = new string[5];
            var paraValue = new string[5];
            paraName[0] = "@Domain";
            paraValue[0] = shopURLManage.DoMain;
            paraName[1] = "@MemLoginID";
            paraValue[1] = shopURLManage.MemLoginID;
            paraName[2] = "@IsAudit";
            paraValue[2] = shopURLManage.IsAudit.ToString();
            paraName[3] = "@GoUrl";
            paraValue[3] = shopURLManage.GoUrl;
            paraName[4] = "@SiteNumber";
            paraValue[4] = shopURLManage.SiteNumber;
            return DatabaseExcetue.RunProcedure("Pro_Shop_AddURLManage", paraName, paraValue);
        }

        public DataTable CheckURLManageByDoMain(string domain)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@domain";
            paraValue[0] = domain;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_CheckURLManageByDoMain", paraName, paraValue);
        }

        public int DeleteURLManage(string guid)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@id";
            paraValue[0] = guid;
            return DatabaseExcetue.RunProcedure("Pro_Shop_DeleteURLManage", paraName, paraValue);
        }

        public DataTable GetUrlManage(string string_0)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@id";
            paraValue[0] = string_0;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetURLManage", paraName, paraValue);
        }

        public DataTable GetUrlManageList(string memLoginID, string isaudit)
        {
            var paraName = new string[2];
            var paraValue = new string[2];
            paraName[0] = "@MemLoginID";
            paraValue[0] = memLoginID;
            paraName[1] = "@isaudit";
            paraValue[1] = isaudit;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetURLManageList", paraName, paraValue);
        }

        public int UpdateURLManage(ShopNum1_ShopURLManage shopNum1_ShopURLManage)
        {
            var paraName = new string[4];
            var paraValue = new string[4];
            paraName[0] = "@id";
            paraValue[0] = shopNum1_ShopURLManage.ID.ToString();
            paraName[1] = "@domain";
            paraValue[1] = shopNum1_ShopURLManage.DoMain;
            paraName[2] = "@isaudit";
            paraValue[2] = shopNum1_ShopURLManage.IsAudit.ToString();
            paraName[3] = "@SiteNumber";
            paraValue[3] = shopNum1_ShopURLManage.SiteNumber;
            return DatabaseExcetue.RunProcedure("Pro_Shop_UpdateURLManage", paraName, paraValue);
        }

        public DataTable GetEditInfo(string ID)
        {
            return
                DatabaseExcetue.ReturnDataTable("    SELECT * FROM ShopNum1_ShopURLManage  WHERE  ID  ='" +
                                                ID.Replace("'", "") + "'        ");
        }

        public DataTable Select_List(CommonPageModel commonModel)
        {
            var paraName = new string[8];
            var paraValue = new string[8];
            paraName[0] = "@pagesize";
            paraValue[0] = commonModel.PageSize;
            paraName[1] = "@currentpage";
            paraValue[1] = commonModel.Currentpage;
            paraName[2] = "@columns";
            paraValue[2] = " * ";
            paraName[3] = "@tablename";
            paraValue[3] = "ShopNum1_ShopURLManage";
            paraName[4] = "@condition";
            paraValue[4] = commonModel.Condition;
            paraName[5] = "@ordercolumn";
            paraValue[5] = "AddTime";
            paraName[6] = "@sortvalue";
            paraValue[6] = "desc";
            paraName[7] = "@resultnum";
            paraValue[7] = commonModel.Resultnum;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_CommonPager", paraName, paraValue);
        }
    }
}