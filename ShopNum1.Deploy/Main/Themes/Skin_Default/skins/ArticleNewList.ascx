<%@ Control Language="C#" %>
<%@ Import Namespace="System.Data" %>
<div class="news_article" style="display: none;">
    <h3>
        <asp:Literal ID="LiteralTitle" runat="server" Visible="false"></asp:Literal></h3>
</div>
<asp:Repeater ID="DataListAriticleNew" runat="server">
    <ItemTemplate>
        <dl>
            <dd>
                <a href='<%# ShopUrlOperate.RetUrl("ArticleDetail",((DataRowView)Container.DataItem).Row["guid"]) %>'
                    target="_blank" title='<%#((DataRowView)Container.DataItem).Row["Title"] %>'>
                    <%# ShopNum1.Common.Utils.GetUnicodeSubString(((DataRowView)Container.DataItem).Row["Title"].ToString(),32,"")%></a></li>
            </dd>
        </dl>
    </ItemTemplate>
</asp:Repeater>
