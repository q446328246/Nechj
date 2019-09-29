<%@ Control Language="C#" %>
<%@ Import Namespace="System.Data" %>
<div class="supply_demand" style="display: block;">
    <asp:Repeater ID="RepeaterData" runat="server">
        <ItemTemplate>
            <div class="spfl fl">
                <div class="spfl_title">
                    <a href='<%#ShopUrlOperate.RetUrl("productlist",((DataRowView)Container.DataItem).Row["Code"])%>' target="_blank"
                    title='<%# ((DataRowView)Container.DataItem).Row["Name"]%>'>
                        <%# ((DataRowView)Container.DataItem).Row["Name"]%></a>
                    <img src="Themes/Skin_Default/Images/class_img3.gif" /></div>
                <div class="spfl_list">
                    <ul>
                        <asp:Repeater ID="RepeaterChild" runat="server">
                            <ItemTemplate>
                                <li>
                                    <img src="Themes/Skin_Default/Images/class_img2.gif" /><a href='<%#ShopUrlOperate.RetUrl("productlist",((DataRowView)Container.DataItem).Row["Code"])%>' target="_blank"
                                    title='<%#((DataRowView)Container.DataItem).Row["Name"] %>'>
                                        <%# ShopNum1.Common.Utils.GetUnicodeSubString(((DataRowView)Container.DataItem).Row["Name"].ToString(),16,"")%></a> </li>
                            </ItemTemplate>
                        </asp:Repeater>
                        <li>
                            <img src="Themes/Skin_Default/Images/class_img2.gif" /><a href='<%#ShopUrlOperate.RetUrl("productlist",((DataRowView)Container.DataItem).Row["Code"])%>'>更多>></a></li>
                    </ul>
                    <asp:HiddenField ID="HiddenFieldCID" runat="server" Value='<%# ((DataRowView)Container.DataItem).Row["ID"] %>' />
                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</div>
