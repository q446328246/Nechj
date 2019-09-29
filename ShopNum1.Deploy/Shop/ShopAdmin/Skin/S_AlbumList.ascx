<%@ Control Language="C#" %>
<%@ Import Namespace="ShopNum1.ShopAdminWebControl" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="ShopNum1.Common" %>
<script type="text/javascript" language="javascript">
    $(function () {

        $(".picture a").hover(function () {
            $(this).addClass("img_border");
        }, function () {
            $(this).removeClass("img_border");
        });
    })

</script>
<%
    //配置参数  切不可随意修改
    DataTable dt_list = S_AlbumList.dt_Album_List; %>
<div style="background: #f3f3f3; border: 1px #e0e0e0 solid; height: 30px; line-height: 30px;
    padding: 0 15px;">
    <table border="0" cellspacing="0" cellpadding="0" width="100%" class="lineh" style="margin-top: 0;
        padding-left: 0;">
        <tr>
            <td style="color: #ff6600; display: block; font-size: 14px; font-weight: bold; height: 30px;
                line-height: 30px; overflow: hidden; padding-right: 10px; vertical-align: top;
                width: 300px;">
                <%= S_AlbumList.typeName %>
            </td>
            <td style="height: 30px; line-height: 30px; vertical-align: top;">
                <a href="javascript:void(0)" id="setalbum" style="display: none"><strong>批量处理</strong></a>
            </td>
            <td style="padding-top: 9px; *padding-top: 0px; vertical-align: top;">
                <input type="checkbox" id="selectall" />
            </td>
            <td style="height: 30px; line-height: 30px; padding-left: 6px; vertical-align: top;
                white-space: nowrap;">
                <label for="selectall">
                    全选</label>
            </td>
            <td style="height: 30px; line-height: 30px; padding-left: 10px; padding-top: 4px;
                vertical-align: top;">
                <asp:LinkButton ID="LinkDel_Select" runat="server" Text="批量删除" OnClientClick=" return submit_Del(); "
                    CssClass="shanchu lmf_btn" Style="text-align: center;"></asp:LinkButton>
            </td>
            <td>
                <span style="display: none;">| <a onclick=" uncheckAll() " href="JavaScript:void(0);">
                    取消</a>| <a onclick=" switchAll() " href="JavaScript:void(0);">反选</a>| <a onclick=" submit_form('del') "
                        href="JavaScript:void(0);">删除</a>| <a id="A1" href="JavaScript:void(0);">转移相册</a>
                    | <a onclick=" submit_form('watermark') " href="JavaScript:void(0);">添加水印</a></span>
            </td>
            <td align="right" style="height: 30px; line-height: 30px; vertical-align: top; white-space: nowrap;">
                排序：
            </td>
            <td width="160" style="height: 30px; line-height: 30px; padding-top: 6px; padding-top: 6px;
                vertical-align: top;">
                <select id="imgtype_sort" name="sort">
                    <option value="">-全部-</option>
                    <option value="0" <%= ShopNum1.Common.Common.ReqStr("sort") == "0" ? "selected='selected'" : "" %>>
                        按上传时间从晚到早</option>
                    <option value="1" <%= ShopNum1.Common.Common.ReqStr("sort") == "1" ? "selected='selected'" : "" %>>
                        按上传时间从早到晚</option>
                    <option value="2" <%= ShopNum1.Common.Common.ReqStr("sort") == "2" ? "selected='selected'" : "" %>>
                        按图片从大到小</option>
                    <option value="3" <%= ShopNum1.Common.Common.ReqStr("sort") == "3" ? "selected='selected'" : "" %>>
                        按图片从小到大</option>
                    <option value="4" <%= ShopNum1.Common.Common.ReqStr("sort") == "4" ? "selected='selected'" : "" %>>
                        按图片名降序</option>
                    <option value="5" <%= ShopNum1.Common.Common.ReqStr("sort") == "5" ? "selected='selected'" : "" %>>
                        按图片名升序</option>
                </select>
            </td>
            <td width="90" align="right">
                <div class="shanc upload" id="open_uploader" style="float: right;">
                    <input type="button" id="fileupload" value="加载上传控件" class="btn_upload" />
                </div>
                <input type="hidden" id="hidShopId" runat="server" />
                <script type="text/javascript" language="javascript">
                    $("#fileupload").uploadify({
                        'uploader': 'uploadify/uploadify.swf',
                        'script': '/Api/uploadify.ashx?albumid=<%= Encryption.Encrypt(hidShopId.Value) %>-<%= ShopNum1.Common.Common.ReqStr("typeid") %>&shopid=dd',
                        'cancelImg': 'uploadify/cancel.png',
                        'fileExt': '*.jpg;*.gif;*.png',
                        'fileDesc': 'Image Files',
                        'auto': true,
                        'multi': true,
                        onAllComplete: function (e, data) {
                            alert("您成功上传了" + data.filesUploaded + "张图片！");
                            window.location.reload(true);
                        }
                    });

                    function coverpic(id, typeid, ImgPath) {
                        var ajaxUrl = "/Api/ShopAdmin/S_Album.ashx?op=setalbum&imgpath=" + ImgPath + "&typeid=" + typeid;

                        $.get(ajaxUrl, null, function (data) {
                            alert("设置成功！");
                        });
                    }
                </script>
                <div id="showupfiles" style="background: #fff; border: 1px solid #bfbfbf; display: none;
                    left: 430px; position: absolute; top: 150px; width: 360px; z-index: 99999;">
                    <div class="upload-wrap">
                        图片相册：<%= S_AlbumList.typeName %>
                    </div>
                </div>
            </td>
        </tr>
    </table>
