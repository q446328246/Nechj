using System;
using System.Collections.Generic;
using System.Data;
using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1MultiEntity;
using System.Data.Common;

namespace ShopNum1.BusinessLogic
{
    public class ShopNum1_Brand_Action : IShopNum1_Brand_Action
    {



        public DataTable SearchWenZhang()
        {
            string str = string.Empty;
            str = "select  *  from Nec_WenZhang where 1=1 ";
          
            return DatabaseExcetue.ReturnDataTable(str);
        }




        public int AddWenZhang(string title,string image,string adress)
        {
            return DatabaseExcetue.RunNonQuery(string.Concat(new object[]
            {
                "INSERT INTO Nec_WenZhang( Title, Image, HtmlAddress) VALUES (  '"
                , title, "',  '", image, "',  '",
                adress, "' )"
            }));
        }

        public DataTable GetWenZhangEditInfo(string id)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@id";
            parms[0].Value = id;
            string strSql = string.Empty;
            strSql =
                "SELECT  * FROM Nec_WenZhang WHERE ID=@id";
            
            return DatabaseExcetue.ReturnDataTable(strSql, parms);
        }

        public int UpdateWenZhang(string id, string Title,string images,string adress)
        {
            return DatabaseExcetue.RunNonQuery(string.Concat(new object[]
            {
                "UPDATE  Nec_WenZhang SET  Title='", Title, "', Image='",
                images, "', HtmlAddress='", adress,
                "' WHERE Guid=", id
            }));
        }










        public string TableName { get; set; }








        public int Add(ShopNum1_Brand brand)
        {
            return DatabaseExcetue.RunNonQuery(string.Concat(new object[]
            {
                "INSERT INTO ShopNum1_Brand( Guid, Name, CategoryName,Logo, WebSite, OrderID, Keywords, IsShow, Remark, Description, CreateUser, CreateTime, ModifyUser, ModifyTime, IsCommend,  IsDeleted  ) VALUES (  '"
                , brand.Guid, "',  '", Operator.FilterString(brand.Name), "',  '",
                Operator.FilterString(brand.CategoryName), "',  '", Operator.FilterString(brand.Logo), "',  '",
                brand.WebSite, "',  ", brand.OrderID, ",  '", Operator.FilterString(brand.Keywords), "',  ",
                brand.IsShow,
                ",  '", Operator.FilterString(brand.Remark), "',  '", Operator.FilterString(brand.Description),
                "',  '", brand.CreateUser, "', '", brand.CreateTime, "',  '", brand.ModifyUser, "' , '",
                brand.ModifyTime, "',  '", brand.IsCommend, "',  ", brand.IsDeleted,
                " )"
            }));
        }

        public DataTable CheckBrand(string strBrand)
        {
                DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@strBrand";
            parms[0].Value = strBrand;
            return
                DatabaseExcetue.ReturnDataTable("Select guid from ShopNum1_Brand where Name=@strBrand  and IsDeleted=0 AND IsShow =1 ",parms);
        }

