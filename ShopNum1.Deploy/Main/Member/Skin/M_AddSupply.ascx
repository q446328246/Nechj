<%@ Control Language="C#" AutoEventWireup="True" CodeBehind="M_AddSupply.ascx.cs" Inherits="ShopNum1.Deploy.Main.Member.Skin.M_AddSupply" %>
<input type="hidden" id="HiddenFieldSupplyDemandCategory" runat="server" value="0" />
<input type="hidden" id="HiddenFieldRegionCode" runat="server" value="0" />
<input type="hidden" id="HiddenGuid" runat="server" value="0" />
<input type="hidden" id="HiddenAddressCode" runat="server" value="0" />
<input type="hidden" id="HiddenImage" runat="server" value="0" />
<script type="text/javascript" charset="utf-8" src="/kindeditor/kindeditor.js"></script>
<script type="text/javascript" charset="utf-8" src="/kindeditor/lang/zh_CN.js"></script>
<script type="text/javascript" charset="utf-8" src="/kindeditor/plugins/code/prettify.js"></script>
<script src="js/CommonJS.js" type="text/javascript"></script>
<script type='text/javascript' src='js/resolution-test.js'></script>
<script type="text/javascript">
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
            width: '600px',
            //编辑器宽度
            height: '420px;',
            //配置编辑器的工具栏
            items: [
                'source', '|', 'undo', 'redo', '|', 'preview', 'print', 'template', 'code', 'cut', 'copy', 'paste',
                'plainpaste', 'wordpaste', '|', 'justifyleft', 'justifycenter', 'justifyright',
                'justifyfull', 'insertorderedlist', 'insertunorderedlist', 'indent', 'outdent', 'subscript',
                'superscript', 'clearhtml', 'quickformat', 'selectall', '|', 'fullscreen', '/',
                'formatblock', 'fontname', 'fontsize', '|', 'forecolor', 'hilitecolor', 'bold',
                'italic', 'underline', 'strikethrough', 'lineheight', 'removeformat', '|', 'image', 'multiimage',
                'flash', 'media', 'insertfile', 'table', 'hr', 'emoticons', 'baidumap', 'pagebreak',
                'anchor', 'link', 'unlink', '|', 'about'
                ]
        });
        prettyPrint();
    });
</script>
<script type="text/javascript" language="javascript" src="/js/DatePicker/WdatePicker.js"></script>
<script src="/JS/jquery-1.6.2.min.js" type="text/javascript"></script>
<script type="text/javascript">
    //分类必选
    function funCheckFL() {
        if ($("#DropDownListSupplyDemandCategory1").val() == "-1") {
            $("#errCommon").html("分类必选！");
            return false;
        }
        else {
            $("#errCommon").html("*");
            return true;
        }
    }

    //地区选择
    function funRegionCode() {
        if ($("#DropDownListRegionCode1").val() == "-1") {
            $("#errRegion").html("地区必选！");
            return false;
        }
        else {
            $("#errRegion").html("*");
            return true;
        }
    }

    function funCheckTitle() {
        var TextBoxTitle = $("#<%=TextBoxTitle.ClientID%>").val();
        if (TextBoxTitle != "") {
            $("#errTitle").html("*");
            return true;
        }
        else {
            $("#errTitle").html("标题不能为空！");
            return false;
        }
    }

    //检查时间
    function funcheckValidTime() {
        var ValidTime = $("#<%=TextBoxValidTime.ClientID%>").val();
        if (ValidTime != "") {
            var date = new Date();
            var ms = date.valueOf() - getDate(ValidTime).valueOf();
            if (ms > 0) {
                $("#errTime").html("过期时间不能小于当前时间！");
                return false;
            }
            else {
                $("#errTime").html("*");
                return true;
            }
        }
        else {
            $("#errTime").html("过期时间不能为空！");
            return false;
        }
    }

    function getDate(strDate) {
        var date = eval('new Date(' + strDate.replace(/\d+(?=-[^-]+$)/,
           function (a) { return parseInt(a, 10) - 1; }).match(/\d+/g) + ')');
        return date;
    }




    //检查邮件
    function funCheckEmail() {
        var email = $("#<%=TextBoxEmail.ClientID%>").val();
        if (email != "") {
            var Regex = /^[\w-]+(\.[\w-]+)*@([\w-]+\.)+(com|cn)$/;
            if (!Regex.test(email)) {
                $("#errEmail").html("邮件格式错误！");
                $("#<%=TextBoxEmail.ClientID%>").val("");
                return false;
            }
            else {
                $("#errEmail").html("");
                return true;
            }
        }
        else {
            return true;
        }
    }

    function funCheckButton() {
        if (funCheckFL() && funRegionCode() && funCheckTitle() && funcheckValidTime() && funCheckEmail()) {
            return true;
        }
        else {
            return false;
        }
    }
        
        
