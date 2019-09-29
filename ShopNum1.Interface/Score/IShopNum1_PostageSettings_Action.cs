using System.Collections.Generic;
using System.Data;
using ShopNum1MultiEntity;

namespace ShopNum1.Interface
{
    public interface IShopNum1_PostageSettings_Action
	{
        int Add(ShopNum1_PostageSettings PostageSettings);
        DataTable SelectPrice(string memloginid);
        int UpdatePostagePrice(string memloginid, decimal FirstHeavyPrice, decimal AfterHeavyPrice, decimal FirstHeavy);
	}
}
