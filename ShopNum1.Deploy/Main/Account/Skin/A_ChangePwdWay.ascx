<%@ Control Language="C#" AutoEventWireup="True" CodeBehind="A_ChangePwdWay.ascx.cs"
    Inherits="ShopNum1.Deploy.Main.Account.Skin.A_ChangePwdWay" %>
<div id="mobilecheck" runat="server">
    <div class="main-right" id="main-right">
        <div class="ps_width clearfix">
            <h1 class="bw h1c">
            </h1>
            <div class="notify main_tip">
                <div class="notify_correct">
                    <span>
                        <%--  <a  href="A_CheckEmail.aspx" style="text-decoration:none;"   class="f14 bw rw notify_correct_text" ></a>--%>
                        <asp:LinkButton ID="LinkButtonEmail" runat="server" CssClass="f14 bw rw notify_correct_text">通过邮箱重置交易密码。</asp:LinkButton>
                    </span>
                    <ul>
                        <li>可以用绑定的邮箱账号进行登陆，进行交易密码的修改等操作。</li>
                        <li>商城会对您的信息严格保密。</li>
                    </ul>
                </div>
            </div>
            <div class="notify main_tip">
                <div class="notify_correct">
                    <span>
                        <%--     <a  href="A_CheckMobile.aspx"  style="text-decoration:none;"  class="f14 bw rw notify_correct_text"  >通过手机重置交易密码。</a> --%>
                        <asp:LinkButton ID="LinkButtonMobile" runat="server" CssClass="f14 bw rw notify_correct_text">通过手机重置交易密码。</asp:LinkButton>
                    </span>
                    <ul>
                        <li>可以用绑定的手机号码进行登陆，进行交易密码的修改等操作。</li>
                        <li>商城会对您的信息严格保密。</li>
                    </ul>
                </div>
            </div>
            <div class="form_top">
                <div class="form_row form_height_auto_row clearfix">
                    <div class="bp_faq">
                        <h4 class="bw f16">
                            服务说明：
                        </h4>
                        <ul>
                            <li class="bw bp_q">该服务完全免费； </li>
                            <li>您绑定的邮箱可用于账号登录，交易密码修改等用途，请妥善保存； </li>
                            <li>如您未在5分钟内接收到验证码，可能是商城系统繁忙请换个时段重置交易密码。 </li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
