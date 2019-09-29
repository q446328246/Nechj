<%@ Control Language="C#" %>
<%@ Import Namespace="System.Data" %>
<!--分隔-->
<div class="leftcate">
    <div class="catList">
        <ul>
            <asp:Repeater ID="RepeaterData" runat="server">
                <ItemTemplate>
                    <li>
                        <h3>
                            <a href='<%#ShopUrlOperate.RetUrl("Search_product",((DataRowView)Container.DataItem).Row["Code"])%>'>
                                <img src="Themes/Skin_Default/Images/hall06.png" width="34" height="33" class="icon" /><b
                                    class="name"><%# ((DataRowView)Container.DataItem).Row["Name"]%></b></a>
                        </h3>
                        <p class="itemlist">
                            <asp:Repeater ID="RepeaterChild" runat="server">
                                <ItemTemplate>
                                    <a href='<%#ShopUrlOperate.RetUrl("Search_product",((DataRowView)Container.DataItem).Row["Code"])%>'
                                        target="_blank">
                                        <%# ((DataRowView)Container.DataItem).Row["Name"]%></a>
                                </ItemTemplate>
                            </asp:Repeater>
                        </p>
                    </li>
                    <asp:HiddenField ID="HiddenFieldCID" runat="server" Value='<%# ((DataRowView)Container.DataItem).Row["ID"] %>' />
                </ItemTemplate>
            </asp:Repeater>
        </ul>
    </div>
</div>
<asp:HiddenField ID="HiddenFieldCategoryCode" runat="server" />
