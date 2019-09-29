<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="ShopArticleComment_Operate.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.ShopArticleComment_Operate" %>

<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="ShopNum1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>��Ѷ������ϸ</title>
    <link rel="stylesheet" type="text/css" href="style/css.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="right">
        <div class="rhigth">
            <div class="rl">
            </div>
            <div class="rcon">
                <h3>
                    <span id="Span1">
                        <asp:Label ID="LabelPageTitle" runat="server" Font-Bold="True" Text="��Ѷ������ϸ"></asp:Label></span></h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="inner_page_list">
                <table border="0" cellpadding="0" cellspacing="1">
                    <tr class="radiobtn" style="display: none">
                        <th align="right" width="150px">
                            <asp:Label ID="LabelName" runat="server" Text="���۱��⣺"></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxTitle" runat="server" CssClass="allinput3 tinput" ReadOnly="true"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th align="right" valign="top">
                            <asp:Label ID="LabelWebSite" runat="server" Text="����ʱ�䣺"></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxTime" runat="server" CssClass="allinput3 tinput" ReadOnly="true"></asp:TextBox>
                        </td>
                    </tr>
                    <tr class="radiobtn">
                        <th align="right">
                            <asp:Label ID="LabelOrderID" runat="server" Text="�����û���"></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxUser" runat="server" CssClass="allinput3 tinput" ReadOnly="true"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelLogo" runat="server" Text="����IP��"></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxIP" runat="server" CssClass="allinput3 tinput" ReadOnly="true"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelKeywords" runat="server" Text="������Ѷ��"></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxArticle" runat="server" CssClass="allinput3 tinput" ReadOnly="true"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="Label1" runat="server" Text="��������ID��"></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxMember" runat="server" CssClass="allinput3 tinput" ReadOnly="true"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelRemark" runat="server" Text="�������ݣ�"></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxContent" CssClass="allinput3 tinput" runat="server" TextMode="MultiLine"
                                Width="500px" ReadOnly="true" Height="100px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr style="display: none">
                        <th align="right">
                            <asp:Label ID="LabelReply" runat="server" Text="�ظ����ݣ�"></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxReply" CssClass="allinput3 tinput" runat="server" TextMode="MultiLine"
                                Width="500px" Height="100px"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="tablebtn">
                <asp:Button ID="ButtonConfirm" runat="server" Text="ȷ��" ToolTip="Submit" CssClass="fanh"
                    OnClick="ButtonConfirm_Click" Visible="false" />
                <input id="inputReset" runat="server" runat="server" type="reset" value="����" class="fanh"
                    visible="false" />
                <asp:Button ID="ButtonBack" runat="server" Text="�����б�" CssClass="fanh" OnClick="ButtonBack_Click" />
                <ShopNum1:MessageShow ID="MessageShow" runat="server" Visible="False" />
            </div>
        </div>
    </div>
    <asp:HiddenField ID="hiddenFieldGuid" runat="server" Value="0" />
    </form>
</body>
</html>
