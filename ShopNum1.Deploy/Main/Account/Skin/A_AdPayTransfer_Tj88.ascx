<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="A_AdPayTransfer_Tj88.ascx.cs"
    Inherits="ShopNum1.Deploy.Main.Account.Skin.A_AdPayTransfer_Tj88" %>
<%@ Import Namespace="ShopNum1.Common" %>
<div id="list_main" class="list_main1">
    <ul id="sidebar">
        <li class='<%=ShopNum1.Common.Common.ReqStr("type")=="0"||ShopNum1.Common.Common.ReqStr("type")==""?"TabbedPanelsTab TabbedPanelsTabSelected":"TabbedPanelsTab" %>'>
            <a href="A_AdPayTransfer_Tj88.aspx?type=0" style="text-decoration: none;">从Tj88提款</a></li>
        <%--<li class='<%=ShopNum1.Common.Common.ReqStr("type")=="1"?"TabbedPanelsTab TabbedPanelsTabSelected":"TabbedPanelsTab" %>'>
            <a href="A_AdPayTransfer_Dv.aspx?type=1" style="text-decoration: none;">转出列表</a></li>
        <li class='<%=ShopNum1.Common.Common.ReqStr("type")=="2"?"TabbedPanelsTab TabbedPanelsTabSelected":"TabbedPanelsTab" %>'>
            <a href="A_AdPayTransfer_Dv.aspx?type=2" style="text-decoration: none;">转入列表</a></li>--%>
    </ul>
    <div id="content">
        <div style='<%=ShopNum1.Common.Common.ReqStr("type")=="0"||ShopNum1.Common.Common.ReqStr("type")==""? "display:block": "display:none"%>'>
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="tabbiao">
                <tr>
                    <td class="tab_r">
                        用户名：
                    </td>
                    <td>
                        <strong style="font-size: 14px;">
                            <asp:Label ID="Lab_MemLoginID" runat="server" Text=""></asp:Label></strong>
                    </td>
                </tr>
                <tr>
                    <td class="tab_r">
                        当前重销币（DV）：
                    </td>
                    <td>
                        <strong class="red" style="font-size: 14px;">￥<asp:Label ID="Lab_AdPayment" runat="server"
                            Text=""></asp:Label>
                        </strong>
                    </td>
                </tr>
                <tr>
                    <td class="tab_r">
                        收款人ID：
                    </td>
                    <td>
                        <input name="input" type="text" class="textwb" id="txt_TransferID" runat="server"
                            onblur="funCheckTransferID()" /><span class="star" id="errTransferID">*</span>
                    </td>
                </tr>
                <tr>
                    <td class="tab_r">
                        确认收款人ID：
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
                        <input name="input" type="text" class="textwb" id="txt_TransferName" runat="server"
                             /><span class="star" id="Span1">*</span>
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
                <tr>
                    <td class="tab_r">
                        &nbsp;
                    </td>
                    <td style="padding: 10px 0px 10px 0px;">
                        <asp:Button ID="Btn_Confirm" runat="server" Text="确认" CssClass="baocbtn" 
                            OnClientClick=" return funCheckButton()" onclick="Btn_Confirm_Click" />
                    </td>
                </tr>
            </table>
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
                        $("#errTransfer").html("转账金额不能大于当前重销币（DV）！");
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
