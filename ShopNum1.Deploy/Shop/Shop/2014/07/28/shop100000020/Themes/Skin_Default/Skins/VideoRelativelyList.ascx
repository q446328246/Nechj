<%@ Control Language="C#" EnableViewState="false"%>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="ShopNum1.Common" %>
<div style="padding: 4px 20px; width: auto; overflow: hidden;">
    <table cellspacing="3" cellpadding="2" border="0">
        <asp:Repeater ID="RepeaterShow" runat="server">
            <ItemTemplate>
                <tr>
                    <td style="text-align: center;">
                           <div style="border: #cccccc 1px solid; padding: 2px; height:164px; width:164px; overflow: hidden; float:none;" class="lmf_content">
                            <a href='<%# ShopUrlOperate.RetUrl("VideoDetail", Eval("Guid"))%>' style="display:block;">
                                <img alt='<%# ((DataRowView)Container.DataItem).Row["Title"]%>' width="160px" height="160px"
                                    src="<%# Eval("ImgAdd")%>" onerror="javascript:this.src='../Images/noImage.gif'" />
                            </a>
                        </div>
                        <div class="lmf_content1">
                            <a title="<%# ShopNum1.WebControl.VideoIsRecommendOrNewsList.GetSubstr(Eval("Title"),10,false)%>"
                                target="_blank" href='<%# ShopUrlOperate.RetUrl("VideoDetail", Eval("Guid"))%>'
                                target="_blank" title='<%# ((DataRowView)Container.DataItem).Row["Title"]%>'>
                                <%# ShopNum1.WebControl.VideoIsRecommendOrNewsList.GetSubstr(Eval("Title"),10,false)%></a>
                        </div>
                        <div class="lmf_content2">
                            播放次数<%# Eval("BroadcastCount")%>
                            评论次数<%# Eval("CommentCount")%>
                        </div>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>
</div>
