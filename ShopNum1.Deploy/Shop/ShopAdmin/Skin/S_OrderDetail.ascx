<%@ Control Language="C#" EnableViewState="false" %>
<%@ Import Namespace="ShopNum1.ShopAdminWebControl" %>
<%@ Import Namespace="ShopNum1.Common" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="ShopNum1.ShopAdminWebControl" %>
<script type="text/javascript" language="javascript">
    $(function () {
        //控制状态选中
        var state = $("#S_OrderDetail_ctl00_hidOrderState").val();
        for (var i = 0; i < 4; i++) {
            $("#select" + state).removeClass("settab" + i);
        }
        $("#select" + state).addClass("settab" + state);
        switch (state) {
            case "0":
                $("#payupdate0").show();
                break;
            case "1":
                $("#payupdate2").show();
                locdlogstic();
                break;
            case "2":
                $("#payupdate3").show();
                break;
            case "3":
                $("#payupdate4").show();
                break;
        }
        $("input[name='islogistic']").change(function () {
            if ($(this).val() == "0") {
                $(".hidfahuo").hide();
            } else {
                $(".hidfahuo").show();
            }
        });
        $("#butEditPay").click(function () {
            $("#dwindow").show();
        });
        //支付选中
        $("input[name='radio_pay']").click(function () {
            $("#S_OrderDetail_ctl00_hidPayMentInfo").val($(this).val() + "|" + $(this).attr("pay_Name") + "|" + $(this).attr("pay_Charge") + "|" + $(this).attr("pay_IsPercent"));
        });


        var hidpaystate = parseInt($("#S_OrderDetail_ctl00_hidPayState").val());
        var hidshipstate = parseInt($("#S_OrderDetail_ctl00_hidShipState").val());
        var hidrefundstatus = parseInt($("#S_OrderDetail_ctl00_hidRefundstatus").val());
        var hidRefundType = parseInt($("#S_OrderDetail_ctl00_hidRefundType").val());
        if (parseInt(state) > 2 || hidrefundstatus > 0) {
            $("#payupdate2").hide();
        }
        if (hidrefundstatus == "1" && state == "1" && hidRefundType == "0") {
            $("#payupdate1").show();
            $("#isshowpayupdate1").hide();
            $("#S_OrderDetail_ctl00_butFahuo").hide();
            $("#S_OrderDetail_ctl00_lblOrderStateTxt").text($("#S_OrderDetail_ctl00_lblOrderStateTxt").text() + ",买家已申请退款...");
            $("#showstatetxt").text($("#S_OrderDetail_ctl00_lblOrderStateTxt").text());
        }
        if (hidrefundstatus == "2" && state == "1" && hidRefundType == "0") {
            $("#payupdate2").show(); //$("#isshowpayupdate1").hide();
            $("#S_OrderDetail_ctl00_lblOrderStateTxt").text($("#S_OrderDetail_ctl00_lblOrderStateTxt").text() + ",卖家拒绝退款...");
            $("#showstatetxt").text($("#S_OrderDetail_ctl00_lblOrderStateTxt").text());
        }


        if (hidrefundstatus == "1" && state == "2" && hidRefundType == "1") {
            $("#S_OrderDetail_ctl00_lblOrderStateTxt").text($("#S_OrderDetail_ctl00_lblOrderStateTxt").text() + ",买家已申请退货...");
            $("#showgoodstate").text($("#S_OrderDetail_ctl00_lblOrderStateTxt").text());
        }
        if (hidrefundstatus == "2" && state == "2" && hidRefundType == "1") {
            $("#S_OrderDetail_ctl00_lblOrderStateTxt").text($("#S_OrderDetail_ctl00_lblOrderStateTxt").text() + ",卖家拒绝退货...");
            $("#showgoodstate").text($("#S_OrderDetail_ctl00_lblOrderStateTxt").text());
        }

        if ($("#S_OrderDetail_ctl00_hidlifetype").val() == "2") {
            $("#hideAddress").hide();
            $("#IsFahuo").hide();
            $("#S_OrderDetail_ctl00_hidislogistic").val("0");
            $("#showlifetxt").text("买家消费");
            $(".showlife").hide();
            $("#showfeestate").text("等待买家消费");
            $("#showfeestateend").text("买家已消费");
            $(".showlifeCode").show();
            $("#showlifesend").show();
            if ($("#S_OrderDetail_ctl00_lblOrderStateTxt").text() == "等待卖家发货") {
                $("#S_OrderDetail_ctl00_lblOrderStateTxt").text("等待买家消费");
            }
            if (state == 3) {
                $("#spanleftend").text("买家已消费");
                $("#S_OrderDetail_ctl00_lblSendGoodsTime").html("" + $("#S_OrderDetail_ctl00_lblPayMentTime").text() + " ~ " + $("#S_OrderDetail_ctl00_lblConfirmOrderTime").text() + "");
            }
        }

        var ev = $("#S_OrderDetail_ctl00_hidEndTime").val();
        if (ev != "") {
            show_date_time(ev.replaceAll("-", "/"), "suretime");
        }
        if ($("#suretime").text() == "0天0小时0分0秒") {
            $("#S_OrderDetail_ctl00_btnSureConfirm").show();
        }
        var logisticname = $("#S_OrderDetail_ctl00_lblLogisticsCompany").text();
        var evp = $("#errordiv p").text();
        if (evp != "") {
            var LogisticNum = $("#S_OrderDetail_ctl00_lblShipmentNumber").text();
            var LogisticsCompany = $("#S_OrderDetail_ctl00_lblLogisticsCompany").text();
            
            if (evp.indexOf("异常") != -1 && logisticname == "顺丰快递") {
                $("#errordiv p").html("您选择的物流公司尚未提供物流跟踪信息反馈。如需了解请咨询物流公司。<a href=\"http://www.kuaidi100.com/all/sf.shtml?from=960&LogisticNum=" + LogisticNum + "\" target=\"_blank\">查询顺丰快递</a>");
            } else if (evp.indexOf("异常") != -1) {
                $("#errordiv p").html("您选择的物流公司尚未提供物流跟踪信息反馈。如需了解请咨询物流公司。<a href=\"http://www.kuaidi100.com/chaxun?com=" + LogisticsCompany + "&nu=" + LogisticNum + "\" target=\"_blank\">查询快递</a>");
            }
        }

        $("#selectlogistic").change(function () {
            if ($(this).find("option:selected").val() == "qtkd") {
                $("#showInputLogistic").show();
            }
        });

        if ($("#S_OrderDetail_ctl00_lbllogisticType").text() == "不需要物流") {
            $("#trancommpany").hide();
            $("#tranord").hide();
            $("#traninfo").hide();
        }
    });

    String.prototype.replaceAll = function (reallyDo, replaceWith, ignoreCase) {
        if (!RegExp.prototype.isPrototypeOf(reallyDo)) {
            return this.replace(new RegExp(reallyDo, (ignoreCase ? "gi" : "g")), replaceWith);
        } else {
            return this.replace(reallyDo, replaceWith);
        }
    };

    function show_date_time(time, element) {
        window.setTimeout("show_date_time('" + time + "','" + element + "')", 1000);
        BirthDay = new Date(time);
        today = new Date();
        timeold = (BirthDay.getTime() - today.getTime());
        sectimeold = timeold / 1000;
        secondsold = Math.floor(sectimeold);
        msPerDay = 24 * 60 * 60 * 1000;
        e_daysold = timeold / msPerDay;
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
        $("#showTab" + id).attr("style", "display:block");
        $("#showTab" + xid).attr("style", "display:none");
    }

    //显示物流数据

    function locdlogstic() {
        $.get("/Api/ShopAdmin/S_OrderDetail.ashx?type=getlogistic", null, function (data) {
            var vdata = eval('(' + data + ')');
            var xhtml = new Array();
            $.each(vdata, function (m, n) {
                xhtml.push("<option value=\"" + n.valuecode + "\">" + n.name + "</option>");
                if (m == 7) {
                    xhtml.push("<option value=\"qtkd\">其它</option>");
                }
            });
            $("#selectlogistic").html(xhtml.join(""));
        });
    }

    //获取发货信息

    function getfahuo() {
        //$("#S_OrderDetail_ctl00_hidislogistic").val();
        if ($("#logisticnumber").val() == "" && $('input:radio[name="islogistic"]:checked').val() == "1") {
            alert("物流单号不能为空!");
            return false;
        }
        $("#S_OrderDetail_ctl00_hidislogistic").val($('input:radio[name="islogistic"]:checked').val());
        if ($("#selectlogistic").find("option:selected").val() == "qtkd") {
            $("#S_OrderDetail_ctl00_hidlogisticCompany").val($("#showInputLogistic").val() + "|" + $("#selectlogistic").find("option:selected").val());
        } else {
            $("#S_OrderDetail_ctl00_hidlogisticCompany").val($("#selectlogistic").find("option:selected").text() + "|" + $("#selectlogistic").find("option:selected").val());
        }
        $("#S_OrderDetail_ctl00_hidlogisitcnumber").val($("#logisticnumber").val());
        return true;
    }

    function closeit() {
        $("#dwindow").hide();
    }

    //卖家也可以发货了！！！

    function sureConfirm() {
        var xarrid = new Array();
        var xnum = new Array();
        var xprice = new Array();
        $("input[name='checksub']").each(function () {
            xarrid.push("" + $(this).val() + "");
            xprice.push($(this).attr("v_price"));
            xnum.push($(this).attr("v_num"));
        });
        $("#S_OrderDetail_ctl00_hidOrderProductId").val(xarrid.join(","));
        $("#S_OrderDetail_ctl00_hidShopPrice").val(xprice.join(","));
        $("#S_OrderDetail_ctl00_hidBuyNum").val(xnum.join(","));
        if (confirm("是否代替买家执行确认收货操作！")) {
            return true;
        } else {
            return false;
        }
    }

    //检测验证码是否正确

    function CheckCode() {
        if ($("#S_OrderDetail_ctl00_hidCheckCode").val() != $("#S_OrderDetail_ctl00_txtlifeCode").val()) {
            alert("消费码不正确！");
            return false;
        }
        if (confirm("确认消费？")) {
            var xarrid = new Array();
            var xnum = new Array();
            var xprice = new Array();
            $("input[name='checksub']").each(function () {
                xarrid.push("" + $(this).val() + "");
                xprice.push($(this).attr("v_price"));
                xnum.push($(this).attr("v_num"));
            });
            $("#S_OrderDetail_ctl00_hidOrderProductId").val(xarrid.join(","));
            $("#S_OrderDetail_ctl00_hidShopPrice").val(xprice.join(","));
            $("#S_OrderDetail_ctl00_hidBuyNum").val(xnum.join(","));
            return true;
        } else {
            return false;
        }
    }

    function NumTxt_Int(o) {
        o.value = o.value.replace(/\D/g, '');
    }
