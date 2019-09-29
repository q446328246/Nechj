using System;
using System.Configuration;
using System.Data;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.Interface;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopInterface;
using ShopNum1MultiEntity;
using ShopNum1.Common.ShopNum1.Common;


namespace ShopNum1.ShopWebControl
{
    [ParseChildren(true)]
    public class ProductDetail : BaseWebControl
    {
        public static DataTable dt_PackAge = null;
        public static string IsLoginId = "";
        private static string string_2 = "";

        private readonly IShopNum1_SpecProudctDetail_Action ishopNum1_SpecProudctDetail_Action_0 =
            LogicFactory.CreateShopNum1_SpecProudctDetail_Action();

        private readonly IShopNum1_SpecProudct_Action ishopNum1_SpecProudct_Action_0 =
            LogicFactory.CreateShopNum1_SpecProudct_Action();

        private readonly IShopNum1_Spec_Action ishopNum1_Spec_Action_0 = LogicFactory.CreateShopNum1_Spec_Action();

        private Button ButtonBuy;
        private Button ButtonCollect;
        private Button ButtonShopCar;
        private HiddenField HiddenFieldGuiGe;
        private HiddenField HiddenFieldGuiGev;
        private HiddenField HiddenFieldGuid;
        private HiddenField HiddenFieldSpecName;
        private Label LabelEms;
        private Label LabelEms_fee;
        private Label LabelExpress;
        private Label LabelExpress_fee;
        private Label LabelMarketPrice;
        private Label LabelName;
        private Label LabelPost;
        private Label LabelPost_Fee;
        private Label LabelRepertoryCount;
        private Label LabelShopPrice;
        private Repeater RepeaterDateImage;
        private Repeater RepeaterProductSepc;
        private TextBox TextBoxBuyNum;
        private HtmlAnchor aviewshow;
        private HtmlTableRow cellFee1;
        private HtmlTableRow cellFee2;
        private HtmlGenericControl divCombin;
        private DataTable dt;
        private HtmlInputHidden hidCityCode;
        private HtmlInputHidden hidDisCount;
        private HtmlInputHidden hidFeeTemplate;
        private HtmlInputHidden hidFeeType;
        private HtmlInputHidden hidIsReal;
        private HtmlInputHidden hidMemloginId;
        private HtmlInputHidden hidProductImgurl;
        private HtmlInputHidden hidProductNum;
        private HtmlInputHidden hidSaleType;
        private HtmlInputHidden hidShopName;
        private Label lblBrand;
        private Label lblClickCount;
        private Label lblCollectCount;
        private Label lblFee;
        private Label lblPackSalePrice;
        private Label lblPriceTxt;
        private Literal lblProductImgUrl;
        private Label lblPromotionPrice;
        private Label lblSaleNumber;
        private Label lblSavePrice;
        private Label lblTipDisCount;
        private Label lblUnitName;
        private Literal literTime;

        private DropDownList ddlColor;
        private DropDownList ddlSize;

        private Repeater repeater_2;
        private string skinFilename = string.Empty;
        private HtmlGenericControl spansaletxt;
        private string string_1 = "ProductDetail.ascx";
        private HtmlTableRow trDisCount;
        private HtmlTableRow trShopPrice;


        private Label LabeScore_Pv_a;
        private Label LabeScore_Pv_b;
        private Label LabeScore_dv;
        private Label LabeScore_hv;
        private Label LabeScore_sv;
        private Label LabeScore_max_hv;
        private Label LabeScore_cv;
        private Label LabeScore_Pv_cv;

        private Label Label_Pv_a;
        private Label Label_Pv_b;
        private Label Label_dv;
        private Label Label_hv;
        private Label Label_sv;
        private Label Label_max_hv;
        private Label Label_cv;
        private Label Label_Pv_cv;

        private HtmlTableRow tr_Pv_a;
        private HtmlTableRow tr_Pv_b;
        private HtmlTableRow tr_dv;
        private HtmlTableRow tr_hv;
        private HtmlTableRow tr_sv;
        private HtmlTableRow tr_max_hv;
        private HtmlTableRow tr_cv;
        private HtmlTableRow tr_Pv_cv;
        private HtmlTableRow trMarketPrice;
        private decimal GoodsWeight;

        //terry mark

        private int tr_shop_category_id;




        public string visitDiv;