</script>
<script type="text/javascript" language="javascript">

    function funSelectValue1(val) {
        $("#DropDownListSupplyDemandCategory2").text("查询中...");
        var id = $(val).val().split('|')[0]; //ID
        //             alert(id);
        $.ajax({
            type: "get",
            url: "/Api/Main/Member/ThreeClassify.ashx",
            async: false,
            data: "FatherID=" + id + "&type=SupplyDemandCategory",
            dataType: "html",
            success: function (ajaxData) {
                if (ajaxData != "") {
                    if (id == "-1") {
                        $("#<%=HiddenFieldSupplyDemandCategory.ClientID%>").val("0");
                        $("#DropDownListSupplyDemandCategory2").html("<option value=\"-1\">-请选择-</option>");
                        $("#DropDownListSupplyDemandCategory3").html("<option value=\"-1\">-请选择-</option>");
                    }
                    else {
                        $("#<%=HiddenFieldSupplyDemandCategory.ClientID%>").val($(val).val());
                        $("#DropDownListSupplyDemandCategory2").html(ajaxData);
                    }

                }
            }
        });
    }
    function funSelectValue2(val) {
        var id = $(val).val().split('|')[0]; //ID
        $.ajax({
            type: "get",
            url: "/Api/Main/Member/ThreeClassify.ashx",
            async: false,
            data: "FatherID=" + id + "&type=SupplyDemandCategory",
            dataType: "html",
            success: function (ajaxData) {
                if (ajaxData != "") {
                    if (id == -1) {
                        $("#<%=HiddenFieldSupplyDemandCategory.ClientID%>").val($("#DropDownListSupplyDemandCategory1").val());
                        $("#DropDownListSupplyDemandCategory3").html("<option value=\"-1\">-请选择-</option>");
                    }
                    else {
                        $("#<%=HiddenFieldSupplyDemandCategory.ClientID%>").val($(val).val());
                        $("#DropDownListSupplyDemandCategory3").html(ajaxData);
                    }

                }
            }
        });
    }

    function funSelectValue3(val) {
        var id = $(val).val().split('|')[0]; //ID
        if (id == "-1") {
            $("#<%=HiddenFieldSupplyDemandCategory.ClientID%>").val($("#DropDownListSupplyDemandCategory2").val());
        }
        else {
            $("#<%=HiddenFieldSupplyDemandCategory.ClientID%>").val($(val).val());
        }
    }
         
        
