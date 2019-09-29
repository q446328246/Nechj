using System.Data;
using ShopNum1MultiEntity;

namespace ShopNum1.WeiXinInterface
{
    public interface IShopNum1_Weixin_ShopWeiXinConfig_Active
    {
        bool Add_DefaultSetting(ShopNum1_Weixin_ShopWeiXinConfig model);
        bool Add_TokenApp(ShopNum1_Weixin_ShopWeiXinConfig model);
        DataTable GetWeixinConfig(string ShopMemLoginId);
        DataTable GetWeixinConfigByUrl(string TokenURL);
    }
}