<%@ Control Language="C#" AutoEventWireup="True" CodeBehind="M_MemberReport.ascx.cs" Inherits="ShopNum1.Deploy.Main.Member.Skin.M_MemberReport" %>

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
                data: "UserID=" + Member + "&type=userisexist",
                dataType: "html",
                success: function(ajaxData) {
                    if (ajaxData == "false") {
                        $("#errMember").html("举报商家的ID号不存在！");
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
            $("#errMember").html("举报商家的ID号不能为空！");
            $("#errMember").css("color", "red");
            $("#loading").css("display", "none");
        }
    }

    function funCheckUrl() {
        var text = $("#<%=TextBoxProductUrl.ClientID%>").val();
        if (text != "") {
            if (text.indexOf("http://") > -1) {
                $("#errUrl").html("*");
                $("#errUrl").css("color", "red");
                return true;
            }
            else {
                $("#errUrl").html("商品链接请以http://开头");
                $("#errUrl").css("color", "red");
                return false;
            }

        }
        else {
            $("#errUrl").html("商品链接不能为空！");
            $("#errUrl").css("color", "red");
            return false;
        }
    }

    function funCheckType() {
        var type = $("#<%=DropDownListType.ClientID%>").val();
        if (type == "-1") {
            $("#errType").html("请选择一项举报类型！");
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
            $("#errEvidence").html("证据不能为空！");
            $("#errEvidence").css("color", "red");
            return false;
        }
    }

    function funCheckButton() {
        funCheckMember();
        if ($("#<%=HiddenFieldMember.ClientID%>").val() == "ok" && funCheckUrl() && funCheckType() && funCheckEvidence()) {
            return true;
        }
        else {
            return false;
        }
    }
    
</script>
<table width="100%" border="0" cellspacing="0" cellpadding="0" class="biaod">
    <tr>
        <th colspan="2" scope="col">
            我要举报
        </th>
    </tr>
    <tr>
        <td class="bordleft">
            举报商家的ID号：
        </td>
        <td class="bordrig">
            <asp:TextBox ID="TextBoxID" runat="server" CssClass="textwb" onblur="funCheckMember()"></asp:TextBox>
            <span class="red" id="errMember">*</span> <span id="loading" style="clear: both;
                vertical-align: middle; display: none; float: right">
                <img src="/Images/ajax_loading.gif" width="26" height="26" />
            </span>
        </td>
    </tr>
    <tr>
        <td class="bordleft">
            商品链接：
        </td>
        <td class="bordrig">
            <asp:TextBox ID="TextBoxProductUrl" runat="server" CssClass="textwb" onblur="funCheckUrl()"></asp:TextBox>
            <span class="red" id="errUrl">*</span>&nbsp;&nbsp;以http://开头。
        </td>
    </tr>
    <tr>
        <td class="bordleft">
            举报类型：
        </td>
        <td class="bordrig">
            <asp:DropDownList ID="DropDownListType" runat="server" CssClass="textwb" onchange="funCheckType()">
                <asp:ListItem Value="-1">-请选择-</asp:ListItem>
                <asp:ListItem Value="炒作信用度">炒作信用度</asp:ListItem>
                <asp:ListItem Value="哄抬物价">哄抬物价</asp:ListItem>
                <asp:ListItem Value="图片发布侵权">图片发布侵权</asp:ListItem>
                <asp:ListItem Value="发布广告信息">发布广告信息</asp:ListItem>
                <asp:ListItem Value="支付方式不符合商品">支付方式不符合商品</asp:ListItem>
                <asp:ListItem Value="出售禁售货">出售禁售货</asp:ListItem>
                <asp:ListItem Value="放错类目属性">放错类目属性</asp:ListItem>
                <asp:ListItem Value="重复铺货">重复铺货</asp:ListItem>
                <asp:ListItem Value="滥用关键字">滥用关键字</asp:ListItem>
            </asp:DropDownList>
            <span class="red" id="errType">*</span>
        </td>
    </tr>
    <tr>
        <td class="bordleft">
            证据：
        </td>
        <td class="bordrig" style="padding-top: 8px;">
            <asp:TextBox ID="TextBoxEvidence" runat="server" TextMode="MultiLine" onblur="funCheckEvidence()"
                Height="160" Width="500" CssClass="textwb"></asp:TextBox>
            <span class="red" id="errEvidence">*</span>
        </td>
    </tr>
    <tr>
        <td class="bordleft" style="border-bottom: solid 1px #c6dfff;">
            上传图片：
        </td>
        <td class="bordrig" style="border-bottom: solid 1px #c6dfff;">
            <asp:FileUpload ID="FileUploadImage" runat="server" name="fileField" />
            <%--   <span class="red">*</span>--%><span>上传图片不超过5M，上传图片支持gif、jpg、png、bmp格式。</span>
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
