using System.Data;
using System.Web.UI;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;

namespace ShopNum1.ShopWebControl
{
    [ParseChildren(true)]
    public class ShopProductDetailMeto : BaseWebControl
    {
        private string skinFilename = "ShopProductDetailMeto.ascx";

        public ShopProductDetailMeto()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        protected override void InitializeSkin(Control skin)
        {
        }

        protected override void Render(HtmlTextWriter writer)
        {
            string guid = (Page.Request.QueryString["guid"] == null) ? "0" : Page.Request.QueryString["guid"];
            string str = string.Empty;
            if (guid != "0")
            {
                DataTable shopProductDetailMeto =
                    ((Shop_Product_Action) LogicFactory.CreateShop_Product_Action()).GetShopProductDetailMeto(guid);
                if ((shopProductDetailMeto == null) || (shopProductDetailMeto.Rows.Count == 0))
                {
                    str = (("\n<title>" + string.Empty + "</title>\r\n") +
                           "<meta name=keywords content=\"" + string.Empty + "\">\r\n") +
                          "<meta name=\"description\" content=\"" + string.Empty + "\">\r\n";
                }
                else
                {
                    str = "\n<title>" + shopProductDetailMeto.Rows[0]["Title"] + string.Empty +
                          "</title>\r\n";
                    if (shopProductDetailMeto.Rows[0]["Keywords"].ToString() == string.Empty)
                    {
                        str = str + "<meta name=keywords content=\"" + shopProductDetailMeto.Rows[0]["Title"] +
                              string.Empty + "\">\r\n";
                    }
                    else
                    {
                        str = str + "<meta name=keywords content=\"" + shopProductDetailMeto.Rows[0]["Keywords"] +
                              string.Empty + "\">\r\n";
                    }
                    if (shopProductDetailMeto.Rows[0]["Description"].ToString() == string.Empty)
                    {
                        str = str + "<meta name=\"description\" content=\"" + shopProductDetailMeto.Rows[0]["Title"] +
                              string.Empty + "\">\r\n";
                    }
                    else
                    {
                        str = str + "<meta name=\"description\" content=\"" +
                              shopProductDetailMeto.Rows[0]["Description"] + string.Empty + "\">\r\n";
                    }
                }
            }
            writer.Write(str);
        }
    }
}