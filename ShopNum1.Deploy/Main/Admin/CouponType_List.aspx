<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="CouponType_List.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.CouponType_List" %>

<%@ Import Namespace="ShopNum1.Common" %>
<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="ShopNum1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>�Ż�ȯ�����б�</title>
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
                    �Ż�ȯ�����б�</h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="order_edit">
                <table cellpadding="0" cellspacing="0" border="0">
                    <tr>
                        <td valign="top">
                            <asp:LinkButton ID="ButtonAdd" runat="server" ToolTip="Submit" CssClass="tianjia2 lmf_btn"
                                OnClick="ButtonAdd_Click"><span>���</span></asp:LinkButton>
                        </td>
                        <td valign="top" class="lmf_app">
                            <asp:LinkButton ID="ButtonDelete" runat="server" CssClass="shanchu lmf_btn" OnClientClick=" return DeleteButton() "
                                OnClick="ButtonDelete_Click"><span>����ɾ��</span></asp:LinkButton>
                        </td>
                        <td valign="top" class="lmf_app">
                            <ShopNum1:MessageShow ID="MessageShow" Visible="false" runat="server" />
                        </td>
                    </tr>
                </table>
            </div>
            <ShopNum1:Num1GridView ID="num1GridViewShow" runat="server" AutoGenerateColumns="False"
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
                            <input id="checkboxAll" onclick=" javascript:SelectAllCheckboxes(this); " type="checkbox" />
                        </HeaderTemplate>
                        <HeaderStyle CssClass="select_width" />
                        <ItemTemplate>
                            <input id="checkboxItem" type="checkbox" value='<%# Eval("ID") %>' />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="��������">
                        <ItemTemplate>
                            <%#Utils.GetUnicodeSubString(Eval("Name").ToString(), 25, "") %>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="25%" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="����">
                        <ItemTemplate>
                            <%#Eval("Comment") %>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="55%" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="�Ƿ���ʾ" SortExpression="IsShow">
                        <ItemTemplate>
                            <asp:Image ID="Image1" runat="server" src='<%# GetRight(Eval("IsShow").ToString()) %>' />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="5%" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="����">
                        <ItemTemplate>
                            <a href="<%# "CouponType_Operate.aspx?ID=" + Eval("ID") %>" style="color: #4482b4;">
                                �༭</a>
                            <asp:LinkButton ID="LinkDelte" runat="server" Style="color: #4482b4;" CommandArgument='<%# Eval("ID") %>'
                                OnClick="ButtonDeleteBylink_Click" OnClientClick=" return window.confirm('��ȷ��Ҫɾ����?'); "> ɾ�� </asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="15%" />
                    </asp:TemplateField>
                </Columns>
            </ShopNum1:Num1GridView>
        </div>
        <asp:ObjectDataSource ID="ObjectDataSourceData" runat="server" SelectMethod="search"
            TypeName="ShopNum1.ShopBusinessLogic.Shop_CouponType_Action">
            <SelectParameters>
                <asp:Parameter DefaultValue="-1" Name="id" Type="Int32" />
                <asp:Parameter DefaultValue="-1" Name="isshow" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:HiddenField ID="CheckGuid" runat="server" Value="0" />
    </div>
    </form>
</body>
</html>
