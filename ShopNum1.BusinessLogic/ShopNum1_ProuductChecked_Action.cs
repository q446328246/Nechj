using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using System.Data.Common;

namespace ShopNum1.BusinessLogic
{
    public class ShopNum1_ProuductChecked_Action : IShopNum1_ProuductChecked_Action
    {
        public DataSet GetFurnitureProduct(string addresscode, string address, string productCategoryCode,
            string ordername, string soft, string startprice, string endprice,
            string productName, string brandguid, string perpagenum, string current_page,
            string isreturcount, Dictionary<string, string> Pvalue, int category)
        {
            int num = 0;
            string str = "";
            if (ordername == "-1")
            {
                ordername = "A.orderid";
            }
            if (ordername.ToLower() == "shopreputation")
            {
                ordername = "C.ShopReputation";
            }
            else
            {
                ordername = "A." + ordername;
            }
            if (productCategoryCode != "-1")
            {
                if (productCategoryCode.IndexOf(",") != -1)
                {
                    string[] strArray = productCategoryCode.Split(new[] {','});
                    for (int i = 0; i < strArray.Length; i++)
                    {
                        if (i == 0)
                        {
                            str = str + " A.ProductCategoryCode like '" + strArray[i] + "%'";
                        }
                        else
                        {
                            str = str + " or A.ProductCategoryCode LIKE '" + strArray[i] + "%'";
                        }
                    }
                }
                else
                {
                    str = " A.ProductCategoryCode like '" + Operator.FilterString(productCategoryCode) + "%'";
                }
            }
            else
            {
                str = "1=1";
            }
            if ((addresscode != "-1") && (addresscode != "000"))
            {
                str = str + " AND A.AddressCode LIKE '" + Operator.FilterString(addresscode) + "%'";
            }
            if (address != "-1")
            {
                str = str + " AND A.AddressValue LIKE '%" + Operator.FilterString(address) + "%'";
            }
            str = str + " and ShopNum1_Shop_Product.id=productId AND A.IsSaled =1 And A.isaudit=1 and A.issell=1 ";
            if (string.IsNullOrEmpty(soft))
            {
                soft = "desc";
            }
            if (startprice != string.Empty)
            {
                str = str + " And A.ShopPrice >=" + Operator.FilterString(startprice);
            }
            if (endprice != string.Empty)
            {
                str = str + " And A.ShopPrice <=" + Operator.FilterString(endprice);
            }
            if (!(!(productName != "-1") || string.IsNullOrEmpty(productName)))
            {
                str = str + " And A.Name like '%" + Operator.FilterString(productName) + "%' ";
            }
            if (brandguid != "-1")
            {
                str = str + "And A.BrandGuid='" + Operator.FilterString(brandguid) + "'";
            }
            if (Pvalue != null)
            {
                string str2 = string.Empty;
                bool flag = true;
                foreach (var pair in Pvalue)
                {
                    if (pair.Value != "0")
                    {
                        string str3;
                        num++;
                        if (flag)
                        {
                            str3 = str2;
                            str2 = str3 + " AND (( PropID=" + pair.Key + " AND PropValueID=" + pair.Value + ")";
                            flag = false;
                        }
                        else
                        {
                            str3 = str2;
                            str2 = str3 + " OR ( PropID=" + pair.Key + " AND PropValueID=" + pair.Value + ")";
                        }
                    }
                }
                if (str2 != string.Empty)
                {
                    str2 = str2 + "  )  ";
                    str = str + str2;
                }
            }
            var paraName = new string[9];
            var paraValue = new string[9];
            paraName[0] = "@perpagenum";
            paraValue[0] = perpagenum;
            paraName[1] = "@current_page";
            paraValue[1] = current_page;
            paraName[2] = "@columnnames";
            paraValue[2] =
                " shop_category_id,A.Guid,A.ShopName,A.Name,A.FeeType,A.ThumbImage,A.OriginalImage,A.MemLoginID,p.ShopPrice,A.AddressValue,A.AddressCode,A.SaleNumber ";
            paraName[3] = "@ordername";
            paraValue[3] = ordername;
            paraName[4] = "@searchname";
            paraValue[4] = str;
            paraName[5] = "@sdesc";
            paraValue[5] = soft;
            paraName[6] = "@propcount";
            paraValue[6] = num.ToString();
            paraName[7] = "@isreturcount";
            paraValue[7] = isreturcount;
            paraName[8] = "@category";
            paraValue[8] = category.ToString();
            return DatabaseExcetue.RunProcedureReturnDataSet("Pro_CommonPageProducts", paraName, paraValue);
        }

        public DataSet GetFurnitureProduct1(string addresscode, string address, string productCategoryCode,
            string ordername, string soft, string startprice, string endprice,
            string productName, string brandguid, string perpagenum, string current_page,
            string isreturcount, Dictionary<string, string> Pvalue, string strName)
        {
            int num = 0;
            string str = string.Empty;
            if (ordername == "-1")
            {
                ordername = "A.orderid";
            }
            if (ordername.ToLower() == "shopreputation")
            {
                ordername = "C.ShopReputation";
            }
            else
            {
                ordername = "A." + ordername;
            }
            if (productCategoryCode != "-1")
            {
                if (productCategoryCode.IndexOf(",") != -1)
                {
                    string[] strArray = productCategoryCode.Split(new[] {','});
                    for (int i = 0; i < strArray.Length; i++)
                    {
                        if (i == 0)
                        {
                            str = str + " A.ProductCategoryCode like '" + strArray[i] + "%'";
                        }
                        else
                        {
                            str = str + " or A.ProductCategoryCode LIKE '" + strArray[i] + "%'";
                        }
                    }
                }
                else
                {
                    str = " A.ProductCategoryCode like '" + Operator.FilterString(productCategoryCode) + "%'";
                }
            }
            else
            {
                str = "1=1";
            }
            if ((addresscode != "-1") && (addresscode != "000"))
            {
                str = str + " AND A.AddressCode LIKE '" + Operator.FilterString(addresscode) + "%'";
            }
            if (address != "-1")
            {
                str = str + " AND A.AddressValue LIKE '%" + Operator.FilterString(address) + "%'";
            }
            str = str + " AND A.IsSaled =1 And A.isaudit=1 and A.issell=1 ";
            if (string.IsNullOrEmpty(soft))
            {
                soft = "desc";
            }
            if (strName != string.Empty)
            {
                str = str + " And A.Name like  '" + Operator.FilterString(strName) + "%'";
            }
            if (startprice != string.Empty)
            {
                str = str + " And A.ShopPrice >=" + Operator.FilterString(startprice);
            }
            if (endprice != string.Empty)
            {
                str = str + " And A.ShopPrice <=" + Operator.FilterString(endprice);
            }
            if (!(!(productName != "-1") || string.IsNullOrEmpty(productName)))
            {
                str = str + " And A.Name like '%" + Operator.FilterString(productName) + "%' ";
            }
            if (brandguid != "-1")
            {
                str = str + "And A.BrandGuid='" + Operator.FilterString(brandguid) + "'";
            }
            if (Pvalue != null)
            {
                string str2 = string.Empty;
                bool flag = true;
                foreach (var pair in Pvalue)
                {
                    if (pair.Value != "0")
                    {
                        string str3;
                        num++;
                        if (flag)
                        {
                            str3 = str2;
                            str2 = str3 + " AND (( PropID=" + pair.Key + " AND PropValueID=" + pair.Value + ")";
                            flag = false;
                        }
                        else
                        {
                            str3 = str2;
                            str2 = str3 + " OR ( PropID=" + pair.Key + " AND PropValueID=" + pair.Value + ")";
                        }
                    }
                }
                if (str2 != string.Empty)
                {
                    str2 = str2 + "  )  ";
                    str = str + str2;
                }
            }
            var paraName = new string[8];
            var paraValue = new string[8];
            paraName[0] = "@perpagenum";
            paraValue[0] = perpagenum;
            paraName[1] = "@current_page";
            paraValue[1] = current_page;
            paraName[2] = "@columnnames";
            paraValue[2] =
                "A.Guid,A.ShopName,A.Name,A.FeeType,A.OriginalImage,A.MemLoginID,A.ShopPrice,A.AddressValue,A.AddressCode,C.ShopReputation,A.SaleNumber";
            paraName[3] = "@ordername";
            paraValue[3] = ordername;
            paraName[4] = "@searchname";
            paraValue[4] = str;
            paraName[5] = "@sdesc";
            paraValue[5] = soft;
            paraName[6] = "@propcount";
            paraValue[6] = num.ToString();
            paraName[7] = "@isreturcount";
            paraValue[7] = isreturcount;
            return DatabaseExcetue.RunProcedureReturnDataSet("Pro_CommonPageProducts", paraName, paraValue);
        }

