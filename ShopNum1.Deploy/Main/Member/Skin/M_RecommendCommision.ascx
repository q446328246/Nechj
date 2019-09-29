<%@ Control Language="C#" AutoEventWireup="True" CodeBehind="M_RecommendCommision.ascx.cs"
    Inherits="ShopNum1.Deploy.Main.Member.Skin.M_RecommendCommision" %>
<div id="content" class="ordmain1">
    <div class="pad">
        <table border="0" cellspacing="0" cellpadding="0" class="lineh">
            <tr class="up_spac">
                <td align="right">
                    会员ID：
                </td>
                <td width="190">
                    <asp:TextBox ID="TextBoxMemLoginID" runat="server" class="ss_nr1"></asp:TextBox>
                </td>
                <td align="right">
                    &nbsp;&nbsp;订单号：
                </td>
                <td width="190">
                    <asp:TextBox ID="TextBoxOrderNumber" runat="server" class="ss_nr1"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="ButtonSearch" runat="server" Text="查询" class="chax btn_spc" name="12"
                        OnClick="ButtonSearch_Click" />
                </td>
            </tr>
        </table>
    </div>
    <table width="100%" border="0" cellspacing="0" cellpadding="5" class="blue_tbw1">
        <tr>
            <th class="th_le">
                会员ID
            </th>
            <th>
                订单编号
            </th>
            <th>
                返利金额
            </th>
            <th class="th_ri">
                返利时间
            </th>
        </tr>
        <asp:Repeater ID="RepeaterShow" runat="server">
            <ItemTemplate>
                <tr>
                    <td class="th_le">
                        <%#Eval("MemLoginID")%>
                    </td>
                    <td>
                        <%#Eval("OrderNumber")%>
                    </td>
                    <td>
                        <%#Eval("RecommendCommision")%>
                    </td>
                    <td class="th_ri">
                        <%#Eval("ReceiptTime")%>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
        <%if (RepeaterShow.Items.Count == 0)
          { %>
        <tr>
            <td colspan="6" style="height: 16px; border-left: solid 1px #e3e3e3; border-right: solid 1px #e3e3e3;">
                <div class="no_data">
                    暂无数据</div>
            </td>
        </tr>
        <% }%>
    </table>
    <!--分页-->
    <div class="btntable_tbg">
        <div id="pageDiv" runat="server" class="fy">
        </div>
    </div>
    <!--分页-->
</div>
