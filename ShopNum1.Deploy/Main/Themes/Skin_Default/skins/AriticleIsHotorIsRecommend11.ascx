<%@ Control Language="C#" %>
<%@ Import Namespace="System.Data" %>
<span id="AriticleIsHotorIsRecommend4">
    <div class="newhot_border" id="article_categroy">
        <div class="newhot_title">
            <div class="title fl">
                <span id="AriticleIsHotorIsRecommend4_ctl00_Labeltitle">
                    <asp:Label ID="Labeltitle" runat="server" Text="女装热点资讯"></asp:Label>
                </span>
            </div>
            <div class="more fr" style="display: none;">
                <a href='<%= ShopUrlOperate.RetUrl("ArticleListSearch") %>'>
                    <asp:Image ID="Image2" runat="server" ImageUrl="../images/ArticleList_more.png" BorderWidth="0px"
                        Visible="false" />
                </a>
            </div>
        </div>
        <div class="newhot_ad">
            <ShopNum1:AdSimpleImage ID="AdSimpleImage" runat="server" AdImgId="37" SkinFilename="AdSimpleImage.ascx" />
        </div>
        <div class="newhot_content">
            <asp:Repeater ID="RepeaterCategory" runat="server">
                <ItemTemplate>
                    <div class="newhot_title_list">
                        <a href='<%# ShopUrlOperate.RetUrl("ArticleDetail",((DataRowView)Container.DataItem).Row["guid"],"guid") %>'
                            target="_self" title='<%# ((DataRowView)Container.DataItem).Row["Title"]%>'>·<%# ((DataRowView)Container.DataItem).Row["Title"]%></a>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</span>