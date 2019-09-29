<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="HelpType_List.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.HelpType_List" %>

<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="t" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>���������б�</title>
    <link rel="stylesheet" type="text/css" href="style/css.css" />
    <script type="text/javascript" language="javascript" src="js/CommonJS.js"> </script>
    <script type="text/javascript" src="js/jquery-1.3.2.min.js"> </script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="right">
        <div class="rhigth">
            <div class="rl">
            </div>
            <div class="rcon">
                <h3>
                    ���������б�</h3>
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
                                <asp:Localize ID="LocalizeName" runat="server" Text="�������ƣ�"></asp:Localize>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBoxName" CssClass="tinput" runat="server" Width="258"></asp:TextBox>
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
                                    OnClientClick=" return EditButton() " OnClick="ButtonEdit_Click" CssClass="dele" />
                            </td>
                            <td valign="top" class="lmf_app">
                                <asp:LinkButton ID="ButtonDelete" runat="server" OnClick="ButtonDelete_Click" OnClientClick=" return DeleteButton() "
                                    CausesValidation="False" class="shanchu lmf_btn"><span>����ɾ��</span></asp:LinkButton>
                            </td>
                            <td valign="top" class="lmf_app">
                                <t:MessageShow ID="MessageShow" Visible="false" runat="server" />
                                <asp:ObjectDataSource ID="ObjectDataSourceDate" runat="server" SelectMethod="Search"
                                    TypeName="ShopNum1.BusinessLogic.ShopNum1_HelpType_Action">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="TextBoxName" Name="name" PropertyName="Text" Type="String" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                                <asp:HiddenField ID="HiddenFieldAgentLoginID" runat="server" />
                                <asp:HiddenField ID="CheckGuid" runat="server" Value="0" />
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <ShopNum1:Num1GridView ID="China315GridViewShow" runat="server" AutoGenerateColumns="False"
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
                    <asp:BoundField DataField="Name" HeaderText="������������" ItemStyle-HorizontalAlign="Center">
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
                            <a href="<%# "HelpType_Operate.aspx?guid='" + Eval("Guid") + "'" %>" style="color: #4482b4;">
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
    </form>
</body>
</html>
