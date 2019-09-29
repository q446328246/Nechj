using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;
using ShopNum1MultiEntity;

namespace ShopNum1.MemberWebControl
{
    [ParseChildren(true)]
    public class M_ShopNewsComment : BaseMemberWebControl
    {
        private Button ButtonGet;
        private DropDownList DropDownListIsAudit;
        private Repeater RepeaterShow;
        private TextBox TextBoxSRegDate1;
        private TextBox TextBoxSRegDate2;
        private HtmlGenericControl pageDiv;
        private string skinFilename = "M_ShopNewsComment.ascx";

        public M_ShopNewsComment()
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

        public static string GetTitle(string guid)
        {
            string str = string.Empty;
            DataTable titleByGuid = ((Shop_News_Action) LogicFactory.CreateShop_News_Action()).GetTitleByGuid(guid);
            if ((titleByGuid != null) && (titleByGuid.Rows.Count > 0))
            {
                str = titleByGuid.Rows[0][0].ToString();
            }
            return str;
        }

        protected override void InitializeSkin(Control skin)
        {
            RepeaterShow = (Repeater) skin.FindControl("RepeaterShow");
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

        private void BindData()
        {
            var action = (Shop_News_Action) LogicFactory.CreateShop_News_Action();
            string str = string.Empty;
            if (!string.IsNullOrEmpty(TextBoxSRegDate1.Text.Trim()))
            {
                str = str + "  AND  CommentTime>'" + TextBoxSRegDate1.Text.Trim() + "'   ";
            }
            if (!string.IsNullOrEmpty(TextBoxSRegDate2.Text.Trim()))
            {
                str = str + "   AND  CommentTime<'" + TextBoxSRegDate2.Text.Trim() + "'  ";
            }
            if (DropDownListIsAudit.SelectedValue != "-1")
            {
                str = str + "   AND  IsAudit = '" + DropDownListIsAudit.SelectedValue + "'  ";
            }
            var commonModel = new CommonPageModel
            {
                Condition = " and 0=0    " + str + "   AND  MemLoginID='" + base.MemLoginID + "'  ",
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