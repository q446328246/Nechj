<%@ Control Language="C#" EnableViewState="false"%>
<%@ Import Namespace="ShopNum1.Common" %>
<%@ Import Namespace="ShopNum1.ShopWebControl" %>
<div class="content">
    <asp:Repeater ID="RepeaterCommentList" runat="server">
        <ItemTemplate>
            <div class="messageAdd">
                <div class="messageAdd-title">
                    <span class="fl">内容标题：<%# Eval("Title")%></span>
                </div>
                <div class="messageAdd-title">
                    <!--时间-->
                    <span class="fr">发布时间：<%# Eval("ValidTime")%></span>
                </div>
                <div class="messageAdd-title">
                    供求类型：<%# SupplyListIsNew.TradeType(Eval("TradeType").ToString()) %>
                </div>
                <div class="messageAdd-title">
                    供求目录：<%# Eval("CfCode")%>><%# Eval("CsCode")%>><%# Eval("CtCode")%>
                </div>
                <div class="messageAdd-title">
                    详细说明：<%# Eval("Content")%>
                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</div>
