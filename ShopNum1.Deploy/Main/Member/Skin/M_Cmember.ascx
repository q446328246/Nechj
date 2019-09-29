<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="M_Cmember.ascx.cs" Inherits="ShopNum1.Deploy.Main.Member.Skin.M_Cmember" %>
<div id="content">
    <div class="pad">
    </div>
    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="blue_tb2">
        <tr>
            <th width="14%" class="th_le">
                会员编号
            </th>
            <th width="14%">
                会员姓名
            </th>
            <th width="14%">
                当前等级
            </th>
            <th width="14%">
                登录账号
            </th>
            <th width="14%">
                联系电话
            </th>
            <th width="30%">
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
                        <span id="ss" runat="server"><a href="M_TJmember.aspx?type=0&pageid=1&MemNO=<%#Eval("MemLoginNO")%>" style="color: #4482b4;">
                            查看推荐会员</a></span>
                            <a href="M_TJmember.aspx?type=1&pageid=1&MemNO=<%#Eval("MemLoginNO")%>" style="color: #4482b4;">
                            查看推荐顾客</a>
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
