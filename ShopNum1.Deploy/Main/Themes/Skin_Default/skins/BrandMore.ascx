<%@ Control Language="C#" %>
<%@ Import Namespace="ShopNum1.Common" %>
<%@ Import Namespace="System.Data" %>
<div class="warp clearfix">
    <div class="BrandMore clearfix">
        <h3>
            品牌列表 <span style="height: 30px; font-size: 12px; padding-left: 420px; font-weight: normal;
                position: relative; top: -12px;"></span><a href="BrandMoreSearch.aspx">更多</a></h3>
        <asp:Repeater ID="repBrnadMore" runat="server">
            <ItemTemplate>
                <div class="Brandbox">
                    <h4>
                        <span style="float: left">
                            <%# ((DataRowView)Container.DataItem).Row["Name"]%></span></h4>
                    <a href='BrandDetail.aspx?BrandGuid=<%# ((DataRowView)Container.DataItem).Row["Guid"] %>'
                        target="_self">
                        <asp:Image ID="ImageBrand" runat="server" Height="70px" ImageUrl='<%# Globals.ImagePath+"s_"+((DataRowView)Container.DataItem).Row["Logo"] %>'
                            onerror="javascript:this.src='../ImgUpload/noImage.gif'" Width="90px" />
                    </a>
                    <p style="width: 160px;">
                        <%# ((DataRowView)Container.DataItem).Row["Description"]%></p>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</div>
