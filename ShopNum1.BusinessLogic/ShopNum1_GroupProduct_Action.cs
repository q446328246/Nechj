using System.Data;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using System.Data.Common;

namespace ShopNum1.BusinessLogic
{
    public class ShopNum1_GroupProduct_Action : IShopNum1_GroupProduct_Action
    {
        public int DeleteButch(string strId)
        {
            return DatabaseExcetue.RunNonQuery("DELETE FROM ShopNum1_Group_Product WHERE Id in(" + strId + ")");
        }

        public DataTable GetGroupProductData(int start, int int_0)
        {
            object obj2 = string.Empty +
                          "   SELECT * FROM (select A.Name,A.GroupPrice,A.GroupImg,A.CreateTime,A.Id,A.MemLoginId,A.ShopName,B.Audit,B.issell,B.issaled ROW_NUMBER()     " +
                          "   over(order by A.CreateTime  DESC) as rows from ShopNum1_Group_Product A Inner Join shopnum1_shop_product B on b.guid=A.ProductGuId  WHERE State=1 And B.Audit=1 And B.issell=1 And B.Issaled=1     ";
            return
                DatabaseExcetue.ReturnDataTable(
                    string.Concat(new[] {obj2, "   ) AS B WHERE  B.rows>=", start, " AND B.rows<=", int_0, "    "}));
        }

        public DataTable SelectGroupByAId(string pagesize, string currentpage, string condition, string resultnum)
        {
            var paraName = new string[8];
            var paraValue = new string[8];
            paraName[0] = "@pagesize";
            paraValue[0] = pagesize;
            paraName[1] = "@currentpage";
            paraValue[1] = currentpage;
            paraName[2] = "@columns";
            paraValue[2] = "*";
            paraName[3] = "@tablename";
            paraValue[3] =
                "select A.id,A.name,A.aid,a.productguid,a.groupcount,a.groupstock,a.groupprice,a.createtime,a.state,a.shopname,a.memloginid,a.groupimg,a.groupsmallimg,(select name from shopnum1_shop_product where guid=a.productguid)pname,(select shopid from shopnum1_shopinfo where memloginid=a.memloginid)shopid,b.name as aname,b.starttime,b.endtime from ShopNum1_Group_Product A \r\ninner join ShopNum1_Product_Activity B on A.aid=b.id";
            paraName[4] = "@condition";
            paraValue[4] = condition;
            paraName[5] = "@ordercolumn";
            paraValue[5] = "id";
            paraName[6] = "@sortvalue";
            paraValue[6] = "desc";
            paraName[7] = "@resultnum";
            paraValue[7] = resultnum;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_CommonPager_two", paraName, paraValue);
        }

        public DataTable SelectGroupList(string pagesize, string currentpage, string condition, string resultnum,
            string strordercolumn, string strsortvalue)
        {
            var paraName = new string[8];
            var paraValue = new string[8];
            paraName[0] = "@pagesize";
            paraValue[0] = pagesize;
            paraName[1] = "@currentpage";
            paraValue[1] = currentpage;
            paraName[2] = "@columns";
            paraValue[2] = "*";
            paraName[3] = "@tablename";
            paraValue[3] =
                "select top 500 A.id,A.aname,A.groupimg,a.groupprice,a.groupcount,a.groupstock,a.createtime,a.state,a.shopname,c.name,a.groupsmallimg,p.shopprice,c.productcategorycode,b.starttime,b.endtime,(select shopid from shopnum1_shopinfo where memloginid=a.memloginid)shopid,c.guid,(case when b.endtime<getdate() then '1' else '0' end) as tgstate from ShopNum1_Group_Product A inner join ShopNum1_Product_Activity B on B.id=A.Aid inner join \r\nShopNum1_Shop_Product C on C.Guid=A.productguid left join ShopNum1_Shop_ProductPrice as p on p.productId=c.id order by " +
                strordercolumn + " " + strsortvalue;
            paraName[4] = "@condition";
            paraValue[4] = condition;
            paraName[5] = "@ordercolumn";
            paraValue[5] = strordercolumn;
            paraName[6] = "@sortvalue";
            paraValue[6] = strsortvalue;
            paraName[7] = "@resultnum";
            paraValue[7] = resultnum;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_CommonPager", paraName, paraValue);
        }

        public int UpdateGroupAState(string strId, string strState)

        {
                DbParameter[] parms = DatabaseExcetue.CreateParameter(2);
            parms[0].ParameterName = "@strId";
            parms[0].Value = strId;
            parms[1].ParameterName = "@strState";
            parms[1].Value = strState;
            return
                DatabaseExcetue.RunNonQuery("UPDATE ShopNum1_Group_Product SET State=@strState WHERE AId=@strId",parms);
        }

        public int UpdateGroupState(string strId, string strState)
        {
                DbParameter[] parms = DatabaseExcetue.CreateParameter(2);
            parms[0].ParameterName = "@strId";
            parms[0].Value = strId;
            parms[1].ParameterName = "@strState";
            parms[1].Value = strState;
            return
                DatabaseExcetue.RunNonQuery("UPDATE ShopNum1_Group_Product SET State=@strState WHERE Id=@strId",parms);
        }
    }
}