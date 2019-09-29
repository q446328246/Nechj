<%@ Control Language="C#" %>
<div class="fqa" style="padding-top: 10px;">
    <div class="fqa_top">
        <img src="Themes/Skin_Default/Images/title_hotcoupon.gif" /></div>
    <div class="fqa_detail rqph">
        <ul>
            <asp:Repeater ID="RepeaterDate" runat="server">
                <ItemTemplate>
                    <li><a href='<%# ShopUrlOperate.shopDetailHrefByShopID(Eval("Guid").ToString(),Eval("shopID").ToString(),"Coupon") %>' target="_blank">
                        <asp:Literal ID="Literal1" Text='<%#Eval("SaleTitle") %>' runat="server"></asp:Literal></a></li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>
    </div>
</div>
