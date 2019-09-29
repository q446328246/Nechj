<%@ Control Language="C#" %>
<%@ Import Namespace="System.Data" %>
<div class="pro01_adv6 fl">
    <div class="all_top">
        <div class="new_info_title_left fl" style="padding-left: 10px; color: #AE270F; font-size: 14px;">
            <asp:Literal ID="LiteralTitle" runat="server"></asp:Literal></div>
        <div class="new_info_title_right fr">
            <a href="<%=ShopUrlOperate.RetUrl("ProductListSearch")%>">更多>></a></div>
    </div>
    <div class="pro01_qh">
        <asp:Repeater ID="RepeaterData" runat="server">
            <ItemTemplate>
                <div id="linea1" runat="server" onmouseout="ChangeDivHeight(this)" style="height: 30px;
                    overflow: hidden; border-top: 1px dashed #f6ab39;">
                    <div id="linea2" runat="server" style="height: 30px; line-height: 30px; text-align: center;
                        background: #fff">
                        <a href='<%#ShopUrlOperate.shopHref(((DataRowView)Container.DataItem).Row["Guid"].ToString(),((DataRowView)Container.DataItem).Row["MemLoginID"].ToString() )%>'>
                            <%#((DataRowView)Container.DataItem).Row["Name"]%></a></div>
                    <a href='<%#ShopUrlOperate.shopHref(((DataRowView)Container.DataItem).Row["Guid"].ToString(),((DataRowView)Container.DataItem).Row["MemLoginID"].ToString() )%>'>
                        <asp:Image ImageUrl='<%# ((DataRowView)Container.DataItem).Row["OriginalImage"]%>'
                            runat="server" Width="204px" Height="204px" onerror="javascript:this.src='../ImgUpload/noImage.gif'" /></a></div>
            </ItemTemplate>
        </asp:Repeater>
        <!-- adv08 -->
        <div style="clear: both;">
        </div>
        <p class="adv8" style="height: 85px;">
            <%--<img src="Themes/Skin_Default/Images/002.jpg" width="204" height="54" />--%>
            <ShopNum1:AdSimpleImage ID="AdSimpleImage" runat="server" AdImgId="43" SkinFilename="AdSimpleImage.ascx" />
        </p>
    </div>
</div>
