<%@ Control Language="C#" %>
<%@ Import Namespace="System.Data" %>
<style type="text/css">
    
</style>
<script language="javascript">
    $(document).ready(function () {
        $(".more_drop_l").click(function () {
            if ($(this).parent().prev().attr("class") == "atrCint")//此时是展开的
            {
                $(this).parent().prev().attr("class", "atrCint_drop");
                $(this).children("i").css("background-position", " 0px 0px");
                $(this).children("div").html("更多");
                $(this).parent().parent().parent().css("background", "");
                return;
            }
            else//此时是收起的
            {
                //其他都收起
                for (var i = 1; i < 7; i++) {
                    $("#ShouHe" + i).attr("class", "atrCint_drop");
                    $("#Qiantou" + i).css("background-position", " 0px 0px");
                    $("#wenzi" + i).html("更多");
                    $("#content" + i).css("background", "");
                }
                //自己展开
                $(this).parent().prev().attr("class", "atrCint")
                $(this).children("i").css("background-position", " 0px -7px");
                $(this).children("div").html("收起");
                $(this).parent().parent().parent().css("background", "#837574");
            }
        });
    });
</script>
<div class="tsCategory_con">
    <asp:Repeater ID="RepeaterData" runat="server">
        <ItemTemplate>
            <div id="content" class="FlowCategory_item" style="background: #685d5c">
                <div class="attrKey">
                    <a href='<%# ShopUrlOperate.RetUrl("categorylist",((DataRowView)Container.DataItem).Row["code"] )%>'>
                        <%# ((DataRowView)Container.DataItem).Row["Name"]%></a></div>
                <div class="attrValues">
                    <div class="atrCint" id="ShouHe1">
                        <asp:Repeater ID="RepeaterChild" runat="server">
                            <ItemTemplate>
                                <ul class="av_collapse">
                                    <li id="Div1" style="padding-bottom: 4px;">
                                        <div class="entity">
                                            <ul class="items">
                                                <li class="arit_bcategory"><a href='<%# ShopUrlOperate.RetUrl("categorylist",((DataRowView)Container.DataItem).Row["code"] ) %>'>
                                                    <%# ((DataRowView)Container.DataItem).Row["Name"]%></a> </li>
                                                <li class="cagethree">
                                                    <asp:Repeater ID="RepeaterthreeChild" runat="server">
                                                        <ItemTemplate>
                                                            <a href='<%# ShopUrlOperate.RetUrl("categorylist",((DataRowView)Container.DataItem).Row["code"] ) %>'>
                                                                <%# ((DataRowView)Container.DataItem).Row["Name"]%>
                                                                <asp:Literal ID="LiteralLine" runat="server"></asp:Literal></a>
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                                    <asp:HiddenField ID="HiddenFieldFID" runat="server" Value='<%# ((DataRowView)Container.DataItem).Row["ID"] %>' />
                                                </li>
                                            </ul>
                                        </div>
                                    </li>
                                </ul>
                            </ItemTemplate>
                        </asp:Repeater>
                        <asp:HiddenField ID="HiddenFieldCID" runat="server" Value='<%# ((DataRowView)Container.DataItem).Row["ID"] %>' />
                    </div>
                    <div class="av_options">
                        <a class="more_drop_l" id="shouqi3">
                            <div id="wenzi3">
                                更多</div>
                            <i id="Qiantou3" class="more_drop_allow"></i></a>
                    </div>
                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</div>
