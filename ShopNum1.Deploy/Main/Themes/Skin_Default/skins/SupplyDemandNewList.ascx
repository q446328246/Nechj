<%@ Control Language="C#" %>
<%@ Import Namespace="System.Data" %>
<div class="roll_news">
    <div class="all_top">
        <div style="padding-left: 10px; float: left; color: #000;">
            供求最新</div>
        <div class="fr more1" style="font-weight: normal;">
            <a href="" id="Href" runat="server">我要发布>></a></div>
    </div>
    <div class="rool_detail fl">
        <table width="640px" class="fl" border="0" cellspacing="0" cellpadding="0">
            <asp:Repeater ID="RepeaterData" runat="server">
                <ItemTemplate>
                    <tr>
                        <td width="20">
                            <div align="center">
                                <img src="Themes/Skin_Default/Images/ico_quote.gif" /></div>
                        </td>
                        <td width="220">
                            <span class=" yellow3">【<%#((DataRowView)Container.DataItem).Row["Name"]%>】</span><a
                                href='<%#ShopUrlOperate.RetUrl("SupplyDemandDetail",((DataRowView)Container.DataItem).Row["Guid"])%>'
                                target="_blank" title='<%#((DataRowView)Container.DataItem).Row["Title"] %>'>
                                <%# ShopNum1.Common.Utils.GetUnicodeSubString(((DataRowView)Container.DataItem).Row["Title"].ToString(),20,"")%></a>
                        </td>
                        <td width="80">
                            <div align="right">
                                <div align="right">
                                    <%#Convert.ToDateTime(((DataRowView)Container.DataItem).Row["ReleaseTime"]).ToString("yyyy-MM-dd")%></div>
                            </div>
                        </td>
                </ItemTemplate>
                <AlternatingItemTemplate>
                    <td width="20">
                        <div align="center">
                            <img src="Themes/Skin_Default/Images/ico_quote.gif" /></div>
                    </td>
                    <td width="220">
                        <span class=" yellow3">【<%#((DataRowView)Container.DataItem).Row["Name"]%>】</span><a
                            href='<%#ShopUrlOperate.RetUrl("SupplyDemandDetail",((DataRowView)Container.DataItem).Row["Guid"])%>'
                            target="_blank" title='<%#((DataRowView)Container.DataItem).Row["Title"] %>'>
                            <%# ((DataRowView)Container.DataItem).Row["Title"].ToString().Length <= 10 ? ((DataRowView)Container.DataItem).Row["Title"].ToString() : ((DataRowView)Container.DataItem).Row["Title"].ToString().Substring(0, 10)%></a>
                    </td>
                    <td width="80">
                        <div align="right">
                            <div align="right">
                                <%#Convert.ToDateTime(((DataRowView)Container.DataItem).Row["ReleaseTime"]).ToString("yyyy-MM-dd")%></div>
                        </div>
                    </td>
                    </tr>
                </AlternatingItemTemplate>
            </asp:Repeater>
        </table>
        <div class="fr adv4">
            <div style="padding-top: 10px">
                <object classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" codebase=" http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=9,0,28,0"
                    width="280" height="122">
                    <param name="movie" value="Themes/Skin_Default/Images/menu11.swf" />
                    <param name="quality" value="high" />
                    <param name="wmode" value="transparent" />
                    <embed src="Themes/Skin_Default/Images/menu11.swf" quality="high" wmode="transparent"
                        pluginspage=" http://www.adobe.com/shockwave/download/download.cgi?P1_Prod_Version=ShockwaveFlash"
                        type="application/x-shockwave-flash" width="280" height="122"></embed>
                </object>
            </div>
            <div style="padding-top: 15px; text-align: center">
                <ShopNum1:AdSimpleImage ID="AdSimpleImage3" runat="server" AdImgId="33" SkinFilename="AdSimpleImage.ascx" />
            </div>
        </div>
    </div>
</div>
