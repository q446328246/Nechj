<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="ShopDoMain_Operate.aspx.cs" Inherits="ShopNum1.Deploy.Main.Admin.ShopDoMain_Operate" %>

<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
    <head id="Head1" runat="server">
        <title>店铺域名操作</title>
        <link type="text/css" rel="Stylesheet" href="css/index.css" />
        <script type="text/javascript" language="javascript" src="js/CommonJS.js"> </script>
    </head>
    <body style="background-image: url(images/Bg_right.gif); background-repeat: repeat; font-size: 12px; padding: 0;">
        <form id="form1" runat="server">
            <div class="navigator">
                <asp:Label ID="LabelPageTitle" runat="server" Text="【 新增域名 】"></asp:Label></div>
            <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="right" width="25%">
                        <asp:Label ID="LabelName" runat="server" Text="域名："></asp:Label>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="TextBoxName" runat="server" CssClass="input2">
                        </asp:TextBox>
                        <font style="color: Red">
                            <asp:Label ID="Label1" runat="server" Text="*">
                            </asp:Label></font>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorName" runat="server" ControlToValidate="TextBoxName"
                                                    Display="Dynamic" ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidatorName" runat="server"
                                                        ControlToValidate="TextBoxName" Display="Dynamic" ErrorMessage="标题最多50个字符" ValidationExpression="^[\s\S]{0,50}$"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td align="right" width="25%">
                        <asp:Label ID="LabelShopName" runat="server" Text="所属店铺："></asp:Label>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="TextBoxShopName" runat="server" CssClass="input2">
                        </asp:TextBox>
                        <font style="color: Red">
                            <asp:Label ID="Label6" runat="server" Text="*">
                            </asp:Label></font>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorTextBoxShopName" runat="server" ControlToValidate="TextBoxShopName"
                                                    Display="Dynamic" ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidatorTextBoxShopName" runat="server"
                                                        ControlToValidate="TextBoxShopName" Display="Dynamic" ErrorMessage="标题最多50个字符" ValidationExpression="^[\s\S]{0,50}$"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td align="right" width="25%">
                        <asp:Label ID="LabelGoUrl" runat="server" Text="链接地址："></asp:Label>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="TextBoxGoUrl" runat="server" CssClass="input2">
                        </asp:TextBox>
                        <font style="color: Red">
                            <asp:Label ID="Label5" runat="server" Text="*">
                            </asp:Label></font>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorTextBoxGoUrl" runat="server" ControlToValidate="TextBoxGoUrl"
                                                    Display="Dynamic" ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidatorTextBoxGoUrl" runat="server"
                                                        ControlToValidate="TextBoxGoUrl" Display="Dynamic" ErrorMessage="标题最多50个字符" ValidationExpression="^[\s\S]{0,50}$"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td align="right" width="25%">
                        <asp:Label ID="Label2" runat="server" Text="备案号："></asp:Label>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="TextBoxSiteNumber" runat="server" CssClass="input2">
                        </asp:TextBox>
                        <font style="color: Red">
                            <asp:Label ID="Label3" runat="server" Text="*">
                            </asp:Label></font>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBoxSiteNumber"
                                                    Display="Dynamic" ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                                                        ControlToValidate="TextBoxName" Display="Dynamic" ErrorMessage="标题最多50个字符" ValidationExpression="^[\s\S]{0,50}$"></asp:RegularExpressionValidator>
                    </td>
                </tr>
      
                <tr style="background-color: #EEEEEE;" class="btconfig">
                    <td align="right">
                        &nbsp;
                    </td>
                    <td align="left">
                        <div style="width: 100%">
                            <asp:Button ID="ButtonConfirm" runat="server" Text="确定" OnClick="ButtonConfirm_Click"
                                        CssClass="bt2" ToolTip="Submit" />
                            <input id="inputReset" runat="server" type="reset" value="重置" class="bt2" />
                            <asp:Button ID="ButtonBack" runat="server" Text="返回列表" class="bt3" CausesValidation="false"
                                        OnClick="ButtonBack_Click" />
                            <uc1:MessageShow ID="MessageShow" runat="server" Visible="False" />
                        </div>
                    </td>
                </tr>
            </table>
            <asp:HiddenField ID="hiddenFieldGuid" runat="server" Value="0" />
            <asp:HiddenField ID="HiddenFieldAgentID" runat="server" />
        </form>
    </body>
</html>