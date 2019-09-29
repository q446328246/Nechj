<%@ Control Language="C#" EnableViewState="false"%>
<div class="topbox">
    <asp:Literal ID="Literallogo" runat="server"></asp:Literal>
</div>
<div id="nav" class="clearfix">
    <div class="nav_cs">
        <ul>
            <asp:Literal ID="LiteralMenu" runat="server"></asp:Literal>
        </ul>
    </div>
</div>
<script type="text/javascript">
    $(function(){
            var stab='<%=Request.QueryString["select"] %>';
            $("#stab_"+stab).addClass("cur");
    });
</script>