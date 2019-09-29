<%@ Control Language="C#" %>
<%@ Import Namespace="System.Data" %>
<div class="all_supply">
    <asp:Repeater ID="RepeaterData" runat="server">
        <ItemTemplate>
            <div class="supply_list">
                <div class="dfl_title">
                    <%# ((DataRowView)Container.DataItem).Row["Name"]%>
                </div>
                <div class="supply_detail">
                    <ul>
                        <asp:Repeater ID="RepeaterChild" runat="server">
                            <ItemTemplate>
                                <li><a href='<%# ShopUrlOperate.RetUrl("supplylist",((DataRowView)Container.DataItem).Row["code"]) %>'
                                    class="dfl_a">
                                    <%# ((DataRowView)Container.DataItem).Row["Name"]%></a>
                                    <asp:Repeater ID="RepeaterthreeChild" runat="server">
                                        <ItemTemplate>
                                            <a href='<%# ShopUrlOperate.RetUrl("supplylist",((DataRowView)Container.DataItem).Row["code"]) %>'>
                                                <%# ((DataRowView)Container.DataItem).Row["Name"]%>
                                            </a>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                    <asp:HiddenField ID="HiddenFieldFID" runat="server" Value='<%# ((DataRowView)Container.DataItem).Row["ID"] %>' />
                                </li>
                            </ItemTemplate>
                        </asp:Repeater>
                        <asp:HiddenField ID="HiddenFieldCID" runat="server" Value='<%# ((DataRowView)Container.DataItem).Row["ID"] %>' />
                    </ul>
                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</div>
