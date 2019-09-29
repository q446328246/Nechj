using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;

namespace ShopNum1.WebControl
{
    [ParseChildren(true)]
    public class KeyWords : BaseWebControl
    {
        private Repeater RepeaterKeyWords;
        private string skinFilename = "KeyWords.ascx";

        public KeyWords()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        protected override void InitializeSkin(Control skin)
        {
            RepeaterKeyWords = (Repeater) skin.FindControl("RepeaterKeyWords");
            if (!Page.IsPostBack)
            {
            }
            BindData();
        }

        protected void BindData()
        {
            string str = ShopSettings.GetValue("KeywordsCount");
            DataTable table =
                ((ShopNum1_KeyWords_Action) LogicFactory.CreateShopNum1_KeyWords_Action()).SearchName(
                    Convert.ToInt32(str), 0);
            RepeaterKeyWords.DataSource = table.DefaultView;
            RepeaterKeyWords.DataBind();
        }
    }
}