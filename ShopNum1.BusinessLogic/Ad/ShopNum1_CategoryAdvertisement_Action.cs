using System.Data;
using System.Text;
using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1MultiEntity;
using System.Data.Common;

namespace ShopNum1.BusinessLogic
{
    public class ShopNum1_CategoryAdvertisement_Action : IShopNum1_CategoryAdvertisement_Action
    {
        public int Add(ShopNum1_CategoryAdvertisement shopNum1_CategoryAdvertisement)
        {
            var builder = new StringBuilder();
            builder.Append("insert into ShopNum1_CategoryAdvertisement(");
            builder.Append(
                "CreateTime,AdvertisementName,Width,Height,AdvertisementDPic,CategoryAdID,CategoryType,CategoryCode,CategoryName,Adlocation,AdDefaultLike,AdvertisementPrice,AdIntroduce,Advertisementflow,IsEnabled,IsShow,IsBuy");
            builder.Append(")");
            builder.Append(" values (");
            builder.Append("'" + shopNum1_CategoryAdvertisement.CreateTime + "',");
            builder.Append("'" + shopNum1_CategoryAdvertisement.AdvertisementName + "',");
            builder.Append(shopNum1_CategoryAdvertisement.Width + ",");
            builder.Append(shopNum1_CategoryAdvertisement.Height + ",");
            builder.Append("'" + shopNum1_CategoryAdvertisement.AdvertisementDPic + "',");
            builder.Append(shopNum1_CategoryAdvertisement.CategoryAdID + ",");
            builder.Append("'" + shopNum1_CategoryAdvertisement.CategoryType + "',");
            builder.Append("'" + shopNum1_CategoryAdvertisement.CategoryCode + "',");
            builder.Append("'" + shopNum1_CategoryAdvertisement.CategoryName + "',");
            builder.Append("'" + shopNum1_CategoryAdvertisement.Adlocation + "',");
            builder.Append("'" + shopNum1_CategoryAdvertisement.AdDefaultLike + "',");
            builder.Append(shopNum1_CategoryAdvertisement.AdvertisementPrice + ",");
            builder.Append("'" + shopNum1_CategoryAdvertisement.AdIntroduce + "',");
            builder.Append(shopNum1_CategoryAdvertisement.Advertisementflow + ",");
            builder.Append(shopNum1_CategoryAdvertisement.IsEnabled + ",");
            builder.Append(shopNum1_CategoryAdvertisement.IsShow + ",");
            builder.Append(shopNum1_CategoryAdvertisement.IsBuy);
            builder.Append(")");
            return DatabaseExcetue.RunNonQuery(builder.ToString());
        }

        public int Delete(string string_0)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@string_0";
            parms[0].Value = string_0;
            var builder = new StringBuilder();
            builder.Append("delete from ShopNum1_CategoryAdvertisement ");
            builder.Append(" where ID IN(@string_0)");
            return DatabaseExcetue.RunNonQuery(builder.ToString(),parms);
        }

        public string GetFatherIDByID(string string_0)
        {

            return DatabaseExcetue.ReturnString("SELECT FatherID FROM ShopNum1_ArticleCategory WHERE ID=" + string_0);
        }

        public DataTable GetPriceAndID(string categorytype, string categoryid, string categorycode)
        {
            var paraName = new string[3];
            var paraValue = new string[3];
            paraName[0] = "@categorytype";
            paraValue[0] = categorytype;
            paraName[1] = "@categoryid";
            paraValue[1] = categoryid;
            paraName[2] = "@categorycode";
            paraValue[2] = categorycode;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_GetPriceAndID", paraName, paraValue);
        }

        public DataTable Search(string string_0)
        {
            string str = string.Empty;
            str = "SELECT * FROM ShopNum1_CategoryAdvertisement WHERE 0=0";
            if (Operator.FilterString(string_0) != "-1")
            {
                str = str + " AND ID=" + string_0 + " ";
            }
            return DatabaseExcetue.ReturnDataTable(str + " ORDER BY CreateTime DESC");
        }

