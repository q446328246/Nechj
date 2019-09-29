<%@ Control Language="C#" EnableViewState="false"%>
<%@ Import Namespace="ShopNum1.Common" %>
<%@ Import Namespace="ShopNum1.ShopWebControl" %>
<script language="javascript" type="text/javascript">
<!--
    function reloadcode(){
    var verify=document.getElementById('Img1');
    verify.setAttribute('src','imagecode.aspx?'+Math.random());
    }
//-->
</script>

<div style="margin-top: 5px;">
    <div class="daohang" style="padding-left:30px;">发表评论</div>
    <asp:Panel ID="PanelAdd" runat="server">
        <div style="border:1px solid #D4D4D4; padding:8px; ">
            <table width="100%" border="0" cellpadding="3">
                <tr>
                    <td align="right"></td>
                    <td>
                        <asp:Label ID="LabelMemLoginID" runat="server" Visible="false"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="right">主&nbsp;&nbsp;题</td>
                    <td>
                        <asp:TextBox ID="TextBoxTitle" runat="server"></asp:TextBox>
                        <asp:Label ID="Label1" runat="server" Text="*" ForeColor="red"></asp:Label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorTitle" runat="server" ControlToValidate="TextBoxTitle"
                            Display="Dynamic" ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidatorTitle" runat="server"
                            ControlToValidate="TextBoxTitle" Display="Dynamic" ErrorMessage="只能输入50个字符" ValidationExpression="^[\s\S]{0,50}$"></asp:RegularExpressionValidator>
                    </td>
                </tr>               
                <tr>
                    <td align="right" valign="top">留言内容</td>
                    <td>
                        <asp:TextBox ID="TextBoxContent" runat="server" Height="60px" TextMode="MultiLine" Width="440px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right"><asp:Localize ID="LocalizeCode" runat="server" Text="验证码："></asp:Localize></td>
                    <td align="left">
                        <asp:TextBox ID="TextBoxCode" runat="server" CssClass="allinput1" onkeydown="if(event.keyCode==13){(document.getElementById('MessageBoardAdd_ctl00_ButtonConfrim')).focus();(document.getElementById('MessageBoardAdd_ctl00_ButtonConfrim')).click();}"></asp:TextBox>
                        <img src="imagecode.aspx" id="Img1" border="0" onclick="reloadcode()" alt="看不清?点一下" style="cursor: pointer;" />
                        <a style="cursor: pointer" onclick="reloadcode()">看不清楚?点一下</a>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>
                        <asp:Button ID="ButtonConfrim" runat="server" Text="提交评论" CssClass="bnt1" />
                    </td>
                </tr>
            </table>
        </div>
    </asp:Panel>
    <asp:Panel ID="PanelOut" runat="server">
        <div class="pada">
            请先
            <asp:LinkButton ID="LinkButtonLogin" runat="server">登录</asp:LinkButton>或
            <asp:LinkButton ID="LinkButtonRegister" runat="server">注册</asp:LinkButton>再留言 
        </div>
    </asp:Panel>
</div>
