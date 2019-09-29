using System.Data;
using ShopNum1.DataAccess;
using ShopNum1.ShopInterface;
using ShopNum1MultiEntity;

namespace ShopNum1.ShopBusinessLogic
{
    public class Shop_Photo_Action : IShop_Photo_Action
    {
        public int AddPhoto(ShopNum1_Shop_Photo photo)
        {
            var paraName = new string[4];
            var paraValue = new string[4];
            paraName[0] = "@name";
            paraValue[0] = photo.Name;
            paraName[1] = "@photopath";
            paraValue[1] = photo.PhotoPath;
            paraName[2] = "@remark";
            paraValue[2] = photo.AlbumsGuid;
            paraName[3] = "@albumsguid";
            paraValue[3] = photo.AlbumsGuid;
            return DatabaseExcetue.RunProcedure("Pro_Shop_AddPhoto", paraName, paraValue);
        }

        public int DeletePhoto(string guid)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@guid";
            paraValue[0] = guid;
            return DatabaseExcetue.RunProcedure("Pro_Shop_DeletePhoto", paraName, paraValue);
        }

        public DataTable EditPhoto(string guid)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@guid";
            paraValue[0] = guid;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_EditPhoto", paraName, paraValue);
        }

        public DataTable SearchPhotoList(string albumsguid, string showcount)
        {
            var paraName = new string[2];
            var paraValue = new string[2];
            paraName[0] = "@albumsguid";
            paraValue[0] = albumsguid;
            paraName[1] = "@showcount";
            paraValue[1] = showcount;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_SearchPhotoList", paraName, paraValue);
        }

        public int UpdatePhoto(ShopNum1_Shop_Photo photo)
        {
            var paraName = new string[3];
            var paraValue = new string[3];
            paraName[0] = "@guid";
            paraValue[0] = photo.Guid.ToString();
            paraName[1] = "@name";
            paraValue[1] = photo.Name;
            paraName[2] = "@photopath";
            paraValue[2] = photo.PhotoPath;
            return DatabaseExcetue.RunProcedure("Pro_Shop_UpdatePhoto", paraName, paraValue);
        }
    }
}