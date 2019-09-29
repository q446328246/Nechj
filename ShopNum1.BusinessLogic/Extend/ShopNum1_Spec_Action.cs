using System;
using System.Collections.Generic;
using System.Data;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1MultiEntity;
using System.Data.Common;

namespace ShopNum1.BusinessLogic
{
    public class ShopNum1_Spec_Action : IShopNum1_Spec_Action
    {
        public int AddTbCat(string string_0, string name, string CreateTime)
        {
            return
                DatabaseExcetue.RunNonQuery("Insert into ShopNum1_TbCat (cid,name,CreateTime)values(" + string_0 + ",'" +
                                            name + "','" + CreateTime + "')");
        }

        public int Delete(string strguid)
        {
            string item = string.Empty;
            var sqlList = new List<string>();
            item = "Delete From ShopNum1_Spec Where ID in (" + strguid + ")";
            sqlList.Add(item);
            item = "Delete From ShopNum1_SpecValue Where SpecID in (" + strguid + ")";
            sqlList.Add(item);
            item = "Delete From ShopNum1_SpecProudctDetails where SpecId in(" + strguid + ")";
            sqlList.Add(item);
            try
            {
                DatabaseExcetue.RunTransactionSql(sqlList);
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        public int DeleteValue(string dguid)
        {
            string format = string.Empty;
            format = "delete from  ShopNum1_SpecValue  where id={0}";
            return DatabaseExcetue.RunNonQuery(string.Format(format, dguid));
        }

        public int GetMaxGuid()
        {
            string strSql = "select max(ID) as MaxId  from ShopNum1_Spec";
            DataTable table = DatabaseExcetue.ReturnDataTable(strSql);
            if ((table == null) || (table.Rows.Count == 0))
            {
                return 1;
            }
            if (table.Rows[0]["MaxId"] == DBNull.Value)
            {
                return 1;
            }
            return (Convert.ToInt32(table.Rows[0]["MaxId"]) + 1);
        }

        public DataTable GetTbCid(string string_0)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@string_0";
            parms[0].Value = string_0;
            return
                DatabaseExcetue.ReturnDataTable("Select Count(*) as CidCount from  ShopNum1_TbCat where cid=@string_0",parms);
        }

        public DataTable Search()
        {
            string strSql = string.Empty;
            strSql = "Select *,dbo.fun_Specstr(id)as detailSpec From ShopNum1_Spec";
            return DatabaseExcetue.ReturnDataTable(strSql);
        }

        public DataTable Search_Type_Spec(string strId)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@strId";
            parms[0].Value = strId;
            return
                DatabaseExcetue.ReturnDataTable(
                    "Select ID,SpecName,dbo.fun_Specstr(id)as detailSpec,(select specid from ShopNum1_TypeSpec where typeid=@strId and TypeID!=0 and specid=t.id)ischeck From ShopNum1_Spec as t",parms);
        }

        public DataTable SearchByGuid(string guid)
        {
            string format = string.Empty;
            format =
                "Select a.id,a.SpecName,a.Memo,a.OrderID,a.ShowType,b.Name,b.orderid oid,b.Imagepath,b.id as DGuid,cast(a.id as varchar(50))+':'+cast(b.id as varchar(50))  as 'DetailGuid' From ShopNum1_Spec as a,ShopNum1_Specvalue as b Where a.id=b.Specid And a.id={0} order by b.orderid asc";
            return DatabaseExcetue.ReturnDataTable(string.Format(format, guid));
        }

        public DataTable SearchName(string guids)
        {
            List<DbParameter> parms = new List<DbParameter>();

            string andSql = string.Format(" in ({0})", DatabaseExcetue.GetGuidsSql(guids, parms));

            
            return
                DatabaseExcetue.ReturnDataTable(
                    "Select id,SpecName,ShowType,OrderID,Memo From ShopNum1_Spec Where id"+andSql,parms.ToArray());
        }

        public DataTable SearchNameByGuid(string strGuid)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@strGuid";
            parms[0].Value = strGuid;
            return
                DatabaseExcetue.ReturnDataTable(
                    "select specname from ShopNum1_Spec where id in(select specid from ShopNum1_SpecProudctDetails where productguid=@strGuid) order by orderid asc",parms);
        }

