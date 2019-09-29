<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="ShopTemplate_List.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.ShopTemplate_List" %>

<%@ Register Assembly="ShopNum1.Control" Namespace="ShopNum1.Control" TagPrefix="cc1" %>
<%@ Import Namespace="System.Data" %>
<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="ShopNum1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>����ģ��</title>
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
                    ����ģ��</h3>
            </div>
            <div style="left: 1000px; top: 377px; visibility: hidden;" id="dhtmltooltip">
                <img src="" height="200" width="200px"></div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="order_edit">
                <table cellpadding="0" cellspacing="0" border="0">
                    <tr>
                        <td valign="top">
                            <asp:LinkButton ID="ButtonAdd" runat="server" OnClick="ButtonAdd_Click" OnClientClick="GetCheckedBoxValues()"
                                CausesValidation="False" CssClass="tianjia2 lmf_btn"><span>���</span></asp:LinkButton>
                        </td>
                        <td valign="top" class="lmf_app">
                            <asp:LinkButton ID="ButtonDelete" runat="server" OnClick="ButtonDelete_Click" OnClientClick="return DeleteButton()"
                                CausesValidation="False" CssClass="shanchu lmf_btn"><span>����ɾ��</span></asp:LinkButton>
                        </td>
                        <td valign="top" class="lmf_app">
                            <ShopNum1:MessageShow ID="MessageShow" runat="server" Visible="False" />
                        </td>
                    </tr>
                </table>
            </div>
            <ShopNum1:Num1GridView ID="Num1GridviewShow" runat="server" AutoGenerateColumns="False"
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
                        <ItemStyle HorizontalAlign="Center" Width="30px" />
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="���" DataField="ID" SortExpression="ID" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField HeaderText="����" DataField="Name" SortExpression="Name" ItemStyle-HorizontalAlign="Center">
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="ģ������ͼ">
                        <ItemTemplate>
                            <img src='<%# Page.ResolveUrl("~/Template/ShopTemplate/" +Eval("TemplateImg").ToString())%>'
                                onmouseover="javascript:ddrivetip('<img width=200px height=200 src=<%# Page.ResolveUrl("~/Template/ShopTemplate/" +Eval("TemplateImg").ToString())%> >','#ffffff')"
                                onmouseout="hideddrivetip()" height="20" width="20" />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="����" SortExpression="IsShow" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <a href="<%# "ShopTemplate_Operate.aspx?guid="+Eval("ID") %>" style="color: #4482b4;">
                                �༭</a>
                            <asp:LinkButton ID="LinkDelte" runat="server" Style="color: #4482b4;" CommandArgument='<%# Eval("ID")%>'
                                OnClientClick="return window.confirm('��ȷ��Ҫɾ����?');" OnClick="ButtonDeleteBylink_Click">ɾ��</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </ShopNum1:Num1GridView>
        </div>
        <asp:ObjectDataSource ID="ObjectDataSourceDate" runat="server" SelectMethod="Search"
            TypeName="ShopNum1.BusinessLogic.ShopNum1_ShopTemplate_Action"></asp:ObjectDataSource>
        <asp:HiddenField ID="CheckGuid" runat="server" Value="0" />
    </div>
    </form>
    <script type="text/javascript" src="js/showimg.js"></script>
</body>
</html>
