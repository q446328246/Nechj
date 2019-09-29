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
    public class Advertisement : BaseWebControl
    {
        private string skinFilename = "Advertisement.ascx";

        public Advertisement()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public string FileName { get; set; }

        public void BindAd()
        {
            string filePath = Page.Request.FilePath;
            string filename = filePath.Substring(filePath.LastIndexOf('/') + 1);
            if (filename == "")
            {
                filename = "Default.aspx";
            }
            DataTable table =
                ((ShopNum1_Advertisement_Action) LogicFactory.CreateShopNum1_Advertisement_Action()).ShowAD(filename);
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

        protected override void InitializeSkin(Control skin)
        {
            BindAd();
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
                                    width + "' height='" + height + "'><param name='movie' value='" + Globals.ImagePath +
                                    content.Substring(content.LastIndexOf('/') + 1) +
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