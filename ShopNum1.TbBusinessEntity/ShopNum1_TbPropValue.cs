namespace ShopNum1.TbBusinessEntity
{
    public class ShopNum1_TbPropValue
    {
        public int int_0;
        public int int_1;
        public bool is_enum_prop;
        public bool is_sale_prop;
        public bool multi;
        public string name;

        public bool Is_enum_prop
        {
            get { return is_enum_prop; }
            set { is_enum_prop = value; }
        }

        public bool Is_sale_prop
        {
            get { return is_sale_prop; }
            set { is_sale_prop = value; }
        }

        public bool Multi
        {
            get { return multi; }
            set { multi = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int pid
        {
            get { return int_0; }
            set { int_0 = value; }
        }

        public int vid
        {
            get { return int_1; }
            set { int_1 = value; }
        }
    }
}