</div>
<input type="hidden" id="hidArryId" runat="server" />
<input type="hidden" id="hidPath" runat="server" />
<ul class="picture-list">
    <% if (dt_list != null)
       {
           for (int i = 0; i < dt_list.Rows.Count; i++)
           {
    %>
    <!--Html循环代码-->
    <li class="normal">
        <dl style="height: auto;">
            <dt style="background: none; height: auto; padding: 0;">
                <div class="picture" style="border: none; height: 166px; width: 166px;">
                    <span class="thumb size160"><i></i><a href="<%= dt_list.Rows[i]["imagepath"].ToString().Replace("~/", "/") %>"
                        class="lightbox" rel="jely">
                        <img width="162" height="162" onerror=" javascript:this.src = '/ImgUpload/noImage.gif'; "
                            src="<%= dt_list.Rows[i]["imagepath"].ToString().Replace("~/", "/") %>" class="thumb" /></a></span></div>
                <table cellpadding="0" cellspacing="0" border="0" style="margin: 0 auto; padding-top: 3px;">
                    <tr>
                        <td>
                            <input type="checkbox" name="sub_check" value="<%= dt_list.Rows[i]["id"] %>" check_path="<%= dt_list.Rows[i]["imagepath"].ToString().Replace("~/", "/") %>" />
                        </td>
                        <td style="padding-left: 8px; width: 150px;" class="showtxt">
                            <label style="display: none;" id="showlbl_<%= dt_list.Rows[i]["id"] %>">
                                <%= dt_list.Rows[i]["name"] %></label>
                            <input type="text" id="showtxt_<%= dt_list.Rows[i]["id"] %>" value='<%= dt_list.Rows[i]["name"] %>'
                                class="editInput1" disabled="disabled" maxlength="12" />
                        </td>
                    </tr>
                </table>
            </dt>
            <dd class="date" style="display: none;">
                <p>
                    单击图片可以预览</p>
                <p>
                    上传时间：<%= Convert.ToDateTime(dt_list.Rows[i]["createtime"]).ToString("yyyy-MM-dd") %></p>
                <p>
                    原图尺寸：<%= dt_list.Rows[i]["DisplaySize"] %></p>
            </dd>
            <dd class="buttons" style="text-align: center;">
                <span class="change-btn" style="display: none;">
                    <iframe width="84" scrolling="no" height="20" frameborder="0" src="S_ReplaceUpload.aspx?op=replace_image_upload&id=<%= dt_list.Rows[i]["id"] %>">
                    </iframe>
                </span><a class="rename" href="JavaScript:void(0);" lang="<%= dt_list.Rows[i]["id"] %>">
                    修改名称</a> <a class="cover" onclick=" coverpic('<%= dt_list.Rows[i]["id"] %>', '<%= ShopNum1.Common.Common.ReqStr("typeid") %>', '<%= dt_list.Rows[i]["imagepath"].ToString().Replace("/", "-") %>') "
                        href="JavaScript:void(0);">设为封面</a> <a onclick=" if (confirm('您确定进行该操作吗?\n注意：使用中的图片也将被删除')) {location.href = '?act=del&typeid=<%= ShopNum1.Common.Common.ReqStr("typeid") %>&id=<%= dt_list.Rows[i]["id"] %>&Imgpath=<%= dt_list.Rows[i]["imagepath"].ToString().Replace("/", "-") %>&sign=del';} "
                            href="javascript:void(0)" class="delete">删除图片</a>
            </dd>
        </dl>
    </li>
    <!--Html循环代码-->
    <% }
       } %>
