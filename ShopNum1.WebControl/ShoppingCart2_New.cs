using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
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
    public class ShoppingCart2_New : BaseWebControl
    {
        private readonly IShopNum1_Cart_Action ishopNum1_Cart_Action_0 = LogicFactory.CreateShopNum1_Cart_Action();
        private TextBox TextBox1;
        private HtmlSelect DropDownList1;
        private Button ButtonAddReceivAddress;
        private Button ButtonCreate;
        private DropDownList DropDownListSelect;
        private DropDownList DropDownListPost;
        private HiddenField HiddenFieldAddressCode;
        private HiddenField HiddenFieldAddressGuid;
        private HiddenField HiddenFieldAddressName;
        private HiddenField HiddenFieldDispatchModeGuid;
        private HiddenField HiddenFieldDispatchModeName;
        private HiddenField HiddenFieldDispatchPrice;
        private HiddenField HiddenFieldFeeTemplateIDandNumber;
        private HiddenField HiddenFieldInvoiceType;
        private HiddenField HiddenFieldMoreMemloginid;
        private HiddenField HiddenFieldPaymentGuid;
        private HiddenField HiddenFieldPaymentName;
        private HiddenField HiddenFieldPaymentPriceValue;
        private Label LabelAllCartPrice;
        private Label LabelBuyShopPrice;
        private Label LabelOnlyProductPrice;
        private Label LabelPriceMeto;
        private Repeater RepeaterReceivingAddress;
        private Repeater RepeaterShopCart2;
        private Repeater RepeaterShopProduct;

        private Repeater RepeaterShoppingCartPayment;
        private TextBox TextBoxAddress;
        private TextBox TextBoxEmail;
        private TextBox TextBoxMessage;
        private TextBox TextBoxMobile;
        private TextBox TextBoxName;
        private TextBox TextBoxPostalcode;
        private TextBox TextBoxTel;
        private DropDownList dropDownList_1;
        private Label labelAllPrice;
        private Label labelLower;
        private Label labelMaretPrice;
        private Label label_7;
        private string skinFilename = "ShoppingCart2_New.ascx";
        private string string_1 = string.Empty;
        private int shopcategoryid;
        private Label lableColor;
        private Label lableSize;
        private decimal allprice;
        private Label mylableshow;
        private Label MylableShoweMoney;
        private Label MylableShoweMoneyJiFen;
        private Label Label2;
        private decimal MYPostage;
        private decimal WLPostage;
        private decimal VIPPostage;
        private decimal MZPrice;
        private decimal ShangPinPrice;
        private Label LabelWuliu;
        private Label label_pv_a_b_all;
        private Label Label1;
        
        public ShoppingCart2_New()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public string AddressGuid { get; set; }
        public string strMemLoginID { get; set; }
        public string PayMentMemLoginID { get; set; }

        protected override void InitializeSkin(Control skin)
        {
            if (Page.Request.Cookies["MemberLoginCookie"] == null)
            {
                Page.Response.Write("<script>window.top.location.target= '_blank '; window.top.location.href='" +
                                    GetPageName.RetUrl("Login") + "' </script>");

            }
            else
            {
                HttpCookie cookie = Page.Request.Cookies["MemberLoginCookie"];
                HttpCookie httpCookie = HttpSecureCookie.Decode(cookie);
                TextBox1 = (TextBox)skin.FindControl("TextBox1");
                DropDownList1 = (HtmlSelect)skin.FindControl("DropDownList1");
                strMemLoginID = httpCookie.Values["MemLoginID"];
                RepeaterShopProduct = (Repeater)skin.FindControl("RepeaterShopProduct");
                RepeaterShopCart2 = (Repeater)skin.FindControl("RepeaterShopCart2");
                RepeaterShopCart2.ItemDataBound += RepeaterShopCart2_ItemDataBound;
                labelAllPrice = (Label)skin.FindControl("labelAllPrice");
                labelMaretPrice = (Label)skin.FindControl("labelMaretPrice");
                labelLower = (Label)skin.FindControl("labelLower");
                LabelBuyShopPrice = (Label)skin.FindControl("LabelBuyShopPrice");
                LabelOnlyProductPrice = (Label)skin.FindControl("LabelOnlyProductPrice");
                LabelPriceMeto = (Label)skin.FindControl("LabelPriceMeto");
                LabelAllCartPrice = (Label)skin.FindControl("LabelAllCartPrice");
                Label1 = (Label)skin.FindControl("Label1");
                LabelAllCartPrice.Text = "";

                if (Page.Request.Cookies["VjProductGuId"] != null)
                {
                    HttpCookie cookie2 = Page.Request.Cookies["VjProductGuId"];
                    HttpCookie httpCookie2 = HttpSecureCookie.Decode(cookie2);
                    string_1 = httpCookie2.Values["parry"];
                }
                if (string_1 != "")
                {
                    if (string_1.IndexOf(",") != -1)
                    {
                        var stringBuilder = new StringBuilder();
                        string[] array = string_1.Split(new[]
                        {
                            ','
                        });
                        for (int i = 0; i < array.Length; i++)
                        {
                            stringBuilder.Append(array[i] + ",");
                        }
                        stringBuilder.Remove(stringBuilder.Length - 1, 1);
                        string_1 = stringBuilder.ToString();
                    }
                    else
                    {
                        string_1 = string_1;
                    }
                }

                RepeaterShoppingCartPayment = (Repeater)skin.FindControl("RepeaterShoppingCartPayment");
                BindDataPayment();
                RepeaterReceivingAddress = (Repeater)skin.FindControl("RepeaterReceivingAddress");
                TextBoxName = (TextBox)skin.FindControl("TextBoxName");
                TextBoxAddress = (TextBox)skin.FindControl("TextBoxAddress");
                TextBoxEmail = (TextBox)skin.FindControl("TextBoxEmail");
                TextBoxPostalcode = (TextBox)skin.FindControl("TextBoxPostalcode");
                TextBoxTel = (TextBox)skin.FindControl("TextBoxTel");
                TextBoxMobile = (TextBox)skin.FindControl("TextBoxMobile");
                DropDownListSelect = (DropDownList)skin.FindControl("DropDownListSelect");
                DropDownListPost = (DropDownList)skin.FindControl("DropDownListPost");
                ButtonAddReceivAddress = (Button)skin.FindControl("ButtonAddReceivAddress");
                ButtonAddReceivAddress.Click += ButtonAddReceivAddress_Click;
                HiddenFieldAddressCode = (HiddenField)skin.FindControl("HiddenFieldAddressCode");
                HiddenFieldAddressName = (HiddenField)skin.FindControl("HiddenFieldAddressName");
                HiddenFieldAddressGuid = (HiddenField)skin.FindControl("HiddenFieldAddressGuid");
                HiddenFieldDispatchPrice = (HiddenField)skin.FindControl("HiddenFieldDispatchPrice");
                BindReceivingAddress();
                ButtonCreate = (Button)skin.FindControl("ButtonCreate");
                ButtonCreate.Click += ButtonCreate_Click;
                HiddenFieldDispatchModeGuid = (HiddenField)skin.FindControl("HiddenFieldDispatchModeGuid");
                HiddenFieldDispatchModeName = (HiddenField)skin.FindControl("HiddenFieldDispatchModeName");
                HiddenFieldPaymentGuid = (HiddenField)skin.FindControl("HiddenFieldPaymentGuid");
                HiddenFieldPaymentName = (HiddenField)skin.FindControl("HiddenFieldPaymentName");
                HiddenFieldInvoiceType = (HiddenField)skin.FindControl("HiddenFieldInvoiceType");
                HiddenFieldMoreMemloginid = (HiddenField)skin.FindControl("HiddenFieldMoreMemloginid");
                HiddenFieldFeeTemplateIDandNumber = (HiddenField)skin.FindControl("HiddenFieldFeeTemplateIDandNumber");
                HiddenFieldPaymentPriceValue = (HiddenField)skin.FindControl("HiddenFieldPaymentPriceValue");
                TextBoxMessage = (TextBox)skin.FindControl("TextBoxMessage");
                mylableshow = (Label)skin.FindControl("mylableshow");
                MylableShoweMoney = (Label)skin.FindControl("MylableShoweMoney");
                lableColor = (Label)skin.FindControl("lableColor");
                lableSize = (Label)skin.FindControl("lableSize");
                MylableShoweMoneyJiFen = (Label)skin.FindControl("MylableShoweMoneyJiFen");
                Label2 = (Label)skin.FindControl("Label2");
                label_pv_a_b_all = (Label)skin.FindControl("label_pv_a_b_all");

                BindData();
            }
        }


        int pp = 10;
        string ppp = "";
        protected void RepeaterShopCart2_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            decimal pv_a_b_all = 0;
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var label = (Label)e.Item.FindControl("LabelShopName");
                LabelWuliu = (Label)e.Item.FindControl("labelWuliu");
                dropDownList_1 = (DropDownList)e.Item.FindControl("DropDownListPost");
                dropDownList_1.SelectedIndexChanged += dropDownList_1_SelectedIndexChanged;
                var repeater = (Repeater)e.Item.FindControl("RepeaterShopProduct");
                repeater.ItemDataBound += method_0;
                if (string_1 == string.Empty)
                {
                    Page.Response.Redirect("/ShoppingCart1.aspx");
                }
                else
                {

                    //terry mark SearchByShopMemID
                    int shopid = Convert.ToInt32((e.Item.DataItem as System.Data.DataRowView)[2]);
                    string strShop = (e.Item.DataItem as System.Data.DataRowView)[0].ToString();
                    DataTable dataTable = ishopNum1_Cart_Action_0.SearchByShopMemID_free(strMemLoginID, string_1, shopid);

                    if (shopcategoryid == 4 || shopcategoryid == 5 || shopcategoryid == 6 || shopcategoryid == 7)
                    {
                        LabelWuliu.Visible = true;
                    }
                    else
                    {
                        LabelWuliu.Visible = false;
                    }

                    if (pp != shopid || pp == 9)
                    {
                        if (shopid == 9)
                        {
                            if (ppp != strShop)
                            {
                                DataTable BTCTable = ishopNum1_Cart_Action_0.SearchByShopMemID_freefive(strMemLoginID, string_1, shopid, strShop);
                                for (int j = 0; j < BTCTable.Rows.Count; j++)
                                {
                                    pv_a_b_all += Convert.ToDecimal(BTCTable.Rows[j]["Score_pv_b"]) * Convert.ToInt32(BTCTable.Rows[j]["BuyNumber"]);
                                    pv_a_b_all += Convert.ToDecimal(BTCTable.Rows[j]["Score_pv_a"]) * Convert.ToInt32(BTCTable.Rows[j]["BuyNumber"]);
                                }
                                repeater.DataSource = BTCTable.DefaultView;
                                repeater.DataBind();
                            }
                        }
                        else
                        {
                            for (int j = 0; j < dataTable.Rows.Count; j++)
                            {
                                pv_a_b_all += Convert.ToDecimal(dataTable.Rows[j]["Score_pv_b"]) * Convert.ToInt32(dataTable.Rows[j]["BuyNumber"]);
                                pv_a_b_all += Convert.ToDecimal(dataTable.Rows[j]["Score_pv_a"]) * Convert.ToInt32(dataTable.Rows[j]["BuyNumber"]);
                            }
                            repeater.DataSource = dataTable.DefaultView;
                            repeater.DataBind();

                            IShop_Ensure_Action shop_Ensure_Action = ShopFactory.LogicFactory.CreateShop_Ensure_Action();
                            DataTable dataTable2 = shop_Ensure_Action.SearchEnsureApply(label.Text);

                            for (int i = 0; i < repeater.Items.Count; i++)
                            {

                                var label2 = (Label)repeater.Items[i].FindControl("LabelProductService");
                                if (dataTable2 != null && dataTable2.Rows.Count > 0)
                                {
                                    for (int j = 0; j < dataTable2.Rows.Count; j++)
                                    {
                                        var image = new Image();
                                        image.ImageUrl = dataTable2.Rows[j]["ImagePath"].ToString();
                                        label2.Controls.Add(image);

                                    }
                                }
                                else
                                {
                                    label2.Text = "";
                                }
                            }
                        }
                    }


                    label_pv_a_b_all.Text = pv_a_b_all.ToString();
                    pp = shopid;
                    ppp = strShop;
                }
            }
        }

        protected void method_0(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var label = (Label)e.Item.FindControl("LabelBuyPrice");
                string value = label.Text.Trim();
                var textBox = (TextBox)e.Item.FindControl("TextBoxBuyNumber");
                string text = textBox.Text.Trim();
                var label2 = (Label)e.Item.FindControl("LabelAll");
                label2.Text = text;
                label2.Text = (Convert.ToDecimal(value) * Convert.ToInt32(text)).ToString();


            }
            var Label3 = (Label)e.Item.FindControl("Label3");
            DataRowView row = (DataRowView)e.Item.DataItem;


            if (Convert.ToInt32(row["shop_category_id"]) == 3)
            {
                Label3.Text = (Convert.ToDecimal(row["Score_pv_a"]) * -1).ToString();
            }
            else if (Convert.ToInt32(row["shop_category_id"]) != 2 && Convert.ToInt32(row["shop_category_id"]) != 3)
            {
                Label3.Text = "";
            }
        }

        protected void BindData()
        {

            if (string_1 == string.Empty)
            {
                Page.Response.Redirect("/ShoppingCart1.aspx");
            }
            else
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



                //SearchByShopMemID
                DataTable dataTable = ishopNum1_Cart_Action_0.SearchShopByMemLoginID(strMemLoginID, string_1);

                shopcategoryid = Convert.ToInt32(dataTable.Rows[0]["shop_category_id"]);


                if (shopcategoryid == 3)
                {
                    mylableshow.Text = "积分";

                }
                else if (shopcategoryid != 3 && shopcategoryid == 2)
                {
                    mylableshow.Text = "";
                }
                if (shopcategoryid == 2)
                {
                    
                        Label1.Text = "请填写正确的服务商(选填)";
                    
                }
                else
                {
                    TextBox1.Text = "C0000001";
                    TextBox1.Visible = false;
                    Label1.Visible = false;
                }


                #region 暂时处理订单服务区代

                //if ((shopcategoryid == (int)CustomerCategory.VIP专区 || shopcategoryid == (int)CustomerCategory.BTC专区) && memberGuid == MemberLevel.NORMAL_MEMBER_ID)
                //{
                //    TextBox1.ReadOnly = true;
                //    TextBox1.Text = "C0000001";
                //}

                //if (shopcategoryid == (int)CustomerCategory.积分专区 || shopcategoryid == (int)CustomerCategory.区代专区1 || shopcategoryid == (int)CustomerCategory.区代专区2 || shopcategoryid == (int)CustomerCategory.社区店铺专区1 || shopcategoryid == (int)CustomerCategory.社区店铺专区2)
                //{
                //    TextBox1.ReadOnly = true;
                //    TextBox1.Text = "C0000001";
                //}
                //TextBox1.Visible = false;

                #endregion
                if (dataTable != null && dataTable.Rows.Count > 0)
                {
                    string text = string.Empty;
                    for (int i = 0; i < dataTable.Rows.Count; i++)
                    {

                        if (i < dataTable.Rows.Count - 1)
                        {
                            text = text + dataTable.Rows[i]["ShopID"] + ",";
                        }
                        else
                        {
                            text += dataTable.Rows[i]["ShopID"].ToString();
                        }

                    }
                    HiddenFieldMoreMemloginid.Value = text;
                    RepeaterShopCart2.DataSource = dataTable.DefaultView;
                    RepeaterShopCart2.DataBind();

                }
                method_3();
                GetAllMoney();
            }
        }

        protected void BindDataPayment()
        {
            if (string_1 == string.Empty)
            {
                Page.Response.Redirect("/ShoppingCart1.aspx");
            }
            else
            {
                DataTable dataTable = ishopNum1_Cart_Action_0.SearchShopByMemLoginID(strMemLoginID, string_1);
                if (dataTable.Rows.Count == 0)
                {
                    Page.Response.Redirect("/ShoppingCart1.aspx");
                }
                else
                {
                    var shopNum1_ShopPayment_Action =
                        (ShopNum1_ShopPayment_Action)LogicFactory.CreateShopNum1_ShopPayment_Action();
                    IShopNum1_Payment_Action shopNum1_Payment_Action = LogicFactory.CreateShopNum1_Payment_Action();
                    string CategoryId = dataTable.Rows[0]["shop_category_id"].ToString();
                    if (CategoryId == "2" || CategoryId == "3" || CategoryId == "9")
                    {

                        DataTable dataTable2 = shopNum1_Payment_Action.SearchTwo(0);

                        if (dataTable2 != null && dataTable2.Rows.Count > 0)
                        {
                            RepeaterShoppingCartPayment.DataSource = dataTable2.DefaultView;
                            RepeaterShoppingCartPayment.DataBind();
                        }
                        foreach (RepeaterItem repeaterItem in RepeaterShoppingCartPayment.Items)
                        {
                            var radioButton = (RadioButton)repeaterItem.FindControl("RadioButtonPayment");
                            radioButton.CheckedChanged += method_2;
                            var literal = (Literal)repeaterItem.FindControl("LiteralIsPersent");
                            var hiddenField = (HiddenField)repeaterItem.FindControl("HiddenFieldIsPersent");
                            if (hiddenField.Value == "1")
                            {
                                literal.Visible = true;
                            }
                        }
                        if (RepeaterShoppingCartPayment.Items.Count > 0)
                        {
                            var radioButton =
                                (RadioButton)RepeaterShoppingCartPayment.Items[0].FindControl("RadioButtonPayment");
                            radioButton.Checked = true;
                        }

                    }
                    else
                    {

                        string value = ShopSettings.GetValue("PayMentType");
                        DataTable dataTable2 = null;

                        string nameById = Common.Common.GetNameById("IsPayMentShop", "ShopNum1_ShopInfo",
                            "   AND  MemLoginID='" + dataTable.Rows[0]["shopid"] + "'   ");
                        if (dataTable.Rows.Count > 1)
                        {
                            PayMentMemLoginID = "admin";
                            dataTable2 = shopNum1_Payment_Action.Search(0);
                        }
                        else
                        {
                            if (nameById != "-1")
                            {
                                if (nameById == "0")
                                {
                                    PayMentMemLoginID = "admin";
                                    dataTable2 = shopNum1_Payment_Action.Search(0);
                                }
                                else
                                {
                                    if (nameById == "1")
                                    {
                                        PayMentMemLoginID = dataTable.Rows[0]["shopid"].ToString();
                                        dataTable2 = shopNum1_ShopPayment_Action.Search(0,
                                            dataTable.Rows[0]["shopid"].ToString());
                                    }
                                }
                            }
                            else
                            {
                                if (value == "0")
                                {
                                    PayMentMemLoginID = "admin";
                                    dataTable2 = shopNum1_Payment_Action.Search(0);
                                }
                                else
                                {
                                    if (value == "1")
                                    {
                                        PayMentMemLoginID = dataTable.Rows[0]["shopid"].ToString();
                                        dataTable2 = shopNum1_ShopPayment_Action.Search(0,
                                            dataTable.Rows[0]["shopid"].ToString());
                                    }
                                    else
                                    {
                                        if (value == "2")
                                        {
                                            var shopNum1_ShopInfoList_Action =
                                                (ShopNum1_ShopInfoList_Action)
                                                    LogicFactory.CreateShopNum1_ShopInfoList_Action();
                                            string shopPayMentType =
                                                shopNum1_ShopInfoList_Action.GetShopPayMentType(
                                                    dataTable.Rows[0]["shopid"].ToString());
                                            if (shopPayMentType == "0")
                                            {
                                                PayMentMemLoginID = "admin";
                                                dataTable2 = shopNum1_Payment_Action.Search(0);
                                            }
                                            else
                                            {
                                                PayMentMemLoginID = dataTable.Rows[0]["shopid"].ToString();
                                                dataTable2 = shopNum1_ShopPayment_Action.Search(0,
                                                    dataTable.Rows[0]["shopid"].ToString());
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        if (dataTable2 != null && dataTable2.Rows.Count > 0)
                        {
                            RepeaterShoppingCartPayment.DataSource = dataTable2.DefaultView;
                            RepeaterShoppingCartPayment.DataBind();
                        }
                        foreach (RepeaterItem repeaterItem in RepeaterShoppingCartPayment.Items)
                        {
                            var radioButton = (RadioButton)repeaterItem.FindControl("RadioButtonPayment");
                            radioButton.CheckedChanged += method_2;
                            var literal = (Literal)repeaterItem.FindControl("LiteralIsPersent");
                            var hiddenField = (HiddenField)repeaterItem.FindControl("HiddenFieldIsPersent");
                            if (hiddenField.Value == "1")
                            {
                                literal.Visible = true;
                            }
                        }
                        if (RepeaterShoppingCartPayment.Items.Count > 0)
                        {
                            var radioButton =
                                (RadioButton)RepeaterShoppingCartPayment.Items[0].FindControl("RadioButtonPayment");
                            radioButton.Checked = true;
                        }
                    }
                }
            }
        }

        protected void method_2(object sender, EventArgs e)
        {
            GetAllMoney();
        }

        protected void dropDownList_1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetAllMoney();
        }

        protected void ButtonCreate_Click(object sender, EventArgs e)
        {
            HttpCookie cookieShopMemberLogin1 = HttpContext.Current.Request.Cookies["MemberLoginCookie"];
            HttpCookie decodedCookieShopMemberLogin1 = HttpSecureCookie.Decode(cookieShopMemberLogin1);
            //会员登录ID
            string MemberLoginID1 = decodedCookieShopMemberLogin1.Values["MemLoginID"];
            var memberrankguid_Action = (ShopNum1_Member_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Member_Action();
            //会员等级
            string memberGuid = memberrankguid_Action.GetCurrentMemberRankGuid(MemberLoginID1);


            if (shopcategoryid == 2)
            {

                #region 暂时处理订单服务区代
                var member_Action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
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
                DataTable tbc = member_Action.NewSearchAreaAgent(TextBox1.Text.Trim());
                if (TextBox1.Text == "" || TextBox1.Text.ToUpper() == "C0000001")
                {
                    TextBox1.Text = "C0000001";
                    #region
                    if (RepeaterShoppingCartPayment.Items == null || RepeaterShoppingCartPayment.Items.Count == 0)
                    {
                        MessageBox.Show("支付方式不能为空！");
                    }
                    else
                    {
                        if (RepeaterShopCart2.Items.Count <= 0)
                        {
                            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "msg", "alert(\"当前结算商品为空,请购买商品后去结算!\");",
                                true);
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
                        //        }
                        //        else
                        //        {
                        //            if (RepeaterShopCart2.Items.Count <= 0)
                        //            {
                        //                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "msg", "alert(\"当前结算商品为空,请购买商品后去结算!\");",
                        //                    true);
                        //            }
                        //            else
                        //            {
                        //                if (shopcategoryid == 4)
                        //                {
                        //                    if ((MZPrice + MYPostage) >= 105700 && (MZPrice + MYPostage) <= 106300)
                        //                    {
                        //                        allprice = 48000.00M;
                        //                        CreatOrderInfo();
                        //                    }
                        //                    else
                        //                    {
                        //                        MessageBox.Show("您报单的价格不符合标准，价格应该处于￥105700-￥106300之间！");
                        //                    }
                        //                }
                        //                else if (shopcategoryid == 6)
                        //                {
                        //                    if ((MZPrice + MYPostage) >= 35900 && (MZPrice + MYPostage) <= 36100)
                        //                    {
                        //                        allprice = 18000.00M;
                        //                        CreatOrderInfo();

                        //                    }
                        //                    else
                        //                    {
                        //                        MessageBox.Show("您报单的价格不符合标准，价格应该处于￥35900-￥36100之间！");
                        //                    }
                        //                }
                        //                else
                        //                {
                        //                    CreatOrderInfo();
                        //                }
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
                        //                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", "alert(\"您的账号首单购买必须为大唐专区！\")", true);
                        //                BindData();
                        //            }
                        //            else
                        //            {
                        //                #region
                        //                if (RepeaterShoppingCartPayment.Items == null || RepeaterShoppingCartPayment.Items.Count == 0)
                        //                {
                        //                    MessageBox.Show("支付方式不能为空！");
                        //                }
                        //                else
                        //                {
                        //                    if (RepeaterShopCart2.Items.Count <= 0)
                        //                    {
                        //                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "msg", "alert(\"当前结算商品为空,请购买商品后去结算!\");",
                        //                            true);
                        //                    }
                        //                    else
                        //                    {
                        //                        if (shopcategoryid == 4)
                        //                        {
                        //                            if ((MZPrice + MYPostage) >= 105700 && (MZPrice + MYPostage) <= 106300)
                        //                            {
                        //                                allprice = 48000.00M;
                        //                                CreatOrderInfo();
                        //                            }
                        //                            else
                        //                            {
                        //                                MessageBox.Show("您报单的价格不符合标准，价格应该处于￥105700-￥106300之间！");
                        //                            }
                        //                        }
                        //                        else if (shopcategoryid == 6)
                        //                        {
                        //                            if ((MZPrice + MYPostage) >= 35900 && (MZPrice + MYPostage) <= 36100)
                        //                            {
                        //                                allprice = 18000.00M;
                        //                                CreatOrderInfo();

                        //                            }
                        //                            else
                        //                            {
                        //                                MessageBox.Show("您报单的价格不符合标准，价格应该处于￥35900-￥36100之间！");
                        //                            }
                        //                        }
                        //                        else
                        //                        {
                        //                            CreatOrderInfo();
                        //                        }
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
                        //            }
                        //            else
                        //            {
                        //                if (RepeaterShopCart2.Items.Count <= 0)
                        //                {
                        //                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "msg", "alert(\"当前结算商品为空,请购买商品后去结算!\");",
                        //                        true);
                        //                }
                        //                else
                        //                {
                        //                    if (shopcategoryid == 4)
                        //                    {
                        //                        if ((MZPrice + MYPostage) >= 105700 && (MZPrice + MYPostage) <= 106300)
                        //                        {
                        //                            allprice = 48000.00M;
                        //                            CreatOrderInfo();
                        //                        }
                        //                        else
                        //                        {
                        //                            MessageBox.Show("您报单的价格不符合标准，价格应该处于￥105700-￥106300之间！");
                        //                        }
                        //                    }
                        //                    else if (shopcategoryid == 6)
                        //                    {
                        //                        if ((MZPrice + MYPostage) >= 35900 && (MZPrice + MYPostage) <= 36100)
                        //                        {
                        //                            allprice = 18000.00M;
                        //                            CreatOrderInfo();

                        //                        }
                        //                        else
                        //                        {
                        //                            MessageBox.Show("您报单的价格不符合标准，价格应该处于￥35900-￥36100之间！");
                        //                        }
                        //                    }
                        //                    else
                        //                    {
                        //                        CreatOrderInfo();
                        //                    }
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
                        //    }
                        //    else
                        //    {
                        //        if (RepeaterShopCart2.Items.Count <= 0)
                        //        {
                        //            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "msg", "alert(\"当前结算商品为空,请购买商品后去结算!\");",
                        //                true);
                        //        }
                        //        else
                        //        {
                        //            if (shopcategoryid == 4)
                        //            {
                        //                if ((MZPrice + MYPostage) >= 105700 && (MZPrice + MYPostage) <= 106300)
                        //                {
                        //                    allprice = 48000.00M;
                        //                    CreatOrderInfo();
                        //                }
                        //                else
                        //                {
                        //                    MessageBox.Show("您报单的价格不符合标准，价格应该处于￥105700-￥106300之间！");
                        //                }
                        //            }
                        //            else if (shopcategoryid == 6)
                        //            {
                        //                if ((MZPrice + MYPostage) >= 35900 && (MZPrice + MYPostage) <= 36100)
                        //                {
                        //                    allprice = 18000.00M;
                        //                    CreatOrderInfo();

                        //                }
                        //                else
                        //                {
                        //                    MessageBox.Show("您报单的价格不符合标准，价格应该处于￥35900-￥36100之间！");
                        //                }
                        //            }
                        //            else
                        //            {
                        //                CreatOrderInfo();
                        //            }
                        //        }
                        //    }
                        //    #endregion
                        //}
                        #endregion
                        #region
                        if (RepeaterShoppingCartPayment.Items == null || RepeaterShoppingCartPayment.Items.Count == 0)
                        {
                            MessageBox.Show("支付方式不能为空！");
                        }
                        else
                        {
                            if (RepeaterShopCart2.Items.Count <= 0)
                            {
                                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "msg", "alert(\"当前结算商品为空,请购买商品后去结算!\");",
                                    true);
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
                    }
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", "alert(\"服务代理不存在！\")", true);
                }
            }
            else 
            {
                TextBox1.Text = "C0000001";
                #region
                if (RepeaterShoppingCartPayment.Items == null || RepeaterShoppingCartPayment.Items.Count == 0)
                {
                    MessageBox.Show("支付方式不能为空！");
                }
                else
                {
                    if (RepeaterShopCart2.Items.Count <= 0)
                    {
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "msg", "alert(\"当前结算商品为空,请购买商品后去结算!\");",
                            true);
                    }
                    else
                    {

                        CreatOrderInfo();

                    }
                }
                #endregion
            }

        }
        protected void CreatOrderInfo()
        {
            #region 创建订单
            BindPaymentMenthod();
            //DataTable InsertOrderInfoTable = ishopNum1_Cart_Action_0.SearchShopByMemLoginID_InsertOrderInfo(strMemLoginID, string_1);

            //RepeaterShopCart2.DataSource = InsertOrderInfoTable.DefaultView;
            //RepeaterShopCart2.DataBind();
            //for(int i=0;i<InsertOrderInfoTable.Rows.Count;i++)
            //{
            //    DataTable datableone = ishopNum1_Cart_Action_0.SearchByShopMemID_free(strMemLoginID, string_1, Convert.ToInt32(InsertOrderInfoTable.Rows[i]["shop_category_id"]));

            //    RepeaterShopProduct.DataSource = datableone.DefaultView;
            //    RepeaterShopProduct.DataBind();
            //}

            var list = new List<ShopNum1_OrderInfo>();
            var list2 = new List<ShopNum1_OrderProduct>();
            IShopNum1_Address_Action shopNum1_Address_Action = LogicFactory.CreateShopNum1_Address_Action();
            foreach (RepeaterItem repeaterItem in RepeaterShopCart2.Items)
            {
                dropDownList_1 = (DropDownList)repeaterItem.FindControl("DropDownListPost");
                if (!(dropDownList_1.SelectedValue != "") || dropDownList_1.SelectedValue.Split(new[]
                        {
                            ':'
                        })[1] != "-1")
                {
                }
            }
            var order = new Order();
            string text = order.CreateOrderNumberDD(strMemLoginID);
            string text2 = text;
            Thread.Sleep(5);
            int num = 0;
            DataTable dataTable = ishopNum1_Cart_Action_0.SearchShopByMemLoginID(strMemLoginID, string_1);
            ShopNum1_Member_Action member_Action = (ShopNum1_Member_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Member_Action();

            string text3 = string.Empty;
            foreach (RepeaterItem repeaterItem2 in RepeaterShopCart2.Items)
            {
                Thread.Sleep(5);
                var shopNum1_OrderInfo = new ShopNum1_OrderInfo();
                shopNum1_OrderInfo.MemLoginID = strMemLoginID;

                shopNum1_OrderInfo.SuperiorRank = new Guid("00000000-0000-0000-0000-000000000000");

                shopNum1_OrderInfo.TradeID = text2;
                shopNum1_OrderInfo.ServiceAgent = TextBox1.Text.Trim();

                if (HiddenFieldPaymentName.Value == "货到付款" || HiddenFieldPaymentName.Value.IndexOf("线下") != -1)
                {
                    shopNum1_OrderInfo.OderStatus = 0;
                }
                else
                {
                    shopNum1_OrderInfo.OderStatus = 0;
                }

                shopNum1_OrderInfo.ShipmentStatus = 0;
                shopNum1_OrderInfo.PaymentStatus = 0;
                shopNum1_OrderInfo.OrderType = 0;
                shopNum1_OrderInfo.PayMentMemLoginID = PayMentMemLoginID;
                dropDownList_1 = (DropDownList)repeaterItem2.FindControl("DropDownListPost");
                if (!(dropDownList_1.SelectedValue != ""))
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "msg",
                        "alert(\"该订单商品已被商家删除或下架!\");window.location.href='/default.aspx';", true);
                    return;
                }
                if (dropDownList_1.SelectedValue.Split(new[]
                        {
                            ':'
                        })[1] == "-1")
                {
                    shopNum1_OrderInfo.IsMinus = 1;
                }
                else
                {
                    shopNum1_OrderInfo.IsMinus = 0;
                }


                if (HiddenFieldAddressGuid.Value == "-1" && Page.Request.Cookies["MemberLoginCookie"] != null)
                {
                    #region 防屏蔽js 备用
                    if (TextBoxName.Text == "" || HiddenFieldAddressName.Value == "-1" || TextBoxAddress.Text == "" || TextBoxMobile.Text == "")
                    {

                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "msg",
                      "alert(\"收货地址信息不完整!\");window.location.href='/default.aspx';", true);
                        return;
                    }
                    #endregion
                    shopNum1_OrderInfo.Name = TextBoxName.Text.Trim();
                    shopNum1_OrderInfo.Email = TextBoxEmail.Text.Trim();
                    shopNum1_OrderInfo.Address = HiddenFieldAddressName.Value + "  " +
                                                 TextBoxAddress.Text.Trim();
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
                    shopNum1_Address.Mobile = TextBoxMobile.Text.Trim();
                    shopNum1_Address.Guid = Guid.NewGuid();
                    shopNum1_Address.MemLoginID = strMemLoginID;
                    shopNum1_Address.CreateTime =
                        Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    shopNum1_Address.IsDeleted = 0;
                    shopNum1_Address.ModifyTime =
                        Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    shopNum1_Address.IsDefault = 1;
                    if (shopNum1_OrderInfo.Mobile != "" &&
                        shopNum1_OrderInfo.Address.Replace(",", "").Trim() != "-1")
                    {
                        Thread.Sleep(200);
                        IShopNum1_Address_Action shopNum1_Address_Action2 =
                            LogicFactory.CreateShopNum1_Address_Action();
                        shopNum1_Address_Action2.Add(shopNum1_Address);
                    }
                }
                else
                {
                    DataTable dataTable2 = shopNum1_Address_Action.Search(HiddenFieldAddressGuid.Value);
                    shopNum1_OrderInfo.Name = dataTable2.Rows[0]["Name"].ToString();
                    shopNum1_OrderInfo.Email = dataTable2.Rows[0]["Email"].ToString();
                    shopNum1_OrderInfo.Address = dataTable2.Rows[0]["area"] + " " +
                                                 dataTable2.Rows[0]["Address"];
                    shopNum1_OrderInfo.Postalcode = dataTable2.Rows[0]["Postalcode"].ToString();
                    shopNum1_OrderInfo.Tel = dataTable2.Rows[0]["Tel"].ToString();
                    shopNum1_OrderInfo.Mobile = dataTable2.Rows[0]["Mobile"].ToString();
                }
                ViewState["tel"] = shopNum1_OrderInfo.Mobile;
                ViewState["Email"] = shopNum1_OrderInfo.Email;
                shopNum1_OrderInfo.PaymentGuid = new Guid(HiddenFieldPaymentGuid.Value);
                shopNum1_OrderInfo.PaymentName = HiddenFieldPaymentName.Value;
                shopNum1_OrderInfo.PaymentPrice = Convert.ToDecimal(HiddenFieldPaymentPriceValue.Value.Trim());
                TextBoxMessage = (TextBox)repeaterItem2.FindControl("TextBoxMessage");
                shopNum1_OrderInfo.ClientToSellerMsg = TextBoxMessage.Text.Trim();
                shopNum1_OrderInfo.SellerToClientMsg = "";
                shopNum1_OrderInfo.ReceivedDays = int.Parse(ShopSettings.GetValue("DefaultReceivedDays"));
                shopNum1_OrderInfo.IsMemdelay = 0;
                var radioButtonList = (RadioButtonList)repeaterItem2.FindControl("RadioButtonListInvoice");
                if (radioButtonList.SelectedValue == "1")
                {
                    shopNum1_OrderInfo.InvoiceTitle = "";
                    shopNum1_OrderInfo.InvoiceContent = "";
                }
                else
                {
                    var textBox = (TextBox)repeaterItem2.FindControl("TextBoxInvoicespayable");
                    var textBox2 = (TextBox)repeaterItem2.FindControl("TextBoxInvoice");
                    shopNum1_OrderInfo.InvoiceTitle = textBox.Text.Trim();
                    shopNum1_OrderInfo.InvoiceContent = textBox2.Text.Trim();
                }
                shopNum1_OrderInfo.InvoiceType = "";
                shopNum1_OrderInfo.InvoiceTax = 0m;
                shopNum1_OrderInfo.OutOfStockOperate = "";
                shopNum1_OrderInfo.PackGuid = Guid.NewGuid();
                shopNum1_OrderInfo.PackName = "";
                shopNum1_OrderInfo.PackPrice = 0m;
                shopNum1_OrderInfo.BlessCardGuid = Guid.NewGuid();
                shopNum1_OrderInfo.BlessCardName = "";
                shopNum1_OrderInfo.BlessCardPrice = 0m;
                shopNum1_OrderInfo.BlessCardContent = "";
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


                if (HiddenFieldAddressGuid.Value != "-1")
                {
                    shopNum1_OrderInfo.RegionCode = HiddenFieldAddressCode.Value;
                }
                else
                {
                    shopNum1_OrderInfo.RegionCode = HiddenFieldAddressCode.Value;
                }
                shopNum1_OrderInfo.Guid = Guid.NewGuid();
                labelAllPrice.Text = "0";
                string value = "0";
                dropDownList_1 = (DropDownList)repeaterItem2.FindControl("DropDownListPost");
                var repeater = (Repeater)repeaterItem2.FindControl("RepeaterShopProduct");
                decimal num2 = 0m;
                foreach (RepeaterItem repeaterItem3 in repeater.Items)
                {
                    string ProductGuid = ((HiddenField)repeaterItem3.FindControl("HiddenFieldProductGuid")).Value;
                    int category_id = Convert.ToInt32(((HiddenField)repeaterItem3.FindControl("HiddenFieldCategoryID")).Value);
                    string CarSize = ((HiddenField)repeaterItem3.FindControl("HiddenFieldCarSize")).Value;
                    string CarColor = ((HiddenField)repeaterItem3.FindControl("HiddenFieldCarColor")).Value;
                    var shop_Product_Action = (Shop_Product_Action)ShopFactory.LogicFactory.CreateShop_Product_Action();
                    DataTable dataTable1 = ishopNum1_Cart_Action_0.SearchShopByMemLoginID_Price(strMemLoginID, string_1, ProductGuid, category_id, CarSize, CarColor);
                    if (dataTable1.Rows.Count > 0)
                    {
                        ShangPinPrice += Convert.ToDecimal(dataTable1.Rows[0]["ShopPrice"]) * Convert.ToDecimal(dataTable1.Rows[0]["BuyNumber"]);
                        shopNum1_OrderInfo.score_pv_cv += Convert.ToDecimal(dataTable1.Rows[0]["Score_pv_cv"]);
                        //   DataTable shopProductEdit = shop_Product_Action.GetShopProductEdit_two(string_1, shopid);
                        // * Convert.ToDecimal(dataTable1.Rows[0]["BuyNumber"])
                        //可用重销币
                        shopNum1_OrderInfo.Score_dv += Convert.ToDecimal(dataTable1.Rows[0]["Score_dv"]) * Convert.ToDecimal(dataTable1.Rows[0]["BuyNumber"]);
                        //得到红包
                        if (Convert.ToDecimal(dataTable1.Rows[0]["Score_hv"]) >= 0)
                        {
                            shopNum1_OrderInfo.Score_hv += Convert.ToDecimal(dataTable1.Rows[0]["Score_hv"]) * Convert.ToDecimal(dataTable1.Rows[0]["BuyNumber"]);
                        }
                        //可用红包
                        if (Convert.ToDecimal(dataTable1.Rows[0]["Score_max_hv"]) < 0)
                        {
                            shopNum1_OrderInfo.score_reduce_hv += Convert.ToDecimal(dataTable1.Rows[0]["Score_max_hv"]) * Convert.ToDecimal(dataTable1.Rows[0]["BuyNumber"]);
                        }
                        //得到积分
                        if (Convert.ToDecimal(dataTable1.Rows[0]["Score_pv_a"]) >= 0)
                        {
                            shopNum1_OrderInfo.Score_pv_a += Convert.ToDecimal(dataTable1.Rows[0]["Score_pv_a"]) * Convert.ToDecimal(dataTable1.Rows[0]["BuyNumber"]);
                        }
                        //可用积分  不知道对不对
                        if (Convert.ToDecimal(dataTable1.Rows[0]["Score_pv_a"]) < 0)
                        {
                            shopNum1_OrderInfo.score_reduce_pv_a += Convert.ToDecimal(dataTable1.Rows[0]["Score_pv_a"]) * Convert.ToDecimal(dataTable1.Rows[0]["BuyNumber"]);
                        }
                        //积分



                        shopNum1_OrderInfo.Score_pv_b += Convert.ToDecimal(dataTable1.Rows[0]["Score_pv_b"]) * Convert.ToDecimal(dataTable1.Rows[0]["BuyNumber"]);
                        shopNum1_OrderInfo.shop_category_id = Convert.ToInt32(dataTable1.Rows[0]["shop_category_id"]);

                        /* e1 += Convert.ToDecimal(shopProductEdit.Rows[0]["Score_cv"]);
                         f += Convert.ToDecimal(shopProductEdit.Rows[0]["Score_max_hv"]);*/






                           //if (Convert.ToString(shopProductEdit.Rows[0]["AgentId"])=="")
                           // {
                           //     shopNum1_OrderInfo.AgentId = "0";
                           // }
                           // else
                           // {
                           //     shopNum1_OrderInfo.AgentId = Convert.ToString(shopProductEdit.Rows[0]["AgentId"]);
                           // }

                        shopNum1_OrderInfo.AgentId = Convert.ToString(dataTable1.Rows[0]["AgentId"]);



                        /* shopNum1_OrderInfo.Score_cv = e1;
                         shopNum1_OrderInfo.Score_max_hv = f;*/

                        var label = (Label)repeaterItem3.FindControl("LabelAll");
                        labelAllPrice.Text =
                            Convert.ToString(Convert.ToDecimal(labelAllPrice.Text) + Convert.ToDecimal(label.Text));
                        value = Convert.ToString(Convert.ToDecimal(value) + Convert.ToDecimal(label.Text));
                        var hiddenField = (HiddenField)repeaterItem3.FindControl("HiddenFieldFeeType");
                        var hiddenField2 = (HiddenField)repeaterItem3.FindControl("HiddenFieldMinusFee");
                        if (hiddenField.Value == "1")
                        {
                            num2 += Convert.ToDecimal(hiddenField2.Value);
                        }
                        var arg_AB8_0 = (Label)repeaterItem3.FindControl("LabelBuyPrice");
                        var arg_ACA_0 = (TextBox)repeaterItem3.FindControl("TextBoxBuyNumber");
                        var label2 = repeaterItem2.FindControl("LabelShopName") as Label;
                        var label3 = repeaterItem3.FindControl("lbProductName") as Label;
                        if (ShopSettings.GetValue("OrderToShopIsEmail") == "1")
                        {
                            IsEmail(shopNum1_OrderInfo.Email, label2.Text, shopNum1_OrderInfo.OrderNumber,
                                strMemLoginID, shopNum1_OrderInfo.Tel, label3.Text, shopNum1_OrderInfo.Mobile);
                        }
                        if (ShopSettings.GetValue("OrderToShopIsMMS") == "1")
                        {
                            string nameById = Common.Common.GetNameById("Mobile", "ShopNum1_Member",
                                " and memloginId='" + label2.Text + "'");
                            IsMMS(nameById, label2.Text, strMemLoginID, shopNum1_OrderInfo.Tel,
                                shopNum1_OrderInfo.OrderNumber, label3.Text.Trim(), shopNum1_OrderInfo.Mobile);
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "msg",
                        "alert(\"该订单中有商品已被商家删除或下架!请删除购物车重新下单！\");window.location.href='/default.aspx';", true);
                        return;
                    }
                }
                if (dropDownList_1.SelectedValue != "")
                {
                    if (dropDownList_1.SelectedValue.Split(new[]
                            {
                                ':'
                            })[1] == "-1")
                    {
                        labelAllPrice.Text =
                            Convert.ToString(Convert.ToDecimal(labelAllPrice.Text) +
                                             Convert.ToDecimal(dropDownList_1.SelectedValue.Split(new[]
                                                     {
                                                         ':'
                                                     })[0]) - num2);
                    }
                    else
                    {
                        labelAllPrice.Text =
                            Convert.ToString(Convert.ToDecimal(labelAllPrice.Text) +
                                             Convert.ToDecimal(dropDownList_1.SelectedValue.Split(new[]
                                                     {
                                                         ':'
                                                     })[0]));
                    }
                }

                foreach (RepeaterItem repeaterItem in RepeaterShoppingCartPayment.Items)
                {
                    var radioButton = (RadioButton)repeaterItem.FindControl("RadioButtonPayment");
                    if (radioButton.Checked)
                    {
                        var hiddenField3 = (HiddenField)repeaterItem.FindControl("HiddenFieldIsPersent");
                        if (hiddenField3.Value == "1")
                        {
                        }
                        label_7 = (Label)repeaterItem.FindControl("LabelCharge");
                        Convert.ToDecimal("0.00");
                        break;
                    }
                }
                labelAllPrice.Text = Convert.ToString(Convert.ToDecimal(labelAllPrice.Text));
                string value2 = ShopSettings.GetValue("IsRecommendCommisionOpen");
                if (value2 == "true")
                {
                    ShopSettings.GetValue("RecommendCommision");
                    double num3 = Convert.ToDouble(ShopSettings.GetValue("RecommendCommision")) / 100.0;
                    shopNum1_OrderInfo.RecommendCommision =
                        Convert.ToDecimal(Convert.ToDouble(labelAllPrice.Text) * num3);
                }
                else
                {
                    shopNum1_OrderInfo.RecommendCommision = 0m;
                }
                var order2 = new Order();
                if (RepeaterShopCart2.Items.Count == 1)
                {
                    shopNum1_OrderInfo.OrderNumber = text2;
                }
                else
                {
                    shopNum1_OrderInfo.OrderNumber = order2.CreateOrderNumber();
                }
                if (ViewState["OrderNumber"] == null)
                {
                    ViewState["OrderNumber"] = shopNum1_OrderInfo.OrderNumber;
                }
                else
                {
                    StateBag viewState;
                    (viewState = ViewState)["OrderNumber"] = viewState["OrderNumber"] + "," +
                                                             shopNum1_OrderInfo.OrderNumber;
                }
                var label4 = (Label)repeaterItem2.FindControl("LabelShopName");
                var label5 = (Label)repeaterItem2.FindControl("LabelSellName");

                shopNum1_OrderInfo.ShopName = label5.Text;
                shopNum1_OrderInfo.ShopID = label4.Text;
                if (text3 == string.Empty)
                {
                    text3 = shopNum1_OrderInfo.ShopID;
                }
                else
                {
                    text3 = text3 + "," + shopNum1_OrderInfo.ShopID;
                }

                shopNum1_OrderInfo.ProductPrice = Convert.ToDecimal(value);
                shopNum1_OrderInfo.ProductPv_b = shopNum1_OrderInfo.Score_pv_b;
                if (shopNum1_OrderInfo.ServiceAgent != "" && shopNum1_OrderInfo.ServiceAgent.ToUpper() != "C0000001")
                {
                    shopNum1_OrderInfo.DispatchType = 0;
                    shopNum1_OrderInfo.FeeType = 1;
                    shopNum1_OrderInfo.DispatchPrice = Convert.ToDecimal(0.0);
                    shopNum1_OrderInfo.ShouldPayPrice = ShangPinPrice;
                }
                else
                {
                    if (allprice != 0M)
                    {

                        #region 加减邮费
                        if (dropDownList_1.SelectedValue != "")
                        {
                            if (dropDownList_1.SelectedValue.Split(new[]
                            {
                                ':'
                            })[1] == "-2")
                            {
                                shopNum1_OrderInfo.DispatchType = 0;
                                shopNum1_OrderInfo.FeeType = 1;
                                shopNum1_OrderInfo.DispatchPrice = Convert.ToDecimal(0.0);
                                shopNum1_OrderInfo.ShouldPayPrice = allprice;
                            }
                            else if (dropDownList_1.SelectedValue.Split(new[]
                            {
                                ':'
                            })[1] == "4")
                            {
                                shopNum1_OrderInfo.DispatchType = 0;
                                shopNum1_OrderInfo.FeeType = 1;
                                shopNum1_OrderInfo.DispatchPrice = 0;
                                shopNum1_OrderInfo.ShouldPayPrice = allprice;
                            }
                            else if (dropDownList_1.SelectedValue.Split(new[]
                            {
                                ':'
                            })[1] == "5")
                            {
                                shopNum1_OrderInfo.DispatchType = 0;
                                shopNum1_OrderInfo.FeeType = 1;
                                shopNum1_OrderInfo.DispatchPrice = 0;
                                shopNum1_OrderInfo.ShouldPayPrice = allprice;
                            }
                            else if (dropDownList_1.SelectedValue.Split(new[]
                            {
                                ':'
                            })[1] == "6")
                            {
                                shopNum1_OrderInfo.DispatchType = 0;
                                shopNum1_OrderInfo.FeeType = 1;
                                shopNum1_OrderInfo.DispatchPrice = 0;
                                shopNum1_OrderInfo.ShouldPayPrice = allprice;
                            }
                            else
                            {
                                shopNum1_OrderInfo.FeeType = 0;
                                shopNum1_OrderInfo.DispatchType = int.Parse(dropDownList_1.SelectedValue.Split(new[]
                                {
                                    ':'
                                })[1]);
                                if (dropDownList_1.SelectedValue.Split(new[]
                                {
                                    ':'
                                })[1] == "-1")
                                {
                                    shopNum1_OrderInfo.FeeType = 1;
                                }
                                shopNum1_OrderInfo.DispatchPrice =
                                    Convert.ToDecimal(dropDownList_1.SelectedValue.Split(new[]
                                    {
                                        ':'
                                    })[0]);
                            }
                        }
                        #endregion
                    }
                    else
                    {

                        //shopNum1_OrderInfo.ShouldPayPrice = ShangPinPrice + MYPostage;

                        #region 加减邮费
                        if (dropDownList_1.SelectedValue != "")
                        {
                            if (dropDownList_1.SelectedValue.Split(new[]
                            {
                                ':'
                            })[1] == "-2")
                            {
                                shopNum1_OrderInfo.DispatchType = 0;
                                shopNum1_OrderInfo.FeeType = 1;
                                shopNum1_OrderInfo.DispatchPrice = Convert.ToDecimal(0.0);
                                shopNum1_OrderInfo.ShouldPayPrice = ShangPinPrice;
                            }
                            else if (dropDownList_1.SelectedValue.Split(new[]
                            {
                                ':'
                            })[1] == "-3")
                            {
                                shopNum1_OrderInfo.DispatchType = 0;
                                shopNum1_OrderInfo.FeeType = 1;
                                shopNum1_OrderInfo.DispatchPrice = 40;
                                shopNum1_OrderInfo.ShouldPayPrice = ShangPinPrice + 40;
                            }
                            else if (dropDownList_1.SelectedValue.Split(new[]
                            {
                                ':'
                            })[1] == "4")
                            {
                                shopNum1_OrderInfo.DispatchType = 0;
                                shopNum1_OrderInfo.FeeType = 1;
                                shopNum1_OrderInfo.DispatchPrice = MYPostage;
                                shopNum1_OrderInfo.ShouldPayPrice = ShangPinPrice + MYPostage;
                            }
                            else if (dropDownList_1.SelectedValue.Split(new[]
                            {
                                ':'
                            })[1] == "5")
                            {
                                shopNum1_OrderInfo.DispatchType = 0;
                                shopNum1_OrderInfo.FeeType = 1;
                                shopNum1_OrderInfo.DispatchPrice = WLPostage;
                                shopNum1_OrderInfo.ShouldPayPrice = ShangPinPrice + WLPostage;
                            }
                            else if (dropDownList_1.SelectedValue.Split(new[]
                            {
                                ':'
                            })[1] == "6")
                            {
                                shopNum1_OrderInfo.DispatchType = 0;
                                shopNum1_OrderInfo.FeeType = 1;
                                shopNum1_OrderInfo.DispatchPrice = VIPPostage;
                                shopNum1_OrderInfo.ShouldPayPrice = ShangPinPrice + VIPPostage;
                            }
                            else
                            {
                                shopNum1_OrderInfo.FeeType = 0;
                                shopNum1_OrderInfo.DispatchType = int.Parse(dropDownList_1.SelectedValue.Split(new[]
                                {
                                    ':'
                                })[1]);
                                if (dropDownList_1.SelectedValue.Split(new[]
                                {
                                    ':'
                                })[1] == "-1")
                                {
                                    shopNum1_OrderInfo.FeeType = 1;
                                }
                                shopNum1_OrderInfo.DispatchPrice =
                                    Convert.ToDecimal(dropDownList_1.SelectedValue.Split(new[]
                                    {
                                        ':'
                                    })[0]);
                            }
                        }
                        #endregion
                    }
                }
                list.Add(shopNum1_OrderInfo);

                var dataTable3 = new DataTable();
                if (string_1 == string.Empty)
                {
                    dataTable3 = ishopNum1_Cart_Action_0.SearchByMemLoginIDAndShopID(strMemLoginID,
                        dataTable.Rows[num]["ShopID"].ToString());
                }
                else
                {
                    dataTable3 = ishopNum1_Cart_Action_0.SearchByMemLoginIDAndShopID(strMemLoginID,
                        dataTable.Rows[num]["ShopID"].ToString(), string_1);
                }
                for (int i = 0; i < dataTable3.Rows.Count; i++)
                {
                    if (Convert.ToInt32(dataTable3.Rows[i]["shop_category_id"]) == shopNum1_OrderInfo.shop_category_id)
                    {
                        //if (shopNum1_OrderInfo.ServiceAgent != "" && shopNum1_OrderInfo.ServiceAgent.ToUpper() != "C0000001")
                        //{
                        //    list2.Add(new ShopNum1_OrderProduct
                        //    {
                        //        ProductImg = dataTable3.Rows[i]["originalimge"].ToString(),
                        //        OrderType = Convert.ToInt32(dataTable3.Rows[i]["carttype"].ToString()),
                        //        Guid = Guid.NewGuid(),
                        //        OrderInfoGuid = shopNum1_OrderInfo.Guid.ToString(),
                        //        ProductGuid = dataTable3.Rows[i]["ProductGuid"].ToString(),
                        //        GroupPrice = Convert.ToDecimal("0.00"),
                        //        SpecificationName = dataTable3.Rows[i]["SpecificationName"].ToString(),
                        //        SpecificationValue = dataTable3.Rows[i]["SpecificationValue"].ToString(),
                        //        setStock = dataTable3.Rows[i]["Attributes"].ToString(),
                        //        ProductName = dataTable3.Rows[i]["Name"].ToString(),
                        //        RepertoryNumber = dataTable3.Rows[i]["RepertoryNumber"].ToString(),
                        //        BuyNumber = 0,
                        //        MarketPrice = Convert.ToDecimal(dataTable3.Rows[i]["MarketPrice"].ToString()),
                        //        ShopPrice = Convert.ToDecimal(dataTable3.Rows[i]["ShopPrice"].ToString()),
                        //        BuyPrice = Convert.ToDecimal(dataTable3.Rows[i]["BuyPrice"].ToString()),
                        //        Attributes = dataTable3.Rows[i]["Attributes"].ToString(),
                        //        IsShipment = Convert.ToInt32(dataTable3.Rows[i]["IsShipment"].ToString()),
                        //        IsReal = Convert.ToInt32(dataTable3.Rows[i]["IsReal"].ToString()),
                        //        ExtensionAttriutes = dataTable3.Rows[i]["ExtensionAttriutes"].ToString(),
                        //        IsJoinActivity = Convert.ToInt32(dataTable3.Rows[i]["IsJoinActivity"].ToString()),
                        //        CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                        //        DetailedSpecifications = dataTable3.Rows[i]["DetailedSpecifications"].ToString(),
                        //        MemLoginID = strMemLoginID,
                        //        ShopID = dataTable3.Rows[i]["ShopID"].ToString(),
                        //        shop_category_id = Convert.ToInt32(dataTable3.Rows[i]["shop_category_id"]),
                        //        Size = dataTable3.Rows[i]["Size"].ToString(),
                        //        Color = dataTable3.Rows[i]["Color"].ToString()

                        //    });
                        //}
                        //else
                        //{
                            list2.Add(new ShopNum1_OrderProduct
                            {
                                ProductImg = dataTable3.Rows[i]["originalimge"].ToString(),
                                OrderType = Convert.ToInt32(dataTable3.Rows[i]["carttype"].ToString()),
                                Guid = Guid.NewGuid(),
                                OrderInfoGuid = shopNum1_OrderInfo.Guid.ToString(),
                                ProductGuid = dataTable3.Rows[i]["ProductGuid"].ToString(),
                                GroupPrice = Convert.ToDecimal("0.00"),
                                SpecificationName = dataTable3.Rows[i]["SpecificationName"].ToString(),
                                SpecificationValue = dataTable3.Rows[i]["SpecificationValue"].ToString(),
                                setStock = dataTable3.Rows[i]["Attributes"].ToString(),
                                ProductName = dataTable3.Rows[i]["Name"].ToString(),
                                RepertoryNumber = dataTable3.Rows[i]["RepertoryNumber"].ToString(),
                                BuyNumber = Convert.ToInt32(dataTable3.Rows[i]["BuyNumber"].ToString()),
                                MarketPrice = Convert.ToDecimal(dataTable3.Rows[i]["MarketPrice"].ToString()),
                                ShopPrice = Convert.ToDecimal(dataTable3.Rows[i]["ShopPrice"].ToString()),
                                BuyPrice = Convert.ToDecimal(dataTable3.Rows[i]["BuyPrice"].ToString()),
                                Attributes = dataTable3.Rows[i]["Attributes"].ToString(),
                                IsShipment = Convert.ToInt32(dataTable3.Rows[i]["IsShipment"].ToString()),
                                IsReal = Convert.ToInt32(dataTable3.Rows[i]["IsReal"].ToString()),
                                ExtensionAttriutes = dataTable3.Rows[i]["ExtensionAttriutes"].ToString(),
                                IsJoinActivity = Convert.ToInt32(dataTable3.Rows[i]["IsJoinActivity"].ToString()),
                                CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                                DetailedSpecifications = dataTable3.Rows[i]["DetailedSpecifications"].ToString(),
                                MemLoginID = strMemLoginID,
                                ShopID = dataTable3.Rows[i]["ShopID"].ToString(),
                                shop_category_id = Convert.ToInt32(dataTable3.Rows[i]["shop_category_id"]),
                                Size = dataTable3.Rows[i]["Size"].ToString(),
                                Color = dataTable3.Rows[i]["Color"].ToString()

                            });
                        
                    }
                }
                num++;
            }
            var shopNum1_OrderInfo_Action =
                (ShopNum1_OrderInfo_Action)LogicFactory.CreateShopNum1_OrderInfo_Action();
            int num4 = shopNum1_OrderInfo_Action.Add(list, list2);
            if (num4 > 0)
            {
                int num5;
                if (string_1 == string.Empty)
                {
                    num5 = ishopNum1_Cart_Action_0.DeleteByMemLoginID(strMemLoginID);
                }
                else
                {
                    num5 = ishopNum1_Cart_Action_0.DeleteByMemLoginID(strMemLoginID, string_1);
                }
                if (num5 > 0)
                {
                }
                var shopNum1_Member_Action =
                    (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
                DataTable memberInfoByMemLoginID =
                    shopNum1_Member_Action.GetMemberInfoByMemLoginID(strMemLoginID);
                if (memberInfoByMemLoginID.Rows.Count > 0)
                {
                    if (ShopSettings.GetValue("OrderIsEmail") == "1")
                    {
                        IsEmail(ViewState["OrderNumber"].ToString(), strMemLoginID,
                            memberInfoByMemLoginID.Rows[0]["email"].ToString());
                    }
                    if (ShopSettings.GetValue("SubmitOrderIsMMS") == "1" && ViewState["tel"] != null)
                    {
                        IsMMS(ViewState["OrderNumber"].ToString(), strMemLoginID, ViewState["tel"].ToString());
                    }
                }
                Page.Response.Redirect(GetPageName.RetDomainUrl("ShoppingCart3", text2, "tradeid"));
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", "alert(\"购买失败！\")", true);
            }
            #endregion
        }
        protected void method_3()
        {
            foreach (RepeaterItem repeaterItem in RepeaterShopCart2.Items)
            {
                var label = (Label)repeaterItem.FindControl("LabelShopName");
                dropDownList_1 = (DropDownList)repeaterItem.FindControl("DropDownListPost");
                dropDownList_1.SelectedIndexChanged += dropDownList_1_SelectedIndexChanged;
                dropDownList_1.Items.Clear();
                string path = Shop_Common_Action.GetShopPath(label.Text.Trim()) + "xml/PostageTemplate.xml";
                string regioncode = string.Empty;
                if (HiddenFieldAddressCode.Value == "-1")
                {
                    regioncode = "-1";
                }
                else
                {
                    if (HiddenFieldAddressCode.Value.Length > 3)
                    {
                        regioncode = HiddenFieldAddressCode.Value.Substring(0, 3);
                    }
                }
                DataTable productInfoByCartProductGuid =
                    ishopNum1_Cart_Action_0.GetProductInfoByCartProductGuid(strMemLoginID, label.Text.Trim(), string_1);
                if (productInfoByCartProductGuid == null || productInfoByCartProductGuid.Rows.Count == 0)
                {
                    break;
                }
                int num = 0;
                decimal num2 = Convert.ToDecimal(0.0);
                decimal num3 = Convert.ToDecimal(0.0);
                decimal num4 = Convert.ToDecimal(0.0);
                decimal num5 = Convert.ToDecimal(0.0);
                decimal Postage = Convert.ToDecimal(0.0);
                decimal HDFK = Convert.ToDecimal(1.1);
                decimal VIPYF = Convert.ToDecimal(1.2);
                MZPrice = Convert.ToDecimal(0.0);
                MYPostage = Convert.ToDecimal(0.0);
                WLPostage = Convert.ToDecimal(0.0);
                VIPPostage = Convert.ToDecimal(0.0);
                int category = 0;

                for (int i = 0; i < productInfoByCartProductGuid.Rows.Count; i++)
                {
                    num5 += Convert.ToDecimal(productInfoByCartProductGuid.Rows[i]["GoodsWeight"].ToString()) * Convert.ToDecimal(productInfoByCartProductGuid.Rows[i]["BuyNumber"].ToString());
                    category = Convert.ToInt32(productInfoByCartProductGuid.Rows[i]["shop_category_id"]);
                    MZPrice += Convert.ToDecimal(productInfoByCartProductGuid.Rows[i]["ShopPrice"].ToString()) * Convert.ToDecimal(productInfoByCartProductGuid.Rows[i]["BuyNumber"].ToString());
                }
                if (category == 2 || category == 5 || category == 7 || category == 9)
                {
                    ShopNum1_PostageSettings_Action PostageAction = (ShopNum1_PostageSettings_Action)LogicFactory.CreateShopNum1_PostageSettings_Action();
                    DataTable table = PostageAction.SelectPrice(label.Text.Trim());
                    if (num5 != 0 && (num5 < Convert.ToDecimal(table.Rows[0]["FirstHeavy"]) || num5 == Convert.ToDecimal(table.Rows[0]["FirstHeavy"])))
                    {
                        Postage = Convert.ToDecimal(table.Rows[0]["FirstHeavyPrice"]);
                        num = 1;
                        MYPostage = Postage;

                        if (category == 5 || category == 7)
                        {

                            if (MZPrice >= 3000)
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
                                WLPostage = 0M;

                            }
                        }
                        if (category == 2)
                        {
                            if (MZPrice >= 10000)
                            {
                                VIPPostage = 0;
                                num = 0;
                                Postage = 0;
                                VIPYF = 1;
                            }
                            else
                            {
                                VIPPostage = decimal.Multiply(MZPrice, (decimal)0.01);
                                if (VIPPostage < 10)
                                {
                                    VIPPostage = 10M;
                                }
                                num = 0;
                                Postage = 0;
                                VIPYF = 0;
                            }
                        }
                        if (category == 1)
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
                            if (category == 5 || category == 7)
                            {

                                if (MZPrice >= 3000)
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
                                    WLPostage = 0M;


                                }
                            }
                            if (category == 2)
                            {
                                if (MZPrice >= 10000)
                                {
                                    VIPPostage = 0;
                                    num = 0;
                                    Postage = 0;
                                    VIPYF = 1;
                                }
                                else
                                {
                                    VIPPostage = decimal.Multiply(MZPrice, (decimal)0.01);
                                    if (VIPPostage < 10)
                                    {
                                        VIPPostage = 10M;
                                    }
                                    num = 0;
                                    Postage = 0;
                                    VIPYF = 0;
                                }
                            }
                            if (category == 1)
                            {
                                num = 0;
                            }
                        }
                    }

                }
                #region 旧逻辑
                //string text = string.Empty;
                //for (int i = 0; i < productInfoByCartProductGuid.Rows.Count; i++)
                //{
                //    if (i < productInfoByCartProductGuid.Rows.Count - 1)
                //    {
                //        string text2 = text;
                //        text = string.Concat(new[]
                //        {
                //            text2,
                //            productInfoByCartProductGuid.Rows[i]["FeeTemplateID"].ToString(),
                //            ",",
                //            productInfoByCartProductGuid.Rows[i]["Express_fee"].ToString(),
                //            ",",
                //            productInfoByCartProductGuid.Rows[i]["Ems_fee"].ToString(),
                //            ",",
                //            productInfoByCartProductGuid.Rows[i]["Post_fee"].ToString(),
                //            ",",
                //            productInfoByCartProductGuid.Rows[i]["BuyNumber"].ToString(),
                //            "|"
                //        });
                //    }
                //    else
                //    {
                //        string text2 = text;
                //        text = string.Concat(new[]
                //        {
                //            text2,
                //            productInfoByCartProductGuid.Rows[i]["FeeTemplateID"].ToString(),
                //            ",",
                //            productInfoByCartProductGuid.Rows[i]["Express_fee"].ToString(),
                //            ",",
                //            productInfoByCartProductGuid.Rows[i]["Ems_fee"].ToString(),
                //            ",",
                //            productInfoByCartProductGuid.Rows[i]["Post_fee"].ToString(),
                //            ",",
                //            productInfoByCartProductGuid.Rows[i]["BuyNumber"].ToString()
                //        });
                //    }
                //}
                //HiddenFieldFeeTemplateIDandNumber.Value = text;
                //int num = 0;
                //decimal num2 = Convert.ToDecimal(0.0);
                //decimal num3 = Convert.ToDecimal(0.0);
                //decimal num4 = Convert.ToDecimal(0.0);
                //for (int i = 0; i < productInfoByCartProductGuid.Rows.Count; i++)
                //{
                //    if (productInfoByCartProductGuid.Rows[i]["FeeType"].ToString() != "1")
                //    {
                //        num = 1;
                //        if (productInfoByCartProductGuid.Rows[i]["FeeTemplateID"] != null &&
                //            productInfoByCartProductGuid.Rows[i]["FeeTemplateID"].ToString() != "" &&
                //            productInfoByCartProductGuid.Rows[i]["FeeTemplateID"].ToString() != "0")
                //        {
                //            var shop_FeeTemplate_Action = new Shop_FeeTemplate_Action();
                //            DataTable feesByFrontCache =
                //                shop_FeeTemplate_Action.GetFeesByFrontCache(HttpContext.Current.Server.MapPath(path),
                //                    "-1", "'" + productInfoByCartProductGuid.Rows[i]["FeeTemplateID"] + "'", regioncode,
                //                    "-1", false);
                //            if (feesByFrontCache != null)
                //            {
                //                IEnumerator enumerator2 = feesByFrontCache.Rows.GetEnumerator();
                //                try
                //                {
                //                    while (enumerator2.MoveNext())
                //                    {
                //                        var dataRow = (DataRow)enumerator2.Current;
                //                        decimal d = Convert.ToDecimal(dataRow["fee"].ToString()) +
                //                                    (int.Parse(
                //                                        productInfoByCartProductGuid.Rows[i]["BuyNumber"].ToString()) -
                //                                     1) * Convert.ToDecimal(dataRow["oneadd"].ToString());
                //                        if (dataRow["feetype"].ToString() == "1")
                //                        {
                //                            num2 += d;
                //                        }
                //                        else
                //                        {
                //                            if (dataRow["feetype"].ToString() == "2")
                //                            {
                //                                num3 += d;
                //                            }
                //                            else
                //                            {
                //                                if (dataRow["feetype"].ToString() == "3")
                //                                {
                //                                    num4 += d;
                //                                }
                //                            }
                //                        }
                //                    }
                //                    goto IL_767;
                //                }
                //                finally
                //                {
                //                    var disposable = enumerator2 as IDisposable;
                //                    if (disposable != null)
                //                    {
                //                        disposable.Dispose();
                //                    }
                //                }
                //            }
                //            if (!string.IsNullOrEmpty(productInfoByCartProductGuid.Rows[i]["Post_fee"].ToString()))
                //            {
                //                num2 += Convert.ToDecimal(productInfoByCartProductGuid.Rows[i]["Post_fee"].ToString());
                //            }
                //            if (!string.IsNullOrEmpty(productInfoByCartProductGuid.Rows[i]["Express_fee"].ToString()))
                //            {
                //                num3 += Convert.ToDecimal(productInfoByCartProductGuid.Rows[i]["Express_fee"].ToString());
                //            }
                //            if (!string.IsNullOrEmpty(productInfoByCartProductGuid.Rows[i]["Ems_fee"].ToString()))
                //            {
                //                num4 += Convert.ToDecimal(productInfoByCartProductGuid.Rows[i]["Ems_fee"].ToString());
                //            }
                //        }
                //        else
                //        {
                //            if (!string.IsNullOrEmpty(productInfoByCartProductGuid.Rows[i]["Post_fee"].ToString()))
                //            {
                //                num2 += Convert.ToDecimal(productInfoByCartProductGuid.Rows[i]["Post_fee"].ToString());
                //            }
                //            if (!string.IsNullOrEmpty(productInfoByCartProductGuid.Rows[i]["Express_fee"].ToString()))
                //            {
                //                num3 += Convert.ToDecimal(productInfoByCartProductGuid.Rows[i]["Express_fee"].ToString());
                //            }
                //            if (!string.IsNullOrEmpty(productInfoByCartProductGuid.Rows[i]["Ems_fee"].ToString()))
                //            {
                //                num4 += Convert.ToDecimal(productInfoByCartProductGuid.Rows[i]["Ems_fee"].ToString());
                //            }
                //        }
                //    }
                //IL_767:
                //    ;
                //}
                #endregion
                if (category == 5)
                {
                    //var listItem = new ListItem();
                    //listItem.Text = "进货邮费￥40";
                    //listItem.Value = 40 + ":-3";
                    //dropDownList_1.Items.Add(listItem);
                    //HiddenFieldDispatchPrice.Value = "40";
                    var listItem4 = new ListItem();
                    listItem4.Text = "免运费";
                    listItem4.Value = "0:-2";
                    dropDownList_1.Items.Add(listItem4);

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
                            var listItem = new ListItem();
                            listItem.Text = "平邮" + num2 + "元";
                            listItem.Value = num2 + ":1";
                            dropDownList_1.Items.Add(listItem);
                            flag2 = false;
                            HiddenFieldDispatchPrice.Value = num2.ToString();
                        }
                        if (num3 != 0m)
                        {
                            flag = false;
                            var listItem2 = new ListItem();
                            listItem2.Text = "快递" + num3 + "元";
                            listItem2.Value = num3 + ":2";
                            dropDownList_1.Items.Add(listItem2);
                            if (flag2)
                            {
                                HiddenFieldDispatchPrice.Value = num3.ToString();
                            }
                            flag3 = false;
                        }
                        if (num4 != 0m)
                        {
                            flag = false;
                            var listItem3 = new ListItem();
                            listItem3.Text = "EMS" + num4 + "元";
                            listItem3.Value = num4 + ":3";
                            dropDownList_1.Items.Add(listItem3);
                            if (flag3 & flag2)
                            {
                                HiddenFieldDispatchPrice.Value = num4.ToString();
                            }
                        }

                        if (Postage != 0m)
                        {
                            flag = false;
                            var listItem5 = new ListItem();
                            listItem5.Text = "邮费" + Postage + "元";
                            listItem5.Value = Postage + ":4";
                            dropDownList_1.Items.Add(listItem5);
                            if (flag3 & flag2)
                            {
                                HiddenFieldDispatchPrice.Value = Postage.ToString();
                            }
                        }
                        if (HDFK == 0m)
                        {
                            flag = false;
                            var listItem6 = new ListItem();
                            listItem6.Text = "货到付款";
                            listItem6.Value = HDFK + ":5";
                            dropDownList_1.Items.Add(listItem6);
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
                            dropDownList_1.Items.Add(listItem7);
                            if (flag3 & flag2)
                            {
                                HiddenFieldDispatchPrice.Value = VIPPostage.ToString();
                            }
                        }

                        if (flag)
                        {
                            var listItem4 = new ListItem();
                            listItem4.Text = "免运费";
                            listItem4.Value = "0:-2";
                            dropDownList_1.Items.Add(listItem4);
                        }
                    }
                    else
                    {
                        var listItem4 = new ListItem();
                        listItem4.Text = "免运费";
                        listItem4.Value = "0:-2";
                        dropDownList_1.Items.Add(listItem4);
                    }
                }
            }
        }

        protected void GetAllMoney()
        {
            labelAllPrice.Text = "0";
            decimal d = 0m;
            decimal d2 = 0m;
            decimal num = 0m;
            decimal num2 = 0m;
            bool flag = false;
            IEnumerator enumerator;
            for (int i = 0; i < RepeaterShopCart2.Items.Count; i++)
            {
                dropDownList_1 = (DropDownList)RepeaterShopCart2.Items[i].FindControl("DropDownListPost");
                var repeater = (Repeater)RepeaterShopCart2.Items[i].FindControl("RepeaterShopProduct");
                enumerator = repeater.Items.GetEnumerator();
                try
                {
                    while (enumerator.MoveNext())
                    {
                        var repeaterItem = (RepeaterItem)enumerator.Current;
                        var label = (Label)repeaterItem.FindControl("LabelAll");
                        var label2 = (Label)repeaterItem.FindControl("labelProductMarketPrice");
                        var label3 = (Label)repeaterItem.FindControl("labelBuyNumber");
                        d += Convert.ToDecimal(label.Text);
                        LabelOnlyProductPrice.Text = d.ToString();
                        d2 += Convert.ToInt32(label3.Text.Trim()) * Convert.ToDecimal(label2.Text.Trim());
                        if (dropDownList_1.SelectedValue != "" && dropDownList_1.SelectedValue.Split(new[]
                        {
                            ':'
                        })[1] == "-1")
                        {
                            var hiddenField = (HiddenField)repeaterItem.FindControl("HiddenFieldFeeType");
                            var hiddenField2 = (HiddenField)repeaterItem.FindControl("HiddenFieldMinusFee");
                            if (hiddenField.Value == "1")
                            {
                                num2 += Convert.ToDecimal(hiddenField2.Value);
                                flag = true;
                            }
                        }
                    }
                }
                finally
                {
                    var disposable = enumerator as IDisposable;
                    if (disposable != null)
                    {
                        disposable.Dispose();
                    }
                }
                try
                {
                    num += Convert.ToDecimal(dropDownList_1.SelectedValue.Split(new[]
                    {
                        ':'
                    })[0]);
                }
                catch
                {
                    num = 0m;
                }
            }
            labelMaretPrice.Text = d2.ToString();

            string a = string.Empty;
            enumerator = RepeaterShoppingCartPayment.Items.GetEnumerator();
            try
            {
                while (enumerator.MoveNext())
                {
                    var repeaterItem2 = (RepeaterItem)enumerator.Current;
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
                        label_7 = (Label)repeaterItem2.FindControl("LabelCharge");
                        Convert.ToDecimal("0.00");
                        break;
                    }
                }
            }
            finally
            {
                var disposable = enumerator as IDisposable;
                if (disposable != null)
                {
                    disposable.Dispose();
                }
            }
            if (a == "1")
            {
                if (flag)
                {
                    LabelBuyShopPrice.Text = (d + num + (d + num - num2) / 100m - num2).ToString("n");
                }
                else
                {
                    LabelBuyShopPrice.Text = (d + num + (d + num) / 100m).ToString("n");
                }
            }
            else
            {
                if (flag)
                {
                    LabelBuyShopPrice.Text = (d + num - num2).ToString("n");
                }
                else
                {
                    LabelBuyShopPrice.Text = (d + num).ToString("n");
                }
            }
            if (LabelOnlyProductPrice.Text == "")
            {
                LabelOnlyProductPrice.Text = "0";
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
                        ((d + num)/100m).ToString("n"),
                        "</b>元 +运费：<b>",
                        num.ToString("n"),
                        "</b>元 - 自提货优惠: <b>",
                        num2,
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
                        ((d + num)/100m).ToString("n"),
                        "</b>元 +运费：<b>",
                        num.ToString("n"),
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
                        "</b>元 + 运费：<b>",
                        num.ToString("n"),
                        "</b>元 - 自提货优惠:<b>",
                        num2,
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
                        "</b>元 + 运费：<b>",
                        num.ToString("n"),
                        "</b>元 =<b>",
                        LabelBuyShopPrice.Text.Replace(",", ""),
                        "</b>元"
                    });
                }
            }
            LabelAllCartPrice.Text = LabelBuyShopPrice.Text.Replace(",", "");
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
            var shopNum1_Address = new ShopNum1_Address();
            if (shopNum1_Address.Mobile != "" && shopNum1_Address.Address != "")
            {
                shopNum1_Address.Guid = Guid.NewGuid();
                shopNum1_Address.Name = TextBoxName.Text;
                shopNum1_Address.Email = TextBoxEmail.Text;
                shopNum1_Address.Address = TextBoxAddress.Text;
                shopNum1_Address.Area = HiddenFieldAddressName.Value;
                shopNum1_Address.AddressValue = HiddenFieldAddressName.Value;
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
                IShopNum1_Address_Action shopNum1_Address_Action = LogicFactory.CreateShopNum1_Address_Action();
                int num = shopNum1_Address_Action.Add(shopNum1_Address);
                if (num > 0)
                {
                    BindReceivingAddress();
                }
                TextBoxName.Text = (TextBoxMobile.Text = string.Empty);
            }
            else
            {
                MessageBox.Show("*号项为必填项！");
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
                DataTable editInfo = shopNum1_Email_Action.GetEditInfo(text2, 0);
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

        protected void IsEmail(string OrderNumber, string MemLoginID, string email)
        {
            if (email != null && !(email == ""))
            {
                string value = ShopSettings.GetValue("Name");
                var orderInfo = new OrderInfo();
                orderInfo.Name = MemLoginID;
                orderInfo.OrderNumber = OrderNumber;
                orderInfo.SysSendTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                orderInfo.ShopName = value;
                string text = string.Empty;
                string emailTitle = string.Empty;
                string text2 = "ce05437f-75a7-4ee2-8014-4bd992357e51";
                var shopNum1_Email_Action = (ShopNum1_Email_Action)LogicFactory.CreateShopNum1_Email_Action();
                DataTable editInfo = shopNum1_Email_Action.GetEditInfo("'" + text2 + "'", 0);
                if (editInfo.Rows.Count > 0)
                {
                    text = editInfo.Rows[0]["Remark"].ToString();
                    emailTitle = editInfo.Rows[0]["Title"].ToString();
                }
                text = text.Replace("{$Name}", MemLoginID);
                text = text.Replace("{$OrderNumber}", OrderNumber);
                text = text.Replace("{$ShopName}", "唐江宝宝");
                text = text.Replace("{$SendTime}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                string emailBody = orderInfo.ChangeOrderInfo(Page.Server.HtmlDecode(text));
                var sendEmail = new SendEmail();
                sendEmail.Emails(email, MemLoginID, emailTitle, text2, emailBody);
            }
        }

        protected void IsMMS(string OrderNumber, string memloginID, string string_5)
        {
            if (!(string_5.Trim() == ""))
            {
                var orderInfo = new OrderInfo();
                orderInfo.Name = memloginID;
                orderInfo.OrderNumber = OrderNumber;
                orderInfo.SysSendTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                orderInfo.ShopName = ShopSettings.GetValue("Name");
                IShopNum1_MMS_Action shopNum1_MMS_Action = LogicFactory.CreateShopNum1_MMS_Action();
                DataTable editInfo = shopNum1_MMS_Action.GetEditInfo("CE05437F-75A7-4EE2-8014-4BD992357E51", 0);
                string text = editInfo.Rows[0]["Remark"].ToString();
                string mMsTitle = editInfo.Rows[0]["Title"].ToString();
                var sMS = new SMS();
                string text2 = "";
                text = orderInfo.ChangeOrderInfo(Page.Server.HtmlDecode(text));
                sMS.Send(string_5.Trim(), text + "【唐江宝宝】", out text2);
                if (text2.IndexOf("发送成功") != -1)
                {
                    ShopNum1_MMSGroupSend emailGroupSend = AddMMS(memloginID, string_5.Trim(), mMsTitle, 2,
                        "CE05437F-75A7-4EE2-8014-4BD992357E51");
                    shopNum1_MMS_Action.AddMMSGroupSend(emailGroupSend);
                }
                else
                {
                    ShopNum1_MMSGroupSend emailGroupSend = AddMMS(memloginID, string_5.Trim(), mMsTitle, 0,
                        "CE05437F-75A7-4EE2-8014-4BD992357E51");
                    shopNum1_MMS_Action.AddMMSGroupSend(emailGroupSend);
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
                    editInfo.Rows[0]["Title"].ToString();
                    text = text.Replace("{$Name}", strName);
                    text = text.Replace("{$OrderNumber}", strOrderNumber);
                    text = text.Replace("{$MemLoginId}", strMemLoginId);
                    text = text.Replace("{$UserTel}", strHomeTel);
                    text = text.Replace("{$SendTime}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    text = text.Replace("{$ProductName}", strProductName);
                    text = text.Replace("{$UserMobile}", strMobile);
                    var orderInfo = new OrderInfo();
                    var sMS = new SMS();
                    text = orderInfo.ChangeOrderInfo(Page.Server.HtmlDecode(text));
                    string empty = string.Empty;
                    sMS.Send(strTel, text + "【唐江宝宝】", out empty);
                }
            }
        }

        protected ShopNum1_MMSGroupSend AddMMS(string memLoginID, string mobile, string MMsTitle, int state,
            string mmsGuid)
        {
            return new ShopNum1_MMSGroupSend
            {
                Guid = Guid.NewGuid(),
                MMSTitle = MMsTitle,
                CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                MMSGuid = new Guid(mmsGuid),
                SendObjectMMS = mobile,
                SendObject = memLoginID + "-" + mobile,
                State = state
            };
        }

        protected void BindPaymentMenthod()
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