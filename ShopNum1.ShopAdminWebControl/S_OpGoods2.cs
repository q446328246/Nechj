using System;
using System.Collections.Generic;
using System.Data;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;
using ShopNum1MultiEntity;

namespace ShopNum1.ShopAdminWebControl
{
    [ParseChildren(true)]
    public class S_OpGoods2 : BaseShopWebControl, IPostBackEventHandler
    {
        private readonly Shop_Product_Action shop_Product_Action_0 =
            ((Shop_Product_Action) LogicFactory.CreateShop_Product_Action());

        private HtmlInputText Panic_endtime;
        private HtmlInputText Panic_starttime;

        private Button butSub;
        private HtmlInputHidden hidBaseProp;
        private HtmlInputHidden hidBaseStock;
        private HtmlInputHidden hidBrand;
        private HtmlInputHidden hidCategoryName;
        private HtmlInputHidden hidIsReal;
        private HtmlInputHidden hidMarketPrice;
        private HtmlInputHidden hidName;
        private HtmlInputHidden hidName3;
        private HtmlInputHidden hidNewSpecs;
        private HtmlInputHidden hidPType;
        private HtmlInputHidden hidProductNum;
        private HtmlInputHidden hidProductSeries;
        private HtmlInputHidden hidRepertoryAlertCount;
        private HtmlInputHidden hidRepertoryCount;
        private HtmlInputHidden hidShopPrice;
        private HtmlInputHidden hidSpec_Check;
        private HtmlInputHidden hidState;
        private HtmlInputHidden hidTipMsg;
        private HtmlInputHidden hidUnitName;
        private HtmlInputHidden hidVd;
        private HtmlInputHidden hidarea;
        private HtmlInputHidden hidfee;
        private HtmlInputHidden hidfee_template;
        private HtmlInputHidden hidhandinput;
        private HtmlInputHidden hidisPanic;
        private HtmlInputHidden hidlist;
        private HtmlInputHidden hidproImage;
        private HtmlInputHidden hidpro_img;
        private HtmlInputHidden hidpublishGoods;
        private HtmlInputHidden hidradio;
        private HtmlInputHidden hidselect;
        private HtmlInputHidden hidsubStock;
        private HtmlInputHidden hidsubfee;
        private HtmlInputHidden hidtxtinput;
        private Label lblFeeName;
        private Repeater repShopType;
        private Repeater repeater_1;

        private string skinFilename = "S_OpGoods2.ascx";
        private string string_1 = string.Empty;
        private string string_2 = string.Empty;
        private string string_3 = string.Empty;
        private HtmlTextArea txtDesc;
        private HtmlTextArea txtDetail;
        private HtmlInputText txtEms_fee;
        private HtmlInputText txtExpress_fee;
        private HtmlInputText txtKeyword;
        private HtmlTextArea txtPanicDetail;
        private HtmlInputText txtPost_fee;
        private HtmlInputText txtSendTime;
        private HtmlTextArea txtWapDetail;

        private HtmlInputHidden hidScore_Pv_a;
        private HtmlInputHidden hidScore_Pv_b;
        private HtmlInputHidden hidScore_dv;
        private HtmlInputHidden hidScore_hv;
        private HtmlInputHidden hidScore_sv;
       
        private HtmlInputHidden hidScore_max_hv;
        private HtmlInputHidden hidScore_cv;
        private HtmlInputHidden hidScore_Pv_a_two;
        private HtmlInputHidden hidShopPrice_two;
        private HtmlInputHidden hidMarketPrice_two;
        private HtmlInputHidden hidShopPrice_free;
        private HtmlInputHidden hidMarketPrice_free;

        private HtmlInputHidden hidShopPrice_five;
        private HtmlInputHidden hidMarketPrice_five;

        private HtmlInputHidden hidShopPrice_six;
        private HtmlInputHidden hidMarketPrice_six;

        private HtmlInputHidden hidShopPrice_seven;
        private HtmlInputHidden hidMarketPrice_seven;

        private HtmlInputHidden hidShopPrice_eight;
        private HtmlInputHidden hidMarketPrice_eight;

         private HtmlInputHidden hidColor;
         private HtmlInputHidden hidSize;

         private HtmlInputHidden hidScore_Pv_a_CTC;
         private HtmlInputHidden hidScore_hv_CTC;
         private HtmlInputHidden hidShopPrice_one_CTC;
         private HtmlInputHidden hidMarketPrice_one_CTC;

         private HtmlInputHidden hidScore_dv_read;

         private HtmlInputHidden hidScore_pv_cv_DT;
         private HtmlInputHidden hidShopPrice_DT;
         private HtmlInputHidden hidMarketPrice_DT;

         private HtmlInputText textWeight;
        
         private HtmlInputHidden hiddenMaxNumber_one;

        public static bool[] cbChecks;

        private string MyID;
        private HtmlInputHidden hiddentxtUnitNumber;
        private HtmlInputHidden hiddenMyPrice;

