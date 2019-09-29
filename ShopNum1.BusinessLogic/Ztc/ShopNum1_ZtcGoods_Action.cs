using System;
using System.Data;
using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1MultiEntity;
using System.Data.Common;

namespace ShopNum1.BusinessLogic
{
    public class ShopNum1_ZtcGoods_Action : IShopNum1_ZtcGoods_Action
    {
        public int Add(ShopNum1_ZtcGoods ZtcGoods)
        {
            return DatabaseExcetue.RunNonQuery(string.Concat(new object[]
            {
                "INSERT ShopNum1_ZtcGoods(  ProductGuid, ProductPrice, SellPrice, SellCount, ZtcName, ZtcImg, Ztc_Money, StartTime, ShopName, State, CreateUser, CreateTime, ModifyUser, ModifyTime, MemberID, IsDeleted ) VALUES (  '"
                , Operator.FilterString(ZtcGoods.ProductGuid), "',  '", Operator.FilterString(ZtcGoods.ProductPrice)
                , "',  '", Operator.FilterString(ZtcGoods.SellPrice), "',  '",
                Operator.FilterString(ZtcGoods.SellCount), "',  '", Operator.FilterString(ZtcGoods.ZtcName), "',  '"
                , ZtcGoods.ZtcImg, "',  '", Operator.FilterString(ZtcGoods.Ztc_Money), "',  '",
                Operator.FilterString(ZtcGoods.StartTime),
                "',  '", Operator.FilterString(ZtcGoods.ShopName), "',  '", Operator.FilterString(ZtcGoods.State),
                "',  '", Operator.FilterString(ZtcGoods.CreateUser), "',  '",
                Operator.FilterString(ZtcGoods.CreateTime), "',  '", Operator.FilterString(ZtcGoods.ModifyUser),
                "',  '", Operator.FilterString(ZtcGoods.ModifyTime), "',  '",
                Operator.FilterString(ZtcGoods.MemberID), "',  ", ZtcGoods.IsDeleted,
                " )"
            }));
        }

        public int Delete(string guids)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@guids";
            parms[0].Value = guids;
            
            return DatabaseExcetue.RunNonQuery("   DELETE ShopNum1_ZtcGoods where  ID IN  (@guid)  ",parms);
        }

        public DataTable GetInfoByGuid(string guid)
        {
            string str = guid.Replace("'", "");
            return DatabaseExcetue.ReturnDataTable("   SELECT  * FROM  ShopNum1_ZtcGoods  WHERE ID ='" + str + "'   ");
        }

        public DataTable Search(int IsDeleted)
        {
            string strSql = string.Empty;
            strSql = "   SELECT   *  FROM  ShopNum1_ZtcGoods  WHERE 1=1 AND starttime<=getdate() ";
            if ((IsDeleted == 0) || (IsDeleted == 1))
            {
                strSql = strSql + "   and   IsDeleted=" + IsDeleted;
            }
            return DatabaseExcetue.ReturnDataTable(strSql);
        }

        public DataTable GetProduct(int topnumber, string ProductSeriesCode, string Name, string MemLoginID,
            int IsDeleted, int IsAudit, int IsSaled)
        {
            object obj2;
            string str = string.Empty;
            str = "   SELECT  top  " + topnumber + "    Guid ,Name   from    ShopNum1_Shop_Product      where  1=1   ";
            if (ProductSeriesCode != "0")
            {
                str = str + "    and   ProductSeriesCode like  '" + ProductSeriesCode + "%'   ";
            }
            if (!string.IsNullOrEmpty(Name))
            {
                str = str + "    and   Name like  '%" + Name + "%'   ";
            }
            str = str + "    and   MemLoginID =  '" + MemLoginID + "'   ";
            if ((IsDeleted == 1) || (IsDeleted == 0))
            {
                obj2 = str;
                str = string.Concat(new[] {obj2, "    and   IsDeleted =  '", IsDeleted, "'   "});
            }
            if ((IsAudit == 1) || (IsAudit == 0))
            {
                obj2 = str;
                str = string.Concat(new[] {obj2, "    and   IsAudit =  '", IsAudit, "'   "});
            }
            if ((IsSaled == 1) || (IsSaled == 0))
            {
                obj2 = str;
                str = string.Concat(new[] {obj2, "    and   IsSaled =  '", IsSaled, "'   "});
            }
            return DatabaseExcetue.ReturnDataTable(str + "   order  by   CreateTime  desc     ");
        }

