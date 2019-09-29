<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="ZtcGoods_List.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.ZtcGoods_List" %>

<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="ShopNum1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>��ƽ̨-ֱͨ����Ʒ�б�</title>
    <link rel='stylesheet' type='text/css' href='style/css.css' />
    <link id="sizestylesheet" rel='stylesheet' type='text/css' href='style/css1.css' />
    <script type="text/javascript" language="javascript" src="js/CommonJS.js"> </script>
    <script type='text/javascript' src='js/resolution-test.js'> </script>
</head>
<body class="widthah">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div style="left: -1000px; position: absolute; top: 377px; visibility: hidden;" id="dhtmltooltip">
        <img src="" height="200" width="200px">
    </div>
    <div id="right">
        <div class="rhigth">
            <div class="rl">
            </div>
            <div class="rcon">
                <h3>
                    ֱͨ����Ʒ�б�</h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="order_edit">
                <table cellpadding="0" cellspacing="0" border="0">
                    <tr style="height: 35px; vertical-align: top;">
                        <td>
                            <asp:Localize ID="LocalizeName" runat="server" Text=" ֱͨ�����ƣ�"></asp:Localize>
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxName" runat="server" CssClass="tinput" Width="200"></asp:TextBox>
                        </td>
                        <td class="lmf_padding">
                            <asp:Localize ID="LocalizeShopName" runat="server" Text="�������ƣ�"></asp:Localize>
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxShopName" runat="server" CssClass="tinput" Width="200"></asp:TextBox>
                        </td>
                        <td class="lmf_padding">
                            <asp:Localize ID="LocalizeState" runat="server" Text="״̬��"></asp:Localize>
                        </td>
                        <td>
                            <asp:DropDownList ID="DropDownListState" runat="server" CssClass="tselect" Style="margin-right: 0;
                                width: 100px;">
                                <asp:ListItem Value="-1">-��ѡ��-</asp:ListItem>
                                <asp:ListItem Value="0">�ر�</asp:ListItem>
                                <asp:ListItem Value="1">����</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:Button ID="ButtonSearch" runat="server" Text="����" CssClass="dele" OnClick="ButtonSearch_Click" />
                        </td>
                    </tr>
                </table>
                <div class="sbtn">
                    <table cellpadding="0" cellspacing="0" border="0">
                        <tr>
                            <td>
                                <asp:LinkButton ID="ButtonOpen" runat="server" CssClass="qiyong lmf_btn" OnClick="ButtonOpen_Click"
                                    OnClientClick=" return EditButton() "><span>����</span></asp:LinkButton>
                            </td>
                            <td valign="top" class="lmf_app">
                                <asp:LinkButton ID="ButtonClose" runat="server" CssClass="jnyong lmf_btn" OnClick="ButtonClose_Click"
                                    OnClientClick=" return EditButton() "><span>�ر�</span></asp:LinkButton>
                            </td>
                            <td valign="top" class="lmf_app">
                                <asp:LinkButton ID="ButtonDelete" runat="server" CssClass="shanchu lmf_btn" OnClick="ButtonDelete_Click"
                                    OnClientClick=" return DeleteButton() "><span>����ɾ��</span></asp:LinkButton>
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
                            <input id="checkboxAll" onclick=" javascript:SelectAllCheckboxes(this); " type="checkbox" />
                        </HeaderTemplate>
                        <HeaderStyle CssClass="select_width" />
                        <ItemTemplate>
                            <input id="checkboxItem" value='<%# Eval("ID") %>' type="checkbox" />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="ֱͨ������" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <a target="_blank" href='<%#ShopUrlOperate.shopHref(Eval("ProductGuid").ToString(), Eval("MemberID").ToString()) %>'
                                class="tjimga">
                                <%# Eval("ZtcName").ToString().Length > 16 ? Eval("ZtcName").ToString().Substring(0, 16) : Eval("ZtcName").ToString() %>
                            </a>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="ͼƬ" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <img src='<%# Page.ResolveUrl(Eval("ZtcImg").ToString()) %> ' onmouseover=" javascript:ddrivetip('<img width=200px height=200 src=<%# Page.ResolveUrl(Eval("ZtcImg").ToString()) %> >', '#ffffff'); "
                                onmouseout=" hideddrivetip() " height="20" width="20" />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="��Ʒ�۸�" SortExpression="ProductPrice">
                        <ItemTemplate>
                            <%# Eval("ProductPrice") %>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="SellPrice" HeaderText="���ۼ۸�" SortExpression="SellPrice"
                        ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField HeaderText="��������" DataField="SellCount" SortExpression="SellCount"
                        ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="Ztc_Money" HeaderText="��ң�BV�����" SortExpression="Ztc_Money"
                        ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="StartTime" HeaderText="��ʼʱ��" SortExpression="StartTime"
                        ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="ShopName" HeaderText="��������" SortExpression="ShopName"
                        ItemStyle-HorizontalAlign="Center" />
                    <asp:TemplateField HeaderText="״̬">
                        <ItemTemplate>
                            <%#Eval("State").ToString() == "1" ? "<font color=green>����</font>" : "<font color=red>�ر�</font>" %>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="����">
                        <ItemTemplate>
                            <a href="<%# "ZtcGoodsDetal.aspx?ID=" + Eval("ID") + "&type=1" %>" style="color: #4482b4;">
                                �鿴</a>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                </Columns>
            </ShopNum1:Num1GridView>
        </div>
        <asp:ObjectDataSource ID="ObjectDataSourceDate" runat="server" SelectMethod="Search"
            TypeName="ShopNum1.BusinessLogic.ShopNum1_ZtcGoods_Action">
            <SelectParameters>
                <asp:ControlParameter ControlID="TextBoxName" Name="ZtcName" PropertyName="Text"
                    Type="String" />
                <asp:ControlParameter ControlID="TextBoxShopName" Name="ShopName" PropertyName="Text"
                    Type="String" />
                <asp:ControlParameter ControlID="DropDownListState" Name="State" PropertyName="SelectedValue"
                    Type="Int32" />
                <asp:Parameter DefaultValue="0" Name="IsDeleted" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:HiddenField ID="CheckGuid" runat="server" Value="0" />
    </div>
    </form>
    <script type="text/javascript" src="js/showimg.js"> </script>
</body>
</html>
