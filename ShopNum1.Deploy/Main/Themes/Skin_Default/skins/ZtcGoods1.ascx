<%@ Control Language="C#" %>
<%@ Import Namespace="ShopNum1.Common" %>
<%@ Import Namespace="System.Data" %>
<div class="pro_hot clearfix">
    <span class="hotspan"></span>
    <h3>
        <asp:Literal ID="LiteralTitle" runat="server"></asp:Literal></h3>
    <div class="hot_lists">
        <ul>
            <asp:Repeater ID="RepeaterData" runat="server">
                <ItemTemplate>
                    <li><a href='<%#ShopUrlOperate.shopHref(((DataRowView)Container.DataItem).Row["ProductGuid"].ToString(),((DataRowView)Container.DataItem).Row["MemberID"].ToString() )%>'
                        class="hotimgs">
                        <asp:Image ID="Image1" ImageUrl='<%# ((DataRowView)Container.DataItem).Row["ZtcImg"].ToString()+"_160x160.jpg"%>'
                            runat="server" Width="92" Height="92" onerror="javascript:this.src='/ImgUpload/noImg.jpg'" /></a>
                        <div class="hot_name">
                            <a href='<%#ShopUrlOperate.shopHref(((DataRowView)Container.DataItem).Row["ProductGuid"].ToString(),((DataRowView)Container.DataItem).Row["MemberID"].ToString() )%>'
                                title="<%# ((DataRowView)Container.DataItem).Row["ZtcName"].ToString()%>">
                                <%# ShopNum1.Common.Utils.GetUnicodeSubString(((DataRowView)Container.DataItem).Row["ZtcName"].ToString(), 28, "")%></a>
                            <p>
                                特价：<b><%# Globals.MoneySymbol%><%# ((DataRowView)Container.DataItem).Row["ProductPrice"]%></b></p>
                            <div class="btnqiang">
                                <a href='<%#ShopUrlOperate.shopHref(((DataRowView)Container.DataItem).Row["ProductGuid"].ToString(),((DataRowView)Container.DataItem).Row["MemberID"].ToString() )%>'>
                                    <input type="button" name="btn" value="立即购买" class="qiangguo" /></a>
                            </div>
                        </div>
                    </li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>
    </div>
</div>
