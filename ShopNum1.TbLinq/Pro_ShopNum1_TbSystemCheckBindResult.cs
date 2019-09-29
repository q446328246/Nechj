using System.Data.Linq.Mapping;

namespace ShopNum1.TbLinq
{
    public class Pro_ShopNum1_TbSystemCheckBindResult
    {
        private int _TotalCount;

        [Column(Storage = "_TotalCount", DbType = "Int NOT NULL")]
        public int TotalCount
        {
            get { return _TotalCount; }
            set
            {
                if (_TotalCount != value)
                {
                    _TotalCount = value;
                }
            }
        }
    }
}