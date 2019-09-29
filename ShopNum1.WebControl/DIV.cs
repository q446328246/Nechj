using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;

namespace ShopNum1.WebControl
{
    [ParseChildren(true)]
    public class DIV : BaseWebControl
    {
        private HtmlGenericControl AdvertisementDIV;
        private string skinFilename = "DIV.ascx";

        public DIV()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public string divID { get; set; }

        public void BindAd()
        {
            DataTable table =
                ((ShopNum1_Advertisement_Action) LogicFactory.CreateShopNum1_Advertisement_Action()).ShowADByDivID(divID);
            if (table != null)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    string type = table.Rows[i]["Type"].ToString();
                    string content = table.Rows[i]["Content"].ToString();
                    string href = table.Rows[i]["Href"].ToString();
                    string width = table.Rows[i]["Width"].ToString();
                    string height = table.Rows[i]["Height"].ToString();
                    InnerHTML(AdvertisementDIV, type, content, href, width, height);
                }
            }
        }

        protected override void InitializeSkin(Control skin)
        {
            AdvertisementDIV = (HtmlGenericControl) skin.FindControl("AdvertisementDIV");
            BindAd();
        }

        public void InnerHTML(HtmlGenericControl htmlGenericControl_1, string type, string content, string href,
            string width, string height)
        {
            if (htmlGenericControl_1 != null)
            {
                string str = type;
                switch (str)
                {
                    case null:
                        return;

                    case "0":
                        if (href == "")
                        {
                            htmlGenericControl_1.InnerHtml = content;
                        }
                        else
                        {
                            htmlGenericControl_1.InnerHtml = "<a href='" + href + "' target='_blank'>" + content +
                                                             "</a>";
                        }
                        return;

                    case "1":
                        htmlGenericControl_1.InnerHtml = "<a href='" + href + "' target='_blank'><img src='" +
                                                         Globals.ImagePath +
                                                         content.Substring(content.LastIndexOf('/') + 1) + "' width='" +
                                                         width + "' height='" + height + "' border='0' /></a>";
                        return;
                }
                if (!(str == "2"))
                {
                    if (str == "3")
                    {
                        htmlGenericControl_1.InnerHtml =
                            "<object classid='clsid:D27CDB6E-AE6D-11cf-96B8-444553540000' codebase=' http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=9,0,28,0' width='" +
                            width + "' height='" + height + "'><param name='movie' value='" + content +
                            "' /><param name='quality' value='high' /><param name='quality' value='high' /><embed src='" +
                            content +
                            "' quality='high' wmode='transparent' pluginspage='http://www.adobe.com/shockwave/download/download.cgi?P1_Prod_Version=ShockwaveFlash' type='application/x-shockwave-flash' width='" +
                            width + "' height='" + height + "'></embed>";
                    }
                }
                else
                {
                    htmlGenericControl_1.InnerHtml = "";
                }
            }
        }
    }
}