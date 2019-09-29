using System;
using System.Data;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;

namespace ShopNum1.ShopAdminWebControl
{
    [ParseChildren(true)]
    public class S_ShowPaymentType : BaseShopWebControl
    {
        private Repeater RepeaterShow;
        private string skinFilename = "S_ShowPaymentType.ascx";

        public S_ShowPaymentType()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public void GetData()
        {
            DataTable paymentType =
                ((ShopNum1_Member_Action) LogicFactory.CreateShopNum1_Member_Action()).GetPaymentType(1);
            if ((paymentType != null) && (paymentType.Rows.Count > 0))
            {
                RepeaterShow.DataSource = paymentType.DefaultView;
                RepeaterShow.DataBind();
            }
        }

        protected override void InitializeSkin(Control skin)
        {
            RepeaterShow = (Repeater) skin.FindControl("RepeaterShow");
            RepeaterShow.ItemDataBound += RepeaterShow_ItemDataBound;
            GetData();
        }

        protected void method_0(object sender, EventArgs e)
        {
            var button = (Button) sender;
            var field = button.Parent.FindControl("HiddenFieldType") as HiddenField;
            if (button.Text == "安装")
            {
                Page.Response.Redirect("S_DeployPayment.aspx?run=add&type=" + field.Value);
            }
            else if (button.Text == "卸载")
            {
                button.Text = "卸载中";
                if (OutReset(field.Value))
                {
                    MessageBox.Show("卸载成功！");
                    GetData();
                }
            }
        }

        public bool OutReset(string type)
        {
            var action = (ShopNum1_ShopPayment_Action) LogicFactory.CreateShopNum1_ShopPayment_Action();
            return (action.Delete(type, base.MemLoginID) > 0);
        }

        protected void RepeaterShow_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if ((e.Item.ItemType == ListItemType.AlternatingItem) || (e.Item.ItemType == ListItemType.Item))
            {
                var label = (Label) e.Item.FindControl("LabelRun");
                var button = (Button) e.Item.FindControl("runbutton");
                button.Click += method_0;
                var anchor = (HtmlAnchor) e.Item.FindControl("pzcj");
                var field = (HiddenField) e.Item.FindControl("HiddenFieldType");
                anchor.HRef = "../S_DeployPayment.aspx?run=edit&type=" + field.Value;
                label.Text = Run(label.Text);
                if (label.Text == "否")
                {
                    button.Text = "安装";
                    label.ForeColor = Color.Red;
                    anchor.Visible = false;
                }
                else
                {
                    button.Text = "卸载";
                    anchor.Visible = true;
                }
            }
        }

        public string Run(string type)
        {
            DataTable paymentKey =
                ((ShopNum1_ShopPayment_Action) LogicFactory.CreateShopNum1_ShopPayment_Action()).GetPaymentKey(type,
                    base
                        .MemLoginID);
            if ((paymentKey != null) && (paymentKey.Rows.Count > 0))
            {
                return "是";
            }
            return "否";
        }
    }
}