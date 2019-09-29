<%@ Control Language="C#" %>
<%@ Import Namespace="ShopNum1.WebControl" %>
<%@ Import Namespace="System.Data" %>
<div class="SearchResultBox">
    <div class="art_conts">
        <ul>
            <asp:Repeater ID="RepeaterData" runat="server">
                <ItemTemplate>
                    <li>
                        <div class="art_lists">
                            <div class="art_imgs">
                                <span>
                                    <%# ((DataRowView)Container.DataItem).Row["ClickCount"]%></span></div>
                            <div class="art_content">
                                <h5>
                                    <a href="<%# ShopUrlOperate.RetUrl("ArticleDetail",((DataRowView)Container.DataItem).Row["Guid"]) %>">
                                        <%# ((DataRowView)Container.DataItem).Row["Title"]%></a>
                                </h5>
                                <a href="<%# ShopUrlOperate.RetUrl("ArticleDetail",((DataRowView)Container.DataItem).Row["Guid"]) %>">
                                    [详情]</a>
                                <p>
                                    分类：<%# ((DataRowView)Container.DataItem).Row["Name"]%>
                                    来源：<%# ((DataRowView)Container.DataItem).Row["Publisher"]%>
                                    发布时间：<%# Convert.ToDateTime(((DataRowView)Container.DataItem).Row["CreateTime"]).ToString("yyyy-MM-dd") %></p>
                            </div>
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
<asp:HiddenField ID="HiddenFieldSearchName" runat="server" />
