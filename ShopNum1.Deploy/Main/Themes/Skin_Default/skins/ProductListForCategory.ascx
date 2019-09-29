<%@ Control Language="C#" %>
<%@ Import Namespace="ShopNum1.Common" %>
<%@ Import Namespace="System.Data" %>
<div class="bBox">
    <div class="prduct">
        <ul class="cagecont">
            <asp:Repeater ID="RepeaterData" runat="server">
                <ItemTemplate>
                    <li>
                        <p class="image">
                            <a href='<%#ShopUrlOperate.shopHref(((DataRowView)Container.DataItem).Row["Guid"].ToString(),((DataRowView)Container.DataItem).Row["MemLoginID"].ToString() )%>?category=2'
                                target="_blank">
                                <asp:Image ID="ImageProduct" runat="server" ImageUrl='<%# ((DataRowView)Container.DataItem).Row["ThumbImage"]+"_160x160.jpg"%> '
                                    onerror="javascript:this.src='/ImgUpload/noimg.jpg_160x160.jpg'" /></a>
                        </p>
                        <p class="flow-ovnt">
                            <span class="cp_title"><a href='<%#ShopUrlOperate.shopHref(((DataRowView)Container.DataItem).Row["Guid"].ToString(),((DataRowView)Container.DataItem).Row["MemLoginID"].ToString() ) %>?category=2'
                                target="_blank" title='<%# ((DataRowView)Container.DataItem).Row["Name"]%>'>
                                <%# ShopNum1.Common.Utils.GetUnicodeSubString(((DataRowView)Container.DataItem).Row["Name"].ToString(), 100, "")%></a>
                            </span>
                        </p>
                        <p class="flow-ovnt">
                            <span class="yuan">
                                <%# Globals.MoneySymbol%></span> <span class="price">
                                    <%# ((DataRowView)Container.DataItem).Row["ShopPrice"]%></span>&nbsp;<span style="width: 50px;
                                        text-align: right;"><del><%# ((DataRowView)Container.DataItem).Row["MarketPrice"]%></del></span>
                        </p>
                    </li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>
    </div>
</div>
