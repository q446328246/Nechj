<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="SurveyTheme_Manage.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.SurveyTheme_Manage" %>

<%@ Register Assembly="ShopNum1.Control" Namespace="ShopNum1.Control" TagPrefix="cc1" %>
<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="ShopNum1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>�̳����ߵ��� </title>
    <link rel='stylesheet' type='text/css' href='style/css.css' />
    <link id="sizestylesheet" rel='stylesheet' type='text/css' href='style/css1.css' />
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
                    �̳����ߵ���</h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="order_edit">
                <div>
                    <table border="0" cellspacing="0" cellpadding="0" style="margin-bottom: 7px;">
                        <tr style="height: 35px; vertical-align: top;">
                            <td>
                                ͶƱ���⣺
                            </td>
                            <td>
                                <asp:TextBox ID="textBoxSurveyTitle" runat="server" CssClass="tinput" Width="258"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Button ID="ButtonSearch" runat="server" Text="��ѯ" OnClick="btnQuery_Click" CssClass="dele" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="sbtn">
                    <asp:Button ID="ButtonAdd" runat="server" OnClick="ButtonAdd_Click" Text="���" OnClientClick=" GetCheckedBoxValues() "
                        CssClass="tianjia2 picbtn" />
                    <asp:Button ID="ButtonEdit" runat="server" OnClick="ButtonEdit_Click" OnClientClick=" return;
EditButton(); " Text="�༭" CssClass="dele" Visible="false" />
                    <asp:Button ID="ButtonDelete" runat="server" Text="����ɾ��" OnClientClick=" return DeleteButton() "
                        OnClick="ButtonDelete_Click" CssClass="shanchu com" />
                    <asp:Button ID="ButtonAddOption" runat="server" OnClick="ButtonAddOption_Click" OnClientClick=" return EditButton() "
                        Text="���ѡ��" CssClass="tianjiafl picbtn" />
                    <ShopNum1:MessageShow ID="MessageShow" runat="server" Visible="False" />
                </div>
            </div>
            <ShopNum1:Num1GridView ID="num1GridiewShow" runat="server" AutoGenerateColumns="False"
                AllowPaging="True" AllowSorting="True" ascendingimageurl="~/images/SortAsc.gif"
                descendingimageurl="~/images/SortDesc.gif" AddSequenceColumn="False" Width="98%"
                Del="False" DeletePromptText="ȷʵҪɾ��ָ���ļ�¼��" Edit="False" FixHeader="False" GridViewSortDirection="Ascending"
                PagingStyle="None" TableName="" DataSourceID="ObjectDataSourceData" AllowMultiColumnSorting="False"
                BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="0" CellPadding="4"
                GridLines="Vertical">
                <FooterStyle BackColor="#CCCC99" />
                <HeaderStyle HorizontalAlign="Center" CssClass="list_header" ForeColor="White"></HeaderStyle>
                <%--��ҳ--%>
                <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <input id="checkboxAll" onclick=" javascript: SelectAllCheckboxes(this); " type="checkbox" />
                        </HeaderTemplate>
                        <ItemTemplate>
                            <input id="checkboxItem" type="checkbox" value='<%# Eval("Guid") %>' />
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="Guid" HeaderText="GUID" Visible="False" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="Title" HeaderText="ͶƱ����" SortExpression="Title" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="StartTime" HeaderText="��ʼʱ��" SortExpression="StartTime">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="EndTime" HeaderText="����ʱ��" SortExpression="EndTime">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="����">
                        <ItemTemplate>
                            <a href="<%# "SurveyTheme_Operate.aspx?Guid='" + Eval("Guid") + "'" %>" style="color: #4482b4;">
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
    <asp:ObjectDataSource ID="ObjectDataSourceData" runat="server" OldValuesParameterFormatString="original_{0}"
        SelectMethod="Search" TypeName="ShopNum1.BusinessLogic.ShopNum1_SurveyTheme_Action">
        <SelectParameters>
            <asp:ControlParameter ControlID="textBoxSurveyTitle" Name="name" PropertyName="Text"
                Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:HiddenField ID="CheckGuid" runat="server" Value="0" />
    </form>
</body>
</html>
