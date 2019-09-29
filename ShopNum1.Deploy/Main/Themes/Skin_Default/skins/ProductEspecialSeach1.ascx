<%@ Control Language="C#" %>
<%@ Import Namespace="ShopNum1.Common" %>
<%@ Import Namespace="System.Data" %>
<ul>
    <asp:Repeater ID="RepeaterData" runat="server">
        <ItemTemplate>
            <a style="display: none;" href='<%#ShopUrlOperate.shopHref(((DataRowView)Container.DataItem).Row["Guid"].ToString(),((DataRowView)Container.DataItem).Row["MemLoginID"].ToString() )%>'>
                <asp:Image ID="ImageProduct" runat="server" Height="85px" ImageUrl='<%#ShopUrlOperate.ShopProductImg(((DataRowView)Container.DataItem).Row["ThumbImage"].ToString(), ((DataRowView)Container.DataItem).Row["MemLoginID"].ToString())%>'
                    Width="85px" onerror="javascript:this.src='../ImgUpload/noImage.gif'" /></a>
            <li><a href='<%#ShopUrlOperate.shopHref(((DataRowView)Container.DataItem).Row["Guid"].ToString(),((DataRowView)Container.DataItem).Row["MemLoginID"].ToString() ) %>'
                target="_blank">
                <%# ShopNum1.Common.Utils.GetUnicodeSubString(((DataRowView)Container.DataItem).Row["Name"].ToString(),14,"")%></a>
            </li>
            <span style="display: none;" class="yuan">
                <%# Globals.MoneySymbol%></span><span style="display: none;" class="price"><%# ((DataRowView)Container.DataItem).Row["ShopPrice"]%></span>
        </ItemTemplate>
    </asp:Repeater>
</ul>
