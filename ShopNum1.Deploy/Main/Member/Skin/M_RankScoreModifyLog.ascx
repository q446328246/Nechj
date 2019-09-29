<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="M_RankScoreModifyLog.ascx.cs"
    Inherits="ShopNum1.Deploy.Main.Member.Skin.M_RankScoreModifyLog" %>
<div id="content">
    <div class="pad">
        <table border="0" cellspacing="0" cellpadding="0" class="lineh">
            <tr class="up_spac">
                <td align="right">
                    时间：
                </td>
                <td>
                    <asp:TextBox ID="TextBoxSRegDate1" runat="server" onclick="WdatePicker({dateFmt:'yyyy-MM-dd'})"
                        class="ss_nrduan"></asp:TextBox>
                </td>
                <td class="line_spac">
                    -
                </td>
                <td>
                    <asp:TextBox ID="TextBoxSRegDate2" runat="server" onclick="WdatePicker({dateFmt:'yyyy-MM-dd'})"
                        class="ss_nrduan"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="ButtonGet" name="12" runat="server" Text="搜索" CssClass="chax btn_spc"
                        OnClick="ButtonGet_Click" />
                </td>
            </tr>
        </table>
    </div>
    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="blue_tb2">
        <tr>
            <th width="20%" class="th_le">
                变更日期
            </th>
            <th width="20%">
                变更类型
            </th>
            <th width="10%">
                当前红包
            </th>
            <th width="10%">
                变更红包
            </th>
            <th width="10%">
                变更后红包
            </th>
            <th width="30%" class="th_ri">
                备注
            </th>
        </tr>
        <asp:Repeater ID="RepeaterShow" runat="server">
            <ItemTemplate>
                <tr>
                    <td>
                        <%#Eval("Date") %>
                    </td>
                    <td>
                        <%#ShopNum1.MemberWebControl.M_RankScoreModifyLog.Type(Eval("OperateType").ToString())%>
                    </td>
                    <td>
                        <%#Eval("CurrentScore") %>
                    </td>
                    <td>
                        <%#Eval("OperateScore") %>
                    </td>
                    <td>
                        <%#Eval("LastOperateScore") %>
                    </td>
                    <td>
                        <%#Eval("Memo") %>
                    </td>
                </tr>
                <%if (RepeaterShow.Items.Count == 0)
                  { %>
                <tr>
                    <td colspan="6" style="height: 16px;">
                        <div class="no_data">
                            暂无数据</div>
                    </td>
                </tr>
                <% }%>
            </ItemTemplate>
        </asp:Repeater>
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