        public int Delete(string guids)
        {
            string item = string.Empty;
            var sqlList = new List<string>();
            item = "delete from ShopNum1_Brand  WHERE Guid IN (" + guids + ") ";
            sqlList.Add(item);
            item = "delete from ShopNum1_ProductCategoryAndProductBranDrelation  WHERE BrandGuid IN (" + guids + ")";
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


        public int AddBTCRecommend(string guid, string CreateTimeBTC, int IsSalesBTC, int IsNewBTC, int IsTercelBTC)
        {


            return DatabaseExcetue.RunNonQuery("  insert into ShopNum1_BTC_Recommend(ProductGuidBTC,CreateTimeBTC,IsSalesBTC,IsNewBTC,IsTercelBTC) values('" + guid.Replace("'", "") + "','" + CreateTimeBTC + "'," + IsSalesBTC + "," + IsNewBTC + "," + IsTercelBTC + ") ");
              
        }

        public int DeleteBTCRecommend(string guid)
        {


            return DatabaseExcetue.RunNonQuery("update  ShopNum1_BTC_Recommend set IsDeleteBTC=1 where ProductGuidBTC='" + guid.Replace("'", "") + "'  and IsDeleteBTC=0");

        }

        public int UpdateBTCRecommendIsSalesBTC(string guid)
        {


            return DatabaseExcetue.RunNonQuery("update  ShopNum1_BTC_Recommend set IsSalesBTC=1 where ProductGuidBTC='" + guid.Replace("'", "") + "'  and IsDeleteBTC=0");

        }

        public int UpdateBTCRecommendIsNewBTC(string guid)
        {


            return DatabaseExcetue.RunNonQuery("update  ShopNum1_BTC_Recommend set IsNewBTC=1 where ProductGuidBTC='" + guid.Replace("'", "") + "'  and IsDeleteBTC=0");

        }

        public int UpdateBTCRecommendIsTercelBTC(string guid)
        {


            return DatabaseExcetue.RunNonQuery("update  ShopNum1_BTC_Recommend set IsTercelBTC=1 where ProductGuidBTC='" + guid.Replace("'", "") + "'  and IsDeleteBTC=0");

        }

        public DataTable GetBrandCategory(string showCount)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@showCount";
            paraValue[0] = showCount;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_GetBrandCategory", paraName, paraValue);
        }

        public DataTable GetBrandImgByCode(string showCount, string code)
        {
            var paraName = new string[2];
            var paraValue = new string[2];
            paraName[0] = "@showCount";
            paraValue[0] = showCount;
            paraName[1] = "@code";
            paraValue[1] = code;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_GetBrandImgByCode", paraName, paraValue);
        }


        public DataTable SelectBTCRecommend(string guid)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@guid";
            parms[0].Value = guid.Replace("'", "");
            string strSql = string.Empty;


