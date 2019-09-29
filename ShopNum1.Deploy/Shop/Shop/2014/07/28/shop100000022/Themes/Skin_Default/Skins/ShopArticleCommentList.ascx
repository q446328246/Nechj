<%@ Control Language="C#" EnableViewState="false"%>
<div class="bBoxnt" style="margin-top:12px;">
    <h2>资讯点评</h2>
    <div class="content">
        <asp:Repeater ID="RepeaterData" runat="server">
            <ItemTemplate>
                <div class="desc_list">
                    <div class="desc_list_top">
                        <div class="desc_name fl">
                            <%--<b style="color: Red">【<%# ShopNum1.ShopWebControl.ShopArticleCommentList.GetValue(Eval("Rank"))%>】</b>--%>
                            评论人：<%# Eval("MemLoginID")%>
                        </div>
                        <div class="desc_date fr">
                            <%# Eval("CommentTime", "{0:yyyy-MM-dd}")%></div>
                    </div>
                    <div class="desc_list_pl">
                        <%--【评论标题】：<%# Eval("Title")%><br />--%>
                        【评论内容】：<%# Eval("Content")%>
                        <div class="glyhf" style="display:none">
                            <img src="Themes/Skin_Default/Images/2010-07-25_084638.gif" />
                            <span style="color: #E77C16; height: 15px;">商家回复：<%# Eval("ReplyTime")%></span>
                            <p>
                                <%# Eval("ReplyContent")%></p>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>        
    </div>
    <!-- 分页部分-->
    <div class="pager">
        <asp:Label ID="LabelPageMessage" runat="server"></asp:Label>
        &nbsp;<asp:HyperLink ID="lnkFirst" runat="server"><span class="fpager">[ 首页</span></asp:HyperLink>
        <asp:HyperLink ID="lnkPrev" runat="server"><span class="fpager">| 上一页</span></asp:HyperLink>
        <asp:HyperLink ID="lnkNext" runat="server"><span class="fpager">| 下一页</span></asp:HyperLink>
        <asp:HyperLink ID="lnkLast" runat="server"><span class="fpager">| 末页 ]</span></asp:HyperLink>
        &nbsp;<span class="fpager">转到<asp:Literal ID="lnkTo" runat="server" />页</span>
    </div>
</div>
