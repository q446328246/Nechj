<%@ Control Language="C#" EnableViewState="false"%>
<ul class="list-h">
    <asp:Repeater ID="RepeaterData" runat="server">
        <ItemTemplate>
            <li class="tb_diply">
                <div class="tb-pic tb-stn">
                    <a><img id="Img1" height="56" width="56" runat="server" src='<%# Eval("imgurl")+"_25x25.jpg" %>' lang='<%# Eval("imgurl")%>' /></a>  
                </div>
            </li>
        </ItemTemplate>
    </asp:Repeater>
</ul>