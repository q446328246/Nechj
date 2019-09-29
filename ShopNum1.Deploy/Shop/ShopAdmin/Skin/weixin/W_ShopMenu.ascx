<%@ Control Language="C#" %>
<%@ Import Namespace="ShopNum1.ShopAdminWebControl" %>
<div class="tjsp_mian">
    <p class="ptitle">
        <a href="S_Welcome.aspx">我是卖家</a><span class="breadcrume_icon">>></span><span class="breadcrume_text">自定义菜单</span></p>
    <div class="box_content">
        <div class="alert">
            <p>
                注意：1级菜单最多只能开启3个! 2级子菜单最多开启5个!</p>
            <p>
                1级菜单长度最多4个中文或字母! 2级子菜单长度最多8个中文或字母!</p>
            <p>
                生成自定义菜单,必须在已经保存的基础上进行,临时勾选启用点击生成是无效的!
            </p>
            <p>
                第一步必须先修改保存状态! 第二步点击启动! 第三步点击关闭!</p>
            <p>
                当您为自定义菜单填写链接地址时请填写以<strong> " http:// " </strong>开头，这样可以保证用户手机浏览的兼容性更好</p>
        </div>
        <div class="btntable_tbg">
            <div class="row_fluid">
                <a href="javascript:void(0);" class="btn" id="add_menu">添加主菜单</a>
            </div>
        </div>
        <div class="row_fluid1">
            <table id="listTable" class="row_fluid2">
                <tr>
                    <th width="88px">
                        显示顺序
                    </th>
                    <th width="299px">
                        主菜单名称
                    </th>
                    <th width="271px">
                        触发关键词或链接地址
                    </th>
                    <th width="47px">
                        操作
                    </th>
                </tr>
                <asp:Repeater ID="rep_menu" runat="server">
                    <ItemTemplate>
                        <tr class="ptr">
                            <td>
                                <input type="text" class="input_mini txt_sort" size="3" value="<%#Eval("Sort") %>"
                                    data-rule-number="true" />
                            </td>
                            <td class="cursor_l">
                                <input type="text" class="input_medium txt_name" maxlength="4" value="<%#Eval("Name") %>"
                                    data-rule-required="true" maxlength="8" />
                                <i class="cursor_p" title="添加子菜单"></i>
                            </td>
                            <td>
                                <input type="text" class="input_medium txt_key" size="15" value="<%#Eval("value") %>"
                                    data-rule-required="true" maxlength="100" />
                            </td>
                            <td>
                                <a class="menu_delete" href="javascript:void(0);">删除</a>
                            </td>
                        </tr>
                        <asp:Repeater ID="rep_chirldmenu" runat="server">
                            <ItemTemplate>
                                <tr class="ztr">
                                    <td>
                                        <input type="text" class="input_mini txt_sort" size="3" value="<%#Eval("Sort") %>"
                                            data-rule-number="true" />
                                    </td>
                                    <td class="cursor_l">
                                        <i class='board'></i>
                                        <input type="text" class="input_medium txt_name" size="15" value="<%#Eval("Name") %>"
                                            data-rule-required="true" maxlength="8" />
                                    </td>
                                    <td>
                                        <input type="text" class="input_medium type txt_key" size="15" value="<%#Eval("value") %>"
                                            data-rule-required="true" maxlength="100" />
                                    </td>
                                    <td>
                                        <a class="menu_delete" href="javascript:void(0);">删除</a>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
            <div>
                <button id="btn_Save" type="button" data-loading-text="提交中..." class="btn_primary">
                    保存</button>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <button id="create_menu" type="button" class="btn_primary1" style="display: none;">
                    生成自定义菜单</button>
                <button id="btn_Create" type="button" class="btn_guanbi">
                    启用</button>
                <button id="btn_Delete" type="button" class="btn_guanbi" style="display: none;">
                    关闭</button>
            </div>
        </div>
    </div>
