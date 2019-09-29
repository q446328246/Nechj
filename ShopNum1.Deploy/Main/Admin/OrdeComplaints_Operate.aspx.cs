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
    public partial class OrdeComplaints_Operate : PageBase, IRequiresSessionState
    {
        protected void ButtonBack_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("OrdeComplaints_List.aspx");
        }

        protected void ButtonSure_Click(object sender, EventArgs e)
        {
              HttpCookie cookie = base.Request.Cookies["AdminLoginCookie"];
                    HttpCookie cookie2 = HttpSecureCookie.Decode(cookie);
                    
            var action = (ShopNum1_OrdeComplaints_Action) LogicFactory.CreateShopNum1_OrdeComplaints_Action();
            var orderComplaint = new ShopNum1_OrderComplaint
                {
                    ProcessingTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                    ProcessingResults = TextBoxProcessingResult.Text,
                    ProcessingStatus = 2,
                    ID = int.Parse(hiddenGuid.Value.Replace("'", "")),
                    OperateUser = cookie2.Values["LoginID"].ToString()
                };
            if (action.addReply(orderComplaint) > 0)
            {
                var operateLog = new ShopNum1_OperateLog
                    {
                        Record = "回复投诉评论",
                        OperatorID = cookie2.Values["LoginID"].ToString(),
                        IP = Globals.IPAddress,
                        PageName = "OrdeComplaints_Operate.aspx",
                        Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                    };
                base.OperateLog(operateLog);
                MessageBox.Show("处理完成");
            }
            else
            {
                MessageBox.Show("处理失败");
            }
            method_5();
        }

        private void method_5()
        {
            DataTable orderComplaintsDetails =
                ((ShopNum1_OrdeComplaints_Action) LogicFactory.CreateShopNum1_OrdeComplaints_Action())
                    .GetOrderComplaintsDetails(hiddenGuid.Value.Replace("'", ""));
            if (orderComplaintsDetails.Rows.Count > 0)
            {
                LabelName.Text = orderComplaintsDetails.Rows[0]["OrderID"].ToString();
                LabelMemLoginID.Text = orderComplaintsDetails.Rows[0]["MemLoginID"].ToString();
                LabelShopID.Text = orderComplaintsDetails.Rows[0]["ComplaintShop"].ToString();
                Labelguid.Text = orderComplaintsDetails.Rows[0]["ID"].ToString();
                LabelComplaintTime.Text = orderComplaintsDetails.Rows[0]["ComplaintTime"].ToString();
                LabelProcessingTime.Text = orderComplaintsDetails.Rows[0]["ProcessingTime"].ToString();
                switch (orderComplaintsDetails.Rows[0]["ProcessingStatus"].ToString())
                {
                    case "0":
                        LabelProcessingState.Text = "未处理";
                        break;

                    case "1":
                        LabelProcessingState.Text = "处理中";
                        break;

                    case "2":
                        LabelProcessingState.Text = "已处理";
                        TextBoxProcessingResult.ReadOnly = true;
                        ButtonSure.Enabled = false;
                        break;
                }
                LabelEvidence.Text = orderComplaintsDetails.Rows[0]["Evidence"].ToString();
                ImageEvidence.ImageUrl = orderComplaintsDetails.Rows[0]["EvidenceImage"].ToString();
                LabelComplaintContent.Text = orderComplaintsDetails.Rows[0]["AppealContent"].ToString();
                TextBoxProcessingResult.Text = orderComplaintsDetails.Rows[0]["ProcessingResults"].ToString();
                ComplaintImage.ImageUrl = orderComplaintsDetails.Rows[0]["AppealImage"].ToString();
                DataTable orderGuidAndTypeByOrderNum =
                    ((ShopNum1_OrderInfo_Action) LogicFactory.CreateShopNum1_OrderInfo_Action())
                        .GetOrderGuidAndTypeByOrderNum(LabelName.Text.Trim());
                if ((orderGuidAndTypeByOrderNum != null) && (orderGuidAndTypeByOrderNum.Rows.Count > 0))
                {
                    string str2 = orderGuidAndTypeByOrderNum.Rows[0]["Guid"].ToString();
                    if (orderGuidAndTypeByOrderNum.Rows[0]["OrderType"].ToString() == "0")
                    {
                        HyperLinkOrderDetail.NavigateUrl = "Order_Operate.aspx?Guid=" + str2;
                    }
                    else if (orderGuidAndTypeByOrderNum.Rows[0]["OrderType"].ToString() == "1")
                    {
                        HyperLinkOrderDetail.NavigateUrl = "OrderSpell_Operate.aspx?Guid" + str2;
                    }
                    else if (orderGuidAndTypeByOrderNum.Rows[0]["OrderType"].ToString() == "2")
                    {
                        HyperLinkOrderDetail.NavigateUrl = "OrderPanic_List.aspx?Guid=" + str2;
                    }
                    else
                    {
                        HyperLinkOrderDetail.NavigateUrl = "";
                    }
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            hiddenGuid.Value = (base.Request.QueryString["guid"] == null) ? "" : base.Request.QueryString["guid"];
            if (!base.IsPostBack)
            {
                method_5();
            }
        }
    }
}