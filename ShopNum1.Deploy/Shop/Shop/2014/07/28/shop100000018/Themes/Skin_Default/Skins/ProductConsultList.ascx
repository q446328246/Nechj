<%@ Control Language="C#" EnableViewState="false"%>
<div id="MessageBarod">
    <div id="ProductComment" class="clearfix">留言信息</div>
    <div class="MessageBox">
        <asp:Repeater ID="RepeaterProductConsultList" runat="server">
            <ItemTemplate>
                <div class="desc_list">
                    <div class="desc_list_top">
                        <div class="desc_name fl">留言人：<%# Eval("ConsultPeople")%></div>
                        <div class="desc_date fr"><%# Eval("SendTime")%></div>
                    </div>
                    <div class="desc_list_pl">
                        【留言内容】：<%# Eval("Content")%>
                        <div class="glyhf">
                            <img alt="回复" src="Themes/Skin_Default/Images/2010-07-25_084638.gif" />
                            <%# Eval("ReplyContent")%>&nbsp;&nbsp;&nbsp;&nbsp; <%# Eval("Replytime")%>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
        <div class="clearfix"></div>
        <!-- 分页部分-->
        <div class="pager">
            <asp:Label ID="LabelPageMessage" runat="server"></asp:Label>
            &nbsp;<asp:HyperLink ID="lnkFirst" runat="server"><span class="fpager">[ 首页</span></asp:HyperLink>
            <asp:HyperLink ID="lnkPrev" runat="server"><span class="fpager">| 上一页</span></asp:HyperLink>
            <asp:HyperLink ID="lnkNext" runat="server"><span class="fpager">| 下一页</span></asp:HyperLink>
            <asp:HyperLink ID="lnkLast" runat="server"><span class="fpager">| 末页 ]</span></asp:HyperLink>
            &nbsp;<span class="fpager">转到<asp:Literal ID="lnkTo" runat="server" />页</span>
        </div>
        <div class="clearfix"></div>
    </div>
</div>
