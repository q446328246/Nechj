using System;
using System.Data;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Factory;

namespace ShopNum1.Deploy.Main.Admin.UserControl
{
    public partial class MemberSelect : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindMemberRank();
            }
        }

        protected void BindListBoxLeftMember()
        {
            ListBoxLeftMember.Items.Clear();
            string memLoginID = TextBoxSMemberName.Text.Trim();
            string realName = TextBoxSMemberID.Text.Trim();
            string selectedValue = DropDownListSMemberRank.SelectedValue;
            var action = (ShopNum1_Member_Action) LogicFactory.CreateShopNum1_Member_Action();
            foreach (DataRow row in action.SearchMemberName(memLoginID, realName, selectedValue).DefaultView.Table.Rows)
            {
                var item = new ListItem();
                if (method_0(base.Request.QueryString["type"]) == "1")
                {
                    item.Text = row["MemLoginID"].ToString().Trim();
                }
                else
                {
                    item.Text = row["MemLoginID"].ToString().Trim();
                }
                item.Value = row["Guid"].ToString().Trim();
                ListBoxLeftMember.Items.Add(item);
            }
        }

        protected void BindMemberRank()
        {
            var item = new ListItem
                {
                    Text = "-全部-",
                    Value = "-1"
                };
            DropDownListSMemberRank.Items.Add(item);
            var action = (ShopNum1_MemberRank_Action) LogicFactory.CreateShopNum1_MemberRank_Action();
            foreach (DataRow row in action.SearchGuidName(0).DefaultView.Table.Rows)
            {
                var item2 = new ListItem
                    {
                        Text = row["Name"].ToString().Trim(),
                        Value = row["Guid"].ToString().Trim()
                    };
                DropDownListSMemberRank.Items.Add(item2);
            }
        }

        protected void ButtonAddAllMember_Click(object sender, EventArgs e)
        {
            foreach (ListItem item in ListBoxLeftMember.Items)
            {
                if (method_1(item.Value))
                {
                    ListBoxRightMember.Items.Add(item);
                }
            }
        }

        protected void ButtonAddMember_Click(object sender, EventArgs e)
        {
            foreach (ListItem item in ListBoxLeftMember.Items)
            {
                if (item.Selected && method_1(item.Value))
                {
                    ListBoxRightMember.Items.Add(item);
                }
            }
        }

        protected void ButtonDeleteAllMember_Click(object sender, EventArgs e)
        {
            if (ListBoxRightMember.Items.Count != -1)
            {
                for (int i = ListBoxRightMember.Items.Count - 1; i >= 0; i--)
                {
                    ListBoxRightMember.Items.Remove(ListBoxRightMember.Items[i]);
                }
            }
        }

        protected void ButtonDeleteMember_Click(object sender, EventArgs e)
        {
            if (ListBoxRightMember.Items.Count != -1)
            {
                for (int i = ListBoxRightMember.Items.Count - 1; i >= 0; i--)
                {
                    if (ListBoxRightMember.Items[i].Selected)
                    {
                        ListBoxRightMember.Items.Remove(ListBoxRightMember.Items[i]);
                    }
                }
            }
        }

        protected void ButtonSearchRelatedProduct_Click(object sender, EventArgs e)
        {
            BindListBoxLeftMember();
        }

        private string method_0(object object_0)
        {
            if (object_0 != null)
            {
                return object_0.ToString();
            }
            return "";
        }

        private bool method_1(string string_0)
        {
            for (int i = 0; i < ListBoxRightMember.Items.Count; i++)
            {
                if (ListBoxRightMember.Items[i].Value == string_0.Trim())
                {
                    return false;
                }
            }
            return true;
        }
    }
}