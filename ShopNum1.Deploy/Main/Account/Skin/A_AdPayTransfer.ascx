<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="A_AdPayTransfer.ascx.cs"
    Inherits="ShopNum1.Deploy.Main.Account.Skin.A_AdPayTransfer" %>
<%@ Import Namespace="ShopNum1.Common" %>
<div id="list_main" class="list_main1">
    <ul id="sidebar">
        <li class='<%=ShopNum1.Common.Common.ReqStr("type")=="0"||ShopNum1.Common.Common.ReqStr("type")==""?"TabbedPanelsTab TabbedPanelsTabSelected":"TabbedPanelsTab" %>'>
            <a href="A_AdPayTransfer.aspx?type=0" style="text-decoration: none;">转账</a></li>
        <li class='<%=ShopNum1.Common.Common.ReqStr("type")=="1"?"TabbedPanelsTab TabbedPanelsTabSelected":"TabbedPanelsTab" %>'>
            <a href="A_AdPayTransfer.aspx?type=1" style="text-decoration: none;">转出列表</a></li>
        <li class='<%=ShopNum1.Common.Common.ReqStr("type")=="2"?"TabbedPanelsTab TabbedPanelsTabSelected":"TabbedPanelsTab" %>'>
            <a href="A_AdPayTransfer.aspx?type=2" style="text-decoration: none;">转入列表</a></li>
    </ul>
    <div id="content">
        <div style='<%=ShopNum1.Common.Common.ReqStr("type")=="0"||ShopNum1.Common.Common.ReqStr("type")==""? "display:block": "display:none"%>'>
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="tabbiao">
                <tr>
                    <td class="tab_r">
                        用户编号：
                    </td>
                    <td>
                        <strong style="font-size: 14px;">
                            <asp:Label ID="Lab_MemLoginID" runat="server" Text=""></asp:Label></strong>
                    </td>
                </tr>
                <tr>
                    <td class="tab_r">
                        当前人民币：
                    </td>
                    <td>
                        <strong class="red" style="font-size: 14px;">￥<asp:Label ID="Lab_AdPayment" runat="server"
                            Text=""></asp:Label>
                        </strong>
                    </td>
                </tr>
                <tr>
                    <td class="tab_r">
                        收款人编号：
                    </td>
                    <td>
                        <input name="input" type="text" class="textwb" id="txt_TransferID" runat="server"
                            onblur="funCheckTransferID()" /><span class="star" id="errTransferID">*</span>
                    </td>
                </tr>
                <tr>
                    <td class="tab_r">
                        确认收款人编号：
                    </td>
                    <td>
                        <input name="input" type="text" class="textwb" id="txt_ConfirmTransferID" runat="server"
                            onblur="funSameName()" /><span class="star" id="errConfirmTransferID">*</span>
                    </td>
                </tr>
                <tr>
                    <td class="tab_r">
                        确认收款人姓名：
                    </td>
                    <td>
                        <input name="input" type="text" class="textwb" id="txt_TransferName" runat="server" /><span
                            class="star" id="Span1">*</span>
                    </td>
                </tr>
                <tr>
                    <td class="tab_r">
                        转账金额：
                    </td>
                    <td>
                        <input name="input" type="text" class="textwb" id="txt_Transfer" runat="server" value="0.00"
                            style="width: 100px;" onblur="funTransfer()" /><span class="star">元</span><span id="errTransfer"
                                style="color: Red"></span>
                    </td>
                </tr>
                <tr>
                    <td class="tab_r">
                        交易密码：
                    </td>
                    <td>
                        <input name="input" type="password" class="textwb" id="input_PayPwd" runat="server"
                            onblur="funCheckPayPwd()" /><span class="star" id="errPwd">*</span>
                    </td>
                </tr>
                <tr>
                    <td class="tab_r">
                        会员备注：
                    </td>
                    <td>
                        <textarea id="txt_Remark" cols="20" rows="2" class="textwb" style="width: 430px;
                            height: 90px; margin-top: 5px;" runat="server" onchange="CheckFull(this,200)"></textarea><br />
                        (会员转账备注长度不能大于100个字符) <span class="gray1" style="color: Red">&nbsp;</span>
                    </td>
                </tr>
                <tr id="tr1221" runat="server">
                    <td class="tab_r">
                        <span class="form_left">绑定手机号码： </span>
                    </td>
                    <td>
                        <asp:Label ID="nextmobile" runat="server" Text="" CssClass="orm_right f14" runat="server">
                
                        </asp:Label>
                    </td>
                </tr>
                <tr id="tr12211" runat="server">
                    <td class="tab_r">
                        <span class="form_left">验证码： </span>
                    </td>
                    <td>
                        <input type="text" id="txtMCode" style="border: 1px solid #CCCCCC; height: 20px;
                            width: 80px;" onblur="existcode()" />
                        <img src="/imagecode.aspx?javascript:Math.random()" id="ImgX" border="0" onclick="reloadcode2()"
                            alt="看不清?点一下" />
                        <a onclick="reloadcode2()">看不清楚？</a>
                    </td>
                </tr>
                <tr id="tr12221" runat="server">
                    <td class="tab_r">
                    </td>
                    <td>
                        <input type="text" id="M_code" name="code" data-tip="验证码" maxlength="6" class="intext intext_short nullv tov vfb"
                            autocomplete="off" runat="server" disabled="disabled" runat="server" />
                        <input type="button" id="J_ver_btn" class="btn btn-white vc_btn mr10 J_ftrack" value="点此免费获取"
                            style="width: 100px; height: 25px; margin-left: 10px" />

                        <a class="grew ml10 l" id="J_cannot_receive" href="javascript:void(0);">收不到短信验证码？
                        </a><span id="spanConfirm"></span>
                        <div style="display: none;" class="tooltip cp_tooltip">
                            短信验证码发送后30分钟内均可使用。验证码短信经过网关时，网络通讯异常可能会造成短信丢失或延时，请您耐心等待，或者换一个时间段进行相关操作。
                        </div>
                        <span class="vc vf" id="yzMsg" style="display: none">请输入验证码 </span>
                         <div class="form_row form_text_row">
                    <span class="form_left"></span><span class="form_right gw" id="spanShowMsg" state="0" style="color: Red;
                            padding-left: 10px;">
                </div>
               
                    </td>
                </tr>
                <tr>
                    <td class="tab_r">
                        &nbsp;
                    </td>
                    <td style="padding: 10px 0px 10px 0px;">
                        <asp:Button ID="Btn_Confirm" runat="server" Text="确认" CssClass="baocbtn" OnClientClick=" return funCheckButton()"
                            OnClick="Btn_Confirm_Click" />
                    </td>
                </tr>
            </table>
        </div>
        <div style='<%=ShopNum1.Common.Common.ReqStr("type")=="0"||ShopNum1.Common.Common.ReqStr("type")==""? "display:none": "display:block"%>'>
            <div class="pad">
                <table border="0" cellspacing="0" cellpadding="0" class="lineh">
                    <tr class="up_spac">
                        <td align="right">
                            转账单号：
                        </td>
                        <td>
                            <input type="text" runat="server" id="txt_OrderNum" class="ss_nr1" />
                        </td>
                        <td align="right" class="ss_nr_spac">
                            操作时间：
                        </td>
                        <td>
                            <table cellpadding="0" cellspacing="0" border="0">
                                <tr>
                                    <td>
                                        <input type="text" class="ss_nrduan Wdate" runat="server" id="txt_StartTime" onclick="WdatePicker({dateFmt:'yyyy-MM-dd'})" />
                                    </td>
                                    <td class="line_spac">
                                        -
                                    </td>
                                    <td>
                                        <input type="text" class="ss_nrduan Wdate" runat="server" id="txt_EndTime" onclick="WdatePicker({dateFmt:'yyyy-MM-dd'})" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td>
                            <asp:Button ID="Btn_Select" runat="server" Text="查询" CssClass="chax btn_spc" />
                        </td>
                    </tr>
                </table>
            </div>
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="btntable_top">
                <tr>
                    <td style="border-left: solid 1px #e3e3e3; text-align: left;">
                        &nbsp;&nbsp;&nbsp; 转账笔数：<span style="color: #ff0000; font-weight: bold;"><asp:Label
                            ID="lab_PayNum" runat="server" Text="0"></asp:Label>
                        </span>笔 &nbsp;&nbsp;&nbsp; 转账金额： ￥<span style="color: #ff0000; font-weight: bold;"><asp:Label
                            ID="lab_PayTransfer" runat="server" Text="0.00"></asp:Label>
                        </span>
                    </td>
                </tr>
            </table>
            <table border="0" cellspacing="1" cellpadding="0" class="biaodhd1" width="100%">
                <tr>
                    <th>
                        转账单号
                    </th>
                    <th>
                        操作日期
                    </th>
                    <th>
                        转账金额
                    </th>
                    <th>
                        收款人ID
                    </th>
                    <th>
                        备注
                    </th>
                </tr>
                <asp:Repeater runat="server" ID="Rep_PayTransfer">
                    <ItemTemplate>
                        <tr>
                            <td>
                                <%# DataBinder.Eval(Container.DataItem, "OrderNumber")%>
                            </td>
                            <td>
                                <%# DataBinder.Eval(Container.DataItem, "Date")%>
                            </td>
                            <td style="color: Red">
                                <%=ShopNum1.Common.Common.ReqStr("type")=="2"?"+":"-"%><%# DataBinder.Eval(Container.DataItem, "OperateMoney")%>
                            </td>
                            <td>
                                <%# DataBinder.Eval(Container.DataItem, "RMemberID")%>
                            </td>
                            <td class="picture">
                                <span style="display: none;">
                                    <%#Eval("Memo").ToString() %></span>
                                <%#(Eval("Memo").ToString().Length > 15? Eval("Memo").ToString().Substring(0, 15) + "..." : Eval("Memo").ToString())%>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                <asp:Repeater ID="Rep_NoValue" runat="server" Visible="false">
                    <ItemTemplate>
                        <tr>
                            <td style="height: 86px;" colspan="5">
                                <div class="no_data">
                                    <%# DataBinder.Eval(Container.DataItem, "NoValue")%>
                                </div>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
            <!--分页-->
            <div class="fenye">
                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="btntable_b">
                    <tr>
                        <td style="border-right: none; border-left: solid 1px #e3e3e3; width: 30px;">
                            &nbsp;
                        </td>
                        <td style="border-left: none;">
                            <div id="pageDiv" runat="server" class="fy">
                            </div>
                        </td>
                    </tr>
                </table>
            </div>
            <!--分页-->
        </div>
    </div>
