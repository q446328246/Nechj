//using System.Data.Linq.Mapping;

namespace ShopNum1MultiEntity
{
    //[Table(Name = "dbo.ShopNum1_TypeProp")]
    public class ShopNum1_TypeProp
    {
        private int? int_0;
        private int? int_1;

        //[Column(Storage = "_PropId", DbType = "Int")]
        public int? PropId
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

        //[Column(Storage = "_TypeId", DbType = "Int")]
        public int? TypeId
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