        public DataTable SpecDetailsGetByTbPropValue(string tbpropvalue)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@tbpropvalue";
            paraValue[0] = tbpropvalue;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_SpecificationDetailsGetByTbPropValue",
                paraName, paraValue);
        }

        public DataTable SpecificationDetailsGetByTbPropValue(string tbpropvalue)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@tbpropvalue";
            paraValue[0] = tbpropvalue;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_SpecificationDetailsGetByTbPropValue",
                paraName, paraValue);
        }

        public int Add(ShopNum1_Spec shopNum1_Spec, List<ShopNum1_SpecValue> listSpecValue)
        {
            var sqlList = new List<string>();
            string str2 =
                DatabaseExcetue.ReturnString(
                    string.Concat(new object[]
                    {
                        "Insert Into ShopNum1_Spec(SpecName,Memo,ShowType,OrderID,tbProp)Values('",
                        shopNum1_Spec.SpecName, "','", shopNum1_Spec.Memo, "',", shopNum1_Spec.ShowType, ",",
                        shopNum1_Spec.OrderID, ",'", shopNum1_Spec.tbProp, "');select @@IDENTITY"
                    }));
            if ((listSpecValue != null) && (listSpecValue.Count > 0))
            {
                for (int i = 0; i < listSpecValue.Count; i++)
                {
                    string item =
                        string.Concat(new object[]
                        {
                            "Insert Into ShopNum1_SpecValue(Specid,Name,Imagepath,orderid,tbPropValue)Values('",
                            str2,
                            "','", listSpecValue[i].Name, "','", listSpecValue[i].Imagepath, "','",
                            listSpecValue[i].OrderId, "','", listSpecValue[i].tbPropValue, "')"
                        });
                    sqlList.Add(item);
                }
            }
            try
            {
                DatabaseExcetue.RunTransactionSql(sqlList);
                return 1;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public int Update(ShopNum1_Spec shopNum1_Spec, List<ShopNum1_SpecValue> listSpecValue)
        {
            string format = string.Empty;
            string str2 = string.Empty;
            var sqlList = new List<string>();
            format = "update ShopNum1_Spec set SpecName='{0}',Memo='{1}',ShowType={2},OrderID={3} where id={4}";
            format = string.Format(format,
                new object[]
                {
                    shopNum1_Spec.SpecName, shopNum1_Spec.Memo, shopNum1_Spec.ShowType,
                    shopNum1_Spec.OrderID, shopNum1_Spec.ID.ToString()
                });
            sqlList.Add(format);
            if ((listSpecValue != null) && (listSpecValue.Count > 0))
            {
                for (int i = 0; i < listSpecValue.Count; i++)
                {
                    if (listSpecValue[i].ID == 0)
                    {
                        str2 =
                            "insert into ShopNum1_SpecValue(Specid,Name,Imagepath,tbPropValue,orderid) values({0},'{1}','{2}','{3}','{4}')";
                        str2 = string.Format(str2,
                            new object[]
                            {
                                listSpecValue[i].SpecID, listSpecValue[i].Name,
                                listSpecValue[i].Imagepath, listSpecValue[i].tbPropValue,
                                listSpecValue[i].OrderId
                            });
                    }
                    else
                    {
                        str2 = "update ShopNum1_Specvalue set orderid='{0}', Name='{1}',Imagepath='{2}' where id={3}";
                        str2 = string.Format(str2,
                            new object[]
                            {
                                listSpecValue[i].OrderId, listSpecValue[i].Name,
                                listSpecValue[i].Imagepath, listSpecValue[i].ID
                            });
                    }
                    sqlList.Add(str2);
                }
            }
            try
            {
                DatabaseExcetue.RunTransactionSql(sqlList);
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        public int AddByCid(ShopNum1_Spec sepc, List<ShopNum1_SpecValue> listSpecValue)
        {
            string item = string.Empty;
            var sqlList = new List<string>();
            item =
                string.Concat(new object[]
                {
                    string.Concat(new object[]
                    {
                        "Insert Into ShopNum1_Spec(SpecName,Memo,ShowType,OrderID,tbProp)Values('",
                        sepc.SpecName,
                        "','", sepc.Memo, "',", sepc.ShowType, ",", sepc.OrderID, ",'", sepc.tbProp, "')"
                    })
                });
            sqlList.Add(item);
            if ((listSpecValue != null) && (listSpecValue.Count > 0))
            {
                for (int i = 0; i < listSpecValue.Count; i++)
                {
                    string str2 =
                        string.Concat(new object[]
                        {
                            "Insert Into ShopNum1_SpecValue(Name,imagepath,tbPropValue)Values('" +
                            listSpecValue[i].Name + "','" + listSpecValue[i].Imagepath + "','" +
                            listSpecValue[i].tbPropValue + "')"
                        });
                    sqlList.Add(str2);
                }
            }
            try
            {
                DatabaseExcetue.RunTransactionSql(sqlList);
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        public bool CheckSpecValueBySguid(string sguid)
        {
            return
                (Convert.ToInt32(
                    DatabaseExcetue.ReturnDataTable(
                        string.Format("SELECT COUNT(*) AS Num FROM ShopNum1_SpecValue WHERE Specid in(" + sguid + ")",
                            sguid)).Rows[0]["Num"]) > 0);
        }

        public DataTable dt_GetSp(string strId)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@strId";
            parms[0].Value = strId;
                                                   
            return
                DatabaseExcetue.ReturnDataTable(
                    "SELECT id,SpecName,showType FROM dbo.ShopNum1_Spec where id in (select specid from ShopNum1_TypeSpec where typeid=@strId) ORDER BY OrderID ASC",parms);
        }

        public DataTable dt_SubSpec(string strSid, string strPid)
        {
            try
            {
                strPid = (((strPid == "") || (strPid == "0")) || (strPid.Length != 0x24))
                    ? "null"
                    : ("'" + strPid + "'");
                return
                    DatabaseExcetue.ReturnDataTable(
                        "SELECT Id,Name,ImagePath,(SELECT TOP 1 specvalueid FROM dbo.ShopNum1_SpecProudctDetails WHERE SpecValueId=t.id and ProductGuid=" +
                        strPid +
                        ")tc,(SELECT TOP 1 SpecValueName FROM ShopNum1_SpecProudctDetails WHERE SpecValueId=t.id and ProductGuid=" +
                        strPid +
                        ")tv,(SELECT TOP 1 productimage FROM ShopNum1_SpecProudctDetails WHERE SpecValueId=t.id and ProductGuid=" +
                        strPid + ")tm FROM shopnum1_specvalue t WHERE SpecID='" + strSid + "' ORDER BY OrderId ASC");
            }
            catch
            {
                return
                    DatabaseExcetue.ReturnDataTable(
                        "SELECT Id,Name,ImagePath,''tc,''tv,''tm FROM dbo.ShopNum1_SpecValue t WHERE SpecID='" + strSid +
                        "' ORDER BY OrderId ASC");
            }
        }
    }
}