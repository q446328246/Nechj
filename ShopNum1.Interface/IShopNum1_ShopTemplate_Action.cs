using System.Data;
using ShopNum1MultiEntity;

namespace ShopNum1.Interface
{
    public interface IShopNum1_ShopTemplate_Action
    {
        int Add(ShopNum1_Shop_Template shopNum1_Shop_Template);
        int CheckTemplateName(string name);
        int Delete(string guid);
        DataTable Edit(string guid);
        DataTable GetTemplateByID(string string_0);
        DataTable GetTemplatePathAndImg(string guid);
        DataTable GetTemplateType();
        DataTable Search();
        int Updata(ShopNum1_Shop_Template shopNum1_Shop_Template);
        bool UpdateIsDefault();
    }
}