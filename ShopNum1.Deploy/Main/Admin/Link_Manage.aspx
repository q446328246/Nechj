<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="Link_Manage.aspx.cs" Inherits="ShopNum1.Deploy.Main.Admin.Link_Manage" %>

<%@ Import Namespace="ShopNum1.Common" %>
<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="ShopNum1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>��������</title>
    <link rel='stylesheet' type='text/css' href='style/css.css' />
    <link id="sizestylesheet" rel='stylesheet' type='text/css' href='style/css1.css' />
    <script type="text/javascript" language="javascript" src="js/CommonJS.js"> </script>
    <script type='text/javascript' src='js/resolution-test.js'> </script>
</head>
<body class="widthah2">
    <form id="form1" runat="server">
    <div id="right">
        <div class="rhigth">
            <div class="rl">
            </div>
            <div class="rcon">
                <h3>
                    ��������</h3>
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
                                ���ӱ��⣺
                            </td>
                            <td>
                                <asp:TextBox ID="TextBoxName" runat="server" CssClass="tinput" Width="200"></asp:TextBox>
                            </td>
                            <td class="lmf_padding">
                                �Ƿ�ǰ̨��ʾ��
                            </td>
                            <td>
                                <asp:DropDownList ID="DropDownListIsShow" runat="server" Width="201px" CssClass="tselect">
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:Button ID="ButtonSearch" runat="server" OnClick="ButtonSearch_Click" Text="��ѯ"
                                    CssClass="dele" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="sbtn">
                    <asp:Button ID="ButtonAdd" runat="server" OnClick="ButtonAdd_Click" Text="���" OnClientClick=" GetCheckedBoxValues() "
                        CssClass="tianjia2 picbtn" />
                    <asp:Button ID="ButtonEdit" runat="server" OnClick="ButtonEdit_Click" OnClientClick=" return EditButton() "
                        Text="�༭" CssClass="dele" Visible="false" />
                    <asp:Button ID="ButtonDelete" runat="server" Text="����ɾ��" OnClientClick=" return DeleteButton() "
                        OnClick="ButtonDelete_Click" CssClass="shanchu com" />
                    <ShopNum1:MessageShow ID="MessageShow" runat="server" Visible="False" />
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
                <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <input id="checkboxAll" onclick=" javascript: SelectAllCheckboxes(this); " type="checkbox" />
                        </HeaderTemplate>
                        <ItemTemplate>
                            <input id="checkboxItem" value='<%# Eval("Guid") %>' type="checkbox" />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="Guid" HeaderText="GUID" Visible="False" />
                    <asp:BoundField DataField="Name" HeaderText="���ӱ���" SortExpression="Name">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="��������" SortExpression="LinkType">
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" Text='<%# ChangeLinkType(DataBinder.Eval
                                                                                                       (Container, "DataItem(LinkType)", "{0}")) %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="���ӵ�ַ" SortExpression="Href">
                        <ItemTemplate>
                            <a href='<%# Eval("Href") %>' target="_blank">
                                <asp:Label ID="Label4" runat="server" Text='<%# Bind("Href") %>'></asp:Label></a>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="OrderID" HeaderText="�����" SortExpression="OrderID">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="CreateTime" HeaderText="����ʱ��" SortExpression="CreateTime">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="�Ƿ�ǰ̨��ʾ">
                        <ItemTemplate>
                            <asp:Image ID="Image1" runat="server" ImageUrl='<%# PageOperator.GetListImageStatus(DataBinder.Eval(Container,
                                                                                                                                        "DataItem(IsShow)", "{0}") == "0" ? "1" : "0") %>' />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="����">
                        <ItemTemplate>
                            <a href="<%# "Link_Operate.aspx?Guid='" + Eval("Guid") + "'" %>" style="color: #4482b4;">
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
    <asp:ObjectDataSource ID="ObjectDataSourceData" runat="server" SelectMethod="Search"
        TypeName="ShopNum1.BusinessLogic.ShopNum1_Link_Action">
        <SelectParameters>
            <asp:ControlParameter ControlID="TextBoxName" DefaultValue="%" Name="name" PropertyName="Text"
                Type="String" />
            <asp:ControlParameter ControlID="DropDownListIsShow" DefaultValue="-1" Name="isShow"
                PropertyName="SelectedValue" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:HiddenField ID="CheckGuid" runat="server" Value="0" />
    </form>
</body>
</html>
