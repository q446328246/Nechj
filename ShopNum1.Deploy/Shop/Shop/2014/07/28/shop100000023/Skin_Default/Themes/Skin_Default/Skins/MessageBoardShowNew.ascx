<%@ Control Language="C#" EnableViewState="false"%>
<%@ Import Namespace="ShopNum1.ShopNewWebControl" %>
<div class="MessageBoard">
    <div class="alltins">
        <div class="alosltn">
            <div  id="div0" runat="server" >
                <asp:LinkButton ID="LinkButtonAll" runat="server" CausesValidation="false">所有 </asp:LinkButton>
            </div>
            <div id="div1" runat="server">
                <asp:LinkButton ID="LinkButton0" runat="server" CausesValidation="false">询问 </asp:LinkButton>
            </div>
            <div id="div2" runat="server">
                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="false">求购</asp:LinkButton>
            </div>
            <div id="div3" runat="server">
                <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="false">售后</asp:LinkButton>
            </div>
            <div id="div4" runat="server">
                <asp:LinkButton ID="LinkButton3" runat="server" CausesValidation="false">其它</asp:LinkButton>
            </div>
        </div>
    </div>
    <div class="content guestext">
        <asp:Repeater ID="RepeaterBoardList" runat="server">
            <ItemTemplate>
                <div class="desc_list">
                    <div class="desc_list_top">
                        <div class="desc_name fl">
                            <b>【<%# MessageBoardShow.GetValue(Eval("MessageType"))%>】</b>
                            留言人：<%# Eval("MemberName")%>
                        </div>
                        <div class="desc_date fr"><%# Eval("SendTime")%></div>
                        <div class="clear"></div>
                    </div>
                    <div class="desc_list_pl">
                        <div class="glyhf clearfix" style="background: none;">
                            <div class="reply fl"><img src="Themes/Skin_Default/Images/quest.png" /></div>
                            <div class="revert fl"><%# Eval("Content")%></div>
                        </div>
                        <div class="glyhf clearfix">
                            <div class="merchant fl">商家回复：<%# Eval("ReplyTime")%></div>
                            <div class="mercont fl"><%# Eval("ReplyContent")%></div>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
    <!--分页-->
    <div class="fenye">
        <div class="lambert">
            <table cellpadding="0" cellspacing="0" border="0">
                <tr>
                    <td><span class="fenye1">共</span></td>
                    <td><span><asp:Label ID="LabelPageCount" runat="server" Text=""></asp:Label></span></td>
                    <td><span class="fenye2">页，到第</span></td>
                    <td><asp:TextBox ID="TextBoxIndex" runat="server" CssClass="pro_input"></asp:TextBox></td>
                    <td class="fenye_td1"><span class="fenye3">页</span></td>
                    <td class="fenye_td2"><asp:Button ID="ButtonSure" runat="server" Text="Button" CssClass="pro_btn" /></td>
                </tr>
            </table>
        </div>
        <div id="pageDiv" runat="server" class="pro_page">
            <div class="black2 ">
                <span class="disabled">< </span><span class="current">1</span><a href="#?page=2">2</a><span
                    class="diandian">...</span> <a href="#?page=200">200</a> <a href="#?page=2">></a>
            </div>
        </div>
    </div>
</div>