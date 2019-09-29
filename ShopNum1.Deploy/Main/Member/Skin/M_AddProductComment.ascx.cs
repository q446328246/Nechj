using System;
using System.Data;
using ShopNum1.Common;
using ShopNum1.Deploy.App_Code;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;

namespace ShopNum1.Deploy.Main.Member.Skin
{
    public partial class M_AddProductComment : BaseMemberControl
    {
        public static DataTable dt_Continue = null;

        private readonly Shop_ProductComment_Action shop_ProductComment_Action_0 =
            ((Shop_ProductComment_Action) LogicFactory.CreateShop_ProductComment_Action());


        protected void btnSave_Click(object sender, EventArgs e)
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

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindData();
            }
        }

        protected void BindData()
        {
            dt_Continue = shop_ProductComment_Action_0.GetCommentDetail(Common.Common.ReqStr("orid"), base.MemLoginID);
            if (dt_Continue.Rows.Count == 0)
            {
                dt_Continue = null;
            }
        }
    }
}
