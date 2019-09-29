<%@ Control Language="C#" %>
<%@ Import Namespace="System.Data" %>
<asp:Repeater ID="RepeaterData" runat="server">
    <ItemTemplate>
        <table width="100%">
            <tr>
                <td rowspan="4">
                    <asp:Image ID="Img1" ImageUrl='<%# ((DataRowView)Container.DataItem).Row["Banner"]%>'
                        runat="server" alt="图片" Width="100" Height="100" onerror="javascript:this.src='../ImgUpload/noImage.gif'" />
                </td>
                <td align="left">
                    <a href='<%#ShopUrlOperate.GetShopUrl(((DataRowView)Container.DataItem).Row["ShopID"].ToString())%>'
                        target="_blank"><b style="font-weight: bold">
                            <%# ((DataRowView)Container.DataItem).Row["Name"]%></b> </a>&nbsp;&nbsp;&nbsp;
                </td>
            </tr>
            <tr>
                <td align="left">
                    店主：<%# ((DataRowView)Container.DataItem).Row["MemLoginID"]%>
                </td>
            </tr>
            <tr>
                <td align="left">
                    所在地:<%#  ((DataRowView)Container.DataItem).Row["AddressCode"]%>
                </td>
                <td>
                </td>
            </tr>
        </table>
    </ItemTemplate>
</asp:Repeater>
