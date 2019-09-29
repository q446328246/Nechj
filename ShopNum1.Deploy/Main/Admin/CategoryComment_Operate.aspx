<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="CategoryComment_Operate.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.CategoryComment_Operate" %>

<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="ShopNum1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>�������۲���</title>
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
                    <asp:Label ID="LabelPageTitle" runat="server" Text="�������۲鿴"></asp:Label></h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <table border="0" cellpadding="0" cellspacing="0" class="shoptable">
                <tr>
                    <th align="right">
                        <div class="shopth">
                            <asp:Label ID="LabelName" runat="server" Text="���۱��⣺"></asp:Label>
                        </div>
                    </th>
                    <td>
                        <div class="shoptd">
                            <asp:TextBox ID="TextBoxTitle" runat="server" CssClass="tinput" ReadOnly="true"></asp:TextBox>
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
                            <asp:TextBox ID="TextBoxTime" runat="server" CssClass="tinput" ReadOnly="true"></asp:TextBox>
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
                            <asp:TextBox ID="TextBoxUser" runat="server" CssClass="tinput" ReadOnly="true"></asp:TextBox>
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
                            <asp:TextBox ID="TextBoxIP" runat="server" CssClass="tinput" ReadOnly="true"></asp:TextBox>
                        </div>
                    </td>
                </tr>
                <tr>
                    <th align="right">
                        <div class="shopth">
                            <asp:Label ID="LabelKeywords" runat="server" Text="����������Ϣ��"></asp:Label>
                        </div>
                    </th>
                    <td>
                        <div class="shoptd">
                            <FCKeditorV2:FCKeditor ID="FCKeditorContent" runat="server" Height="300" Width="600">
                            </FCKeditorV2:FCKeditor>
                        </div>
                    </td>
                </tr>
                <tr>
                    <th align="right">
                        <div class="shopth">
                            <asp:Label ID="Label1" runat="server" Text="�����û���"></asp:Label>
                        </div>
                    </th>
                    <td>
                        <div class="shoptd">
                            <asp:TextBox ID="TextBoxMember" runat="server" CssClass="tinput" ReadOnly="true"></asp:TextBox>
                        </div>
                    </td>
                </tr>
                <tr>
                    <th align="right">
                        <div class="shopth" style="height: 115px;">
                            <asp:Label ID="LabelRemark" runat="server" Text="�������ݣ�"></asp:Label>
                        </div>
                    </th>
                    <td>
                        <div class="shopth" style="height: 115px;">
                            <asp:TextBox ID="TextBoxContent" CssClass="tinput txtarea" runat="server" TextMode="MultiLine"
                                ReadOnly="true"></asp:TextBox>
                        </div>
                    </td>
                </tr>
                <tr>
                    <th align="right">
                        <div class="shopth" style="border-bottom: none; height: 115px;">
                            <asp:Label ID="Label2" runat="server" Text="�ظ����ݣ�"></asp:Label>
                        </div>
                    </th>
                    <td>
                        <div class="shopth" style="border-bottom: none; height: 115px;">
                            <asp:TextBox ID="TextBoxReplyContent" CssClass="tinput txtarea" runat="server" TextMode="MultiLine"></asp:TextBox>
                        </div>
                    </td>
                </tr>
            </table>
            <div class="tablebtn">
                <asp:Button ID="ButtonConfirm" runat="server" Text="ȷ��" ToolTip="Submit" CssClass="qued"
                    OnClick="ButtonConfirm_Click" />
                <asp:Button ID="ButtonBack" runat="server" Text="�����б�" CssClass="fanh" OnClick="ButtonBack_Click" />
                <ShopNum1:MessageShow ID="MessageShow" runat="server" Visible="False" />
            </div>
        </div>
    </div>
    <asp:HiddenField ID="hiddenFieldGuid" runat="server" Value="0" />
    </form>
</body>
</html>
