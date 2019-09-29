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
    public partial class ShopVedioCommentChecked_List : PageBase, IRequiresSessionState
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            if (!base.IsPostBack)
            {
                this.BindData();
                this.BindGrid();
            }
        }

        protected void BindGrid()
        {
            this.Num1GridViewShow.DataBind();
        }

        protected void ButtonAudit_Click(object sender, EventArgs e)
        {
            ShopNum1_VedioCommentChecked_Action action = (ShopNum1_VedioCommentChecked_Action)LogicFactory.CreateShopNum1_VedioCommentChecked_Action();
            DataTable memLoginIDByGuid = action.GetMemLoginIDByGuid(this.CheckGuid.Value);
            ShopNum1_Member_Action action2 = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
            int rankscore = (ShopSettings.GetValue("MyMessageRankSorce") == string.Empty) ? 0 : int.Parse(ShopSettings.GetValue("MyMessageRankSorce"));
            int score = (ShopSettings.GetValue("MyMessageSorce") == string.Empty) ? 0 : int.Parse(ShopSettings.GetValue("MyMessageSorce"));
            for (int i = 0; i < memLoginIDByGuid.Rows.Count; i++)
            {
                if (!(memLoginIDByGuid.Rows[i]["IsAudit"].ToString() == "1"))
                {
                    action2.UpdateMemberScore(memLoginIDByGuid.Rows[i]["MemLoginID"].ToString(), rankscore, score);
                }
            }
            if (action.UpdateAudit(this.CheckGuid.Value, 1) > 0)
            {
                ShopNum1_OperateLog operateLog = new ShopNum1_OperateLog
                {
                    Record = "管理员审核通过店铺视频评论",
                    OperatorID = base.ShopNum1LoginID,
                    IP = Globals.IPAddress,
                    PageName = "ShopVedioCommentChecked_List.aspx",
                    Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                };
                base.OperateLog(operateLog);
                this.BindGrid();
                this.MessageShow.ShowMessage("Audit2Yes");
                this.MessageShow.Visible = true;
            }
            else
            {
                this.MessageShow.ShowMessage("Audit2No");
                this.MessageShow.Visible = true;
            }
        }

        protected void ButtonCancelAudit_Click(object sender, EventArgs e)
        {
            ShopNum1_VedioCommentChecked_Action action = (ShopNum1_VedioCommentChecked_Action)LogicFactory.CreateShopNum1_VedioCommentChecked_Action();
            if (action.UpdateAudit(this.CheckGuid.Value, 2) > 0)
            {
                ShopNum1_OperateLog operateLog = new ShopNum1_OperateLog
                {
                    Record = "管理员审核不通过店铺视频评论",
                    OperatorID = base.ShopNum1LoginID,
                    IP = Globals.IPAddress,
                    PageName = "ShopVedioCommentChecked_List.aspx",
                    Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                };
                base.OperateLog(operateLog);
                this.BindGrid();
                this.MessageShow.ShowMessage("Audit2Yes");
                this.MessageShow.Visible = true;
            }
            else
            {
                this.MessageShow.ShowMessage("Audit2No");
                this.MessageShow.Visible = true;
            }
        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            ShopNum1_VedioCommentChecked_Action action = (ShopNum1_VedioCommentChecked_Action)LogicFactory.CreateShopNum1_VedioCommentChecked_Action();
            if (action.Delete(this.CheckGuid.Value.ToString()) > 0)
            {
                ShopNum1_OperateLog operateLog = new ShopNum1_OperateLog
                {
                    Record = "管理员删除店铺视频评论",
                    OperatorID = base.ShopNum1LoginID,
                    IP = Globals.IPAddress,
                    PageName = "ShopVedioCommentChecked_List.aspx",
                    Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                };
                base.OperateLog(operateLog);
                this.BindGrid();
                this.MessageShow.ShowMessage("DelYes");
                this.MessageShow.Visible = true;
            }
            else
            {
                this.MessageShow.ShowMessage("DelNo");
                this.MessageShow.Visible = true;
            }
        }

        protected void ButtonReply_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("ShopVedioCommentChecked_Operate.aspx?guid=" + this.CheckGuid.Value + "&Type=Audit");
        }

        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            this.BindGrid();
        }

        public string ChangeIsAudit(object object_0)
        {
            if (object_0.ToString() == "1")
            {
                return "已审核";
            }
            if (object_0.ToString() == "0")
            {
                return "未审核";
            }
            if (object_0.ToString() == "2")
            {
                return "审核未通过";
            }
            return "非法状态";
        }

        public string ChangeIsReply(object object_0)
        {
            if (object_0.ToString() == "1")
            {
                return "已回复";
            }
            if (object_0.ToString() == "0")
            {
                return "未回复";
            }
            return "";
        }

        private void BindData()
        {
            ListItem item = new ListItem
            {
                Text = "-全部-",
                Value = "-2"
            };
            this.DropDownListIsAudit.Items.Add(item);
            ListItem item2 = new ListItem
            {
                Text = "未审核",
                Value = "0"
            };
            this.DropDownListIsAudit.Items.Add(item2);
            ListItem item3 = new ListItem
            {
                Text = "审核未通过",
                Value = "2"
            };
            this.DropDownListIsAudit.Items.Add(item3);
            ListItem item4 = new ListItem
            {
                Text = "-全部-",
                Value = "-1"
            };
            this.DropDownListSIsReply.Items.Add(item4);
            ListItem item5 = new ListItem
            {
                Text = "未回复",
                Value = "0"
            };
            this.DropDownListSIsReply.Items.Add(item5);
            ListItem item6 = new ListItem
            {
                Text = "已回复",
                Value = "1"
            };
            this.DropDownListSIsReply.Items.Add(item6);
        }


    }
}