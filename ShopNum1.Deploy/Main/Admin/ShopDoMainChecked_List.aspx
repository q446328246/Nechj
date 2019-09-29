<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="ShopDoMainChecked_List.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.ShopDoMainChecked_List" %>

<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="ShopNum1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>������������б�</title>
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
                    ������������б�</h3>
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
                                <asp:Label ID="LabelSMemLoginID" runat="server" Text="��ԱID��"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBoxMemLoginID" runat="server" CssClass="tinput" Width="200"></asp:TextBox>
                            </td>
                            <td class="lmf_padding">
                                <asp:Label ID="Label4" runat="server" Text="���״̬��"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="DropDownListIsAudit" runat="server" CssClass="tselect" Style="width: 201px;">
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:Button ID="ButtonSearch" runat="server" Text="��ѯ" CssClass="dele" />
                            </td>
                        </tr>
                    </table>
                    <table border="0" cellspacing="0" cellpadding="0" style="margin-bottom: 7px;">
                        <tr>
                            <td>
                                <table cellpadding="0" cellspacing="0" border="0">
                                    <tr>
                                        <td valign="top" style="display: none;">
                                            <asp:LinkButton ID="ButtonReportexl" runat="server" CausesValidation="False" CssClass="daochubtn lmf_btn"
                                                OnClick="ButtonReportExcel_Click"><span>������Excel</span></asp:LinkButton>
                                        </td>
                                        <td valign="top" class="lmf_app" style="display: none;">
                                            <asp:LinkButton ID="ButtonReporthtl" runat="server" CausesValidation="False" CssClass="daochubtn lmf_btn"
                                                OnClick="ButtonReportHtml_Click" OnClientClick=" javascript:document.getElementById('form1').target = '_blank';window.location.href = window.location.href; ">
                                                        <span>������Html</span></asp:LinkButton>
                                        </td>
                                        <td valign="top">
                                            <asp:LinkButton ID="ButtonIsAudit1" runat="server" OnClick="ButtonIsAudit1_Click"
                                                OnClientClick=" return AuditButton() " CausesValidation="False" CssClass="shtg lmf_btn"><span>���ͨ��</span></asp:LinkButton>
                                        </td>
                                        <td valign="top" class="lmf_app">
                                            <asp:LinkButton ID="ButtonIsAudit0" runat="server" OnClick="ButtonIsAudit0_Click"
                                                OnClientClick=" return AuditButton() " CausesValidation="False" CssClass="shwtg lmf_btn"><span>���δͨ��</span></asp:LinkButton>
                                        </td>
                                        <td valign="top" class="lmf_app">
                                            <asp:LinkButton ID="ButtonDelete" OnClick="ButtonDelete_Click" runat="server" OnClientClick=" return DeleteButton() "
                                                CssClass="shanchu lmf_btn"><span>����ɾ��</span></asp:LinkButton>
                                        </td>
                                        <td valign="top" class="lmf_app">
                                            <ShopNum1:MessageShow ID="MessageShow" runat="server" Visible="False" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td style="display: none;">
                                <asp:RadioButtonList ID="RadioButtonListOutPage" runat="server" RepeatDirection="Horizontal">
                                    <asp:ListItem Selected="True" Value="0">����ӡ��ǰҳ</asp:ListItem>
                                    <asp:ListItem Value="1">��ӡ���в�ѯ��¼</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                    </table>
                </div>
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
                            <input id="checkboxAll" onclick=" javascript: SelectAllCheckboxes(this); " type="checkbox" />
                        </HeaderTemplate>
                        <HeaderStyle CssClass="select_width" />
                        <ItemTemplate>
                            <input id="checkboxItem" type="checkbox" value='<%# Eval("ID") %>' />
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID">
                        <HeaderStyle CssClass="hidden" />
                        <ItemStyle CssClass="hidden" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="����" SortExpression="DoMain">
                        <ItemTemplate>
                            <a id="A1" href='<%# "http://" + Eval("DoMain") %>' runat="server" target="_blank">
                                <asp:Label ID="Label2" runat="server" Text='<%# Eval("DoMain") %>'></asp:Label></a>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="����URL" SortExpression="GoUrl">
                        <ItemTemplate>
                            <a id="A1" href='<%# "http://" + Eval("GoUrl") %>' runat="server" target="_blank">
                                <asp:Label ID="Label3" runat="server" Text='<%# Bind("GoUrl") %>'></asp:Label></a>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="MemLoginID" HeaderText="��ԱID" SortExpression="MemLoginID">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="����ʱ��" DataField="AddTime" SortExpression="AddTime">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="���״̬" SortExpression="IsAudit">
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# ChangeIsAudit(DataBinder.Eval(Container, "DataItem(IsAudit)", "{0}")) %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="����" SortExpression="IsShow" Visible="false">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkDelte" runat="server" Style="color: #4482b4;" CommandArgument='<%# Eval("ID") %>'
                                OnClientClick=" return window.confirm('��ȷ��Ҫɾ����?'); " OnClick="ButtonDeleteBylink_Click">ɾ��</asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="15%" />
                    </asp:TemplateField>
                </Columns>
            </ShopNum1:Num1GridView>
        </div>
    </div>
    <asp:ObjectDataSource ID="ObjectDataSourceData" runat="server" SelectMethod="Search"
        TypeName="ShopNum1.BusinessLogic.ShopNum1_ShopURLManage_Action" OldValuesParameterFormatString="original_{0}">
        <SelectParameters>
            <asp:ControlParameter ControlID="TextBoxMemLoginID" Name="MemLoginID" PropertyName="Text"
                Type="String" />
            <asp:ControlParameter ControlID="DropDownListIsAudit" Name="isAudit" PropertyName="SelectedValue"
                Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:HiddenField ID="CheckGuid" runat="server" Value="0" />
    <asp:HiddenField ID="hiddenFieldGuid" runat="server" Value="0" />
    <br />
    </form>
</body>
</html>
