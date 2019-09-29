using System.Collections.Generic;
using System.Data;
using ShopNum1MultiEntity;

namespace ShopNum1.Interface
{
    public interface IShopNum1_SpecificationProductImage_Action
    {
        bool AddSpecificationImages(List<ShopNum1_SpecificationProductImage> pImages);
        bool DelImgsBySpecificationValue(string specificationvalue, string memloginid);
        DataTable GetProuctSImage(string productGuid, string specificationValue, string memloginid);
        bool SpecificationImageInsert(ShopNum1_SpecificationProductImage pImage);
        bool Update(ShopNum1_SpecificationProductImage pImage);
    }
}