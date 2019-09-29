<%@ Control Language="C#" %>
<%@ Import Namespace="System.Data" %>
<div class="new_info" style="clear: both; padding-top: 5px;">
    <div class="new_info_title">
        <div class="new_info_title_left new_info_title_left1 fl">
            商品公告</div>
        <div class="new_info_title_right fr">
            <a href="<%=ShopUrlOperate.RetUrl("ArticleListSearch")%>">更多>></a></div>
    </div>
    <div class="new_info_list" style="padding-top: 8px; padding-bottom: 8px;">
        <div class="new_info_list_de new_info_list_de1 fl">
            <asp:Repeater ID="RepeaterArticleList" runat="server">
                <HeaderTemplate>
                    <ul>
                </HeaderTemplate>
                <ItemTemplate>
                    <li>·<a href='<%# ShopUrlOperate.RetUrl("ArticleDetail",((DataRowView)Container.DataItem).Row["guid"]) %>'
                        target="_blank" title='<%#((DataRowView)Container.DataItem).Row["Title"] %>'>
                        <%# ShopNum1.Common.Utils.GetUnicodeSubString(((DataRowView)Container.DataItem).Row["Title"].ToString(),22,"")%></a></li>
                </ItemTemplate>
                <FooterTemplate>
                    </ul>
                </FooterTemplate>
            </asp:Repeater>
        </div>
        <div class="new_info_list_img1 fr" style="line-height: 20px; line-height: 22px\9;">
            <%--          <a href="javascript:void(0)">
                <img width="180" height="70" src="Themes/Skin_Default/Images/newsimg2.jpg" /></a><br />
            <a href="javascript:void(0)">清凉一夏，冲绳旅游攻略</a>--%>
            <ShopNum1:AdSimpleImageTitle ID="AdSimpleImageTitle" runat="server" AdImgId="1" SkinFilename="AdSimpleImageTitle.ascx" />
            <br />
            <%--<a href="javascript:void(0)"> 
                <img width="180" height="70" src="Themes/Skin_Default/Images/newsimg3.jpg" /><br />
            </a><a href="javascript:void(0)">老挝沿途绝美风景</a>--%>
            <ShopNum1:AdSimpleImageTitle ID="AdSimpleImageTitle1" runat="server" AdImgId="4"
                SkinFilename="AdSimpleImageTitle.ascx" />
        </div>
    </div>
</div>
