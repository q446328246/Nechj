<%@ Control Language="C#" %>
<%@ Import Namespace="System.Data" %>
<div class="mod1" id="SellOrder">
    <div class="title">
        <span class="left"></span><span class="right"></span>
        <div class="fl">
            销售排行</div>
    </div>
    <div class="content vote">
        <asp:DataList ID="DataListSellOrder" runat="server" RepeatColumns="1" Width="100%"
            BorderWidth="0">
            <ItemTemplate>
                <table id="Link" width="100%" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            <a href='<%# ShopUrlOperate.RetUrl("ProductDetail",((DataRowView)Container.DataItem).Row["ProductGuid"]) %>'
                                target="_blank">
                                <%-- <a href='AnnouncementDetail.aspx?guid=<%# DataBinder.Eval(Container.DataItem,"Guid") %>'   target="_blank"> --%>
                                <%# ((DataRowView)Container.DataItem).Row["Name"]%></a>
                        </td>
                    </tr>
                </table>
            </ItemTemplate>
        </asp:DataList>
    </div>
</div>
