<%@ Control Language="C#" %>
<%@ Import Namespace="System.Data" %>
<div class="all_gq" style="width: 998px;">
    <div class="all_top">
        <span style="padding-left: 10px; color: #ff8400; font-size: 14px;">商品分类列表</span>
    </div>
    <!-- 大分类 -->
    <asp:Repeater ID="RepeaterData" runat="server">
        <ItemTemplate>
            <div class="dfl">
                <div class="dfl_title">
                    <%# ((DataRowView)Container.DataItem).Row["Name"]%>
                </div>
                <div class="dfl_detail">
                    <asp:Repeater ID="RepeaterChild" runat="server">
                        <ItemTemplate>
                            <a href="<%# ShopUrlOperate.RetUrl("productlist",((DataRowView)Container.DataItem).Row["Code"]) %>"
                                class="dfl_a" style="color: #0092d2;">
                                <%# ((DataRowView)Container.DataItem).Row["Name"]%></a>
                            <asp:Repeater ID="RepeaterthreeChild" runat="server">
                                <ItemTemplate>
                                    <a href='<%# ShopUrlOperate.RetUrl("productlist",((DataRowView)Container.DataItem).Row["Code"]) %>'>
                                        <%# ((DataRowView)Container.DataItem).Row["Name"]%>
                                    </a>
                                </ItemTemplate>
                            </asp:Repeater>
                            <asp:HiddenField ID="HiddenFieldFID" runat="server" Value='<%# ((DataRowView)Container.DataItem).Row["ID"] %>' />
                        </ItemTemplate>
                    </asp:Repeater>
                    <asp:HiddenField ID="HiddenFieldCID" runat="server" Value='<%# ((DataRowView)Container.DataItem).Row["ID"] %>' />
                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</div>
