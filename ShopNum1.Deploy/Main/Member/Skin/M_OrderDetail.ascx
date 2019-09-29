<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="M_OrderDetail.ascx.cs"
    Inherits="ShopNum1.Deploy.Main.Member.Skin.M_OrderDetail" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="ShopNum1.Deploy.Main.Member.Skin" %>
<script type="text/javascript" language="javascript">
    $(function () {
        //控制状态选中
        var state = $("#<%=hidOrderState.ClientID%>").val();
        for (var i = 0; i < 4; i++) {
            $("#select" + state).removeClass("settab" + i);
        }
        $("#select" + state).addClass("settab" + state);
        switch (state) {
            case "0": $("#payupdate0").show(); break;
            case "1": $("#payupdate1").show(); break;
            case "2": $("#payupdate3").show(); break;
            case "3": $("#payupdate4").show(); break;
        }
        $("#<%=butEditPay.ClientID%>").click(function () {
            $("#dwindow").show();
        });
        //支付选中
        $("input[name='radio_pay']").click(function () {
            $("#<%=hidPayMentInfo.ClientID%>").val($(this).val() + "|" + $(this).attr("pay_Name") + "|" + $(this).attr("pay_Charge") + "|" + $(this).attr("pay_IsPercent"));
        });

        var hidpaystate = parseInt($("#<%=hidPayState.ClientID%>").val());
        var hidshipstate = parseInt($("#<%=hidShipState.ClientID%>").val());
        var hidrefundstatus = parseInt($("#<%=hidRefundstatus.ClientID%>").val());
        var hidRefundType = parseInt($("#<%=hidRefundType.ClientID%>").val());
        if (hidpaystate > 1 || hidshipstate > 2 || hidrefundstatus > 0) {
            $("#payupdate").hide(); $("#<%=butSureConfirm.ClientID%>").hide(); $("#payupdate3").hide();
        }
        if ((hidshipstate == "5" || hidshipstate == "1" || hidpaystate == "2") && (hidrefundstatus == "1" || hidrefundstatus == "2") && state == "2") {
            $("#payupdate").show(); $("#<%=butSureConfirm.ClientID%>").show(); $("#payupdate3").show();
        }
        if (hidrefundstatus == "1" && state == "1" && hidRefundType == "0") {
            $("#refundtxt").text(", 该订单正在退款...");
            $("#<%=lblOrderStateTxt.ClientID%>").text($("#<%=lblOrderStateTxt.ClientID%>").text() + ",退款中...");
        }
        if (hidrefundstatus == "2" && state == "1" && hidRefundType == "0") {
            $("#refundtxt").html(", 卖家拒绝退款,您可以点击<a target=\"_blank\" href=\"m_index.aspx?tomurl=M_MemberComplaints.aspx?shopid=" + $("#<%=lblMemLoginId.ClientID%>").text() + "|" + $("#<%=lblOrderNumber.ClientID%>").text() + "\">【投诉】</a>,请求平台处理。");
            $("#<%=lblOrderStateTxt.ClientID%>").text($("#<%=lblOrderStateTxt.ClientID%>").text() + ",卖家拒绝退款.");
        }
        if (hidrefundstatus == "1" && state == "2" && hidRefundType == "1") {
            $("#vexitstate").text(", 该订单正在退货..."); $("#payupdate3").show(); $("#<%=butSureConfirm.ClientID%>").show();
            $("#<%=lblOrderStateTxt.ClientID%>").text($("#<%=lblOrderStateTxt.ClientID%>").text() + ",退货中...");
        }
        if (hidrefundstatus == "2" && state == "2" && hidRefundType == "1") {
            $("#vexitstate").html(", 卖家拒绝退货,您可以点击<a target=\"_blank\" href=\"m_index.aspx?tomurl=M_MemberComplaints.aspx?shopid=" + $("#<%=lblMemLoginId.ClientID%>").text() + "|" + $("#<%=lblOrderNumber.ClientID%>").text() + "\">【投诉】</a>,请求平台处理。");
            $("#<%=lblOrderStateTxt.ClientID%>").text($("#<%=lblOrderStateTxt.ClientID%>").text() + ",卖家拒绝退货.");
        }
        if ($("#<%=hidlifetype.ClientID%>").val() == "2") {
            $("#hideAddress").hide();
            $(".hidpaystate").hide(); $(".showlife").show(); $("#payupdate3").hide();
            $("#lifetypestate").text("等待买家消费");
            $("#spanlifefeeType").text("买家已消费");

            if (state == "3") {
                $("#spanleftend").text("买家已消费");
                $("#<%=lblSendGoodsTime.ClientID%>").text("" + $("#M_OrderDetail_ctl00_lblPayMentTime").text() + " ~ " + $("#M_OrderDetail_ctl00_lblConfirmOrderTime").text() + "")
            }
        }
        else {
            $(".showlife").hide();
        }
        var ev = $("#<%=hidEndTime.ClientID%>").val();
        if (ev != "") {
            show_date_time(ev.replaceAll("-", "/"), "suretime");
        }

        var edd = $("#<%=hidCanleTime.ClientID%>").val();
        if (edd != "") {
            show_date_time(edd.replaceAll("-", "/"), "canceltime");
        }
        if ($("#<%=lbllogisticType.ClientID%>").text() == "不需要物流") {
            $("#trancommpany").hide(); $("#tranord").hide(); $("#traninfo").hide();
        }

        //                        var strue='<%=ShopNum1.Common.Common.ReqStr("send") %>';
        //                        if(strue=="sure")
        //                        {
        //                            $("#<%=butSureConfirm.ClientID%>").click();
        //                        }
        var logisticname = $("#<%=lblLogisticsCompany.ClientID%>").text();
        var evp = $("#errordiv p").text();
        if (evp != "") {
            var LogisticNum = $("#<%=lblShipmentNumber.ClientID%>").text();
            var LogisticsCompany = $("#S_OrderDetail_ctl00_lblLogisticsCompany").text();
            if (evp.indexOf("异常") != -1 && logisticname == "顺丰快递") {
                $("#errordiv p").html("您选择的物流公司尚未提供物流跟踪信息反馈。如需了解请咨询物流公司。<a href=\"http://www.kuaidi100.com/all/sf.shtml?from=960&LogisticNum=" + LogisticNum + "\" target=\"_blank\">查询顺丰快递</a>");
            }
            else if (evp.indexOf("异常") != -1) {
                $("#errordiv p").html("您选择的物流公司尚未提供物流跟踪信息反馈。如需了解请咨询物流公司。<a href=\"http://www.kuaidi100.com/chaxun?com=" + LogisticsCompany + "&nu=" + LogisticNum + "\" target=\"_blank\">查询快递</a>");
            }
        }
    });
    function show_date_time(time, element) {
        window.setTimeout("show_date_time('" + time + "','" + element + "')", 1000);
        BirthDay = new Date(time);
        today = new Date();
        timeold = (BirthDay.getTime() - today.getTime());
        sectimeold = timeold / 1000
        secondsold = Math.floor(sectimeold);
        msPerDay = 24 * 60 * 60 * 1000
        e_daysold = timeold / msPerDay
        daysold = Math.floor(e_daysold);
        e_hrsold = (e_daysold - daysold) * 24;
        hrsold = Math.floor(e_hrsold);
        e_minsold = (e_hrsold - hrsold) * 60;
        minsold = Math.floor((e_hrsold - hrsold) * 60);
        seconds = Math.floor((e_minsold - minsold) * 60);
        if (daysold < 0) {
            document.getElementById(element).innerHTML = "0天0小时0分0秒";
        } else {
            document.getElementById(element).innerHTML = daysold + "天" + hrsold + "小时" + minsold + "分" + seconds + "秒";
        }
    }
    //选项卡切换
    function setTab(id, xid) {
        $("#showTab" + id).attr("style", "display:block"); $("#showTab" + xid).attr("style", "display:none");
    }
    //确认收货
    function checkReceive() {
        var xarrid = new Array();
        var xnum = new Array();
        var xprice = new Array();
        $("input[name='checksub']").each(function () {
            xarrid.push($(this).val());
            xprice.push($(this).attr("v_price"));
            xnum.push($(this).attr("v_num"));
        });
        $("#<%=hidShopPrice.ClientID%>").val(xprice.join(","));
        $("#<%=hidOrderProductId.ClientID%>").val(xarrid.join(","));
        $("#<%=hidBuyNum.ClientID%>").val(xnum.join(","));
        var strMsg = "点击确定后,您之前付款的 " + $("#M_OrderDetail_ctl00_lblShouldPrice").text() + " 元将直接到卖家帐户里,请务必收到货再确认!";
        if ($("#<%=hidRefundstatus.ClientID%>").val() == "1") {
            strMsg += "\r\n该订单处于退货中,如果确认收货将会关闭退款,是否确认收货?";
        }
        if (confirm(strMsg)) {
            return true;
        }
        else {
            return false;
        }
    }
    function closeit() {
        $("#dwindow").hide();
    }
    String.prototype.replaceAll = function (reallyDo, replaceWith, ignoreCase) {
        if (!RegExp.prototype.isPrototypeOf(reallyDo)) {
            return this.replace(new RegExp(reallyDo, (ignoreCase ? "gi" : "g")), replaceWith);
        } else {
            return this.replace(reallyDo, replaceWith);
        }
    }
    function DelaySure() {
        if (parseInt($("#<%=hidTotalDays.ClientID%>").val()) >= 3) {
            alert("您可以在离超时结束还剩最后3天时，申请延长确认收货时间！"); return false;
        }
        if (confirm("是否确认延迟收货？")) { return true; } else { return false; }
    }
    function sendcheck(o) {
        var shoploginid = $("#<%=lblMemLoginId.ClientID%>").text();
        var ordernumber = $("#<%=lblOrderNumber.ClientID%>").text();
        if ($(o).attr("lang") == "1") {
            alert("卖家已经收到您的提醒,尽快为您发货！"); return false;
        }
        $(o).attr("lang", "1");
        $.get("/Api/Main/Member/M_OrderDetail.ashx?ordernumber=" + ordernumber + "&shoploginid=" + shoploginid + "&sign", null, function (data) { });
        alert("提醒成功！");
        return true;
    }
