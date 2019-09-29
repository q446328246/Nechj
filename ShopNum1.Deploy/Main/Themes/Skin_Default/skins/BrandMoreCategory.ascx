<%@ Control Language="C#" %>
<%@ Import Namespace="System.Data" %>
<div class="cBox clearfix">
    <h2>
        更多品牌信息 <span></span>
    </h2>
    <div class="content clearfix">
        <asp:Repeater ID="RepeaterData" runat="server">
            <ItemTemplate>
                <dl>
                    <dt><a href='<%#ShopUrlOperate.RetUrl("BrandMoreSearch",((DataRowView)Container.DataItem).Row["Code"])%>'>
                        <%# ((DataRowView)Container.DataItem).Row["Name"]%></a></dt>
                    <asp:Repeater ID="RepeaterChild" runat="server">
                        <HeaderTemplate>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <dd>
                                <a href='<%#ShopUrlOperate.RetUrl("BrandMoreSearch",((DataRowView)Container.DataItem).Row["Code"]) %>'>
                                    <%# ((DataRowView)Container.DataItem).Row["Name"]%></a></dd>
                            <asp:Repeater ID="RepeaterthreeChild" runat="server">
                                <HeaderTemplate>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <dd>
                                        <a href='<%#ShopUrlOperate.RetUrl("BrandMoreSearch",((DataRowView)Container.DataItem).Row["Code"])%>'>
                                            <%# ((DataRowView)Container.DataItem).Row["Name"]%></a></dd>
                                </ItemTemplate>
                                <FooterTemplate>
                                </FooterTemplate>
                            </asp:Repeater>
                            <asp:HiddenField ID="HiddenFieldFID" runat="server" Value='<%# ((DataRowView)Container.DataItem).Row["ID"] %>' />
                        </ItemTemplate>
                        <FooterTemplate>
                        </FooterTemplate>
                    </asp:Repeater>
                    <asp:HiddenField ID="HiddenFieldCID" runat="server" Value='<%# ((DataRowView)Container.DataItem).Row["ID"] %>' />
                </dl>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</div>
