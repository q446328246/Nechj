using System;
using System.Collections.Generic;
using System.Data;
using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1MultiEntity;
using System.Data.Common;
using System.Data.SqlClient;

namespace ShopNum1.BusinessLogic
{
    public class ShopNum1_Cart_Action : IShopNum1_Cart_Action
    {
        public DataTable SearchShopByMemLoginID_Price(string memLoginID, string guids, string productGuid, int category_id, string size, string color)
        {
            List<DbParameter> parms = new List<DbParameter>();

            string andSql = string.Format(" in ({0})", DatabaseExcetue.GetGuidsSql(guids, parms));

            DbParameter parm = new SqlParameter();
            parm.ParameterName = "@memLoginID";
            parm.Value = memLoginID;
            parms.Add(parm);

            parm = new SqlParameter();
            parm.ParameterName = "@category_id";
            parm.Value = category_id;
            parms.Add(parm);

            parm = new SqlParameter();
            parm.ParameterName = "@productGuid";
            parm.Value = productGuid.Replace("'", "");
            parms.Add(parm);
            parm = new SqlParameter();
            parm.ParameterName = "@size";
            parm.Value = size;
            parms.Add(parm);
            parm = new SqlParameter();
            parm.ParameterName = "@color";
            parm.Value = color;
            parms.Add(parm);
            string strSql = string.Empty;
            strSql =
                "SELECT a.AgentId,a.Score_pv_cv, a.size,a.color, A.ShopID,A.Score_dv,spp.Score_pv_a,spp.Score_pv_b ,spp.Score_hv,spp.Score_max_hv,dd.category_name,B.ShopRank,B.ShopName as SellName,B.Tel,a.shop_category_id,A.BuyNumber,spp.ShopPrice FROM ShopNum1_Shop_Product as sp left join  ShopNum1_Shop_Cart AS A on a.ProductGuId=sp.[Guid]  LEFT JOIN ShopNum1_ShopInfo AS B ON A.ShopID=B.MemLoginID left join ShopNum1_Shop_CustomerCategory as dd on dd.id=a.shop_category_id left join ShopNum1_Shop_ProductPrice as spp on sp.Id=spp.productId  WHERE 0 =0 AND A.MemLoginID=@memLoginID and spp.shop_category_id=a.shop_category_id and sellName!=''";
            if (guids != string.Empty)
            {
                strSql = strSql + " AND A.guid" + andSql;
                strSql = strSql + " and a.ProductGuId=@productGuid";
                strSql = strSql + " and a.size=@size";
                strSql = strSql + " and a.color=@color";
                strSql = strSql + " and a.shop_category_id=@category_id";
            }
            return DatabaseExcetue.ReturnDataTable(strSql, parms.ToArray());
        }

        public DataTable SearchShopByMemLoginID_Price(string memLoginID, string guids, string productGuid, int category_id)
        {
            List<DbParameter> parms = new List<DbParameter>();

            string andSql = string.Format(" in ({0})", DatabaseExcetue.GetGuidsSql(guids, parms));

            DbParameter parm = new SqlParameter();
            parm.ParameterName = "@memLoginID";
            parm.Value = memLoginID;
            parms.Add(parm);

            parm = new SqlParameter();
            parm.ParameterName = "@category_id";
            parm.Value = category_id;
            parms.Add(parm);

            parm = new SqlParameter();
            parm.ParameterName = "@productGuid";
            parm.Value = productGuid.Replace("'", "");
            parms.Add(parm);

            string strSql = string.Empty;
            strSql =
                "SELECT a.Score_pv_cv, a.size,a.color, A.ShopID,A.Score_dv,spp.Score_pv_a,spp.Score_pv_b ,spp.Score_hv,spp.Score_max_hv,dd.category_name,B.ShopRank,B.ShopName as SellName,B.Tel,a.shop_category_id,A.BuyNumber,spp.ShopPrice FROM ShopNum1_Shop_Product as sp left join  ShopNum1_Shop_Cart AS A on a.ProductGuId=sp.[Guid]  LEFT JOIN ShopNum1_ShopInfo AS B ON A.ShopID=B.MemLoginID left join ShopNum1_Shop_CustomerCategory as dd on dd.id=a.shop_category_id left join ShopNum1_Shop_ProductPrice as spp on sp.Id=spp.productId  WHERE 0 =0 AND A.MemLoginID=@memLoginID and spp.shop_category_id=a.shop_category_id and sellName!=''";
            if (guids != string.Empty)
            {
                strSql = strSql + " AND A.guid" + andSql;
                strSql = strSql + " and a.ProductGuId=@productGuid";
                strSql = strSql + " and a.shop_category_id=@category_id";
            }
            return DatabaseExcetue.ReturnDataTable(strSql, parms.ToArray());
        }
        public DataTable GetProductInfoByMemLoginID(string MemloginID)
        {
            List<DbParameter> parms = new List<DbParameter>();



            DbParameter parm = new SqlParameter();
            parm.ParameterName = "@MemloginID";
            parm.Value = MemloginID;
            parms.Add(parm);


            return
                DatabaseExcetue.ReturnDataTable(
                    string.Format(
                        "select Guid,ProductGuId from ShopNum1_Shop_Cart where MemLoginID=@MemloginID"), parms.ToArray());
        }
        public int Add(ShopNum1_Shop_Cart cart)
        {
            string strSql = string.Empty;
            DataTable table = CheckCartProduct(cart.MemLoginID, cart.ProductGuid.ToString(), cart.Attributes, 0,
                cart.SpecificationValue);
            if (table.Rows.Count > 0)
            {
                int num2 = Convert.ToInt32(table.Rows[0]["BuyNumber"]) + cart.BuyNumber;
                strSql =
                    string.Concat(new object[]
                    {
                        "UPDATE  ShopNum1_Shop_Cart SET  BuyNumber=", num2, ", BuyPrice=", cart.BuyPrice,
                        " WHERE MemLoginID='", cart.MemLoginID, "' AND ProductGuid='", cart.ProductGuid, "'"
                    });
            }
            else
            {
                strSql = string.Concat(new object[]
                {
                    "INSERT INTO ShopNum1_Shop_Cart( Guid,MemLoginID,ProductGuid,Name,RepertoryNumber,BuyNumber,MarketPrice,ShopPrice,BuyPrice,Attributes,SpecificationName,SpecificationValue,IsShipment,IsReal,ExtensionAttriutes,ParentGuid,IsJoinActivity,CartType,IsPresent,CreateTime,DetailedSpecifications ) VALUES (  '"
                    , cart.Guid, "',  '", cart.MemLoginID, "',  '", cart.ProductGuid, "',  '", cart.Name, "',  '",
                    cart.RepertoryNumber, "',  ", cart.BuyNumber, ",  ", cart.MarketPrice, ",  ", cart.ShopPrice,
                    ",  ", cart.BuyPrice, ",  '", cart.Attributes, "',  '",
                    Operator.FormatToEmpty(cart.SpecificationName), "',  '",
                    Operator.FormatToEmpty(cart.SpecificationValue), "',  ", cart.IsShipment, ",  ", cart.IsReal,
                    ",  '", cart.ExtensionAttriutes, "',  '", cart.ParentGuid,
                    "',  ", cart.IsJoinActivity, ",  ", cart.CartType, ",  ", cart.IsPresent, ",  '",
                    cart.CreateTime, "', '", cart.DetailedSpecifications, "')"
                });
            }
            return DatabaseExcetue.RunNonQuery(strSql);
        }