</div>
<script type="text/javascript">

    $(function () {

        //动态生成主菜单
        $("#add_menu").click(function () {
            if ($("#listTable .ptr").length < 3) {
                var _menuPtrtmp = "<tr class=\"ptr\">"
                    + "<td>"
                    + "   <input type=\"text\" class=\"input_mini txt_sort\" size=\"3\" value=\"0\" data-rule-number=\"true\" />"
                    + "</td>"
                    + "<td class=\"cursor_l\">"
                    + "    <input type=\"text\" class=\"input_medium txt_name\" size=\"15\" value=\"\""
                    + "       data-rule-required=\"true\" maxlength=\"4\" />"
                    + "    <i class=\"cursor_p\" title=\"添加子菜单\"></i>"
                    + "</td>"
                    + "<td>"
                    + "    <input type=\"text\" class=\"input_medium txt_key\" size=\"15\" value=\"\""
                    + "        data-rule-required=\"true\" maxlength=\"100\"  />"
                    + "</td>"
                    + "<td>"
                    + "    <a class=\"menu_delete\" href=\"javascript:void(0);\">删除</a>"
                    + "</td>"
                    + "</tr>";
                $("#listTable").append(_menuPtrtmp);
            }
        }); //动态生成子菜单
        $(".cursor_p").live("click", function () {

            if ($(this).parents(".ptr").nextAll(".ptr").index() == -1) {

                if ($(this).parents(".ptr").nextAll().length >= 5) {
                    return false;
                }
            } else if ($(this).parents(".ptr").nextAll(".ptr").index() - $(this).parents(".ptr").index() > 5) {
                return false;
            }
            var _menuZtrtmp = "<tr class=\"ztr\">"
                + " <td>"
                + "    <input type=\"text\" class=\"input_mini txt_sort\" size=\"3\" value=\"0\" data-rule-number=\"true\" />"
                + "</td>"
                + "<td class=\"cursor_l\">"
                + "    <i class='board'></i>"
                + "    <input type=\"text\" class=\"input_medium txt_name\" size=\"15\" value=\"\""
                + "        data-rule-required=\"true\" maxlength=\"8\" />"
                + "</td>"
                + "<td>"
                + "    <input type=\"text\" class=\"input_medium type txt_key\" size=\"15\" value=\"\""
                + "        data-rule-required=\"true\" maxlength=\"100\" />"
                + "</td>"
                + "<td>"
                + "    <a class=\"menu_delete\" href=\"javascript:void(0);\">删除</a>"
                + "</td>"
                + "</tr>";
            $(this).parents(".ptr").after(_menuZtrtmp);
        }); //删除菜单
        $(".menu_delete").live("click", function () {


            if ($(this).parents("tr").attr("class") == "ztr") {
                $(this).parents("tr").remove();
            } else {

                while ($(this).parents("tr").next().attr("class") == "ztr") {
                    $(this).parents("tr").next().remove();
                }

                $(this).parents(".ptr").remove();
            }
        }); //获取菜单json
        $("#btn_Save").click(function () {

            var IsHaveChirld = false;
            var _menuJson = "";
            if ($("#listTable tr:not(:first)").length > 0) {
                _menuJson = "[";
                $("#listTable tr:not(:first)").each(function (i) {
                    if ($(this).attr("class") == "ptr") {
                        //如果不是第一个ptr,
                        if (i != 0) {
                            if (IsHaveChirld) _menuJson = _menuJson.substring(0, _menuJson.length - 1);
                            _menuJson += "]},";
                        }
                        _menuJson += "{\"Sort\": \"" + $(this).find(".txt_sort").val() + "\","
                            + "\"Name\": \"" + $(this).find(".txt_name").val() + "\" ,"
                            + "\"Value\": \"" + $(this).find(".txt_key").val() + "\","
                            + "\"SubButton\": [";
                        IsHaveChirld = false;
                    } else {
                        //二级菜单
                        _menuJson += "{\"Sort\": \"" + $(this).find(".txt_sort").val() + "\","
                            + "\"Name\": \"" + $(this).find(".txt_name").val() + "\","
                            + "\"Value\": \"" + $(this).find(".txt_key").val() + "\","
                            + "\"SubButton\": []},";
                        IsHaveChirld = true;
                    }

                });
                if (IsHaveChirld) {
                    _menuJson = _menuJson.substring(0, _menuJson.length - 1);
                }
                _menuJson += "]}]";
            }

            $.ajax({
                cache: false,
                url: "/api/ShopAdmin/api_menu.ashx",
                data: {
                    menu_json: _menuJson,
                    type: "menu_add"
                },
                dataType: "json",
                success: function (result) {
                    alert(result.errmsg);
                    setTimeout(function () {
                        window.location.href = "W_ShopMenu.aspx";
                    }, 1000);
                }
            });
        }); //限制排序只能输入数字
        $(".txt_sort").each(function () {
            var obj = $(this);
            var tempval = obj.val();
            obj.blur(function () {
                var reg = new RegExp(/^(0|[1-9]\d*)$/);
                if (!reg.test(obj.val())) {
                    obj.val(tempval);
                } else {
                    tempval = obj.val();
                }
            });
        }); //创建菜单
        $("#btn_Create").click(function () {
            $.ajax({
                cache: false,
                url: "/api/ShopAdmin/api_menu.ashx",
                data: {
                    type: "menu_create"
                },
                dataType: "json",
                success: function (result) {
                    if (result.errcode == "0") {
                        alert("菜单启动成功！");
                    } else {
                        alert("菜单启动失败，错误码:" + result.errcode);
                    }
                }
            });
        }); //关闭菜单
        $("#btn_Delete").click(function () {
            $.ajax({
                cache: false,
                url: "/api/ShopAdmin/api_menu.ashx",
                data: {
                    type: "menu_create"
                },
                dataType: "json",
                success: function (result) {
                    if (result.errcode == "0") {
                        alert("菜单关闭成功！");
                    } else {
                        alert("菜单关闭失败，错误码:" + result.errcode);
                    }
                }
            });
        });
    })
</script>
