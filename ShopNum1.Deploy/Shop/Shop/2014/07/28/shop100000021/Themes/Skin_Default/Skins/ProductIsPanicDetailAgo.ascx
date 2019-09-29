<%@ Control Language="C#" EnableViewState="false"%>
<%@ Import Namespace="ShopNum1.ShopWebControl" %>
<%@ Import Namespace="System.Data " %>
<%@ Import Namespace="ShopNum1.Common" %>
<div class="dateil_left">
    <h5>往期热门团购</h5>
    <asp:Repeater ID="RepeaterData" runat="server">
        <ItemTemplate>
            <div class="dateil_con1">
                <div class="dateil_list">
                    <div class="img">
                        <a  href='<%# GetPageName.RetUrl("ProductIsSpell_Detail",Eval("guid"))%>' target="_blank">
                           <asp:Image ID="ImageProduct" runat="server" BorderWidth="0px" Height="150px" ImageUrl='<%# Eval("OriginalImage") %>'
                                        onerror="javascript:this.src='Themes/Skin_Default/Images/noImage.gif'" Width="218px" />
                    </div>
                    <p>
                        <a  href='<%# GetPageName.RetUrl("ProductIsSpell_Detail",Eval("guid"))%>'  target="_blank">
                           <%# Utils.GetUnicodeSubString(Eval("Name").ToString(), 25, "")%></a>
                    </p>
                    <div class="jiage kan">
                        <i>￥<%# Eval("SpellPrice")%></i>
                        <a href='<%# GetPageName.RetUrl("ProductIsSpell_Detail",Eval("guid"))%>'class="qukan"></a>
                    </div>
                    <div class="clear"></div>
                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</div>
