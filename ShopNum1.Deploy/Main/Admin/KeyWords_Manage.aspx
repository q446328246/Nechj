<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="KeyWords_Manage.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.KeyWords_Manage" %>

<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="ShopNum1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>�ؼ��ֹ���</title>
    <link rel="stylesheet" type="text/css" href="style/css.css" />
    <script type="text/javascript" language="javascript" src="js/CommonJS.js"> </script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="right">
        <div class="rhigth">
            <div class="rl">
            </div>
            <div class="rcon">
                <h3>
                    �ؼ��ֹ���</h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="order_edit">
                <div style="margin-bottom: 20px;">
                    <table border="0" cellspacing="0" cellpadding="0" style="margin-bottom: 7px;">
                        <tr>
                            <td width="70" style="padding-right: 5px; text-align: right;">
                                �ؼ��֣�
                            </td>
                            <td width="260">
                                <asp:TextBox ID="TextBoxQKeyWords" Width="200" runat="server" CssClass="tinput"></asp:TextBox>
                            </td>
                            <td width="100" style="padding-right: 5px; text-align: right;">
                                ���ͣ�
                            </td>
                            <td width="190">
                                <asp:DropDownList ID="DropDownListQType" runat="server" Width="180" CssClass="tselect">
                                    <asp:ListItem Selected="True" Value="-1">-ȫ��-</asp:ListItem>
                                    <asp:ListItem Value="1">��Ʒ</asp:ListItem>
                                    <%-- <asp:ListItem Value="2">����</asp:ListItem>
                                            <asp:ListItem Value="3">��Ѷ</asp:ListItem>
                                            <asp:ListItem Value="4">����</asp:ListItem>
                                            <asp:ListItem Value="5">����</asp:ListItem>--%>
                                </asp:DropDownList>
                            </td>
                        </tr>
                    </table>
                    <table border="0" cellspacing="0" cellpadding="0" style="margin-bottom: 7px;">
                        <tr>
                            <td width="70" style="padding-right: 5px; text-align: right;">
                                ����������
                            </td>
                            <td width="260">
                                <asp:TextBox ID="TextBoxQCount" runat="server" CssClass="tinput" Width="200"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidatorQCount" runat="server"
                                    ControlToValidate="TextBoxQCount" Display="Dynamic" ErrorMessage="�����ʽ����ȷ" ValidationExpression="^[0-9]*$"></asp:RegularExpressionValidator>
                            </td>
                            <td width="100" style="padding-right: 5px; text-align: right;">
                                ǰ̨�Ƿ���ʾ��
                            </td>
                            <td width="190">
                                <asp:DropDownList ID="DropDownListQIfShow" runat="server" Width="180" CssClass="tselect">
                                </asp:DropDownList>
                            </td>
                            <td width="90">
                                <asp:Button ID="ButtonSearch" runat="server" Text="��ѯ" OnClick="ButtonSearch_Click"
                                    CausesValidation="False" CssClass="dele" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="sbtn">
                    <table cellpadding="0" cellspacing="0" border="0">
                        <tr>
                            <td valign="top">
                                <asp:LinkButton ID="ButtonAdd" runat="server" CausesValidation="False" CssClass="tianjia2 lmf_btn"
                                    OnClick="ButtonAdd_Click"><span>���</span></asp:LinkButton>
                            </td>
                            <td valign="top" class="lmf_app">
                                <asp:LinkButton ID="ButtonEdit" runat="server" CausesValidation="False" OnClientClick=" return EditButton() "
                                    CssClass="bji lmf_btn" OnClick="ButtonEdit_Click"><span>�༭</span></asp:LinkButton>
                            </td>
                            <td valign="top" class="lmf_app">
                                <asp:LinkButton ID="ButtonDelete" runat="server" CausesValidation="False" OnClientClick=" return DeleteButton() "
                                    CssClass="shanchu lmf_btn" OnClick="ButtonDelete_Click"><span>����ɾ��</span></asp:LinkButton>
                            </td>
                            <td valign="top" class="lmf_app">
                                <ShopNum1:MessageShow ID="MessageShow" runat="server" Visible="False" />
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <ShopNum1:Num1GridView ID="Num1GridViewShow" runat="server" AutoGenerateColumns="False"
                AllowPaging="True" AllowSorting="True" ascendingimageurl="~/images/SortAsc.gif"
                descendingimageurl="~/images/SortDesc.gif" AddSequenceColumn="False" Width="98%"
                Del="False" DeletePromptText="ȷʵҪɾ��ָ���ļ�¼��" Edit="False" FixHeader="False" GridViewSortDirection="Ascending"
                PagingStyle="None" TableName="" DataSourceID="ObjectDataSourceData" AllowMultiColumnSorting="False"
                BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="0" CellPadding="4"
                GridLines="Vertical" Style="margin-top: 15px;">
                <FooterStyle BackColor="#CCCC99" />
                <HeaderStyle HorizontalAlign="Center" CssClass="list_header" ForeColor="White"></HeaderStyle>
                <%--��ҳ--%>
                <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <input id="checkboxAll" onclick=" javascript: SelectAllCheckboxes(this); " type="checkbox" />
                        </HeaderTemplate>
                        <ItemTemplate>
                            <input id="checkboxItem" type="checkbox" value='<%# Eval("Guid") %>' />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="Name" HeaderText="�ؼ���" SortExpression="Name">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Count" HeaderText="��������" SortExpression="Count">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="ǰ̨�Ƿ���ʾ" SortExpression="IfShow">
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" Text='<%# ChangeIfShow(DataBinder.Eval(Container,
                                                                                                                 "DataItem(IfShow)", "{0}")) %>'>></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="����" SortExpression="Type">
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# ChangeType(DataBinder.Eval(Container,
                                                                                                               "DataItem(Type)", "{0}")) %>'>></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                </Columns>
            </ShopNum1:Num1GridView>
        </div>
    </div>
    <br />
    <asp:ObjectDataSource ID="ObjectDataSourceData" runat="server" SelectMethod="Search"
        TypeName="ShopNum1.BusinessLogic.ShopNum1_KeyWords_Action">
        <SelectParameters>
            <asp:ControlParameter ControlID="TextBoxQKeyWords" Name="name" PropertyName="Text"
                Type="String" />
            <asp:ControlParameter ControlID="TextBoxQCount" Name="count" PropertyName="Text"
                Type="String" />
            <asp:ControlParameter ControlID="DropDownListQType" Name="type" PropertyName="SelectedValue"
                Type="Int32" />
            <asp:ControlParameter ControlID="DropDownListQIfShow" Name="ifshow" PropertyName="SelectedValue"
                Type="Int32" />
            <asp:Parameter Name="isDelete" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:HiddenField ID="CheckGuid" runat="server" Value="0" />
    </form>
</body>
</html>
