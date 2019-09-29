<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="M_MemberApproval1.ascx.cs" Inherits="ShopNum1.Deploy.Main.Member.Skin.M_MemberApproval1" %>

<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
Width="363px"  Height="207px"  onrowcommand="GridView1_RowCommand">
<Columns>

<asp:TemplateField HeaderText="请求推荐的用户" SortExpression="ip2">
<ItemTemplate>
<asp:Label ID="Label2" runat="server" Text='<%# Eval("MemloginID") %>'></asp:Label>
</ItemTemplate>
</asp:TemplateField>

<asp:TemplateField HeaderText="删除" SortExpression="ip2">
<ItemTemplate>
<asp:LinkButton ID="LinkButtonDelte" runat="server" CausesValidation="False" CommandName="Delete1"  Text="删除" OnClientClick='<%#  "if (!confirm(\"你确定要删除" + Eval("MemloginID").ToString() + "吗?\")) return false;"%>' CommandArgument='<%# Eval("MemloginID") %>'></asp:LinkButton>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="详细" SortExpression="ip2">
<ItemTemplate>
    <a href='M_MemberApprovalDetailedA.aspx?type=<%# Eval("MemloginID") %>'>详细</a>
</ItemTemplate>
</asp:TemplateField>
</Columns>


</asp:GridView>


