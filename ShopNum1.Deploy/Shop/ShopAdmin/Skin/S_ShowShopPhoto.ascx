<%@ Control Language="C#" %>
<%@ Import Namespace="ShopNum1.ShopAdminWebControl" %>
<%@ Import Namespace="ShopNum1.Common" %>
<script type="text/javascript" language="javascript">
    function funReturn(imageurl) {
        var txtid = '<%= ShopNum1.Common.Common.ReqStr("txtid") %>';
        var imgid = '<%= ShopNum1.Common.Common.ReqStr("imgid") %>';
        try {
            window.parent.document.getElementById(imgid).src = imageurl;
            window.parent.document.getElementById(txtid).value = imageurl;
            window.parent.document.getElementById("sp_dialog_contDiv2").style.display = "none";
            window.parent.document.getElementById("sp_dialog_outDiv2").style.display = "none";
            window.parent.document.getElementById("sp_overlayDiv2").style.display = "none";
        } catch (e) {
            window.parent.document.getElementById("sp_dialog_contDiv").style.display = "none";
            window.parent.document.getElementById("sp_dialog_outDiv").style.display = "none";
            window.parent.document.getElementById("sp_overlayDiv").style.display = "none";
        }
        try {
            window.parent.openSingleChild(imageurl);
        } catch (e) {
        }
    }

    $(function () {
        if ($("#S_ShowShopPhoto_ctl00_pageDiv").html() == "") {
            $(".fenye").hide();
        }
    });
</script>
<style type="text/css">
    .img_bor
    {
        border: 1px solid #dddddd;
        margin-top: 18px;
        padding: 18px;
    }
    
    .border_img
    {
    }
    
    .border_img a
    {
        border: 1px solid #dddddd;
        display: block;
        height: 96px;
        padding: 1px;
        width: 96px;
    }
    
    .border_img a img
    {
        height: 96px;
        width: 96px;
    }
    
    .img_title
    {
        margin-top: 10px;
        padding: 0 5px;
    }
    
    .img_bor td
    {
    }
    
    .img_bor ul
    {
        overflow: hidden;
    }
    
    .img_bor ul li
    {
        float: left;
        padding: 9px;
        width: 98px;
    }
</style>
<script type="text/javascript" language="javascript">
    $(function () {
        var txtid = '<%= ShopNum1.Common.Common.ReqStr("txtid") %>';
        var imgid = '<%= ShopNum1.Common.Common.ReqStr("imgid") %>';
        $("#S_ShowShopPhoto_ctl00_DropDownListType").change(function () {
            window.location.href = "?txtid=" + txtid + "&imgid=" + imgid + "&st=" + $(this).find("option:selected").val() + "&pageid=1";
        });

        $("#hidImgCategoryID").val($("#S_ShowShopPhoto_ctl00_DropDownListType").find("option:selected").val());
        //全选
        $("#checkall").click(function () {
            var ischeck = $(this).is(":checked");
            ischeck = ischeck == true ? "反选" : "全选";
            $(this).next().text(ischeck);
            var checkboxs = document.getElementsByName("checksub");
            for (var i = 0; i < checkboxs.length; i++) {
                checkboxs[i].checked = $(this).is(":checked");
            }
        });
        //编辑信息
        $(".bianji").click(function () {
            $("#sp_" + $(this).attr("id")).attr("style", "display:none");
            $("#edit_" + $(this).attr("id")).attr("style", "display:block");
        });
        $(".editname").dblclick(function () {
            $("#sp_" + $(this).attr("lang")).attr("style", "display:none");
            $("#edit_" + $(this).attr("lang")).attr("style", "display:block");
        });
        //失去焦点进行编辑修改
        $(".blur_txt").blur(function () {
            var guid = $(this).attr("lang");
            $.get("?type=1&name=" + escape($(this).val()) + "&id=" + guid, null, function (data) {
            });
            $("#sp_" + $(this).attr("id")).attr("title", $(this).val());
            $("#sp_" + $(this).attr("id")).text(cut($(this).val(), 5));
            $("#sp_" + $(this).attr("id")).show();
            $("#edit_" + $(this).attr("id")).hide();
        });
        //标题提示效果处
        var sweetTitles = {
            x: 10,
            y: 20,
            tipElements: ".editname",
            init: function () {
                $(this.tipElements).mouseover(function (e) {
                    this.myTitle = this.title;
                    this.title = "";
                    var tooltip = "";
                    if (this.myTitle == "") {
                        tooltip = "";
                    } else {
                        tooltip = "<div id='tooltip'><p>双击修改-" + this.myTitle + "</p></div>";
                    }
                    $('body').append(tooltip);
                    $('#tooltip').css({ "opacity": "0.8", "top": (e.pageY + 20) + "px", "left": (e.pageX + 10) + "px" }).show('fast');
                }).mouseout(function () {
                    this.title = this.myTitle;
                    $('#tooltip').remove();
                }).mousemove(function (e) { $('#tooltip').css({ "top": (e.pageY + 20) + "px", "left": (e.pageX + 10) + "px" }); });
            }
        };
        sweetTitles.init();
        //$('a').imgPreview();
        $('a').imgPreview({ imgCSS: { width: 300} });
    });

    function cut(str, len) {
        if (str.toString().length >= len)
            return str.toString().substring(0, len);
        return str;
    }

    function subSearch() {
        var selecttype = $("#S_ShowShopPhoto_ctl00_DropDownListType").find("option:selected").val();
        var imgname = $("#S_ShowShopPhoto_ctl00_txtImageName").val();
        var txtid = '<%= ShopNum1.Common.Common.ReqStr("txtid") %>';
        var imgid = '<%= ShopNum1.Common.Common.ReqStr("imgid") %>';
        location.href = "/Shop/ShopAdmin/S_ShowShopPhoto.aspx?txtid=" + txtid + "&imgid=" + imgid + "&st=" + selecttype + "&imgname=" + escape(imgname) + "";
        return false;
    }
