<%@ Control Language="C#" %>
<%@ Import Namespace="System.Data" %>
<span id="AriticleIsHotorIsRecommend2">
    <div class="newhot_border" id="article_categroy">
        <div class="newhot_title">
            <div class="title fl">
                <span id="AriticleIsHotorIsRecommend2_ctl00_Labeltitle">
                    <asp:Label ID="Labeltitle" runat="server" Text="家纺热点资讯"></asp:Label></span></div>
            <div class="more fr" style="display: none;">
                <a href='<%= ShopUrlOperate.RetUrl("ArticleListSearch") %>'>
                    <asp:Image ID="Image2" runat="server" ImageUrl="../images/ArticleList_more.png" BorderWidth="0px"
                        Visible="false" />
                </a>
            </div>
        </div>
        <div class="newhot_ad">
            <ShopNum1:AdSimpleImage ID="AdSimpleImage5" runat="server" AdImgId="36" SkinFilename="AdSimpleImage.ascx" />
        </div>
        <div class="newhot_content">
            <asp:Repeater ID="RepeaterCategory" runat="server">
                <ItemTemplate>
                    <div class="newhot_title_list">
                        <a href='<%# ShopUrlOperate.RetUrl("ArticleDetail",Eval("guid"),"guid") %>' target="_self" 
                        title='<%# ((DataRowView)Container.DataItem).Row["Title"]%>'>
                            ·<%# Eval("Title")%></a>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</span>