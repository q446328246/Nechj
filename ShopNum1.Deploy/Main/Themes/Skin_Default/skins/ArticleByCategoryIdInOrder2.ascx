<%@ Control Language="C#" %>
<%@ Import Namespace="System.Data" %>
<span id="ArticleByCategoryIdInOrder2">
<asp:Repeater ID="RepeaterArticleFirst" runat="server">
    <ItemTemplate>
       <div class="new_headline_bj2">
             <div class="new_headline_title">
                <a target="_blank" href='<%# ShopUrlOperate.RetUrl("ArticleDetail",((DataRowView)Container.DataItem).Row["Guid"]) %>'
                title='<%# ((DataRowView)Container.DataItem).Row["Title"]%>'>
                    <%# ((DataRowView)Container.DataItem).Row["Title"]%></a>
            </div>
            <div class="new_headline_content">
                <%# Server.HtmlDecode(((DataRowView)Container.DataItem).Row["Description"].ToString())%>
            </div>
        </div>
        <div class="new_headline_list">
        <%--<input type="hidden" name="ArticleByCategoryIdInOrder2$ctl00$RepeaterArticleFirst$ctl00$HiddenFieldGuid"
                                            id="ArticleByCategoryIdInOrder2_ctl00_RepeaterArticleFirst_ctl00_HiddenFieldGuid"
                                            value="a3ef3443-3482-4b82-8559-3f58c041aa73" />--%>
            <asp:HiddenField ID="HiddenFieldGuid" Value='<%# ((DataRowView)Container.DataItem).Row["Guid"]%>' runat="server" />
            <asp:Repeater ID="RepeaterArticleNew" runat="server">
                <ItemTemplate>
                   <div style="height: 25px; overflow: hidden;">
                        <span class="new_titletag">[<a target="_blank" href='<%# ShopUrlOperate.RetUrl("ArticleList",((DataRowView)Container.DataItem).Row["ID"]) %>'>
                            <%#((DataRowView)Container.DataItem).Row["Name"]%>
                        </a>]</span> <a target="_blank" href='<%# ShopUrlOperate.RetUrl("ArticleDetail",((DataRowView)Container.DataItem).Row["Guid"]) %>'
                        title='<%# ((DataRowView)Container.DataItem).Row["Title"]%>'>
                            <%# ((DataRowView)Container.DataItem).Row["Title"]%>
                        </a>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </ItemTemplate>
</asp:Repeater>
</span>
