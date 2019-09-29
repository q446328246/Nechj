using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;
using ShopNum1MultiEntity;

namespace ShopNum1.MemberWebControl
{
    [ParseChildren(true)]
    public class M_SupplyDemandComment : BaseMemberWebControl
    {
        private Button ButtonGet;
        private DropDownList DropDownListIsAudit;
        private Repeater RepeaterShow;
        private TextBox TextBoxSRegDate1;
        private TextBox TextBoxSRegDate2;
        private TextBox TextBoxTitle;
        private HtmlGenericControl pageDiv;
        private string skinFilename = "M_SupplyDemandComment.ascx";

        public M_SupplyDemandComment()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public string pageid { get; set; }

        public string PageSize { get; set; }

        public string type { get; set; }

        private void ButtonGet_Click(object sender, EventArgs e)
        {
            BindData();
        }

        protected override void InitializeSkin(Control skin)
        {
            RepeaterShow = (Repeater) skin.FindControl("RepeaterShow");
            TextBoxTitle = (TextBox) skin.FindControl("TextBoxTitle");
            DropDownListIsAudit = (DropDownList) skin.FindControl("DropDownListIsAudit");
            pageDiv = (HtmlGenericControl) skin.FindControl("pageDiv");
            pageid = (Common.Common.ReqStr("PageID") == "") ? "1" : Common.Common.ReqStr("PageID");
            TextBoxSRegDate1 = (TextBox) skin.FindControl("TextBoxSRegDate1");
            TextBoxSRegDate2 = (TextBox) skin.FindControl("TextBoxSRegDate2");
            ButtonGet = (Button) skin.FindControl("ButtonGet");
            ButtonGet.Click += ButtonGet_Click;
            type = (Common.Common.ReqStr("type") == "") ? "0" : Common.Common.ReqStr("type");
            BindData();
        }

        public static string IsAudit(string IsAudit)
        {
            if (IsAudit == "0")
            {
                return "未审核";
            }
            if (IsAudit == "1")
            {
                return "审核通过";
            }
            if (IsAudit == "2")
            {
                return "审核未通过";
            }
            return "";
        }

        private void BindData()
        {
            var action = (ShopNum1_SupplyDemandComment_Action) LogicFactory.CreateShopNum1_SupplyDemandComment_Action();
            string str = string.Empty;
            if (!string.IsNullOrEmpty(TextBoxSRegDate1.Text.Trim()))
            {
                str = str + "  AND  CreateTime>'" + TextBoxSRegDate1.Text.Trim() + "'   ";
            }
            if (!string.IsNullOrEmpty(TextBoxSRegDate2.Text.Trim()))
            {
                str = str + "   AND  CreateTime<'" + TextBoxSRegDate2.Text.Trim() + "'  ";
            }
            if (!string.IsNullOrEmpty(TextBoxTitle.Text.Trim()))
            {
                str = str + "   AND  Title LIKE '%" + TextBoxTitle.Text.Trim() + "%'  ";
            }
            if (DropDownListIsAudit.SelectedValue != "-1")
            {
                str = str + "   AND  IsAudit = '" + DropDownListIsAudit.SelectedValue + "'  ";
            }
            var commonModel = new CommonPageModel
            {
                Condition = " and 0=0    " + str + "   AND  CreateMerber='" + base.MemLoginID + "'  ",
                Currentpage = pageid,
                Resultnum = "0",
                PageSize = PageSize
            };
            DataTable table = action.Select_List(commonModel);
            var pl = new PageList1
            {
                PageSize = Convert.ToInt32(PageSize),
                PageID = Convert.ToInt32(pageid)
            };
            if ((table != null) && (table.Rows.Count > 0))
            {
                pl.RecordCount = Convert.ToInt32(table.Rows[0][0]);
            }
            else
            {
                pl.RecordCount = 0;
            }
            pageDiv.InnerHtml = new PageListBll("main/member/M_Comment.aspx", true).GetPageListNew(pl);
            commonModel.Resultnum = "1";
            DataTable table2 = action.Select_List(commonModel);
            RepeaterShow.DataSource = table2.DefaultView;
            RepeaterShow.DataBind();
        }
    }
}