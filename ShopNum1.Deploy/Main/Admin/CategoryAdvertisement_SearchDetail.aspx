<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="CategoryAdvertisement_SearchDetail.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.CategoryAdvertisement_SearchDetail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>分类广告查看详细</title>
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
                    分类广告查看详细</h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <table border="0" cellpadding="0" cellspacing="0" class="shoptable">
                <tr>
                    <th align="right">
                        <div class="shopth">
                            广告名称：
                        </div>
                    </th>
                    <td>
                        <div class="shoptd">
                            <asp:TextBox ID="TextBoxPageName" ReadOnly="true" runat="server" CssClass="tinput"></asp:TextBox>
                            <span>请输入广告名称</span>
                        </div>
                    </td>
                </tr>
                <tr>
                    <th align="right">
                        <div class="shopth">
                            广告位：
                        </div>
                    </th>
                    <td>
                        <div class="shoptd">
                            <asp:DropDownList ID="DropDownListAdPageName" Enabled="false" AutoPostBack="true"
                                CssClass="tselect" runat="server" Width="180px" OnSelectedIndexChanged="DropDownListAdPageName_SelectedIndexChanged">
                                <asp:ListItem Selected="True" Value="-1">-请选择-</asp:ListItem>
                                <asp:ListItem Value="1">商品分类</asp:ListItem>
                                <asp:ListItem Value="2">分类信息分类</asp:ListItem>
                                <asp:ListItem Value="3">供求分类</asp:ListItem>
                                <asp:ListItem Value="4">店铺分类</asp:ListItem>
                                <asp:ListItem Value="5">资讯分类</asp:ListItem>
                                <asp:ListItem Value="6">品牌分类</asp:ListItem>
                            </asp:DropDownList>
                            <asp:DropDownList ID="DropDownListAdID" Enabled="false" AutoPostBack="true" runat="server"
                                CssClass="tselect" Width="180px" OnSelectedIndexChanged="DropDownListAdID_SelectedIndexChanged">
                                <asp:ListItem Selected="True" Value="-1">-请选择-</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </td>
                </tr>
                <tr>
                    <th align="right">
                        <div class="shopth">
                            广告位ID：
                        </div>
                    </th>
                    <td>
                        <div class="shoptd">
                            <asp:TextBox ID="TextBoxCategoryAdID" ReadOnly="true" runat="server" CssClass="tinput"></asp:TextBox>
                            <span>请输入广告位ID</span>
                        </div>
                    </td>
                </tr>
                <tr>
                    <th align="right">
                        <div class="shopth">
                            广告分类：
                        </div>
                    </th>
                    <td>
                        <div class="shoptd">
                            <asp:DropDownList ID="DropDownListCategory1" Width="180" Enabled="false" AutoPostBack="true"
                                CssClass="tselect" runat="server" OnSelectedIndexChanged="DropDownListCategory1_SelectedIndexChanged">
                                <asp:ListItem Selected="True" Value="-1">-请选择-</asp:ListItem>
                            </asp:DropDownList>
                            <asp:DropDownList ID="DropDownListCategory2" Width="180" Enabled="false" AutoPostBack="true"
                                CssClass="tselect" runat="server" OnSelectedIndexChanged="DropDownListCategory2_SelectedIndexChanged">
                                <asp:ListItem Selected="True" Value="-1">-请选择-</asp:ListItem>
                            </asp:DropDownList>
                            <asp:DropDownList ID="DropDownListCategory3" Width="180" Enabled="false" runat="server"
                                CssClass="tselect">
                                <asp:ListItem Selected="True" Value="-1">-请选择-</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </td>
                </tr>
                <tr>
                    <th align="right">
                        <div class="shopth">
                            广告默认图片：
                        </div>
                    </th>
                    <td>
                        <div class="shoptd">
                            <asp:TextBox ID="TextBoxDefaultPic" ReadOnly="true" CssClass="tinput" runat="server"></asp:TextBox>
                            <img id="ImageOriginalImge2" alt="" src="" runat="server" />
                            <span>请输入广告默认图片</span>
                        </div>
                    </td>
                </tr>
                <tr>
                    <th align="right">
                        <div class="shopth">
                            广告现在的图片：
                        </div>
                    </th>
                    <td>
                        <div class="shoptd">
                            <asp:TextBox ID="TextBoxNowPic" ReadOnly="true" CssClass="tinput" runat="server"></asp:TextBox>
                            <img id="ImgNowPic" alt="" src="" runat="server" />
                            <span>请输入广告现在的图片</span>
                        </div>
                    </td>
                </tr>
                <tr>
                    <th align="right">
                        <div class="shopth">
                            广告默认链接
                        </div>
                    </th>
                    <td>
                        <div class="shoptd">
                            <asp:TextBox ID="TextBoxDefaultLikeAddress" ReadOnly="true" MaxLength="200" CssClass="tinput"
                                runat="server"></asp:TextBox>
                            <span>请输入广告默认链接</span>
                        </div>
                    </td>
                </tr>
                <tr>
                    <th align="right">
                        <div class="shopth">
                            广告现在的链接：
                        </div>
                    </th>
                    <td>
                        <div class="shoptd">
                            <asp:TextBox ID="TextBoxNowLikeAddress" ReadOnly="true" MaxLength="200" CssClass="tinput"
                                runat="server"></asp:TextBox>
                            <span>请输入广告现在的链接</span>
                        </div>
                    </td>
                </tr>
                <tr>
                    <th align="right">
                        <div class="shopth">
                            广告价格：
                        </div>
                    </th>
                    <td>
                        <div class="shoptd">
                            <asp:TextBox ID="TextBoxAdPrice" ReadOnly="true" MaxLength="200" CssClass="tinput"
                                runat="server"></asp:TextBox>
                            <span>请输入广告价格</span>
                        </div>
                    </td>
                </tr>
                <tr>
                    <th align="right">
                        <div class="shopth">
                            广告流量：
                        </div>
                    </th>
                    <td>
                        <div class="shoptd">
                            <asp:TextBox ID="TextBoxAdflow" ReadOnly="true" MaxLength="200" CssClass="tinput"
                                runat="server"></asp:TextBox>（每天）
                        </div>
                    </td>
                </tr>
                <tr>
                    <th align="right">
                        <div class="shopth">
                            广告描述：
                        </div>
                    </th>
                    <td>
                        <div class="shoptd">
                            <asp:TextBox ID="TextBoxAdIntroduce" ReadOnly="true" MaxLength="200" CssClass="tinput"
                                runat="server"></asp:TextBox>
                            <span>请输入广告描述</span>
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
                            <asp:CheckBox ID="CheckBoxIsShow" Enabled="false" Checked="true" runat="server" />
                            <span>请选择</span>
                        </div>
                    </td>
                </tr>
                <tr>
                    <th align="right">
                        <div class="shopth">
                            是否购买：
                        </div>
                    </th>
                    <td>
                        <div class="shoptd">
                            <asp:DropDownList ID="DropDownListIsBuy" Width="180" Enabled="false" runat="server"
                                CssClass="tselect">
                                <asp:ListItem Selected="True" Value="0">未购买</asp:ListItem>
                                <asp:ListItem Value="1">已购买</asp:ListItem>
                            </asp:DropDownList>
                            <span>请选择</span>
                        </div>
                    </td>
                </tr>
            </table>
            <div class="tablebtn">
                <asp:Button ID="ButtonBack" CssClass="fanh" runat="server" Text="返回列表" OnClick="ButtonBack_Click" />
            </div>
        </div>
    </div>
    <asp:HiddenField ID="hiddenFieldGuid" Value="-1" runat="server" />
    <asp:HiddenField ID="HiddenFieldCategoryCode" Value="-1" runat="server" />
    </form>
</body>
</html>
