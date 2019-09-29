<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="ShopRank_List.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.ShopRank_List" %>

<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="ShopNum1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>���̵ȼ�</title>
    <link rel='stylesheet' type='text/css' href='style/css.css' />
    <link id="sizestylesheet" rel='stylesheet' type='text/css' href='style/css1.css' />
    <script type="text/javascript" language="javascript" src="js/CommonJS.js"> </script>
    <script type='text/javascript' src='js/resolution-test.js'> </script>
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
                    ���̵ȼ�</h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="order_edit">
                <table cellpadding="0" cellspacing="0" border="0">
                    <tr>
                        <td valign="top">
                            <asp:LinkButton ID="ButtonAdd" runat="server" CssClass="tianjia2 lmf_btn" PostBackUrl="~/Main/Admin/ShopRank_Operate.aspx">
                                        <span>���</span></asp:LinkButton>
                        </td>
                        <td valign="top" class="lmf_app" style="display: none;">
                            <asp:LinkButton ID="ButtonEdit" runat="server" OnClick="ButtonEdit_Click" OnClientClick=" return EditButton() "
                                CausesValidation="False" CssClass="dele" Visible="false"><span>�༭</span></asp:LinkButton>
                        </td>
                        <td valign="top" class="lmf_app">
                            <asp:LinkButton ID="ButtonDelete" runat="server" OnClick="ButtonDelete_Click" OnClientClick=" return DeleteButton() "
                                CausesValidation="False" CssClass="shanchu lmf_btn"><span>����ɾ��</span></asp:LinkButton>
                        </td>
                        <td valign="top" class="lmf_app">
                            <ShopNum1:MessageShow ID="MessageShow" Visible="false" runat="server" />
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
                            <input id="checkboxAll" onclick=" javascript:SelectAllCheckboxes(this); " type="checkbox" />
                        </HeaderTemplate>
                        <HeaderStyle CssClass="select_width" />
                        <ItemTemplate>
                            <input id="checkboxItem" value='<%# Eval("Guid") %>' type="checkbox" runat="server" />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="30px" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="Name" HeaderText="����" SortExpression="Name" ItemStyle-HorizontalAlign="Center" />
                    <asp:TemplateField HeaderText="�ȼ�ͼƬ" SortExpression="Pic">
                        <ItemTemplate>
                            <img src='<%# Page.ResolveUrl(Eval("Pic").ToString()) %>' />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="MaxProductCount" HeaderText="�����Ʒ����" SortExpression="MaxProductCount"
                        ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField HeaderText="�������(Ԫ/��)" DataField="price" SortExpression="price" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="MaxArticleCout" HeaderText="��ӵ������Ѷ����" SortExpression="MaxArticleCout"
                        ItemStyle-HorizontalAlign="Center" Visible="false" />
                    <asp:BoundField DataField="MaxVedioCount" HeaderText="��ӵ������Ƶ����" SortExpression="MaxVedioCount"
                        ItemStyle-HorizontalAlign="Center" Visible="false" />
                    <asp:BoundField DataField="shopTemplate" HeaderText="����ʹ�õ�ģ��" SortExpression="shopTemplate"
                        ItemStyle-HorizontalAlign="Center" Visible="false" />
                    <asp:TemplateField HeaderText="�ȼ�ֵ" SortExpression="Pic">
                        <ItemTemplate>
                            <%#Eval("RankValue") %>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="�Ƿ�Ĭ��" SortExpression="IsDefault">
                        <ItemTemplate>
                            <asp:Image ID="Image2" runat="server" src='<%# GetRight(Eval("IsDefault").ToString(), "0") %>' />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="����">
                        <ItemTemplate>
                            <a href="<%#"ShopRank_Operate.aspx?guid=" + Eval("Guid") %>" style="color: #4482b4;">
                                �༭</a>
                            <asp:HiddenField ID="HiddenFieldIsDefault" runat="server" Value='<%# Eval("IsDefault") %>' />
                            <asp:LinkButton ID="LinkDelte" runat="server" Style="color: #4482b4;" CommandArgument='<%# Eval("Guid") %>'
                                OnClick="ButtonDeleteBylink_Click" OnClientClick=" return window.confirm('��ȷ��Ҫɾ����?'); ">ɾ��</asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="15%" />
                    </asp:TemplateField>
                </Columns>
            </ShopNum1:Num1GridView>
        </div>
        <asp:ObjectDataSource ID="ObjectDataSourceDate" runat="server" SelectMethod="Search"
            TypeName="ShopNum1.ShopBusinessLogic.Shop_Rank_Action">
            <SelectParameters>
                <asp:Parameter DefaultValue="0" Name="isDeleted" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </div>
    <asp:HiddenField ID="CheckGuid" runat="server" Value="0" />
    </form>
</body>
</html>
