<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="ShopNum1_CategoryInfoChecked_List.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.ShopNum1_CategoryInfoChecked_List" %>

<%@ Import Namespace="ShopNum1.Common" %>
<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="ShopNum1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>��ƽ̨-������Ϣ���</title>
    <link rel="stylesheet" type="text/css" href="style/css.css" />
    <script type="text/javascript" language="javascript" src="js/CommonJS.js"> </script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div id="right">
        <div class="rhigth">
            <div class="rl">
            </div>
            <div class="rcon">
                <h3>
                    <asp:Label ID="Label1" runat="server" Text="������Ϣ���" /></h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="order_edit">
                <div>
                    <table border="0" cellspacing="0" cellpadding="0">
                        <tr style="height: 35px; vertical-align: top;">
                            <td style="text-align: right;">
                                <asp:Localize ID="LocalizeFavourTickitName" runat="server" Text="�����ѯ��"></asp:Localize>
                            </td>
                            <td>
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="DropDownListCategoryCf" runat="server" AutoPostBack="true"
                                            CssClass="tselect" Style="width: 100px;" OnSelectedIndexChanged="DropDownListCategoryCf_SelectedIndexChanged">
                                        </asp:DropDownList>
                                        <asp:DropDownList ID="DropDownListCategoryCs" runat="server" CssClass="tselect" Style="width: 100px;"
                                            OnSelectedIndexChanged="DropDownListCategoryCs_SelectedIndexChanged">
                                            <asp:ListItem Text="" Value="-1"></asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:DropDownList ID="DropDownListCategoryCt" runat="server" CssClass="tselect" Style="width: 100px;">
                                            <asp:ListItem Text="" Value="-1"></asp:ListItem>
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            <td class="lmf_padding" style="text-align: right;">
                                <asp:Localize ID="Localize1" runat="server" Text="���״̬��"></asp:Localize>
                            </td>
                            <td>
                                <asp:DropDownList ID="DropDownListIsAudit" runat="server" CssClass="tselect" Style="width: 201px;">
                                </asp:DropDownList>
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
                                <asp:Button ID="ButtonSearchDetail" Visible="false" runat="server" Text="�鿴" CssClass="dele"
                                    OnClientClick=" return EditButton() " OnClick="ButtonSearchDetail_Click" />
                                <asp:LinkButton ID="ButtonAudit" runat="server" OnClick="ButtonAudit_Click" OnClientClick=" return AuditButton() "
                                    CausesValidation="False" class="shtg lmf_btn"><span>���ͨ��</span></asp:LinkButton>
                            </td>
                            <td valign="top" class="lmf_app">
                                <asp:LinkButton ID="ButtonCancelAudit" runat="server" OnClick="ButtonCancelAudit_Click"
                                    OnClientClick=" return AuditButton() " CausesValidation="False" class="shwtg lmf_btn"><span>���δͨ��</span></asp:LinkButton>
                            </td>
                            <td valign="top" class="lmf_app">
                                <asp:LinkButton ID="ButtonDelete" runat="server" OnClick="ButtonDelete_Click" OnClientClick=" return DeleteButton() "
                                    CausesValidation="False" class="shanchu lmf_btn"><span>����ɾ��</span></asp:LinkButton>
                            </td>
                        </tr>
                    </table>
                    <ShopNum1:MessageShow ID="MessageShow1" runat="server" Visible="false" />
                </div>
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
                            <input id="checkboxItem" value='<%# Eval("Guid") %>' type="checkbox" />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="����">
                        <ItemTemplate>
                            <a href='<%#ShopUrlOperate.RetUrl("CategoryInfoDetail", Eval("Guid").ToString()) %>'
                                target="_blank">
                                <asp:Label ID="Label3" runat="server" Text='<%# Bind("Title") %>'></asp:Label></a>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="AssociatedMemberID" HeaderText="������" SortExpression="AssociatedMemberID"
                        ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField HeaderText="��������" DataField="AssociatedCategoryName" ItemStyle-HorizontalAlign="Center"
                        SortExpression="AssociatedCategoryName" />
                    <asp:TemplateField HeaderText="��������">
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" Text='<%# Eval("Type") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="��Ч��">
                        <ItemTemplate>
                            <asp:Label ID="Label3" runat="server" Text='<%# GetValidateTime(Eval("ValidTime")) %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="�ؼ���" DataField="Keywords" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField HeaderText="��ϵ�绰" DataField="Tel" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField HeaderText="�����ʼ�" DataField="Email" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField HeaderText="������ϵ��ʽ" DataField="OtherContactWay" ItemStyle-HorizontalAlign="Center" />
                    <asp:TemplateField HeaderText="���״̬">
                        <ItemTemplate>
                            <asp:Image ID="Image1" runat="server" ImageUrl='<%# PageOperator.GetListImageStatus(Eval("IsAudit").ToString()) %>' />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="����">
                        <ItemTemplate>
                            <a href="<%# "CategoryDetails.aspx?guid=" + Eval("Guid") + "" %>" style="color: #4482b4;">
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
    <asp:HiddenField ID="HiddenFieldCode" runat="server" Value="0" />
    <asp:HiddenField ID="CheckGuid" runat="server" Value="0" />
    <asp:ObjectDataSource ID="ObjectDataSourceData" runat="server" SelectMethod="Search"
        TypeName="ShopNum1.BusinessLogic.ShopNum1_CategoryChecked_Action">
        <SelectParameters>
            <asp:ControlParameter ControlID="HiddenFieldCode" Name="Code" PropertyName="Value"
                Type="String" />
            <asp:ControlParameter ControlID="DropDownListIsAudit" DefaultValue="-2" Name="isAudit"
                PropertyName="SelectedValue" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
    </form>
</body>
</html>
