using ShopNum1MultiEntity;

namespace ShopNum1.Interface
{
    public interface IShopNum1_MemberEmailExec_Action
    {
        int MemberEmailExec(string Emailkey, string type);
        int MemberEmailInsert(ShopNum1_MemberEmailExec MemberEmailExec);
        int MemberMobileExec(string Emailkey, string Type);
    }
}