        public DataTable GetProduct(int topnumber, string ProductSeriesCode, string Name, string MemLoginID,
            int IsDeleted, int IsAudit, int IsSaled, int IsPanicBuy, int IsSpellBuy)
        {
            object obj2;
            string str = string.Empty;
            str = "   SELECT  top  " + topnumber + "    Guid ,Name   from    ShopNum1_Shop_Product      where  1=1   ";
            if (ProductSeriesCode != "0")
            {
                str = str + "    and   ProductSeriesCode like  '" + ProductSeriesCode + "%'   ";
            }
            if (!string.IsNullOrEmpty(Name))
            {
                str = str + "    and   Name like  '%" + Name + "%'   ";
            }
            str = str + "    and   MemLoginID =  '" + MemLoginID + "'   ";
            if ((IsDeleted == 1) || (IsDeleted == 0))
            {
                obj2 = str;
                str = string.Concat(new[] {obj2, "    and   IsDeleted =  '", IsDeleted, "'   "});
            }
            if ((IsAudit == 1) || (IsAudit == 0))
            {
                obj2 = str;
                str = string.Concat(new[] {obj2, "    and   IsAudit =  '", IsAudit, "'   "});
            }
            if ((IsSaled == 1) || (IsSaled == 0))
            {
                obj2 = str;
                str = string.Concat(new[] {obj2, "    and   IsSaled =  '", IsSaled, "'   "});
            }
            return DatabaseExcetue.ReturnDataTable(str + "   order  by   CreateTime  desc     ");
        }

        public DataTable Search(string ZtcName, int State, string MemberID)
        {
            string str = string.Empty;
            str = "   SELECT   *  FROM  ShopNum1_ZtcGoods  WHERE 1=1   ";
            if (!string.IsNullOrEmpty(ZtcName))
            {
                str = str + "    ZtcName  LIKE  '%" + ZtcName + "%'  ";
            }
            if (State != -1)
            {
                object obj2 = str;
                str = string.Concat(new[] {obj2, "    State=  ", State, "  "});
            }
            return
                DatabaseExcetue.ReturnDataTable((str + "   AND    MemberID ='" + MemberID + "'   ") +
                                                "   ORDER BY   CreateTime  DESC     ");
        }

        public DataTable Search(string top1, string top2, int State)
        {
            string str = string.Empty;
            str = "    SELECT  * FROM  (SELECT  ROW_NUMBER() OVER (ORDER BY Ztc_Money DESC) AS ROWID, *     ";
            object obj2 = str;
            string str2 =
                string.Concat(new[] {obj2, "   FROM  ShopNum1_ZtcGoods   WHERE Ztc_Money>0 AND  State=", State, "    "});
            return
                DatabaseExcetue.ReturnDataTable(str2 + "   )AS B WHERE ROWID>=" + top1 + " AND  ROWID<=" + top2 + "    ");
        }

        public DataTable Search(string top1, string top2, int State, decimal Ztc_Money)
        {
            string str = string.Empty;
            str =
                "    SELECT  *,(select salenumber from shopnum1_shop_product where guid=b.productguid)salenumber FROM  (SELECT  ROW_NUMBER() OVER (ORDER BY Ztc_Money DESC) AS ROWID, *     ";
            object obj2 = str;
            string str2 =
                string.Concat(new[]
                {
                    obj2, "   FROM  ShopNum1_ZtcGoods z  WHERE Ztc_Money>=", Ztc_Money, " And StartTime<='",
                    DateTime.Now.ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss"), "' AND  State=", State, "    "
                });
            return
                DatabaseExcetue.ReturnDataTable(str2 + "   )AS B WHERE ROWID>=" + top1 + " AND  ROWID<=" + top2 + "    ");
        }

        public DataTable Search(string ZtcName, string ShopName, int State, int IsDeleted)
        {
            object obj2;
            string str = string.Empty;
            str = "    SELECT * FROM   ShopNum1_ZtcGoods   WHERE 1=1     ";
            if (!string.IsNullOrEmpty(ZtcName))
            {
                str = str + "   AND      ZtcName  LIKE  '%" + ZtcName + "%'    ";
            }
            if (!string.IsNullOrEmpty(ShopName))
            {
                str = str + "   AND      ShopName  LIKE  '%" + ShopName + "%'    ";
            }
            if (State != -1)
            {
                obj2 = str;
                str = string.Concat(new[] {obj2, "   AND      State  = ", State, "    "});
            }
            if (IsDeleted != -1)
            {
                obj2 = str;
                str = string.Concat(new[] {obj2, "   AND      IsDeleted  = ", IsDeleted, "    "});
            }
            return DatabaseExcetue.ReturnDataTable(str + "    ORDER  BY  CreateTime   DESC       ");
        }

        public DataTable SearchData(int State, decimal Ztc_Money)
        {
            string str = string.Empty;
            str = "    SELECT  id FROM  (SELECT  ROW_NUMBER() OVER (ORDER BY Ztc_Money DESC) AS ROWID, *     ";
            object obj2 = str;
            return
                DatabaseExcetue.ReturnDataTable(
                    string.Concat(new[]
                    {
                        obj2, "   FROM  ShopNum1_ZtcGoods   WHERE Ztc_Money>=", Ztc_Money,
                        " And starttime<=getdate()  AND  State=", State, "    "
                    }) + "   )AS B WHERE 1=1    ");
        }

