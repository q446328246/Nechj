<%@ Control Language="C#" %>
<%@ Import Namespace="ShopNum1.Common" %>
<%@ Import Namespace="System.Data" %>
<style type="text/css">
    .prduct1 ul li .image a
    {
        border: 1px solid #e7e7e7;
    }
    .prduct1 ul li .image a:hover
    {
        border: 1px solid #A22525;
    }
</style>
<div class="bBox1">
    <div class="prduct1">
        <ul style="height: 445px; overflow: hidden; _height: 550px;">
            <asp:Repeater ID="RepeaterData" runat="server">
                <ItemTemplate>
                    <li style="margin-bottom: 9px; _margin-bottom: 12px;">
                        <p class="image">
                            <a href='<%#ShopUrlOperate.shopHref(((DataRowView)Container.DataItem).Row["Guid"].ToString(),((DataRowView)Container.DataItem).Row["MemLoginID"].ToString() )%>'
                                style="display: block;">
                                <asp:Image ID="ImageProduct" runat="server" Height="175" Width="175" Style="" ImageUrl='<%# ((DataRowView)Container.DataItem).Row["ThumbImage"]%>'
                                    onerror="javascript:this.src='/ImgUpload/noImage.gif'" /></a>
                        </p>
                        <p class="flow-ovnt" style="padding-top: 5px;">
                            <span class="prdcname"><a href='<%#ShopUrlOperate.shopHref(((DataRowView)Container.DataItem).Row["Guid"].ToString(),((DataRowView)Container.DataItem).Row["MemLoginID"].ToString() ) %>'
                                target="_blank" title='<%# ((DataRowView)Container.DataItem).Row["Name"]%>'>
                                <%# ShopNum1.Common.Utils.GetUnicodeSubString(((DataRowView)Container.DataItem).Row["Name"].ToString(), 14, "")%></a>
                            </span>
                        </p>
                        <p class="flow-ovnt" style="padding-top: 0px;">
                            <span class="yuan">
                                <%# Globals.MoneySymbol%></span><span class="price"><%# ((DataRowView)Container.DataItem).Row["ShopPrice"]%></span>
                        </p>
                        <%--  <p class="flow-ovnt" style="margin-bottom: 4px;">
                            <span class="prdcorder"><a href='<%#ShopUrlOperate.shopHref(((DataRowView)Container.DataItem).Row["Guid"].ToString(),((DataRowView)Container.DataItem).Row["MemLoginID"].ToString() ) %>'>
                                查看详情</a></span> <span class="prdcorder"><a href='<%#ShopUrlOperate.shopHref(((DataRowView)Container.DataItem).Row["Guid"].ToString(),((DataRowView)Container.DataItem).Row["MemLoginID"].ToString() )%>'
                                    target="_blank">加入购物车</a></span>
                        </p>--%>
                    </li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>
    </div>
</div>
