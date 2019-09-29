using System;
using System.Collections;
using System.Web.SessionState;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class Email_List : PageBase, IRequiresSessionState
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            if (!Page.IsPostBack)
            {
                BindGrid();
                BindData();
            }
        }

        protected void BindGrid()
        {
            Num1GridView.DataBind();
        }

        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            CheckGuid.Value = "0";
            base.Response.Redirect("Email_Operate.aspx?guid=" + CheckGuid.Value);
        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            string[] strArray = CheckGuid.Value.Split(new[] {','});
            var list = new ArrayList();
            list.Add(strArray);
            for (int i = 0; i < list.Count; i++)
            {
                if (((((strArray[i].ToUpper() == "'EFAE7062-E62E-4BF3-A513-126F55EDB960'") ||
                       (strArray[i].ToUpper() == "'B18D049B-BDC5-4B08-AE29-6D686F6B4A03'")) ||
                      ((strArray[i].ToUpper() == "'B195A8AB-8B12-4DF2-B719-C9CC8E6E5226'") ||
                       (strArray[i].ToUpper() == "'7C367402-4219-46B7-BC48-72CF48F6A836'"))) ||
                     (((strArray[i].ToUpper() == "'D6F534A3-0538-4933-B114-CB4C85B26265'") ||
                       (strArray[i].ToUpper() == "'D483077E-E7A3-4F4F-BD66-9010DC04E4E3'")) ||
                      (strArray[i].ToUpper() == "'4A12724C-5154-4928-B867-D5BD180E80E6'"))) ||
                    (strArray[i].ToUpper() == "'9D7B9B03-DFE5-4BD5-9EEE-E0A1A86E347B'"))
                {
                    MessageBox.Show("删除内容中含有系统文件，无法删除！");
                    return;
                }
            }
            var action = (ShopNum1_Email_Action) LogicFactory.CreateShopNum1_Email_Action();
            if (action.Delete(CheckGuid.Value) > 0)
            {
                BindGrid();
                MessageShow.ShowMessage("DelYes");
                MessageShow.Visible = true;
            }
            else
            {
                MessageShow.ShowMessage("DelNo");
                MessageShow.Visible = true;
            }
        }

        protected void ButtonDeleteBylink_Click(object sender, EventArgs e)
        {
            var button = (LinkButton) sender;
            string commandArgument = button.CommandArgument;
            var action = (ShopNum1_Email_Action) LogicFactory.CreateShopNum1_Email_Action();
            if (action.Delete("'" + commandArgument + "'") > 0)
            {
                BindGrid();
                MessageShow.ShowMessage("DelYes");
                MessageShow.Visible = true;
            }
            else
            {
                MessageShow.ShowMessage("DelNo");
                MessageShow.Visible = true;
            }
        }

        protected void ButtonEdit_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("Email_Operate.aspx?guid=" + CheckGuid.Value);
        }

        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            BindGrid();
        }

        private void BindData()
        {
        }


    }
}