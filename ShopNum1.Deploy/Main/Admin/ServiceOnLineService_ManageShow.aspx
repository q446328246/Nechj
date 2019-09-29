<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="ServiceOnLineService_ManageShow.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.ServiceOnLineService_ManageShow" %>

<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="t" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>客服管理</title>
    <link rel="stylesheet" type="text/css" href="style/css.css" />
    <script type="text/javascript" language="javascript" src="js/CommonJS.js"> </script>
    <style type="text/css">
        .shopth
        {
            margin: 0;
            margin-top: 1px;
        }
        
        .shoptd
        {
            margin: 0;
            margin-top: 1px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div id="right">
        <div class="rhigth">
            <div class="rl">
            </div>
            <div class="rcon">
                <h3>
                    <asp:Label ID="LabelTtitle" runat="server" Text="客服管理"></asp:Label></h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="order_edit">
                <table border="0" cellpadding="0" cellspacing="0" class="shoptable" width="100%">
                    <tr>
                        <th align="right" width="150px">
                            <div class="shopth">
                                开启关闭：
                            </div>
                        </th>
                        <td valign="middle">
                            <div class="shoptd">
                                <table cellpadding="0" cellspacing="0" border="0">
                                    <tr>
                                        <td>
                                            <asp:RadioButton ID="RadioButtonOpen" runat="server" GroupName="online" />
                                        </td>
                                        <td style="color: #333333;">
                                            开启
                                        </td>
                                        <td style="padding-left: 18px;">
                                            <asp:RadioButton ID="RadioButtonClose" runat="server" GroupName="online" />
                                        </td>
                                        <td style="color: #333333;">
                                            关闭
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <div class="shopth">
                                在线客服：
                            </div>
                        </th>
                        <td>
                            <div class="shoptd">
                                <table cellpadding="0" cellspacing="0" border="0">
                                    <tr>
                                        <td>
                                            <asp:CheckBox ID="CheckBoxQQ" Checked="false" Text="" runat="server" />
                                        </td>
                                        <td style="color: #333333;">
                                            QQ
                                        </td>
                                        <td style="padding-left: 18px;">
                                            <asp:CheckBox ID="CheckBoxWW" Checked="false" Text="" runat="server" />
                                        </td>
                                        <td style="color: #333333;">
                                            在线旺旺
                                        </td>
                                        <td style="padding-left: 18px;">
                                            <asp:CheckBox ID="CheckBoxPhone" Checked="false" Text="" runat="server" />
                                        </td>
                                        <td style="color: #333333;">
                                            服务电话
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <div class="shopth">
                                服务电话：
                            </div>
                        </th>
                        <td>
                            <div class="shoptd">
                                <table cellpadding="0" cellspacing="0" border="0">
                                    <tr>
                                        <td colspan="6">
                                            <asp:TextBox ID="TextBoxServerPhone" runat="server" CssClass="tinput"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </td>
                    </tr>
                </table>
                <div class="sbtn" style="margin-left: 150px;">
                    <asp:Button ID="ButtonAdd" runat="server" Text="确定" CssClass="dele" OnClick="ButtonAdd_Click" />
                    <t:MessageShow ID="MessageShow" Visible="false" runat="server" />
                    <asp:HiddenField ID="HiddenFieldXmlPath" runat="server" />
                </div>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
