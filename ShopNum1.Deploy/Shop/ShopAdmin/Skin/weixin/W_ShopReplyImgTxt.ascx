<%@ Control Language="C#" %>
<%@ Import Namespace="ShopNum1.ShopAdminWebControl" %>
<div class="tjsp_mian">
    <p class="ptitle">
        <a href="S_Welcome.aspx">我是卖家</a><span class="breadcrume_icon">>></span><span class="breadcrume_text">添加图文回复</span></p>
    <div class="box_content">
        <div class="control_group">
            <label class="control_label" for="keyword">
                关键词：</label>
            <div class="controls">
                <asp:TextBox ID="txt_keyword" title="多个关键词请用空格格开：例如: 美丽 漂亮 好看" class="textwb" value=""
                    MaxLength="30" data-rule-required="true" name="keyword" runat="server"></asp:TextBox>
                <br />
                <span class="maroon">*</span><span class="help_inline">必填, 多个关键词请用空格格开：例如: 美丽 漂亮 好看</span>
            </div>
        </div>
        <div class="control_group">
            <label class="control_label">
                关键词类型：</label>
            <div class="controls">
                <label class="radio">
                    <asp:RadioButton ID="rbtn_accurate" value="0" GroupName="match_type" runat="server"
                        Checked="true" />
                    完全匹配，用户输入的和此关键词一样才会触发!
                </label>
                <label class="radio">
                    <asp:RadioButton ID="rbtn_vague" value="1" GroupName="match_type" runat="server" />
                    模糊匹配，只要用户输入的文字包含本关键词就触发!
                </label>
            </div>
        </div>
        <div class="control_group">
            <label for="title" class="control_label">
                标题：</label>
            <div class="controls">
                <asp:TextBox ID="txt_title" runat="server" name="title" value="" data-rule-required="true"
                    MaxLength="50" class="textwb"></asp:TextBox>
                <span class="maroon1">*</span>
            </div>
        </div>
        <div class="control_group">
            <label for="picurl" class="control_label">
                图文封面：</label>
            <div class="controls">
                <asp:Image ID="thumb_img" Style="display: none; max-height: 100px;" runat="server"
                    ImageUrl="/ImgUpload/noimg.jpg_160x160.jpg" />
                <asp:HiddenField ID="thumb" Value="" runat="server" />
                <span class="help_inline"><a class="btn" id="insertimage">选择图文封面</a></span> <span
                    class="maroon1">*</span>建议大小(宽720高400)
            </div>
        </div>
        <div class="control_group">
            <label for="introduction" class="control_label">
                简介：</label>
            <div class="controls">
                <asp:TextBox ID="txt_description" TextMode="MultiLine" name="description" data-rule-required="true"
                    MaxLength="200" class="textwb1" runat="server"></asp:TextBox>
                <span class="maroon">*</span>
            </div>
        </div>
        <div class="control_group">
            <label for="picurl" class="control_label">
                详细内容：</label>
            <div class="controls">
                <div class="alert">
                    <asp:RadioButton ID="rbtn_Arti" runat="server" value="1" GroupName="article" Checked="true" />文章
                    <asp:RadioButton ID="rbtn_link" runat="server" value="0" GroupName="article" />链接
                </div>
                <asp:TextBox ID="FCKeditorRemark" runat="server" TextMode="MultiLine" name="reply_content"
                    class="Texteditor" Style="height: 300px; visibility: hidden; width: 586px;"></asp:TextBox>
            </div>
        </div>
        <div class="control_group">
            <label for="picurl" class="control_label">
                多图文：</label>
            <div class="controls">
                <a class="add_on" id="btn_ruleadd" href="#contentlist">添加</a> <span style="color: red;"
                    class="help_inline">最多添加9个</span>
                <table id="more_graphics_table" class="dataTable_mini">
                    <asp:Repeater ID="rep_contentlist" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <input type="hidden" value="<%#Eval("ID") %>" />
                                    <%#Eval("Title") %>
                                </td>
                                <td>
                                    <a class="btn_mini" href="javascript:void(0)"><i class="icon_remove"></i></a>
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
    <asp:HiddenField ID="hid_ruleid" runat="server" Value="0" />
    <asp:HiddenField ID="hid_articleid" runat="server" Value="0" />
