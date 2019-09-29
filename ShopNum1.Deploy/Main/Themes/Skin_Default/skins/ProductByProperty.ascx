<%@ Control Language="C#" %>
<%@ Import Namespace="ShopNum1.Common" %>
<%@ Import Namespace="System.Data" %>
<div class="pro_hot clearfix">
    <span class="hotspan"></span>
    <h3>
        <span class="fl">
       
            <asp:Literal ID="LiteralTitle" runat="server"></asp:Literal></span> <span class="fr">
                <a href="http://shop100000027.bb.qhtj88.com/productsearchlist.aspx?category=1&showstyle=Grid&keywords=&priceStart=&priceEnd=&sort=desc&ordername=salenumber">
                    更多</a></span>
    </h3>
    <div class="hot_lists">
        <ul class="clearfix">
            <asp:Repeater ID="RepeaterData" runat="server">
                <ItemTemplate>
                    <li>
                        <div class="hotimgs">
                            <a href='<%#ShopUrlOperate.shopHref(((DataRowView)Container.DataItem).Row["Guid"].ToString(),((DataRowView)Container.DataItem).Row["MemLoginID"].ToString() )%>?category=1'>
                                <asp:Image ID="Image1" ImageUrl='<%#Page.ResolveUrl(((DataRowView)Container.DataItem).Row["OriginalImage"].ToString())+"_100x100.jpg"%>'
                                    runat="server" onerror="javascript:this.src='../ImgUpload/noimg.jpg_100x100.jpg'" />
                            </a>
                        </div>
                        <div class="hot_name">
                            <a href='<%#ShopUrlOperate.shopHref(((DataRowView)Container.DataItem).Row["Guid"].ToString(),((DataRowView)Container.DataItem).Row["MemLoginID"].ToString() )%>?category=1'
                                title="<%# ((DataRowView)Container.DataItem).Row["Name"].ToString()%>">
                                <%# ShopNum1.Common.Utils.GetUnicodeSubString(((DataRowView)Container.DataItem).Row["Name"].ToString(),28,"")%></a>
                            <p>
                                特价：<b><%# Globals.MoneySymbol%><%# ((DataRowView)Container.DataItem).Row["ShopPrice"]%></b></p>
                            <div class="btnqiang">
                                <a href='<%#ShopUrlOperate.shopHref(((DataRowView)Container.DataItem).Row["Guid"].ToString(),((DataRowView)Container.DataItem).Row["MemLoginID"].ToString() )%>?category=1'>
                                    <input type="button" name="btn" value="立即抢购" class="qiangguo" />
                                </a>
                            </div>
                        </div>
                    </li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>
    </div>
</div>