</div>
<style type="text/css">
    #tooltip
    {
        position: absolute;
        z-index: 1000;
        max-width: 300px;
        width: auto !important;
        width: auto;
        background: #e3e3e3;
        border: #FEFFD4 solid 1px;
        text-align: left;
        padding: 3px;
    }
    #tooltip p
    {
        padding: 10px;
        color: #FF0000;
        font: 12px verdana,arial,sans-serif;
        line-height: 180%;
    }
</style>
<input type="hidden" value="" id="havaUser" runat="server" />
<input type="hidden" value="" id="HiddenPayPwd" runat="server" />
<%--    <script type="text/javascript" language="javascript">--%>
<script type="text/javascript" language="javascript">
    //         function ontoPage(txtId)
    //         {
    //               location.href='?sort=<%=ShopNum1.Common.Common.ReqStr("sort")%>&typeid=<%=ShopNum1.Common.Common.ReqStr("typeid")%>&pageid='+$("#txtIndex").val();
    //         }
    $(function () {
        //标题提示效果处
        var sweetTitles = {
            x: 10, y: 20, tipElements: ".picture", init: function () {
                $(this.tipElements).mouseover(function (e) {
                    var myTitle = $(this).find("span").html(); var tooltip = "";
                    tooltip = "<div id='tooltip'><p>" + myTitle + "</p></div>";
                    $('#tooltip').css({ "opacity": "0.8", "top": (e.pageY + 20) + "px", "left": (e.pageX - 50) + "px" }).show('fast'); $('body').append(tooltip);
                }).mouseout(function () { $('#tooltip').remove(); }).mousemove(function (e) { $('#tooltip').css({ "top": (e.pageY + 20) + "px", "left": (e.pageX - 50) + "px" }); });
            }
        };
        sweetTitles.init();
    });
