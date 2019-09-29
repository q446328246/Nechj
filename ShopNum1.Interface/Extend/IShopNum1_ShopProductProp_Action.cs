using System.Collections.Generic;
using System.Data;
using ShopNum1MultiEntity;

namespace ShopNum1.Interface
{
    public interface IShopNum1_ShopProductProp_Action
    {
        int Add(ShopNum1_ShopProductProp model, List<ShopNum1_ShopProductPropValue> shopProductPropValue);
        int Delete(string string_0);
        bool Exists(int ID);
        int GetMaxOrderId();
        ShopNum1_ShopProductProp GetPropModelByID(int ID);
        DataTable GetSearchListPropByCode(string Code);
        ShopNum1_ShopProductProp ReaderBind(IDataReader dataReader);
        DataTable Search_Type_Prop(string strId);
        DataTable SelectProByProductGuid(string strGuid);
    }
}