        public DataSet GetFurnitureProduct2(string addresscode, string address, string productCategoryCode,
            string ordername, string soft, string startprice, string endprice,
            string productName, string brandguid, string perpagenum, string current_page,
            string isreturcount, Dictionary<string, string> Pvalue, int IsShopNew,
            int IsshopHot, int IsShopGood, int IsShopRecommend)
        {
            int num = 0;
            string str = string.Empty;
            if (ordername == "-1")
            {
                ordername = "orderid";
            }
            if (ordername.ToLower() == "shopreputation")
            {
                ordername = "ShopReputation";
            }
            if (productCategoryCode != "-1")
            {
                if (productCategoryCode.IndexOf(",") != -1)
                {
                    string[] strArray = productCategoryCode.Split(new[] {','});
                    for (int i = 0; i < strArray.Length; i++)
                    {
                        if (i == 0)
                        {
                            str = str + " And ProductCategoryCode like '" + strArray[i] + "%'";
                        }
                        else
                        {
                            str = str + " And ProductCategoryCode LIKE '" + strArray[i] + "%'";
                        }
                    }
                }
                else
                {
                    str = " And ProductCategoryCode like '" + Operator.FilterString(productCategoryCode) + "%'";
                }
            }
            if ((addresscode != "-1") && (addresscode != "000"))
            {
                str = str + " AND AddressCode LIKE '" + Operator.FilterString(addresscode) + "%'";
            }
            if (address != "-1")
            {
                str = str + " AND AddressValue LIKE '%" + Operator.FilterString(address) + "%'";
            }
            str = str + " AND IsSaled =1 And isaudit=1 and issell=1 ";
            if (string.IsNullOrEmpty(soft))
            {
                soft = "desc";
            }
            if (IsShopNew == 1)
            {
                str = str + " And IsNew =" + IsShopNew;
            }
            if (IsshopHot == 1)
            {
                str = str + " And IsHot =" + IsshopHot;
            }
            if (IsShopGood == 1)
            {
                str = str + " And IsShopGood =" + IsShopGood;
            }
            if (IsShopRecommend == 1)
            {
                str = str + " And IsRecommend =" + IsShopRecommend;
            }
            if (startprice != string.Empty)
            {
                str = str + " And ShopPrice >=" + Operator.FilterString(startprice);
            }
            if (endprice != string.Empty)
            {
                str = str + " And ShopPrice <=" + Operator.FilterString(endprice);
            }
            if (!(!(productName != "-1") || string.IsNullOrEmpty(productName)))
            {
                str = str + " And Name like '%" + Operator.FilterString(productName) + "%' ";
            }
            if (brandguid != "-1")
            {
                str = str + "And BrandGuid='" + Operator.FilterString(brandguid) + "'";
            }
            string str2 = string.Empty;
            if (Pvalue != null)
            {
                bool flag = true;
                foreach (var pair in Pvalue)
                {
                    if (pair.Value != "0")
                    {
                        string str3;
                        num++;
                        if (flag)
                        {
                            str3 = str2;
                            str2 = str3 + " AND (( PropID=" + pair.Key + " AND PropValueID=" + pair.Value + ")";
                            flag = false;
                        }
                        else
                        {
                            str3 = str2;
                            str2 = str3 + " OR ( PropID=" + pair.Key + " AND PropValueID=" + pair.Value + ")";
                        }
                    }
                }
                if (str2 != string.Empty)
                {
                    str2 = str2 + "  )  ";
                }
            }
            var paraName = new string[8];
            var paraValue = new string[8];
            paraName[0] = "@pagesize";
            paraValue[0] = perpagenum;
            paraName[1] = "@currentpage";
            paraValue[1] = current_page;
            paraName[2] = "@condition";
            paraValue[2] = str;
            paraName[3] = "@ordercolumn";
            paraValue[3] = ordername;
            paraName[4] = "@sortvalue";
            paraValue[4] = soft;
            paraName[5] = "@propcount";
            paraValue[5] = num.ToString();
            paraName[6] = "@propvalue";
            paraValue[6] = str2;
            paraName[7] = "@resultnum";
            paraValue[7] = isreturcount;
            return DatabaseExcetue.RunProcedureReturnDataSet("Pro_CommonPageProduct_V82", paraName, paraValue);
        }

        public DataTable GetOrderID(string guid)
        {
            guid = guid.Replace("'", "");
            var builder = new StringBuilder();
            builder.Append("SELECT OrderID from  ShopNum1_Shop_Product where");
            builder.Append(" guid ='" + guid + "' ");
            return DatabaseExcetue.ReturnDataTable(builder.ToString());
        }

        public DataTable GetProductByCategoryID(string code, string showcount, string MemLoginID)
        {
            var builder = new StringBuilder();
            builder.Append("SELECT TOP " + showcount);
            builder.Append("    Guid,Name,OriginalImage,ThumbImage,SmallImage,AddressCode,ShopName,CreateTime,p.MarketPrice,p.ShopPrice,ProductCategoryCode,AddressValue,MemLoginID ");
            builder.Append(" FROM ");
            builder.Append("ShopNum1_Shop_Product");
            builder.Append(" left join ShopNum1_Shop_ProductPrice as p on p.productId=ShopNum1_Shop_Product.id WHERE 0=0 AND isdeleted=0 and issell=1 and issaled=1 and isaudit=1 And productstate=0 and p.shop_category_id=2");
            if (Operator.FormatToEmpty(code) != string.Empty)
            {
                if (code.IndexOf(",") != -1)
                {
                    string[] strArray = code.Split(new[] {','});
                    for (int i = 0; i < strArray.Length; i++)
                    {
                        if (i == 0)
                        {
                            builder.Append(" AND ProductCategoryCode LIKE '" + strArray[i] + "%'");
                        }
                        else
                        {
                            builder.Append(" or ProductCategoryCode LIKE '" + strArray[i] + "%'");
                        }
                    }
                }
                else
                {
                    builder.Append(" AND MemLoginID = '" + MemLoginID + "' and ProductCategoryCode LIKE '" + code + "%'");
                }
            }
            builder.Append("  ORDER BY OrderID Desc,Modifytime desc");
            return DatabaseExcetue.ReturnDataTable(builder.ToString());
        }



        public DataTable GetProductByBTC(string state, string showcount)
        {
            var builder = new StringBuilder();
            builder.Append("SELECT TOP " + showcount);
            builder.Append("    Guid,Name,OriginalImage,ThumbImage,SmallImage,AddressCode,ShopName,CreateTime,p.MarketPrice,p.ShopPrice,ProductCategoryCode,AddressValue,MemLoginID ");
            builder.Append(" FROM ");
            builder.Append("ShopNum1_Shop_Product");
            builder.Append(" left join ShopNum1_Shop_ProductPrice as p on p.productId=ShopNum1_Shop_Product.id left join ShopNum1_BTC_Recommend as btc on btc.ProductGuidBTC=ShopNum1_Shop_Product.Guid WHERE 0=0 AND isdeleted=0 and issell=1 and issaled=1 and isaudit=1 And productstate=0 and p.shop_category_id=9 and IsDeleteBTC=0 and "+state+"=1");



            builder.Append("  ORDER BY CreateTimeBTC desc");
            return DatabaseExcetue.ReturnDataTable(builder.ToString());
        }

