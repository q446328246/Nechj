<%@ Control Language="C#" AutoEventWireup="True" CodeBehind="A_PwdSer.ascx.cs" Inherits="ShopNum1.Deploy.Main.Account.Skin.A_PwdSer" %>
<div class="zhszmian">
    <div class="zhszmian_nr">
        <div class="zhs_le">
            <dl>
                <dt>�����˺Ű�ȫ�ȼ���<span class="redbold">
                    <asp:Label ID="Lab_SafeRank" runat="server" Text=""></asp:Label>
                </span></dt>
                <dd>
                    <asp:Image ID="Image_SafeRankImg" runat="server" Width="360" Height="13" />
                </dd>
                <dd>
                    <asp:Label ID="Lab_SafeRankTitle" runat="server" Text=""></asp:Label></dd>
            </dl>
        </div>
        <div class="zhs_ri">
            <ul>
                <li>����˺Ű�ȫ�ȼ��������ԣ�</li>
                <li>
                    <asp:LinkButton ID="LinkButton_Mobile" runat="server" CssClass="alink_blue" PostBackUrl="../A_BindMobile.aspx">�ֻ���</asp:LinkButton>
                    <asp:LinkButton ID="LinkButton_Email" runat="server" CssClass="alink_blue" PostBackUrl="../A_BindEmail.aspx">�����</asp:LinkButton></li>
                <%--<li>
                    <asp:LinkButton ID="LinkButton_Set" runat="server" CssClass="alink_blue" PostBackUrl="<% =Url1 %>">���ý�������</asp:LinkButton>
                </li>--%>
            </ul>
        </div>
    </div>
    <div style="clear: both;">
    </div>
    <div class="dengl">
        <div class="denflot done">
            ��¼����
        </div>
        <div class="denflot dtwo">
            <ul>
                <li>��¼�̳�ʱ��Ҫʹ�õ����롣</li>
                <li><span class="orange">��������˺ű����ֶΣ��벻Ҫ���׸�֪���ˡ�</span></li>
            </ul>
        </div>
        <div class="denflot dthree">
            <a href="A_UpPwd.aspx" class="xiug" target="win" onclick="subItem(this)">�޸� </a>
        </div>
    </div>
    <div class="dengl">
        <div class="denflot" id="divTradePwd">
            ��������
            <asp:HiddenField ID="hfTradePwd" runat="server" />
        </div>
        <div class="denflot dtwo">
            <ul>
                <li>����������Ϊ���ṩ����İ�ȫ���ϡ����ý������룬Ϊ��Ľ��ױ��ݻ�����</li>
                <li><span class="orange">���¼���벻ͬ������������ڽ��е��̹������֧���Ȳ���ʱ����Ҫ���롣</span></li>
            </ul>
        </div>
        <div class="denflot dthree">
            <a href="<% =Url2 %>" class="xiug" target="win" onclick="subItem(this)">����
            </a>
        </div>
    </div>
    <div class="dengl">
        <div class="denflot done" id="div1">
            �����ʽ𱣻�
            <asp:HiddenField ID="HiddenField1" runat="server" />
        </div>
        <div class="denflot dtwo">
            <ul>
                <li>������ת�ˡ�������Ҫ������֤</li>
                <li><span class="orange">����������ڴ˴����йر�</span></li>
            </ul>
        </div>
        <div class="denflot dthree">
            <a href="A_ProtectingTheDeal.aspx" class="xiug" target="win" onclick="subItem(this)">����
            </a>
        </div>
    </div>
</div>
<script type="text/javascript" language="javascript">
    $(function () {
        //���ù��������������ʽ
        if ($("#<%= hfTradePwd.ClientID %>").val() == "0") {
            $("#divTradePwd").addClass("done2");
        }
        else {
            $("#divTradePwd").addClass("done");
        }
    })
    
</script>
