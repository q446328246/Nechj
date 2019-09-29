<%@ Control Language="C#" %>
<%@ Import Namespace="ShopNum1.ShopAdminWebControl" %>
<div class="tjsp_mian">
    <p class="ptitle">
        <a href="S_Welcome.aspx">我是卖家</a><span class="breadcrume_icon">>></span><span class="breadcrume_text">默认设置</span></p>
    <div class="box_content">
        <div class="control_group">
            <label class="control_label">
                默认关注回复：</label>
            <div class="controls">
                <div>
                    <asp:TextBox value="" ID="default_new" name="default_reply" class="textwb" runat="server"></asp:TextBox>
                </div>
                <span class="help_in">此处填写您已定义的关键词,当用户添加关注时自动回复内容!</span><span class="help_block">
                    <label class="checkbox">
                        <asp:CheckBox ID="cb_Atten" Checked="true" runat="server" />
                        是否开启默认关注回复
                    </label>
                </span>
            </div>
        </div>
        <div class="control_group">
            <label class="control_label">
                默认无匹配回复：</label>
            <div class="controls">
                <div>
                    <asp:TextBox value="" ID="default_reply" name="default_reply" class="textwb" runat="server"></asp:TextBox>
                </div>
                <span class="help_in">此处填写您已定义的关键词,当用户触发的关键词无匹配时自动回复内容!</span> <span class="help_block">
                    <label class="checkbox">
                        <asp:CheckBox ID="cb_NotFind" Checked="true" runat="server" />
                        是否开启默认无匹配回复
                    </label>
                </span>
            </div>
        </div>
        <%--<div class="control_group">
            <label class="control_label">
                默认LBS查询范围：</label>
            <div class="controls">
                <input type="text" value="10000" class="textwb" maxlength="5" id="lbs_distance" data-rule-number="true"
                    name="lbs_distance">单位（米）<br>
                <span class="help_inline" style="color: red;">当用户用发送地图定位时在此范围内的商家可被推送给用户!</span>
            </div>
        </div>--%>
        <div class="form_actions">
            <button id="reg-btn" class="btn_primary" type="button">
                保存</button>
        </div>
    </div>
</div>
<script type="text/javascript">

    $(function () {
        $("#reg-btn").click(function () {
            var attenrepkeys = $.trim($("#<%= default_new.ClientID %>").val());
            var notfindkeys = $.trim($("#<%= default_reply.ClientID %>").val());
            var isopenatten = $("#<%= cb_Atten.ClientID %>").is(":checked") ? true : false;
            var isopennotfindkey = $("#<%= cb_NotFind.ClientID %>").is(":checked") ? true : false;

            $.ajax({
                cache: false,
                url: "/api/ShopAdmin/api_ShopSetting.ashx",
                data: {
                    attenrepkeys: attenrepkeys,
                    notfindkeys: notfindkeys,
                    isopenatten: isopenatten,
                    isopennotfindkey: isopennotfindkey,
                    type: "shop_defaultsetting"
                },
                dataType: "json",
                success: function (result) {
                    alert(result.errmsg);
                }
            });
        });
    })

</script>
