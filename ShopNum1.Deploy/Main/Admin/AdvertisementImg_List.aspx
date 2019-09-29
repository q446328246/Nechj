<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdvertisementImg_List.aspx.cs" Inherits="ShopNum1.Deploy.Main.Admin.AdvertisementImg_List" %>

<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="ShopNum1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
    <head id="Head1" runat="server">
        <%= HeaderInfo("图片广告列表") %>
        <link rel="stylesheet" type="text/css" href="style/css.css" />
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
                            广告图片列表</h3>
                    </div>
                    <div class="rr">
                    </div>
                </div>
                <div class="welcon clearfix">
                    <div class="order_edit">
                        <table cellpadding="0" cellspacing="0" border="0">
                            <tr style="height: 35px; vertical-align: top;">
                                <td>
                                    页面名称：
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBoxPageName" runat="server" CssClass="tinput"></asp:TextBox>
                                </td>
                                <td class="lmf_padding" style="display: none">
                                    文件名：
                                </td>
                                <td style="display: none">
                                    <asp:DropDownList ID="DropDownListFileName" runat="server" CssClass="tselect">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:Button ID="ButtonSearch" runat="server" Text="查询" CssClass="dele" />
                                </td>
                            </tr>
                        </table>
                        <asp:ObjectDataSource ID="ObjectDataSourceXml" runat="server" SelectMethod="GetXmlDataTable1"
                                              TypeName="ShopNum1.AdXml.DefaultAdvertismentOperate">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="TextBoxPageName" Name="pagename" PropertyName="Text"
                                                      Type="String" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                        <table cellpadding="0" cellspacing="0" border="0">
                            <tr>
                                <td valign="top">
                                    <asp:LinkButton ID="ButtonAdd" runat="server" OnClick="ButtonAdd_Click" CausesValidation="False"
                                                    class="tianjia2 lmf_btn" Visible="false"><span>添加</span></asp:LinkButton>
                                    <asp:Button ID="ButtonEdit" runat="server" CausesValidation="False" Text="编辑" Visible="false"
                                                OnClientClick=" return EditButton() " OnClick="ButtonEdit_Click" CssClass="fanh" />
                                </td>
                                <td valign="top" class="lmf_app">
                                    <asp:LinkButton ID="ButtonDelete" runat="server" OnClick="ButtonDelete_Click" OnClientClick=" return DeleteButton() "
                                                    CausesValidation="False" class="shanchu lmf_btn" Visible="false"><span>批量删除</span></asp:LinkButton>
                                </td>
                            </tr>
                        </table>
                        <ShopNum1:MessageShow ID="MessageShow" runat="server" Visible="False" />
                    </div>
                    <ShopNum1:Num1GridView ID="Num1GridViewShow" runat="server" AutoGenerateColumns="False"
                                           AllowPaging="True" AllowSorting="True" ascendingimageurl="~/images/SortAsc.gif"
                                           descendingimageurl="~/images/SortDesc.gif" AddSequenceColumn="False" Width="98%"
                                           Del="False" DeletePromptText="确实要删除指定的记录吗？" Edit="False" FixHeader="False" GridViewSortDirection="Ascending"
                                           PagingStyle="None" TableName="" DataSourceID="ObjectDataSourceXml" AllowMultiColumnSorting="False"
                                           BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="0" CellPadding="4"
                                           GridLines="Vertical">
                        <footerstyle backcolor="#CCCC99" />
                        <headerstyle horizontalalign="Center" cssclass="list_header" forecolor="White"></headerstyle>
                        <%--分页--%>
                        <pagerstyle cssclass="lmf_page" backcolor="#F7F7DE" forecolor="Black" horizontalalign="Right" />
                        <selectedrowstyle backcolor="#CE5D5A" font-bold="True" forecolor="White" />
                        <alternatingrowstyle backcolor="White" />
                        <columns>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <input id="checkboxAll" onclick=" javascript: SelectAllCheckboxes(this); " type="checkbox" />
                                </HeaderTemplate>
                                <HeaderStyle CssClass="select_width" />
                                <ItemTemplate>
                                    <input id="checkboxItem" type="checkbox" value='<%# Eval("id") %>' />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="id" HeaderText="广告ID" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="pagename" HeaderText="页面名称" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="title" HeaderText="广告位名称" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="href" HeaderText="链接地址" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="width" HeaderText="宽度" ItemStyle-HorizontalAlign="Center" Visible="false" />
                            <asp:BoundField DataField="height" HeaderText="高度" ItemStyle-HorizontalAlign="Center" Visible="false"  />
                            <asp:TemplateField HeaderText="图片">
                                <ItemTemplate>
                                    <img src='<%# Page.ResolveUrl(Eval("imgsrc").ToString()) %>' onmouseover=" javascript:ddrivetip('<img width=200px height=200 src=<%# Eval("imgsrc") %> >', '#ffffff'); "
                                         onmouseout=" hideddrivetip() " height="20" width="20" />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="操作">
                                <ItemTemplate>
                                    <a href="<%# "AdvertisementImg_Operate.aspx?guid=" + Eval("id") %>" style="color: #4482b4;">
                                        编辑</a>
                                    <asp:LinkButton ID="LinkDelte" runat="server" Style="color: #4482b4;" OnClick="ButtonDeleteBylink_Click"
                                                    CommandArgument='<%# Eval("id") %>' OnClientClick=" return window.confirm('您确定要删除吗?'); " Visible="false">删除</asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                        </columns>
                    </ShopNum1:Num1GridView>
                </div>
                <asp:HiddenField ID="CheckGuid" runat="server" Value="0" />
            </div>
        </form>
        <script type="text/javascript" src="js/showimg.js"> </script>
    </body>
</html>