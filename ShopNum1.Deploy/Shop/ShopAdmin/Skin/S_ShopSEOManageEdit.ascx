<%@ Control Language="C#" %>
<%@ Import Namespace="ShopNum1.ShopAdminWebControl" %>
<script src="../js/jquery-1.6.2.min.js" type="text/javascript"> </script>
<script>
    //页面名
    function funCheckPageName() {
        var PageName = $("#<%= TextBoxPageName.ClientID %>").val();
        if (PageName == "") {
            $("#errPageName").html("页面名不能为空！");
            return false;
        } else {
            $("#errPageName").html("*");
            return true;
        }
    }

    //标题

    function funCheckTitle() {
        var Title = $("#<%= TextBoxTitle.ClientID %>").val();
        if (Title == "") {
            $("#errTitle").html("标题不能为空！");
            return false;
        } else {
            $("#errTitle").html("*");
            return true;
        }
    }

    //关键字

    function funCheckKeyWord() {
        var KeyWord = $("#<%= TextBoxKeyWord.ClientID %>").val();
        if (KeyWord == "") {
            $("#errKeyWord").html("关键字不能为空！");
            return false;
        } else {
            $("#errKeyWord").html("*");
            return true;
        }
    }

    //说明

    function funCheckEsec() {
        var Esec = $("#<%= TextBoxEsec.ClientID %>").val();
        if (Esec == "") {
            $("#errEsec").html("说明不能为空！");
            return false;
        } else {
            $("#errEsec").html("*");
            return true;
        }
    }

    //提交事件

    function funCheckButton() {
        if (funCheckPageName() && funCheckTitle() && funCheckKeyWord() && funCheckEsec()) {
            return true;
        }
        return false;
    }

</script>
<div class="biaogenr">
    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="biaod" style="margin-top: 15px;">
        <tr>
            <th colspan="2" scope="col">
                SEO设置
            </th>
            <tr>
                <td class="bordleft" style="width: 100">
                    页面名：
                </td>
                <td class="bordrig" style="padding-top: 8px;">
                    <asp:TextBox ID="TextBoxPageName" runat="server" CssClass="textwb" onblur="funCheckPageName()"></asp:TextBox>
                    <span class="red" id="errPageName">*</span>
                </td>
            </tr>
            <tr>
                <td class="bordleft">
                    标题：
                </td>
                <td class="bordrig" style="padding-top: 8px;">
                    <asp:TextBox ID="TextBoxTitle" runat="server" CssClass="textwb" onblur="funCheckTitle()"></asp:TextBox>
                    <span class="red" id="errTitle">*</span>
                </td>
            </tr>
            <tr>
                <td class="bordleft">
                    关键字：
                </td>
                <td class="bordrig" style="padding-top: 8px;">
                    <asp:TextBox ID="TextBoxKeyWord" runat="server" CssClass="textwb" onblur="funCheckKeyWord()"></asp:TextBox>
                    <span class="red" id="errKeyWord">*</span>
                </td>
            </tr>
            <tr>
                <td class="bordleft">
                    说明：
                </td>
                <td class="bordrig" style="padding-top: 8px;">
                    <asp:TextBox ID="TextBoxEsec" runat="server" CssClass="textwb" onblur="funCheckEsec()"
                        Width="300" Height="90" TextMode="MultiLine"></asp:TextBox>
                    <span class="red" id="errEsec">*</span>
                </td>
            </tr>
    </table>
    <div class="op_btn">
        <asp:Button ID="ButtonSubmit" runat="server" Text="确定" CssClass="baocbtn" OnClientClick=" return funCheckButton() " />
        <asp:Button ID="ButtonBackList" runat="server" Text="返回" CssClass="baocbtn" />
    </div>
</div>
<asp:HiddenField ID="HiddenFieldID" runat="server" />
