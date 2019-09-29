<%@ Control Language="C#" EnableViewState="false" %>
<%@ Import Namespace="ShopNum1.ShopAdminWebControl" %>
<script type="text/javascript" language="javascript">
    document.write('<div class="sp_overlay"  style="display:none" id="sp_overlayDiv2"></div>');

    function funClosex() {
        $("#sp_dialog_contDiv2").css("display", "none");
        $("#sp_dialog_outDiv2").css("display", "none");
        $("#sp_overlayDiv2").css("display", "none");
    }

    function funOpenx() {
        $("#sp_dialog_contDiv2").css("display", "block");
        $("#sp_dialog_outDiv2").css("display", "block");
        $("#sp_overlayDiv2").css("display", "block");
    }

    function showDialog(type) {
        funOpenx();
        $("#showiframe").attr("src", "/Shop/ShopAdmin/S_ShowShopPhoto.aspx?txtid=<%= HiddenAlbumPic.ClientID %>&imgid=<%= imgsrc.ClientID %>");
    }

    $(function () {
        $("#wm_text_pos label").click(function () {
            $("#S_Album_2_ctl00_hidTxt_potisiton").val($(this).prev().val());
            $("#wm_text_pos label").removeClass("checked");
            $(this).addClass("checked");
        });
        $("#wm_img_pos label").click(function () {
            $("#S_Album_2_ctl00_hidImg_potisiton").val($(this).prev().val());
            $("#wm_img_pos label").removeClass("checked");
            $(this).addClass("checked");
        });

        if ($("#S_Album_2_ctl00_hidImg_potisiton").val() != "") {
            $("#wm_img_pos label").removeClass("checked");
            var id = $("#S_Album_2_ctl00_hidImg_potisiton").val();
            $("#wm_img_pos_" + id).attr("checked", "checked").parent().find("label").addClass("checked");
        }

        if ($("#S_Album_2_ctl00_hidTxt_potisiton").val() != "") {
            $("#wm_text_pos label").removeClass("checked");
            var id = $("#S_Album_2_ctl00_hidTxt_potisiton").val();
            $("#wm_text_pos_" + id).attr("checked", "checked").parent().find("label").addClass("checked");
        }
        $("input[name='r_water']").click(function () {
            $("#S_Album_2_ctl00_hidCheck").val($(this).val());
            if ($(this).val() == "1") {
                $(".ablum_font").show();
                $(".ablum_pic").hide();
            } else if ($(this).val() == "2") {
                $(".ablum_pic").show();
                $(".ablum_font").hide();
            } else {
                $(".ablum_pic").hide();
                $(".ablum_font").hide();
                $(".ablum_font").hide();
                $(".ablum_pic").hide();
            }
        });
        $("input[name='r_water']").each(function () {
            if ($(this).val() == $("#S_Album_2_ctl00_hidCheck").val()) {
                $(this).click();
            }
        });

        $("#S_Album_2_ctl00_selectfont").find("option[value='" + $("#S_Album_2_ctl00_hidSelectFont").val() + "']").attr("selected", true);
    });

    function subCheck() {
        //        alert();
        //         $("#wm_img_pos input").each(function(){
        //                if($(this).is(":checked")){alert($(this).val());$("#S_Album_2_ctl00_hidImg_potisiton").val($(this).val());}
        //         });
        //         $("#wm_text_pos input").each(function(){
        //                if($(this).is(":checked")){$("#S_Album_2_ctl00_hidTxt_potisiton").val($(this).val());}
        //         });  
        var rcheckv = 0;
        $("input[name='r_water']").each(function () {
            if ($(this).attr("checked")) {
                rcheckv = $(this).val();
            }
        });
        if ($("#S_Album_2_ctl00_txtImageWaterMarkClarity").val() == "" && rcheckv == "2") {
            alert("透明度不能为空！");
            return false;
        }
        $("#S_Album_2_ctl00_hidSelectFont").val($("#S_Album_2_ctl00_selectfont").find("option:selected").val());
        return true;
    }
