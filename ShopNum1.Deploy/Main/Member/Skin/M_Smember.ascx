<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="M_Smember.ascx.cs" Inherits="ShopNum1.Deploy.Main.Member.Skin.M_Smember" %>
<div id="content">
    <div class="pad">

    </div>
    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="blue_tb2">
        <tr>
            <th width="16%" class="th_le">
                会员编号
            </th>
            <th width="16%">
                会员姓名    
            </th>
            <th width="16%">
                当前等级
            </th>
            <th width="16%">
                登录账号
            </th>
            <th width="16%">
                联系电话
            </th>
            <th width="16%">
                操作
            </th>
            
        </tr>
        <asp:Repeater ID="RepeaterShow" runat="server">
            <ItemTemplate>
                <tr>
                    <td>
                        <%#Eval("MemLoginNO")%>
                    </td>
                    <td>
                        <%#Eval("RealName")%>
                    </td>
                    <td>
                        <%#Eval("Name") %>
                    </td>
                    <td>
                        <%#Eval("MemLoginID")%>
                    </td>
                    <td>
                        <%#Eval("Mobile")%>
                    </td>
                    <td>
                         <a href="M_LookOrder.aspx?pageid=1&MemNO=<%#Eval("MemLoginNO")%>" style="color: #4482b4;">查看顾客订单</a>
                                <%--查看顾客订单（开发中）--%>
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

