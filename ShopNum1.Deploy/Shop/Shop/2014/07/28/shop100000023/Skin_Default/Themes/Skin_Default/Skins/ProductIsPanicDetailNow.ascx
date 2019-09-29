<%@ Control Language="C#" EnableViewState="false"%>
<%@ Import Namespace="ShopNum1.ShopWebControl" %>
<%@ Import Namespace="System.Data " %>
<%@ Import Namespace="ShopNum1.Common" %>
<div class="dateil_left">
    <h5>本期热门团购</h5>
    <asp:Repeater ID="RepeaterData" runat="server">
        <ItemTemplate>
            <div class="dateil_con1">
                <div class="dateil_list">
                    <div class="img">
                        <a  href='<%# GetPageName.RetUrl("ProductIsSpell_Detail",Eval("id"))%>' target="_blank">
                           <asp:Image ID="ImageProduct" runat="server" BorderWidth="0px" Height="150px" ImageUrl='<%# Eval("OriginalImage") %>'
                                        onerror="javascript:this.src='Themes/Skin_Default/Images/noImage.gif'" Width="218px" />
                                        </a>
                    </div>
                    <p>
                        <a href='<%# GetPageName.RetUrl("ProductIsSpell_Detail",Eval("id"))%>' style="margin:0 0 5px;" target="_blank">
                           <%# Utils.GetUnicodeSubString(Eval("Name").ToString(), 25, "")%></a>
                    </p>
                    <div class="jiage kan">
                        <i style="width:80px;">￥<%# Eval("ShopPrice")%></i>原价：<del><%# Eval("MarketPrice")%></del>
                        <a href='<%# GetPageName.RetUrl("ProductIsSpell_Detail",Eval("guid"))%>'class=""></a>
                        已售：<font color="green"><%# Eval("groupcount")%></font>
                    </div>
                    <div class="clear"></div>
                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</div>
