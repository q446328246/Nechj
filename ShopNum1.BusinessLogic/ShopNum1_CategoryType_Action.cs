using System;
using System.Collections.Generic;
using System.Data;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1MultiEntity;
using System.Data.Common;

namespace ShopNum1.BusinessLogic
{
    public class ShopNum1_CategoryType_Action : IShopNum1_CategoryType_Action
    {
        public int Add_CategoryType(ShopNum1_CategoryType shopNum1_CategoryType)
        {
            string[] strArray2;
            int num;
            var sqlList = new List<string>();
            string str =
                "insert into ShopNum1_CategoryType(name,description,orderid,createuser,modifyuser,isshow,spec_ids,pro_ids)values";
            object obj2 = str;
            obj2 =
                string.Concat(new[]
                {
                    obj2, "('", shopNum1_CategoryType.Name, "','", shopNum1_CategoryType.Description, "','",
                    shopNum1_CategoryType.OrderID, "',"
                });
            string str2 =
                string.Concat(new[]
                {
                    obj2, "'", shopNum1_CategoryType.CreateUser, "','", shopNum1_CategoryType.ModifyUser, "','",
                    shopNum1_CategoryType.IsShow, "',"
                });
            string str3 =
                DatabaseExcetue.ReturnString(str2 + "'" + shopNum1_CategoryType.Spec_Ids + "','" +
                                             shopNum1_CategoryType.Pro_Ids + "');SELECT @@IDENTITY AS returnName");
            if (shopNum1_CategoryType.Pro_Ids != "")
            {
                strArray2 = (shopNum1_CategoryType.Pro_Ids.Replace("L", "") + ",").Split(new[] {','});
                for (num = 0; num < strArray2.Length; num++)
                {
                    if (strArray2[num] != "")
                    {
                        sqlList.Add("INSERT INTO ShopNum1_TypeProp(TypeId,PropId)Values('" + str3 + "','" +
                                    strArray2[num] + "');");
                    }
                }
            }
            if (shopNum1_CategoryType.Spec_Ids != "")
            {
                strArray2 = (shopNum1_CategoryType.Spec_Ids.Replace("J", "") + ",").Split(new[] {','});
                for (num = 0; num < strArray2.Length; num++)
                {
                    if (strArray2[num] != "")
                    {
                        sqlList.Add("INSERT INTO ShopNum1_TypeSpec(TypeId,SpecId)Values('" + str3 + "','" +
                                    strArray2[num] + "');");
                    }
                }
            }
            DatabaseExcetue.RunTransactionSql(sqlList);
            return 1;
        }

        public int Add_CategoryTypeInto(ShopNum1_CategoryType shopNum1_CategoryType)
        {
            var sqlList = new List<string>();
            string str =
                "insert into ShopNum1_CategoryType(name,description,orderid,createuser,modifyuser,isshow,spec_ids,pro_ids)values";
            object obj2 = str;
            obj2 =
                string.Concat(new[]
                {
                    obj2, "('", shopNum1_CategoryType.Name, "','", shopNum1_CategoryType.Description, "','",
                    shopNum1_CategoryType.OrderID, "',"
                });
            string str3 =
                string.Concat(new[]
                {
                    obj2, "'", shopNum1_CategoryType.CreateUser, "','", shopNum1_CategoryType.ModifyUser, "','",
                    shopNum1_CategoryType.IsShow, "',"
                });
            string str2 =
                DatabaseExcetue.ReturnString(str3 + "'" + shopNum1_CategoryType.Spec_Ids + "','" +
                                             shopNum1_CategoryType.Pro_Ids + "');SELECT @@IDENTITY AS returnName");
            DatabaseExcetue.RunTransactionSql(sqlList);
            return Convert.ToInt32(str2);
        }

        public int DeleteBatch_CategoryType(string strId)
        {
                DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@strId";
            parms[0].Value = strId;
            return DatabaseExcetue.RunNonQuery("delete from ShopNum1_CategoryType where id in(@strId)",parms);
        }

        public string Get_SpValue(string strId)
        {
            return
                DatabaseExcetue.ReturnString(
                    "select (spec_ids+'|'+pro_ids)spvalue from ShopNum1_CategoryType where id='" + strId + "'");
        }

        public int Get_TypeMaxId()
        {
            string strSql = "select max(id)+1 from ShopNum1_CategoryType";
            return Convert.ToInt32(DatabaseExcetue.ReturnString(strSql));
        }

