using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Email;
using ShopNum1.Factory;
using ShopNum1.Interface;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFeeTemplate;
using ShopNum1.ShopInterface;
using ShopNum1.Standard;
using ShopNum1MultiEntity;
using ShopNum1.Common.ShopNum1.Common;

namespace ShopNum1.WebControl
{
    [ParseChildren(true)]
    public class ConfirmOrder : BaseWebControl
    {
        private TextBox TextBox1;
        private HtmlSelect DropDownList1;
        private Button ButtonAddReceivAddress;
        private Button ButtonCreate;
        private DropDownList DropDownListPost;
        private DropDownList DropDownListSelect;
        private HiddenField HiddenFieldAddressCode;
        private HiddenField HiddenFieldAddressGuid;
        private HiddenField HiddenFieldAddressName;
        private HiddenField HiddenFieldAllCartPrice;
        private HiddenField HiddenFieldDispatchModeGuid;
        private HiddenField HiddenFieldDispatchModeName;
        private HiddenField HiddenFieldDispatchPrice;
        private HiddenField HiddenFieldFeeTemplateID;
        private HiddenField HiddenFieldInvoiceType;
        private HiddenField HiddenFieldPaymentCharge;
        private HiddenField HiddenFieldPaymentGuid;
        private HiddenField HiddenFieldPaymentName;
        private HiddenField HiddenFieldPaymentPriceValue;
        private HiddenField HiddenFieldProtectAllCount;
        private HiddenField HiddenFieldSName;
        private HiddenField HiddenFieldSValue;
        private Label LabelAllCartPrice;
        private Label LabelBuyShopPrice;
        private Label LabelBuyShopPrice3;
        private Label LabelOnlyProductPrice;
        private Label LabelPost;
        private Label LabelPriceMeto;
        private Label LabelSellName;
        private Label LabelShopName;
        private RadioButtonList RadioButtonListInvoice;
        private Repeater RepeaterReceivingAddress;
        private Repeater RepeaterShopProduct;
        private Repeater RepeaterShoppingCartPayment;
        private TextBox TextBoxAddress;
        private TextBox TextBoxEmail;
        private TextBox TextBoxInvoice;
        private TextBox TextBoxInvoicespayable;
        private TextBox TextBoxMessage;
        private TextBox TextBoxMobile;
        private TextBox TextBoxName;
        private TextBox TextBoxPostalcode;
        private TextBox TextBoxTel;
        private HtmlInputHidden hidPrice;
        private HtmlInputHidden hidSaleType;
        private HtmlInputHidden hidShopId;
        private IShopNum1_Cart_Action ishopNum1_Cart_Action_0 = LogicFactory.CreateShopNum1_Cart_Action();
        private Label labelAll;
        private Label labelAllPrice;
        private Label labelLower;
        private Label labelMaretPrice;
        private Label labelProtectAllCount;
        private Label label_9;
        private Label lblTotal;
        private string string_0 = string.Empty;
        private string skinFilename = "ShoppingCart2.ascx";
        private string string_2 = string.Empty;

        private Label labelScore_hv;
        private Label labelScore_dv;
        private Label labelScore_pv_a;
        private Label labelScore_pv_b;
        private Label labelAgentId;

        private Label labelScore_cv;
        private Label labelScore_max_hv;
        private Label label_pv_a_b_all;
        private decimal MYlabelScore_dv;
        private decimal MYlabelScore_hv;
        private decimal MYlabelScore_pv_a;
        private decimal MYlabelScore_pv_b;
        private string MYlabelAgentId;
        private decimal MYlabelscore_reduce_hv;
        private decimal MYlabelscore_reduce_pv_a;
        private decimal MYlabelscore_reduce_pv_cv;

        private decimal MYlabelScore_cv;
        private decimal MYlabelScore_max_hv;
        private decimal MYPostage;
        private decimal VIPPostage;
        private decimal WLPostage;
        private int shop_category_id;
        private decimal ShangPinPrice;
        private Label LabelWuliu;
        private Label Label1;



        //private string string_3;

        //private string string_4;

        //private string string_5;

        //private string string_6;

        //private string string_7;

        public ConfirmOrder()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public string AddressGuid { get; set; }
        public string strMemLoginID { get; set; }
        private string Shopid { get; set; }
        private string ProductGuid { get; set; }
        private string BuyNumber { get; set; }

        protected override void InitializeSkin(Control skin)
        {
            LabelWuliu = (Label)skin.FindControl("labelWuliu");
            Label1 = (Label)skin.FindControl("Label1");
            TextBox1 = (TextBox)skin.FindControl("TextBox1");
            DropDownList1 = (HtmlSelect)skin.FindControl("DropDownList1");
            lblTotal = (Label)skin.FindControl("lblTotal");
            labelAll = (Label)skin.FindControl("labelAll");
            RadioButtonListInvoice = (RadioButtonList)skin.FindControl("RadioButtonListInvoice");
            TextBoxInvoicespayable = (TextBox)skin.FindControl("TextBoxInvoicespayable");
            TextBoxInvoice = (TextBox)skin.FindControl("TextBoxInvoice");
            LabelShopName = (Label)skin.FindControl("LabelShopName");
            LabelSellName = (Label)skin.FindControl("LabelSellName");
            DropDownListPost = (DropDownList)skin.FindControl("DropDownListPost");
            RepeaterShopProduct = (Repeater)skin.FindControl("RepeaterShopProduct");
            RepeaterShopProduct.ItemDataBound += RepeaterShopProduct_ItemDataBound;
            hidSaleType = (HtmlInputHidden)skin.FindControl("hidSaleType");
            hidPrice = (HtmlInputHidden)skin.FindControl("hidPrice");
            hidShopId = (HtmlInputHidden)skin.FindControl("hidShopId");

            labelScore_hv = (Label)skin.FindControl("labelScore_hv");
            labelScore_dv = (Label)skin.FindControl("labelScore_dv");
            labelScore_pv_a = (Label)skin.FindControl("labelScore_pv_a");
            labelScore_pv_b = (Label)skin.FindControl("labelScore_pv_b");
            labelAgentId = (Label)skin.FindControl("labelAgentId");
            labelScore_cv = (Label)skin.FindControl("labelScore_cv");
            labelScore_max_hv = (Label)skin.FindControl("labelScore_max_hv");
            label_pv_a_b_all = (Label)skin.FindControl("label_pv_a_b_all");

            if (Page.Request.Cookies["MemberLoginCookie"] == null)
            {
                Page.Response.Write(string.Concat(new[]
                {
                    "<script>window.top.location.target= '_blank '; window.top.location.href='",
                    GetPageName.RetUrl("Login"),
                    "?goback=",
                    Page.Request.Url.ToString().Replace("/", "%2f"),
                    "' </script>"
                }));
            }
            else
            {
                HttpCookie cookie = Page.Request.Cookies["MemberLoginCookie"];
                HttpCookie httpCookie = HttpSecureCookie.Decode(cookie);
                strMemLoginID = httpCookie.Values["MemLoginID"];
                HiddenFieldSName = (HiddenField)skin.FindControl("HiddenFieldSName");
                HiddenFieldSValue = (HiddenField)skin.FindControl("HiddenFieldSValue");
                HiddenFieldFeeTemplateID = (HiddenField)skin.FindControl("HiddenFieldFeeTemplateID");
                Shopid = Common.Common.ReqStr("shopid");
                if (Page.Request.Cookies["SpecificationCookie"] != null)
                {
                    HttpCookie SpecificationCookie = Page.Request.Cookies["SpecificationCookie"];
                    HttpCookie httpSpecificationCookie = HttpSecureCookie.Decode(SpecificationCookie);
                    HiddenFieldSName.Value = httpSpecificationCookie.Values["SpecName"].Replace(";",
                        "&nbsp;&nbsp;&nbsp;");
                    HiddenFieldSValue.Value = httpSpecificationCookie.Values["SpecValue"];
                    hidPrice.Value = httpSpecificationCookie.Values["Price"];
                    hidShopId.Value = httpSpecificationCookie.Values["ShopId"];
                    LabelSellName.Text = httpSpecificationCookie.Values["ShopName"];
                    Shopid = hidShopId.Value;
                    hidSaleType.Value = httpSpecificationCookie.Values["SaleType"];
                }
                labelAllPrice = (Label)skin.FindControl("labelAllPrice");
                labelMaretPrice = (Label)skin.FindControl("labelMaretPrice");
                labelLower = (Label)skin.FindControl("labelLower");
                LabelBuyShopPrice = (Label)skin.FindControl("LabelBuyShopPrice");
                LabelOnlyProductPrice = (Label)skin.FindControl("LabelOnlyProductPrice");
                LabelPriceMeto = (Label)skin.FindControl("LabelPriceMeto");
                LabelAllCartPrice = (Label)skin.FindControl("LabelAllCartPrice");
                labelProtectAllCount = (Label)skin.FindControl("labelProtectAllCount");
                string_0 = ((Page.Request.QueryString["checkedguid"] == null)
                    ? string.Empty
                    : Page.Request.QueryString["checkedguid"]);
                RepeaterShoppingCartPayment = (Repeater)skin.FindControl("RepeaterShoppingCartPayment");
                RepeaterReceivingAddress = (Repeater)skin.FindControl("RepeaterReceivingAddress");
                TextBoxName = (TextBox)skin.FindControl("TextBoxName");
                TextBoxAddress = (TextBox)skin.FindControl("TextBoxAddress");
                TextBoxEmail = (TextBox)skin.FindControl("TextBoxEmail");
                TextBoxPostalcode = (TextBox)skin.FindControl("TextBoxPostalcode");
                TextBoxTel = (TextBox)skin.FindControl("TextBoxTel");
                TextBoxMobile = (TextBox)skin.FindControl("TextBoxMobile");
                DropDownListSelect = (DropDownList)skin.FindControl("DropDownListSelect");
                ButtonAddReceivAddress = (Button)skin.FindControl("ButtonAddReceivAddress");
                ButtonAddReceivAddress.Click += ButtonAddReceivAddress_Click;
                HiddenFieldAddressCode = (HiddenField)skin.FindControl("HiddenFieldAddressCode");
                HiddenFieldAddressGuid = (HiddenField)skin.FindControl("HiddenFieldAddressGuid");
                HiddenFieldAddressName = (HiddenField)skin.FindControl("HiddenFieldAddressName");
                BindReceivingAddress();
                ButtonCreate = (Button)skin.FindControl("ButtonCreate");
                ButtonCreate.Click += ButtonCreate_Click;
                HiddenFieldDispatchModeGuid = (HiddenField)skin.FindControl("HiddenFieldDispatchModeGuid");
                HiddenFieldDispatchModeName = (HiddenField)skin.FindControl("HiddenFieldDispatchModeName");
                HiddenFieldPaymentGuid = (HiddenField)skin.FindControl("HiddenFieldPaymentGuid");
                HiddenFieldPaymentName = (HiddenField)skin.FindControl("HiddenFieldPaymentName");
                HiddenFieldInvoiceType = (HiddenField)skin.FindControl("HiddenFieldInvoiceType");
                HiddenFieldPaymentPriceValue = (HiddenField)skin.FindControl("HiddenFieldPaymentPriceValue");
                TextBoxMessage = (TextBox)skin.FindControl("TextBoxMessage");
                LabelPost = (Label)skin.FindControl("LabelPost");
                HiddenFieldDispatchPrice = (HiddenField)skin.FindControl("HiddenFieldDispatchPrice");
                HiddenFieldProtectAllCount = (HiddenField)skin.FindControl("HiddenFieldProtectAllCount");

                /* HiddenScore_hv = (HiddenField)skin.FindControl("HiddenScore_hv");
                 HiddenScore_dv = (HiddenField)skin.FindControl("HiddenScore_dv");
                 HiddenScore_pv_a = (HiddenField)skin.FindControl("HiddenScore_pv_a");
                 HiddenScore_pv_b = (HiddenField)skin.FindControl("HiddenScore_pv_b");*/

                HiddenFieldPaymentCharge = (HiddenField)skin.FindControl("HiddenFieldPaymentCharge");
                HiddenFieldAllCartPrice = (HiddenField)skin.FindControl("HiddenFieldAllCartPrice");
                ProductGuid = Common.Common.ReqStr("ProductionGuid");
                BuyNumber = ((Page.Request.QueryString["num"] == null) ? "1" : Page.Request.QueryString["num"]);
                BindData();
                BindDataPayment();
                LabelShopName.Text = Shopid;

            }
        }

