using System.Data;

namespace ShopNum1.Interface
{
    public interface IShop_ImageCategory_Action
    {
        int Delete(string string_0);
        DataTable dt_Album_Import(string strMemloginId);
        string Get_TypeName(string strId);
        int Insert(string CreateUser, string name, string description, string sort);
        DataTable Select(string strType, string strMemloginId);
        DataTable Select_AllType(string strMemloginId);
        int Update(string strid, string name, string description, string sort);
        int UpdateAlbumImg(string strTypeId, string strImgPath);
    }
}