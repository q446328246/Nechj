<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="A_ProtectingTheDeal_SMS.ascx.cs" Inherits="ShopNum1.Deploy.Main.Account.Skin.A_ProtectingTheDeal_SMS" %>
<div id="mobilecheck" runat="server">
    <div class="main-right" id="main-right">
        <div class="ps_width clearfix">
            <h1 class="bw h1c">
            </h1>
         
            <div class="notify main_tip">
                <div class="notify_correct">
                    <span>
                       
                        <asp:LinkButton ID="LinkButtonMobile" runat="server" CssClass="f14 bw rw notify_correct_text">通过手机开启或关闭资金保护。</asp:LinkButton>
                    </span>
                    <ul>
                        <li>可以用绑定的手机号码进行资金保护的开启或关闭</li>
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
                           
                            <li>如您未在5分钟内接收到验证码，可能是商城系统繁忙请换个时段重置交易密码。 </li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>