<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="MMS_List.aspx.cs" Inherits="ShopNum1.Deploy.Main.Admin.MMS_List" %>

<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="ShopNum1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>���Ź���</title>
    <script type="text/javascript" language="javascript" src="js/CommonJS.js"> </script>
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
                    ����ģ�����</h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="order_edit">
                <table cellpadding="0" cellspacing="0" border="0">
                    <tr style="height: 35px; vertical-align: top;">
                        <td>
                            ���ű��⣺
                        </td>
                        <td>
                            <asp:TextBox ID="textBoxTitle" runat="server" CssClass="tinput" Width="200px"></asp:TextBox>
                        </td>
                        <td class="lmf_padding" style="display: none">
                            �������
                        </td>
                        <td style="display: none">
                            <asp:DropDownList ID="DropDownListType" runat="server" Width="201px" CssClass="tselect">
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:Button ID="ButtonSearch" runat="server" OnClick="ButtonSearch_Click" Text="��ѯ"
                                CssClass="dele" />
                        </td>
                    </tr>
                </table>
                <div class="sbtn">
                    <table cellpadding="0" cellspacing="0" border="0">
                        <tr>
                            <td valign="top">
                                <asp:LinkButton ID="ButtonAdd" runat="server" OnClick="ButtonAdd_Click" OnClientClick=" GetCheckedBoxValues() "
                                    class="tianjia2 lmf_btn"><span>���</span></asp:LinkButton>
                            </td>
                            <td valign="top" class="lmf_app">
                                <asp:LinkButton ID="ButtonDelete" runat="server" OnClick="ButtonDelete_Click" OnClientClick=" return DeleteButton() "
                                    class="shanchu lmf_btn"><span>����ɾ��</span></asp:LinkButton>
                            </td>
                            <td valign="top" class="lmf_app">
                                <ShopNum1:MessageShow ID="MessageShow" runat="server" Visible="False" />
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <ShopNum1:Num1GridView ID="Num1GridiewShow" runat="server" AutoGenerateColumns="False"
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
                    <%--<asp:TemplateField>
                        <HeaderTemplate>
                            <input id="checkboxAll" onclick="javascript:SelectAllCheckboxes(this);" type="checkbox" />
                        </HeaderTemplate>
                        <HeaderStyle CssClass="select_width" />
                        <ItemTemplate>
                            <input id="checkboxItem" type="checkbox" value='<%# Eval("Guid") %>' />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>--%>
                    <asp:BoundField DataField="Guid" HeaderText="GUID" SortExpression="Guid" Visible="False"
                        ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="Title" HeaderText="���ű���" SortExpression="Title" ItemStyle-HorizontalAlign="Center" />
                    <%--<asp:BoundField DataField="TypeName" HeaderText="�������" SortExpression="TypeName"
                        ItemStyle-HorizontalAlign="Center">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>--%>
                    <asp:BoundField HeaderText="��������" DataField="Description" SortExpression="Description"
                        ItemStyle-HorizontalAlign="Center" />
                    <asp:TemplateField HeaderText="����">
                        <ItemTemplate>
                            <a href="<%# "MMS_Operate.aspx?guid='" + Eval("Guid") + "'" %>" style="color: #4482b4;">
                                �༭</a>
                            <asp:LinkButton ID="LinkDelte" runat="server" Style="color: #4482b4;" OnClick="ButtonDeleteBylink_Click"
                                CommandArgument='<%# Eval("Guid") %>' Visible="false" OnClientClick=" return window.confirm('��ȷ��Ҫɾ����?'); ">ɾ��</asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                </Columns>
            </ShopNum1:Num1GridView>
        </div>
        <asp:ObjectDataSource ID="ObjectDataSourceData" runat="server" SelectMethod="Search"
            TypeName="ShopNum1.BusinessLogic.ShopNum1_MMS_Action">
            <SelectParameters>
                <asp:ControlParameter ControlID="textBoxTitle" Name="title" PropertyName="Text" Type="String" />
                <asp:ControlParameter ControlID="DropDownListType" Name="typename" PropertyName="SelectedValue"
                    Type="String" />
                <asp:Parameter DefaultValue="0" Name="isDeleted" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:HiddenField ID="CheckGuid" runat="server" Value="0" />
    </div>
    </form>
</body>
</html>
