using System.Data;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using System.Data.Common;

namespace ShopNum1.BusinessLogic
{
    public class ShopNum1_SpecificationProudctCategory_Action : IShopNum1_SpecificationProudctCategory_Action
    {
        public bool Check(string productcategoryid)
        {
            string strSql =
                "SELECT COUNT(ID) AS AllCount FROM dbo.ShopNum1_SpecificationProudctCategory WHERE ProductCategoryID=@ProductCategoryID";
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@productcategoryid";
            paraValue[0] = productcategoryid;
            return DatabaseExcetue.CheckExists(strSql, paraName, paraValue);
        }

        public int DeleteByProductCategoryID(string productCategoryID)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@productCategoryID";
            parms[0].Value = productCategoryID;
                                                   
            return
                DatabaseExcetue.RunNonQuery(
                    "delete from ShopNum1_SpecificationProudctCategory where ProductCategoryID=@productCategoryID",parms);
        }

        public string GetSpecNamesString(string productcategoryid)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@productcategoryid";
            paraValue[0] = productcategoryid;
            object obj2 = DatabaseExcetue.ReturnProcedureString("Pro_ShopNum1_SpecificationProudctCategoryGetName",
                paraName, paraValue);
            if (obj2 == null)
            {
                return string.Empty;
            }
            return obj2.ToString();
        }

        public DataTable GetSpecs(string productcategoryid)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@productcategoryid";
            paraValue[0] = productcategoryid;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_SpecificationProdCategoryGetspecs",
                paraName, paraValue);
        }

        public int Insert(string string_0, string productcategoryid, string productcategorycode, string specificationid)
        {
            var paraName = new string[4];
            var paraValue = new string[4];
            paraName[0] = "@id";
            paraValue[0] = string_0;
            paraName[1] = "@productcategoryid";
            paraValue[1] = productcategoryid;
            paraName[2] = "@productcategorycode";
            paraValue[2] = productcategorycode;
            paraName[3] = "@specificationid";
            paraValue[3] = specificationid;
            return DatabaseExcetue.RunProcedure("Pro_ShopNum1_SpecificationProudctCategoryInsert", paraName, paraValue);
        }

        public bool InsertMuch(string productcategoryid, string productcategorycode, string specificationid)
        {
            var paraName = new string[3];
            var paraValue = new string[3];
            paraName[0] = "@productcategoryid";
            paraValue[0] = productcategoryid;
            paraName[1] = "@productcategorycode";
            paraValue[1] = productcategorycode;
            paraName[2] = "@specificationid";
            paraValue[2] = specificationid;
            return
                (DatabaseExcetue.RunProcedure("Pro_ShopNum1_SpecificationProudctCategoryInsertMuch", paraName, paraValue) >
                 0);
        }
    }
}