using System.Data;
using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1MultiEntity;

namespace ShopNum1.BusinessLogic
{
    public class ShopNum1_CategoryAdID_Action : IShopNum1_CategoryAdID_Action
    {
        public int Add(ShopNum1_CategoryAdID shopNum1_CategoryAdID)
        {
            return
                DatabaseExcetue.RunNonQuery(
                    "insert ShopNum1_CategoryAdID( CategoryType,CategoryAdName,CategoryAdIntroduce,Width,Height,CategoryAdPic,CategoryAdflow,visitPeople,CategoryAdDefalutPic,CategoryAdDefalutLike,IsShow ) VALUES (  '" +
                    shopNum1_CategoryAdID.CategoryType + "',  '" +
                    Operator.FilterString(shopNum1_CategoryAdID.CategoryAdName) + "',  '" +
                    Operator.FilterString(shopNum1_CategoryAdID.CategoryAdIntroduce) + "',   " +
                    Operator.FilterString(shopNum1_CategoryAdID.Width.ToString()) + ",   " +
                    Operator.FilterString(shopNum1_CategoryAdID.Height.ToString()) + ",  '" +
                    Operator.FilterString(shopNum1_CategoryAdID.CategoryAdPic) + "',   " +
                    Operator.FilterString(shopNum1_CategoryAdID.CategoryAdflow.ToString()) + ",   " +
                    Operator.FilterString(shopNum1_CategoryAdID.visitPeople.ToString()) + ",  '" +
                    Operator.FilterString(shopNum1_CategoryAdID.CategoryAdDefalutPic) + "',  '" +
                    Operator.FilterString(shopNum1_CategoryAdID.CategoryAdDefalutLike) + "',   " +
                    Operator.FilterString(shopNum1_CategoryAdID.IsShow.ToString()) + "  )");
        }

        public int Delete(string string_0)
        {
            DataTable table =
                DatabaseExcetue.ReturnDataTable(
                    "SELECT COUNT(*) FROM ShopNum1_CategoryAdPayMent WHERE CategoryAdID IN (" + string_0 + ")");
            if (((table != null) && (table.Rows.Count > 0)) && (table.Rows[0][0].ToString() != "0"))
            {
                return -2;
            }
            return DatabaseExcetue.RunNonQuery("DELETE FROM ShopNum1_CategoryAdID WHERE id IN (" + string_0 + ")");
        }

        public DataTable Search(string categoryType, string adID)
        {
            string strSql = string.Empty;
            strSql = "SELECT * FROM ShopNum1_CategoryAdID WHERE 0=0";
            if (Operator.FilterString(categoryType) != "-1")
            {
                strSql = strSql + " AND CategoryType='" + categoryType + "' ";
            }
            if (Operator.FilterString(adID) != "-1")
            {
                strSql = strSql + " AND ID=" + adID + " ";
            }
            return DatabaseExcetue.ReturnDataTable(strSql);
        }

        public int Updata(ShopNum1_CategoryAdID shopNum1_CategoryAdID)
        {
            return
                DatabaseExcetue.RunNonQuery("UPDATE  ShopNum1_CategoryAdID SET  CategoryType ='" +
                                            Operator.FilterString(shopNum1_CategoryAdID.CategoryType) +
                                            "', CategoryAdName ='" +
                                            Operator.FilterString(shopNum1_CategoryAdID.CategoryAdName) +
                                            "', CategoryAdIntroduce ='" +
                                            Operator.FilterString(shopNum1_CategoryAdID.CategoryAdIntroduce) +
                                            "', Width =" + shopNum1_CategoryAdID.Width + ", Height =" +
                                            shopNum1_CategoryAdID.Height + ", CategoryAdPic ='" +
                                            shopNum1_CategoryAdID.CategoryAdPic + "', CategoryAdflow =" +
                                            shopNum1_CategoryAdID.CategoryAdflow + ", visitPeople =" +
                                            shopNum1_CategoryAdID.visitPeople + ", CategoryAdDefalutPic ='" +
                                            shopNum1_CategoryAdID.CategoryAdDefalutPic + "', CategoryAdDefalutLike ='" +
                                            shopNum1_CategoryAdID.CategoryAdDefalutLike + "', IsShow =" +
                                            shopNum1_CategoryAdID.IsShow + " WHERE id=" +
                                            shopNum1_CategoryAdID.ID);
        }
    }
}