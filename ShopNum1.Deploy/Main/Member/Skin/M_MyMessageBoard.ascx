<%@ Control Language="C#" AutoEventWireup="True" CodeBehind="M_MyMessageBoard.ascx.cs" Inherits="ShopNum1.Deploy.Main.Member.Skin.M_MyMessageBoard" %>

<div id="content" class="ordmain1">
    <div class="pad">
        <table border="0" cellspacing="0" cellpadding="0" class="lineh">
            <tr class="up_spac">
                <td align="right">
                    留言类型：
                </td>
                <td>
                    <asp:DropDownList ID="DropDownListMessageType" runat="server" CssClass="tselect">
                        <asp:ListItem Value="-1">-全部-</asp:ListItem>
                        <asp:ListItem Value="0">售后</asp:ListItem>
                        <asp:ListItem Value="1">询问</asp:ListItem>
                        <asp:ListItem Value="2">一般信息</asp:ListItem>
                        <asp:ListItem Value="3">求购</asp:ListItem>
                        <asp:ListItem Value="4">留言</asp:ListItem>
                        <asp:ListItem Value="5">重要消息</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td align="right" class="ss_nr_spac">
                    是否回复：
                </td>
                <td>
                    <asp:DropDownList ID="DropDownListIsReply" runat="server" CssClass="tselect">
                        <asp:ListItem Value="-1">-全部-</asp:ListItem>
                        <asp:ListItem Value="0">否</asp:ListItem>
                        <asp:ListItem Value="1">是</asp:ListItem>
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
        <div class="shanc">
            <a href="#" class="shanchu lmf_btn">批量删除</a>
        </div>
    </div>
    <table width="100%" border="0" cellspacing="0" cellpadding="5" class="blue_tbw1">
        <tr>
            <th class="th_le" width="4%">
                <input name="checktop" type="checkbox" title="全选" />
            </th>
            <th width="10%">
                留言类型
            </th>
            <th width="30%">
                留言标题
            </th>
            <th width="16%">
                留言店铺
            </th>
            <th width="20%">
                留言时间
            </th>
            <th width="10%">
                是否回复
            </th>
            <th width="10%" class="th_ri">
                操作
            </th>
        </tr>
        <asp:Repeater ID="RepeaterShow" runat="server">
            <ItemTemplate>
                <tr>
                    <td class="th_le">
                        <input name="checksub" type="checkbox" value='<%#Eval("Guid")%>' />
                    </td>
                    <td>
                        <%#ShopNum1.MemberWebControl.M_MyMessageBoard.GetMessageTypeName(Eval("MessageType").ToString())%>
                    </td>
                    <td>
                        <%#Eval("Title").ToString().Length>16?Eval("Title").ToString().Substring(0,16):Eval("Title").ToString() %>
                    </td>
                    <td>
                        <a target="_blank" href='<%#ShopUrlOperate.shopHref(Eval("ReplyUser").ToString())%>'>
                            <%#ShopNum1.MemberWebControl.M_MyMessageBoard.GetShopName(Eval("ReplyUser").ToString())%>
                        </a>
                    </td>
                    <td>
                        <%#Eval("SendTime")%>
                    </td>
                    <td>
                        <%#Eval("IsReply").ToString()=="1"?"是":"<span style=\"color:red\" >否</span>"%>
                    </td>
                    <td class="th_ri">
                        <a href="M_MyMessageBoardDetailed.aspx?guid=<%#Eval("Guid")%>">查看</a>
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
