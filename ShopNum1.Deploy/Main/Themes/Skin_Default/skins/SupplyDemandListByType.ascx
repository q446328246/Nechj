<%@ Control Language="C#" %>
<%@ Import Namespace="System.Data" %>
供求信息
<div class="cBox">
    <h2 style="padding-top: 5px;">
        <asp:Repeater ID="RepeaterTitle" runat="server">
            <ItemTemplate>
                <img src="Themes/Skin_Default/Images/22.gif" />
                <a href='<%# ((DataRowView)Container.DataItem).Row["Release"] %>'>[我要发布]</a> <a href='<%# ((DataRowView)Container.DataItem).Row["Href"]%>'>
                    <%# ((DataRowView)Container.DataItem).Row["CfTitle"]%></a> <span class="right">
                </span>
            </ItemTemplate>
        </asp:Repeater>
        <span class="right"></span>
    </h2>
    <div class="content">
        <ul>
            <asp:Repeater ID="RepeaterShow" runat="server">
                <ItemTemplate>
                    <table width="100%" cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                <img src="Themes/Skin_Default/Images/circle.jpg" />
                            </td>
                            <td align="left" height="24px;">
                                [<%#((DataRowView)Container.DataItem).Row["Name"]%>] <a target="_blank" href='<%# "SurveyThemeDetail.aspx?guid=" + ((DataRowView)Container.DataItem).Row["Guid"]%>'>
                                    <%# ((DataRowView)Container.DataItem).Row["Title"]%>
                                </a>
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:Repeater>
        </ul>
    </div>
</div>
