<%@ Control Language="C#" %>
<%@ Import Namespace="System.Data" %>
<div class="links" style="display: none;">
    <asp:Repeater ID="RepeaterData" runat="server">
        <ItemTemplate>
            <a target="_blank" href='<%# Eval("Href","{0}") %>'>
                <%# ((DataRowView)Container.DataItem).Row["Name"]%></a>
        </ItemTemplate>
    </asp:Repeater>
</div>
<!--友情链接-->
<div id="links">
    <ul>
        <li>
            <img width="161" src="Themes/Skin_Default/Images/bottm_09.jpg" /></li>
        <li>
            <img width="195" src="Themes/Skin_Default/Images/bottm_10.jpg" /></li>
        <li>
            <img width="195" src="Themes/Skin_Default/Images/bottm_11.jpg" /></li>
        <li>
            <img width="196" src="Themes/Skin_Default/Images/bottm_12.jpg" /></li>
        <li>
            <img width="158" src="Themes/Skin_Default/Images/bottm_13.jpg" /></li>
    </ul>
</div>
<!--合作伙伴-->
<div class="caborate">
    <table cellpadding="0" cellspacing="0" border="0" width="100%">
        <tr>
            <td>
                <dl>
                    <dt>
                        <img src="Themes/Skin_Default/Images/xl.png" /></dt>
                    <dd>
                        <a href="#" target="_blank">我们在新浪</a></dd>
                </dl>
            </td>
            <td>
                <dl>
                    <dt>
                        <img src="Themes/Skin_Default/Images/TX.png" /></dt>
                    <dd>
                        <a href="#" target="_blank">我们在腾讯</a></dd>
                </dl>
            </td>
            <td>
                <dl>
                    <dt>
                        <img src="Themes/Skin_Default/Images/KJ.png" /></dt>
                    <dd>
                        <a href="#" target="_blank">我们的空间</a></dd>
                </dl>
            </td>
            <td>
                <dl>
                    <dt>
                        <img src="Themes/Skin_Default/Images/RR.png" target="_blank" /></dt>
                    <dd>
                        <a href="#">人人网</a></dd>
                </dl>
            </td>
            <td>
                <dl>
                    <dt>
                        <img src="Themes/Skin_Default/Images/KX.png" target="_blank" /></dt>
                    <dd>
                        <a href="#">开心网</a></dd>
                </dl>
            </td>
            <td>
                <dl>
                    <dt>
                        <img src="Themes/Skin_Default/Images/DB.png" target="_blank" /></dt>
                    <dd>
                        <a href="#">豆瓣网</a></dd>
                </dl>
            </td>
            <td>
                <dl>
                    <dt>
                        <img src="Themes/Skin_Default/Images/BD.png" /></dt>
                    <dd>
                        <a href="#" target="_blank">百度分享</a></dd>
                </dl>
            </td>
        </tr>
    </table>
</div>
