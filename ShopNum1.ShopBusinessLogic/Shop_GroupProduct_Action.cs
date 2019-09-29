using System;
using System.Data;
using ShopNum1.DataAccess;
using ShopNum1MultiEntity;

namespace ShopNum1.ShopBusinessLogic
{
    public class Shop_GroupProduct_Action
    {
        public int AddGroupProduct(ShopNum1_Group_Product Shop_GroupProduct)
        {
            string str =
                "INSERT INTO ShopNum1_Group_Product(Aid,Aname,Name,ProductGuId,GroupPrice,GroupImg,GroupSmallImg,GroupStock,VirtualNum,LimitNum,Introduce,ShopName,MemLoginId,CreateTime";
            if (Shop_GroupProduct.State.HasValue)
            {
                str = str + ",state";
            }
            object obj2 = str;
            obj2 =
                string.Concat(new[]
                {
                    obj2, ")VALUES('", Shop_GroupProduct.Aid, "','", Shop_GroupProduct.Aname, "','",
                    Shop_GroupProduct.Name, "','", Shop_GroupProduct.ProductGuId, "',"
                });
            obj2 =
                string.Concat(new[]
                {
                    obj2, "'", Shop_GroupProduct.GroupPrice, "','", Shop_GroupProduct.GroupImg, "','",
                    Shop_GroupProduct.GroupSmallImg, "',"
                });
            string str2 =
                string.Concat(new[]
                {
                    obj2, "'", Shop_GroupProduct.GroupStock, "','", Shop_GroupProduct.VirtualNum, "','",
                    Shop_GroupProduct.LimitNum, "',"
                });
            str = str2 + "'" + Shop_GroupProduct.Introduce + "','" + Shop_GroupProduct.ShopName + "','" +
                  Shop_GroupProduct.MemLoginId + "','" + DateTime.Now + "'";
            if (Shop_GroupProduct.State.HasValue)
            {
                obj2 = str;
                str = string.Concat(new[] {obj2, ",'", Shop_GroupProduct.State, "'"});
            }
            return DatabaseExcetue.RunNonQuery(str + ");");
        }

        public int DeleteGroupProduct(string strId, string strMemloginId)
        {
            string strSql = "DELETE FROM ShopNum1_Group_Product WHERE Id='" + strId + "' ";
            if (strMemloginId != "")
            {
                strSql = strSql + " and memloginId='" + strMemloginId + "'";
            }
            return DatabaseExcetue.RunNonQuery(strSql);
        }

        public DataTable GetGroupProductById(string strId, string strMemloginId)
        {
            return
                DatabaseExcetue.ReturnDataTable(
                    "SELECT *,(select repertorycount from shopnum1_shop_product where guid=t.productguid)repc FROM ShopNum1_Group_Product as t WHERE ID='" +
                    strId + "' AND MemLoginId='" + strMemloginId + "'");
        }

        public DataTable GetGroupProductDetial(string strId)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@Id";
            paraValue[0] = strId;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GroupDetail", paraName, paraValue);
        }

        public DataTable GetProduct(int topnumber, string ProductSeriesCode, string Name, string MemLoginID)
        {
            string str = string.Empty;
            str = "   SELECT  top  " + topnumber + "    Guid ,Name  from    ShopNum1_Shop_Product      where  1=1   ";
            if (ProductSeriesCode != "0")
            {
                str = str + "    and   ProductSeriesCode like  '%" + ProductSeriesCode + "%'   ";
            }
            if (Name != "")
            {
                str = str + " and Name like '%" + Name + "%'";
            }
            return
                DatabaseExcetue.ReturnDataTable((str +
                                                 " and isdeleted=0 and issell=1 and isaudit=1 and issaled=1 AND productstate=0 and memloginID='" +
                                                 MemLoginID +
                                                 "' and repertorycount>0 and guid not in (select productguid from ShopNum1_Limt_Product where state=1)") +
                                                "   order  by   modifytime  desc     ");
        }

