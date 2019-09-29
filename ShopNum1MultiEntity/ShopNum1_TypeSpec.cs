//using System.Data.Linq.Mapping;

namespace ShopNum1MultiEntity
{
    //[Table(Name = "dbo.ShopNum1_TypeSpec")]
    public class ShopNum1_TypeSpec
    {
        private int? int_0;
        private int? int_1;

        //[Column(Storage = "_SpecID", DbType = "Int")]
        public int? SpecID
        {
            get { return int_1; }
            set
            {
                if (int_1 != value)
                {
                    int_1 = value;
                }
            }
        }

        //[Column(Storage = "_TypeID", DbType = "Int")]
        public int? TypeID
        {
            get { return int_0; }
            set
            {
                if (int_0 != value)
                {
                    int_0 = value;
                }
            }
        }
    }
}