using System;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;

namespace ShopNum1.ShopNewWebControl
{
    [ParseChildren(true)]
    public class ProductIsPanicDetail : BaseWebControl
    {
        public static int i = 0;
        public static int finished = 0;

        private Button button_0 = new Button();
        private Label label_0;
        private Label label_1;
        private Label label_10;
        private Label label_11;
        private Label label_2;
        private Label label_3;
        private Label label_4;
        private Label label_5;
        private Label label_6;
        private Label label_7;
        private Label label_8;
        private Label label_9;
        private Literal literal_0;
        private Repeater repeater_0;
        private string string_0 = string.Empty;
        private string string_1 = "ProductIsPanicDetailNew.ascx";
        private string string_2;

        public ProductIsPanicDetail()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = string_1;
            }
        }

        public static string MemLoginID { get; set; }
        public string MemberType { get; set; }
        public string MemberLoginID { get; set; }
        public static string Isfinished { get; set; }

        protected override void InitializeSkin(Control skin)
        {
            string shopid = (Page.Request.QueryString["ShopID"] == null) ? "0" : Page.Request.QueryString["ShopID"];
            var shop_ShopInfo_Action = (Shop_ShopInfo_Action) LogicFactory.CreateShop_ShopInfo_Action();
            MemLoginID = shop_ShopInfo_Action.GetMemberLoginidByShopid(shopid);
            string_2 = ((Page.Request.QueryString["guid"] == null) ? "-1" : Page.Request.QueryString["guid"]);
            var shop_ShopInfo_Action2 = (Shop_ShopInfo_Action) LogicFactory.CreateShop_ShopInfo_Action();
            DataTable memLoginInfo = shop_ShopInfo_Action2.GetMemLoginInfo(MemLoginID);
            if (memLoginInfo.Rows.Count > 0)
            {
                MemberType = memLoginInfo.Rows[0]["MemberType"].ToString();
                repeater_0 = (Repeater) skin.FindControl("RepeaterData");
                if (!Page.IsPostBack)
                {
                }
                method_0();
            }
        }

        protected void button_0_Click(object sender, EventArgs e)
        {
            if (Page.Request.Cookies["MemberLoginCookie"] != null)
            {
                HttpCookie httpCookie = Page.Request.Cookies["MemberLoginCookie"];
                HttpCookie httpCookie2 = HttpSecureCookie.Decode(httpCookie);
                MemberLoginID = httpCookie2.Values["MemLoginID"];
                string shopid = (Page.Request.QueryString["ShopID"] == null) ? "0" : Page.Request.QueryString["ShopID"];
                var shop_ShopInfo_Action = (Shop_ShopInfo_Action) LogicFactory.CreateShop_ShopInfo_Action();
                MemLoginID = shop_ShopInfo_Action.GetMemberLoginidByShopid(shopid);
                
                if (MemLoginID != MemberLoginID)
                {
                    var shop_Product_Action = (Shop_Product_Action) LogicFactory.CreateShop_Product_Action();
                    if (shop_Product_Action.CheckMenberBuyProduct(string_2, MemberLoginID).Rows.Count > 0)
                    {
                        MessageBox.Show("您已经购买过");
                    }
                    else
                    {
                        string url = string.Concat(new[]
                        {
                            "http://",
                            Page.Request.Url.Host,
                            "/ProductDetail/",
                            Common.Common.ReqStr("GuID"),
                            ".html?type=qg&"
                        });
                        Page.Response.Redirect(url);
                    }
                }
                else
                {
                    MessageBox.Show("您不能购买自己的商品！");
                }
            }
            else
            {
                GetUrl.RedirectShopLoginGoBack("目前尚未登录！请登录后再购买！");
            }
        }

        protected void method_0()
        {
            var shop_Product_Action = (Shop_Product_Action) LogicFactory.CreateShop_Product_Action();
            DataSet panicInfo = shop_Product_Action.GetPanicInfo(MemLoginID, string_2);
            if (panicInfo.Tables[0].Rows.Count > 0)
            {
                string_2 = panicInfo.Tables[0].Rows[0]["Guid"].ToString();
                repeater_0.DataSource = panicInfo;
                repeater_0.DataBind();
                foreach (RepeaterItem repeaterItem in repeater_0.Items)
                {
                    label_5 = (Label) repeaterItem.FindControl("lblCharactervg");
                    label_6 = (Label) repeaterItem.FindControl("lblAllnum");
                    label_7 = (Label) repeaterItem.FindControl("lblGoodCount");
                    label_8 = (Label) repeaterItem.FindControl("lblMiddelCount");
                    label_9 = (Label) repeaterItem.FindControl("lblBadCount");
                    label_10 = (Label) repeaterItem.FindControl("lblTotal");
                    label_11 = (Label) repeaterItem.FindControl("lblContinue");
                    DataTable dataTable = panicInfo.Tables[1];
                    if (dataTable.Rows.Count > 0)
                    {
                        label_5.Text = ((dataTable.Rows[0]["Characteravg"].ToString() == "")
                            ? "0"
                            : dataTable.Rows[0]["Characteravg"].ToString());
                        label_6.Text = dataTable.Rows[0]["Allnum"].ToString();
                    }
                    if (panicInfo.Tables[2].Rows.Count > 0)
                    {
                        string text = panicInfo.Tables[2].Rows[0]["py"].ToString();
                        label_10.Text = text.Split(new[]
                        {
                            '-'
                        })[0];
                        label_7.Text = text.Split(new[]
                        {
                            '-'
                        })[1];
                        label_8.Text = text.Split(new[]
                        {
                            '-'
                        })[2];
                        label_9.Text = text.Split(new[]
                        {
                            '-'
                        })[3];
                        label_11.Text = text.Split(new[]
                        {
                            '-'
                        })[4];
                    }
                    new Button();
                    button_0 = (Button) repeaterItem.FindControl("ButtonShopCar");
                    button_0.Click += button_0_Click;
                    label_4 = (Label) repeaterItem.FindControl("LabelTime");
                    label_0 = (Label) repeaterItem.FindControl("LabelName");
                    label_1 = (Label) repeaterItem.FindControl("LabelShopPrice");
                    label_2 = (Label) repeaterItem.FindControl("LabelCarriage");
                    label_3 = (Label) repeaterItem.FindControl("LabelRepertoryCount");
                    var repeater = (Repeater) repeaterItem.FindControl("RepeaterDateImage");
                    literal_0 = (Literal) repeaterItem.FindControl("LiteralMemLoginID");
                    string[] array = panicInfo.Tables[0].Rows[0]["multiimages"].ToString().Split(new[]
                    {
                        ','
                    });
                    var dataTable2 = new DataTable();
                    dataTable2.Columns.Add("imgurl", Type.GetType("System.String"));
                    if (array.Length > 0)
                    {
                        for (int i = 0; i < array.Length; i++)
                        {
                            DataRow dataRow = dataTable2.NewRow();
                            dataRow["imgurl"] = array[i];
                            dataTable2.Rows.Add(dataRow);
                        }
                    }
                    else
                    {
                        DataRow dataRow2 = dataTable2.NewRow();
                        dataRow2["imgurl"] = panicInfo.Tables[0].Rows[0]["multiimages"].ToString();
                        dataTable2.Rows.Add(dataRow2);
                    }
                    repeater.DataSource = dataTable2;
                    repeater.DataBind();
                }
                if (Convert.ToDateTime(panicInfo.Tables[0].Rows[0]["StartTime"]) > DateTime.Now.ToLocalTime())
                {
                    button_0.Enabled = false;
                    label_4.Text = "开始倒计时：";
                }
                else
                {
                    label_4.Text = "结束倒计时：";
                }
                if (Convert.ToDateTime(panicInfo.Tables[0].Rows[0]["EndTime"].ToString()) < DateTime.Now.ToLocalTime())
                {
                    button_0.Enabled = false;
                    label_4.Text = "已结束时间：";
                    finished = 1;
                    Isfinished = "1";
                }
                if (!string.IsNullOrEmpty(panicInfo.Tables[0].Rows[0]["SaleNumber"].ToString()) &&
                    int.Parse(panicInfo.Tables[0].Rows[0]["repertorycount"].ToString()) == 0)
                {
                    button_0.Enabled = false;
                    finished = 1;
                    Isfinished = "1";
                }
            }
        }

        public static string SetNoNull(object value)
        {
            string result;
            if (value.ToString() == "")
            {
                result = "0";
            }
            else
            {
                result = value.ToString();
            }
            return result;
        }

        public static string IsBegin(object begin, object object_0)
        {
            string result;
            if (DateTime.Parse(begin.ToString()) > DateTime.Now.ToLocalTime())
            {
                Convert.ToDateTime(begin.ToString()).ToString("yyyy-MM-dd HH:mm:ss");
                result = Convert.ToDateTime(begin.ToString()).ToString("yyyy-MM-dd HH:mm:ss");
            }
            else
            {
                result = Convert.ToDateTime(object_0.ToString()).ToString();
            }
            return result;
        }

        public static string IsShow(object object_0)
        {
            string a = object_0.ToString();
            string result;
            if (a == "0")
            {
                result = "否";
            }
            else
            {
                if (a == "1")
                {
                    result = "是";
                }
                else
                {
                    result = "";
                }
            }
            return result;
        }

        public static int GetCount(object PanicBuyCount, object SaledNum)
        {
            int result;
            if (!string.IsNullOrEmpty(SaledNum.ToString()))
            {
                result = int.Parse(PanicBuyCount.ToString()) - int.Parse(SaledNum.ToString());
            }
            else
            {
                result = int.Parse(PanicBuyCount.ToString());
            }
            return result;
        }

        public static string SetLastBuyTime(object MemberName, object LastTine)
        {
            string result;
            if (!string.IsNullOrEmpty(MemberName.ToString()))
            {
                result = MemberName + "在" + LastTine + "购买了它";
            }
            else
            {
                result = "当前还无人购买";
            }
            return result;
        }

        public static string returnImagePath(object object_0)
        {
            string newValue = "http://" + MemLoginID + ConfigurationManager.AppSettings["Domain"];
            return object_0.ToString().Replace("~/", newValue);
        }
    }
}