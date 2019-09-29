<%@ Control Language="C#" %>
<%@ Import Namespace="ShopNum1.WebControl" %>
<%@ Import Namespace="System.Data " %>

<script type="text/javascript">
function hotOrNew(resutl,element)
{
    if(resutl=="0")
    {
        $("#"+element).append("<i></i>")
    }
    if(resutl=="1")
    {
        $("#"+element).append("<i class=\"yh01\"></i>");
    }
    if(resutl=="2")
    {
        $("#"+element).append("<i class=\"yh02\"></i>");
    }
}
</script>
<div class="youhuihd">
    <h1 class="yhti">优惠活动</h1>
    <div class="youhuili clearfix">
        <ul>
            <asp:Repeater ID="RepeaterData" runat="server">
                <ItemTemplate>
                    <li>
                        <span class="hui"></span>
                        <a id="divClass<%#Container.ItemIndex+1%>" href='<%# ShopUrlOperate.shopDetailHrefByShopID(Eval("Guid").ToString(),Eval("shopID").ToString(),"Coupon") %>' class="huiwei">
                        <%#Eval("SaleTitle") %>

                        <script> hotOrNew('<%# CouponsList.check(Eval("IsHot"), Eval("IsNew"))%>',"divClass<%#Container.ItemIndex+1%>")</script>

                        </a>
                        <div class="clear"></div>
                    </li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>
    </div>
</div>
