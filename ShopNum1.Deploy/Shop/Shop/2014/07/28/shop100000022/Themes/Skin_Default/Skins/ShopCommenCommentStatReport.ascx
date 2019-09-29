<%@ Control Language="C#" EnableViewState="false" %>
<%@ Import Namespace="ShopNum1.Common" %>
<div class="aBox clearfix">
    <h2>
        店铺动态评分</h2>
    <div class="content">
        <asp:Repeater EnableViewState="False" ID="RepeaterShow" runat="server">
            <ItemTemplate>
                <table class="fl">
                    <tr>
                        <td class="title">
                            宝贝与描述相符
                        </td>
                        <td class="count">
                            <img src="Themes/Skin_Default/Images/xinxin.jpg" />&nbsp;<%# Eval("Characteravg")%>分
                        </td>
                    </tr>
                    <tr>
                        <td class="title">
                            卖家服务态度
                        </td>
                        <td class="count">
                            <img src="Themes/Skin_Default/Images/xinxin.jpg" />&nbsp;<%# Eval("Attitudeavg")%>分
                        </td>
                    </tr>
                    <tr>
                        <td class="title">
                            卖家发货速度
                        </td>
                        <td class="count">
                            <img src="Themes/Skin_Default/Images/xinxin.jpg" />&nbsp;<%# Eval("Speedavg")%>分
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                        </td>
                    </tr>
                </table>
                <table class="fr">
                    <tr>
                        <td class="title">
                            共<%# Eval("Allnum")%>人
                        </td>
                    </tr>
                </table>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</div>
