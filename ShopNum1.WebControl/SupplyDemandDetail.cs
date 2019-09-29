using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;

namespace ShopNum1.WebControl
{
    [ParseChildren(true)]
    public class SupplyDemandDetail : BaseWebControl
    {
        private Repeater RepeaterData;
        private Repeater RepeaterDataUpDown;
        private string skinFilename = "SupplyDemandDetail.ascx";
        private string string_1 = "上一篇：";
        private string string_2 = "下一篇：";

        public SupplyDemandDetail()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public string Guid { get; set; }

        public string NextSupplyDemandName
        {
            get { return string_2; }
            set { string_2 = value; }
        }

        public string OnSupplyDemandName
        {
            get { return string_1; }
            set { string_1 = value; }
        }

        public void Bind()
        {
            var action = (ShopNum1_SupplyDemandCheck_Action) LogicFactory.CreateShopNum1_SupplyDemandCheck_Action();
            DataTable supplyDemandDetail = action.GetSupplyDemandDetail(Guid);
            if (supplyDemandDetail.Rows.Count > 0)
            {
                RepeaterData.DataSource = supplyDemandDetail.DefaultView;
                RepeaterData.DataBind();
            }
            DataTable table2 = action.GetSupplyDemandDetailOnAndNext(Guid, OnSupplyDemandName, NextSupplyDemandName);
            if (table2.Rows.Count > 0)
            {
                RepeaterDataUpDown.DataSource = table2.DefaultView;
                RepeaterDataUpDown.DataBind();
            }
        }

        protected override void InitializeSkin(Control skin)
        {
            RepeaterData = (Repeater) skin.FindControl("RepeaterData");
            RepeaterDataUpDown = (Repeater) skin.FindControl("RepeaterDataUpDown");
            if (!Page.IsPostBack)
            {
            }
            Guid = (Page.Request.QueryString["guid"] == null) ? "0" : Page.Request.QueryString["guid"];
            Bind();
            string str = Common.Common.GetNameById("IsAudit", "ShopNum1_SupplyDemand",
                "  AND  ID='" + Page.Request.QueryString["guid"] + "'   ");
            string str2 = Common.Common.GetNameById("MemberID", "ShopNum1_SupplyDemand",
                "  AND  ID='" + Page.Request.QueryString["guid"] + "'   ");
            string str3 = string.Empty;
            if (Page.Request.Cookies["MemberLoginCookie"] != null)
            {
                HttpCookie cookie = Page.Request.Cookies["MemberLoginCookie"];
                str3 = HttpSecureCookie.Decode(cookie).Values["MemLoginID"];
            }
            if ((str != "3") && (str2 != str3))
            {
                Page.Response.Redirect("http://" + ShopSettings.siteDomain);
            }
        }
    }
}