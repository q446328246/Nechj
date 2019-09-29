using System.Data;
using ShopNum1MultiEntity;

namespace ShopNum1.Interface
{
    public interface IShopNum1_MemberPwd_Action
    {
        DataTable CheckLink(string pwdkey, string type);
        int MemberPwdInsert(ShopNum1_MemberPwd MemberPwd);
        DataTable ShopNum1MemberPwdExec(string pwdkey, string type);
        int UpdatePwd(string pwdkey, string type, string string_0);
    }
}