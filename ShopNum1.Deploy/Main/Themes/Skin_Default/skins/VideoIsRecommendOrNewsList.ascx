<%@ Control Language="C#" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="ShopNum1.Common" %>
<ul class="VideoList">
    <asp:Repeater ID="RepeaterShow" runat="server">
        <ItemTemplate>
            <li><a href='<%# ShopUrlOperate.RetUrl("VideoDetail", Eval("Guid"))%>' target="_blank"
                title='<%# ((DataRowView)Container.DataItem).Row["Title"]%>' class="VideoImg">
                <img alt='<%# ((DataRowView)Container.DataItem).Row["Title"]%>' width="164px" height="164px"
                    src="<%# (Eval("ImgAdd")) %>" onerror="javascript:this.src='/ImgUpload/noimg.jpg'" />
            </a><span class="VideoName">
                <%# ShopNum1.WebControl.VideoIsRecommendOrNewsList.GetSubstr(Eval("Title"), 10, false)%></span>
                <span class="VideoNum">播放次数<%# Eval("BroadcastCount")%></span> </li>
        </ItemTemplate>
    </asp:Repeater>
</ul>
