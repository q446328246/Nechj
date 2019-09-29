<%@ Control Language="C#" %>
<%@ Import Namespace="System.Data" %>
<div class="new_info1">
    <div class="all_top">
        <div class="new_info_title_left fl" style="padding-left: 10px; font-size: 14px;">
            商品资讯</div>
        <div class="new_info_title_right fr">
            <a href='<%=ShopUrlOperate.RetUrl("ArticleListSearch")%>'>更多>></a></div>
    </div>
    <div class="new_info_list" style="border: none;">
        <div class="new_info_list_img fl" style="height: 151px">
            <%-- <img width="133" style="border: 1px dashed #dedede;" height="151" src="Themes/Skin_Default/Images/adv07.jpg" />--%>
            <ShopNum1:AdSimpleImage ID="AdSimpleImage" runat="server" AdImgId="42" SkinFilename="AdSimpleImage.ascx" />
        </div>
        <div class="new_info_list_de fr">
            <ul>
                <asp:Repeater ID="RepeaterArticleList" runat="server">
                    <ItemTemplate>
                        <li>·<a href='<%# ShopUrlOperate.RetUrl("ArticleDetail",((DataRowView)Container.DataItem).Row["guid"]) %>'
                            target="_blank">
                            <%# ShopNum1.Common.Utils.GetUnicodeSubString(((DataRowView)Container.DataItem).Row["Title"].ToString(),30,"")%></a></li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
        </div>
    </div>
</div>
