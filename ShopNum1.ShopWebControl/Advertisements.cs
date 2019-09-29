using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;

namespace ShopNum1.ShopWebControl
{
    [ParseChildren(true)]
    public class Advertisements : BaseWebControl
    {
        private Image image_0;
        private string skinFilename = "Advertisement.ascx";

        public Advertisements()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public string MemLoginID { get; set; }

        public string OpenTime { get; set; }

        public string PageName { get; set; }

        public string SetPath { get; set; }

        public void BindAd()
        {
            string filePath = Page.Request.FilePath;
            var action = (Shop_Advertisement_Action) LogicFactory.CreateShop_Advertisement_Action();
            action.StrPath = SetPath;
            DataTable table = null;
            if (PageName == "Default.aspx")
            {
                table = action.ShowAD(PageName);
                if (table != null)
                {
                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        var control = (HtmlGenericControl) Page.FindControl(table.Rows[i]["DivID"].ToString());
                        string type = table.Rows[i]["Type"].ToString();
                        string content = table.Rows[i]["Content"].ToString();
                        string href = table.Rows[i]["Href"].ToString();
                        string width = table.Rows[i]["Width"].ToString();
                        string height = table.Rows[i]["Height"].ToString();
                        if (type != "2")
                        {
                            InnerHTML(control, type, content, href, width, height);
                        }
                    }
                }
            }
            else
            {
                table = action.ShowAD(PageName);
                if (table != null)
                {
                    image_0.ImageUrl = table.Rows[0]["Content"].ToString();
                    image_0.ToolTip = table.Rows[0]["pagename"].ToString();
                    image_0.Width = Convert.ToInt32(table.Rows[0]["Width"].ToString());
                    image_0.Height = Convert.ToInt32(table.Rows[0]["Height"].ToString());
                }
            }
        }

        protected override void InitializeSkin(Control skin)
        {
            image_0 = (Image) skin.FindControl("ImgAdvertiment");
            string shopid = (Page.Request.QueryString["ShopID"] == null) ? "0" : Page.Request.QueryString["ShopID"];
            DataTable memSimpleByShopID =
                ((Shop_ShopInfo_Action) LogicFactory.CreateShop_ShopInfo_Action()).GetMemSimpleByShopID(shopid);
            try
            {
                if ((memSimpleByShopID != null) && (memSimpleByShopID.Rows.Count > 0))
                {
                    OpenTime = DateTime.Parse(memSimpleByShopID.Rows[0]["OpenTime"].ToString()).ToString("yyyy-MM-dd");
                    SetPath = "~/Shop/Shop/" + OpenTime.Replace("-", "/") + "/" + ShopSettings.GetValue("PersonShopUrl") +
                              shopid + "/Themes/Skin_Default/Advertisement.xml";
                    BindAd();
                }
            }
            catch
            {
            }
        }

        public void InnerHTML(HtmlGenericControl htmlGenericControl_0, string type, string content, string href,
            string width, string height)
        {
            if (htmlGenericControl_0 != null)
            {
                string str = type;
                if (str != null)
                {
                    if (str != "0")
                    {
                        if (!(str == "1"))
                        {
                            if (str == "2")
                            {
                                htmlGenericControl_0.InnerHtml =
                                    "<object classid='clsid:D27CDB6E-AE6D-11cf-96B8-444553540000' codebase=' http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0' width='" +
                                    width + "' height='" + height + "'><param name='movie' value='" + content +
                                    "' /><param name='quality' value='high' /><embed src='" + content +
                                    "' quality='high' pluginspage=' http://www.macromedia.com/go/getflashplayer' type='application/x-shockwave-flash'></embed></object>";
                            }
                        }
                        else
                        {
                            htmlGenericControl_0.InnerHtml = "<a href='" + href + "' target='_blank'><img src='" +
                                                             content + "' width='" + width + "' height='" + height +
                                                             "' border='0' /></a>";
                        }
                    }
                    else if (href == "")
                    {
                        htmlGenericControl_0.InnerHtml = content;
                    }
                    else
                    {
                        htmlGenericControl_0.InnerHtml = "<a href='" + href + "' target='_blank'>" + content + "</a>";
                    }
                }
            }
        }
    }
}