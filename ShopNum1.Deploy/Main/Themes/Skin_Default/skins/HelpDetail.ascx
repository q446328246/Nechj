<%@ Control Language="C#" %>
<%@ Import Namespace="System.Data" %>
<script type="text/javascript">
    function CheckIsEmpty() {
        var str = document.getElementById("HelpDetail1_ctl00_TextBoxSearch").value;
        if (str == "") {
            return false;
        }
        return true;
    }
</script>
<div class="help_search">
    <table border="0" cellpadding="0" cellspacing="0" class="help_tab">
        <tbody>
            <tr>
                <td>
                    <span class="zhao">找帮助</span>
                </td>
                <td>
                    <asp:TextBox ID="TextBoxSearch" runat="server" CssClass="help_input"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="ButtonAgainSearch" runat="server" Text="" CssClass="helpbtn" OnClientClick=" return CheckIsEmpty()" />
                </td>
                <td align="right">
                    <img src="Themes/Skin_Default/Images/help_phone.jpg" />
                </td>
            </tr>
        </tbody>
    </table>
</div>
<div class="help_con">
    <h3 class="help_con_title">
        <asp:Label ID="LabelHelp" runat="server" Text=""></asp:Label></h3>
    <div class="help_con_body">
        <asp:Repeater ID="RepeaterData" runat="server">
            <ItemTemplate>
                <div class="article_title">
                    <%# ((DataRowView)Container.DataItem).Row["Title"]%></div>
                <div class="article_time">
                    时间：<%# Convert.ToDateTime(((DataRowView)Container.DataItem).Row["CreateTime"]).ToString("yyyy-MM-dd")%>&nbsp&nbsp
                    作者：<%# ((DataRowView)Container.DataItem).Row["CreateUser"]%>
                </div>
                <div class="article_detail article_imgcon">
                    <%# Server.HtmlDecode(((DataRowView)Container.DataItem).Row["Remark"].ToString())%>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</div>
