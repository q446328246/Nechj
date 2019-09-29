using System.Data;
using ShopNum1MultiEntity;

namespace ShopNum1.Interface
{
    public interface IShopNum1_AttachMent_Action
    {
        int Delete(string Guid);
        int Insert(ShopNum1_AttachMent shopNum1_AttachMent);
        DataTable Search(string AssociatedCategoryGuid);
        DataRow SearchAttachMent(string Guid);
    }
}