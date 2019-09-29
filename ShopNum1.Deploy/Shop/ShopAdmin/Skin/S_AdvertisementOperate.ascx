<%@ Control Language="C#" %>
<%@ Import Namespace="ShopNum1.ShopAdminWebControl" %>
<div class="pad">
    <table id="Table1" width="100%" border="0" cellspacing="0" cellpadding="0" class="tabbiao">
        <tr>
            <td align="right">
                幻灯片：
            </td>
            <td>
                <input name="input" type="text" class="ss_nr1" id="txt_pageName" runat="server" maxlength="30"
                    readonly="true" />
                <span class="gray1">&nbsp;</span>
            </td>
        </tr>
        <tr style="display: none">
            <td align="right">
                文件名：
            </td>
            <td>
                <input type="text" class="ss_nr1" id="txt_fieName" runat="server" maxlength="200" />
                <span class="gray1">&nbsp;</span>
            </td>
        </tr>
        <tr style="display: none">
            <td align="right">
                Title：
            </td>
            <td>
                <input type="text" class="ss_nr1" id="txt_divID" runat="server" maxlength="50" />
                <span class="gray1">&nbsp;</span>
            </td>
        </tr>
        <tr>
            <td align="right">
                说明：
            </td>
            <td>
                <%-- <textarea id="txt_Explain" rows="2" cols="20"  runat="server"  style="width:200px; height: 25px;"  >
                
               </textarea>--%>
                <input name="txt_Explain" type="text" class="ss_nr1" id="txt_Explain" runat="server"
                    maxlength="30" />
                <span class="gray1">&nbsp;</span>
            </td>
        </tr>
        <tr style="display: none">
            <td align="right">
                广告类型：
            </td>
            <td>
                <select id="sel_AdType" name="sel" size="1" class="tselect1">
                    <option value="0">文字</option>
                    <option value="1">图片</option>
                    <option value="2">幻灯片</option>
                    <option value="3">flash</option>
                </select>
                <select id="sel_PathType" name="sel" size="1" class="tselect1">
                    <option value="0">路径</option>
                    <option value="1">上传</option>
                </select>
                <span class="gray1">&nbsp;</span>
                <input id="hid_AdType" type="hidden" runat="server" />
                <input id="hid_PathType" type="hidden" runat="server" />
            </td>
        </tr>
        <tr>
            <td align="right">
                链接地址：
            </td>
            <td>
                <input type="text" class="ss_nr1" id="txt_AdLink" runat="server" />
                <span class="gray1">&nbsp;</span>
            </td>
        </tr>
        <tr>
            <td valign="top" align="right">
                内容：
            </td>
            <td valign="top">
                <input type="text" runat="server" id="txt_Content" class="textwb" readonly="true"
                    style="display: none;" />
                <input type="text" runat="server" id="txt_Path" class="textwb" style="display: none;" />
                <input type="file" runat="server" id="input_fileUpPath" onchange="getFullPath(this)" />
                <div style="color: #bbbbbb; height: 15px; line-height: 15px; padding: 0 0 8px 0;">
                    图片的格式为jpg,gif,bmp,png,建议长度：1600 宽度：458</div>
                <br />
                <img id="imgShow" width="500" height="300" runat="server" />
            </td>
        </tr>
        <tr id="trHeight" style="display: none">
            <td>
                高度：
            </td>
            <td>
                <input type="text" class="textwb" id="txt_AdHeight" runat="server" />
                <span class="gray1">&nbsp;</span>
            </td>
        </tr>
        <tr id="trWidth" style="display: none">
            <td>
                宽度：
            </td>
            <td>
                <input type="text" class="textwb" id="txt_Adwidth" runat="server" />
                <span class="gray1">&nbsp;</span>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td style="padding: 10px 0px 10px 0px;">
                <asp:Button ID="btn_Save" runat="server" Text="保存" CssClass="querbtn" />
                <asp:Button ID="btn_Back" runat="server" Text="返回" CssClass="querbtn" />
            </td>
        </tr>
    </table>
