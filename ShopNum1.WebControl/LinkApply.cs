using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;
using ShopNum1MultiEntity;

namespace ShopNum1.WebControl
{
    [ParseChildren(true)]
    public class LinkApply : BaseWebControl
    {
        private Button ButtonApply;
        private TextBox TextBoxDescription;
        private TextBox TextBoxHref;
        private TextBox TextBoxMemo;
        private TextBox TextBoxName;
        private string skinFilename = "LinkApply.ascx";

        public LinkApply()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public static string Name { get; set; }

        public static string NetName { get; set; }

        protected void ButtonApply_Click(object sender, EventArgs e)
        {
            if (!CheckIsDuplication())
            {
                MessageBox.Show("已提交过申请！");
            }
            else
            {
                var link = new ShopNum1_Link
                {
                    Guid = Guid.NewGuid(),
                    Href = "http://" + TextBoxHref.Text.Trim().Replace("http://", ""),
                    Description = TextBoxDescription.Text.Trim(),
                    Memo = TextBoxMemo.Text.Trim(),
                    Name = TextBoxName.Text.Trim(),
                    ImgADD = string.Empty,
                    LinkType = 0,
                    ImgType = string.Empty,
                    CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                    ModifyTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                    CreateUser = TextBoxName.Text.Trim(),
                    ModifyUser = TextBoxName.Text.Trim()
                };
                string columnName = "OrderID";
                string tableName = "ShopNum1_Link";
                int num = 1 + ShopNum1_Common_Action.ReturnMaxID(columnName, tableName);
                link.OrderID = num;
                link.IsShow = 0;
                link.IsDeleted = 0;
                var action = (ShopNum1_Link_Action) LogicFactory.CreateShopNum1_Link_Action();
                if (action.Add(link) > 0)
                {
                    MessageBox.Show("申请成功");
                }
                else
                {
                    MessageBox.Show("申请失败");
                }
            }
        }

        protected bool CheckIsDuplication()
        {
            string link = "http://" + TextBoxHref.Text.Trim().Replace("http://", "");
            var action = (ShopNum1_Link_Action) LogicFactory.CreateShopNum1_Link_Action();
            return (action.CheckIsDuplication(link).Rows[0][0].ToString() == "0");
        }

        protected override void InitializeSkin(Control skin)
        {
            TextBoxName = (TextBox) skin.FindControl("TextBoxName");
            TextBoxHref = (TextBox) skin.FindControl("TextBoxHref");
            TextBoxDescription = (TextBox) skin.FindControl("TextBoxDescription");
            TextBoxMemo = (TextBox) skin.FindControl("TextBoxMemo");
            ButtonApply = (Button) skin.FindControl("ButtonApply");
            ButtonApply.Click += ButtonApply_Click;
            if (!Page.IsPostBack)
            {
            }
            Name = ShopSettings.GetValue("Name");
            NetName = ShopSettings.siteDomain;
        }
    }
}