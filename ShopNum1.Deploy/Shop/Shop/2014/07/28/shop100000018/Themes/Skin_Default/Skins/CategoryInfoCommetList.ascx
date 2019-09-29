<%@ Control Language="C#" %>
<%@ Import Namespace="ShopNum1.ShopWebControl" %>
<div class="content">
    <asp:Repeater ID="RepeaterCommentList" runat="server">
        <ItemTemplate>
            <div class="messageAdd">
                <div class="messageAdd-title">
                    <span class="fl">评论人：<%# Eval("AssociateMemberID")%></span>
                </div>
                <div class="messageAdd-title">
                    <!--时间-->
                    <span class="fr">
                        <%# Eval("CreateTime")%></span>
                </div>
                <div class="messageAdd-title">
                    标题：<%# Eval("Title")%>
                </div>
                <div class="messageAdd-title">
                    内容：<%# Eval("Content")%>
                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</div>
<!-- 分页部分-->
<div class="pager" style="text-align: right">
    <asp:Label ID="LabelPageMessage" runat="server"></asp:Label>
    &nbsp;<asp:HyperLink ID="lnkFirst" runat="server"><span class="fpager">[ 首页</span></asp:HyperLink>
    <asp:HyperLink ID="lnkPrev" runat="server"><span class="fpager">| 上一页</span></asp:HyperLink>
    <asp:HyperLink ID="lnkNext" runat="server"><span class="fpager">| 下一页</span></asp:HyperLink>
    <asp:HyperLink ID="lnkLast" runat="server"><span class="fpager">| 末页 ]</span></asp:HyperLink>
    &nbsp;<span class="fpager">转到
        <asp:Literal ID="lnkTo" runat="server" />
        页</span>
</div>