</div>
<script type="text/javascript" language="javascript">

    $(document).ready(function () {
        var b = $('#S_AdvertisementOperate_ctl00_txt_Content').val();
        $("#<%= imgShow.ClientID %>").attr("src", b);
    });
    //   function getFullPath(obj)
    //  { 
    //  var b=  $('#S_AdvertisementOperate_ctl00_txt_Content').val();

    //  var c=b.substring(0, b.lastIndexOf('/'));
    // 
    //   var a=c+obj.value;

    //   $("#<%= imgShow.ClientID %>").attr("src",a);
    //   $('#S_AdvertisementOperate_ctl00_txt_Content').val(a);

    //  
    //   }  

    $(document).ready(
        $("#sel_AdType").change(
            function () {
                var AdTypeValue = $("#sel_AdType").find("option:selected").val();
                $("#S_AdvertisementOperate_ctl00_hid_AdType").val(AdTypeValue);
                if (AdTypeValue == "0") {
                    $("#trHeight").hide();
                    $("#trWidth").hide();
                    $("#sel_PathType").hide();
                    $("#S_AdvertisementOperate_ctl00_input_fileUpPath").hide();
                    $("#S_AdvertisementOperate_ctl00_txt_Path").hide();
                } else {
                    $("#trHeight").show();
                    $("#trWidth").show();
                    $("#sel_PathType").show();
                    $("#S_AdvertisementOperate_ctl00_txt_Content").hide();
                    $("#S_AdvertisementOperate_ctl00_input_fileUpPath").show();
                    $("#S_AdvertisementOperate_ctl00_txt_Path").show();
                }
            }
        ),
        $("#sel_PathType").change(
            function () {
                var AdTPathType = $("#sel_PathType").find("option:selected").val();
                $("#S_AdvertisementOperate_ctl00_hid_PathType").val(AdTPathType);
                if (AdTPathType == "0") {
                    $("#S_AdvertisementOperate_ctl00_txt_Content").hide();
                    $("#S_AdvertisementOperate_ctl00_txt_Path").show();
                    $("#S_AdvertisementOperate_ctl00_input_fileUpPath").hide();
                } else {
                    $("#trHeight").show();
                    $("#trWidth").show();
                    $("#S_AdvertisementOperate_ctl00_txt_Content").hide();
                    $("#S_AdvertisementOperate_ctl00_txt_Path").show();
                    $("#S_AdvertisementOperate_ctl00_input_fileUpPath").show();
                }
            }
        )
    );

    function getFullPath(obj) {
        //获取欲上传的文件路径
        var filepath = obj.value;
        //为了避免转义反斜杠出问题，这里将对其进行转换
        var re = /(\\+)/g;
        var filename = filepath.replace(re, "#");
        //对路径字符串进行剪切截取
        var one = filename.split("#");
        //获取数组中最后一个，即文件名
        var two = one[one.length - 1];
        //再对文件名进行截取，以取得后缀名
        var three = two.split(".");
        //获取截取的最后一个字符串，即为后缀名
        var last = three[three.length - 1];
        //添加需要判断的后缀名类型
        var tp = "jpg,gif,bmp,png,JPG,GIF,BMP,PNG";
        //返回符合条件的后缀名在字符串中的位置
        var tiparry = tp.split(",");
        var bflag = true;
        for (var i in tiparry) {
            if (tiparry[i] == last) {
                bflag = false;
            }
        }
        var rs = tp.indexOf(last);
        //如果返回的结果大于或等于0，说明包含允许上传的文件类型
        if (bflag) {
            alert("您选择的上传文件不是有效的图片文件！");
            obj.value = "";
            return false;
        }
        if (obj) {
            if (window.navigator.userAgent.indexOf("MSIE") >= 1) {
                obj.select();
                $("#S_AdvertisementOperate_ctl00_imgShow").attr("src", obj.value);
                return false;
                if (window.navigator.userAgent.indexOf("MSIE") == 25) {
                    obj.blur();
                }
            } else if (window.navigator.userAgent.indexOf("Firefox") >= 1) {
                $("#S_AdvertisementOperate_ctl00_imgShow").attr("src", window.URL.createObjectURL(obj.files.item(0)));
                return false;
            }
            $("#S_AdvertisementOperate_ctl00_imgShow").attr("src", obj.value);
            return false;
        }
    }
</script>
