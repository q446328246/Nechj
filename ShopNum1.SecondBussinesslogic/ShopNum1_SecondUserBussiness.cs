using ShopNum1.Second;

namespace ShopNum1_Second
{
    public class ShopNum1_SecondUserBussiness
    {
        private readonly ShopNum1_SecondUserAccess shopNum1_SecondUserAccess_0 = new ShopNum1_SecondUserAccess();

        public bool Add(ShopNum1_SecondUser model)
        {
            return shopNum1_SecondUserAccess_0.Add(model);
        }

        public bool Delete(int ID)
        {
            return shopNum1_SecondUserAccess_0.Delete(ID);
        }

        public bool Exists(int ID)
        {
            return shopNum1_SecondUserAccess_0.Exists(ID);
        }

        public int GetMaxId()
        {
            return shopNum1_SecondUserAccess_0.GetMaxId();
        }

        public string GetMemLogid(string SecondID, string Secondtype)
        {
            object memLogid = shopNum1_SecondUserAccess_0.GetMemLogid(SecondID, Secondtype);
            if (memLogid == null)
            {
                return "";
            }
            return memLogid.ToString();
        }

        public bool Update(ShopNum1_SecondUser model)
        {
            return shopNum1_SecondUserAccess_0.Update(model);
        }
    }
}