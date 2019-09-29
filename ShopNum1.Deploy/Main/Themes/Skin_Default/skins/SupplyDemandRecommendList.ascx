<%@ Control Language="C#" %>
<%@ Import Namespace="System.Data" %>
<div class="fl bdsad" style="width: 495px; overflow: hidden;">
    <div class="all_top" style="width: 495px">
        <div style="padding-left: 10px; float: left; color: #000;">
            供应信息推荐</div>
        <div class="fr more1" style="font-weight: normal;">
            <a href="" id="Href" runat="server">我要发布>></a></div>
    </div>
    <div class="rool_detail fl" style="width: 495px; text-align: left'">
        <table width="485" border="0" cellspacing="0" cellpadding="0">
            <asp:Repeater ID="RepeaterData" runat="server">
                <ItemTemplate>
                    <tr>
                        <td width="230">
                            <span class=" yellow3">【<%#((DataRowView)Container.DataItem).Row["Name"]%>】</span><a
                                href='<%#ShopUrlOperate.RetUrl("SupplyDemandDetail",((DataRowView)Container.DataItem).Row["Guid"])%>'
                                target="_blank" title='<%#((DataRowView)Container.DataItem).Row["Title"] %>'>
                                <%# ShopNum1.Common.Utils.GetUnicodeSubString(((DataRowView)Container.DataItem).Row["Title"].ToString(), 20, "")%></a>
                        </td>
                </ItemTemplate>
                <AlternatingItemTemplate>
                    <td width="230">
                        <span class="yellow3">【<%#((DataRowView)Container.DataItem).Row["Name"]%>】</span><a
                            href='<%# ShopUrlOperate.RetUrl("SupplyDemandDetail",((DataRowView)Container.DataItem).Row["Guid"])%>'
                            target="_blank" title="<%#((DataRowView)Container.DataItem).Row["Title"] %>">
                            <%# ShopNum1.Common.Utils.GetUnicodeSubString(((DataRowView)Container.DataItem).Row["Title"].ToString(), 20, "")%></a>
                    </td>
                    </tr>
                </AlternatingItemTemplate>
            </asp:Repeater>
        </table>
    </div>
</div>
