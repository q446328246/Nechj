<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="ShopCategoryAply_SearchDetail.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.ShopCategoryAply_SearchDetail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>�����������鿴��ϸ</title>
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
                    <asp:Label ID="LabelTitle" runat="server" Text="�����������鿴��ϸ"></asp:Label></h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="inner_page_list">
                <table border="0" cellpadding="0" cellspacing="1">
                    <tr>
                        <th align="right" width="150px">
                            <asp:Localize ID="LocalizeName" runat="server" Text="�������ƣ�"></asp:Localize>
                        </th>
                        <td valign="middle">
                            <asp:TextBox ID="TextBoxShopName" CssClass="tinput" ReadOnly="true" runat="server"></asp:TextBox>
                            <span>�������������</span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Localize ID="Localizereplacement" runat="server" Text="������̻�Ա��"></asp:Localize>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxMemberLoginID" ReadOnly="true" CssClass="tinput" runat="server"></asp:TextBox>
                            <span>������������̻�Ա</span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Localize ID="Localize2" runat="server" Text="����ǰ���̷��ࣺ"></asp:Localize>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxOldShopCategory" ReadOnly="true" CssClass="tinput" runat="server"></asp:TextBox>
                            <span>����������ǰ���̷���</span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Localize ID="Localize3" runat="server" Text="����ǰ����Ʒ�ƣ�"></asp:Localize>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxOldShopBrand" ReadOnly="true" CssClass="tinput" runat="server"></asp:TextBox>
                            <span>����������ǰ����Ʒ��</span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Localize ID="Localize4" runat="server" Text="������̷��ࣺ"></asp:Localize>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxShopApplyCategory" ReadOnly="true" CssClass="tinput" runat="server"></asp:TextBox>
                            <span>������������̷���</span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Localize ID="Localize5" runat="server" Text="�������Ʒ�ƣ�"></asp:Localize>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxShopApplyBrand" ReadOnly="true" CssClass="tinput" runat="server"></asp:TextBox>
                            <span>����������ǰ���̷���</span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Localize ID="Localize6" runat="server" Text="����ʱ�䣺"></asp:Localize>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxApplyTime" ReadOnly="true" CssClass="tinput" runat="server"></asp:TextBox>
                            <span>����������ʱ��</span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Localize ID="Localize1" runat="server" Text="��ע��"></asp:Localize>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxComment" TextMode="MultiLine" Height="100px" Width="500px"
                                CssClass="tinput txtarea" ReadOnly="true" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="tablebtn">
                <asp:Button ID="ButtonBack" CssClass="fanh" runat="server" Text="�����б�" OnClick="ButtonBack_Click" />
            </div>
        </div>
    </div>
    </form>
</body>
</html>
