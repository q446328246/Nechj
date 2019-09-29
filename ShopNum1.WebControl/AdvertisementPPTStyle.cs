using System.Data;
using System.Text;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;

namespace ShopNum1.WebControl
{
    [ParseChildren(true)]
    public class AdvertisementPPTStyle : BaseWebControl
    {
        private string skinFilename = "AdvertisementPPTStyle.ascx";

        public AdvertisementPPTStyle()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public string AdID { get; set; }

        public string AdType { get; set; }

        public void BindAd()
        {
            string filePath = Page.Request.FilePath;
            if (filePath.Substring(filePath.LastIndexOf('/') + 1) == "")
            {
            }
            DataTable table =
                ((ShopNum1_Advertisement_Action) LogicFactory.CreateShopNum1_Advertisement_Action()).ShowADByDivID(
                    AdID, AdType);
            var builder = new StringBuilder();
            var builder2 = new StringBuilder();
            var builder3 = new StringBuilder();
            var control = new HtmlGenericControl();
            if (table != null)
            {
                int num = 0;
                int num2 = 1;
                while (num < table.Rows.Count)
                {
                    control = (HtmlGenericControl) Page.FindControl(table.Rows[num]["DivID"].ToString());
                    string str3 = table.Rows[num]["Content"].ToString();
                    string str4 = table.Rows[num]["Href"].ToString();
                    table.Rows[num]["Width"].ToString();
                    table.Rows[num]["Height"].ToString();
                    string str5 = table.Rows[num]["explain"].ToString();
                    if (num2 == 2)
                    {
                        builder2.Append("<li class=\"cur\"> <a target=\"_blank\" href=\"" +
                                        ((str4 == "") ? "javascript:" : str4) + "\"><img src=\"" + str3 + "\" alt=\"" +
                                        str5 + "\" /></a>");
                        builder.Append("<li class=\"cur\"></li>");
                        builder3.Append("<li class=\"cur\"><a target=\"_blank\" href=\"" +
                                        ((str4 == "") ? "javascript:" : str4) + "\">" + str5 + "</a></li>");
                    }
                    else
                    {
                        builder2.Append("<li> <a target=\"_blank\" href=\"" + ((str4 == "") ? "javascript:" : str4) +
                                        "\"><img src=\"" + str3 + "\" alt=\"" + str5 + "\" /></a>");
                        builder.Append("<li></li>");
                        builder3.Append(
                            string.Concat(new object[]
                            {
                                "<li value=\"", num, "\" ><a target=\"_blank\" href=\"",
                                (str4 == "") ? "javascript:" : str4, "\">", str5, "</a></li>"
                            }));
                    }
                    num2++;
                    num++;
                }
                if ((control != null) && (builder2.Length != 0))
                {
                    var builder4 = new StringBuilder();
                    builder4.Append("<div class=\"slides\" name=\"__DT\">");
                    builder4.Append("<ul class=\"slide-pic\">");
                    builder4.Append(builder2);
                    builder4.Append("</ul>");
                    builder4.Append("<ul class=\"slide-li op\">");
                    builder4.Append(builder);
                    builder4.Append("</ul>");
                    builder4.Append("<ul class=\"slide-li slide-txt\">");
                    builder4.Append(builder3);
                    builder4.Append("</ul>");
                    builder4.Append("</div>");
                    control.InnerHtml = builder4.ToString();
                }
            }
        }

        protected override void InitializeSkin(Control skin)
        {
            BindAd();
        }
    }
}