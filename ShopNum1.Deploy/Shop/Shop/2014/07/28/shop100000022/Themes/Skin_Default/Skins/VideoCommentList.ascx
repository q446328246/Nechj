<%@ Control Language="C#" EnableViewState="false"%>
<div class="bBox bBoxnt">
    <div class="sdfrquen">
        <h2>视频点评</h2>
    </div>
    <div class="content" style="border: none; padding: 0px;">
        <asp:Repeater ID="RepeaterData" runat="server">
            <ItemTemplate>
                <div class="desc_list frquen_list">
                    <div class="desc_list_top">
                        <div class="desc_name fl"><%# Eval("MemLoginID")%></div>
                        <div class="desc_date fr"><%# Eval("CommentTime", "{0:yyyy-MM-dd}")%></div>
                    </div>
                    <div class="desc_list_pl">
                        <div class="glyhf">
                            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                <tr>
                                    <td style="width:80px; vertical-align:top;">
                                        <p class="talek">评论内容：</p>
                                    </td>
                                    <td>
                                        <p style="color:#999;"><%# Eval("Comment")%></p>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</div>
<!-- 分页部分-->
<div class="pager">
    <asp:Label ID="LabelPageMessage" runat="server"></asp:Label>
    &nbsp;<asp:HyperLink ID="lnkFirst" runat="server" Text="[ 首页"></asp:HyperLink>
    <asp:HyperLink ID="lnkPrev" runat="server" Text="| 上一页"></asp:HyperLink>
    <asp:HyperLink ID="lnkNext" runat="server" Text="| 下一页"></asp:HyperLink>
    <asp:HyperLink ID="lnkLast" runat="server" Text="| 末页 ]"></asp:HyperLink>
    &nbsp;<span class="fpager">转到<asp:Literal ID="lnkTo" runat="server" Visible="false" />页</span>
</div>