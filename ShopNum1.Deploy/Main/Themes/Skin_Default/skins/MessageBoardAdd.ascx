<%@ Control Language="C#" %>
<%@ Import Namespace="ShopNum1.Common" %>
<%@ Import Namespace="ShopNum1.ShopWebControl" %>
<script language="javascript" type="text/javascript">
<!--
    function reloadcode() {
        var verify = document.getElementById('Img1');
        verify.setAttribute('src', 'imagecode.aspx?' + Math.random());
    }
//-->
</script>
<div class="bBox bBoxnt">
    <h2>
        我要留言：</h2>
    <div class="content" style="text-align: left;">
        <asp:Panel ID="PanelAdd" runat="server">
            <div class="accretion">
                <table width="100%" border="0" cellpadding="10">
                    <tr style="display: none;">
                        <td align="right">
                        </td>
                        <td>
                            <asp:Label ID="LabelMemLoginID" runat="server" Visible="false"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <label class="spenel">
                                主&nbsp;&nbsp;题：</label>
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxTitle" ValidationGroup="MessageBoard" CssClass="inpt_cont"
                                runat="server"></asp:TextBox>
                            <asp:Label ID="Label1" runat="server" Text="*" ForeColor="red"></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorTitle" ValidationGroup="MessageBoard"
                                runat="server" ControlToValidate="TextBoxTitle" Display="Dynamic" ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorTitle" runat="server"
                                ValidationGroup="MessageBoard" ControlToValidate="TextBoxTitle" Display="Dynamic"
                                ErrorMessage="只能输入50个字符" ValidationExpression="^[\s\S]{0,50}$"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <label class="spenel">
                                留言类型：</label>
                        </td>
                        <td align="left">
                            <div class="mold">
                                <asp:RadioButtonList ID="RadioButtonListmessageType" runat="server" RepeatColumns="6">
                                </asp:RadioButtonList>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" valign="top">
                            <label class="spenel">
                                留言内容：</label>
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxContent" CssClass="inpt_cont" runat="server" Height="60px"
                                TextMode="MultiLine" Width="440px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr id="VerifyCode" runat="server">
                        <td style="text-align: right">
                            <asp:Localize ID="LocalizeCode" runat="server" Text="验证码："></asp:Localize>
                        </td>
                        <td align="left">
                            <table cellpadding="0" cellspacing="0" border="0" style="margin: 0;">
                                <tr>
                                    <td valign="middle" align="left" style="padding-top: 0;">
                                        <asp:TextBox ID="TextBoxCode" runat="server" CssClass="inpt_cont" onkeydown="if(event.keyCode==13){(document.getElementById('MessageBoardAdd_ctl00_ButtonConfrim')).focus();(document.getElementById('MessageBoardAdd_ctl00_ButtonConfrim')).click();}"></asp:TextBox>
                                    </td>
                                    <td valign="middle" align="left" style="padding-left: 5px; padding-top: 0;">
                                        <img src="imagecode.aspx?javascript:Math.random()" id="Img1" border="0" onclick="reloadcode()"
                                            alt="看不清?点一下" style="cursor: pointer;" />
                                    </td>
                                    <td valign="middle" align="left" style="padding-left: 5px; padding-top: 0;">
                                        <a style="cursor: pointer" onclick="reloadcode()">看不清楚?点一下</a>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            <p style="padding: 5px 0px;">
                                <asp:Button ID="ButtonConfrim" ValidationGroup="MessageBoard" runat="server" Text=""
                                    CssClass="bntonts" />
                            </p>
                        </td>
                    </tr>
                </table>
            </div>
        </asp:Panel>
        <asp:Panel ID="PanelOut" runat="server">
            <div style="border: 0px solid #D4D4D4; padding: 20px;" class="pada">
                请先
                <asp:LinkButton ID="LinkButtonLogin" runat="server">登录</asp:LinkButton>或
                <asp:LinkButton ID="LinkButtonRegister" runat="server">注册</asp:LinkButton>再留言
            </div>
        </asp:Panel>
    </div>
</div>
