using System;
using System.Data;
using System.Web.SessionState;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1MultiEntity;
using System.Web;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class ShopProductCommentAudit_List : PageBase, IRequiresSessionState
    {
        protected void BindGrid()
        {
            Num1GridViewShow.DataBind();
        }

        protected void ButtonAudit_Click(object sender, EventArgs e)
        {
            var action = (ShopNum1_ProductComment_Action) LogicFactory.CreateShopNum1_ProductComment_Action();
            var action2 = (ShopNum1_ShopInfoList_Action) LogicFactory.CreateShopNum1_ShopInfoList_Action();
            DataTable commentTypeByGuid = action.GetCommentTypeByGuid(CheckGuid.Value);
            string s = (ShopSettings.GetValue("GoodAppraiseReputation") == string.Empty)
                           ? "0"
                           : ShopSettings.GetValue("GoodAppraiseReputation");
            string str = (ShopSettings.GetValue("StandardAppraiseReputation") == string.Empty)
                             ? "0"
                             : ShopSettings.GetValue("StandardAppraiseReputation");
            string str2 = (ShopSettings.GetValue("BadAppraiseReputation") == string.Empty)
                              ? "0"
                              : ShopSettings.GetValue("BadAppraiseReputation");
            int score = 0;
            var action3 = (ShopNum1_Member_Action) LogicFactory.CreateShopNum1_Member_Action();
            int rankscore = (ShopSettings.GetValue("MyProductCommentRankSorce") == string.Empty)
                                ? 0
                                : int.Parse(ShopSettings.GetValue("MyProductCommentRankSorce"));
            int num3 = (ShopSettings.GetValue("MyProductCommentSorce") == string.Empty)
                           ? 0
                           : int.Parse(ShopSettings.GetValue("MyProductCommentSorce"));
            for (int i = 0; i < commentTypeByGuid.Rows.Count; i++)
            {
                if (commentTypeByGuid.Rows[i]["IsAudit"].ToString() != "1")
                {
                    if (commentTypeByGuid.Rows[i]["CommentType"].ToString() == "5")
                    {
                        score = int.Parse(s);
                    }
                    else if (commentTypeByGuid.Rows[i]["CommentType"].ToString() == "3")
                    {
                        score = int.Parse(str);
                    }
                    else if (commentTypeByGuid.Rows[i]["CommentType"].ToString() == "1")
                    {
                        score = -int.Parse(str2);
                    }
                    action2.UpdateShopReputationByMemLoginID(commentTypeByGuid.Rows[i]["ShopLoginId"].ToString(), score);
                    action3.UpdateMemberScore(commentTypeByGuid.Rows[i]["MemLoginID"].ToString(), rankscore, num3);
                    method_5(num3, rankscore, commentTypeByGuid.Rows[i]["MemLoginID"].ToString());
                }
            }
              HttpCookie cookie = base.Request.Cookies["AdminLoginCookie"];
                    HttpCookie cookie2 = HttpSecureCookie.Decode(cookie);
               
                    
            var operateLog = new ShopNum1_OperateLog
                {
                    Record = "管理员审核通过商品评论",
                    OperatorID = cookie2.Values["LoginID"].ToString(),
                    IP = Globals.IPAddress,
                    PageName = "ShopProductCommentAudit_List.aspx",
                    Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                };
            base.OperateLog(operateLog);
            if (action.UpdateProductAudit(CheckGuid.Value, "1") > 0)
            {
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

        protected void ButtonCancelAudit_Click(object sender, EventArgs e)
        {
            var action = (ShopNum1_ProductComment_Action) LogicFactory.CreateShopNum1_ProductComment_Action();
              HttpCookie cookie = base.Request.Cookies["AdminLoginCookie"];
                    HttpCookie cookie2 = HttpSecureCookie.Decode(cookie);
                    
            var operateLog = new ShopNum1_OperateLog
                {
                    Record = "管理员审核不通过商品评论",
                    OperatorID = cookie2.Values["LoginID"].ToString(),
                    IP = Globals.IPAddress,
                    PageName = "ShopProductCommentAudit_List.aspx",
                    Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                };
            base.OperateLog(operateLog);
            if (action.UpdateProductAudit(CheckGuid.Value, "2") > 0)
            {
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

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            var action = (ShopNum1_ProductComment_Action) LogicFactory.CreateShopNum1_ProductComment_Action();
            if (action.DeleteProduct(CheckGuid.Value) > 0)
            {
                  HttpCookie cookie = base.Request.Cookies["AdminLoginCookie"];
                    HttpCookie cookie2 = HttpSecureCookie.Decode(cookie);
                   
                var operateLog = new ShopNum1_OperateLog
                    {
                        Record = "管理员删除待审核商品评论",
                        OperatorID = cookie2.Values["LoginID"].ToString(),
                        IP = Globals.IPAddress,
                        PageName = "ShopProductCommentAudit_List.aspx",
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

        protected void ButtonDeleteBylink_Click(object sender, EventArgs e)
        {
            var button = (LinkButton) sender;
            string guids = "'" + button.CommandArgument + "'";
            var action = (ShopNum1_ProductComment_Action) LogicFactory.CreateShopNum1_ProductComment_Action();
            if (action.DeleteProduct(guids) > 0)
            {
                  HttpCookie cookie = base.Request.Cookies["AdminLoginCookie"];
                    HttpCookie cookie2 = HttpSecureCookie.Decode(cookie);
                    
                var operateLog = new ShopNum1_OperateLog
                    {
                        Record = "管理员删除待审核商品评论",
                        OperatorID = cookie2.Values["LoginID"].ToString(),
                        IP = Globals.IPAddress,
                        PageName = "ShopProductCommentAudit_List.aspx",
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

        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            BindGrid();
        }

        protected void ButtonSearchDetail_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("ShopProductComment_Detail.aspx?Guid=" + CheckGuid.Value + "&Type=Audit");
        }

        public string Is(object object_0)
        {
            if (object_0.ToString() == "1")
            {
                return "已审核";
            }
            if (object_0.ToString() == "0")
            {
                return "未审核";
            }
            return "审核未通过";
        }

        private void method_5(int int_0, int int_1, string string_4)
        {
            string str = Common.Common.GetNameById("cast(memberrank as varchar)+'-'+cast(score as varchar)",
                                                   "shopnum1_member", " and memloginid='" + string_4 + "'");
            int num = 0;
            int num2 = 0;
            if ((str != "") && (str.IndexOf("-") != -1))
            {
                num = Convert.ToInt32(str.Split(new[] {'-'})[1]);
                num2 = Convert.ToInt32(str.Split(new[] {'-'})[0]);
            }
            if (int_0 > 0)
            {
                var scoreModeLog = new ShopNum1_ScoreModifyLog
                    {
                        Guid = Guid.NewGuid(),
                        OperateType = 1,
                        CurrentScore = num,
                        OperateScore = int_0,
                        LastOperateScore = int_0,
                        Date = DateTime.Now,
                        Memo = "买家评论送消费红包",
                        MemLoginID = string_4,
                        CreateUser = string_4,
                        CreateTime = DateTime.Now,
                        IsDeleted = 0
                    };
                ((ShopNum1_ScoreModifyLog_Action) LogicFactory.CreateShopNum1_ScoreModifyLog_Action()).OperateScore(
                    scoreModeLog);
            }
            if (int_1 > 0)
            {
                var rankScoreModifyLog = new ShopNum1_RankScoreModifyLog
                    {
                        Guid = Guid.NewGuid(),
                        OperateType = 1,
                        CurrentScore = num2,
                        OperateScore = int_1,
                        LastOperateScore = int_1,
                        Date = DateTime.Now,
                        Memo = "买家评论送等级红包",
                        MemLoginID = string_4,
                        CreateUser = string_4,
                        CreateTime = DateTime.Now,
                        IsDeleted = 0
                    };
                ((ShopNum1_RankScoreModifyLog_Action) LogicFactory.CreateShopNum1_RankScoreModifyLog_Action())
                    .OperateScore(rankScoreModifyLog);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            if (!base.IsPostBack)
            {
                BindGrid();
            }
        }
    }
}