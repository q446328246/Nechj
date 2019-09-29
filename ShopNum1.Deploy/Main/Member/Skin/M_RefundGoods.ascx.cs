using System;
using System.Data;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Deploy.App_Code;
using ShopNum1.Email;
using ShopNum1.Factory;
using ShopNum1MultiEntity;
using ShopNum1.Common.ShopNum1.Common;

namespace ShopNum1.Deploy.Main.Member.Skin
{
    public partial class M_RefundGoods : BaseMemberControl
    {
        protected void btnSubmit_Click(object sender, EventArgs e)
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
            DataTable ordertimetable = action.SelectOrderTime(hidProductGuID.Value);
            DateTime OrderTime = Convert.ToDateTime(ordertimetable.Rows[0]["PayTime"]);
            string CategoryID = ordertimetable.Rows[0]["shop_category_id"].ToString();
            string OrderNumber = ordertimetable.Rows[0]["OrderNumber"].ToString();
            string MJmember = ordertimetable.Rows[0]["MemLoginID"].ToString();
            string OrderType = "";


            string strr = "M_OrderList.aspx";
            DateTime d1 = DateTime.Now;
            TimeSpan d3 = d1.Subtract(OrderTime);
            ShopNum1_Member_Action MemberAction = (ShopNum1_Member_Action) LogicFactory.CreateShopNum1_Member_Action();
            DataTable Usertable=MemberAction.SearchMembertwo(MJmember);
            string MJmemberNo=Usertable.Rows[0]["MemLoginNO"].ToString();
            




