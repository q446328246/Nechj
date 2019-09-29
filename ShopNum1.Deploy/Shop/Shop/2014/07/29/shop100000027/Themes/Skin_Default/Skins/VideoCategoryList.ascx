<%@ Control Language="C#" EnableViewState="false"%>
<%@ Import Namespace="ShopNum1.Common" %>
<div class="ks_panel" style="margin-top:8px;">
    <div class="storn_hd">
        <h3>
            视频分类</h3>
    </div>
    <div class="content" style="border: 0px;">
        <table width="100%" border="0" cellpadding="0" cellspacing="1" style="text-align: center"
            class="table1">
            <asp:Repeater ID="RepeaterData" runat="server">
                <ItemTemplate>
                    <tr>
                        <td width="50%" bgcolor="#FFFFFF">
                            <a href='<%# GetPageName.RetUrl("VideoList",Eval("guid"))%>'>
                                <%# Eval("Name")%></a>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
    </div>
</div>
