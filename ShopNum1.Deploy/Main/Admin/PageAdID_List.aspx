<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="PageAdID_List.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.PageAdID_List" %>

<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="ShopNum1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>�Զ����ɹ��λ�б�</title>
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
                    ���λ�б�</h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="order_edit">
                <table cellpadding="0" cellspacing="0" border="0">
                    <tr style="height: 35px; vertical-align: top;">
                        <td>
                            ҳ������
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxPageName" runat="server" CssClass="tinput" Width="258"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Button ID="ButtonSearch" runat="server" Text="��ѯ" CssClass="dele" />
                        </td>
                    </tr>
                </table>
                <div class="sbtn">
                    <table cellpadding="0" cellspacing="0" border="0">
                        <tr>
                            <td valign="top">
                                <asp:LinkButton ID="ButtonAdd" runat="server" OnClick="ButtonAdd_Click" CausesValidation="False"
                                    class="tianjia2 lmf_btn" Visible="false"><span>���</span></asp:LinkButton>
                                <asp:Button ID="ButtonEdit" runat="server" CausesValidation="False" Text="�༭" Visible="false"
                                    OnClientClick=" return EditButton() " OnClick="ButtonEdit_Click" CssClass="fanh" />
                            </td>
                            <td valign="top" class="lmf_app">
                                <asp:LinkButton ID="ButtonDelete" runat="server" OnClick="ButtonDelete_Click" OnClientClick=" return DeleteButton() "
                                    CausesValidation="False" class="shanchu lmf_btn" Visible="false"><span>����ɾ��</span></asp:LinkButton>
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
                GridLines="Vertical">
                <FooterStyle BackColor="#CCCC99" />
                <HeaderStyle HorizontalAlign="Center" CssClass="list_header" ForeColor="White"></HeaderStyle>
                <%--��ҳ--%>
                <PagerStyle CssClass="lmf_page" BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <input id="checkboxAll" onclick=" javascript: SelectAllCheckboxes(this); " type="checkbox" />
                        </HeaderTemplate>
                        <HeaderStyle CssClass="select_width" />
                        <ItemTemplate>
                            <input id="checkboxItem" type="checkbox" value='<%# Eval("guid") %>' />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="divid" HeaderText="���λID" ItemStyle-HorizontalAlign="Center"
                        SortExpression="divid" />
                    <asp:BoundField DataField="pagename" HeaderText="ҳ����" ItemStyle-HorizontalAlign="Center"
                        SortExpression="pagename" />
                    <asp:BoundField DataField="filename" HeaderText="�ļ���" ItemStyle-HorizontalAlign="Center"
                        SortExpression="filename" />
                    <asp:BoundField DataField="height" HeaderText="�߶�" ItemStyle-HorizontalAlign="Center"
                        SortExpression="height" Visible="false" />
                    <asp:BoundField DataField="width" HeaderText="���" ItemStyle-HorizontalAlign="Center"
                        SortExpression="width" Visible="false" />
                    <asp:BoundField DataField="content" HeaderText="˵��" ItemStyle-HorizontalAlign="Center"
                        SortExpression="content" />
                    <asp:TemplateField HeaderText="����">
                        <ItemTemplate>
                            <a href="<%# "PageAdID_Operate.aspx?guid=" + Eval("guid") %>" style="color: #4482b4;">
                                �༭</a>
                            <asp:LinkButton ID="LinkDelte" runat="server" Style="color: #4482b4;" OnClick="ButtonDeleteBylink_Click"
                                CommandArgument='<%# Eval("guid") %>' OnClientClick=" return window.confirm('��ȷ��Ҫɾ����?'); "
                                Visible="false">ɾ��</asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                </Columns>
            </ShopNum1:Num1GridView>
        </div>
        <asp:ObjectDataSource ID="ObjectDataSourceData" runat="server" SelectMethod="Search"
            TypeName="ShopNum1.BusinessLogic.ShopNum1_PageAdID_Action">
            <SelectParameters>
                <asp:ControlParameter ControlID="TextBoxPageName" Name="pagename" PropertyName="Text"
                    Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:HiddenField ID="CheckGuid" runat="server" Value="0" />
    </div>
    </form>
</body>
</html>