        public DataTable GetProductByCategoryID(string code, string showcount)
        {
            var builder = new StringBuilder();
            builder.Append("SELECT TOP " + showcount);
            builder.Append("    Guid,Name,OriginalImage,ThumbImage,SmallImage,AddressCode,ShopName,CreateTime,p.MarketPrice,p.ShopPrice,ProductCategoryCode,AddressValue,MemLoginID ");
            builder.Append(" FROM ");
            builder.Append("ShopNum1_Shop_Product");
            builder.Append(" left join ShopNum1_Shop_ProductPrice as p on p.productId=ShopNum1_Shop_Product.id WHERE 0=0 AND isdeleted=0 and issell=1 and issaled=1 and isaudit=1 And productstate=0 ");
            if (Operator.FormatToEmpty(code) != string.Empty)
            {
                if (code.IndexOf(",") != -1)
                {
                    string[] strArray = code.Split(new[] { ',' });
                    for (int i = 0; i < strArray.Length; i++)
                    {
                        if (i == 0)
                        {
                            builder.Append(" AND ProductCategoryCode LIKE '" + strArray[i] + "%'");
                        }
                        else
                        {
                            builder.Append(" or ProductCategoryCode LIKE '" + strArray[i] + "%'");
                        }
                    }
                }
                else
                {
                    builder.Append("  ProductCategoryCode LIKE '" + code + "%'");
                }
            }
            builder.Append("and  ORDER BY OrderID Desc,Modifytime desc");
            return DatabaseExcetue.ReturnDataTable(builder.ToString());
        }

        public DataTable SearchGroupProduct(string categorycode, string Sort, string SortType, string pagesize,
            string current_page)
        {
            var paraName = new string[5];
            var paraValue = new string[5];
            paraName[0] = "@categorycode";
            paraValue[0] = categorycode;
            paraName[1] = "@Sort";
            paraValue[1] = Sort;
            paraName[2] = "@SortType";
            paraValue[2] = SortType;
            paraName[3] = "@pagesize";
            paraValue[3] = pagesize;
            paraName[4] = "@current_page";
            paraValue[4] = current_page;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_SearchGroupProduct", paraName, paraValue);
        }

        public DataTable SearchProductOrder(string pagesize, string field)
        {
            var paraName = new string[2];
            var paraValue = new string[2];
            paraName[0] = "@pagesize";
            paraValue[0] = pagesize;
            paraName[1] = "@field";
            paraValue[1] = field;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_SearchProductOrder", paraName, paraValue);
        }

        public DataTable SearchRelatedProduct(string productname, string memberid, int pageindex, int pagesize,
            string isreturcount)
        {
            var paraName = new string[5];
            var paraValue = new string[5];
            paraName[0] = "@ProductName";
            paraValue[0] = productname;
            paraName[1] = "@MemberID";
            paraValue[1] = memberid;
            paraName[2] = "@pageindex";
            paraValue[2] = pageindex.ToString();
            paraName[3] = "@pagesize";
            paraValue[3] = pagesize.ToString();
            paraName[4] = "@isreturcount";
            paraValue[4] = isreturcount;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_SearchRelatedProduct", paraName, paraValue);
        }

        public DataTable SelectProductPanicBuy(string pagesize)
        {
            var paraName = new string[8];
            var paraValue = new string[8];
            paraName[0] = "@pagesize";
            paraValue[0] = pagesize;
            paraName[1] = "@currentpage";
            paraValue[1] = "1";
            paraName[2] = "@columns";
            paraValue[2] = "name,shopprice,marketprice,starttime,endtime,guid,memloginid,originalimage ";
            paraName[3] = "@tablename";
            paraValue[3] = "ShopNum1_Shop_product";
            paraName[4] = "@condition";
            paraValue[4] = " and productstate=1 and starttime<getdate() and isaudit=1 and issell=1 and issaled=1";
            paraName[5] = "@ordercolumn";
            paraValue[5] = "endtime";
            paraName[6] = "@sortvalue";
            paraValue[6] = "desc";
            paraName[7] = "@resultnum";
            paraValue[7] = "1";
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_CommonPager_two", paraName, paraValue);
        }

        public DataTable SelectProductShowLine(string pagesize, string code)
        {
            var paraName = new string[8];
            var paraValue = new string[8];
            paraName[0] = "@pagesize";
            paraValue[0] = pagesize;
            paraName[1] = "@currentpage";
            paraValue[1] = "1";
            paraName[2] = "@columns";
            paraValue[2] = " guid,memloginid,name,originalimage ";
            paraName[3] = "@tablename";
            paraValue[3] = "ShopNum1_Shop_product";
            paraName[4] = "@condition";
            paraValue[4] =
                " and isaudit=1 and issaled=1 and issell=1 and productstate=0 and productcategorycode like '" + code +
                "%'";
            paraName[5] = "@ordercolumn";
            paraValue[5] = "salenumber";
            paraName[6] = "@sortvalue";
            paraValue[6] = "desc";
            paraName[7] = "@resultnum";
            paraValue[7] = "1";
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_CommonPager_two", paraName, paraValue);
        }

        int IShopNum1_ProuductChecked_Action.Delete(string guids)
        {
            throw new NotImplementedException();
        }

        DataTable IShopNum1_ProuductChecked_Action.GetList(string categoryID)
        {
            throw new NotImplementedException();
        }

        DataTable IShopNum1_ProuductChecked_Action.GetPanceProductByCategoryCode(string categorycode, string pagesize,
            string current_page)
        {
            throw new NotImplementedException();
        }

        DataTable IShopNum1_ProuductChecked_Action.GetProductByCategoryCode(string categorycode, string pagesize,
            string current_page)
        {
            throw new NotImplementedException();
        }

        DataTable IShopNum1_ProuductChecked_Action.GetShopInfoByGuid(string guid)
        {
            throw new NotImplementedException();
        }

        DataTable IShopNum1_ProuductChecked_Action.Search(string productName, string productNum, string productCategory,
            string price1, string price2, string isSaled, string isAudit,
            string isPanicBuy, string isSpellBuy, string shopID,
            string isSell, string isShopNew, string isShopHot,
            string isShopGood, string isShopRecommend)
        {
            throw new NotImplementedException();
        }

        int IShopNum1_ProuductChecked_Action.SearchAllCount(string productName, string productNum,
            string productCategory, string price1, string price2,
            string isSaled, string isAudit, string isPanicBuy,
            string isSpellBuy, string shopID)
        {
            throw new NotImplementedException();
        }

        int IShopNum1_ProuductChecked_Action.SearchAllCountNew(string productName, string productNum,
            string productCategory, string price1, string price2,
            string isSaled, string isAudit, string isPanicBuy,
            string isSpellBuy, string MemLoginID, string shopName,
            string sName)
        {
            throw new NotImplementedException();
        }

        DataTable IShopNum1_ProuductChecked_Action.SearchNew(string productName, string productNum,
            string productCategory, string price1, string price2,
            string isSaled, string isAudit, string isPanicBuy,
            string isSpellBuy, string shopID, string shopName,
            string sName)
        {
            throw new NotImplementedException();
        }

        DataTable IShopNum1_ProuductChecked_Action.SearchPerPage(int startRowIndex, int maximumRows, string productName,
            string productNum, string productCategory,
            string price1, string price2, string isSaled,
            string isAudit, string isPanicBuy, string isSpellBuy,
            string MemLoginID)
        {
            throw new NotImplementedException();
        }

        DataTable IShopNum1_ProuductChecked_Action.SearchPerPageNew(int startRowIndex, int maximumRows,
            string productName, string productNum,
            string productCategory, string price1, string price2,
            string isSaled, string isAudit, string isPanicBuy,
            string isSpellBuy, string MemLoginID,
            string shopName, string sName, string isSell,
            string isShopNew, string isShopHot,
            string isShopGood, string IsShopRecommend)
        {
            throw new NotImplementedException();
        }

        DataTable IShopNum1_ProuductChecked_Action.SearchProductByMemLoginID(string MemLoginID, string ProductCount)
        {
            throw new NotImplementedException();
        }

        DataSet IShopNum1_ProuductChecked_Action.SearchProductList(string pageindex, string pagesize, string addresscode,
            string mainproductcategoryguid, string name,
            string startdate, string enddate, string brandguid)
        {
            throw new NotImplementedException();
        }

