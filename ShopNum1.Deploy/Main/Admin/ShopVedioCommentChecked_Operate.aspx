<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="ShopVedioCommentChecked_Operate.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.ShopVedioCommentChecked_Operate" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>��Ƶ�������</title>
    <link href="style/css.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="right">
        <div class="rhigth">
            <div class="rl">
            </div>
            <div class="rcon">
                <h3>
                    <asp:Label ID="LabelPageTitle" runat="server" Text="��Ƶ���۲鿴"></asp:Label></h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <table border="0" cellpadding="0" cellspacing="0" class="shoptable">
                <tr style="display: none">
                    <th align="right">
                        <div class="shopth">
                            <asp:Label ID="LabelName" runat="server" Text="���۱��⣺"></asp:Label>
                        </div>
                    </th>
                    <td>
                        <div class="shoptd">
                            <asp:TextBox ID="TextBoxTitle" runat="server" CssClass="tinput" ReadOnly="true"></asp:TextBox><span>���۱���</span>
                        </div>
                    </td>
                </tr>
                <tr>
                    <th align="right">
                        <div class="shopth">
                            <asp:Label ID="LabelWebSite" runat="server" Text="����ʱ�䣺"></asp:Label>
                        </div>
                    </th>
                    <td>
                        <div class="shoptd">
                            <asp:TextBox ID="TextBoxTime" runat="server" CssClass="tinput" ReadOnly="true"></asp:TextBox><span>����ʱ��</span>
                        </div>
                    </td>
                </tr>
                <tr>
                    <th align="right">
                        <div class="shopth">
                            <asp:Label ID="LabelOrderID" runat="server" Text="�����û���"></asp:Label>
                        </div>
                    </th>
                    <td>
                        <div class="shoptd">
                            <asp:TextBox ID="TextBoxUser" runat="server" CssClass="tinput" ReadOnly="true"></asp:TextBox><span>�����û�</span>
                        </div>
                    </td>
                </tr>
                <tr>
                    <th align="right">
                        <div class="shopth">
                            <asp:Label ID="LabelLogo" runat="server" Text="����IP��"></asp:Label>
                        </div>
                    </th>
                    <td>
                        <div class="shoptd">
                            <asp:TextBox ID="TextBoxIP" runat="server" CssClass="tinput" ReadOnly="true"></asp:TextBox><span>����IP</span>
                        </div>
                    </td>
                </tr>
                <tr>
                    <th align="right">
                        <div class="shopth">
                            <asp:Label ID="LabelKeywords" runat="server" Text="������Ƶ��"></asp:Label>
                        </div>
                    </th>
                    <td>
                        <div class="shoptd">
                            <asp:TextBox ID="TextBoxVideo" runat="server" CssClass="tinput" ReadOnly="true"></asp:TextBox><span>������Ƶ</span>
                        </div>
                    </td>
                </tr>
                <tr>
                    <th align="right">
                        <div class="shopth">
                            <asp:Label ID="Label1" runat="server" Text="��������ID��"></asp:Label>
                        </div>
                    </th>
                    <td>
                        <div class="shoptd">
                            <asp:TextBox ID="TextBoxMember" runat="server" CssClass="tinput" ReadOnly="true"></asp:TextBox><span>��������ID</span>
                        </div>
                    </td>
                </tr>
                <tr>
                    <th align="right">
                        <div class="shopth" style="border-bottom: none; height: 115px;">
                            <asp:Label ID="LabelRemark" runat="server" Text="�������ݣ�"></asp:Label>
                        </div>
                    </th>
                    <td>
                        <div class="shoptd" style="border-bottom: none; height: 115px;">
                            <asp:TextBox ID="TextBoxContent" CssClass="tinput txtarea" runat="server" TextMode="MultiLine"
                                ReadOnly="true"></asp:TextBox>
                        </div>
                    </td>
                </tr>
            </table>
            <div class="tablebtn">
                <asp:Button ID="ButtonBack" CssClass="fanh" runat="server" Text="�����б�" OnClick="ButtonBack_Click" />
                <%--<asp:Button ID="ButtonConfirm" runat="server" Text="ȷ��" ToolTip=""
                    CssClass="qued" Enabled="False" />
                --%>
            </div>
        </div>
    </div>
    <asp:HiddenField ID="hiddenFieldGuid" runat="server" Value="0" />
    </form>
</body>
</html>
