using System;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;

namespace ShopNum1.ShopNewWebControl
{
    [ParseChildren(true)]
    public class ProductIsSpellDetail : BaseWebControl
    {
        public static int int_0 = 0;
        public static int finished = 0;
        private Button button_0 = new Button();
        private HtmlInputHidden htmlInputHidden_0;
        private Label label_0;
        private Label label_1;
        private Label label_2;
        private Literal literal_0;
        private Repeater repeater_0;
        private string string_0 = string.Empty;
        private string string_1 = "ProductIsSpellDetailNew.ascx";
        private string string_2;
        private string string_3 = string.Empty;


        public ProductIsSpellDetail()
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
            htmlInputHidden_0 = (HtmlInputHidden) skin.FindControl("hidProductGuId");
            string_2 = ((Page.Request.QueryString["guid"] == null) ? "-1" : Page.Request.QueryString["guid"]);
            repeater_0 = (Repeater) skin.FindControl("RepeaterData");
            if (!Page.IsPostBack)
            {
            }
            method_0();
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
                    int num = 0;
                    var shopNum1_OrderInfo_Action =
                        (ShopNum1_OrderInfo_Action) Factory.LogicFactory.CreateShopNum1_OrderInfo_Action();
                    DataTable dataTable = shopNum1_OrderInfo_Action.SearchOrderInfoByProductGuid(string_2);
                    if (dataTable.Rows.Count > 0)
                    {
                        for (int i = 0; i < dataTable.Rows.Count; i++)
                        {
                            if (dataTable.Rows[i]["MemLoginID"].ToString() == MemberLoginID)
                            {
                                num = 1;
                            }
                        }
                        if (num == 1)
                        {
                            MessageBox.Show("您已经参加过此商品的团购活动，请不要重复参加！");
                        }
                        else
                        {
                            string url = string.Concat(new[]
                            {
                                "http://",
                                Page.Request.Url.Host,
                                "/ProductDetail/",
                                htmlInputHidden_0.Value,
                                ".html?type=tg&"
                            });
                            Page.Response.Redirect(url);
                        }
                    }
                    else
                    {
                        string url = string.Concat(new[]
                        {
                            "http://",
                            Page.Request.Url.Host,
                            "/ProductDetail/",
                            htmlInputHidden_0.Value,
                            ".html?type=tg&"
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
            var shop_GroupProduct_Action = new Shop_GroupProduct_Action();
            DataTable groupProductDetial = shop_GroupProduct_Action.GetGroupProductDetial(string_2);
            if (groupProductDetial.Rows.Count > 0)
            {
                repeater_0.DataSource = groupProductDetial;
                repeater_0.DataBind();
                htmlInputHidden_0.Value = groupProductDetial.Rows[0]["GuiD"].ToString();
                decimal value = Convert.ToDecimal(groupProductDetial.Rows[0]["GroupPrice"]);
                decimal value2 = Convert.ToDecimal(groupProductDetial.Rows[0]["ShopPrice"]);
                string value3 = (Convert.ToDouble(value)/Convert.ToDouble(value2)).ToString("F2");
                string text = (Convert.ToDecimal(value3)*10m).ToString("F1");
                foreach (RepeaterItem repeaterItem in repeater_0.Items)
                {
                    new Button();
                    button_0 = (Button) repeaterItem.FindControl("ButtonShopCar");
                    button_0.Click += button_0_Click;
                    label_0 = (Label) repeaterItem.FindControl("LabelName");
                    label_1 = (Label) repeaterItem.FindControl("LabelShopPrice");
                    label_2 = (Label) repeaterItem.FindControl("LabelDiscount");
                    label_2.Text = text;
                    var arg_19B_0 = (Repeater) repeaterItem.FindControl("RepeaterDateImage");
                    literal_0 = (Literal) repeaterItem.FindControl("LiteralMemLoginID");
                }
                if (DateTime.Parse(groupProductDetial.Rows[0]["StartTime"].ToString()) > DateTime.Now.ToLocalTime())
                {
                    button_0.Text = "即将开始";
                    button_0.Enabled = false;
                }
                if (DateTime.Parse(groupProductDetial.Rows[0]["EndTime"].ToString()) < DateTime.Now.ToLocalTime())
                {
                    button_0.Enabled = false;
                    button_0.Text = "已结束";
                    finished = 1;
                    Isfinished = "1";
                }
                if (!string.IsNullOrEmpty(groupProductDetial.Rows[0]["groupcount"].ToString()) &&
                    int.Parse(groupProductDetial.Rows[0]["groupstock"].ToString()) <=
                    int.Parse(groupProductDetial.Rows[0]["groupcount"].ToString()))
                {
                    button_0.Enabled = false;
                    button_0.Text = "已结束";
                    finished = 1;
                    Isfinished = "1";
                }
            }
            else
            {
                string url = "http://" + HttpContext.Current.Request.Url.Host + "/NoFind.aspx";
                Page.Response.Redirect(url);
            }
        }

        public static string IsBegin(object begin, object object_0)
        {
            string result;
            if (DateTime.Parse(object_0.ToString()) < DateTime.Now.ToLocalTime())
            {
                result = begin.ToString();
            }
            else
            {
                if (Isfinished == "1")
                {
                    result = "1900-1-1";
                }
                else
                {
                    result = object_0.ToString();
                }
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
                int num = int.Parse(PanicBuyCount.ToString()) - int.Parse(SaledNum.ToString());
                if (num > 0)
                {
                    result = num;
                }
                else
                {
                    result = 0;
                }
            }
            else
            {
                result = int.Parse(PanicBuyCount.ToString());
            }
            return result;
        }

        public static string SetNotNull(object JoinMemNum)
        {
            string result;
            if (!string.IsNullOrEmpty(JoinMemNum.ToString()))
            {
                result = JoinMemNum.ToString();
            }
            else
            {
                result = "0";
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