<%@ Control Language="C#" %>
<%@ Import Namespace="ShopNum1.ShopAdminWebControl" %>
<div class="tjsp_mian">
    <p class="ptitle">
        <a href="S_Welcome.aspx">我是卖家</a><span class="breadcrume_icon">>></span><span class="breadcrume_text">wap配置</span></p>
    <div class="box_content">
        <div class="control_group">
            <label for="title" class="config_label">
                微信号：</label>
            <div>
                <asp:TextBox ID="txt_weixin" MaxLength="50" class="textwb" runat="server"></asp:TextBox><span
                    class="maroon">*</span>
            </div>
        </div>
        <div class="control_group">
            <label for="title" class="config_label">
                联系方式：</label>
            <div>
                <asp:TextBox ID="txt_mobile" MaxLength="50" class="textwb" runat="server"></asp:TextBox><span
                    class="maroon">*</span>(手机号码或者电话号码)
            </div>
        </div>
        <div class="control_group">
            <label for="title" class="config_label">
                Logo：</label>
            <div class="controls">
                <asp:Image ID="img_logo" Style="height: 50px; width: 100px;" runat="server" ImageUrl="/ImgUpload/noimg.jpg_160x160.jpg"
                    onerror="javascript:this.src='/ImgUpload/noImg.jpg_160x160.jpg'" />
                <asp:HiddenField ID="hid_log" Value="" runat="server" />
                <span><a class="btn_logo" onclick=" LogoImageUpload() ">浏览</a>&nbsp;&nbsp;<span class="maroon">*</span>(建议大小(宽103高23)</span>
            </div>
        </div>
        <div class="row_fluid">
            <a href="javascript:void(0);" class="btn" id="add_menu">添加图片</a>&nbsp;&nbsp;微信商城wap站点幻灯片图片,建议大小(宽320高148)
        </div>
        <div class="row_fluid1">
            <table id="listTable" class="row_fluid2" cellpadding="0" cellspacing="0">
                <tr>
                    <th style="height: 24px; width: 354px;">
                        图片地址
                    </th>
                    <th style="height: 24px; width: 122px;">
                    </th>
                    <th style="height: 24px; width: 198px;">
                        URL
                    </th>
                    <th style="height: 24px; width: 32px;">
                        操作
                    </th>
                </tr>
                <asp:Repeater ID="rep_flash" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td>
                                <img id="img_logoid<%#Container.ItemIndex %>" style="height: 50px; width: 300px;"
                                    src="<%#Eval("Value") %>" onerror=" javascript:this.src = '/ImgUpload/noImg.jpg_160x160.jpg'; ">
                                <input id="hid_logoid<%#Container.ItemIndex %>" class="hid_logoid" type="hidden"
                                    value="<%#Eval("Value") %>">
                            </td>
                            <td>
                                <span class="help_inline"><a class="btn_logo" onclick=" ImageUpload(<%#Container.ItemIndex %>) ">
                                    浏览</a> </span>
                            </td>
                            <td>
                                <input class="txt_url" type="text" maxlength="200" class="textwb" value="<%#Eval("Url") %>" />
                            </td>
                            <td>
                                <a class="menu_delete" href="javascript:void(0);">删除</a>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
        </div>
    </div>
    <div class="form_actions">
        <button class="btn_primary " type="button" id="btn_Save">
            保存</button>
    </div>
</div>
<script type="text/javascript">

    $(function () {
        //动态flash
        $("#add_menu").click(function () {
            if ($("#listTable tr").length < 6) {
                var _menuPtrtmp = "<tr>"
                    + " <td>"
                    + "     <img id=\"img_logoid" + $("#listTable tr").length + "\" style=\"width: 300px; height: 50px;\" src=\"/ImgUpload/noimg.jpg_160x160.jpg \" />"
                    + "     <input class=\"hid_logoid\" type=\"hidden\" id=\"hid_logoid" + $("#listTable tr").length + "\" value=\"\" />"
                    + " </td>"
                    + " <td>"
                    + "     <span class=\"help_inline\"><a class=\"btn_logo\" onclick=\"ImageUpload(" + $("#listTable tr").length + ")\">浏览</a></span>"
                    + " </td>"
                    + " <td>"
                    + "      <input class=\"txt_url\" type=\"text\" maxlength=\"200\" class=\"textwb\" />"
                    + " </td>"
                    + " <td>"
                    + "     <a class=\"menu_delete\" href=\"javascript:void(0);\">删除</a>"
                    + " </td>"
                    + " </tr>";
                $("#listTable").append(_menuPtrtmp);
            }
        }); //删除菜单
        $(".menu_delete").live("click", function () {
            $(this).parents("tr").remove();
        });
        $(".btn_primary").click(function () {
            //微信号
            var weixin = $.trim($("#<%= txt_weixin.ClientID %>").val());

            //微信号
            var mobile = $.trim($("#<%= txt_mobile.ClientID %>").val());

            //Logo
            var logo = $("#<%= hid_log.ClientID %>").val();
            if ($.trim(weixin) == "") {
                alert("微信号不能为空！");
                return false;
            }

            if ($.trim(mobile) == "") {
                alert("手机号不能为空！");
                return false;
            }

            if ($.trim(logo) == "") {
                alert("logo不能为空！");
                return false;
            }

            //var re = /^1(3|5|8)\d{9}$/;
            //if (!re.test(mobile)) {
            //    alert("请填写正确的手机号码！");
            //    return false;
            //}

            //Flash
            var flash = "";
            var flashurl = "";
            if ($("#listTable tr:not(:first)").length > 0) {
                $("#listTable tr:not(:first)").each(function (i) {
                    flash += $(this).find(".hid_logoid").val() + ",";
                    flashurl += $(this).find(".txt_url").val() + ",";
                });
                flash = flash.substring(0, flash.length - 1);
            }

            $.ajax({
                cache: false,
                url: "/api/ShopAdmin/api_ShopSetting.ashx",
                data: {
                    weixin: weixin,
                    mobile: mobile,
                    logo: logo,
                    flash: flash,
                    flashurl: flashurl,
                    type: "shop_configop"
                },
                dataType: "json",
                success: function (result) {
                    alert(result.errmsg);
                }
            });
        });
    });

    function LogoImageUpload() {
        funOpen();
        $("#showiframe").attr("src", "/Shop/ShopAdmin/S_ShowShopPhoto.aspx?txtid=<%= hid_log.ClientID %>&imgid=<%= img_logo.ClientID %>");
    }

    function ImageUpload(nI) {
        funOpen();
        $("#showiframe").attr("src", "/Shop/ShopAdmin/S_ShowShopPhoto.aspx?txtid=hid_logoid" + nI + "&imgid=img_logoid" + nI);
    }

</script>
<!--弹出层-->
<div class="sp_dialog sp_dialog_out" style="display: none;" id="sp_dialog_outDiv">
    <div class="sp_dialog_cont" style="display: none;" id="sp_dialog_contDiv">
        <div class="sp_tan">
            <h4>
                选择图片</h4>
            <div class="sp_close">
                <a href="javascript:void(0)" onclick=" funClose() "></a>
            </div>
            <div class="clear">
            </div>
        </div>
        <div class="sp_tan_content">
            <iframe src="" id="showiframe" width="100%" height="470" frameborder="0" scrolling="no">
            </iframe>
        </div>
    </div>
</div>
