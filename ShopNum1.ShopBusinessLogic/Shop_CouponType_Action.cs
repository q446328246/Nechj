using System.Data;
using ShopNum1.DataAccess;
using ShopNum1.ShopInterface;
using ShopNum1MultiEntity;

namespace ShopNum1.ShopBusinessLogic
{
    public class Shop_CouponType_Action : IShop_CouponType_Action
    {
        public int Add(ShopNum1_Shop_CouponType ShopNum1_Shop_CouponType)
        {
            return
                DatabaseExcetue.RunNonQuery(
                    string.Concat(new object[]
                    {
                        "INSERT INTO ShopNum1_Shop_CouponType (\tName\t,\tOrderID\t,\tIsShow\t,\tCreateUser\t,\tCreateTime\t,\tComment\t,\tIsDeleted\t) VALUES ('"
                        , ShopNum1_Shop_CouponType.Name, "', ", ShopNum1_Shop_CouponType.OrderID, " , ",
                        ShopNum1_Shop_CouponType.IsShow, " ,'", ShopNum1_Shop_CouponType.CreateUser, "','",
                        ShopNum1_Shop_CouponType.CreateTime, "','", ShopNum1_Shop_CouponType.Comment, "', ",
                        ShopNum1_Shop_CouponType.IsDeleted, " )"
                    }));
        }

        public int Delete(string ID)
        {
            try
            {
                DatabaseExcetue.RunNonQuery("DELETE FROM ShopNum1_Shop_CouponType WHERE ID IN (" + ID + ")");
                DatabaseExcetue.RunNonQuery("DELETE FROM ShopNum1_Shop_Coupon WHERE Type IN (" + ID + ")");
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        public DataTable search(int int_0, int isshow)
        {
            string str = string.Empty;
            str = "SELECT * FROM ShopNum1_Shop_CouponType WHERE 1=1 ";
            if (int_0 != -1)
            {
                str = str + " and ID=" + int_0;
            }
            if (isshow != -1)
            {
                str = str + " and IsShow=" + isshow;
            }
            return DatabaseExcetue.ReturnDataTable(str + " ORDER BY OrderID");
        }

        public int Update(ShopNum1_Shop_CouponType ShopNum1_Shop_CouponType)
        {
            return
                DatabaseExcetue.RunNonQuery(
                    string.Concat(new object[]
                    {
                        "UPDATE ShopNum1_Shop_CouponType SET Name='", ShopNum1_Shop_CouponType.Name, "', IsShow=",
                        ShopNum1_Shop_CouponType.IsShow, ", OrderID=", ShopNum1_Shop_CouponType.OrderID,
                        ", ModifyUser='", ShopNum1_Shop_CouponType.ModifyUser, "', ModifyTime='",
                        ShopNum1_Shop_CouponType.ModifyTime, "', Comment='", ShopNum1_Shop_CouponType.Comment,
                        "'  WHERE ID=", ShopNum1_Shop_CouponType.id, " "
                    }));
        }
    }
}