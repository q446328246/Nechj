using System;
using System.Data;
using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1MultiEntity;
using System.Data.Common;

namespace ShopNum1.BusinessLogic
{
    public class ShopNum1_ZtcApply_Action : IShopNum1_ZtcApply_Action
    {
        public int Add(ShopNum1_ZtcApply ZtcApply)
        {
            return DatabaseExcetue.RunNonQuery(string.Concat(new object[]
            {
                "INSERT ShopNum1_ZtcApply(  ProductGuid, ProductName, MemberID, ShopID, ShopName, Ztc_Money, Remark, StartTime, ApplyTime, PayState, AuditState, AuditTime, OperateUser, OperateRemark, Type, CreateUser, CreateTime, IsDeleted ) VALUES (  '"
                , Operator.FilterString(ZtcApply.ProductGuid), "',  '", Operator.FilterString(ZtcApply.ProductName),
                "',  '", Operator.FilterString(ZtcApply.MemberID), "',  '", Operator.FilterString(ZtcApply.ShopID),
                "',  '", Operator.FilterString(ZtcApply.ShopName), "',  '",
                Operator.FilterString(ZtcApply.Ztc_Money), "',  '", Operator.FilterString(ZtcApply.Remark), "',  '",
                Operator.FilterString(ZtcApply.StartTime),
                "',  '", Operator.FilterString(ZtcApply.ApplyTime), "',  '",
                Operator.FilterString(ZtcApply.PayState), "',  '", Operator.FilterString(ZtcApply.AuditState),
                "',  '", Operator.FilterString(ZtcApply.AuditTime), "',  '",
                Operator.FilterString(ZtcApply.OperateUser), "',  '", Operator.FilterString(ZtcApply.OperateRemark),
                "',  '", Operator.FilterString(ZtcApply.Type), "',  '", Operator.FilterString(ZtcApply.CreateUser),
                "',  '", Operator.FilterString(ZtcApply.CreateTime), "',  ", ZtcApply.IsDeleted, " )"
            }));
        }

        public int Delete(string guids)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@guids";
            parms[0].Value = guids;
            return DatabaseExcetue.RunNonQuery("   DELETE ShopNum1_ZtcApply where  ID IN  (@guids)  ",parms);
        }

        public DataTable GetInfoByGuid(string guid)
        {

            string str = guid.Replace("'", "");
            return DatabaseExcetue.ReturnDataTable("   SELECT  * FROM  ShopNum1_ZtcApply  WHERE ID ='" + str + "'   ");
        }

        public DataTable Search(int IsDeleted)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@IsDeleted";
            parms[0].Value = IsDeleted;
            string strSql = string.Empty;
            strSql = "   SELECT   * FROM  ShopNum1_ZtcApply  WHERE 1=1   ";
            if ((IsDeleted == 0) || (IsDeleted == 1))
            {
                strSql = strSql + "   and   IsDeleted=@IsDeleted";
            }
            return DatabaseExcetue.ReturnDataTable(strSql,parms);
        }

        public int ChangeAuditState(string ID, int AuditState)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(2);

            parms[0].ParameterName = "@ID";
            parms[0].Value = ID;
            parms[1].ParameterName = "@AuditState";
            parms[1].Value = AuditState;
            return
                DatabaseExcetue.RunNonQuery(
                    string.Concat(new object[]
                    {
                        "  UPDATE  ShopNum1_ZtcApply  SET AuditState=@AuditState,AuditTime='", DateTime.Now,
                        "' WHERE ID =@ID    "
                    }),parms);
        }

        public DataTable GetInfo(string ProductName, string MemberID, string ShopName, string Type, string AuditState,
            string Time1, string Time2)
        {
            string str = string.Empty;
            str = "   SELECT  * FROM  ShopNum1_ZtcApply  WHERE 1=1   ";
            if (!string.IsNullOrEmpty(ProductName))
            {
                str = str + "    AND    ProductName LIKE  '%" + ProductName + "%'  ";
            }
            if (!string.IsNullOrEmpty(MemberID))
            {
                str = str + "    AND    MemberID  ='" + MemberID + "'  ";
            }
            if (!string.IsNullOrEmpty(ShopName))
            {
                str = str + "    AND    ShopName  ='" + ShopName + "'  ";
            }
            if (Type != "-1")
            {
                str = str + "    AND    Type  ='" + Type + "'  ";
            }
            if (AuditState != "-1")
            {
                str = str + "    AND    AuditState  ='" + AuditState + "'  ";
            }
            if (!string.IsNullOrEmpty(Time1))
            {
                str = str + "    AND    StartTime  >'" + Time1 + "'  ";
            }
            if (!string.IsNullOrEmpty(Time2))
            {
                str = str + "    AND    StartTime  <'" + Time2 + "'  ";
            }
            return DatabaseExcetue.ReturnDataTable(str + "    ORDER  BY   CreateTime  DESC        ");
        }

        public DataTable Search(string ProductName, int AuditState, string MemberID, int Type)
        {
            string str = string.Empty;
            str = "   SELECT   * FROM  ShopNum1_ZtcApply  WHERE 1=1   ";
            if ((AuditState == 0) || (AuditState == 1))
            {
                str = str + "   AND   AuditState=" + AuditState;
            }
            if (Type != -1)
            {
                str = str + "   AND   Type=" + Type;
            }
            if (!string.IsNullOrEmpty(ProductName))
            {
                str = str + "   AND   ProductName like'%" + ProductName + "%'";
            }
            return
                DatabaseExcetue.ReturnDataTable((str + "    AND  MemberID='" + MemberID + "'      ") +
                                                "   ORDER BY   CreateTime DESC   ");
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
            paraValue[3] = "ShopNum1_ZtcApply";
            paraName[4] = "@condition";
            paraValue[4] = commonModel.Condition;
            paraName[5] = "@ordercolumn";
            paraValue[5] = "ApplyTime";
            paraName[6] = "@sortvalue";
            paraValue[6] = "desc";
            paraName[7] = "@resultnum";
            paraValue[7] = commonModel.Resultnum;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_CommonPager_two", paraName, paraValue);
        }
    }
}