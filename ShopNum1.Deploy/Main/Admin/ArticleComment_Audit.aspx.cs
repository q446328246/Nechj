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
    public partial class ArticleComment_Audit : PageBase, IRequiresSessionState
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            if (!Page.IsPostBack)
            {
                CheckGuid.Value = (base.Request.QueryString["guid"] == null) ? "0" : base.Request.QueryString["guid"];
                if (CheckGuid.Value != "0")
                {
                    LabelPageTitle.Text = "【 资讯评论审核 】";
                }
                BindGrid();
                BindStatus();
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
            DropDownListSIsReply.Items.Add(item);
            var item2 = new ListItem
                {
                    Text = " 未回复",//LocalizationUtil.GetCommonMessage("NoReply"),
                    Value = "0"
                };
            DropDownListSIsReply.Items.Add(item2);
            var item3 = new ListItem
                {
                    Text = " 已回复",//LocalizationUtil.GetCommonMessage("IsReply"),
                    Value = "1"
                };
            DropDownListSIsReply.Items.Add(item3);
            var item4 = new ListItem
                {
                    Text = " -全部-",//LocalizationUtil.GetCommonMessage("All"),
                    Value = "-2"
                };
            DropDownListSIsAudit.Items.Add(item4);
            var item5 = new ListItem
                {
                    Text = " 未审核",//LocalizationUtil.GetCommonMessage("NoAudit"),
                    Value = "0"
                };
            DropDownListSIsAudit.Items.Add(item5);
            var item6 = new ListItem
                {
                    Text = "审核未通过",
                    Value = "2"
                };
            DropDownListSIsAudit.Items.Add(item6);
        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            var action = (ShopNum1_ArticleComment_Action) LogicFactory.CreateShopNum1_ArticleComment_Action();
            if (action.Delete(CheckGuid.Value) > 0)
            {
                var operateLog = new ShopNum1_OperateLog
                    {
                        Record = "删除成功",
                        OperatorID = base.ShopNum1LoginID,
                        IP = Globals.IPAddress,
                        PageName = "ArticleComment_List.aspx",
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
            var action = (ShopNum1_ArticleComment_Action) LogicFactory.CreateShopNum1_ArticleComment_Action();
            if (action.UpdateAudit(CheckGuid.Value, 2) > 0)
            {
                var operateLog = new ShopNum1_OperateLog
                    {
                        Record = "取消审核成功",
                        OperatorID = base.ShopNum1LoginID,
                        IP = Globals.IPAddress,
                        PageName = "ArticleComment_List.aspx",
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
            var action = (ShopNum1_ArticleComment_Action) LogicFactory.CreateShopNum1_ArticleComment_Action();
            DataTable articleCommentInfoByGuid = action.GetArticleCommentInfoByGuid(CheckGuid.Value);
            if (action.UpdateAudit(CheckGuid.Value, 1) > 0)
            {
                int num2 = 0;
                int num3 = 0;
                try
                {
                    num2 = int.Parse(ShopSettings.GetValue("ArticleCommentRankSorce"));
                }
                catch
                {
                    num2 = 0;
                }
                try
                {
                    num3 = int.Parse(ShopSettings.GetValue("ArticleCommentSorce"));
                }
                catch
                {
                    num2 = 0;
                }
                var action2 = (ShopNum1_ArticleComment_Action) LogicFactory.CreateShopNum1_ArticleComment_Action();
                for (int i = 0; i < articleCommentInfoByGuid.Rows.Count; i++)
                {
                    if (!(articleCommentInfoByGuid.Rows[i]["IsAudit"].ToString() == "1"))
                    {
                        action2.UpdateScoreByCommentArticle(articleCommentInfoByGuid.Rows[i]["MemLoginID"].ToString(),
                                                            num2.ToString(), num3.ToString());
                    }
                }
                var operateLog = new ShopNum1_OperateLog
                    {
                        Record = "审核成功",
                        OperatorID = base.ShopNum1LoginID,
                        IP = Globals.IPAddress,
                        PageName = "ArticleComment_List.aspx",
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
            base.Response.Redirect("ArticleComment_Reply.aspx?guid=" + CheckGuid.Value);
        }

        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            BindGrid();
        }

        public string ChangeIsAudit(string strIsAudit)
        {
            if (strIsAudit == "0")
            {
                return "未审核"; //LocalizationUtil.GetChangeMessage("MessageBoard_List", "IsAudit", "0");
            }
            if (strIsAudit == "1")
            {
                return "已审核"; //LocalizationUtil.GetChangeMessage("MessageBoard_List", "IsAudit", "1");
            }
            if (strIsAudit == "2")
            {
                return "审核未通过";
            }
            return "非法状态";
        }

        public string ChangeIsReply(string strIsReply)
        {
            if (strIsReply == "0")
            {
                return " 未回复"; //LocalizationUtil.GetChangeMessage("MessageBoard_List", "IsReply", "0");
            }
            if (strIsReply == "1")
            {
                return "已回复"; //LocalizationUtil.GetChangeMessage("MessageBoard_List", "IsReply", "1");
            }
            return "非法状态";
        }
    }
}