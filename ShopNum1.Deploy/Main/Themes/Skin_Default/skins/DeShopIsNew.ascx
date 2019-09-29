<%@ Control Language="C#" %>
<%@ Import Namespace="System.Data" %>
<asp:Repeater ID="RepeaterData" runat="server">
    <ItemTemplate>
        <div class="ranking_list cle">
            <div class="ranking_img fl">
                <a href="<%#ShopUrlOperate.GetShopUrl(((DataRowView)Container.DataItem).Row["ShopID"].ToString())%>">
                    <asp:Image Width="70" Height="71" runat="server" ImageUrl='<%# ((DataRowView)Container.DataItem).Row["Banner"]%>'
                        onerror="javascript:this.src='../ImgUpload/noImage.gif'" /></a></div>
            <div class="ranking_detail fr" style="height:66px; overflow:hidden">
                <span class="blue"><a href='<%#ShopUrlOperate.GetShopUrl(((DataRowView)Container.DataItem).Row["ShopID"].ToString())%>'
                    target="_blank">
                    <%#ShopNum1.Common.Utils.GetUnicodeSubString(((DataRowView)Container.DataItem).Row["Name"].ToString(),20,"")%></a></span><br />
               <div style="height:35px; overflow:hidden;"> <span class="blue1">主营宝贝<asp:Repeater ID="RepeaterProduct" runat="server">
                    <ItemTemplate>
                        <a href='<%#ShopUrlOperate.shopHref(((DataRowView)Container.DataItem).Row["Guid"].ToString(),((DataRowView)Container.DataItem).Row["MemLoginID"].ToString() )%>'>
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
