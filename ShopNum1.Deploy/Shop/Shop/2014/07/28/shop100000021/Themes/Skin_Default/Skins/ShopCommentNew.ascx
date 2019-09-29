<%@ Control Language="C#" EnableViewState="false" %>
<%@ Import Namespace="System.Data" %>
<script type="text/javascript" language="javascript">
function opPY(type)
{
    switch(type)
    {
       case "1":return "<img src='Themes/Skin_Default/Images/gds_dp2.png'/>"; break;
       case "3":return "<img src='Themes/Skin_Default/Images/gds_dp1.png'/>";break;
       case "5":return "<img src='Themes/Skin_Default/Images/gds_dp.png'/>";break;
    }
}
</script>
<div class="bBox bBoxnt">
    <h2 style="color: #c70c11;">评价</h2>
    <div class="content pistcont">
        <table cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td>
                    <ul class="secrety">
                        <li runat="server" id="All">
                            <asp:LinkButton ID="LinkButtonAll" runat="server">全部评价</asp:LinkButton></li>
                        <li runat="server" id="Good">
                            <asp:LinkButton ID="LinkButtonGood" runat="server">好评</asp:LinkButton></li>
                        <li runat="server" id="General">
                            <asp:LinkButton ID="LinkButtonGeneral" runat="server">中评</asp:LinkButton></li>
                        <li runat="server" id="Bad">
                            <asp:LinkButton ID="LinkButtonBad" runat="server">差评</asp:LinkButton></li>
                        <li runat="server" id="FollowFollow">
                            <asp:LinkButton ID="LinkButton" runat="server">追加评价</asp:LinkButton></li>
                    </ul>
                </td>
                <td><p class="prison">商品信息</p></td>
                <td><p class="taoism">评价人信息</p></td>
            </tr>
        </table>
    </div>
    <div class="content confuist">
        <asp:Repeater ID="RepeaterShow" runat="server">
            <ItemTemplate>
                <div class="confuistList clearfix">
                    <div class="pinjia fl">
                        <p><script type="text/javascript" language="javascript">
                            document.write(opPY('<%# ((DataRowView)Container.DataItem).Row["Commenttype"]%>'));</script></p>
                        <p class="spinlun"><span>[<asp:Label ID="LabelCommentType" runat="server" Text=""></asp:Label>]</span></p>
                    </div>
                    <div class="pinjia_con fl tl">
                       <%# ShopNum1.Common.Utils.GetUnicodeSubString(((DataRowView)Container.DataItem).Row["comment"].ToString(),40,"...")%><br />
                       <%# ShopNum1.Common.Utils.GetUnicodeSubString(((DataRowView)Container.DataItem).Row["continuecomment"].ToString(), 40, "...")%>
                    </div>
                    <div class="fl tl">
                        <p class="spinfos"><%# ((DataRowView)Container.DataItem).Row["ProductName"]%></p>
                        <p><span class="sjiage"><%# ((DataRowView)Container.DataItem).Row["BuyPrice"]%></span>元</p>
                    </div>
                    <div class="fl">
                        <p class="sjpinfors"><%# ((DataRowView)Container.DataItem).Row["MemLoginID"]%></p>
                        <p class="shijian">[<%# ((DataRowView)Container.DataItem).Row["CommentTime"]%>]</p>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</div>
<!--分页-->
<div class="fenye">
    <div class="lambert">
        <table cellpadding="0" cellspacing="0" border="0">
            <tr>
                <td><span class="fenye1">共</span></td>
                <td><span><asp:Label ID="LabelPageCount" runat="server" Text=""></asp:Label></span></td>
                <td><span class="fenye2">页，到第</span></td>
                <td><asp:TextBox ID="TextBoxIndex" runat="server" CssClass="pro_input"></asp:TextBox></td>
                <td class="fenye_td1"><span class="fenye3">页</span></td>
                <td class="fenye_td2"><asp:Button ID="ButtonSure" runat="server" Text="Button" CssClass="pro_btn" /></td>
            </tr>
        </table>
    </div>
    <div id="pageDiv" runat="server" class="pro_page">
        <div class="black2 ">
            <span class="disabled">< </span><span class="current">1</span><a href="#?page=2">2</a><span
                class="diandian">...</span> <a href="#?page=200">200</a> <a href="#?page=2">></a>
        </div>
    </div>
</div>
