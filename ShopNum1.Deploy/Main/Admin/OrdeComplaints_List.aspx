<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="OrdeComplaints_List.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.OrdeComplaints_List" %>

<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="ShopNum1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Ͷ�߹�������</title>
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
                    <asp:Label ID="LabelPageTitle" runat="server" Text="Ͷ�߹���"></asp:Label></h3>
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
                                Ͷ�߶���
                            </td>
                            <td>
                                <asp:TextBox ID="TextBoxComplaintShop" CssClass="tinput" Width="258" runat="server"></asp:TextBox>
                            </td>
                            <td class="lmf_padding">
                                Ͷ�����
                            </td>
                            <td>
                                <asp:DropDownList ID="DropDownListType" runat="server" Width="201" CssClass="tselect">
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:Button ID="ButtonSearch" runat="server" CssClass="dele" OnClick="ButtonSearch_Click"
                                    Text="��ѯ" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="sbtn">
                    <table cellpadding="0" cellspacing="0" border="0">
                        <tr>
                            <td valign="top">
                                <asp:LinkButton ID="Button1" runat="server" OnClick="ButtonDelete_Click" OnClientClick=" return DeleteButton() "
                                    CssClass="shanchu lmf_btn"><span>����ɾ��</span></asp:LinkButton>
                            </td>
                            <td valign="top" class="lmf_app">
                                <asp:LinkButton ID="ButtonReply" runat="server" CausesValidation="False" OnClientClick=" return EditButton() "
                                    CssClass="liuyan lmf_btn" OnClick="ButtonReply_Click" Visible="false"><span>�鿴���ظ�</span></asp:LinkButton>
                            </td>
                            <td valign="top" class="lmf_app">
                                <ShopNum1:MessageShow ID="MessageShow" runat="server" Visible="False" />
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <div>
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
                                <input id="checkboxItem" value='<%# Eval("ID") %>' type="checkbox" />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="Guid" HeaderText="Guid" Visible="False" />
                        <asp:TemplateField HeaderText="Ͷ�߱��" SortExpression="ID">
                            <ItemTemplate>
                                <a href='<%#"OrdeComplaints_Operate.aspx?guid=" + Eval("ID") %>'>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("ID") %>'></asp:Label></a>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="MemLoginID" HeaderText="Ͷ����" SortExpression="Title" ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField HeaderText="Ͷ�߶���" DataField="ComplaintShop" SortExpression="ComplaintShop"
                            ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField DataField="ComplaintTime" HeaderText="Ͷ��ʱ��" SortExpression="ComplaintTime">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Ͷ������" DataField="ComplaintType" SortExpression="ComplaintType"
                            ItemStyle-HorizontalAlign="Center" />
                        <asp:TemplateField HeaderText="����״̬" SortExpression="ProcessingStatus">
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%#IsProcess(Eval("ProcessingStatus"))
    %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="����">
                            <ItemTemplate>
                                <a href="<%# "OrdeComplaints_Operate.aspx?guid=" + Eval("ID") %>" style="color: #4482b4;">
                                    �ظ�</a>
                                <asp:LinkButton ID="LinkDelte" runat="server" Style="color: #4482b4;" CommandArgument='<%# Eval("ID") %>'
                                    OnClientClick=" return window.confirm('��ȷ��Ҫɾ����?'); " OnClick="ButtonDeleteBylink_Click">ɾ��</asp:LinkButton>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="15%" />
                        </asp:TemplateField>
                    </Columns>
                </ShopNum1:Num1GridView>
            </div>
        </div>
    </div>
    <asp:ObjectDataSource ID="ObjectDataSourceData" runat="server" SelectMethod="GetOrderComplaints"
        TypeName="ShopNum1.BusinessLogic.ShopNum1_OrdeComplaints_Action">
        <SelectParameters>
            <asp:ControlParameter ControlID="TextBoxComplaintShop" Name="ComplaintShop" PropertyName="Text"
                Type="String" />
            <asp:ControlParameter ControlID="DropDownListType" Name="type" PropertyName="SelectedValue"
                Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:HiddenField ID="CheckGuid" runat="server" Value="0" />
    </form>
</body>
</html>
