using System.Data;
using ShopNum1.DataAccess;
using ShopNum1.Interface;

namespace ShopNum1.BusinessLogic
{
    public class ShopNum1_Coupon_Action : IShopNum1_Coupon_Action
    {
        public DataTable GetCouponTitleByAdressCode(string adresscode, string showcount)
        {
            var paraName = new string[2];
            var paraValue = new string[2];
            paraName[0] = "@adresscode";
            paraValue[0] = adresscode;
            paraName[1] = "@showcount";
            paraValue[1] = showcount;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_GetCouponTitleByAdressCode", paraName,
                paraValue);
        }

        public DataTable GetCouponTitleByBrowserCount(string showcount)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@showcount";
            paraValue[0] = showcount;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_GetCouponTitleByBrowserCount", paraName,
                paraValue);
        }

        public DataSet SearchCouponByCategory(string category, string pagesize, string current_page)
        {
            var paraName = new string[3];
            var paraValue = new string[3];
            paraName[0] = "@category";
            paraValue[0] = category;
            paraName[1] = "@pagesize";
            paraValue[1] = pagesize;
            paraName[2] = "@current_page";
            paraValue[2] = current_page;
            return DatabaseExcetue.RunProcedureReturnDataSet("Pro_ShopNum1_SearchCouponByCategory", paraName, paraValue);
        }

        public DataTable SearchCouponByType(string category, string addcode, string ordername, string sDesc,
            string pagesize, string current_page, string isReturCount)
        {
            string str = "";
            if (!(string.IsNullOrEmpty(category) || !(category != "-1")))
            {
                str = " AND A.type=" + category;
            }
            if (!(string.IsNullOrEmpty(addcode) || !(addcode != "-1")))
            {
                str = str + " AND A.AdressCode like '" + addcode + "%' ";
            }
            var paraName = new string[7];
            var paraValue = new string[7];
            paraName[0] = "@perPageNum";
            paraValue[0] = pagesize;
            paraName[1] = "@current_page";
            paraValue[1] = current_page;
            paraName[2] = "@ColumnNames";
            paraValue[2] = " A.Guid,A.CouponName,A.MemLoginID,A.BrowserCount,A.Type,A.SaleTitle,A.ImgPath,B.shopID ";
            paraName[3] = "@OrderName";
            paraValue[3] = ordername;
            paraName[4] = "@searchName";
            paraValue[4] = str;
            paraName[5] = "@sDesc";
            paraValue[5] = sDesc;
            paraName[6] = "@isReturCount";
            paraValue[6] = isReturCount;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_SearchCouponByType", paraName, paraValue);
        }
    }
}