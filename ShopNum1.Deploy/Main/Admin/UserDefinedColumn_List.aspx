<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="UserDefinedColumn_List.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.UserDefinedColumn_List" %>

<%@ Import Namespace="ShopNum1.Common" %>
<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
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
                    ��Ŀ�б�</h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="order_edit">
                <table border="0" cellspacing="0" cellpadding="0">
                    <tr style="height: 35px; vertical-align: top;">
                        <td align="right">
                            <asp:Label ID="LabelSMemLoginID" runat="server" Text="��ʾλ�ã�"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlLocation" runat="server" Width="207px" CssClass="tselect">
                                <asp:ListItem Value="-1" Selected="True">-ȫ��-</asp:ListItem>
                                <asp:ListItem Value="0">�в����� </asp:ListItem>
                                <asp:ListItem Value="1">�ײ����� </asp:ListItem>
                                <asp:ListItem Value="2">���Ͻǵ���</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td class="lmf_padding">
                            &nbsp;
                        </td>
                        <td>
                            <asp:Button ID="ButtonSearch" runat="server" OnClick="ButtonSearch_Click" Text="��ѯ"
                                CssClass="dele" />
                        </td>
                    </tr>
                </table>
            </div>
            <div class="welcon clearfix">
                <div class="order_edit">
                    <table cellpadding="0" cellspacing="0" border="0">
                        <tr>
                            <td valign="top">
                                <asp:LinkButton ID="ButtonAdd" runat="server" OnClick="ButtonAdd_Click" CausesValidation="False"
                                    class="tianjia2 lmf_btn"><span>���</span></asp:LinkButton>
                            </td>
                            <td valign="top" class="lmf_app">
                                <asp:LinkButton ID="ButtonEdit" runat="server" Visible="false" OnClick="ButtonEdit_Click"
                                    OnClientClick=" return EditButton() " CausesValidation="False" class="dele lmf_btn"><span>�༭</span></asp:LinkButton>
                                <asp:LinkButton ID="ButtonDelete" runat="server" OnClick="ButtonDelete_Click" OnClientClick=" return DeleteButton() "
                                    CausesValidation="False" class="shanchu lmf_btn"><span>����ɾ��</span></asp:LinkButton>
                            </td>
                            <td valign="top" class="lmf_app">
                                <uc1:MessageShow ID="MessageShow" runat="server" Visible="False" />
                            </td>
                        </tr>
                    </table>
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
                                <input id="checkboxItem" type="checkbox" value='<%# Eval("Guid") %>' />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="Guid" HeaderText="GUID" Visible="False" SortExpression="Guid"
                            ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField DataField="Name" HeaderText="��Ŀ����" SortExpression="Name">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="LinkAddress" HeaderText="���ӵ�ַ" SortExpression="LinkAddress"
                            ItemStyle-HorizontalAlign="Center"></asp:BoundField>
                        <asp:TemplateField HeaderText="�Ƿ�ǰ̨��ʾ" SortExpression="IfShow" Visible="false">
                            <ItemTemplate>
                                <asp:Image ID="Image1" runat="server" ImageUrl='<%# PageOperator.GetListImageStatus(Eval("IfShow").ToString() == "0" ? "1" : "0") %>' />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="�Ƿ��Ա������ʾ" SortExpression="IsMember" Visible="false">
                            <ItemTemplate>
                                <asp:Image ID="Image2" runat="server" ImageUrl='<%# PageOperator.GetListImageStatus(Eval("IsMember").ToString() == "0" ? "1" : "0") %>' />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="�Ƿ����ǰ̨��ʾ" SortExpression="IsShop" Visible="false">
                            <ItemTemplate>
                                <asp:Image ID="Image3" runat="server" ImageUrl='<%# PageOperator.GetListImageStatus(Eval("IsShop").ToString() == "0" ? "1" : "0") %>' />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="��ʾλ��" SortExpression="IfOpen">
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# ShowLocation(Eval("ShowLocation").ToString()) %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="�Ƿ����´��ڴ�" SortExpression="IfOpen">
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# ChangeIfOpen(Eval("IfOpen").ToString()) %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="OrderID" HeaderText="����" SortExpression="OrderID">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="����">
                            <ItemTemplate>
                                <a href="<%# "UserDefinedColumn_Operate.aspx?guid='" + Eval("Guid") + "'" %>" style="color: #4482b4;">
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
        <asp:HiddenField ID="CheckGuid" runat="server" Value="0" />
        <asp:HiddenField ID="HiddenFieldAgentID" runat="server" />
        <asp:ObjectDataSource ID="ObjectDataSourceData" runat="server" SelectMethod="Search"
            TypeName="ShopNum1.BusinessLogic.ShopNum1_UserDefinedColumn_Action" OldValuesParameterFormatString="original_{0}">
            <SelectParameters>
                <asp:Parameter Name="Name" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </form>
</body>
</html>
