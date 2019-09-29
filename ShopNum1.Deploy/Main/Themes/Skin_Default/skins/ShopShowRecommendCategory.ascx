<%@ Control Language="C#" %>
<%@ Import Namespace="System.Data" %>
<div class="shps" style="position: relative; left: -5px">
    <asp:Repeater ID="RepeaterData" runat="server">
        <ItemTemplate>
            <div class="shps_d">
                <span class="shps_weight"><a href='<%#ShopUrlOperate.RetUrl("shoplist",((DataRowView)Container.DataItem).Row["Code"])%>'>
                    <%# ((DataRowView)Container.DataItem).Row["Name"]%>
                </a></span>
                <br />
                <asp:Repeater ID="RepeaterChild" runat="server">
                    <ItemTemplate>
                        <a href='<%#ShopUrlOperate.RetUrl("shoplist",((DataRowView)Container.DataItem).Row["Code"])%>'
                            target="_blank" title='<%# ((DataRowView)Container.DataItem).Row["Name"] %>'>
                            <%# ((DataRowView)Container.DataItem).Row["Name"]%></a><asp:Literal ID="LiteralLine"
                                runat="server">/</asp:Literal>
                    </ItemTemplate>
                </asp:Repeater>
                <asp:HiddenField ID="HiddenFieldCID" runat="server" Value='<%# ((DataRowView)Container.DataItem).Row["ID"] %>' />
            </div>
        </ItemTemplate>
    </asp:Repeater>
</div>