</script>
<input type="hidden" id="hidOrderPay" runat="server" />
<input type="hidden" id="hidBuyNum" runat="server" />
<input type="hidden" id="hidOrderProductId" runat="server" />
<input type="hidden" id="hidShopPrice" runat="server" />
<input type="hidden" id="hidOrderGuId" runat="server" />
<input type="hidden" id="HidOrderNumber" runat="server" />
<input type="hidden" id="hidOrderState" runat="server" />
<input type="hidden" id="hidPayMentInfo" runat="server" />
<input type="hidden" id="hidPayMentName" runat="server" />
<input type="hidden" id="hidPayState" runat="server" />
<input type="hidden" id="hidShipState" runat="server" />
<input type="hidden" id="hidRefundstatus" runat="server" />
<input type="hidden" id="hidShouldPayPrice" runat="server" />
<input type="hidden" id="hidShopId" runat="server" />
<input type="hidden" id="hidDispatchPrice" runat="server" />
<input type="hidden" id="hidPaymentPrice" runat="server" />
<input type="hidden" id="hidExpiresTime" runat="server" />
<input type="hidden" id="hidlifetype" runat="server" />
<input type="hidden" id="hidEndTime" runat="server" />
<input type="hidden" id="hidCanleTime" runat="server" />
<input type="hidden" id="hidTotalDays" runat="server" />
<input type="hidden" id="hidRefundType" runat="server" />
<div id="content_bg">
    <div class="con_order">
        <style type="text/css">
            .pop_title_left
            {
                float: left;
                width: 80%;
                overflow: hidden;
                text-indent: 6px;
                cursor: move;
            }
            .pop_title_right
            {
                width: 15%;
                float: right;
                text-align: right;
                cursor: pointer;
            }
            .pop_content
            {
                float: left;
                width: 100%;
                background: #fff;
                margin: 5px 0 0 0;
                font-size: 12px;
            }
        </style>
        <!--修改支付方式弹出层-->
        <table width="100%" border="0" cellspacing="0" cellpadding="0" class="order_tab">
            <tr style="height: 40px;">
                <td>
                    <span id="select0" class="selecttab0">1、确认订单信息</span>
                </td>
                <td>
                    <span id="select1" class="selecttab1">2、买家已付款</span>
                </td>
                <td>
                    <span id="select2" class="selecttab2">3、<span id="lifetypestate">卖家发货</span></span>
                </td>
                <td>
                    <span id="select3" class="selecttab3">4、<span id="spanlifefeeType">确认收货</span></span>
                </td>
            </tr>
            <tr style="height: 30px;">
                <td class="arrow_1" valign="top">
                    <div>
                        <asp:Label ID="lblSetOrderTime" runat="server"></asp:Label>&nbsp;</div>
                    <div id="payupdate0" class="payupdate" style="display: none;">
                        <div class="xiaojt">
                        </div>
                        <div class="orderxx">
                            <ul>
                                <%if (hidPayMentName.Value == "货到付款" || hidPayMentName.Value == "线下支付" || hidPayMentName.Value == "唐江智付快捷支付") { butPayMoney.Visible = false; hidshow.Visible = false;  }%>
                                <li class="ordul1">当前订单状态：宝贝已拍下，请买家尽快付款</li>
                                <li>1.<span id="hidshow" runat="server">点击这里<asp:LinkButton ID="butPayMoney" runat="server"
                                    Text="付款," CssClass="orang_a" /></span>如果您在<asp:Label ID="lblCancleOrder" runat="server"></asp:Label>天内未付款,系统将在<span
                                        id="canceltime" style="color: Red"></span>后取消订单。 </li>
                                <li>2.如果你想取消这笔订单，可以
                                    <asp:LinkButton ID="butCancelOrder" OnClientClick="if(confirm('是否取消订单？')){return true;}else{return false;}"
                                        runat="server" Text="取消订单" CssClass="orang_a" OnClick="butCancelOrder_Click" /></li>
                                <li>3.您当前的支付方式为[<%=hidPayMentName.Value%>]<input type="button" id="butEditPay" runat="server"
                                    value="修改支付方式" class="zf_bot" /></li>
                            </ul>
                        </div>
                    </div>
                </td>
                <td class="arrow_2" valign="top">
                    <div>
                        <asp:Label ID="lblPayMentTime" runat="server"></asp:Label>&nbsp;</div>
                    <div id="payupdate1" class="payupdate payupdate1" style="display: none">
                        <div class="xiaojt">
                        </div>
                        <div class="orderxx">
                            <ul>
                                <li class="ordul1">当前订单状态：买家已付款<span id="refundtxt">, <span class="hidpaystate">请通知卖家尽快发货</span><span
                                    class="showlife">等待买家消费</span></span></li>
                                <li class="hidpaystate">1.如果您不想购买，您可以申请退款</li>
                                <li class="hidpaystate">2.您可以通知卖家已付款，请尽快发货</li>
                            </ul>
                        </div>
                    </div>
                </td>
                <td class="arrow_3" valign="top">
                    <div>
                        <asp:Label ID="lblSendGoodsTime" runat="server"></asp:Label>&nbsp;</div>
                    <div id="payupdate2" class="payupdate2" style="display: none">
                        <div class="xiaojt">
                        </div>
                        <div class="orderxx">
                            <ul>
                                <li class="ordul1">当前订单状态：卖家已发货，请查看下面物流信息了解宝贝寄送情况</li>
                                <li>1.可以根据下面的物流信息查询您的宝贝情况</li>
                                <li>2.如果您像详细跟踪您的宝贝物流信息，可以直接与物流公司联系</li>
                            </ul>
                        </div>
                    </div>
                </td>
                <td class="arrow_4" valign="top">
                    <div>
                        <asp:Label ID="lblConfirmOrderTime" runat="server"></asp:Label>&nbsp;</div>
                    <div id="payupdate3" class="payupdate3" style="display: none;">
                        <div class="xiaojt">
                        </div>
                        <div class="orderxx">
                            <ul>
                                <li class="ordul1">当前订单状态：等待买家确认收货<span id="vexitstate"></span></li>
                                <li>1.如果没有收到货，或收到货后出现问题，您可以联系卖家协商解决</li>
                                <li>2.如果卖家没有履行应尽的承诺，您可以投诉维权</li>
                                <li>3.如果您已经收到货，请点击 【<asp:LinkButton ID="butSureConfirm" runat="server" CssClass="orang_a"
                                    OnClientClick="return checkReceive()" Text="确认收货" OnClick="butSureConfirm_Click" />】(如果您在<asp:Label
                                        ID="lblSureDays" runat="server" runat="server"></asp:Label>天内未确认收货,卖家将在<span id="suretime"
                                            style="color: Red"></span>后可以执行确认收货操作!)
                                    <asp:Label ID="lblDelay" runat="server" Text="您可以延迟3天收货"></asp:Label>
                                    <%if (lblDelay.Text.IndexOf("您已延迟过") == -1)
                                      { %>
                                    ,【<asp:LinkButton ID="btnDelay" Enabled="false" runat="server" OnClientClick="return DelaySure()"
                                        Text="我要延迟收货" CssClass="orang_a" OnClick="btnDelay_Click"></asp:LinkButton>】<%} %></li>
                            </ul>
                        </div>
                    </div>
                    <div id="payupdate4" class="payupdate3" style="display: none; padding-top: 10px;">
                        <div class="xiaojt">
                        </div>
                        <div class="orderxx">
                            <ul>
                                <li class="ordul1">当前订单状态：<span id="spanleftend">交易成功</span></li>
                            </ul>
                        </div>
                    </div>
                </td>
            </tr>
        </table>
        <div class="ddtitle">
            订单信息
        </div>
        <div class="dingdnr">
            <div class="dingdx">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr style="height: 30px; line-height: 30px;">
                        <th colspan="6" scope="col" class="ding_th">
                            卖家信息
                        </th>
                    </tr>
                    <tr>
                        <td style="width: 320px;">
                            掌柜ID：<asp:Label ID="lblMemLoginId" runat="server"></asp:Label><a href="M_index.aspx?tomurl=M_SendMsg.aspx?ordernumber=<%=lblOrderNumber.Text %>"
                                target="_blank" class="fasong" style="color: #ffffff;">发送消息</a>
                            <%if (hidOrderState.Value == "1")
                              { %>
                            <span onclick="sendcheck(this)" lang="0" class="fasong" style="color: #ffffff; cursor: pointer;">
                                提醒发货</span>
                            <%} %>
                        </td>
                        <td>
                            真实姓名：<asp:Label ID="lblTrueName" runat="server"></asp:Label>
                        </td>
                        <td>
                            城市：<asp:Label ID="lblAreaName" runat="server"></asp:Label>
                        </td>

                    </tr>

                    <tr>
                        <td colspan="2">
                            联系电话：<asp:Label ID="lblMoible" runat="server"></asp:Label>
                        </td>
                        <td>
                            邮件：<asp:Label ID="lblEmail" runat="server"></asp:Label>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr id="TuiJian" runat="server">
                        <td >
                           推荐服务站：<asp:Label ID="Recommend_Serve" runat="server"></asp:Label> 
                       </td>
                    </tr>
                </table>
            </div>
            <div class="dingdx">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr style="height: 30px; line-height: 30px;">
                        <th colspan="6" scope="col" class="ding_th">
                            订单信息
                        </th>
                    </tr>
                    <tr>
                     <td >
                            所用红包：<asp:Label ID ="LabelDeduction_hv" runat="server" Text="0"></asp:Label>
                        </td>
                    
                        <td>
                            订单编号：<asp:Label ID="lblOrderNumber" runat="server"></asp:Label>
                        </td>
                        <td>
                            订单状态：<asp:Label ID="lblOrderStateTxt" runat="server"></asp:Label>
                        </td>
                        <td>
                            订单时间：<asp:Label ID="lblOrderDate" runat="server"></asp:Label>
                        </td>
                        
                        <td>
                            <asp:Label ID="lblDispatch" runat="server"></asp:Label>
                        </td>
                        <td>
                            总计：<asp:Label ID="lblShouldPrice" runat="server"></asp:Label>
                        </td>
                        <td style=" display:none;">
                            获得积分：<asp:Label ID="LabeScroce_pva" runat="server"></asp:Label>
                        </td>
                        <td style=" display:none;">
                            服务商：<asp:Label ID="LabelServiceAgent" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
                <table width="100%" border="0" cellspacing="1" cellpadding="0" class="orderta">
                    <tr style="height: 30px; line-height: 30px;">
                        <th scope="col" style="display: none;">
                        </th>
                        <th scope="col" style="width: 290px;">
                            商品
                        </th>
                        <th scope="col">
                            商品规格
                        </th>
                        <th scope="col">
                            单价(元)
                        </th>
                        <th scope="col">
                            数量
                        </th>
                        <th scope="col">
                            金额(元)
                        </th>
                        <%--  <th scope="col">状态</th>--%>
                    </tr>
                    <%DataTable dt_OrderProduct = M_OrderDetail.dt_OrderInfo;
                      if (dt_OrderProduct != null)
                      {
                          for (int i = 0; i < dt_OrderProduct.Rows.Count; i++)
                          {
                              DataRow dr_Product = dt_OrderProduct.Rows[i];
                    %>
                    <tr>
                        <td style="height: 60px; display: none;">
                            <input type="checkbox" disabled="disabled" name="checksub" checked="checked" v_num="<%=dr_Product["BuyNumber"]%>"
                                v_price="<%=dr_Product["ShopPrice"]%>" value="<%=dr_Product["ProductGuId"] %>" />
                        </td>
                        <td style="height: 60px;">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td style="padding-right: 0px; width: 61px; padding-left: 2px; text-align: left;
                                        border: none">
                                        <a href="<%=ShopUrlOperate.shopHrefcenter(dr_Product["ProductGuId"].ToString(),dr_Product["ShopId"].ToString(),Page.Request.QueryString["id"].ToString())%>"
                                            target="_blank">
                                            <img src="<%=dr_Product["ProductImg"]%>_60x60.jpg" onerror="javascript:this,src='/ImgUpload/noImg.jpg_60x60.jpg'" /></a>
                                    </td>
                                    <td style="border: none; text-align: left; line-height: 150%;">
                                        <a href="<%=ShopUrlOperate.shopHrefcenter(dr_Product["ProductGuId"].ToString(),dr_Product["ShopId"].ToString(),Page.Request.QueryString["id"].ToString())%>"
                                            target="_blank">
                                            <%=dr_Product["ProductName"]%></a>
                                            <p>
                                            商品颜色:  <%=dr_Product["Color"] %> ;商品尺寸:<%=dr_Product["Size"] %>
                                            </p>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td>
                            <%=dr_Product["specificationname"].ToString().Replace("0","")%>
                        </td>
                        <td>
                            <strong class="red">
                                
                                
                          <% if (Convert.ToInt32(dr_Product["shop_category_id"]) == 3)
                            { %>
                            <%if (!Convert.IsDBNull(dr_Product["daCV"]))
                            {%>
                             <%=Convert.ToDecimal(dr_Product["daCV"]) * -1%>积分
                            <%} %>
                                <%else
                                    {%>
                                        0
                                   <%} %>  
                            
                          <%} %>
                           <%else if (Convert.ToInt32(dr_Product["shop_category_id"]) != 3 )
                            { %>
                           <%=Convert.ToDecimal(dr_Product["ShopPrice"])%></strong>
                          <%} %>
                        </td>
                        <td>
                            <%=dr_Product["BuyNumber"]%>
                        </td>
                        <td>
                            <strong class="red">
                            
                          <% if (Convert.ToInt32(dr_Product["shop_category_id"]) == 3)
                            { %>
                             <%if (!Convert.IsDBNull(dr_Product["daCV"]))
                            {%>
                           <%=Convert.ToDecimal(dr_Product["daCV"]) * -1 * Convert.ToInt32(dr_Product["BuyNumber"])%>积分
                            <%} %>
                                <%else
                                    {%>
                                        0
                                   <%} %>  
                            
                          <%} %>
                           <%else if (Convert.ToInt32(dr_Product["shop_category_id"]) != 3 )
                            { %>
                           <%=Convert.ToDecimal(dr_Product["ShopPrice"]) * Convert.ToInt32(dr_Product["BuyNumber"])%></strong>
                          <%} %>
                                
                        </td>
                        <%--  <td></td>--%>
                    </tr>
                    <%}
                      }%>
                </table>
            </div>
            <div class="dingdx" id="salepromotion">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr style="height: 30px; line-height: 30px;">
                        <th colspan="6" scope="col" class="ding_th">
                            促销信息
                        </th>
                    </tr>
                    <tr>
                    </tr>
                </table>
            </div>
            <div class="wulxx">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <th class="ding_th" style="cursor: pointer;" onclick="setTab(1,2)">
                            物流信息
                        </th>
                        <th class="ding_th" style="background: #e8f2ff; cursor: pointer; display: none;"
                            onclick="setTab(2,1)">
                            收货信息
                        </th>
                    </tr>
                    <tr>
                        <td>
                            <table width="850" id="showTab1">
                                <tr>
                                    <td class="tab_r">
                                        运送方式：
                                    </td>
                                    <td>
                                        <asp:Label ID="lbllogisticType" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr id="trancommpany">
                                    <td class="tab_r">
                                        物流公司：
                                    </td>
                                    <td>
                                        <asp:Label ID="lblLogisticsCompany" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr id="tranord">
                                    <td class="tab_r">
                                        运单号：
                                    </td>
                                    <td>
                                        <asp:Label ID="lblShipmentNumber" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr id="traninfo">
                                    <td class="tab_r">
                                        物流信息：
                                    </td>
                                    <td>
                                        <div id="LogisticInfo" runat="server">
                                        </div>
                                    </td>
                                </tr>
                                <tr id="hideAddress">
                                    <td class="tab_r">
                                        收货地址：
                                    </td>
                                    <td>
                                        <asp:Label ID="lblReceiveAddress" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top" class="tab_r">
                                        买家留言：
                                    </td>
                                    <td valign="top">
                                        <asp:Label ID="lblBuyerMsg" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr style="display: none;">
                                    <td class="tab_r">
                                        卖家回复：<asp:Label ID="lblSellerMsg" runat="server"></asp:Label>
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr style="display: none;">
                                    <td class="tab_r">
                                        发票类型：
                                    </td>
                                    <td>
                                        <asp:Label ID="LabelInvoiceTypeValue" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tab_r">
                                        发票抬头：
                                    </td>
                                    <td>
                                        <asp:Label ID="LabelInvoiceTitleValue" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tab_r">
                                        发票内容：
                                    </td>
                                    <td>
                                        <asp:Label ID="LabelInvoiceContentValue" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="wulxx">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <th colspan="2" class="ding_th">
                            操作历史
                        </th>
                    </tr>
                    <%
                        DataTable dt_OrderOperate = M_OrderDetail.dt_OrderOperate;
                        if (dt_OrderOperate != null)
                        {
                            for (int v = 0; v < dt_OrderOperate.Rows.Count; v++)
                            {

                                DataRow drop = dt_OrderOperate.Rows[v];
                    %>
                    <tr>
                        <td>
                            <%=drop["createuser"] + " 于 " + drop["operatedatetime"] + "  当前状态为：" + drop["currentstatemsg"] + " 下一步状态为：" + drop["nextstatemsg"]%>
                        </td>
                    </tr>
                    <%}
                        } %>
                </table>
            </div>
        </div>
    </div>