</script>
<!--物流信息-->
<input type="hidden" id="hidislogistic" runat="server" />
<input type="hidden" id="hidlogisitcnumber" runat="server" />
<input type="hidden" id="hidlogisticCompany" runat="server" />
<!--物流信息-->
<input type="hidden" id="hidMemloginId" runat="server" />
<input type="hidden" id="hidOrderGuId" runat="server" />
<input type="hidden" id="hidOrderState" runat="server" />
<input type="hidden" id="hidPayState" runat="server" />
<input type="hidden" id="hidShipState" runat="server" />
<input type="hidden" id="hidRefundstatus" runat="server" />
<input type="hidden" id="hidPayMentName" runat="server" />
<input type="hidden" id="hidOrderPay" runat="server" />
<input type="hidden" id="hidDispatchPrice" runat="server" />
<input type="hidden" id="hidPaymentPrice" runat="server" />
<input type="hidden" id="hidOrderProductId" runat="server" />
<input type="hidden" id="hidShouldPayPrice" runat="server" />
<input type="hidden" id="hidShopPrice" runat="server" />
<input type="hidden" id="hidBuyNum" runat="server" />
<input type="hidden" id="hidExpiresTime" runat="server" />
<input type="hidden" id="hidlifetype" runat="server" />
<input type="hidden" id="hidEndTime" runat="server" />
<input type="hidden" id="hidCheckCode" runat="server" />
<input type="hidden" id="hidRefundType" runat="server" />
<div id="content_bg">
    <div class="con_order">
        <table width="100%" border="0" cellspacing="0" cellpadding="0" class="order_tab">
            <tr style="height: 40px;">
                <td>
                    <span id="select0" class="selecttab0">1、确认订单信息</span>
                </td>
                <td>
                    <span id="select1" class="selecttab1">2、买家已付款</span>
                </td>
                <td>
                    <span id="select2" class="selecttab2">3、<span id="showfeestate">卖家发货</span></span>
                </td>
                <td>
                    <span id="select3" class="selecttab3">4、<span id="showfeestateend">确认收货</span></span>
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
                                <li class="ordul1" style="margin-bottom: 5px; margin-top: 30px;">当前订单状态：宝贝未付款，请通知买家尽快付款。</li>
                                <li>支付方式：<%= hidPayMentName.Value %>。</li>
                                <li>
                                    <% if (hidPayMentName.Value != "货到付款" && hidPayMentName.Value != "线下支付")
                                       { %>
                                    请通知买家尽快付款。<% } %></li>
                            </ul>
                        </div>
                    </div>
                </td>
                <td class="arrow_2" valign="top">
                    <asp:Label ID="lblPayMentTime" runat="server"></asp:Label>
                    <div id="payupdate1" class="payupdate1" style="display: none">
                        <div class="xiaojt">
                        </div>
                        <div class="orderxx">
                            <ul>
                                <li class="ordul1" style="margin-bottom: 5px; margin-top: 30px;">当前订单状态：<span id="showstatetxt">买家已付款，请尽快发货。</span></li>
                                <li id="isshowpayupdate1">请尽快发货，以免买家申请退款。</li>
                            </ul>
                        </div>
                    </div>
                </td>
                <td class="arrow_3" valign="top">
                    <div style="">
                        <asp:Label ID="lblSendGoodsTime" runat="server"></asp:Label>&nbsp;</div>
                    <div id="payupdate2" class="payupdate2" style="display: none; padding-top: 20px;">
                        <div class="xiaojt">
                        </div>
                        <div class="orderxx">
                            <ul>
                                <li class="ordul1" style="margin: 20px 0 5px 0;">当前订单状态：等待<span id="showlifetxt">卖家发货</span><span
                                    class="showlife">，请查看上面物流信息了解宝贝寄送情况</span></li>
                                <li class="showlife">请尽快发货，以免买家申请退款。</li>
                                <li class="showlife">
                                    <table cellpadding="0" cellspacing="0" border="0" id="IsFahuo" style="padding: 10px 20px;">
                                        <tr>
                                            <td align="right">
                                                是否需要物流：
                                            </td>
                                            <td align="left">
                                                <input type="radio" name="islogistic" value="1" checked="checked" />需要
                                                <input type="radio" name="islogistic" value="0" />不需要
                                            </td>
                                            <td align="right" class="ss_nr_spac hidfahuo">
                                                物流公司：
                                            </td>
                                            <td class="hidfahuo">
                                                <select id="selectlogistic" class="tselect" style="width: 160px;">
                                                </select><input type="text" id="showInputLogistic" maxlength="8" style="border: 1px solid #CCCCCC;
                                                    color: #464646; display: none; height: 22px; line-height: 22px; margin-left: 5px;
                                                    width: 100px;" />
                                            </td>
                                            <td align="right" class="ss_nr_spac hidfahuo">
                                                物流单号：
                                            </td>
                                            <td class="hidfahuo">
                                                <input type="text" id="logisticnumber" class="ss_nr1" style="width: 160px;" />
                                            </td>
                                            <td>
                                                <asp:LinkButton ID="butFahuo" runat="server" Text="发货" OnClientClick=" return getfahuo(); "
                                                    CssClass="fasong" Style="color: #ffffff; display: block;" />
                                            </td>
                                        </tr>
                                    </table>
                                </li>
                                <li>
                                    <table cellpadding="0" cellspacing="0" border="0" id="showlifesend" style="display: none;
                                        padding: 10px 20px;">
                                        <tr>
                                            <td align="right">
                                                消费码：
                                                <input id="txtlifeCode" type="text" onkeyup="NumTxt_Int(this)" runat="server" class="ss_nr1"
                                                    value="" maxlength="10" />
                                            </td>
                                            <td>
                                                <asp:LinkButton ID="btnLifeFahuo" runat="server" Text="消费" OnClientClick=" return CheckCode() "
                                                    Style="color: #ffffff; display: block;" CssClass="fasong"></asp:LinkButton>
                                            </td>
                                        </tr>
                                    </table>
                                </li>
                            </ul>
                        </div>
                    </div>
                </td>
                <td class="arrow_4" valign="top">
                    <div>
                        <asp:Label ID="lblConfirmOrderTime" runat="server"></asp:Label>&nbsp;</div>
                    <div id="payupdate3" class="payupdate3" style="display: none">
                        <div class="xiaojt">
                        </div>
                        <div class="orderxx">
                            <ul>
                                <li class="ordul1" style="margin-bottom: 5px; margin-top: 30px;">当前订单状态：<span id="showgoodstate">等待买家确认收货</span></li>
                                <li class="ordul1" id="exitgoods" style="margin-bottom: 5px; margin-top: 30px;">如果买家在<asp:Label
                                    ID="lblSureDays" runat="server"></asp:Label>天内未确认收货, 您可以在<span id="suretime" style="color: Red"></span>后可以执行确认收货操作<asp:LinkButton
                                        ID="btnSureConfirm" runat="server" Text="【确认收货】" OnClientClick=" return sureConfirm(); "
                                        CssClass="orang_a" Style="display: none; width: 60px;" />
                                </li>
                            </ul>
                        </div>
                    </div>
                    <div id="payupdate4" class="payupdate3" style="display: none; padding-top: 10px;">
                        <div class="xiaojt">
                        </div>
                        <div class="orderxx">
                            <ul>
                                <li class="ordul1" style="margin-bottom: 5px; margin-top: 30px;">当前订单状态：<span id="spanleftend">交易已成功</span></li>
                            </ul>
                        </div>
                    </div>
                </td>
            </tr>
        </table>
    </div>
    <div class="ddtitle" style="margin: 0 auto; width: 950px;">
        <span style="float: left;">订单信息</span><span style="float: right;"><a target="_blank"
            href="S_PrintOrder.aspx?guid=<%= ShopNum1.Common.Common.ReqStr("guid") %>&ordertype=<%= ShopNum1.Common.Common.ReqStr("ordertype") %>">
            <img src="images/print.jpg" /></a></span>
    </div>
    <div class="dingdnr" style="margin: 0 auto; width: 950px;">
        <div class="dingdx">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr style="height: 30px; line-height: 30px;">
                    <th colspan="6" scope="col" class="ding_th">
                        买家信息
                    </th>
                </tr>
                <tr>
                    <td style="width: 200px;">
                        会员ID：<asp:Label ID="lblMemLoginId" runat="server"></asp:Label><a class="fasong" style="color: #ffffff;"
                            href="/Main/Member/M_index.aspx?tomurl=M_SendMsg.aspx?ordernumber=<%= lblOrderNumber.Text %>|shop&"
                            target="_blank">发送消息</a>
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
                        总计：<asp:Label ID="lblShouldPrice" runat="server"></asp:Label>元
                    </td>
                    <td style=" display:none;">
                            获得积分：<asp:Label ID="LabeScroce_pva" runat="server"></asp:Label>
                        </td>
                        <td style=" display:none;">
                            服务商：<asp:Label ID="LabelServiceAgent" runat="server"></asp:Label>
                        </td>
                </tr>
            </table>
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="orderta">
                <tr style="height: 30px; line-height: 30px;">
                    <th scope="col" style="border-left: solid 1px #dddddd; display: none;">
                    </th>
                    <th scope="col" style="border-left: solid 1px #dddddd; width: 390px;">
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
                        发货数量
                    </th>
                    <th scope="col" style="border-right: solid 1px #dddddd;">
                        金额(元)
                    </th>
                </tr>
                <% DataTable dt_OrderProduct = S_OrderDetail.dt_OrderInfo;
                   if (dt_OrderProduct != null)
                   {
                       for (int i = 0; i < dt_OrderProduct.Rows.Count; i++)
                       {
                           DataRow dr_Product = dt_OrderProduct.Rows[i];
                %>
                <tr>
                    <td style="border-left: solid 1px #dddddd; display: none; height: 60px;">
                        <input type="checkbox" disabled="disabled" name="checksub" checked="checked" v_num="<%= dr_Product["BuyNumber"] %>"
                            v_price="<%= dr_Product["ShopPrice"] %>" value="<%= dr_Product["ProductGuId"] %>" />
                    </td>
                    <td style="border-left: solid 1px #dddddd; height: 60px;">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td style="border: none; padding-left: 2px; padding-right: 0px; text-align: left;
                                    width: 61px;">
                                    <a href="<%= ShopUrlOperate.shopHrefcenter(dr_Product["ProductGuId"].ToString(), dr_Product["ShopId"].ToString(),Page.Request.QueryString["category"].ToString()) %>"
                                        target="_blank">
                                        <img src="<%= dr_Product["ProductImg"] %>_60x60.jpg" onerror=" javascript:this, src = '/ImgUpload/noImg.jpg_60x60.jpg'; " /></a>
                                </td>
                                <td style="border: none; line-height: 150%; text-align: left;">
                                    <a href="<%= ShopUrlOperate.shopHrefcenter(dr_Product["ProductGuId"].ToString(), dr_Product["ShopId"].ToString(),Page.Request.QueryString["category"].ToString()) %>"
                                        target="_blank">
                                        <%= dr_Product["ProductName"] %></a>
                                        <p>
                                            商品颜色:  <%=dr_Product["Color"] %> ;商品尺寸:<%=dr_Product["Size"] %>
                                            </p>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td>
                        <%= dr_Product["specificationname"].ToString().Replace("0", "") %>
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
                        <%= dr_Product["BuyNumber"] %>
                    </td>
                    <td>
                        <%= dr_Product["unitCount"]%>
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
                           <%=Convert.ToDecimal(dr_Product["ShopPrice"]) * Convert.ToDecimal(dr_Product["BuyNumber"])%></strong>
                          <%} %>
                                
                        </td>
                </tr>
                <% }
                   } %>
            </table>
        </div>
        <div class="dingdx">
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
                    <th class="ding_th" style="cursor: pointer;" onclick=" setTab(1, 2) ">
                        物流信息
                    </th>
                    <th class="ding_th" style="background: #e8f2ff; cursor: pointer; display: none;"
                        onclick=" setTab(2, 1) ">
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
                                    物流详细：
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
                                <td class="tab_r">
                                    买家留言：
                                </td>
                                <td>
                                    <asp:Label ID="lblBuyerMsg" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr style="display: none;">
                                <td class="tab_r">
                                    卖家回复：
                                </td>
                                <td>
                                    <asp:Label ID="lblSellerMsg" runat="server"></asp:Label>
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
                    <th colspan="2" class="ding_th" style="background: #e8f2ff">
                        操作历史
                    </th>
                </tr>
                <%
                    DataTable dt_OrderOperate = S_OrderDetail.dt_OrderOperate;
                    if (dt_OrderOperate != null)
                    {
                        for (int v = 0; v < dt_OrderOperate.Rows.Count; v++)
                        {
                            DataRow drop = dt_OrderOperate.Rows[v];
                %>
                <tr>
                    <td>
                        <%= drop["createuser"] + " 于 " + drop["operatedatetime"] + "  订单当前状态为：" + drop["CurrentStateMsg"] + " 下一步状态为：" + drop["NextStateMsg"] %>
                    </td>
                </tr>
                <% }
                    } %>
            </table>
        </div>
    </div>
</div>
