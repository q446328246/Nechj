using System;
using System.Data;
using System.Web.SessionState;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1MultiEntity;
using System.Web;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class AdvancePaymentStatistics_List : PageBase, IRequiresSessionState
    {
        protected void BindGrid()
        {
            try
            {
                Num1GridViewShow.DataBind();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        protected void ButtonReport_Click(object sender, EventArgs e)
        {
            var operateLog = new ShopNum1_OperateLog
                {
                    Record = "导出金币（BV）统计数据",
                    OperatorID = base.ShopNum1LoginID,
                    IP = Globals.IPAddress,
                    PageName = "AdvancePaymentStatistics_List.aspx",
                    Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                };

            base.OperateLog(operateLog);
            HttpCookie cookie = method_5();
            HttpCookie cookie2 = HttpSecureCookie.Encode(cookie);
            base.Response.AppendCookie(cookie2);

            Page.Response.Redirect("AdvancePaymentStatistics_Report.aspx?Type=xls");
        }

        public HttpCookie method_5()
        {
            //string selectedValue =  DropdownListSOperateType.SelectedValue;
            var cookie = new HttpCookie("MoneyReportCookie");
            //cookie.Values.Add("operateType", selectedValue);
            return cookie;
        }


        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            BindGrid();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            if (!Page.IsPostBack)
            {
                BindGrid();
            }
            //DataTable allAdvancePayment =((ShopNum1_Member_Action) LogicFactory.CreateShopNum1_Member_Action()).GetAllAdvancePayment(-1,Convert.ToInt32(DropdownListSOperateType.SelectedValue));
            //if ((allAdvancePayment != null) && (allAdvancePayment.Rows.Count > 0))
            //{
            //    if (!string.IsNullOrEmpty(allAdvancePayment.Rows[0][0].ToString()))
            //    {
            //        LabelMoney.Text = allAdvancePayment.Rows[0][0].ToString();
            //    }
            //    else
            //    {
            //        LabelMoney.Text = "0";
            //    }
            //}
            //else
            //{
            //    LabelMoney.Text = "0";
            //}
            //try
            //{
            //    string str = Common.Common.GetNameById("SUM(LockAdvancePayment)", "ShopNum1_Member", " AND 1=1");
            //    if (!string.IsNullOrEmpty(str))
            //    {
            //        LabelLockAdvancePayment.Text = str;
            //    }
            //    else
            //    {
            //        LabelLockAdvancePayment.Text = "0";
            //    }
            //}
            //catch (Exception)
            //{
            //    LabelLockAdvancePayment.Text = "0";
            //}
        }
    }
}