        public DataTable SearchData(int State, decimal Ztc_Money, int page, int int_0)
        {
            int num = ((page*int_0) - int_0) + 1;
            int num2 = page*int_0;
            string str = string.Empty;
            str = "    SELECT  * FROM  (SELECT  ROW_NUMBER() OVER (ORDER BY Ztc_Money DESC) AS ROWID, *     ";
            object obj2 = str;
            obj2 =
                string.Concat(new[]
                {
                    obj2, "   FROM  ShopNum1_ZtcGoods   WHERE Ztc_Money>=", Ztc_Money, " And starttime<='",
                    DateTime.Now.ToLocalTime(), "' AND  State=", State, "    "
                });
            return
                DatabaseExcetue.ReturnDataTable(
                    string.Concat(new[] {obj2, "   )AS B WHERE ROWID>=", num, " AND  ROWID<=", num2, "    "}));
        }

        public DataTable SearchProductImage(string Guid)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@Guid";
            parms[0].Value = Guid.Replace("'","");
            string str = string.Empty;
            str = "   SELECT   OriginalImage  FROM  ShopNum1_Shop_Product  WHERE 1=1   ";
            return DatabaseExcetue.ReturnDataTable(str + "   and   Guid=@Guid",parms);
        }

        public DataTable SearchProductOrder(string Ztc_Money)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@Ztc_Money";
            parms[0].Value = Ztc_Money;
            string strSql = string.Empty;
            strSql = "   SELECT   COUNT(*)  FROM  ShopNum1_ZtcGoods  WHERE 1=1   ";
            if (!string.IsNullOrEmpty(Ztc_Money))
            {
                strSql = strSql + "   and  Ztc_Money >@Ztc_Money";
            }
            return DatabaseExcetue.ReturnDataTable(strSql,parms);
        }

        public DataTable SearchShopInfo(string MemLoginID)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@MemLoginID";
            parms[0].Value = MemLoginID;
            string str = string.Empty;
            str = "   SELECT   *   FROM  ShopNum1_ShopInfo  WHERE 1=1   ";
            return DatabaseExcetue.ReturnDataTable(str + "   and   MemLoginID=@MemLoginID",parms);
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
            paraValue[3] = "ShopNum1_ZtcGoods";
            paraName[4] = "@condition";
            paraValue[4] = commonModel.Condition;
            paraName[5] = "@ordercolumn";
            paraValue[5] = "CreateTime";
            paraName[6] = "@sortvalue";
            paraValue[6] = "desc";
            paraName[7] = "@resultnum";
            paraValue[7] = commonModel.Resultnum;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_CommonPager_two", paraName, paraValue);
        }

        public int TimeNessMoney(decimal money)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@money";
            parms[0].Value = money;
            return
                DatabaseExcetue.RunNonQuery(
                    string.Concat(new object[]
                    {
                        " UPDATE  ShopNum1_ZtcGoods  SET  Ztc_Money=Ztc_Money-@money  WHERE  Ztc_Money>=@money  AND  StartTime <=GETDATE()  AND State=1 AND IsDeleted=0 "
                    }),parms);
        }

        public int Update(string string_0, string ZtcName, string ZtcImg, string SellPrice, string SellCount)
        {
            object obj2 = ((("    UPDATE   ShopNum1_ZtcGoods  SET     " + "   ZtcName ='" + ZtcName + "',     ") +
                            "   ZtcImg ='" + ZtcImg + "',     ") + "   SellPrice ='" + SellPrice + "',     ") +
                          "   SellCount ='" + SellCount + "',     ";
            return
                DatabaseExcetue.RunNonQuery(string.Concat(new[] {obj2, "   ModifyTime ='", DateTime.Now, "'     "}) +
                                            "   WHERE  ID='" + string_0 + "'     ");
        }

        public int UpdateAddMoney(string ID, decimal Ztc_Money)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(2);

            parms[0].ParameterName = "@ID";
            parms[0].Value = ID;
            parms[1].ParameterName = "@Ztc_Money";
            parms[1].Value = Ztc_Money;
            return
                DatabaseExcetue.RunNonQuery(
                    string.Concat(new object[]
                    {
                        "  UPDATE   ShopNum1_ZtcGoods  SET   Ztc_Money=Ztc_Money+@Ztc_Money,ModifyTime='",
                        DateTime.Now, "'  WHERE   ID   =@ID     "
                    }),parms);
        }

        public int UpdateState(string string_0, int State)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(2);

            parms[0].ParameterName = "@string_0";
            parms[0].Value = string_0;
            parms[1].ParameterName = "@State";
            parms[1].Value = State;
            return
                DatabaseExcetue.RunNonQuery(
                    string.Concat(new object[]
                    {
                        "  UPDATE   ShopNum1_ZtcGoods  SET   State=@State  WHERE   ID   IN  (@string_0)     "
                    }),parms);
        }
    }
}