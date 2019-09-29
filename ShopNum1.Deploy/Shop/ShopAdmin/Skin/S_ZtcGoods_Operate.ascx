<%@ Control Language="C#" %>
<%@ Import Namespace="ShopNum1.ShopAdminWebControl" %>
<script src="/JS/jquery-1.6.2.min.js" type="text/javascript"> </script>
<script>
    function showDialog() {
        funOpen();
        $("#showiframe").attr("src", "/Shop/ShopAdmin/S_ShowShopPhoto.aspx?txtid=<%= TextBoxOrganizImg.ClientID %>&imgid=<%= ImageProduct.ClientID %>");
    }
</script>
<div class="sp_dialog sp_dialog_out" style="display: none;" id="sp_dialog_outDiv">
    <div class="sp_dialog_cont" style="display: none;" id="sp_dialog_contDiv">
        <div class="sp_tan">
            <h4>
                选择图片</h4>
            <div class="sp_close">
                <a href="javascript:void(0)" onclick=" funClose() "></a>
            </div>
            <div class="clear">
            </div>
        </div>
        <div class="sp_tan_content">
            <iframe src="" id="showiframe" width="100%" height="470" frameborder="0" scrolling="no">
            </iframe>
        </div>
    </div>
</div>
<div class="biaogenr">
    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="biaod">
        <tr>
            <th colspan="2">
                直通车编辑
            </th>
        </tr>
        <tr>
            <td height="30" width="30%" class="bordleft">
                直通车名称：
            </td>
            <td class="bordrig">
                <ShopNum1:TextBox ID="TextBoxZtcName" CanBeNull="必填" MaxLength="100" runat="server"
                    CssClass="textwb" />
            </td>
        </tr>
        <tr>
            <td class="bordleft">
                <asp:Label ID="Label3" runat="server" Text="商品图片："></asp:Label>
            </td>
            <td class="bordrig">
                <asp:Image ID="ImageProduct" runat="server" Width="200" Height="200" onerror="javascript:this.src='/ImgUpload/noImage.gif'" /><br />
                <asp:TextBox ID="TextBoxOrganizImg" runat="server" CssClass="textwb"></asp:TextBox><font
                    color="red">*</font>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="TextBoxOrganizImg"
                    Display="Dynamic" ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>
                <input id="bt2" class="selpic" style="bottom: -5px; position: relative;" type="button"
                    value="选择图片" onclick=" showDialog() " />
            </td>
        </tr>
        <tr>
            <td class="bordleft">
                出售价格：
            </td>
            <td class="bordrig">
                <ShopNum1:TextBox ID="TextBoxSellPrice" CanBeNull="必填" MaxLength="100" runat="server"
                    CssClass="textwb" />
            </td>
        </tr>
        <tr>
            <td class="bordleft">
                销售数量：
            </td>
            <td class="bordrig">
                <ShopNum1:TextBox ID="TextBoxSellCount" CanBeNull="必填" MaxLength="100" runat="server"
                    CssClass="textwb" />
            </td>
        </tr>
        <tr>
            <td class="bordleft">
                <asp:Label ID="Label1" runat="server" Text="剩余金币（BV）："></asp:Label>
            </td>
            <td class="bordrig">
                <asp:Label ID="LabelZtcMoneyShow" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="bordleft">
                <asp:Label ID="Label4" runat="server" Text="开始时间："></asp:Label>
            </td>
            <td class="bordrig">
                <asp:Label ID="LabelStartTime" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="bordleft">
                <asp:Label ID="Label5" runat="server" Text="审核时间："></asp:Label>
            </td>
            <td class="bordrig">
                <asp:Label ID="LabelCreateTime" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="bordleft">
                <asp:Label ID="Label2" runat="server" Text="开启状态："></asp:Label>
            </td>
            <td class="bordrig">
                <asp:Label ID="LabelState" runat="server" Text=""></asp:Label>(此状态由平台更改)
            </td>
        </tr>
        <tr id="trShow" runat="server">
            <td class="bordleft">
                <asp:Label ID="LabelContent" runat="server" Text="显示状态："></asp:Label>
            </td>
            <td class="bordrig">
                <asp:Label ID="LabelShowState" runat="server" Text=""></asp:Label>
            </td>
        </tr>
    </table>
    <div class="op_btn">
        <asp:Button ID="ButtonConfirm" runat="server" Text="编辑" CssClass="baocbtn" />&nbsp;&nbsp;
        <asp:Button ID="ButtonAddMoney" runat="server" Text="续费" CssClass="baocbtn" Visible="false" />&nbsp;&nbsp;
        <asp:Button ID="ButtonBackList" runat="server" Text="返回列表" CssClass="baocbtn" />
    </div>
</div>
