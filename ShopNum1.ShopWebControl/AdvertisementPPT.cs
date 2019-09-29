using System;
using System.Data;
using System.Text;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;

namespace ShopNum1.ShopWebControl
{
    [ParseChildren(true)]
    public class AdvertisementPPT : BaseWebControl
    {
        private string skinFilename = "AdvertisementPPT.ascx";

        public AdvertisementPPT()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public string OpenTime { get; set; }

        public string SetPath { get; set; }

        public string ShopID { get; set; }

        public void BindAd()
        {
            string filePath = Page.Request.FilePath;
            string pagename = filePath.Substring(filePath.LastIndexOf('/') + 1);
            if (pagename == "")
            {
                pagename = "Default.aspx";
            }
            if (pagename =="default_two.aspx")
            {
                pagename = "Default.aspx";
            }
            if (ShopID != "0")
            {
                var action = (Shop_Advertisement_Action) LogicFactory.CreateShop_Advertisement_Action();
                action.StrPath = SetPath;
                DataTable table = action.SearchPPT(pagename);
                var builder = new StringBuilder();
                var builder2 = new StringBuilder();
                var builder3 = new StringBuilder();
                var control = new HtmlGenericControl();
                int num = 0;
                int num2 = 1;
                while (num < table.Rows.Count)
                {
                    if (table.Rows[num]["Type"].ToString() == "2")
                    {
                        control = (HtmlGenericControl) Page.FindControl(table.Rows[num]["DivID"].ToString());
                        string str4 = table.Rows[num]["Content"].ToString();
                        string str5 = table.Rows[num]["Href"].ToString();
                        table.Rows[num]["Width"].ToString();
                        table.Rows[num]["Height"].ToString();
                        string str6 = table.Rows[num]["explain"].ToString();
                        if (num2 == 1)
                        {
                            builder2.Append(
                                string.Concat(new object[]
                                {
                                    "<li value=\"", num,
                                    "\"  class=\"cur\"  style=\"display:block;\"> <a target=\"_blank\" href=\"",
                                    (str5 == "") ? "javascript:" : str5, "\"><img src=\"", str4, "\" alt=\"", str6,
                                    "\" /></a>"
                                }));
                            builder.Append("<li class=\"cur\"  style=\"display:block;\"></li>");
                            builder3.Append(
                                string.Concat(new object[]
                                {
                                    "<li value=\"", num, "\" class=\"cur\" ><a target=\"_blank\" href=\"",
                                    (str5 == "") ? "javascript:" : str5, "\">", str6, "</a></li>"
                                }));
                        }
                        else
                        {
                            builder2.Append(
                                string.Concat(new object[]
                                {
                                    "<li value=\"", num, "\" > <a target=\"_blank\" href=\"",
                                    (str5 == "") ? "javascript:" : str5, "\"><img src=\"", str4, "\" alt=\"", str6,
                                    "\" /></a>"
                                }));
                            builder.Append("<li></li>");
                            builder3.Append(
                                string.Concat(new object[]
                                {
                                    "<li value=\"", num, "\" ><a target=\"_blank\" href=\"",
                                    (str5 == "") ? "javascript:" : str5, "\">", str6, "</a></li>"
                                }));
                        }
                        num2++;
                    }
                    num++;
                }
                if ((control != null) && (builder2.Length != 0))
                {
                    var builder4 = new StringBuilder();
                    builder4.Append("<div class=\"slides\" name=\"__DT\">");
                    builder4.Append("<a class=\"np1\"></a><ul class=\"slide-pic\">");
                    builder4.Append(builder2);
                    builder4.Append("</ul><a class=\"np2\"></a>");
                    builder4.Append("<ul class=\"slide-li op\">");
                    builder4.Append(builder);
                    builder4.Append("</ul>");
                    builder4.Append("<div class=\"suibian\">");
                    builder4.Append("<ul class=\"slide-li slide-txt\">");
                    builder4.Append(builder3);
                    builder4.Append("</ul>");
                    builder4.Append("</div>");
                    builder4.Append("</div>");
                    control.InnerHtml = builder4.ToString();
                }
            }
        }

