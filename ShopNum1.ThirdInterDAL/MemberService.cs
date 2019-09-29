using System;

namespace ShopNum1.ThirdInterDAL
{
    public class MemberService
    {
        public int CheckMember(string memLoginId, string password)
        {
            string sql =
                string.Format(
                    "SELECT count(*) FROM ShopNum1_Member WHERE MemberType=2 and MemLoginID='{0}' and Pwd='{1}'",
                    memLoginId, password);
            var helper = new SqlHelper();
            if (Convert.ToInt32(helper.ExecuteScalar(sql)) > 0)
            {
                return 1;
            }
            return 0;
        }
    }
}