<%@ Control Language="C#" %>
<%@ Import Namespace="System.Data" %>
<div class="nsnp_de_dp nsnp_de_dp2">
    <asp:Repeater ID="RepeaterData" runat="server">
        <ItemTemplate>
            <div class="ranking_list ranking_list2 fl">
                <div class="ranking_img fl" style="height: 60px; width: 60px;">
                    <a href="<%#ShopUrlOperate.GetShopUrl(((DataRowView)Container.DataItem).Row["ShopID"].ToString())%>">
                        <asp:Image Image ID="Img1" Width="60" Height="60" runat="server" ImageUrl='<%# ((DataRowView)Container.DataItem).Row["Banner"]%>'
                            onerror="javascript:this.src='../ImgUpload/noImage.gif'" /></a></div>
                <div class="ranking_detail ranking_detail2 fr">
                    店铺：<span class="blue blue2"><a href='<%#ShopUrlOperate.GetShopUrl(((DataRowView)Container.DataItem).Row["ShopID"].ToString())%>'
                        target="_blank" title='<%# ((DataRowView)Container.DataItem).Row["ShopName"] %>'><%# ShopNum1.Common.Utils.GetUnicodeSubString(((DataRowView)Container.DataItem).Row["ShopName"].ToString(),18,"")%></a></span><br />
                    信用：<asp:Image ID="ImageReputation" runat="server" /></div>
            </div>
            <asp:HiddenField ID="HiddenFieldReputation" runat="server" Value='<%# ((DataRowView)Container.DataItem).Row["ShopReputation"]%>' />
        </ItemTemplate>
    </asp:Repeater>
</div>