</script>
<script>
    $(function () {
        //求分类
        $.ajax({
            type: "get",
            url: "/Api/Main/Member/ThreeClassify.ashx",
            async: false,
            data: "FatherID=0&type=SupplyDemandCategory",
            dataType: "html",
            success: function (ajaxData) {
                if (ajaxData != "") {
                    $("#DropDownListSupplyDemandCategory1").html(ajaxData);
                    //alert($("#<%=HiddenGuid.ClientID%>").val().length);
                    //编辑处理
                    if ($("#<%=HiddenGuid.ClientID%>").val() != "0") {
                        if ($("#<%=HiddenGuid.ClientID%>").val().length == 9) {
                            var code1 = $("#<%=HiddenGuid.ClientID%>").val().substring(0, 3);
                            $("#DropDownListSupplyDemandCategory1 option").each(function() {
                                if ($(this).val().split('|')[1] == code1) {
                                    $(this).attr("selected", "selected");
                                    funSelectValue1(this);
                                    var code2 = $("#<%=HiddenGuid.ClientID%>").val().substring(0, 6);
                                    $("#DropDownListSupplyDemandCategory2 option").each(function() {
                                        if ($(this).val().split('|')[1] == code2) {
                                            $(this).attr("selected", "selected");
                                            funSelectValue2(this);
                                            var code3 = $("#<%=HiddenGuid.ClientID%>").val();
                                            $("#DropDownListSupplyDemandCategory3 option").each(function() {
                                                if ($(this).val().split('|')[1] == code3) {
                                                    $(this).attr("selected", "selected");
                                                }
                                            });
                                        }
                                    });
                                }
                            });
                        }
                        else if ($("#<%=HiddenGuid.ClientID%>").val().length == 6) {
                            var code1 = $("#<%=HiddenGuid.ClientID%>").val().substring(0, 3);
                            $("#DropDownListSupplyDemandCategory1 option").each(function() {
                                if ($(this).val().split('|')[1] == code1) {
                                    $(this).attr("selected", "selected");
                                    funSelectValue1(this);
                                    var code2 = $("#<%=HiddenGuid.ClientID%>").val().substring(0, 6);
                                    $("#DropDownListSupplyDemandCategory2 option").each(function() {
                                        if ($(this).val().split('|')[1] == code2) {
                                            $(this).attr("selected", "selected");
                                            funSelectValue2(this);
                                        }
                                    });
                                }
                            });
                        }
                        else if ($("#<%=HiddenGuid.ClientID%>").val().length == 3) {
                            var code1 = $("#<%=HiddenGuid.ClientID%>").val().substring(0, 3);
                            $("#DropDownListSupplyDemandCategory1 option").each(function() {
                                if ($(this).val().split('|')[1] == code1) {
                                    $(this).attr("selected", "selected");
                                    funSelectValue1(this);
                                }
                            });
                        }
                    }
                }

            }
        });



        //求地区
        $.ajax({
            type: "get",
            url: "/Api/Main/Member/ThreeClassify.ashx",
            async: false,
            data: "FatherID=0&type=RegionCode",
            dataType: "html",
            success: function (ajaxData) {
                if (ajaxData != "") {
                    $("#DropDownListRegionCode1").html(ajaxData);
                    if ($("#<%=HiddenAddressCode.ClientID%>").val() != "0") {
                        if ($("#<%=HiddenAddressCode.ClientID%>").val().length == 9) {
                            var code1 = $("#<%=HiddenAddressCode.ClientID%>").val().substring(0, 3);
                            $("#DropDownListRegionCode1 option").each(function() {
                                if ($(this).val().split('|')[1] == code1) {
                                    $(this).attr("selected", "selected");
                                    funSelectRegionCode1(this);
                                    var code2 = $("#<%=HiddenAddressCode.ClientID%>").val().substring(0, 6);
                                    $("#DropDownListRegionCode2 option").each(function() {
                                        if ($(this).val().split('|')[1] == code2) {
                                            $(this).attr("selected", "selected");
                                            funSelectRegionCode2(this);
                                            var code3 = $("#<%=HiddenAddressCode.ClientID%>").val();
                                            $("#DropDownListRegionCode3 option").each(function() {
                                                if ($(this).val().split('|')[1] == code3) {
                                                    $(this).attr("selected", "selected");
                                                }
                                            });
                                        }
                                    });
                                }
                            });
                        }
                        else if ($("#<%=HiddenAddressCode.ClientID%>").val().length == 6) {
                            var code1 = $("#<%=HiddenAddressCode.ClientID%>").val().substring(0, 3);
                            $("#DropDownListRegionCode1 option").each(function() {
                                if ($(this).val().split('|')[1] == code1) {
                                    $(this).attr("selected", "selected");
                                    funSelectRegionCode1(this);
                                    var code2 = $("#<%=HiddenAddressCode.ClientID%>").val().substring(0, 6);
                                    $("#DropDownListRegionCode2 option").each(function() {
                                        if ($(this).val().split('|')[1] == code2) {
                                            $(this).attr("selected", "selected");
                                            funSelectRegionCode2(this);
                                        }
                                    });
                                }
                            });
                        }
                        else if ($("#<%=HiddenAddressCode.ClientID%>").val().length == 3) {
                            var code1 = $("#<%=HiddenAddressCode.ClientID%>").val().substring(0, 3);
                            $("#DropDownListRegionCode1 option").each(function() {
                                if ($(this).val().split('|')[1] == code1) {
                                    $(this).attr("selected", "selected");
                                    funSelectRegionCode1(this);
                                }
                            });
                        }

                    }
                }
            }
        });
    })
