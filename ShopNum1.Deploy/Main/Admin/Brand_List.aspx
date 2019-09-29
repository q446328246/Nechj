<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="Brand_List.aspx.cs" Inherits="ShopNum1.Deploy.Main.Admin.Brand_List" %>

<%@ Import Namespace="ShopNum1.Common" %>
<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="ShopNum1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>商品品牌</title>
    <link rel='stylesheet' type='text/css' href='style/css.css' />
    <link id="sizestylesheet" rel='stylesheet' type='text/css' href='style/css1.css' />
    <script src="js/jquery.js" type="text/javascript"> </script>
    <script type="text/javascript" language="javascript" src="js/CommonJS.js"> </script>
    <script type='text/javascript' src='js/resolution-test.js'> </script>
</head>
<body class="widthah">
    <form id="form1" runat="server">
    <div style="left: -1000px; position: absolute; top: 377px; visibility: hidden;" id="dhtmltooltip">
        <img src="" height="200" width="200px">
    </div>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div id="right">
        <div class="rhigth">
            <div class="rl">
            </div>
            <div class="rcon">
                <h3>
                    商品品牌</h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="order_edit">
                <table border="0" cellpadding="0" cellspacing="0">
                    <tr style="height: 35px; vertical-align: top;">
                        <td>
                            <asp:Label ID="LabelName" runat="server" Text="品牌名称：" Font-Bold="False"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxName" runat="server" CssClass="tinput" Width="100"></asp:TextBox>
                        </td>
                        <td align="right" class="lmf_padding">
                            <asp:Label ID="Label4" runat="server" Text="品牌类别：" Font-Bold="False"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="TxtCategoryName" runat="server" CssClass="tinput" Width="100"></asp:TextBox>
                        </td>
                        <td class="lmf_padding">
                            <asp:Label ID="Label2" runat="server" Text="是否在前台显示：" Font-Bold="False"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="DropDownListIsShow" runat="server" CssClass="tselect" Style="width: 100px;">
                                <asp:ListItem Value="-2" Selected="True">-全部-</asp:ListItem>
                                <asp:ListItem Value="1">是</asp:ListItem>
                                <asp:ListItem Value="0">否</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label1" runat="server" Text="品牌网址：" Font-Bold="False"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="TxtBrandLink" runat="server" CssClass="tinput" Width="100"></asp:TextBox>
                        </td>
                        <td class="lmf_padding">
                            <asp:Label ID="Label3" runat="server" Text="是否推荐：" Font-Bold="False"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="DropDownListIsRecommond" runat="server" CssClass="tselect"
                                Style="width: 100px;">
                                <asp:ListItem Value="-2" Selected="True">-全部-</asp:ListItem>
                                <asp:ListItem Value="1">是</asp:ListItem>
                                <asp:ListItem Value="0">否</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:Button ID="ButtonSearch" runat="server" OnClick="ButtonSearch_Click" Text="查询"
                                CssClass="dele" />
                        </td>
                    </tr>
                </table>
                <div class="sbtn">
                    <table cellpadding="0" cellspacing="0" border="0">
                        <tr>
                            <td valign="top">
                                <asp:LinkButton ID="ButtonAdd" runat="server" OnClick="ButtonAdd_Click" OnClientClick=" GetCheckedBoxValues() "
                                    CssClass="tianjia2 lmf_btn"><span>添加</span></asp:LinkButton>
                            </td>
                            <td valign="top" class="lmf_app" style="display: none;">
                                <asp:LinkButton ID="ButtonEdit" runat="server" OnClick="ButtonEdit_Click" OnClientClick=" return EditButton() "
                                    CssClass="fanh" Visible="false"><span>编辑</span></asp:LinkButton>
                            </td>
                            <td valign="top" class="lmf_app">
                                <asp:LinkButton ID="ButtonDelete" runat="server" OnClientClick=" return DeleteButton() "
                                    OnClick="ButtonDelete_Click" CssClass="shanchu lmf_btn"><span>批量删除</span></asp:LinkButton>
                            </td>
                            <td valign="top" class="lmf_app">
                                <ShopNum1:MessageShow ID="MessageShow" runat="server" Visible="False" />
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <ShopNum1:Num1GridView ID="Num1GridviewShow" runat="server" AutoGenerateColumns="False"
                AllowPaging="True" AllowSorting="True" ascendingimageurl="~/images/SortAsc.gif"
                descendingimageurl="~/images/SortDesc.gif" AddSequenceColumn="False" Width="98%"
                Del="False" DeletePromptText="确实要删除指定的记录吗？" Edit="False" FixHeader="False" GridViewSortDirection="Ascending"
                PagingStyle="None" TableName="" DataSourceID="ObjectDataSourceData" AllowMultiColumnSorting="False"
                BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="0" CellPadding="4"
                GridLines="Vertical">
                <FooterStyle BackColor="#CCCC99" />
                <HeaderStyle HorizontalAlign="Center" CssClass="list_header" ForeColor="White"></HeaderStyle>
                <%--分页--%>
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
                            <input id="checkboxItem" type="checkbox" value='<%# Eval("Guid") %>' align="middle" />
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="Guid" HeaderText="Guid" Visible="False" SortExpression="Guid" />
                    <asp:TemplateField HeaderText="品牌图片" SortExpression="logo">
                        <ItemTemplate>
                            <img src='<%# Page.ResolveUrl("" + Eval("Logo")) %> ' onmouseover=" javascript:ddrivetip('<img width=200px height=200 src=<%# Page.ResolveUrl(Eval("Logo").ToString()) %> >', '#ffffff'); "
                                onmouseout=" hideddrivetip() " height="20" width="20" />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="Name" HeaderText="品牌名称" SortExpression="Name">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="CategoryName" HeaderText="品牌类别" SortExpression="CategoryName">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="WebSite" HeaderText="品牌网址" SortExpression="WebSite" ItemStyle-HorizontalAlign="Center">
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="是否前台显示" SortExpression="IsShow">
                        <ItemTemplate>
                            <asp:Image ID="Image1" runat="server" src='<%# PageOperator.GetListImageStatus(Eval("Isshow").ToString() == "1" ? "0" : "1") %>' />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="是否推荐" SortExpression="IsCommend">
                        <ItemTemplate>
                            <asp:Image ID="Image2" runat="server" src='<%# PageOperator.GetListImageStatus(Eval("IsCommend").ToString() == "1" ? "0" : "1") %>' />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="OrderID" HeaderText="排序号" SortExpression="OrderID">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="操作">
                        <ItemTemplate>
                            <a href="<%# "Brand_Operate.aspx?guid=" + "'" + Eval("Guid") + "'" %>" style="color: #4482b4;">
                                编辑</a>
                            <asp:LinkButton ID="LinkDelte" runat="server" Style="color: #4482b4;" CommandArgument='<%# Eval("Guid") %>'
                                OnClientClick=" return window.confirm('您确定要删除吗?'); " OnClick="ButtonDeleteBylink_Click">删除</asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                </Columns>
            </ShopNum1:Num1GridView>
        </div>
    </div>
    <asp:ObjectDataSource ID="ObjectDataSourceData" runat="server" SelectMethod="SearchF0"
        TypeName="ShopNum1.BusinessLogic.ShopNum1_Brand_Action">
        <SelectParameters>
            <asp:ControlParameter ControlID="TextBoxName" Name="name" PropertyName="Text" Type="String" />
            <asp:ControlParameter ControlID="TxtBrandLink" Name="link" PropertyName="Text" Type="String" />
            <asp:Parameter DefaultValue="0" Name="isDeleted" Type="Int32" />
            <asp:ControlParameter ControlID="DropDownListIsShow" Name="IsShow" PropertyName="SelectedValue"
                Type="String" />
            <asp:ControlParameter ControlID="DropDownListIsRecommond" Name="IsRecommond" PropertyName="SelectedValue"
                Type="String" />
            <asp:ControlParameter ControlID="TxtCategoryName" Name="CategoryName" PropertyName="Text"
                Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:HiddenField ID="CheckGuid" runat="server" Value="0" />
    <asp:HiddenField ID="HiddenFieldCode" runat="server" Value="-1" />
    </form>
    <script type="text/javascript" src="js/showimg.js"> </script>
</body>
</html>
