using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;

namespace ShopNum1.ShopAdminWebControl
{
    [ParseChildren(true)]
    public class S_ShopRankDetailed : BaseMemberWebControl
    {
        private Button ButtonBackList;
        private Repeater RepeaterShow;
        private Repeater repeater_0;
        private string skinFilename = "S_ShopRankDetailed.ascx";

        public S_ShopRankDetailed()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public void BindData(string guid)
        {
            DataTable table = ((Shop_Rank_Action) LogicFactory.CreateShop_Rank_Action()).Search("'" + guid + "'", 0);
            if ((table != null) && (table.Rows.Count > 0))
            {
                RepeaterShow.DataSource = table.DefaultView;
                RepeaterShow.DataBind();
            }
        }

        protected void ButtonBackList_Click(object sender, EventArgs e)
        {
            if ((Page.Request.QueryString["type"] != null) && (Page.Request.QueryString["type"] == "open"))
            {
                Page.Response.Redirect("S_ShopOpenStep1.aspx");
            }
            else
            {
                Page.Response.Redirect("S_ShowShopRank.aspx");
            }
        }

        protected override void InitializeSkin(Control skin)
        {
            RepeaterShow = (Repeater) skin.FindControl("RepeaterShow");
            RepeaterShow.ItemDataBound += RepeaterShow_ItemDataBound;
            ButtonBackList = (Button) skin.FindControl("ButtonBackList");
            ButtonBackList.Click += ButtonBackList_Click;
            if (Page.Request.QueryString["guid"] != null)
            {
                BindData(Page.Request.QueryString["guid"]);
            }
        }

        protected void RepeaterShow_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
            {
                var field = e.Item.FindControl("HiddenFieldShopTemplate") as HiddenField;
                repeater_0 = (Repeater) e.Item.FindControl("RepeaterData");
                DataTable templateByID =
                    ((ShopNum1_ShopTemplate_Action) Factory.LogicFactory.CreateShopNum1_ShopTemplate_Action())
                        .GetTemplateByID(field.Value);
                repeater_0.DataSource = templateByID;
                repeater_0.DataBind();
            }
        }
    }
}