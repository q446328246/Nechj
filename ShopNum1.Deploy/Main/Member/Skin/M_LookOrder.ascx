<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="M_LookOrder.ascx.cs" Inherits="ShopNum1.Deploy.Main.Member.Skin.M_LookOrder" %>
<div id="content">
    <div class="pad">

    </div>
    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="blue_tb2">
        <tr>
            <th width="25%" class="th_le">
                订单编号
            </th>
            
            <th width="25%">
                积分（PV）
            </th>
            <th width="25%">
                金币（BV）
            </th>
            <th width="25%">
                日期
            </th>
            
        </tr>
        <asp:Repeater ID="RepeaterShow" runat="server">
            <ItemTemplate>
                <tr>
                    <td>
                        <%#Eval("OrderNumber")%>
                    </td>
                    <td>
                        <%#Eval("Score_pv_a")%>
                    </td>
                    <td>
                        <%#Eval("ShouldPayPrice")%>
                    </td>
                    <td>
                        <%#Eval("PayTime")%>
                    </td>
                    
                    
                </tr>
                </ItemTemplate>
        </asp:Repeater>
                <%if (RepeaterShow.Items.Count == 0)
                  { %>
                <tr>
                    <td colspan="6" style="height: 16px;">
                        <div class="no_data">
                            暂无数据</div>
                    </td>
                </tr>
                <% }%>
            
    </table>
    <div class="btntable_tbg">
        <div id="pageDiv" runat="server" class="fy">
        </div>
    </div>
    <script type="text/javascript">
            <!--
        var TabbedPanels1 = new Spry.Widget.TabbedPanels("list_main");
            //-->
    </script>
</div>

