<%@ Control Language="C#" %>
<%@ Import Namespace="ShopNum1.ShopAdminWebControl" %>
<input type="hidden" id="hidShowWeiXin" runat="server" />
<input type="hidden" id="hidIsTip" runat="server" value="0" />
<input type="hidden" id="hidOpenTime" runat="server" />
<input type="hidden" id="hidEndTime" runat="server" />
<input type="hidden" id="hidWxPayMoney" runat="server" />
<input type="hidden" id="hidPayTime" runat="server" />
<input type="hidden" id="hidMyShouldPay" runat="server" />
<input type="hidden" id="hidDepartTime" runat="server" />
<script type="text/javascript" language="javascript">
    $(function () {
        var endT = $("#W_WelcomeWx_ctl00_hidEndTime").val();
        if (endT != "") {
            show_date_time(endT.replaceAll("-", "/"), "endtime");
        }

        var isShow = $("#W_WelcomeWx_ctl00_hidShowWeiXin").val(); //是否开通了微信
        var isTip = $("#W_WelcomeWx_ctl00_hidIsTip").val(); //是否显示提示信息
        if (isShow == "0" || isShow == "") {
            $("#J_OpenWx").show();
        } else if (endT != "") {
            $("#J_endTimeShow").show();
        }
        if (isTip == "1") {
            $("#J_showTip").show(); //显示店铺提示
        }

        $("#btnOpen,#btnDelay").click(function () {
            funOpen();
            $("#titleDiv").text($(this).attr("lang"));
        });
    });

    //检查交易密码是否正确   

    function funPay() {
        $("#errPwd").html("查询中...");
        funCheckPayPwd();
        if ($("#errPwd").attr("lang") == "1") {
            $("#errPwd").css("color", "green");
            $("#errPwd").html("交易密码正确！");
            return true;
        }
        $("#errPwd").html("交易密码错误！");
        return false;
    }

    function funCheckPayPwd() {
        var payPwd = $("#<%= txtPayPassWord.ClientID %>").val();
        $.ajax({
            type: "get",
            url: "/Api/ShopAdmin/S_AdminOpt.ashx",
            async: false,
            data: "type=paypwd&payPwd=" + payPwd,
            dataType: "html",
            success: function (ajaxData) {
                if (ajaxData != "") {
                    if (ajaxData == "false") {
                        $("#errPwd").attr("lang", "0");
                    } else if (ajaxData == "true") {
                        $("#errPwd").attr("lang", "1");
                    }
                }
            }
        });

    }

    //检查交易密码是否正确   
    String.prototype.replaceAll = function (reallyDo, replaceWith, ignoreCase) {
        if (!RegExp.prototype.isPrototypeOf(reallyDo)) {
            return this.replace(new RegExp(reallyDo, (ignoreCase ? "gi" : "g")), replaceWith);
        } else {
            return this.replace(reallyDo, replaceWith);
        }
    };

    function show_date_time(time, element) {
        window.setInterval("show_date_time('" + time + "','" + element + "')", 1000);
        //AJAX获取服务器数据
        //因程序执行耗费时间,所以时间并不十分准确,误差大约在2000毫秒以下
        var xmlHttp = false;
        //获取服务器时间
        try {
            xmlHttp = new ActiveXObject("Msxml2.XMLHTTP");
        } catch (e) {
            try {
                xmlHttp = new ActiveXObject("Microsoft.XMLHTTP");
            } catch (e2) {
                xmlHttp = false;
            }
        }
        if (!xmlHttp && typeof XMLHttpRequest != 'undefined') {
            xmlHttp = new XMLHttpRequest();
        }
        xmlHttp.open("GET", "/Api/newtime.txt?date=" + (-new Date), false);
        xmlHttp.setRequestHeader("Range", "bytes=-1");
        xmlHttp.send(null);
        var severtime = new Date(xmlHttp.getResponseHeader("Date")); //服务器时间

        BirthDay = new Date(time);
        today = new Date(severtime);
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
</script>
<div class="right_mian">
    <div class="jianjie">
        <div style="padding-top: 40px;">
        </div>
        <div id="J_endTimeShow" class="come_wx" style="display: none;">
            微信到期倒计时:<span id="endtime"></span><br />
            <span>创建时间：<%= hidOpenTime.Value %></span> <span>到期时间：<%= hidEndTime.Value %></span>
        </div>
        <div id="J_OpenWx" class="come_wx" style="display: none;">
            <div>
                您暂时未开启微信,请点击【我要申请】按钮开通微信功能！</div>
            <input type="button" id="btnOpen" class="baocbtn" value="我要申请" lang="开通微信功能" />
        </div>
        <div id="J_showTip" class="come_wx" style="display: none;">
            <div>
                尊敬的卖家,您的微信商城功能使用即将到期！</div>
            <input type="button" id="btnDelay" class="baocbtn" value="我要续费" lang="续费微信功能" />
        </div>
        <%--交易密码弹出层 start--%>
        <div class="sp_dialog sp_dialog_out" style="display: none;" id="sp_dialog_outDiv">
            <div class="sp_dialog_cont" style="display: none;" id="sp_dialog_contDiv">
                <div class="sp_tan">
                    <h4>
                        [<span id="titleDiv"></span>]金币（BV）支付</h4>
                    <div class="sp_close">
                        <a href="javascript:void(0)" onclick=" funClose() "></a>
                    </div>
                    <div class="clear">
                    </div>
                </div>
                <div class="sp_tan_content">
                    <table>
                        <tr>
                            <td colspan="2" style="line-height: 36px;">
                                <div>
                                    您当前的金币（BV）余额为：￥<%= hidMyShouldPay.Value %></div>
                                <div>
                                    <asp:Label ID="lblIsHavePayPwd" runat="server" Text="您当前没有设置交易密码，请点击" Visible="false"></asp:Label>
                                    <a id="Apaypwdalink" href='/main/account/A_Index.aspx?tomurl=A_PwdSer.aspx' style="color: red"
                                        visible="false" target="_parent" runat="server">设置交易密码</a>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="line-height: 36px;">
                                <div>
                                    您需要支付：￥<%= hidWxPayMoney.Value %>
                                    元/<%= hidPayTime.Value %></div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                交易密码：
                            </td>
                            <td>
                                <input type="password" id="txtPayPassWord" runat="server" />
                                <span style="color: red" id="errPwd" lang="0"></span>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                <asp:Button ID="BtnPay" runat="server" Text="确认支付" CssClass="sqjdbzj" OnClientClick=" return funPay() " />
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
        <%--交易密码弹出层 start--%>
    </div>
</div>
