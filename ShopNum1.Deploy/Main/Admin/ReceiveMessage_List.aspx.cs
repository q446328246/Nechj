using System;
using System.Web.SessionState;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class ReceiveMessage_List : PageBase, IRequiresSessionState
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            if (!Page.IsPostBack)
            {
                BindStatus();
                BindGrid();
                textBoxLoginID.Text = base.ShopNum1LoginID;
            }
        }

        protected void BindGrid()
        {
            Num1GridiewShow.DataBind();
        }

        protected void BindStatus()
        {
            var item = new ListItem
                {
                    Text = " -È«²¿-",//LocalizationUtil.GetCommonMessage("All"),
                    Value = "-1"
                };
            DropDownListSIsRead.Items.Add(item);
            DropDownListSIsReply.Items.Add(item);
            var item2 = new ListItem
                {
                    Text = " Î´¶Á",//LocalizationUtil.GetCommonMessage("NoRead"),
                    Value = "0"
                };
            DropDownListSIsRead.Items.Add(item2);
            var item3 = new ListItem
                {
                    Text = " ÒÑ¶Á",//LocalizationUtil.GetCommonMessage("IsRead"),
                    Value = "1"
                };
            DropDownListSIsRead.Items.Add(item3);
            var item4 = new ListItem
                {
                    Text = " Î´»Ø¸´",//LocalizationUtil.GetCommonMessage("NoReply"),
                    Value = "0"
                };
            DropDownListSIsReply.Items.Add(item4);
            var item5 = new ListItem
                {
                    Text = " ÒÑ»Ø¸´",//LocalizationUtil.GetCommonMessage("IsReply"),
                    Value = "1"
                };
            DropDownListSIsReply.Items.Add(item5);
        }

        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            CheckGuid.Value = "0";
            base.Response.Redirect("Message_Operate.aspx?guid=" + CheckGuid.Value);
        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            var action = (ShopNum1_MessageInfo_Action) LogicFactory.CreateShopNum1_MessageInfo_Action();
            if (action.DeleteReceive(CheckGuid.Value) > 0)
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
            var action = (ShopNum1_MessageInfo_Action) LogicFactory.CreateShopNum1_MessageInfo_Action();
            var button = (LinkButton) sender;
            string guids = "'" + button.CommandArgument + "'";
            if (action.DeleteReceive(guids) > 0)
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
            base.Response.Redirect("Message_Reply.aspx?guid=" + CheckGuid.Value + "&Type=1");
        }

        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            BindGrid();
        }

        protected void ButtonSearchBylink_Click(object sender, EventArgs e)
        {
            var button = (LinkButton) sender;
            string str = "'" + button.CommandArgument + "'";
            base.Response.Redirect("Message_Reply.aspx?guid=" + str + "&type=1");
        }

        public string ChangeIsRead(string strIsRead)
        {
            if (strIsRead == "0")
            {
                return " Î´¶Á";//LocalizationUtil.GetChangeMessage("ReceiveMessage_List", "IsRead", "0");
            }
            if (strIsRead == "1")
            {
                return " ÒÑ¶Á";//LocalizationUtil.GetChangeMessage("ReceiveMessage_List", "IsRead", "1");
            }
            return "";
        }

        public string ChangeIsReply(string strIsReply)
        {
            if (strIsReply == "0")
            {
                return " Î´»Ø¸´";//LocalizationUtil.GetChangeMessage("ReceiveMessage_List", "IsReply", "0");
            }
            if (strIsReply == "1")
            {
                return " ÒÑ»Ø¸´";//LocalizationUtil.GetChangeMessage("ReceiveMessage_List", "IsReply", "1");
            }
            return "";
        }

        protected void Num1GridiewShow_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (Operator.FormatToEmpty(e.Row.Cells[8].Text) == string.Empty)
                {
                    e.Row.Cells[7].Text = " Î´»Ø¸´";//LocalizationUtil.GetChangeMessage("ReceiveMessage_List", "IsReply", "0");
                }
                else
                {
                    e.Row.Cells[7].Text = " ÒÑ»Ø¸´";//LocalizationUtil.GetChangeMessage("ReceiveMessage_List", "IsReply", "1");
                }
            }
        }


    }
}