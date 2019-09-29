<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="User_List.aspx.cs" Inherits="ShopNum1.Deploy.Main.Admin.User_List" %>

<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link rel='stylesheet' type='text/css' href='style/css.css' />
    <link id="sizestylesheet" rel='stylesheet' type='text/css' href='style/css1.css' />
    <script type="text/javascript" language="javascript" src="js/CommonJS.js"> </script>
    <script src="js/tanchuDIV2.js" type="text/javascript"> </script>
    <script type='text/javascript' src='js/resolution-test.js'> </script>
    <script src="js/dragbox/Shopnum1.Dialog.min.js" type="text/javascript"> </script>
    <link rel="stylesheet" type="text/css" href="js/dragbox/Shopnum1.DragBox.min.css" />
    <style type="text/css">
        
    </style>
</head>
<body class="widthah" style="height: 600px;">
    <form id="form1" runat="server">
    <div id="right">
        <div class="rhigth">
            <div class="rl">
            </div>
            <div class="rcon">
                <h3>
                    用户管理</h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="order_edit">
                <div>
                    <table cellpadding="0" cellspacing="0" border="0">
                        <tr style="height: 35px; vertical-align: top;">
                            <td>
                                用户名：
                            </td>
                            <td>
                                <asp:TextBox ID="TextBoxSRealName" CssClass="tinput" runat="server" Width="200"></asp:TextBox>
                            </td>
                            <td class="lmf_padding" style="display: none">
                                部门：
                            </td>
                            <td style="display: none">
                                <asp:DropDownList ID="DropDownListSDept" runat="server" AutoPostBack="True" Width="201px"
                                    CssClass="tselect">
                                    <asp:ListItem Value="-1">全部</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td class="lmf_padding">
                                <asp:Label ID="LabelSIsForbid" runat="server" Text="状态："></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="DropdownListSIsForbid" runat="server" AutoPostBack="True" Width="201px"
                                    CssClass="tselect">
                                    <asp:ListItem Value="-1" Selected="True">全部</asp:ListItem>
                                    <asp:ListItem Value="1">已禁用</asp:ListItem>
                                    <asp:ListItem Value="0">未禁用</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:Button ID="ButtonSearch" runat="server" CausesValidation="False" Text="查询" OnClick="ButtonSearch_Click"
                                    CssClass="dele" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="sbtn">
                    <table cellpadding="0" cellspacing="0" border="0">
                        <tr>
                            <td valign="top">
                                <a href="adduser.aspx?width=700&height=450" class="tianjia2 lmf_btn dialog"><span>添加</span></a>
                            </td>
                            <td valign="top" class="lmf_app">
                                <asp:LinkButton ID="ButtonDelete" runat="server" CausesValidation="False" OnClientClick=" return DeleteButton() "
                                    OnClick="ButtonDelete_Click" CssClass="shanchu lmf_btn">
                                            <span>批量删除</span></asp:LinkButton>
                            </td>
                            <td>
                                <uc1:MessageShow ID="MessageShow" runat="server" Visible="False" />
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <div>
                <ShopNum1:Num1GridView ID="Num1GridViewShow" runat="server" AutoGenerateColumns="False"
                    AllowPaging="True" AllowSorting="True" ascendingimageurl="~/images/SortAsc.gif"
                    descendingimageurl="~/images/SortDesc.gif" AddSequenceColumn="False" Width="98%"
                    Del="False" DeletePromptText="确实要删除指定的记录吗？" Edit="False" FixHeader="False" GridViewSortDirection="Ascending"
                    PagingStyle="None" TableName="" DataSourceID="ObjectDataSourceData" AllowMultiColumnSorting="False"
                    BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="0px"
                    CellPadding="4" GridLines="Vertical">
                    <FooterStyle BackColor="#CCCC99" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="list_header" ForeColor="White"></HeaderStyle>
                    <%--分页--%>
                    <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                    <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <%--<asp:BoundField DataField="RealName" HeaderText="姓名" SortExpression="RealName">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="DeptName" HeaderText="部门" SortExpression="DeptName">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Age" HeaderText="年龄" SortExpression="age">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="性别" SortExpression="sex">
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# ChangeAge(DataBinder.Eval(Container, "DataItem(sex)","{0}")) %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="WorkNumber" HeaderText="工号" SortExpression="WorkNumber">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Telephone" HeaderText="电话" SortExpression="Telephone">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>--%>
                        <asp:TemplateField ControlStyle-Width="35">
                            <HeaderTemplate>
                                <input id="checkboxAll" onclick=" javascript:SelectAllCheckboxes(this); " type="checkbox" />
                            </HeaderTemplate>
                            <ItemTemplate>
                                <input id="checkboxItem" value='<%# Eval("Guid") %>|<%# Eval("LoginID") %>' type="checkbox" />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="Guid" HeaderText="Guid" Visible="False" />
                        <asp:BoundField DataField="LoginID" HeaderText="用户名" SortExpression="LoginID">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="LoginTimes" HeaderText="登录次数" SortExpression="LoginTimes">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="上次登录时间">
                            <ItemTemplate>
                                <%#FormatDate(Eval("LastLoginTime").ToString()) %>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="上次修改密码时间">
                            <ItemTemplate>
                                <%#FormatDate(Eval("LastModifyPasswordTime").ToString()) %>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="状态" SortExpression="IsForbid">
                            <ItemTemplate>
                                <%-- <asp:Label ID="Label1" runat="server" Text='<%# ChangeIsForbid(DataBinder.Eval(Container, "DataItem(IsForbid)","{0}")) %>'></asp:Label>--%>
                                <asp:Image ID="Image1" runat="server" src='<%# ChangeIsForbid(DataBinder.Eval(Container, "DataItem(IsForbid)", "{0}")) %>' />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="操作">
                            <ItemTemplate>
                                <a href='adduser.aspx?width=700&height=450&id=<%# Eval("Guid") %>' style="color: #4482b4;"
                                    class="dialog">编辑</a>
                                <asp:LinkButton ID="LinkDelte" runat="server" Style="color: #4482b4;" CommandArgument='<%# Eval("Guid") + "|" + Eval("LoginID") %>'
                                    CausesValidation="false" OnClientClick=" return window.confirm('您确定要删除吗?'); "
                                    OnClick="ButtonDeleteBylink_Click">删除</asp:LinkButton>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                    </Columns>
                </ShopNum1:Num1GridView>
            </div>
        </div>
        <asp:ObjectDataSource ID="ObjectDataSourceData" runat="server" SelectMethod="Search"
            TypeName="ShopNum1.BusinessLogic.ShopNum1_User_Action">
            <SelectParameters>
                <asp:ControlParameter ControlID="TextBoxSRealName" Name="realName" PropertyName="Text"
                    Type="String" />
                <asp:ControlParameter ControlID="DropDownListSDept" DefaultValue="" Name="deptGuid"
                    PropertyName="SelectedValue" Type="String" />
                <asp:ControlParameter ControlID="DropdownListSIsForbid" Name="isForbid" PropertyName="SelectedValue"
                    Type="Int32" />
                <asp:Parameter Name="IsDeleted" Type="Int32" DefaultValue="0" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </div>
    <asp:HiddenField ID="CheckGuid" runat="server" Value="0" />
    <asp:HiddenField ID="hiddenGuid" runat="server" Value="0" />
    </form>
</body>
</html>
