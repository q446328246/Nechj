using System;
using System.Data;
using System.Web.SessionState;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1MultiEntity;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class Theme_ProductList : PageBase, IRequiresSessionState
    {
        private readonly ShopNum1_Activity_Action shopNum1_Activity_Action_0 =
            ((ShopNum1_Activity_Action) LogicFactory.CreateShopNum1_Activity_Action());

        public DataTable dt = null;

        private string string_4 = string.Empty;
        private string string_5 = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            if (!Page.IsPostBack)
            {
                ShopNum1_OperateLog log;
                if (Common.Common.ReqStr("delete") != "")
                {
                    log = new ShopNum1_OperateLog
                        {
                            Record = "删除主题商品成功",
                            OperatorID = base.ShopNum1LoginID,
                            IP = Globals.IPAddress,
                            PageName = "Theme_ProductList.aspx",
                            Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                        };
                    base.OperateLog(log);
                    string_5 = Common.Common.ReqStr("delete");
                    shopNum1_Activity_Action_0.DeleteThemeActivtyProduct("'" + string_5 + "'");
                    base.Response.Redirect("Theme_ProductList.aspx?state=3&Aid=" + Common.Common.ReqStr("Aid"));
                }
                if (Common.Common.ReqStr("agree") != "")
                {
                    log = new ShopNum1_OperateLog
                        {
                            Record = "主题商品审核通过",
                            OperatorID = base.ShopNum1LoginID,
                            IP = Globals.IPAddress,
                            PageName = "Theme_ProductList.aspx",
                            Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                        };
                    base.OperateLog(log);
                    string_5 = Common.Common.ReqStr("agree");
                    shopNum1_Activity_Action_0.UpdateThemeProductIsAudit(string_5, "1");
                    base.Response.Redirect("Theme_ProductList.aspx?state=0&Aid=" + Common.Common.ReqStr("Aid"));
                }
                if (Common.Common.ReqStr("disagree") != "")
                {
                    log = new ShopNum1_OperateLog
                        {
                            Record = "主题商品审核未通过",
                            OperatorID = base.ShopNum1LoginID,
                            IP = Globals.IPAddress,
                            PageName = "Theme_ProductList.aspx",
                            Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                        };
                    base.OperateLog(log);
                    string_5 = Common.Common.ReqStr("disagree");
                    shopNum1_Activity_Action_0.UpdateThemeProductIsAudit(string_5, "2");
                    base.Response.Redirect("Theme_ProductList.aspx?state=0&Aid=" + Common.Common.ReqStr("Aid"));
                }
                if ((Common.Common.ReqStr("close") == "true") && (Common.Common.ReqStr("Aid") != ""))
                {
                    string_5 = Common.Common.ReqStr("Aid");
                    shopNum1_Activity_Action_0.UpdateThemeProductByThemeGuid(string_5, "3");
                }
                if (Common.Common.ReqStr("end") != "")
                {
                    log = new ShopNum1_OperateLog
                        {
                            Record = "主题商品活动结束",
                            OperatorID = base.ShopNum1LoginID,
                            IP = Globals.IPAddress,
                            PageName = "Theme_ProductList.aspx",
                            Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                        };
                    base.OperateLog(log);
                    string_5 = Common.Common.ReqStr("end");
                    shopNum1_Activity_Action_0.UpdateThemeProductIsAudit(string_5, "3");
                    base.Response.Redirect("Theme_ProductList.aspx?state=1&Aid=" + Common.Common.ReqStr("Aid"));
                }
                string_4 = " and ThemeGuid='" + Common.Common.ReqStr("Aid") + "' ";
                if (Common.Common.ReqStr("state") != "")
                {
                    string_4 = string_4 + "  and IsAudit=" + Common.Common.ReqStr("state");
                }
                else
                {
                    string_4 = string_4 + " and IsAudit=0";
                }
                BindData();
            }
        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            string_5 = CheckGuid.Value.Replace("''", "");
            shopNum1_Activity_Action_0.DeleteThemeActivtyProduct(string_5);
            BindData();
            var operateLog = new ShopNum1_OperateLog
                {
                    Record = "删除主题商品成功",
                    OperatorID = base.ShopNum1LoginID,
                    IP = Globals.IPAddress,
                    PageName = "Theme_ProductList.aspx",
                    Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                };
            base.OperateLog(operateLog);
            MessageShow.Visible = true;
            MessageShow.ShowMessage("删除成功！");
            BindData();
        }

        private void BindData()
        {
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
                    shopNum1_Activity_Action_0.SelectThemeActivtyProduct(pagesize, currentpage, string_4, "0").Rows[0][0
                        ]);
            var bll = new PageListBll(rawUrl, true);
            var pl = new PageList1
                {
                    PageSize = Convert.ToInt32(pagesize),
                    PageID = Convert.ToInt32(currentpage),
                    RecordCount = num
                };
            pageDiv.InnerHtml = bll.GetPageListNew(pl);
            dt = shopNum1_Activity_Action_0.SelectThemeActivtyProduct(pagesize, currentpage, string_4, "1");
        }
    }
}