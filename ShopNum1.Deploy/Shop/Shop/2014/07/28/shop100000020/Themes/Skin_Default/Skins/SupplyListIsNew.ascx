<%@ Control Language="C#" EnableViewState="false"%>
<%@ Import Namespace="ShopNum1.Common" %>

<h2>最新供求列表</h2>
<div class="aBox11">
    <div class="content">
        <asp:Repeater ID="RepeaterShow" runat="server">
            <ItemTemplate>
                <table border="0" cellpadding="0" cellspacing="1">
                    <tr>
                        <td>
                            <a style="width: 215px; height: 25px; line-height: 25px; overflow: hidden; display: block;
                                margin: 0 auto; border-bottom: 1px dotted #ccc;" href='<%# GetPageName.RetUrl("SupplyDemandDetail",Eval("guid"))%>'>
                                ·<%# Eval("Title")%></a>
                        </td>
                    </tr>
                </table>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</div>

