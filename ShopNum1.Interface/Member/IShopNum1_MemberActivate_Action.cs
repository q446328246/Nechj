using ShopNum1MultiEntity;

namespace ShopNum1.Interface
{
    public interface IShopNum1_MemberActivate_Action
    {
        bool CheckKey(string type, string MemberID, string string_0, string typeinfo);
        string CheckMobileCode(string Emailkey, string mobile, string Type);
        int DeleteKey(string MemberID, string Key);
        int DeleteKey(string MemberID, string strPhoneEmail, string strType);
        int InsertforGetMobileCode(ShopNum1_MemberActivate memberactivate);
        int UpdateIsinvalid(string mobile, string MemberID, string string_0);
    }
}