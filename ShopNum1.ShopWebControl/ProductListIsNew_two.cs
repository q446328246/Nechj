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
using ShopNum1.ShopFactory;




using ShopNum1MultiEntity;
using System.Configuration;
using ShopNum1.BusinessLogic;

using ShopNum1.ShopFactory;

using ShopNum1.Factory;
using System.Web.UI.HtmlControls;
namespace ShopNum1.ShopWebControl
{
    [ParseChildren(true)]
    public class ProductListIsNew_two : BaseWebControl
    {
        private string skinFilename = "ProductListIsNew_two.ascx";
         private DropDownList ddlColor;
        private DropDownList ddlSize;
        private TextBox TextBoxBuyNum;
        private Label LabelRepertoryCount;

        private Literal LiteralProductId;
        private Literal LiteralProductGuid;

        private Repeater RepeaterData;
        private DataTable table;

        private Button butAllPrice;
        public ProductListIsNew_two()
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
            string shopid = (Page.Request.QueryString["ShopID"] == null) ? "0" : Page.Request.QueryString["ShopID"];
            var action = (Shop_ShopInfo_Action) ShopNum1.ShopFactory.LogicFactory.CreateShop_ShopInfo_Action();
            MemLoginID = action.GetMemberLoginidByShopid(shopid);
            RepeaterData = (Repeater) skin.FindControl("RepeaterData");
            RepeaterData.ItemDataBound += RepeaterData_ItemDataBound;
            //RepeaterData.ItemCommand += RepeaterData_ItemCommand;

            butAllPrice = (Button)skin.FindControl("butAllPrice");
            butAllPrice.Click += butAllPrice_click;


            if (!Page.IsPostBack)
            {
            }
            BindData();
        }

