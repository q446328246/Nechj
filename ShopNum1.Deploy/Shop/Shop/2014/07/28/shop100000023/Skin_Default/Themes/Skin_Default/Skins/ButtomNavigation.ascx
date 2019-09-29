<%@ Control Language="C#" EnableViewState="false"%>
<%@ Import Namespace="ShopNum1.ShopWebControl" %>
<%@ Import Namespace="System.Data" %>
<!-- bottom -->
<div style="clear: both; width: 950px; text-align: center; margin: 0 auto; border-top: 1px solid #CCC;padding-top: 8px; line-height: 30px;">
    <div class="bottom_link">
        <asp:Repeater ID="RepeaterData" runat="server">
            <ItemTemplate>
                <a href='<%#ShopUrlOperate.RetUrl(((DataRowView)Container.DataItem).Row["LinkAddress"].ToString()) %>'
                    target='<%# ButtomNavigation.ShowIsOpen( ((DataRowView)Container.DataItem).Row["IfOpen"].ToString())%>'>
                    <%# ((DataRowView)Container.DataItem).Row["Name"]%></a>
                <asp:Label ID="LabelSpilt" runat="server" Text="|"></asp:Label>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</div>