        public ProductDetail()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = string_1;
            }
        }


        public string MemberLoginID { get; set; }

        public string MemberType { get; set; }

        public string ShopName { get; set; }

        public void AddShopCar(string MyMemLoginID)
        {
            string category = CookieCustomerCategory.ToString();
            HttpCookie cookieMemRankGuid = HttpSecureCookie.Decode(Page.Request.Cookies["MemberLoginCookie"]);

            string MemRankGuid = null;
            string MemLinkCategory = null;
            //判断是否登陆，若没有登陆取会员等级为普通用户的Guid
            if (cookieMemRankGuid != null)
            {
                MemRankGuid = cookieMemRankGuid.Values["MemRankGuid"];
            }
            else
            {
                MemRankGuid = MemberLevel.VISITOR_MEMBER_ID;
            }
            //根据会员等级的Guid以及可看属性获得专区板块ID字符串
            DataTable linkCategory = LogicFactory.CreateMemberRank_LinkCategory_Action().GetRankLinkCategoryByID(MemRankGuid, "2");

            MemLinkCategory = linkCategory.Rows[0]["Category_ID"].ToString();
            if (!MemLinkCategory.Contains(category))
            {
                MessageBox.Show("您的会员等级权限不足!");
            }
            else
            {
                if ("0a40df84-860a-4594-bed7-5717069f3456".ToUpper() == HiddenFieldGuid.Value.ToUpper())
                {
                    MessageBox.Show("该商品不允许加入购入车与其他商品合买!");
                }
                else
                {
                    Shop_Product_Action ProAction = (Shop_Product_Action)ShopFactory.LogicFactory.CreateShop_Product_Action();
                    DataTable protable = ProAction.SelectShopProductZG(HiddenFieldGuid.Value);
                    string agentId = protable.Rows[0]["agentId"].ToString();
                    var cd = (ShopNum1_Cart_Action)LogicFactory.CreateShopNum1_Cart_Action();

                    HttpCookie cookie2 = Page.Request.Cookies["MemberLoginCookie"];
                    HttpCookie cookie3 = HttpSecureCookie.Decode(cookie2);
                    MemberLoginID = cookie3.Values["MemLoginID"];

                    if (cd.SelectShopCar(MemberLoginID).Rows.Count > 0)
                    {
                        //if (Convert.ToString(cd.SelectShopCar(MemberLoginID).Rows[0]["shop_category_id"]) == "9" && Convert.ToInt32(cd.SelectShopCar(MemberLoginID).Rows[0]["AgentId"]) != Convert.ToInt32(agentId))
                        //{
                        //    MessageBox.Show("不可添加不同等级商品到购物车!");
                        //    return;
                        ////}
                        //else 
                        if (hidMemloginId.Value != Convert.ToString(cd.SelectShopCar(MemberLoginID).Rows[0]["ShopID"]))
                        {
                            MessageBox.Show("不可添加不同店铺商品到购物车!");
                            return;
                        }





                        else
                        {



                            bool flag = false;
                            try
                            {
                                //if (MemRankGuid.ToUpper() == MemberLevel.NORMAL_MEMBER_ID.ToUpper())
                                //{

                                //    if (agentId == "2")
                                //    {

                                //        MessageBox.Show("您没有购买该资格商品的权限!");
                                //        return;
                                //    }
                                //}
                                if (int.Parse(TextBoxBuyNum.Text) > 0)
                                {
                                    flag = true;
                                }
                                else
                                {
                                    MessageBox.Show("请正确填写购买数量!");
                                }
                                if (int.Parse(LabelRepertoryCount.Text.Trim()) < int.Parse(TextBoxBuyNum.Text))
                                {
                                    MessageBox.Show("商品库存不足！");
                                    return;
                                }
                                if (hidMemloginId.Value == MyMemLoginID)
                                {
                                    MessageBox.Show("您不能添加自己的商品！");
                                    return;
                                }
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("请正确填写购买数量!");
                            }
                            if (flag)
                            {
                                DataTable specificationByProduct;
                                decimal a;
                                decimal b;
                                decimal c;
                                decimal dee;
                                if (Convert.ToDecimal(LabeScore_hv.Text) == 0)
                                {
                                    a = Convert.ToDecimal(LabeScore_max_hv.Text) * (-1);
                                }
                                else
                                {
                                    a = Convert.ToDecimal(LabeScore_hv.Text);
                                }
                                if (Convert.ToDecimal(LabeScore_Pv_a.Text) == 0)
                                {
                                    b = Convert.ToDecimal(LabeScore_cv.Text) * (-1);
                                }
                                else
                                {
                                    b = Convert.ToDecimal(LabeScore_Pv_a.Text);
                                }
                                c = Convert.ToDecimal(LabeScore_dv.Text) * (-1);
                                dee = Convert.ToDecimal(LabeScore_Pv_cv.Text);
                                var shopcart = new ShopNum1_Shop_Cart
                                {
                                    Guid = Guid.NewGuid(),
                                    MemLoginID = MyMemLoginID,
                                    ProductGuid = new Guid(HiddenFieldGuid.Value),
                                    OriginalImge = hidProductImgurl.Value,
                                    Name = LabelName.Text,
                                    RepertoryNumber = hidProductNum.Value,
                                    BuyNumber = int.Parse(TextBoxBuyNum.Text),
                                    MarketPrice = decimal.Parse(LabelMarketPrice.Text.Trim()),
                                    shop_category_id = Convert.ToInt32(tr_shop_category_id),
                                    Score_dv = c,
                                    Score_hv = a,
                                    Score_pv_a = b,
                                    Size = ddlSize.SelectedValue,
                                    Color = ddlColor.SelectedValue,
                                    Score_pv_cv = dee,
                                    Score_pv_b = Convert.ToDecimal(LabeScore_Pv_b.Text),
                                    GoodsWeight = Convert.ToDecimal(GoodsWeight),
                                    AgentId = Convert.ToInt32(agentId)
                                };
                                string text = LabelShopPrice.Text;
                                if (!string.IsNullOrEmpty(HiddenFieldGuiGev.Value))
                                {
                                    specificationByProduct =
                                        ishopNum1_SpecProudct_Action_0.GetSpecificationByProduct(HiddenFieldGuid.Value,
                                            HiddenFieldGuiGev.Value.Replace(":", ",")
                                                .Replace(";", "|")
                                                .TrimEnd(new[] { ';' })
                                                .TrimEnd(new[] { '|' }));
                                    if (((specificationByProduct != null) && (specificationByProduct.Rows.Count > 0)) &&
                                        (specificationByProduct.Rows[0]["GoodsPrice"].ToString() != ""))
                                    {
                                        text = specificationByProduct.Rows[0]["GoodsPrice"].ToString();
                                    }
                                }
                                shopcart.ShopPrice = decimal.Parse(text);
                                shopcart.Attributes = string_2;
                                if (!string.IsNullOrEmpty(HiddenFieldGuiGev.Value))
                                {
                                    specificationByProduct =
                                        ishopNum1_SpecProudct_Action_0.GetSpecificationByProduct(HiddenFieldGuid.Value,
                                            HiddenFieldGuiGev.Value.Replace(":", ",")
                                                .Replace(";", "|")
                                                .TrimEnd(new[] { ';' })
                                                .TrimEnd(new[] { '|' }));
                                    if ((specificationByProduct != null) && (specificationByProduct.Rows.Count > 0))
                                    {
                                        shopcart.BuyPrice = Convert.ToDecimal(specificationByProduct.Rows[0]["GoodsPrice"].ToString());
                                    }
                                    else
                                    {
                                        shopcart.BuyPrice = decimal.Parse(LabelShopPrice.Text.Trim());
                                    }
                                }
                                else
                                {
                                    shopcart.BuyPrice = decimal.Parse(LabelShopPrice.Text.Trim());
                                }
                                if (trDisCount.Visible)
                                {
                                    if (hidSaleType.Value == "1")
                                    {
                                        shopcart.BuyPrice = decimal.Parse(lblPromotionPrice.Text);
                                    }
                                    else if (hidSaleType.Value == "2")
                                    {
                                        decimal d = Convert.ToDecimal(LabelShopPrice.Text) * Convert.ToDecimal(hidDisCount.Value);
                                        shopcart.BuyPrice = Math.Round(d, 2);
                                    }
                                }
                                if (lblPriceTxt.Text == "抢 购 价：")
                                {
                                    hidSaleType.Value = "4";
                                }
                                shopcart.IsShipment = 0;
                                shopcart.IsReal = int.Parse(hidIsReal.Value);
                                shopcart.ExtensionAttriutes = "";
                                shopcart.IsJoinActivity = 0;
                                shopcart.CartType = Convert.ToInt32(hidSaleType.Value);
                                shopcart.IsPresent = 0;
                                shopcart.CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                shopcart.DetailedSpecifications = "";
                                shopcart.ShopID = hidMemloginId.Value;
                                shopcart.SellName = hidShopName.Value;
                                shopcart.FeeType = int.Parse(hidFeeType.Value);
                                shopcart.shop_category_id = tr_shop_category_id;
                                if (HiddenFieldGuiGe.Value.Length > 1)
                                {
                                    if (HiddenFieldGuiGe.Value.Trim(new[] { ';' }) != "0")
                                    {
                                        shopcart.SpecificationValue =
                                            HiddenFieldGuiGev.Value.Trim(new[] { ';' }).Replace(":", ",").Replace(";", "|");
                                    }
                                    if (HiddenFieldSpecName.Value.Trim(new[] { ';' }) != "0")
                                    {
                                        shopcart.SpecificationName =
                                            HiddenFieldSpecName.Value.TrimEnd(new[] { ';' }).Replace("/", "-").TrimEnd(new[] { '0' });
                                    }
                                }
                                if (hidFeeType.Value == "1")
                                {
                                    shopcart.Post_fee = 0;
                                    shopcart.Ems_fee = 0;
                                    shopcart.Express_fee = 0;
                                }
                                else
                                {
                                    shopcart.Post_fee = decimal.Parse(LabelPost_Fee.Text);
                                    shopcart.Ems_fee = decimal.Parse(LabelEms_fee.Text);
                                    shopcart.Express_fee = decimal.Parse(LabelExpress_fee.Text);
                                }
                                var action = (ShopNum1_Cart_Action)LogicFactory.CreateShopNum1_Cart_Action();
                                int num = 0;
                                if (shopcart.SellName != "")
                                {
                                    num = action.AddCart(shopcart);
                                }
                                else
                                {
                                    num = 1;
                                }
                                if (num > 0)
                                {
                                    Page.Response.Redirect(GetPageName.RetDomainUrl("ShoppingCart1"));
                                    MessageBox.Show("添加成功!");
                                }
                                else
                                {
                                    MessageBox.Show("添加失败!");
                                }
                            }
                        }
                    }
                    else
                    {



                        bool flag = false;
                        try
                        {

                            //if (MemRankGuid.ToUpper() == MemberLevel.NORMAL_MEMBER_ID.ToUpper())
                            //{

                            //    if (agentId == "2")
                            //    {

                            //        MessageBox.Show("您没有购买该资格商品的权限!");
                            //        return;
                            //    }
                            //}
                            if (int.Parse(TextBoxBuyNum.Text) > 0)
                            {
                                flag = true;
                            }
                            else
                            {
                                MessageBox.Show("请正确填写购买数量!");
                            }
                            if (int.Parse(LabelRepertoryCount.Text.Trim()) < int.Parse(TextBoxBuyNum.Text))
                            {
                                MessageBox.Show("商品库存不足！");
                                return;
                            }
                            if (hidMemloginId.Value == MyMemLoginID)
                            {
                                MessageBox.Show("您不能添加自己的商品！");
                                return;
                            }
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("请正确填写购买数量!");
                        }
                        if (flag)
                        {
                            DataTable specificationByProduct;
                            decimal a;
                            decimal b;
                            decimal c;
                            decimal dee;
                            if (Convert.ToDecimal(LabeScore_hv.Text) == 0)
                            {
                                a = Convert.ToDecimal(LabeScore_max_hv.Text) * (-1);
                            }
                            else
                            {
                                a = Convert.ToDecimal(LabeScore_hv.Text);
                            }
                            if (Convert.ToDecimal(LabeScore_Pv_a.Text) == 0)
                            {
                                b = Convert.ToDecimal(LabeScore_cv.Text) * (-1);
                            }
                            else
                            {
                                b = Convert.ToDecimal(LabeScore_Pv_a.Text);
                            }
                            c = Convert.ToDecimal(LabeScore_dv.Text) * (-1);
                            dee = Convert.ToDecimal(LabeScore_Pv_cv.Text);
                            var shopcart = new ShopNum1_Shop_Cart
                            {
                                Guid = Guid.NewGuid(),
                                MemLoginID = MyMemLoginID,
                                ProductGuid = new Guid(HiddenFieldGuid.Value),
                                OriginalImge = hidProductImgurl.Value,
                                Name = LabelName.Text,
                                RepertoryNumber = hidProductNum.Value,
                                BuyNumber = int.Parse(TextBoxBuyNum.Text),
                                MarketPrice = decimal.Parse(LabelMarketPrice.Text.Trim()),
                                shop_category_id = Convert.ToInt32(tr_shop_category_id),
                                Score_dv = c,
                                Score_hv = a,
                                Score_pv_a = b,
                                Size = ddlSize.SelectedValue,
                                Color = ddlColor.SelectedValue,
                                Score_pv_cv = dee,
                                Score_pv_b = Convert.ToDecimal(LabeScore_Pv_b.Text),
                                GoodsWeight = Convert.ToDecimal(GoodsWeight),
                                AgentId = Convert.ToInt32(agentId)
                            };
                            string text = LabelShopPrice.Text;
                            if (!string.IsNullOrEmpty(HiddenFieldGuiGev.Value))
                            {
                                specificationByProduct =
                                    ishopNum1_SpecProudct_Action_0.GetSpecificationByProduct(HiddenFieldGuid.Value,
                                        HiddenFieldGuiGev.Value.Replace(":", ",")
                                            .Replace(";", "|")
                                            .TrimEnd(new[] { ';' })
                                            .TrimEnd(new[] { '|' }));
                                if (((specificationByProduct != null) && (specificationByProduct.Rows.Count > 0)) &&
                                    (specificationByProduct.Rows[0]["GoodsPrice"].ToString() != ""))
                                {
                                    text = specificationByProduct.Rows[0]["GoodsPrice"].ToString();
                                }
                            }
                            shopcart.ShopPrice = decimal.Parse(text);
                            shopcart.Attributes = string_2;
                            if (!string.IsNullOrEmpty(HiddenFieldGuiGev.Value))
                            {
                                specificationByProduct =
                                    ishopNum1_SpecProudct_Action_0.GetSpecificationByProduct(HiddenFieldGuid.Value,
                                        HiddenFieldGuiGev.Value.Replace(":", ",")
                                            .Replace(";", "|")
                                            .TrimEnd(new[] { ';' })
                                            .TrimEnd(new[] { '|' }));
                                if ((specificationByProduct != null) && (specificationByProduct.Rows.Count > 0))
                                {
                                    shopcart.BuyPrice = Convert.ToDecimal(specificationByProduct.Rows[0]["GoodsPrice"].ToString());
                                }
                                else
                                {
                                    shopcart.BuyPrice = decimal.Parse(LabelShopPrice.Text.Trim());
                                }
                            }
                            else
                            {
                                shopcart.BuyPrice = decimal.Parse(LabelShopPrice.Text.Trim());
                            }
                            if (trDisCount.Visible)
                            {
                                if (hidSaleType.Value == "1")
                                {
                                    shopcart.BuyPrice = decimal.Parse(lblPromotionPrice.Text);
                                }
                                else if (hidSaleType.Value == "2")
                                {
                                    decimal d = Convert.ToDecimal(LabelShopPrice.Text) * Convert.ToDecimal(hidDisCount.Value);
                                    shopcart.BuyPrice = Math.Round(d, 2);
                                }
                            }
                            if (lblPriceTxt.Text == "抢 购 价：")
                            {
                                hidSaleType.Value = "4";
                            }
                            shopcart.IsShipment = 0;
                            shopcart.IsReal = int.Parse(hidIsReal.Value);
                            shopcart.ExtensionAttriutes = "";
                            shopcart.IsJoinActivity = 0;
                            shopcart.CartType = Convert.ToInt32(hidSaleType.Value);
                            shopcart.IsPresent = 0;
                            shopcart.CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                            shopcart.DetailedSpecifications = "";
                            shopcart.ShopID = hidMemloginId.Value;
                            shopcart.SellName = hidShopName.Value;
                            shopcart.FeeType = int.Parse(hidFeeType.Value);
                            shopcart.shop_category_id = tr_shop_category_id;
                            if (HiddenFieldGuiGe.Value.Length > 1)
                            {
                                if (HiddenFieldGuiGe.Value.Trim(new[] { ';' }) != "0")
                                {
                                    shopcart.SpecificationValue =
                                        HiddenFieldGuiGev.Value.Trim(new[] { ';' }).Replace(":", ",").Replace(";", "|");
                                }
                                if (HiddenFieldSpecName.Value.Trim(new[] { ';' }) != "0")
                                {
                                    shopcart.SpecificationName =
                                        HiddenFieldSpecName.Value.TrimEnd(new[] { ';' }).Replace("/", "-").TrimEnd(new[] { '0' });
                                }
                            }
                            if (hidFeeType.Value == "1")
                            {
                                shopcart.Post_fee = 0;
                                shopcart.Ems_fee = 0;
                                shopcart.Express_fee = 0;
                            }
                            else
                            {
                                shopcart.Post_fee = decimal.Parse(LabelPost_Fee.Text);
                                shopcart.Ems_fee = decimal.Parse(LabelEms_fee.Text);
                                shopcart.Express_fee = decimal.Parse(LabelExpress_fee.Text);
                            }
                            var action = (ShopNum1_Cart_Action)LogicFactory.CreateShopNum1_Cart_Action();
                            int num = 0;
                            if (shopcart.SellName != "")
                            {
                                num = action.AddCart(shopcart);
                            }
                            else
                            {
                                num = 1;
                            }
                            if (num > 0)
                            {
                                Page.Response.Redirect(GetPageName.RetDomainUrl("ShoppingCart1"));
                                MessageBox.Show("添加成功!");
                            }
                            else
                            {
                                MessageBox.Show("添加失败!");
                            }
                        }
                    }


                }
            }
        }

        protected void BindClickCount()
        {
            ((Shop_Product_Action)ShopFactory.LogicFactory.CreateShop_Product_Action()).UpdateClickCountByGuid(
                HiddenFieldGuid.Value.Replace("'", ""));
        }

        protected void ButtonBuy_Click(object sender, EventArgs e)
        {
            string category = CookieCustomerCategory.ToString();
            HttpCookie cookieMemRankGuid = HttpSecureCookie.Decode(Page.Request.Cookies["MemberLoginCookie"]);

            string MemRankGuid = null;
            string MemLinkCategory = null;
            //判断是否登陆，若没有登陆取会员等级为普通用户的Guid
            //if (cookieMemRankGuid != null)
            //{
            MemRankGuid = cookieMemRankGuid.Values["MemRankGuid"];
            //}
            //else
            //{
            //    MemRankGuid = MemberLevel.NORMAL_MEMBER_ID;
            //}
            //根据会员等级的Guid以及可看属性获得专区板块ID字符串
            DataTable linkCategory = LogicFactory.CreateMemberRank_LinkCategory_Action().GetRankLinkCategoryByID(MemRankGuid, "2");

            MemLinkCategory = linkCategory.Rows[0]["Category_ID"].ToString();
            if (!MemLinkCategory.Contains(category))
            {
                MessageBox.Show("您的会员等级权限不足!");
            }
            else
            {
                var action444 = (Shop_Product_Action)ShopFactory.LogicFactory.CreateShop_Product_Action();
                DataTable maxnumberall = action444.selectMaxNumber(Common.Common.ReqStr("guid").ToString());

                if (Page.Request.Cookies["MemberLoginCookie"] == null)
                {
                    string str = Page.Request.Url.ToString().Replace("%3a%2f%2f", "://").Replace("/", "%2f").Replace("&", "%26");
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "script", "<script>$(function(){ $('#loginbox').show();$('#mylogingo').attr('src','http://www.t.com/Login.aspx'); });</script>");
                }
                else
                {
                    Shop_Product_Action ProAction = (Shop_Product_Action)ShopFactory.LogicFactory.CreateShop_Product_Action();
                    DataTable protable = ProAction.SelectShopProductZG(HiddenFieldGuid.Value);
                    string agentId = protable.Rows[0]["agentId"].ToString();

                    //if (MemRankGuid.ToUpper() == MemberLevel.NORMAL_MEMBER_ID.ToUpper())
                    //{

                    //    if (agentId == "2")
                    //    {

                    //        MessageBox.Show("您没有购买该资格商品的权限!");
                    //        return;
                    //    }
                    //}

                    HttpCookie cookie2 = Page.Request.Cookies["MemberLoginCookie"];
                    HttpCookie cookie3 = HttpSecureCookie.Decode(cookie2);
                    MemberLoginID = cookie3.Values["MemLoginID"];
                    if (hidMemloginId.Value == MemberLoginID)
                    {
                        MessageBox.Show("您不能购买自己的商品！");
                    }
                    else if (Convert.ToInt32(maxnumberall.Rows[0]["MaxNumber"]) < Convert.ToInt32(TextBoxBuyNum.Text) && (category == "4" || category == "5" || category == "6" || category == "7"))
                    {
                        MessageBox.Show("您不能购买超过" + maxnumberall.Rows[0]["MaxNumber"].ToString() + "件商品！");
                        return;
                    }
                    else
                    {
                        if (hidSaleType.Value == "4")
                        {



                            var action = (Shop_Product_Action)ShopFactory.LogicFactory.CreateShop_Product_Action();
                            if (action.CheckMenberBuyProduct(Common.Common.ReqStr("guid"), MemberLoginID).Rows.Count > 0)
                            {
                                MessageBox.Show("您已经购买过");
                                return;
                            }
                            TextBoxBuyNum.Text = "1";



                        }
                        if (int.Parse(TextBoxBuyNum.Text) <= 0)
                        {
                            MessageBox.Show("请正确填写购买数量!");
                        }
                        else if (int.Parse(LabelRepertoryCount.Text.Trim()) < int.Parse(TextBoxBuyNum.Text))
                        {
                            MessageBox.Show("商品库存不足！");
                        }
                        else
                        {
                            var cookie = new HttpCookie("SpecificationCookie");
                            cookie.Values.Add("SpecName",
                                HttpUtility.HtmlEncode(
                                    HiddenFieldSpecName.Value.Replace("/", "-").TrimEnd(new[] { '0' })));
                            cookie.Values.Add("SpecValue",
                                HiddenFieldGuiGev.Value.Trim(new[] { ';' }).Replace(":", ",").Replace(";", "|"));
                            cookie.Values.Add("ShopName", hidShopName.Value);
                            cookie.Values.Add("ShopId", hidMemloginId.Value);
                            string text = LabelShopPrice.Text;
                            if (!string.IsNullOrEmpty(HiddenFieldGuiGev.Value))
                            {
                                DataTable specificationByProduct =
                                    ishopNum1_SpecProudct_Action_0.GetSpecificationByProduct(HiddenFieldGuid.Value,
                                        HiddenFieldGuiGev.Value.Replace(
                                            ":", ",")
                                            .Replace(";", "|")
                                            .TrimEnd(new[] { ';' })
                                            .TrimEnd(new[] { '|' }));
                                if (((specificationByProduct != null) && (specificationByProduct.Rows.Count > 0)) &&
                                    (specificationByProduct.Rows[0]["GoodsPrice"].ToString() != ""))
                                {
                                    text = specificationByProduct.Rows[0]["GoodsPrice"].ToString();
                                }
                            }
                            if (trDisCount.Visible)
                            {
                                if (hidSaleType.Value == "2")
                                {
                                    decimal d = Convert.ToDecimal(text) * Convert.ToDecimal(hidDisCount.Value);
                                    cookie.Values.Add("Price", Math.Round(d, 2).ToString());
                                }
                                else if (hidSaleType.Value == "1")
                                {
                                    cookie.Values.Add("Price", lblPromotionPrice.Text);
                                }
                            }
                            else
                            {
                                cookie.Values.Add("Price", text);
                            }
                            if (lblPriceTxt.Text == "抢 购 价：")
                            {
                                hidSaleType.Value = "4";
                            }
                            cookie.Values.Add("SaleType", hidSaleType.Value);
                            HttpCookie cookie4 = HttpSecureCookie.Encode(cookie);
                            cookie4.Expires = Convert.ToDateTime(DateTime.Now.AddHours(1.0).ToString("yyyy-MM-dd HH:mm:ss"));
                            cookie4.Domain = ConfigurationManager.AppSettings["CookieDomain"];
                            Page.Response.AppendCookie(cookie4);
                            if (Page.Request.Cookies["PackAgeCookie"] != null)
                            {
                                HttpCookie cookie5 = Page.Request.Cookies["PackAgeCookie"];
                                cookie5.Values.Clear();
                                cookie5.Expires =
                                    Convert.ToDateTime(DateTime.Now.AddDays(-6.0).ToString("yyyy-MM-dd HH:mm:ss"));
                                cookie5.Domain = ConfigurationManager.AppSettings["CookieDomain"];
                                Page.Response.Cookies.Add(cookie5);
                            }
                            string str2 = "";
                            try
                            {
                                str2 = hidCityCode.Value;
                            }
                            catch
                            {
                            }
                            Page.Response.Redirect(
                                GetPageName.GetMainPage("/Main/ConfirmOrder.aspx?ProductionGuid=" + HiddenFieldGuid.Value + "&num=" + TextBoxBuyNum.Text + "&Code=" + str2 + "&shopcategoryid=" + tr_shop_category_id + "&Color=" + ddlColor.SelectedValue + "&Size=" + ddlSize.SelectedValue));
                        }
                    }
                }
            }
        }

        protected void ButtonShopCar_Click(object sender, EventArgs e)
        {
            HttpCookie cookie;
            if (Page.Request.Cookies["MemberLoginCookie"] != null)
            {
                cookie = Page.Request.Cookies["MemberLoginCookie"];
                HttpCookie cookie2 = HttpSecureCookie.Decode(cookie);
                MemberLoginID = cookie2.Values["MemLoginID"];
                //cookie2.Values["MemberType"];
                if (hidSaleType.Value == "4")
                {
                    var action = (Shop_Product_Action)ShopFactory.LogicFactory.CreateShop_Product_Action();
                    if (action.CheckMenberBuyProduct(Common.Common.ReqStr("guid"), MemberLoginID).Rows.Count > 0)
                    {
                        MessageBox.Show("您已经购买过");
                        return;
                    }
                }
                AddShopCar(MemberLoginID);
            }
            else
            {
                string myMemLoginID = string.Empty;
                if (Page.Request.Cookies["Visitor_LoginCookie"] != null)
                {
                    cookie = Page.Request.Cookies["Visitor_LoginCookie"];
                    myMemLoginID = HttpSecureCookie.Decode(cookie).Values["MemLoginID"];
                }
                else
                {
                    string str = "visitor_" + new Order().CreateOrderNumber();
                    var cookie3 = new HttpCookie("Visitor_LoginCookie");
                    cookie3.Values.Add("MemLoginID", str);
                    HttpCookie cookie4 = HttpSecureCookie.Encode(cookie3);
                    cookie4.Domain = ConfigurationManager.AppSettings["CookieDomain"];
                    Page.Response.AppendCookie(cookie4);
                    myMemLoginID = str;
                }
                AddShopCar(myMemLoginID);
            }
        }

        protected void ButtonCollect_Click(object sender, EventArgs e)
        {
            if (Page.Request.Cookies["MemberLoginCookie"] != null)
            {
                HttpCookie cookie = Page.Request.Cookies["MemberLoginCookie"];
                HttpCookie cookie2 = HttpSecureCookie.Decode(cookie);
                MemberLoginID = cookie2.Values["MemLoginID"];
                var action = (Shop_Collect_Action)ShopFactory.LogicFactory.CreateShop_Collect_Action();
                if (hidMemloginId.Value == MemberLoginID)
                {
                    MessageBox.Show("您不能收藏自己的商品！");
                }
                else if (
                    action.AddProductCollect(MemberLoginID, HiddenFieldGuid.Value, hidShopName.Value, "0",
                        LabelShopPrice.Text, LabelName.Text, hidMemloginId.Value, tr_shop_category_id) > 0)
                {
                    MessageBox.Show("收藏成功!");
                    action.ProductCollectNum(HiddenFieldGuid.Value);
                    BindData();
                }
                else
                {
                    MessageBox.Show("已收藏过该商品!");
                }
            }
            else
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "script", "<script>$(function(){$('#mylogingo').attr('src','http://" + ShopSettings.siteDomain + "/poplogin.aspx?vj=shopcar');  $('#loginbox').show();});</script>");
            }
        }

        protected override void InitializeSkin(Control skin)
        {
            lblPackSalePrice = (Label)skin.FindControl("lblPackSalePrice");
            lblSavePrice = (Label)skin.FindControl("lblSavePrice");
            lblBrand = (Label)skin.FindControl("lblBrand");
            divCombin = (HtmlGenericControl)skin.FindControl("divCombin");
            aviewshow = (HtmlAnchor)skin.FindControl("aviewshow");
            spansaletxt = (HtmlGenericControl)skin.FindControl("spansaletxt");
            lblPriceTxt = (Label)skin.FindControl("lblPriceTxt");
            lblSaleNumber = (Label)skin.FindControl("lblSaleNumber");
            lblTipDisCount = (Label)skin.FindControl("lblTipDisCount");
            lblPromotionPrice = (Label)skin.FindControl("lblPromotionPrice");
            lblUnitName = (Label)skin.FindControl("lblUnitName");
            lblCollectCount = (Label)skin.FindControl("lblCollectCount");
            lblClickCount = (Label)skin.FindControl("lblClickCount");
            lblProductImgUrl = (Literal)skin.FindControl("lblProductImgUrl");
            literTime = (Literal)skin.FindControl("literTime");
            ButtonBuy = (Button)skin.FindControl("ButtonBuy");
            ButtonShopCar = (Button)skin.FindControl("ButtonShopCar");
            ButtonShopCar.Click += ButtonShopCar_Click;
            ButtonShopCar.Text = "加入购物车";
            ButtonCollect = (Button)skin.FindControl("ButtonCollect");
            ButtonCollect.Click += ButtonCollect_Click;
            ButtonBuy = (Button)skin.FindControl("ButtonBuy");
            ButtonBuy.Click += ButtonBuy_Click;
            TextBoxBuyNum = (TextBox)skin.FindControl("TextBoxBuyNum");
            LabelName = (Label)skin.FindControl("LabelName");
            LabelMarketPrice = (Label)skin.FindControl("LabelMarketPrice");
            LabelShopPrice = (Label)skin.FindControl("LabelShopPrice");
            LabelRepertoryCount = (Label)skin.FindControl("LabelRepertoryCount");
            cellFee1 = (HtmlTableRow)skin.FindControl("cellFee1");
            cellFee2 = (HtmlTableRow)skin.FindControl("cellFee2");
            trDisCount = (HtmlTableRow)skin.FindControl("trDisCount");
            LabelPost_Fee = (Label)skin.FindControl("LabelPost_Fee");
            LabelExpress_fee = (Label)skin.FindControl("LabelExpress_fee");
            LabelEms_fee = (Label)skin.FindControl("LabelEms_fee");
            LabelPost = (Label)skin.FindControl("LabelPost");
            LabelExpress = (Label)skin.FindControl("LabelExpress");
            LabelEms = (Label)skin.FindControl("LabelEms");
            RepeaterDateImage = (Repeater)skin.FindControl("RepeaterDateImage");
            trShopPrice = (HtmlTableRow)skin.FindControl("trShopPrice");
            cellFee1 = (HtmlTableRow)skin.FindControl("cellFee1");
            cellFee2 = (HtmlTableRow)skin.FindControl("cellFee2");
            hidShopName = (HtmlInputHidden)skin.FindControl("hidShopName");
            hidMemloginId = (HtmlInputHidden)skin.FindControl("hidMemloginId");
            hidFeeType = (HtmlInputHidden)skin.FindControl("hidFeeType");
            hidSaleType = (HtmlInputHidden)skin.FindControl("hidSaleType");
            hidIsReal = (HtmlInputHidden)skin.FindControl("hidIsReal");
            hidProductNum = (HtmlInputHidden)skin.FindControl("hidProductNum");
            hidFeeTemplate = (HtmlInputHidden)skin.FindControl("hidFeeTemplate");
            hidDisCount = (HtmlInputHidden)skin.FindControl("hidDisCount");
            hidProductImgurl = (HtmlInputHidden)skin.FindControl("hidProductImgurl");
            hidCityCode = (HtmlInputHidden)skin.FindControl("hidCityCode");
            lblFee = (Label)skin.FindControl("lblFee");
            string text1 = (Page.Request.QueryString["ShopID"] == null) ? "0" : Page.Request.QueryString["ShopID"];
            RepeaterProductSepc = (Repeater)skin.FindControl("RepeaterProductSepc");
            RepeaterProductSepc.ItemDataBound += RepeaterProductSepc_ItemDataBound;
            HiddenFieldSpecName = (HiddenField)skin.FindControl("HiddenFieldSpecName");
            HiddenFieldGuiGe = (HiddenField)skin.FindControl("HiddenFieldGuiGe");
            HiddenFieldGuiGev = (HiddenField)skin.FindControl("HiddenFieldGuiGev");
            HiddenFieldGuid = (HiddenField)skin.FindControl("HiddenFieldGuid");
            HiddenFieldGuid.Value = (Page.Request.QueryString["guid"] == null) ? "0" : Page.Request.QueryString["guid"];


            LabeScore_Pv_a = (Label)skin.FindControl("LabeScore_Pv_a");
            LabeScore_Pv_b = (Label)skin.FindControl("LabeScore_Pv_b");
            LabeScore_dv = (Label)skin.FindControl("LabeScore_dv");
            LabeScore_hv = (Label)skin.FindControl("LabeScore_hv");
            LabeScore_sv = (Label)skin.FindControl("LabeScore_sv");
            LabeScore_max_hv = (Label)skin.FindControl("LabeScore_max_hv");
            LabeScore_cv = (Label)skin.FindControl("LabeScore_cv");
            LabeScore_Pv_cv = (Label)skin.FindControl("LabeScore_Pv_cv");
            Label_Pv_a = (Label)skin.FindControl("Label_Pv_a");
            Label_Pv_b = (Label)skin.FindControl("Label_Pv_b");
            Label_dv = (Label)skin.FindControl("Label_dv");
            Label_hv = (Label)skin.FindControl("Label_hv");
            Label_sv = (Label)skin.FindControl("Label_sv");
            Label_max_hv = (Label)skin.FindControl("Label_max_hv");
            Label_cv = (Label)skin.FindControl("Label_cv");
            Label_Pv_cv = (Label)skin.FindControl("Label_Pv_cv");


            tr_Pv_a = (HtmlTableRow)skin.FindControl("tr_Pv_a");
            tr_Pv_b = (HtmlTableRow)skin.FindControl("tr_Pv_b");
            tr_dv = (HtmlTableRow)skin.FindControl("tr_dv");
            tr_hv = (HtmlTableRow)skin.FindControl("tr_hv");
            tr_sv = (HtmlTableRow)skin.FindControl("tr_sv");
            tr_max_hv = (HtmlTableRow)skin.FindControl("tr_max_hv");
            tr_cv = (HtmlTableRow)skin.FindControl("tr_cv");
            tr_Pv_cv = (HtmlTableRow)skin.FindControl("tr_Pv_cv");
            trMarketPrice = (HtmlTableRow)skin.FindControl("trMarketPrice");

            ddlColor = (DropDownList)skin.FindControl("ddlColor");
            ddlSize = (DropDownList)skin.FindControl("ddlSize");
            string category = CookieCustomerCategory.ToString();
            HttpCookie cookieMemRankGuid = HttpSecureCookie.Decode(Page.Request.Cookies["MemberLoginCookie"]);

            string MemRankGuid = null;
            string MemLinkCategory = null;
            //判断是否登陆，若没有登陆取会员等级为普通用户的Guid
            if (cookieMemRankGuid != null)
            {
                MemRankGuid = cookieMemRankGuid.Values["MemRankGuid"];
            }
            else
            {
                MemRankGuid = MemberLevel.VISITOR_MEMBER_ID;
            }
            //根据会员等级的Guid以及可看属性获得专区板块ID字符串
            DataTable linkCategory = LogicFactory.CreateMemberRank_LinkCategory_Action().GetRankLinkCategoryByID(MemRankGuid, "1");

            MemLinkCategory = linkCategory.Rows[0]["Category_ID"].ToString();
            if (!MemLinkCategory.Contains(category))
            {
                MessageBox.Show("您的会员等级权限不足!");
            }
            else
            {
                BindData();
            }
            if (!Page.IsPostBack)
            {
                BindClickCount();
            }
            //Func<bool> func = method_2;
            //func();
            Product_Browse();
        }

        public static string IsBegin(object begin, object object_0)
        {
            if (Convert.ToDateTime(begin.ToString()) > DateTime.Now.ToLocalTime())
            {
                return begin.ToString();
            }
            return object_0.ToString();
        }

        public static string IsFeeType(object object_0)
        {
            switch (object_0.ToString())
            {
                case "0":
                    return "买家";

                case "1":
                    return "卖家";
            }
            return "";
        }

        public static string IsShow(object object_0)
        {
            switch (object_0.ToString())
            {
                case "0":
                    return "否";

                case "1":
                    return "是";
            }
            return "";
        }

        protected void BindData()
        {
            HttpCookie cookieMemRankGuid = HttpSecureCookie.Decode(Page.Request.Cookies["MemberLoginCookie"]);

            string MemRankGuid = null;
            string MemLinkCategory = null;
            //判断是否登陆，若没有登陆取会员等级为普通用户的Guid
            if (cookieMemRankGuid != null)
            {
                MemRankGuid = cookieMemRankGuid.Values["MemRankGuid"];
            }
            else
            {
                MemRankGuid = MemberLevel.VISITOR_MEMBER_ID;
            }
            DateTime time;
            DateTime time2;
            DateTime time3;
            string str5;
            IShop_Product_Action action = ShopFactory.LogicFactory.CreateShop_Product_Action();
            string shopid = (Page.Request.QueryString["ShopID"] == null) ? "0" : Page.Request.QueryString["ShopID"];
            //if (Page.Request.QueryString["id"] != null) 
            //{
            //    HiddenFieldGuid.Value = Page.Request.QueryString["guid"];
            //}
            DataSet productInfoByGuidAndMemLoginID = action.GetProductInfoByGuidAndMemLoginID(HiddenFieldGuid.Value, "");
            if (productInfoByGuidAndMemLoginID.Tables[0].Rows.Count == 0)
            {
                str5 = "http://" + HttpContext.Current.Request.Url.Host + "/NoFind.aspx";
                Page.Response.Redirect(str5);
            }
            else
            {
                var action2 = (Shop_ShopInfo_Action)ShopFactory.LogicFactory.CreateShop_ShopInfo_Action();
                string str4 = action2.GetMemberLoginidByShopid(shopid);
                if (productInfoByGuidAndMemLoginID.Tables[0].Select("memloginID='" + str4 + "'").Length == 0)
                {
                    str5 = "http://" + HttpContext.Current.Request.Url.Host + "/NoFind.aspx";
                    Page.Response.Redirect(str5);
                }
            }
            dt_PackAge = productInfoByGuidAndMemLoginID.Tables[1];
            if (dt_PackAge.Rows.Count == 0)
            {
                dt_PackAge = null;
            }
            DataTable table3 = productInfoByGuidAndMemLoginID.Tables[2];
            if (table3.Rows.Count > 0)
            {
                lblPackSalePrice.Text = table3.Rows[0]["SalePrice"].ToString();
                lblSavePrice.Text =
                    (Convert.ToDecimal(table3.Rows[0]["Price"].ToString()) -
                     Convert.ToDecimal(table3.Rows[0]["SalePrice"].ToString())).ToString();
                aviewshow.Target = "_blank";
                aviewshow.InnerText = "查看套餐";
                aviewshow.Attributes.Add("class", "tb-view");
                aviewshow.HRef =
                    string.Concat(new[]
                    {
                        "http://", HttpContext.Current.Request.Url.Host, "/Combination.html?pid=",
                        HiddenFieldGuid.Value,
                        "&packid=", table3.Rows[0]["id"], "&action=viewpackage"
                    });
            }

            else
            {
                divCombin.Visible = false;
            }
            DataTable table = productInfoByGuidAndMemLoginID.Tables[0];
            if (table.Rows[0]["isreal"].ToString() == "0")
            {
                ButtonShopCar.Visible = false;
            }
            string nameqvfenshangpin = "";
            if (table.Rows[0]["aid"].ToString() == "0")
            {
                nameqvfenshangpin = "(高级认证)" + table.Rows[0]["name"].ToString();

            }
            else 
            {
                nameqvfenshangpin = "(普通认证)" + table.Rows[0]["name"].ToString();
            }
            lblCollectCount.Text = table.Rows[0]["collectcount"].ToString();
            string_2 = table.Rows[0]["setStock"].ToString();
            lblUnitName.Text = table.Rows[0]["unitname"].ToString();
            lblBrand.Text = table.Rows[0]["brandname"].ToString();
            HiddenFieldGuiGe.Value = table.Rows[0]["setstock"].ToString();
            lblSaleNumber.Text = table.Rows[0]["salenumber"].ToString();
            LabelName.Text = nameqvfenshangpin;
            hidProductImgurl.Value = Page.ResolveUrl(table.Rows[0]["OriginalImage"].ToString());
            lblProductImgUrl.Text = "<img id=\"ProductImgurl\" src='" +
                                    Page.ResolveUrl(table.Rows[0]["OriginalImage"].ToString()) +
                                    "_300x300.jpg' width=\"300\" height=\"300\" onerror=\"javascript:this.src='/ImgUpload/noImg.jpg_300x300.jpg'\" jqimg='" +
                                    Page.ResolveUrl(table.Rows[0]["OriginalImage"].ToString()) + "' />";
            hidFeeType.Value = table.Rows[0]["FeeType"].ToString();
            lblFee.Text = IsFeeType(hidFeeType.Value) + "承担";

            LabelPost_Fee.Text = table.Rows[0]["Post_fee"].ToString();
            LabelExpress_fee.Text = table.Rows[0]["Express_fee"].ToString();

            LabelEms_fee.Text = table.Rows[0]["Ems_fee"].ToString();
            LabelRepertoryCount.Text = table.Rows[0]["RepertoryCount"].ToString();

            string cc = (table.Rows[0]["Color"]).ToString().Replace("，", ",");
            if (cc != "")
            {
                ddlColor.DataSource = cc.Split(',');
                ddlColor.DataBind();
            }

            string cc_two = table.Rows[0]["Size"].ToString().Replace("，", ",");
            if (cc_two != "")
            {
                ddlSize.DataSource = cc_two.Split(',');
                ddlSize.DataBind();
            }
            GoodsWeight = Convert.ToDecimal(table.Rows[0]["GoodsWeight"]);
            //显示各专区的价格

            //int productid=action.SearchProductID(table.Rows[0]["Guid"].ToString());
            //int prefecture = CookieCustomerCategory;

            //if (Page.Request.QueryString["id"] != null )
            //{
            //DataTable tb = action.SearchProductPrice(Page.Request.QueryString["proguid"], Convert.ToInt32(Page.Request.QueryString["id"]));
            //HiddenFieldGuid.Value = Page.Request.QueryString["guid"];
            //int prefecture = Convert.ToInt32(Page.Request.QueryString["id"]);

            //}

            DataTable tb = action.SearchProductPrice(HiddenFieldGuid.Value, CookieCustomerCategory);



            if (tb.Rows.Count > 0 && Convert.ToDecimal(tb.Rows[0]["Score_pv_a"]) == 0)
            {
                tr_Pv_a.Visible = false;
                visitDiv = "none";
                Label_Pv_a.Visible = false;
                LabeScore_Pv_a.Visible = false;
            }
            if (tb.Rows.Count > 0 && Convert.ToDecimal(tb.Rows[0]["Score_pv_cv"]) == 0)
            {
                tr_Pv_cv.Visible = false;
                Label_Pv_cv.Visible = false;
                LabeScore_Pv_cv.Visible = false;
            }
            if (tb.Rows.Count > 0 && Convert.ToDecimal(tb.Rows[0]["Score_pv_b"]) == 0 || (CookieCustomerCategory == 9 && MemRankGuid == MemberLevel.NORMAL_MEMBER_ID))
            {
                tr_Pv_b.Visible = false;
                Label_Pv_b.Visible = false;
                LabeScore_Pv_b.Visible = false;
            }
            if (tb.Rows.Count > 0 && Convert.ToDecimal(tb.Rows[0]["Score_dv"]) == 0)
            {
                tr_dv.Visible = false;
                Label_dv.Visible = false;
                LabeScore_dv.Visible = false;
            }
            if (tb.Rows.Count > 0 && Convert.ToDecimal(tb.Rows[0]["Score_hv"]) == 0)
            {
                tr_hv.Visible = false;
                Label_hv.Visible = false;
                LabeScore_hv.Visible = false;
            }
            if (tb.Rows.Count > 0 && Convert.ToDecimal(tb.Rows[0]["Score_sv"]) == 0)
            {
                tr_sv.Visible = false;
                Label_sv.Visible = false;
                LabeScore_sv.Visible = false;
            }
            if (tb.Rows.Count > 0 && Convert.ToDecimal(tb.Rows[0]["Score_max_hv"]) == 0)
            {
                tr_max_hv.Visible = false;
                Label_max_hv.Visible = false;
                LabeScore_max_hv.Visible = false;
            }
            if (tb.Rows.Count > 0 && Convert.ToDecimal(tb.Rows[0]["Score_cv"]) == 0)
            {
                tr_cv.Visible = false;
                Label_cv.Visible = false;
                LabeScore_cv.Visible = false;
            }
            if (tb.Rows.Count > 0 && Convert.ToDecimal(tb.Rows[0]["MarketPrice"]) == 0)
            {
                trMarketPrice.Visible = false;

                LabelMarketPrice.Visible = false;
            }

            if (tb.Rows.Count > 0 && Convert.ToDecimal(tb.Rows[0]["ShopPrice"]) == 0)
            {
                trShopPrice.Visible = false;
                lblPriceTxt.Visible = false;
                LabelShopPrice.Visible = false;
            }
            LabeScore_Pv_a.Text = tb.Rows[0]["Score_pv_a"].ToString();
            LabeScore_Pv_b.Text = tb.Rows[0]["Score_pv_b"].ToString();
            LabeScore_dv.Text = (Convert.ToDecimal(tb.Rows[0]["Score_dv"]) * -1).ToString();
            LabeScore_hv.Text = tb.Rows[0]["Score_hv"].ToString();
            LabeScore_sv.Text = tb.Rows[0]["Score_sv"].ToString();
            LabeScore_max_hv.Text = (Convert.ToDecimal(tb.Rows[0]["Score_max_hv"]) * -1).ToString();
            LabeScore_cv.Text = (Convert.ToDecimal(tb.Rows[0]["Score_cv"]) * -1).ToString();
            LabelMarketPrice.Text = tb.Rows[0]["MarketPrice"].ToString();
            LabeScore_Pv_cv.Text = tb.Rows[0]["Score_pv_cv"].ToString();
            
            tr_shop_category_id = Convert.ToInt32(tb.Rows[0]["shop_category_id"]);
            
            LabelShopPrice.Text = tb.Rows[0]["ShopPrice"].ToString();
            if (tr_shop_category_id == 2) 
            {
                LabelMarketPrice.Text = (Convert.ToDecimal(tb.Rows[0]["MarketPrice"]) / Convert.ToDecimal(QLX_NEC_BILI.GetNECbili())).ToString();
                LabelShopPrice.Text = (Convert.ToDecimal(tb.Rows[0]["ShopPrice"]) / Convert.ToDecimal(QLX_NEC_BILI.GetNECbili())).ToString();
                lblPriceTxt.Text = "兑换新能源链:";
            }


            if (Convert.ToInt32(LabelRepertoryCount.Text) < 0)
            {
                LabelRepertoryCount.Text = "0";
                ButtonBuy.Enabled = false;
                ButtonShopCar.Visible = false;
            }
            lblClickCount.Text = table.Rows[0]["ClickCount"].ToString();
            hidFeeTemplate.Value = table.Rows[0]["FeeTemplateID"].ToString();
            hidFeeType.Value = table.Rows[0]["FeeType"].ToString();
            hidProductNum.Value = table.Rows[0]["ProductNum"].ToString();
            hidShopName.Value = table.Rows[0]["ShopName"].ToString();
            hidMemloginId.Value = table.Rows[0]["MemloginId"].ToString();
            hidIsReal.Value = table.Rows[0]["IsReal"].ToString();
            string str = table.Rows[0]["groupprice"].ToString();
            if (!(hidIsReal.Value == "0"))
            {
            }
            LabelName.Text = LabelName.Text;
            if ((table.Rows[0]["productstate"].ToString() == "1") &&
                (Convert.ToDateTime(table.Rows[0]["starttime"].ToString()) >= DateTime.Now.ToLocalTime()))
            {
                lblPriceTxt.Text = "抢 购 价：";
                hidSaleType.Value = "4";
                LabelName.Text = LabelName.Text + "[抢购尚未开始]";
                ButtonBuy.Enabled = false;
            }
            else if ((table.Rows[0]["productstate"].ToString() == "1") &&
                     (Convert.ToDateTime(table.Rows[0]["endtime"].ToString()) >= DateTime.Now.ToLocalTime()))
            {
                lblPriceTxt.Text = "抢 购 价：";
                hidSaleType.Value = "4";
                LabelName.Text = LabelName.Text + "[抢购进行中...]";
                ButtonShopCar.Visible = false;
            }
            else if (table.Rows[0]["productstate"].ToString() == "1")
            {
                lblPriceTxt.Text = "抢 购 价：";
                hidSaleType.Value = "4";
                LabelName.Text = LabelName.Text + "[抢购时间已结束]";
                ButtonBuy.Enabled = false;
            }
            if (str != "")
            {
                spansaletxt.InnerText = "团购";
                time3 = Convert.ToDateTime(table.Rows[0]["gstart"].ToString());
                time2 = Convert.ToDateTime(table.Rows[0]["gend"].ToString());
                time = Convert.ToDateTime(DateTime.Now.ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss"));
                if (time <= time2)
                {
                    if (time > time3)
                    {
                        LabelRepertoryCount.Text = table.Rows[0]["groupstock"].ToString();
                        trShopPrice.Visible = false;
                        trDisCount.Visible = true;
                        ButtonShopCar.Visible = false;
                        hidSaleType.Value = "1";
                        lblPromotionPrice.Text = str;
                        lblTipDisCount.Text = "(" + method_1(time, time2) + "后结束)";
                        ButtonShopCar.Visible = false;
                        literTime.Text = "<script>show_date_time('" + IsBegin(time3, time2).Replace("-", "/") +
                                         "','spTimego','后结束');</script>";
                    }
                    else
                    {
                        lblTipDisCount.Text = "(" + method_1(time3, time) + "后开始)";
                        literTime.Text = "<script>show_date_time('" + IsBegin(time3, time2).Replace("-", "/") +
                                         "','spTimego','后开始');</script>";
                    }
                }
                else
                {
                    trDisCount.Visible = false;
                }
            }
            string str2 = table.Rows[0]["discount"].ToString();
            if (!string.IsNullOrEmpty(str2) && (Common.Common.ReqStr("type") != "tg"))
            {
                spansaletxt.InnerText = "限时折扣";
                time3 = Convert.ToDateTime(table.Rows[0]["dstart"].ToString());
                time2 = Convert.ToDateTime(table.Rows[0]["dend"].ToString());
                time = Convert.ToDateTime(DateTime.Now.ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss"));
                if (time <= time2)
                {
                    hidDisCount.Value = str2;
                    trDisCount.Visible = true;
                    decimal d = Convert.ToDecimal(LabelShopPrice.Text) * Convert.ToDecimal(str2);
                    lblPromotionPrice.Text = Math.Round(d, 2).ToString();
                    if (time > time3)
                    {
                        hidSaleType.Value = "2";
                        ButtonShopCar.Visible = false;
                        lblTipDisCount.Text = "(" + method_1(time, time2) + "后结束)";
                        ButtonShopCar.Visible = false;
                        literTime.Text = "<script>show_date_time('" + IsBegin(time3, time2).Replace("-", "/") +
                                         "','spTimego','后结束');</script>";
                    }
                    else
                    {
                        lblTipDisCount.Text = "(" + method_1(time3, time).Replace("-", "") + "后开始)";
                        literTime.Text = "<script>show_date_time('" + IsBegin(time3, time2).Replace("-", "/") +
                                         "','spTimego','后开始');</script>";
                    }
                }
                else
                {
                    trDisCount.Visible = false;
                }
            }
            if (hidFeeType.Value == "0")
            {
                cellFee1.Visible = false;
                cellFee2.Visible = true;
                if (LabelPost_Fee.Text != "0.00")
                {
                    LabelPost_Fee.Visible = true;
                    LabelPost.Visible = true;
                }
                if (LabelExpress_fee.Text != "0.00")
                {
                    LabelExpress_fee.Visible = true;
                    LabelExpress.Visible = true;
                }
                if (LabelEms_fee.Text != "0.00")
                {
                    LabelEms_fee.Visible = true;
                    LabelEms.Visible = true;
                }
            }
            else
            {
                cellFee1.Visible = true;
                cellFee2.Visible = false;
            }
            string[] strArray = table.Rows[0]["multiimages"].ToString().Split(new[] { ',' });
            var table2 = new DataTable();
            var column = new DataColumn
            {
                ColumnName = "imgurl",
                DataType = Type.GetType("System.String")
            };
            table2.Columns.Add(column);
            for (int i = 0; i < strArray.Length; i++)
            {
                if (strArray[i] != "")
                {
                    DataRow row = table2.NewRow();
                    row["imgurl"] = strArray[i].Replace("~/", "/");
                    table2.Rows.Add(row);
                }
            }
            RepeaterDateImage.DataSource = table2;
            RepeaterDateImage.DataBind();
        }

        private string method_1(DateTime dateTime_0, DateTime dateTime_1)
        {
            TimeSpan span = dateTime_1.Subtract(dateTime_0);
            return string.Concat(new object[] { span.Days, "天", span.Hours, "时", span.Minutes, "分", span.Seconds, "秒" });
        }


        private bool method_2()
        {
            if (HiddenFieldGuid.Value != string.Empty)
            {
                dt = ishopNum1_SpecProudct_Action_0.dt_SpecProducts(HiddenFieldGuid.Value);
                if (dt.Rows.Count <= 0)
                {
                    return false;
                }
                DataTable table = ishopNum1_Spec_Action_0.SearchNameByGuid(HiddenFieldGuid.Value);
                if (table.Rows.Count > 0)
                {
                    RepeaterProductSepc.DataSource = table;
                    RepeaterProductSepc.DataBind();
                }
                if (RepeaterProductSepc.Items.Count > 0)
                {
                    var control =
                        (HtmlGenericControl)
                            RepeaterProductSepc.Controls[RepeaterProductSepc.Controls.Count - 1].FindControl(
                                "spanNoSelect");
                    string str = string.Empty;
                    foreach (DataRow row in table.Rows)
                    {
                        str = str + "\"" + row["specname"] + "\" ";
                    }
                    control.InnerHtml = str;
                }
                return true;
            }
            return false;
        }

        public void Product_Browse()
        {
            try
            {
                HttpCookie cookie = Page.Request.Cookies["MemberLoginCookie"];
                HttpCookie cookie2 = HttpSecureCookie.Decode(cookie);
                MemberLoginID = cookie2.Values["MemLoginID"];
            }
            catch (Exception)
            {
            }
            DataTable table = Common.Common.GetTableById("OriginalImage,MemLoginID", "ShopNum1_Shop_Product",
                "   AND  Guid='" + Page.Request.QueryString["guid"] + "'");
            string str = "";
            string str2 = "";
            if (table.Rows.Count > 0)
            {
                str = table.Rows[0]["OriginalImage"].ToString();
                str2 = table.Rows[0]["MemLoginID"].ToString();
            }
            if (!string.IsNullOrEmpty(MemberLoginID) && (str2 != MemberLoginID))
            {
                try
                {
                    bool flag;
                    var action =
                        (ShopNum1_ShopProduct_Browse_Action)LogicFactory.CreateShopNum1_ShopProduct_Browse_Action();
                    if (!(flag = action.GetDataByMemLoginID(Page.Request.QueryString["guid"], MemberLoginID)))
                    {
                        var browse = new ShopNum1_ShopProduct_Browse
                        {
                            BrowseDateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                            BrowseTimes = 1,
                            Guid = Guid.NewGuid(),
                            MemLoginID = MemberLoginID,
                            Name = LabelName.Text,
                            ProductGuid = new Guid(Page.Request.QueryString["guid"]),
                            ProductImage = str,
                            ShopID = str2,
                            ShopPrice = Convert.ToDecimal(LabelShopPrice.Text)
                        };
                        action.Add(browse);
                    }
                    else if (flag)
                    {
                        action.AddTimes(Page.Request.QueryString["guid"], MemberLoginID);
                    }
                }
                catch (Exception)
                {
                }
            }
        }

        protected void RepeaterProductSepc_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
            {
                try
                {
                    repeater_2 = (Repeater)e.Item.FindControl("RepeaterProductSepcDetail");
                    var builder = new StringBuilder();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string str =
                            dt.Rows[i]["specdetail"].ToString().Split(new[] { '|' })[e.Item.ItemIndex].Split(
                                new[] { ',' })[1];
                        if ((i <= 0) ||
                            (str !=
                             dt.Rows[i - 1]["specdetail"].ToString().Split(new[] { '|' })[e.Item.ItemIndex].Split
                                 (new[] { ',' })[1]))
                        {
                            builder.Append(str + ",");
                        }
                    }
                    if (builder.ToString() != "")
                    {
                        DataTable detailByDGuid =
                            ishopNum1_SpecProudctDetail_Action_0.GetDetailByDGuid(
                                builder.ToString().Substring(0, builder.Length - 1), HiddenFieldGuid.Value);
                        repeater_2.DataSource = detailByDGuid;
                        repeater_2.DataBind();
                    }
                    else
                    {
                        RepeaterProductSepc.DataSource = dt.DefaultView;
                        RepeaterProductSepc.DataBind();
                    }
                }
                catch
                {
                }
            }
        }
    }
}