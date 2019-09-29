<%@ Control Language="C#" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="ShopNum1.Common" %>
<div class="VideoRecommendBox clearfix">
    <ul>
        <asp:Repeater ID="RepeaterShow" runat="server">
            <ItemTemplate>
                <li><span class="title fl"><a href='<%# ShopUrlOperate.RetUrl("VideoDetail", ((DataRowView)Container.DataItem).Row["Guid"])%>'
                    target="_blank" title='<%# ((DataRowView)Container.DataItem).Row["Title"]%>'>
                    <%# ShopNum1.WebControl.VideoIsRecommendOrNewsList.GetSubstr(((DataRowView)Container.DataItem).Row["Title"],10,false)%></a>
                </span><span class="number fr">人气：<%#((DataRowView)Container.DataItem).Row["BroadcastCount"] %>
                </span></li>
            </ItemTemplate>
        </asp:Repeater>
    </ul>
</div>
