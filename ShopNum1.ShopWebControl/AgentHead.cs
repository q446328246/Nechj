using System;
using System.Data;
using System.Globalization;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Interface;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;

namespace ShopNum1.ShopWebControl
{
    [ParseChildren(true)]
    public class AgentHead : BaseWebControl
    {
        private HtmlGenericControl htmlGenericControl_0;
        private HtmlGenericControl htmlGenericControl_1;
        private HtmlGenericControl htmlGenericControl_2;
        private HtmlGenericControl htmlGenericControl_3;
        private HtmlGenericControl htmlGenericControl_4;
        private HtmlGenericControl htmlGenericControl_5;
        private HtmlImage htmlImage_0;
        private Image image_0;
        private Label label_0;
        private Label label_1;
        private Literal literal_0;
        private Literal literal_1;
        private string string_0;
        private string string_1 = "AgentHead.ascx";
        private string string_2;

        public AgentHead()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = string_1;
            }
        }

        public static string staticShopId { get; set; }

        protected override void InitializeSkin(Control skin)
        {
            staticShopId = Page.Request.Url.Host;
            label_0 = (Label) skin.FindControl("LabelMemLoginID");
            htmlGenericControl_0 = (HtmlGenericControl) skin.FindControl("islogin");
            htmlGenericControl_1 = (HtmlGenericControl) skin.FindControl("unlogin");
            literal_0 = (Literal) skin.FindControl("AgnetAddress");
            literal_1 = (Literal) skin.FindControl("LiteralCartCount");
            htmlGenericControl_4 = (HtmlGenericControl) skin.FindControl("shopcart1");
            htmlGenericControl_5 = (HtmlGenericControl) skin.FindControl("shopcart2");
            htmlGenericControl_2 = (HtmlGenericControl) skin.FindControl("loginTwo");
            htmlGenericControl_3 = (HtmlGenericControl) skin.FindControl("loginOutTwo");
            label_1 = (Label) skin.FindControl("LabelMemLoginIDTwo");
            htmlImage_0 = (HtmlImage) skin.FindControl("ImageOriginalImge");
            image_0 = (Image) skin.FindControl("ImageShopLogo");
            GetShopLogo();
           
            
            try
            {
                string value = "";
                //if (staticShopId == ShopNum1.Common.ShopNum1.Common.ShopIdToTj88.ShopId_Tj88)
                //{
                  //  string Category = Page.Request["category"].ToString();
                //    if (Category=="1")
                //    {
                //       value = ShopSettings.GetValue("Logo_DaTang"); 
                //    }
                //    if (Category=="2")
                //    {
                //         value = ShopSettings.GetValue("Logo_VIP"); 
                //    }
                //    if (Category == "3")
                //    {
                //        value = ShopSettings.GetValue("Logo_JiFen");
                //    }
                //    if (Category == "8")
                //    {
                //        value = ShopSettings.GetValue("Logo_QDSQ");
                //    }
                //}
                //else
                //{
                    value = ShopSettings.GetValue("Logo");
                //}
               htmlImage_0.Src = Page.ResolveUrl(value);
            }
            catch
            {
            }
            if (Page.Request.Cookies["MemberLoginCookie"] != null)
            {
                HttpCookie cookie = Page.Request.Cookies["MemberLoginCookie"];
                HttpCookie httpCookie = HttpSecureCookie.Decode(cookie);
                if (httpCookie != null)
                {
                    label_0.Text = (label_1.Text = httpCookie.Values["MemLoginID"]);
                    method_0(label_0.Text.Trim());
                }
                htmlGenericControl_0.Visible = true;
                htmlGenericControl_1.Visible = false;
                htmlGenericControl_4.Visible = false;
                htmlGenericControl_5.Visible = true;
                htmlGenericControl_2.Visible = false;
                htmlGenericControl_3.Visible = true;
            }
            else
            {
                htmlGenericControl_0.Visible = false;
                htmlGenericControl_1.Visible = true;
                htmlGenericControl_2.Visible = true;
                htmlGenericControl_3.Visible = false;
                htmlGenericControl_4.Visible = true;
                htmlGenericControl_5.Visible = false;
            }
            if (Page.IsPostBack && Page.Request.Form["secondEVENTTARGET"] != null &&
                Page.Request.Form["secondEVENTTARGET"] != "" && Page.Request.Form["secondEVENTTARGET"] == "cartClick")
            {
                Page.Response.Redirect(GetPageName.RetDomainUrl("ShoppingCart1"));
            }
        }

        public void GetShopLogo()
        {
            try
            {
                string text = string.Empty;
                string path = string.Empty;
                string shopid = (Page.Request.QueryString["ShopID"] == null) ? "0" : Page.Request.QueryString["ShopID"];
                var shop_ShopInfo_Action = (Shop_ShopInfo_Action) LogicFactory.CreateShop_ShopInfo_Action();
                text = shop_ShopInfo_Action.GetMemberLoginidByShopid(shopid);
                if (!(text == ""))
                {
                    var shopNum1_ShopInfoList_Action =
                        (ShopNum1_ShopInfoList_Action) Factory.LogicFactory.CreateShopNum1_ShopInfoList_Action();
                    DataTable memLoginInfo = shop_ShopInfo_Action.GetMemLoginInfo(text);
                    string_2 = shopNum1_ShopInfoList_Action.GetShopIDByMemLoginID(text).Rows[0]["ShopID"].ToString();
                    string_0 = DateTime.Parse(memLoginInfo.Rows[0]["OpenTime"].ToString()).ToString("yyyy-MM-dd");
                    path = string.Concat(new[]
                    {
                        "~/Shop/Shop/",
                        string_0.Replace("-", "/"),
                        "/",
                        ShopSettings.GetValue("PersonShopUrl"),
                        string_2,
                        "/Site_Settings.xml"
                    });
                    var dataSet = new DataSet();
                    dataSet.ReadXml(Page.Server.MapPath(path));
                    DataRow dataRow = dataSet.Tables["Setting"].Rows[0];
                    staticShopId = Page.Request.Url.Host;
                    if (staticShopId == ShopNum1.Common.ShopNum1.Common.ShopIdToTj88.ShopId_Tj88)
                    {
                        string Category = CookieCategoryString;
                        if (Category == "1")
                        {
                            image_0.ImageUrl = ShopNum1.Common.ShopNum1.Common.ShopIdToTj88.Shop_Url_DatTang_Img;
                        }
                        if (Category == "2")
                        {
                            image_0.ImageUrl = ShopNum1.Common.ShopNum1.Common.ShopIdToTj88.Shop_Url_VIP_Img ;
                        }
                        if (Category == "3")
                        {
                            image_0.ImageUrl = ShopNum1.Common.ShopNum1.Common.ShopIdToTj88.Shop_Url_JiFen_Img ;
                        }
                        if (Category == "6")
                        {
                            image_0.ImageUrl = ShopNum1.Common.ShopNum1.Common.ShopIdToTj88.Shop_Url_QDSQ_Img;
                        }
                        if (Category == "5")
                        {
                            image_0.ImageUrl = ShopNum1.Common.ShopNum1.Common.ShopIdToTj88.Shop_Url_QDSQ_Img;
                        }
                        if (Category == "4")
                        {
                            image_0.ImageUrl = ShopNum1.Common.ShopNum1.Common.ShopIdToTj88.Shop_Url_QDSQ_Img;
                        }
                        if (Category == "7")
                        {
                            image_0.ImageUrl = ShopNum1.Common.ShopNum1.Common.ShopIdToTj88.Shop_Url_QDSQ_Img;
                        }
                        if (Category == "8")
                        {
                            image_0.ImageUrl = ShopNum1.Common.ShopNum1.Common.ShopIdToTj88.Shop_Url_QDSQ_Img;
                        }
                    }
                    else
                    {

                        image_0.ImageUrl = dataRow["ShopLogo"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                Page.Response.Write(ex.Message);
            }
        }

        protected void method_0(string string_4)
        {
            if (literal_1 != null)
            {
                IShopNum1_Cart_Action shopNum1_Cart_Action = Factory.LogicFactory.CreateShopNum1_Cart_Action();
                literal_1.Text = shopNum1_Cart_Action.GetMemCartCount(string_4).ToString();
            }
        }

        public static string RenderControl(Control control)
        {
            var stringWriter = new StringWriter(CultureInfo.InvariantCulture);
            var htmlTextWriter = new HtmlTextWriter(stringWriter);
            control.RenderControl(htmlTextWriter);
            htmlTextWriter.Flush();
            htmlTextWriter.Close();
            return stringWriter.ToString();
        }

        public static string SetUrl(object object_0)
        {
            string result;
            if (object_0.ToString() == "LoginExit")
            {
                result = staticShopId;
            }
            else
            {
                if (object_0.ToString() == "")
                {
                    result = "http://" + ShopSettings.siteDomain;
                }
                else
                {
                    result = string.Concat(new[]
                    {
                        "http://",
                        ShopSettings.siteDomain,
                        "/",
                        object_0.ToString(),
                        ShopSettings.IsOverrideUrl ? ShopSettings.overrideUrlName : ".aspx"
                    });
                }
            }
            return result;
        }

        public static string SetAgentUrl()
        {
            return "http://" + staticShopId;
        }
    }
}