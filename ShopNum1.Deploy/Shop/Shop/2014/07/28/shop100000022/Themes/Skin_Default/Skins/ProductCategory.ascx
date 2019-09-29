<%@ Control Language="C#" EnableViewState="false"%>
<%@ Import Namespace="ShopNum1.Common" %>
<%@ Import Namespace="System.Configuration" %>
<%@ Import Namespace="System.Data" %>
<div class="ks_panel">
    <div class="storn_hd"><h3>商品分类</h3></div>
    <div class="ks_care">
        <asp:Repeater ID="RepeaterData" runat="server">
            <ItemTemplate>
                <div class="big_care">
                    <a href='<%# ShopUrlOperate.RetShopUrl("ProductSearchList",Eval("Code"),"code")%>'><%# Eval("Name")%></a></div>
                <ul class="ks_cagen" style="display:none;">
                    <asp:Repeater ID="RepeaterChild" runat="server">
                        <ItemTemplate>
                            <li class="smal_care"><a href='<%# ShopUrlOperate.RetShopUrl("ProductSearchList",Eval("Code"),"code")%>'><%# Eval("Name")%></a></li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
                <asp:HiddenField ID="HiddenFieldCID" runat="server" Value='<%# Eval("ID") %>' />
            </ItemTemplate>
        </asp:Repeater>
    </div>
</div>
<div class="clear"></div>
<script type="text/javascript" language="javascript">
        $(function(){
                $(".big_care").toggle(function(){$(this).next().show("slow");},function(){$(this).next().hide("slow");});
                $(".big_care a").click(function(){
                        location.href=$(this).attr("href");
                });
        });
</script>