</script>
<script type="text/javascript">
    function funSelectRegionCode1(val) {
        var id = $(val).val().split('|')[0]; //ID
        $.ajax({
            type: "get",
            url: "/Api/Main/Member/ThreeClassify.ashx",
            async: false,
            data: "FatherID=" + id + "&type=RegionCode",
            dataType: "html",
            success: function (ajaxData) {
                if (ajaxData != "") {
                    if (id == "-1") {
                        $("#<%=HiddenFieldRegionCode.ClientID%>").val("0");
                        $("#DropDownListRegionCode2").html("<option value=\"-1\">-请选择-</option>");
                        $("#DropDownListRegionCode3").html("<option value=\"-1\">-请选择-</option>");
                    }
                    else {
                        $("#DropDownListRegionCode2").html(ajaxData);
                        $("#<%=HiddenFieldRegionCode.ClientID%>").val($(val).val());
                    }

                }
            }
        });
    }

    function funSelectRegionCode2(val) {
        var id = $(val).val().split('|')[0]; //ID
        $.ajax({
            type: "get",
            url: "/Api/Main/Member/ThreeClassify.ashx",
            async: false,
            data: "FatherID=" + id + "&type=RegionCode",
            dataType: "html",
            success: function (ajaxData) {
                if (ajaxData != "") {
                    if (id == "-1") {
                        $("#<%=HiddenFieldRegionCode.ClientID%>").val($("#DropDownListRegionCode1").val())
                        $("#DropDownListRegionCode3").html("<option value=\"-1\">-请选择-</option>");
                    }
                    else {
                        $("#DropDownListRegionCode3").html(ajaxData);
                        $("#<%=HiddenFieldRegionCode.ClientID%>").val($(val).val());
                    }

                }
            }
        });
    }

    function funSelectRegionCode3(val) {
        var id = $(val).val().split('|')[0]; //ID
        if (id == "-1") {
            $("#<%=HiddenFieldRegionCode.ClientID%>").val($("#DropDownListRegionCode2").val())
        }
        else {
            $("#<%=HiddenFieldRegionCode.ClientID%>").val($(val).val());
        }
    }
         
         
        
