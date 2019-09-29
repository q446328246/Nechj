using System;
using System.Data;
using System.Web.SessionState;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1MultiEntity;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class Theme_ActivityList : PageBase, IRequiresSessionState
    {
        public DataTable dt = null;
   
        private ShopNum1_Activity_Action shopNum1_Activity_Action_0 = ((ShopNum1_Activity_Action)LogicFactory.CreateShopNum1_Activity_Action());

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            string guid = this.CheckGuid.Value.Replace("''", "");
            this.shopNum1_Activity_Action_0.DeleteThemeActivty(guid);
            base.Response.Redirect("Theme_ActivityList.aspx");
            ShopNum1_OperateLog operateLog = new ShopNum1_OperateLog
            {
                Record = "删除主题活动成功",
                OperatorID = base.ShopNum1LoginID,
                IP = Globals.IPAddress,
                PageName = "Theme_ActivityList.aspx",
                Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
            };
            base.OperateLog(operateLog);
            this.MessageShow.Visible = true;
            this.MessageShow.ShowMessage("删除成功！");
        }

        private void BindData()
        {
            PageList1 list;
            string rawUrl = base.Request.RawUrl;
            if (rawUrl.IndexOf("?") != -1)
            {
                rawUrl = rawUrl.Split(new char[] { '?' })[0];
            }
            string pagesize = "10";
            string currentpage = "1";
            if (ShopNum1.Common.Common.ReqStr("pagesize") != "")
            {
                pagesize = ShopNum1.Common.Common.ReqStr("pagesize");
            }
            if (ShopNum1.Common.Common.ReqStr("pageid") != "")
            {
                currentpage = ShopNum1.Common.Common.ReqStr("pageid");
            }
            int num = Convert.ToInt32(this.shopNum1_Activity_Action_0.SelectThemeActivty(pagesize, currentpage, "", "0").Rows[0][0]);
            PageListBll bll = new PageListBll(rawUrl, true);
            list = new PageList1
            {
                PageSize = Convert.ToInt32(pagesize),
                PageID = Convert.ToInt32(currentpage),
                RecordCount = num,
                PageCount = num / Convert.ToInt32(pagesize)
            };
            if (list.PageCount < (((double)list.RecordCount) / ((double)list.PageSize)))
            {
                list.PageCount++;
            }
            if (list.PageID > list.PageCount)
            {
                list.PageID = list.PageCount;
            }
            if ((list.PageSize > num) || (list.PageCount == 1))
            {
                this.showPage.Visible = false;
            }
            else
            {
                this.showPage.Visible = true;
            }
            this.pageDiv.InnerHtml = bll.GetPageListNewManage(list);
            this.dt = this.shopNum1_Activity_Action_0.SelectThemeActivty(pagesize, currentpage, "", "1");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            if (!this.Page.IsPostBack)
            {
                try
                {
                    if (ShopNum1.Common.Common.ReqStr("close") != "")
                    {
                        string strId = ShopNum1.Common.Common.ReqStr("close");
                        this.shopNum1_Activity_Action_0.CloseActivity(strId);
                    }
                    else if (ShopNum1.Common.Common.ReqStr("delete") != "")
                    {
                        this.shopNum1_Activity_Action_0.DeleteThemeActivty("'" + ShopNum1.Common.Common.ReqStr("delete") + "'");
                        ShopNum1_OperateLog operateLog = new ShopNum1_OperateLog
                        {
                            Record = "删除主题活动成功",
                            OperatorID = base.ShopNum1LoginID,
                            IP = Globals.IPAddress,
                            PageName = "Theme_ActivityList.aspx",
                            Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                        };
                        base.OperateLog(operateLog);
                        this.MessageShow.Visible = true;
                        this.MessageShow.ShowMessage("删除成功！");
                    }
                }
                catch
                {
                }
                this.BindData();
            }
        }
    }
}