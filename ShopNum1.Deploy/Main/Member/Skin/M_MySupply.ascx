<%@ Control Language="C#" AutoEventWireup="True" CodeBehind="M_MySupply.ascx.cs" Inherits="ShopNum1.Deploy.Main.Member.Skin.M_MySupply" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="ShopNum1.Common" %>
<div id="content" class="ordmain1">
    <div class="pad">
        <table border="0" cellspacing="0" cellpadding="0" class="lineh">
            <tr class="up_spac">
                <td align="right">
                    审核状态：
                </td>
                <td>
                    <asp:DropDownList ID="DropDownListIsAudit" runat="server" CssClass="tselect">
                        <asp:ListItem Value="-1">-全部-</asp:ListItem>
                        <asp:ListItem Value="0">未审核</asp:ListItem>
                        <asp:ListItem Value="2">审核未通过</asp:ListItem>
                        <asp:ListItem Value="3">审核通过</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td align="right" class="ss_nr_spac">
                    类型：
                </td>
                <td>
                    <asp:DropDownList ID="DropDownListType" runat="server" CssClass="tselect">
                        <asp:ListItem Value="-1">-全部-</asp:ListItem>
                        <asp:ListItem Value="0">供</asp:ListItem>
                        <asp:ListItem Value="1">求</asp:ListItem>
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
                <td class="dind_l">
                    <div class="shanc">
                        <a href="#" class="shanchu lmf_btn">批量删除</a>
                    </div>
                    <div class="shanc">
                        <a href="M_AddSupply.aspx" class="tianjiafl lmf_btn">添加供求</a>
                    </div>
                </td>
            </tr>
        </table>
    </div>
    <table width="100%" border="0" cellspacing="0" cellpadding="5" class="blue_tbw1">
        <tr>
            <th width="4%" class="th_le">
                <input name="checktop" type="checkbox" title="全选" />
            </th>
            <th width="10%">
                类型
            </th>
            <th width="22%">
                信息标题
            </th>
            <th width="20%">
                发布时间
            </th>
            <th width="20%">
                有效期
            </th>
            <th width="14%">
                审核状态
            </th>
            <th width="10%" class="th_ri">
                操作
            </th>
        </tr>
        <asp:Repeater ID="RepeaterShow" runat="server">
            <ItemTemplate>
                <tr>
                    <td class="th_le">
                        <input name="checksub" type="checkbox" value='<%#Eval("ID")%>' />
                    </td>
                    <td>
                        <%#Eval("TradeType").ToString()=="0"?"供":"求"%>
                    </td>
                    <td>
                        <a target="_blank" href='<%# ShopUrlOperate.RetUrl("SupplyDemandDetail",((DataRowView)Container.DataItem).Row["ID"]) %>'>
                            <%# Utils.GetUnicodeSubString(Eval("Title").ToString(), 24, "")%>
                        </a>
                    </td>
                    <td>
                        <%#Eval("ReleaseTime")%>
                    </td>
                    <td>
                        <%#Eval("ValidTime")%>
                    </td>
                    <td>
                        <%#ShopNum1.MemberWebControl.M_MySupply.IsAudit(Eval("IsAudit").ToString())%>
                    </td>
                    <td class="th_ri">
                        <a href="M_AddSupply.aspx?ID=<%#Eval("ID")%>">编辑</a>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
        <%if (RepeaterShow.Items.Count == 0)
          { %>
        <tr>
            <td colspan="7" style="height: 16px; border-left: solid 1px #e3e3e3; border-right: solid 1px #e3e3e3;">
                <div class="no_data">
                    没有数据！</div>
            </td>
        </tr>
        <% }%>
    </table>
    <div class="shangpinkjdd">
        <!--分页-->
        <div class="btntable_tbg">
            <div id="pageDiv" runat="server" class="fy">
            </div>
        </div>
        <!--分页-->
    </div>
</div>
