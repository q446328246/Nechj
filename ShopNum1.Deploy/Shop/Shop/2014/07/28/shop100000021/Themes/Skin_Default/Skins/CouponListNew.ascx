<%@ Control Language="C#" %>
<!-- 优惠券列表 -->
<div class="bBox bBoxnt">
    <h2>最新优惠券</h2>
    <div class="content privil_img clearfix">
        <div class="privil_cod fl">
            <asp:Panel ID="PanelNoFind" runat="server" Visible="false">
                <p class="nofind">没有找到符合条件的优惠劵！</p> 
            </asp:Panel>
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
                            人气：<span class="moodsn"><%# Eval("BrowserCount")%></span>
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
<!--分页-->
<div class="fenye">
    <div class="lambert">
        <table cellpadding="0" cellspacing="0" border="0">
            <tr>
                <td><span class="fenye1">共</span></td>
                <td><span><asp:Label ID="LabelPageCount" runat="server" Text=""></asp:Label></span></td>
                <td><span class="fenye2">页，到第</span></td>
                <td><asp:TextBox ID="TextBoxIndex" runat="server" CssClass="pro_input"></asp:TextBox></td>
                <td class="fenye_td1"><span class="fenye3">页</span></td>
                <td class="fenye_td2"><asp:Button ID="ButtonSure" runat="server" Text="Button" CssClass="pro_btn" /></td>
            </tr>
        </table>
    </div>
    <div id="pageDiv" runat="server" class="pro_page">
        <div class="black2 " style="float: right; width: 210px; text-align: right;">
            <span class="disabled">< </span><span class="current">1</span><a href="#?page=2">2</a><span
                class="diandian">...</span> <a href="#?page=200">200</a> <a href="#?page=2">></a>
        </div>
    </div>
</div>
