using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;
using ShopNum1MultiEntity;

namespace ShopNum1.ShopAdminWebControl
{
    [ParseChildren(true)]
    public class S_ShopURLManageEdit : BaseShopWebControl
    {
        private readonly Shop_URLManage_Action shop_URLManage_Action_0 =
            ((Shop_URLManage_Action) LogicFactory.CreateShop_URLManage_Action());

        private Button ButtonBackList;
        private Button ButtonSubmit;
        private HiddenField HiddenFieldID;
        private Label LabelDomain;
        private Label LabelTitle;

        private TextBox TextBoxDoMain;
        private string skinFilename = "S_ShopURLManageEdit.ascx";

        public S_ShopURLManageEdit()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            if (Page.Request.QueryString["ID"] != null)
            {
                method_1();
            }
            else
            {
                BindData();
            }
        }

        protected void ButtonBackList_Click(object sender, EventArgs e)
        {
            Page.Response.Redirect("S_ShopURLManage.aspx");
        }

        public void GetInfo()
        {
            DataTable editInfo =
                ((Shop_URLManage_Action) LogicFactory.CreateShop_URLManage_Action()).GetEditInfo(
                    Page.Request.QueryString["ID"]);
            if ((editInfo != null) && (editInfo.Rows.Count > 0))
            {
                TextBoxDoMain.Text = editInfo.Rows[0]["DoMain"].ToString();
                if (editInfo.Rows[0]["IsAudit"].ToString() == "1")
                {
                }
            }
        }

        protected override void InitializeSkin(Control skin)
        {
            LabelTitle = (Label) skin.FindControl("LabelTitle");
            TextBoxDoMain = (TextBox) skin.FindControl("TextBoxDoMain");
            HiddenFieldID = (HiddenField) skin.FindControl("HiddenFieldID");
            ButtonSubmit = (Button) skin.FindControl("ButtonSubmit");
            ButtonSubmit.Click += ButtonSubmit_Click;
            ButtonBackList = (Button) skin.FindControl("ButtonBackList");
            ButtonBackList.Click += ButtonBackList_Click;
            LabelDomain = (Label) skin.FindControl("LabelDomain");
            LabelDomain.Text = ShopSettings.siteDomain.Substring(3);
            if (Page.Request.QueryString["ID"] != null)
            {
                GetInfo();
                HiddenFieldID.Value = Page.Request.QueryString["ID"];
                LabelTitle.Text = "编辑域名";
            }
            else
            {
                LabelTitle.Text = "添加域名";
            }
        }

        protected void BindData()
        {
            var action = (ShopNum1_ShopInfoList_Action) Factory.LogicFactory.CreateShopNum1_ShopInfoList_Action();
            string str = action.GetShopIDByMemLoginID(base.MemLoginID).Rows[0]["ShopID"].ToString();
            var shopURLManage = new ShopNum1_ShopURLManage
            {
                MemLoginID = base.MemLoginID,
                IsAudit = 0,
                DoMain = TextBoxDoMain.Text.Trim(),
                SiteNumber = ""
            };
            string str2 = ShopSettings.siteDomain.Substring(ShopSettings.siteDomain.IndexOf("."));
            shopURLManage.GoUrl = ShopSettings.GetValue("PersonShopUrl") + str + str2;
            if (shop_URLManage_Action_0.AddURLManage(shopURLManage) > 0)
            {
                MessageBox.Show("申请成功，等待审核！");
                TextBoxDoMain.Text = "";
                Page.Response.Redirect("S_ShopURLManage.aspx");
            }
            else
            {
                MessageBox.Show("申请失败！");
            }
        }

        protected void method_1()
        {
            var manage = new ShopNum1_ShopURLManage
            {
                ID = Convert.ToInt32(Page.Request.QueryString["ID"]),
                MemLoginID = base.MemLoginID,
                IsAudit = 0,
                SiteNumber = "",
                DoMain = TextBoxDoMain.Text
            };
            if (shop_URLManage_Action_0.UpdateURLManage(manage) > 0)
            {
                MessageBox.Show("编辑成功！");
            }
            else
            {
                MessageBox.Show("编辑失败!");
            }
        }
    }
}