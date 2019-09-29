<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="Help_List.aspx.cs" Inherits="ShopNum1.Deploy.Main.Admin.Help_List" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="t" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>�����б�</title>
    <link rel='stylesheet' type='text/css' href='style/css.css' />
    <link id="sizestylesheet" rel='stylesheet' type='text/css' href='style/css1.css' />
    <script type="text/javascript" language="javascript" src="js/CommonJS.js"> </script>
    <script type='text/javascript' src='js/resolution-test.js'> </script>
</head>
<body class="widthah">
    <form id="form1" runat="server">
    <div id="right">
        <div class="rhigth">
            <div class="rl">
            </div>
            <div class="rcon">
                <h3>
                    �����б�</h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="order_edit">
                <div>
                    <table border="0" cellspacing="0" cellpadding="0">
                        <tr style="height: 35px; vertical-align: top;">
                            <td>
                                <asp:Localize ID="Localize1" runat="server" Text="�������"></asp:Localize>
                            </td>
                            <td>
                                <asp:DropDownList ID="DropDownListType" Width="200px" CssClass="tselect" runat="server">
                                </asp:DropDownList>
                            </td>
                            <td class="lmf_padding">
                                <asp:Localize ID="Localize2" runat="server" Text="�������⣺"></asp:Localize>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBoxTitle" CssClass="tinput" runat="server" Width="200"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Button ID="ButtonSearch" runat="server" Text="��ѯ" CssClass="dele" OnClick="ButtonSearch_Click" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="sbtn">
                    <table cellpadding="0" cellspacing="0" border="0">
                        <tr>
                            <td valign="top">
                                <asp:LinkButton ID="ButtonAdd" runat="server" OnClick="ButtonAdd_Click" CausesValidation="False"
                                    class="tianjia2 lmf_btn"><span>���</span></asp:LinkButton>
                                <asp:Button ID="ButtonEdit" runat="server" CausesValidation="False" Text="�༭" Visible="false"
                                    OnClientClick=" return EditButton() " OnClick="ButtonEdit_Click" CssClass="fanh" />
                            </td>
                            <td valign="top" class="lmf_app">
                                <asp:LinkButton ID="ButtonDelete" runat="server" OnClick="ButtonDelete_Click" OnClientClick=" return DeleteButton() "
                                    CausesValidation="False" class="shanchu lmf_btn"><span>����ɾ��</span></asp:LinkButton>
                            </td>
                            <td valign="top" class="lmf_app">
                                <t:MessageShow ID="MessageShow" Visible="false" runat="server" />
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <ShopNum1:Num1GridView ID="Num1GridView" runat="server" AutoGenerateColumns="False"
                AllowPaging="True" AllowSorting="True" ascendingimageurl="~/images/SortAsc.gif"
                descendingimageurl="~/images/SortDesc.gif" AddSequenceColumn="False" Width="98%"
                Del="False" DeletePromptText="ȷʵҪɾ��ָ���ļ�¼��" Edit="False" FixHeader="False" GridViewSortDirection="Ascending"
                PagingStyle="None" TableName="" DataSourceID="ObjectDataSourceDate" AllowMultiColumnSorting="False"
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
                            <input id="checkboxItem" value='<%# Eval("Guid") %>' type="checkbox" />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="��������">
                        <ItemTemplate>
                            <a href='<%#ShopUrlOperate.RetUrl("HelpList", Eval("Guid").ToString()) %>' target="_blank">
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("Title") %>'></asp:Label></a>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="Name" HeaderText="�������" ItemStyle-HorizontalAlign="Center">
                    </asp:BoundField>
                    <asp:BoundField DataField="CreateUser" HeaderText="�����" ItemStyle-HorizontalAlign="Center">
                    </asp:BoundField>
                    <asp:BoundField DataField="CreateTime" HeaderText="���ʱ��" DataFormatString="{0:yyyy-MM-dd}"
                        ItemStyle-HorizontalAlign="Center"></asp:BoundField>
                    <asp:BoundField DataField="ModifyUser" HeaderText="����޸���" ItemStyle-HorizontalAlign="Center">
                    </asp:BoundField>
                    <asp:BoundField DataField="ModifyTime" HeaderText="����޸�ʱ��" DataFormatString="{0:yyyy-MM-dd}"
                        ItemStyle-HorizontalAlign="Center"></asp:BoundField>
                    <asp:TemplateField HeaderText="����">
                        <ItemTemplate>
                            <a href="<%# "Help_Operate.aspx?guid='" + Eval("Guid") + "'" %>" style="color: #4482b4;">
                                �༭</a>
                            <asp:LinkButton ID="LinkDelte" runat="server" Style="color: #4482b4;" OnClick="ButtonDeleteBylink_Click"
                                CommandArgument='<%# Eval("Guid") %>' OnClientClick=" return window.confirm('��ȷ��Ҫɾ����?'); ">ɾ��</asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                </Columns>
            </ShopNum1:Num1GridView>
        </div>
    </div>
    <asp:ObjectDataSource ID="ObjectDataSourceDate" runat="server" SelectMethod="Search"
        TypeName="ShopNum1.BusinessLogic.ShopNum1_Help_Action">
        <SelectParameters>
            <asp:ControlParameter ControlID="TextBoxTitle" Name="title" PropertyName="Text" Type="String" />
            <asp:ControlParameter ControlID="DropDownListType" Name="type" PropertyName="SelectedValue"
                Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:HiddenField ID="HiddenFieldAgentLoginID" runat="server" />
    <asp:HiddenField ID="CheckGuid" runat="server" Value="0" />
    </form>
</body>
</html>
