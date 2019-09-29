using System.Data;

namespace ShopNum1.Second
{
    public class ShopNum1_SecondTypeBussiness
    {
        private readonly ShopNum1_SecondTypeAccess shopNum1_SecondTypeAccess_0 = new ShopNum1_SecondTypeAccess();

        public bool Add(ShopNum1_SecondType model)
        {
            return shopNum1_SecondTypeAccess_0.Add(model);
        }

        public bool Delete(int ID)
        {
            return shopNum1_SecondTypeAccess_0.Delete(ID);
        }

        public bool Exists(int ID)
        {
            return shopNum1_SecondTypeAccess_0.Exists(ID);
        }

        public int GetMaxOrderId()
        {
            return shopNum1_SecondTypeAccess_0.GetMaxOrderId();
        }

        public DataTable GetModel(int ID)
        {
            return shopNum1_SecondTypeAccess_0.GetModel(ID);
        }

        public DataTable GetSecondByCount(string count, string isAvabile)
        {
            return shopNum1_SecondTypeAccess_0.GetSecondByCount(count, isAvabile);
        }

        public bool Update(ShopNum1_SecondType model)
        {
            return shopNum1_SecondTypeAccess_0.Update(model);
        }
    }
}