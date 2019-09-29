using System;

namespace ShopNum1.TbBusinessEntity
{
    public class ShopNum1_TbCat
    {
        public DateTime createTime;
        public int int_0;
        public string name;

        private int _cid
        {
            get { return int_0; }
            set { int_0 = value; }
        }

        private DateTime _createTime
        {
            get { return createTime; }
            set { createTime = value; }
        }

        private string _name
        {
            get { return name; }
            set { name = value; }
        }
    }
}