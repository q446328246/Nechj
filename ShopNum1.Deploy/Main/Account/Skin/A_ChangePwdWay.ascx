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
                        <asp:LinkButton ID="LinkButtonEmail" runat="server" CssClass="f14 bw rw notify_correct_text">ͨ���������ý������롣</asp:LinkButton>
                    </span>
                    <ul>
                        <li>�����ð󶨵������˺Ž��е�½�����н���������޸ĵȲ�����</li>
                        <li>�̳ǻ��������Ϣ�ϸ��ܡ�</li>
                    </ul>
                </div>
            </div>
            <div class="notify main_tip">
                <div class="notify_correct">
                    <span>
                        <%--     <a  href="A_CheckMobile.aspx"  style="text-decoration:none;"  class="f14 bw rw notify_correct_text"  >ͨ���ֻ����ý������롣</a> --%>
                        <asp:LinkButton ID="LinkButtonMobile" runat="server" CssClass="f14 bw rw notify_correct_text">ͨ���ֻ����ý������롣</asp:LinkButton>
                    </span>
                    <ul>
                        <li>�����ð󶨵��ֻ�������е�½�����н���������޸ĵȲ�����</li>
                        <li>�̳ǻ��������Ϣ�ϸ��ܡ�</li>
                    </ul>
                </div>
            </div>
            <div class="form_top">
                <div class="form_row form_height_auto_row clearfix">
                    <div class="bp_faq">
                        <h4 class="bw f16">
                            ����˵����
                        </h4>
                        <ul>
                            <li class="bw bp_q">�÷�����ȫ��ѣ� </li>
                            <li>���󶨵�����������˺ŵ�¼�����������޸ĵ���;�������Ʊ��棻 </li>
                            <li>����δ��5�����ڽ��յ���֤�룬�������̳�ϵͳ��æ�뻻��ʱ�����ý������롣 </li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
