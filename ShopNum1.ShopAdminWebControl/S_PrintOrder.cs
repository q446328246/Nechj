using System.Data;
using System.Web.UI;
using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;

namespace ShopNum1.ShopAdminWebControl
{
    [ParseChildren(true)]
    public class S_PrintOrder : BaseShopWebControl
    {
        public static string Address = null;
        public static string CreateTime = null;
        public static string DispatchPrice = null;
        public static DataTable dt_OrderInfo = null;
        public static string Email = null;
        public static string Logisticscompany = null;
        public static string Mobile = null;
        public static string Name = null;
        public static string OrderNumber = null;
        public static string PaymentPrice = null;
        public static string PostCode = null;
        public static string ShipmentNumber = null;
        public static string ShopId = null;
        public static string ShopMobile = null;
        public static string ShopName = null;
        public static string Tel = null;
        public static string TotalPrice = null;
        public static string Area = null;
        private DataTable dt;
        private string skinFilename = "S_PrintOrder.ascx";

        public S_PrintOrder()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        protected override void InitializeSkin(Control skin)
        {
            string strOrderGuId = Common.Common.ReqStr("guid");
            string strOrderType = Common.Common.ReqStr("ordertype");
            DataSet set =
                ((ShopNum1_OrderInfo_Action) LogicFactory.CreateShopNum1_OrderInfo_Action()).GetOrderDetail(
                    strOrderGuId, base.MemLoginID, strOrderType, "1");
            if ((set != null) && (set.Tables.Count == 4))
            {
                dt_OrderInfo = set.Tables[0];
                if (dt_OrderInfo.Rows.Count == 0)
                {
                    dt_OrderInfo = null;
                }
                else
                {
                    int num = 0;
                    for (int i = 0; i < dt_OrderInfo.Rows.Count; i++)
                    {
                        if (dt_OrderInfo.Rows[i]["ordernumber"].ToString() != "")
                        {
                            num = i;
                            break;
                        }
                    }
                    DataRow row = dt_OrderInfo.Rows[num];
                    ShopName = row["ShopName"].ToString();
                    ShopId = row["ShopId"].ToString();
                    Name = row["name"].ToString();
                    Tel = row["tel"].ToString();
                    Mobile = row["Mobile"].ToString();
                    Address = row["Address"].ToString();
                    PostCode = row["postalcode"].ToString();
                    OrderNumber = row["OrderNumber"].ToString();
                    CreateTime = row["CreateTime"].ToString();
                    ShipmentNumber = row["shipmentnumber"].ToString();
                    TotalPrice = row["shouldpayprice"].ToString();
                    DispatchPrice = row["DispatchPrice"].ToString();
                    Logisticscompany = row["Logisticscompany"].ToString();
                    PaymentPrice = row["PaymentPrice"].ToString();
                    if (row["shop_category_id"].ToString() == "1")
                    {
                        Area = "大唐";
                    }
                    if (row["shop_category_id"].ToString() == "2")
                    {
                        Area = "VIP";
                    }
                    if (row["shop_category_id"].ToString() == "3")
                    {
                        Area = "积分";
                    }
                    if (row["shop_category_id"].ToString() == "4")
                    {
                        Area = "区代首次";
                    }
                    if (row["shop_category_id"].ToString() == "5")
                    {
                        Area = "区代二次";
                    }
                    if (row["shop_category_id"].ToString() == "6")
                    {
                        Area = "社区首次";
                    }
                    if (row["shop_category_id"].ToString() == "7")
                    {
                        Area = "社区二次";
                    }
                    if (row["shop_category_id"].ToString() == "9")
                    {
                        Area = "BTC/CTC";
                    }
                    Area += " 专区";

                    dt = set.Tables[3];
                    if (dt.Rows.Count == 0)
                    {
                        dt = null;
                    }
                    else
                    {
                        Email = dt.Rows[0]["Email"].ToString();
                        ShopMobile = dt.Rows[0]["Mobile"].ToString();
                    }
                }
            }
        }
    }
}