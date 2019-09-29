<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="TbCIDSpecification.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.TbCIDSpecification" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>导入淘宝分类规格</title>
    <link rel='stylesheet' type='text/css' href='style/css.css' />
    <script type="text/javascript" language="javascript" src="js/CommonJS.js"> </script>
</head>
<!--淘宝分类 -->
<body>
    <form id="form1" runat="server">
    <div id="right">
        <div class="rhigth">
            <div class="rl">
            </div>
            <div class="rcon">
                <h3>
                    淘宝分类列表</h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="order_edit">
                <table>
                    <tr type="taobao">
                        <td colspan="2">
                            <div class="htweb_top">
                                <div class="toptitle">
                                </div>
                                <div class="topk" style="float: left; margin-right: 10px;">
                                    <asp:ListBox ID="ListBoxTop" runat="server" Style="overflow: auto" Height="210px"
                                        Width="189px" CssClass="tinput" AutoPostBack="true" OnSelectedIndexChanged="ListBoxTop_SelectedIndexChanged">
                                        <asp:ListItem Value="1">游戏话费           -></asp:ListItem>
                                        <asp:ListItem Value="2">服装鞋包           -></asp:ListItem>
                                        <asp:ListItem Value="3">手机数码           -></asp:ListItem>
                                        <asp:ListItem Value="4">家用电器           -></asp:ListItem>
                                        <asp:ListItem Value="5">美妆饰品           -></asp:ListItem>
                                        <asp:ListItem Value="6">母婴用品           -></asp:ListItem>
                                        <asp:ListItem Value="7">家居建材           -></asp:ListItem>
                                        <asp:ListItem Value="8">百货食品           -></asp:ListItem>
                                        <asp:ListItem Value="9">运动户外           -></asp:ListItem>
                                        <asp:ListItem Value="10">文化玩乐           -></asp:ListItem>
                                        <asp:ListItem Value="11">生活服务           -></asp:ListItem>
                                        <asp:ListItem Value="12">其他           -></asp:ListItem>
                                    </asp:ListBox>
                                </div>
                                <div class="topk" style="float: left; margin-right: 10px;">
                                    <asp:ListBox ID="lbox1" runat="server" Style="overflow: auto" Height="210px" Width="189px"
                                        CssClass="tinput" OnSelectedIndexChanged="lbox1_SelectedIndexChanged" AutoPostBack="true">
                                    </asp:ListBox>
                                </div>
                                <div class="topk" style="float: left; margin-right: 10px;">
                                    <asp:ListBox ID="lbox2" runat="server" Height="210px" Width="189px" Visible="false"
                                        CssClass="tinput" AutoPostBack="true" OnSelectedIndexChanged="lbox2_SelectedIndexChanged">
                                    </asp:ListBox>
                                </div>
                                <div class="topk" style="float: left; margin-right: 10px;">
                                    <asp:ListBox ID="lbox3" runat="server" Style="overflow: auto:" Height="210px" Width="189px"
                                        CssClass="tinput" Visible="false" AutoPostBack="true" OnSelectedIndexChanged="lbox3_SelectedIndexChanged">
                                    </asp:ListBox>
                                </div>
                                <div class="topk" style="float: left; margin-right: 10px;">
                                    <asp:ListBox ID="lbox4" runat="server" Height="210px" Visible="false" Width="189px"
                                        CssClass="tinput" OnSelectedIndexChanged="lbox4_SelectedIndexChanged" AutoPostBack="true">
                                    </asp:ListBox>
                                </div>
                                <div class="topk" style="float: left; margin-right: 10px;">
                                    <asp:ListBox ID="lbox5" runat="server" Style="overflow: auto:" Height="210px" Width="189px"
                                        CssClass="tinput" Visible="false"></asp:ListBox>
                                </div>
                            </div>
                            <!-- 隔开 -->
                            <div class="gk">
                            </div>
                        </td>
                    </tr>
                </table>
                <div style="margin-top: 20px;">
                    <asp:Button ID="ButtonCatetory" CssClass="fanh" runat="server" Text="导入分类" OnClick="ButtonCatetory_Click" /><span
                        style="color: Red">注意：导入分类只能选择一级分类导入!</span>
                    <asp:Button ID="Button1" CssClass="fanh" runat="server" Text="导入规格" OnClick="Button1_Click" />
                    <span style="color: Red">注意：导入规格属性要选择最底级分类，导入相应淘宝分类下的规格和属性。</span>
                </div>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
