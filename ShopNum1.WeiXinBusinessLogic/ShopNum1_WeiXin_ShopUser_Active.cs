using System.Data;
using ShopNum1.DataAccess;
using ShopNum1.WeiXinInterface;
using ShopNum1MultiEntity;

namespace ShopNum1.WeiXinBusinessLogic
{
    public class ShopNum1_WeiXin_ShopUser_Active : IShopNum1_WeiXin_ShopUser_Active
    {
        public int AddWeiXinHao(ShopNum1_WeiXin_ShopUser ShopUser)
        {
            string str =
                "INSERT INTO ShopNum1_WeiXin_ShopUser(TwoDimensionalPic,WeiXinName,PublicNo,ShopLoginID,CreateTime,ModifyTime";
            object obj2 = str + ")";
            return
                DatabaseExcetue.RunNonQuery(
                    string.Concat(new[]
                    {
                        obj2, "VALUES('", ShopUser.TwoDimensionalPic, "','", ShopUser.WeiXinName, "','",
                        ShopUser.PublicNo, "','", ShopUser.ShopLoginID, "','", ShopUser.CreateTime, "','",
                        ShopUser.ModifyTime, "')"
                    }));
        }

        public DataTable SelectWeiXinHao(string shoploginid)
        {
            return
                DatabaseExcetue.ReturnDataTable(("SELECT * FROM ShopNum1_WeiXin_ShopUser  WHERE ShopLoginID='" +
                                                 shoploginid + "'"));
        }

        public DataTable SelectWeiXinStore(string pagesize, string pageid, string resultnum, string condition,
            string ordercolumn, string sortvalue)
        {
            string str =
                "select A.*,B.clickcount,B.shopreputation,B.ShopCategoryId,B.addresscode,B.OrderID,\r\n(select sum(salenumber) from shopnum1_shop_product where memloginid=A.shoploginid)salenumber from ShopNum1_WeiXin_ShopUser A\r\n inner join ShopNum1_ShopInfo B ON B.memloginid=A.shoploginid ";
            var paraName = new string[8];
            var paraValue = new string[8];
            paraName[0] = "@pagesize";
            paraValue[0] = pagesize;
            paraName[1] = "@currentpage";
            paraValue[1] = pageid;
            paraName[2] = "@columns";
            paraValue[2] =
                " TwoDimensionalPic,WeiXinName,PublicNo,ShopLoginID,CreateTime,ModifyTime,clickcount,shopreputation,ShopCategoryId,addresscode ";
            paraName[3] = "@tablename";
            paraValue[3] = str;
            paraName[4] = "@condition";
            paraValue[4] = condition;
            paraName[5] = "@ordercolumn";
            paraValue[5] = ordercolumn;
            paraName[6] = "@sortvalue";
            paraValue[6] = sortvalue;
            paraName[7] = "@resultnum";
            paraValue[7] = resultnum;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_CommonPager", paraName, paraValue);
        }

        public int UpdateWeiXinHao(ShopNum1_WeiXin_ShopUser ShopUser)
        {
            object obj2 = (("UPDATE ShopNum1_WeiXin_ShopUser SET TwoDimensionalPic='" + ShopUser.TwoDimensionalPic +
                            "',") + "WeiXinName='" + ShopUser.WeiXinName + "',") + "PublicNo='" + ShopUser.PublicNo +
                          "',";
            obj2 = string.Concat(new[] {obj2, "CreateTime='", ShopUser.CreateTime, "',"});
            return
                DatabaseExcetue.RunNonQuery((string.Concat(new[] {obj2, "ModifyTime='", ShopUser.ModifyTime, "'"}) +
                                             " WHERE ShopLoginID='" + ShopUser.ShopLoginID + "'"));
        }
    }
}