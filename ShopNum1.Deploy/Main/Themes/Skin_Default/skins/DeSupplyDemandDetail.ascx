<%@ Control Language="C#" %>
<%@ Import Namespace="System.Data" %>
<ShopNum1:SupplyDemandAds ID="SupplyDemandAds" runat="server" SkinFilename="SupplyDemandAds.ascx"
    AdvID="ad2" />
<div class="supply_demand_right fr">
    <div class="supply_demand_right_top">
        <span class="boldfont"><a href="javascript:void(0)">· 2011夏天变身法式优雅</a> <a href="javascript:void(0)">
            · 美女抢眼睛搭配！平日也要度假风</a></span><br />
        <a href="javascript:void(0)">· 甜辣小妖精穿出妩媚S线</a> <a href="javascript:void(0)">· 6天造无敌美腿</a>
        <a href="javascript:void(0)">· 夏日清凉白色衣怎么穿不单调</a>
    </div>
    <div class="supply_demand_right_middle cle" style="float: left; clear: both;">
        <div class="supply_demand_right_middle_leftlist fl">
            <ul>
                <asp:Repeater ID="RepeaterData1" runat="server">
                    <ItemTemplate>
                        <li>· <a href='<%#ShopUrlOperate.RetUrl("SupplyDemandDetail",((DataRowView)Container.DataItem).Row["Guid"])%>'
                            target="_blank" title='<%#((DataRowView)Container.DataItem).Row["Title"] %>'>
                            <%# ShopNum1.Common.Utils.GetUnicodeSubString(((DataRowView)Container.DataItem).Row["Title"].ToString(),32,"")%></a></li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
        </div>
        <div class="supply_demand_right_middle_leftlist fr">
            <ul>
                <asp:Repeater ID="RepeaterData2" runat="server">
                    <ItemTemplate>
                        <li>·<a href='<%#ShopUrlOperate.RetUrl("SupplyDemandDetail",((DataRowView)Container.DataItem).Row["Guid"])%>'
                            target="_blank" title='<%#((DataRowView)Container.DataItem).Row["Title"] %>'><%# ShopNum1.Common.Utils.GetUnicodeSubString(((DataRowView)Container.DataItem).Row["Title"].ToString(),32,"")%></a></li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
        </div>
    </div>
    <div class="supply_demand_right_bottom cle fl">
        <div class="dpkt" style="clear: both;">
            <div class="dpkt_top fl">
                <span class="fl red">搭配课堂</span> <span class="fr"></span>
            </div>
            <div class="supply_demand_right_middle_leftlist fl" style="width: 200px;">
                <ul>
                    <asp:Repeater ID="RepeaterData3" runat="server">
                        <ItemTemplate>
                            <li>·<a href='<%#ShopUrlOperate.RetUrl("SupplyDemandDetail",((DataRowView)Container.DataItem).Row["Guid"])%>'
                                target="_blank" title='<%# ((DataRowView)Container.DataItem).Row["Title"] %>'><%# ShopNum1.Common.Utils.GetUnicodeSubString(((DataRowView)Container.DataItem).Row["Title"].ToString(),30,"")%></a></li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
            </div>
            <div class="fr dpkt_img">
                <a href="javascript:void(0)">
                    <img width="76" height="120" src="Themes/Skin_Default/Images/newsimg4.jpg" /></a><br />
                <div class="dpkt_img_title">
                    <a href="javascript:void(0)">森林系</a></div>
            </div>
        </div>
        <div class="cldp fr">
            <div class="cldp_top fl">
                <span class="fl red">流行单品</span> <span class="fr"></span>
            </div>
            <div class="fl dpkt_img">
                <a href="javascript:void(0)">
                    <img width="76" height="120" src="Themes/Skin_Default/Images/newsimg5.jpg" /></a><br />
                <div class="dpkt_img_title">
                    <a href="javascript:void(0)">牛仔搭配</a></div>
            </div>
            <div class="fr dpkt_img">
                <a href="javascript:void(0)">
                    <img width="76" height="120" src="Themes/Skin_Default/Images/newsimg6.jpg" /></a><br />
                <div class="dpkt_img_title">
                    <a href="javascript:void(0)">时尚世博</a></div>
            </div>
        </div>
    </div>
</div>
