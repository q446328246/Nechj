using System;
using System.Web;
using System.Web.SessionState;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1MultiEntity;


namespace ShopNum1.Deploy.Api
{
    /// <summary>
    /// CategoryType 的摘要说明
    /// </summary>
    public class CategoryType : PageBase, IHttpHandler, IRequiresSessionState
    {

        new public void ProcessRequest(HttpContext context)
        {
            var ShopNum1_ct = new ShopNum1_CategoryType_Action();
            if (context.Request.QueryString["oid"] != null)
            {
                string str = context.Request.QueryString["oid"];
                try
                {
                    ShopNum1_ct.update_CategoryType_Order(str.Split('|')[0], str.Split('|')[1]);
                    context.Response.Write("ok");
                }
                catch
                {
                    context.Response.Write("error");
                }
            }
            else if (context.Request.QueryString["delBatchId"] != null)
            {
                try
                {
                    string strDelBatchId = context.Request.QueryString["delBatchId"];
                    ShopNum1_ct.DeleteBatch_CategoryType(strDelBatchId);
                    HttpCookie cookie = context.Request.Cookies["AdminLoginCookie"];
                    HttpCookie cookie2 = HttpSecureCookie.Decode(cookie);
                    
                    #region  操作日志部分

                    var operateLog = new ShopNum1_OperateLog();
                    operateLog.Record = "管理员删除商品类型";
                    operateLog.OperatorID = cookie2.Values["LoginID"].ToString();
                    operateLog.IP = Globals.IPAddress;
                    operateLog.PageName = "CategoryType.aspx";
                    operateLog.Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    int log = OperateLog(operateLog);

                    #endregion

                    context.Response.Write("ok");
                }
                catch
                {
                    context.Response.Write("error");
                }
            }
        }

        new public bool IsReusable
        {
            get { return false; }
        }
    }
}