<%@ Control Language="C#" EnableViewState="false"%>
<div id="print_view">
    <div class="info">
        <p>
            你选择打印<asp:Literal ID="LiteralCount" runat="server"></asp:Literal>张优惠券，预计将打印在1张A4纸上。</p>
        <a class="print" id="Aprint" title="打印优惠券" href="javascript:void(0)" runat="server" onclick="javascript:window.print()" >打印优惠券</a>
    </div>
    <div id="print_box">
        <div id="divToPrint">
            <asp:Literal ID="LiteralPic" runat="server"></asp:Literal>
        </div>
    </div>
</div>