        DataSet IShopNum1_ProuductChecked_Action.SearchProductList(string pageindex, string pagesize, string addresscode,
            string mainproductcategoryguid, string name,
            string startdate, string enddate, string brandguid,
            string keywords, string startShopPrice,
            string endShopPrice)
        {
            throw new NotImplementedException();
        }

        int IShopNum1_ProuductChecked_Action.Update(string guids, string intState)
        {
            throw new NotImplementedException();
        }

        int IShopNum1_ProuductChecked_Action.UpdateProduct(string guids, string strName, string strValue)
        {
            throw new NotImplementedException();
        }

        public DataSet V8_2_GetFurnitureProductNew(string addresscode, string address, string productCategoryCode,
            string ordername, string soft, string startprice, string endprice,
            string productName, string brandguid, string perpagenum,
            string current_page, string isreturcount,
            Dictionary<string, string> Pvalue, string strSaleType, string category)
        {
            int num = 0;
            string str = "";
            if (ordername == "-1")
            {
                ordername = "orderid";
            }
            if (ordername.ToLower() == "shopreputation")
            {
                ordername = "ShopReputation";
            }
            if (productCategoryCode != "-1")
            {
                if (productCategoryCode.IndexOf(",") != -1)
                {
                    string[] strArray = productCategoryCode.Split(new[] {','});
                    for (int i = 0; i < strArray.Length; i++)
                    {
                        if (i == 0)
                        {
                            str = str + " And ProductCategoryCode like '" + strArray[i] + "%'";
                        }
                        else
                        {
                            str = str + " or ProductCategoryCode LIKE '" + strArray[i] + "%'";
                        }
                    }
                }
                else
                {
                    str = " And ProductCategoryCode like '" + Operator.FilterString(productCategoryCode) + "%'";
                }
            }
            if ((addresscode != "-1") && (addresscode != "000"))
            {
                str = str + " AND AddressCode LIKE '" + Operator.FilterString(addresscode) + "%'";
            }
            if (address != "-1")
            {
                str = str + " AND AddressValue LIKE '%" + Operator.FilterString(address) + "%'";
            }
            if (startprice != string.Empty)
            {
                str = str + " And ShopPrice >=" + Operator.FilterString(startprice);
            }
            if (endprice != string.Empty)
            {
                str = str + " And ShopPrice <=" + Operator.FilterString(endprice);
            }
            if (!(!(productName != "-1") || string.IsNullOrEmpty(productName)))
            {
                str = str + " And Name like '%" + Operator.FilterString(productName) + "%' ";
            }
            if (brandguid != "-1")
            {
                str = str + "And BrandGuid='" + Operator.FilterString(brandguid) + "'";
            }
            string str3 = string.Empty;
            if (Pvalue != null)
            {
                bool flag = true;
                foreach (var pair in Pvalue)
                {
                    if (pair.Value != "0")
                    {
                        string str4;
                        num++;
                        if (flag)
                        {
                            str4 = str3;
                            str3 = str4 + " AND (( PropID=" + pair.Key + " AND PropValueID=" + pair.Value + ")";
                            flag = false;
                        }
                        else
                        {
                            str4 = str3;
                            str3 = str4 + " OR ( PropID=" + pair.Key + " AND PropValueID=" + pair.Value + ")";
                        }
                    }
                }
                if (str3 != string.Empty)
                {
                    str3 = str3 + "  )  ";
                }
            }
            string str2 = strSaleType;
            switch (str2)
            {
                case null:
                    break;

                case "1":
                    str = str + " And tg!=''";
                    break;

                case "2":
                    str = str + " And zk!=''";
                    break;

                default:
                    if (!(str2 == "3"))
                    {
                        if (str2 == "4")
                        {
                            str = str + " And zh!=''";
                        }
                    }
                    else
                    {
                        str = str + " And qg=1";
                    }
                    break;
            }
            var paraName = new string[9];
            var paraValue = new string[9];
            paraName[0] = "@pagesize";
            paraValue[0] = perpagenum;
            paraName[1] = "@currentpage";
            paraValue[1] = current_page;
            paraName[2] = "@condition";
            paraValue[2] = str;
            paraName[3] = "@ordercolumn";
            paraValue[3] = ordername;
            paraName[4] = "@sortvalue";
            paraValue[4] = soft;
            paraName[5] = "@propcount";
            paraValue[5] = num.ToString();
            paraName[6] = "@propvalue";
            paraValue[6] = str3;
            paraName[7] = "@resultnum";
            paraValue[7] = isreturcount;
            paraName[8] = "@category";
            paraValue[8] = category.ToString();
            return DatabaseExcetue.RunProcedureReturnDataSet("Pro_CommonPageProduct_V82", paraName, paraValue);
        }

        public DataTable V8_2_SearchPerPageNew(string resultnum, string pagesize, string currentpage, string productName,
            string productCategory, string price1, string price2, string isSaled,
            string isAudit, string MemLoginID, string shopName, string isSell,
            string isNew, string isHot, string isShopGood, string isRecommend)
        {
            var builder = new StringBuilder();
            builder.Append("A.[Guid],");
            builder.Append("A.[Name],");
            builder.Append("A.ProductNum,");
            builder.Append("A.MemLoginID,");
            builder.Append("A.RepertoryCount,");
            builder.Append("A.IsNew,");
            builder.Append("A.IsHot,");
            builder.Append("A.IsPromotion,");
            builder.Append("A.IsShopNew,");
            builder.Append("A.IsShopHot,");
            builder.Append("A.IsShopRecommend,");
            builder.Append("A.IsRecommend,");
            builder.Append("A.IsShopGood,");
            builder.Append("A.SaleNumber,");
            builder.Append("A.CreateTime,");
            builder.Append("A.IsAudit,");
            builder.Append("p.MarketPrice,");
            builder.Append("p.Shopprice,");
            builder.Append("A.OriginalImage,");
            builder.Append("A.ProductCategoryName,");
            builder.Append("B.ShopID,");
            builder.Append("A.OrderID,");
            builder.Append("A.IsSell,");
            builder.Append("A.IsSaled,");
            builder.Append("A.ModifyTime,");
            builder.Append("B.ShopName");
            var builder2 = new StringBuilder();
            builder2.Append("  0=0 And A.productstate=0");
            if (Operator.FormatToEmpty(productName) != string.Empty)
            {
                builder2.Append(" AND A.[Name] LIKE '%" + Operator.FilterString(productName) + "%'");
            }
            if (Operator.FormatToEmpty(productCategory) != "-1")
            {
                builder2.Append(" AND A.ProductCategoryCode  LIKE '" + productCategory + "%'");
            }
            if (Operator.FormatToEmpty(price1) != string.Empty)
            {
                builder2.Append(" AND p.MarketPrice  >= " + price1);
            }
            if (Operator.FormatToEmpty(price2) != string.Empty)
            {
                builder2.Append(" AND p.MarketPrice <= " + price2);
            }
            if (Operator.FormatToEmpty(isSaled) != "-1")
            {
                builder2.Append(" AND A.IsSaled = " + isSaled);
            }
            if (Operator.FormatToEmpty(isAudit) != "-1")
            {
                if (Operator.FormatToEmpty(isAudit) == "-2")
                {
                    builder2.Append(" AND A.IsAudit IN (0,2) ");
                }
                else
                {
                    builder2.Append(" AND A.IsAudit =" + isAudit);
                }
            }
            if (Operator.FormatToEmpty(MemLoginID) != string.Empty)
            {
                builder2.Append(" AND A.MemLoginID ='" + MemLoginID + "' ");
            }
            if (Operator.FormatToEmpty(shopName) != string.Empty)
            {
                builder2.Append(" AND B.ShopName like '%" + shopName + "%' ");
            }
            if (Operator.FormatToEmpty(isSell) != "-1")
            {
                builder2.Append(" AND A.IsSell ='" + isSell + "'");
            }
            if (Operator.FormatToEmpty(isNew) != "-1")
            {
                builder2.Append(" AND A.IsNew ='" + isNew + "'");
            }
            if (Operator.FormatToEmpty(isHot) != "-1")
            {
                builder2.Append(" AND A.IsHot ='" + isHot + "'");
            }
            if (Operator.FormatToEmpty(isShopGood) != "-1")
            {
                builder2.Append(" AND A.IsShopGood ='" + isShopGood + "'");
            }
            if (Operator.FormatToEmpty(isRecommend) != "-1")
            {
                builder2.Append(" AND A.IsRecommend ='" + isRecommend + "'");
            }
            string str = "Select " + builder +
                         " From ShopNum1_Shop_Product A Inner Join ShopNum1_ShopInfo B on B.memloginId=A.memloginId left join ShopNum1_Shop_ProductPrice as p on  p.productId=a.id WHERE " +
                         builder2;
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
            paraValue[4] = "";
            paraName[5] = "@ordercolumn";
            paraValue[5] = "ModifyTime";
            paraName[6] = "@sortvalue";
            paraValue[6] = "desc";
            paraName[7] = "@resultnum";
            paraValue[7] = resultnum;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_CommonPager_two", paraName, paraValue);
        }

