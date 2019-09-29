using System;
using System.Collections.Generic;
using System.Data;
using ShopNum1MultiEntity;

namespace ShopNum1.Interface
{
    public interface IShopNum1_ShopProductRelationProp_Action
    {
        int Add(ShopNum1_ShopProductRelationProp model);
        int Add(List<ShopNum1_ShopProductRelationProp> RelationProps);
        void Delete(Guid guid);
        void Delete(int ID);
        bool Exists(int ID);
        DataSet GetList(string strWhere);
        List<ShopNum1_ShopProductRelationProp> GetListArray(string strWhere);
        List<ShopNum1_ShopProductRelationProp> GetListArray(string guid, string PropID, string Memlogid);
        int GetMaxId();
        ShopNum1_ShopProductRelationProp GetModel(int ID);
        DataTable GetProductPropNameAndID(string guid, string memlogid);
        DataTable GetProductPropValue(string propid, string prodguid);
        ShopNum1_ShopProductRelationProp ReaderBind(IDataReader dataReader);
        void Update(ShopNum1_ShopProductRelationProp model);
    }
}