<%@ Control Language="C#" %>
<%@ Import Namespace="ShopNum1.Common" %>
<%@ Import Namespace="ShopNum1.WebControl" %>
<%@ Import Namespace="System.Data" %>
<div class="help_search">
    <table border="0" cellpadding="0" cellspacing="0" class="help_tab">
        <tbody>
            <tr>
                <td>
                    <span class="zhao">找帮助</span>
                </td>
                <td>
                    <asp:TextBox ID="TextBoxSearch" runat="server" CssClass="help_input"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="ButtonAgainSearch" runat="server" Text="" CssClass="helpbtn" OnClientClick=" return CheckIsEmpty()" />
                </td>
                <td align="right">
                    <img src="Themes/Skin_Default/Images/help_phone.jpg" />
                </td>
            </tr>
        </tbody>
    </table>
</div>
<div class="help_con">
    <p class="serhjieg">
        共为您找到了 <b>
            <asp:Label ID="LabelNum" runat="server" Text=""></asp:Label></b> 条关于<i>“<asp:Label
                ID="LabelName" runat="server" Text=""></asp:Label>”</i> 的信息！
    </p>
    <div class="foncont">
        <ul>
            <asp:Repeater ID="RepeaterData" runat="server">
                <ItemTemplate>
                    <li>
                        <p class="mallanwer">
                            <a href='<%# "HelpList.aspx?guid=" + ((DataRowView)Container.DataItem).Row["Guid"]%>'
                                target="_self">·
                                <%#ShopNum1.Common.Utils.GetUnicodeSubString(((DataRowView)Container.DataItem).Row["Title"].ToString(),32,"") %>
                            </a>
                        </p>
                        <div class="findateil">
                            <%#ShopNum1.Common.Utils.GetUnicodeSubString(Server.HtmlDecode(((DataRowView)Container.DataItem).Row["Remark"].ToString()), 32, "")%>
                        </div>
                    </li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>
    </div>
    <!--分页 Start-->
    <div class="fenye">
        <!--分页跳转 Start-->
        <div class="page_skip">
            <table cellpadding="0" cellspacing="0" border="0">
                <tr>
                    <td>
                        <span class="fenye1">共</span>
                    </td>
                    <td>
                        <span>
                            <asp:Label ID="LabelPageCount" runat="server" Text=""></asp:Label></span>
                    </td>
                    <td>
                        <span class="fenye2">页，到第</span>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBoxIndex" runat="server" CssClass="page_input">
                        </asp:TextBox>
                    </td>
                    <td>
                        <span class="fenye3">页</span>
                    </td>
                    <td>
                        <asp:Button ID="ButtonSure" runat="server" Text="Button" CssClass="page_btn" />
                    </td>
                </tr>
            </table>
        </div>
        <!--//分页跳转 End-->
        <!--分页排序 Start-->
        <div id="pageDiv" runat="server" class="page_sort">
            <span class="disabled">< </span><span class="current">1</span> <a href="#?page=2">2</a>
            <span class="diandian">...</span> <a href="#?page=200">200</a> <a href="#?page=2">></a>
        </div>
        <!--//分页排序 End-->
        <div class="clear">
        </div>
    </div>
    <!--//分页 End-->
</div>
