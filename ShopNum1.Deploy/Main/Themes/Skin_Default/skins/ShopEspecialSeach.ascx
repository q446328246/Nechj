<%@ Control Language="C#" %>
<%@ Import Namespace="System.Data" %>
<div class="latest_shop" style="margin-bottom: 6px;">
    <div class="all_top">
        <div class="latest_shop1 fl" style="border: none;">
            <asp:Localize ID="localizeTitle" runat="server" Text=""></asp:Localize>
        </div>
    </div>
    <asp:Repeater ID="RepeaterData" runat="server">
        <ItemTemplate>
            <div class="latest_shop_detail">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td rowspan="4" width="80" valign="top" style="border-right: 1px dashed #e1e1e1;
                            background: #fcfcfc;">
                            <img src='<%# ((DataRowView)Container.DataItem).Row["Banner"]%>' runat="server" alt="图片"
                                width="90" height="90" />
                        </td>
                        <td class="las_t">
                            <a href='<%#ShopUrlOperate.GetShopUrl(((DataRowView)Container.DataItem).Row["ShopID"].ToString())%>'
                                target="_blank">
                                <%# ((DataRowView)Container.DataItem).Row["ShopName"]%></a> <span id="spanshopid"
                                    runat="server" visible="false">
                                    <%# ((DataRowView)Container.DataItem).Row["MemLoginID"]%></span>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            主营宝贝：<asp:Repeater ID="RepeaterProduct" runat="server">
                                <ItemTemplate>
                                    <a href='<%#ShopUrlOperate.shopHref(((DataRowView)Container.DataItem).Row["Guid"].ToString(),((DataRowView)Container.DataItem).Row["MemLoginID"].ToString() )%>'>
                                        <%#((DataRowView)Container.DataItem).Row["Name"]%></a>
                                </ItemTemplate>
                            </asp:Repeater>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            店铺介绍：<a href='<%#ShopUrlOperate.GetShopUrl(((DataRowView)Container.DataItem).Row["ShopID"].ToString())%>'
                                target="_blank">
                                <%#((DataRowView)Container.DataItem).Row["ShopIntroduce"]%></a>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Repeater ID="RepeaterImg" runat="server">
                                <ItemTemplate>
                                    <img id="EnsureImg" alt="图片" width="16" height="17" src='<%#((DataRowView)Container.DataItem).Row["ImagePath"] %>'
                                        runat="server" />
                                </ItemTemplate>
                            </asp:Repeater>
                            <a href='<%#ShopUrlOperate.GetShopMessageBoardUrl(((DataRowView)Container.DataItem).Row["ShopID"].ToString()) %>'
                                target="_blank">留言</a> <a href='' target="_blank">点评</a>
                        </td>
                </table>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</div>
