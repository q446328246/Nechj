<%@ Control Language="C#" %>
<%@ Import Namespace="System.Data" %>
<!--商品三级分类-->
<script type="text/javascript">

    function show(element) {
        element.getElementsByTagName("DIV")[0].style.display = "block";
        element.getElementsByTagName("DIV")[1].style.display = "block";

    }

    function hide(element) {
        element.getElementsByTagName("DIV")[0].style.display = "none";
        element.getElementsByTagName("DIV")[1].style.display = "none";
    }

    function show1(element) {
        element.style.display = "block";
    }

    function hide1(element) {
        element.style.display = "none";
    }

    function show2(element) {
        element.style.display = "block";
    }

    function hide2(element) {
        element.style.display = "none";
    }

    
</script>
<style type="text/css">
    .xz_sjfl li .show
    {
        display: block;
    }
    .xz_sjfl li .hide
    {
        display: none;
    }
    .xz_sjfl li
    {
        height: 30px;
        line-height: 30px; *height:28px;*line-height:28px;}
    * + html .xz_sjfl li
    {
        height: 28px;
        line-height: 28px;
    }
    .xz_sjfl li
    {
        background-position: right -3px;
    }
    .xz_sjfl
    {
        background-position: 7px 5px;
    }
    .xz_sub_text
    {
        overflow: hidden;
        line-height: 20px;
        padding: 14px 6px 4px 10px;
        border-bottom: 1px dashed #595050;
    }
    .xz_sub_text1
    {
        float: left;
        padding-right: 14px;
    }
    .xz_spfl li .xz_sub_text1 a
    {
        font-size: 13px;
        font-weight: 700;
    }
    .xz_sub_text2
    {
        float: left;
    }
    .xz_spfl li .xz_sub_text2 a
    {
        font-size: 12px;
        font-weight: 400;
    }
</style>
<!-- 按分类浏览 -->
<div class="xz_spfl" style="position: relative; z-index: 22;">
    <div class="xz_spfl_h">
        所有店铺分类
    </div>
    <div class="xz_spfl_m">
        <ul class="xz_sjfl">
            <asp:Repeater ID="RepeaterData" runat="server">
                <ItemTemplate>
                    <div>
                        <div onmousemove='show(this)' onmouseleave='hide(this)'>
                            <li><a href='<%# ShopUrlOperate.RetUrl("shoplistsearch",((DataRowView)Container.DataItem).Row["Code"].ToString(),"code")%>'>
                                <%# ((DataRowView)Container.DataItem).Row["Name"]%></a>
                                <div id="child1" class="xz_sub_h " onmousemove='show1(this)' onmouseleave='hide1(this)'>
                                </div>
                                <div id="child2" class="xz_sub " style="display: none;" onmousemove='show2(this)'
                                    onmouseleave='hide2(this)'>
                                    <asp:HiddenField ID="HiddenFieldCID" runat="server" Value='<%# ((DataRowView)Container.DataItem).Row["ID"] %>' />
                                    <asp:Repeater ID="RepeaterChild" runat="server">
                                        <ItemTemplate>
                                            <div class="xz_sub_text">
                                                <div class="xz_sub_text1">
                                                    <a href='<%# ShopUrlOperate.RetUrl("shoplistsearch",((DataRowView)Container.DataItem).Row["Code"].ToString(),"code")%>'>
                                                        <%# ((DataRowView)Container.DataItem).Row["Name"]%></a></a>&nbsp;&nbsp;&nbsp;&nbsp;
                                                </div>
                                                <div class="xz_sub_text2">
                                                    <asp:HiddenField ID="HiddenFieldFID" runat="server" Value='<%# ((DataRowView)Container.DataItem).Row["ID"]%>' />
                                                    <asp:Repeater ID="RepeaterthreeChild" runat="server">
                                                        <ItemTemplate>
                                                            <a href='<%# ShopUrlOperate.RetUrl("shoplistsearch",((DataRowView)Container.DataItem).Row["Code"].ToString(),"code")%>'>
                                                                <%# ((DataRowView)Container.DataItem).Row["Name"]%>
                                                            </a>&nbsp;
                                                            <asp:Literal ID="LiteralLine" runat="server">|</asp:Literal>&nbsp;
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                                </div>
                                            </div>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </div>
                            </li>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </ul>
    </div>
</div>
