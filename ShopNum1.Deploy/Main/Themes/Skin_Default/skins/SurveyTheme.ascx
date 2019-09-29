<%@ Control Language="C#" %>
<%@ Import Namespace="System.Data" %>
<div class="cBox">
    <div class="title">
        在线调查
    </div>
    <div class="content">
        <asp:Repeater ID="RepeaterSurveyTheme" runat="server">
            <ItemTemplate>
                <p>
                    <asp:HiddenField ID="HiddenFieldGuid" Value='<%# ((DataRowView)Container.DataItem).Row["Guid"]%>'
                        runat="server" />
                    <%# ((DataRowView)Container.DataItem).Row["Title"]%><br />
                    &nbsp;&nbsp;参与人数：<%# ((DataRowView)Container.DataItem).Row["Count"]%>
                </p>
                <asp:CheckBoxList ID="CheckBoxListSurveyOption" runat="server" Visible="true">
                </asp:CheckBoxList>
                <asp:RadioButtonList ID="RadioButtonListSurveyOption" runat="server" Visible="true">
                </asp:RadioButtonList>
            </ItemTemplate>
        </asp:Repeater>
        <asp:Button ID="ButtonConfirm" runat="server" Text="投票" class="bnt2" />&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button
            ID="ButtonDetail" runat="server" Text="查看" class="bnt2" />
    </div>
    <div class="bottom">
    </div>
</div>
