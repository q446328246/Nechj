<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="ManagerShopPayMent.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.ManagerShopPayMent" %>

<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="ShopNum1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>��д����URL</title>
    <link type="text/css" rel="Stylesheet" href="style/css.css" />
    <script type="text/javascript" language="javascript" src="js/CommonJS.js"> </script>
</head>
<style type="text/css">
    .guige_text label
    {
        color: #333333;
        display: inline-block;
        padding-left: 4px;
    }
    
    .guige_text input
    {
        display: inline-block;
        margin-left: 10px;
        position: relative;
        top: 3px;
    }
</style>
<body>
    <form id="form1" runat="server">
    <div id="right">
        <div class="rhigth">
            <div class="rl">
            </div>
            <div class="rcon">
                <h3>
                    <asp:Label ID="LabelPageTitle" runat="server" Text="����֧������"></asp:Label></h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="inner_page_list">
                <table cellspacing="1" cellpadding="0" border="0">
                    <tr>
                        <th align="right" width="150px">
                            ����֧�����ͣ�
                        </th>
                        <td align="left" class="guige_text">
                            <asp:RadioButtonList ID="RadioButtonListShopPayMent" RepeatDirection="Horizontal"
                                runat="server" RepeatLayout="Flow">
                                <asp:ListItem Selected="True" Value="0">֧����ƽ̨</asp:ListItem>
                                <asp:ListItem Value="1">֧��������</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                </table>
                <div style="margin: 10px 125px; margin-top: 20px;">
                    <asp:Button ID="ButtonUpdata" runat="server" ValidationGroup="shopurl" Text="ȷ��"
                        CssClass="fanh" OnClick="ButtonUpdata_Click" />&nbsp;
                    <asp:Button ID="ButtonBack" runat="server" Text="�����б�" CssClass="fanh" OnClick="ButtonBack_Click" />
                    <ShopNum1:MessageShow ID="MessageShow" runat="server" Visible="False" />
                </div>
            </div>
            <asp:HiddenField ID="CheckGuid" runat="server" Value="0" />
        </div>
    </div>
    </form>
</body>
</html>
