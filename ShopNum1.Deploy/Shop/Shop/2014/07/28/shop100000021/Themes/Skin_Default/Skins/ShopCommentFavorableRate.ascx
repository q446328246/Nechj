<%@ Control Language="C#" EnableViewState="false" %>
<div class="bBoxnt">
    <h2 style="color:#c70c11;">好评率(<asp:Label ID="LabelFavorableRate" runat="server" CssClass="other"></asp:Label>%)</h2>
    <div class="flume">
        <table width="100%" cellpadding="0" cellspacing="0">
            <tr>
                <td>&nbsp;&nbsp;</td>
                <td><span class="tdgood">好评</span> </td>
                <td><span class="tdgener">中评</span></td>
                <td><span class="tdbad">差评</span></td>
                <td>总计</td>
            </tr>
            <tr>
                <td>最近1周</td>
                <td><asp:Label ID="LabelGoodWeek" runat="server"></asp:Label></td>
                <td><asp:Label ID="LabelGeneralWeek" runat="server"></asp:Label></td>
                <td><asp:Label ID="LabelBadWeek" runat="server"></asp:Label></td>
                <td><asp:Label ID="LabelAllWeek" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td>最近1个月</td>
                <td><asp:Label ID="LabelGoodOneMonth" runat="server"></asp:Label></td>
                <td><asp:Label ID="LabelGeneralOneMonth" runat="server"></asp:Label></td>
                <td><asp:Label ID="LabelBadOneMonth" runat="server"></asp:Label></td>
                <td><asp:Label ID="LabelAllOneMonth" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td>最近6个月</td>
                <td><asp:Label ID="LabelGoodSixMonth" runat="server"></asp:Label></td>
                <td><asp:Label ID="LabelGeneralSixMonth" runat="server"></asp:Label></td>
                <td><asp:Label ID="LabelBadSixMonth" runat="server"></asp:Label></td>
                <td><asp:Label ID="LabelAllSixMonth" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td>6个月前</td>
                <td><asp:Label ID="LabelGoodPrevious" runat="server"></asp:Label></td>
                <td><asp:Label ID="LabelGeneralPrevious" runat="server"></asp:Label></td>
                <td><asp:Label ID="LabelBadPrevious" runat="server"></asp:Label></td>
                <td><asp:Label ID="LabelAllPrevious" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td>总计</td>
                <td><asp:Label ID="LabelGoodAll" runat="server"></asp:Label></td>
                <td><asp:Label ID="LabelGeneralAll" runat="server"></asp:Label></td>
                <td><asp:Label ID="LabelBadAll" runat="server"></asp:Label></td>
                <td><asp:Label ID="LabelAll" runat="server"></asp:Label></td>
            </tr>
        </table>
    </div>
</div>
