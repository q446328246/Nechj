﻿using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.MultiBaseWebControl;

namespace ShopNum1.WebControl
{
    [ParseChildren(true)]
    public class ProductSearchNofind : BaseWebControl
    {
        private Label LabelProtectSearch;
        private string skinFilename = "ProductSearchNofind.ascx";

        public ProductSearchNofind()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public string ProtectName { get; set; }

        protected override void InitializeSkin(Control skin)
        {
            LabelProtectSearch = (Label) skin.FindControl("LabelProtectSearch");
            ProtectName = (Common.Common.ReqStr("search") == "") ? "" : Common.Common.ReqStr("search");
            if (ProtectName == "-1")
            {
                LabelProtectSearch.Text = "";
            }
            else
            {
                LabelProtectSearch.Text = "与“" + ProtectName.Trim() + "”";
            }
        }
    }
}