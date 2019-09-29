<%@ Control Language="C#" %>
<%@ Import Namespace="ShopNum1.WebControl" %>
<%@ Import Namespace="System.Data" %>
<div class="mess_box clearfix">
    <div class="th5">
        <span class="redpic"></span><span class="fl">
            <asp:Literal ID="LiteralTitel" runat="server"></asp:Literal></span><a runat="server"
                id="Href" class="more_red">更多>></a></div>
    <div class="mess_list">
        <asp:Repeater ID="RepeaterSupplyFirst" runat="server">
            <ItemTemplate>
                <div class="mess_conts">
                    <a href='<%# ShopUrlOperate.RetUrl("SupplyDemandDetail",((DataRowView)Container.DataItem).Row["ID"]) %>'
                        class="messpic">
                        <img src='<%# Eval("Image")%>' width="95" height="75" onerror="javascript:this.src='../ImgUpload/noImage.gif'"
                            runat="server" /></a>
                    <div class="messname">
                        <p>
                            <a href='<%# ShopUrlOperate.RetUrl("SupplyDemandDetail",((DataRowView)Container.DataItem).Row["ID"]) %>'
                                title='<%# Eval("Title")%>'>
                                <%#ShopNum1.Common.Utils.GetUnicodeSubString(Eval("Title").ToString(), 28, "")%>
                            </a>
                        </p>
                        <div class="suname">
                            <a href='<%# ShopUrlOperate.RetUrl("SupplyDemandDetail",((DataRowView)Container.DataItem).Row["ID"]) %>'>
                                <%# Server.HtmlDecode(((DataRowView)Container.DataItem).Row["Description"].ToString())%></a></div>
                    </div>
                </div>
                <div class="mess_li">
                    <ul>
                        <asp:HiddenField ID="HiddenFieldGuid" Value='<%# ((DataRowView)Container.DataItem).Row["ID"]%>'
                            runat="server" />
                        <asp:Repeater ID="RepeaterData" runat="server">
                            <ItemTemplate>
                                <li><span class="spantit">【<%# ((DataRowView)Container.DataItem).Row["TradeType"].ToString() == "0" ? "供应" : "求购"%>】</span>
                                    <a href='<%# ShopUrlOperate.RetUrl("SupplyDemandDetail",((DataRowView)Container.DataItem).Row["ID"]) %>'
                                        title="<%# ((DataRowView)Container.DataItem).Row["Title"]%>">
                                        <%#ShopNum1.Common.Utils.GetUnicodeSubString(Eval("Title").ToString().Replace("【供应】", "").Replace("【求购】", ""), 32, "")%></a>
                                    <span class="spantime">[<%# Eval("ReleaseTime", "{0:MM-dd}")%>]</span> </li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </div>
                <div class="clear">
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</div>