        protected void BindData()
        {
            string shopid2 = TJShopInfo.shopId;
             table =
                ((Shop_Product_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_Product_Action()).GetAllToShop_ProductByshop_category_id(shopid2, 5);
         
            RepeaterData.DataSource = table;
            RepeaterData.DataBind();
        }

        protected void RepeaterData_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            ddlColor = (DropDownList)e.Item.FindControl("ddlColorcc");
            ddlSize = (DropDownList)e.Item.FindControl("ddlSizecc");
            TextBoxBuyNum = (TextBox)e.Item.FindControl("TextBoxBuyNum1");
            LabelRepertoryCount = (Label)e.Item.FindControl("LabelRepertoryCount");
            LiteralProductId = (Literal)e.Item.FindControl("LiteralProductId");
            LiteralProductGuid = (Literal)e.Item.FindControl("LiteralProductGuid");
            Button button = (Button)e.Item.FindControl("btnBuyProduct2");


            
            //HtmlInputButton button2 = (HtmlInputButton)e.Item.FindControl("btnCut");
            //button2.OnClientClick = "cutnum('" + TextBoxBuyNum.ClientID + "')";
            string shopid2 = TJShopInfo.shopId;
            //DataTable table =
            //    ((Shop_Product_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_Product_Action()).GetAllToShop_ProductByshop_category_id_two(shopid2, 5, LiteralProductGuid.Text);
            DataRow row = table.Select(string.Format("guid = '{0}' ", LiteralProductGuid.Text))[0];
            
            if (table != null )
            {
                button.OnClientClick = "return   buyProduct2('" + row["guid"] + "','" + row["productId"] + "','" + e.Item.ClientID + "')";
                string cc = (row["Color"]).ToString().Replace("，", ",");
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


        protected void butAllPrice_click(object sender, EventArgs e)
        {
            MessageBox.Show("你好");
            ProductListIsHot_two product = new ProductListIsHot_two();
           
        }
       
        
        //遍历repeater
        //var aa = 0;
        //for (int i = 0; i < RepeaterData.Items.Count; i++)
        //{
        //    CheckBox check = RepeaterData.Items[i].FindControl("checkbox1") as CheckBox;
        //    if (check.Checked == true)
        //    {
        //        aa += 1;
        //    }
        //    else
        //    {
        //        return;
        //    }
        //}


        //protected void RepeaterData_ItemCommand(object sender, RepeaterCommandEventArgs e)
        //{
            
        //    HttpCookie cookie = Page.Request.Cookies["MemberLoginCookie"];
        //    if (e.CommandName == "buy")
        //    {
        //        //e.CommandArgument = "";
        //        var literal = (Literal)e.Item.FindControl("LiteralMemLoginID");
        //        var literal2 = (Literal)e.Item.FindControl("LiteralGroupPrice");
        //        string text = literal2.Text;
        //        var literal3 = (Literal)e.Item.FindControl("LiteralProductName");
        //        string productName = literal3.Text;
        //        var literal4 = (Literal)e.Item.FindControl("LiteralShopName");
        //        string shopID = literal4.Text;
        //        var literal5 = (Literal)e.Item.FindControl("LiteralProductGuid");

        //        var prodactId = (Literal)e.Item.FindControl("LiteralProductId");
        //        string productguid = literal5.Text;
        //        var dlcololr = (DropDownList)e.Item.FindControl("ddlColor");
        //        var TextBoxBuyNum_one = (TextBox)e.Item.FindControl("TextBoxBuyNum1");

        //        var dlSize = (DropDownList)e.Item.FindControl("ddlSize");

        //        Guid cc = new Guid(literal5.Text);
        //        string category = "5";
        //        HttpCookie cookieMemRankGuid = HttpSecureCookie.Decode(Page.Request.Cookies["MemberLoginCookie"]);

        //        string MemRankGuid = null;
        //        string MemLinkCategory = null;
        //        //判断是否登陆，若没有登陆取会员等级为普通用户的Guid
        //        //if (cookieMemRankGuid != null)
        //        //{
        //        MemRankGuid = cookieMemRankGuid.Values["MemRankGuid"];
        //        //}
        //        //else
        //        //{
        //        //    MemRankGuid = MemberLevel.NORMAL_MEMBER_ID;
        //        //}
        //        //根据会员等级的Guid以及可看属性获得专区板块ID字符串
        //        DataTable linkCategory = ShopNum1.Factory.LogicFactory.CreateMemberRank_LinkCategory_Action().GetRankLinkCategoryByID(MemRankGuid, "2");

        //        MemLinkCategory = linkCategory.Rows[0]["Category_ID"].ToString();
        //        if (!MemLinkCategory.Contains(category))
        //        {
        //            MessageBox.Show("您的会员等级权限不足!");
        //        }
        //        else
        //        {
        //            if (Page.Request.Cookies["MemberLoginCookie"] != null)
        //            {
        //                cookie = Page.Request.Cookies["MemberLoginCookie"];
        //                HttpCookie cookie2 = HttpSecureCookie.Decode(cookie);
        //                MemberLoginID = cookie2.Values["MemLoginID"];
        //                //cookie2.Values["MemberType"];

        //                if (dlcololr.SelectedValue=="")
        //                {
        //                    dlcololr.SelectedValue = "无";
        //                }
        //                 if (dlSize.SelectedValue=="")
        //                {
        //                    dlSize.SelectedValue = "无";
        //                }
        //                AddShopCar(MemberLoginID, prodactId.Text, cc, TextBoxBuyNum_one.Text, dlcololr.SelectedValue, dlSize.SelectedValue);
        //            }
        //            else
        //            {
        //                string myMemLoginID = string.Empty;
        //                if (Page.Request.Cookies["Visitor_LoginCookie"] != null)
        //                {
        //                    cookie = Page.Request.Cookies["Visitor_LoginCookie"];
        //                    myMemLoginID = HttpSecureCookie.Decode(cookie).Values["MemLoginID"];
        //                }
        //                else
        //                {
        //                    string str = "visitor_" + new Order().CreateOrderNumber();
        //                    var cookie3 = new HttpCookie("Visitor_LoginCookie");
        //                    cookie3.Values.Add("MemLoginID", str);
        //                    HttpCookie cookie4 = HttpSecureCookie.Encode(cookie3);
        //                    cookie4.Domain = ConfigurationManager.AppSettings["CookieDomain"];
        //                    Page.Response.AppendCookie(cookie4);
        //                    myMemLoginID = str;
        //                }
        //                if (dlcololr.SelectedValue == "")
        //                {
        //                    dlcololr.SelectedValue = "无";
        //                }
        //                if (dlSize.SelectedValue == "")
        //                {
        //                    dlSize.SelectedValue = "无";
        //                }
        //                AddShopCar(myMemLoginID, prodactId.Text, cc, TextBoxBuyNum_one.Text, dlcololr.SelectedValue, dlSize.SelectedValue);
        //            }
        //        }
        //    }
        //}

        public string MemberLoginID { get; set; }

        public string MemberType { get; set; }

        public string ShopName { get; set; }

    //    public void AddShopCar(string MyMemLoginID, string prodactId, Guid cc1, string TextBoxBuyNum_one, string dlcololr, string dlSize)
    //    {
    //        string productId = prodactId;
    //        string shopid2 = TJShopInfo.shopId;
    //        DataTable table;
            
    //        table =
    //       ((Shop_Product_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_Product_Action()).GetAllToShop_ProductByshop_category_id_free(shopid2, 5, productId);
           
    //        HttpCookie cookie2 = Page.Request.Cookies["MemberLoginCookie"];
    //        HttpCookie cookie3 = HttpSecureCookie.Decode(cookie2);
    //        MemberLoginID = cookie3.Values["MemLoginID"];
    //        var cd = (ShopNum1_Cart_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Cart_Action();
    //        if (cd.SelectShopCar(MemberLoginID).Rows.Count > 0)
    //        {
    //            if (Convert.ToString(cd.SelectShopCar(MemberLoginID).Rows[0][0]) != Convert.ToString(table.Rows[0]["shop_category_id"].ToString()))
    //            {
    //                MessageBox.Show("不可添加多个不同专区到购物车!");
    //            }


    //            else
    //            {


    //                bool flag = false;
    //                try
    //                {
    //                    if (int.Parse(TextBoxBuyNum.Text) > 0)
    //                    {
    //                        flag = true;
    //                    }
    //                    else
    //                    {
    //                        MessageBox.Show("请正确填写购买数量!");
    //                    }
    //                    if (int.Parse(LabelRepertoryCount.Text.Trim()) < int.Parse(TextBoxBuyNum.Text))
    //                    {
    //                        MessageBox.Show("商品库存不足！");
    //                        return;
    //                    }

    //                }
    //                catch (Exception)
    //                {
    //                    MessageBox.Show("请正确填写购买数量!");
    //                }
    //                if (flag)
    //                {

    //                    decimal a;
    //                    decimal b;
    //                    if (Convert.ToDecimal(table.Rows[0]["Score_hv"]) == 0)
    //                    {
    //                        a = Convert.ToDecimal(table.Rows[0]["Score_max_hv"]) * (-1);
    //                    }
    //                    else
    //                    {
    //                        a = Convert.ToDecimal(table.Rows[0]["Score_hv"]);
    //                    }
    //                    if (Convert.ToDecimal(table.Rows[0]["Score_pv_a"]) == 0)
    //                    {
    //                        b = Convert.ToDecimal(table.Rows[0]["Score_cv"]) * (-1);
    //                    }
    //                    else
    //                    {
    //                        b = Convert.ToDecimal(table.Rows[0]["Score_pv_a"]);
    //                    }
    //                    var shopcart = new ShopNum1_Shop_Cart
    //                    {
    //                        Guid = Guid.NewGuid(),
    //                        MemLoginID = MyMemLoginID,
    //                        ProductGuid = cc1,
    //                        OriginalImge = table.Rows[0]["OriginalImage"].ToString(),
    //                        Name = table.Rows[0]["Name"].ToString(),
    //                        RepertoryNumber = table.Rows[0]["ProductNum"].ToString(),
    //                        BuyNumber = int.Parse(TextBoxBuyNum_one),
    //                        MarketPrice = decimal.Parse(table.Rows[0]["MarketPrice"].ToString()),
    //                        shop_category_id = Convert.ToInt32(table.Rows[0]["shop_category_id"].ToString()),

    //                        Score_hv = a,
    //                        Score_pv_a = b,
    //                        Size = dlSize,
    //                        Color = dlcololr,
    //                        ShopPrice = decimal.Parse(table.Rows[0]["ShopPrice"].ToString()),
    //                        Attributes = table.Rows[0]["setStock"].ToString(),

    //                        BuyPrice = decimal.Parse(table.Rows[0]["ShopPrice"].ToString()),
    //                        IsShipment = 0,
    //                        IsReal = int.Parse(table.Rows[0]["IsReal"].ToString()),
    //                        ExtensionAttriutes = "",
    //                        IsJoinActivity = 0,
    //                        CartType = 0,
    //                        IsPresent = 0,
    //                        CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
    //                        DetailedSpecifications = "",
    //                        ShopID = table.Rows[0]["MemloginId"].ToString(),
    //                        SellName = table.Rows[0]["ShopName"].ToString(),
    //                        FeeType = int.Parse(table.Rows[0]["FeeType"].ToString()),

    //                        SpecificationValue = "",
    //                        Post_fee = 0,
    //                        Ems_fee = 0,
    //                        Express_fee = 0
                         
    //                    };
    //                    var action = (ShopNum1_Cart_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Cart_Action();
    //                    action.AddCart(shopcart);
                      
    //                }
    //            }
    //        }
    //        else
    //        {
    //            bool flag = false;
    //            try
    //            {
    //                if (int.Parse(TextBoxBuyNum.Text) > 0)
    //                {
    //                    flag = true;
    //                }
    //                else
    //                {
    //                    MessageBox.Show("请正确填写购买数量!");
    //                }
    //                if (int.Parse(LabelRepertoryCount.Text.Trim()) < int.Parse(TextBoxBuyNum.Text))
    //                {
    //                    MessageBox.Show("商品库存不足！");
    //                    return;
    //                }

    //            }
    //            catch (Exception)
    //            {
    //                MessageBox.Show("请正确填写购买数量!");
    //            }
    //            if (flag)
    //            {

    //                decimal a;
    //                decimal b;
    //                if (Convert.ToDecimal(table.Rows[0]["Score_hv"]) == 0)
    //                {
    //                    a = Convert.ToDecimal(table.Rows[0]["Score_max_hv"]) * (-1);
    //                }
    //                else
    //                {
    //                    a = Convert.ToDecimal(table.Rows[0]["Score_hv"]);
    //                }
    //                if (Convert.ToDecimal(table.Rows[0]["Score_pv_a"]) == 0)
    //                {
    //                    b = Convert.ToDecimal(table.Rows[0]["Score_cv"]) * (-1);
    //                }
    //                else
    //                {
    //                    b = Convert.ToDecimal(table.Rows[0]["Score_pv_a"]);
    //                }
    //                var shopcart = new ShopNum1_Shop_Cart
    //                {
    //                    Guid = Guid.NewGuid(),
    //                    MemLoginID = MyMemLoginID,
    //                    ProductGuid = cc1,
    //                    OriginalImge = table.Rows[0]["OriginalImage"].ToString(),
    //                    Name = table.Rows[0]["Name"].ToString(),
    //                    RepertoryNumber = table.Rows[0]["ProductNum"].ToString(),
    //                    BuyNumber = int.Parse(TextBoxBuyNum_one),
    //                    MarketPrice = decimal.Parse(table.Rows[0]["MarketPrice"].ToString()),
    //                    shop_category_id = Convert.ToInt32(table.Rows[0]["shop_category_id"].ToString()),

    //                    Score_hv = a,
    //                    Score_pv_a = b,
    //                    Size = dlSize,
    //                    Color = dlcololr,
    //                    ShopPrice = decimal.Parse(table.Rows[0]["ShopPrice"].ToString()),
    //                    Attributes = table.Rows[0]["setStock"].ToString(),

    //                    BuyPrice = decimal.Parse(table.Rows[0]["ShopPrice"].ToString()),
    //                    IsShipment = 0,
    //                    IsReal = int.Parse(table.Rows[0]["IsReal"].ToString()),
    //                    ExtensionAttriutes = "",
    //                    IsJoinActivity = 0,
    //                    CartType = 0,
    //                    IsPresent = 0,
    //                    CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
    //                    DetailedSpecifications = "",
    //                    ShopID = table.Rows[0]["MemloginId"].ToString(),
    //                    SellName = table.Rows[0]["ShopName"].ToString(),
    //                    FeeType = int.Parse(table.Rows[0]["FeeType"].ToString()),

    //                    SpecificationValue = "",
    //                    Post_fee = 0,
    //                    Ems_fee = 0,
    //                    Express_fee = 0
                        
    //                };
    //                var action = (ShopNum1_Cart_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Cart_Action();
    //                action.AddCart(shopcart);
    //                #region 没用的
                    
    //                #endregion
    //            }
    //        }
    //    }
    }
}
