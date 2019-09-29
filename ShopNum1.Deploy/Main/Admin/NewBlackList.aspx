<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewBlackList.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.NewBlackList" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ShopNum1" %>
<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="ShopNum1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>黑名单</title>
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
                    <h3>黑名单</h3>
                </div>
                <div class="rr">
                </div>
            </div>
            <div class="welcon clearfix">
                <div class="order_edit">
                    <table border="0" cellpadding="0" cellspacing="0">
                        <tr style="height: 35px; vertical-align: top;">

                            <td>
                                <asp:TextBox ID="TextBox1" runat="server" ToolTipText="请输入查询id或添加id或删除id"></asp:TextBox>
                                <asp:Button ID="ButtonSearch" runat="server" Text="查询" OnClick="ButtonSearch_Click"
                                    CssClass="dele" />
                                <asp:Button ID="ADDBTN" runat="server" Text="添加" OnClick="ADDBTN_Click"
                                    CssClass="dele" />
                                <asp:Button ID="DELBTN" runat="server" Text="删除" OnClick="DELBTN_Click"
                                    CssClass="dele" />
                            </td>
                        </tr>

                    </table>

                </div>
                <ShopNum1:Num1GridView ID="Num1GridViewShow" runat="server" AutoGenerateColumns="False"
                    AllowPaging="True" AllowSorting="True" ascendingimageurl="~/images/SortAsc.gif"
                    descendingimageurl="~/images/SortDesc.gif" AddSequenceColumn="False" Width="98%"
                    Del="False" DeletePromptText="确实要删除指定的记录吗？" Edit="False" FixHeader="False" GridViewSortDirection="Ascending"
                    PagingStyle="Default" TableName="" AllowMultiColumnSorting="False"
                    BackColor="White" BorderColor="#DEDFDE" BorderStyle="None"
                    BorderWidth="0px" CellPadding="4"
                    GridLines="Vertical" EnableModelValidation="True">
                    <FooterStyle BackColor="#CCCC99" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="list_header" ForeColor="White"></HeaderStyle>
                    <%--分页--%>
                    <PagerStyle CssClass="lmf_page" BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                    <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField HeaderText="ID" DataField="BID" ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField HeaderText="会员编号" DataField="BLID" ItemStyle-HorizontalAlign="Center" />


                        <%--   <asp:TemplateField HeaderText="所属类别">
                                <ItemTemplate>
                                    <asp:Localize ID="Localize3" runat="server" Text='<%# Eval("CategoryName").ToString() %>'></asp:Localize>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="附件描述" DataField="Description"  ItemStyle-HorizontalAlign="Center" />--%>
                    </Columns>

                </ShopNum1:Num1GridView>

            </div>

            <%--分页--%>
            <asp:HiddenField ID="CheckGuid" runat="server" Value="0" />
        </div>
    </form>
</body>
</html>
