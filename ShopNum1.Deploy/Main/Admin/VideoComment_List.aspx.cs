using System;
using System.Data;
using System.Web.SessionState;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1MultiEntity;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class VideoComment_List : PageBase, IRequiresSessionState
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            string str = (Page.Request.QueryString["IsAudit"] == null) ? "0" : Page.Request.QueryString["IsAudit"];
            if (!Page.IsPostBack)
            {
                CheckGuid.Value = (base.Request.QueryString["guid"] == null) ? "0" : base.Request.QueryString["guid"];
                if (CheckGuid.Value != "0")
                {
                    LabelPageTitle.Text = "【 相关视频评论 】";
                }
                BindGrid();
                if (str != "0")
                {
                    DropDownListSIsAudit.SelectedValue = "0";
                }
            }
        }

        protected void BindGrid()
        {
            Num1GridViewShow.DataBind();
        }

        protected void BindStatus()
        {
            var item = new ListItem
                {
                    Text = " -全部-",//LocalizationUtil.GetCommonMessage("All"),
                    Value = "-1"
                };
            DropDownListSIsAudit.Items.Add(item);
            var item2 = new ListItem
                {
                    Text = " 未审核",//LocalizationUtil.GetCommonMessage("NoAudit"),
                    Value = "0"
                };
            DropDownListSIsAudit.Items.Add(item2);
            var item3 = new ListItem
                {
                    Text = " 已审核",//LocalizationUtil.GetCommonMessage("YesAudit"),
                    Value = "1"
                };
            DropDownListSIsAudit.Items.Add(item3);
        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            var action = (ShopNum1_VideoComment_Action) LogicFactory.CreateShopNum1_VideoComment_Action();
            if (action.Delete(CheckGuid.Value) > 0)
            {
                var operateLog = new ShopNum1_OperateLog
                    {
                        Record = "删除成功",
                        OperatorID = base.ShopNum1LoginID,
                        IP = Globals.IPAddress,
                        PageName = "VideoComment_List.aspx",
                        Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                    };
                base.OperateLog(operateLog);
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

        protected void ButtonIsAudit0_Click(object sender, EventArgs e)
        {
            var action = (ShopNum1_VideoComment_Action) LogicFactory.CreateShopNum1_VideoComment_Action();
            var action1 = (ShopNum1_ScoreModifyLog_Action) LogicFactory.CreateShopNum1_ScoreModifyLog_Action();
            var action2 = (ShopNum1_RankScoreModifyLog_Action) LogicFactory.CreateShopNum1_RankScoreModifyLog_Action();
            var action3 = (ShopNum1_Common_Action) LogicFactory.CreateShopNum1_Common_Action();
            if (action.UpdateAuditNot(CheckGuid.Value) > 0)
            {
                var operateLog = new ShopNum1_OperateLog
                    {
                        Record = "取消审核成功",
                        OperatorID = base.ShopNum1LoginID,
                        IP = Globals.IPAddress,
                        PageName = "VideoComment_List.aspx",
                        Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                    };
                base.OperateLog(operateLog);
                BindGrid();
                MessageShow.ShowMessage("Audit2Yes");
                MessageShow.Visible = true;
            }
            else
            {
                MessageShow.ShowMessage("Audit2No");
                MessageShow.Visible = true;
            }
        }

        protected void ButtonIsAudit1_Click(object sender, EventArgs e)
        {
            var action = (ShopNum1_VideoComment_Action) LogicFactory.CreateShopNum1_VideoComment_Action();
            var action1 = (ShopNum1_ScoreModifyLog_Action) LogicFactory.CreateShopNum1_ScoreModifyLog_Action();
            var action2 = (ShopNum1_RankScoreModifyLog_Action) LogicFactory.CreateShopNum1_RankScoreModifyLog_Action();
            var action3 = (ShopNum1_Common_Action) LogicFactory.CreateShopNum1_Common_Action();
            if (action.UpdateAudit(CheckGuid.Value) > 0)
            {
                var operateLog = new ShopNum1_OperateLog
                    {
                        Record = "审核成功",
                        OperatorID = base.ShopNum1LoginID,
                        IP = Globals.IPAddress,
                        PageName = "VideoComment_List.aspx",
                        Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                    };
                base.OperateLog(operateLog);
                BindGrid();
                MessageShow.ShowMessage("Audit1Yes");
                MessageShow.Visible = true;
            }
            else
            {
                MessageShow.ShowMessage("Audit1No");
                MessageShow.Visible = true;
            }
        }

        protected void ButtonReply_Click(object sender, EventArgs e)
        {
            DataTable table =
                ((ShopNum1_VideoComment_Action) LogicFactory.CreateShopNum1_VideoComment_Action()).SearchByGuid(
                    CheckGuid.Value);
            Page.ClientScript.RegisterStartupScript(this.GetType(),"",
                                       "<script> window.open('" +
                                       GetPageName.RetUrl("VideoDetail", table.Rows[0]["VideoGuid"]) + "')</script>");
        }

        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            BindGrid();
        }

        public string ChangeAudit(string strIsAudit)
        {
            if (strIsAudit == "0")
            {
                return "未审核";
            }
            if (strIsAudit == "1")
            {
                return "审核通过";
            }
            if (strIsAudit == "2")
            {
                return "审核未通过";
            }
            return "";
        }

        public string ChangeIsAudit(string strIsAudit)
        {
            if (strIsAudit == "0")
            {
                return " 未审核";//LocalizationUtil.GetChangeMessage("MessageBoard_List", "IsAudit", "0");
            }
            if (strIsAudit == "1")
            {
                return " 已审核";//LocalizationUtil.GetChangeMessage("MessageBoard_List", "IsAudit", "1");
            }
            return "";
        }
    }
}