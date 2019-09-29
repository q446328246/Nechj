using System;
using System.Data;
using System.Web.SessionState;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.ShopBusinessLogic;
using ShopNum1MultiEntity;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class ShopReputation_Operate : PageBase, IRequiresSessionState
    {
        public void Add()
        {
            var reputation = new ShopNum1_ShopReputation
                {
                    Name = TextBoxName.Text,
                    maxScore = int.Parse(TextBoxMaxScore.Text),
                    minScore = int.Parse(TextBoxMinScore.Text),
                    Memo = TextBoxMemo.Text,
                    Pic = HiddenFieldpath.Value,
                    ModifyTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                    ModifyUser = "admin",
                    CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                    CreateUser = "admin",
                    IsDeleted = 0,
                    Type = int.Parse(DropDownListRankType.SelectedValue),
                    Guid = Guid.NewGuid()
                };
            var action = (Shop_Reputation_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_Reputation_Action();
            if (action.Add(reputation) > 0)
            {
                method_7();
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

        protected void ButtonConfirm_Click(object sender, EventArgs e)
        {
            ShopNum1_OperateLog log;
            if (CheckGuid.Value == "0")
            {
                log = new ShopNum1_OperateLog
                    {
                        Record = "新增店铺信誉等级",
                        OperatorID = base.ShopNum1LoginID,
                        IP = Globals.IPAddress,
                        PageName = "ShopReputation_Operate.aspx",
                        Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                    };
                base.OperateLog(log);
                Add();
            }
            else
            {
                log = new ShopNum1_OperateLog
                    {
                        Record = "修改店铺信誉等级",
                        OperatorID = base.ShopNum1LoginID,
                        IP = Globals.IPAddress,
                        PageName = "ShopReputation_Operate.aspx",
                        Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                    };
                base.OperateLog(log);
                method_6();
            }
        }

        private void BindData()
        {
            DataTable table =
                ((Shop_Reputation_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_Reputation_Action()).Search(CheckGuid.Value, 0);
            TextBoxName.Text = table.Rows[0]["name"].ToString();
            HiddenFieldpath.Value = table.Rows[0]["Pic"].ToString();
            TextBoxMaxScore.Text = table.Rows[0]["maxScore"].ToString();
            TextBoxMinScore.Text = table.Rows[0]["minScore"].ToString();
            TextBoxMemo.Text = table.Rows[0]["Memo"].ToString();
            DropDownListRankType.SelectedValue = table.Rows[0]["Type"].ToString();
            RankImage.ImageUrl = table.Rows[0]["Pic"].ToString();
        }

        private void method_6()
        {
            var reputation = new ShopNum1_ShopReputation
                {
                    Name = TextBoxName.Text,
                    maxScore = int.Parse(TextBoxMaxScore.Text),
                    minScore = int.Parse(TextBoxMinScore.Text),
                    Memo = TextBoxMemo.Text,
                    Pic = HiddenFieldpath.Value,
                    ModifyTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                    ModifyUser = "admin",
                    Type = int.Parse(DropDownListRankType.SelectedValue),
                    Guid = new Guid(CheckGuid.Value.Replace("'", ""))
                };
            var action = (Shop_Reputation_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_Reputation_Action();
            if (action.Update(reputation) == 1)
            {
                base.Response.Redirect("ShopReputation_List.aspx");
            }
            else
            {
                MessageShow.ShowMessage("EditNo");
                MessageShow.Visible = true;
            }
        }

        private void method_7()
        {
            TextBoxName.Text = string.Empty;
            TextBoxMinScore.Text = string.Empty;
            TextBoxMaxScore.Text = string.Empty;
            TextBoxMemo.Text = string.Empty;
            HiddenFieldpath.Value = string.Empty;
            DropDownListRankType.SelectedValue = "1";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            if (!base.IsPostBack)
            {
                CheckGuid.Value = (Page.Request.QueryString["guid"] == "0")
                                      ? "0"
                                      : ("'" + base.Request.QueryString["guid"] + "'");
                if (CheckGuid.Value != "0")
                {
                    LabelPageTitle.Text = "修改店铺信誉等级";
                    BindData();
                    ButtonConfirm.Text = "更新";
                }
                else
                {
                    int maxScore = ((Shop_Reputation_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_Reputation_Action()).GetMaxScore();
                    if (maxScore == 0)
                    {
                        TextBoxMinScore.Text = "0";
                    }
                    else
                    {
                        TextBoxMinScore.Text = (maxScore + 1).ToString();
                    }
                }
            }
        }
    }
}