</script>
<script>

    function funCheckButton() {
        if ($("#<%=txt_Remark.ClientID%>").val().length > 100) {
            alert("会员转账备注长度不能大于100个字符！"); return false;
        }
        funCheckTransferID(); funTransfer(); funCheckPayPwd();
        if ($("#<%=havaUser.ClientID%>").val() == "1" && funTransfer() && $("#<%=HiddenPayPwd.ClientID %>").val() == "1") {
            return true;
        }
        return false;
    }

    function funCheckPayPwd() {
        var payPwd = $("#<%=input_PayPwd.ClientID%>").val();
        if (payPwd != "") {
            $("#errPwd").html("查询中...");
            $.ajax({
                type: "get",
                url: "/Api/ShopAdmin/S_AdminOpt.ashx?date=" + new Date(),
                async: false,
                data: "type=paypwd&payPwd=" + payPwd,
                dataType: "html",
                success: function (ajaxData) {
                    if (ajaxData != "") {
                        if (ajaxData == "false") {
                            $("#errPwd").html("交易密码错误！");
                            $("#<%=HiddenPayPwd.ClientID %>").val("0");
                            return true;
                        }
                        else if (ajaxData == "true") {
                            $("#errPwd").html("*");
                            $("#<%=HiddenPayPwd.ClientID %>").val("1");
                            return false;
                        }
                    }
                }
            });
        }
        else {
            $("#errPwd").html("交易密码不能为空！");
        }

    }

    function funTransfer() {
        var Transfer = $("#<%=txt_Transfer.ClientID%>").val()
        if (Transfer != "") {
            var oo = /^(-)?(([1-9]{1}\d*)|([0]{1}))(\.(\d){1,2})?$/;
            if (!oo.test(Transfer)) {
                $("#errTransfer").html("转账金额格式错误！");
                return false;
            }
            else {
                if (parseFloat(Transfer) > 0) {
                    var txtMoney = parseFloat($("#<%=Lab_AdPayment.ClientID%>").text());
                    if (txtMoney < parseFloat(Transfer)) {
                        $("#errTransfer").html("转账金额不能大于当前人民币！");
                        return false;
                    }
                    else {
                        $("#errTransfer").html("");
                        return true;
                    }
                }
                else {
                    $("#errTransfer").html("转账金额不能为0或者负数！");
                    return false;
                }

            }
            return false;
        }
        else {
            $("#errTransfer").html("转账金额不能为空！");
            return false;
        }
    }

    function funSameName() {
        var samename = $("#<%=txt_ConfirmTransferID.ClientID%>").val();
        var yuanname = $("#<%=txt_Transfer.ClientID%>ID").val();
        if (samename != yuanname) {
            $("#errConfirmTransferID").html("确认收款人ID输入不正确！");
            return false;
        }
        else {
            $("#errConfirmTransferID").html("*");
            return true;
        }
    }


    function funCheckTransferID() {
        var TransferID = $("#<%=txt_Transfer.ClientID%>ID").val();
        if (TransferID != "") {
            if ($("#<%=Lab_MemLoginID.ClientID%>").text() == TransferID) {
                $("#errTransferID").html("不能给自己转账！");
                return false;
            }
            else {
                //收款人是否存在
                $.ajax({
                    url: "/api/CheckMemberLogin.ashx",
                    data: encodeURI("type=userisexist&UserID=" + TransferID + ""), //中文编码
                    success: function (result) {
                        if (result != null) {
                            if (result) {
                                $("#errTransferID").html("*");
                                $("#<%=havaUser.ClientID%>").val("1")
                                return true;
                            } else {
                                $("#errTransferID").html("收款人不存在！");
                                $("#<%=havaUser.ClientID%>").val("0")
                                return false;
                            }
                        } else {
                            return false;
                        }
                    }
                });

                $("#errTransferID").html("");
            }
        } else { $("#errTransferID").html("收款人不能为空！"); return false; }
    }
