using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;

namespace ShopNum1.MemberWebControl
{
    [ParseChildren(true)]
    public class M_AddProductComment : BaseMemberWebControl
    {
        public static DataTable dt_Continue = null;

        private readonly Shop_ProductComment_Action shop_ProductComment_Action_0 =
            ((Shop_ProductComment_Action) LogicFactory.CreateShop_ProductComment_Action());

        private HtmlTextArea TextBoxComment;

        private Button btnSave;

        private HtmlInputHidden hidCommentC;
        private HtmlInputHidden hidPGuid;

        private string skinFilename = "M_AddProductComment.ascx";

        public M_AddProductComment()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string[] strArray = (hidCommentC.Value + ",").Split(new[] {','});
            string[] strArray2 = (hidPGuid.Value + ",").Split(new[] {','});
            for (int i = 0; i < (strArray.Length - 1); i++)
            {
                if (!(strArray[i] != "") || (strArray[i].Length > 500))
                {
                    return;
                }
                shop_ProductComment_Action_0.UpdateContinueComment(Common.Common.ReqStr("orid"), base.MemLoginID,
                    strArray[i], strArray2[i]);
            }
            MessageBox.Show("追加评论操作成功！");
            Page.Response.Redirect("m_index.aspx?tomurl=M_FeedBack.aspx");
        }

        protected override void InitializeSkin(Control skin)
        {
            btnSave = (Button) skin.FindControl("btnSave");
            btnSave.Click += btnSave_Click;
            hidCommentC = (HtmlInputHidden) skin.FindControl("hidCommentC");
            TextBoxComment = (HtmlTextArea) skin.FindControl("TextBoxComment");
            hidPGuid = (HtmlInputHidden) skin.FindControl("hidPGuid");

            if (!Page.IsPostBack)
            {
                BindData();
            }
        }

        private void BindData()
        {
            dt_Continue = shop_ProductComment_Action_0.GetCommentDetail(Common.Common.ReqStr("orid"), base.MemLoginID);
            if (dt_Continue.Rows.Count == 0)
            {
                dt_Continue = null;
            }
        }
    }
}