</script>
<table width="100%" border="0" cellspacing="0" cellpadding="0" class="biaod" style="margin-top: 15px;">
    <tr>
        <th colspan="2" scope="col" width="130">
            <asp:Label ID="LabelTitle" runat="server" Text="发布供求信息"></asp:Label>
        </th>
    </tr>
    <tr>
        <td class="bordleft" width="130">
            所属类别：
        </td>
        <td class="bordrig">
            <select id="DropDownListSupplyDemandCategory1" onchange="funSelectValue1(this)" class="tselect1">
                <option value="-1">-请选择-</option>
            </select>
            <select id="DropDownListSupplyDemandCategory2" onchange="funSelectValue2(this)" class="tselect1">
                <option value="-1">-请选择-</option>
            </select>
            <select id="DropDownListSupplyDemandCategory3" onchange="funSelectValue3(this)" class="tselect1">
                <option value="-1">-请选择-</option>
            </select>
            <span id="errCommon" class="star">*</span>
        </td>
    </tr>
    <tr>
        <td class="bordleft">
            所属地区：
        </td>
        <td class="bordrig">
            <select id="DropDownListRegionCode1" onchange="funSelectRegionCode1(this)" class="tselect1">
                <option value="-1">-请选择-</option>
            </select>
            <select id="DropDownListRegionCode2" onchange="funSelectRegionCode2(this)" class="tselect1">
                <option value="-1">-请选择-</option>
            </select>
            <select id="DropDownListRegionCode3" onchange="funSelectRegionCode3(this)" class="tselect1">
                <option value="-1">-请选择-</option>
            </select>
            <span id="errRegion" class="star">*</span>
        </td>
    </tr>
    <tr>
        <td class="bordleft">
            信息标题：
        </td>
        <td class="bordrig">
            <asp:TextBox ID="TextBoxTitle" runat="server" CssClass="textwb" onblur="funCheckTitle()"
                MaxLength="50"></asp:TextBox>
            <span class="star" id="errTitle">*</span>
        </td>
    </tr>
    <tr>
        <td class="bordleft">
            交易类型：
        </td>
        <td class="bordrig">
            <asp:RadioButton ID="RadioButtonGong" runat="server" GroupName="gq" Checked="true"
                Text="供" Width="60px" />
            <asp:RadioButton ID="RadioButtonQiu" runat="server" GroupName="gq" Text="求" Width="60px" />
        </td>
    </tr>
    <tr>
        <td class="bordleft">
            联系电话：
        </td>
        <td class="bordrig">
            <asp:TextBox ID="TextBoxTel" runat="server" CssClass="textwb"></asp:TextBox>
            <span class="gray1"></span>
        </td>
    </tr>
    <tr>
        <td class="bordleft">
            电子邮件：
        </td>
        <td class="bordrig">
            <asp:TextBox ID="TextBoxEmail" runat="server" CssClass="textwb" onblur="funCheckEmail()"></asp:TextBox>
            <span class="gray1" id="errEmail" style="color: Red"></span>
        </td>
    </tr>
    <tr>
        <td class="bordleft">
            其他联系方式：
        </td>
        <td class="bordrig">
            <asp:TextBox ID="TextBoxOtherContactWay" runat="server" CssClass="textwb"></asp:TextBox>
            <span class="gray1"></span>
        </td>
    </tr>
    <tr>
        <td class="bordleft">
            联系人：
        </td>
        <td class="bordrig">
            <asp:TextBox ID="TextBoxContactName" runat="server" CssClass="textwb"></asp:TextBox>
            <span class="gray1"></span>
        </td>
    </tr>
    <tr>
        <td class="bordleft">
            过期时间：
        </td>
        <td class="bordrig">
            <asp:TextBox ID="TextBoxValidTime" runat="server" CssClass="Wdate  ss_nrduan" onclick="WdatePicker()"
                Style="width: 200px" onblur="funcheckValidTime()" onchange="funcheckValidTime()"></asp:TextBox>
            <span class="red" id="errTime">*</span>
        </td>
    </tr>
    <tr>
        <td class="bordleft">
            关键字：
        </td>
        <td class="bordrig">
            <asp:TextBox ID="TextBoxKeywords" runat="server" CssClass="textwb"></asp:TextBox>
            <span class="gray1">请认真填写，以便于被搜索引擎收录</span>
        </td>
    </tr>
    <tr>
        <td class="bordleft">
            信息描述：
        </td>
        <td class="bordrig">
            <asp:TextBox ID="TextBoxDescription" runat="server" CssClass="textwb1" TextMode="MultiLine"
                Font-Size="13px"></asp:TextBox>
            <div class="texttw_star">
                <span class="gray1">请认真填写，以便于被搜索引擎收录</span></div>
        </td>
    </tr>
    <tr>
        <td class="bordleft">
            选择图片：
        </td>
        <td class="bordrig">
            <asp:FileUpload ID="FileUploadImage" runat="server" />
        </td>
    </tr>
    <asp:Panel ID="PanelIsShow" runat="server" Visible="false">
        <tr>
            <td class="bordleft">
                图片预览：
            </td>
            <td class="bordrig">
                <asp:Image ID="ImageGq" runat="server" Width="200" Height="200" />
                <%--<asp:HiddenField ID="HiddenFieldImage" runat="server" />--%>
            </td>
        </tr>
    </asp:Panel>
    <tr>
        <td class="bordleft" style="border-bottom: solid 1px #c6dfff;">
            信息内容：
        </td>
        <td class="bordrig" style="border-bottom: solid 1px #c6dfff;">
            <asp:TextBox ID="TexteditorContent" runat="server" CssClass="Texteditor"></asp:TextBox>
            <span class="red" id="errContent" style="display: none">*</span>
        </td>
    </tr>
</table>
<div style="text-align: center; margin: 20px 0px 50px 0px;">
    <asp:Button ID="ButtonTj" runat="server" Text="确定" CssClass="baocbtn" 
        OnClientClick="return funCheckButton()" onclick="ButtonTj_Click" />
    <asp:Button ID="ButtonGoBack" runat="server" Text="返回" CssClass="baocbtn" 
        onclick="ButtonGoBack_Click" />&nbsp;&nbsp;
</div>
