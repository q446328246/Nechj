using System.Collections.Generic;
using System.Data;
using ShopNum1MultiEntity;

namespace ShopNum1.ShopInterface
{
    public interface IShop_Image_Action
    {
        int DeleteSelectImg(List<ShopNum1_Shop_Image> shopImg);
        int DeleteShopImg(string strID);
        DataTable dt_Album_Page(string PageSize, string currentpage, string condition, string resultnum);
        int Insert(ShopNum1_Shop_Image shopNum1_Shop_Image);
        DataSet MangeShopImg(string pagesize, string currentpage, string condition, string resultnum);

        DataTable Select_List(int PageSize, int CurrentPage, int ResultNum, string strName, string strOrderType,
            string strTypeId, string strCreateUser);

        DataTable Shop_ImgUser();
        int UpdateImgName(string strName, string strId, string strMemloginId);
    }
}