</script>
<!--弹出层-->
<div class="sp_dialog sp_dialog_out" style="display: none;" id="sp_dialog_outDiv2">
    <div class="sp_dialog_cont" id="sp_dialog_contDiv2">
        <div class="sp_tan">
            <h4>
                选择图片</h4>
            <div class="sp_close">
                <a href="javascript:void(0)" onclick=" funClosex() "></a>
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
<style type="text/css">
    .ablum_font, .ablum_pic
    {
        display: none;
    }
    
    .ablum_sy
    {
        background: #ffffff;
        border: 1px solid #c6dffe;
        height: 145px;
        padding: 5px;
        width: 200px;
    }
    
    .wm_pos
    {
        background: #f5fafe;
        height: 125px;
        padding: 10px;
        position: relative;
        width: 180px;
        z-index: 1;
    }
    
    .wm_pos li
    {
        border: 1px dotted #c6dffe;
        display: block;
        float: left;
        height: 30px;
        margin: 5px;
        width: 48px;
    }
    
    .wm_pos label
    {
        color: #A2CAE9;
        cursor: pointer;
        display: block;
        font-weight: bold;
        line-height: 30px;
        text-align: center;
        vertical-align: middle;
    }
    
    .wm_pos .over
    {
        color: #FFF;
    }
    
    #wm_text_pos li label.checked, #wm_img_pos li label.checked
    {
        background: #c6dffe;
        color: #ffffff;
    }
