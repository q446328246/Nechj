using System;
using System.Data;
using System.Web.SessionState;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1MultiEntity;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class Group_ActivityList : PageBase, IRequiresSessionState
    {
        private readonly ShopNum1_Activity_Action shopNum1_Activity_Action_0 =
            ((ShopNum1_Activity_Action) LogicFactory.CreateShopNum1_Activity_Action());

        public DataTable dt = null;

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            string strId = CheckGuid.Value.Replace("''", "");
            shopNum1_Activity_Action_0.DeleteActivity(strId);
            var operateLog = new ShopNum1_OperateLog
                {
                    Record = "删除团购活动信息",
                    OperatorID = base.ShopNum1LoginID,
                    IP = Globals.IPAddress,
                    PageName = "Group_ActivityList.aspx",
                    Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                };
            base.OperateLog(operateLog);
            base.Response.Redirect("Group_ActivityList.aspx?PageID=1");
            MessageShow.Visible = true;
            MessageShow.ShowMessage("删除成功！");
        }

        private void BindData()
        {
            PageList1 list;
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
            int num =
                Convert.ToInt32(
                    shopNum1_Activity_Action_0.SelectActivity(pagesize, currentpage, " AND TYPE=1", "0").Rows[0][0]);
            var bll = new PageListBll(rawUrl, true);
            list = new PageList1
                {
                    PageSize = Convert.ToInt32(pagesize),
                    PageID = Convert.ToInt32(currentpage),
                    RecordCount = num,
                    PageCount = num / Convert.ToInt32(pagesize)
                };
            if (list.PageCount < ((list.RecordCount)/((double) list.PageSize)))
            {
                list.PageCount++;
            }
            if (list.PageID > list.PageCount)
            {
                list.PageID = list.PageCount;
            }
            if ((list.PageSize > num) || (list.PageCount == 1))
            {
                showPage.Visible = false;
            }
            else
            {
                showPage.Visible = true;
            }
            pageDiv.InnerHtml = bll.GetPageListNewManage(list);
            dt = shopNum1_Activity_Action_0.SelectActivity(pagesize, currentpage, " AND TYPE=1", "1");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            if (!Page.IsPostBack)
            {
                try
                {
                    string str;
                    if (Common.Common.ReqStr("close") != "")
                    {
                        str = Common.Common.ReqStr("close");
                        shopNum1_Activity_Action_0.CloseActivity(str);
                    }
                    else if (Common.Common.ReqStr("delete") != "")
                    {
                        var operateLog = new ShopNum1_OperateLog
                            {
                                Record = "删除团购活动信息",
                                OperatorID = base.ShopNum1LoginID,
                                IP = Globals.IPAddress,
                                PageName = "Group_ActivityList.aspx",
                                Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                            };
                        base.OperateLog(operateLog);
                        str = Common.Common.ReqStr("delete");
                        shopNum1_Activity_Action_0.DeleteActivity(str);
                    }
                }
                catch
                {
                }
                BindData();
            }
        }
    }
}