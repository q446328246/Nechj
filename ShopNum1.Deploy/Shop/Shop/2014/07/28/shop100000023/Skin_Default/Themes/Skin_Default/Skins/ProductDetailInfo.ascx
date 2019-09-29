<%@ Control Language="C#" %>
<asp:Repeater ID="RepeaterProductDetail" runat="server">
    <ItemTemplate>
        <div class="pbox">
            <div class="content">
                <%#  Server.HtmlDecode(Eval("Detail").ToString()) %>
            </div>
        </div>
    </ItemTemplate>
</asp:Repeater>
