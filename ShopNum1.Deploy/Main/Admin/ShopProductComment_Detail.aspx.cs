using System;
using System.Data;
using System.Web.SessionState;
using ShopNum1.BusinessLogic;
using ShopNum1.Factory;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class ShopProductComment_Detail : PageBase, IRequiresSessionState
    {
        private string GoBack { get; set; }

        protected void ButtonBack_Click(object sender, EventArgs e)
        {
            if (GoBack == "List")
            {
                base.Response.Redirect("ShopProductComment_List.aspx");
            }
            else if (GoBack == "Audit")
            {
                base.Response.Redirect("ShopProductCommentAudit_List.aspx");
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            string guid = Page.Request.QueryString["Guid"].Replace("'", "");
            GoBack = (Page.Request.QueryString["Type"] == null) ? "-1" : Page.Request.QueryString["Type"];
            DataTable table =
                ((ShopNum1_ProductComment_Action) LogicFactory.CreateShopNum1_ProductComment_Action()).Search(guid);
            TextBoxName.Text = table.Rows[0]["ProductName"].ToString();
            TextBoxMenLoginID.Text = table.Rows[0]["MemLoginID"].ToString();
            TextBoxCommentTime.Text = table.Rows[0]["CommentTime"].ToString();
            if (table.Rows[0]["CommentType"].ToString() == "5")
            {
                TextBoxCommentType.Text = "����";
            }
            else if (table.Rows[0]["CommentType"].ToString() == "3")
            {
                TextBoxCommentType.Text = "����";
            }
            else
            {
                TextBoxCommentType.Text = "����";
            }
            string str2 = table.Rows[0]["Speed"].ToString();
            switch (str2)
            {
                case null:
                    break;

                case "5":
                    TextBoxSpeed.Text = "�ܿ�";
                    break;

                case "4":
                    TextBoxSpeed.Text = "�ȽϿ�";
                    break;

                case "3":
                    TextBoxSpeed.Text = "һ��";
                    break;

                default:
                    if (!(str2 == "2"))
                    {
                        if (str2 == "1")
                        {
                            TextBoxSpeed.Text = "����";
                        }
                    }
                    else
                    {
                        TextBoxSpeed.Text = "��";
                    }
                    break;
            }
            str2 = table.Rows[0]["Attitude"].ToString();
            switch (str2)
            {
                case null:
                    break;

                case "5":
                    TextBoxAttitude.Text = "�ܺ�";
                    break;

                case "4":
                    TextBoxAttitude.Text = "�ȽϺ�";
                    break;

                case "3":
                    TextBoxAttitude.Text = "һ��";
                    break;

                default:
                    if (!(str2 == "2"))
                    {
                        if (str2 == "1")
                        {
                            TextBoxAttitude.Text = "�ܲ�";
                        }
                    }
                    else
                    {
                        TextBoxAttitude.Text = "��";
                    }
                    break;
            }
            str2 = table.Rows[0]["Character"].ToString();
            switch (str2)
            {
                case null:
                    break;

                case "5":
                    TextBoxCharacter.Text = "�����";
                    break;

                case "4":
                    TextBoxCharacter.Text = "�Ƚ����";
                    break;

                case "3":
                    TextBoxCharacter.Text = "���";
                    break;

                default:
                    if (!(str2 == "2"))
                    {
                        if (str2 == "1")
                        {
                            TextBoxCharacter.Text = "�ܲ����";
                        }
                    }
                    else
                    {
                        TextBoxCharacter.Text = "�����";
                    }
                    break;
            }
            TextBoxComment.Text = table.Rows[0]["Comment"].ToString();
            TextBoxReplyTime.Text = table.Rows[0]["ReplyTime"].ToString();
            TextBoxReply.Text = table.Rows[0]["Reply"].ToString();
        }
    }
}