        public DataTable Search(string AdName, string CategoryType, string CategoryID, string AdCode, string AdIShow,
            string AdIsBuy)
        {
            var builder = new StringBuilder();
            builder.Append("select   ");
            builder.Append(
                " ID,AdvertisementName,Width,Height,AdvertisementDPic,CategoryName,AdvertisementNPic,CategoryAdID,CategoryType,CategoryCode,Adlocation,AdDefaultLike,AdvertisementLike,AdvertisementPrice,AdIntroduce,Advertisementflow,IsEnabled,IsShow,IsBuy ");
            builder.Append(" from ShopNum1_CategoryAdvertisement ");
            builder.Append(" where 0=0");
            if (Operator.FilterString(AdName) != "-1")
            {
                builder.Append(" AND AdvertisementName='" + AdName + "' ");
            }
            if (Operator.FilterString(CategoryType) != "-1")
            {
                builder.Append(" AND CategoryType='" + CategoryType + "' ");
            }
            if (Operator.FilterString(CategoryID) != "-1")
            {
                builder.Append(" AND CategoryAdID=" + CategoryID + " ");
            }
            if (Operator.FilterString(AdCode) != "-1")
            {
                builder.Append(" AND CategoryCode like '" + AdCode + "%' ");
            }
            if (Operator.FilterString(AdIShow) != "-1")
            {
                builder.Append(" AND IsShow=" + AdIShow + " ");
            }
            if (Operator.FilterString(AdIsBuy) != "-1")
            {
                builder.Append(" AND IsBuy=" + AdIsBuy + " ");
            }
            builder.Append(" ORDER BY CreateTime DESC");
            return DatabaseExcetue.ReturnDataTable(builder.ToString());
        }

        public int Updata(ShopNum1_CategoryAdvertisement shopNum1_CategoryAdvertisement)
        {
            var builder = new StringBuilder();
            builder.Append("update ShopNum1_CategoryAdvertisement set ");
            builder.Append("AdvertisementName='" + shopNum1_CategoryAdvertisement.AdvertisementName + "',");
            builder.Append("Width=" + shopNum1_CategoryAdvertisement.Width + ",");
            builder.Append("Height=" + shopNum1_CategoryAdvertisement.Height + ",");
            builder.Append("AdvertisementDPic='" + shopNum1_CategoryAdvertisement.AdvertisementDPic + "',");
            builder.Append("AdvertisementNPic='" + shopNum1_CategoryAdvertisement.AdvertisementNPic + "',");
            builder.Append("CategoryAdID=" + shopNum1_CategoryAdvertisement.CategoryAdID + ",");
            builder.Append("CategoryType='" + shopNum1_CategoryAdvertisement.CategoryType + "',");
            builder.Append("CategoryCode='" + shopNum1_CategoryAdvertisement.CategoryCode + "',");
            builder.Append("CategoryName='" + shopNum1_CategoryAdvertisement.CategoryName + "',");
            builder.Append("Adlocation='" + shopNum1_CategoryAdvertisement.Adlocation + "',");
            builder.Append("AdDefaultLike='" + shopNum1_CategoryAdvertisement.AdDefaultLike + "',");
            builder.Append("AdvertisementLike='" + shopNum1_CategoryAdvertisement.AdvertisementLike + "',");
            builder.Append("AdvertisementPrice=" + shopNum1_CategoryAdvertisement.AdvertisementPrice + ",");
            builder.Append("AdIntroduce='" + shopNum1_CategoryAdvertisement.AdIntroduce + "',");
            builder.Append("Advertisementflow=" + shopNum1_CategoryAdvertisement.Advertisementflow + ",");
            builder.Append("IsEnabled=" + shopNum1_CategoryAdvertisement.IsEnabled + ",");
            builder.Append("IsShow=" + shopNum1_CategoryAdvertisement.IsShow + ",");
            builder.Append("IsBuy=" + shopNum1_CategoryAdvertisement.IsBuy);
            builder.Append(" where ID=" + shopNum1_CategoryAdvertisement.ID);
            return DatabaseExcetue.RunNonQuery(builder.ToString());
        }
    }
}