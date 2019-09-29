<%@ Control Language="C#" %>
<%@ Import Namespace="System.Data" %>
<span id="AriticlekeyWords2">
    <div class="new_titlebj2" id="article_categroy">
        <div class="new_title fl">
            <span id="AriticlekeyWords2_ctl00_Labeltitle">
                <asp:Label ID="Labeltitle" runat="server" Text="男装分类"></asp:Label>
            </span>
        </div>
        <div class="new_class fl">
            <asp:Repeater ID="RepeaterShow" runat="server">
                <ItemTemplate>
                    <a href='<%# ShopUrlOperate.RetUrl("ArticleListSearch",((DataRowView)Container.DataItem).Row["ID"],"ID") %>'
                        target="_self">
                        <%#((DataRowView)Container.DataItem).Row["Name"]%></a> |
                </ItemTemplate>
            </asp:Repeater>
        </div>
        <div class="new_more fr" >
            <a href='<%=ShopUrlOperate.RetUrl("ArticleListSearch")%>' target="_self">
                <asp:Image ID="Image1" runat="server" ImageUrl="../images/bnt_more_1.png" BorderWidth="0px" /></a>
        </div>
    </div>
</span>