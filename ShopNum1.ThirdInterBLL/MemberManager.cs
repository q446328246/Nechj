using ShopNum1.ThirdInterDAL;

namespace ShopNum1.ThirdInterBLL
{
    public class MemberManager
    {
        public int CheckMember(string memLoginId, string password)
        {
            var service = new MemberService();
            return service.CheckMember(memLoginId, password);
        }
    }
}