<%@ Control Language="C#" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="ShopNum1.Common" %>
<ul class="VideoList clearfix">
    <asp:Repeater ID="RepeaterData" runat="server">
        <ItemTemplate>
            <li><a class="VideoImg" href='<%# ShopUrlOperate.RetUrl("VideoDetail",((DataRowView)Container.DataItem).Row["Guid"] )%>'>
                <img alt='<%# ((DataRowView)Container.DataItem).Row["Title"]%>' width="164" height="164"
                    src="<%# Eval("ImgAdd") %>" onerror="javascript:this.src='/ImgUpload/noimg.jpg'" />
            </a><span class="VideoName"><a href='<%# ShopUrlOperate.RetUrl("VideoDetail",((DataRowView)Container.DataItem).Row["Guid"] )%>'>
                <%# ShopNum1.WebControl.VideoIsRecommendOrNewsList.GetSubstr(((DataRowView)Container.DataItem).Row["Title"], 10, false)%></a>
            </span><span class="VideoNum">播放次数<%#((DataRowView)Container.DataItem).Row["BroadcastCount"]%></span>
            </li>
        </ItemTemplate>
    </asp:Repeater>
</ul>
<div id="pageDiv" runat="server" class="page_sort">
</div>
