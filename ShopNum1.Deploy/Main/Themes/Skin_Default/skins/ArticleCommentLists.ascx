<%@ Control Language="C#" %>
<%@ Import Namespace="System.Data" %>
<div class="CommentsAdd">
    <h1 class="CommentsAdd_title">
        <span>用户评论</span></h1>
    <div class="desc_cont">
        <asp:Repeater ID="RepeaterArticleCommentList" runat="server">
            <ItemTemplate>
                <div class="desc_list">
                    <div class="desc_list_top">
                        <div class="desc_name fl">
                            <span class="red2">
                                <%# ((DataRowView)Container.DataItem).Row["MemLoginID"]%></span>:
                            <%# ((DataRowView)Container.DataItem).Row["Title"]%>
                        </div>
                        <div class="desc_date fr">
                            <%# ((DataRowView)Container.DataItem).Row["SendTime"]%>
                        </div>
                        <div class="clear">
                        </div>
                    </div>
                    <div class="desc_list_pl">
                        <div class="yhpl">
                            <%# ((DataRowView)Container.DataItem).Row["Content"]%></div>
                        <div class="glyhf">
                            <p>
                                <span class="red">管理员回复：</span><%# ((DataRowView)Container.DataItem).Row["ReplyContent"]%></p>
                            <p>
                                <%# ((DataRowView)Container.DataItem).Row["ReplyTime"]%></p>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</div>
<!-- 分页部分-->
<div class="page" style="margin-left: 0; margin-right: 0;">
    <asp:Label ID="LabelPageMessage" runat="server"></asp:Label>
    &nbsp;<asp:HyperLink ID="lnkFirst" runat="server"><span class="fpager">[ 首页</span></asp:HyperLink>
    <asp:HyperLink ID="lnkPrev" runat="server"><span class="fpager">| 上一页</span></asp:HyperLink>
    <asp:HyperLink ID="lnkNext" runat="server"><span class="fpager">| 下一页</span></asp:HyperLink>
    <asp:HyperLink ID="lnkLast" runat="server"><span class="fpager">| 末页 ]</span></asp:HyperLink>
    &nbsp;<span class="fpager">转到
        <asp:Literal ID="lnkTo" runat="server" />
        页</span>
</div>
