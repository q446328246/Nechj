using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;

namespace ShopNum1.ShopAdminWebControl
{
    [ParseChildren(true)]
    public class S_EnsureApplyRecordList : BaseShopWebControl
    {
        private Repeater Rep_EnsureApply;
        private Repeater Rep_EnsureNoApply;
        private string skinFilename = "S_EnsureApplyRecordList.ascx";

        public S_EnsureApplyRecordList()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public static string GetImg(object object_0)
        {
            return object_0.ToString().Split(new[] {'~'})[1];
        }

        public static string GetStatus(object object_0, object obj2, object objid, object objMemID, object objtype)
        {
            string str = string.Empty;
            string str2 = string.Empty;
            if ((object_0.ToString() == "0") && (obj2.ToString() == "1"))
            {
                str = "等待审核";
                str2 = "0";
            }
            if ((object_0.ToString() == "0") && (obj2.ToString() == "0"))
            {
                string ensureid = objid.ToString();
                string shopid = objMemID.ToString();
                var action = (Shop_Ensure_Action) LogicFactory.CreateShop_Ensure_Action();
                if (action.GetCheckedShopEnsureList(ensureid, shopid).Rows.Count > 0)
                {
                    str = "支付";
                    str2 = "1";
                }
                else
                {
                    str = "申请开通此服务";
                    str2 = "-1";
                }
            }
            if (objtype.ToString() == "0")
            {
                return str;
            }
            return str2;
        }

        protected override void InitializeSkin(Control skin)
        {
            Rep_EnsureApply = (Repeater) skin.FindControl("Rep_EnsureApply");
            Rep_EnsureNoApply = (Repeater) skin.FindControl("Rep_EnsureNoApply");
            Rep_EnsureNoApply.ItemCommand += Rep_EnsureNoApply_ItemCommand;
            BindData();
            method_1();
        }

        protected void BindData()
        {
            DataTable shopapplyEnsure =
                ((Shop_Ensure_Action) LogicFactory.CreateShop_Ensure_Action()).GetShopapplyEnsure(base.MemLoginID);
            Rep_EnsureApply.DataSource = shopapplyEnsure;
            Rep_EnsureApply.DataBind();
        }

        protected void method_1()
        {
            DataTable shopNotApplyEnsure =
                ((Shop_Ensure_Action) LogicFactory.CreateShop_Ensure_Action()).GetShopNotApplyEnsure(base.MemLoginID);
            Rep_EnsureNoApply.DataSource = shopNotApplyEnsure;
            Rep_EnsureNoApply.DataBind();
        }

        protected void Rep_EnsureNoApply_ItemCommand(object sender, RepeaterCommandEventArgs e)
        {
            var button1 = (Button) e.Item.FindControl("btn_Open");
            var hidden = (HtmlInputHidden) e.Item.FindControl("hid_Open");
            var hidden2 = (HtmlInputHidden) e.Item.FindControl("hid_Type");
            var hidden3 = (HtmlInputHidden) e.Item.FindControl("hid_Guid");
            if (e.CommandName == "open")
            {
                if (hidden2.Value == "-1")
                {
                    Page.Response.Redirect("S_EnsureApplyRecordOperate.aspx?ID=" + hidden.Value);
                }
                else if (hidden2.Value == "0")
                {
                    MessageBox.Show("等待审核");
                }
                else if (hidden2.Value == "1")
                {
                    Page.Response.Redirect("S_EnsureApplyRecordOperate.aspx?ID=" + hidden.Value + "&type=" +
                                           Encryption.GetMd5Hash(hidden2.Value) + "&guid=" + hidden3.Value);
                }
            }
        }
    }
}