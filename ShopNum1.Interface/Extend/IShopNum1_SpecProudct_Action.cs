using System.Collections.Generic;
using System.Data;
using ShopNum1MultiEntity;

namespace ShopNum1.Interface
{
    public interface IShopNum1_SpecProudct_Action
    {
        int AddListSpecProducts(List<ShopNum1_SpecProudct> SpecificationProudcts);
        int DeleteSpecProduct(string strPGuID);
        DataTable dt_SpecProducts(string strPid);
        DataTable dt_SpecProducts(string strPid, string strSpecDetail);
        DataTable dt_SpecProducts(string strPid, string strCtype, string strV);
        DataTable GetSpecificationByProduct(string productGuid, string Detail);
        int UpdateListSpecProducts(List<ShopNum1_SpecProudct> SpecificationProudcts);
    }
}