        public int Delete(string guids)
        {
            var builder = new StringBuilder();
            builder.Append("DELETE ");
            builder.Append("FROM ");
            builder.Append("ShopNum1_Shop_Product ");
            builder.Append("WHERE ");
            builder.Append("[Guid] IN ");
            builder.Append("(" + guids + ") ");
            return DatabaseExcetue.RunNonQuery(builder.ToString());
        }

        public DataTable GetList(string categoryID)
        {
            var builder = new StringBuilder();
            builder.Append("SELECT ");
            builder.Append("[ID],");
            builder.Append("[Name],");
            builder.Append("[code]");
            builder.Append(" FROM ");
            builder.Append("ShopNum1_ProductCategory");
            builder.Append(" WHERE FatherID=" + categoryID);
            return DatabaseExcetue.ReturnDataTable(builder.ToString());
        }

        public DataTable GetPanceProductByCategoryCode(string categorycode, string pagesize, string current_page)
        {
            var paraName = new string[3];
            var paraValue = new string[3];
            paraName[0] = "@categorycode";
            paraValue[0] = categorycode;
            paraName[1] = "@pagesize";
            paraValue[1] = pagesize;
            paraName[2] = "@current_page";
            paraValue[2] = current_page;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_GetPanceProductByCategoryCode", paraName,
                paraValue);
        }