</div>
<!--修改支付方式弹出层-->
<div style="position: fixed; display: none; left: 0; top: 0; width: 100%; height: 100%;
    z-index: 9999; _position: absolute; _top: expression(eval(document.documentElement.scrollTop+0));"
    id="dwindow">
    <div style="display: block;" class="sp_overlay">
    </div>
    <div style="width: 600px; position: relative; z-index: 1000; margin: 0px auto 10px;
        top: 0px; background: #c5c5c5; border-radius: 3px 3px 3px 3px; padding: 6px;">
        <div style="border: 1px solid #9ECCE8; background: #ffffff;">
            <div class="pop_title" id="pop_title" style="overflow: hidden;">
                <div class="pop_title_left">
                    修改支付方式
                </div>
                <div class="pop_title_right">
                    <label onclick="closeit()" title="关闭此窗口" class="sp_close">
                        关闭&nbsp;
                    </label>
                </div>
            </div>
            <div class="pop_content" id="dwindowcontent" style="float: none; margin: 0;">
                <table width="540" cellspacing="1" cellpadding="0" border="0" align="center" style="background-color: #eee;
                    color: #333333; margin: 20px 30px;" id="PaymentTable">
                    <% DataTable dt_pay = M_OrderDetail.dt_PayMent; %>
                    <%if (dt_pay != null)
                      {
                          for (int i = 0; i < dt_pay.Rows.Count; i++)
                          {
                              DataRow dr = dt_pay.Rows[i];
                              if (dr["name"].ToString().IndexOf("线下支付") == -1 && dr["name"].ToString().IndexOf("货到付款") == -1 && dr["name"].ToString().IndexOf("唐江智付快捷支付") == -1)
                              {
                    %>
                    <!--支付方式循环代码-->
                    <tr style="background: #fff;">
                        <td width="5%" align="center">
                            <input type="radio" name="radio_pay" value="<%=dr["guid"] %>" pay_name="<%=dr["Name"]%>"
                                pay_charge="<%=dr["Charge"]%>" pay_ispercent="<%=dr["IsPercent"]%>" />
                        </td>
                        <td width="15%" style="padding-left: 5px;">
                            <span>
                                <%=dr["Name"]%></span>
                        </td>
                        <td width="8%" align="center" style="padding-left: 5px; display: none;">
                            <span>
                                <%=dr["Charge"]%></span>%
                        </td>
                    </tr>
                    <!--支付方式循环代码-->
                    <%} 
                          }
                      }%>
                </table>
                <div style="margin: 4px; text-align: right; padding-bottom: 15px;">
                    <asp:LinkButton ID="btnUpdatePayMent" runat="server" Text="确定" CssClass="baocbtn"
                        Style="display: block; margin: 0 auto; color: #ffffff;" OnClick="btnUpdatePayMent_Click" /></div>
            </div>
        </div>
    </div>
</div>