</script>
<table cellpadding="0" cellspacing="0" border="0" style="padding-top: 10px; z-index: 100px;">
    <tr class="up_spac">
        <td>
            <div class="shanc upload" id="open_uploader" style="float: right; z-index: 9999">
                <input type="button" id="fileupload" value="加载上传控件" class="btn_upload" />
            </div>
            <input type="hidden" id="hidShopId" runat="server" />
            <input type="hidden" id="hidImgCategoryID" runat="server" />
            <script type="text/javascript" language="javascript">
                $("#fileupload").uploadify({
                    'uploader': 'uploadify/uploadify.swf',
                    'script': '/Api/uploadify.ashx?albumid=<%= Encryption.Encrypt(hidShopId.Value) %>-' + $("#S_ShowShopPhoto_ctl00_hidImgCategoryID").val() + '&shopid=dd',
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

            </script>
        </td>
    </tr>
    <tr class="up_spac">
        <td align="right">
            选择相册：
        </td>
        <td>
            <asp:DropDownList ID="DropDownListType" runat="server" CssClass="tselect1" Width="100">
                <%--<asp:ListItem Value="-1">-全部-</asp:ListItem>--%>
            </asp:DropDownList>
        </td>
        <td align="right" style="padding-left: 20px;">
            图片名称：
        </td>
        <td>
            <input type="text" class="ss_nr1" runat="server" id="txtImageName" value='' style="width: 150px;" />
        </td>
        <td>
            <asp:Button ID="ButtonChaxData" runat="server" OnClientClick=" return subSearch() "
                Text="查询" CssClass="chax btn_spc" Style="margin-left: 10px;" />
        </td>
    </tr>
</table>
<div class="img_bor" style="z-index: 0px;">
    <ul>
        <asp:Repeater ID="RepeaterShow" runat="server">
            <ItemTemplate>
                <li>
                    <div class="border_img">
                        <a onclick=' funReturn("<%#Eval("ImagePath") %>") '>
                            <img src='<%#Eval("ImagePath").ToString().StartsWith("~/") ? Eval("ImagePath").ToString().Substring(1) : Eval("ImagePath").ToString() %>' /></a></div>
                    <div class="img_title">
                        <a href="#">
                            <%#Eval("Name").ToString().Length > 6 ? Eval("Name").ToString().Substring(0, 6) : Eval("Name").ToString() %></a></div>
                </li>
            </ItemTemplate>
        </asp:Repeater>
        <% if (RepeaterShow.Items.Count == 0)
           { %>
        <li style="text-align: center; width: 100%;"><span>暂无数据</span> </<li>
            <% } %>
    </ul>
    <!--分页-->
    <div class="fenye">
        <table width="100%" border="0" cellspacing="0" cellpadding="0" class="btntable_t">
            <tr>
                <td style="border-left: solid 1px #e3e3e3; border-right: none; width: 30px;">
                    &nbsp;
                </td>
                <td style="border-left: none;">
                    <div id="pageDiv" runat="server" class="fy">
                    </div>
                </td>
            </tr>
        </table>
    </div>
    <!--分页-->
</div>
