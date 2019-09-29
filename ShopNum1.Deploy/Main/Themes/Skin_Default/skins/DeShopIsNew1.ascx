<%@ Control Language="C#" %>
<%@ Import Namespace="System.Data" %>
<asp:Repeater ID="RepeaterData" runat="server">
    <ItemTemplate>
        <div class="ranking_list cle">
            <div class="ranking_img fl" style="display: none;">
                <a href="<%#ShopUrlOperate.GetShopUrl(((DataRowView)Container.DataItem).Row["ShopID"].ToString())%>">
                    <asp:Image Width="70" Height="71" runat="server" ImageUrl='<%# ((DataRowView)Container.DataItem).Row["Banner"]%>'
                        onerror="javascript:this.src='../ImgUpload/noImage.gif'" /></a></div>
            <div class="ranking_detail">
                <span class="blue"><a style="color: #333;" href='<%#ShopUrlOperate.GetShopUrl(((DataRowView)Container.DataItem).Row["ShopID"].ToString())%>'
                    target="_blank">
                    <%# ((DataRowView)Container.DataItem).Row["Name"].ToString().Length <= 10 ? ((DataRowView)Container.DataItem).Row["ShopName"] : ((DataRowView)Container.DataItem).Row["ShopName"].ToString().Substring(0, 10)%></a></span><br />
                <div>
                    <span class="blue1">主营<asp:Repeater ID="RepeaterProduct" runat="server">
                        <ItemTemplate>
                            <a style="color: #333;" href='<%#ShopUrlOperate.shopHref(((DataRowView)Container.DataItem).Row["Guid"].ToString(),((DataRowView)Container.DataItem).Row["MemLoginID"].ToString() )%>'>
                                <%#((DataRowView)Container.DataItem).Row["Name"]%></a>
                        </ItemTemplate>
                    </asp:Repeater>
                        <span id="spanMemLoginID" runat="server" visible="false">
                            <%# ((DataRowView)Container.DataItem).Row["MemLoginID"]%></span></span></div>
                <asp:Repeater ID="RepeaterImg" runat="server">
                    <ItemTemplate>
                        <img id="EnsureImg" alt="图片" width="16" height="17" src='<%#((DataRowView)Container.DataItem).Row["ImagePath"] %>'
                            runat="server" />
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </ItemTemplate>
</asp:Repeater>
