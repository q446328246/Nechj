<%@ Control Language="C#" %>
<%@ Import Namespace="ShopNum1.ShopAdminWebControl" %>
<script src="js/CommonJS.js" type="text/javascript"> </script>
<script type='text/javascript' src='js/resolution-test.js'> </script>
<script src="/JS/jquery-1.6.2.min.js" type="text/javascript"> </script>
<script type="text/javascript">
    function funCheckTextBoxName() {
        if ($("#<%= TextBoxName.ClientID %>").val() == "") {
            $("#errTextBoxName").html("分类名称不能为空！");
            return false;
        } else {
            $("#errTextBoxName").html("*");
            return true;
        }
    }

    function funCheckTextBoxKeyWrods() {
        if ($("#<%= TextBoxKeyWrods.ClientID %>").val() == "") {
            $("#errTextBoxKeyWrods").html("关键字不能为空！");
            return false;
        } else {
            $("#errTextBoxKeyWrods").html("*");
            return true;
        }
    }

    function funCheckTextBoxOrderID() {
        if ($("#<%= TextBoxOrderID.ClientID %>").val() == "") {
            $("#errTextBoxOrderID").html("关键字不能为空！");
            return false;
        } else {
            $("#errTextBoxOrderID").html("*");
            return true;
        }
    }

    function funCheckButton() {
        if (funCheckTextBoxName() && funCheckTextBoxKeyWrods() && funCheckTextBoxOrderID()) {
            return true;
        }
        return false;
    }

</script>
<div class="biaogenr">
    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="biaod" style="margin-top: 15px;">
        <tr>
            <th colspan="2">
                资讯分类
            </th>
        </tr>
        <tr>
            <td class="bordleft">
                分类名称：
            </td>
            <td class="bordrig" style="padding-top: 8px;">
                <asp:TextBox ID="TextBoxName" MaxLength="20" CssClass="textwb" runat="server" onblur="funCheckTextBoxName()"></asp:TextBox>
                <span class="red" id="errTextBoxName">*</span>
            </td>
        </tr>
        <tr>
            <td class="bordleft">
                分类关键字：
            </td>
            <td class="bordrig" style="padding-top: 8px;">
                <asp:TextBox ID="TextBoxKeyWrods" CssClass="textwb" runat="server" onblur="funCheckTextBoxKeyWrods()"></asp:TextBox>
                <span class="red" id="errTextBoxKeyWrods">*</span>
            </td>
        </tr>
        <tr>
            <td class="bordleft">
                分类描述：
            </td>
            <td class="bordrig" style="padding-top: 8px;">
                <asp:TextBox ID="TextBoxDescription" runat="server" CssClass="textwb" TextMode="MultiLine"
                    Width="600" Height="100"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="bordleft">
                排序号：
            </td>
            <td class="bordrig" style="padding-top: 8px;">
                <asp:TextBox ID="TextBoxOrderID" MaxLength="9" runat="server" CssClass="textwb" onblur="funCheckTextBoxOrderID()"></asp:TextBox>
                <span class="red" id="errTextBoxOrderID">*</span>
            </td>
        </tr>
        <tr>
            <td class="bordleft" style="border-bottom: 1px solid #C6DFFF;">
                是否显示：
            </td>
            <td class="bordrig" style="border-bottom: 1px solid #C6DFFF; padding-top: 8px;">
                <asp:CheckBox ID="CheckBoxIsShow" runat="server" Checked="True" Text="是" />
            </td>
        </tr>
    </table>
    <div class="op_btn">
        <asp:Button ID="ButtonConfrim" runat="server" Text="确定" CssClass="baocbtn" OnClientClick=" return funCheckButton() " />
        <asp:Button ID="ButtonBack" runat="server" Text="返回" CssClass="baocbtn" CausesValidation="False" />
    </div>
    <asp:HiddenField ID="hiddenFieldGuid" runat="server" Value="0" />
</div>