        public ShopNum1_CategoryType Select_CategoryType(string strID)
        {
                DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@strID";
            parms[0].Value = strID;
            var type = new ShopNum1_CategoryType();
            DataTable table =
                DatabaseExcetue.ReturnDataTable(
                    "select name,description,orderid,spec_ids,pro_ids,isshow from ShopNum1_CategoryType where id=@strID",parms);
            if (table.Rows.Count > 0)
            {
                type.Name = table.Rows[0]["name"].ToString();
                type.IsShow = Convert.ToInt32(table.Rows[0]["isshow"]);
                type.Description = table.Rows[0]["description"].ToString();
                type.OrderID = Convert.ToInt32(table.Rows[0]["orderid"].ToString());
                type.Spec_Ids = table.Rows[0]["spec_ids"].ToString();
                type.Pro_Ids = table.Rows[0]["pro_ids"].ToString();
            }
            return type;
        }

        public DataTable Select_ProductCategoryType()
        {
            string strSql = "select id as code,id,name from ShopNum1_CategoryType where isdeleted=0";
            return DatabaseExcetue.ReturnDataTable(strSql);
        }

        public DataTable SelectCategoryType_List(int pagesize, int currentpage, string strcondition, int resultnum)
        {
            var paraName = new string[7];
            var paraValue = new string[7];
            paraName[0] = "pagesize";
            paraValue[0] = pagesize.ToString();
            paraName[1] = "currentpage";
            paraValue[1] = currentpage.ToString();
            paraName[2] = "columns";
            paraValue[2] = "name,id,orderid";
            paraName[3] = "tablename";
            paraValue[3] = "ShopNum1_CategoryType";
            paraName[4] = "condition";
            paraValue[4] = " and isdeleted=0";
            paraName[5] = "ordercolumn";
            paraValue[5] = "orderid";
            paraName[6] = "resultnum";
            paraValue[6] = resultnum.ToString();
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_CommonPager_two", paraName, paraValue);
        }

        public int Update_CategoryType(ShopNum1_CategoryType shopNum1_CategoryType)
        {
            string[] strArray2;
            int num;
            var sqlList = new List<string>();
            object obj2 = "update ShopNum1_CategoryType set name='" + shopNum1_CategoryType.Name + "',description='" +
                          shopNum1_CategoryType.Description + "'";
            obj2 =
                string.Concat(new[]
                {
                    obj2, ",orderid='", shopNum1_CategoryType.OrderID, "',modifyuser='",
                    shopNum1_CategoryType.ModifyUser, "',"
                });
            obj2 =
                string.Concat(new[]
                {
                    obj2, "isshow='", shopNum1_CategoryType.IsShow, "',spec_ids='", shopNum1_CategoryType.Spec_Ids,
                    "',pro_ids='", shopNum1_CategoryType.Pro_Ids, "'"
                });
            string item = string.Concat(new[] {obj2, " where id='", shopNum1_CategoryType.ID, "';"});
            sqlList.Add(item);
            sqlList.Add("delete from ShopNum1_TypeProp where typeId='" + shopNum1_CategoryType.ID + "';");
            if (shopNum1_CategoryType.Pro_Ids != "")
            {
                strArray2 = (shopNum1_CategoryType.Pro_Ids.Replace("L", "") + ",").Split(new[] {','});
                for (num = 0; num < strArray2.Length; num++)
                {
                    if (strArray2[num] != "")
                    {
                        sqlList.Add(
                            string.Concat(new object[]
                            {
                                "INSERT INTO ShopNum1_TypeProp(TypeId,PropId)Values('", shopNum1_CategoryType.ID,
                                "','"
                                , strArray2[num], "');"
                            }));
                    }
                }
            }
            sqlList.Add("delete from ShopNum1_TypeSpec where typeId='" + shopNum1_CategoryType.ID + "';");
            if (shopNum1_CategoryType.Spec_Ids != "")
            {
                strArray2 = (shopNum1_CategoryType.Spec_Ids.Replace("J", "") + ",").Split(new[] {','});
                for (num = 0; num < strArray2.Length; num++)
                {
                    if (strArray2[num] != "")
                    {
                        sqlList.Add(
                            string.Concat(new object[]
                            {
                                "INSERT INTO ShopNum1_TypeSpec(TypeId,SpecId)Values('", shopNum1_CategoryType.ID,
                                "','"
                                , strArray2[num], "');"
                            }));
                    }
                }
            }
            DatabaseExcetue.RunTransactionSql(sqlList);
            return 1;
        }

        public int update_CategoryType_Order(string strorderid, string strId)
        {
                DbParameter[] parms = DatabaseExcetue.CreateParameter(2);
            parms[0].ParameterName = "@strorderid";
            parms[0].Value = strorderid;
            parms[1].ParameterName = "@strId";
            parms[1].Value = strId;
            return
                DatabaseExcetue.RunNonQuery("update ShopNum1_CategoryType set orderid=@strorderid' where id=@strId",parms);
        }
    }
}