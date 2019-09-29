<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="ShopEnsure_List.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.ShopEnsure_List" %>

<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>���̵����б�</title>
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
                    ���̵����б�</h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="order_edit">
                <table cellpadding="0" cellspacing="0" border="0">
                    <tr style="height: 35px; vertical-align: top;">
                        <td>
                            �������ƣ�
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxName" runat="server" CssClass="tinput" Width="258"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Button ID="ButtonSearch" runat="server" Text="��ѯ" OnClick="ButtonSearch_Click"
                                CssClass="dele" />
                        </td>
                    </tr>
                </table>
                <div class="sbtn">
                    <table cellpadding="0" cellspacing="0" border="0">
                        <tr>
                            <td valign="top">
                                <asp:LinkButton ID="ButtonAdd" runat="server" OnClick="ButtonAdd_Click" CausesValidation="False"
                                    CssClass="tianjia2 lmf_btn"><span>���</span></asp:LinkButton>
                            </td>
                            <td valign="top" class="lmf_app" style="display: none;">
                                <asp:LinkButton ID="ButtonEdit" runat="server" CausesValidation="False" OnClientClick=" return EditButton() "
                                    OnClick="ButtonEdit_Click" CssClass="dele" Visible="false"><span>�༭</span></asp:LinkButton>
                            </td>
                            <td valign="top" class="lmf_app">
                                <asp:LinkButton ID="ButtonDelete" runat="server" CausesValidation="False" OnClientClick=" return DeleteButton(); "
                                    OnClick="ButtonDelete_Click" CssClass="shanchu lmf_btn"><span>����ɾ��</span></asp:LinkButton>
                            </td>
                            <td valign="top" class="lmf_app">
                                <uc1:MessageShow ID="MessageShow" runat="server" Visible="False" />
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
                            <input id="checkboxAll" onclick=" javascript:SelectAllCheckboxes(this); " type="checkbox" />
                        </HeaderTemplate>
                        <HeaderStyle CssClass="select_width" />
                        <ItemTemplate>
                            <input id="checkboxItem" value='<%# Eval("id") %>' type="checkbox" />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="3%" />
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="��������" DataField="Name" SortExpression="Name" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField HeaderText="�������" DataField="EnsureMoney" SortExpression="EnsureMoney"
                        ItemStyle-HorizontalAlign="Center" />
                    <asp:TemplateField HeaderText="������ʶ" SortExpression="image">
                        <ItemTemplate>
                            <img src='<%#Page.ResolveClientUrl(Eval("ImagePath").ToString()) %>' alt="" />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="����">
                        <ItemTemplate>
                            <a href="<%# "ShopEnsure_Operate.aspx?id=" + Eval("id") %>" style="color: #4482b4;">
                                �༭</a>
                            <asp:LinkButton ID="LinkDelte" runat="server" Style="color: #4482b4;" CommandArgument='<%# Eval("ID") %>'
                                OnClick="ButtonDeleteBylink_Click" OnClientClick=" return window.confirm('��ȷ��Ҫɾ����?'); "> ɾ�� </asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="15%" />
                    </asp:TemplateField>
                </Columns>
            </ShopNum1:Num1GridView>
        </div>
        <asp:HiddenField ID="CheckGuid" runat="server" Value="0" />
        <asp:ObjectDataSource ID="ObjectDataSourceData" runat="server" SelectMethod="GetShopEnsureList"
            TypeName="ShopNum1.ShopBusinessLogic.Shop_Ensure_Action" OldValuesParameterFormatString="original_{0}">
            <SelectParameters>
                <asp:ControlParameter ControlID="TextBoxName" Name="name" PropertyName="Text" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </div>
    </form>
</body>
</html>