</ul>
<div style="clear: both">
</div>
<div class="fenye" style="height: 60px;">
    <table width="100%" cellspacing="0" cellpadding="0" border="0" class="btntable_b">
        <tbody>
            <tr>
                <td style="border-left: solid 1px #e3e3e3; border-right: none; width: 30px;">
                    &nbsp;
                </td>
                <td style="border-left: none;">
                    <div class="fy">
                        <%= S_AlbumList.pageDiv %>
                    </div>
                </td>
            </tr>
        </tbody>
    </table>
</div>
<input type="hidden" id="hidEditTxt" value="0" />
<script type="text/javascript" language="javascript">
    function ontoPage(txtId) {
        location.href = '?sort=<%= ShopNum1.Common.Common.ReqStr("sort") %>&typeid=<%= ShopNum1.Common.Common.ReqStr("typeid") %>&pageid=' + $("#txtIndex").val();
    }

    $(function () {
        //标题提示效果处
        var sweetTitles = {
            x: 10,
            y: 20,
            tipElements: ".picture",
            init: function () {
                $(this.tipElements).mouseover(function (e) {
                    var myTitle = $(this).parent().next().html();
                    var tooltip = "";
                    tooltip = "<div id='tooltip'><p>" + myTitle + "</p></div>";
                    $('#tooltip').css({ "opacity": "0.8", "top": (e.pageY + 20) + "px", "left": (e.pageX + 10) + "px" }).show('fast');
                    $('body').append(tooltip);
                }).mouseout(function () { $('#tooltip').remove(); }).mousemove(function (e) { $('#tooltip').css({ "top": (e.pageY + 20) + "px", "left": (e.pageX + 10) + "px" }); });
            }
        };
        sweetTitles.init();

        $("#imgtype_sort").change(function () {
            if ($(this).find("option:selected").val() == "") {
                location.href = '?typeid=<%= ShopNum1.Common.Common.ReqStr("typeid") %>&pageid=1';
            } else {
                location.href = '?sort=' + $(this).find("option:selected").val() + '&typeid=<%= ShopNum1.Common.Common.ReqStr("typeid") %>&pageid=1';
            }
        });
        $("#open_uploader a").toggle(function () {
            $("#showupfiles").show();
            $(this).text("取消上传");
        }, function () {
            $("#showupfiles").hide();
            $(this).text("上传图片");
        });
        $("#setalbum strong").toggle(function () {
            $(this).text("取消批量处理");
            $("#divbatch").show();
        },
            function () {
                $(this).text("批量处理");
                $("#divbatch").hide();
            });

        $(".lightbox").click(function () { window.scrollTo(0, 0); });
        var idcheck = 0;
        $(".rename").click(function () {
            idcheck = $(this).attr("lang");
            $("#hidEditTxt").val(idcheck);
            $("#showtxt_" + idcheck).removeAttr("disabled");
            $("#showtxt_" + idcheck).removeClass("editInput1");
            $("#showtxt_" + idcheck).addClass("editInput2");
            if ($(this).text() == "修改名称")
                $(this).text("保存名称");
            else {
                $(this).text("修改名称");
                $("#showtxt_" + idcheck).attr("disabled", "disabled");
                $("#showtxt_" + idcheck).removeClass("editInput2");
                $("#showtxt_" + idcheck).addClass("editInput1");
                $.get("/Api/ShopAdmin/S_Album.ashx?op=savename&name=" + escape($("#showtxt_" + idcheck).val()) + "&id=" + idcheck + "", null, function (data) {
                });
                alert("保存成功！");
            }
        });
    });
</script>
