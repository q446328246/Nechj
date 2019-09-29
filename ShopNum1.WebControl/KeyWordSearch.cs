using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;

namespace ShopNum1.WebControl
{
    [ParseChildren(true)]
    public class KeyWordSearch : BaseWebControl
    {
        private Repeater RepeaterData;
        private string skinFilename = "KeyWordSearch.ascx";

        public KeyWordSearch()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public string ShowCount { get; set; }

        public void BindData()
        {
            RepeaterData.DataSource =
                ((ShopNum1_KeyWords_Action) LogicFactory.CreateShopNum1_KeyWords_Action()).GetKeyWords(ShowCount);
            RepeaterData.DataBind();
        }

        public static string GetSubstr(object title, int length, bool isEllipsis)
        {
            string str = title.ToString();
            if (str.Length > length)
            {
                str = str.Substring(0, length);
            }
            if (isEllipsis)
            {
                str = str + "...";
            }
            return str;
        }

        protected override void InitializeSkin(Control skin)
        {
            RepeaterData = (Repeater) skin.FindControl("RepeaterData");
            if (!Page.IsPostBack)
            {
            }
            BindData();
        }
    }
}