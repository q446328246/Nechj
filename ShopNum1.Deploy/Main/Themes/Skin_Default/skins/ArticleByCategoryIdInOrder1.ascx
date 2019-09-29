<%@ Control Language="C#" %>
<%@ Import Namespace="System.Data" %>
<span id="ArticleByCategoryIdInOrder1">
<asp:Repeater ID="RepeaterArticleFirst" runat="server">
    <ItemTemplate>
       <div class="new_headline_bj1">
            <div class="new_headline_title">
                <a target="_blank" href='<%# ShopUrlOperate.RetUrl("ArticleDetail",Eval("Guid")) %>'
                title='<%# ((DataRowView)Container.DataItem).Row["Title"]%>'>
                    <%# Eval("Title")%></a>
            </div>
            <div class="new_headline_content">
                <%# Server.HtmlDecode(Eval("Description").ToString())%>
            </div>
        </div>
       <div class="new_headline_list">
        <%--<input type="hidden" name="ArticleByCategoryIdInOrder1$ctl00$RepeaterArticleFirst$ctl00$HiddenFieldGuid"
                                            id="ArticleByCategoryIdInOrder1_ctl00_RepeaterArticleFirst_ctl00_HiddenFieldGuid"
                                            value="dc7b832c-0983-41f9-ac5d-0a095d672813" />--%>
            <asp:HiddenField ID="HiddenFieldGuid" Value='<%# Eval("Guid")%>' runat="server" />
            <asp:Repeater ID="RepeaterArticleNew" runat="server">
                <ItemTemplate>
                   <div style="height: 25px; overflow: hidden;">
                        <span class="new_titletag">[<a target="_blank" href='<%# ShopUrlOperate.RetUrl("ArticleList",Eval("id")) %>'>
                            <%#Eval("Name")%>
                        </a>]</span> <a target="_blank" href='<%# ShopUrlOperate.RetUrl("ArticleDetail",Eval("guid")) %>' title='<%# ((DataRowView)Container.DataItem).Row["Title"]%>'>
                            <%# Eval("Title")%>
                        </a>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </ItemTemplate>
</asp:Repeater>
</span>
