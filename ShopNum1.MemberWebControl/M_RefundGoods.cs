using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Email;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;
using ShopNum1MultiEntity;

namespace ShopNum1.MemberWebControl
{
    [ParseChildren(true)]
    public class M_RefundGoods : BaseMemberWebControl
    {
        private Button btnReturnDetail;
        private Button btnSubmit;
        private HtmlInputHidden hidImgPath;
        private HtmlInputHidden hidIsReceive;
        private HtmlInputHidden hidLogisticName;
        private HtmlInputHidden hidLogisticNumber;
        private HtmlInputHidden hidProductGuID;
        private HtmlInputHidden hidRefundReason;
        private HtmlInputHidden hidRefundType;
        private HtmlInputHidden hidShopId;
        private HtmlInputHidden hidorderstatus;
        private Label lblExit;
        private Label lblState;
        private Label lblmoney;
        private HtmlSelect selisreceive;
        private HtmlSelect selrefundCase;
        private HtmlImage showimg;
        private string skinFilename = "M_RefundGoods.ascx";
        private HtmlTableRow trReason;
        private HtmlTableRow trstate;
        private HtmlTextArea txtIntroduce;
        private HtmlTextArea txtReason;
        private HtmlInputText txtmoney;

        public M_RefundGoods()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            var refund = new ShopNum1_Refund
            {
                ApplyTime = DateTime.Now,
                MemLoginID = base.MemLoginID,
                OrderID = hidProductGuID.Value,
                ProductGuid = new Guid(hidProductGuID.Value),
                ShopID = hidShopId.Value
            };
            var action = (ShopNum1_OrderInfo_Action) LogicFactory.CreateShopNum1_OrderInfo_Action();
            if (action.SearchOrderInfoByOrderId(hidProductGuID.Value, "shipmentstatus") == "0")
            {
                refund.IsReceive = 0;
            }
            else
            {
                refund.IsReceive = int.Parse(hidIsReceive.Value);
                refund.LogisticName = hidLogisticName.Value;
                refund.LogisticNumber = hidLogisticNumber.Value;
            }
            refund.RefundMoney = Convert.ToDecimal(txtmoney.Value);
            refund.RefundID = DateTime.Now.ToString("yyyyMMddHHmmss");
            refund.RefundReason = hidRefundReason.Value;
            if (Common.Common.ReqStr("op") != "")
            {
                if (Common.Common.ReqStr("op").IndexOf("exitmoney") != -1)
                {
                    refund.RefundType = 0;
                }
                else
                {
                    refund.RefundType = 1;
                }
            }
            refund.RefundStatus = 0;
            refund.RefundContent = txtIntroduce.Value;
            refund.RefundImg = hidImgPath.Value;
            var action3 = (ShopNum1_Refund_Action) LogicFactory.CreateShopNum1_Refund_Action();
            int num = 0;
            if (btnSubmit.Text == "编辑")
            {
                num = action3.Update(refund);
            }
            else
            {
                action3.DeleteRefundByOrId(refund.OrderID);
                num = action3.Add(refund);
            }
            if (num > 0)
            {
                if (refund.RefundType == 0)
                {
                    var action2 = (ShopNum1_OrderInfo_Action) LogicFactory.CreateShopNum1_OrderInfo_Action();
                    OrderOperateLog("", "买家申请退款", "等待卖家处理");
                    action2.UpdateOrderState(hidProductGuID.Value, base.MemLoginID, "", "", "2", "1", "0");
                }
                else
                {
                    ((ShopNum1_OrderInfo_Action) LogicFactory.CreateShopNum1_OrderInfo_Action()).UpdateOrderState(
                        hidProductGuID.Value, base.MemLoginID, "", "3", "", "1", "0");
                    OrderOperateLog("", "买家申请退货", "等待卖家处理");
                }
                if (ShopSettings.GetValue("CancelOrderIsEmail") == "1")
                {
                    IsEmail(refund.OrderID, base.MemLoginID);
                }
            }
            string str = "M_OrderList.aspx";
            if (Page.Request.Url.ToString().IndexOf("lifeorder") != -1)
            {
                str = "M_LifeOrderList.aspx";
            }
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(),"tip", "<script>alert('操作成功！');location.href='" + str + "';</script>");
        }

        protected override void InitializeSkin(Control skin)
        {
            lblState = (Label) skin.FindControl("lblState");
            trstate = (HtmlTableRow) skin.FindControl("trstate");
            trReason = (HtmlTableRow) skin.FindControl("trReason");
            showimg = (HtmlImage) skin.FindControl("showimg");
            hidRefundReason = (HtmlInputHidden) skin.FindControl("hidRefundReason");
            hidIsReceive = (HtmlInputHidden) skin.FindControl("hidIsReceive");
            hidProductGuID = (HtmlInputHidden) skin.FindControl("hidProductGuID");
            hidRefundType = (HtmlInputHidden) skin.FindControl("hidRefundType");
            hidShopId = (HtmlInputHidden) skin.FindControl("hidShopId");
            lblmoney = (Label) skin.FindControl("lblmoney");
            lblExit = (Label) skin.FindControl("lblExit");
            selisreceive = (HtmlSelect) skin.FindControl("selisreceive");
            selrefundCase = (HtmlSelect) skin.FindControl("selrefundCase");
            txtIntroduce = (HtmlTextArea) skin.FindControl("txtIntroduce");
            txtmoney = (HtmlInputText) skin.FindControl("txtmoney");
            hidImgPath = (HtmlInputHidden) skin.FindControl("hidImgPath");
            btnSubmit = (Button) skin.FindControl("btnSubmit");
            btnSubmit.Click += btnSubmit_Click;
            btnReturnDetail = (Button) skin.FindControl("btnReturnDetail");
            hidorderstatus = (HtmlInputHidden) skin.FindControl("hidorderstatus");
            hidLogisticName = (HtmlInputHidden) skin.FindControl("hidLogisticName");
            hidLogisticNumber = (HtmlInputHidden) skin.FindControl("hidLogisticNumber");
            txtReason = (HtmlTextArea) skin.FindControl("txtReason");
            BindData();
        }

        protected void IsEmail(string ordernum, string MemLoginID)
        {
            DataTable orderInfoByGuid =
                ((ShopNum1_OrderInfo_Action) LogicFactory.CreateShopNum1_OrderInfo_Action()).GetOrderInfoByGuid(ordernum);
            if ((orderInfoByGuid.Rows[0]["Email"] != null) && !(orderInfoByGuid.Rows[0]["Email"].ToString() == ""))
            {
                string str = orderInfoByGuid.Rows[0]["Email"].ToString();
                string str2 = ShopSettings.GetValue("Name");
                var stute = new UpdateOrderStute();
                stute.Name = MemLoginID; // = MemLoginID);
                stute.OrderNumber = ordernum;
                stute.UpdateTime = DateTime.Now.ToString();
                stute.SysSendTime = DateTime.Now.ToString();
                stute.ShopName = str2;
                string s = string.Empty;
                string str4 = string.Empty;
                string str5 = "3b924290-4cf7-4013-9ea4-d2e3a0bfd4b2";
                DataTable editInfo =
                    ((ShopNum1_Email_Action) LogicFactory.CreateShopNum1_Email_Action()).GetEditInfo("'" + str5 + "'", 0);
                if (editInfo.Rows.Count > 0)
                {
                    s = editInfo.Rows[0]["Remark"].ToString();
                    str4 = editInfo.Rows[0]["Title"].ToString();
                }
                s =
                    s.Replace("{$Name}", stute.Name)
                        .Replace("{$OrderNumber}", stute.OrderNumber)
                        .Replace("{$ShopName}", stute.ShopName)
                        .Replace("{$SendTime}", DateTime.Now.ToString());
                string str6 = stute.ChangeUpdateOrderStute(Page.Server.HtmlDecode(s));
                new SendEmail().Emails(str, MemLoginID, str4, str5, str6);
            }
        }

        private void BindData()
        {
            if (Common.Common.ReqStr("op").IndexOf("|") != -1)
            {
                string str = Common.Common.ReqStr("op");
                hidorderstatus.Value = str.Split(new[] {'@'})[1];
                hidProductGuID.Value = str.Split(new[] {'|'})[2];
                if (str.Split(new[] {'|'})[0] == "exitgoods")
                {
                    lblExit.Text = "退货";
                }
                hidShopId.Value = Common.Common.GetNameById("shopid", "shopnum1_orderinfo",
                    " and memloginId='" + base.MemLoginID +
                    "' and guid='" + str.Split(new[] {'|'})[2] + "'");
                lblmoney.Text = Common.Common.GetNameById("shouldpayprice", "shopnum1_orderinfo",
                    " and memloginId='" + base.MemLoginID + "' and guid='" +
                    str.Split(new[] {'|'})[2] + "'");
            }
            if (Common.Common.ReqStr("view").IndexOf("|") != -1)
            {
                btnSubmit.Text = "编辑";
                trstate.Visible = true;
                string str2 = Common.Common.ReqStr("view");
                hidorderstatus.Value = str2.Split(new[] {'@'})[1];
                DataTable table =
                    ((ShopNum1_Refund_Action) LogicFactory.CreateShopNum1_Refund_Action()).SelectRefundInfo(
                        str2.Split(new[] {'|'})[2], base.MemLoginID, "0");
                if (str2.Split(new[] {'|'})[0] == "exitgoods")
                {
                    lblExit.Text = "退货";
                }
                lblmoney.Text = Common.Common.GetNameById("shouldpayprice", "shopnum1_orderinfo",
                    " and memloginId='" + base.MemLoginID + "' and guid='" +
                    str2.Split(new[] {'|'})[2] + "'");
                hidProductGuID.Value = str2.Split(new[] {'|'})[2];
                if (table.Rows.Count > 0)
                {
                    lblState.Text = RefundStatus(table.Rows[0]["RefundStatus"].ToString(),
                        table.Rows[0]["RefundType"].ToString());
                    txtReason.Value = table.Rows[0]["onpassreason"].ToString();
                    if (table.Rows[0]["RefundStatus"].ToString() == "1")
                    {
                        btnSubmit.Visible = false;
                    }
                    hidRefundType.Value = table.Rows[0]["RefundType"].ToString();
                    hidRefundReason.Value = table.Rows[0]["refundreason"].ToString();
                    txtmoney.Value = table.Rows[0]["RefundMoney"].ToString();
                    txtIntroduce.Value = table.Rows[0]["RefundContent"].ToString();
                    showimg.Src = table.Rows[0]["RefundImg"].ToString();
                    hidImgPath.Value = table.Rows[0]["RefundImg"].ToString();
                    hidIsReceive.Value = table.Rows[0]["IsReceive"].ToString();
                    hidLogisticName.Value = table.Rows[0]["LogisticName"].ToString();
                    hidLogisticNumber.Value = table.Rows[0]["LogisticNumber"].ToString();
                }
            }
        }

        protected void OrderOperateLog(string memo, string CurrentStateMsg, string NextStateMsg)
        {
            if (!string.IsNullOrEmpty(hidProductGuID.Value))
            {
                var orderOperateLog = new ShopNum1_OrderOperateLog
                {
                    Guid = Guid.NewGuid(),
                    OrderInfoGuid = new Guid(hidProductGuID.Value),
                    OderStatus = 1,
                    ShipmentStatus = 0,
                    PaymentStatus = 0,
                    CurrentStateMsg = CurrentStateMsg,
                    NextStateMsg = NextStateMsg,
                    Memo = memo,
                    OperateDateTime = DateTime.Now,
                    IsDeleted = 0,
                    CreateUser = base.MemLoginID
                };
                ((ShopNum1_OrderOperateLog_Action) LogicFactory.CreateShopNum1_OrderOperateLog_Action()).Add(
                    orderOperateLog);
            }
        }

        protected string RefundStatus(string status, string rtype)
        {
            string str = "退款";
            if (rtype == "1")
            {
                str = "退货";
            }
            string str3 = status;
            switch (str3)
            {
                case null:
                    break;

                case "0":
                    return (str + "申请等待卖家确认中");

                case "1":
                    trReason.Visible = true;
                    return (str + "成功");

                default:
                    if (!(str3 == "2"))
                    {
                        if (str3 == "3")
                        {
                            trReason.Visible = true;
                            return ("平台介入" + str + "成功");
                        }
                    }
                    else
                    {
                        return ("卖家拒绝" + str);
                    }
                    break;
            }
            return "";
        }
    }
}