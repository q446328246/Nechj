using System;
using System.Data;
using System.Web.SessionState;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1MultiEntity;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class Group_ProductList : PageBase, IRequiresSessionState
    {
        private readonly ShopNum1_GroupProduct_Action shopNum1_GroupProduct_Action_0 =
            ((ShopNum1_GroupProduct_Action) LogicFactory.CreateShopNum1_GroupProduct_Action());

        public DataTable dt = null;

        private string string_4 = string.Empty;
        private string string_5 = string.Empty;

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            string_5 = CheckGuid.Value.Replace("''", "");
            shopNum1_GroupProduct_Action_0.DeleteButch(string_5);
            BindData();
            var operateLog = new ShopNum1_OperateLog
                {
                    Record = "删除团购活动信息",
                    OperatorID = base.ShopNum1LoginID,
                    IP = Globals.IPAddress,
                    PageName = "Group_ProductList.aspx",
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
                    shopNum1_GroupProduct_Action_0.SelectGroupByAId(pagesize, currentpage, string_4, "3").Rows[0][0]);
            var bll = new PageListBll(rawUrl, true);
            var pl = new PageList1
                {
                    PageSize = Convert.ToInt32(pagesize),
                    PageID = Convert.ToInt32(currentpage),
                    RecordCount = num
                };
            pageDiv.InnerHtml = bll.GetPageListNew(pl);
            dt = shopNum1_GroupProduct_Action_0.SelectGroupByAId(pagesize, currentpage, string_4, "2");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            if (!Page.IsPostBack)
            {
                if (Common.Common.ReqStr("delete") != "")
                {
                    var operateLog = new ShopNum1_OperateLog
                        {
                            Record = "删除团购活动信息",
                            OperatorID = base.ShopNum1LoginID,
                            IP = Globals.IPAddress,
                            PageName = "Group_ProductList.aspx",
                            Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                        };
                    base.OperateLog(operateLog);
                    string_5 = Common.Common.ReqStr("delete");
                    shopNum1_GroupProduct_Action_0.DeleteButch(string_5);
                }
                if (Common.Common.ReqStr("agree") != "")
                {
                    string_5 = Common.Common.ReqStr("agree");
                    shopNum1_GroupProduct_Action_0.UpdateGroupState(string_5, "1");
                    base.Response.Redirect("Group_ProductList.aspx?state=1&Aid=" + Common.Common.ReqStr("Aid"));
                }
                if (Common.Common.ReqStr("disagree") != "")
                {
                    string_5 = Common.Common.ReqStr("disagree");
                    shopNum1_GroupProduct_Action_0.UpdateGroupState(string_5, "2");
                    base.Response.Redirect("Group_ProductList.aspx?state=2&Aid=" + Common.Common.ReqStr("Aid"));
                }
                if ((Common.Common.ReqStr("close") == "true") && (Common.Common.ReqStr("Aid") != ""))
                {
                    string_5 = Common.Common.ReqStr("Aid");
                    shopNum1_GroupProduct_Action_0.UpdateGroupAState(string_5, "3");
                    base.Response.Redirect("Group_ProductList.aspx?state=3&Aid=" + Common.Common.ReqStr("Aid"));
                }
                if (Common.Common.ReqStr("end") != "")
                {
                    string_5 = Common.Common.ReqStr("end");
                    shopNum1_GroupProduct_Action_0.UpdateGroupState(string_5, "3");
                }
                string_4 = " and Aid='" + Common.Common.ReqStr("Aid") + "' ";
                if (Common.Common.ReqStr("state") != "")
                {
                    string_4 = string_4 + "  and state=" + Common.Common.ReqStr("state");
                }
                else
                {
                    string_4 = string_4 + " and state=0";
                }
                BindData();
            }
        }
    }
}