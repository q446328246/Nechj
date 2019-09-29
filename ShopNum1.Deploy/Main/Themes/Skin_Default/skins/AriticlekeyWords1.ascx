<%@ Control Language="C#" %>
<span id="AriticlekeyWords1">
    <div class="new_titlebj1" id="article_categroy">
        <div class="new_title fl">
            <span id="AriticlekeyWords1_ctl00_Labeltitle">
                <asp:Label ID="Labeltitle" runat="server" Text="女装资讯"></asp:Label>
            </span>
        </div>
        <div class="new_class fl">
            <asp:Repeater ID="RepeaterShow" runat="server">
                <ItemTemplate>
                    <a href='<%# ShopUrlOperate.RetUrl("ArticleListSearch",Eval("ID"),"ID") %>' target="_self">
                        <%# Eval("Name")%></a> |
                </ItemTemplate>
            </asp:Repeater>
        </div>
        <div class="new_more fr">
            <a href='<%= ShopUrlOperate.RetUrl("ArticleListSearch") %>' target="_self">
                <asp:Image ID="Image1" runat="server" ImageUrl="../images/bnt_more_1.png" BorderWidth="0px" /></a>
        </div>
    </div>
</span>