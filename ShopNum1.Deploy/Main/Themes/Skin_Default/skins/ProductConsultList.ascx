<%@ Control Language="C#" %>
<div class="mod2" id="MessageBarod">
    <div id="ProductComment" class="clearfix">
        <a href="javascript:void(0)" class="cur"><span class="fl"></span><span class="fr"></span>
            留言信息</a>
    </div>
    <div style="margin-bottom: 10px; background: #f5f8fd; border: 1px solid #dfdfdf;">
        <asp:Repeater ID="RepeaterProductConsultList" runat="server">
            <ItemTemplate>
                <div class="desc_list">
                    <div class="desc_list_top">
                        <div class="desc_name fl">
                            留言人：<%# Eval("ConsultPeople")%>
                        </div>
                        <div class="desc_date fr">
                            <%# Eval("SendTime")%></div>
                    </div>
                    <div class="desc_list_pl">
                        <%--【留言标题】：<%# Eval("Title")%><br />--%>
                        【留言内容】：<%# Eval("Content")%>
                        <div class="glyhf">
                            <img alt="" src="Themes/Skin_Default/Images/2010-07-25_084638.gif" />
                            <%--                        <span style="color: #E77C16; height: 15px;">商家回复：<%# Eval("ReplyTime")%></span>
                            <p>
                                <%# Eval("ReplyContent")%><%# Eval("ReplyTime")%></p>--%>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
        <div class="clearfix">
        </div>
        <!-- 分页部分-->
        <div class="pager" style="margin: 0 5px 5px 5px;">
            <asp:Label ID="LabelPageMessage" runat="server"></asp:Label>
            &nbsp;<asp:HyperLink ID="lnkFirst" runat="server"><span class="fpager">[ 首页</span></asp:HyperLink>
            <asp:HyperLink ID="lnkPrev" runat="server"><span class="fpager">| 上一页</span></asp:HyperLink>
            <asp:HyperLink ID="lnkNext" runat="server"><span class="fpager">| 下一页</span></asp:HyperLink>
            <asp:HyperLink ID="lnkLast" runat="server"><span class="fpager">| 末页 ]</span></asp:HyperLink>
            &nbsp;<span class="fpager">转到
                <asp:Literal ID="lnkTo" runat="server" />
                页</span>
        </div>
        <div class="clearfix">
        </div>
    </div>
</div>
