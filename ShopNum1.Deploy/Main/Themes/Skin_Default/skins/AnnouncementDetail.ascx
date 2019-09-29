<%@ Control Language="C#" %>
<%@ Import Namespace="ShopNum1.WebControl" %>
<%@ Import Namespace="System.Data" %>
<div class="SearchResultBox">
    <div class="article_list">
        <asp:Repeater ID="RepeaterData" runat="server">
            <ItemTemplate>
                <div class="article_list">
                    <div class="article_title">
                        <%# ((DataRowView)Container.DataItem).Row["Title"]%></div>
                    <div class="article_time">
                        发布时间：<%# Convert.ToDateTime(((DataRowView)Container.DataItem).Row["CreateTime"]).ToString("yyyy-MM-dd")%>
                        发布者：<%# ((DataRowView)Container.DataItem).Row["CreateUser"]%>
                    </div>
                    <div class="article_detail article_imgcon">
                        <%# HttpUtility.HtmlDecode(((DataRowView)Container.DataItem).Row["Remark"].ToString())%>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
        <!-- JiaThis Button BEGIN -->
        <div class="jiathis_style_32x32">
            <a class="jiathis_button_qzone"></a><a class="jiathis_button_tsina"></a><a class="jiathis_button_tqq">
            </a><a class="jiathis_button_renren"></a><a class="jiathis_button_kaixin001"></a>
            <a href="http://www.jiathis.com/share" class="jiathis jiathis_txt jtico jtico_jiathis"
                target="_blank"></a><a class="jiathis_counter_style"></a>
        </div>
        <script type="text/javascript" src="http://v3.jiathis.com/code/jia.js" charset="utf-8"></script>
        <!-- JiaThis Button END -->
    </div>
    <asp:Repeater ID="RepeaterUpDown" runat="server">
        <ItemTemplate>
            <div class="pageupdown">
                <!-- 上一篇，下一篇 -->
                <%# ((DataRowView)Container.DataItem).Row["Name"]%><a href='<%# ShopUrlOperate.RetUrl("AnnouncementDetail",((DataRowView)Container.DataItem).Row["guid"]) %>'><%# ((DataRowView)Container.DataItem).Row["Title"]%></a>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</div>
