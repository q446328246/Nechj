<%@ Control Language="C#" EnableViewState="false"%>
<%@ Import Namespace="ShopNum1.Common" %>
<script type="text/javascript">
    $(function() {
    $('ul.LatestNews li:last a').css('border-bottom', 'none');
    })    
</script>

<div class="ks_panel">
    <div class="storn_hd"><h3>最新资讯</h3></div>
    <div class="content">
        <ul class="LatestNews">
            <asp:Repeater ID="RepeaterShow" runat="server">
                <ItemTemplate>
                    <li>
                        <a href='<%# GetPageName.RetUrl("NewsDetail",Eval("guid"))%>'>·<%# Eval("Title")%></a>
                    </li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>
    </div>
</div>