</style>
<!--弹出层-->
<table width="100%" border="0" cellspacing="0" cellpadding="0" class="tabbiaoduo">
    <tr>
        <td class="tab_r" style="border-left: none;">
            水印开启设置：
        </td>
        <td>
            <input type="radio" name="r_water" value="0" checked="checked" />不开启水印
            <input type="radio" name="r_water" value="1" />开启文字水印
            <input type="radio" name="r_water" value="2" />开启图片水印
        </td>
    </tr>
    <tr class="ablum_pic">
        <td class="tab_r" style="border-left: none;">
            水印图片：
        </td>
        <td>
            <img style="height: 100px; width: 100px;" id="imgsrc" runat="server" />
            <asp:HiddenField ID="HiddenAlbumPic" runat="server" />
            <input type="button" class="selpic" onclick=" showDialog(1) " value="选择图片" />(水印图片大小最好不要超过100px)
        </td>
    </tr>
    <tr class="ablum_pic">
        <td class="tab_r" style="border-left: none;">
            图片水印位置：
        </td>
        <td>
            <div class="ablum_sy">
                <ul id="wm_img_pos" class="wm_pos">
                    <li>
                        <input type="radio" id="wm_img_pos_1" value="1" name="wm_img_pos" checked="checked"
                            style="display: none;">
                        <label class="checked" for="wm_img_pos_1">
                            左上</label>
                    </li>
                    <li>
                        <input type="radio" id="wm_img_pos_2" value="2" name="wm_img_pos" style="display: none;">
                        <label class="" for="wm_img_pos_2">
                            正上</label>
                    </li>
                    <li>
                        <input type="radio" id="wm_img_pos_3" checked="" value="3" name="wm_img_pos" style="display: none;">
                        <label class="" for="wm_img_pos_3">
                            右上</label>
                    </li>
                    <li>
                        <input type="radio" id="wm_img_pos_4" value="4" name="wm_img_pos" style="display: none;">
                        <label class="" for="wm_img_pos_4">
                            左中</label>
                    </li>
                    <li>
                        <input type="radio" id="wm_img_pos_5" value="5" name="wm_img_pos" style="display: none;">
                        <label class="" for="wm_img_pos_5">
                            中间</label>
                    </li>
                    <li>
                        <input type="radio" id="wm_img_pos_6" value="6" name="wm_img_pos" style="display: none;">
                        <label class="" for="wm_img_pos_6">
                            右中</label>
                    </li>
                    <li>
                        <input type="radio" id="wm_img_pos_7" value="7" name="wm_img_pos" style="display: none;">
                        <label class="" for="wm_img_pos_7">
                            左下</label>
                    </li>
                    <li>
                        <input type="radio" id="wm_img_pos_8" value="8" name="wm_img_pos" style="display: none;">
                        <label class="" for="wm_img_pos_8">
                            中下</label>
                    </li>
                    <li>
                        <input type="radio" id="wm_img_pos_9" value="9" name="wm_img_pos" style="display: none;">
                        <label class="" for="wm_img_pos_9">
                            右下
                        </label>
                    </li>
                </ul>
            </div>
        </td>
    </tr>
    <tr class="ablum_pic">
        <td class="tab_r" style="border-left: none; display: none;">
            图片水印透明度：
        </td>
        <td style="display: none;">
            <input name="input" type="text" class="textwb" id="txtImageWaterMarkClarity" runat="server" />
            <span class="red">*</span>
        </td>
    </tr>
    <tr class="ablum_font">
        <td class="tab_r" style="border-left: none;">
            水印文字：
        </td>
        <td>
            <input name="input" type="text" class="textwb" id="txtFontTxt" runat="server" />
            <span class="red">&nbsp;</span>
        </td>
    </tr>
    <tr class="ablum_font">
        <td class="tab_r" style="border-left: none;">
            水印文字字体：
        </td>
        <td>
            <select id="selectfont" runat="server">
            </select>
            <span class="red">&nbsp;</span>
        </td>
    </tr>
    <tr class="ablum_font">
        <td class="tab_r" style="border-left: none;">
            水印文字字体大小：
        </td>
        <td>
            <input name="input" type="text" class="textwb" id="txtFontSize" runat="server" />px
            <span class="red">&nbsp;</span>
        </td>
    </tr>
    <tr class="ablum_font">
        <td class="tab_r" style="border-left: none;">
            水印文字字体颜色：
        </td>
        <td>
            <input name="input" type="text" id="txtColor" runat="server" class="textwb" style="float: left;" />
            <input type="button" id="colorpicker" value="打开取色器" class="selpic" />
        </td>
    </tr>
    <tr class="ablum_font">
        <td class="tab_r" style="border-left: none;">
            文字水印位置：
        </td>
        <td>
            <div class="ablum_sy">
                <ul id="wm_text_pos" class="wm_pos">
                    <li>
                        <input type="radio" id="wm_text_pos_1" value="1" name="wm_text_pos" checked="checked"
                            style="display: none;">
                        <label class="checked" for="wm_text_pos_1">
                            左上</label>
                    </li>
                    <li>
                        <input type="radio" id="wm_text_pos_2" value="2" name="wm_text_pos" style="display: none;">
                        <label class="" for="wm_text_pos_2">
                            正上</label>
                    </li>
                    <li>
                        <input type="radio" id="wm_text_pos_3" checked="" value="3" name="wm_text_pos" style="display: none;">
                        <label class="" for="wm_text_pos_3">
                            右上</label>
                    </li>
                    <li>
                        <input type="radio" id="wm_text_pos_4" value="4" name="wm_text_pos" style="display: none;">
                        <label class="" for="wm_text_pos_4">
                            左中</label>
                    </li>
                    <li>
                        <input type="radio" id="wm_text_pos_5" value="5" name="wm_text_pos" style="display: none;">
                        <label class="" for="wm_text_pos_5">
                            中间</label>
                    </li>
                    <li>
                        <input type="radio" id="wm_text_pos_6" value="6" name="wm_text_pos" style="display: none;">
                        <label class="" for="wm_text_pos_6">
                            右中</label>
                    </li>
                    <li>
                        <input type="radio" id="wm_text_pos_7" value="7" name="wm_text_pos" style="display: none;">
                        <label class="" for="wm_text_pos_7">
                            左下</label>
                    </li>
                    <li>
                        <input type="radio" id="wm_text_pos_8" value="8" name="wm_text_pos" style="display: none;">
                        <label class="" for="wm_text_pos_8">
                            中下</label>
                    </li>
                    <li>
                        <input type="radio" id="wm_text_pos_9" value="9" name="wm_text_pos" style="display: none;">
                        <label class="" for="wm_text_pos_9">
                            右下
                        </label>
                    </li>
                </ul>
            </div>
        </td>
    </tr>
    <tr>
        <td class="tab_r" style="border-left: none;">
            &nbsp;
        </td>
        <td style="padding: 10px 0px 10px 0px;">
            <asp:Button ID="btnSave" runat="server" OnClientClick=" return subCheck() " CssClass="baocbtn"
                Text="确定" />
        </td>
    </tr>
</table>
<input type="hidden" id="hidCheck" runat="server" />
<input type="hidden" id="hidImg_potisiton" runat="server" />
<input type="hidden" id="hidTxt_potisiton" runat="server" />
<input type="hidden" id="hidPath" runat="server" />
<input type="hidden" id="hidSelectFont" runat="server" />