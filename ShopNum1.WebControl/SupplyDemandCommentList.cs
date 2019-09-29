using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;

namespace ShopNum1.WebControl
{
    [ParseChildren(true)]
    public class SupplyDemandCommentList : BaseWebControl
    {
        private readonly string string_0 = GetPageName.RetDomainUrl("SupplyDemandDetail");
        private Button ButtonSure;

        private Label LabelPageCount;
        private TextBox TextBoxIndex;
        private int int_0;
        private HtmlGenericControl pageDiv;
        private Repeater repeater_0;
        private string string_1 = "SupplyDemandCommentList.ascx";
        private string string_2;

        public SupplyDemandCommentList()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = string_1;
            }
        }

        public string Guid { get; set; }

        public int ShowCount { get; set; }

        public void BindData()
        {
            var pl = new PageList1
            {
                PageSize = ShowCount,
                PageID = int_0
            };
            var action = (ShopNum1_SupplyDemandComment_Action) LogicFactory.CreateShopNum1_SupplyDemandComment_Action();
            DataSet set = action.GetSupplyDemandCommentList(ShowCount.ToString(), int_0.ToString(), Guid, string_2, "1");
            if ((set != null) && (set.Tables[0].Rows.Count > 0))
            {
                pl.RecordCount = Convert.ToInt32(set.Tables[0].Rows[0][0]);
            }
            else
            {
                pl.RecordCount = 0;
            }
            var bll = new PageListBll("SupplyDemandDetail", true)
            {
                ShowRecordCount = true,
                ShowPageCount = false,
                ShowPageIndex = false,
                //ShowRecordCount = false,
                ShowNoRecordInfo = false,
                ShowNumListButton = true,
                PrevPageText = "<<上一页",
                NextPageText = "下一页>> "
            };
            TextBoxIndex.Text = int_0.ToString();
            pageDiv.InnerHtml = bll.GetPageListVk(pl);
            LabelPageCount.Text = pl.PageCount.ToString();
            DataSet set2 = action.GetSupplyDemandCommentList(ShowCount.ToString(), int_0.ToString(), Guid, string_2, "0");
            if ((set2 != null) && (set2.Tables[0].Rows.Count > 0))
            {
                repeater_0.DataSource = set2.Tables[0];
                repeater_0.DataBind();
            }
        }

        protected void ButtonSure_Click(object sender, EventArgs e)
        {
            TextBoxIndex.Text.Trim();
            Page.Response.Redirect(string_0 + "?guid=" + Guid + "&ordername=" + string_2);
        }

        protected override void InitializeSkin(Control skin)
        {
            pageDiv = (HtmlGenericControl) skin.FindControl("pageDiv");
            LabelPageCount = (Label) skin.FindControl("LabelPageCount");
            TextBoxIndex = (TextBox) skin.FindControl("TextBoxIndex");
            ButtonSure = (Button) skin.FindControl("ButtonSure");
            ButtonSure.Click += ButtonSure_Click;
            int_0 = 1;
            try
            {
                int_0 = int.Parse(Page.Request.QueryString["PageID"]);
            }
            catch
            {
                int_0 = 1;
            }
            repeater_0 = (Repeater) skin.FindControl("RepeaterData");
            repeater_0.ItemDataBound += repeater_0_ItemDataBound;
            Guid = (Common.Common.ReqStr("guid") == "") ? "0" : Common.Common.ReqStr("guid");
            string_2 = (Common.Common.ReqStr("ordername") == "") ? "CreateTime" : Common.Common.ReqStr("ordername");
            BindData();
        }

        protected void repeater_0_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
            {
                var image = (Image) e.Item.FindControl("ImagePhoto");
                var field = (HiddenField) e.Item.FindControl("HiddenFieldCreateMerber");
                string str = Common.Common.GetNameById("Photo", "ShopNum1_Member",
                    "  AND MemLoginID='" + field.Value + "'");
                if (!string.IsNullOrEmpty(str))
                {
                    image.ImageUrl = str;
                }
                else
                {
                    image.ImageUrl = "/Main/Themes/Skin_Default/Images/arst.png";
                }
            }
        }
    }
}