using System.Data;
using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1MultiEntity;
using System.Data.Common;

namespace ShopNum1.BusinessLogic
{
    public class ShopNum1_Image_Action : IShopNum1_Image_Action
    {
        public int Add(ShopNum1_Image shopnum1_image, string imageCategoryID)
        {
            return DatabaseExcetue.RunNonQuery(string.Concat(new object[]
            {
                "insert ShopNum1_Image(  Guid, Name, ImageType, ImagePath, Description, UseTimes, CreateUser, CreateTime, ModifyUser, ModifyTime, IsDeleted, ImageCategoryID, IsDownload ) VALUES (  '"
                , shopnum1_image.Guid, "',  '", Operator.FilterString(shopnum1_image.Name), "',  '",
                shopnum1_image.ImageType, "',  '", shopnum1_image.ImagePath, "',  '",
                Operator.FilterString(shopnum1_image.Description), "',  ", shopnum1_image.UseTimes, ",  '",
                shopnum1_image.CreateUser, "',   '", shopnum1_image.CreateTime,
                "',   '", shopnum1_image.ModifyUser, "',   '", shopnum1_image.ModifyTime, "',   ",
                shopnum1_image.IsDeleted, ", ", imageCategoryID, ", ", 0, " )"
            }));
        }

        public int Delete(string guids)
        {
                DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@guid";
            parms[0].Value = guids.Replace("'","");
            return DatabaseExcetue.RunNonQuery("DELETE FROM ShopNum1_Image WHERE Guid IN (@guid)",parms);
        }

        public DataTable Search(string guid)
        {
                DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@guid";
            parms[0].Value = guid.Replace("'","");
            return
                DatabaseExcetue.ReturnDataTable(
                    "SELECT Guid,ImagePath,ImageType,Name,ImageCategoryID,Description FROM ShopNum1_Image WHERE 0=0 AND Guid IN ()",parms);
        }

        public DataTable Search(string imageType, string name, int isDeleted, string imageCategoryID)
        {
            string str = string.Empty;
            str =
                "SELECT Guid, Name, ImageType, ImagePath, Description, UseTimes, CreateUser, CreateTime,ModifyUser, ModifyTime, IsDeleted FROM ShopNum1_Image WHERE 0=0";
            if (Operator.FormatToEmpty(name) != string.Empty)
            {
                str = str + " AND Name Like '%" + Operator.FilterString(name) + "%'";
            }
            if ((Operator.FormatToEmpty(imageType) != string.Empty) && (imageType != "-1"))
            {
                str = str + " AND ImageType='" + imageType + "' ";
            }
            if ((isDeleted == 0) || (isDeleted == 1))
            {
                str = string.Concat(new object[] {str, " AND IsDeleted=", isDeleted, " "});
            }
            if (imageCategoryID != "0")
            {
                str = str + " AND ImageCategoryID=" + imageCategoryID + " ";
            }
            return DatabaseExcetue.ReturnDataTable(str + " ORDER BY CreateTime DESC");
        }

        public DataTable SearchImageByType(string imageType, string name, int isDeleted, string imageCategoryID,
            string pagesize, string current_page, string isReturCount)
        {
            string str = "";
            if (Operator.FormatToEmpty(name) != string.Empty)
            {
                str = str + " AND Name Like '%" + Operator.FilterString(name) + "%'";
            }
            if ((Operator.FormatToEmpty(imageType) != string.Empty) && (imageType != "-1"))
            {
                str = str + " AND ImageType='" + imageType + "' ";
            }
            if ((isDeleted == 0) || (isDeleted == 1))
            {
                str = string.Concat(new object[] {str, " AND IsDeleted=", isDeleted, " "});
            }
            if (imageCategoryID != "0")
            {
                str = str + " AND ImageCategoryID=" + imageCategoryID + " ";
            }
            var paraName = new string[5];
            var paraValue = new string[5];
            paraName[0] = "@perPageNum";
            paraValue[0] = pagesize;
            paraName[1] = "@current_page";
            paraValue[1] = current_page;
            paraName[2] = "@ColumnNames";
            paraValue[2] = " Guid, Name, ImageType, ImagePath, Description, CreateTime,IsDeleted";
            paraName[3] = "@searchName";
            paraValue[3] = str;
            paraName[4] = "@isReturCount";
            paraValue[4] = isReturCount;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_SearchImageByType", paraName, paraValue);
        }

        public int Update(ShopNum1_Image shopnum1_image)
        {
            return DatabaseExcetue.RunNonQuery(string.Concat(new object[]
            {
                "UPDATE ShopNum1_Image  SET  [Name] = '", shopnum1_image.Name, "' ,[ImageType] = '",
                shopnum1_image.ImageType, "' ,[ImagePath] = '", shopnum1_image.ImagePath, "' ,[Description] ='",
                shopnum1_image.Description, "' ,[ModifyUser] = '", shopnum1_image.ModifyUser, "' ,[ModifyTime] = '",
                shopnum1_image.ModifyTime, "' ,[ImageCategoryID] = '", shopnum1_image.ImageCategoryID,
                "' WHERE guid='", shopnum1_image.Guid,
                "'"
            }));
        }

        public int UpdateName(string strGuid, string strNewName)
        {
                DbParameter[] parms = DatabaseExcetue.CreateParameter(2);
            parms[0].ParameterName = "@strGuid";
            parms[0].Value = strGuid;
            parms[1].ParameterName = "@strNewName";
            parms[1].Value = strNewName;
            return
                DatabaseExcetue.RunNonQuery("UPDATE ShopNum1_Image SET Name=@strNewName WHERE Guid=@strGuid",parms);
        }
    }
}