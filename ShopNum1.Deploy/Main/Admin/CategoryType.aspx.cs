using System;
using System.Data;
using System.Web.SessionState;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class CategoryType : PageBase, IRequiresSessionState
    {
        public DataTable dt_CategoryType = null;

        private void BindData()
        {
            string rawUrl = base.Request.RawUrl;
            if (rawUrl.IndexOf("?") != -1)
            {
                rawUrl = rawUrl.Split(new[] {'?'})[0];
            }
            var list = new PageList1();
            int currentpage = 1;
            int pagesize = 20;
            if (base.Request.QueryString["pagesize"] != null)
            {
                pagesize = Convert.ToInt32(base.Request.QueryString["pagesize"]);
            }
            if (base.Request.QueryString["pageid"] != null)
            {
                currentpage = Convert.ToInt32(base.Request.QueryString["pageid"]);
            }
            var action = new ShopNum1_CategoryType_Action();
            int num3 = Convert.ToInt32(action.SelectCategoryType_List(pagesize, currentpage, "", 0).Rows[0][0]);
            var bll = new PageListBll(rawUrl, true);
            list.PageSize = pagesize;
            list.PageID = currentpage;
            list.RecordCount = num3;
            pageDiv.InnerHtml = bll.GetPageListNewManage(list);
            dt_CategoryType = action.SelectCategoryType_List(pagesize, currentpage, "", 1);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            if (!Page.IsPostBack)
            {
                BindData();
            }
        }
    }
}