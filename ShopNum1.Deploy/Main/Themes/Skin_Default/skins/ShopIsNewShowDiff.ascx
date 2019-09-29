<%@ Control Language="C#" %>
<%@ Import Namespace="System.Data" %>
<div class="nsnp">
    <!-- adv08 -->
    <div class="adv9 fr">
        <ShopNum1:AdSimpleImage ID="AdSimpleImage3" runat="server" AdImgId="16" SkinFilename="AdSimpleImage.ascx" />
    </div>
    <div class="nsnp_de" style="float: left;">
        <div class="nsnp_de_newly">
            <ShopNum1:ShopIsNewShow ID="ShopIsNewShow1" runat="server" SkinFilename="ShopIsNewShow.ascx"
                ShowCount="8" />
            <!-- adv10 -->
            <div class="adv10">
                <a href="javascript:void(0)">
                    <img width="192" height="60" src="Themes/Skin_Default/Images/002.jpg" /></a>
            </div>
        </div>
        <div class="nsnp_de_dp">
            <asp:Repeater ID="RepeaterData" runat="server">
                <ItemTemplate>
                    <div class="ranking_list ranking_list2 fl">
                        <div class="ranking_img fl" style="height: 60px; width: 60px;">
                            <a href="<%#ShopUrlOperate.GetShopUrl(((DataRowView)Container.DataItem).Row["ShopID"].ToString())%>">
                                <asp:Image Width="60" Height="60" runat="server" ImageUrl='<%# ((DataRowView)Container.DataItem).Row["Banner"]%>'
                                    onerror="javascript:this.src='../ImgUpload/noImage.gif'" /></a></div>
                        <div class="ranking_detail ranking_detail2 fr">
                            店铺：<span class="blue blue2"><a href='<%#ShopUrlOperate.GetShopUrl(((DataRowView)Container.DataItem).Row["ShopID"].ToString())%>'
                                target="_blank" title='<%# ((DataRowView)Container.DataItem).Row["ShopName"] %>'><%# ShopNum1.Common.Utils.GetUnicodeSubString(((DataRowView)Container.DataItem).Row["ShopName"].ToString(), 18, "")%></a></span><br />
                            信用：<asp:Image ID="ImageReputation" runat="server" /></div>
                    </div>
                    <asp:HiddenField ID="HiddenFieldReputation" runat="server" Value='<%# ((DataRowView)Container.DataItem).Row["ShopReputation"]%>' />
                </ItemTemplate>
            </asp:Repeater>
        </div>
        <!-- advertisement list -->
        <div class="adv_list">
            <div class="adv11">
                <ShopNum1:AdSimpleImage ID="AdSimpleImage1" runat="server" AdImgId="26" SkinFilename="AdSimpleImage.ascx" />
            </div>
            <div class="adv12">
                <ShopNum1:AdSimpleImage ID="AdSimpleImage2" runat="server" AdImgId="27" SkinFilename="AdSimpleImage.ascx" />
            </div>
            <div class="adv13" style="padding-bottom: 0;">
                <ShopNum1:AdSimpleImage ID="AdSimpleImage4" runat="server" AdImgId="28" SkinFilename="AdSimpleImage.ascx" />
            </div>
        </div>
    </div>
</div>
