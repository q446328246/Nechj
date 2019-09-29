using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;
using ShopNum1MultiEntity;

namespace ShopNum1.MemberWebControl
{
    [ParseChildren(true)]
    public class M_SignIn : BaseMemberWebControl
    {
        private Button ButtonSingin;
        private string skinFilename = "M_SignIn.ascx";

        public M_SignIn()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        private void ButtonSingin_Click(object sender, EventArgs e)
        {
            var action = (ShopNum1_Member_Action) LogicFactory.CreateShopNum1_Member_Action();
            string dayTime = DateTime.Now.ToString("yyyy-MM-dd");
            DataTable table = action.CheckSignin(base.MemLoginID, dayTime);
            if (((table != null) && (table.Rows.Count != 0)) && (Convert.ToInt32(table.Rows[0]["count"]) > 0))
            {
                Page.Response.Write(
                    "<script>alert(\"您今天已签到过了，明天再来吧！\");window.location.href=window.location.href</script>");
            }
            else
            {
                var signIn = new ShopNum1_SignIn
                {
                    guid = Guid.NewGuid(),
                    CreateTime = DateTime.Now,
                    MemLoginID = base.MemLoginID
                };
                if (action.AddSignin(signIn) > 0)
                {
                    string str2 = ShopSettings.GetValue("SignOrSendScore");
                    string str3 = ShopSettings.GetValue("SignRankScore");
                    string str4 = ShopSettings.GetValue("SignScore");
                    if (!(string.IsNullOrEmpty(str2) || (int.Parse(str2) != 1)))
                    {
                        action.UpdateMemberScore(base.MemLoginID, Convert.ToInt32(str3), Convert.ToInt32(str4));
                        method_0(Convert.ToInt32(str4), Convert.ToInt32(str3));
                    }
                    ButtonSingin.Text = "已签到";
                    Page.Response.Write("<script>alert(\"签到成功！\");window.location.href=window.location.href</script>");
                }
            }
        }

        protected override void InitializeSkin(Control skin)
        {
            ButtonSingin = (Button) skin.FindControl("ButtonSingin");
            ButtonSingin.Click += ButtonSingin_Click;
            var action = (ShopNum1_Member_Action) LogicFactory.CreateShopNum1_Member_Action();
            string dayTime = DateTime.Now.ToString("yyyy-MM-dd");
            DataTable table = action.CheckSignin(base.MemLoginID, dayTime);
            if (((table != null) && (table.Rows.Count != 0)) && (Convert.ToInt32(table.Rows[0]["count"]) > 0))
            {
                ButtonSingin.Text = "已签到";
            }
        }

        private void method_0(int int_0, int int_1)
        {
            string str = Common.Common.GetNameById("cast(memberrank as varchar)+'-'+cast(score as varchar)",
                "shopnum1_member", " and memloginid='" + base.MemLoginID + "'");
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
                    CurrentScore = num - int_0,
                    OperateScore = int_0,
                    LastOperateScore = num,
                    Date = DateTime.Now,
                    Memo = "签到送消费红包",
                    MemLoginID = base.MemLoginID,
                    CreateUser = base.MemLoginID,
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
                    CurrentScore = num2 - int_1,
                    OperateScore = int_1,
                    LastOperateScore = num2,
                    Date = DateTime.Now,
                    Memo = "签到送等级红包",
                    MemLoginID = base.MemLoginID,
                    CreateUser = base.MemLoginID,
                    CreateTime = DateTime.Now,
                    IsDeleted = 0
                };
                ((ShopNum1_RankScoreModifyLog_Action) LogicFactory.CreateShopNum1_RankScoreModifyLog_Action())
                    .OperateScore(rankScoreModifyLog);
            }
        }
    }
}