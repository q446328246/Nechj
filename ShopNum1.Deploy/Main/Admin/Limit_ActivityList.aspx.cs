using System;
using System.Data;
using System.Web.SessionState;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1MultiEntity;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class Limit_ActivityList : PageBase, IRequiresSessionState
    {
        private readonly ShopNum1_Activity_Action shopNum1_Activity_Action_0 =
            ((ShopNum1_Activity_Action) LogicFactory.CreateShopNum1_Activity_Action());

        public DataTable dt = null;

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            shopNum1_Activity_Action_0.DeleteActivity(CheckGuid.Value);
            var operateLog = new ShopNum1_OperateLog
                {
                    Record = "限时折扣活动删除成功",
                    OperatorID = base.ShopNum1LoginID,
                    IP = Globals.IPAddress,
                    PageName = "Limit_ActivityList.aspx",
                    Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                };
            base.OperateLog(operateLog);
            MessageShow.Visible = true;
            MessageShow.ShowMessage("批量删除成功！");
            BindData();
        }

        private void BindData()
        {
            PageList1 list;
            string condition = " AND TYPE=2";
            string rawUrl = base.Request.RawUrl;
            if (rawUrl.IndexOf("?") != -1)
            {
                rawUrl = rawUrl.Split(new[] {'?'})[0];
            }
            string pagesize = "10";
            string currentpage = "1";
            if (Common.Common.ReqStr("pagesize") != "")
            {
                pagesize = Common.Common.ReqStr("pagesize");
            }
            if (Common.Common.ReqStr("pageid") != "")
            {
                currentpage = Common.Common.ReqStr("pageid");
            }
            int num2 =
                Convert.ToInt32(
                    shopNum1_Activity_Action_0.SelectActivity(pagesize, currentpage, condition, "0").Rows[0][0]);
            var bll = new PageListBll(rawUrl, true);
            list = new PageList1
                {
                    PageSize = Convert.ToInt32(pagesize),
                    PageID = Convert.ToInt32(currentpage),
                    RecordCount = num2,
                    PageCount = num2 / Convert.ToInt32(pagesize)
                };
            if (list.PageCount < ((list.RecordCount)/((double) list.PageSize)))
            {
                list.PageCount++;
            }
            if (Convert.ToInt32(currentpage) > list.PageCount)
            {
                currentpage = list.PageCount.ToString();
            }
            pageDiv.InnerHtml = bll.GetPageListNewManage(list);
            dt = shopNum1_Activity_Action_0.SelectActivity(pagesize, currentpage, condition, "1");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            ShopNum1_OperateLog log;
            if (Common.Common.ReqStr("agree") != "")
            {
                log = new ShopNum1_OperateLog
                    {
                        Record = "限时折扣活动审核成功",
                        OperatorID = base.ShopNum1LoginID,
                        IP = Globals.IPAddress,
                        PageName = "Limit_ActivityList.aspx",
                        Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                    };
                base.OperateLog(log);
                shopNum1_Activity_Action_0.UpdateActivityState(Common.Common.ReqStr("agree"), "1");
            }
            if (Common.Common.ReqStr("disagree") != "")
            {
                log = new ShopNum1_OperateLog
                    {
                        Record = "限时折扣活动审核未成功",
                        OperatorID = base.ShopNum1LoginID,
                        IP = Globals.IPAddress,
                        PageName = "Limit_ActivityList.aspx",
                        Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                    };
                base.OperateLog(log);
                shopNum1_Activity_Action_0.UpdateActivityState(Common.Common.ReqStr("disagree"), "2");
            }
            if (Common.Common.ReqStr("delete") != "")
            {
                log = new ShopNum1_OperateLog
                    {
                        Record = "限时折扣活动删除成功",
                        OperatorID = base.ShopNum1LoginID,
                        IP = Globals.IPAddress,
                        PageName = "Limit_ActivityList.aspx",
                        Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                    };
                base.OperateLog(log);
                shopNum1_Activity_Action_0.DeleteActivity(Common.Common.ReqStr("delete"));
                MessageShow.Visible = true;
                MessageShow.ShowMessage("DelYes");
            }
            if (!Page.IsPostBack)
            {
                BindData();
            }
        }
    }
}