        public S_OpGoods2()
        {
            cbChecks = new bool[7] { true, false, false, false, false, false, false };
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public void RaisePostBackEvent(string eventArgument)
        {
            Func<string, bool> func = null;
            try
            {
                string str = Page.Request.Form["__EVENTTARGET"];
                if (func == null)
                {
                    func = method_4;
                }
                Func<string, bool> func2 = func;
                func2(str);
            }
            catch (Exception exception)
            {
                Page.Response.Write(exception.Message + "|" + exception.StackTrace);
            }
        }

        protected override void InitializeSkin(Control skin)
        {
            try
            {
                txtPanicDetail = (HtmlTextArea) skin.FindControl("txtPanicDetail");
                repShopType = (Repeater) skin.FindControl("repShopType");
                repShopType.ItemDataBound += repShopType_ItemDataBound;
                string_1 = Common.Common.ReqStr("pid");
                string_2 = Common.Common.ReqStr("ctype");
                string_3 = Common.Common.ReqStr("code");
                hidIsReal = (HtmlInputHidden) skin.FindControl("hidIsReal");
                hidPType = (HtmlInputHidden) skin.FindControl("hidPType");
                hidCategoryName = (HtmlInputHidden) skin.FindControl("hidCategoryName");
                hidName = (HtmlInputHidden) skin.FindControl("hidName");
                hidProductNum = (HtmlInputHidden) skin.FindControl("hidProductNum");
                hidRepertoryCount = (HtmlInputHidden) skin.FindControl("hidRepertoryCount");
                hidShopPrice = (HtmlInputHidden) skin.FindControl("hidShopPrice");
                hidMarketPrice = (HtmlInputHidden) skin.FindControl("hidMarketPrice");
                hidUnitName = (HtmlInputHidden) skin.FindControl("hidUnitName");
                hidBrand = (HtmlInputHidden) skin.FindControl("hidBrand");
                hidState = (HtmlInputHidden) skin.FindControl("hidState");
                hidSpec_Check = (HtmlInputHidden) skin.FindControl("hidSpec_Check");
                hidBaseStock = (HtmlInputHidden) skin.FindControl("hidBaseStock");
                hidProductSeries = (HtmlInputHidden) skin.FindControl("hidProductSeries");
                hidhandinput = (HtmlInputHidden) skin.FindControl("hidhandinput");
                hidtxtinput = (HtmlInputHidden) skin.FindControl("hidtxtinput");
                hidradio = (HtmlInputHidden) skin.FindControl("hidradio");
                hidselect = (HtmlInputHidden) skin.FindControl("hidselect");
                hidlist = (HtmlInputHidden) skin.FindControl("hidlist");
                hidBaseProp = (HtmlInputHidden) skin.FindControl("hidBaseProp");
                hidpro_img = (HtmlInputHidden) skin.FindControl("hidpro_img");
                hidproImage = (HtmlInputHidden) skin.FindControl("hidproImage");
                hidarea = (HtmlInputHidden) skin.FindControl("hidarea");
                hidpublishGoods = (HtmlInputHidden) skin.FindControl("hidpublishGoods");
                hidisPanic = (HtmlInputHidden) skin.FindControl("hidisPanic");
                hidfee = (HtmlInputHidden) skin.FindControl("hidfee");
                hidsubfee = (HtmlInputHidden) skin.FindControl("hidsubfee");
                hidsubStock = (HtmlInputHidden) skin.FindControl("hidsubStock");
                hidTipMsg = (HtmlInputHidden) skin.FindControl("hidTipMsg");
                hidRepertoryAlertCount = (HtmlInputHidden) skin.FindControl("hidRepertoryAlertCount");
                txtSendTime = (HtmlInputText) skin.FindControl("txtSendTime");
                Panic_endtime = (HtmlInputText) skin.FindControl("Panic_endtime");
                Panic_starttime = (HtmlInputText) skin.FindControl("Panic_starttime");
                txtKeyword = (HtmlInputText) skin.FindControl("txtKeyword");
                txtDetail = (HtmlTextArea) skin.FindControl("txtDetail");
                txtDesc = (HtmlTextArea) skin.FindControl("txtDesc");
                txtWapDetail = (HtmlTextArea) skin.FindControl("txtWapDetail");
                txtPost_fee = (HtmlInputText) skin.FindControl("txtPost_fee");
                textWeight = (HtmlInputText)skin.FindControl("textWeight");
                txtExpress_fee = (HtmlInputText) skin.FindControl("txtExpress_fee");
                txtEms_fee = (HtmlInputText) skin.FindControl("txtEms_fee");
                hidfee_template = (HtmlInputHidden) skin.FindControl("hidfee_template");
                hidNewSpecs = (HtmlInputHidden) skin.FindControl("hidNewSpecs");
                hidVd = (HtmlInputHidden) skin.FindControl("hidVd");
                lblFeeName = (Label) skin.FindControl("lblFeeName");
                butSub = (Button) skin.FindControl("butSub");

                hidScore_Pv_a = (HtmlInputHidden)skin.FindControl("hidScore_Pv_a");
                hidScore_Pv_b = (HtmlInputHidden)skin.FindControl("hidScore_Pv_b");
                hidScore_dv = (HtmlInputHidden)skin.FindControl("hidScore_dv");
                hidScore_hv = (HtmlInputHidden)skin.FindControl("hidScore_hv");
                hidScore_sv = (HtmlInputHidden)skin.FindControl("hidScore_sv");
              
                hidScore_max_hv = (HtmlInputHidden)skin.FindControl("hidScore_max_hv");
                hidScore_cv = (HtmlInputHidden)skin.FindControl("hidScore_cv");
                hidScore_Pv_a_two = (HtmlInputHidden)skin.FindControl("hidScore_Pv_a_two");
                hidShopPrice_two = (HtmlInputHidden)skin.FindControl("hidShopPrice_two");
                hidMarketPrice_two = (HtmlInputHidden)skin.FindControl("hidMarketPrice_two");
                hidShopPrice_free = (HtmlInputHidden)skin.FindControl("hidShopPrice_free");
                hidMarketPrice_free = (HtmlInputHidden)skin.FindControl("hidMarketPrice_free");

                hidScore_dv_read = (HtmlInputHidden)skin.FindControl("hidScore_dv_read");

                hidShopPrice_five = (HtmlInputHidden)skin.FindControl("hidShopPrice_five");
                hidMarketPrice_five = (HtmlInputHidden)skin.FindControl("hidMarketPrice_five");
                hidShopPrice_six = (HtmlInputHidden)skin.FindControl("hidShopPrice_six");
                hidMarketPrice_six = (HtmlInputHidden)skin.FindControl("hidMarketPrice_six");
                hidShopPrice_seven = (HtmlInputHidden)skin.FindControl("hidShopPrice_seven");
                hidMarketPrice_seven = (HtmlInputHidden)skin.FindControl("hidMarketPrice_seven");
                hidShopPrice_eight = (HtmlInputHidden)skin.FindControl("hidShopPrice_eight");
                hidMarketPrice_eight = (HtmlInputHidden)skin.FindControl("hidMarketPrice_eight");

                hidScore_Pv_a_CTC = (HtmlInputHidden)skin.FindControl("hidScore_Pv_a_CTC");
                hidScore_hv_CTC = (HtmlInputHidden)skin.FindControl("hidScore_hv_CTC");
                hidShopPrice_one_CTC = (HtmlInputHidden)skin.FindControl("hidShopPrice_one_CTC");
                hidMarketPrice_one_CTC = (HtmlInputHidden)skin.FindControl("hidMarketPrice_one_CTC");

                hidScore_pv_cv_DT = (HtmlInputHidden)skin.FindControl("hidScore_pv_cv_DT");
                hidShopPrice_DT = (HtmlInputHidden)skin.FindControl("hidShopPrice_DT");
                hidMarketPrice_DT = (HtmlInputHidden)skin.FindControl("hidMarketPrice_DT");

                hiddenMaxNumber_one = (HtmlInputHidden)skin.FindControl("hiddenMaxNumber_one");

                hiddentxtUnitNumber = (HtmlInputHidden)skin.FindControl("hiddentxtUnitNumber");
                hidSize = (HtmlInputHidden)skin.FindControl("hidSize");
                hidColor = (HtmlInputHidden)skin.FindControl("hidColor");
                hiddenMyPrice = (HtmlInputHidden)skin.FindControl("hiddenMyPrice");
             //  if (!Page.IsPostBack)
               // {
                    txtSendTime.Value = DateTime.Now.ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss");
                    Panic_starttime.Value = DateTime.Now.ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss");
                    Panic_endtime.Value = DateTime.Now.ToLocalTime().AddDays(7.0).ToString("yyyy-MM-dd HH:mm:ss");
                    var action = (Shop_ProductCategory_Action) LogicFactory.CreateShop_ProductCategory_Action();
                    repShopType.DataSource = action.SearchShopType(0, base.MemLoginID).DefaultView;
                    repShopType.DataBind();
                    if (string_1.Length >= 0x23)
                    {
                        method_3();
                    }
                    else
                    {
                        try
                        {
                            HttpCookie cookie = Page.Request.Cookies["MemberLoginCookie"];
                            string rankguid = HttpSecureCookie.Decode(cookie).Values["ShopRank"];
                            try
                            {
                                rankguid = Common.Common.GetNameById("ShopRank", "ShopNum1_ShopInfo",
                                    " AND  MemLoginID='" + base.MemLoginID + "'  ");
                            }
                            catch (Exception)
                            {
                            }
                            var action2 = (Shop_ShopInfo_Action) LogicFactory.CreateShop_ShopInfo_Action();
                            string str2 = action2.IsAllowToAddProduct(base.MemLoginID, rankguid, "1");
                            string str3 = action2.IsAllowToAddProduct(base.MemLoginID, rankguid, "2");
                            hidTipMsg.Value = str2 + "|" + str3;
                        }
                        catch
                        {
                        }
                    }
              // }
                Page.RegisterRequiresRaiseEvent(this);
            }
            catch
            {
                Page.Response.Redirect("/login.aspx?goback=" + HttpUtility.UrlEncode(Page.Request.Url.ToString()));
            }
        }

        protected void method_0(string string_4)
        {
            string str = hidSpec_Check.Value;
            var action =
                (ShopNum1_SpecProudctDetail_Action) Factory.LogicFactory.CreateShopNum1_SpecProudctDetail_Action();
            var specDetials = new List<ShopNum1_SpecProudctDetail>();
            var item = new ShopNum1_SpecProudctDetail
            {
                ProductGuid = new Guid(string_4),
                TypeId = 0,
                SpecId = 0,
                SpecValueId = 0,
                SpecValueName = "",
                ProductImage = ""
            };
            specDetials.Add(item);
            if (str != "")
            {
                string[] strArray = str.Split(new[] {'|'});
                for (int i = 0; i < strArray.Length; i++)
                {
                    var detail2 = new ShopNum1_SpecProudctDetail
                    {
                        ProductGuid = new Guid(string_4),
                        TypeId = Convert.ToInt32(string_2),
                        SpecId = Convert.ToInt32(strArray[i].Split(new[] {','})[0]),
                        SpecValueId = Convert.ToInt32(strArray[i].Split(new[] {','})[1]),
                        SpecValueName = strArray[i].Split(new[] {','})[2]
                    };
                    if (strArray[i].Split(new[] {','})[3] == "undefined")
                    {
                        detail2.ProductImage = "";
                    }
                    else
                    {
                        detail2.ProductImage = strArray[i].Split(new[] {','})[3];
                    }
                    specDetials.Add(detail2);
                }
            }
            if (string_1.Length < 0x23)
            {
                action.AddListSpecProudctDetail(specDetials);
            }
            else
            {
                action.UpdateListSpecProudctDetail(specDetials, hidVd.Value, hidNewSpecs.Value);
            }
        }

        protected void method_1(string string_4)
        {
            string str = hidBaseStock.Value;
            var action = (ShopNum1_SpecProudct_Action) Factory.LogicFactory.CreateShopNum1_SpecProudct_Action();
            if (str != "")
            {
                ShopNum1_SpecProudct proudct;
                var specProudcts = new List<ShopNum1_SpecProudct>();
                string[] strArray = null;
                string[] strArray2 = null;
                if (str.IndexOf("&") != -1)
                {
                    strArray = str.Split(new[] {'&'});
                    for (int i = 0; i < strArray.Length; i++)
                    {
                        proudct = new ShopNum1_SpecProudct();
                        strArray2 = strArray[i].Split(new[] {'*'});
                        proudct.ProductGuid = string_4;
                        proudct.SpecDetail = strArray2[0];
                        proudct.SpecTotalId = strArray2[1].Split(new[] {','})[0];
                        proudct.GoodsPrice = decimal.Parse(strArray2[1].Split(new[] {','})[1]);
                        proudct.GoodsStock = Convert.ToInt32(strArray2[1].Split(new[] {','})[2]);
                        proudct.GoodsNumber = strArray2[1].Split(new[] {','})[3];
                        proudct.ShopID = base.MemLoginID;
                        proudct.CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        specProudcts.Add(proudct);
                    }
                }
                else
                {
                    proudct = new ShopNum1_SpecProudct();
                    strArray2 = str.Split(new[] {'*'});
                    proudct.ProductGuid = string_4;
                    proudct.SpecDetail = strArray2[0];
                    proudct.SpecTotalId = strArray2[1].Split(new[] {','})[0];
                    proudct.GoodsPrice = Convert.ToDecimal(strArray2[1].Split(new[] {','})[1]);
                    proudct.GoodsStock = Convert.ToInt32(strArray2[1].Split(new[] {','})[2]);
                    proudct.GoodsNumber = strArray2[1].Split(new[] {','})[3];
                    proudct.ShopID = base.MemLoginID;
                    proudct.CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    specProudcts.Add(proudct);
                }
                action.AddListSpecProducts(specProudcts);
            }
            else
            {
                action.DeleteSpecProduct(string_4);
            }
        }

        protected void method_2(string string_4)
        {
            var action =
                (ShopNum1_ShopProRelateProp_Action) Factory.LogicFactory.CreateShopNum1_ShopProRelateProp_Action();
            var shopProRelateProp = new List<ShopNum1_ShopProRelateProp>();
            string str = hidBaseProp.Value;
            if (str != "")
            {
                ShopNum1_ShopProRelateProp prop;
                if (str.IndexOf("|") != -1)
                {
                    string[] strArray = str.Split(new[] {'|'});
                    for (int i = 0; i < strArray.Length; i++)
                    {
                        prop = new ShopNum1_ShopProRelateProp
                        {
                            ProductGuid = new Guid(string_4),
                            CTypeID = Convert.ToInt32(string_2),
                            PCategoryID = Convert.ToInt32(string_3),
                            ShowType = Convert.ToInt32(strArray[i].Split(new[] {','})[0]),
                            PropID = Convert.ToInt32(strArray[i].Split(new[] {','})[1]),
                            PropValueID =
                                Convert.ToInt32((strArray[i].Split(new[] {','})[2] == "")
                                    ? "0"
                                    : strArray[i].Split(new[] {','})[2]),
                            InputValue = strArray[i].Split(new[] {','})[3]
                        };
                        shopProRelateProp.Add(prop);
                    }
                }
                else
                {
                    prop = new ShopNum1_ShopProRelateProp
                    {
                        ProductGuid = new Guid(string_4),
                        CTypeID = Convert.ToInt32(string_2),
                        PCategoryID = Convert.ToInt32(string_3),
                        ShowType = Convert.ToInt32(str.Split(new[] {','})[0]),
                        PropID = Convert.ToInt32(str.Split(new[] {','})[1]),
                        PropValueID =
                            Convert.ToInt32((str.Split(new[] {','})[2] == "") ? "0" : str.Split(new[] {','})[2]),
                        InputValue = str.Split(new[] {','})[3]
                    };
                    shopProRelateProp.Add(prop);
                }
                action.AddListPropValue(shopProRelateProp);
            }
        }

        protected void method_3()
        {
            DataTable productDetail = shop_Product_Action_0.GetProductDetail(string_1);
            if (productDetail.Rows.Count > 0)
            {
                hidRepertoryAlertCount.Value = productDetail.Rows[0]["RepertoryAlertCount"].ToString();
                hidarea.Value = productDetail.Rows[0]["AddressValue"] + "|" +
                                productDetail.Rows[0]["AddressCode"];
                hidProductSeries.Value = productDetail.Rows[0]["ProductSeriesCode"] + "|" +
                                         productDetail.Rows[0]["ProductSeriesName"];
                hidRepertoryCount.Value = productDetail.Rows[0]["RepertoryCount"].ToString();
                hidName.Value = productDetail.Rows[0]["name"].ToString();
              /*  hidShopPrice.Value = productDetail.Rows[0]["shopprice"].ToString();*/
                hidUnitName.Value = productDetail.Rows[0]["UnitName"].ToString();
                hidProductNum.Value = productDetail.Rows[0]["productnum"].ToString();
                txtDetail.Value = productDetail.Rows[0]["Detail"].ToString();
                hidCategoryName.Value = productDetail.Rows[0]["ProductCategoryName"].ToString();
                hidBrand.Value = productDetail.Rows[0]["BrandGuid"] + "," + productDetail.Rows[0]["BrandName"];
                txtKeyword.Value = productDetail.Rows[0]["Keywords"].ToString();
                txtDesc.Value = productDetail.Rows[0]["Description"].ToString();
                hidfee.Value = productDetail.Rows[0]["FeeType"].ToString();
            /*  hidMarketPrice.Value = productDetail.Rows[0]["MarketPrice"].ToString();*/
                txtWapDetail.Value = productDetail.Rows[0]["Wap_desc"].ToString();
                txtPanicDetail.Value = productDetail.Rows[0]["Instruction"].ToString();

                MyID = productDetail.Rows[0]["id"].ToString();
                hidColor.Value = productDetail.Rows[0]["Color"].ToString();
                hidSize.Value = productDetail.Rows[0]["Size"].ToString();
                //数量限制
                hiddenMaxNumber_one.Value = productDetail.Rows[0]["MaxNumber"].ToString();
                hiddentxtUnitNumber.Value = productDetail.Rows[0]["unitCount"].ToString();
              //  hidScore_Pv_a_CTC  
                //hidScore_hv_CTC 
                //hidShopPrice_one_CTC 
                //hidMarketPrice_one_CTC

              /*  hidScore_Pv_a.Value = productDetail.Rows[0]["Score_Pv_a"].ToString();
                hidScore_Pv_b.Value = productDetail.Rows[0]["Score_Pv_b"].ToString();
                hidScore_dv.Value = productDetail.Rows[0]["Score_dv"].ToString();
                hidScore_hv.Value = productDetail.Rows[0]["Score_hv"].ToString();
                hidScore_sv.Value = productDetail.Rows[0]["Score_sv"].ToString();*/
               
             /*   hidScore_max_hv.Value = productDetail.Rows[0]["Score_max_hv"].ToString();
                hidScore_cv.Value = productDetail.Rows[0]["Score_cv"].ToString();
                hidScore_Pv_a_two.Value = productDetail.Rows[0]["Score_Pv_a_two"].ToString();*/
               for (int i = 0; i <  productDetail.Rows.Count; i++)
			{
                
                if (productDetail.Rows[i]["shop_category_id"].ToString() == "1")
                {

                    //大唐专区可得积分 txtScore_Pv_a 
                    hidScore_Pv_a.Value = productDetail.Rows[i]["Score_Pv_a"].ToString();


                    //大唐专区可得红包  txtScore_hv
                    hidScore_hv.Value =(Convert.ToDecimal( productDetail.Rows[i]["Score_max_hv"])*-1).ToString();

                    //大唐专区商品价格  txtShopPrice_one  
                    hidShopPrice.Value = productDetail.Rows[i]["shopprice"].ToString();

                    //大唐专区市场价格  txtMarketPrice_one 
                    hidMarketPrice.Value = productDetail.Rows[i]["MarketPrice"].ToString();
                    hiddenMyPrice.Value = productDetail.Rows[i]["MyPrice"].ToString();
                    if ( hidScore_Pv_a.Value=="0"&& hidScore_hv.Value=="0"&&hidMarketPrice.Value=="0")
                    {
                        cbChecks[0] = false;
                    }
                    else
                    {
                        cbChecks[0] = true;
                    }
                    
                   
                }
                if (productDetail.Rows[i]["shop_category_id"].ToString() == "2")
                {

                    //VIP专区可得积分  txtScore_Pv_a_two
                    hidScore_Pv_a_two.Value = productDetail.Rows[i]["Score_pv_b"].ToString();


                    //VIP专区可用红包   txtScore_max_hv 
                    hidScore_max_hv.Value = (Convert.ToDecimal(productDetail.Rows[i]["Score_max_hv"]) * (-1)).ToString();

                   /* hidScore_max_hv.Value = productDetail.Rows[i]["Score_max_hv"].ToString();*/
                    //VIP专区商品价格  txtShopPrice_two 
                    hidShopPrice_two.Value = Convert.ToDecimal(productDetail.Rows[i]["shopprice"]) .ToString();

                    //VIP专区市场价格  txtMarketPrice_two 
                    hidMarketPrice_two.Value = productDetail.Rows[i]["MarketPrice"].ToString();
                    //VIP专区可用红包 txtScore_dv_reade hidScore_dv_read

                    //hidScore_dv_read.Value = productDetail.Rows[i]["Score_dv"].ToString();
                    hiddenMyPrice.Value = productDetail.Rows[i]["MyPrice"].ToString();
                    if (hidScore_Pv_a_two.Value=="0"&& hidScore_max_hv.Value=="0"&& hidMarketPrice_two.Value=="0")
                    {
                        cbChecks[1] = false;
                        
                    }
                    else
                    {
                        cbChecks[1] = true;
                    }
                    
                }
                if (productDetail.Rows[i]["shop_category_id"].ToString() == "3")
                {

                    //积分专区可用积分  txtScore_cv 
                 //   hidScore_cv.Value = (Convert.ToDecimal(productDetail.Rows[i]["Score_cv"]) * (-1)).ToString();
                   hidScore_cv.Value =(Convert.ToDecimal(productDetail.Rows[i]["Score_cv"])*(-1)).ToString();
                    //积分专区商品价格  txtShopPrice_free 
                  //  hidShopPrice_free.Value = productDetail.Rows[i]["shopprice"].ToString();

                   // 积分专区市场价格  txtMarketPrice_free
                      hidMarketPrice_free.Value = productDetail.Rows[i]["MarketPrice"].ToString();
                      hiddenMyPrice.Value = productDetail.Rows[i]["MyPrice"].ToString();
                    if (hidScore_cv.Value=="0")
                    {
                        cbChecks[2] = false;
                    }
                    else
                    {
                        cbChecks[2] = true;
                    }

                }

                if (productDetail.Rows[i]["shop_category_id"].ToString() == "4")
                {


                    /// 区代专区首次购物价格商品价格  txtShopPrice_five  hidShopPrice_five 
                    hidShopPrice_five.Value = productDetail.Rows[i]["shopprice"].ToString();

                    //区代专区首次购物市场价格  txtMarketPrice_five  hidMarketPrice_five
                    hidMarketPrice_five.Value = productDetail.Rows[i]["MarketPrice"].ToString();
                    hiddenMyPrice.Value = productDetail.Rows[i]["MyPrice"].ToString();
                    
                    if (hidShopPrice_free.Value == "0" && hidMarketPrice_free.Value == "0")
                    {
                        cbChecks[3] = false;
                    }
                    else
                    {
                        cbChecks[3] = true;
                    }

                }
                if (productDetail.Rows[i]["shop_category_id"].ToString() == "5")
                {
                    hiddenMyPrice.Value = productDetail.Rows[i]["MyPrice"].ToString();

                    //区代专区二次购物价格商品价格  txtShopPrice_six  hidShopPrice_six
                    hidShopPrice_six.Value = productDetail.Rows[i]["shopprice"].ToString();

                    //区代专区二次购物市场价格   txtMarketPrice_six   hidMarketPrice_six
                    hidMarketPrice_six.Value = productDetail.Rows[i]["MarketPrice"].ToString();
                    if (hidShopPrice_free.Value == "0" && hidMarketPrice_free.Value == "0")
                    {
                        cbChecks[4] = false;
                    }
                    else
                    {
                        cbChecks[4] = true;
                    }

                }
                if (productDetail.Rows[i]["shop_category_id"].ToString() == "6")
                {
                    hiddenMyPrice.Value = productDetail.Rows[i]["MyPrice"].ToString();

                    //社区店专首次购物价格商品价格  txtShopPrice_seven   hidShopPrice_seven
                    hidShopPrice_seven.Value = productDetail.Rows[i]["shopprice"].ToString();

                    //社区店专首次购物市场价格  txtMarketPrice_seven   hidMarketPrice_seven
                    hidMarketPrice_seven.Value = productDetail.Rows[i]["MarketPrice"].ToString();

                   
                    if (hidShopPrice_free.Value == "0" && hidMarketPrice_free.Value == "0")
                    {
                        cbChecks[5] = false;
                    }
                    else
                    {
                        cbChecks[5] = true;
                    }

                }
                if (productDetail.Rows[i]["shop_category_id"].ToString() == "7")
                {
                    hiddenMyPrice.Value = productDetail.Rows[i]["MyPrice"].ToString();

                    //社区店专二次购物价格商品价格  txtShopPrice_eight    hidShopPrice_eight
                    hidShopPrice_eight.Value = productDetail.Rows[i]["shopprice"].ToString();

                    //社区店专二次购物市场价格  txtMarketPrice_eight  hidMarketPrice_eight
                    hidMarketPrice_eight.Value = productDetail.Rows[i]["MarketPrice"].ToString();
                    if (hidShopPrice_free.Value == "0" && hidMarketPrice_free.Value == "0")
                    {
                        cbChecks[6] = false;
                    }
                    else
                    {
                        cbChecks[6] = true;
                    }

                }
                if (productDetail.Rows[i]["shop_category_id"].ToString() == "9")
                {
                

                   
                    //CTC可得积分    txtScore_Pv_a_CTC       hidScore_Pv_a_CTC
                    //hidScore_Pv_a_CTC.Value = productDetail.Rows[i]["Score_pv_b"].ToString();
                    //CTC可用红包    txtScore_hv_CTC         hidScore_hv_CTC
                    //hidScore_hv_CTC.Value = (Convert.ToDecimal(productDetail.Rows[i]["Score_hv"])).ToString();
                    //CTC商品价格    txtShopPrice_one_CTC    hidShopPrice_one_CTC
                    hidShopPrice_one_CTC.Value = productDetail.Rows[i]["shopprice"].ToString();
                    //CTC市场价格    txtMarketPrice_one_CTC  hidMarketPrice_one_CTC
                    hidMarketPrice_one_CTC.Value = productDetail.Rows[i]["MarketPrice"].ToString();

                    //可得PVC ：txtScore_pv_cv_DT  hidScore_pv_cv_DT
                    //hidScore_pv_cv_DT.Value = productDetail.Rows[i]["Score_pv_cv"].ToString();
                    //商品价格：txtShopPrice_DT    hidShopPrice_DT
                    //hidShopPrice_DT.Value = productDetail.Rows[i]["shopprice"].ToString();
                    //市场价格：txtMarketPrice_DT  hidMarketPrice_DT
                    //hidMarketPrice_DT.Value = productDetail.Rows[i]["MarketPrice"].ToString();
                }
			}


               txtPost_fee.Value = productDetail.Rows[0]["Post_fee"].ToString();
               txtExpress_fee.Value = productDetail.Rows[0]["Express_fee"].ToString();
               txtEms_fee.Value = productDetail.Rows[0]["Ems_fee"].ToString();
               textWeight.Value = productDetail.Rows[0]["GoodsWeight"].ToString();
               hidsubfee.Value = "1";

                /*if (productDetail.Rows[0]["FeeTemplateID"].ToString() == "0")
                {
                    hidfee_template.Value = productDetail.Rows[0]["FeeTemplateID"] + "," +
                                            productDetail.Rows[0]["FeeTemplateName"];
                    lblFeeName.Text = productDetail.Rows[0]["FeeTemplateName"].ToString();
                    hidsubfee.Value = "0";
                }
                else
                {
                    txtPost_fee.Value = productDetail.Rows[0]["Post_fee"].ToString();
                    txtExpress_fee.Value = productDetail.Rows[0]["Express_fee"].ToString();
                    txtEms_fee.Value = productDetail.Rows[0]["Ems_fee"].ToString();
                    hidsubfee.Value = "1";
                }*/

                hidIsReal.Value = productDetail.Rows[0]["isreal"].ToString();
                if (productDetail.Rows[0]["IsShopNew"].ToString() == "1")
                {
                    hidPType.Value = "isnew";
                }
                if (productDetail.Rows[0]["IsShopHot"].ToString() == "1")
                {
                    hidPType.Value = hidPType.Value + "ishot";
                }
                if (productDetail.Rows[0]["IsShopPromotion"].ToString() == "1")
                {
                    hidPType.Value = hidPType.Value + "ispromotion";
                }
                if (productDetail.Rows[0]["IsShopRecommend"].ToString() == "1")
                {
                    hidPType.Value = hidPType.Value + "Isrecommend";
                }
                hidState.Value = productDetail.Rows[0]["ProductState"].ToString();
                hidpro_img.Value = productDetail.Rows[0]["MultiImages"].ToString();
                hidpublishGoods.Value = productDetail.Rows[0]["pulishtype"].ToString();
                Panic_endtime.Value = productDetail.Rows[0]["endtime"].ToString();
                txtSendTime.Value = productDetail.Rows[0]["StartTime"].ToString();
                hidsubStock.Value = productDetail.Rows[0]["setstock"].ToString();
            }
        }


        private bool method_4(string string_4)
        {
            string str = string_4;
            if ((str != null) && (str == "btnOk"))
            {
                OpProduct();
            }
            return true;
        }

        protected bool OpProduct()
        {
            string g = Guid.NewGuid().ToString();
            g = (string_1.Length < 0x23) ? g : string_1;
            var product = new ShopNum1_Shop_Product
            {
                Guid = new Guid(g),
                Name = Operator.FilterString(hidName.Value),
                ProductNum = hidProductNum.Value,
                Score = 0
            };
            try
            {
                product.RepertoryAlertCount = Convert.ToInt32(hidRepertoryAlertCount.Value);
            }
            catch
            {
                product.RepertoryAlertCount = 10;
            }

            /*ShopNum1_Shop_Product_Price priceDT = new ShopNum1_Shop_Product_Price();
            priceDT.pv=0
                pr
                    for()
                    {
                    ShopNum1_Shop_Product_Price priceDT = product.Prices[i];
                    }
            product.Prices.Add(price1);

            product.Prices.Add(price2);

            product.Prices.Add(price3);
            /*ShopNum1_Shop_Product_Price
            product.ShopPrice = decimal.Parse(hidShopPrice.Value);
            product.MarketPrice = decimal.Parse(hidMarketPrice.Value);
            product.Score_sv = decimal.Parse(hidScore_sv.Value);
            product.Score_Pv_a = decimal.Parse(hidScore_Pv_a.Value);
            product.Score_Pv_b = decimal.Parse(hidScore_Pv_b.Value);
            product.Score_hv = decimal.Parse(hidScore_hv.Value);
            product.Score_dv = decimal.Parse(hidScore_dv.Value);
            product.Score_max_hvc = (decimal.Parse(hidScore_max_hv.Value))*(-1);*/

           HttpCookie cookie = Page.Request.Cookies["MemberLoginCookie"];
            HttpCookie cookie2 = HttpSecureCookie.Decode(cookie);
           string MemberLoginID = cookie2.Values["MemLoginID"];
           if (MemberLoginID == TJShopInfo.shopId)
           {
               ShopNum1_Shop_Product_Price priceDT = new ShopNum1_Shop_Product_Price();
               priceDT.Score_Score_Pv_a = decimal.Parse(hidScore_Pv_a.Value);
               priceDT.Score_Score_max_hvc = decimal.Parse(hidScore_hv.Value)*-1;
               priceDT.marketPrice = decimal.Parse(hidMarketPrice.Value);
               priceDT.shopPrice = decimal.Parse(hidShopPrice.Value);
               priceDT.score_cv = 0;
              

               decimal aa = priceDT.Score_Score_Pv_a;
               decimal bb = priceDT.Score_Score_max_hvc;
               decimal cc = priceDT.marketPrice;
               decimal dd = priceDT.shopPrice;
               priceDT.Shop_category_id = 1;
               if (!( bb == 0 && cc == 0 && dd == 0))
               {

                   product.Prices.Add(priceDT);
               }
              
               
               ShopNum1_Shop_Product_Price priceVIP = new ShopNum1_Shop_Product_Price();
               priceVIP.Score_Score_Pv_b = decimal.Parse(hidScore_Pv_a_two.Value);
               priceVIP.Score_Score_max_hvc = decimal.Parse(hidScore_max_hv.Value) * (-1);
               priceVIP.marketPrice = decimal.Parse(hidMarketPrice_two.Value);
               priceVIP.Shop_category_id = 2;
               priceVIP.shopPrice = decimal.Parse(hidShopPrice_two.Value) ;
               priceVIP.Score_Score_hv = 0;
               priceVIP.score_cv = 0;

               decimal a = priceVIP.Score_Score_Pv_b;
               decimal b = priceVIP.Score_Score_max_hvc;
               decimal c = priceVIP.marketPrice;
               decimal d = priceVIP.shopPrice;
               if (!( c == 0 && d == 0))
               {

                   product.Prices.Add(priceVIP);
               }
               //else{
               //    MessageBox.Show("发布失败！VIP专区的价格是红包和积分都必须比价格低");
               //    return false;
               //}
              
               ShopNum1_Shop_Product_Price priceJiFen = new ShopNum1_Shop_Product_Price();
               priceJiFen.score_cv = decimal.Parse(hidScore_cv.Value) * (-1);
               priceJiFen.marketPrice = decimal.Parse(hidMarketPrice_free.Value);
               priceJiFen.shopPrice = decimal.Parse(hidShopPrice_free.Value);
               priceJiFen.Shop_category_id = 3;
               priceJiFen.Score_Score_Pv_a = 0;
               priceJiFen.Score_Score_hv = 0;
               priceJiFen.Score_Score_max_hvc = 0;
               decimal aaa = priceJiFen.shopPrice;

               if (!(aaa == 0))
               {

                   product.Prices.Add(priceJiFen);
               }
              

               //区代1
               ShopNum1_Shop_Product_Price QuDai_1 = new ShopNum1_Shop_Product_Price();
               QuDai_1.score_cv = 0;
               QuDai_1.marketPrice = decimal.Parse(hidMarketPrice_five.Value);
               QuDai_1.shopPrice = decimal.Parse(hidShopPrice_five.Value);
               QuDai_1.Shop_category_id = 4;
               QuDai_1.Score_Score_Pv_a = 0;
               QuDai_1.Score_Score_hv = 0;
               QuDai_1.Score_Score_max_hvc = 0;
              
               decimal bbba = QuDai_1.marketPrice;
               decimal ccca = QuDai_1.shopPrice;

               if (!(bbba == 0 && ccca == 0))
               {

                   product.Prices.Add(QuDai_1);
               }
               
               //区代2
               ShopNum1_Shop_Product_Price QuDai_2 = new ShopNum1_Shop_Product_Price();
               QuDai_2.score_cv = 0;
               QuDai_2.marketPrice = decimal.Parse(hidMarketPrice_six.Value);
               QuDai_2.shopPrice = decimal.Parse(hidShopPrice_six.Value);
               QuDai_2.Shop_category_id = 5;
               QuDai_2.Score_Score_Pv_a = 0;
               QuDai_2.Score_Score_hv = 0;
               QuDai_2.Score_Score_max_hvc = 0;

               decimal bbbb = QuDai_2.marketPrice;
               decimal cccb = QuDai_2.shopPrice;

               if (!(bbbb == 0 && cccb == 0))
               {

                   product.Prices.Add(QuDai_2);
               }
              
               //社区1
               ShopNum1_Shop_Product_Price SheQu_1 = new ShopNum1_Shop_Product_Price();
               SheQu_1.score_cv = 0;
               SheQu_1.marketPrice = decimal.Parse(hidMarketPrice_seven.Value);
               SheQu_1.shopPrice = decimal.Parse(hidShopPrice_seven.Value);
               SheQu_1.Shop_category_id = 6;
               SheQu_1.Score_Score_Pv_a = 0;
               SheQu_1.Score_Score_hv = 0;
               SheQu_1.Score_Score_max_hvc = 0;
              
               decimal bbbbc = SheQu_1.marketPrice;
               decimal cccbc = SheQu_1.shopPrice;

               if (!(bbbbc == 0 && cccbc == 0))
               {

                   product.Prices.Add(SheQu_1);
               }
              
               
               //社区2
               ShopNum1_Shop_Product_Price SheQu_2 = new ShopNum1_Shop_Product_Price();
               SheQu_2.score_cv = 0;
               SheQu_2.marketPrice = decimal.Parse(hidMarketPrice_eight.Value);
               SheQu_2.shopPrice = decimal.Parse(hidShopPrice_eight.Value);
               SheQu_2.Shop_category_id = 7;
               SheQu_2.Score_Score_Pv_a = 0;
               SheQu_2.Score_Score_hv = 0;
               SheQu_2.Score_Score_max_hvc = 0;

               decimal bbbbd = SheQu_2.marketPrice;
               decimal cccbd = SheQu_2.shopPrice;

               if (!(bbbbd == 0 && cccbd == 0))
               {

                   product.Prices.Add(SheQu_2);
               }


               if (hiddentxtUnitNumber.Value == "")
               {
                   product.unitCount = 1;
               }
               else
               {
                   product.unitCount = Convert.ToInt32(hiddentxtUnitNumber.Value);
               }
           }
           else if (MemberLoginID != TJShopInfo.shopId && MemberLoginID != TJShopInfo.shoCVid)
           {


               ShopNum1_Shop_Product_Price priceCTC = new ShopNum1_Shop_Product_Price();

               priceCTC.marketPrice = decimal.Parse(hidMarketPrice_one_CTC.Value);
               priceCTC.Shop_category_id = 9;
               priceCTC.shopPrice = decimal.Parse(hidShopPrice_one_CTC.Value);
               priceCTC.Score_Score_max_hvc = 0;
               priceCTC.score_cv = 0;
               priceCTC.Score_Score_Pv_a = 0;
               priceCTC.Score_Score_hv =0 ;
               decimal a21 = priceCTC.Score_Score_Pv_b;
               decimal b21 = priceCTC.Score_Score_hv;
               decimal c21 = priceCTC.marketPrice;
               decimal d21 = priceCTC.shopPrice;
               if (!(c21 == 0 && d21 == 0))
               {

                   product.Prices.Add(priceCTC);
               }
               //else if (!(c21 == 0 && d21 == 0) && a21 > d21 || a21 < 0  || d21 < 0)
               //{
               //    MessageBox.Show("发布失败！BTC/CTC专区的价格是积分必须比价格低");
               //    return false;
               //}
               product.unitCount = 1;
           }
               
           else if (MemberLoginID == TJShopInfo.shoCVid)
           {
               ShopNum1_Shop_Product_Price priceCV = new ShopNum1_Shop_Product_Price();

               priceCV.marketPrice = decimal.Parse(hidMarketPrice_DT.Value);
               priceCV.Shop_category_id = 9;
               priceCV.shopPrice = decimal.Parse(hidShopPrice_DT.Value);
               priceCV.Score_Score_max_hvc = 0;
               priceCV.score_cv = 0;
               priceCV.scroce_pv_cv = 0;

               decimal a21 = priceCV.scroce_pv_cv;
               decimal c21 = priceCV.marketPrice;
               decimal d21 = priceCV.shopPrice;
               if (!(c21 == 0 && d21 == 0))
               {

                   product.Prices.Add(priceCV);
               }
               
           }
          
        
          
               product.MaxNumber_one = 10000;
           
          
           
            product.MyPrice =Convert.ToDecimal( hiddenMyPrice.Value) ;
            product.RepertoryCount = Convert.ToInt32(hidRepertoryCount.Value);
            product.UnitName = hidUnitName.Value;
            product.Detail = txtDetail.Value;
            product.Instruction = txtPanicDetail.Value;
            product.ProductSeriesCode = hidProductSeries.Value.Split(new[] {'|'})[0];
            product.ProductSeriesName = (hidProductSeries.Value.Split(new[] {'|'})[1]).Replace(" ","").Replace("\r\n","");
            product.ProductCategoryCode = string_3;
            product.ProductCategoryName = hidCategoryName.Value.Trim();
            product.Color = (hidColor.Value.Trim()).Replace("，",",");
            product.Size = (hidSize.Value.Trim()).Replace("，",",");

            if (hidBrand.Value != "")
            {
                product.BrandGuid = new Guid(hidBrand.Value.Split(new[] {','})[0]);
                product.BrandName = hidBrand.Value.Split(new[] {','})[1];
            }
            else
            {
                product.BrandGuid = new Guid("00000000-0000-0000-0000-000000000000");
                product.BrandName = "其它";
            }


            product.OriginalImage = hidproImage.Value;
            product.ThumbImage = hidproImage.Value;
            product.SmallImage = hidproImage.Value;
            product.MultiImages = hidpro_img.Value;
            product.Keywords = Operator.FilterString(txtKeyword.Value);
            product.Description = Operator.FilterString(txtDesc.Value);
            product.AddressCode = hidarea.Value.Split(new[] {'|'})[1];
            product.AddressValue = hidarea.Value.Split(new[] {'|'})[0];
            product.FeeType = Convert.ToInt32(hidfee.Value);
            product.MemLoginID = base.MemLoginID;
            product.ShopName = Common.Common.GetNameById("shopname", "shopnum1_shopinfo",
                " and memloginId='" + base.MemLoginID + "'");

            product.FeeTemplateID = 1;
            product.Post_fee = decimal.Parse(txtPost_fee.Value);
            product.Express_fee = decimal.Parse(txtExpress_fee.Value);
            product.Ems_fee = decimal.Parse(txtEms_fee.Value);
            product.textWeight = decimal.Parse(textWeight.Value);

            /*
            if (product.FeeType == 0)
            {
                if (hidsubfee.Value == "0")
                {
                    product.FeeTemplateID = Convert.ToInt32(hidfee_template.Value.Split(new[] {','})[0]);
                    product.FeeTemplateName = hidfee_template.Value.Split(new[] {','})[1];
                }
                else
                {
                    product.FeeTemplateID = 1;
                    product.Post_fee = decimal.Parse(txtPost_fee.Value);
                    product.Express_fee = decimal.Parse(txtExpress_fee.Value);
                    product.Ems_fee = decimal.Parse(txtEms_fee.Value);
                }
            }*/
            product.MinusFee = decimal.Parse("0.00");
            product.IsReal = Convert.ToInt32(hidIsReal.Value);
            if (hidPType.Value.IndexOf("isnew") != -1)
            {
                product.IsShopNew = 1;
            }
            if (hidPType.Value.IndexOf("ishot") != -1)
            {
                product.IsShopHot = 1;
            }
            if (hidPType.Value.IndexOf("ispromotion") != -1)
            {
                product.IsShopPromotion = 1;
            }
            if (hidPType.Value.IndexOf("Isrecommend") != -1)
            {
                product.IsShopRecommend = 1;
            }
            product.EndTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            if (hidpublishGoods.Value == "0")
            {
                product.DeSaleTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                product.StartTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                product.SaleTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                product.IsSell = 1;
            }
            else if (hidpublishGoods.Value == "1")
            {
                if (txtSendTime.Value != "")
                {
                    product.StartTime = Convert.ToDateTime(txtSendTime.Value);
                    product.SaleTime = Convert.ToDateTime(txtSendTime.Value);
                }
                else
                {
                    product.StartTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    product.SaleTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                }
                product.IsSell = 1;
            }
            else
            {
                product.IsSell = 0;
            }
            if (Panic_starttime.Value != "")
            {
                product.StartTime = Convert.ToDateTime(Panic_starttime.Value);
            }
            if (Panic_endtime.Value != "")
            {
                product.EndTime = Convert.ToDateTime(Panic_endtime.Value);
            }
            string input = txtWapDetail.Value;
            string pattern = "<(?!img|br|a|p|/p).*?>";
            input = Regex.Replace(input, pattern, string.Empty, RegexOptions.IgnoreCase);
            product.Wap_desc = input;
            product.CreateUser = base.MemLoginID;
            product.GoodsType = Convert.ToInt32(string_2);
            product.Ctype = Convert.ToInt32(string_2);
            product.ProductState = Convert.ToInt32(hidState.Value);
            product.SetStock = Convert.ToInt32(hidsubStock.Value);
            product.PulishType = Convert.ToInt32(hidpublishGoods.Value);
            if (product.PulishType == 2)
            {
                product.IsSell = 0;
            }
            product.ModifyTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            if (ShopSettings.GetValue("AddProductIsAudit") == "0")
            {
                product.IsAudit = 1;
            }
            else
            {
                product.IsAudit = 0;
            }
            if (product.ProductState == 1)
            {
                if (ShopSettings.GetValue("AddPanicBuyProductIsAudit") == "0")
                {
                    product.IsAudit = 1;
                }
                else
                {
                    product.IsAudit = 0;
                }
            }
            if (string_1.Length < 0x23)
            {
              
                shop_Product_Action_0.AddShopProduct(product);
                method_0(g);
                method_1(g);
                method_2(g);
                 
          
               Page.Response.Redirect(
                   string.Concat(new object[]
                    {
                        "/shop/ShopAdmin/S_SellGoods_Three.aspx?op=add&step=two&shopid=", base.MemLoginID,
                        "&pstate=",
                        product.ProductState, "&ctype=", Common.Common.ReqStr("ctype"), "&pid=", g, "&code=",
                        Common.Common.ReqStr("code"), "&cid=", Common.Common.ReqStr("cid")
                    }));
           
          
            }
            else
            {
             /*   shop_Product_Action_0.UpdateShopProduct(product);*/
                DataTable productDetail = shop_Product_Action_0.GetProductDetail(string_1);
                MyID = productDetail.Rows[0]["id"].ToString();
                product.MyID =Convert.ToInt32(MyID);
                Guid guid = new Guid(string_1);
                product.Guid = guid;
                product.SaleNumber = Convert.ToInt32(productDetail.Rows[0]["SaleNumber"]);
                
                shop_Product_Action_0.DelectShopNum1_Shop_Product(MyID);
                shop_Product_Action_0.DelectShopNum1_Shop_ProductPrice(MyID);
                shop_Product_Action_0.AddShopProduct(product);
                method_0(g);
                method_1(g);
                method_2(g);
               
                    Page.Response.Redirect(
                        string.Concat(new object[]
                    {
                        "/shop/ShopAdmin/S_SellGoods_Three.aspx?op=edit&step=two&shopid=", base.MemLoginID,
                        "&pstate=",
                        product.ProductState, "&ctype=", Common.Common.ReqStr("ctype"), "&pid=", g, "&code=",
                        Common.Common.ReqStr("code"), "&cid=", Common.Common.ReqStr("cid")
                    }));
                
               
            }
            return true;
        }

        protected void repShopType_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
            {
                repeater_1 = (Repeater) e.Item.FindControl("repSubShopType");
                hidName3 = (HtmlInputHidden) e.Item.FindControl("hidShopFatherId");
                repeater_1.DataSource =
                    ((Shop_ProductCategory_Action) LogicFactory.CreateShop_ProductCategory_Action()).Search(
                        Convert.ToInt32(hidName3.Value), base.MemLoginID);
                repeater_1.DataBind();
            }
        }
    }
}