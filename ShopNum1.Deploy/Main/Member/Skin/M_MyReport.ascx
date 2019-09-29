<%@ Control Language="C#" AutoEventWireup="True" CodeBehind="M_MyReport.ascx.cs" Inherits="ShopNum1.Deploy.Main.Member.Skin.M_MyReport" %>

<div id="content" class="ordmain1">
    <div class="pad">
        <table border="0" cellspacing="0" cellpadding="0" class="lineh">
            <tr class="up_spac">
                <td align="right">
                    举报类型：
                </td>
                <td>
                    <asp:DropDownList ID="DropDownListType" runat="server" CssClass="tselect">
                        <asp:ListItem Value="-1">-全部-</asp:ListItem>
                        <asp:ListItem Value="炒作信用度">炒作信用度</asp:ListItem>
                        <asp:ListItem Value="哄抬物价">哄抬物价</asp:ListItem>
                        <asp:ListItem Value="图片发布侵权">图片发布侵权</asp:ListItem>
                        <asp:ListItem Value="发布广告信息">发布广告信息</asp:ListItem>
                        <asp:ListItem Value="支付方式不符合商品">支付方式不符合商品</asp:ListItem>
                        <asp:ListItem Value="出售禁售货">出售禁售货</asp:ListItem>
                        <asp:ListItem Value="放错类目属性">放错类目属性</asp:ListItem>
                        <asp:ListItem Value="重复铺货">重复铺货</asp:ListItem>
                        <asp:ListItem Value="滥用关键字">滥用关键字</asp:ListItem>
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
        <table border="0" cellspacing="0" cellpadding="5" class="btntable_t">
            <tr>
                <td>
                    <div class="shanc">
                        <a href="#" class="shanchu lmf_btn">批量删除</a>
                    </div>
                    <div class="shanc">
                        <a href="M_MemberReport.aspx" class="woyaots lmf_btn">我要举报</a>
                    </div>
                </td>
            </tr>
        </table>
    </div>
    <table width="100%" border="0" cellspacing="1" cellpadding="5" class="blue_tb2">
        <tr>
            <th width="4%" class="th_le">
                <input name="checktop" type="checkbox" title="全选" />
            </th>
            <th width="10%">
                举报编号
            </th>
            <th width="15%">
                举报对象
            </th>
            <th width="25%">
                举报类型
            </th>
            <th width="11%">
                平台处理
            </th>
            <th width="20%">
                举报时间
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
                        <%#Eval("ReportShop")%>
                    </td>
                    <td>
                        <%#Eval("ReportType")%>
                    </td>
                    <td>
                        <%#ShopNum1.MemberWebControl.M_MyReport.ProcessingStatus( Eval("ProcessingStatus").ToString())%>
                    </td>
                    <td>
                        <%#Eval("ReportTime")%>
                    </td>
                    <td>
                        <a href="M_ReportDetailed.aspx?ID=<%#Eval("ID")%>">查看</a>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
        <%if (RepeaterShow.Items.Count == 0)
          { %>
        <tr>
            <td colspan="7" style="height: 16px; border-left: solid 1px #e3e3e3; border-right: solid 1px #e3e3e3;">
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
