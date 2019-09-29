<%@ Control Language="C#" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="ShopNum1.Common" %>
<div class="VideoHotBox">
    <ul>
        <asp:Repeater ID="RepeaterShow" runat="server">
            <ItemTemplate>
                <li>                    
                    <a href='<%# ShopUrlOperate.RetUrl("VideoDetail", Eval("Guid"))%>' class="VideoImg">
                        <img alt='<%# ((DataRowView)Container.DataItem).Row["Title"]%>' width="160px" height="160px"
                            src="<%# Eval("ImgAdd")%>" onerror="javascript:this.src='/ImgUpload/noimg.jpg'" />
                    </a>                    
                    <span class="VideoName">
                        <a title="<%# ShopNum1.WebControl.VideoIsRecommendOrNewsList.GetSubstr(Eval("Title"),10,false)%>"
                            target="_blank" href='<%# ShopUrlOperate.RetUrl("VideoDetail", Eval("Guid"))%>'
                            target="_blank" title='<%# ((DataRowView)Container.DataItem).Row["Title"]%>'>
                            <%# ShopNum1.WebControl.VideoIsRecommendOrNewsList.GetSubstr(Eval("Title"),10,false)%></a>
                    </span>
                    <span class="VideoNum">
                        播放次数<%# Eval("BroadcastCount")%>
                        评论次数<%#ShopNum1.WebControl.VideoIsHotList.GetVideoCommentCount(Eval("Guid").ToString())%>
                    </span>
                </li>
            </ItemTemplate>
        </asp:Repeater>
    </ul>
</div>


