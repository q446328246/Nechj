<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AttachMent_List_Select.aspx.cs" Inherits="ShopNum1.Deploy.Main.Admin.AttachMent_List_Select" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
    <head id="Head1" runat="server">
        <title>附件操作</title>
        <link rel="stylesheet" type="text/css" href="style/css.css" />
        <script type="text/javascript" language="javascript" src="js/CommonJS.js"> </script>
        <base target="_self" />
        <script language="javascript" type="text/javascript">
            function ReturnValue(str) {
                window.returnValue = str.href + "," + str.innerHTML;
                window.close();
            }

        //        //设置返回到父窗口的值 
        //        function ReturnValue(str) 
        //        { 
        //            window.returnValue=str; 
        //            window.close(); 
        //        } 
    </script>
    </head>
    <body>
        <form id="form1" runat="server">
            <div id="right">
                <div class="rhigth">
                    <div class="rl">
                    </div>
                    <div class="rcon">
                        <h3>
                            附件操作</h3>
                    </div>
                    <div class="rr">
                    </div>
                </div>
                <div class="welcon clearfix">
                    <div class="order_edit">
                        <table cellpadding="0" cellspacing="0" border="0">
                            <tr style="height: 35px; vertical-align: top;">
                                <td class="lmf_tiaojian">
                                    <asp:Localize ID="LocalizeAttachMentCateGory" runat="server" Text="附件类型："></asp:Localize>
                                </td>
                                <td>
                                    <asp:DropDownList ID="DropDownListAttachMentCateGory" runat="server" CssClass="tselect">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:Button ID="ButtonSearch" CssClass="dele" runat="server" Text="查询" />
                                </td>
                            </tr>
                        </table>
                    </div>
                    <ShopNum1:Num1GridView ID="num1GridViewShow" runat="server" AutoGenerateColumns="False"
                                           AllowPaging="True" AllowSorting="True" ascendingimageurl="~/images/SortAsc.gif"
                                           descendingimageurl="~/images/SortDesc.gif" AddSequenceColumn="False" Width="98%"
                                           Del="False" DeletePromptText="确实要删除指定的记录吗？" Edit="False" FixHeader="False" GridViewSortDirection="Ascending"
                                           PagingStyle="None" TableName="" AllowMultiColumnSorting="False" BackColor="White"
                                           BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="0" CellPadding="4" GridLines="Vertical">
                        <footerstyle backcolor="#CCCC99" />
                        <headerstyle horizontalalign="Center" cssclass="list_header" forecolor="White"></headerstyle>
                        <%--分页--%>
                        <pagerstyle cssclass="lmf_page" backcolor="#F7F7DE" forecolor="Black" horizontalalign="Right" />
                        <selectedrowstyle backcolor="#CE5D5A" font-bold="True" forecolor="White" />
                        <alternatingrowstyle backcolor="White" />
                        <columns>
                            <asp:TemplateField HeaderText="附件名称">
                                <ItemTemplate>
                                    <a id="A1" href='<%# Eval("AttachmentURL") %>' runat="server" onclick="return ReturnValue(this)">
                                        <%# Eval("Title") %></a>
                                    <asp:Label ID="Label1" runat="server"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="上传时间" DataField="UploadTime" DataFormatString="{0:yyyy-MM-dd}" ItemStyle-HorizontalAlign="Center"  />
                            <asp:TemplateField HeaderText="所属类别">
                                <ItemTemplate>
                                    <asp:Localize ID="Localize3" runat="server" Text='<%# Eval("CategoryName").ToString() %>'></asp:Localize>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="附件描述" DataField="Description"  ItemStyle-HorizontalAlign="Center" />
                        </columns>
                    </ShopNum1:Num1GridView>
                </div>
                <asp:HiddenField ID="HiddenFieldOrganizeID" runat="server" />
            </div>
        </form>
    </body>
</html>