</script>
<script type="text/javascript">
    function reloadcode2() {
        var verify = document.getElementById('ImgX');
        verify.setAttribute('src', '/imagecode.aspx?' + Math.random());
    }
    //验证码
    function existcode() {
        var boolresult = true;
        var inputcontrol = $("#txtMCode").val();
        var context = document.getElementById("spanShowMsg");
        if (inputcontrol != "") {
            $.ajax({
                url: "/api/CheckMemberLogin.ashx",
                data: "type=findpwdverifycode&findpwdcode=" + inputcontrol + "",
                success: function (result) {
                    if (result == "true") {
                        context.innerHTML = "";
                        //context.className="onCorrect1";
                        $("#spanShowMsg").attr("state", "1");
                        boolresult = true;
                    } else {
                        boolresult = false;
                        context.innerHTML = "验证码错误";
                        //context.className="onError1";
                        $("#spanShowMsg").attr("state", "0");
                    }
                }
            });
        }
        else {
            context.innerHTML = "验证码不能为空";
            $("#spanShowMsg").attr("state", "0");
            //context.className="onError1";
            boolresult = false;
        }
        return boolresult;
    }

    var timerId;
    var $thisid;
    $(function () {

        $("#J_cannot_receive").click(function () {
            $(".cp_tooltip").show(); setTimeout(function () { $(".cp_tooltip").hide(); }, 3000);
        });
        $("#J_ver_btn").click(function () {
            if ($("#txtMCode").val() == "") {
                $("#spanShowMsg").text("验证码不能为空！"); return false;
            }
            if ($("#spanShowMsg").attr("state") == "0") {
                $("#spanShowMsg").text("验证码不正确！"); return false;
            }
            $("#J_ver_btn").attr("disabled", "disabled");
            $("#<%= M_code.ClientID %>").removeAttr("disabled");
            $("#spanConfirm").get(0).className = "";
            // $("#spanShowMsg").get(0).className="onCorrect1";
            $("#spanShowMsg").text("短信已发送，请耐心等待...");
            $("#spanShowMsg").attr("style", "color:green; padding-left:10px;");
            $thisid = $(this);
            timerId = setInterval("goTo()", 1000);
            $.get("/Api/CheckInfo.ashx?type=2&Mobile=" + $("#<%=nextmobile.ClientID%>").text(), null, function (data) {
                //alert("手机短信验证码已发送，请耐心等待......");
                if (data != "1") {
                    $("#spanShowMsg").get(0).className = "onError1";
                    $("#spanShowMsg").text("短信发送出现异常，请重新验证");
                }
            });
        });

        $("#<%= M_code.ClientID %>").focus(function () {
            $("#spanShowMsg").get(0).className = "onTips1";
            $("#spanShowMsg").text("验证码是6位字符");
            $("#spanConfirm").get(0).className = "";
        });

        $("#<%= M_code.ClientID %>").blur(function () {
            if (this.value == "") {
                $("#spanShowMsg").get(0).className = "onError1";
                $("#spanShowMsg").text("请输入验证码");
            }
            else {
                $.get("/Api/CheckInfo.ashx?type=3&key=" + $("#<%=M_code.ClientID%>").val() + "&mobile=" + $("#<%=nextmobile.ClientID%>").text(), null, function (data) {
                    if (data == "1") {
                        $("#spanConfirm").get(0).className = "onCorrect1";
                        $("#spanConfirm").text("");
                        $("#spanShowMsg").get(0).className = "";
                        $("#spanShowMsg").text("");
                    }
                    else {
                        $("#spanShowMsg").get(0).className = "onError1";
                        $("#spanShowMsg").text("验证码错误或已过期，请重新输入!");
                    }
                });
            }
        });
    });

    var i = 60;
    function goTo() {
        i--;
        $thisid.val("已发送验证码(" + i + "秒)");
        if (i == 0) {
            $thisid.val("免费获取验证码");
            clearInterval(timerId); i = 60;
            $thisid.removeAttr("disabled");
        }
    }
</script>
<%--<script type="text/javascript" language="javascript">
    function Btn_Confirm_Click() {
        if ($("#<%= M_code.ClientID %>").val() == "") {
            $("#spanShowMsg").get(0).className = "onError1";
            $("#spanShowMsg").text("请输入验证码");
            return;
        }

        $.get("/Api/CheckInfo.ashx?type=3&key=" + $("#<%=M_code.ClientID%>").val() + "&mobile=" + $("#<%=nextmobile.ClientID%>").text(), null, function (data) {
            if (data == "1") {
                window.location.href = "A_UpProtection.aspx?Mobile=" + $("#<%=nextmobile.ClientID%>").text() + "&key=" + $("#<%=M_code.ClientID%>").val();
            }
            else {
                $("#spanShowMsg").get(0).className = "onError1";
                $("#spanShowMsg").text("验证码错误或已过期，请重新输入!");
            }
        });
    }

    function GoURL() {
        window.location.href = "A_UpProtection.aspx?Mobile=" + $("#<%=nextmobile.ClientID%>").text() + "&key=" + $("#<%=M_code.ClientID%>").val() + "&type=Email";
    };
    function goNext() {
        setTimeout(GoURL, 1000);
    }

</script>--%>
