using System.Collections.Generic;
using System.Data;
using ShopNum1MultiEntity;

namespace ShopNum1.Interface
{
    public interface IShopNum1_SpecProudctDetail_Action
    {
        int AddListSpecProudctDetail(List<ShopNum1_SpecProudctDetail> SpecDetials);
        DataTable GetDetailByDGuid(string strGuids);
        DataTable GetDetailByDGuid(string guids, string productguid);
        string GetSpecImageBySpecId(string strProductGuId, string strSpecId);
        string SearchName(string strId);

        int UpdateListSpecProudctDetail(List<ShopNum1_SpecProudctDetail> SpecDetials, string strDelSpecId,
            string strNewSpec);
    }
}