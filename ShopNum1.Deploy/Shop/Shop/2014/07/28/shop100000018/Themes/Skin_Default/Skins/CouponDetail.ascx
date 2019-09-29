<%@ Control Language="C#" EnableViewState="false"%>
<!-- 优惠券 -->
<div class="bBox">
    <h2 class="stitle">优惠券</h2>
    <div class="coupon_cont clearfix">
        <div class="coupon_imgs">
            <div class="coupon_icons">
                <img height="88" width="88" id="imgIsEffective" runat="server" src="../Images/advids.png" />
            </div>
            <div class="coupon_gods">
                <img id="CouponImg" runat="server" src="" />
            </div>
        </div>
        <div class="coupon_detail">
            <p class="dogst">
                在您之前已有<span class="horsehoe"><asp:Literal ID="LiteralBrowserCount" Text="0" runat="server"></asp:Literal></span>人浏览，
                打印了<span class="horsehoe aerosite"><asp:Literal ID="LiteralDownloadCount" runat="server"></asp:Literal></span>份
            </p>
            <div class="dy_detail">
                <div class="dy_detail_fl fl">
                    <div class="dy_zx">选择打印张数->点击预览并确认打印</div>
                    <asp:DropDownList ID="DropDownListPrint" Width="200px" runat="server">
                        <asp:ListItem Selected="True" Value="1">1张</asp:ListItem>
                        <asp:ListItem Value="2">2张</asp:ListItem>
                        <asp:ListItem Value="3">3张</asp:ListItem>
                        <asp:ListItem Value="4">4张</asp:ListItem>
                        <asp:ListItem Value="5">5张</asp:ListItem>
                        <asp:ListItem Value="6">6张</asp:ListItem>
                        <asp:ListItem Value="7">7张</asp:ListItem>
                        <asp:ListItem Value="8">8张</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="dy_detail_fr fr">
                    <asp:ImageButton ID="ImageButton" ImageUrl="../Images/bt1.jpg" runat="server" />
                </div>
            </div>
        </div>
    </div>
</div>
<!-- 活动详情 -->
<div class="hd_de diagram">
    <div class="hd_de_top">
        <div class="hd_de_topli">活动详情</div>
    </div>
    <asp:Repeater ID="RepeaterDetail" runat="server">
        <ItemTemplate>
            <div class="hd_de_lr">
                <span class="font_b pigst">优惠券名称：</span><span class="mauve pigst"><%# Eval("CouponName")%></span><br />
                <span class="font_b pigst">有&nbsp;&nbsp;&nbsp;效&nbsp;&nbsp;&nbsp;期：</span> <span class="aerosite">
                    <%# Convert.ToDateTime(Eval("StartTime").ToString()).ToString("yyyy-MM-dd")%>
                </span>至 <span class="aerosite">
                    <%# Convert.ToDateTime(Eval("EndTime").ToString()).ToString("yyyy-MM-dd")%>
                </span>
                <br />
                <span class="font_b pigst">发&nbsp;&nbsp;&nbsp;布&nbsp;&nbsp;&nbsp;者：</span> <span class="mauve pigst">
                    <%# Eval("MemLoginID")%></span>
                <br />
                <span class="font_b pigst" style="text-align: right">发&nbsp;布&nbsp;日&nbsp;期&nbsp;：</span> <span class="mauve pigst">
                    <%# Convert.ToDateTime(Eval("CreateTime").ToString()).ToString("yyyy-MM-dd")%></span>
                <br />
                <span class="font_b pigst" style="text-align: right">活&nbsp;动&nbsp;详&nbsp;情&nbsp;：</span>
                <span class="hdjs pigst">
                    <%# Server.HtmlDecode(Eval("Content").ToString())%>
                </span>
            </div>
        </ItemTemplate>
    </asp:Repeater>
    <asp:HiddenField ID="HiddenFieldGuid" runat="server" />
</div>
