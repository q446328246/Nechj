using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;

namespace ShopNum1.ShopWebControl
{
    [ParseChildren(true)]
    public class NewsDetail : BaseWebControl
    {
        private HiddenField HiddenFieldGuid;
        private Repeater RepeaterData;
        private string skinFilename = "NewsDetail.ascx";

        public NewsDetail()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public string MemLoginID { get; set; }

        public int ShowCount { get; set; }

        protected override void InitializeSkin(Control skin)
        {
            string shopid = (Page.Request.QueryString["ShopID"] == null) ? "0" : Page.Request.QueryString["ShopID"];
            var action = (Shop_ShopInfo_Action) LogicFactory.CreateShop_ShopInfo_Action();
            MemLoginID = action.GetMemberLoginidByShopid(shopid);
            HiddenFieldGuid = (HiddenField) skin.FindControl("HiddenFieldGuid");
            HiddenFieldGuid.Value = (Page.Request.QueryString["guid"] == null) ? "-1" : Page.Request.QueryString["guid"];
            RepeaterData = (Repeater) skin.FindControl("RepeaterData");
            if (!Page.IsPostBack)
            {
            }
            method_1();
            BindData();
        }

        public static string IsShow(object object_0)
        {
            switch (object_0.ToString())
            {
                case "0":
                    return "否";

                case "1":
                    return "是";
            }
            return "";
        }

        protected void BindData()
        {
            try
            {
                ((Shop_News_Action) LogicFactory.CreateShop_News_Action()).UpdateClickCountByGuid(
                    HiddenFieldGuid.Value.Replace("'", ""));
            }
            catch
            {
            }
        }

        protected void method_1()
        {
            RepeaterData.DataSource =
                ((Shop_News_Action) LogicFactory.CreateShop_News_Action()).GetNewsByGuidAndMemLoginID(
                    HiddenFieldGuid.Value, MemLoginID);
            RepeaterData.DataBind();
        }
    }
}