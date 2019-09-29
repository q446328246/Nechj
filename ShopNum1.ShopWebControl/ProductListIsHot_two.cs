using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;

using ShopNum1MultiEntity;
using System.Configuration;
using ShopNum1.BusinessLogic;

using ShopNum1.ShopFactory;

using ShopNum1.Factory;
namespace ShopNum1.ShopWebControl
{
    [ParseChildren(true)]
    public class ProductListIsHot_two : BaseWebControl
    {
        private string skinFilename = "ProductListIsHot_two.ascx";

        private DropDownList ddlColor;
        private DropDownList ddlSize;
        private TextBox TextBoxBuyNum;


        private Repeater RepeaterData;
        private Literal LiteralProductGuid;
        private Literal LiteralClientId;
        private DataTable table;

        public ProductListIsHot_two()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public string MemLoginID { get; set; }

        public int ShowCount { get; set; }

        protected override void InitializeSkin(Control skin)
        {
            //string test = ConfigurationManager.AppSettings["Domain"];
            string shopid = (Page.Request.QueryString["ShopID"] == null) ? "0" : Page.Request.QueryString["ShopID"];
            var action = (Shop_ShopInfo_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_ShopInfo_Action();
            MemLoginID = action.GetMemberLoginidByShopid(shopid);
            RepeaterData = (Repeater)skin.FindControl("RepeaterData");
            RepeaterData.ItemDataBound += RepeaterData_ItemDataBound;
            if (!Page.IsPostBack)
            {
                
            }
            BindData();
            
        }

        protected void BindData()
        {
            string shopid2 = TJShopInfo.shopId;
            table =
                ((Shop_Product_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_Product_Action()).GetAllToShop_ProductByshop_category_id(shopid2, 4);

            RepeaterData.DataSource = table;
            RepeaterData.DataBind();
        }

        protected void RepeaterData_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            ddlColor = (DropDownList)e.Item.FindControl("ddlColor");
            ddlSize = (DropDownList)e.Item.FindControl("ddlSize");
            TextBoxBuyNum = (TextBox)e.Item.FindControl("TextBoxBuyNum");
            //LabelRepertoryCount = (Label)e.Item.FindControl("LabelRepertoryCount");

            //LiteralProductId = (Literal)e.Item.FindControl("LiteralProductId");
            LiteralProductGuid = (Literal)e.Item.FindControl("LiteralProductGuid");

            Button button = (Button)e.Item.FindControl("btnBuyProduct");

            string shopid2 = TJShopInfo.shopId;
            
           //DataTable table =
                //((Shop_Product_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_Product_Action()).GetAllToShop_ProductByshop_category_id_two(shopid2, 4, LiteralProductGuid.Text);
            
            DataRow row = table.Select(string.Format("guid = '{0}' ", LiteralProductGuid.Text))[0];
            if (row != null)
            {
                string cc = (row["Color"]).ToString().Replace("，", ",");

                button.OnClientClick = "return   buyProduct('" + row["guid"] + "','" + row["productId"] + "','" + e.Item.ClientID + "')";

                if (cc != "")
                {
                    ddlColor.DataSource = cc.Split(',');
                    ddlColor.DataBind();
                }

                string cc_two = row["Size"].ToString().Replace("，", ",");
                if (cc_two != "")
                {
                    ddlSize.DataSource = cc_two.Split(',');
                    ddlSize.DataBind();
                }
            }
               


        }
        public  string BuyProduct(string guid, string productid, string buyNum, string color, string size, HttpContext page,string type)
        {

            HttpCookie cookie = page.Request.Cookies["MemberLoginCookie"];
            string MemberLoginID = "";

            string category = type;
                HttpCookie cookieMemRankGuid = HttpSecureCookie.Decode(page.Request.Cookies["MemberLoginCookie"]);

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
                DataTable linkCategory = ShopNum1.Factory.LogicFactory.CreateMemberRank_LinkCategory_Action().GetRankLinkCategoryByID(MemRankGuid, "2");

                MemLinkCategory = linkCategory.Rows[0]["Category_ID"].ToString();
                if (!MemLinkCategory.Contains(category))
                {
                    MessageBox.Show("您的会员等级权限不足!");
                    return "您的会员等级权限不足!";
                }
                else
                {

                    if (page.Request.Cookies["MemberLoginCookie"] != null)
                    {
                        cookie = page.Request.Cookies["MemberLoginCookie"];
                        HttpCookie cookie2 = HttpSecureCookie.Decode(cookie);
                        MemberLoginID = cookie2.Values["MemLoginID"];     
                        
                    }
                    else
                    {
                        string myMemLoginID = string.Empty;
                        if (page.Request.Cookies["Visitor_LoginCookie"] != null)
                        {
                            cookie = page.Request.Cookies["Visitor_LoginCookie"];
                            myMemLoginID = HttpSecureCookie.Decode(cookie).Values["MemLoginID"];
                        }
                        else
                        {
                            string str = "visitor_" + new Order().CreateOrderNumber();
                            var cookie3 = new HttpCookie("Visitor_LoginCookie");
                            cookie3.Values.Add("MemLoginID", str);
                            HttpCookie cookie4 = HttpSecureCookie.Encode(cookie3);
                            cookie4.Domain = ConfigurationManager.AppSettings["CookieDomain"];
                            page.Response.AppendCookie(cookie4);
                            myMemLoginID = str;
                        }

                       
                    }
                    return AddShopCar(MemberLoginID, productid, new Guid(guid), buyNum, color, size, type, page);
                
                }
            
        }


        public string MemberLoginID { get; set; }

        public string MemberType { get; set; }

        public string ShopName { get; set; }

        public  string AddShopCar(string MyMemLoginID, string prodactId, Guid cc1, string TextBoxBuyNum_one, string dlcololr, string dlSize, string type, HttpContext page)
        {
            string MemberLoginID = "";
             DataTable table1 =
                ((Shop_Product_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_Product_Action()).SelecetBuyNumberByGuid(cc1, MyMemLoginID);
             int MyBuyNumber = 0;
             if (table1!=null&& table1.Rows.Count > 0)
             {
                  MyBuyNumber =Convert.ToInt32 (table1.Rows[0]["BuyNumber"]);
             }
             else
             {
                 MyBuyNumber = 0;
             }
      

             DataTable table2 =
                ((Shop_Product_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_Product_Action()).SelecetMaxNumberByid(Convert.ToInt32( prodactId));

             int MAXBuyNumber = Convert.ToInt32(table2.Rows[0]["MaxNumber"]);

             if ((MyBuyNumber + Convert.ToInt32(TextBoxBuyNum_one)) > MAXBuyNumber  && type!="7")
             {
                 MessageBox.Show("产品购买施行数量限制，您不能购买大于"+MAXBuyNumber+"件本商品");
                 return "产品购买施行数量限制，您不能购买大于" + MAXBuyNumber + "件本商品";
             }
             else
             {

             
            string productId = prodactId;
            string shopid2 = TJShopInfo.shopId;
            DataTable table =
                ((Shop_Product_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_Product_Action()).GetAllToShop_ProductByshop_category_id_free(shopid2, Convert.ToInt32(type), productId);
                 string RepertoryCount= table.Rows[0]["RepertoryCount"].ToString();
            HttpCookie cookie2 = page.Request.Cookies["MemberLoginCookie"];
            HttpCookie cookie3 = HttpSecureCookie.Decode(cookie2);
            MemberLoginID = cookie3.Values["MemLoginID"];
            var cd = (ShopNum1_Cart_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Cart_Action();
            if (cd.SelectShopCar(MemberLoginID).Rows.Count > 0)
            {
              //  if (Convert.ToString(cd.SelectShopCar(MemberLoginID).Rows[0][0]) != Convert.ToString(table.Rows[0]["shop_category_id"].ToString()))
                if(false)
                {
                  //  MessageBox.Show("不可添加多个不同专区到购物车!");
                  //  return "不可添加多个不同专区到购物车!";
                }


                else
                {
                    bool flag = false;


                    try
                    {
                        if (int.Parse(TextBoxBuyNum_one) > 0)
                        {
                            flag = true;
                        }
                        else
                        {
                            MessageBox.Show("请正确填写购买数量!");
                            return "请正确填写购买数量!";
                        }
                        if (int.Parse(RepertoryCount) < int.Parse(TextBoxBuyNum_one))
                        {
                            MessageBox.Show("商品库存不足！");
                            return "商品库存不足！";
                        }

                    }
                    catch (Exception)
                    {
                        MessageBox.Show("请正确填写购买数量!");
                        return "请正确填写购买数量!";
                    }
                    if (flag)
                    {

                        decimal a;
                        decimal b;
                        if (Convert.ToDecimal(table.Rows[0]["Score_hv"]) == 0)
                        {
                            a = Convert.ToDecimal(table.Rows[0]["Score_max_hv"]) * (-1);
                        }
                        else
                        {
                            a = Convert.ToDecimal(table.Rows[0]["Score_hv"]);
                        }
                        if (Convert.ToDecimal(table.Rows[0]["Score_pv_a"]) == 0)
                        {
                            b = Convert.ToDecimal(table.Rows[0]["Score_cv"]) * (-1);
                        }
                        else
                        {
                            b = Convert.ToDecimal(table.Rows[0]["Score_pv_a"]);
                        }
                        var shopcart = new ShopNum1_Shop_Cart
                        {
                            Guid = Guid.NewGuid(),
                            MemLoginID = MyMemLoginID,
                            ProductGuid = cc1,
                            OriginalImge = table.Rows[0]["OriginalImage"].ToString(),
                            Name = table.Rows[0]["Name"].ToString(),
                            RepertoryNumber = table.Rows[0]["ProductNum"].ToString(),
                            BuyNumber = int.Parse(TextBoxBuyNum_one),
                            MarketPrice = decimal.Parse(table.Rows[0]["MarketPrice"].ToString()),
                            shop_category_id = Convert.ToInt32(table.Rows[0]["shop_category_id"].ToString()),

                            Score_hv = a,
                            Score_pv_a = b,
                            Size = dlSize,
                            Color = dlcololr,
                            ShopPrice = decimal.Parse(table.Rows[0]["ShopPrice"].ToString()),
                            Attributes = table.Rows[0]["setStock"].ToString(),

                            BuyPrice = decimal.Parse(table.Rows[0]["ShopPrice"].ToString()),
                            IsShipment = 0,
                            IsReal = int.Parse(table.Rows[0]["IsReal"].ToString()),
                            ExtensionAttriutes = "",
                            IsJoinActivity = 0,
                            CartType = 0,
                            IsPresent = 0,
                            CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                            DetailedSpecifications = "",
                            ShopID = table.Rows[0]["MemloginId"].ToString(),
                            SellName = table.Rows[0]["ShopName"].ToString(),
                            FeeType = int.Parse(table.Rows[0]["FeeType"].ToString()),

                            SpecificationValue = "",
                            Post_fee = 0,
                            Ems_fee = 0,
                            Express_fee = 0
                            //Guid,MemLoginID,ProductGuid,OriginalImge,Name,RepertoryNumber,BuyNumber,MarketPrice,ShopPrice,BuyPrice,Attributes,SpecificationName,SpecificationValue,IsShipment,IsReal,ExtensionAttriutes,shopcart.DetailedSpecifications ,IsJoinActivity,CartType,IsPresent,CreateTime,ShopID,SellName,FeeType,Post_fee,Express_fee,Ems_fee,shop_category_id,Score_pv_a,Score_hv,Color,Size
                        };
                        var action = (ShopNum1_Cart_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Cart_Action();
                        action.AddCart(shopcart);
                       
                        #region 没用的
                        string text = table.Rows[0]["ShopPrice"].ToString();
                        //if (!string.IsNullOrEmpty(HiddenFieldGuiGev.Value))
                        //{
                        //    specificationByProduct =
                        //        ishopNum1_SpecProudct_Action_0.GetSpecificationByProduct(HiddenFieldGuid.Value,
                        //            HiddenFieldGuiGev.Value.Replace(":", ",")
                        //                .Replace(";", "|")
                        //                .TrimEnd(new[] { ';' })
                        //                .TrimEnd(new[] { '|' }));
                        //    if (((specificationByProduct != null) && (specificationByProduct.Rows.Count > 0)) &&
                        //        (specificationByProduct.Rows[0]["GoodsPrice"].ToString() != ""))
                        //    {
                        //        text = specificationByProduct.Rows[0]["GoodsPrice"].ToString();
                        //    }
                        //}
                        //shopcart.ShopPrice = decimal.Parse(text);
                        //shopcart.Attributes = string_2;
                        //if (!string.IsNullOrEmpty(HiddenFieldGuiGev.Value))
                        //{
                        //    specificationByProduct =
                        //        ishopNum1_SpecProudct_Action_0.GetSpecificationByProduct(HiddenFieldGuid.Value,
                        //            HiddenFieldGuiGev.Value.Replace(":", ",")
                        //                .Replace(";", "|")
                        //                .TrimEnd(new[] { ';' })
                        //                .TrimEnd(new[] { '|' }));
                        //    if ((specificationByProduct != null) && (specificationByProduct.Rows.Count > 0))
                        //    {
                        //        shopcart.BuyPrice = Convert.ToDecimal(specificationByProduct.Rows[0]["GoodsPrice"].ToString());
                        //    }
                        //    else
                        //    {
                        //        shopcart.BuyPrice = decimal.Parse(LabelShopPrice.Text.Trim());
                        //    }
                        //}
                        //else
                        //{
                        //    shopcart.BuyPrice = decimal.Parse(LabelShopPrice.Text.Trim());
                        //}
                        //if (trDisCount.Visible)
                        //{
                        //    if (hidSaleType.Value == "1")
                        //    {
                        //        shopcart.BuyPrice = decimal.Parse(lblPromotionPrice.Text);
                        //    }
                        //    else if (hidSaleType.Value == "2")
                        //    {
                        //        decimal d = Convert.ToDecimal(LabelShopPrice.Text) * Convert.ToDecimal(hidDisCount.Value);
                        //        shopcart.BuyPrice = Math.Round(d, 2);
                        //    }
                        //}
                        //if (lblPriceTxt.Text == "抢 购 价：")
                        //{
                        //    hidSaleType.Value = "4";
                        //}
                        //shopcart.IsShipment = 0;
                        //shopcart.IsReal = int.Parse(hidIsReal.Value);
                        //shopcart.ExtensionAttriutes = "";
                        //shopcart.IsJoinActivity = 0;
                        //shopcart.CartType = Convert.ToInt32(hidSaleType.Value);
                        //shopcart.IsPresent = 0;
                        //shopcart.CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        //shopcart.DetailedSpecifications = "";
                        //shopcart.ShopID = hidMemloginId.Value;
                        //shopcart.SellName = hidShopName.Value;
                        //shopcart.FeeType = int.Parse(hidFeeType.Value);
                        //shopcart.shop_category_id = tr_shop_category_id;
                        //if (HiddenFieldGuiGe.Value.Length > 1)
                        //{
                        //    if (HiddenFieldGuiGe.Value.Trim(new[] { ';' }) != "0")
                        //    {
                        //        shopcart.SpecificationValue =
                        //            HiddenFieldGuiGev.Value.Trim(new[] { ';' }).Replace(":", ",").Replace(";", "|");
                        //    }
                        //    if (HiddenFieldSpecName.Value.Trim(new[] { ';' }) != "0")
                        //    {
                        //        shopcart.SpecificationName =
                        //            HiddenFieldSpecName.Value.TrimEnd(new[] { ';' }).Replace("/", "-").TrimEnd(new[] { '0' });
                        //    }
                        //}
                        //if (hidFeeType.Value == "1")
                        //{
                        //    shopcart.Post_fee = 0;
                        //    shopcart.Ems_fee = 0;
                        //    shopcart.Express_fee = 0;
                        //}
                        //else
                        //{
                        //    shopcart.Post_fee = decimal.Parse(LabelPost_Fee.Text);
                        //    shopcart.Ems_fee = decimal.Parse(LabelEms_fee.Text);
                        //    shopcart.Express_fee = decimal.Parse(LabelExpress_fee.Text);
                        //}
                        //var action = (ShopNum1_Cart_Action)LogicFactory.CreateShopNum1_Cart_Action();
                        //int num = 0;
                        //if (shopcart.SellName != "")
                        //{
                        //    num = action.AddCart(shopcart);
                        //}
                        //else
                        //{
                        //    num = 1;
                        //}
                        //if (num > 0)
                        //{
                        //    Page.Response.Redirect(GetPageName.RetDomainUrl("ShoppingCart1"));
                        //    MessageBox.Show("添加成功!");
                        //}
                        //else
                        //{
                        //    MessageBox.Show("添加失败!");
                        //}
                        #endregion
                    }
                    return "1";
                }

            }
            else
            {
                bool flag = false;


                try
                {
                    if (int.Parse(TextBoxBuyNum_one) > 0)
                    {
                        flag = true;
                    }
                    else
                    {
                        MessageBox.Show("请正确填写购买数量!");
                        return "请正确填写购买数量!";
                    }
                    if (int.Parse(RepertoryCount.Trim()) < int.Parse(TextBoxBuyNum_one))
                    {
                        MessageBox.Show("商品库存不足！");
                        return "商品库存不足！";
                    }

                }
                catch (Exception)
                {
                    MessageBox.Show("请正确填写购买数量!");
                    return "请正确填写购买数量!";
                }
                if (flag)
                {

                    decimal a;
                    decimal b;
                    if (Convert.ToDecimal(table.Rows[0]["Score_hv"]) == 0)
                    {
                        a = Convert.ToDecimal(table.Rows[0]["Score_max_hv"]) * (-1);
                    }
                    else
                    {
                        a = Convert.ToDecimal(table.Rows[0]["Score_hv"]);
                    }
                    if (Convert.ToDecimal(table.Rows[0]["Score_pv_a"]) == 0)
                    {
                        b = Convert.ToDecimal(table.Rows[0]["Score_cv"]) * (-1);
                    }
                    else
                    {
                        b = Convert.ToDecimal(table.Rows[0]["Score_pv_a"]);
                    }
                    var shopcart = new ShopNum1_Shop_Cart
                    {
                        Guid = Guid.NewGuid(),
                        MemLoginID = MyMemLoginID,
                        ProductGuid = cc1,
                        OriginalImge = table.Rows[0]["OriginalImage"].ToString(),
                        Name = table.Rows[0]["Name"].ToString(),
                        RepertoryNumber = table.Rows[0]["ProductNum"].ToString(),
                        BuyNumber = int.Parse(TextBoxBuyNum_one),
                        MarketPrice = decimal.Parse(table.Rows[0]["MarketPrice"].ToString()),
                        shop_category_id = Convert.ToInt32(table.Rows[0]["shop_category_id"].ToString()),

                        Score_hv = a,
                        Score_pv_a = b,
                        Size = dlSize,
                        Color = dlcololr,
                        ShopPrice = decimal.Parse(table.Rows[0]["ShopPrice"].ToString()),
                        Attributes = table.Rows[0]["setStock"].ToString(),

                        BuyPrice = decimal.Parse(table.Rows[0]["ShopPrice"].ToString()),
                        IsShipment = 0,
                        IsReal = int.Parse(table.Rows[0]["IsReal"].ToString()),
                        ExtensionAttriutes = "",
                        IsJoinActivity = 0,
                        CartType = 0,
                        IsPresent = 0,
                        CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                        DetailedSpecifications = "",
                        ShopID = table.Rows[0]["MemloginId"].ToString(),
                        SellName = table.Rows[0]["ShopName"].ToString(),
                        FeeType = int.Parse(table.Rows[0]["FeeType"].ToString()),

                        SpecificationValue = "",
                        Post_fee = 0,
                        Ems_fee = 0,
                        Express_fee = 0
                        //Guid,MemLoginID,ProductGuid,OriginalImge,Name,RepertoryNumber,BuyNumber,MarketPrice,ShopPrice,BuyPrice,Attributes,SpecificationName,SpecificationValue,IsShipment,IsReal,ExtensionAttriutes,shopcart.DetailedSpecifications ,IsJoinActivity,CartType,IsPresent,CreateTime,ShopID,SellName,FeeType,Post_fee,Express_fee,Ems_fee,shop_category_id,Score_pv_a,Score_hv,Color,Size
                    };
                    var action = (ShopNum1_Cart_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Cart_Action();
                    action.AddCart(shopcart);
                    
                    #region 没用的
                    string text = table.Rows[0]["ShopPrice"].ToString();
                    //if (!string.IsNullOrEmpty(HiddenFieldGuiGev.Value))
                    //{
                    //    specificationByProduct =
                    //        ishopNum1_SpecProudct_Action_0.GetSpecificationByProduct(HiddenFieldGuid.Value,
                    //            HiddenFieldGuiGev.Value.Replace(":", ",")
                    //                .Replace(";", "|")
                    //                .TrimEnd(new[] { ';' })
                    //                .TrimEnd(new[] { '|' }));
                    //    if (((specificationByProduct != null) && (specificationByProduct.Rows.Count > 0)) &&
                    //        (specificationByProduct.Rows[0]["GoodsPrice"].ToString() != ""))
                    //    {
                    //        text = specificationByProduct.Rows[0]["GoodsPrice"].ToString();
                    //    }
                    //}
                    //shopcart.ShopPrice = decimal.Parse(text);
                    //shopcart.Attributes = string_2;
                    //if (!string.IsNullOrEmpty(HiddenFieldGuiGev.Value))
                    //{
                    //    specificationByProduct =
                    //        ishopNum1_SpecProudct_Action_0.GetSpecificationByProduct(HiddenFieldGuid.Value,
                    //            HiddenFieldGuiGev.Value.Replace(":", ",")
                    //                .Replace(";", "|")
                    //                .TrimEnd(new[] { ';' })
                    //                .TrimEnd(new[] { '|' }));
                    //    if ((specificationByProduct != null) && (specificationByProduct.Rows.Count > 0))
                    //    {
                    //        shopcart.BuyPrice = Convert.ToDecimal(specificationByProduct.Rows[0]["GoodsPrice"].ToString());
                    //    }
                    //    else
                    //    {
                    //        shopcart.BuyPrice = decimal.Parse(LabelShopPrice.Text.Trim());
                    //    }
                    //}
                    //else
                    //{
                    //    shopcart.BuyPrice = decimal.Parse(LabelShopPrice.Text.Trim());
                    //}
                    //if (trDisCount.Visible)
                    //{
                    //    if (hidSaleType.Value == "1")
                    //    {
                    //        shopcart.BuyPrice = decimal.Parse(lblPromotionPrice.Text);
                    //    }
                    //    else if (hidSaleType.Value == "2")
                    //    {
                    //        decimal d = Convert.ToDecimal(LabelShopPrice.Text) * Convert.ToDecimal(hidDisCount.Value);
                    //        shopcart.BuyPrice = Math.Round(d, 2);
                    //    }
                    //}
                    //if (lblPriceTxt.Text == "抢 购 价：")
                    //{
                    //    hidSaleType.Value = "4";
                    //}
                    //shopcart.IsShipment = 0;
                    //shopcart.IsReal = int.Parse(hidIsReal.Value);
                    //shopcart.ExtensionAttriutes = "";
                    //shopcart.IsJoinActivity = 0;
                    //shopcart.CartType = Convert.ToInt32(hidSaleType.Value);
                    //shopcart.IsPresent = 0;
                    //shopcart.CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    //shopcart.DetailedSpecifications = "";
                    //shopcart.ShopID = hidMemloginId.Value;
                    //shopcart.SellName = hidShopName.Value;
                    //shopcart.FeeType = int.Parse(hidFeeType.Value);
                    //shopcart.shop_category_id = tr_shop_category_id;
                    //if (HiddenFieldGuiGe.Value.Length > 1)
                    //{
                    //    if (HiddenFieldGuiGe.Value.Trim(new[] { ';' }) != "0")
                    //    {
                    //        shopcart.SpecificationValue =
                    //            HiddenFieldGuiGev.Value.Trim(new[] { ';' }).Replace(":", ",").Replace(";", "|");
                    //    }
                    //    if (HiddenFieldSpecName.Value.Trim(new[] { ';' }) != "0")
                    //    {
                    //        shopcart.SpecificationName =
                    //            HiddenFieldSpecName.Value.TrimEnd(new[] { ';' }).Replace("/", "-").TrimEnd(new[] { '0' });
                    //    }
                    //}
                    //if (hidFeeType.Value == "1")
                    //{
                    //    shopcart.Post_fee = 0;
                    //    shopcart.Ems_fee = 0;
                    //    shopcart.Express_fee = 0;
                    //}
                    //else
                    //{
                    //    shopcart.Post_fee = decimal.Parse(LabelPost_Fee.Text);
                    //    shopcart.Ems_fee = decimal.Parse(LabelEms_fee.Text);
                    //    shopcart.Express_fee = decimal.Parse(LabelExpress_fee.Text);
                    //}
                    //var action = (ShopNum1_Cart_Action)LogicFactory.CreateShopNum1_Cart_Action();
                    //int num = 0;
                    //if (shopcart.SellName != "")
                    //{
                    //    num = action.AddCart(shopcart);
                    //}
                    //else
                    //{
                    //    num = 1;
                    //}
                    //if (num > 0)
                    //{
                    //    Page.Response.Redirect(GetPageName.RetDomainUrl("ShoppingCart1"));
                    //    MessageBox.Show("添加成功!");
                    //}
                    //else
                    //{
                    //    MessageBox.Show("添加失败!");
                    //}
                    #endregion
                }
                return "1";
            }
            }
        }
    }
	}


