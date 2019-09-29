using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1MultiEntity;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class AdvanceSettlementApplyLog :PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
        }

        protected void ButtonSearch_Click(object sender, EventArgs e)
        {

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
                    Record = "导出结算审核数据",
                    OperatorID = base.ShopNum1LoginID,
                    IP = Globals.IPAddress,
                    PageName = "AdvanceSettlementApplyLog.aspx",
                    Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                };
                base.OperateLog(operateLog);
                HttpCookie cookie =  method_5();
                cookie.Values.Add("reportType", "6");
                cookie.Values.Add("Guids", "-1");
                HttpCookie cookie2 = HttpSecureCookie.Encode(cookie);
                base.Response.AppendCookie(cookie2);
                base.Response.Redirect("Report_CheckV82.aspx?Type=xls");
            }
        }

        public HttpCookie method_5()
        {
            string text = TextBoxMemLoginNO.Text;
            string str2 = TextBoxSRealName.Text;
            string selectedValue = DropdownListSOperateStatus.SelectedValue;
            string str4 = TextBoxSDate1.Text;
            string str5 = TextBoxSDate2.Text;
            var cookie = new HttpCookie("MoneyReportCookie");
            cookie.Values.Add("MemLoginID", text);
            cookie.Values.Add("RealName", str2);
            cookie.Values.Add("State", selectedValue);
            cookie.Values.Add("Sdate", str4);
            cookie.Values.Add("Edate", str5);
            return cookie;
        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {

        }

        public string ChangeOperateStatus(string operateStatus)
        {
            if (operateStatus == "0")
            {
                return " 未发放";// LocalizationUtil.GetChangeMessage("AdvancePaymentApplyLog_List", "OperateStatus", "0");
            }
            if (operateStatus == "1")
            {
                return " 已发放";// LocalizationUtil.GetChangeMessage("AdvancePaymentApplyLog_List", "OperateStatus", "1");
            }
            return "确认状态";
        }

        protected void ButtonProportion_Click(object sender, EventArgs e)
        {
            ShopNum1_AdvancePaymentApplyLog_Action shopNum1_AdvancePaymentApplyLog_Action = new ShopNum1_AdvancePaymentApplyLog_Action();
            
            int num = 0;
            string Settlementid = CheckGuid.Value;
            string No;
            string times;
            string[] id = Settlementid.Replace("'","").Split(',');

            int iPageSize = Num1GridViewShow.PageSize;
            int IpageIndex = Num1GridViewShow.PageIndex;
            for (int i = 0; i < id.Length; i++)
            {
                    string ids = id[i];
                    int currentIndex = Convert.ToInt32(ids) - IpageIndex*iPageSize -1;
                    
                    No = Num1GridViewShow.Rows[currentIndex].Cells[2].Text;
                    times = Num1GridViewShow.Rows[currentIndex].Cells[4].Text;
                    num = shopNum1_AdvancePaymentApplyLog_Action.AllUpdateJsZt(No,times);
            }

            Num1GridViewShow.DataBind();
            //string No;
            //string times;
            //for (int i = 0; i < Num1GridViewShow.Rows.Count; i++)
            //{
               
            //        No = Num1GridViewShow.Rows[i].Cells[2].Text;
            //        times=Num1GridViewShow.Rows[i].Cells[4].Text;

            //}

            
        }

        
    }
}