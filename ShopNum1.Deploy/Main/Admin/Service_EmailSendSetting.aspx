<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="Service_EmailSendSetting.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.Service_EmailSendSetting" %>

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
                    �ʼ���������</h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <table border="0" cellpadding="0" cellspacing="0" class="shoptable">
                <tr>
                    <th align="right" width="260px">
                        <div class="shopth">
                            <asp:Label ID="LabelPayIsEmail" runat="server" Text="����ʱ�Ƿ����ҷ����ʼ���"></asp:Label>
                        </div>
                    </th>
                    <td>
                        <div class="shoptd">
                            <asp:DropDownList ID="DropDownListPayIsEmail" runat="server" Width="180px" CssClass="tselect">
                                <asp:ListItem Value="0">�������ʼ�</asp:ListItem>
                                <asp:ListItem Value="1">�����ʼ�</asp:ListItem>
                            </asp:DropDownList>
                            <%-- <span>��ѡ��</span>--%>
                        </div>
                    </td>
                </tr>
                <tr>
                    <th align="right">
                        <div class="shopth">
                            <asp:Label ID="LabelShipmentIsEmail" runat="server" Text="����ʱ�Ƿ����ҷ����ʼ���"></asp:Label>
                        </div>
                    </th>
                    <td>
                        <div class="shoptd">
                            <asp:DropDownList ID="DropDownListShipmentIsEmail" runat="server" Width="180px" CssClass="tselect">
                                <asp:ListItem Value="0">�������ʼ�</asp:ListItem>
                                <asp:ListItem Value="1">�����ʼ�</asp:ListItem>
                            </asp:DropDownList>
                            <%--   <span>��ѡ��</span>--%>
                        </div>
                    </td>
                </tr>
                <tr>
                    <th align="right">
                        <div class="shopth">
                            <asp:Label ID="LabelShipmentOKIsEmail" runat="server" Text="ȷ���ջ�ʱ�Ƿ����ҷ����ʼ���"></asp:Label>
                        </div>
                    </th>
                    <td>
                        <div class="shoptd">
                            <asp:DropDownList ID="DropDownListShipmentOKIsEmail" runat="server" Width="180px"
                                CssClass="tselect">
                                <asp:ListItem Value="0">�������ʼ�</asp:ListItem>
                                <asp:ListItem Value="1">�����ʼ�</asp:ListItem>
                            </asp:DropDownList>
                            <%-- <span>��ѡ��</span>--%>
                        </div>
                    </td>
                </tr>
                <tr>
                    <th align="right">
                        <div class="shopth">
                            <asp:Label ID="LabelOrderIsEmail" runat="server" Text="�¶���ʱ�Ƿ����ҷ����ʼ���"></asp:Label>
                        </div>
                    </th>
                    <td>
                        <div class="shoptd">
                            <asp:DropDownList ID="DropDownListOrderIsEmail" runat="server" Width="180px" CssClass="tselect">
                                <asp:ListItem Value="0">�������ʼ�</asp:ListItem>
                                <asp:ListItem Value="1">�����ʼ�</asp:ListItem>
                            </asp:DropDownList>
                            <%--   <span>��ѡ��</span>--%>
                        </div>
                    </td>
                </tr>
                <tr>
                    <th align="right">
                        <div class="shopth">
                            <asp:Label ID="Label1" runat="server" Text="�¶���ʱ�Ƿ���̼ҷ����ʼ���"></asp:Label>
                        </div>
                    </th>
                    <td>
                        <div class="shoptd">
                            <asp:DropDownList ID="DropDownListOrderToShopIsEmail" runat="server" Width="180px"
                                CssClass="tselect">
                                <asp:ListItem Value="0">�������ʼ�</asp:ListItem>
                                <asp:ListItem Value="1">�����ʼ�</asp:ListItem>
                            </asp:DropDownList>
                            <%-- <span>��ѡ��</span>--%>
                        </div>
                    </td>
                </tr>
                <tr>
                    <th align="right">
                        <div class="shopth">
                            <asp:Label ID="LabelCancelOrderIsEmail" runat="server" Text="ȡ������ʱ�Ƿ�����ҷ����ʼ���"></asp:Label>
                        </div>
                    </th>
                    <td>
                        <div class="shoptd">
                            <asp:DropDownList ID="DropDownListCancelOrderIsEmail" runat="server" Width="180px"
                                CssClass="tselect">
                                <asp:ListItem Value="0">�������ʼ�</asp:ListItem>
                                <asp:ListItem Value="1">�����ʼ�</asp:ListItem>
                            </asp:DropDownList>
                            <%--  <span>��ѡ��</span>--%>
                        </div>
                    </td>
                </tr>
                <tr>
                    <th align="right">
                        <div class="shopth">
                            <asp:Label ID="LabelMemberRegister" runat="server" Text="ע��ɹ����Ƿ����Ա���ʼ���"></asp:Label>
                        </div>
                    </th>
                    <td>
                        <div class="shoptd">
                            <asp:DropDownList ID="DropDownListMemberRegister" runat="server" Width="180px" CssClass="tselect">
                                <asp:ListItem Value="0">�������ʼ�</asp:ListItem>
                                <asp:ListItem Value="1">�����ʼ�</asp:ListItem>
                            </asp:DropDownList>
                            <%-- <span>��ѡ��</span>--%>
                        </div>
                    </td>
                </tr>
                <tr>
                    <th align="right">
                        <div class="shopth">
                            <asp:Label ID="Label28" runat="server" Text="ע��ʱ�Ƿ���Ҫ����Ա���ͼ����ʼ���"></asp:Label>
                        </div>
                    </th>
                    <td>
                        <div class="shoptd">
                            <asp:DropDownList ID="DropDownListRegIsActivationEmail" runat="server" Width="180px"
                                CssClass="tselect">
                                <asp:ListItem Value="0">�������ʼ�</asp:ListItem>
                                <asp:ListItem Value="1">�����ʼ�</asp:ListItem>
                            </asp:DropDownList>
                            <%--<span>��ѡ��</span>--%>
                        </div>
                    </td>
                </tr>
                <tr>
                    <th align="right">
                        <div class="shopth">
                            <asp:Label ID="LabelApplyOpenShopIsEmail" runat="server" Text="���뿪����Ƿ�����̷��ʼ���"></asp:Label>
                        </div>
                    </th>
                    <td>
                        <div class="shoptd">
                            <asp:DropDownList ID="DropDownListApplyOpenShopIsEmail" runat="server" Width="180px"
                                CssClass="tselect">
                                <asp:ListItem Value="0">�������ʼ�</asp:ListItem>
                                <asp:ListItem Value="1">�����ʼ�</asp:ListItem>
                            </asp:DropDownList>
                            <%--  <span>��ѡ��</span>--%>
                        </div>
                    </td>
                </tr>
                <tr>
                    <th align="right">
                        <div class="shopth">
                            <asp:Label ID="LabelAuditOpenShopIsEmail" runat="server" Text="������˺��Ƿ�����̷��ʼ���"></asp:Label>
                        </div>
                    </th>
                    <td>
                        <div class="shoptd">
                            <asp:DropDownList ID="DropDownListAuditOpenShopIsEmail" runat="server" Width="180px"
                                CssClass="tselect">
                                <asp:ListItem Value="0">�������ʼ�</asp:ListItem>
                                <asp:ListItem Value="1">�����ʼ�</asp:ListItem>
                            </asp:DropDownList>
                            <%-- <span>��ѡ��</span>--%>
                        </div>
                    </td>
                </tr>
            </table>
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
</html>