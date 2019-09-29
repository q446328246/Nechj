<%@ Control Language="C#" AutoEventWireup="True" CodeBehind="M_MyComplaints.ascx.cs" Inherits="ShopNum1.Deploy.Main.Member.Skin.M_MyComplaints" %>

<div id="content" class="ordmain1">
    <div class="pad">
        <table border="0" cellspacing="0" cellpadding="0" class="lineh">
            <tr class="up_spac">
                <td align="right">
                    投诉类型：
                </td>
                <td>
                    <asp:DropDownList ID="DropDownListType" runat="server" CssClass="tselect">
                        <asp:ListItem Value="-1">-全部-</asp:ListItem>
                        <asp:ListItem Value="恶意骚扰">恶意骚扰</asp:ListItem>
                        <asp:ListItem Value="售后保障服务">售后保障服务</asp:ListItem>
                        <asp:ListItem Value="未收到货">未收到货</asp:ListItem>
                        <asp:ListItem Value="违背承诺">违背承诺</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td align="right" class="ss_nr_spac">
                    投诉状态：
                </td>
                <td>
                    <asp:DropDownList ID="DropDownListStatus" runat="server" CssClass="tselect">
                        <asp:ListItem Value="-1">-全部-</asp:ListItem>
                        <asp:ListItem Value="0">未处理</asp:ListItem>
                        <asp:ListItem Value="1">处理中</asp:ListItem>
                        <asp:ListItem Value="2">已处理</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:Button ID="ButtonSearch" runat="server" Text="查询" CssClass="chax btn_spc" 
                        name="12" onclick="ButtonSearch_Click" />
                </td>
            </tr>
        </table>
    </div>
    <div class="btntable_tbg">
        <table width="100%" border="0" cellspacing="0" cellpadding="5" class="btntable_t">
            <tr>
                <td style="border-left: solid 1px #e3e3e3;">
                    <div class="shanc">
                        <a href="#" class="shanchu lmf_btn">批量删除</a>
                    </div>
                    <div class="shanc" style="display: none;">
                        <a href="M_MemberComplaints.aspx" class="woyaots lmf_btn">我要投诉</a>
                    </div>
                </td>
            </tr>
        </table>
    </div>
    <table width="100%" border="0" cellspacing="0" cellpadding="5" class="blue_tb2">
        <tr>
            <th width="4%" class="th_le">
                <input name="checktop" type="checkbox" title="全选" />
            </th>
            <th width="10%">
                投诉编号
            </th>
            <th width="10%">
                订单编号
            </th>
            <th width="15%">
                投诉商家
            </th>
            <th width="20%">
                投诉类型
            </th>
            <th width="11%">
                平台处理
            </th>
            <th width="20%">
                投诉时间
            </th>
            <th width="10%" class="th_ri">
                操作
            </th>
        </tr>
        <asp:Repeater ID="RepeaterShow" runat="server">
            <ItemTemplate>
                <tr>
                    <td>
                        <input name="checksub" type="checkbox" value='<%#Eval("ID")%>' />
                    </td>
                    <td>
                        <%#Eval("ID")%>
                    </td>
                    <td>
                        <%#Eval("OrderID")%>
                    </td>
                    <td>
                        <%#Eval("ComplaintShop")%>
                    </td>
                    <td>
                        <%#Eval("ComplaintType")%>
                    </td>
                    <td>
                        <%#ShopNum1.MemberWebControl.M_MyReport.ProcessingStatus( Eval("ProcessingStatus").ToString())%>
                    </td>
                    <td>
                        <%#Eval("ComplaintTime")%>
                    </td>
                    <td>
                        <a href="M_ComplaintsDetailed.aspx?ID=<%#Eval("ID")%>">查看</a>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
        <%if (RepeaterShow.Items.Count == 0)
          { %>
        <tr>
            <td colspan="8" style="height: 16px; border-left: solid 1px #e3e3e3; border-right: solid 1px #e3e3e3;">
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
