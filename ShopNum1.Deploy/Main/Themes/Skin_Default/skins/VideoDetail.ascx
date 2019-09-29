<%@ Control Language="C#" %>
<%@ Import Namespace="ShopNum1.ShopWebControl" %>
<%@ Import Namespace="ShopNum1.Common" %>
<asp:Repeater ID="RepeaterData" runat="server">
    <ItemTemplate>
        <div class="title">
            <span>视频:<%# Eval("Title")%></span>
        </div>
        <div class="player">
            <script>                document.write('<%# VideoDetail.GetVideo(Eval("VideoAdd "), "725", "702")%>')</script>
        </div>
    </ItemTemplate>
</asp:Repeater>
