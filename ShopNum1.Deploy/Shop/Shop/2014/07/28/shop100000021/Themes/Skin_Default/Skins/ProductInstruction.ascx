<%@ Control Language="C#" EnableViewState="false"%>
<asp:Repeater ID="RepeaterProductDetail" runat="server">
    <ItemTemplate>
        <div class="pbox">
            <div class="content">
                <%#  Server.HtmlDecode(Eval("Instruction").ToString())%>
            </div>
        </div>
    </ItemTemplate>
</asp:Repeater>
