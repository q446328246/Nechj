<%@ Control Language="C#" EnableViewState="false"%>

<div class="sp_dialog_info">
            <p class="sp_general info_title">
                ����ϸ��д������Ϣ��</p>
            <p class="sp_general">
                <label class="sp_lable">
                    �һ�������</label>
                <asp:TextBox ID="TextBoxNumber" runat="server" class="sp_input" onblur="funCheckNum()" ReadOnly="true" ></asp:TextBox>
                    <span id="SpanNumErr"></span>
                    <span id="SpanNumRight" style=" display:block">
                        <img src="/ImgUpload/shopNum1Admin-right.gif"/>
                    </span>
                </p>
            <p class="sp_general">
                <label class="sp_lable">
                    �ջ���������</label>
                <asp:TextBox ID="TextBoxMemLoginID" runat="server" class="sp_input" onblur="funCheckName()"></asp:TextBox>    
                    <span id="SpanMemLoginIDErr">*</span>
                    <span id="SpanMemLoginIDRight" style=" display:none">
                        <img src="/ImgUpload/shopNum1Admin-right.gif"/>
                    </span>
                    </p>
            <div class="sp_general">
                <label class="sp_lable" style="line-height: 22px;">
                    �ջ���ַ��</label>
                 <p class="sp_general fl" style=" line-height:30px;">
                 
                                <asp:DropDownList ID="DropDownListAddress1" runat="server" Width="90">
                                </asp:DropDownList>
                                <asp:DropDownList ID="DropDownListAddress2" runat="server" Width="90">
                                <asp:ListItem Text="-��ѡ��-" Value="-1"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:DropDownList ID="DropDownListAddress3" runat="server" Width="90">
                                <asp:ListItem Text="-��ѡ��-" Value="-1"></asp:ListItem>
                                </asp:DropDownList>                 
                 </p>   

                    <asp:HiddenField ID="HiddenFieldCode" runat="server"  Value="0"/>
                    <span id="SpanAdressErr">*</span>
                    <span id="SpanAdressRight" style=" display:none">
                        <img src="/ImgUpload/shopNum1Admin-right.gif"/>
                    </span>
            </div>
            <p class="sp_general" style="height: 36px;">
                <label class="sp_lable sp_lablen" style=" line-height:26px;">
                    ��ϸ��ַ��</label>
                    <asp:TextBox ID="TextBoxAddress" runat="server" class="sp_input" ></asp:TextBox></p>
            <p class="sp_general">
                <label class="sp_lable">
                    �ֻ����룺</label>
                    <asp:TextBox ID="TextBoxTel" runat="server" class="sp_input" onblur="checkSubmitMobil()"></asp:TextBox>
                    <span id="SpanPhoneErr">*</span>
                    <span id="SpanPhoneRight" style=" display:none">
                        <img src="/ImgUpload/shopNum1Admin-right.gif"/>
                    </span></p>
            <p class="sp_general">
                <label class="sp_lable">
                    �������룺</label>
                    <asp:TextBox ID="TextBoxPostalcode" runat="server" class="sp_input" onblur="funCheckPostalcode()"></asp:TextBox>
                    <span id="SpanPostalcodeErr">*</span>
                    <span id="SpanPostalcodeRight" style=" display:none">
                        <img src="/ImgUpload/shopNum1Admin-right.gif"/>
                    </span></p>        
            <p class="sp_general">
                <label class="sp_lable">
                    ���䣺</label>
                    <asp:TextBox ID="TextBoxEmail" runat="server" class="sp_input" onblur="funCheckEmail()"></asp:TextBox>
                    <span id="SpanEmailErr"></span>
                    <span id="SpanEmailRight" style=" display:none">
                        <img src="/ImgUpload/shopNum1Admin-right.gif"/>
                    </span>
                    </p>
            <p class="sp_general">
                <label class="sp_lable">
                    ��֤�룺</label><asp:TextBox ID="TextBoxCode" onblur="funCheckYzm()"
                            runat="server" CssClass="text textcode fl" Height="18px" Style="vertical-align: top;
                            padding: 2px; margin: 0; width:86px;"></asp:TextBox><span style="padding-top: 2px;"><img src="/imagecode.aspx?javascript:Math.random()" id="safecode" border="0" onclick="reloadcode()"
                            alt="������?��һ��" style="cursor: hand;" /></span><span style="padding-top: 2px;"></span>
                            <span id="SpanCodeErr"></span>
                    <span id="SpanCodeRight" style=" display:none">
                        <img src="/ImgUpload/shopNum1Admin-right.gif"/>
                    </span>
                            </p>
            <p class="sp_general" style="padding-top: 16px; text-align:center">
                <span id="loginSpan">
                    <input type="button" name="setbut" class="ascertain" id="buttonCreate" onclick="funCheckLogin()" />
                </span>
                <span class="login_info" style="display:none; float:right; font-weight:bold; color:Green" id="dataJzz">
                            <img src="/Images/ajax_loading.gif" />������Ʒ����������...</span>
                </p>
            <p class="sp_general">
            </p>
        </div>