            strSql = "SELECT * from  ShopNum1_BTC_Recommend where ProductGuidBTC= @guid";
            return DatabaseExcetue.ReturnDataTable(strSql, parms);
        }

        public DataTable GetBrandMeto(string guid)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@guid";
            parms[0].Value = guid.Replace("'","");
            string strSql = string.Empty;
            strSql = "SELECT  Name,Keywords,Description FROM ShopNum1_Brand where 0=0";
            guid = guid.Replace("'", "");
            if (Operator.FormatToEmpty(guid) != "-1")
            {
                strSql = strSql + "  and IsDeleted=0 AND IsShow =1  AND  Guid=@guid";
            }
            return DatabaseExcetue.ReturnDataTable(strSql,parms);
        }

        public DataTable GetEditInfo(string guid)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@guid";
            parms[0].Value = guid.Replace("'","");
            string strSql = string.Empty;
            strSql =
                "SELECT  Name,CategoryName,IsCommend, Logo,WebSite,OrderID,Keywords,IsShow,Remark,Description, CreateUser,CreateTime,ModifyUser,ModifyTime,IsDeleted FROM ShopNum1_Brand WHERE 0=0";
            guid = guid.Replace("'", "");
            if (Operator.FormatToEmpty(guid) != "-1")
            {
                strSql = strSql + " AND  Guid=@guid  and IsDeleted=0 ";
            }
            return DatabaseExcetue.ReturnDataTable(strSql,parms);
        }

        public DataTable GetProductBrand(string code)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@code";
            paraValue[0] = code;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_GetProductBrand", paraName, paraValue);
        }

        public DataTable GetProductBrandBycount(string code, string ShowCountTwo)
        {
            string str = (string.Empty + "select distinct Top " + ShowCountTwo +
                          " * from (SELECT  Guid,A.Name,Logo,WebSite,A.orderid from ShopNum1_Brand A INNER JOIN") +
                         " ShopNum1_TypeBrand B ON B.BRANDGUID=a.GUID INNER JOIN" +
                         " shopnum1_productcategory C on c.categorytype=b.typeid";
            if (code != "-1")
            {
                str = str + "  AND  Code  LIKE '" + code + "%'";
            }
            return
                DatabaseExcetue.ReturnDataTable(str + " AND A.IsDeleted=0 AND A.IsShow =1 ) as tab order by orderid asc");
        }

        public DataTable GetProductCategoryCode(string fatherID)
        {
                DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@fatherID";
            parms[0].Value = fatherID;
            return
                DatabaseExcetue.ReturnDataTable(("select ID,Name,Code from " + TableName) + " WHERE FatherID=@fatherID" ,parms);
        }

        public DataTable Search(int isDeleted)
        {
                DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@isDeleted";
            parms[0].Value = isDeleted;
            string str = string.Empty;
            str = "SELECT Guid, Name,OrderID ,IsDeleted FROM ShopNum1_Brand where 0=0 ";
            if ((isDeleted == 0) || (isDeleted == 1))
            {
                str =
                    string.Concat(new object[] { str, " AND IsDeleted=@isDeleted  and IsDeleted=0 AND IsShow =1  " });
            }
            return DatabaseExcetue.ReturnDataTable(str + " ORDER BY OrderID DESC ",parms);
        }

        public DataTable SearchBrand(string pagesize)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@pagesize";
            paraValue[0] = pagesize;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_SearchBrand", paraName, paraValue);
        }

        public DataTable SearchProductByBrandGuid(string brandGuid, string field, string order)
        {
                DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@brandGuid";
            parms[0].Value = brandGuid;
           
            string str = string.Empty;
            str =
                "SELECT \tA.Guid\t, \tA.Name\t, \tA.IsPanicBuy\t, \tA.IsSpellBuy\t, \tB.ShopID\t, \tA.OriginalImage\t, \tA.ThumbImage\t, \tA.SmallImage\t, \tA.MarketPrice\t, \tA.ShopPrice\t, \tA.BrandName\t, \tA.CreateTime\t, \tA.MemLoginID\t  FROM ShopNum1_Shop_Product AS A,ShopNum1_ShopInfo AS B  WHERE A.MemLoginID=B.MemLoginID AND A.IsDeleted=0 AND IsSell=1 AND IsSaled=1 ";
            if (brandGuid != "-1")
            {
                str = str + " AND BrandGuid=@brandGuid";
            }
            return DatabaseExcetue.ReturnDataTable(str + " ORDER BY " + field + " " + order,parms);
        }

        public DataTable Select_Brand_Import(string strTypeId)
        {
                DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@strTypeId";
            parms[0].Value = strTypeId;
            string strSql =
                "SELECT GUID as code,NAME FROM  shopnum1_brand WHERE GUID IN(select BRANDGUID from shopnum1_typebrand where typeid=@strTypeId ) and IsDeleted=0 AND IsShow =1 ";
            if (strTypeId == "")
            {
                strSql = "SELECT GUID as code,NAME FROM  shopnum1_brand where  IsDeleted=0 AND IsShow =1 ";
            }
            return DatabaseExcetue.ReturnDataTable(strSql,parms);
        }

        public DataTable SelectBrandFlagStore(string pagesize, string code)
        {
            string str = "select top " + pagesize +
                         " A.Guid,A.name,A.logo,A.orderid from shopnum1_brand A Where GuId in(select brandguid from ShopNum1_TypeBrand where typeid in(select categorytype from  ShopNum1_productcategory  where Code like '" +
                         code + "%')) AND A.isshow=1 And A.Isdeleted=0  And  logo!='' order by A.orderid desc";
            var paraName = new string[8];
            var paraValue = new string[8];
            paraName[0] = "@pagesize";
            paraValue[0] = pagesize;
            paraName[1] = "@currentpage";
            paraValue[1] = "1";
            paraName[2] = "@columns";
            paraValue[2] = " Guid,name,logo,orderid ";
            paraName[3] = "@tablename";
            paraValue[3] = str;
            paraName[4] = "@condition";
            paraValue[4] = "";
            paraName[5] = "@ordercolumn";
            paraValue[5] = "orderid";
            paraName[6] = "@sortvalue";
            paraValue[6] = "desc";
            paraName[7] = "@resultnum";
            paraValue[7] = "2";
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_CommonPager_two", paraName, paraValue);
        }

        public int Update(string guid, ShopNum1_Brand brand)
        {
            return DatabaseExcetue.RunNonQuery(string.Concat(new object[]
            {
                "UPDATE  ShopNum1_Brand SET  Name='", Operator.FilterString(brand.Name), "', CategoryName='",
                Operator.FilterString(brand.CategoryName), "', Logo='", Operator.FilterString(brand.Logo),
                "', WebSite='", brand.WebSite, "', OrderID=", brand.OrderID, ", IsCommend=", brand.IsCommend,
                ", Keywords='", Operator.FilterString(brand.Keywords), "', IsShow=", brand.IsShow,
                ", Remark='", Operator.FilterString(brand.Remark), "', Description='",
                Operator.FilterString(brand.Description), "', ModifyUser='", brand.ModifyUser, "', ModifyTime='",
                brand.ModifyTime, "' WHERE Guid=", guid
            }));
        }

        public int Add_TypeBrand(List<ShopNum1_TypeBrand> listShopNum1_TypeBrand)
        {
            string item = null;
            var sqlList = new List<string>();
            if ((listShopNum1_TypeBrand != null) && (listShopNum1_TypeBrand.Count > 0))
            {
                sqlList.Add("delete from ShopNum1_TypeBrand where typeid='" + listShopNum1_TypeBrand[0].TypeID + "'");
                for (int i = 0; i < listShopNum1_TypeBrand.Count; i++)
                {
                    item =
                        string.Concat(new object[]
                        {
                            "insert into ShopNum1_TypeBrand(typeid,brandguid)values('",
                            listShopNum1_TypeBrand[i].TypeID, "','", listShopNum1_TypeBrand[i].BrandGuid, "')"
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

        public DataTable BindProductBrand(string Code)
        {
            string strSql = string.Empty;
            if (Code != "0")
            {
                return
                    DatabaseExcetue.ReturnDataTable(
                        "SELECT Guid,Name,Logo From ShopNum1_Brand Where guid in(select brandguid from ShopNum1_TypeBrand where typeid in(select categorytype from shopnum1_productcategory where code like '" +
                        Code + "%'))and IsShow=1");
            }
            strSql = "SELECT Guid,Name,Logo From ShopNum1_Brand Where IsShow=1 And IsCommend=1 ";
            return DatabaseExcetue.ReturnDataTable(strSql);
        }

        public int Delete_TypeBrand(string strId)
        {
                DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@strId";
            parms[0].Value = strId;
            return DatabaseExcetue.RunNonQuery("delete from ShopNum1_TypeBrand where id=@strId",parms);
        }

        public DataTable dt_Select_BrandByCid(string strCid)
        {
                DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@strCid";
            parms[0].Value = strCid;
            string str = "SELECT name,Guid FROM dbo.ShopNum1_Brand X WHERE Guid IN ";
            return
                DatabaseExcetue.ReturnDataTable((str + "(SELECT BrandGuid FROM dbo.ShopNum1_TypeBrand b ") +
                                                "INNER JOIN ShopNum1_CategoryType c ON c.id=b.TypeID WHERE c.id=@strCid) and IsDeleted=0 AND IsShow =1 ",parms);
        }

        public DataTable Search_Type_Brand(string strId)
        {
                DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@strId";
            parms[0].Value = strId;
            return
                DatabaseExcetue.ReturnDataTable(
                    "select guid,name,(select top 1 id from shopnum1_typebrand where brandguid=t.guid and typeid=@strId as ischeck from shopnum1_brand as t where IsDeleted=0 AND IsShow =1 order by orderid asc ",parms);
        }

        public DataTable SearchF(string name, int isDeleted, string productCategorycode)
        {
            string str = string.Empty;
            str =
                "select  Guid,Name,Logo,WebSite,OrderID,Keywords,IsShow,Remark,ProductCategoryCode,Description,CreateUser,CreateTime,ModifyUser,ModifyTime,IsDeleted,IsCommend";
            str = (str + "  from ShopNum1_Brand ") + "  where Guid  in  (" +
                  "  select  BrandGuid  from ShopNum1_ProductCategoryAndProductBranDrelation  where";
            if (productCategorycode != "-1")
            {
                str = str + " ProductCategoryCode  like  '" + productCategorycode + "%')  ";
            }
            else
            {
                str = str + " 1=1 )  ";
            }
            if (Operator.FormatToEmpty(name) != string.Empty)
            {
                str = str + " AND Name LIKE '%" + Operator.FilterString(name) + "%'";
            }
            if ((isDeleted == 0) || (isDeleted == 1))
            {
                str = string.Concat(new object[] {str, " AND  IsDeleted=", isDeleted, " "});
            }
            return DatabaseExcetue.ReturnDataTable(str + "  and IsDeleted=0 AND IsShow =1  Order By OrderID Desc");
        }

        public DataTable SearchF0(string name, string link, int isDeleted, string IsShow, string IsRecommond,
            string CategoryName)
        {
            string str = string.Empty;
            str =
                "select  Guid,Name,Logo,WebSite,OrderID,Keywords,IsShow,Remark,CategoryName,Description,CreateUser,CreateTime,ModifyUser,ModifyTime,IsDeleted,IsCommend";
            str = str + "  from ShopNum1_Brand where 1=1 ";
            if (Operator.FormatToEmpty(link) != string.Empty)
            {
                str = str + " and website like '%" + link + "%'";
            }
            if ((IsShow == "0") || (IsShow == "1"))
            {
                str = str + " AND IsShow='" + IsShow + "' ";
            }
            if ((IsRecommond == "0") || (IsRecommond == "1"))
            {
                str = str + " AND iscommend='" + IsRecommond + "' ";
            }
            if (Operator.FormatToEmpty(CategoryName) != string.Empty)
            {
                str = str + " AND CategoryName LIKE '%" + Operator.FilterString(CategoryName) + "%'";
            }
            if (Operator.FormatToEmpty(name) != string.Empty)
            {
                str = str + " AND Name LIKE '%" + Operator.FilterString(name) + "%'";
            }
            if ((isDeleted == 0) || (isDeleted == 1))
            {
                str = string.Concat(new object[] {str, " AND  IsDeleted=", isDeleted, " "});
            }
            return DatabaseExcetue.ReturnDataTable(str + " Order By OrderID asc");
        }

        public DataTable SelectBTCRecommend(string name, string DateStart, string DateOver,  string RecommendType, string Sort)
        {
            DateTime PaytimeStart = DateTime.Parse("1900-01-01 0:00:00");
                DateTime PaytimeOver =DateTime.Parse("2100-12-31 0:00:00") ;

                if (DateStart != string.Empty && DateStart != null)
            {
                PaytimeStart = Convert.ToDateTime(DateStart);
            }
                if (DateOver != string.Empty && DateOver !=null)
            {
                PaytimeOver =Convert.ToDateTime(DateOver);
            }
                var paraName = new string[5];
                var paraValue = new string[5];
                paraName[0] = "@name";
                paraValue[0] = name;
                paraName[1] = "@DateStart";
                paraValue[1] = PaytimeStart.ToString();
                paraName[2] = "@DateOver";
                paraValue[2] = PaytimeOver.ToString();
                paraName[3] = "@RecommendType";
                paraValue[3] = RecommendType;
                paraName[4] = "@Sort";
                paraValue[4] = Sort;
                return DatabaseExcetue.RunProcedureReturnDataTable("Pro_BTC_Recommend", paraName, paraValue);
        }
    }
}