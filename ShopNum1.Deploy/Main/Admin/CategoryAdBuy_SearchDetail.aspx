<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="CategoryAdBuy_SearchDetail.aspx.cs"
         Inherits="ShopNum1.Deploy.Main.Admin.CategoryAdBuy_SearchDetail" %>

<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
    <head id="Head1" runat="server">
        <title>��Ա��������ϸ</title>
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
                            <asp:Label ID="LabelTitle" runat="server" Text="��Ա��������ϸ"></asp:Label></h3>
                    </div>
                    <div class="rr">
                    </div>
                </div>
                <div class="welcon clearfix">
                    <div class="inner_page_list">
                        <table border="0" cellpadding="0" cellspacing="1">
                            <tr>
                                <th align="right" width="150px">
                                    <asp:Localize ID="LocalizeName" runat="server" Text=" ������ƣ�"></asp:Localize>
                                </th>
                                <td valign="middle">
                                    <asp:TextBox ID="TextBoxPageName" ReadOnly="true" runat="server" CssClass="tinput"></asp:TextBox>
                                    <span>��������������</span>
                                </td>
                            </tr>
                            <tr>
                                <th align="right">
                                    <asp:Localize ID="Localizereplacement" runat="server" Text="���λ��"></asp:Localize>
                                </th>
                                <td>
                                    <asp:DropDownList ID="DropDownListAdPageName" Enabled="false" AutoPostBack="true"
                                                      CssClass="tselect" runat="server" Width="180px" OnSelectedIndexChanged="DropDownListAdPageName_SelectedIndexChanged">
                                        <asp:ListItem Selected="True" Value="-1">-��ѡ��-</asp:ListItem>
                                        <asp:ListItem Value="1">��Ʒ����</asp:ListItem>
                                        <asp:ListItem Value="2">������Ϣ����</asp:ListItem>
                                        <asp:ListItem Value="3">�������</asp:ListItem>
                                        <asp:ListItem Value="4">���̷���</asp:ListItem>
                                        <asp:ListItem Value="5">��Ѷ����</asp:ListItem>
                                        <asp:ListItem Value="6">Ʒ�Ʒ���</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:DropDownList ID="DropDownListAdID" Enabled="false" AutoPostBack="true" runat="server"
                                                      CssClass="tselect" Width="180px" OnSelectedIndexChanged="DropDownListAdID_SelectedIndexChanged">
                                        <asp:ListItem Selected="True" Value="-1">-��ѡ��-</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <th align="right">
                                    <asp:Localize ID="Localize2" runat="server" Text="���λID��"></asp:Localize>
                                </th>
                                <td>
                                    <asp:TextBox ID="TextBoxCategoryAdID" ReadOnly="true" runat="server" CssClass="tinput"></asp:TextBox>
                                    <span>����������λID</span>
                                </td>
                            </tr>
                            <tr>
                                <th align="right">
                                    <asp:Localize ID="Localize1" runat="server" Text=" �����ࣺ"></asp:Localize>
                                </th>
                                <td>
                                    <asp:DropDownList ID="DropDownListCategory1" Width="180" Enabled="false" AutoPostBack="true"
                                                      CssClass="tselect" runat="server" OnSelectedIndexChanged="DropDownListCategory1_SelectedIndexChanged">
                                        <asp:ListItem Selected="True" Value="-1">-��ѡ��-</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:DropDownList ID="DropDownListCategory2" Width="180" Enabled="false" AutoPostBack="true"
                                                      CssClass="tselect" runat="server" OnSelectedIndexChanged="DropDownListCategory2_SelectedIndexChanged">
                                        <asp:ListItem Selected="True" Value="-1">-��ѡ��-</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:DropDownList ID="DropDownListCategory3" Width="180" Enabled="false" runat="server"
                                                      CssClass="tselect">
                                        <asp:ListItem Selected="True" Value="-1">-��ѡ��-</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <th align="right">
                                    <asp:Localize ID="Localize3" runat="server" Text="���ͼƬ��"></asp:Localize>
                                </th>
                                <td valign="middle">
                                    <img id="ImgNowPic" alt="" src="" runat="server" width="20" height="20" />
                                </td>
                            </tr>
                            <tr>
                                <th align="right">
                                    <asp:Localize ID="Localize4" runat="server" Text="������ӣ�"></asp:Localize>
                                </th>
                                <td valign="middle">
                                    <a href="" runat="server" id="ALikeAddress" target="_blank"></a>
                                </td>
                            </tr>
                            <tr>
                                <th align="right">
                                    <asp:Localize ID="Localize5" runat="server" Text="Ӧ����"></asp:Localize>
                                </th>
                                <td valign="middle">
                                    <asp:TextBox ID="TextBoxAdPrice" ReadOnly="true" MaxLength="200" CssClass="tinput"
                                                 runat="server"></asp:TextBox>
                                    <span>��������Ӧ�����</span>
                                </td>
                            </tr>
                            <tr>
                                <th align="right">
                                    <asp:Localize ID="Localize6" runat="server" Text="���������"></asp:Localize>
                                </th>
                                <td valign="middle">
                                    <asp:TextBox ID="TextBoxAdIntroduce" ReadOnly="true" CssClass="tinput" runat="server"></asp:TextBox>
                                    <span>��������������</span>
                                </td>
                            </tr>
                            <tr>
                                <th align="right">
                                    <asp:Localize ID="Localize7" runat="server" Text="֧����ʽ��"></asp:Localize>
                                </th>
                                <td valign="middle">
                                    <asp:TextBox ID="TextBoxPayMent" ReadOnly="true" CssClass="tinput" runat="server"></asp:TextBox>
                                    <span>��������֧����ʽ</span>
                                </td>
                            </tr>
                            <tr>
                                <th align="right">
                                    <asp:Localize ID="Localize8" runat="server" Text="֧��״̬��"></asp:Localize>
                                </th>
                                <td valign="middle">
                                    <asp:TextBox ID="TextBoxIsPayMent" ReadOnly="true" CssClass="tinput" runat="server"></asp:TextBox>
                                    <span>��������֧��״̬</span>
                                </td>
                            </tr>
                            <tr>
                                <th align="right">
                                    <asp:Localize ID="Localize9" runat="server" Text="���״̬��"></asp:Localize>
                                </th>
                                <td valign="middle">
                                    <asp:DropDownList ID="DropDownListIsAudit" AutoPostBack="true" Width="180" runat="server"
                                                      CssClass="tselect" OnSelectedIndexChanged="DropDownListIsAudit_SelectedIndexChanged">
                                        <asp:ListItem Selected="True" Value="1">���ͨ��</asp:ListItem>
                                        <asp:ListItem Value="2">���δͨ��</asp:ListItem>
                                    </asp:DropDownList>
                                    <span>�����������״̬</span>
                                </td>
                            </tr>
                            <tr>
                                <th align="right">
                                    <asp:Literal ID="LiteralFailCause" Visible="false" Text="��ͨ����ԭ��" runat="server"></asp:Literal>
                                </th>
                                <td>
                                    <ShopNum1:TextBox ID="TextBoxFailCause" CanBeNull="����" Visible="false" TextMode="MultiLine"
                                                      Height="100px" Width="300px" CssClass="allinput1" runat="server"></ShopNum1:TextBox>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="tablebtn">
                        <asp:Button ID="ButtonUpdata" CssClass="fanh" runat="server" Text="ȷ��" OnClick="ButtonUpdata_Click" />
                        <asp:Button ID="ButtonBack" CssClass="fanh" CausesValidation="false" runat="server"
                                    Text="�����б�" OnClick="ButtonBack_Click" />
                        <uc1:MessageShow ID="MessageShow" runat="server" Visible="False" />
                    </div>
                </div>
                <asp:HiddenField ID="hiddenFieldGuid" Value="-1" runat="server" />
                <asp:HiddenField ID="HiddenFieldCategoryCode" Value="-1" runat="server" />
                <asp:HiddenField ID="HiddenFieldMemLoginID" runat="server" />
            </div>
        </form>
    </body>
</html>