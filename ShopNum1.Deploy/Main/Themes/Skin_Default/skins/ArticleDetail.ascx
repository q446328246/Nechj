<%@ Control Language="C#" %>
<%@ Import Namespace="System.Data" %>
<div class="SearchResultBox">
    <div class="article_list">
        <asp:Repeater ID="RepeaterArticleDetail" runat="server">
            <ItemTemplate>
                <div class="article_title">
                    <%# ((DataRowView)Container.DataItem).Row["Title"]%></div>
                <div class="article_time">
                    来源：<%# ((DataRowView)Container.DataItem).Row["Source"]%>&nbsp&nbsp 编辑：<%# ((DataRowView)Container.DataItem).Row["CreateUser"]%>&nbsp&nbsp
                    更新时间：<%# Convert.ToDateTime(((DataRowView)Container.DataItem).Row["CreateTime"]).ToString("yyyy-MM-dd")%>&nbsp&nbsp
                    浏览：<%# ((DataRowView)Container.DataItem).Row["ClickCount"]%>
                </div>
                <div class="article_detail article_imgcon">
                    <%# Server.HtmlDecode(((DataRowView)Container.DataItem).Row["Content"].ToString())%>
                </div>
            </ItemTemplate>
        </asp:Repeater>
        <!-- JiaThis Button Start -->
        <div class="jiathis_style_32x32">
            <a class="jiathis_button_qzone"></a><a class="jiathis_button_tsina"></a><a class="jiathis_button_tqq">
            </a><a class="jiathis_button_renren"></a><a class="jiathis_button_kaixin001"></a>
            <a href="http://www.jiathis.com/share" class="jiathis jiathis_txt jtico jtico_jiathis"
                target="_blank"></a><a class="jiathis_counter_style"></a>
        </div>
        <script type="text/javascript" src="http://v3.jiathis.com/code/jia.js" charset="utf-8"></script>
        <!-- //JiaThis Button End -->
    </div>
    <asp:Repeater ID="RepeaterOnAndNext" runat="server">
        <ItemTemplate>
            <div class="pageupdown">
                <%# ((DataRowView)Container.DataItem).Row["Name"]%><a href='<%# ShopUrlOperate.RetUrl("ArticleDetail",((DataRowView)Container.DataItem).Row["guid"]) %>'><%# ((DataRowView)Container.DataItem).Row["Title"]%></a>
            </div>
        </ItemTemplate>
    </asp:Repeater>
    <asp:HiddenField ID="HiddenFieldGuid" runat="server" Value="0" />
</div>
