<%@ Control Language="C#" %>
<%@ Import Namespace="System.Data" %>
<div class="pro01_adv6 fl">
    <div class="all_top">
        <div class="new_info_title_left fl" style="padding-left: 10px; color: #AE270F; font-size: 14px;">
            <asp:Literal ID="LiteralTitle" runat="server"></asp:Literal></div>
        <div class="new_info_title_right fr">
            <a href="<%=ShopUrlOperate.RetUrl("PanicBuyList")%>">更多>></a></div>
    </div>
    <div class="pro01_qh" style="height: 444px;">
        <asp:Repeater ID="RepeaterData" runat="server">
            <ItemTemplate>
                <div id="linea1" runat="server" onmouseout="ChangeDivHeight(this)" style="height: 30px;
                    overflow: hidden; border-top: 1px dashed #f6ab39;">
                    <div id="linea2" runat="server" style="height: 30px; line-height: 30px; text-align: center;
                        background: #fff">
                        <a href='<%#ShopUrlOperate.shopDetailHref(((DataRowView)Container.DataItem).Row["Guid"].ToString(),((DataRowView)Container.DataItem).Row["MemLoginID"].ToString(),"ProductIsPanic_Detail" )%>'>
                            <%#((DataRowView)Container.DataItem).Row["Name"]%></a></div>
                    <a href='<%#ShopUrlOperate.shopDetailHref(((DataRowView)Container.DataItem).Row["Guid"].ToString(),((DataRowView)Container.DataItem).Row["MemLoginID"].ToString(),"ProductIsPanic_Detail" )%>'>
                        <asp:Image ImageUrl='<%# ((DataRowView)Container.DataItem).Row["OriginalImage"]%>'
                            runat="server" Width="204px" Height="204px" onerror="javascript:this.src='../ImgUpload/noImage.gif'" /></a></div>
            </ItemTemplate>
        </asp:Repeater>
        <!-- adv08 -->
        <div style="clear: both;">
        </div>
        <p class="adv8" style="height: 85px;">
            <ShopNum1:AdSimpleImage ID="AdSimpleImage" runat="server" AdImgId="43" SkinFilename="AdSimpleImage.ascx" />
        </p>
    </div>
</div>
