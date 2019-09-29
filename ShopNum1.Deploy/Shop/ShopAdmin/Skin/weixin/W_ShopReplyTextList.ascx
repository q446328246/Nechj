<%@ Control Language="C#" %>
<%@ Import Namespace="ShopNum1.ShopAdminWebControl" %>
<div class="tjsp_mian">
    <p class="ptitle">
        <a href="S_Welcome.aspx">我是卖家</a><span class="breadcrume_icon">>></span><span class="breadcrume_text">文字回复列表</span></p>
    <div class="box_content">
        <div class="box_content1">
            <a class="icon_plus1" href="W_ShopReplyText.aspx">添加</a> <a class="icon_refresh"
                href="javascript:location.reload();"></a><a class="icon_delete" style="display: none;"
                    href="javascript:void(0);"></a>
        </div>
        <div class="box_content2">
            <form method="post" action="" id="listForm">
            <table id="listTable" class="table">
                <thead>
                    <tr>
                        <th class='with_checkbox'>
                            <input type="checkbox" class="check_all">
                        </th>
                        <th>
                            关键词
                        </th>
                        <th>
                            回答
                        </th>
                        <th>
                            匹配类型
                        </th>
                        <th>
                            时间
                        </th>
                        <th>
                            操作
                        </th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="rep_rule" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td class="with_checkbox">
                                    <input type="checkbox" name="check" value="<%#Eval("ID") %>">
                                </td>
                                <td>
                                    <%#Eval("keyword") %>
                                </td>
                                <td class="label_sat">
                                    <%#Eval("content") %>
                                </td>
                                <td>
                                    <span class="label_satgreen">
                                        <%#Convert.ToInt32(Eval("Matching")) == 0 ? "完全" : "模糊" %></span>
                                </td>
                                <td>
                                    <%#Eval("CreateTime") %>
                                </td>
                                <td>
                                    <div style="margin: 0 auto; width: 50px;">
                                        <a href="W_ShopReplyText.aspx?ruleid=<%#Eval("ID") %>" class="with_hidden2"></a>
                                        <a href="javascript:void(0);" class="with_hidden3"></a>
                                    </div>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
            </form>
            <div class="dataTables_paginate paging_full_numbers">
                <span></span>
            </div>
        </div>
    </div>
</div>
<script type="text/javascript">

    $(function () {

        //规则删除
        $("#listTable tr:not(:first)").each(function () {
            var obj = $(this);
            obj.find(".with_hidden3").click(function () {
                if (confirm("删除操作不可逆,是否确定？")) {
                    var ruleid = "'" + obj.find("input[name='check']").val() + "'";
                    $.ajax({
                        cache: false,
                        url: "/api/ShopAdmin/api_reply.ashx",
                        data: {
                            ruleids: ruleid,
                            type: "del_replytxt"
                        },
                        dataType: "json",
                        success: function (result) {
                            alert(result.errmsg);
                            if (result.errcode == 0) {
                                obj.remove();
                            }
                        }
                    });
                }
            });
        }); //全选
        $(".check_all").click(function () {
            if ($(this).is(":checked")) {
                $("input[name='check']").attr("checked", "checked");
            } else {
                $("input[name='check']").removeAttr("checked");
            }
        }); //显示隐藏批量删除按钮
        $("input[type='checkbox']").click(function () {
            var num = 0;
            $("input[name='check']").each(function () {
                if ($(this).is(":checked")) {
                    num++;
                }
            });
            if (num > 0) {
                $(".icon_delete").show();
            } else {
                $(".icon_delete").hide();
            }
        }); //批量删除
        $(".icon_delete").click(function () {
            if (confirm("删除操作不可逆,是否确定？")) {
                var ruleids = "";
                $("#listTable tr:not(:first)").each(function () {
                    if ($(this).find("input[type='checkbox']").is(":checked")) {
                        ruleids += "'" + $(this).find("input[type='checkbox']").val() + "',";
                    }
                });
                if (ruleids != "") {
                    ruleids = ruleids.substring(0, ruleids.length - 1);


                    $.ajax({
                        cache: false,
                        url: "/api/ShopAdmin/api_reply.ashx",
                        data: {
                            ruleids: ruleids,
                            type: "del_replytxt"
                        },
                        dataType: "json",
                        success: function (result) {
                            alert(result.errmsg);
                            if (result.errcode == 0) {
                                window.location.reload();
                            }
                        }
                    });

                }
            }
        });
    })

</script>
