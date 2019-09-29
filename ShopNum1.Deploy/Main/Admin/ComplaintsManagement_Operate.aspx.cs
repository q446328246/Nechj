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
    public partial class ComplaintsManagement_Operate : PageBase, IRequiresSessionState
    {
        protected void ButtonBack_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("ComplaintsManagement_List.aspx");
        }

        protected void ButtonConfirm_Click(object sender, EventArgs e)
        {
            var action = (ShopNum1_MemberReport_Action)LogicFactory.CreateShopNum1_MemberReport_Action();
            var memberReport = new ShopNum1_MemberReport
                {
                    ProcessingTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                    ProcessingResults = TextBoxResult.Text,
                    ProcessingStatus = 2,
                    OperateUser = base.ShopNum1LoginID,
                    ID = int.Parse(hiddenGuid.Value.Replace("'", ""))
                };
            if (action.addReply(memberReport) > 0)
            {
                HttpCookie cookie = base.Request.Cookies["AdminLoginCookie"];
                HttpCookie cookie2 = HttpSecureCookie.Decode(cookie);

                var operateLog = new ShopNum1_OperateLog
                    {
                        Record = "回复举报信息",
                        OperatorID = cookie2.Values["LoginID"].ToString(),
                        IP = Globals.IPAddress,
                        PageName = "ComplaintsManagement_Operate.aspx",
                        Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                    };
                base.OperateLog(operateLog);
                MessageBox.Show("处理完成");
                TextBoxResult.Enabled = false;
                ButtonConfirm.Enabled = false;
            }
            else
            {
                MessageBox.Show("处理失败");
            }
            method_5();
        }

        private void method_5()
        {
            DataTable complaintsManagement =
                ((ShopNum1_MemberReport_Action)LogicFactory.CreateShopNum1_MemberReport_Action())
                    .GetComplaintsManagement(hiddenGuid.Value);
            if (complaintsManagement.Rows.Count > 0)
            {
                HyperLinkProductLink.Text = complaintsManagement.Rows[0]["ProductUrl"].ToString();
                HyperLinkProductLink.NavigateUrl = "http://" +
                                                   complaintsManagement.Rows[0]["ProductUrl"].ToString()
                                                                                             .Replace("http://", "");
                ReplyImage.Src = complaintsManagement.Rows[0]["ComplaintImage"].ToString();
                LabelReplyTime.Text = complaintsManagement.Rows[0]["ComplaintTime"].ToString();
                LabelMemLoginID.Text = complaintsManagement.Rows[0]["MemLoginID"].ToString();
                LabelShopID.Text = complaintsManagement.Rows[0]["ReportShop"].ToString();
                Labelguid.Text = complaintsManagement.Rows[0]["ID"].ToString();
                LabelReportTime.Text = complaintsManagement.Rows[0]["ReportTime"].ToString();
                LabelProcessingTime.Text = complaintsManagement.Rows[0]["ProcessingTime"].ToString();
                ImageEvidence.ImageUrl = complaintsManagement.Rows[0]["EvidenceImage"].ToString();
                switch (complaintsManagement.Rows[0]["ProcessingStatus"].ToString())
                {
                    case "0":
                        LabelProcessingState.Text = "未处理";
                        break;

                    case "1":
                        LabelProcessingState.Text = "处理中";
                        break;

                    case "2":
                        LabelProcessingState.Text = "已处理";
                        TextBoxResult.ReadOnly = true;
                        ButtonConfirm.Enabled = false;
                        break;
                }
                LabelProcessingResult.Text = complaintsManagement.Rows[0]["ProcessingResults"].ToString();
                LabelEvidence.Text = complaintsManagement.Rows[0]["Evidence"].ToString();
                LabelComplaintContent.Text = complaintsManagement.Rows[0]["ComplaintContent"].ToString();
                TextBoxResult.Text = complaintsManagement.Rows[0]["ProcessingResults"].ToString();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            hiddenGuid.Value = (base.Request.QueryString["guid"] == null) ? "" : base.Request.QueryString["guid"];
            if (!base.IsPostBack)
            {
                method_5();
                Processing();
                method_5();
            }
        }

        public void Processing()
        {
            if (LabelProcessingState.Text == "未处理")
            {
                var action = (ShopNum1_MemberReport_Action)LogicFactory.CreateShopNum1_MemberReport_Action();
                try
                {
                    action.UpdateProcessingStatus(hiddenGuid.Value.Replace("'", ""), 1);
                }
                catch (Exception)
                {
                    MessageBox.Show("系统错误！");
                }
            }
        }
    }
}