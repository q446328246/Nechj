using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.MultiBaseWebControl;

namespace ShopNum1.WebControl
{
    [ParseChildren(true)]
    public class nofindsearch : BaseWebControl
    {
        private Label LabelProtectSearch;
        private string skinFilename = "nofindsearch.ascx";

        public nofindsearch()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        protected override void InitializeSkin(Control skin)
        {
            LabelProtectSearch = (Label) skin.FindControl("LabelProtectSearch");
            string url = "";
            if (Common.Common.ReqStr("pv") != "")
            {
                string str2 = HttpUtility.HtmlDecode(Page.Request.QueryString["search"]).Replace("%2f", "/");
                LabelProtectSearch.Text = str2;
                string str3 = Common.Common.ReqStr("pv");
                switch (str3)
                {
                    case null:
                        break;

                    case "1":
                        if (Common.Common.ReturnExist("count(*)", "ShopNum1_Shop_Product",
                            " and name like '%" + str2 +
                            "%' and isaudit=1 and issell=1 and issaled=1"))
                        {
                            url = "/Search_productlist.aspx?search=" + Common.Common.ReqStr("search");
                        }
                        break;

                    case "2":
                        if (Common.Common.ReturnExist("count(*)", "ShopNum1_ShopInfo",
                            " and shopname like '%" + str2 + "%' and isaudit=1"))
                        {
                            url = "/ShopListSearch.aspx?search=" + Common.Common.ReqStr("search");
                        }
                        break;

                    default:
                        if (!(str3 == "3"))
                        {
                            if ((str3 == "4") &&
                                Common.Common.ReturnExist("count(*)", "ShopNum1_SupplyDemand",
                                    " and title like '%" + str2 + "%' and IsAudit=3 "))
                            {
                                url = "/SupplyDemandListSearch.aspx?search=" + Common.Common.ReqStr("search");
                            }
                        }
                        else if (Common.Common.ReturnExist("count(*)", "ShopNum1_Article",
                            " and title like '%" + str2 + "%' and isaudit=1"))
                        {
                            url = "/ArticleListSearch.aspx?search=" + Common.Common.ReqStr("search");
                        }
                        break;
                }
                if (url != "")
                {
                    Page.Response.Redirect(url);
                }
            }
        }
    }
}