<%@ Control Language="C#" %>
<%@ Import Namespace="System.Data" %>
<div class="gBox">
    <h2>
        <span class="left">
            <asp:Label ID="LabelTitle" runat="server" Text='<%= ((DataRowView)Container.DataItem).Row["Title"]%>'></asp:Label></span>
    </h2>
    <div class="content">
        <table width="99%" border="0" cellspacing="1" cellpadding="0" style="text-align: left;
            margin-bottom: 6px" bgcolor="#f2f9ff">
            <tr style="font-size: 14px;">
                <td width="20%">
                    投票选项
                </td>
                <td>
                    投票数
                </td>
                <td width="60%">
                    所占百分比( % )
                </td>
            </tr>
            <asp:Repeater ID="RepeaterSurveyThemeDetail" runat="server">
                <ItemTemplate>
                    <tr>
                        <td>
                            <%# ((DataRowView)Container.DataItem).Row["Name"]%>
                        </td>
                        <td>
                            &nbsp;<%# ((DataRowView)Container.DataItem).Row["Count"]%>
                        </td>
                        <td>
                            <asp:HiddenField ID="HiddenFieldCount" runat="server" Value='<%# ((DataRowView)Container.DataItem).Row["Count"]%>' />
                            <asp:Label ID="LabelShow" runat="server" />
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
        <p id="SurveyThemeDetailText" style="font-size: 14px; background-color: #f1f1f1;
            border: 1px solid #e3e3e3; line-eight: 200%; padding: 5px;">
            总共有<font class="StorePrice"><asp:Label ID="LabelAllCount1" runat="server" Text='<%=((DataRowView)Container.DataItem).Row["Name"]%>'></asp:Label></font>人参加调查
            ，累计投票： <font class="StorePrice">
                <asp:Label ID="LabelAllCount2" runat="server" Text='<%=((DataRowView)Container.DataItem).Row["Count"]%>'></asp:Label></font>
            张。</p>
    </div>
    <div class="bottom">
        <span class="left" />
    </div>
</div>
