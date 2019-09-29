<%@ Control Language="C#" %>
<!-- 优惠券列表 -->
<div class="bBox bBoxnt">
    <h2>
        最新优惠券
    </h2>
    <div class="content privil_img">
        <div class="privil_cod" style="float: left;">
            <asp:Repeater ID="RepeaterData" runat="server">
                <ItemTemplate>
                    <div class="privilege">
                        <div class="coupon_img">
                            <div class="coupon_icon">
                                <img id="imgIsEffective" runat="server" src="Themes/Skin_Default/Images/ineffect.png"
                                    width="64" height="49" />
                            </div>
                            <div class="coupon_goods">
                                <a href='<%#ShopUrlOperate.shopDetailHref(Eval("Guid").ToString(),Eval("MemLoginID").ToString(),"Coupon") %>'>
                                    <img id="ImgCoupon" runat="server" src="" /></a>
                            </div>
                        </div>
                        <p class="coupon_name">
                            <a href='<%#ShopUrlOperate.shopDetailHref(Eval("Guid").ToString(),Eval("MemLoginID").ToString(),"Coupon") %>'
                                class="yellowfont">
                                <%#ShopNum1.Common.Utils.GetUnicodeSubString(Eval("CouponName").ToString(), 28, "")%></a>
                        </p>
                        <p>
                            人气：<span class="moodsn">10000</span>
                        </p>
                        <p class="sdate">
                            有效期:
                            <%# Convert.ToDateTime(Eval("StartTime").ToString()).ToString("yyyy-MM-dd") %>
                            至
                            <%# Convert.ToDateTime(Eval("EndTime").ToString()).ToString("yyyy-MM-dd") %>
                        </p>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</div>
<div class="turn_page">
    <ul>
        <li><a class="curn" href="#">1</a><a href="#">2</a><a href="#">3</a><a href="#">4</a><a
            href="#">5</a><a class="pluto">...</a><a class="nextpg" href="#">下一页</a><span class="total">共15页</span>
        </li>
        <li class="ont"><span class="fl">到第</span><input type="text" class="txt_word fl" name="textnum" id="textnum" /><span class="fl">页</span><input
            type="button" class="tex_butn fl" id="uidconfire" name="uidconfire" />
        </li>
    </ul>
</div>