</div>
<div style="display: none;">
    <div id="contentlist" class="modal_content">
        <div class="modal_header">
            <button aria-hidden="true" data-dismiss="modal" class="close" type="button">
                ×</button>
            <h4 class="modal_title">
                <i class="icon_table"></i>选择图文集</h4>
        </div>
        <div class="modal_body">
            <div class="row_fluid">
                图文标题：<input type="text" placeholder="输入标题进行查找" class="input_medium" id="key" name="key">
                <button id="_soso" class="add_on" type="button">
                    <strong>查找</strong></button>
            </div>
            <div class="row_fluid">
                <input type="checkbox" name="chkall" id="chkall" />
                全选
                <ul id="data_list" class="unstyled list_li_border">
                </ul>
            </div>
        </div>
        <div class="modal_footer">
            <button data-dismiss="modal" class="btn_primary" type="button">
                确定</button>
        </div>
    </div>
</div>
<script type="text/javascript">
    //Jquery 技术考核
    function hideSet() {
        $(".tab1 .ke-dialog-row").not("div:eq(0)").hide();
        setTimeout("hideSet()", 100);
    }


    KindEditor.ready(function (K) {
        var editor = K.create('.Texteditor', {
            //上传管理
            uploadJson: '/kindeditor/file/upload_json.ashx',
            //文件管理
            fileManagerJson: '/kindeditor/file/file_manager_json.ashx',

            afterCreate: function () {
                var self = this;
                K.ctrl(document, 13, function () {
                    self.sync();
                    K('form[name=example]')[0].submit();
                });
                K.ctrl(self.edit.doc, 13, function () {
                    self.sync();
                    K('form[name=example]')[0].submit();
                });
            },
            allowFileManager: true,
            //编辑器高度
            width: '589px',
            //编辑器宽度
            height: '300px;',

            //配置编辑器的工具栏
            items: [
                'source', '|', 'undo', 'redo', '|', 'preview',
                'plainpaste', 'wordpaste', '|', 'justifyleft', 'justifycenter', 'justifyright',
                'justifyfull',
                'formatblock', 'fontname', 'fontsize', '|', 'forecolor', 'hilitecolor', 'bold',
                'italic', 'underline', 'fullscreen', '/', 'lineheight', 'removeformat', '|', 'image', 'multiimage',
                'insertfile', 'table', 'hr', 'emoticons', 'baidumap', 'about'
            ]
        });

        K('#insertimage').click(function () {
            hideSet();
            editor.loadPlugin('image', function () {
                editor.plugin.imageDialog({
                    imageAlign: false,
                    imageUrl: K('#<%= thumb.ClientID %>').val(),
                    clickFn: function (url, title, width, height, border, align) {
                        K('#<%= thumb.ClientID %>').val(url);
                        if (K('#<%= thumb_img.ClientID %>')) {
                            K('#<%= thumb.ClientID %>').hide();
                            K('#<%= thumb_img.ClientID %>').attr('src', url);
                            K('#<%= thumb_img.ClientID %>').attr('alt', title);
                            if (width != "") {
                                K('#<%= thumb_img.ClientID %>').attr('width', title);
                            }
                            if (height != "") {
                                K('#<%= thumb_img.ClientID %>').attr('height', title);
                            }
                            K('#<%= thumb_img.ClientID %>').show();
                        }
                        editor.hideDialog();
                    }
                });
            });
        });

        $("#btn_Save").click(function () {

            //关键字
            var keys = $.trim($("#<%= txt_keyword.ClientID %>").val());
            //匹配类型
            var msgtype = $("input[type=radio]:checked").val(); //标题
            var title = $.trim($("#<%= txt_title.ClientID %>").val());
            //图片
            var image = $('#<%= thumb.ClientID %>').val();
            //描述
            var desc = $.trim($("#<%= txt_description.ClientID %>").val());

            //文章类型
            var articltype = $(".alert input[type=radio]:checked").val(); //文章内容
            editor.sync();
            var articlecontent = $("#<%= FCKeditorRemark.ClientID %>").val();


            //多图文
            var chirldids = "";
            if ($("#more_graphics_table tr").length != 0) {
                $("#more_graphics_table tr").each(function () {
                    chirldids += $(this).find("input[type='hidden']").val() + ",";
                });
                chirldids = chirldids.substring(0, chirldids.length - 1);
            }

            if (keys.length == 0) {
                alert("关键字不能为空!");
                return false;
            }

            if (title.length == 0) {
                alert("标题不能为空!");
                return false;
            }

            if (image.length == 0) {
                alert("请选择图片!");
                return false;
            }

            if (desc.length == 0) {
                alert("简介不能为空!");
                return false;
            }

            if (desc.length > 200) {
                alert("简介不能超过200个字符!");
                return false;
            }

            if (articlecontent.length == 0 && $("input[name='W_ShopReplyImgTxt$ctl00$article']:checked").val() == "1") {
                alert("内容不能为空!");
                return false;
            }
            $.ajax({
                cache: false,
                type: 'POST',
                url: "/api/ShopAdmin/api_reply.ashx",
                data: {
                    keys: keys,
                    msgtype: msgtype,
                    title: title,
                    image: image,
                    desc: desc,
                    articltype: articltype,
                    articlecontent: articlecontent,
                    ruleid: $("#<%= hid_ruleid.ClientID %>").val(),
                    article: $("#<%= hid_articleid.ClientID %>").val(),
                    chirldids: chirldids,
                    type: "op_replyimgtxt"
                },
                dataType: "json",
                success: function (result) {
                    alert(result.errmsg);
                    if (result.errcode == "0") {
                        setTimeout(function () {
                            window.location.href = "W_ShopReplyImgTxtList.aspx";
                        }, 1000);
                    }
                }
            });
        });
    });


    $(function () {

        if ($("#hid_ruleid.ClientID").val() != "0") {
            $(".breadcrume_text").text("编辑图文回复");
        }

        if ($("#thumb.ClientID").val() != "") {
            $('#<%= thumb_img.ClientID %>').show();
        }

        //删除多图
        $(".btn_mini").live("click", function () {
            $(this).parents("tr").remove();
        });

        //全选
        $("#chkall").click(function () {
            if ($(this).is(":checked")) {
                $("input[name='check']").attr("checked", "checked");
            } else {
                $("input[name='check']").removeAttr("checked");
            }
        });
        var contentJson = "";
        $("#btn_ruleadd").fancybox({
            'titlePosition': 'contentlist',
            'transitionIn': 'none',
            'transitionOut': 'none',
            'showCloseButton': false,
            'onStart': function () {
                $("#data_list").html('');
                $.ajax({
                    cache: false,
                    url: "/api/ShopAdmin/api_reply.ashx",
                    data: {
                        ruleid: $("#<%= hid_ruleid.ClientID %>").val(),
                        type: "get_allcontent"
                    },
                    dataType: "json",
                    success: function (result) {
                        if (result != "") {
                            for (var nI in result) {
                                var html = "<li><label><input type=\"checkbox\" value=\"" + result[nI].ID + "\" name=\"check\">" + result[nI].Title + "</label></li>";
                                $("#data_list").append(html);
                            }
                            contentJson = result;
                        }
                    }
                });

            },
            'onCleanup': function () {


            }
        });


        //多图搜索
        $("#_soso").click(function () {
            if (contentJson != "") {
                $("#data_list").html('');
                var key = $.trim($("#key").val());
                if (key != "") {
                    for (var nI in contentJson) {
                        if (contentJson[nI].Title.indexOf(key) != -1) {
                            var html = "<li><label><input type=\"checkbox\" value=\"" + contentJson[nI].ID + "\" name=\"check\">" + contentJson[nI].Title + "</label></li>";
                            $("#data_list").append(html);
                        }
                    }
                } else {
                    for (var nI in contentJson) {
                        var html = "<li><label><input type=\"checkbox\" value=\"" + contentJson[nI].ID + "\" name=\"check\">" + contentJson[nI].Title + "</label></li>";
                        $("#data_list").append(html);
                    }
                }
            }
        }); //多图添加
        $('.btn_primary').click(function () {
            var checkednum = 0;

            var html = "";
            $("#data_list li").each(function () {
                if ($(this).find("input[name='check']").is(":checked")) {
                    var IsHavs = false;
                    var cbobj = $(this);
                    $("#more_graphics_table tr").each(function () {
                        if (cbobj.find("input[name='check']").val() == $(this).find("input[type='hidden']").val()) {
                            IsHavs = true;
                        }
                    });
                    if (!IsHavs) {
                        checkednum++;
                        html += "<tr><td><input type=\"hidden\" value=\"" + cbobj.find("input[name='check']").val() + "\" />" + cbobj.text() + "</td><td><a class=\"btn_mini\" href=\"javascript:void(0)\"><i class=\"icon_remove\"></i></a></td></tr>";
                    }
                }
            });
            if (html != "") {
                if ($("#more_graphics_table tr").length + checkednum <= 9)
                    $("#more_graphics_table").append(html);
                else
                    alert("最多添加 9 个同类图文！");
            }
            $.fancybox.close();
            $("#fancybox-overlay").hide();
        }); //关闭
        $('.close').click(function () {
            $.fancybox.close();
            $("#fancybox-overlay").hide();
        });
    });
</script>
