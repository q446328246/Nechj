<%@ Control Language="C#" AutoEventWireup="True" CodeBehind="M_MemberComplaints.ascx.cs" Inherits="ShopNum1.Deploy.Main.Member.Skin.M_MemberComplaints" %>

<script src="../js/jquery-1.6.2.min.js" type="text/javascript"></script>
<script type="text/javascript">
    function funCheckMember() {
        var Member = $("#<%=TextBoxID.ClientID%>").val();
        if (Member != "") {
            $("#loading").css("display", "block");
            //检查【举报商家的ID号】是否存在！
            $.ajax({
                type: "get",
                url: "/api/CheckMemberLogin.ashx",
                async: false,
                data: "UserID=" + escape(Member) + "&type=userisexist",
                dataType: "html",
                success: function(ajaxData) {
                    if (ajaxData == "false") {
                        $("#errMember").html("投诉商家的ID号不存在！");
                        $("#errMember").css("color", "red");
                        $("#loading").css("display", "none");
                        $("#<%=HiddenFieldMember.ClientID%>").val("no");
                    } else if (ajaxData == "true") {
                        $("#errMember").html("*");
                        $("#errMember").css("color", "red");
                        $("#loading").css("display", "none");
                        $("#<%=HiddenFieldMember.ClientID%>").val("ok");
                    }
                }
            });
        }
        else {
            $("#errMember").html("投诉商家的ID号不能为空！");
            $("#errMember").css("color", "red");
            $("#loading").css("display", "none");
        }
    }

    function funCheckOrderID() {
        var text = $("#<%=TextBoxOrderID.ClientID%>").val();
        if (text != "") {
            $("#errUrl").html("*");
            $("#errUrl").css("color", "red");
            return true;
        }
        else {
            $("#errUrl").html("商品订单不能为空！");
            $("#errUrl").css("color", "red");
            return false;
        }
    }

    function funCheckType() {
        var type = $("#<%=DropDownListType.ClientID%>").val();
        if (type == "-1") {
            $("#errType").html("请选择一项投诉类型！");
            $("#errType").css("color", "red");
            return false;
        }
        else {
            $("#errType").html("*");
            $("#errType").css("color", "red");
            return true;
        }
    }

    //证据
    function funCheckEvidence() {
        var Evidence = $("#<%=TextBoxEvidence.ClientID%>").val();
        if (Evidence != "") {
            $("#errEvidence").html("*");
            $("#errEvidence").css("color", "red");
            return true;
        }
        else {
            $("#errEvidence").html("说明不能为空！");
            $("#errEvidence").css("color", "red");
            return false;
        }

    }

    function funCheckButton() {
        funCheckMember();
        if ($("#<%=HiddenFieldMember.ClientID%>").val() == "ok" && funCheckOrderID() && funCheckType() && funCheckEvidence()) {
            return true;
        }
        else {
            return false;
        }
    }

    //获取url参数值
    function getQueryString(name) {
        var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)", "i");
        var r = window.location.search.substr(1).match(reg);
        if (r != null) return unescape(r[2]); return null;
    }
    $(function () {
        var arry = getQueryString("shopid");
        if (arry != null) {
            //$("#<%=TextBoxID.ClientID%>").val(arry.toString().split("|")[0]);
            $("#<%=TextBoxOrderID.ClientID%>").val(arry.toString().split("|")[1]);
        }
    });
</script>
<table width="100%" border="0" cellspacing="0" cellpadding="0" class="biaod">
    <tr>
        <th colspan="2">
            我要投诉
        </th>
    </tr>
    <tr>
        <td class="bordleft">
            投诉商家的ID号：
        </td>
        <td class="bordrig">
            <asp:TextBox ID="TextBoxID" runat="server" CssClass="textwb" onblur="funCheckMember()"></asp:TextBox><span
                class="star" id="errMember">*</span> <span id="loading" style="clear: both; vertical-align: middle;
                    display: none; float: right">
                    <img src="/Images/ajax_loading.gif" width="26" height="26" />
                </span>
        </td>
    </tr>
    <tr>
        <td class="bordleft">
            订单编号：
        </td>
        <td class="bordrig">
            <asp:TextBox ID="TextBoxOrderID" runat="server" CssClass="textwb" onblur="funCheckOrderID()"></asp:TextBox><span
                class="star" id="errUrl">*</span>
        </td>
    </tr>
    <tr>
        <td class="bordleft">
            投诉类型：
        </td>
        <td class="bordrig">
            <asp:DropDownList ID="DropDownListType" runat="server" CssClass="tselect2" onchange="funCheckType()">
                <asp:ListItem Value="-1">-请选择-</asp:ListItem>
                <asp:ListItem Value="恶意骚扰">恶意骚扰</asp:ListItem>
                <asp:ListItem Value="售后保障服务">售后保障服务</asp:ListItem>
                <asp:ListItem Value="未收到货">未收到货</asp:ListItem>
                <asp:ListItem Value="违背承诺">违背承诺</asp:ListItem>
                <asp:ListItem Value="其它">其它</asp:ListItem>
            </asp:DropDownList>
            <span class="star" id="errType">*</span>
        </td>
    </tr>
    <tr>
        <td class="bordleft">
            说明：
        </td>
        <td class="bordrig" style="padding-top: 8px;">
            <asp:TextBox ID="TextBoxEvidence" runat="server" TextMode="MultiLine" onblur="funCheckEvidence()"
                CssClass="textwb1"></asp:TextBox><span class="star" id="errEvidence">*</span>
        </td>
    </tr>
    <tr>
        <td class="bordleft" style="border-bottom: 1px solid #C6DFFF;">
            上传凭证：
        </td>
        <td class="bordrig" style="border-bottom: 1px solid #C6DFFF;">
            <asp:FileUpload ID="FileUploadImage" runat="server" name="fileField" /><span>上传凭证不超过1M，上传图片支持gif、jpg、png、bmp格式。</span>
        </td>
    </tr>
</table>
<div style="text-align: center; margin: 20px 0px 50px 0px;">
    <asp:Button ID="ButtonSubmit" runat="server" Text="确定" CssClass="baocbtn" 
        OnClientClick="return  funCheckButton()" onclick="ButtonSubmit_Click" />
    <asp:Button ID="ButtonBackList" runat="server" Text="返回" CssClass="baocbtn" 
        onclick="ButtonBackList_Click" />
</div>
<asp:HiddenField ID="HiddenFieldMember" runat="server" Value="no" />
