<%@ Control Language="C#" %>
<%@ Import Namespace="System.Data" %>
<div class="rec_shop">
    <div class="all_top">
        <div style="padding-left: 10px; float: left; color: #000;">
            推荐店铺</div>
        <div class="fr more1" style="font-weight: normal;">
            <a href="javascript:void(0)"></a>
        </div>
    </div>
    <asp:Repeater ID="RepeaterData" runat="server">
        <ItemTemplate>
            <div class="ranking_list cle">
                <div class="ranking_img fl" style="height: 60px">
                    <a href="<%#ShopUrlOperate.GetShopUrl(((DataRowView)Container.DataItem).Row["ShopID"].ToString())%>">
                        <asp:Image ID="Img1" ImageUrl='<%# ((DataRowView)Container.DataItem).Row["Banner"]%>'
                            runat="server" alt="图片" onerror="javascript:this.src='../ImgUpload/noImage.gif'"
                            Width="70" Height="60" /></a></div>
                <div class="ranking_detail fr">
                    店铺：<span class="blue" style="white-space: nowrap"><a href='<%#ShopUrlOperate.GetShopUrl(((DataRowView)Container.DataItem).Row["ShopID"].ToString())%>'
                        target="_blank" title='<%# ((DataRowView)Container.DataItem).Row["ShopName"] %>'><%# ShopNum1.Common.Utils.GetUnicodeSubString(((DataRowView)Container.DataItem).Row["ShopName"].ToString(),16,"")%></a></span><br />
                    <span class="blue1" style="white-space: nowrap">宝贝：<asp:Repeater ID="RepeaterProduct"
                        runat="server">
                        <ItemTemplate>
                            <a title='<%#((DataRowView)Container.DataItem).Row["Name"]%>' href='<%#ShopUrlOperate.shopHref(((DataRowView)Container.DataItem).Row["Guid"].ToString(),((DataRowView)Container.DataItem).Row["MemLoginID"].ToString() )%>'
                                target="_blank" title='<%#((DataRowView)Container.DataItem).Row["Name"]%>'>
                                <%#((DataRowView)Container.DataItem).Row["Name"]%></a>
                        </ItemTemplate>
                    </asp:Repeater>
                        <span id="spanMemLoginID" runat="server" visible="false">
                            <%# ((DataRowView)Container.DataItem).Row["MemLoginID"]%></span></span><br />
                    信用：<asp:Image ID="ImageReputation" runat="server" /></div>
            </div>
            <asp:HiddenField ID="HiddenFieldReputation" runat="server" Value='<%# ((DataRowView)Container.DataItem).Row["ShopReputation"]%>' />
        </ItemTemplate>
    </asp:Repeater>
</div>