        public int AddCart(ShopNum1_Shop_Cart shopcart)
        {
            DataTable table;
            string strSql = string.Empty;
            int num = 0;
            if (shopcart.IsPresent == 0)
            {
                table = CheckCartProduct_two(shopcart.MemLoginID, shopcart.ProductGuid.ToString(), shopcart.Attributes, 0,
                    shopcart.SpecificationValue, shopcart.Color, shopcart.Size);
                num = 0;
            }
            else
            {
                table = CheckCartProduct_two(shopcart.MemLoginID, shopcart.ProductGuid.ToString(), shopcart.Attributes, 1,
                    shopcart.SpecificationValue, shopcart.Color, shopcart.Size);
                num = 1;
            }
            int num123;
            string guid;
            if (table.Rows.Count>0)
            {
                 num123= Convert.ToInt32(table.Rows[0]["shop_category_id"]);
                 guid = table.Rows[0]["guid"].ToString();
            }
            else
            {
                num123 = 11111111;
                guid = "";
            }
            
            int num222= shopcart.shop_category_id;
            if (table.Rows.Count > 0 && num123 == num222 && shopcart.ProductGuid.ToString() == table.Rows[0]["ProductGuId"].ToString())
            {
                int num3 = Convert.ToInt32(table.Rows[0]["BuyNumber"]) + shopcart.BuyNumber;
                strSql =
                    string.Concat(new object[]
                    {
                        "UPDATE  ShopNum1_Shop_Cart SET  BuyNumber=", num3, ", BuyPrice=", shopcart.BuyPrice,
                        " WHERE MemLoginID='", shopcart.MemLoginID, "' AND ProductGuid='", shopcart.ProductGuid,
                        "' AND IsPresent=", num, "   AND SpecificationValue='", shopcart.SpecificationValue, "' and guid='",guid,"'  and shop_category_id=",num123," "
                    });
            }
            else
            {
                strSql = string.Concat(new object[]
                {
                    "INSERT INTO ShopNum1_Shop_Cart( Guid,MemLoginID,ProductGuid,OriginalImge,Name,RepertoryNumber,BuyNumber,MarketPrice,ShopPrice,BuyPrice,Attributes,SpecificationName,SpecificationValue,IsShipment,IsReal,ExtensionAttriutes,shopcart.DetailedSpecifications ,IsJoinActivity,CartType,IsPresent,CreateTime,ShopID,SellName,FeeType,Post_fee,Express_fee,Ems_fee,shop_category_id,Score_pv_a,Score_hv,Color,Size,Score_dv,Score_pv_cv,Score_pv_b,GoodsWeight) VALUES (  '"
                    , shopcart.Guid, "',  '", shopcart.MemLoginID, "',  '", shopcart.ProductGuid, "',  '",
                    shopcart.OriginalImge, "',  '", Operator.FormatToEmpty(shopcart.Name), "',  '",
                    shopcart.RepertoryNumber, "',  ", shopcart.BuyNumber, ",  ", shopcart.MarketPrice,
                    ",  ", shopcart.ShopPrice, ",  ", shopcart.BuyPrice, ",  '",
                    Operator.FormatToEmpty(shopcart.Attributes), "',  '",
                    Operator.FormatToEmpty(shopcart.SpecificationName), "',  '",
                    Operator.FormatToEmpty(shopcart.SpecificationValue), "',  ", shopcart.IsShipment, ",  ",
                    shopcart.IsReal, ",  '", Operator.FormatToEmpty(shopcart.ExtensionAttriutes),
                    "',  '", Operator.FormatToEmpty(shopcart.DetailedSpecifications), "',  ",
                    shopcart.IsJoinActivity, ",  ", shopcart.CartType, ",  ", shopcart.IsPresent, ",  '",
                    shopcart.CreateTime, "', '", shopcart.ShopID, "', '", shopcart.SellName, "', ", shopcart.FeeType
                    ,
                    ",  ", shopcart.Post_fee, ",  ", shopcart.Express_fee, ",  ", shopcart.Ems_fee, ",  ", shopcart.shop_category_id, ",  ", shopcart.Score_pv_a, ",  ", shopcart.Score_hv, ",  '", shopcart.Color, "',  '", shopcart.Size, "',",shopcart.Score_dv,",",shopcart.Score_pv_cv,",",shopcart.Score_pv_b,",",shopcart.GoodsWeight," )"
                });
            }
            return DatabaseExcetue.RunNonQuery(strSql);
        }

