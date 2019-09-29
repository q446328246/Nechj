<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="ShopAuditFailedReason.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.ShopAuditFailedReason" %>

<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="style/css.css" />
    <link id="sizestylesheet" rel='stylesheet' type='text/css' href='style/css1.css' />
    <script type="text/javascript" language="javascript" src="JS/jquery-1.9.1.js"></script>
    <script type="text/javascript" language="javascript" src="JS/CommonJS.js"></script>
</head>
<body style="background: none;">
    <form id="form1" runat="server">
    <div style="padding: 20px;">
        <asp:Panel ID="PanelShow" runat="server" Visible="true">
            <div class="inner_page_list">
                <table cellpadding="0" cellspacing="0" border="0">
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelShopAuditFailedReason" runat="server" Text="店铺审核失败原因："></asp:Label>
                        </th>
                        <td align="left">
                            <asp:TextBox ID="TextBoxShopAuditFailedReason" CssClass="tinput" Width="490" runat="server"
                                TextMode="MultiLine" Height="190"></asp:TextBox>
                            <asp:Label ID="Label4" runat="server" ForeColor="#FF0066" Text="*"></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorRealName" runat="server" ControlToValidate="TextBoxShopAuditFailedReason"
                                Display="Dynamic" ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorRealName" runat="server"
                                ControlToValidate="TextBoxShopAuditFailedReason" Display="Dynamic" ErrorMessage="姓名最多500个字符"
                                ValidationExpression="^[\s\S]{0,500}$"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                </table>
                <div style="text-align: center; margin-top: 12px;">
                    <asp:Button ID="ButtonConfirm" runat="server" Text="确定" ToolTip="Submit" CssClass="dele"
                        OnClick="ButtonConfirm_Click" />
                    <uc1:MessageShow ID="MessageShow" runat="server" Visible="False" />
                </div>
            </div>
        </asp:Panel>
        <asp:Panel ID="PanelShowMsg" runat="server" Visible="false">
            <div style="width: 100%; height: 100; margin-top: 60px; text-align: center;">
                操作成功！</div>
        </asp:Panel>
    </div>
    <asp:HiddenField ID="hiddenGuid" runat="server" Value="0" />
    </form>
</body>
</html>
