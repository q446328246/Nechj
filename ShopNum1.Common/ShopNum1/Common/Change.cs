namespace ShopNum1.Common
{
    public static class Change
    {
        public static string ChangeYesNo(string isDefault)
        {
            if (isDefault == "1")
            {
                return "是";
            }
            return "否";
        }
    }
}