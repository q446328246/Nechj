<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="M_SendMsg.ascx.cs"
    Inherits="ShopNum1.Deploy.Main.Member.Skin.M_SendMsg" %>
<script src="/JS/jquery-1.6.2.min.js" type="text/javascript"></script>
<script>
    function funCheckUserName() {
        var user = $("#<%=txtUser.ClientID%>").val();
        if (user != "") {
            var arrUser = user.split(',');
            for (var i = 0; i < arrUser.length; i++) {
                if ($("#<%=HiddenFieldUser.ClientID %>").val() != arrUser[i]) {
                    //                alert()
                    $.ajax({
                        type: "get",
                        url: "/api/CheckMemberLogin.ashx",
                        async: false,
                        data: "UserID=" + escape(arrUser[i]) + "&type=userisexist",
                        dataType: "html",
                        success: function (ajaxData) {
                            if (ajaxData == "false") {
                                //                                $("#errUser").html("会员名不存在！");
                                $("#<%=HiddenFieldState.ClientID%>").val("no");
                            }
                            else if (ajaxData == "true") {
                                //                                $("#errUser").html("");
                                $("#<%=HiddenFieldState.ClientID%>").val("ok");
                            }
                        }
                    })
                }
                else {
                    $("#errUser").html("不能给自己发信息！");
                    //$("#<%=HiddenFieldState.ClientID%>").val("no");
                }
            }
            //alert($("#<%=HiddenFieldState.ClientID%>").val());
            if ($("#<%=HiddenFieldState.ClientID%>").val() == "no") {
                $("#errUser").html("发送信息会员名错误！");
            }
            else if ($("#<%=HiddenFieldState.ClientID%>").val() == "ok") {
                $("#errUser").html("");
            }

        }
        else {
            $("#errUser").html("会员名不允许为空！");
        }
    }

    //检查标题
    function funCheckTitle() {
        var title = $("#<%=txtTitle.ClientID%>").val();
        if (title == "") {
            $("#errTitle").html("标题不能为空！");
            return false;
        }
        else {
            $("#errTitle").html("");
            return true;
        }

    }

    //检查内容
    function funCheckMsg() {
        var Msg = $("#<%=txtMsg.ClientID%>").val();
        if (Msg == "") {
            $("#errMsg").html("内容不能为空！");
            return false;
        }
        else {
            $("#errMsg").html("");
            return true;
        }

    }

    function funCheckButton() {
        funCheckUserName();
        if ($("#<%=HiddenFieldState.ClientID%>").val() == "ok" && funCheckTitle() && funCheckMsg()) {
            return true;
        }
        return false;
    }
    
</script>
<style type="text/css">
    .fontSize
    {
        font-size: 12px;
    }
</style>
<div class="tjsp_mian">
    <p class="ptitle">
        <a href="M_Welcome.aspx">我是买家</a><span class="breadcrume_icon">>></span><a href="javascript:void(0)">我的站内信</a><span
            class="breadcrume_icon">>></span><span class="breadcrume_text">发送站内信</span></p>
    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="biaod" style="margin-top: 15px;">
        <tr>
            <th colspan="2" scope="col">
                发送站内信
            </th>
        </tr>
        <tr id="showthis">
            <td class="bordleft" style="border-bottom: solid 1px #c6dfff;">
                会员名：
            </td>
            <td class="bordrig" style="border-bottom: solid 1px #c6dfff;">
                <input type="text" id="txtUser" runat="server" class="textwb fontSize" onblur="funCheckUserName()"
                    size="12" />
                <span class="red">*</span><span class="red" id="errUser"></span>
                <br />
                会员名不能为空,多个会员可以用英文逗号隔开.<br />
            </td>
        </tr>
        <tr>
            <td class="bordleft">
                标题：
            </td>
            <td class="bordrig">
                <input type="text" id="txtTitle" class="textwb fontSize" runat="server" onblur="funCheckTitle()"
                    size="12" />
                <span class="red">*</span> <span class="red" id="errTitle"></span>
            </td>
        </tr>
        <tr>
            <td class="bordleft" style="border-bottom: solid 1px #c6dfff;">
                消息内容：
            </td>
            <td class="bordrig" style="border-bottom: solid 1px #c6dfff;">
                <textarea runat="server" id="txtMsg" class="textwb fontSize" style="width: 400px;
                    height: 130px;" onblur="funCheckMsg()" size="12"></textarea>
                <span class="red">*</span> <span class="red" id="errMsg"></span>
            </td>
        </tr>
    </table>
    <div style="text-align: center; margin: 20px 0px 50px 0px;">
        <asp:Button ID="butSure" runat="server" CssClass="baocbtn" Text="确定" OnClientClick="return funCheckButton()"
            OnClick="butSure_Click" />&nbsp;
        <input name="" type="button" class="baocbtn" value="返回" onclick="location.href='M_Msg.aspx?isread=2&pageid=1';" />
    </div>
</div>
<asp:HiddenField ID="HiddenFieldState" runat="server" />
<asp:HiddenField ID="HiddenFieldUser" runat="server" Value="" />
