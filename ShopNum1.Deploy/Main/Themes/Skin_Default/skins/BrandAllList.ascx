<%@ Control Language="C#" %>
<%@ Import Namespace="ShopNum1.Common" %>
<%@ Import Namespace="System.Data" %>
<div class="latest_shop">
    <div class="pailist">
        <span class="pspan">品牌列表</span></div>
    <div class="brand_list_detail">
        <asp:Repeater ID="RepeaterData" runat="server">
            <ItemTemplate>
                <div class="brand_list_detail_title">
                    <%# ((DataRowView)Container.DataItem).Row["Name"] %><span>(<asp:Label ID="LabelBrandCount"
                        runat="server" Text="Label"></asp:Label>)</span>
                </div>
                <div class="brand_list_detail_list">
                    <ul class="clearfix">
                        <asp:Repeater ID="RepeaterBrand" runat="server">
                            <ItemTemplate>
                                <li><a href='<%#Server.HtmlEncode(ShopUrlOperate.RetUrl("BrandDetail",((DataRowView)Container.DataItem).Row["Guid"].ToString(),"brandguid")) %>'
                                    target="_blank">
                                    <asp:Image ID="ImageBrand" Width="97" Height="47" runat="server" ImageUrl='<%# ((DataRowView)Container.DataItem).Row["Logo"] %>'
                                        onerror="javascript:this.src='../ImgUpload/noImage.gif'" />
                                </a></li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </div>
                <div class="clear">
                </div>
                <asp:HiddenField ID="HiddenFieldCID" runat="server" Value='<%# ((DataRowView)Container.DataItem).Row["Code"] %>' />
            </ItemTemplate>
        </asp:Repeater>
    </div>
</div>
