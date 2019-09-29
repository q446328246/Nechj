using System;
using System.Data;
using System.Web.SessionState;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1MultiEntity;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class MemberRank_Operate : PageBase, IRequiresSessionState
    {
        protected void ButtonConfirm_Click(object sender, EventArgs e)
        {
            ShopNum1_OperateLog log;
            if (CheckGuid.Value == "0")
            {
                log = new ShopNum1_OperateLog
                    {
                        Record = "管理员新增会员等级",
                        OperatorID = base.ShopNum1LoginID,
                        IP = Globals.IPAddress,
                        PageName = "MemberRank_Operate.aspx",
                        Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                    };
                base.OperateLog(log);
                method_7();
            }
            else
            {
                log = new ShopNum1_OperateLog
                    {
                        Record = "管理员修改会员等级",
                        OperatorID = base.ShopNum1LoginID,
                        IP = Globals.IPAddress,
                        PageName = "MemberRank_Operate.aspx",
                        Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                    };
                base.OperateLog(log);
                method_6();
            }
        }

        private void BindData()
        {
            DataTable table =
                ((ShopNum1_MemberRank_Action)LogicFactory.CreateShopNum1_MemberRank_Action()).Search(
                    CheckGuid.Value, 0);
            TextBoxName.Text = table.Rows[0]["name"].ToString();
            TextBoxpath.Text = table.Rows[0]["Pic"].ToString();
            TextBoxMaxScore.Text = table.Rows[0]["maxScore"].ToString();
            TextBoxMinScore.Text = table.Rows[0]["minScore"].ToString();
            TextBoxMemo.Text = table.Rows[0]["Memo"].ToString();
            ImageOriginalImge.Src = table.Rows[0]["Pic"].ToString();
            if (table.Rows[0]["IsDefault"].ToString() == "1")
            {
                CheckBoxIsDefault.Checked = true;
            }
        }

        private void method_6()
        {
            var memberRank = new ShopNum1_MemberRank
                {
                    Name = TextBoxName.Text,
                    maxScore = int.Parse(TextBoxMaxScore.Text),
                    minScore = int.Parse(TextBoxMinScore.Text),
                    Memo = TextBoxMemo.Text
                };
            string text = TextBoxpath.Text;
            memberRank.Pic = text;
            if (CheckBoxIsDefault.Checked)
            {
                memberRank.IsDefault = 1;
            }
            else
            {
                memberRank.IsDefault = 0;
            }
            memberRank.ModifyTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            memberRank.ModifyUser = "admin";
            memberRank.Guid = new Guid(CheckGuid.Value.Replace("'", ""));
            var action = (ShopNum1_MemberRank_Action)LogicFactory.CreateShopNum1_MemberRank_Action();
            if (action.Update(memberRank) == 1)
            {
                base.Response.Redirect("MemberRank_List.aspx");
            }
            else
            {
                MessageShow.ShowMessage("EditNo");
                MessageShow.Visible = true;
            }
        }

        private void method_7()
        {
            var memberRank = new ShopNum1_MemberRank
                {
                    Name = TextBoxName.Text,
                    maxScore = int.Parse(TextBoxMaxScore.Text),
                    minScore = int.Parse(TextBoxMinScore.Text),
                    Memo = TextBoxMemo.Text
                };
            string text = TextBoxpath.Text;
            memberRank.Pic = text;
            memberRank.ModifyTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            memberRank.ModifyUser = "admin";
            memberRank.CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            memberRank.CreateUser = "admin";
            if (CheckBoxIsDefault.Checked)
            {
                memberRank.IsDefault = 1;
            }
            else
            {
                memberRank.IsDefault = 0;
            }
            memberRank.IsDeleted = 0;
            memberRank.Guid = Guid.NewGuid();
            var action = (ShopNum1_MemberRank_Action)LogicFactory.CreateShopNum1_MemberRank_Action();
            if (action.Add(memberRank) > 0)
            {
                method_8();
                MessageShow.ShowMessage("AddYes");
                MessageShow.Visible = true;
            }
            else
            {
                MessageShow.ShowMessage("AddNo");
                MessageShow.Visible = true;
            }
            int maxScore = action.GetMaxScore();
            if (maxScore == 0)
            {
                TextBoxMinScore.Text = "0";
            }
            else
            {
                TextBoxMinScore.Text = (maxScore + 1).ToString();
            }
        }

        private void method_8()
        {
            TextBoxName.Text = string.Empty;
            TextBoxMinScore.Text = string.Empty;
            TextBoxMaxScore.Text = string.Empty;
            TextBoxMemo.Text = string.Empty;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            if (!base.IsPostBack)
            {
                CheckGuid.Value = (Page.Request.QueryString["guid"] == "0")
                                      ? "0"
                                      : base.Request.QueryString["guid"];
                if (CheckGuid.Value != "0")
                {
                    LabelPageTitle.Text = "修改会员等级";
                    BindData();
                }
                else
                {
                    int maxScore =
                        ((ShopNum1_MemberRank_Action)LogicFactory.CreateShopNum1_MemberRank_Action()).GetMaxScore();
                    if (maxScore == 0)
                    {
                        TextBoxMinScore.Text = "0";
                    }
                    else
                    {
                        TextBoxMinScore.Text = "999999998";
                        // = (maxScore + 1).ToString();
                    }
                }
            }
        }
    }
}