        public DataTable GetProductById(string GuId, string MemLoginID)
        {
            string str2 = "   SELECT  shopprice,repertorycount,name from   ShopNum1_Shop_Product  where  1=1   ";
            return
                DatabaseExcetue.ReturnDataTable((str2 + "  and memloginID='" + MemLoginID + "' and guid='" + GuId +
                                                 "'  ") +
                                                "  and isdeleted=0 and issell=1 and isaudit=1  order  by   modifytime  desc     ");
        }

        public DataTable SelectActivity(string pagesize, string currentpage, string condition, string resultnum)
        {
            var paraName = new string[8];
            var paraValue = new string[8];
            paraName[0] = "@pagesize";
            paraValue[0] = pagesize;
            paraName[1] = "@currentpage";
            paraValue[1] = currentpage;
            paraName[2] = "@columns";
            paraValue[2] = "id,Name,GroupSmallImg,GroupCount,State,Aname,MemloginId,ProductGuId";
            paraName[3] = "@tablename";
            paraValue[3] = "ShopNum1_Group_Product";
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

        public DataTable SelectGroupProduct(string pagesize, string currentpage, string condition, string resultnum,
            string sortvalue, string ordercolumn)
        {
            string str =
                "select v.id,v.Name,GroupSmallImg,GroupImg,GroupCount,createtime,visitcount,v.shopname,v.MemLoginId,\r\nv.State,Aname,(select p.shopprice from shopnum1_shop_product left join ShopNum1_Shop_ProductPrice as p on p.productId =shopnum1_shop_product.id where guid=v.productguid)shopprice,groupprice,Aid from ShopNum1_Group_Product as v inner join ShopNum1_Product_Activity B on B.id=v.Aid   ";
            var paraName = new string[8];
            var paraValue = new string[8];
            paraName[0] = "@pagesize";
            paraValue[0] = pagesize;
            paraName[1] = "@currentpage";
            paraValue[1] = currentpage;
            paraName[2] = "@columns";
            paraValue[2] = "*";
            paraName[3] = "@tablename";
            paraValue[3] = str;
            paraName[4] = "@condition";
            paraValue[4] = condition;
            paraName[5] = "@ordercolumn";
            paraValue[5] = ordercolumn;
            paraName[6] = "@sortvalue";
            paraValue[6] = sortvalue;
            paraName[7] = "@resultnum";
            paraValue[7] = resultnum;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_CommonPager", paraName, paraValue);
        }

        public int UpdateGroupProduct(ShopNum1_Group_Product Shop_GroupProduct)
        {
            string str =
                string.Concat(new object[]
                {
                    "UPDATE ShopNum1_Group_Product set Aid='", Shop_GroupProduct.Aid, "',Aname='",
                    Shop_GroupProduct.Aname, "',ProductGuId='", Shop_GroupProduct.ProductGuId, "',Name='",
                    Shop_GroupProduct.Name, "',GroupPrice='", Shop_GroupProduct.GroupPrice, "',"
                });
            if (Shop_GroupProduct.GroupImg != null)
            {
                str = str + "GroupImg='" + Shop_GroupProduct.GroupImg + "',";
            }
            if (Shop_GroupProduct.GroupSmallImg != null)
            {
                str = str + "GroupSmallImg='" + Shop_GroupProduct.GroupSmallImg + "',";
            }
            object obj2 = str;
            return
                DatabaseExcetue.RunNonQuery(
                    string.Concat(new[]
                    {
                        obj2, "State='", Shop_GroupProduct.State, "',GroupStock='", Shop_GroupProduct.GroupStock,
                        "',VirtualNum='", Shop_GroupProduct.VirtualNum, "',LimitNum='", Shop_GroupProduct.LimitNum,
                        "',Introduce='", Shop_GroupProduct.Introduce, "' where id='", Shop_GroupProduct.Id, "'"
                    }));
        }
    }
}