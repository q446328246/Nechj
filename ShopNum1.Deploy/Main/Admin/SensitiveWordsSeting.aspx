<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="SensitiveWordsSeting.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.SensitiveWordsSeting" %>

<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="ShopNum1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>����������</title>
    <link rel="stylesheet" type="text/css" href="style/css.css" />
    <script type="text/javascript" language="javascript" src="js/CommonJS.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="right">
        <div class="rhigth">
            <div class="rl">
            </div>
            <div class="rcon">
                <h3>
                    ����������</h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="order_edit">
                <table cellpadding="0" cellspacing="0" border="0">
                    <tr style="height: 35px; vertical-align: top;">
                        <td>
                            <asp:Label ID="LabelName" runat="server" Text="���ƣ�"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxName" CssClass="tinput" runat="server" Width="258"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Button ID="ButtonSearch" runat="server" CssClass="dele" Text="����" OnClick="ButtonSearch_Click" />
                        </td>
                    </tr>
                </table>
                <div class="sbtn">
                    <table cellpadding="0" cellspacing="0" border="0">
                        <tr>
                            <td valign="top">
                                <asp:LinkButton ID="ButtonInsert" runat="server" CssClass="tianjia2 lmf_btn" OnClick="ButtonInsert_Click"><span>���</span></asp:LinkButton>
                            </td>
                            <td valign="top" class="lmf_app" style="display: none;">
                                <asp:LinkButton ID="ButtonUpdata" runat="server" CssClass="dele" OnClientClick="return EditButton()"
                                    OnClick="ButtonUpdata_Click" Visible="false"><span>�༭</span></asp:LinkButton>
                            </td>
                            <td valign="top" class="lmf_app">
                                <asp:LinkButton ID="ButtonDel" runat="server" CssClass="shanchu lmf_btn" OnClientClick="return DeleteButton()"
                                    OnClick="ButtonDel_Click"><span>����ɾ��</span></asp:LinkButton>
                            </td>
                            <td valign="top" class="lmf_app">
                                <ShopNum1:MessageShow ID="MessageShow" Visible="false" runat="server" />
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <ShopNum1:Num1GridView ID="Num1GridViewShow" runat="server" AutoGenerateColumns="False"
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
                            <input id="checkboxAll" onclick="javascript:SelectAllCheckboxes(this);" type="checkbox" />
                        </HeaderTemplate>
                        <HeaderStyle CssClass="select_width" />
                        <ItemTemplate>
                            <input id="checkboxItem" value='<%# Eval("ID") %>' type="checkbox" />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="5%" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="find" HeaderText="��Ҫ�滻��������" ItemStyle-Width="40%" SortExpression="find"
                        ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="replacement" HeaderText="�滻��" ItemStyle-Width="40%" SortExpression="replacement"
                        ItemStyle-HorizontalAlign="Center" />
                    <asp:TemplateField HeaderText="����">
                        <ItemTemplate>
                            <a href="<%# "SensitiveWordsSeting_Operate.aspx?ID="+Eval("ID") %>" style="color: #4482b4;">
                                �༭</a>
                            <asp:LinkButton ID="LinkDelte" runat="server" Style="color: #4482b4;" CommandArgument='<%# Eval("ID") %>'
                                OnClientClick="return window.confirm('��ȷ��Ҫɾ����?');" OnClick="ButtonDeleteBylink_Click">ɾ��</asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="15%" />
                    </asp:TemplateField>
                </Columns>
            </ShopNum1:Num1GridView>
        </div>
        <asp:ObjectDataSource ID="ObjectDataSourceDate" runat="server" SelectMethod="SearchByName"
            TypeName="ShopNum1.BusinessLogic.ShopNum1_BadWord_Action">
            <SelectParameters>
                <asp:ControlParameter ControlID="TextBoxName" Name="name" PropertyName="Text" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:HiddenField ID="CheckGuid" runat="server" Value="0" />
        <!-- #include file="Hintinfo.aspx" -->
    </div>
    </form>
</body>
</html>
