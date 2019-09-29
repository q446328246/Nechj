using System.Collections.Generic;
using System.Data;
using ShopNum1MultiEntity;

namespace ShopNum1.Interface
{
    public interface IShopNum1_Spec_Action
    {
        int Add(ShopNum1_Spec shopNum1_Spec, List<ShopNum1_SpecValue> listSpecValue);
        int AddTbCat(string string_0, string name, string CreateTime);
        int Delete(string strguid);
        int DeleteValue(string dguid);
        int GetMaxGuid();
        DataTable GetTbCid(string string_0);
        DataTable Search();
        DataTable Search_Type_Spec(string strId);
        DataTable SearchByGuid(string guid);
        DataTable SearchName(string guids);
        DataTable SearchNameByGuid(string strGuid);
        DataTable SpecDetailsGetByTbPropValue(string tbpropvalue);
        DataTable SpecificationDetailsGetByTbPropValue(string tbpropvalue);
        int Update(ShopNum1_Spec shopNum1_Spec, List<ShopNum1_SpecValue> listSpecValue);
    }
}