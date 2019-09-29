<%@ Control Language="C#" %>
<%@ Import Namespace="ShopNum1.Common" %>
<%@ Import Namespace="System.Data" %>
<h3 class="clearfix"><span>推荐品牌</span><a href="BrandDetail.aspx">更多</a></h3>
<div class="announ_list clearfix">
    <asp:Repeater ID="RepeaterBrand" runat="server">
        <ItemTemplate>
            <a href='<%# ShopUrlOperate.RetUrl("BrandDetail",((DataRowView)Container.DataItem).Row["Guid"].ToString(),"brandguid")%>' class="BrandReList">
                <asp:Image ID="ImageBrand" Width="97" Height="47" runat="server" ImageUrl='<%# ((DataRowView)Container.DataItem).Row["Logo"] %>'
                    onerror="javascript:this.src='/ImgUpload/noImg.jpg'" />
            </a>
        </ItemTemplate>
    </asp:Repeater>
</div>
