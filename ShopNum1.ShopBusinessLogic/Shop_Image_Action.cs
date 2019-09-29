using System;
using System.Collections.Generic;
using System.Data;
using ShopNum1.DataAccess;
using ShopNum1.ShopInterface;
using ShopNum1MultiEntity;

namespace ShopNum1.ShopBusinessLogic
{
    public class Shop_Image_Action : IShop_Image_Action
    {
        public int Insert(ShopNum1_Shop_Image shopNum1_Shop_Image)
        {
            string text = "Insert into ShopNum1_Shop_Image(Name,ImageType,ImagePath,";
            text += "CreateUser,ImageCategoryID,ImageSize,DisplaySize)values(";
            string text2 = text;
            text = string.Concat(new[]
            {
                text2,
                "'",
                shopNum1_Shop_Image.Name,
                "','",
                shopNum1_Shop_Image.ImageType,
                "','",
                shopNum1_Shop_Image.ImagePath,
                "'"
            });
            object obj = text;
            text = string.Concat(new[]
            {
                obj,
                ",'",
                shopNum1_Shop_Image.CreateUser,
                "','",
                shopNum1_Shop_Image.ImageCategoryID,
                "',"
            });
            obj = text;
            text = string.Concat(new[]
            {
                obj,
                "'",
                shopNum1_Shop_Image.ImageSize,
                "','",
                shopNum1_Shop_Image.DisplaySize,
                "')"
            });
            return DatabaseExcetue.RunNonQuery(text);
        }

        public DataTable Select_List(int PageSize, int CurrentPage, int ResultNum, string strName, string strOrderType,
            string strTypeId, string strCreateUser)
        {
            string text = "";
            if (strName != "")
            {
                text = text + " and name like '%" + strName + "%'";
            }
            if (strTypeId == "0")
            {
                text = text +
                       " and ImageCategoryID not in(select id from ShopNum1_Shop_ImageCategory where createuser='" +
                       strCreateUser + "')";
            }
            else
            {
                if (strTypeId != "")
                {
                    text = text + " and ImageCategoryID='" + strTypeId + "'";
                }
            }
            text = text + " and CreateUser='" + strCreateUser + "' ";
            string text2;
            string text3;
            switch (strOrderType)
            {
                case "0":
                    text2 = "id";
                    text3 = "asc";
                    goto IL_18F;
                case "1":
                    text2 = "id";
                    text3 = "desc";
                    goto IL_18F;
                case "2":
                    text2 = "ImageSize";
                    text3 = "desc";
                    goto IL_18F;
                case "3":
                    text2 = "ImageSize";
                    text3 = "asc";
                    goto IL_18F;
                case "4":
                    text2 = "name";
                    text3 = "desc";
                    goto IL_18F;
                case "5":
                    text2 = "name";
                    text3 = "asc";
                    goto IL_18F;
            }
            text2 = "id";
            text3 = "desc";
            IL_18F:
            var array = new string[8];
            var array2 = new string[8];
            array[0] = "@pagesize";
            array2[0] = PageSize.ToString();
            array[1] = "@currentpage";
            array2[1] = CurrentPage.ToString();
            array[2] = "@columns";
            array2[2] = "id,Name,createtime,ImageType,ImagePath,CreateUser,ImageCategoryID,ImageSize,DisplaySize";
            array[3] = "@tablename";
            array2[3] = "ShopNum1_Shop_Image";
            array[4] = "@condition";
            array2[4] = text;
            array[5] = "@ordercolumn";
            array2[5] = text2;
            array[6] = "@sortvalue";
            array2[6] = text3;
            array[7] = "@resultnum";
            array2[7] = ResultNum.ToString();
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_CommonPager_two", array, array2);
        }

        public DataTable dt_Album_Page(string PageSize, string currentpage, string condition, string resultnum)
        {
            var array = new string[8];
            var array2 = new string[8];
            array[0] = "@pagesize";
            array2[0] = PageSize;
            array[1] = "@currentpage";
            array2[1] = currentpage;
            array[2] = "@columns";
            array2[2] = "id,imagepath";
            array[3] = "@tablename";
            array2[3] = "ShopNum1_shop_Image";
            array[4] = "@condition";
            array2[4] = condition;
            array[5] = "@ordercolumn";
            array2[5] = "createtime";
            array[6] = "@sortvalue";
            array2[6] = "desc";
            array[7] = "@resultnum";
            array2[7] = resultnum;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_CommonPager_two", array, array2);
        }

        public DataSet MangeShopImg(string pagesize, string currentpage, string condition, string resultnum)
        {
            var array = new string[4];
            var array2 = new string[4];
            array[0] = "@pagesize";
            array2[0] = pagesize;
            array[1] = "@currentpage";
            array2[1] = currentpage;
            array[2] = "@condition";
            array2[2] = condition;
            array[3] = "@resultnum";
            array2[3] = resultnum;
            return DatabaseExcetue.RunProcedureReturnDataSet("Pro_Shop_ImagePager", array, array2);
        }

        public int DeleteShopImg(string strID)
        {
            string text = "delete from ShopNum1_Shop_Image where id in (" + strID + ")";
            return DatabaseExcetue.RunNonQuery(text);
        }

        public int DeleteSelectImg(List<ShopNum1_Shop_Image> shopImg)
        {
            var list = new List<string>();
            if (shopImg.Count > 0)
            {
                for (int i = 0; i < shopImg.Count; i++)
                {
                    list.Add("delete ShopNum1_Shop_Image where id='" + shopImg[i].Id + "'");
                }
            }
            int result;
            try
            {
                DatabaseExcetue.RunTransactionSql(list);
                result = 1;
            }
            catch (Exception)
            {
                result = 0;
            }
            return result;
        }

        public DataTable Shop_ImgUser()
        {
            string text =
                "select createuser,(select shopid from shopnum1_shopinfo where memloginid=x.createuser)shopid FROM ShopNum1_Shop_Image as x group by createuser";
            return DatabaseExcetue.ReturnDataTable(text);
        }

        public int UpdateImgName(string strName, string strId, string strMemloginId)
        {
            string text = string.Concat(new[]
            {
                "UPDATE ShopNum1_Shop_Image SET Name='",
                strName,
                "' WHERE id='",
                strId,
                "' AND CreateUser='",
                strMemloginId,
                "'"
            });
            return DatabaseExcetue.RunNonQuery(text);
        }

        public DataTable Select_List(CommonPageModel commonModel)
        {
            var array = new string[8];
            var array2 = new string[8];
            array[0] = "@pagesize";
            array2[0] = commonModel.PageSize;
            array[1] = "@currentpage";
            array2[1] = commonModel.Currentpage;
            array[2] = "@columns";
            array2[2] = " * ";
            array[3] = "@tablename";
            array2[3] = "ShopNum1_shop_Image";
            array[4] = "@condition";
            array2[4] = commonModel.Condition;
            array[5] = "@ordercolumn";
            array2[5] = "createtime";
            array[6] = "@sortvalue";
            array2[6] = "desc";
            array[7] = "@resultnum";
            array2[7] = commonModel.Resultnum;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_CommonPager_two", array, array2);
        }
    }
}