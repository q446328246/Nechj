<%@ Control Language="C#" %>
<%@ Import Namespace="ShopNum1.Common" %>
<%@ Import Namespace="System.Data" %>
<style type="text/css">
    .cagecont li .image a
    {
        border: 1px solid #e7e7e7;
    }
    .cagecont li .image a:hover
    {
        border: 1px solid #A22525;
    }
</style>
<div class="bBox">
    <div class="prduct">
        <ul class="cagecont">
            <asp:Repeater ID="RepeaterData" runat="server">
                <ItemTemplate>
                    <li style="margin-bottom: 10px; _margin-bottom: 0px;">
                        <div style="_width: 177px; text-align: center; overflow: hidden; float: left; _height: 238px;">
                            <p class="image">
                                <a href='<%#ShopUrlOperate.shopHref(((DataRowView)Container.DataItem).Row["Guid"].ToString(),((DataRowView)Container.DataItem).Row["MemLoginID"].ToString() )%>'
                                    style="display: block;">
                                    <asp:Image ID="ImageProduct" runat="server" Height="175" Width="175" Style="" ImageUrl='<%# ((DataRowView)Container.DataItem).Row["ThumbImage"]%>'
                                        onerror="javascript:this.src='/ImgUpload/noImage.gif'" /></a>
                            </p>
                            <p class="flow-ovnt">
                                <span class="cp_title"><a href='<%#ShopUrlOperate.shopHref(((DataRowView)Container.DataItem).Row["Guid"].ToString(),((DataRowView)Container.DataItem).Row["MemLoginID"].ToString() ) %>'
                                    target="_blank" title='<%# ((DataRowView)Container.DataItem).Row["Name"]%>'>
                                    <%# ShopNum1.Common.Utils.GetUnicodeSubString(((DataRowView)Container.DataItem).Row["Name"].ToString(), 14, "")%></a>
                                </span>
                            </p>
                            <p class="flow-ovnt">
                                <span class="yuan">
                                    <%# Globals.MoneySymbol%></span><span class="price"><%# ((DataRowView)Container.DataItem).Row["ShopPrice"]%></span>
                            </p>
                        </div>
                    </li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>
    </div>
</div>