        public int AddOrder(List<ShopNum1_Shop_Cart> cart)
        {
            var sqlList = new List<string>();
            foreach (ShopNum1_Shop_Cart cart2 in cart)
            {
                string item = string.Empty;
                DataTable table = CheckCartProduct(cart2.MemLoginID, cart2.ProductGuid.ToString(), cart2.Attributes, 0,
                    cart2.SpecificationValue);
                if (table.Rows.Count > 0)
                {
                    int num3 = Convert.ToInt32(table.Rows[0]["BuyNumber"]) + cart2.BuyNumber;
                    item =
                        string.Concat(new object[]
                        {
                            "UPDATE  ShopNum1_Shop_Cart SET  BuyNumber=", num3, ", BuyPrice=", cart2.BuyPrice,
                            " WHERE MemLoginID='", cart2.MemLoginID, "' AND ProductGuid='", cart2.ProductGuid, "'"
                        });
                }
                else
                {
                    item = string.Concat(new object[]
                    {
                        "INSERT INTO ShopNum1_Shop_Cart( Guid,MemLoginID,ProductGuid,Name,RepertoryNumber,BuyNumber,MarketPrice,ShopPrice,BuyPrice,IsShipment,IsReal,ExtensionAttriutes,ParentGuid,IsJoinActivity,CartType,IsPresent,CreateTime,DetailedSpecifications ,ShopID,SellName,FeeType,Post_fee,Express_fee,Ems_fee   ) VALUES (  '"
                        , cart2.Guid, "',  '", cart2.MemLoginID, "',  '", cart2.ProductGuid, "',  '", cart2.Name,
                        "',  '", cart2.RepertoryNumber, "',  ", cart2.BuyNumber, ",  ", cart2.MarketPrice, ",  ",
                        cart2.ShopPrice,
                        ",  ", cart2.BuyPrice, ",  ", cart2.IsShipment, ",  ", cart2.IsReal, ",  '",
                        cart2.ExtensionAttriutes, "',  '", cart2.ParentGuid, "',  ", cart2.IsJoinActivity, ",  ",
                        cart2.CartType, ",  ", cart2.IsPresent,
                        ",  '", cart2.CreateTime, "', '", cart2.DetailedSpecifications, "', '", cart2.ShopID, "', '"
                        , cart2.SellName, "', ", cart2.FeeType, ",  ", cart2.Post_fee, ",  ", cart2.Express_fee,
                        ",  ", cart2.Ems_fee,
                        " )"
                    });
                }
                sqlList.Add(item);
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

        public DataTable CheckCartProduct(string memLoginID, string productGuid, string attributes, int isPresent,
            string guige)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(5);

            parms[0].ParameterName = "@memLoginID";
            parms[0].Value = memLoginID;
            parms[1].ParameterName = "@productGuid";
            parms[1].Value = productGuid;
            parms[2].ParameterName = "@attributes";
            parms[2].Value = attributes;
            parms[3].ParameterName = "@isPresent";
            parms[3].Value = isPresent;
            parms[4].ParameterName = "@guige";
            if (guige==null)
            {
                guige = "";
            }
            
            parms[4].Value = guige;
            return
                DatabaseExcetue.ReturnDataTable(
                    string.Concat(new object[]
                    {
                        "SELECT BuyPrice,BuyNumber,ProductGuId,IsPresent,shop_category_id,guid FROM ShopNum1_Shop_Cart  WHERE MemLoginID=@memLoginID AND ProductGuid =@productGuid AND  IsPresent=@isPresent  and  SpecificationValue=@guige  "
                    }),parms);
        }

        public DataTable CheckCartProduct_two(string memLoginID, string productGuid, string attributes, int isPresent,
         string guige, string Color, string Size)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(7);

            parms[0].ParameterName = "@memLoginID";
            parms[0].Value = memLoginID;
            parms[1].ParameterName = "@productGuid";
            parms[1].Value = productGuid;
            parms[2].ParameterName = "@attributes";
            parms[2].Value = attributes;
            parms[3].ParameterName = "@isPresent";
            parms[3].Value = isPresent;
            parms[4].ParameterName = "@guige";
            parms[5].ParameterName = "@Color";
            parms[5].Value = Color;
            parms[6].ParameterName = "@Size";
            parms[6].Value = Size;
            if (guige == null)
            {
                guige = "";
            }

            parms[4].Value = guige;
            return
                DatabaseExcetue.ReturnDataTable(
                    string.Concat(new object[]
                    {
                        "SELECT BuyPrice,BuyNumber,ProductGuId,IsPresent,shop_category_id,guid FROM ShopNum1_Shop_Cart  WHERE MemLoginID=@memLoginID AND ProductGuid =@productGuid AND  IsPresent=@isPresent  and  SpecificationValue=@guige and Size=@Size and Color=@Color "
                    }), parms);
        }

        public DataTable SelectShopCar(string memLoginID)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@memLoginID";
            parms[0].Value = memLoginID;

            return
                DatabaseExcetue.ReturnDataTable(" SELECT top 1 shop_category_id,A.ShopID FROM ShopNum1_Shop_Cart A LEFT JOIN ShopNum1_ShopInfo AS B ON A.ShopID=B.MemLoginID left join ShopNum1_Shop_CustomerCategory as dd on dd.id=a.shop_category_id WHERE 0 =0 AND A.MemLoginID =@memLoginID and sellname!='' and productguid in(select guid from shopnum1_shop_product where isAudit=1 and isSell=1 and IsSaled=1 and isdeleted=0) ", parms);
            
        }


