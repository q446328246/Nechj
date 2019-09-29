<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="ServiceOnLineService_List.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.ServiceOnLineService_List" %>

<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="ShopNum1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>���߿ͷ�</title>
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
                    <asp:Label ID="LabelTtitle" runat="server" Text="���߿ͷ�"></asp:Label></h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="order_edit">
                <table cellpadding="0" cellspacing="0" border="0">
                    <tr>
                        <td valign="top">
                            <asp:LinkButton ID="ButtonAdd" runat="server" CssClass="tianjia2 lmf_btn" OnClick="ButtonAdd_Click"
                                OnClientClick=" return GetCheckedBoxValues() "><span>���</span></asp:LinkButton>
                        </td>
                        <td valign="top" class="lmf_app">
                            <asp:LinkButton ID="ButtonDelete" runat="server" CausesValidation="False" CssClass="shanchu lmf_btn"
                                OnClientClick=" return DeleteButton() " OnClick="ButtonDelete_Click"><span>����ɾ��</span></asp:LinkButton>
                        </td>
                        <td valign="top" class="lmf_app">
                            <ShopNum1:MessageShow ID="MessageShow" Visible="false" runat="server" />
                        </td>
                    </tr>
                </table>
                <asp:ObjectDataSource ID="ObjectDataSourceDate" runat="server" SelectMethod="GetOnlineServiceInfo"
                    TypeName="ShopNum1.BusinessLogic.ShopNum1_OnLineService_Action">
                    <SelectParameters>
                        <asp:Parameter DefaultValue="0" Name="Deleted" Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
                <asp:HiddenField ID="CheckGuid" runat="server" Value="0" />
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
                            <input id="checkboxAll" onclick=" javascript: SelectAllCheckboxes(this); " type="checkbox" />
                        </HeaderTemplate>
                        <HeaderStyle CssClass="select_width" />
                        <ItemTemplate>
                            <input id="checkboxItem" value='<%# Eval("Guid") %>' type="checkbox" />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="���߿ͷ�����" DataField="Name" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField HeaderText="���߿ͷ��˺�" DataField="ServiceAccount" ItemStyle-HorizontalAlign="Center" />
                    <asp:TemplateField HeaderText="�Ƿ���ʾ">
                        <ItemTemplate>
                            <asp:Image ID="Image1" runat="server" src='<%# ChangeIsShow(DataBinder.Eval(Container, "DataItem(IsShow)", "{0}")) %>' />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="�����" DataField="OrderID" ItemStyle-HorizontalAlign="Center" />
                    <asp:TemplateField HeaderText="����">
                        <ItemTemplate>
                            <a href="<%# "ServiceOnLineService_Operate.aspx?guid=" + "'" + Eval("Guid") + "'" %>"
                                style="color: #4482b4;">�༭</a>
                            <asp:LinkButton ID="LinkDelte" runat="server" Style="color: #4482b4;" CommandArgument='<%#Eval("Guid") %>'
                                OnClientClick=" return window.confirm('��ȷ��Ҫɾ����?'); " OnClick="ButtonDeleteBylink_Click">ɾ��</asp:LinkButton>
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
