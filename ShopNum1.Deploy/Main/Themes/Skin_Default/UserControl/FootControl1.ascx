<%@ Control Language="C#" AutoEventWireup="true" %>
<%@ OutputCache Duration="600" Shared="true" VaryByParam="none" %>
<%--友情图片连接--%>
<ShopNum1:LinkListImage ID="LinkListImage" runat="server" ShowCount="10" SkinFilename="LinkListImage.ascx" />
<!--底部导航-->
<div id="footer">
    <div class="copyright">
        <div id="DivButtomNavigation" style="display: none;">
            <%--<ShopNum1:ButtomNavigation ID="ButtomNavigation" ShowCount="6" runat="server" SkinFilename="ButtomNavigation2.ascx" style="display:none;" />--%>
        </div>
        <ShopNum1:DomainCopyright ID="DomainCopyright" runat="server" SkinFilename="DomainCopyright.ascx" />
        <!-- bottom -->
        <%--<center>
    <div style="clear: both; height: 8px; overflow: hidden;">
    </div>
    <ShopNum1:Bazs ID="Bazs" runat="server" SkinFilename="Bazs.ascx" />
</center>--%>
    </div>
</div>
<%--<ShopNum1:OnLineService ID="OnLineService" runat="server" SkinFilename="OnLineService.ascx"  ShowCount="5"/>--%>
