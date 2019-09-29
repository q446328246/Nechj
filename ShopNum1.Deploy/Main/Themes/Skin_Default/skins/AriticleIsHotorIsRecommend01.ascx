<%@ Control Language="C#" %>
<%@ Import Namespace="System.Data" %>
<span id="AriticleIsHotorIsRecommend3">
    <div class="mod1" id="article_categroy">
        <div class="new_recommend_titlebj">
            <span id="AriticleIsHotorIsRecommend3_ctl00_Labeltitle">
                <asp:Label ID="Labeltitle" runat="server" Text="女装技巧推荐"></asp:Label></span></div>
        <div>
            <div class="new_recommend_left fl">
                <asp:Repeater ID="RepeaterCategory" runat="server">
                    <ItemTemplate>
                        <div class="new_recommend_list">
                            <a href='<%# ShopUrlOperate.RetUrl("ArticleDetail",((DataRowView)Container.DataItem).Row["Guid"]) %>'
                                target="_self" title='<%# ((DataRowView)Container.DataItem).Row["Title"]%>'>·<%# ((DataRowView)Container.DataItem).Row["Title"]%></a>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
            <div class="new_recommend_ad fr">
                <ShopNum1:AdSimpleImage ID="AdSimpleImage" runat="server" AdImgId="38" SkinFilename="AdSimpleImage.ascx" />
            </div>
        </div>
    </div>
</span>