using System;
using System.Data;
using System.Text;
using ShopNum1.DataAccess;
using ShopNum1.ShopInterface;
using ShopNum1MultiEntity;
using System.Collections;
using System.Data.Common;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace ShopNum1.ShopBusinessLogic
{
    public class Shop_Product_Action : IShop_Product_Action
    {


        /// <summary>
        /// 根据menberID查店铺名
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        public DataTable SelectShopInfoName(string memberid)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@memberid";
            parms[0].Value = memberid;



            return DatabaseExcetue.ReturnDataTable("SELECT ShopName FROM [ShopNum1_ShopInfo] WHERE MemLoginID=@memberid", parms);
        }

        //宝宝网资格商品新逻辑判断
        public DataTable SelectShopProductZG(string guid)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@guid";
            parms[0].Value = guid;



            return DatabaseExcetue.ReturnDataTable("SELECT agentId FROM ShopNum1_Shop_Product WHERE Guid=@guid", parms);
        }


        /// <summary>
        /// 微信专用
        /// </summary>
        /// <param name="guid"></param>
        /// <param name="shop_category_id"></param>
        /// <returns></returns>
        public DataTable GetShopProductEditWeixin(string guid, int shop_category_id)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(2);

            parms[0].ParameterName = "@guid";
            parms[0].Value = guid;
            parms[1].ParameterName = "@shop_category_id";
            parms[1].Value = shop_category_id;


            return DatabaseExcetue.ReturnDataTable("  SELECT a.OriginalImage,b.Name as ShopID,* FROM ShopNum1_Shop_Product as a left join ShopNum1_Shop_ProductPrice as p on p.productId=a.id left join ShopNum1_ShopInfo as b on a.ShopName=b.ShopName  WHERE p.shop_category_id=@shop_category_id and a.Guid=@guid", parms);
        }
        public int AddShopProduct(ShopNum1_Shop_Product shop_Product)
        {
            int cagetprodactid = 0;
            for (int i = 0; i < shop_Product.Prices.Count; i++)
            {
                 cagetprodactid +=Convert.ToInt32(shop_Product.Prices[i].Shop_category_id);
            }
            if (cagetprodactid>0)
            {
                var paraName = new string[54]; 
                var paraValue = new string[54];
                paraName[0] = "@guid";
                paraValue[0] = shop_Product.Guid.ToString();
                paraName[1] = "@name";
                paraValue[1] = shop_Product.Name;
                paraName[2] = "@productnum";
                paraValue[2] = shop_Product.ProductNum;
                /*  paraName[3] = "@ShopPrice";
                  paraValue[3] = shop_Product.ShopPrice.ToString();
                  paraName[4] = "@MarketPrice";
                  paraValue[4] = shop_Product.MarketPrice.ToString();*/
                paraName[3] = "@RepertoryCount";
                paraValue[3] = shop_Product.RepertoryCount.ToString();
                paraName[4] = "@unitname";
                paraValue[4] = shop_Product.UnitName;
                paraName[5] = "@detail";
                paraValue[5] = shop_Product.Detail;
                paraName[6] = "@instruction";
                paraValue[6] = shop_Product.Instruction;
                paraName[7] = "@BrandGuid";
                paraValue[7] = shop_Product.BrandGuid.ToString();
                paraName[8] = "@BrandName";
                paraValue[8] = shop_Product.BrandName;
                paraName[9] = "@productseriescode";
                paraValue[9] = shop_Product.ProductSeriesCode;
                paraName[10] = "@productseriesname";
                paraValue[10] = shop_Product.ProductSeriesName;
                paraName[11] = "@productcategorycode";
                paraValue[11] = shop_Product.ProductCategoryCode;
                paraName[12] = "@productcategoryname";
                paraValue[12] = shop_Product.ProductCategoryName;
                paraName[13] = "@originalimage";
                paraValue[13] = shop_Product.OriginalImage;
                paraName[14] = "@thumbimage";
                paraValue[14] = shop_Product.ThumbImage;
                paraName[15] = "@SmallImage";
                paraValue[15] = shop_Product.SmallImage;
                paraName[16] = "@MultiImages";
                paraValue[16] = shop_Product.MultiImages;
                paraName[17] = "@description";
                paraValue[17] = shop_Product.Description;
                paraName[18] = "@keywords";
                paraValue[18] = shop_Product.Keywords;
                paraName[19] = "@AddressCode";
                paraValue[19] = shop_Product.AddressCode;
                paraName[20] = "@AddressValue";
                paraValue[20] = shop_Product.AddressValue;
                paraName[21] = "@memloginid";
                paraValue[21] = shop_Product.MemLoginID;
                paraName[22] = "@shopname";
                paraValue[22] = shop_Product.ShopName;
                paraName[23] = "@isaudit";
                paraValue[23] = shop_Product.IsAudit.ToString();
                paraName[24] = "@FeeType";
                paraValue[24] = shop_Product.FeeType.ToString();
                paraName[25] = "@Post_fee";
                paraValue[25] = shop_Product.Post_fee.ToString();
                paraName[26] = "@Express_fee";
                paraValue[26] = shop_Product.Express_fee.ToString();
                paraName[27] = "@Ems_fee";
                paraValue[27] = shop_Product.Ems_fee.ToString();
                paraName[28] = "@FeeTemplateID";
                paraValue[28] = shop_Product.FeeTemplateID.ToString();
                paraName[29] = "@FeeTemplateName";
                paraValue[29] = shop_Product.FeeTemplateName;
                paraName[30] = "@MinusFee";
                paraValue[30] = shop_Product.MinusFee.ToString();
                paraName[31] = "@IsReal";
                paraValue[31] = shop_Product.IsReal.ToString();
                paraName[32] = "@IsSell";
                paraValue[32] = shop_Product.IsSell.ToString();
                paraName[33] = "@CreateUser";
                paraValue[33] = shop_Product.CreateUser;
                paraName[34] = "@saletime";
                paraValue[34] = shop_Product.SaleTime.ToString();
                paraName[35] = "@DeSaleTime";
                paraValue[35] = shop_Product.DeSaleTime.ToString();
                paraName[36] = "@ModifyTime";
                paraValue[36] = shop_Product.ModifyTime.ToString();
                paraName[37] = "@StartTime";
                paraValue[37] = shop_Product.StartTime.ToString();
                paraName[38] = "@EndTime";
                paraValue[38] = shop_Product.EndTime.ToString();
                paraName[39] = "@ProductState";
                paraValue[39] = shop_Product.ProductState.ToString();
                paraName[40] = "@Ctype";
                paraValue[40] = shop_Product.Ctype.ToString();
                paraName[41] = "@IsShopNew";
                paraValue[41] = shop_Product.IsShopNew.ToString();
                paraName[42] = "@IsShopHot";
                paraValue[42] = shop_Product.IsShopHot.ToString();
                paraName[43] = "@IsShopPromotion";
                paraValue[43] = shop_Product.IsShopPromotion.ToString();
                paraName[44] = "@IsShopRecommend";
                paraValue[44] = shop_Product.IsShopRecommend.ToString();
                paraName[45] = "@SetStock";
                paraValue[45] = shop_Product.SetStock.ToString();
                paraName[46] = "@pulishtype";
                paraValue[46] = shop_Product.PulishType.ToString();
                paraName[47] = "@Wap_desc";
                paraValue[47] = shop_Product.Wap_desc;
                paraName[48] = "@RepertoryAlertCount";
                paraValue[48] = shop_Product.RepertoryAlertCount.ToString();
                paraName[49] = "@Color";
                paraValue[49] = shop_Product.Color.ToString();
                paraName[50] = "@Size";
                paraValue[50] = shop_Product.Size.ToString();
                paraName[51] = "@GoodsWeight";
                paraValue[51] = shop_Product.textWeight.ToString();
                paraName[52] = "@SaleNumber";
                paraValue[52] = shop_Product.SaleNumber.ToString();
                 /* paraName[54] = "@Score_hv";
                 paraValue[54] = shop_Product.Score_hv.ToString();
                 paraName[55] = "@Score_sv";
                 paraValue[55] = shop_Product.Score_sv.ToString();
                 paraName[56] = "@Score_max_hv";
                 paraValue[56] = shop_Product.Score_max_hvc.ToString();*/
                paraName[53] = "@unitCount";
                paraValue[53] = shop_Product.unitCount.ToString();

                int returnValue = Convert.ToInt32(DatabaseExcetue.RunProcedureReturnDataSet("Pro_Shop_AddShopProduct", paraName, paraValue).Tables[0].Rows[0]["returnvalue"]);

                for (int i = 0; i < shop_Product.Prices.Count; i++)
                {

                    var paraName_price = new string[13];
                    var paraValue_price = new string[13];
                    paraName_price[0] = "@Score_pv_a";
                    paraValue_price[0] = (shop_Product.Prices[i].Score_Score_Pv_a).ToString();
                    paraName_price[1] = "@Score_hv";
                    paraValue_price[1] = (shop_Product.Prices[i].Score_Score_hv).ToString();
                    paraName_price[2] = "@Score_max_hv";
                    paraValue_price[2] = (shop_Product.Prices[i].Score_Score_max_hvc).ToString();
                    paraName_price[3] = "@Score_cv";
                    paraValue_price[3] = (shop_Product.Prices[i].score_cv).ToString();
                    paraName_price[4] = "@shop_category_id";
                    paraValue_price[4] = (shop_Product.Prices[i].Shop_category_id).ToString();
                    paraName_price[5] = "@ShopPrice";
                    paraValue_price[5] = (shop_Product.Prices[i].shopPrice).ToString();
                    paraName_price[6] = "@MarketPrice";
                    paraValue_price[6] = (shop_Product.Prices[i].marketPrice).ToString();
                    paraName_price[6] = "@MarketPrice";
                    paraValue_price[6] = (shop_Product.Prices[i].marketPrice).ToString();
                    paraName_price[7] = "@productId";
                    paraValue_price[7] = returnValue.ToString();
                    paraName_price[8] = "@Score_dv";
                    paraValue_price[8] = (shop_Product.Prices[i].Score_Score_dv).ToString();
                    paraValue_price[8] = (shop_Product.Prices[i].Score_Score_dv).ToString();
                    paraName_price[9] = "@Score_pv_cv";
                    paraValue_price[9] = (shop_Product.Prices[i].scroce_pv_cv).ToString();
                    paraName_price[10] = "@Score_pv_b";
                    paraValue_price[10] = (shop_Product.Prices[i].Score_Score_Pv_b).ToString();
                    paraName_price[11] = "@MaxNumber";
                    paraValue_price[11] = shop_Product.MaxNumber_one.ToString();
                    paraName_price[12] = "@MyPrice";
                    paraValue_price[12] = shop_Product.MyPrice.ToString();

                     DatabaseExcetue.RunNonQuery("INSERT INTO ShopNum1_Shop_ProductPrice(productId,Score_pv_a,Score_hv,Score_max_hv,Score_cv,shop_category_id,ShopPrice,MarketPrice,Score_dv,Score_pv_cv,Score_pv_b,MaxNumber,MyPrice) VALUES(@productId,@Score_pv_a,@Score_hv,@Score_max_hv,@Score_cv,@shop_category_id,@ShopPrice,@MarketPrice,@Score_dv,@Score_pv_cv,@Score_pv_b,@MaxNumber,@MyPrice)", paraName_price, paraValue_price);
                }
                return returnValue;
            }

            else
            {
                return 1;
            }
             
        }






        public void AddshopNum1_Shop_ProductPrice(ShopNum1_Shop_Product shop_Product)
         {
             
             for (int i = 0; i < shop_Product.Prices.Count; i++)
             {
                
                     
                
                 var paraName_price = new string[11];
                 var paraValue_price = new string[11];
                 paraName_price[0] = "@Score_pv_a";
                 paraValue_price[0] = (shop_Product.Prices[i].Score_Score_Pv_a).ToString();
                 paraName_price[1] = "@Score_hv";
                 paraValue_price[1] = (shop_Product.Prices[i].Score_Score_hv).ToString();
                 paraName_price[2] = "@Score_max_hv";
                 paraValue_price[2] = (shop_Product.Prices[i].Score_Score_max_hvc).ToString();
                 paraName_price[3] = "@Score_cv";
                 paraValue_price[3] = (shop_Product.Prices[i].score_cv).ToString();
                 paraName_price[4] = "@shop_category_id";
                 paraValue_price[4] = (shop_Product.Prices[i].Shop_category_id).ToString();
                 paraName_price[5] = "@ShopPrice";
                 paraValue_price[5] = (shop_Product.Prices[i].shopPrice).ToString();
                 paraName_price[6] = "@MarketPrice";
                 paraValue_price[6] = (shop_Product.Prices[i].marketPrice).ToString();
                 paraName_price[6] = "@MarketPrice";
                 paraValue_price[6] = (shop_Product.Prices[i].marketPrice).ToString();
                 paraName_price[7] = "@MyId";
                 paraValue_price[7] = shop_Product.MyID.ToString();
                 paraName_price[8] = "@Score_dv";
                 paraValue_price[8] = (shop_Product.Prices[i].Score_Score_dv).ToString();
                 paraName_price[9] = "@Score_pv_cv";
                 paraValue_price[9] = (shop_Product.Prices[i].scroce_pv_cv).ToString();
                 paraName_price[10] = "@Score_pv_bv";
                 paraValue_price[10] = (shop_Product.Prices[i].Score_Score_Pv_b).ToString();

                 DatabaseExcetue.RunNonQuery("INSERT INTO ShopNum1_Shop_ProductPrice(productId,Score_pv_a,Score_hv,Score_max_hv,Score_cv,shop_category_id,ShopPrice,MarketPrice,Score_dv,Score_pv_cv,Score_pv_b) VALUES(@MyId,@Score_pv_a,@Score_hv,@Score_max_hv,@Score_cv,@shop_category_id,@ShopPrice,@MarketPrice,@Score_dv,@Score_pv_cv,@Score_pv_bv)", paraName_price, paraValue_price);
             }
             
         }


        public DataTable DelectShopNum1_Shop_Product(string Myid)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@id";
            paraValue[0] = Myid;
            return DatabaseExcetue.ReturnDataTable("delete from ShopNum1_Shop_Product where Id=@id", paraName, paraValue);
        }

        public DataTable DelectShopNum1_Shop_ProductPrice(string Myid)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@id";
            paraValue[0] =Myid;
            return DatabaseExcetue.ReturnDataTable("delete from ShopNum1_Shop_ProductPrice where productId=@id", paraName, paraValue);
        }


        public DataTable AutoSearchProductName(string keyword)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@keyword";
            paraValue[0] = keyword;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_AutoSearchProductName", paraName, paraValue);
        }

        public DataTable AutoSearchProductName(string keyword, string type)
        {
            var paraName = new[] {"@keyword", "@type"};
            var paraValue = new[] {keyword, type};
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_AutoSearchProductName", paraName, paraValue);
        }

        public DataTable AutoSearchShopName(string keyword)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@keyword";
            paraValue[0] = keyword;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_AutoSearchShopName", paraName, paraValue);
        }

        public DataTable AutoSearchShopName(string keyword, string type)
        {
            var paraName = new[] {"@keyword", "@type"};
            var paraValue = new[] {keyword, type};
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_AutoSearchShopName", paraName, paraValue);
        }

        public DataTable AutoSearchSupplyName(string keyword)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@keyword";
            paraValue[0] = keyword;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_AutoSearchSupplyName", paraName, paraValue);
        }

        public DataTable CheckMenberBuyProduct(string guid, string memberid)
        {
            var paraName = new string[2];
            var paraValue = new string[2];
            paraName[0] = "@guid";
            paraValue[0] = guid;
            paraName[1] = "@memberid";
            paraValue[1] = memberid;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_CheckMenberBuyProduct", paraName, paraValue);
        }

        public string CheckSpellPanicProduct(string memberid, string type)
        {
            var paraName = new string[2];
            var paraValue = new string[2];
            paraName[0] = "@memberid";
            paraValue[0] = memberid;
            paraName[1] = "@type";
            paraValue[1] = type;
            return
                DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_CheckSpellPanicProduct", paraName, paraValue).Rows
                    [0][0].ToString();
        }

        public int DeleteById(string strId)
        {
            return DatabaseExcetue.RunNonQuery("Delete from  Shopnum1_Shop_Product WHERE Id IN (" + strId + ")");
        }

        public int DeleteShopProduct(string guid, string memloginid)
        {
            return
                DatabaseExcetue.RunNonQuery("delete from ShopNum1_Shop_Product where id='" + guid + "' and memloginid='" +
                                            memloginid + "'");
        }
        public DataTable selectMaxNumber(string guid)
        {
            return DatabaseExcetue.ReturnDataTable(" select e.MaxNumber from [ShopNum1_Shop_Product] as c left join ShopNum1_Shop_ProductPrice as e on e.productId=c.id  where c.guid='" + guid + "'");
        }
        public int DeleteShopNum1_Shop_ProductPricet(string guid, string shop_category_id)
        {
            DataTable cc = DatabaseExcetue.ReturnDataTable(" select e.ShopPrice from [ShopNum1_Shop_Product] as c left join ShopNum1_Shop_ProductPrice as e on e.productId=c.id  where c.id='" + guid + "'");
           // return
              //  DatabaseExcetue.RunNonQuery("delete from ShopNum1_Shop_ProductPrice where productId='" + guid + "' and shop_category_id='" +
                                         //   shop_category_id + "'");
            if (cc.Rows.Count>1)
            {
                return
               DatabaseExcetue.RunNonQuery("delete from ShopNum1_Shop_ProductPrice where productId='" + guid + "' and shop_category_id='" +
                                            shop_category_id + "'");
            }
            else
            {
                DatabaseExcetue.RunNonQuery("delete from ShopNum1_Shop_ProductPrice where productId='" + guid + "' and shop_category_id='" +
                                            shop_category_id + "'");
              //  DatabaseExcetue.RunNonQuery("delete from ShopNum1_Shop_Product where Id='" + guid + "' ");
                return DatabaseExcetue.RunNonQuery("delete from ShopNum1_Shop_Product where Id='" + guid + "' "); ;
            }
        }
      /*  public int UpdateShopNum1_Shop_ProductPricet(string guid, string shop_category_id)
        {
            var paraName = new string[2];
            var paraValue = new string[2];
            paraName[0] = "@guid";
            paraValue[0] = guid;
            paraName[1] = "@shop_category_id";
            paraValue[1] = shop_category_id;

            return
                DatabaseExcetue.RunNonQuery("update ");
        }*/


        public DataTable GetCollectRankingProduct(string showcount, string shopid,int category)
        {
            var paraName = new string[3];
            var paraValue = new string[3];
            paraName[0] = "@showcount";
            paraValue[0] = showcount;
            paraName[1] = "@shopid";
            paraValue[1] = shopid;
            paraName[2] = "@category";
            paraValue[2] = category.ToString();
            //paraName[1] = "@category";
            //paraValue[1] = category.ToString();
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetCollectRankingProduct", paraName, paraValue);
        }
         



        public DataTable GetIsProduct(string isnew, string ishot, string ispromotion, string showcount, string ordertype,
            string shopid, string sort)
        {
            var paraName = new string[7];
            var paraValue = new string[7];
            paraName[0] = "@isnew";
            paraValue[0] = isnew;
            paraName[1] = "@ishot";
            paraValue[1] = ishot;
            paraName[2] = "@ispromotion";
            paraValue[2] = ispromotion;
            paraName[3] = "@showcount";
            paraValue[3] = showcount;
            paraName[4] = "@ordertype";
            paraValue[4] = ordertype;
            paraName[5] = "@shopid";
            paraValue[5] = shopid;
            paraName[6] = "@sort";
            paraValue[6] = sort;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetIsProduct", paraName, paraValue);
        }

        public DataTable GetIsProduct(string isnew, string ishot, string ispromotion, string ispanicbuy,
            string isspellbuy, string showcount, string ordertype, string shopid)
        {
            var paraName = new string[8];
            var paraValue = new string[8];
            paraName[0] = "@isnew";
            paraValue[0] = isnew;
            paraName[1] = "@ishot";
            paraValue[1] = ishot;
            paraName[2] = "@ispromotion";
            paraValue[2] = ispromotion;
            paraName[3] = "@ispanicbuy";
            paraValue[3] = ispanicbuy;
            paraName[4] = "@isspellbuy";
            paraValue[4] = isspellbuy;
            paraName[5] = "@showcount";
            paraValue[5] = showcount;
            paraName[6] = "@ordertype";
            paraValue[6] = ordertype;
            paraName[7] = "@shopid";
            paraValue[7] = shopid;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetIsAllProduct", paraName, paraValue);
        }

        public DataTable GetIsProductAndRecommend(string isnew, string ishot, string ispromotion, string IsShopRecommend,
            string ispanicbuy, string isspellbuy, string showcount,
            string ordertype, string shopid, int shop_category_id)
        {
            var paraName = new string[10];
            var paraValue = new string[10];
            paraName[0] = "@isnew";
            paraValue[0] = isnew;
            paraName[1] = "@ishot";
            paraValue[1] = ishot;
            paraName[2] = "@ispromotion";
            paraValue[2] = ispromotion;
            paraName[8] = "@IsShopRecommend";
            paraValue[8] = IsShopRecommend;
            paraName[3] = "@ispanicbuy";
            paraValue[3] = ispanicbuy;
            paraName[4] = "@isspellbuy";
            paraValue[4] = isspellbuy;
            paraName[5] = "@showcount";
            paraValue[5] = showcount;
            paraName[6] = "@ordertype";
            paraValue[6] = ordertype;
            paraName[7] = "@shopid";
            paraValue[7] = shopid;
            paraName[9] = "@shop_category_id";
            paraValue[9] = shop_category_id.ToString();

            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetIsProductAndRecommend", paraName, paraValue);
        }
        public DataTable GetAllToShop_ProductByshop_category_id(string shopid, int shop_category_id)
        {
            var paraName = new string[3];
            var paraValue = new string[3];
            paraName[0] = "@shopid";
            paraValue[0] = shopid;
            paraName[1] = "@shop_category_id";
            paraValue[1] = shop_category_id.ToString();
            paraName[2] = "@IsAudit";
            paraValue[2] = "1";
            return DatabaseExcetue.ReturnDataTable("select * from ShopNum1_Shop_Product left join ShopNum1_Shop_ProductPrice on ShopNum1_Shop_ProductPrice.productId=ShopNum1_Shop_Product.id where MemLoginID=@shopid and IsDeleted=0 and ShopNum1_Shop_ProductPrice.shop_category_id=@shop_category_id and IsAudit=@IsAudit  AND IsSell=1  AND ProductState=0 and IsDeleted=0 order by ShopNum1_Shop_Product.ProductCategoryCode", paraName, paraValue);
        }

        public DataTable GetAllToShop_ProductByshop_category_id_two(string shopid, int shop_category_id, string guid)
        {
            var paraName = new string[3];
            var paraValue = new string[3];
            paraName[0] = "@shopid";
            paraValue[0] = shopid;
            paraName[1] = "@shop_category_id";
            paraValue[1] = shop_category_id.ToString();
            paraName[2] = "@guid";
            paraValue[2] = guid.ToString();
            return DatabaseExcetue.ReturnDataTable("select * from ShopNum1_Shop_Product left join ShopNum1_Shop_ProductPrice on ShopNum1_Shop_ProductPrice.productId=ShopNum1_Shop_Product.id where MemLoginId=@shopid and ShopNum1_Shop_ProductPrice.shop_category_id=@shop_category_id and ShopNum1_Shop_Product.guid=@guid", paraName, paraValue);
        }



        public DataTable SelecetBuyNumberByGuid(Guid guid, string MemLoginId)
        {
            var paraName = new string[2];
            var paraValue = new string[2];
            paraName[0] = "@guid";
            paraValue[0] = guid.ToString();
            paraName[1] = "@MemLoginId";
            paraValue[1] = MemLoginId;

            return DatabaseExcetue.ReturnDataTable(" select BuyNumber from ShopNum1_Shop_Cart where  ProductGuId=@guid and MemLoginId=@MemLoginId", paraName, paraValue);
        }

        public DataTable SelecetMaxNumberByid(int productId)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@productId";
            paraValue[0] = productId.ToString();

            return DatabaseExcetue.ReturnDataTable("select MaxNumber from ShopNum1_Shop_Product as d left join ShopNum1_Shop_ProductPrice as c on c.productId=d.id where productId=@productId", paraName, paraValue);
        }

        public DataTable GetAllToShop_ProductByshop_category_id_free(string shopid, int shop_category_id, string productId)
        {
            var paraName = new string[3];
            var paraValue = new string[3];
            paraName[0] = "@shopid";
            paraValue[0] = shopid;
            paraName[1] = "@shop_category_id";
            paraValue[1] = shop_category_id.ToString();
            paraName[2] = "@productId";
            paraValue[2] = productId.ToString();
            return DatabaseExcetue.ReturnDataTable("select * from ShopNum1_Shop_Product left join ShopNum1_Shop_ProductPrice on ShopNum1_Shop_ProductPrice.productId=ShopNum1_Shop_Product.id where ShopNum1_Shop_Product.MemLoginID=@shopid and ShopNum1_Shop_ProductPrice.shop_category_id=@shop_category_id and ShopNum1_Shop_ProductPrice.productId=@productId", paraName, paraValue);
        }


        public DataTable GetAllShop_Cart(string shopid, int shop_category_id, string ProductGuId)
        {
            var paraName = new string[3];
            var paraValue = new string[3];
            paraName[0] = "@shopid";
            paraValue[0] = shopid;
            paraName[1] = "@shop_category_id";
            paraValue[1] = shop_category_id.ToString();
            paraName[2] = "@ProductGuId";
            paraValue[2] = ProductGuId;
            return DatabaseExcetue.ReturnDataTable("select * from ShopNum1_Shop_Cart where ShopID=@shopid and shop_category_id=@shop_category_id and ProductGuId=@ProductGuId", paraName, paraValue);
        }




        public DataSet GetIsProductNew(string isnew, string ishot, string ispromotion, string ordertype, string shopid,
            string sort, string perpagenum, string current_page, string isreturcount)
        {
            string str = string.Empty;
            if (isnew != "-1")
            {
                str = " AND IsShopNew=" + isnew;
            }
            if (ishot != "-1")
            {
                str = str + " AND isShophot=" + ishot;
            }
            if (ispromotion != "-1")
            {
                str = str + " AND isShoppromotion=" + ispromotion;
            }
            str = str + " AND issell=1 AND IsAudit=1 and starttime<=getdate() and  ProductState=0 ";
            var paraName = new string[11];
            var paraValue = new string[11];
            paraName[0] = "@isnew";
            paraValue[0] = isnew;
            paraName[1] = "@ishot";
            paraValue[1] = ishot;
            paraName[2] = "@ispromotion";
            paraValue[2] = ispromotion;
            paraName[3] = "@columnnames";
            paraValue[3] =
                " Guid,Name,ProductNum,ShopPrice,MarketPrice,RepertoryCount,UnitName,CreateTime,Detail,Instruction,ProductSeriesCode,ProductSeriesName,ProductCategoryCode,ProductCategoryName,IsNew,IsHot,IsPromotion,OriginalImage,ThumbImage,multiImages,ClickCount,CollectCount,BuyCount,CommentCount,SaleNumber,Description,Keywords,starttime,endtime,MemLoginID,ShopName ";
            paraName[4] = "@searchname";
            paraValue[4] = str;
            paraName[5] = "@ordertype";
            paraValue[5] = ordertype;
            paraName[6] = "@shopid";
            paraValue[6] = shopid;
            paraName[7] = "@sort";
            paraValue[7] = sort;
            paraName[8] = "@perpagenum";
            paraValue[8] = perpagenum;
            paraName[9] = "@current_page";
            paraValue[9] = current_page;
            paraName[10] = "@isreturcount";
            paraValue[10] = isreturcount;
            return DatabaseExcetue.RunProcedureReturnDataSet("Pro_Shop_GetIsProductNew", paraName, paraValue);
        }

        public DataSet GetIsProductNew(string isnew, string ishot, string ispromotion, string ispanicbuy,
            string isspellbuy, string ordertype, string shopid, string sort,
            string perpagenum, string current_page, string isreturcount)
        {
            string str = string.Empty;
            if (isnew != "-1")
            {
                str = " AND  IsNew=" + isnew;
            }
            if (ishot != "-1")
            {
                str = str + " AND ishot=" + ishot;
            }
            if (ispromotion != "-1")
            {
                str = str + " AND ispromotion=" + ispromotion;
            }
            str = str + " AND issell=1 AND IsAudit=1 and  ProductState=0  ";
            var paraName = new string[11];
            var paraValue = new string[11];
            paraName[0] = "@isnew";
            paraValue[0] = isnew;
            paraName[1] = "@ishot";
            paraValue[1] = ishot;
            paraName[2] = "@ispromotion";
            paraValue[2] = ispromotion;
            paraName[3] = "@columnnames";
            paraValue[3] =
                "Guid,Name,ProductNum,ShopPrice,IsNew,IsHot,IsPromotion,OriginalImage,SaleNumber,MemLoginID,ShopName,Collectcount,CreateTime";
            paraName[4] = "@searchname";
            paraValue[4] = str;
            paraName[5] = "@ordertype";
            paraValue[5] = ordertype;
            paraName[6] = "@shopid";
            paraValue[6] = shopid;
            paraName[7] = "@sort";
            paraValue[7] = sort;
            paraName[8] = "@perpagenum";
            paraValue[8] = perpagenum;
            paraName[9] = "@current_page";
            paraValue[9] = current_page;
            paraName[10] = "@isreturcount";
            paraValue[10] = isreturcount;
            return DatabaseExcetue.RunProcedureReturnDataSet("Pro_Shop_GetIsProductNew", paraName, paraValue);
        }

        public DataSet GetIsProductNewAndRecommend(string isnew, string ishot, string ispromotion,
            string IsShopRecommend, string ordertype, string shopid, string sort,
            string perpagenum, string current_page, string isreturcount,int shop_category_id)
        {
            string str = string.Empty;
            if (isnew != "-1")
            {
                str = " AND IsShopNew=" + isnew;
            }
            if (ishot != "-1")
            {
                str = str + " AND isShophot=" + ishot;
            }
            if (ispromotion != "-1")
            {
                str = str + " AND isShoppromotion=" + ispromotion;
            }
            if (IsShopRecommend != "-1")
            {
                str = str + " AND IsShopRecommend=" + IsShopRecommend;
            }
            str = str + " AND issell=1 AND IsAudit=1 and  ProductState=0 ";
            var paraName = new string[13];
            var paraValue = new string[13];
            
            paraName[0] = "@isnew";
            paraValue[0] = isnew;
            paraName[1] = "@ishot";
            paraValue[1] = ishot;
            paraName[2] = "@ispromotion";
            paraValue[2] = ispromotion;
            paraName[3] = "@columnnames";
            paraValue[3] =
                " Score_dv,Score_cv,shop_category_id,Guid,Name,ProductNum,p.ShopPrice,IsNew,IsHot,IsPromotion,OriginalImage,SaleNumber,MemLoginID,ShopName,Collectcount,CreateTime ";
            paraName[4] = "@searchname";
            paraValue[4] = str;
            paraName[5] = "@ordertype";
            paraValue[5] = ordertype;
            paraName[6] = "@shopid";
            paraValue[6] = shopid;
            paraName[7] = "@sort";
            paraValue[7] = sort;
            paraName[8] = "@perpagenum";
            paraValue[8] = perpagenum;
            paraName[9] = "@current_page";
            paraValue[9] = current_page;
            paraName[10] = "@isreturcount";
            paraValue[10] = isreturcount;
            paraName[11] = "@IsShopRecommend";
            paraValue[11] = IsShopRecommend;
            paraName[12] = "@shop_category_id";
            paraValue[12] = shop_category_id.ToString();
            return DatabaseExcetue.RunProcedureReturnDataSet("Pro_Shop_GetIsProductNewRecommend", paraName, paraValue);
        }

        public DataSet GetIsProductNewProductState(string isnew, string ishot, string ispromotion, string ispanicbuy,
            string isspellbuy, string ordertype, string shopid, string sort,
            string perpagenum, string current_page, string isreturcount)
        {
            string str = string.Empty;
            if (isnew != "-1")
            {
                str = " AND  IsNew=" + isnew;
            }
            if (ishot != "-1")
            {
                str = str + " AND ishot=" + ishot;
            }
            if (ispromotion != "-1")
            {
                str = str + " AND ispromotion=" + ispromotion;
            }
            str = str + " AND issell=1 AND IsAudit=1 and  ProductState=1  ";
            var paraName = new string[11];
            var paraValue = new string[11];
            paraName[0] = "@isnew";
            paraValue[0] = isnew;
            paraName[1] = "@ishot";
            paraValue[1] = ishot;
            paraName[2] = "@ispromotion";
            paraValue[2] = ispromotion;
            paraName[3] = "@columnnames";
            paraValue[3] =
                "Guid,Name,ProductNum,p.ShopPrice,IsNew,IsHot,IsPromotion,OriginalImage,SaleNumber,MemLoginID,ShopName,Collectcount,CreateTime ";
            paraName[4] = "@searchname";
            paraValue[4] = str;
            paraName[5] = "@ordertype";
            paraValue[5] = ordertype;
            paraName[6] = "@shopid";
            paraValue[6] = shopid;
            paraName[7] = "@sort";
            paraValue[7] = sort;
            paraName[8] = "@perpagenum";
            paraValue[8] = perpagenum;
            paraName[9] = "@current_page";
            paraValue[9] = current_page;
            paraName[10] = "@isreturcount";
            paraValue[10] = isreturcount;
            return DatabaseExcetue.RunProcedureReturnDataSet("Pro_Shop_GetIsProductNew", paraName, paraValue);
        }

        public int GetLimitBuyCount(string guid)
        {
            return
                Convert.ToInt32(
                    DatabaseExcetue.ReturnDataTable("SELECT RepertoryCount FROM ShopNum1_Shop_Product WHERE Guid='" +
                                                    guid + "'").Rows[0]["RepertoryCount"].ToString());
        }

        public DataTable GetPanicBuyList(string shopid, string showcount, string productguid)
        {
            var paraName = new string[3];
            var paraValue = new string[3];
            paraName[0] = "@shopid";
            paraValue[0] = shopid;
            paraName[1] = "@showcount";
            paraValue[1] = showcount;
            paraName[2] = "@productguid";
            paraValue[2] = productguid;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetPanicBuyList", paraName, paraValue);
        }

        public DataSet GetPanicInfo(string shopid, string guid)
        {
            var paraName = new string[2];
            var paraValue = new string[2];
            paraName[0] = "@shopid";
            paraValue[0] = shopid;
            paraName[1] = "@guid";
            paraValue[1] = guid;
            return DatabaseExcetue.RunProcedureReturnDataSet("Pro_Shop_GetPanicInfoNew", paraName, paraValue);
        }

        public DataTable GetPanicInfoMeta(string shopid, string guid)
        {
            var paraName = new string[2];
            var paraValue = new string[2];
            paraName[0] = "@shopid";
            paraValue[0] = shopid;
            paraName[1] = "@guid";
            paraValue[1] = guid;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetPanicInfoMeta", paraName, paraValue);
        }

        public DataTable GetPanicList(string showcount, string ordertype, string shopid)
        {
            return null;
        }

        public DataTable GetProductBrandAndOrderIdByCode(string code)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@code";
            paraValue[0] = code;
            return DatabaseExcetue.RunProcedureReturnDataTable("[Pro_Shop_GetProductBrandAndOrderIdByCode]", paraName,
                paraValue);
        }

        public DataTable GetProductCategoryNameByCode(string code)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@code";
            paraValue[0] = code;
            return DatabaseExcetue.RunProcedureReturnDataTable("[Pro_Shop_GetProductInfoByCode]", paraName, paraValue);
        }

        public DataTable GetProductDetail(string guid)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@guid";
            paraValue[0] = guid;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetProductInfo", paraName, paraValue);
        }

        public DataTable GetProductDetailMeta(string guid)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@guid";
            paraValue[0] = guid;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetProductDetailMeta", paraName, paraValue);
        }

        public DataSet GetProductInfoByGuidAndMemLoginID(string guid, string memloginid)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@guid";
            paraValue[0] = guid;
            return DatabaseExcetue.RunProcedureReturnDataSet("Pro_Shop_GetProductDetailByGuId", paraName, paraValue);
        }

        public DataTable GetSaleRankingProduct(string showcount, string shopid,int category)
        {
            var paraName = new string[3];
            var paraValue = new string[3];
            paraName[0] = "@showcount";
            paraValue[0] = showcount;
            paraName[1] = "@shopid";
            paraValue[1] = shopid;
            paraName[2] = "@category";
            paraValue[2] = category.ToString();
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetSaleRankingProduct", paraName, paraValue);
        }

        public DataTable GetShopCategroy(string memloginid)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@memloginid";
            paraValue[0] = memloginid;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_GetShopCategroy", paraName, paraValue);
        }

        public DataTable GetShopMetaByGuid(string guid)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@guid";
            paraValue[0] = guid;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetShopMetaByGuid", paraName, paraValue);
        }

        public DataTable GetShopName(string memberID)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@memberid";
            paraValue[0] = memberID;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetShopInfoByMemloginID", paraName, paraValue);
        }

        public DataTable GetShopProduct(string name, string productnum, string issaled, string beginprice,
            string endprice, string producttype, string productseriescode,
            string productcategorycode, string memloginid, string isAudit)
        {
            var paraName = new string[10];
            var paraValue = new string[10];
            paraName[0] = "@name";
            paraValue[0] = name;
            paraName[1] = "@productnum";
            paraValue[1] = productnum;
            paraName[2] = "@issaled";
            paraValue[2] = issaled;
            paraName[3] = "@beginprice";
            paraValue[3] = beginprice;
            paraName[4] = "@endprice";
            paraValue[4] = endprice;
            paraName[5] = "@producttype";
            paraValue[5] = producttype;
            paraName[6] = "@productseriescode";
            paraValue[6] = productseriescode;
            paraName[7] = "@productcategorycode";
            paraValue[7] = productcategorycode;
            paraName[8] = "@memloginid";
            paraValue[8] = memloginid;
            paraName[9] = "@isAudit";
            paraValue[9] = isAudit;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetShopProduct", paraName, paraValue);
        }

        public DataTable GetShopproductCatetoryByCode(string code, string memloginid)
        {
            var paraName = new string[2];
            var paraValue = new string[2];
            paraName[0] = "@code";
            paraValue[0] = code;
            paraName[1] = "@memloginid";
            paraValue[1] = memloginid;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetShopproductCatetoryByCode", paraName,
                paraValue);
        }

        public DataTable GetShopProductDetailMeto(string guid)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@guid";
            paraValue[0] = guid;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetShopProductDetailMeto", paraName, paraValue);
        }

        public DataTable GetShopProductEdit(string guid, int shop_category_id)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(2);

            parms[0].ParameterName = "@guid";
            parms[0].Value = guid;
            parms[1].ParameterName = "@shop_category_id";
            parms[1].Value = shop_category_id;
            

            return DatabaseExcetue.ReturnDataTable("SELECT * FROM ShopNum1_Shop_Product as a left join ShopNum1_Shop_ProductPrice as p on p.productId=a.id WHERE p.shop_category_id=@shop_category_id and a.Guid=@guid",parms);
        }
        public DataTable GetFinancialProduct(string guid)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@guid";
            parms[0].Value = guid;
            


            return DatabaseExcetue.ReturnDataTable("SELECT * FROM Nec_LiCaiJiJin WHERE ProductId=@guid", parms);
        }

        public DataTable GetShopProductEdit_two(string guid, int shop_category_id)
        {
            List<DbParameter> parms = new List<DbParameter>();

            string andSql = string.Format(" in ({0})", DatabaseExcetue.GetGuidsSql(guid, parms));

            DbParameter parm = new SqlParameter();
            parm.ParameterName = "@shop_category_id";
            parm.Value = shop_category_id;
            parms.Add(parm);



            return DatabaseExcetue.ReturnDataTable("SELECT a.Id,Name,a.ProductNum,a.RepertoryCount,a.UnitName,a.Detail,a.Instruction,a.BrandGuid,a.BrandName,a.ProductSeriesCode,a.ProductSeriesName,a.ProductCategoryCode,a.ProductCategoryName,a.OriginalImage,a.ThumbImage,a.SmallImage,a.MultiImages,a.ClickCount,a.CollectCount,a.BuyCount,a.CommentCount,a.SaleNumber,a.MonthSale,a.Description,a.Keywords,a.AddressCode,a.AddressValue,a.MemLoginID,a.ShopName,a.IsAudit,a.IsNew,a.IsHot,a.IsPromotion,a.IsRecommend,a.IsBest,a.FeeType,a.Post_fee,a.Express_fee,a.Ems_fee,a.IsReal,a.IsSell,a.IsShopNew,a.IsShopHot,a.IsShopPromotion,a.IsShopRecommend,a.IsShopGood,a.FeeTemplateID,a.FeeTemplateName,a.MinusFee,a.Wap_desc,a.Wap_detail_url,a.ModifyUser,a.ModifyTime,a.CreateTime,a.CreateUser,a.SaleTime,a.DeSaleTime,a.StartTime,a.EndTime,a.ProductState,a.Score,a.Ctype,a.IsDeleted,a.IsSaled,a.OrderID,a.SetStock,a.PulishType,a.RepertoryAlertCount,p.AgentId,p.ShopPrice,p.MarketPrice,p.Score_dv,p.Score_bv,p.Score_pv_a,p.Score_pv_b,p.Score_hv,p.Score_max_hv,p.Score_sv,p.Score_cv,p.Score_rv,p.Score_cv,p.Score_max_hv FROM ShopNum1_Shop_Product as a left join ShopNum1_Shop_ProductPrice as p on p.productId=a.id WHERE a.Guid " + andSql + " and p.shop_category_id=@shop_category_id", parms.ToArray());
        }
        

        public DataTable GetSpellInfo(string shopid, string guid)
        {
            var paraName = new string[2];
            var paraValue = new string[2];
            paraName[0] = "@shopid";
            paraValue[0] = shopid;
            paraName[1] = "@guid";
            paraValue[1] = guid;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetSpellInfo", paraName, paraValue);
        }

        public DataTable GetSpellInfoMeta(string shopid, string guid)
        {
            var paraName = new string[2];
            var paraValue = new string[2];
            paraName[0] = "@shopid";
            paraValue[0] = shopid;
            paraName[1] = "@guid";
            paraValue[1] = guid;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetSpellInfoMeta", paraName, paraValue);
        }

        public DataTable GetSpellList(string showcount, string ordertype, string shopid)
        {
            var paraName = new string[3];
            var paraValue = new string[3];
            paraName[0] = "@showcount";
            paraValue[0] = showcount;
            paraName[1] = "@ordertype";
            paraValue[1] = ordertype;
            paraName[2] = "@shopid";
            paraValue[2] = shopid;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetSpellList", paraName, paraValue);
        }

        public DataTable GetSpellListFor(string shopid, string showcount, string ischeck)
        {
            string str = string.Empty;
            str = " select TOP " + showcount +
                  "  b.ID,A.OriginalImage,b.groupprice shopprice,A.marketprice,A.name,A.guid,B.groupcount,B.memloginid from ShopNum1_Shop_Product A inner join shopnum1_group_product B on B.productguid=A.guid where  B.aid in(select id from ShopNum1_Product_Activity where 1=1 And B.memloginid='" +
                  shopid + "'";
            if (ischeck == "0")
            {
                str = str + "  AND endtime>getdate() ";
            }
            else
            {
                str = str + "  AND endtime<getdate() ";
            }
            return DatabaseExcetue.ReturnDataTable((str + ")"));
        }

        public DataTable GetTemplateFee(string strGuId)
        {
            return
                DatabaseExcetue.ReturnDataTable(
                    "SELECT FeeTemplateID,FeeType,isreal,Post_fee,Express_fee,Ems_fee FROM ShopNum1_Shop_Product where GuId in (" +
                    strGuId + ")");
        }

        public DataTable SearchProductList(string memloginid, string kwyword, string pricestart, string priceend,
            string code, string sortstyle)
        {
            var paraName = new string[6];
            var paraValue = new string[6];
            paraName[0] = "@memloginid";
            paraValue[0] = memloginid;
            paraName[1] = "@kwyword";
            paraValue[1] = kwyword;
            paraName[2] = "@pricestart";
            paraValue[2] = pricestart;
            paraName[3] = "@priceend";
            paraValue[3] = priceend;
            paraName[4] = "@code";
            paraValue[4] = code;
            paraName[5] = "@sortstyle";
            paraValue[5] = sortstyle;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_SearchProductList", paraName, paraValue);
        }

        public DataSet SearchProductListNew(string memloginid, string kwyword, string pricestart, string priceend,
            string code, string ordertype, string sort, string perpagenum,
            string current_page, string isreturcount,int category)
        {
            string str = string.Empty;
            if (!string.IsNullOrEmpty(kwyword))
            {
                str = "  AND Name like '%" + kwyword + "%'";
            }
            if (!string.IsNullOrEmpty(pricestart))
            {
                str = str + " AND ShopPrice>=" + pricestart;
            }
            if (!string.IsNullOrEmpty(priceend))
            {
                str = str + " AND ShopPrice<=" + priceend;
            }
            if (!string.IsNullOrEmpty(code))
            {
                str = str + " AND ProductSeriesCode like '%" + code + "%'";
            }
            str = str + " and ShopNum1_Shop_Product.id=productId and issell=1 and issaled=1 and isaudit=1  and  IsDeleted=0 and productstate=0 and memloginId='" + memloginid +
                  "'";
            var paraName = new string[9];
            var paraValue = new string[9];
            paraName[0] = "@searchname";
            paraValue[0] = str;
            paraName[1] = "@ordertype";
            paraValue[1] = ordertype;
            paraName[2] = "@sort";
            paraValue[2] = sort;
            paraName[3] = "@perpagenum";
            paraValue[3] = perpagenum;
            paraName[4] = "@current_page";
            paraValue[4] = current_page;
            paraName[5] = "@isreturcount";
            paraValue[5] = isreturcount;
            paraName[6] = "@shopid";
            paraValue[6] = memloginid;
            paraName[7] = "@columnnames";
            paraValue[7] =
                "  Score_dv,Score_cv,shop_category_id,Guid,Name,ProductNum,ShopPrice,IsNew,IsHot,IsPromotion,OriginalImage,SaleNumber,MemLoginID,ShopName,Collectcount,CreateTime ";
            paraName[8] = "@category";
            paraValue[8] = category.ToString();
            return DatabaseExcetue.RunProcedureReturnDataSet("Pro_Shop_SearchProductListNew", paraName, paraValue);
        }

        public DataTable SearchProductShopByGuid(string productguid)
        {
            return
                DatabaseExcetue.ReturnDataTable(
                    "SELECT MemLoginID,ShopName,Name,ProductNum,MarketPrice,ShopPrice,IsReal,OriginalImage,setstock  FROM ShopNum1_Shop_Product left join ShopNum1_Shop_ProductPrice on ShopNum1_Shop_ProductPrice.productId=ShopNum1_Shop_Product.id  WHERE Guid in (" +
                    productguid + ")");
        }

        public DataTable SearchProductShopByGuid_two(string productguid, int shop_category_id)
        {
            return
                DatabaseExcetue.ReturnDataTable(
                    "SELECT MemLoginID,ShopName,ProductName_EN,Name,ProductNum,MarketPrice,ShopPrice,IsReal,OriginalImage,setstock,MyPrice  FROM ShopNum1_Shop_Product left join ShopNum1_Shop_ProductPrice on ShopNum1_Shop_ProductPrice.productId=ShopNum1_Shop_Product.id  WHERE Guid ='" +
                    productguid + "' and ShopNum1_Shop_ProductPrice.shop_category_id=" + shop_category_id);
        }

        public int UpdateClickCountByGuid(string guid)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@guid";
            paraValue[0] = guid;
            return DatabaseExcetue.RunProcedure("Pro_Shop_UpdateClickCountByGuid", paraName, paraValue);
        }

        public int UpdateProductSaled(string strIds, string isSaled)
        {
            var builder = new StringBuilder();
            builder.Append("UPDATE  ShopNum1_Shop_Product SET issell=" + isSaled + " WHERE [id] in (" + strIds + ")");
            return DatabaseExcetue.RunNonQuery(builder.ToString());
        }

        public int UpdateSaleNumberByOrderGuid(string OrderGuidguid, string strSaleNumber)
        {
            var paraName = new string[2];
            var paraValue = new string[2];
            paraName[0] = "@guid";
            paraValue[0] = OrderGuidguid;
            paraName[1] = "@salenumber";
            paraValue[1] = strSaleNumber;
            return DatabaseExcetue.RunProcedure("Pro_Shop_UpdateSaleNumberByOrderGuid", paraName, paraValue);
        }

        public int UpdateShopProduct(ShopNum1_Shop_Product shop_Product)
        {
            var paraName = new string[47];
            var paraValue = new string[47];
            paraName[0] = "@guid";
            paraValue[0] = shop_Product.Guid.ToString();
            paraName[1] = "@name";
            paraValue[1] = shop_Product.Name;
            paraName[2] = "@productnum";
            paraValue[2] = shop_Product.ProductNum;
           /* paraName[3] = "@shopprice";
            paraValue[3] = shop_Product.ShopPrice.ToString();
            paraName[4] = "@MarketPrice";*/

           /* paraValue[4] = shop_Product.MarketPrice.ToString();*/

            paraName[3] = "@ctype";
            paraValue[3] = shop_Product.Ctype.ToString();
            paraName[4] = "@Wap_desc";
            paraValue[4] = shop_Product.Wap_desc;

            paraName[5] = "@repertorycount";
            paraValue[5] = shop_Product.RepertoryCount.ToString();
            paraName[6] = "@unitname";
            paraValue[6] = shop_Product.UnitName;
            paraName[7] = "@detail";
            paraValue[7] = shop_Product.Detail;
            paraName[8] = "@instruction";
            paraValue[8] = shop_Product.Instruction;
            paraName[9] = "@productseriescode";
            paraValue[9] = shop_Product.ProductSeriesCode;
            paraName[10] = "@productseriesname";
            paraValue[10] = shop_Product.ProductSeriesName;
            paraName[11] = "@BrandGuid";
            paraValue[11] = shop_Product.BrandGuid.ToString();
            paraName[12] = "@BrandName";
            paraValue[12] = shop_Product.BrandName;
            paraName[13] = "@originalimage";
            paraValue[13] = shop_Product.OriginalImage;
            paraName[14] = "@thumbimage";
            paraValue[14] = shop_Product.ThumbImage;
            paraName[15] = "@SmallImage";
            paraValue[15] = shop_Product.SmallImage;
            paraName[0x10] = "@MultiImages";
            paraValue[0x10] = shop_Product.MultiImages;
            paraName[0x11] = "@description";
            paraValue[0x11] = shop_Product.Description;
            paraName[0x12] = "@keywords";
            paraValue[0x12] = shop_Product.Keywords;
            paraName[0x13] = "@AddressCode";
            paraValue[0x13] = shop_Product.AddressCode;
            paraName[20] = "@AddressValue";
            paraValue[20] = shop_Product.AddressValue;
            paraName[0x15] = "@IsAudit";
            paraValue[0x15] = shop_Product.IsAudit.ToString();
            paraName[0x16] = "@FeeType";
            paraValue[0x16] = shop_Product.FeeType.ToString();
            paraName[0x17] = "@Post_fee";
            paraValue[0x17] = shop_Product.Post_fee.ToString();
            paraName[0x18] = "@Express_fee";
            paraValue[0x18] = shop_Product.Express_fee.ToString();
            paraName[0x19] = "@Ems_fee";
            paraValue[0x19] = shop_Product.Ems_fee.ToString();
            paraName[0x1a] = "@FeeTemplateID";
            paraValue[0x1a] = shop_Product.FeeTemplateID.ToString();
            paraName[0x1b] = "@FeeTemplateName";
            paraValue[0x1b] = shop_Product.FeeTemplateName;
            paraName[0x1c] = "@MinusFee";
            paraValue[0x1c] = shop_Product.MinusFee.ToString();
            paraName[0x1d] = "@IsReal";
            paraValue[0x1d] = shop_Product.IsReal.ToString();
            paraName[30] = "@IsSell";
            paraValue[30] = shop_Product.IsSell.ToString();
            paraName[0x1f] = "@CreateUser";
            paraValue[0x1f] = shop_Product.CreateUser;
            paraName[0x20] = "@saletime";
            paraValue[0x20] = shop_Product.SaleTime.ToString();
            paraName[0x21] = "@DeSaleTime";
            paraValue[0x21] = shop_Product.DeSaleTime.ToString();
            paraName[0x22] = "@RepertoryAlertCount";
            paraValue[0x22] = shop_Product.RepertoryAlertCount.ToString();
            paraName[0x23] = "@StartTime";
            paraValue[0x23] = shop_Product.StartTime.ToString();
            paraName[0x24] = "@EndTime";
            paraValue[0x24] = shop_Product.EndTime.ToString();
            paraName[0x25] = "@ProductState";
            paraValue[0x25] = shop_Product.ProductState.ToString();
            paraName[0x26] = "@ModifyTime";
            paraValue[0x26] = shop_Product.ModifyTime.ToString();
            paraName[0x27] = "@IsShopNew";
            paraValue[0x27] = shop_Product.IsShopNew.ToString();
            paraName[40] = "@IsShopHot";
            paraValue[40] = shop_Product.IsShopHot.ToString();
            paraName[0x29] = "@IsShopPromotion";
            paraValue[0x29] = shop_Product.IsShopPromotion.ToString();
            paraName[0x2a] = "@IsShopRecommend";
            paraValue[0x2a] = shop_Product.IsShopRecommend.ToString();
            paraName[0x2b] = "@SetStock";
            paraValue[0x2b] = shop_Product.SetStock.ToString();
            paraName[0x2c] = "@pulishtype";
            paraValue[0x2c] = shop_Product.PulishType.ToString();
            paraName[0x2d] = "@ProductCategoryCode";
            paraValue[0x2d] = shop_Product.ProductCategoryCode;
            paraName[0x2e] = "@ProductCategoryName";
            paraValue[0x2e] = shop_Product.ProductCategoryName;
         
            return DatabaseExcetue.RunProcedure("Pro_Shop_UpdateShopProduct", paraName, paraValue);
        }

        public int ChangeCarByCook(string oldUser, string newUser)
        {
            return
                DatabaseExcetue.RunNonQuery("     UPDATE  ShopNum1_Shop_Cart  SET  MemLoginId='" + newUser +
                                            "'   WHERE  MemLoginId='" + oldUser + "'   and  ShopID <>'" + newUser +
                                            "'    ");
        }

        public DataTable GetProductList(string strPageSize, string strCurrentPage, string strCondition,string strResultNum)
        {
            var paraName = new string[8];
            var paraValue = new string[8];
            paraName[0] = "@pagesize";
            paraValue[0] = strPageSize;
            paraName[1] = "@currentpage";
            paraValue[1] = strCurrentPage;
            paraName[2] = "@columns";
            paraValue[2] =
                "memloginid,productseriesname,RepertoryAlertCount,guid,ShopNum1_Shop_ProductPrice.shop_category_id,name,productnum,shopprice,repertorycount,issell,isshopnew,isshophot,isshoppromotion,isshoprecommend,ModifyTime,productcategoryname,smallimage,originalimage,isaudit,ShopNum1_Shop_Product.id,productcategorycode,ctype,salenumber,(select top 1 id from ShopNum1_SpecProudctDetails where productguid=shopnum1_shop_product.guid And specid!=0)as vd,(select top 1 shopid from shopnum1_shopinfo where memloginid=shopnum1_shop_product.memloginid)shopid,Productstate,(select top 1 category_name from ShopNum1_Shop_CustomerCategory where id=shop_category_id)category_name";
            paraName[3] = "@tablename";
            paraValue[3] = "ShopNum1_Shop_Product";
            paraName[4] = "@condition";
            paraValue[4] = strCondition;
            paraName[5] = "@ordercolumn";
            paraValue[5] = "modifytime";
            paraName[6] = "@sortvalue";
            paraValue[6] = "desc";
            paraName[7] = "@resultnum";
            paraValue[7] = strResultNum;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_CommonPager", paraName, paraValue);
        }


        public DataTable GetProductList_two(string strPageSize, string strCurrentPage, string strCondition, string strResultNum)
        {
            var paraName = new string[8];
            var paraValue = new string[8];
            paraName[0] = "@pagesize";
            paraValue[0] = strPageSize;
            paraName[1] = "@currentpage";
            paraValue[1] = strCurrentPage;
            paraName[2] = "@columns";
            paraValue[2] =
                "memloginid,productseriesname,RepertoryAlertCount,guid,ShopNum1_Shop_ProductPrice.shop_category_id,name,productnum,shopprice,repertorycount,issell,isshopnew,isshophot,isshoppromotion,isshoprecommend,ModifyTime,productcategoryname,smallimage,originalimage,isaudit,ShopNum1_Shop_Product.id,productcategorycode,ctype,salenumber,(select top 1 id from ShopNum1_SpecProudctDetails where productguid=shopnum1_shop_product.guid And specid!=0)as vd,(select top 1 shopid from shopnum1_shopinfo where memloginid=shopnum1_shop_product.memloginid)shopid,Productstate,(select top 1 category_name from ShopNum1_Shop_CustomerCategory where id=shop_category_id)category_name";
            paraName[3] = "@tablename";
            paraValue[3] = "ShopNum1_Shop_ProductPrice as d  left join ShopNum1_Shop_Product as c on c.id=d.productId";
            paraName[4] = "@condition";
            paraValue[4] = strCondition;
            paraName[5] = "@ordercolumn";
            paraValue[5] = "modifytime";
            paraName[6] = "@sortvalue";
            paraValue[6] = "desc";
            paraName[7] = "@resultnum";
            paraValue[7] = strResultNum;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_CommonPager", paraName, paraValue);
        }

        public DataTable GetQgProduct(int start, int int_0)
        {
            object obj2 = string.Empty +
                          "   SELECT * FROM (select Guid,Name,ShopPrice,OriginalImage,MemLoginID, ROW_NUMBER()     " +
                          "   over(order by CreateTime  DESC) as rows from ShopNum1_Shop_Product WHERE ProductState=1    ";
            return
                DatabaseExcetue.ReturnDataTable(
                    string.Concat(new[] {obj2, "   ) AS B WHERE  B.rows>=", start, " AND B.rows<=", int_0, "    "}));
        }


        public DataTable SearchProductPrice(string productid, int shop_category_id)
        {
            var paraName = new string[2];
            var paraValue = new string[2];

            paraName[0] = "@guid";
            paraValue[0] = productid.ToString();

            paraName[1]= "@shop_category_id";
            paraValue[1] = shop_category_id.ToString();

            return  DatabaseExcetue.ReturnDataTable(
                    "SELECT r.* FROM ShopNum1_Shop_ProductPrice as r left join ShopNum1_Shop_Product as p on p.Id=r.productId WHERE [guid]=@guid AND r.shop_category_id=@shop_category_id", paraName, paraValue);
        }








        public int SearchProductID(string productid)
        {
            var paraName = new string[1];
            var paraValue = new string[1];

            paraName[0] = "@productid";
            paraValue[0] = productid;
            return
                DatabaseExcetue.RunNonQuery(
                    "SELECT Id  FROM ShopNum1_Shop_Product WHERE Guid =@productid",paraName,paraValue);
        }
    }
}