            if (d3.Days>7)
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "tip", "<script>alert('付款时间大于7天后，不能申请退款！');location.href='" + strr + "';</script>");
                return;
            }
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
            if (CategoryID != "5"&&CategoryID != "2")
            {

                //int re3G = action.ReFund3Gorder(OrderNumber, MJmemberNo, Convert.ToDecimal(ordertimetable.Rows[0]["Score_pv_a"]));
                int re3G = 1;
                if (re3G == 0)
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "tip", "<script>alert('会员网积分不足，不能申请退款！');location.href='" + strr + "';</script>");
                    return;
                }
            }


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
                    #region 退款接口
                    try
                    {
                        if (CategoryID == "1")
                        {
                            OrderType = "2";
                        }
                        else if (CategoryID == "2" || CategoryID == "9")
                        {
                            OrderType = "3";
                        }
                        else if (CategoryID == "4" || CategoryID == "5")
                        {
                            OrderType = "4";
                            
                        }
                        else if (CategoryID == "6" || CategoryID == "7")
                        {
                            OrderType = "4";
                            
                        }
                        var memaction = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
                        String Guid = memaction.GetGuidByMemLoginID(MJmember);
                        DataTable tableTJ = memaction.SearchMemberGuid(Guid);
                        string TjNO = tableTJ.Rows[0]["Superior"].ToString();
                        string ZSno = tableTJ.Rows[0]["MemLoginNO"].ToString();
                        if (OrderType != "4" && (TjNO != null || TjNO != "")) 
                        {

                            String TjGuid = memaction.GetGuidByMemLoginNO(TjNO);
                            DataTable Tjtable = memaction.SearchMemberGuid(TjGuid);
                            string memberRank = Tjtable.Rows[0]["MemberRankGuid"].ToString();
                            if (ZSno.ToUpper().IndexOf("C") != -1)
                            {
                                memberRank = tableTJ.Rows[0]["MemberRankGuid"].ToString();
                            }
                            if (memberRank.ToUpper() != MemberLevel.NORMAL_MEMBER_ID.ToUpper())
                            {
                                string MemNO = tableTJ.Rows[0]["MemLoginNO"].ToString();
                                string TJMemLoginNO;
                                if (MemNO.ToUpper().IndexOf("C") != -1)
                                {
                                    TJMemLoginNO = MemNO;
                                }
                                else
                                {

                                    TJMemLoginNO = tableTJ.Rows[0]["Superior"].ToString();
                                }
                                TJAPIzl.MemberServiceSoapClient mms = new TJAPIzl.MemberServiceSoapClient();
                                string md5_one = ShopNum1.Common.MD5JiaMi.MyMd5JiaMi;
                                string privateKey_two = "Number=" + TJMemLoginNO + "&OrderID=" + OrderNumber + "&OrderType=" + OrderType + md5_one;
                                string md5Check_two = ShopNum1.Common.MD5JiaMi.Md5JiaMi(privateKey_two);
                                string fh = mms.MemberOrderBack(TJMemLoginNO, OrderNumber, OrderType, md5Check_two);
                                ShopNum1_Order_Refuse_Action orderrefuseaction = (ShopNum1_Order_Refuse_Action)LogicFactory.CreateShopNum1_Order_Refuse_Action();
                                ShopNum1_Order_Refuse orderrefuse = new ShopNum1_Order_Refuse();
                                orderrefuse.OrderID = OrderNumber;
                                orderrefuse.MemberloginID = MJmember;
                                orderrefuse.Remark = fh;
                                orderrefuse.Status = "0";
                                orderrefuse.EndTime = DateTime.Now.ToString();
                                orderrefuse.AdminID = "退款";
                                orderrefuseaction.Add(orderrefuse);

                            }



                        }


                    }
                    catch (Exception ex)
                    {


                    }
                    #endregion
                }
                else
                {
                    ((ShopNum1_OrderInfo_Action) LogicFactory.CreateShopNum1_OrderInfo_Action()).UpdateOrderState(
                        hidProductGuID.Value, base.MemLoginID, "", "3", "", "1", "0");
                    OrderOperateLog("", "买家申请退货", "等待卖家处理");
                    #region 退款接口
                    try
                    {
                        if (CategoryID == "1")
                        {
                            OrderType = "2";
                        }
                        else if (CategoryID == "2" || CategoryID == "9")
                        {
                            OrderType = "3";
                        }
                        else if (CategoryID == "4" || CategoryID == "5")
                        {
                            OrderType = "4";

                        }
                        else if (CategoryID == "6" || CategoryID == "7")
                        {
                            OrderType = "4";

                        }
                        var memaction = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
                        String Guid = memaction.GetGuidByMemLoginID(MJmember);
                        DataTable tableTJ = memaction.SearchMemberGuid(Guid);
                        string TjNO = tableTJ.Rows[0]["Superior"].ToString();
                        string ZSno = tableTJ.Rows[0]["MemLoginNO"].ToString();
                        if (OrderType != "4" && (TjNO != null || TjNO != ""))
                        {

                            String TjGuid = memaction.GetGuidByMemLoginNO(TjNO);
                            DataTable Tjtable = memaction.SearchMemberGuid(TjGuid);
                            string memberRank = Tjtable.Rows[0]["MemberRankGuid"].ToString();
                            if (ZSno.ToUpper().IndexOf("C") != -1)
                            {
                                memberRank = tableTJ.Rows[0]["MemberRankGuid"].ToString();
                            }
                            if (memberRank.ToUpper() != MemberLevel.NORMAL_MEMBER_ID.ToUpper())
                            {
                                string MemNO = tableTJ.Rows[0]["MemLoginNO"].ToString();
                                string TJMemLoginNO;
                                if (MemNO.ToUpper().IndexOf("C") != -1)
                                {
                                    TJMemLoginNO = MemNO;
                                }
                                else
                                {

                                    TJMemLoginNO = tableTJ.Rows[0]["Superior"].ToString();
                                }
                                TJAPIzl.MemberServiceSoapClient mms = new TJAPIzl.MemberServiceSoapClient();
                                string md5_one = ShopNum1.Common.MD5JiaMi.MyMd5JiaMi;
                                string privateKey_two = "Number=" + TJMemLoginNO + "&OrderID=" + OrderNumber + "&OrderType=" + OrderType + md5_one;
                                string md5Check_two = ShopNum1.Common.MD5JiaMi.Md5JiaMi(privateKey_two);
                                string fh = mms.MemberOrderBack(TJMemLoginNO, OrderNumber, OrderType, md5Check_two);
                                ShopNum1_Order_Refuse_Action orderrefuseaction = (ShopNum1_Order_Refuse_Action)LogicFactory.CreateShopNum1_Order_Refuse_Action();
                                ShopNum1_Order_Refuse orderrefuse = new ShopNum1_Order_Refuse();
                                orderrefuse.OrderID = OrderNumber;
                                orderrefuse.MemberloginID = MJmember;
                                orderrefuse.Remark = fh;
                                orderrefuse.Status = "1";
                                orderrefuse.EndTime = DateTime.Now.ToString();
                                orderrefuse.AdminID = "退款";
                                orderrefuseaction.Add(orderrefuse);

                            }



                        }


                    }
                    catch (Exception ex)
                    {


                    }
                    #endregion
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

        protected void Page_Load(object sender, EventArgs e)
        {
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

        protected void BindData()
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
                txtmoney.Value = Common.Common.GetNameById("shouldpayprice", "shopnum1_orderinfo",
                    " and memloginId='" + base.MemLoginID + "' and guid='" +
                    str.Split(new[] { '|' })[2] + "'");

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