        public DataTable GetProductByCategoryCode(string categorycode, string pagesize, string current_page)
        {
            var paraName = new string[3];
            var paraValue = new string[3];
            paraName[0] = "@categorycode";
            paraValue[0] = categorycode;
            paraName[1] = "@pagesize";
            paraValue[1] = pagesize;
            paraName[2] = "@current_page";
            paraValue[2] = current_page;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_GetProductByCategoryCode", paraName,
                paraValue);
        }

        public DataTable GetShopInfoByGuid(string guid)
        {
                DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@guid";
            parms[0].Value = guid.Replace("'","");
            string strSql = string.Empty;
            strSql = "SELECT * FROM ShopNum1_Shop_Product left join ShopNum1_Shop_ProductPrice as p on ShopNum1_Shop_Product.id=p.productId WHERE 1=1";
            if (!string.IsNullOrEmpty(guid))
            {
                strSql = strSql + " and Guid=@guid" ;
            }
            return DatabaseExcetue.ReturnDataTable(strSql,parms);
        }

        public DataSet ProductComment(string guid)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@guid";
            paraValue[0] = guid;
            return DatabaseExcetue.RunProcedureReturnDataSet("Pro_Shop_ProductComment", paraName, paraValue);
        }

        public DataTable ProductCommentCount(string guid)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@guid";
            paraValue[0] = guid;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_ProductCommentCount", paraName, paraValue);
        }

        public DataTable Search(string productName, string productNum, string productCategory, string price1,
            string price2, string isSaled, string isAudit, string ShopName, string isSpellBuy,
            string MemLoginID, string isSell, string isShopNew, string isShopHot, string isShopGood,
            string isShopRecommend)
        {
            var builder = new StringBuilder();
            builder.Append("SELECT ");
            builder.Append("A.[Guid],");
            builder.Append("A.[Name],");
            builder.Append("A.ProductNum,");
            builder.Append("A.MemLoginID,");
            builder.Append("A.RepertoryCount,");
            builder.Append("A.IsNew,");
            builder.Append("A.IsHot,");
            builder.Append("A.IsPromotion,");
            builder.Append("A.IsShopNew,");
            builder.Append("A.IsShopHot,");
            builder.Append("A.IsShopRecommend,");
            builder.Append("A.IsShopGood,");
            builder.Append("A.SaleNumber,");
            builder.Append("A.IsAudit,");
            builder.Append("p.MarketPrice,");
            builder.Append("p.Shopprice,");
            builder.Append("A.OriginalImage,");
            builder.Append("A.ProductCategoryName,");
            builder.Append("B.ShopID,");
            builder.Append("A.OrderID,");
            builder.Append("A.IsSell,");
            builder.Append("A.IsSaled,");
            builder.Append("B.ShopName");
            builder.Append(" FROM ");
            builder.Append("ShopNum1_Shop_Product AS A left join ShopNum1_ShopInfo AS B on A.MemLoginID=B.MemLoginID left join ShopNum1_Shop_ProductPrice as p on a.Id=p.productId");
            builder.Append(" WHERE 0=0");
            if (Operator.FormatToEmpty(productName) != string.Empty)
            {
                builder.Append(" AND A.[Name] LIKE '%" + Operator.FilterString(productName) + "%'");
            }
            if (Operator.FormatToEmpty(productNum) != string.Empty)
            {
                builder.Append(" AND A.ProductNum LIKE '%" + productNum + "%'");
            }
            if (Operator.FormatToEmpty(productCategory) != "-1")
            {
                builder.Append(" AND A.ProductCategoryCode  LIKE '" + productCategory + "%'");
            }
            if (Operator.FormatToEmpty(ShopName) != "")
            {
                builder.Append(" AND B.ShopName  LIKE '%" + ShopName + "%'");
            }
            if (Operator.FormatToEmpty(price1) != string.Empty)
            {
                builder.Append(" AND A.MarketPrice  >= " + price1);
            }
            if (Operator.FormatToEmpty(price2) != string.Empty)
            {
                builder.Append(" AND A.MarketPrice <= " + price2);
            }
            if (Operator.FormatToEmpty(isSaled) != "-1")
            {
                builder.Append(" AND A.IsSaled LIKE '%" + isSaled + "%'");
            }
            if (Operator.FormatToEmpty(isAudit) != "-1")
            {
                if (Operator.FormatToEmpty(isAudit) == "-2")
                {
                    builder.Append(" AND A.IsAudit IN (0,2) ");
                }
                else
                {
                    builder.Append(" AND A.IsAudit =" + isAudit);
                }
            }
            if (Operator.FormatToEmpty(MemLoginID) != string.Empty)
            {
                builder.Append(" AND B.MemLoginID ='" + MemLoginID + "' ");
            }
            if (Operator.FormatToEmpty(isSell) != "-1")
            {
                builder.Append(" AND A.IsSell =" + isSell);
            }
            if (Operator.FormatToEmpty(isShopNew) != "-1")
            {
                builder.Append(" AND A.IsShopNew =" + isShopNew);
            }
            if (Operator.FormatToEmpty(isShopHot) != "-1")
            {
                builder.Append(" AND A.IsShopHot =" + isShopHot);
            }
            if (Operator.FormatToEmpty(isShopGood) != "-1")
            {
                builder.Append(" AND A.IsShopGood =" + isShopGood);
            }
            if (Operator.FormatToEmpty(isShopRecommend) != "-1")
            {
                builder.Append(" AND A.IsShopRecommend =" + isShopRecommend);
            }
            builder.Append(" ORDER BY A.OrderID ");
            return DatabaseExcetue.ReturnDataTable(builder.ToString());
        }

        public int SearchAllCount(string productName, string productNum, string productCategory, string price1,
            string price2, string isSaled, string isAudit, string isPanicBuy, string isSpellBuy,
            string MemLoginID)
        {
            var builder = new StringBuilder();
            builder.Append(" 0=0");
            if (Operator.FormatToEmpty(productName) != string.Empty)
            {
                builder.Append(" AND [Name] LIKE '%" + Operator.FilterString(productName) + "%'");
            }
            if (Operator.FormatToEmpty(productNum) != string.Empty)
            {
                builder.Append(" AND ProductNum LIKE '%" + productNum + "%'");
            }
            if (Operator.FormatToEmpty(productCategory) != "-1")
            {
                builder.Append(" AND ProductCategoryCode  LIKE '" + productCategory + "%'");
            }
            if (Operator.FormatToEmpty(price1) != string.Empty)
            {
                builder.Append(" AND MarketPrice  >= " + price1);
            }
            if (Operator.FormatToEmpty(price2) != string.Empty)
            {
                builder.Append(" AND MarketPrice <= " + price2);
            }
            if (Operator.FormatToEmpty(isSaled) != "-1")
            {
                builder.Append(" AND IsSaled LIKE '%" + isSaled + "%'");
            }
            if (Operator.FormatToEmpty(isAudit) != "-1")
            {
                if (Operator.FormatToEmpty(isAudit) == "-2")
                {
                    builder.Append(" AND IsAudit IN (0,2) ");
                }
                else
                {
                    builder.Append(" AND IsAudit =" + isAudit);
                }
            }
            if (Operator.FormatToEmpty(isPanicBuy) != string.Empty)
            {
                builder.Append(" AND IsPanicBuy =" + isPanicBuy);
            }
            if (Operator.FormatToEmpty(isSpellBuy) != string.Empty)
            {
                builder.Append(" AND IsSpellBuy =" + isSpellBuy);
            }
            if (Operator.FormatToEmpty(MemLoginID) != string.Empty)
            {
                builder.Append(" AND MemLoginID ='" + MemLoginID + "' ");
            }
            var paraName = new string[3];
            var paraValue = new string[3];
            paraName[0] = "@tablename";
            paraValue[0] = "ShopNum1_Shop_Product";
            paraName[1] = "@searchname";
            paraValue[1] = builder.ToString();
            paraName[2] = "@isreturcount";
            paraValue[2] = (paraValue[1] == " 0=0") ? "2" : "1";
            return
                Convert.ToInt32(DatabaseExcetue.ReturnProcedureString("Pro_CommonPageGetByRowNum", paraName, paraValue));
        }

        public int SearchAllCountNew(int startRowIndex, int maximumRows, string productName, string productNum,
            string productCategory, string price1, string price2, string isSaled,
            string isAudit, string isPanicBuy, string isSpellBuy, string MemLoginID,
            string shopName, string sName)
        {
            throw new NotImplementedException();
        }

        public int SearchAllCountNew(string productName, string productNum, string productCategory, string price1,
            string price2, string isSaled, string isAudit, string isPanicBuy, string isSpellBuy,
            string MemLoginID, string shopName, string sName, string isSell, string isShopNew,
            string isShopHot, string isShopGood, string isShopRecommend)
        {
            var builder = new StringBuilder();
            builder.Append(" 0=0");
            if (Operator.FormatToEmpty(productName) != string.Empty)
            {
                builder.Append(" AND A.[Name] LIKE '%" + Operator.FilterString(productName) + "%'");
            }
            if (Operator.FormatToEmpty(productNum) != string.Empty)
            {
                builder.Append(" AND A.ProductNum LIKE '%" + productNum + "%'");
            }
            if (Operator.FormatToEmpty(productCategory) != "-1")
            {
                builder.Append(" AND A.ProductCategoryCode  LIKE '" + productCategory + "%'");
            }
            if (Operator.FormatToEmpty(price1) != string.Empty)
            {
                builder.Append(" AND A.MarketPrice  >= " + price1);
            }
            if (Operator.FormatToEmpty(price2) != string.Empty)
            {
                builder.Append(" AND A.MarketPrice <= " + price2);
            }
            if (Operator.FormatToEmpty(isSaled) != "-1")
            {
                builder.Append(" AND A.IsSaled LIKE '%" + isSaled + "%'");
            }
            if (Operator.FormatToEmpty(isAudit) != "-1")
            {
                if (Operator.FormatToEmpty(isAudit) == "-2")
                {
                    builder.Append(" AND A.IsAudit IN (0,2) ");
                }
                else
                {
                    builder.Append(" AND A.IsAudit =" + isAudit);
                }
            }
            if (Operator.FormatToEmpty(isPanicBuy) != string.Empty)
            {
                builder.Append(" AND A.IsPanicBuy =" + isPanicBuy);
            }
            if (Operator.FormatToEmpty(isSpellBuy) != string.Empty)
            {
                builder.Append(" AND A.IsSpellBuy =" + isSpellBuy);
            }
            if (Operator.FormatToEmpty(MemLoginID) != string.Empty)
            {
                builder.Append(" AND A.MemLoginID ='" + MemLoginID + "' ");
            }
            if (Operator.FormatToEmpty(shopName) != string.Empty)
            {
                builder.Append(" AND B.ShopName like'%" + shopName + "%' ");
            }
            if (Operator.FormatToEmpty(sName) != string.Empty)
            {
                builder.Append(" AND B.SName like'%" + sName + "%' ");
            }
            if (Operator.FormatToEmpty(isSell) != "-1")
            {
                builder.Append(" AND A.IsSell ='" + isSell + "'");
            }
            if (Operator.FormatToEmpty(isShopNew) != "-1")
            {
                builder.Append(" AND A.IsNew ='" + isShopNew + "'");
            }
            if (Operator.FormatToEmpty(isShopHot) != "-1")
            {
                builder.Append(" AND A.IsHot ='" + isShopHot + "'");
            }
            if (Operator.FormatToEmpty(isShopGood) != "-1")
            {
                builder.Append(" AND A.IsShopGood ='" + isShopGood + "'");
            }
            if (Operator.FormatToEmpty(isShopRecommend) != "-1")
            {
                builder.Append(" AND A.IsRecommend ='" + isShopRecommend + "'");
            }
            var paraName = new string[3];
            var paraValue = new string[3];
            paraName[0] = "@tablename";
            paraValue[0] = " ShopNum1_Shop_Product AS A left join ShopNum1_ShopInfo AS B on A.MemLoginID=B.MemLoginID";
            paraName[1] = "@searchname";
            paraValue[1] = builder.ToString();
            paraName[2] = "@isreturcount";
            paraValue[2] = (paraValue[1] == " 0=0") ? "2" : "1";
            return
                Convert.ToInt32(DatabaseExcetue.ReturnProcedureString("Pro_CommonPageGetByRowNum", paraName, paraValue));
        }

        public DataTable SearchEspecialProduct(string pagesize, string field)
        {
            var paraName = new string[2];
            var paraValue = new string[2];
            paraName[0] = "@pagesize";
            paraValue[0] = pagesize;
            paraName[1] = "@field";
            paraValue[1] = field;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_SearchEspecialProduct", paraName, paraValue);
        }

        public DataTable SearchNew(string productName, string productNum, string productCategory, string price1,
            string price2, string isSaled, string isAudit, string isPanicBuy, string isSpellBuy,
            string MemLoginID, string shopName, string sName)
        {
            var builder = new StringBuilder();
            builder.Append("SELECT ");
            builder.Append("A.[Guid],");
            builder.Append("A.[Name],");
            builder.Append("A.ProductNum,");
            builder.Append("A.MemLoginID,");
            builder.Append("A.RepertoryCount,");
            builder.Append("A.IsNew,");
            builder.Append("A.IsHot,");
            builder.Append("A.IsPromotion,");
            builder.Append("A.IsShopNew,");
            builder.Append("A.IsShopHot,");
            builder.Append("A.IsShopRecommend,");
            builder.Append("A.IsShopGood,");
            builder.Append("A.SaleNumber,");
            builder.Append("A.starttime,");
            builder.Append("A.endtime,");
            builder.Append("A.IsAudit,");
            builder.Append("A.MarketPrice,");
            builder.Append("A.Shopprice,");
            builder.Append("A.OriginalImage,");
            builder.Append("A.ProductCategoryName,");
            builder.Append("B.ShopID,");
            builder.Append("A.OrderID,");
            builder.Append("A.IsSell,");
            builder.Append("A.IsSaled,");
            builder.Append("B.ShopName");
            builder.Append(" FROM ");
            builder.Append("ShopNum1_Shop_Product AS A left join ShopNum1_ShopInfo AS B on A.MemLoginID=B.MemLoginID");
            builder.Append(" WHERE 0=0");
            if (Operator.FormatToEmpty(productName) != string.Empty)
            {
                builder.Append(" AND A.[Name] LIKE '%" + Operator.FilterString(productName) + "%'");
            }
            if (Operator.FormatToEmpty(productNum) != string.Empty)
            {
                builder.Append(" AND A.ProductNum LIKE '%" + productNum + "%'");
            }
            if (Operator.FormatToEmpty(productCategory) != "-1")
            {
                builder.Append(" AND A.ProductCategoryCode  LIKE '" + productCategory + "%'");
            }
            if (Operator.FormatToEmpty(price1) != string.Empty)
            {
                builder.Append(" AND A.MarketPrice  >= " + price1);
            }
            if (Operator.FormatToEmpty(price2) != string.Empty)
            {
                builder.Append(" AND A.MarketPrice <= " + price2);
            }
            if (Operator.FormatToEmpty(isSaled) != "-1")
            {
                builder.Append(" AND A.IsSaled LIKE '%" + isSaled + "%'");
            }
            if (Operator.FormatToEmpty(isAudit) != "-1")
            {
                if (Operator.FormatToEmpty(isAudit) == "-2")
                {
                    builder.Append(" AND A.IsAudit IN (0,2) ");
                }
                else
                {
                    builder.Append(" AND A.IsAudit =" + isAudit);
                }
            }
            builder.Append(" AND A.ProductState =1");
            if (Operator.FormatToEmpty(MemLoginID) != string.Empty)
            {
                builder.Append(" AND B.MemLoginID ='" + MemLoginID + "' ");
            }
            if (Operator.FormatToEmpty(shopName) != string.Empty)
            {
                builder.Append(" AND B.ShopName like'%" + shopName + "%' ");
            }
            if (Operator.FormatToEmpty(sName) != string.Empty)
            {
                builder.Append(" AND B.Name like'%" + sName + "%' ");
            }
            builder.Append(" ORDER BY A.OrderID ");
            return DatabaseExcetue.ReturnDataTable(builder.ToString());
        }

        public DataTable SearchPerPage(int startRowIndex, int maximumRows, string productName, string productNum,
            string productCategory, string price1, string price2, string isSaled,
            string isAudit, string isPanicBuy, string isSpellBuy, string MemLoginID)
        {
            var builder = new StringBuilder();
            builder.Append("A.[Guid],");
            builder.Append("A.[Name],");
            builder.Append("A.ProductNum,");
            builder.Append("A.MemLoginID,");
            builder.Append("A.RepertoryCount,");
            builder.Append("A.IsNew,");
            builder.Append("A.IsHot,");
            builder.Append("A.IsPromotion,");
            builder.Append("A.IsShopNew,");
            builder.Append("A.IsShopHot,");
            builder.Append("A.IsShopRecommend,");
            builder.Append("A.IsShopGood,");
            builder.Append("A.SaleNumber,");
            builder.Append("A.IsAudit,");
            builder.Append("A.MarketPrice,");
            builder.Append("A.Shopprice,");
            builder.Append("A.OriginalImage,");
            builder.Append("A.ProductCategoryName,");
            builder.Append("B.ShopID,");
            builder.Append("A.OrderID,");
            builder.Append("A.IsSell,");
            builder.Append("A.IsSaled,");
            builder.Append("B.ShopName");
            var builder2 = new StringBuilder();
            builder2.Append("  0=0");
            if (Operator.FormatToEmpty(productName) != string.Empty)
            {
                builder2.Append(" AND A.[Name] LIKE '%" + Operator.FilterString(productName) + "%'");
            }
            if (Operator.FormatToEmpty(productNum) != string.Empty)
            {
                builder2.Append(" AND A.ProductNum LIKE '%" + productNum + "%'");
            }
            if (Operator.FormatToEmpty(productCategory) != "-1")
            {
                builder2.Append(" AND A.ProductCategoryCode  LIKE '" + productCategory + "%'");
            }
            if (Operator.FormatToEmpty(price1) != string.Empty)
            {
                builder2.Append(" AND A.MarketPrice  >= " + price1);
            }
            if (Operator.FormatToEmpty(price2) != string.Empty)
            {
                builder2.Append(" AND A.MarketPrice <= " + price2);
            }
            if (Operator.FormatToEmpty(isSaled) != "-1")
            {
                builder2.Append(" AND A.IsSaled LIKE '%" + isSaled + "%'");
            }
            if (Operator.FormatToEmpty(isAudit) != "-1")
            {
                if (Operator.FormatToEmpty(isAudit) == "-2")
                {
                    builder2.Append(" AND A.IsAudit IN (0,2) ");
                }
                else
                {
                    builder2.Append(" AND A.IsAudit =" + isAudit);
                }
            }
            if (Operator.FormatToEmpty(isPanicBuy) != string.Empty)
            {
                builder2.Append(" AND A.IsPanicBuy =" + isPanicBuy);
            }
            if (Operator.FormatToEmpty(isSpellBuy) != string.Empty)
            {
                builder2.Append(" AND A.IsSpellBuy =" + isSpellBuy);
            }
            if (Operator.FormatToEmpty(MemLoginID) != string.Empty)
            {
                builder2.Append(" AND A.MemLoginID ='" + MemLoginID + "' ");
            }
            var paraName = new string[8];
            var paraValue = new string[8];
            paraName[0] = "@startnum";
            paraValue[0] = startRowIndex.ToString();
            paraName[1] = "@count";
            paraValue[1] = "10";
            paraName[2] = "@tablename";
            paraValue[2] = " ShopNum1_Shop_Product AS A left join ShopNum1_ShopInfo AS B on A.MemLoginID=B.MemLoginID";
            paraName[3] = "@columnnames";
            paraValue[3] = builder.ToString();
            paraName[4] = "@ordername";
            paraValue[4] = "A.OrderID";
            paraName[5] = "@searchname";
            paraValue[5] = builder2.ToString();
            paraName[6] = "@sdesc";
            paraValue[6] = "desc";
            paraName[7] = "@isreturcount";
            paraValue[7] = "0";
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_CommonPageGetByRowNum", paraName, paraValue);
        }

        public DataTable SearchPerPageNew(int startRowIndex, int maximumRows, string productName, string productNum,
            string productCategory, string price1, string price2, string isSaled,
            string isAudit, string isPanicBuy, string isSpellBuy, string MemLoginID,
            string shopName, string sName, string isSell, string isShopNew,
            string isShopHot, string isShopGood, string isShopRecommend)
        {
            var builder = new StringBuilder();
            builder.Append("A.[Guid],");
            builder.Append("A.[Name],");
            builder.Append("A.ProductNum,");
            builder.Append("A.MemLoginID,");
            builder.Append("A.RepertoryCount,");
            builder.Append("A.IsNew,");
            builder.Append("A.IsHot,");
            builder.Append("A.IsPromotion,");
            builder.Append("A.IsShopNew,");
            builder.Append("A.IsShopHot,");
            builder.Append("A.IsShopRecommend,");
            builder.Append("A.IsRecommend,");
            builder.Append("A.IsShopGood,");
            builder.Append("A.SaleNumber,");
            builder.Append("A.CreateTime,");
            builder.Append("A.IsAudit,");
            builder.Append("A.MarketPrice,");
            builder.Append("A.Shopprice,");
            builder.Append("A.OriginalImage,");
            builder.Append("A.ProductCategoryName,");
            builder.Append("B.ShopID,");
            builder.Append("A.OrderID,");
            builder.Append("A.IsSell,");
            builder.Append("A.IsSaled,");
            builder.Append("B.ShopName,");
            builder.Append("B.Name AS SName");
            var builder2 = new StringBuilder();
            builder2.Append("  0=0 And A.productstate=0");
            if (Operator.FormatToEmpty(productName) != string.Empty)
            {
                builder2.Append(" AND A.[Name] LIKE '%" + Operator.FilterString(productName) + "%'");
            }
            if (Operator.FormatToEmpty(productNum) != string.Empty)
            {
                builder2.Append(" AND A.ProductNum LIKE '%" + productNum + "%'");
            }
            if (Operator.FormatToEmpty(productCategory) != "-1")
            {
                builder2.Append(" AND A.ProductCategoryCode  LIKE '" + productCategory + "%'");
            }
            if (Operator.FormatToEmpty(price1) != string.Empty)
            {
                builder2.Append(" AND A.MarketPrice  >= " + price1);
            }
            if (Operator.FormatToEmpty(price2) != string.Empty)
            {
                builder2.Append(" AND A.MarketPrice <= " + price2);
            }
            if (Operator.FormatToEmpty(isSaled) != "-1")
            {
                builder2.Append(" AND A.IsSaled = " + isSaled);
            }
            if (Operator.FormatToEmpty(isAudit) != "-1")
            {
                if (Operator.FormatToEmpty(isAudit) == "-2")
                {
                    builder2.Append(" AND A.IsAudit IN (0,2) ");
                }
                else
                {
                    builder2.Append(" AND A.IsAudit =" + isAudit);
                }
            }
            if (Operator.FormatToEmpty(isPanicBuy) != string.Empty)
            {
                builder2.Append(" AND A.IsPanicBuy =" + isPanicBuy);
            }
            if (Operator.FormatToEmpty(isSpellBuy) != string.Empty)
            {
                builder2.Append(" AND A.IsSpellBuy =" + isSpellBuy);
            }
            if (Operator.FormatToEmpty(MemLoginID) != string.Empty)
            {
                builder2.Append(" AND A.MemLoginID ='" + MemLoginID + "' ");
            }
            if (Operator.FormatToEmpty(shopName) != string.Empty)
            {
                builder2.Append(" AND B.ShopName like '%" + shopName + "%' ");
            }
            if (Operator.FormatToEmpty(sName) != string.Empty)
            {
                builder2.Append(" AND B.SName like '%" + sName + "%' ");
            }
            if (Operator.FormatToEmpty(isSell) != "-1")
            {
                builder2.Append(" AND A.IsSell ='" + isSell + "'");
            }
            if (Operator.FormatToEmpty(isShopNew) != "-1")
            {
                builder2.Append(" AND A.IsNew ='" + isShopNew + "'");
            }
            if (Operator.FormatToEmpty(isShopHot) != "-1")
            {
                builder2.Append(" AND A.IsHot ='" + isShopHot + "'");
            }
            if (Operator.FormatToEmpty(isShopGood) != "-1")
            {
                builder2.Append(" AND A.IsShopGood ='" + isShopGood + "'");
            }
            if (Operator.FormatToEmpty(isShopRecommend) != "-1")
            {
                builder2.Append(" AND A.IsRecommend ='" + isShopRecommend + "'");
            }
            var paraName = new string[8];
            var paraValue = new string[8];
            paraName[0] = "@startnum";
            paraValue[0] = startRowIndex.ToString();
            paraName[1] = "@count";
            paraValue[1] = maximumRows.ToString();
            paraName[2] = "@tablename";
            paraValue[2] = " ShopNum1_Shop_Product AS A left join ShopNum1_ShopInfo AS B on A.MemLoginID=B.MemLoginID";
            paraName[3] = "@columnnames";
            paraValue[3] = builder.ToString();
            paraName[4] = "@ordername";
            paraValue[4] = "A.OrderID";
            paraName[5] = "@searchname";
            paraValue[5] = builder2.ToString();
            paraName[6] = "@sdesc";
            paraValue[6] = "desc";
            paraName[7] = "@isreturcount";
            paraValue[7] = "0";
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_CommonPageGetByRowNum", paraName, paraValue);
        }

        public DataTable SearchProductByMemLoginID(string MemLoginID, string ProductCount)
        {
            var builder = new StringBuilder();
            builder.Append("select top " + ProductCount + " ");
            builder.Append("[Name], ");
            builder.Append("[Guid], ");
            builder.Append("[MemLoginID] ");
            builder.Append("From ShopNum1_Shop_Product");
            builder.Append(" WHERE ");
            builder.Append("MemLoginID ='" + MemLoginID + "'  AND IsAudit=1 AND IsDeleted = 0");
            builder.Append("Order By ModifyTime Desc");
            return DatabaseExcetue.ReturnDataTable(builder.ToString());
        }

        public DataSet SearchProductList(string pageindex, string pagesize, string addresscode,
            string mainproductcategoryguid, string name, string startdate, string enddate,
            string brandguid)
        {
            var paraName = new string[8];
            var paraValue = new string[8];
            paraName[0] = "@pageindex";
            paraValue[0] = pageindex;
            paraName[1] = "@pagesize";
            paraValue[1] = pagesize;
            paraName[2] = "@addresscode";
            paraValue[2] = addresscode;
            paraName[3] = "@mainproductcategoryguid";
            paraValue[3] = mainproductcategoryguid;
            paraName[4] = "@name";
            paraValue[4] = name;
            paraName[5] = "@startdate";
            paraValue[5] = startdate;
            paraName[6] = "@enddate";
            paraValue[6] = enddate;
            paraName[7] = "@brandguid";
            paraValue[7] = brandguid;
            return DatabaseExcetue.RunProcedureReturnDataSet("Pro_ShopNum1_SearchProductList", paraName, paraValue);
        }

        public DataSet SearchProductList(string pageindex, string pagesize, string addresscode,
            string mainproductcategoryguid, string name, string startdate, string enddate,
            string brandguid, string keywords, string startshopprice, string endshopprice)
        {
            var paraName = new string[11];
            var paraValue = new string[11];
            paraName[0] = "@pageindex";
            paraValue[0] = pageindex;
            paraName[1] = "@pagesize";
            paraValue[1] = pagesize;
            paraName[2] = "@addresscode";
            paraValue[2] = addresscode;
            paraName[3] = "@mainproductcategoryguid";
            paraValue[3] = mainproductcategoryguid;
            paraName[4] = "@name";
            paraValue[4] = name;
            paraName[5] = "@startdate";
            paraValue[5] = startdate;
            paraName[6] = "@enddate";
            paraValue[6] = enddate;
            paraName[7] = "@brandguid";
            paraValue[7] = brandguid;
            paraName[8] = "@keywords";
            paraValue[8] = keywords;
            paraName[9] = "@startshopprice";
            paraValue[9] = startshopprice;
            paraName[10] = "@endshopprice";
            paraValue[10] = endshopprice;
            return DatabaseExcetue.RunProcedureReturnDataSet("Pro_ShopNum1_SearchProductList2", paraName, paraValue);
        }

        public int Update(string guids, string intState)
        {
            var builder = new StringBuilder();
            builder.Append("UPDATE ");
            builder.Append("ShopNum1_Shop_Product");
            builder.Append(" SET ");
            builder.Append("IsAudit = " + intState);
            builder.Append(" WHERE ");
            builder.Append("[Guid] in (" + guids + ")");
            return DatabaseExcetue.RunNonQuery(builder.ToString());
        }

        public int UpdateAgent(string guids, string agentId)
        {
            var builder = new StringBuilder();
            builder.Append("UPDATE ");
            builder.Append("ShopNum1_Shop_Product");
            builder.Append(" SET ");
            builder.Append("agentId = " + agentId);
            builder.Append(" WHERE ");
            builder.Append("[Guid] in (" + guids + ")");
            return DatabaseExcetue.RunNonQuery(builder.ToString());
        }

        public int UpdateProduct(string guids, string strName, string strValue)
        {
                DbParameter[] parms = DatabaseExcetue.CreateParameter(2);
            parms[0].ParameterName = "@guids";
            parms[0].Value = guids.Replace("'","");
            parms[1].ParameterName = "@strValue";
            parms[1].Value = strValue;
            return
                DatabaseExcetue.RunNonQuery("UPDATE ShopNum1_Shop_Product SET " + strName + "=@strValue WHERE Guid IN (@guids)",parms);
        }
    }
}