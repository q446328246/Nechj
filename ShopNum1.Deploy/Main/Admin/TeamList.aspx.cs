using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.Common;
using ShopNum1MultiEntity;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class TeamList : PageBase
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            if (base.checkadmin()) {
                TextIsadmin.Value = "1";
            }
        }
        protected void ButtonReportAll_Click(object sender, EventArgs e)
        {
            if (Num1GridViewShow.Rows.Count < 1)
            {
                MessageBox.Show("当前无导出的记录！");
            }
            else
            {
                var operateLog = new ShopNum1_OperateLog
                {
                    Record = "导出领导人变更记录",
                    OperatorID = base.ShopNum1LoginID,
                    IP = Globals.IPAddress,
                    PageName = "RexodMemberLogo.aspx",
                    Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                };
                base.OperateLog(operateLog);
                HttpCookie cookie = method_5();
                cookie.Values.Add("reportType", "13");
                cookie.Values.Add("Guids", "-1");
                HttpCookie cookie2 = HttpSecureCookie.Encode(cookie);
                base.Response.AppendCookie(cookie2);
                base.Response.Redirect("Report_CheckV82.aspx?Type=xls");
            }
        }
        protected void ButtonSearch_Click(object sender, EventArgs e)
        {

        }
        public HttpCookie method_5()
        {
            string text = TextBoxMemLoginNO.Text;

            string str4 = TextMobile.Text;
            
            var cookie = new HttpCookie("MoneyReportCookie");
            cookie.Values.Add("MemLoginID", text);
            cookie.Values.Add("Mobile", text);
            
            return cookie;
        }
    }
}