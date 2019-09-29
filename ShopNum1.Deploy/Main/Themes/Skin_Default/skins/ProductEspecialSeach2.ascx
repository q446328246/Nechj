<%@ Control Language="C#" %>
<%@ Import Namespace="ShopNum1.Common" %>
<%@ Import Namespace="System.Data" %>
<div class="four01_detail" style="display: block; width: 932px; border: none; height: 120px;
    overflow: hidden;">
    <asp:Repeater ID="RepeaterData" runat="server">
        <ItemTemplate>
            <div class="four01_cp" style="width: 133px; text-align: center;">
                <a href='<%#ShopUrlOperate.shopHref(((DataRowView)Container.DataItem).Row["Guid"].ToString(),((DataRowView)Container.DataItem).Row["MemLoginID"].ToString() )%>'>
                    <asp:Image ID="ImageProduct" runat="server" Height="85px" ImageUrl='<%#ShopUrlOperate.ShopProductImg(((DataRowView)Container.DataItem).Row["ThumbImage"].ToString(), ((DataRowView)Container.DataItem).Row["MemLoginID"].ToString())%>'
                        Width="85px" onerror="javascript:this.src='../ImgUpload/noImage.gif'" /></a>
                <br />
                <span class="cp_title"><a href='<%#ShopUrlOperate.shopHref(((DataRowView)Container.DataItem).Row["Guid"].ToString(),((DataRowView)Container.DataItem).Row["MemLoginID"].ToString() ) %>'
                    target="_blank">
                    <%# ShopNum1.Common.Utils.GetUnicodeSubString(((DataRowView)Container.DataItem).Row["Name"].ToString(),14,"")%></a>
                </span>
                <br />
                <span class="yuan">
                    <%# Globals.MoneySymbol%></span><span class="price"><%# ((DataRowView)Container.DataItem).Row["ShopPrice"]%></span>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</div>