        protected override void InitializeSkin(Control skin)
        {
            ShopID = (Page.Request.QueryString["ShopID"] == null) ? "0" : Page.Request.QueryString["ShopID"];
           
            if (ShopID != "0")
            {
                if (ShopID==ShopNum1.Common.ShopNum1.Common.ShopIdToTj88.ShopId)
                {
                    string Category = CookieCategoryString;
                    if (Category == "1")
                    {
                        DataTable memSimpleByShopID =
                   ((Shop_ShopInfo_Action)LogicFactory.CreateShop_ShopInfo_Action()).GetMemSimpleByShopID(
                       ShopSettings.GetValue("PersonShopUrl") + ShopID);
                        if ((memSimpleByShopID != null) && (memSimpleByShopID.Rows.Count > 0))
                        {
                            OpenTime = DateTime.Parse(memSimpleByShopID.Rows[0]["OpenTime"].ToString()).ToString("yyyy-MM-dd");
                            SetPath = "~/Shop/Shop/" + OpenTime.Replace("-", "/") + "/" + ShopSettings.GetValue("PersonShopUrl") +
                                      ShopID + "/Themes/Skin_Default/AdvertisemenDaTang.xml";
                        }
                    }
                    if (Category == "2")
                    {
                        DataTable memSimpleByShopID =
                   ((Shop_ShopInfo_Action)LogicFactory.CreateShop_ShopInfo_Action()).GetMemSimpleByShopID(
                       ShopSettings.GetValue("PersonShopUrl") + ShopID);
                        if ((memSimpleByShopID != null) && (memSimpleByShopID.Rows.Count > 0))
                        {
                            OpenTime = DateTime.Parse(memSimpleByShopID.Rows[0]["OpenTime"].ToString()).ToString("yyyy-MM-dd");
                            SetPath = "~/Shop/Shop/" + OpenTime.Replace("-", "/") + "/" + ShopSettings.GetValue("PersonShopUrl") +
                                      ShopID + "/Themes/Skin_Default/AdvertisemenVIP.xml";
                        }
                    }
                    if (Category == "3")
                    {
                        DataTable memSimpleByShopID =
                   ((Shop_ShopInfo_Action)LogicFactory.CreateShop_ShopInfo_Action()).GetMemSimpleByShopID(
                       ShopSettings.GetValue("PersonShopUrl") + ShopID);
                        if ((memSimpleByShopID != null) && (memSimpleByShopID.Rows.Count > 0))
                        {
                            OpenTime = DateTime.Parse(memSimpleByShopID.Rows[0]["OpenTime"].ToString()).ToString("yyyy-MM-dd");
                            SetPath = "~/Shop/Shop/" + OpenTime.Replace("-", "/") + "/" + ShopSettings.GetValue("PersonShopUrl") +
                                      ShopID + "/Themes/Skin_Default/AdvertisemenJiFen.xml";
                        }
                    }
                    if (Category == "8")
                    {
                        DataTable memSimpleByShopID =
                    ((Shop_ShopInfo_Action)LogicFactory.CreateShop_ShopInfo_Action()).GetMemSimpleByShopID(
                        ShopSettings.GetValue("PersonShopUrl") + ShopID);
                        if ((memSimpleByShopID != null) && (memSimpleByShopID.Rows.Count > 0))
                        {
                            OpenTime = DateTime.Parse(memSimpleByShopID.Rows[0]["OpenTime"].ToString()).ToString("yyyy-MM-dd");
                            SetPath = "~/Shop/Shop/" + OpenTime.Replace("-", "/") + "/" + ShopSettings.GetValue("PersonShopUrl") +
                                      ShopID + "/Themes/Skin_Default/AdvertisemenQDSQ.xml";
                        }
                    }
                }
                else
                {
                    DataTable memSimpleByShopID =
                    ((Shop_ShopInfo_Action)LogicFactory.CreateShop_ShopInfo_Action()).GetMemSimpleByShopID(
                        ShopSettings.GetValue("PersonShopUrl") + ShopID);
                    if ((memSimpleByShopID != null) && (memSimpleByShopID.Rows.Count > 0))
                    {
                        OpenTime = DateTime.Parse(memSimpleByShopID.Rows[0]["OpenTime"].ToString()).ToString("yyyy-MM-dd");
                        SetPath = "~/Shop/Shop/" + OpenTime.Replace("-", "/") + "/" + ShopSettings.GetValue("PersonShopUrl") +
                                  ShopID + "/Themes/Skin_Default/Advertisement.xml";
                    }
                }
                
                BindAd();
            }
        }
    }
}