<%@ Control Language="C#" %>
<%@ Import Namespace="System.Data" %>
<div class="store_category_view">
    <h3>
        <span>最新资讯<asp:Literal ID="LiteralTitle" runat="server" Visible='false'></asp:Literal></span></h3>
    <div class="news_conts">
        <ul>
            <asp:Repeater ID="DataListAriticleNew" runat="server">
                <ItemTemplate>
                    <li><a href='<%# ShopUrlOperate.RetUrl("ArticleDetail",((DataRowView)Container.DataItem).Row["guid"]) %>'
                        target="_blank" title='<%#((DataRowView)Container.DataItem).Row["Title"] %>'>
                        <%# ShopNum1.Common.Utils.GetUnicodeSubString(((DataRowView)Container.DataItem).Row["Title"].ToString(),32,"")%></a>
                    </li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>
    </div>
</div>
