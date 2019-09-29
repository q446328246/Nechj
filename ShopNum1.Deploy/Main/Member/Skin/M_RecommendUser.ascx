<%@ Control Language="C#" AutoEventWireup="True" CodeBehind="M_RecommendUser.ascx.cs"
    Inherits="ShopNum1.Deploy.Main.Member.Skin.M_RecommendUser" %>
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
                <td>
                    <asp:Button ID="ButtonSearch" runat="server" Text="查询" class="chax btn_spc" name="12"
                        OnClick="ButtonSearch_Click" />
                </td>
            </tr>
        </table>
    </div>
    <div class="btntable_tbg">
        <div class="shanc">
            <a class="shanchu21 lmf_btn" href="M_RecommendUserLink.aspx">生成推广链接</a>
        </div>
    </div>
    <table width="100%" cellspacing="0" cellpadding="5" class="blue_tb2">
        <tr>
            <th class="th_le">
                会员ID
            </th>
            <th>
                会员姓名
            </th>
            <th>
                电子邮件
            </th>
            <th class="th_ri">
                手机号码
            </th>
        </tr>
        <asp:Repeater ID="RepeaterShow" runat="server">
            <ItemTemplate>
                <tr>
                    <td>
                        <%#Eval("MemLoginID")%>
                    </td>
                    <td>
                        <%#Eval("RealName")%>
                    </td>
                    <td>
                        <%#Eval("Email")%>
                    </td>
                    <td>
                        <%#Eval("Mobile")%>
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