        protected void RepeaterShopProduct_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var label = (Label)e.Item.FindControl("LabelBuyPrice");
                var label2 = (Label)e.Item.FindControl("lblSpecName");
                LabelBuyShopPrice3 = (Label)e.Item.FindControl("lblBuyNumber");
                label2.Text = HiddenFieldSName.Value;
                var textBox = (TextBox)e.Item.FindControl("TextBoxBuyNumber");
                var labelMyColor2 = (Label)e.Item.FindControl("labelMyColor");
                var labelMySize2 = (Label)e.Item.FindControl("labelMySize");
                string Color = Page.Request.QueryString["Color"].ToString();
                string Size = Page.Request.QueryString["Size"].ToString();
                if (Color == "")
                {
                    Color = "无";
                }
                else
                {
                    Color = Page.Request.QueryString["Color"].ToString();
                }
                if (Size == "")
                {
                    Size = "无";
                }
                else
                {
                    Size = Page.Request.QueryString["Size"].ToString();
                }
                labelMyColor2.Text = Color;
                labelMySize2.Text = Size;

                textBox.Text = BuyNumber;
                if (Page.Request.Cookies["PackAgeCookie"] != null)
                {
                    HttpCookie cookie = Page.Request.Cookies["PackAgeCookie"];
                    HttpCookie httpCookie = HttpSecureCookie.Decode(cookie);
                    LabelBuyShopPrice3.Text = httpCookie.Values["BuyNum"];
                    hidPrice.Value = httpCookie.Values["PackPrice"];
                    labelAll.Text =
                        (Convert.ToInt32(LabelBuyShopPrice3.Text) * Convert.ToDecimal(hidPrice.Value)).ToString();
                    string text = httpCookie.Values["Pack_Price"];
                    string text2 = httpCookie.Values["SpecName"];
                    if (text.IndexOf(",") != -1)
                    {
                        string[] array = text.Split(new[]
                        {
                            ','
                        });
                        label.Text = array[e.Item.ItemIndex];
                    }
                    else
                    {
                        label.Text = text;
                    }
                    if (text2.IndexOf("|") != -1)
                    {
                        string[] array2 = text2.Split(new[]
                        {
                            '|'
                        });
                        label2.Text = array2[e.Item.ItemIndex];
                    }
                    else
                    {
                        label2.Text = text2.Replace("|", "");
                    }
                }
                else
                {
                    label.Text = hidPrice.Value;
                    LabelBuyShopPrice3.Text = BuyNumber;
                    string value = textBox.Text.Trim();
                    labelAll.Text = label.Text;
                    if (label.Text != "")
                    {
                        labelAll.Text = (Convert.ToDecimal(label.Text) * Convert.ToInt32(value)).ToString();
                    }
                }
            }
        }
        //修改后
        protected void BindData()
        {
            var member_Action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
            DataTable memberAreaAgent = member_Action.SearchAreaAgent();
            DropDownList1.DataSource = memberAreaAgent;
            DropDownList1.DataTextField = "ShopName";
            DropDownList1.DataValueField = "MemLoginNO";
            DropDownList1.DataBind();
            DropDownList1.Items.Insert(0, new ListItem("=请选择=", "C0000001"));
            DropDownList1.Items.Insert(1, new ListItem("=手动输入=", "0"));
            HttpCookie cookieShopMemberLogin1 = HttpContext.Current.Request.Cookies["MemberLoginCookie"];
            HttpCookie decodedCookieShopMemberLogin1 = HttpSecureCookie.Decode(cookieShopMemberLogin1);
            //会员登录ID
            string MemberLoginID1 = decodedCookieShopMemberLogin1.Values["MemLoginID"];
            var memberrankguid_Action = (ShopNum1_Member_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Member_Action();
            //会员等级
            string memberGuid = memberrankguid_Action.GetCurrentMemberRankGuid(MemberLoginID1);
            string membertype = memberrankguid_Action.GetCurrentMemberType(MemberLoginID1);
            int shopcategoryid = Convert.ToInt32(Page.Request.QueryString["shopcategoryid"]);
            if (shopcategoryid == 4 || shopcategoryid == 5 || shopcategoryid == 6 || shopcategoryid == 7)
            {
                LabelWuliu.Visible = true;
            }
            else
            {
                LabelWuliu.Visible = false;
            }
            var shop_Product_Action = (Shop_Product_Action)ShopFactory.LogicFactory.CreateShop_Product_Action();
            DataTable shopProductEdit;


            #region 暂时处理订单服务区代
            if (shopcategoryid == 2)
            {
                
                    Label1.Text = "请填写正确的服务商(选填)";
                
            }
            else
            {

                TextBox1.Visible = false;
                Label1.Visible = false;
                TextBox1.Text = "C0000001";
            }

            //if ((shopcategoryid == (int)CustomerCategory.VIP专区 || shopcategoryid == (int)CustomerCategory.BTC专区) && memberGuid == MemberLevel.NORMAL_MEMBER_ID)
            //{
            //    TextBox1.ReadOnly = true;
            //    TextBox1.Text = "C0000001";
            //}

            //if (shopcategoryid == (int)CustomerCategory.积分专区 || shopcategoryid == (int)CustomerCategory.区代专区1 || shopcategoryid == (int)CustomerCategory.区代专区2 || shopcategoryid == (int)CustomerCategory.社区店铺专区1 || shopcategoryid == (int)CustomerCategory.社区店铺专区2 )
            //{
            //    TextBox1.ReadOnly = true;
            //    TextBox1.Text = "C0000001";
            //}

            //TextBox1.Visible = false;
            #endregion



            if (Page.Request.Cookies["PackAgeCookie"] != null)
            {
                HttpCookie cookie = Page.Request.Cookies["PackAgeCookie"];
                HttpCookie httpCookie = HttpSecureCookie.Decode(cookie);
                LabelSellName.Text = httpCookie.Values["ShopName"];
                LabelShopName.Text = httpCookie.Values["MemloginId"];
                hidSaleType.Value = "3";
                ProductGuid = httpCookie.Values["PackGuId"];


                shopProductEdit = shop_Product_Action.GetShopProductEdit(ProductGuid, shopcategoryid);
                Shopid = LabelShopName.Text;
                lblTotal.Text = "组合套餐价";
                MYlabelscore_reduce_pv_cv = Convert.ToDecimal(shopProductEdit.Rows[0]["Score_pv_cv"]);
                #region
                ShangPinPrice = Convert.ToDecimal(shopProductEdit.Rows[0]["ShopPrice"]);
                //得到积分
                if ((Convert.ToDecimal(shopProductEdit.Rows[0]["Score_cv"]) + Convert.ToDecimal(shopProductEdit.Rows[0]["Score_pv_a"])) >= 0)
                {
                    MYlabelScore_pv_a = (Convert.ToDecimal(shopProductEdit.Rows[0]["Score_cv"]) + Convert.ToDecimal(shopProductEdit.Rows[0]["Score_pv_a"])) * Convert.ToDecimal(BuyNumber);
                }
                //可用积分
                if ((Convert.ToDecimal(shopProductEdit.Rows[0]["Score_cv"]) + Convert.ToDecimal(shopProductEdit.Rows[0]["Score_pv_a"])) < 0)
                {
                    MYlabelscore_reduce_pv_a = (Convert.ToDecimal(shopProductEdit.Rows[0]["Score_cv"]) + Convert.ToDecimal(shopProductEdit.Rows[0]["Score_pv_a"])) * Convert.ToDecimal(BuyNumber);
                }
                //得到红包
                if ((Convert.ToDecimal(shopProductEdit.Rows[0]["Score_max_hv"]) + Convert.ToDecimal(shopProductEdit.Rows[0]["Score_hv"])) >= 0)
                {
                    MYlabelScore_hv = (Convert.ToDecimal(shopProductEdit.Rows[0]["Score_max_hv"]) + Convert.ToDecimal(shopProductEdit.Rows[0]["Score_hv"])) * Convert.ToDecimal(BuyNumber);
                }
                //可用红包
                if ((Convert.ToDecimal(shopProductEdit.Rows[0]["Score_max_hv"]) + Convert.ToDecimal(shopProductEdit.Rows[0]["Score_hv"])) < 0)
                {
                    MYlabelscore_reduce_hv = (Convert.ToDecimal(shopProductEdit.Rows[0]["Score_max_hv"]) + Convert.ToDecimal(shopProductEdit.Rows[0]["Score_hv"])) * Convert.ToDecimal(BuyNumber);
                }

                #endregion
                MYlabelScore_dv = Convert.ToDecimal(shopProductEdit.Rows[0]["Score_dv"]) * Convert.ToDecimal(BuyNumber);
                MYlabelScore_pv_b = Convert.ToDecimal(shopProductEdit.Rows[0]["Score_pv_b"]) * Convert.ToDecimal(BuyNumber);
                MYlabelAgentId = Convert.ToString(shopProductEdit.Rows[0]["agentId"]);

                labelScore_dv.Text = MYlabelScore_dv.ToString();
                labelScore_hv.Text = MYlabelScore_hv.ToString();
                labelScore_pv_a.Text = MYlabelScore_pv_a.ToString();
                labelScore_pv_b.Text = MYlabelScore_pv_b.ToString();
                labelAgentId.Text = MYlabelAgentId;
                labelScore_cv.Text = (MYlabelscore_reduce_pv_a * (-1)).ToString();
                labelScore_max_hv.Text = (MYlabelscore_reduce_hv * (-1)).ToString();


                shop_category_id = Convert.ToInt32(shopProductEdit.Rows[0]["shop_category_id"]);

            }
            else
            {

                shopProductEdit = shop_Product_Action.GetShopProductEdit(ProductGuid, shopcategoryid);
                MYlabelscore_reduce_pv_cv = Convert.ToDecimal(shopProductEdit.Rows[0]["Score_pv_cv"]);
                #region
                //得到积分
                ShangPinPrice = Convert.ToDecimal(shopProductEdit.Rows[0]["ShopPrice"]);
                if ((Convert.ToDecimal(shopProductEdit.Rows[0]["Score_cv"]) + Convert.ToDecimal(shopProductEdit.Rows[0]["Score_pv_a"])) >= 0)
                {
                    MYlabelScore_pv_a = (Convert.ToDecimal(shopProductEdit.Rows[0]["Score_cv"]) + Convert.ToDecimal(shopProductEdit.Rows[0]["Score_pv_a"])) * Convert.ToDecimal(BuyNumber);
                }
                //可用积分
                if ((Convert.ToDecimal(shopProductEdit.Rows[0]["Score_cv"]) + Convert.ToDecimal(shopProductEdit.Rows[0]["Score_pv_a"])) < 0)
                {
                    MYlabelscore_reduce_pv_a = (Convert.ToDecimal(shopProductEdit.Rows[0]["Score_cv"]) + Convert.ToDecimal(shopProductEdit.Rows[0]["Score_pv_a"])) * Convert.ToDecimal(BuyNumber);
                }
                //得到红包
                if ((Convert.ToDecimal(shopProductEdit.Rows[0]["Score_max_hv"]) + Convert.ToDecimal(shopProductEdit.Rows[0]["Score_hv"])) >= 0)
                {
                    MYlabelScore_hv = (Convert.ToDecimal(shopProductEdit.Rows[0]["Score_max_hv"]) + Convert.ToDecimal(shopProductEdit.Rows[0]["Score_hv"])) * Convert.ToDecimal(BuyNumber);
                }
                //可用红包
                if ((Convert.ToDecimal(shopProductEdit.Rows[0]["Score_max_hv"]) + Convert.ToDecimal(shopProductEdit.Rows[0]["Score_hv"])) < 0)
                {
                    MYlabelscore_reduce_hv = (Convert.ToDecimal(shopProductEdit.Rows[0]["Score_max_hv"]) + Convert.ToDecimal(shopProductEdit.Rows[0]["Score_hv"])) * Convert.ToDecimal(BuyNumber);
                }
                #endregion
                MYlabelScore_dv = Convert.ToDecimal(shopProductEdit.Rows[0]["Score_dv"]) * Convert.ToDecimal(BuyNumber);
                MYlabelScore_pv_b = Convert.ToDecimal(shopProductEdit.Rows[0]["Score_pv_b"]) * Convert.ToDecimal(BuyNumber);
                MYlabelAgentId = Convert.ToString(shopProductEdit.Rows[0]["agentId"]);

                labelScore_dv.Text = MYlabelScore_dv.ToString();
                labelScore_hv.Text = MYlabelScore_hv.ToString();
                labelScore_pv_a.Text = MYlabelScore_pv_a.ToString();
                labelScore_pv_b.Text = MYlabelScore_pv_b.ToString();
                if (Convert.ToDecimal(MYlabelScore_pv_a) != 0)
                {
                    label_pv_a_b_all.Text = MYlabelScore_pv_a.ToString();
                }
                else if (Convert.ToDecimal(MYlabelScore_pv_b) != 0)
                {
                    label_pv_a_b_all.Text = MYlabelScore_pv_b.ToString(); ;
                }
                else
                {
                    label_pv_a_b_all.Text = "0.00";
                }
                labelAgentId.Text = MYlabelAgentId;
                labelScore_cv.Text = (MYlabelscore_reduce_pv_a * (-1)).ToString();
                labelScore_max_hv.Text = (MYlabelscore_reduce_hv * (-1)).ToString();

                shop_category_id = Convert.ToInt32(shopProductEdit.Rows[0]["shop_category_id"]);
                /*   string Color = Page.Request.QueryString["Color"].ToString();
                   string Size = Page.Request.QueryString["Size"].ToString();
                   if (Color == "")
                   {
                       Color = "无";
                   }
                   else
                   {
                       Color = Page.Request.QueryString["Color"].ToString();
                   }
                   if (Size == "")
                   {
                       Size = "无";
                   }
                   else
                   {
                       Size = Page.Request.QueryString["Size"].ToString();
                   }
                   labelMyColor.Text = Color;
                   labelMySize.Text = Size;*/
                /* shop_category_id = Convert.ToInt32(shopProductEdit.Rows[0]["shop_category_id"]);*/


            }
            if (shopProductEdit != null || shopProductEdit.Rows.Count != 0)
            {
                LabelShopName.Text = shopProductEdit.Rows[0]["MemLoginID"].ToString();
                Shopid = shopProductEdit.Rows[0]["MemLoginID"].ToString();
                RepeaterShopProduct.DataSource = shopProductEdit.DefaultView;
                RepeaterShopProduct.DataBind();
                var shopNum1_ShopInfoList_Action =
                    (ShopNum1_ShopInfoList_Action)LogicFactory.CreateShopNum1_ShopInfoList_Action();
                DataTable editInfo = shopNum1_ShopInfoList_Action.GetEditInfo(Shopid);
                if (editInfo != null && editInfo.Rows.Count > 0)
                {
                    method_3(shopProductEdit);
                    method_4();
                }
                try
                {
                    IShop_Ensure_Action shop_Ensure_Action = ShopFactory.LogicFactory.CreateShop_Ensure_Action();
                    DataTable dataTable =
                        shop_Ensure_Action.SearchEnsureApply(shopProductEdit.Rows[0]["memloginId"].ToString());
                    for (int i = 0; i < RepeaterShopProduct.Items.Count; i++)
                    {
                        var label = (Label)RepeaterShopProduct.Items[i].FindControl("LabelProductService");
                        if (dataTable != null && dataTable.Rows.Count > 0)
                        {
                            for (int j = 0; j < dataTable.Rows.Count; j++)
                            {
                                var image = new Image();
                                image.ImageUrl = dataTable.Rows[j]["ImagePath"].ToString();
                                label.Controls.Add(image);
                            }
                        }
                        else
                        {
                            label.Text = "";
                        }
                    }
                }
                catch (Exception ex)
                {
                    Page.Response.Write(ex.Message);
                }
            }
        }

        protected void BindDataPayment()
        {
            var shopNum1_ShopPayment_Action =
                    (ShopNum1_ShopPayment_Action)LogicFactory.CreateShopNum1_ShopPayment_Action();
            IShopNum1_Payment_Action shopNum1_Payment_Action = LogicFactory.CreateShopNum1_Payment_Action();
            string CategoryId = Page.Request.QueryString["shopcategoryid"].ToString();
            if (CategoryId == "2" || CategoryId == "3" || CategoryId == "9")
            {

                DataTable dataTable = shopNum1_Payment_Action.SearchTwo(0);
                if (dataTable != null && dataTable.Rows.Count > 0)
                {

                    RepeaterShoppingCartPayment.DataSource = dataTable.DefaultView;
                    RepeaterShoppingCartPayment.DataBind();
                }
                foreach (RepeaterItem repeaterItem in RepeaterShoppingCartPayment.Items)
                {
                    var radioButton = (RadioButton)repeaterItem.FindControl("RadioButtonPayment");
                    radioButton.CheckedChanged += method_1;
                    var literal = (Literal)repeaterItem.FindControl("LiteralIsPersent");
                    var hiddenField = (HiddenField)repeaterItem.FindControl("HiddenFieldIsPersent");
                    if (hiddenField.Value == "1")
                    {
                        literal.Visible = true;
                    }
                }
                if (RepeaterShoppingCartPayment.Items.Count > 0)
                {
                    var radioButton = (RadioButton)RepeaterShoppingCartPayment.Items[0].FindControl("RadioButtonPayment");
                    radioButton.Checked = true;
                }

            }
            else
            {
                LogicFactory.CreateShopNum1_Cart_Action();
                string value = ShopSettings.GetValue("PayMentType");
                DataTable dataTable = null;

                string nameById = Common.Common.GetNameById("IsPayMentShop", "ShopNum1_ShopInfo",
                    "   AND  MemLoginID='" + Shopid + "'   ");
                if (nameById != "-1")
                {
                    if (nameById == "0")
                    {
                        string_2 = "admin";
                        dataTable = shopNum1_Payment_Action.Search(0);
                    }
                    else
                    {
                        if (nameById == "1")
                        {
                            string_2 = Shopid;
                            dataTable = shopNum1_ShopPayment_Action.Search(0, Shopid);
                        }
                    }
                }
                else
                {
                    if (value == "0")
                    {
                        string_2 = "admin";
                        dataTable = shopNum1_Payment_Action.Search(0);
                    }
                    else
                    {
                        if (value == "1")
                        {
                            string_2 = Shopid;
                            dataTable = shopNum1_ShopPayment_Action.Search(0, Shopid);
                        }
                        else
                        {
                            if (value == "2")
                            {
                                var shopNum1_ShopInfoList_Action =
                                    (ShopNum1_ShopInfoList_Action)LogicFactory.CreateShopNum1_ShopInfoList_Action();
                                string shopPayMentType = shopNum1_ShopInfoList_Action.GetShopPayMentType(Shopid);
                                if (shopPayMentType == "0")
                                {
                                    string_2 = "admin";
                                    dataTable = shopNum1_Payment_Action.Search(0);
                                }
                                else
                                {
                                    string_2 = Shopid;
                                    dataTable = shopNum1_ShopPayment_Action.Search(0, Shopid);
                                }
                            }
                        }
                    }
                }
                if (dataTable != null && dataTable.Rows.Count > 0)
                {

                    RepeaterShoppingCartPayment.DataSource = dataTable.DefaultView;
                    RepeaterShoppingCartPayment.DataBind();
                }
                foreach (RepeaterItem repeaterItem in RepeaterShoppingCartPayment.Items)
                {
                    var radioButton = (RadioButton)repeaterItem.FindControl("RadioButtonPayment");
                    radioButton.CheckedChanged += method_1;
                    var literal = (Literal)repeaterItem.FindControl("LiteralIsPersent");
                    var hiddenField = (HiddenField)repeaterItem.FindControl("HiddenFieldIsPersent");
                    if (hiddenField.Value == "1")
                    {
                        literal.Visible = true;
                    }
                }
                if (RepeaterShoppingCartPayment.Items.Count > 0)
                {
                    var radioButton = (RadioButton)RepeaterShoppingCartPayment.Items[0].FindControl("RadioButtonPayment");
                    radioButton.Checked = true;
                }
            }
        }

        protected void method_1(object sender, EventArgs e)
        {
            method_4();
        }

        protected void method_2(object sender, EventArgs e)
        {
            method_4();
        }

        protected void ButtonCreate_Click(object sender, EventArgs e)
        {


            #region 暂时处理订单服务区代
            HttpCookie cookieShopMemberLogin1 = HttpContext.Current.Request.Cookies["MemberLoginCookie"];
            HttpCookie decodedCookieShopMemberLogin1 = HttpSecureCookie.Decode(cookieShopMemberLogin1);
            //会员登录ID
            string MemberLoginID1 = decodedCookieShopMemberLogin1.Values["MemLoginID"];
            var memberrankguid_Action = (ShopNum1_Member_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Member_Action();
            //会员等级
            string memberGuid = memberrankguid_Action.GetCurrentMemberRankGuid(MemberLoginID1);
            int shopcategoryid = Convert.ToInt32(Page.Request.QueryString["shopcategoryid"]);
            if (RepeaterShopProduct.Items.Count != 0)
            {
                var member_Action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
                if (shopcategoryid == 2)
                {
                    DataTable tbc = member_Action.NewSearchAreaAgent(TextBox1.Text.Trim());


                    //if (TextBox1.Text == "")
                    //{
                    //    TextBox1.Text = "C0000001";
                    //}
                    //if (TextBox1.Text == "C0000001" && shopcategoryid == (int)CustomerCategory.大唐专区)
                    //{
                    //    TextBox1.Text = "C0000001";
                    //}
                    //if ((shopcategoryid == (int)CustomerCategory.VIP专区 || shopcategoryid == (int)CustomerCategory.BTC专区) && memberGuid != MemberLevel.NORMAL_MEMBER_ID && TextBox1.Text == "C0000001")
                    //{

                    //    TextBox1.Text = "C0000001";
                    //}
            #endregion
                    if (TextBox1.Text == ""||TextBox1.Text.ToUpper()=="C0000001")
                    {
                        TextBox1.Text = "C0000001";
                        #region
                        if (RepeaterShoppingCartPayment.Items == null || RepeaterShoppingCartPayment.Items.Count == 0)
                        {
                            MessageBox.Show("支付方式不能为空！");
                            BindData();
                        }
                        else
                        {


                            if (shopcategoryid == 4)
                            {
                                if ((ShangPinPrice * Convert.ToInt32(BuyNumber) + MYPostage) >= 219500 && (ShangPinPrice * Convert.ToInt32(BuyNumber) + MYPostage) <= 220500)
                                {
                                    HiddenFieldAllCartPrice.Value = "100000.00";
                                    BindData();
                                    CreatOrderInfo();
                                }
                                else
                                {
                                    MessageBox.Show("您报单的价格不符合标准，价格应该处于￥219500-￥220500之间！");
                                }
                            }
                            else if (shopcategoryid == 6)
                            {
                                if ((ShangPinPrice * Convert.ToInt32(BuyNumber) + MYPostage) >= 99700 && (ShangPinPrice * Convert.ToInt32(BuyNumber) + MYPostage) <= 100300)
                                {
                                    HiddenFieldAllCartPrice.Value = "50000.00";
                                    BindData();
                                    CreatOrderInfo();

                                }
                                else
                                {
                                    MessageBox.Show("您报单的价格不符合标准，价格应该处于￥99700-￥100300之间！");
                                }
                            }
                            else
                            {

                                CreatOrderInfo();
                            }
                        }
                        #endregion
                    }

                    else if (tbc.Rows.Count > 0)
                    {
                        //DataTable tbc = member_Action.SearchAreaAgentExist(TextBox1.Text);
                        if (tbc.Rows[0]["IsFuwuzhan"].ToString() == "1")
                        {
                            #region 坑死爹
                            //DataTable memtable = member_Action.SearchMembertwo(MemberLoginID1);
                            //string tjr = memtable.Rows[0]["Superior"].ToString();
                            //if (tjr != null && tjr != "")
                            //{
                            //    ShopNum1_OrderInfo_Action orderAction = (ShopNum1_OrderInfo_Action)LogicFactory.CreateShopNum1_OrderInfo_Action();
                            //    DataTable memOrder = orderAction.GetOrderLastInfoIsMy(MemberLoginID1);
                            //    decimal GeneralPV = 0M;
                            //    foreach (DataRow dr in memOrder.Rows)
                            //    {
                            //        GeneralPV += Convert.ToDecimal(dr["Score_pv_a"]);

                            //    }
                            //    if (GeneralPV > 300)
                            //    {
                            //        #region
                            //        if (RepeaterShoppingCartPayment.Items == null || RepeaterShoppingCartPayment.Items.Count == 0)
                            //        {
                            //            MessageBox.Show("支付方式不能为空！");
                            //            BindData();
                            //        }
                            //        else
                            //        {


                            //            if (shopcategoryid == 4)
                            //            {
                            //                if ((ShangPinPrice * Convert.ToInt32(BuyNumber) + MYPostage) >= 105700 && (ShangPinPrice * Convert.ToInt32(BuyNumber) + MYPostage) <= 106300)
                            //                {
                            //                    HiddenFieldAllCartPrice.Value = "48000.00";
                            //                    BindData();
                            //                    CreatOrderInfo();
                            //                }
                            //                else
                            //                {
                            //                    MessageBox.Show("您报单的价格不符合标准，价格应该处于￥105700-￥106300之间！");
                            //                }
                            //            }
                            //            else if (shopcategoryid == 6)
                            //            {
                            //                if ((ShangPinPrice * Convert.ToInt32(BuyNumber) + MYPostage) >= 35900 && (ShangPinPrice * Convert.ToInt32(BuyNumber) + MYPostage) <= 36100)
                            //                {
                            //                    HiddenFieldAllCartPrice.Value = "18000.00";
                            //                    BindData();
                            //                    CreatOrderInfo();

                            //                }
                            //                else
                            //                {
                            //                    MessageBox.Show("您报单的价格不符合标准，价格应该处于￥35900-￥36100之间！");
                            //                }
                            //            }
                            //            else
                            //            {
                            //                BindData();
                            //                CreatOrderInfo();
                            //            }
                            //        }
                            //        #endregion
                            //    }
                            //    else
                            //    {
                            //        if (memberGuid.ToUpper() == MemberLevel.NORMAL_Regular_Members.ToUpper())
                            //        {
                            //            if (shopcategoryid != 1)
                            //            {
                            //                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", "alert(\"您的账号首单购买必须为大唐专区,并且满足300积分！\")", true);
                            //                BindData();
                            //            }
                            //            else
                            //            {
                            //                #region
                            //                if (RepeaterShoppingCartPayment.Items == null || RepeaterShoppingCartPayment.Items.Count == 0)
                            //                {
                            //                    MessageBox.Show("支付方式不能为空！");
                            //                    BindData();
                            //                }
                            //                else
                            //                {


                            //                    if (shopcategoryid == 4)
                            //                    {
                            //                        if ((ShangPinPrice * Convert.ToInt32(BuyNumber) + MYPostage) >= 105700 && (ShangPinPrice * Convert.ToInt32(BuyNumber) + MYPostage) <= 106300)
                            //                        {
                            //                            HiddenFieldAllCartPrice.Value = "48000.00";
                            //                            BindData();
                            //                            CreatOrderInfo();
                            //                        }
                            //                        else
                            //                        {
                            //                            MessageBox.Show("您报单的价格不符合标准，价格应该处于￥105700-￥106300之间！");
                            //                        }
                            //                    }
                            //                    else if (shopcategoryid == 6)
                            //                    {
                            //                        if ((ShangPinPrice * Convert.ToInt32(BuyNumber) + MYPostage) >= 35900 && (ShangPinPrice * Convert.ToInt32(BuyNumber) + MYPostage) <= 36100)
                            //                        {
                            //                            HiddenFieldAllCartPrice.Value = "18000.00";
                            //                            BindData();
                            //                            CreatOrderInfo();

                            //                        }
                            //                        else
                            //                        {
                            //                            MessageBox.Show("您报单的价格不符合标准，价格应该处于￥35900-￥36100之间！");
                            //                        }
                            //                    }
                            //                    else
                            //                    {
                            //                        BindData();
                            //                        CreatOrderInfo();
                            //                    }
                            //                }
                            //                #endregion
                            //            }
                            //        }
                            //        else
                            //        {
                            //            #region
                            //            if (RepeaterShoppingCartPayment.Items == null || RepeaterShoppingCartPayment.Items.Count == 0)
                            //            {
                            //                MessageBox.Show("支付方式不能为空！");
                            //                BindData();
                            //            }
                            //            else
                            //            {


                            //                if (shopcategoryid == 4)
                            //                {
                            //                    if ((ShangPinPrice * Convert.ToInt32(BuyNumber) + MYPostage) >= 105700 && (ShangPinPrice * Convert.ToInt32(BuyNumber) + MYPostage) <= 106300)
                            //                    {
                            //                        HiddenFieldAllCartPrice.Value = "48000.00";
                            //                        BindData();
                            //                        CreatOrderInfo();
                            //                    }
                            //                    else
                            //                    {
                            //                        MessageBox.Show("您报单的价格不符合标准，价格应该处于￥105700-￥106300之间！");
                            //                    }
                            //                }
                            //                else if (shopcategoryid == 6)
                            //                {
                            //                    if ((ShangPinPrice * Convert.ToInt32(BuyNumber) + MYPostage) >= 35900 && (ShangPinPrice * Convert.ToInt32(BuyNumber) + MYPostage) <= 36100)
                            //                    {
                            //                        HiddenFieldAllCartPrice.Value = "18000.00";
                            //                        BindData();
                            //                        CreatOrderInfo();

                            //                    }
                            //                    else
                            //                    {
                            //                        MessageBox.Show("您报单的价格不符合标准，价格应该处于￥35900-￥36100之间！");
                            //                    }
                            //                }
                            //                else
                            //                {
                            //                    BindData();
                            //                    CreatOrderInfo();
                            //                }
                            //            }
                            //            #endregion
                            //        }
                            //    }
                            //}
                            //else
                            //{
                            //    #region
                            //    if (RepeaterShoppingCartPayment.Items == null || RepeaterShoppingCartPayment.Items.Count == 0)
                            //    {
                            //        MessageBox.Show("支付方式不能为空！");
                            //        BindData();
                            //    }
                            //    else
                            //    {


                            //        if (shopcategoryid == 4)
                            //        {
                            //            if ((ShangPinPrice * Convert.ToInt32(BuyNumber) + MYPostage) >= 105700 && (ShangPinPrice * Convert.ToInt32(BuyNumber) + MYPostage) <= 106300)
                            //            {
                            //                HiddenFieldAllCartPrice.Value = "48000.00";
                            //                BindData();
                            //                CreatOrderInfo();
                            //            }
                            //            else
                            //            {
                            //                MessageBox.Show("您报单的价格不符合标准，价格应该处于￥105700-￥106300之间！");
                            //            }
                            //        }
                            //        else if (shopcategoryid == 6)
                            //        {
                            //            if ((ShangPinPrice * Convert.ToInt32(BuyNumber) + MYPostage) >= 35900 && (ShangPinPrice * Convert.ToInt32(BuyNumber) + MYPostage) <= 36100)
                            //            {
                            //                HiddenFieldAllCartPrice.Value = "18000.00";
                            //                BindData();
                            //                CreatOrderInfo();

                            //            }
                            //            else
                            //            {
                            //                MessageBox.Show("您报单的价格不符合标准，价格应该处于￥35900-￥36100之间！");
                            //            }
                            //        }
                            //        else
                            //        {
                            //            BindData();
                            //            CreatOrderInfo();
                            //        }
                            //    }
                            //    #endregion
                            //}
                            #endregion
                            #region
                            if (RepeaterShoppingCartPayment.Items == null || RepeaterShoppingCartPayment.Items.Count == 0)
                            {
                                MessageBox.Show("支付方式不能为空！");
                                BindData();
                            }
                            else
                            {


                                if (shopcategoryid == 4)
                                {
                                    if ((ShangPinPrice * Convert.ToInt32(BuyNumber) + MYPostage) >= 219500 && (ShangPinPrice * Convert.ToInt32(BuyNumber) + MYPostage) <= 220500)
                                    {
                                        HiddenFieldAllCartPrice.Value = "100000.00";
                                        BindData();
                                        CreatOrderInfo();
                                    }
                                    else
                                    {
                                        MessageBox.Show("您报单的价格不符合标准，价格应该处于￥219500-￥220500之间！");
                                    }
                                }
                                else if (shopcategoryid == 6)
                                {
                                    if ((ShangPinPrice * Convert.ToInt32(BuyNumber) + MYPostage) >= 99700 && (ShangPinPrice * Convert.ToInt32(BuyNumber) + MYPostage) <= 100300)
                                    {
                                        HiddenFieldAllCartPrice.Value = "50000.00";
                                        BindData();
                                        CreatOrderInfo();

                                    }
                                    else
                                    {
                                        MessageBox.Show("您报单的价格不符合标准，价格应该处于￥99700-￥100300之间！");
                                    }
                                }
                                else
                                {

                                    CreatOrderInfo();
                                }
                            }
                            #endregion
                        }
                        else
                        {
                            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", "alert(\"服务代理错误！\")", true);

                            BindData();
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", "alert(\"服务代理不存在！\")", true);

                        BindData();
                    }
                }
                else
                {
                    TextBox1.Text = "C0000001";
                    #region
                    if (RepeaterShoppingCartPayment.Items == null || RepeaterShoppingCartPayment.Items.Count == 0)
                    {
                        MessageBox.Show("支付方式不能为空！");
                        BindData();
                    }
                    else
                    {


                        if (shopcategoryid == 4)
                        {
                            if ((ShangPinPrice * Convert.ToInt32(BuyNumber) + MYPostage) >= 219500 && (ShangPinPrice * Convert.ToInt32(BuyNumber) + MYPostage) <= 220500)
                            {
                                HiddenFieldAllCartPrice.Value = "100000.00";
                                BindData();
                                CreatOrderInfo();
                            }
                            else
                            {
                                MessageBox.Show("您报单的价格不符合标准，价格应该处于￥219500-￥220500之间！");
                            }
                        }
                        else if (shopcategoryid == 6)
                        {
                            if ((ShangPinPrice * Convert.ToInt32(BuyNumber) + MYPostage) >= 99700 && (ShangPinPrice * Convert.ToInt32(BuyNumber) + MYPostage) <= 100300)
                            {
                                HiddenFieldAllCartPrice.Value = "50000.00";
                                BindData();
                                CreatOrderInfo();

                            }
                            else
                            {
                                MessageBox.Show("您报单的价格不符合标准，价格应该处于￥99700-￥100300之间！");
                            }
                        }
                        else
                        {

                            CreatOrderInfo();
                        }
                    }
                    #endregion
                }

            }
        }
        protected void CreatOrderInfo()
        {
            #region 添加订单
            method_5();
            ShopNum1_Member_Action member_Action = (ShopNum1_Member_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Member_Action();

            DataTable tableTJ = member_Action.SearchMembertwo(strMemLoginID);



            var shopNum1_OrderInfo = new ShopNum1_OrderInfo();
            shopNum1_OrderInfo.MemLoginID = strMemLoginID;

            shopNum1_OrderInfo.SuperiorRank = new Guid("00000000-0000-0000-0000-000000000000");
            shopNum1_OrderInfo.Guid = Guid.NewGuid();
            var order = new Order();
            shopNum1_OrderInfo.OrderNumber = order.CreateOrderNumberDD(strMemLoginID);
            shopNum1_OrderInfo.TradeID = shopNum1_OrderInfo.OrderNumber;
            shopNum1_OrderInfo.ShipmentStatus = 0;
            shopNum1_OrderInfo.PaymentStatus = 0;
            shopNum1_OrderInfo.PayMentMemLoginID = string_2;
            shopNum1_OrderInfo.OrderType = Convert.ToByte(hidSaleType.Value);


            shopNum1_OrderInfo.Score_dv = 0;

            shopNum1_OrderInfo.Score_hv = MYlabelScore_hv;


            shopNum1_OrderInfo.score_reduce_hv = MYlabelscore_reduce_hv;


            shopNum1_OrderInfo.Score_pv_a = MYlabelScore_pv_a;

            shopNum1_OrderInfo.score_reduce_pv_a = MYlabelscore_reduce_pv_a;

            shopNum1_OrderInfo.Score_pv_b = MYlabelScore_pv_b;

            shopNum1_OrderInfo.Score_cv = MYlabelScore_cv;
            shopNum1_OrderInfo.Score_max_hv = MYlabelScore_max_hv;
            shopNum1_OrderInfo.shop_category_id = shop_category_id;
            shopNum1_OrderInfo.AgentId = MYlabelAgentId;
            shopNum1_OrderInfo.ServiceAgent = TextBox1.Text.Trim();
            shopNum1_OrderInfo.score_pv_cv = MYlabelscore_reduce_pv_cv;

            string Color = Page.Request.QueryString["Color"].ToString();
            string Size = Page.Request.QueryString["Size"].ToString();
            if (Color == "")
            {
                Color = "无";
            }
            else
            {
                Color = Page.Request.QueryString["Color"].ToString();
            }
            if (Size == "")
            {
                Size = "无";
            }
            else
            {
                Size = Page.Request.QueryString["Size"].ToString();
            }


            if (HiddenFieldAddressGuid.Value == "-1" && Page.Request.Cookies["MemberLoginCookie"] != null)
            {
                if (TextBoxName.Text == "" || HiddenFieldAddressName.Value == "-1" || TextBoxAddress.Text == "" || TextBoxMobile.Text == "")
                {

                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "msg",
                  "alert(\"收货地址信息不完整!\");window.location.href='/default.aspx';", true);
                    return;
                }

                shopNum1_OrderInfo.Name = TextBoxName.Text.Trim();
                shopNum1_OrderInfo.Email = TextBoxEmail.Text.Trim();
                shopNum1_OrderInfo.Address = HiddenFieldAddressName.Value + "  " + TextBoxAddress.Text.Trim();
                shopNum1_OrderInfo.Postalcode = TextBoxPostalcode.Text.Trim();
                shopNum1_OrderInfo.Tel = TextBoxTel.Text;
                shopNum1_OrderInfo.Mobile = TextBoxMobile.Text.Trim();
                var shopNum1_Address = new ShopNum1_Address();
                shopNum1_Address.Name = TextBoxName.Text.Trim();
                shopNum1_Address.Email = TextBoxEmail.Text.Trim();
                shopNum1_Address.Address = HiddenFieldAddressName.Value + "  " + TextBoxAddress.Text.Trim();
                shopNum1_Address.AddressValue = HiddenFieldAddressName.Value;
                shopNum1_Address.Area = HiddenFieldAddressName.Value;
                shopNum1_Address.Postalcode = TextBoxPostalcode.Text.Trim();
                shopNum1_Address.Tel = TextBoxTel.Text;
                shopNum1_Address.Mobile = TextBoxMobile.Text;
                shopNum1_Address.Guid = Guid.NewGuid();
                shopNum1_Address.MemLoginID = strMemLoginID;
                shopNum1_Address.CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                shopNum1_Address.ModifyTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));


                shopNum1_Address.IsDeleted = 0;
                shopNum1_Address.IsDefault = 1;
                if (shopNum1_OrderInfo.Mobile != "" &&
                    shopNum1_OrderInfo.Address.Replace(",", "").Trim() != "-1")
                {
                    IShopNum1_Address_Action shopNum1_Address_Action =
                        LogicFactory.CreateShopNum1_Address_Action();
                    shopNum1_Address_Action.Add(shopNum1_Address);
                    Thread.Sleep(100);
                }
                else
                {
                    shopNum1_OrderInfo.Address = "";
                }
            }
            else
            {
                var shopNum1_Address_Action2 =
                    (ShopNum1_Address_Action)LogicFactory.CreateShopNum1_Address_Action();
                DataTable dataTable = shopNum1_Address_Action2.Search(HiddenFieldAddressGuid.Value);
                shopNum1_OrderInfo.Name = dataTable.Rows[0]["Name"].ToString();
                shopNum1_OrderInfo.Email = dataTable.Rows[0]["Email"].ToString();
                shopNum1_OrderInfo.Address = dataTable.Rows[0]["area"] + " " + dataTable.Rows[0]["Address"];
                shopNum1_OrderInfo.Postalcode = dataTable.Rows[0]["Postalcode"].ToString();
                shopNum1_OrderInfo.Tel = dataTable.Rows[0]["Tel"].ToString();
                shopNum1_OrderInfo.Mobile = dataTable.Rows[0]["Mobile"].ToString();
                Thread.Sleep(100);
            }
            shopNum1_OrderInfo.ClientToSellerMsg = TextBoxMessage.Text.Trim();
            if (shopNum1_OrderInfo.ServiceAgent != "" && shopNum1_OrderInfo.ServiceAgent != "C0000001")
            {
                shopNum1_OrderInfo.DispatchType = 0;
                shopNum1_OrderInfo.FeeType = 1;
                shopNum1_OrderInfo.DispatchPrice = Convert.ToDecimal(0.0);
                shopNum1_OrderInfo.ShouldPayPrice = (ShangPinPrice * Convert.ToInt32(BuyNumber));
            }
            else
            {
                #region 邮费
                if (DropDownListPost.SelectedValue.Split(new[]
                    {
                        ':'
                    })[1] == "-2")
                {
                    shopNum1_OrderInfo.DispatchType = 0;
                    shopNum1_OrderInfo.FeeType = 1;
                    shopNum1_OrderInfo.DispatchPrice = Convert.ToDecimal(0.0);
                    shopNum1_OrderInfo.ShouldPayPrice = (ShangPinPrice * Convert.ToInt32(BuyNumber));
                }
                else if (DropDownListPost.SelectedValue.Split(new[]
                            {
                                ':'
                            })[1] == "-3")
                {
                    shopNum1_OrderInfo.DispatchType = 0;
                    shopNum1_OrderInfo.FeeType = 1;
                    shopNum1_OrderInfo.DispatchPrice = 40;
                    shopNum1_OrderInfo.ShouldPayPrice = (ShangPinPrice * Convert.ToInt32(BuyNumber)) + 40;
                }
                else if (DropDownListPost.SelectedValue.Split(new[]
                            {
                                ':'
                            })[1] == "4")
                {
                    shopNum1_OrderInfo.DispatchType = 0;
                    shopNum1_OrderInfo.FeeType = 1;
                    shopNum1_OrderInfo.DispatchPrice = MYPostage;
                    shopNum1_OrderInfo.ShouldPayPrice = (ShangPinPrice * Convert.ToInt32(BuyNumber)) + MYPostage;
                }
                else if (DropDownListPost.SelectedValue.Split(new[]
                            {
                                ':'

                            })[1] == "5")
                {
                    shopNum1_OrderInfo.DispatchType = 0;
                    shopNum1_OrderInfo.FeeType = 1;
                    shopNum1_OrderInfo.DispatchPrice = WLPostage;
                    shopNum1_OrderInfo.ShouldPayPrice = (ShangPinPrice * Convert.ToInt32(BuyNumber)) + WLPostage;
                }
                else if (DropDownListPost.SelectedValue.Split(new[]
                            {
                                ':'
                            })[1] == "6")
                {
                    shopNum1_OrderInfo.DispatchType = 0;
                    shopNum1_OrderInfo.FeeType = 1;
                    shopNum1_OrderInfo.DispatchPrice = VIPPostage;
                    shopNum1_OrderInfo.ShouldPayPrice = (ShangPinPrice * Convert.ToInt32(BuyNumber)) + VIPPostage;

                }
                #region
                else
                {
                    shopNum1_OrderInfo.FeeType = 0;
                    shopNum1_OrderInfo.DispatchType = int.Parse(DropDownListPost.SelectedValue.Split(new[]
                        {
                            ':'
                        })[1]);
                    if (DropDownListPost.SelectedValue.Split(new[]
                        {
                            ':'
                        })[1] == "-1")
                    {
                        shopNum1_OrderInfo.FeeType = 2;
                    }
                    shopNum1_OrderInfo.DispatchPrice = Convert.ToDecimal(DropDownListPost.SelectedValue.Split(new[]
                        {
                            ':'
                        })[0]);
                }
                #endregion
                if (DropDownListPost.SelectedValue.Split(new[]
                    {
                        ':'
                    })[1] == "-1")
                {
                    shopNum1_OrderInfo.FeeType = 2;
                    shopNum1_OrderInfo.DispatchType = -1;
                    shopNum1_OrderInfo.IsMinus = 1;
                }
                else
                {
                    shopNum1_OrderInfo.IsMinus = 0;
                }
                #endregion
            }
            //shopNum1_OrderInfo.DispatchPrice = Convert.ToDecimal(HiddenFieldDispatchPrice.Value);
            if (RadioButtonListInvoice.SelectedValue == "0")
            {
                shopNum1_OrderInfo.InvoiceTitle = TextBoxInvoicespayable.Text;
                shopNum1_OrderInfo.InvoiceContent = TextBoxInvoice.Text;
                shopNum1_OrderInfo.InvoiceType = "";
                shopNum1_OrderInfo.InvoiceTax = 0m;
            }
            else
            {
                shopNum1_OrderInfo.InvoiceTitle = "";
                shopNum1_OrderInfo.InvoiceContent = "";
                shopNum1_OrderInfo.InvoiceType = "";
                shopNum1_OrderInfo.InvoiceTax = 0m;
            }
            shopNum1_OrderInfo.PaymentGuid = new Guid(HiddenFieldPaymentGuid.Value.ToUpper());
            if (HiddenFieldPaymentName.Value == "货到付款" || HiddenFieldPaymentName.Value.IndexOf("线下") != -1 ||
                shopNum1_OrderInfo.PaymentGuid == new Guid("ACB3A3BD-3229-436D-90DD-001B9C29AF9A") ||
                shopNum1_OrderInfo.PaymentGuid == new Guid("9ECA37CE-91C3-4D0C-8EFC-48D37A586D57") ||
                shopNum1_OrderInfo.PaymentGuid == new Guid("D2038EF7-7466-412F-AB4C-773EADB7FFFA") ||
                shopNum1_OrderInfo.PaymentGuid == new Guid("ACB3A3BD-3229-436D-90DD-001B9C29AF9A"))
            {
                shopNum1_OrderInfo.OderStatus = 1;
            }
            else
            {
                shopNum1_OrderInfo.OderStatus = 0;
            }
            shopNum1_OrderInfo.PaymentName = HiddenFieldPaymentName.Value;
            shopNum1_OrderInfo.PaymentPrice = Convert.ToDecimal("0.00");
            shopNum1_OrderInfo.SellerToClientMsg = "";
            shopNum1_OrderInfo.ReceivedDays = int.Parse(ShopSettings.GetValue("DefaultReceivedDays"));
            shopNum1_OrderInfo.IsMemdelay = 0;
            shopNum1_OrderInfo.OutOfStockOperate = "";
            shopNum1_OrderInfo.PackGuid = Guid.NewGuid();
            shopNum1_OrderInfo.PackName = "";
            shopNum1_OrderInfo.PackPrice = 0m;
            shopNum1_OrderInfo.BlessCardGuid = Guid.NewGuid();
            shopNum1_OrderInfo.BlessCardName = "";
            shopNum1_OrderInfo.BlessCardPrice = 0m;
            shopNum1_OrderInfo.BlessCardContent = "";
            shopNum1_OrderInfo.ProductPrice = Convert.ToDecimal(hidPrice.Value) * Convert.ToDecimal(BuyNumber);
            shopNum1_OrderInfo.ProductPv_b = MYlabelScore_pv_b;
            shopNum1_OrderInfo.AlreadPayPrice = 0m;
            shopNum1_OrderInfo.SurplusPrice = 0m;
            shopNum1_OrderInfo.UseScore = 0;
            shopNum1_OrderInfo.ScorePrice = 0m;

            shopNum1_OrderInfo.JoinActiveType = -1;
            shopNum1_OrderInfo.FromAd = Guid.NewGuid();
            shopNum1_OrderInfo.FromUrl = string.Empty;
            shopNum1_OrderInfo.PayTime = null;
            shopNum1_OrderInfo.DispatchTime = null;
            shopNum1_OrderInfo.ShipmentNumber = string.Empty;
            shopNum1_OrderInfo.CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            shopNum1_OrderInfo.ConfirmTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            shopNum1_OrderInfo.PayMemo = "";
            shopNum1_OrderInfo.ActivityGuid = Guid.NewGuid();
            shopNum1_OrderInfo.BuyType = "";
            shopNum1_OrderInfo.Discount = 0m;
            shopNum1_OrderInfo.Deposit = 0m;
            shopNum1_OrderInfo.JoinActiveType = 0;
            shopNum1_OrderInfo.ActvieContent = "";
            shopNum1_OrderInfo.UsedFavourTicket = "";
            string text = string.Empty;
            if (shopNum1_OrderInfo.FeeType == 2)
            {
                var random = new Random();
                for (int i = 1; i < 7; i++)
                {
                    text += random.Next(1, 9).ToString();
                }
            }
            shopNum1_OrderInfo.IdentifyCode = text;
            string value = ShopSettings.GetValue("IsRecommendCommisionOpen");
            if (value == "true")
            {
                ShopSettings.GetValue("RecommendCommision");
                double num = Convert.ToDouble(ShopSettings.GetValue("RecommendCommision")) / 100.0;
                shopNum1_OrderInfo.RecommendCommision =
                    Convert.ToDecimal(Convert.ToDouble(HiddenFieldAllCartPrice.Value) * num);
            }
            else
            {
                shopNum1_OrderInfo.RecommendCommision = 0m;
            }
            if (HiddenFieldAddressGuid.Value != "-1")
            {
                shopNum1_OrderInfo.RegionCode = HiddenFieldAddressCode.Value;
            }
            else
            {
                shopNum1_OrderInfo.RegionCode = HiddenFieldAddressCode.Value;
                HiddenFieldAddressCode.Value = shopNum1_OrderInfo.RegionCode;
            }
            var shop_Product_Action = (Shop_Product_Action)ShopFactory.LogicFactory.CreateShop_Product_Action();
            DataTable dataTable2;
            if (Page.Request.Cookies["PackAgeCookie"] != null)
            {
                dataTable2 = shop_Product_Action.SearchProductShopByGuid_two(ProductGuid, shop_category_id);
            }
            else
            {
                dataTable2 = shop_Product_Action.SearchProductShopByGuid_two(ProductGuid, shop_category_id);
            }
            shopNum1_OrderInfo.ShopID = dataTable2.Rows[0]["MemLoginID"].ToString();
            DataTable shopnametable = shop_Product_Action.SelectShopInfoName(shopNum1_OrderInfo.ShopID);
            shopNum1_OrderInfo.ShopName = shopnametable.Rows[0]["ShopName"].ToString();
            var list = new List<ShopNum1_OrderProduct>();
            //修改钱和积分等
            foreach (RepeaterItem repeaterItem in RepeaterShopProduct.Items)
            {
                var hiddenField = (HiddenField)repeaterItem.FindControl("HiddenFieldGuid");
                var image = (Image)repeaterItem.FindControl("ImageProductPic");
                var label = repeaterItem.FindControl("lbProductName") as Label;
                var shopNum1_OrderProduct = new ShopNum1_OrderProduct();
                var textBox = (TextBox)repeaterItem.FindControl("TextBoxBuyNumber");
                //if (shopNum1_OrderInfo.ServiceAgent != "" && shopNum1_OrderInfo.ServiceAgent.ToUpper() != "C0000001")
                //{
                //    shopNum1_OrderProduct.BuyNumber = 0;
                //}
                //else
                //{
                shopNum1_OrderProduct.BuyNumber = int.Parse(textBox.Text);

                shopNum1_OrderProduct.shop_category_id = shop_category_id;
                shopNum1_OrderProduct.Guid = Guid.NewGuid();
                shopNum1_OrderProduct.OrderInfoGuid = shopNum1_OrderInfo.Guid.ToString();
                shopNum1_OrderProduct.ProductGuid = hiddenField.Value;
                LogicFactory.CreateShopNum1_Cart_Action();
                shopNum1_OrderProduct.GroupPrice = Convert.ToDecimal("0.00");
                shopNum1_OrderProduct.ProductName = label.Text;
                shopNum1_OrderProduct.RepertoryNumber =
                    dataTable2.Rows[repeaterItem.ItemIndex]["ProductNum"].ToString();
                var label2 = repeaterItem.FindControl("labelBuyPrice") as Label;
                shopNum1_OrderProduct.MarketPrice =
                    Convert.ToDecimal(dataTable2.Rows[repeaterItem.ItemIndex]["MarketPrice"].ToString());
                shopNum1_OrderProduct.ShopPrice = Convert.ToDecimal(label2.Text);
                shopNum1_OrderProduct.score_pv_cv = MYlabelscore_reduce_pv_cv;
                if (hidSaleType.Value != "3")
                {
                    shopNum1_OrderProduct.BuyPrice = Convert.ToDecimal(HiddenFieldAllCartPrice.Value);
                }
                else
                {
                    shopNum1_OrderProduct.BuyPrice = Convert.ToDecimal(label2.Text) *
                                                     Convert.ToInt32(shopNum1_OrderProduct.BuyNumber);
                }
                shopNum1_OrderProduct.ProductImg = image.ImageUrl;
                shopNum1_OrderProduct.OrderType = Convert.ToInt32(hidSaleType.Value);
                string nameById = Common.Common.GetNameById("memloginid", "shopnum1_orderinfo",
                    string.Concat(new[]
                            {
                                " And memloginid='",
                                strMemLoginID,
                                "' And ordertype=4 And Oderstatus>-1 And Oderstatus<4 And guid in(select orderinfoguid from shopnum1_orderproduct where productguid='",
                                shopNum1_OrderProduct.ProductGuid,
                                "' and MemloginID='",
                                strMemLoginID,
                                "' And ProductState=1)"
                            }));
                if (nameById != "")
                {
                    MessageBox.Show("很抱歉,抢购商品一个ID限购一件！^_^");
                    BindData();
                    return;
                }
                string nameById2 = Common.Common.GetNameById("repertorycount", "shopnum1_shop_product",
                    " And Guid='" + shopNum1_OrderProduct.ProductGuid + "'");
                if (nameById2 == "0")
                {
                    MessageBox.Show("很抱歉,商品太火爆了,库存不足,无法完成下面操作哟！^_^");
                    BindData();
                    return;
                }
                if (hidSaleType.Value == "1")
                {
                    string nameById3 = Common.Common.GetNameById("groupstock", "shopnum1_group_product",
                        " And ProductGuId='" + hiddenField.Value + "'");
                    if (nameById3 == "0" || nameById3 == "")
                    {
                        MessageBox.Show("很抱歉,商品太火爆了,库存不足,无法完成下面操作哟！^_^");
                        BindData();
                        return;
                    }
                }
                if (shopNum1_OrderInfo.FeeType == 2)
                {
                    string nameById4 = Common.Common.GetNameById("mobile", "shopnum1_member",
                        " and memloginid='" + strMemLoginID + "'");
                    if (nameById4 == "")
                    {
                        MessageBox.Show("您还未绑定手机号码,这样不能通过手机收到验证码了哟！^_^");
                        BindData();
                        return;
                    }
                    shopNum1_OrderInfo.Mobile = nameById4;
                }
                shopNum1_OrderProduct.Attributes =
                    dataTable2.Rows[repeaterItem.ItemIndex]["setStock"].ToString();
                shopNum1_OrderProduct.SpecificationName = HiddenFieldSName.Value;
                shopNum1_OrderProduct.SpecificationValue = HiddenFieldSValue.Value;
                shopNum1_OrderProduct.setStock = dataTable2.Rows[repeaterItem.ItemIndex]["setStock"].ToString();
                shopNum1_OrderProduct.IsShipment = 0;
                shopNum1_OrderProduct.IsReal =
                    Convert.ToInt32(dataTable2.Rows[repeaterItem.ItemIndex]["IsReal"].ToString());
                shopNum1_OrderProduct.ExtensionAttriutes = "";
                shopNum1_OrderProduct.IsJoinActivity = 0;
                shopNum1_OrderProduct.CreateTime =
                    Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                shopNum1_OrderProduct.DetailedSpecifications = "";
                shopNum1_OrderProduct.MemLoginID = strMemLoginID;
                shopNum1_OrderProduct.ShopID = dataTable2.Rows[repeaterItem.ItemIndex]["MemLoginID"].ToString();
                shopNum1_OrderProduct.Color = Color;
                shopNum1_OrderProduct.Size = Size;
                list.Add(shopNum1_OrderProduct);

                if (ShopSettings.GetValue("OrderToShopIsEmail") == "1")
                {
                    IsEmail(shopNum1_OrderInfo.Email, LabelShopName.Text, shopNum1_OrderInfo.OrderNumber,
                        strMemLoginID, shopNum1_OrderInfo.Tel, shopNum1_OrderProduct.ProductName,
                        shopNum1_OrderInfo.Mobile);
                }
                if (ShopSettings.GetValue("OrderToShopIsMMS") == "1")
                {
                    string nameById5 = Common.Common.GetNameById("Mobile", "ShopNum1_Member",
                        " and memloginId='" + LabelShopName.Text + "'");
                    IsMMS(nameById5, LabelShopName.Text, strMemLoginID, shopNum1_OrderInfo.Tel,
                        shopNum1_OrderInfo.OrderNumber, label.Text.Trim(), shopNum1_OrderInfo.Mobile);
                }
            }
            var shopNum1_OrderInfo_Action =
                (ShopNum1_OrderInfo_Action)LogicFactory.CreateShopNum1_OrderInfo_Action();
            string nameById42221 = Common.Common.GetNameById("mobile", "shopnum1_member",
                      " and memloginid='" + strMemLoginID + "'");
            int num2 = shopNum1_OrderInfo_Action.Add(shopNum1_OrderInfo, list);
            if (num2 > 0)
            {
                try
                {
                    if (ShopSettings.GetValue("OrderIsEmail") == "1")
                    {
                        IsEmail(shopNum1_OrderInfo.Guid.ToString(), shopNum1_OrderInfo.OrderNumber);
                    }
                    if (ShopSettings.GetValue("OrderIsMMS") == "1")
                    {
                        IsMMS(shopNum1_OrderInfo.OrderNumber, shopNum1_OrderInfo.MemLoginID,
                            nameById42221);
                    }
                }
                catch (Exception)
                {
                }
                Page.Response.Redirect(GetPageName.RetDomainUrl("ShoppingCart3", shopNum1_OrderInfo.TradeID,
                    "tradeid"));
            }

            else
            {
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", "alert(\"购买失败！\")", true);
            }
            #endregion
        }
        protected void method_3(DataTable dt)
        {
            DropDownListPost.Items.Clear();
            string path = Shop_Common_Action.GetShopPath(LabelShopName.Text.Trim()) + "xml/PostageTemplate.xml";
            string regioncode = string.Empty;
            if (HiddenFieldAddressCode.Value == "-1")
            {
                regioncode = Common.Common.ReqStr("Code");
            }
            else
            {
                if (HiddenFieldAddressCode.Value.Length >= 3)
                {
                    regioncode = HiddenFieldAddressCode.Value.Substring(0, 3);
                }
                else
                {
                    regioncode = HiddenFieldAddressCode.Value;
                }
            }
            int num = 0;
            decimal num2 = Convert.ToDecimal(0.0);
            decimal num3 = Convert.ToDecimal(0.0);
            decimal num4 = Convert.ToDecimal(0.0);
            decimal num5 = Convert.ToDecimal(0.0);
            decimal Postage = Convert.ToDecimal(0.0);
            decimal HDFK = Convert.ToDecimal(1.1);
            decimal VIPYF = Convert.ToDecimal(1.2);
            MYPostage = Convert.ToDecimal(0.0);
            WLPostage = Convert.ToDecimal(0.0);
            VIPPostage = Convert.ToDecimal(0.0);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (!string.IsNullOrEmpty(dt.Rows[i]["GoodsWeight"].ToString()))
                {
                    num5 += Convert.ToDecimal(dt.Rows[i]["GoodsWeight"].ToString()) * Convert.ToDecimal(BuyNumber);
                }


                #region 旧邮费逻辑
            //if (dt.Rows[i]["FeeType"].ToString() != "1")
            //{
            //    num = 1;
            //    if (dt.Rows[i]["FeeTemplateID"] != null && dt.Rows[i]["FeeTemplateID"].ToString() != "" &&
            //        dt.Rows[i]["FeeTemplateID"].ToString() != "0")
            //    {
            //        HiddenFieldFeeTemplateID.Value = dt.Rows[i]["FeeTemplateID"].ToString();
            //        var shop_FeeTemplate_Action = new Shop_FeeTemplate_Action();
            //        DataTable feesByFrontCache =
            //            shop_FeeTemplate_Action.GetFeesByFrontCache(HttpContext.Current.Server.MapPath(path), "-1",
            //                (dt.Rows[i]["FeeTemplateID"].ToString().Length > 1)
            //                    ? ("'" + dt.Rows[i]["FeeTemplateID"] + "'")
            //                    : dt.Rows[i]["FeeTemplateID"].ToString(), regioncode, "-1", false);
            //        if (feesByFrontCache != null)
            //        {
            //            IEnumerator enumerator = feesByFrontCache.Rows.GetEnumerator();
            //            try
            //            {
            //                while (enumerator.MoveNext())
            //                {
            //                    var dataRow = (DataRow)enumerator.Current;
            //                    decimal d = Convert.ToDecimal(dataRow["fee"].ToString()) +
            //                                (int.Parse(BuyNumber) - 1) *
            //                                Convert.ToDecimal(dataRow["oneadd"].ToString());
            //                    if (dataRow["feetype"].ToString() == "1")
            //                    {
            //                        num2 += d;
            //                    }
            //                    else
            //                    {
            //                        if (dataRow["feetype"].ToString() == "2")
            //                        {
            //                            num3 += d;
            //                        }
            //                        else
            //                        {
            //                            if (dataRow["feetype"].ToString() == "3")
            //                            {
            //                                num4 += d;
            //                            }
            //                        }
            //                    }
            //                }
            //                goto IL_518;
            //            }
            //            finally
            //            {
            //                var disposable = enumerator as IDisposable;
            //                if (disposable != null)
            //                {
            //                    disposable.Dispose();
            //                }
            //            }
            //        }
            //        if (!string.IsNullOrEmpty(dt.Rows[i]["Post_fee"].ToString()))
            //        {
            //            num2 += Convert.ToDecimal(dt.Rows[i]["Post_fee"].ToString());
            //        }
            //        if (!string.IsNullOrEmpty(dt.Rows[i]["Express_fee"].ToString()))
            //        {
            //            num3 += Convert.ToDecimal(dt.Rows[i]["Express_fee"].ToString());
            //        }
            //        if (!string.IsNullOrEmpty(dt.Rows[i]["Ems_fee"].ToString()))
            //        {
            //            num4 += Convert.ToDecimal(dt.Rows[i]["Ems_fee"].ToString());
            //        }
            //    }
            //    else
            //    {
            //        if (!string.IsNullOrEmpty(dt.Rows[i]["Post_fee"].ToString()))
            //        {
            //            num2 += Convert.ToDecimal(dt.Rows[i]["Post_fee"].ToString());
            //        }
            //        if (!string.IsNullOrEmpty(dt.Rows[i]["Express_fee"].ToString()))
            //        {
            //            num3 += Convert.ToDecimal(dt.Rows[i]["Express_fee"].ToString());
            //        }
            //        if (!string.IsNullOrEmpty(dt.Rows[i]["Ems_fee"].ToString()))
            //        {
            //            num4 += Convert.ToDecimal(dt.Rows[i]["Ems_fee"].ToString());
            //        }
            //    }
            //}
                #endregion
            IL_518:
                ;
            }
            if (Convert.ToInt32(dt.Rows[0]["shop_category_id"]) == 2 || Convert.ToInt32(dt.Rows[0]["shop_category_id"]) == 5 || Convert.ToInt32(dt.Rows[0]["shop_category_id"]) == 7 || Convert.ToInt32(dt.Rows[0]["shop_category_id"]) == 9)
            {
                string memberid = dt.Rows[0]["MemLoginID"].ToString();
                ShopNum1_PostageSettings_Action PostageAction = (ShopNum1_PostageSettings_Action)LogicFactory.CreateShopNum1_PostageSettings_Action();
                DataTable table = PostageAction.SelectPrice(memberid);
                if (num5 != 0 && (num5 < Convert.ToDecimal(table.Rows[0]["FirstHeavy"]) || num5 == Convert.ToDecimal(table.Rows[0]["FirstHeavy"])))
                {
                    Postage = Convert.ToDecimal(table.Rows[0]["FirstHeavyPrice"]);
                    num = 1;
                    MYPostage = Postage;

                    if (Convert.ToInt32(dt.Rows[0]["shop_category_id"]) == 5 || Convert.ToInt32(dt.Rows[0]["shop_category_id"]) == 7)
                    {
                        if (ShangPinPrice * Convert.ToInt32(BuyNumber) >= 3000)
                        {
                            Postage = 0;
                            num = 0;
                            MYPostage = Postage;
                        }
                        else
                        {
                            Postage = Convert.ToDecimal(table.Rows[0]["FirstHeavyPrice"]);
                            num = 1;
                            MYPostage = Postage;
                            HDFK = 0;
                            WLPostage = 0;
                        }
                    }
                    if (Convert.ToInt32(dt.Rows[0]["shop_category_id"]) == 2)
                    {
                        if (ShangPinPrice * Convert.ToInt32(BuyNumber) >= 10000)
                        {
                            VIPPostage = 0;
                            num = 0;
                            Postage = 0;
                            VIPYF = 1;
                        }
                        else
                        {
                            VIPPostage = decimal.Multiply(ShangPinPrice * Convert.ToInt32(BuyNumber), (decimal)0.01);
                            if (VIPPostage < 10)
                            {
                                VIPPostage = 10M;
                            }
                            num = 0;
                            Postage = 0;
                            VIPYF = 0;
                        }
                    }
                    if (Convert.ToInt32(dt.Rows[0]["shop_category_id"]) == 1)
                    {
                        num = 0;
                    }
                }
                else
                {
                    if (num5 != 0)
                    {
                        Postage = (Math.Ceiling((num5 - Convert.ToDecimal(table.Rows[0]["FirstHeavy"])) / 1000)) * Convert.ToDecimal(table.Rows[0]["AfterHeavyPrice"]) + Convert.ToDecimal(table.Rows[0]["FirstHeavyPrice"]);
                        num = 1;
                        MYPostage = Postage;
                        if (Convert.ToInt32(dt.Rows[0]["shop_category_id"]) == 5 || Convert.ToInt32(dt.Rows[0]["shop_category_id"]) == 7)
                        {
                            if (ShangPinPrice * Convert.ToInt32(BuyNumber) >= 3000)
                            {
                                Postage = 0;
                                num = 0;
                                MYPostage = Postage;
                            }
                            else
                            {

                                Postage = (Math.Ceiling((num5 - Convert.ToDecimal(table.Rows[0]["FirstHeavy"])) / 1000)) * Convert.ToDecimal(table.Rows[0]["AfterHeavyPrice"]) + Convert.ToDecimal(table.Rows[0]["FirstHeavyPrice"]);
                                num = 1;
                                MYPostage = Postage;
                                HDFK = 0;
                                WLPostage = 0;
                            }
                        }
                        if (Convert.ToInt32(dt.Rows[0]["shop_category_id"]) == 2)
                        {
                            if (ShangPinPrice * Convert.ToInt32(BuyNumber) >= 10000)
                            {
                                VIPPostage = 0;
                                num = 0;
                                Postage = 0;
                                VIPYF = 1;
                            }
                            else
                            {
                                VIPPostage = decimal.Multiply(ShangPinPrice * Convert.ToInt32(BuyNumber), (decimal)0.01);
                                if (VIPPostage < 10)
                                {
                                    VIPPostage = 10M;
                                }
                                num = 0;
                                Postage = 0;
                                VIPYF = 0;
                            }
                        }
                        if (Convert.ToInt32(dt.Rows[0]["shop_category_id"]) == 1)
                        {
                            num = 0;
                        }
                    }
                }

            }

            //if (dt.Rows[0]["isreal"].ToString() == "0")
            //{
            //    var listItem = new ListItem();
            //    listItem.Text = "自提货";
            //    listItem.Value = "0:-1";
            //    DropDownListPost.Items.Add(listItem);
            //}
            if (Convert.ToInt32(dt.Rows[0]["shop_category_id"]) == 5)
            {
                //var listItem = new ListItem();
                //listItem.Text = "进货邮费￥40";
                //listItem.Value = 40 + ":-3";
                //DropDownListPost.Items.Add(listItem);
                //HiddenFieldDispatchPrice.Value = "40";
                var listItem5 = new ListItem();
                listItem5.Text = "免运费";
                listItem5.Value = "0:-2";
                DropDownListPost.Items.Add(listItem5);

            }
            else
            {
                if (num == 1)
                {
                    bool flag = true;
                    bool flag2 = true;
                    bool flag3 = true;
                    if (num2 != 0m)
                    {
                        flag = false;
                        var listItem2 = new ListItem();
                        listItem2.Text = "平邮" + num2 + "元";
                        listItem2.Value = num2 + ":1";
                        DropDownListPost.Items.Add(listItem2);
                        flag2 = false;
                        HiddenFieldDispatchPrice.Value = num2.ToString();
                    }
                    if (num3 != 0m)
                    {
                        flag = false;
                        var listItem3 = new ListItem();
                        listItem3.Text = "快递" + num3 + "元";
                        listItem3.Value = num3 + ":2";
                        DropDownListPost.Items.Add(listItem3);
                        if (flag2)
                        {
                            HiddenFieldDispatchPrice.Value = num3.ToString();
                        }
                        flag3 = false;
                    }
                    if (num4 != 0m)
                    {
                        flag = false;
                        var listItem4 = new ListItem();
                        listItem4.Text = "EMS" + num4 + "元";
                        listItem4.Value = num4 + ":3";
                        DropDownListPost.Items.Add(listItem4);
                        if (flag3 & flag2)
                        {
                            HiddenFieldDispatchPrice.Value = num4.ToString();
                        }
                    }
                    if (Postage != 0m)
                    {
                        flag = false;
                        var listItem6 = new ListItem();
                        listItem6.Text = "邮费" + Postage + "元";
                        listItem6.Value = Postage + ":4";
                        DropDownListPost.Items.Add(listItem6);
                        if (flag3 & flag2)
                        {
                            HiddenFieldDispatchPrice.Value = Postage.ToString();
                        }
                    }
                    if (HDFK == 0m)
                    {
                        flag = false;
                        var listItem7 = new ListItem();
                        listItem7.Text = "货到付款";
                        listItem7.Value = HDFK + ":5";
                        DropDownListPost.Items.Add(listItem7);
                        if (flag3 & flag2)
                        {
                            HiddenFieldDispatchPrice.Value = HDFK.ToString();
                        }
                    }
                    if (VIPYF == 0m)
                    {
                        flag = false;
                        var listItem7 = new ListItem();
                        listItem7.Text = "邮费" + Convert.ToDecimal(VIPPostage) + "元";
                        listItem7.Value = VIPPostage + ":6";
                        DropDownListPost.Items.Add(listItem7);
                        if (flag3 & flag2)
                        {
                            HiddenFieldDispatchPrice.Value = VIPPostage.ToString();
                        }
                    }


                    if (flag)
                    {
                        var listItem5 = new ListItem();
                        listItem5.Text = "免运费";
                        listItem5.Value = "0:-2";
                        DropDownListPost.Items.Add(listItem5);
                    }
                }
                else
                {
                    var listItem5 = new ListItem();
                    listItem5.Text = "免运费";
                    listItem5.Value = "0:-2";
                    DropDownListPost.Items.Add(listItem5);
                }
            }
        }

        protected void method_4()
        {
            labelAllPrice.Text = "0";
            decimal d = 0m;
            decimal d2 = 0m;
            decimal d3 = 0m;
            decimal num = 0m;
            bool flag = false;
            foreach (RepeaterItem repeaterItem in RepeaterShopProduct.Items)
            {
                var label = (Label)repeaterItem.FindControl("labelProductMarketPrice");
                if (labelAll.Text.Trim() == "")
                {
                    labelAll.Text = "0";
                }
                d += Convert.ToDecimal(labelAll.Text);
                LabelOnlyProductPrice.Text = d.ToString();
                if (label.Text.Trim() == "")
                {
                    label.Text = "0";
                }
                d2 += Convert.ToInt32(BuyNumber) * Convert.ToDecimal(label.Text.Trim());
                try
                {
                    if (DropDownListPost.SelectedValue.Split(new[]
                    {
                        ':'
                    })[1] == "-1")
                    {
                        var hiddenField = (HiddenField)repeaterItem.FindControl("HiddenFieldFeeType");
                        var hiddenField2 = (HiddenField)repeaterItem.FindControl("HiddenFieldMinusFee");
                        if (hiddenField.Value == "1")
                        {
                            num += Convert.ToDecimal(hiddenField2.Value) * Convert.ToInt32(BuyNumber);
                            flag = true;
                        }
                    }
                }
                catch
                {
                }
            }
            labelMaretPrice.Text = d2.ToString();
            decimal d4 = 0m;
            string a = string.Empty;
            foreach (RepeaterItem repeaterItem2 in RepeaterShoppingCartPayment.Items)
            {
                var radioButton = (RadioButton)repeaterItem2.FindControl("RadioButtonPayment");
                if (radioButton.Checked)
                {
                    var hiddenField3 = (HiddenField)repeaterItem2.FindControl("HiddenFieldIsPersent");
                    if (hiddenField3.Value == "1")
                    {
                        a = "1";
                    }
                    else
                    {
                        a = "0";
                    }
                    label_9 = (Label)repeaterItem2.FindControl("LabelCharge");
                    d4 = Convert.ToDecimal(label_9.Text);
                    break;
                }
            }
            if (a == "1")
            {
                if (flag)
                {
                    LabelBuyShopPrice.Text = (d + d3 + (d + d3 - num) * d4 / 100m - num).ToString("n");
                }
                else
                {
                    LabelBuyShopPrice.Text = (d + d3 + (d + d3) * d4 / 100m).ToString("n");
                }
            }
            else
            {
                if (flag)
                {
                    LabelBuyShopPrice.Text = (d + d3 + d4 - num).ToString("n");
                }
                else
                {
                    LabelBuyShopPrice.Text = (d + d3 + d4).ToString("n");
                }
            }
            labelLower.Text =
                (Convert.ToDecimal(labelMaretPrice.Text) - Convert.ToDecimal(LabelOnlyProductPrice.Text)).ToString("n");
            if (a == "1")
            {
                if (flag)
                {
                    LabelPriceMeto.Text = string.Concat(new object[]
                    {
                        "商品总价格：<b>",
                        LabelOnlyProductPrice.Text,
                        "</b>元 + 支付费用：<b>",
                        ((d + d3)*d4/100m).ToString("n"),
                        "</b>元 +运费：<b>",
                        d3.ToString("n"),
                        "</b>元 - 生活服务优惠: <b>",
                        num,
                        " </b>元 =<b>",
                        LabelBuyShopPrice.Text.Replace(",", ""),
                        "</b>元"
                    });
                }
                else
                {
                    LabelPriceMeto.Text = string.Concat(new[]
                    {
                        "商品总价格：<b>",
                        LabelOnlyProductPrice.Text,
                        "</b>元 + 支付费用：<b>",
                        ((d + d3)*d4/100m).ToString("n"),
                        "</b>元 +运费：<b>",
                        d3.ToString("n"),
                        "</b>元 =<b>",
                        LabelBuyShopPrice.Text.Replace(",", ""),
                        "</b>元"
                    });
                }
            }
            else
            {
                if (flag)
                {
                    LabelPriceMeto.Text = string.Concat(new object[]
                    {
                        "商品总价格：<b>",
                        LabelOnlyProductPrice.Text,
                        "</b>元 + 支付费用：<b>",
                        d4.ToString("n"),
                        "</b>元 + 运费：<b>",
                        d3.ToString("n"),
                        "</b>元 - 生活服务优惠:<b>",
                        num,
                        " 元 =",
                        LabelBuyShopPrice.Text.Replace(",", ""),
                        "</b>元"
                    });
                }
                else
                {
                    LabelPriceMeto.Text = string.Concat(new[]
                    {
                        "商品总价格：<b>",
                        LabelOnlyProductPrice.Text,
                        "</b>元 + 支付费用：<b>",
                        d4.ToString("n"),
                        "</b>元 + 运费：<b>",
                        d3.ToString("n"),
                        "</b>元 =<b>",
                        LabelBuyShopPrice.Text.Replace(",", ""),
                        "</b>元"
                    });
                }
            }
        }

        protected void BindReceivingAddress()
        {
            var shopNum1_Address_Action = (ShopNum1_Address_Action)LogicFactory.CreateShopNum1_Address_Action();
            DataTable dataTable = shopNum1_Address_Action.Search(strMemLoginID, 0);
            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                bool flag = true;
                RepeaterReceivingAddress.DataSource = dataTable;
                RepeaterReceivingAddress.DataBind();
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    if (dataTable.Rows[i]["IsDefault"].ToString() == "1")
                    {
                        flag = false;
                        HiddenFieldAddressGuid.Value = dataTable.Rows[i]["Guid"].ToString();
                        HiddenFieldAddressCode.Value = dataTable.Rows[i]["AddressCode"].ToString();
                    }
                }
                if (flag)
                {
                    HiddenFieldAddressGuid.Value = dataTable.Rows[0]["Guid"].ToString();
                    HiddenFieldAddressCode.Value = dataTable.Rows[0]["AddressCode"].ToString();
                }
            }
        }

        protected void ButtonAddReceivAddress_Click(object sender, EventArgs e)
        {
            if (HiddenFieldAddressName.Value != "-1")
            {
                if (TextBoxName.Text == "" || HiddenFieldAddressName.Value == "-1" || TextBoxAddress.Text == "" || TextBoxMobile.Text == "")
                {

                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "msg",
                  "alert(\"收货地址信息不完整!\");window.location.href='/default.aspx';", true);
                    return;
                }
                var shopNum1_Address = new ShopNum1_Address();
                shopNum1_Address.Guid = Guid.NewGuid();
                shopNum1_Address.Name = TextBoxName.Text;
                shopNum1_Address.Email = TextBoxEmail.Text;
                shopNum1_Address.Address = TextBoxAddress.Text;
                shopNum1_Address.AddressValue = HiddenFieldAddressName.Value;
                shopNum1_Address.Area = HiddenFieldAddressName.Value;
                shopNum1_Address.AddressCode = HiddenFieldAddressCode.Value;
                shopNum1_Address.Postalcode = TextBoxPostalcode.Text;
                shopNum1_Address.Tel = TextBoxTel.Text;
                shopNum1_Address.Mobile = TextBoxMobile.Text;
                shopNum1_Address.IsDefault = 0;
                shopNum1_Address.MemLoginID = strMemLoginID;
                shopNum1_Address.CreateUser = strMemLoginID;
                shopNum1_Address.CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                shopNum1_Address.ModifyUser = strMemLoginID;
                shopNum1_Address.ModifyTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                shopNum1_Address.IsDeleted = 0;
                shopNum1_Address.AddressValue = HiddenFieldAddressName.Value;
                IShopNum1_Address_Action shopNum1_Address_Action = LogicFactory.CreateShopNum1_Address_Action();
                int num = shopNum1_Address_Action.Add(shopNum1_Address);
                if (num > 0)
                {
                    BindReceivingAddress();
                }
                TextBoxName.Text = (TextBoxMobile.Text = string.Empty);
                //}
            }
        }

        protected void IsEmail(string strEmail, string strName, string OrderNumber, string strMemloginId,
            string strHomeTel, string strProductName, string strMobile)
        {
            if (!string.IsNullOrEmpty(strEmail))
            {
                string value = ShopSettings.GetValue("Name");
                var orderInfo = new OrderInfo();
                string memLoginID = orderInfo.Name = strMemLoginID;
                orderInfo.OrderNumber = OrderNumber;
                orderInfo.SysSendTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                orderInfo.ShopName = value;
                string text = string.Empty;
                string emailTitle = string.Empty;
                string text2 = "457f965d-f1cc-45cf-b4a5-ddbbd6b7fdc0";
                var shopNum1_Email_Action = (ShopNum1_Email_Action)LogicFactory.CreateShopNum1_Email_Action();
                DataTable editInfo = shopNum1_Email_Action.GetEditInfo("'" + text2 + "'", 0);
                if (editInfo.Rows.Count > 0)
                {
                    text = editInfo.Rows[0]["Remark"].ToString();
                    emailTitle = editInfo.Rows[0]["Title"].ToString();
                }
                text = text.Replace("{$Name}", strName);
                text = text.Replace("{$OrderNumber}", OrderNumber);
                text = text.Replace("{$MemLoginId}", strMemloginId);
                text = text.Replace("{$UserTel}", strHomeTel);
                text = text.Replace("{$SendTime}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                text = text.Replace("{$ShopName}", orderInfo.ShopName);
                text = text.Replace("{$ProductName}", strProductName);
                text = text.Replace("{$UserMobile}", strMobile);
                string emailBody = orderInfo.ChangeOrderInfo(Page.Server.HtmlDecode(text));
                var sendEmail = new SendEmail();
                sendEmail.Emails(strEmail, memLoginID, emailTitle, text2, emailBody);
            }
        }

        protected void IsEmail(string guid, string OrderNumber)
        {
            var shopNum1_OrderInfo_Action = (ShopNum1_OrderInfo_Action)LogicFactory.CreateShopNum1_OrderInfo_Action();
            DataTable orderInfoByGuid = shopNum1_OrderInfo_Action.GetOrderInfoByGuid(guid);
            if (orderInfoByGuid.Rows[0]["Email"] != null && !(orderInfoByGuid.Rows[0]["Email"].ToString() == ""))
            {
                string email = orderInfoByGuid.Rows[0]["Email"].ToString();
                string value = ShopSettings.GetValue("Name");
                var orderInfo = new OrderInfo();
                string text = orderInfo.Name = orderInfoByGuid.Rows[0]["MemLoginID"].ToString();
                orderInfo.OrderNumber = orderInfoByGuid.Rows[0]["OrderNumber"].ToString();
                orderInfo.SysSendTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                orderInfo.ShopName = value;
                string text2 = string.Empty;
                string emailTitle = string.Empty;
                string text3 = "ce05437f-75a7-4ee2-8014-4bd992357e51";
                var shopNum1_Email_Action = (ShopNum1_Email_Action)LogicFactory.CreateShopNum1_Email_Action();
                DataTable editInfo = shopNum1_Email_Action.GetEditInfo("'" + text3 + "'", 0);
                if (editInfo.Rows.Count > 0)
                {
                    text2 = editInfo.Rows[0]["Remark"].ToString();
                    emailTitle = editInfo.Rows[0]["Title"].ToString();
                }
                text2 = text2.Replace("{$Name}", text);
                text2 = text2.Replace("{$OrderNumber}", OrderNumber);
                text2 = text2.Replace("{$ShopName}", orderInfo.ShopName);
                text2 = text2.Replace("{$SendTime}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                string emailBody = orderInfo.ChangeOrderInfo(Page.Server.HtmlDecode(text2));
                var sendEmail = new SendEmail();
                sendEmail.Emails(email, text, emailTitle, text3, emailBody);
            }
        }

        protected void IsMMS(string OrderNumber, string memloginID, string string_8)
        {
            if (!(string_8.Trim() == ""))
            {
                var orderInfo = new OrderInfo();
                orderInfo.Name = memloginID;
                orderInfo.OrderNumber = OrderNumber;
                orderInfo.SysSendTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                orderInfo.ShopName = ShopSettings.GetValue("Name");
                string text = "ce05437f-75a7-4ee2-8014-4bd992357e51";
                IShopNum1_MMS_Action shopNum1_MMS_Action = LogicFactory.CreateShopNum1_MMS_Action();
                DataTable editInfo = shopNum1_MMS_Action.GetEditInfo(text, 0);
                if (editInfo != null && editInfo.Rows.Count > 0)
                {
                    string text2 = editInfo.Rows[0]["Remark"].ToString();
                    text2 = text2.Replace("{$Name}", orderInfo.Name);
                    text2 = text2.Replace("{$OrderNumber}", orderInfo.OrderNumber);
                    text2 = text2.Replace("{$ShopName}", orderInfo.ShopName);
                    text2 = text2.Replace("{$SendTime}", DateTime.Now.ToString("yyyy-MM-dd"));
                    string mMsTitle = editInfo.Rows[0]["Title"].ToString();
                    var sMS = new SMS();
                    string text3 = "";
                    text2 = orderInfo.ChangeOrderInfo(Page.Server.HtmlDecode(text2));
                    sMS.Send(string_8.Trim(), text2 + "【唐江宝宝】", out text3);
                    if (text3.IndexOf("发送成功") != -1)
                    {
                        ShopNum1_MMSGroupSend emailGroupSend = AddMMS(memloginID, string_8.Trim(), text2, mMsTitle, 2,
                            text);
                        shopNum1_MMS_Action.AddMMSGroupSend(emailGroupSend);
                    }
                    else
                    {
                        ShopNum1_MMSGroupSend emailGroupSend = AddMMS(memloginID, string_8.Trim(), text2, mMsTitle, 0,
                            text);
                        shopNum1_MMS_Action.AddMMSGroupSend(emailGroupSend);
                    }
                }
            }
        }

        protected void IsMMS(string strTel, string strName, string strMemLoginId, string strHomeTel,
            string strOrderNumber, string strProductName, string strMobile)
        {
            if (!string.IsNullOrEmpty(strTel))
            {
                IShopNum1_MMS_Action shopNum1_MMS_Action = LogicFactory.CreateShopNum1_MMS_Action();
                DataTable editInfo = shopNum1_MMS_Action.GetEditInfo("190d25f8-a9e9-4162-b4e8-0a3954c83473", 0);
                if (editInfo.Rows.Count > 0)
                {
                    string text = editInfo.Rows[0]["Remark"].ToString();
                    string mMsTitle = editInfo.Rows[0]["Title"].ToString();
                    text = text.Replace("{$Name}", strName);
                    text = text.Replace("{$OrderNumber}", strOrderNumber);
                    text = text.Replace("{$MemLoginId}", strMemLoginId);
                    text = text.Replace("{$UserTel}", strHomeTel);
                    text = text.Replace("{$SendTime}", DateTime.Now.ToString());
                    text = text.Replace("{$ProductName}", strProductName);
                    text = text.Replace("{$UserMobile}", strMobile);
                    var orderInfo = new OrderInfo();
                    var sMS = new SMS();
                    text = orderInfo.ChangeOrderInfo(Page.Server.HtmlDecode(text));
                    string empty = string.Empty;
                    sMS.Send(strTel, text + "【唐江宝宝】", out empty);
                    if (empty.IndexOf("发送成功") != -1)
                    {
                        ShopNum1_MMSGroupSend emailGroupSend = AddMMS(strMemLoginId, strMobile.Trim(), text, mMsTitle, 2,
                            "190d25f8-a9e9-4162-b4e8-0a3954c83473");
                        shopNum1_MMS_Action.AddMMSGroupSend(emailGroupSend);
                    }
                    else
                    {
                        ShopNum1_MMSGroupSend emailGroupSend = AddMMS(strMemLoginId, strMobile.Trim(), text, mMsTitle, 0,
                            "190d25f8-a9e9-4162-b4e8-0a3954c83473");
                        shopNum1_MMS_Action.AddMMSGroupSend(emailGroupSend);
                    }
                }
            }
        }

        protected ShopNum1_MMSGroupSend AddMMS(string memLoginID, string mobile, string strContent, string MMsTitle,
            int state, string mmsGuid)
        {
            return new ShopNum1_MMSGroupSend
            {
                Guid = Guid.NewGuid(),
                MMSTitle = MMsTitle,
                CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                MMSGuid = new Guid(mmsGuid),
                SendObjectMMS = strContent,
                SendObject = memLoginID + "-" + mobile,
                State = state
            };
        }

        protected void method_5()
        {
            foreach (RepeaterItem repeaterItem in RepeaterShoppingCartPayment.Items)
            {
                var radioButton = repeaterItem.FindControl("RadioButtonPayment") as RadioButton;
                if (radioButton.Checked)
                {
                    var htmlGenericControl = repeaterItem.FindControl("guid") as HtmlGenericControl;
                    HiddenFieldPaymentGuid.Value = htmlGenericControl.InnerText;
                    HiddenFieldPaymentName.Value = ((Label)repeaterItem.FindControl("LabelName")).Text.Trim();
                }
            }
        }
    }
}