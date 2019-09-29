namespace ShopNum1.TbBusinessEntity
{
    public class ShopNum1_TbSysItemCat
    {
        public bool is_parent;
        public string name;
        public string string_0;

        public string cid
        {
            get { return string_0; }
            set { string_0 = value; }
        }

        public bool Is_parent
        {
            get { return is_parent; }
            set { is_parent = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
    }
}