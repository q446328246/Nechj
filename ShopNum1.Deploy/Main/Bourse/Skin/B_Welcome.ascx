<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="B_Welcome.ascx.cs" Inherits="ShopNum1.Deploy.Main.Bourse.Skin.B_Welcome" %>
<%@ Import Namespace="ShopNum1.Common" %>
<%@ Import Namespace="System.Data" %>

<script src="../js/jquery-1.6.2.min.js" type="text/javascript"></script>
<script src="../js/channle.js" type="text/javascript"></script>

<div class="right_mian">
    <div class="wel">
        <div class="wel_right1">
            <p style="padding-top: 8px;">
                <span class="redht">
                    <asp:Label ID="LabelMemLoginID" runat="server" Text=""></asp:Label></span>，欢迎您！</p>
            <p style="padding-top: 8px;">
                登录次数：<strong class="red"><asp:Label ID="LabelLoginTime" runat="server" Text=""></asp:Label></strong>
                次
                <asp:Label ID="LabelShowShang" runat="server" Text="您上一次登录的时间："></asp:Label>
                <span class="orange">
                    <asp:Label ID="LabelLastLoginTime" runat="server" Text=""></asp:Label></span></p>
            <p style="padding-top: 8px;">
                <table cellpadding="0" cellspacing="0" border="0">
                    <tr>
                        <td>
                            <span class="shouj1" style="color: #005ea7; padding-right: 8px;">会员等级: </span>
                        </td>
                        <td style="padding-right: 10px;">
                            <asp:Image ID="ImageRank" runat="server" Style="height: 16px"></asp:Image>
                        </td>
                        <td>
                            <a href="javascript:void(0)" class="shouj" runat="server" id="Sjyz" style="color: #005ea7;">
                                手机已验证</a>
                        </td>
                        <td>
                            <a href="javascript:void(0)" class="youx" runat="server" id="Yxyz" style="color: #005ea7;">
                                邮箱已验证</a>
                        </td>
                        <td>
                            <a class="shouj11" runat="server" id="Sjwyz" style="color: #005ea7;" href="/main/account/A_PwdSer.aspx">
                                手机未验证</a>
                        </td>
                        <td>
                            <a class="youx11" runat="server" id="Yxwyz" style="color: #005ea7;" href="/main/account/A_PwdSer.aspx">
                                邮箱未验证</a>
                        </td>
                        <td>
                        </td>
                    </tr>
                </table>
            </p>
            <div style="clear: both">
            </div>
            <div style="border: solid 1px #ffeacd; margin-top: 7px; padding: 6px; width: 95%;">
                <table border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td>
                            当前人民币：
                        </td>
                        <td>
                            <strong class="red">￥<asp:Label ID="LabelAdvancePayment" runat="server" Text="0.00"></asp:Label></strong>
                        </td>
                        <td style="padding-left: 10px;">
                            <input name="12" type="button" class="chax" value="充值" onclick="funGoPay()" />
                        </td>
                        <td>
                            当前重销积分：
                        </td>
                        <td style="padding-left: 10px;">
                            <strong class="red">￥<asp:Label ID="LabelScore_dv" runat="server" Text="0.00"></asp:Label></strong>
                        </td>
                        <td style="padding-left: 10px;">
                        </td>
                    </tr>
                   
                </table>
            </div>
        </div>
    </div>

    
    
</div>
