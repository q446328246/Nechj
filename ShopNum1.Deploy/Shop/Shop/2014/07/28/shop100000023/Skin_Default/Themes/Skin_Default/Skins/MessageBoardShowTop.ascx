<%@ Control Language="C#" %>
<%@ Import Namespace="ShopNum1.ShopWebControl" %>
<div class="bBox">
    <div>
        <h2>
            <asp:LinkButton ID="LinkButtonAll" runat="server" CausesValidation="false">网友留言 </asp:LinkButton>
            <div style="margin-left: 100px; position: relative; top: -33px;">
                <table>
                    <tr>
                        <td style="border-left: 1px dotted #D3D3D3; width: 80px; font-weight: normal; height: 12px;
                            padding-left: 7px;">
                            <div id="div1" runat="server">
                                <asp:LinkButton ID="LinkButton0" runat="server" CausesValidation="false">售后 </asp:LinkButton>
                            </div>
                        </td>
                        <td style="border-left: 1px dotted #D3D3D3; width: 80px; font-weight: normal; height: 12px;
                            padding-left: 7px; "">
                            <div id="div2" runat="server">
                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="false">询问</asp:LinkButton>
                            </div>
                        </td>
                        <td style="border-left: 1px dotted #D3D3D3; width: 80px; font-weight: normal; height: 12px;
                            padding-left: 7px; "">
                            <div id="div3" runat="server">
                                <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="false">一般消息</asp:LinkButton>
                            </div>
                        </td>
                        <td style="border-left: 1px dotted #D3D3D3; width: 80px; font-weight: normal; height: 12px;
                            padding-left: 7px; "">
                            <div id="div4" runat="server">
                                <asp:LinkButton ID="LinkButton3" runat="server" CausesValidation="false">求购</asp:LinkButton>
                            </div>
                        </td>
                        <td style="border-left: 1px dotted #D3D3D3; width: 80px; font-weight: normal; height: 12px;
                            padding-left: 7px; "">
                            <div id="div5" runat="server">
                                <asp:LinkButton ID="LinkButton4" runat="server" CausesValidation="false">留言</asp:LinkButton>
                            </div>
                        </td>
                        <td style="border-left: 1px dotted #D3D3D3; width: 80px; font-weight: normal; height: 12px;
                            padding-left: 7px; "">
                            <div id="div6" runat="server">
                                <asp:LinkButton ID="LinkButton5" runat="server" CausesValidation="false">重要消息</asp:LinkButton>
                            </div>
                        </td>
                    </tr>
                </table>
            </div>
        </h2>
    </div>
    <div class="content">
        <asp:Repeater ID="RepeaterBoardList" runat="server">
            <ItemTemplate>
                <div class="messageAdd">
                    <div class="messageAdd-title">
                        <span class="fl"><b style="color: #f00;">【<%# MessageBoardShow.GetValue(Eval("MessageType"))%>】</b>
                            留言人：<%# Eval("MemberName")%>
                        </span>
                        <!--时间-->
                        <span class="fr">
                            <%# Eval("SendTime")%>&nbsp;&nbsp;</span>
                    </div>
                    <div class="messageAdd-title">
                        留言标题：<%# Eval("Title")%>
                    </div>
                    <div class="messageAdd-title">
                        留言内容：<%# Eval("Content")%>
                    </div>
                    <div class="messageAdd-top" style='display: <%# string.IsNullOrEmpty(Eval("ManageTime").ToString()+Eval("ReplyContent").ToString())==true?"none":"block"%>'>
                    </div>
                    <div class="messageAdd-content" style='display: <%# string.IsNullOrEmpty(Eval("ManageTime").ToString()+Eval("ReplyContent").ToString())==true?"none":"block"%>'>
                        <table cellpadding="0" cellspacing="10" width="100%" border="0">
                            <tr style='display: <%# string.IsNullOrEmpty(Eval("ReplyContent").ToString())==true?"none":"block"%>'>
                                <td>
                                    <span class="fl">
                                        <img src="Themes/Skin_Default/Images/2010-07-25_084638.gif" />
                                        <span style="color: #E77C16; height: 15px;">商家回复：<%# Eval("ReplyTime")%></span>
                                        <p>
                                            <%# Eval("ReplyContent")%></p>
                                </td>
                            </tr>
                            <tr style='display: <%# string.IsNullOrEmpty(Eval("ManageTime").ToString())==true?"none":"block"%>'>
                                <td>
                                    <img src="Themes/Skin_Default/Images/2010-07-25_084638.gif" />
                                    <span style="color: #E77C16; height: 15px;">团派客服:<%# Eval("ManageTime")%></span>
                                    <p>
                                        <%# Eval("ManageReply")%></p>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="messageAdd-bottom" style='display: <%# string.IsNullOrEmpty(Eval("ManageTime").ToString()+Eval("ReplyContent").ToString())==true?"none":"block"%>'>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</div>
<!-- 分页部分-->
<div class="pager">
    <asp:Label ID="LabelPageMessage" runat="server"></asp:Label>
    &nbsp;<asp:HyperLink ID="lnkFirst" runat="server"><span class="fpager">[ 首页</span></asp:HyperLink>
    <asp:HyperLink ID="lnkPrev" runat="server"><span class="fpager">| 上一页</span></asp:HyperLink>
    <asp:HyperLink ID="lnkNext" runat="server"><span class="fpager">| 下一页</span></asp:HyperLink>
    <asp:HyperLink ID="lnkLast" runat="server"><span class="fpager">| 末页 ]</span></asp:HyperLink>
    &nbsp;<span class="fpager">转到
        <asp:Literal ID="lnkTo" runat="server" />
        页</span>
</div>
