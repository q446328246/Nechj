<%@ Control Language="C#" %>
<%@ Import Namespace="ShopNum1.ShopAdminWebControl" %>
<div id="list_main">
    <ul class="sidebar">
        <li class='TabbedPanelsTab TabbedPanelsTabSelected'><a href="javascript:void(0);">接口管理</a></li>
        <li class='TabbedPanelsTab'><a href="javascript:void(0);">授权设置</a></li>
    </ul>
    <div style="border: 1px solid #ccc; border-top: 0;">
        <div class="config_mian">
            <div class="alert">
                <p>
                    1. <strong>Token </strong>必须为<strong> 英文或数字(3-32位) </strong>
                </p>
                <p>
                    2. 保存后将<strong> URL，Token </strong>复制到微信公众平台<strong> 开发模式 </strong>下<strong> 服务器配置
                    </strong>里
                </p>
                <p>
                    3. 保存成功后，可以开始使用微信功能</p>
            </div>
            <div class="control_group">
                <label class="control_label">
                    URL：</label>
                <div class="controls">
                    <asp:TextBox value="" ID="txt_tokenurl" class="textwb" runat="server" Enabled="false"
                        Width="400"></asp:TextBox>
                    <input type="button" id="btn_tokenurl" class="add_on" value="复制" />
                    <div class="text_star">
                        <span class="help_inline">店铺微信接口url</span></div>
                </div>
            </div>
            <div class="control_group">
                <label class="control_label">
                    Token：</label>
                <div class="controls">
                    <asp:TextBox value="" ID="txt_token" class="textwb" runat="server" Width="400"></asp:TextBox>
                    <input type="button" id="btn_token" class="add_on" value="复制" />
                    <div class="text_star">
                        <span class="help_inline">店铺微信接口token</span></div>
                </div>
            </div>
        </div>
        <div class="config_mian" style="display: none;">
            <div class="alert">
                <p>
                    1. 要在微信公众平台 <strong>开发模式</strong> 下使用自定义菜单，首先要在公众平台 <strong>申请</strong> 自定义菜单使用的
                    <strong>AppId和AppSecret</strong> ，<br />
                    &nbsp;&nbsp;&nbsp;然后填入下边表单,点击保存。</p>
                <p>
                    2. 提交完id和密钥后，可以在【自定义菜单】中设置各个菜单项，然后进行发布，您的微信公众号便支持自定义菜单了。
                </p>
                <p>
                    3. 公众平台规定， <strong>菜单发布 <span class="red bold">24小时后生效</span> </strong>。如果为新增粉丝，则可马上看到菜单。</p>
            </div>
            <div class="control_group">
                <label class="control_label">
                    AppId：</label>
                <div class="controls">
                    <asp:TextBox value="" ID="txt_appid" class="textwb" runat="server"></asp:TextBox>
                    <div class="text_star">
                        <span class="help_inline">店铺微信接口AppId,如果要开启自定义菜单则必填</span></div>
                </div>
            </div>
            <div class="control_group">
                <label class="control_label">
                    AppSecret：</label>
                <div class="controls">
                    <asp:TextBox value="" ID="txt_appsecret" class="textwb" runat="server"></asp:TextBox>
                    <div class="text_star">
                        <span class="help_inline">店铺微信接口AppSecret,如果要开启自定义菜单则必填</span></div>
                </div>
            </div>
        </div>
        <div class="form_actions">
            <button id="reg-btn" class="btn_primary" type="button">
                保存</button>
        </div>
    </div>
</div>
<script type="text/javascript">

    $(function () {

        $(".sidebar li").click(function (i) {
            $(".sidebar li").removeClass("TabbedPanelsTabSelected");
            $(this).addClass("TabbedPanelsTabSelected");

            $(".config_mian").css("display", "none");
            $(".config_mian").eq($(this).index()).css("display", "block");
        });
        $("#reg-btn").click(function () {

            var tokenurl = $.trim($("#<%= txt_tokenurl.ClientID %>").val());
            var token = $.trim($("#<%= txt_token.ClientID %>").val());
            var appid = $.trim($("#<%= txt_appid.ClientID %>").val());
            var appsecret = $.trim($("#<%= txt_appsecret.ClientID %>").val());

            if (token.length < 3 || token.length > 32) {
                alert("Token的长度只能在3-32个字符以内！");
                return;
            }

            $.ajax({
                cache: false,
                url: "/api/ShopAdmin/api_ShopSetting.ashx",
                data: {
                    tokenurl: tokenurl,
                    token: token,
                    appid: appid,
                    appsecret: appsecret,
                    type: "shop_apiconfig"
                },
                dataType: "json",
                success: function (result) {
                    alert(result.errmsg);
                }
            });
        });
        if (!!window.ActiveXObject && !window.XMLHttpRequest) {
            $("#btn_tokenurl").click(function () {
                var clipBoardContent = $("#<%= txt_tokenurl.ClientID %>").val();
                if (window.clipboardData.setData("Text", clipBoardContent)) {
                    alert("以下内容已成功复制到粘贴板中:\r\n" + clipBoardContent);
                }
            });
            $("#btn_token").click(function () {
                var clipBoardContent = $("#<%= txt_token.ClientID %>").val();
                if (window.clipboardData.setData("Text", clipBoardContent)) {
                    alert("以下内容已成功复制到粘贴板中:\r\n" + clipBoardContent);
                }
            });
        } else {
            $("#btn_tokenurl").zclip({
                path: '/JS/zclip/ZeroClipboard.swf',
                copy: $("#<%= txt_tokenurl.ClientID %>").val()
            });

            $("#btn_token").zclip({
                path: '/JS/zclip/ZeroClipboard.swf',
                copy: $("#<%= txt_token.ClientID %>").val()
            });
        }
    })
</script>
