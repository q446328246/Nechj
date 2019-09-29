<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="Service_MMSSendSetting.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.Service_MMSSendSetting" %>

<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="ShopNum1" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>վ������</title>
    <link rel="stylesheet" type="text/css" href="style/css.css" />
    <script src="js/CommonJS.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="right">
        <div class="rhigth">
            <div class="rl">
            </div>
            <div class="rcon">
                <h3>
                    ���ŷ�������</h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="inner_page_list">
                <table border="0" cellpadding="0" cellspacing="1">
                    <tr>
                        <th align="right" width="180px;">
                            <asp:Label ID="LabelPayIsMMS" runat="server" Text="����ʱ�Ƿ����ҷ��Ͷ��ţ�"></asp:Label>
                            <td>
                                <asp:DropDownList ID="DropDownListPayIsMMS" runat="server" Width="220px" CssClass="tselect">
                                    <asp:ListItem Value="0">�����Ͷ���</asp:ListItem>
                                    <asp:ListItem Value="1">���Ͷ���</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelShipmentIsMMS" runat="server" Text="����ʱ�Ƿ����ҷ��Ͷ��ţ�"></asp:Label>
                        </th>
                        <td valign="middle">
                            <asp:DropDownList ID="DropDownListShipmentIsMMS" runat="server" Width="220px" CssClass="tselect">
                                <asp:ListItem Value="0">�����Ͷ���</asp:ListItem>
                                <asp:ListItem Value="1">���Ͷ���</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelShipmentOKIsMMS" runat="server" Text="ȷ���ջ�ʱ�Ƿ����ҷ��Ͷ��ţ�"></asp:Label>
                        </th>
                        <td>
                            <asp:DropDownList ID="DropDownListShipmentOKIsMMS" runat="server" Width="220px" CssClass="tselect">
                                <asp:ListItem Value="0">�����Ͷ���</asp:ListItem>
                                <asp:ListItem Value="1">���Ͷ���</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelOrderIsMMS" runat="server" Text="�¶���ʱ�Ƿ����ҷ��Ͷ��ţ�"></asp:Label>
                        </th>
                        <td>
                            <asp:DropDownList ID="DropDownListOrderIsMMS" runat="server" Width="220px" CssClass="tselect">
                                <asp:ListItem Value="0">�����Ͷ���</asp:ListItem>
                                <asp:ListItem Value="1">���Ͷ���</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="Label2" runat="server" Text="�¶���ʱ�Ƿ���̼ҷ��Ͷ��ţ�"></asp:Label>
                        </th>
                        <td>
                            <asp:DropDownList ID="DropDownListOrderToShopIsMMS" runat="server" Width="220px"
                                CssClass="tselect">
                                <asp:ListItem Value="0">�����Ͷ���</asp:ListItem>
                                <asp:ListItem Value="1">���Ͷ���</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelCancelOrderIsMMS" runat="server" Text="ȡ������ʱ�Ƿ����ҷ��Ͷ��ţ�"></asp:Label>
                        </th>
                        <td>
                            <asp:DropDownList ID="DropDownListCancelOrderIsMMS" runat="server" Width="220px"
                                CssClass="tselect">
                                <asp:ListItem Value="0">�����Ͷ���</asp:ListItem>
                                <asp:ListItem Value="1">���Ͷ���</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="Label25" runat="server" Text="ע��ɹ����Ƿ����Ա���Ͷ��ţ�"></asp:Label>
                        </th>
                        <td>
                            <asp:DropDownList ID="DropDownListRegistOrderIsMMS" runat="server" Width="220px"
                                CssClass="tselect">
                                <asp:ListItem Value="0">�����Ͷ���</asp:ListItem>
                                <asp:ListItem Value="1">���Ͷ���</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelApplyOpenShopIsMMS" runat="server" Text="���뿪����Ƿ�����̷��Ͷ��ţ�"></asp:Label>
                        </th>
                        <td>
                            <asp:DropDownList ID="DropDownListApplyOpenShopIsMMS" runat="server" Width="220px"
                                CssClass="tselect">
                                <asp:ListItem Value="0">�����Ͷ���</asp:ListItem>
                                <asp:ListItem Value="1">���Ͷ���</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelAuditOpenShopIsMMS" runat="server" Text="������˺��Ƿ�����̷��Ͷ��ţ�"></asp:Label>
                        </th>
                        <td>
                            <asp:DropDownList ID="DropDownListAuditOpenShopIsMMS" runat="server" Width="220px"
                                CssClass="tselect">
                                <asp:ListItem Value="0">�����Ͷ���</asp:ListItem>
                                <asp:ListItem Value="1">���Ͷ���</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="Label1" runat="server" Text=" ֧���Ƿ���Ҫ����ȷ���룺"></asp:Label>
                        </th>
                        <td valign="middle">
                            <asp:DropDownList ID="DropDownListMobileCheck" runat="server" CssClass="tselect"
                                Width="220px">
                                <asp:ListItem Value="0">����Ҫ��֤</asp:ListItem>
                                <asp:ListItem Value="1">��Ҫ��֤</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="tablebtn">
                <asp:Button ID="ButtonEdit" runat="server" Text="ȷ��" CssClass="fanh" OnClick="ButtonEdit_Click" />
                <ShopNum1:MessageShow ID="MessageShow" Visible="false" runat="server" />
                <asp:HiddenField ID="HiddenFieldXmlPath" runat="server" />
            </div>
        </div>
    </div>
    </form>
</body>
</html>
