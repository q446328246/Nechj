using System.Collections.Generic;
using System.Data;
using ShopNum1MultiEntity;

namespace ShopNum1.ShopInterface
{
    public interface IShop_PackAge_Action
    {
        int DeletePackAge(string strPackAgeId, string strMemloginId);
        int DeletePackAgeInfo(string strPackAgeId, string strProductGuID);
        DataSet GetPackAgeInfo(string strPackAgeId, string strMemloginID);
        DataSet GetPackAgeProduct(string strPackAgeId, string strProductGuID);
        int OpPackAge(ShopNum1_PackAge ShopNum1_PackAge, List<ShopNum1_PackAgeRalate> listPackAgeRalate);

        DataTable SelectPackAgeProduct(string pagesize, string currentpage, string condition, string resultnum,
            string sortvalue, string ordercolumn, string strColumns, string strTabName);
    }
}