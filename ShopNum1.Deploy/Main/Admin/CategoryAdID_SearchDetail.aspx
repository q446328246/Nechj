<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="CategoryAdID_SearchDetail.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.CategoryAdID_SearchDetail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>分类广告位查看详细</title>
    <link href="style/css.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="right">
        <div class="rhigth">
            <div class="rl">
            </div>
            <div class="rcon">
                <h3>
                    分类广告位查看详细</h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <table border="0" cellpadding="0" cellspacing="0" class="shoptable">
                <tr>
                    <th align="right">
                        <div class="shopth">
                            广告位ID：
                        </div>
                    </th>
                    <td>
                        <div class="shoptd">
                            <asp:TextBox ID="TextBoxID" ReadOnly="true" CssClass="tinput" runat="server"></asp:TextBox>
                            <span>请输入广告位ID</span>
                        </div>
                    </td>
                </tr>
                <tr>
                    <th align="right">
                        <div class="shopth">
                            广告位名称：
                        </div>
                    </th>
                    <td>
                        <div class="shoptd">
                            <asp:TextBox ID="TextBoxCategoryAdName" CssClass="tinput" ReadOnly="true" runat="server"></asp:TextBox>
                            <span>请输入广告位名称</span>
                        </div>
                    </td>
                </tr>
                <tr>
                    <th align="right">
                        <div class="shopth">
                            广告位所在页：
                        </div>
                    </th>
                    <td>
                        <div class="shoptd">
                            <asp:TextBox ID="TextBoxCategoryType" ReadOnly="true" CssClass="tinput" runat="server"></asp:TextBox>
                            <span>请输入广告位所在页</span>
                        </div>
                    </td>
                </tr>
                <tr>
                    <th align="right">
                        <div class="shopth">
                            广告位宽度：
                        </div>
                    </th>
                    <td>
                        <div class="shoptd">
                            <asp:TextBox ID="TextBoxWidth" ReadOnly="true" CssClass="tinput" runat="server"></asp:TextBox>
                            <span>请输入广告位宽度</span>
                        </div>
                    </td>
                </tr>
                <tr>
                    <th align="right">
                        <div class="shopth">
                            广告位高度：
                        </div>
                    </th>
                    <td>
                        <div class="shoptd">
                            <asp:TextBox ID="TextBoxHeight" ReadOnly="true" CssClass="tinput" runat="server"></asp:TextBox>
                            <span>请输入广告位高度</span>
                        </div>
                    </td>
                </tr>
                <tr>
                    <th align="right">
                        <div class="shopth" style="height: 120px;">
                            广告位默认图片：
                        </div>
                    </th>
                    <td>
                        <div class="shoptd" style="height: 120px;">
                            <asp:Image ID="ImageAdDefalutPic" Height="100" Width="200" runat="server" />
                        </div>
                    </td>
                </tr>
                <tr>
                    <th align="right">
                        <div class="shopth">
                            广告位默认链接：
                        </div>
                    </th>
                    <td>
                        <div class="shoptd">
                            <asp:TextBox ID="TextBoxAdDefalutLike" ReadOnly="true" CssClass="tinput" runat="server"></asp:TextBox>
                            <span>请输入广告位默认链接</span>
                        </div>
                    </td>
                </tr>
                <tr>
                    <th align="right">
                        <div class="shopth">
                            广告位流量：
                        </div>
                    </th>
                    <td>
                        <div class="shoptd">
                            <asp:TextBox ID="TextBoxAdflow" ReadOnly="true" CssClass="tinput" runat="server"></asp:TextBox>（每天）
                        </div>
                    </td>
                </tr>
                <tr>
                    <th align="right">
                        <div class="shopth" style="border-bottom: none;">
                            广告位访问人数：
                        </div>
                    </th>
                    <td>
                        <div class="shoptd" style="border-bottom: none;">
                            <asp:TextBox ID="TextBoxvisitPeople" ReadOnly="true" CssClass="tinput" runat="server"></asp:TextBox>（每天）
                        </div>
                    </td>
                </tr>
                <tr>
                    <th align="right">
                        <div class="shopth">
                            是否显示：
                        </div>
                    </th>
                    <td>
                        <div class="shoptd">
                            <asp:CheckBox ID="CheckBoxIsShow" Checked="true" runat="server" />
                        </div>
                    </td>
                </tr>
                <tr>
                    <th align="right">
                        <div class="shopth" style="height: 120px;">
                            备注：
                        </div>
                    </th>
                    <td>
                        <div class="shoptd" style="height: 120px;">
                            <asp:TextBox ID="TextBoxIntroduce" TextMode="MultiLine" Height="100px" Width="500px"
                                CssClass="tinput" ReadOnly="true" runat="server"></asp:TextBox>
                            <span>请输入备注内容</span>
                        </div>
                    </td>
                </tr>
            </table>
            <div class="tablebtn">
                <asp:Button ID="ButtonBack" CssClass="fanh" runat="server" Text="返回列表" OnClick="ButtonBack_Click" />
            </div>
        </div>
    </div>
    </form>
</body>
</html>