        public DataTable CheckMemberLoginID(string memLoginID)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@memLoginID";
            parms[0].Value = memLoginID;
            return
                DatabaseExcetue.ReturnDataTable("select MemLoginID from ShopNum1_Member where MemLoginID=@memLoginID And IsDeleted =0",parms);
        }


        public DataTable CheckRepertoryCount(string guid)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@guid";
            parms[0].Value = guid.Replace("'","");
            return
                DatabaseExcetue.ReturnDataTable(
                    "select A.BuyNumber, B.RepertoryCount from ShopNum1_Shop_Cart AS A left join ShopNum1_Shop_Product AS B on A.ProductGuid=B.guid Where A.guid=@guid",parms);
        }

        public int Delete(string guids)
        {
            List<DbParameter> parms = new List<DbParameter>();

            string andSql = string.Format(" in ({0})", DatabaseExcetue.GetGuidsSql(guids, parms));

           
            return DatabaseExcetue.RunNonQuery("DELETE FROM ShopNum1_Shop_Cart  WHERE  Guid "+andSql,parms.ToArray());
        }

        public int DeleteByMemLoginID(string memLoginID)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@memLoginID";
            parms[0].Value = memLoginID;
            return DatabaseExcetue.RunNonQuery("DELETE FROM ShopNum1_Shop_Cart  WHERE  MemLoginID =@memLoginID",parms);
        }

        public int DeleteByMemLoginID(string memLoginID, string guids)
        {
            List<DbParameter> parms = new List<DbParameter>();

            string andSql = string.Format(" in ({0})", DatabaseExcetue.GetGuidsSql(guids, parms));

            DbParameter parm = new SqlParameter();
            parm.ParameterName = "@memLoginID";
            parm.Value = memLoginID;
            parms.Add(parm);
            string strSql = string.Empty;
            strSql = "DELETE FROM ShopNum1_Shop_Cart  WHERE  MemLoginID =@memLoginID";
            if (guids != string.Empty)
            {
                strSql = strSql + " AND Guid"+andSql;
            }
            return DatabaseExcetue.RunNonQuery(strSql,parms.ToArray());
        }

        public DataTable GetGroupPriceByProductGuid(string productguid)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@productguid";
            paraValue[0] = productguid;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_GetGroupPriceByProductGuid", paraName,
                paraValue);
        }

        public DataTable GetInfoByGuid(string guid)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@guid";
            parms[0].Value = guid.Replace("'","");
            string strSql = string.Empty;
            strSql = "select *   FROM ShopNum1_Shop_Cart  WHERE  1 =1 ";
            if (!string.IsNullOrEmpty(guid))
            {
                strSql = strSql + " AND Guid =@guid";
            }
            return DatabaseExcetue.ReturnDataTable(strSql,parms);
        }

        public int GetMemCartCount(string memLoginID)
        {
            string strSql =
                "SELECT count(BuyNumber) AS AllCount FROM  ShopNum1_Shop_Cart WHERE  MemLoginID=@MemLoginID and productguid in(select guid from shopnum1_shop_product where issaled=1 and issell=1 and isaudit=1)";
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@MemLoginID";
            paraValue[0] = memLoginID;
            object objA = DatabaseExcetue.ReturnObject(strSql, paraName, paraValue);
            if (Equals(objA, null) || Equals(objA, DBNull.Value))
            {
                return 0;
            }
            return int.Parse(objA.ToString());
        }

        public int GetProductCount(string memLoginID, string productGuid)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(2);

            parms[0].ParameterName = "@memLoginID";
            parms[0].Value = memLoginID;
            parms[1].ParameterName = "@productGuid";
            parms[1].Value = productGuid;
            return
                Convert.ToInt32(
                    DatabaseExcetue.ReturnDataTable("SELECT BuyNumber FROM ShopNum1_Shop_Cart  WHERE MemLoginID=@memLoginID AND ProductGuid =@productGuid",parms).Rows[0][
                                                        "BuyNumber"].ToString());
        }

        public DataTable GetProductInfoByCartProductGuid(string MemloginID, string ShopID, string CartGuID)
        {
            List<DbParameter> parms = new List<DbParameter>();

            string andSql = string.Format(" in ({0})", DatabaseExcetue.GetGuidsSql(CartGuID,parms));

            DbParameter parm = new SqlParameter();
            parm.ParameterName = "@MemloginID";
            parm.Value = MemloginID;
            parms.Add(parm);
            
            parm = new SqlParameter();
            parm.ParameterName = "@ShopID";
            parm.Value = ShopID;
            parms.Add(parm);

            string str = string.Empty;
            str =
                "SELECT A.FeeType,A.FeeTemplateID,A.Post_fee,A.Express_fee,A.Ems_fee,B.BuyNumber,A.MemLoginID,A.GoodsWeight,B.shop_category_id,B.ShopPrice FROM ShopNum1_Shop_Cart AS B ";
            return
                DatabaseExcetue.ReturnDataTable(
                    string.Format(
                        str +
                        " Inner JOIN ShopNum1_Shop_Product AS A ON A.Guid=B.ProductGuid WHERE A.isAudit=1 and A.isSell=1 and A.IsSaled=1 and A.isdeleted=0 " +
                        "And B.MemLoginID=@MemloginID AND B.ShopID=@ShopID AND b.guid" + andSql), parms.ToArray());
        }

        public DataTable GetProductInfoByProductGuids(string MemloginID, string ShopID, string CartGuID)
        {
            List<DbParameter> parms = new List<DbParameter>();

            string andSql = string.Format(" in ({0})", DatabaseExcetue.GetGuidsSql(CartGuID, parms));

            DbParameter parm = new SqlParameter();
            parm.ParameterName = "@MemloginID";
            parm.Value = MemloginID;
            parms.Add(parm);

            parm = new SqlParameter();
            parm.ParameterName = "@ShopID";
            parm.Value = ShopID;
            parms.Add(parm);

            string str = string.Empty;
            str =
                "SELECT A.FeeType,A.FeeTemplateID,A.Post_fee,A.Express_fee,A.Ems_fee,B.BuyNumber,A.MemLoginID,A.GoodsWeight,B.shop_category_id,B.ShopPrice FROM ShopNum1_Shop_Cart AS B ";
            return
                DatabaseExcetue.ReturnDataTable(
                    string.Format(
                        str +
                        " Inner JOIN ShopNum1_Shop_Product AS A ON A.Guid=B.ProductGuid WHERE A.isAudit=1 and A.isSell=1 and A.IsSaled=1 and A.isdeleted=0 " +
                        "And B.MemLoginID=@MemloginID AND B.ShopID=@ShopID AND b.ProductGuid" + andSql), parms.ToArray());
        }



        public DataTable SearchBuyPriceByMemLoginID(string memLoginID)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@memLoginID";
            parms[0].Value = memLoginID;
            
            string strSql = string.Empty;
            strSql = "SELECT BuyNumber,BuyPrice   FROM ShopNum1_Shop_Cart  WHERE 0 =0 ";
            if (Operator.FormatToEmpty(memLoginID) != string.Empty)
            {
                strSql = strSql + " AND MemLoginID=@memLoginID";
            }
            return DatabaseExcetue.ReturnDataTable(strSql,parms);
        }

        public DataTable SearchByMemLoginID(string memLoginID)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@memLoginID";
            parms[0].Value = memLoginID;
            string strSql = string.Empty;
            strSql =
                "SELECT Guid,MemLoginID,ProductGuid,OriginalImge,Name,RepertoryNumber,BuyNumber,MarketPrice,ShopPrice,BuyPrice,Attributes,IsShipment,IsReal,ShopID,SellName,ExtensionAttriutes,ParentGuid,IsJoinActivity,CartType,IsPresent,FeeType,Post_fee,Express_fee,Ems_fee,DetailedSpecifications, CreateTime FROM ShopNum1_Shop_Cart  WHERE 0 =0 ";
            if (Operator.FormatToEmpty(memLoginID) != string.Empty)
            {
                strSql = strSql + " AND MemLoginID=@memLoginID";
            }
            return DatabaseExcetue.ReturnDataTable(strSql,parms);
        }

        public DataTable SearchByMemLoginID(string memLoginID, int cartType)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(2);

            parms[0].ParameterName = "@memLoginID";
            parms[0].Value = memLoginID;
            parms[1].ParameterName = "@cartType";
            parms[1].Value = cartType;
            string str = string.Empty;
            str =
                "SELECT Guid,MemLoginID,ShopID,ProductGuid,OriginalImge,Name,RepertoryNumber,BuyNumber,MarketPrice,ShopPrice,BuyPrice,Attributes,IsShipment,IsReal,ExtensionAttriutes,ParentGuid,IsJoinActivity,CartType,IsPresent,DetailedSpecifications, CreateTime FROM ShopNum1_Shop_Cart  WHERE 0 =0 ";
            if (Operator.FormatToEmpty(memLoginID) != string.Empty)
            {
                str = str + " AND MemLoginID=@memLoginID";
            }
            return DatabaseExcetue.ReturnDataTable(str + " AND CartType=@cartType",parms);
        }

        public DataTable SearchByMemLoginID(string memLoginID, string SellName)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(2);

            parms[0].ParameterName = "@memLoginID";
            parms[0].Value = memLoginID;
            parms[1].ParameterName = "@SellName";
            parms[1].Value = SellName;
            string strSql = string.Empty;
            strSql =
                "SELECT Guid,MemLoginID,ProductGuid,OriginalImge,Name,RepertoryNumber,BuyNumber,MarketPrice,ShopPrice,BuyPrice,Attributes,IsShipment,IsReal,ShopID,SellName,ExtensionAttriutes,ParentGuid,IsJoinActivity,CartType,IsPresent,FeeType,Post_fee,Express_fee,Ems_fee,DetailedSpecifications, CreateTime FROM ShopNum1_Shop_Cart  WHERE 0 =0 ";
            if (Operator.FormatToEmpty(memLoginID) != string.Empty)
            {
                strSql = strSql + " AND MemLoginID=@memLoginID";
            }
            if (Operator.FormatToEmpty(SellName) != string.Empty)
            {
                strSql = strSql + " AND SellName=@SellName";
            }
            return DatabaseExcetue.ReturnDataTable(strSql,parms);
        }

        public DataTable SearchByMemLoginIDAndShopID(string memLoginID, string ShopID)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(2);

            parms[0].ParameterName = "@memLoginID";
            parms[0].Value = memLoginID;
            parms[1].ParameterName = "@ShopID";
            parms[1].Value = ShopID;
            string strSql = string.Empty;
            strSql =
                "SELECT a.Size,a.Color,a.Guid,a.MemLoginID,ProductGuid,a.shop_category_id,OriginalImge,a.Name,RepertoryNumber,BuyNumber,a.MarketPrice,a.ShopPrice,BuyPrice,Attributes,SpecificationName,SpecificationValue,IsShipment,a.IsReal,ShopID,SellName,ExtensionAttriutes,ParentGuid,IsJoinActivity,CartType,IsPresent,a.FeeType,a.Post_fee,a.Express_fee,a.Ems_fee,DetailedSpecifications, a.CreateTime,c.MyPrice FROM ShopNum1_Shop_Cart as a left join ShopNum1_Shop_Product as b on a.ProductGuId=b.Guid left join ShopNum1_Shop_ProductPrice as c on c.productId=b.Id WHERE 0 =0 and c.shop_category_id=a.shop_category_id ";
            if (Operator.FormatToEmpty(memLoginID) != string.Empty)
            {
                strSql = strSql + " AND a.MemLoginID=@memLoginID";
            }
            if (Operator.FormatToEmpty(ShopID) != string.Empty)
            {
                strSql = strSql + " AND a.ShopID=@ShopID";
            }
            return DatabaseExcetue.ReturnDataTable(strSql,parms);
        }

        public DataTable SearchByMemLoginIDAndShopID(string memLoginID, string ShopID, string guids)
        {
            

            List<DbParameter> parms = new List<DbParameter>();

            string andSql = string.Format(" in ({0})", DatabaseExcetue.GetGuidsSql(guids, parms));

            DbParameter parm = new SqlParameter();
            parm.ParameterName = "@memLoginID";
            parm.Value = memLoginID;
            parms.Add(parm);
            parm = new SqlParameter();
            parm.ParameterName = "@ShopID";
            parm.Value = ShopID;
            parms.Add(parm);
            string strSql = string.Empty;
            strSql =
                "SELECT a.Size,a.Color,a.Guid,a.MemLoginID,ProductGuid,a.shop_category_id,OriginalImge,a.Name,RepertoryNumber,BuyNumber,a.MarketPrice,a.ShopPrice,BuyPrice,Attributes,SpecificationName,SpecificationValue,IsShipment,a.IsReal,ShopID,SellName,ExtensionAttriutes,ParentGuid,IsJoinActivity,CartType,IsPresent,a.FeeType,a.Post_fee,a.Express_fee,a.Ems_fee,DetailedSpecifications, a.CreateTime,c.MyPrice FROM ShopNum1_Shop_Cart as a left join ShopNum1_Shop_Product as b on a.ProductGuId=b.Guid left join ShopNum1_Shop_ProductPrice as c on c.productId=b.Id WHERE 0 =0 and c.shop_category_id=a.shop_category_id ";
            if (Operator.FormatToEmpty(memLoginID) != string.Empty)
            {
                strSql = strSql + " AND a.MemLoginID=@memLoginID";
            }
            if (Operator.FormatToEmpty(ShopID) != string.Empty)
            {
                strSql = strSql + " AND a.ShopID=@ShopID";
            }
            if (Operator.FormatToEmpty(guids) != string.Empty)
            {
                strSql = strSql + " AND a.Guid"+andSql;
            }

            return DatabaseExcetue.ReturnDataTable(strSql, parms.ToArray());
        }

        public DataTable SearchByMemLoginIDShopID(string memLoginID, string Shopid)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(2);

            parms[0].ParameterName = "@memLoginID";
            parms[0].Value = memLoginID;
            parms[1].ParameterName = "@Shopid";
            parms[1].Value = Shopid;
            string strSql = string.Empty;
            strSql =
                "SELECT Guid,MemLoginID,ProductGuid,OriginalImge,Name,RepertoryNumber,BuyNumber,MarketPrice,ShopPrice,BuyPrice,Attributes,IsShipment,IsReal,ShopID,SellName,ExtensionAttriutes,ParentGuid,IsJoinActivity,CartType,IsPresent,FeeType,Post_fee,Express_fee,Ems_fee,DetailedSpecifications, CreateTime FROM ShopNum1_Shop_Cart  WHERE 0 =0 ";
            if (Operator.FormatToEmpty(memLoginID) != string.Empty)
            {
                strSql = strSql + " AND MemLoginID=@memLoginID";
            }
            if (Operator.FormatToEmpty(Shopid) != string.Empty)
            {
                strSql = strSql + " AND ShopID=@Shopid";
            }
            return DatabaseExcetue.ReturnDataTable(strSql,parms);
        }

        public DataTable SearchByPostPrice(string memLoginID, string shopName)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(2);

            parms[0].ParameterName = "@memLoginID";
            parms[0].Value = memLoginID;
            parms[1].ParameterName = "@shopName";
            parms[1].Value = shopName;
            string strSql = string.Empty;
            strSql =
                "SELECT sum(Post_fee) Post_fee,sum(Express_fee) Express_fee,sum(Ems_fee) Ems_fee FROM ShopNum1_Shop_Cart  WHERE 0 =0 ";
            if (Operator.FormatToEmpty(memLoginID) != string.Empty)
            {
                strSql = strSql + " AND MemLoginID=@memLoginID";
            }
            if (Operator.FormatToEmpty(shopName) != string.Empty)
            {
                strSql = strSql + " AND ShopID=@shopName";
            }
            return DatabaseExcetue.ReturnDataTable(strSql,parms);
        }

        public DataTable SearchByShopMemID(string memLoginID, string shopName)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(2);

            parms[0].ParameterName = "@memLoginID";
            parms[0].Value = memLoginID;
            parms[1].ParameterName = "@shopName";
            parms[1].Value = shopName;
            string strSql = string.Empty;
            strSql =
                "SELECT A.Guid,A.MemLoginID,A.ProductGuid,A.OriginalImge,A.Name,A.RepertoryNumber,A.BuyNumber,A.MarketPrice,A.ShopPrice,A.BuyPrice,A.Attributes,A.SpecificationName,A.SpecificationValue,A.IsShipment,A.IsReal,A.ShopID,A.SellName,A.ExtensionAttriutes,A.ParentGuid,A.IsJoinActivity,A.CartType,A.IsPresent,A.FeeType,B.MinusFee,B.repertorycount,A.Post_fee,A.Express_fee,A.Ems_fee,A.DetailedSpecifications, (select  goodsstock from ShopNum1_SpecProudct where specdetail=A.specificationValue and productguid=A.productguid)specCount,A.CreateTime FROM ShopNum1_Shop_Cart AS A LEFT JOIN ShopNum1_Shop_Product AS B ON A.ProductGuid=B.Guid  WHERE B.isAudit=1 and b.isSell=1 and b.IsSaled=1 and b.isdeleted=0 ";
            if (Operator.FormatToEmpty(memLoginID) != string.Empty)
            {
                strSql = strSql + " AND A.MemLoginID=@memLoginID";
            }
            if (Operator.FormatToEmpty(shopName) != string.Empty)
            {
                strSql = strSql + " AND A.ShopID=@shopName";
            }
            return DatabaseExcetue.ReturnDataTable(strSql,parms);
        }


        public DataTable SearchByShopMemID_two(string memLoginID, string shopName, int shop_category_id)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(3);

            parms[0].ParameterName = "@memLoginID";
            parms[0].Value = memLoginID;
            parms[1].ParameterName = "@shopName";
            parms[1].Value = shopName;
            parms[2].ParameterName = "@shop_category_id";
            parms[2].Value = shop_category_id;
            string strSql = string.Empty;
            strSql =
                "SELECT a.Score_pv_a,a.Score_pv_b,A.Guid,a.shop_category_id,a.Color,a.Size,A.MemLoginID,A.ProductGuid,A.OriginalImge,A.Name,A.RepertoryNumber,A.BuyNumber,A.MarketPrice,A.ShopPrice,A.BuyPrice,A.Attributes,A.SpecificationName,A.SpecificationValue,A.IsShipment,A.IsReal,A.ShopID,A.SellName,A.ExtensionAttriutes,A.ParentGuid,A.IsJoinActivity,A.CartType,A.IsPresent,A.FeeType,B.MinusFee,B.repertorycount,A.Post_fee,A.Express_fee,A.Ems_fee,A.DetailedSpecifications, (select  goodsstock from ShopNum1_SpecProudct where specdetail=A.specificationValue and productguid=A.productguid)specCount,A.CreateTime,A.Score_dv*-1 as Score_dv FROM ShopNum1_Shop_Cart AS A LEFT JOIN ShopNum1_Shop_Product AS B ON A.ProductGuid=B.Guid  WHERE B.isAudit=1 and b.isSell=1 and b.IsSaled=1 and b.isdeleted=0 ";
            if (Operator.FormatToEmpty(memLoginID) != string.Empty)
            {
                strSql = strSql + " AND A.MemLoginID=@memLoginID";
            }
            if (Operator.FormatToEmpty(shopName) != string.Empty)
            {
                strSql = strSql + " AND A.ShopID=@shopName";
            }
            if (Operator.FormatToEmpty(shop_category_id.ToString()) != string.Empty)
            {
                strSql = strSql + " and a.shop_category_id=@shop_category_id";
            }
            return DatabaseExcetue.ReturnDataTable(strSql,parms);
        }




        public DataTable SearchByShopMemID(string memLoginID, string shopName, string guids)
        {
            List<DbParameter> parms = new List<DbParameter>();

            string andSql = string.Format(" in ({0})", DatabaseExcetue.GetGuidsSql(guids, parms));

            DbParameter parm = new SqlParameter();
            parm.ParameterName = "@memLoginID";
            parm.Value = memLoginID;
            parms.Add(parm);
            parm = new SqlParameter();
            parm.ParameterName = "@shopName";
            parm.Value = shopName;
            parms.Add(parm);
            string strSql = string.Empty;
            strSql =
                "SELECT A.Guid,A.MemLoginID,A.ProductGuid,A.OriginalImge,A.Name,A.RepertoryNumber,A.BuyNumber,A.MarketPrice,A.ShopPrice,A.BuyPrice,A.Attributes,A.SpecificationName,A.SpecificationValue,A.IsShipment,A.IsReal,A.ShopID,A.SellName,A.ExtensionAttriutes,A.ParentGuid,A.IsJoinActivity,A.CartType,A.IsPresent,A.FeeType,B.MinusFee,A.Post_fee,A.Express_fee,A.Ems_fee,A.DetailedSpecifications, A.CreateTime FROM ShopNum1_Shop_Cart AS A Inner JOIN ShopNum1_Shop_Product AS B ON A.ProductGuid=B.Guid WHERE  B.isAudit=1 and B.isSell=1 and B.IsSaled=1 and B.isdeleted=0";
            if (Operator.FormatToEmpty(memLoginID) != string.Empty)
            {
                strSql = strSql + " AND A.MemLoginID=@memLoginID";
            }
            if (Operator.FormatToEmpty(shopName) != string.Empty)
            {
                strSql = strSql + " AND A.ShopID=@shopName";
            }
            if (Operator.FormatToEmpty(guids) != string.Empty)
            {
                strSql = strSql + " AND A.Guid"+andSql;
            }
            return DatabaseExcetue.ReturnDataTable(strSql,parms.ToArray());
        }
        public DataTable SearchByShopMemID_freefive(string memLoginID, string guids, int shop_category_id,string strShop)
        {
            List<DbParameter> parms = new List<DbParameter>();

            string andSql = string.Format(" in ({0})", DatabaseExcetue.GetGuidsSql(guids, parms));

            DbParameter parm = new SqlParameter();
            parm.ParameterName = "@memLoginID";
            parm.Value = memLoginID;
            parms.Add(parm);

            parm = new SqlParameter();
            parm.ParameterName = "@shop_category_id";
            parm.Value = shop_category_id;
            parms.Add(parm);

            parm = new SqlParameter();
            parm.ParameterName = "@strShop";
            parm.Value = strShop;
            parms.Add(parm);

            string strSql = string.Empty;
            strSql =
                "SELECT  A.Guid,a.Score_pv_a,a.Score_pv_b,a.Size,a.Color,A.MemLoginID,A.ProductGuid,A.OriginalImge,A.Name,A.RepertoryNumber,A.BuyNumber,A.MarketPrice,A.ShopPrice,A.BuyPrice,A.Attributes,A.SpecificationName,A.SpecificationValue,A.IsShipment,A.IsReal,A.ShopID,A.SellName,A.ExtensionAttriutes,A.ParentGuid,A.shop_category_id,A.IsJoinActivity,A.CartType,A.IsPresent,A.FeeType,B.MinusFee,A.Post_fee,A.Express_fee,A.Ems_fee,A.DetailedSpecifications, A.CreateTime FROM ShopNum1_Shop_Cart AS A Inner JOIN ShopNum1_Shop_Product AS B ON A.ProductGuid=B.Guid WHERE  B.isAudit=1 and B.isSell=1 and B.IsSaled=1 and B.isdeleted=0";
            if (Operator.FormatToEmpty(memLoginID) != string.Empty)
            {
                strSql = strSql + " AND A.MemLoginID=@memLoginID";
            }

            if (Operator.FormatToEmpty(guids) != string.Empty)
            {
                strSql = strSql + " AND A.Guid"+andSql;
            }
            if (Operator.FormatToEmpty(shop_category_id.ToString()) != string.Empty)
            {
                strSql = strSql + " and a.shop_category_id=@shop_category_id";
            }
            if (Operator.FormatToEmpty(strShop.ToString()) != string.Empty)
            {
                strSql = strSql + " and a.ShopID=@strShop";
            }
            return DatabaseExcetue.ReturnDataTable(strSql, parms.ToArray());
        }
        public DataTable SearchByShopMemID_free(string memLoginID, string guids, int shop_category_id)
        {
            List<DbParameter> parms = new List<DbParameter>();

            string andSql = string.Format(" in ({0})", DatabaseExcetue.GetGuidsSql(guids, parms));

            DbParameter parm = new SqlParameter();
            parm.ParameterName = "@memLoginID";
            parm.Value = memLoginID;
            parms.Add(parm);
            parm = new SqlParameter();
            parm.ParameterName = "@shop_category_id";
            parm.Value = shop_category_id;
            parms.Add(parm);
            
            string strSql = string.Empty;
            strSql =
                "SELECT A.Guid,a.Size,a.Color,A.MemLoginID,A.ProductGuid,A.Score_dv,A.Score_pv_a,a.Score_pv_b,A.OriginalImge,A.Name,A.RepertoryNumber,A.BuyNumber,A.MarketPrice,A.ShopPrice,A.BuyPrice,A.Attributes,A.SpecificationName,A.SpecificationValue,A.IsShipment,A.IsReal,A.ShopID,A.SellName,A.ExtensionAttriutes,A.ParentGuid,A.shop_category_id,A.IsJoinActivity,A.CartType,A.IsPresent,A.FeeType,B.MinusFee,A.Post_fee,A.Express_fee,A.Ems_fee,A.DetailedSpecifications, A.CreateTime FROM ShopNum1_Shop_Cart AS A Inner JOIN ShopNum1_Shop_Product AS B ON A.ProductGuid=B.Guid WHERE  B.isAudit=1 and B.isSell=1 and B.IsSaled=1 and B.isdeleted=0";
            if (Operator.FormatToEmpty(memLoginID) != string.Empty)
            {
                strSql = strSql + " AND A.MemLoginID=@memLoginID";
            }
            
            if (Operator.FormatToEmpty(guids) != string.Empty)
            {
                strSql = strSql + " AND A.Guid"+andSql;
            }
            if (Operator.FormatToEmpty(shop_category_id.ToString()) != string.Empty)
            {
                strSql = strSql + " and a.shop_category_id=@shop_category_id";
            }
            return DatabaseExcetue.ReturnDataTable(strSql,parms.ToArray());
        }
        public DataTable SearchByShopMemID_freetwo(string memLoginID, string guids, int shop_category_id,string shopcarguid)
        {
            List<DbParameter> parms = new List<DbParameter>();

            string andSql = string.Format(" in ({0})", DatabaseExcetue.GetGuidsSql(guids, parms));

            DbParameter parm = new SqlParameter();
            parm.ParameterName = "@memLoginID";
            parm.Value = memLoginID;
            parms.Add(parm);
            parm = new SqlParameter();
            parm.ParameterName = "@shop_category_id";
            parm.Value = shop_category_id;
            parms.Add(parm);
            parm = new SqlParameter();
            parm.ParameterName = "@shopcarguid";
            parm.Value = shopcarguid.Replace("'","");
            parms.Add(parm);
            string strSql = string.Empty;
            strSql =
                "SELECT A.Guid,a.Size,a.Color,A.MemLoginID,A.ProductGuid,A.OriginalImge,A.Name,A.RepertoryNumber,A.BuyNumber,A.MarketPrice,A.ShopPrice,A.BuyPrice,A.Attributes,A.SpecificationName,A.SpecificationValue,A.IsShipment,A.IsReal,A.ShopID,A.SellName,A.ExtensionAttriutes,A.ParentGuid,A.shop_category_id,A.IsJoinActivity,A.CartType,A.IsPresent,A.FeeType,B.MinusFee,A.Post_fee,A.Express_fee,A.Ems_fee,A.DetailedSpecifications, A.CreateTime FROM ShopNum1_Shop_Cart AS A Inner JOIN ShopNum1_Shop_Product AS B ON A.ProductGuid=B.Guid WHERE  B.isAudit=1 and B.isSell=1 and B.IsSaled=1 and B.isdeleted=0";
            if (Operator.FormatToEmpty(memLoginID) != string.Empty)
            {
                strSql = strSql + " AND A.MemLoginID=@memLoginID";
            }

            if (Operator.FormatToEmpty(guids) != string.Empty)
            {
                strSql = strSql + " AND A.Guid"+andSql;
            }
            if (Operator.FormatToEmpty(shop_category_id.ToString()) != string.Empty)
            {
                strSql = strSql + " and a.shop_category_id=@shop_category_id";
            }
            if (Operator.FormatToEmpty(shopcarguid.ToString()) != string.Empty)
            {
                strSql = strSql + " and a.Guid=@shopcarguid";
            }
            return DatabaseExcetue.ReturnDataTable(strSql,parms.ToArray());
        }

        public DataTable SearchShopByMemLoginID(string memLoginID)
        {
            string strSql = string.Empty;
            strSql =
                "SELECT distinct dd.category_name, A.ShopID,B.ShopName as sellname,B.Tel,B.shopid MemLoginID, a.shop_category_id FROM ShopNum1_Shop_Cart A LEFT JOIN ShopNum1_ShopInfo AS B ON A.ShopID=B.MemLoginID left join ShopNum1_Shop_CustomerCategory as dd on dd.id=a.shop_category_id WHERE 0 =0 AND A.MemLoginID = @MemLoginID and sellname!='' and productguid in(select guid from shopnum1_shop_product where isAudit=1 and isSell=1 and IsSaled=1 and isdeleted=0 ) ";
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@MemLoginID";
            paraValue[0] = memLoginID;
            
            return DatabaseExcetue.ReturnDataTable(strSql, paraName, paraValue);
        }

        public DataTable SearchShopByMemLoginID_two(string memLoginID, string guids, int shop_category_id)
        {
            List<DbParameter> parms = new List<DbParameter>();

            string andSql = string.Format(" in ({0})", DatabaseExcetue.GetGuidsSql(guids, parms));

            DbParameter parm = new SqlParameter();
            parm.ParameterName = "@memLoginID";
            parm.Value = memLoginID;
            parms.Add(parm);

            parm = new SqlParameter();
            parm.ParameterName = "@shop_category_id";
            parm.Value = shop_category_id;
            parms.Add(parm);
            string strSql = string.Empty;
            strSql =
                "SELECT DISTINCT A.ShopID,dd.category_name,B.ShopRank,B.ShopName as SellName,B.Tel,a.shop_category_id FROM ShopNum1_Shop_Cart AS A LEFT JOIN ShopNum1_ShopInfo AS B ON A.ShopID=B.MemLoginID left join ShopNum1_Shop_CustomerCategory as dd on dd.id=a.shop_category_id WHERE 0 =0 AND A.MemLoginID=@memLoginID and sellName!=''";
            if (guids != string.Empty)
            {
                strSql = strSql + " AND A.guid"+andSql;
                strSql = strSql + " and a.shop_category_id=@shop_category_id";
            }
            return DatabaseExcetue.ReturnDataTable(strSql,parms.ToArray());
        }

        public int DeleteShopcara(string guids)
        {



            return DatabaseExcetue.RunNonQuery("DELETE FROM ShopNum1_Shop_Cart  WHERE  Guid= '" + guids + "'");
        }
        public DataTable SelecetCatgrogryID(string guid)
        {

            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@guid";
            paraValue[0] = guid;
            return DatabaseExcetue.ReturnDataTable("select shop_category_id from ShopNum1_Shop_Cart where guid=@guid", paraName, paraValue);

         }
         public DataTable SelecetMaxnumber(string guid,string  catrogry)
        {

            var paraName = new string[2];
            var paraValue = new string[2];
            paraName[0] = "@guid";
            paraValue[0] = guid;
            paraName[1] = "@catrogry";
            paraValue[1] = catrogry.ToString();
            return DatabaseExcetue.ReturnDataTable("select maxnumber from  ShopNum1_Shop_Product as d left join ShopNum1_Shop_ProductPrice as p on d.id=p.productid where guid=@guid and shop_category_id=@catrogry", paraName, paraValue);

         }

         public DataTable SelecetShop_ProductPrice(string guid, string catrogry)
         {

             var paraName = new string[2];
             var paraValue = new string[2];
             paraName[0] = "@guid";
             paraValue[0] = guid;
             paraName[1] = "@catrogry";
             paraValue[1] = catrogry.ToString();
             return DatabaseExcetue.ReturnDataTable("select ShopPrice from  ShopNum1_Shop_Product as d left join ShopNum1_Shop_ProductPrice as p on d.id=p.productid where guid=@guid and shop_category_id=@catrogry", paraName, paraValue);

         }
        

        public DataTable SearchShopByMemLoginID_InsertOrderInfo(string memLoginID, string guids)
        {
            

            List<DbParameter> parms = new List<DbParameter>();

            string andSql = string.Format(" in ({0})", DatabaseExcetue.GetGuidsSql(guids, parms));

            DbParameter parm = new SqlParameter();
            parm.ParameterName = "@memLoginID";
            parm.Value = memLoginID;
            parms.Add(parm);

            
            string strSql = string.Empty;
            strSql =
                "SELECT DISTINCT A.ShopID,A.Score_dv,A.Score_pv_a,A.Score_pv_b ,A.Score_hv,dd.category_name,B.ShopRank,B.ShopName as SellName,B.Tel,a.shop_category_id,A.BuyNumber,a.ShopPrice,a.ProductGuId FROM ShopNum1_Shop_Cart AS A LEFT JOIN ShopNum1_ShopInfo AS B ON A.ShopID=B.MemLoginID left join ShopNum1_Shop_CustomerCategory as dd on dd.id=a.shop_category_id WHERE 0 =0 AND A.MemLoginID=@memLoginID and sellName!=''";
            if (guids != string.Empty)
            {
                strSql = strSql + " AND A.guid"+andSql;
            }
            return DatabaseExcetue.ReturnDataTable(strSql,parms.ToArray());
        }


        public DataTable SearchShopByMemLoginID(string memLoginID, string guids)
        {
            List<DbParameter> parms = new List<DbParameter>();

            string andSql = string.Format(" in ({0})", DatabaseExcetue.GetGuidsSql(guids, parms));

            DbParameter parm = new SqlParameter();
            parm.ParameterName = "@memLoginID";
            parm.Value = memLoginID;
            parms.Add(parm);

            

            string strSql = string.Empty;
            strSql =
                "select distinct ShopID,category_name,shop_category_id,SellName,Tel from (SELECT DISTINCT A.ShopID,A.Score_dv,A.Score_pv_a,A.Score_pv_b ,A.Score_hv,dd.category_name,B.ShopRank,B.ShopName as SellName,B.Tel,a.shop_category_id,A.BuyNumber,a.ShopPrice,a.ProductGuId FROM ShopNum1_Shop_Cart AS A LEFT JOIN ShopNum1_ShopInfo AS B ON A.ShopID=B.MemLoginID left join ShopNum1_Shop_CustomerCategory as dd on dd.id=a.shop_category_id WHERE 0 =0 AND A.MemLoginID=@memLoginID and sellName!=''";
            if (guids != string.Empty)
            {
                strSql = strSql +" AND A.guid"+andSql+") as a";
            }
            return DatabaseExcetue.ReturnDataTable(strSql,parms.ToArray());
        }

        public int Update(List<ShopNum1_Shop_Cart> listCart)
        {
            string item = string.Empty;
            var sqlList = new List<string>();
            foreach (ShopNum1_Shop_Cart cart in listCart)
            {
                item =
                    string.Concat(new object[]
                    {
                        "UPDATE  ShopNum1_Shop_Cart SET  BuyNumber=", cart.BuyNumber, ", BuyPrice=", cart.BuyPrice,
                        " WHERE Guid='", cart.Guid, "'"
                    });
                sqlList.Add(item);
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

        public int UpdateCar(List<ShopNum1_Shop_Cart> listCart)
        {
            string item = string.Empty;
            var sqlList = new List<string>();
            foreach (ShopNum1_Shop_Cart cart in listCart)
            {
                item =
                    string.Concat(new object[]
                    {
                        "UPDATE  ShopNum1_Shop_Cart SET  BuyNumber=", cart.BuyNumber, ", ShopPrice=", cart.ShopPrice
                        ,
                        " WHERE Guid='", cart.Guid, "'"
                    });
                sqlList.Add(item);
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
    }
}