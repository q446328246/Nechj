using System;
using System.Data;
using System.Web.SessionState;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Factory;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class AttachMent_List_Select : PageBase, IRequiresSessionState
    {
        protected void BindAttachMentCateGory()
        {
            DataTable table =
                ((ShopNum1_AttachMentCategory_Action) LogicFactory.CreateShopNum1_AttachMentCategory_Action()).Search();
            DropDownListAttachMentCateGory.Items.Add(new ListItem("-全部-", "-1"));
            for (int i = 0; i < table.Rows.Count; i++)
            {
                DropDownListAttachMentCateGory.Items.Add(new ListItem(table.Rows[i]["CategoryName"].ToString(),
                                                                      table.Rows[i]["Guid"].ToString()));
            }
        }

        protected void BindGrid()
        {
            DataTable table =
                ((ShopNum1_AttachMent_Action) LogicFactory.CreateShopNum1_AttachMent_Action()).Search(
                    DropDownListAttachMentCateGory.SelectedValue);
            num1GridViewShow.DataSource = table;
            num1GridViewShow.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            if (!Page.IsPostBack)
            {
                BindAttachMentCateGory();
                BindGrid();
            }
        }
    }
}