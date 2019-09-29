<%@ Control Language="C#" %>
<%@ Import Namespace="ShopNum1.Common" %>
<%@ Import Namespace="System.Data" %>
<div class="tuijianpro">
    <h1>
        <asp:Literal ID="LiteralTitle" runat="server"></asp:Literal>店铺热卖</h1>
    <div class="tuijiancont">
        <asp:Repeater ID="RepeaterData" runat="server">
            <ItemTemplate>
                <div class="tuijian">
                    <div class="tjname">
                        <a href='<%#ShopUrlOperate.shopHref(((DataRowView)Container.DataItem).Row["ProductGuid"].ToString(),((DataRowView)Container.DataItem).Row["MemberID"].ToString() )%>?category=1'
                            title="<%# ((DataRowView)Container.DataItem).Row["ZtcName"].ToString()%>">
                            <%# ShopNum1.Common.Utils.GetUnicodeSubString(((DataRowView)Container.DataItem).Row["ZtcName"].ToString(), 28, "")%></a>
                    </div>
                    <div class="tjimga">
                        <a href='<%#ShopUrlOperate.shopHref(((DataRowView)Container.DataItem).Row["ProductGuid"].ToString(),((DataRowView)Container.DataItem).Row["MemberID"].ToString() )%>?category=1'>
                            <asp:Image ID="Image1" ImageUrl='<%# ((DataRowView)Container.DataItem).Row["ZtcImg"].ToString()+"_160x160.jpg"%>'
                                onerror="javascript:this.src='../ImgUpload/noimg.jpg_160x160.jpg'" runat="server" /></a>
                        <p>
                            <%# Globals.MoneySymbol%><%# ((DataRowView)Container.DataItem).Row["SellPrice"]%></p>
                    </div>
                    <div class="otherInfo clearfix">
                        <span>已销售<b><%#Eval("sellcount")%></b>笔</span> <a href='<%#ShopUrlOperate.shopHref(((DataRowView)Container.DataItem).Row["ProductGuid"].ToString(),((DataRowView)Container.DataItem).Row["MemberID"].ToString() )%>?category=1'
                            title="<%# ((DataRowView)Container.DataItem).Row["ZtcName"].ToString()%>">去看看</a>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
        <div class="tr">
            <a href="http://shop100000027.bb.qhtj88.comProductListHot.aspx?category=1">更多热卖</a></div>
    </div>
</div>
