using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1MultiEntity;
using System.Data.Common;
using System.Data.SqlClient;

namespace ShopNum1.BusinessLogic
{
    public class ShopNum1_MobileService_Action : IShopNum1_MobileService_Action
    {
        //获取热门搜索表
        public DataTable SelectHot(string category_ID)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@category_ID";
            parms[0].Value = category_ID;
            string strSql = string.Empty;
            strSql =
                " select * from [ShopNum1].[dbo].[MobileService_ReMenSouSuo] WHERE Shop_Category_ID=@category_ID order by Id ";

            return DatabaseExcetue.ReturnDataTable(strSql, parms);
        }

        //关联搜索
        public DataTable RelationSelect(string category_ID,string words)
        {


            
            string strSql = string.Empty;
            strSql =
                "select top 10 Name as ProductName,(select top 1 ShopName from ShopNum1_ShopInfo where ShopName like '%" + words + "%') as ShopName from [Shopnum1].[dbo].[ShopNum1_Shop_Product] as a left join ShopNum1_Shop_ProductPrice as b on a.Id=b.productId   where Name like '%" + words + "%' and b.shop_category_id='" + category_ID + "'";

            return DatabaseExcetue.ReturnDataTable(strSql);
        }
          //关联搜索店铺列表
        public DataTable RelationSelectShopInfo( string words,int satar,int end)
        {
           
            string strSql = string.Empty;
            strSql =
                "select * from ( select ShopName,Phone,AddressValue,Address,Banner,MemLoginID,MainGoods, ROW_NUMBER() OVER(Order by ShopName DESC) as RowNumber from ShopNum1_ShopInfo where MemLoginID!='C0000001' and IsDeleted=0 and ShopName like '%" + words + "%' ) AS RowNumber  where RowNumber BETWEEN " + satar + " and " + end + "";

            return DatabaseExcetue.ReturnDataTable(strSql);
        }
        //查询用户各个状态订单数量
        public DataTable SelectOrderStatusNumber(string member)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@member";
            parms[0].Value = member;

            string strSql = string.Empty;
            strSql ="select (select Count(*) from ShopNum1_OrderInfo where MemLoginID=@member and OderStatus=0) as a,(select Count(*) from ShopNum1_OrderInfo where MemLoginID=@member and OderStatus=1) as b,(select Count(*) from ShopNum1_OrderInfo where MemLoginID=@member and OderStatus=2) as c";

            return DatabaseExcetue.ReturnDataTable(strSql,parms);
        }
        //批量删除购物车
        public int DeleteShopCar(string guids)
        {
            List<DbParameter> parms = new List<DbParameter>();

            string andSql = string.Format(" in ({0})", DatabaseExcetue.GetGuidsSql(guids, parms));


            return DatabaseExcetue.RunNonQuery("DELETE FROM ShopNum1_Shop_Cart  WHERE  Guid " + andSql, parms.ToArray());
        }

          

        public string SelectProdctDetailByGuid(string guid)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@guid";
            parms[0].Value = guid;
            string strSql = string.Empty;
            strSql = "select Detail from ShopNum1_Shop_Product where Guid=@guid";
            return DatabaseExcetue.ReturnDataTable(strSql, parms).Rows[0]["Detail"].ToString();
        }

        public string SelectShopInfoByGuid(string guid)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@guid";
            parms[0].Value = guid;
            string strSql = string.Empty;
            strSql = " select ShopUrl from ShopNum1_Shop_Product as a left join ShopNum1_ShopInfo as b on a.MemLoginID=b.MemLoginID  where a.Guid=@guid";
            return DatabaseExcetue.ReturnDataTable(strSql, parms).Rows[0]["ShopUrl"].ToString();
        }
    }
}
