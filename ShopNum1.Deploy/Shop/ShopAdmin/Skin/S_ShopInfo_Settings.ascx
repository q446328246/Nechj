<%@ Control Language="C#"%>
<%@ Import Namespace="ShopNum1.ShopAdminWebControl" %>
<script type="text/javascript" charset="utf-8" src="/kindeditor/kindeditor.js"> </script>
<script type="text/javascript" charset="utf-8" src="/kindeditor/lang/zh_CN.js"> </script>
<script type="text/javascript" charset="utf-8" src="/kindeditor/plugins/code/prettify.js"> </script>
<script src="js/CommonJS.js" type="text/javascript"> </script>
<script type='text/javascript' src='js/resolution-test.js'> </script>
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
            width: '560px',
            //编辑器宽度
            height: '220px;',
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
<script>
    //店铺名称
    function funTextBoxShopName() {
        var shopname = $("#<%= TextBoxShopName.ClientID %>").val();
        if (shopname != "") {
            if (shopname.length <= 20) {
                if ($("#<%= HiddenShopName.ClientID %>").val() != shopname) {
                    //检查店铺名称
                    //求唯一店铺名称！
                    $.ajax({
                        type: "get",
                        url: "/Api/ShopAdmin/S_AdminOpt.ashx",
                        async: true,
                        data: "type=ShopName&ShopName=" + shopname,
                        dataType: "html",
                        success: function (ajaxData) {
                            if (ajaxData != "") {
                                if (ajaxData == "false") {
                                    $("#errShopName").html("");
                                    $("#<%= HiddenNameSure.ClientID %>").val("ok");
                                    return true;
                                } else if (ajaxData == "true") {
                                    $("#errShopName").html("店铺名称已存在！");
                                    $("#<%= HiddenNameSure.ClientID %>").val("no");
                                    return false;
                                }
                            }
                        }
                    });
                } else {
                    $("#<%= HiddenNameSure.ClientID %>").val("ok");
                    $("#errShopName").html("");
                    return true;
                }
            } else {
                $("#<%= HiddenNameSure.ClientID %>").val("no");
                $("#errShopName").html("店铺名称请控制长度不超过20字！");
                return false;
            }
        } else {
            $("#<%= HiddenNameSure.ClientID %>").val("no");
            $("#errShopName").html("店铺名称不能为空！");
            return false;
        }
        return true;
    }


    function funCheckIdentityCard() {
        var IdentityCard = $("#<%= TextBoxIdentityCard.ClientID %>").val();
        if (IdentityCard != "") {
            var reg = /(^\d{15}$)|(^\d{18}$)|(^\d{17}(\d|X|x)$)/;
            if (reg.test(IdentityCard) === false) {
                $("#errIdentityCard").html("身份证号码不合法！");
                return false;
            } else {
                //唯一
                $.ajax({
                    type: "get",
                    url: "/Api/ShopAdmin/S_AdminOpt.ashx",
                    async: true,
                    data: "type=IdentityCard&IdentityCard=" + IdentityCard,
                    dataType: "html",
                    success: function (ajaxData) {
                        if (ajaxData != "") {
                            if (IdentityCard != $("#<%= HiddenIdentityValue.ClientID %>").val()) {
                                if (ajaxData == "false") {
                                    $("#errIdentityCard").html("");
                                    $("#<%= HiddenIdentityCard.ClientID %>").val("ok");
                                    return true;
                                } else if (ajaxData == "true") {
                                    $("#<%= HiddenIdentityCard.ClientID %>").val("no");
                                    $("#errIdentityCard").html("身份证已存在！");
                                    return false;
                                }
                            } else {
                                $("#errIdentityCard").html("");
                                $("#<%= HiddenIdentityCard.ClientID %>").val("ok");
                                return true;
                            }
                        }
                    }
                });
            }
        } else {
            $("#errIdentityCard").html("身份证号码不能为空！");
            $("#<%= HiddenIdentityCard.ClientID %>").val("no");
            return false;
        }
    }

    function funCheckButton() {
        funTextBoxShopName();
        funCheckIdentityCard();
        if (funTextBoxShopName() && $("#<%= HiddenNameSure.ClientID %>").val() == "ok" && $("#<%= HiddenIdentityCard.ClientID %>").val() == "ok" && funPhone() && funCheckTel()) {
            checkSumbit();
            return true;
        }
        return false;
    }

    function showDialog(type) {
        funOpen();
        switch (type) {
            case 1:
                $("#showiframe").attr("src", "/Shop/ShopAdmin/S_ShowShopPhoto.aspx?txtid=<%= HiddenFieldLogo.ClientID %>&imgid=<%= ImageMyLogo.ClientID %>");
                break;
            case 2:
                $("#showiframe").attr("src", "/Shop/ShopAdmin/S_ShowShopPhoto.aspx?txtid=<%= HiddenFieldBackGround.ClientID %>&imgid=<%= ImageBoxBackGround.ClientID %>");
                break;
            case 3:
                $("#showiframe").attr("src", "/Shop/ShopAdmin/S_ShowShopPhoto.aspx?txtid=<%= HiddenFieldSign.ClientID %>&imgid=<%= ImageSign.ClientID %>");
                break;
            default:
                break;
        }
    }

    //    验证手机号码

    function funPhone() {
        var phone = $("#S_ShopInfo_ctl00_S_ShopInfo_Settings_ctl00_TextBoxPhone").val();
        if (phone == "") {
            $("#errTextBoxPhone").html("手机号码不能为空！");
            return false;
        } else {
            var p1 = /^1[358]\d{9}$/;
            if (p1.test(phone)) {
                $("#errTextBoxPhone").html("");
                return true;
            } else {
                $("#errTextBoxPhone").html("手机号码格式错误！");
                return false;
            }
        }
    }

    //验证电话号码

    function funCheckTel() {
        return true;
        var tel = $("#S_ShopInfo_ctl00_S_ShopInfo_Settings_ctl00_TextBoxTel").val();
        if (tel == "") {
            $("#errTel").html("固定电话不能为空！");
            return false;
        } else {
            var reg = /^((0\d{2,3})-)(\d{7,8})(-(\d{3,}))?$/;
            if (!reg.test(tel)) {
                $("#errTel").html("号码格式错误！");
                return false;
            } else {
                $("#errTel").html("");
                return true;
            }
        }
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
<div>
    <!--弹出层-->
    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="tabbiao">
        <tr>
            <td align="right" valign="top" width="130px">
                店铺名称：
            </td>
            <td>
                <asp:TextBox ID="TextBoxShopName" runat="server" CssClass="textwb" Width="219" onblur="funTextBoxShopName()"></asp:TextBox>
                <span id="Span1" style="color: red">*</span> <span id="errShopName" style="color: red">
                </span>
                <div class="gray1">
                    店铺名称请控制长度不超过20字。</div>
            </td>
        </tr>
        <tr>
            <td align="right" valign="top">
                掌柜名：
            </td>
            <td>
                <asp:TextBox ID="TextBoxName" runat="server" CssClass="textwb" Width="219"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right" valign="top">
                店铺保障：
            </td>
            <td>
                <asp:Repeater ID="RepeaterBaoz" runat="server">
                    <ItemTemplate>
                        <asp:Image ID="ImagePath" runat="server" Width="14" Height="15" Style="margin-left: 10px;"
                            ImageUrl='<%#Eval("ImagePath") %>' />
                        <span class="blue">
                            <%#Eval("Name") %></span>
                    </ItemTemplate>
                </asp:Repeater>
                <input name="" type="button" class="dianpbz" value="申请店铺保障" onclick=" javascript:location.href = 'S_EnsureApplyRecordList.aspx'; " />
            </td>
        </tr>
        <tr>
            <td align="right" valign="top">
                店铺等级：
            </td>
            <td>
                <table cellpadding="0" cellspacing="0" border="0">
                    <tr>
                        <td>
                            <span class="blue">
                                <asp:Label ID="LabelShopRank" runat="server" Text="系统默认"></asp:Label></span>
                        </td>
                        <td style="padding-left: 10px;">
                            <asp:Image ID="ImageShopRank" runat="server" Height="16"></asp:Image>
                        </td>
                        <td style="padding-left: 10px;">
                            <input name="" type="button" class="sqjdbzj1" value="马上升级店铺等级" onclick=" javascript:location.href = 'S_ShowShopRank.aspx'; " />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="right" valign="top">
                主营商品：
            </td>
            <td>
                <asp:TextBox ID="TextBoxMainGoods" runat="server" CssClass="textwb" Width="450" Height="90"
                    TextMode="MultiLine"></asp:TextBox>
                <div class="gray1">
                    主营商品关键字有助于搜索店铺时找到您的店铺。</div>
            </td>
        </tr>
        <tr>
            <td align="right" valign="top">
                店铺logo：
            </td>
            <td>
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td width="330" style="padding-bottom: 6px; padding-top: 6px;">
                            <asp:Image ID="ImageMyLogo" runat="server" Width="221" Height="52" />
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="TextBoxLogo" runat="server" CssClass="textwb" Width="219" Visible="false"></asp:TextBox>
                            <asp:HiddenField ID="HiddenFieldLogo" runat="server" />
                            <input name="" type="button" class="selpic" onclick=" showDialog(1) " value="选择图片" />
                            <div class="gray1" style="margin-top: 0; width: 370px;">
                                此处为您的店铺logo，将显示在店铺logo栏里,图片规格为407x74。</div>
                        </td>
                        <td class="blue">
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="right" valign="top">
                店铺条幅：
            </td>
            <td>
                <div>
                    <asp:Image ID="ImageBoxBackGround" runat="server" Width="615" Height="160" />
                </div>
                <div>
                    <asp:TextBox ID="TextBoxBackGround" runat="server" CssClass="textwb" Width="219"
                        Visible="false"></asp:TextBox>
                    <asp:HiddenField ID="HiddenFieldBackGround" runat="server" />
                    <input name="" type="button" class="selpic" onclick=" showDialog(2) " value="选择图片" />
                </div>
                <div class="gray1" style="margin-top: 0;">
                    此处为您的店铺条幅，将显示在店铺导航上方的banner位置,图片规格为1600x100。</div>
            </td>
        </tr>
        <tr>
            <td align="right" valign="top">
                店铺标志：
            </td>
            <td>
                <div>
                    <asp:Image ID="ImageSign" runat="server" Width="100" Height="100" />
                </div>
                <div>
                    <asp:TextBox ID="TextBoxSign" runat="server" CssClass="textwb" Width="219" Visible="false"></asp:TextBox>
                    <asp:HiddenField ID="HiddenFieldSign" runat="server" />
                    <input name="" type="button" class="selpic" value="选择图片" onclick=" showDialog(3) " />
                </div>
            </td>
        </tr>
        <tr>
            <td align="right" valign="top">
                身份证号：
            </td>
            <td>
                <asp:TextBox ID="TextBoxIdentityCard" runat="server" CssClass="textwb" Width="219"
                    onblur="funCheckIdentityCard()" ReadOnly="true"></asp:TextBox>
                <span style="color: red" id="errIdentityCard"></span>
            </td>
        </tr>
        <tr>
            <td align="right" valign="top">
                <span id="Span2" style="color: red">&nbsp;*</span>手机号码：
            </td>
            <td>
                <asp:TextBox ID="TextBoxPhone" runat="server" CssClass="textwb" Width="219" onblur="funPhone()"></asp:TextBox>
                <span style="color: red" id="errTextBoxPhone"></span>
            </td>
        </tr>
        <tr>
            <td align="right" valign="top">
                固定电话：
            </td>
            <td>
                <asp:TextBox ID="TextBoxTel" runat="server" CssClass="textwb" Width="219" onblur="funCheckTel()"></asp:TextBox>
                <%--<span style="color: red" id="errTel"></span>--%>
            </td>
        </tr>
       <%-- tr>
            <td align="right" valign="top">
                推荐人：
            </td>
            <td>
               <asp:Label ID="LabelReferral" runat="server" CssClass="textwb" Width="219"></asp:Label>
                <%--<span style="color: red" id="errTel"></span>--%>
            <%--</td>--%>
        <%--</tr>--%>
        <tr>
            <td align="right" valign="top">
                所在地区：
            </td>
            <td>
                <div id="p_local">
                </div>
            </td>
        </tr>
        <tr>
            <td align="right" valign="top">
                详细地址：
            </td>
            <td>
                <asp:TextBox ID="TextBoxAdress" runat="server" CssClass="textwb" Width="219"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right" valign="top">
                店铺简介：
            </td>
            <td>
                <asp:TextBox ID="TextBoxMemo" runat="server" CssClass="textwb" Width="450" TextMode="MultiLine"
                    Height="90"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right" valign="top">
                店铺介绍：
            </td>
            <td>
                <asp:TextBox ID="TextBoxShopIntroduce" runat="server" CssClass="Texteditor" Width="450"
                    TextMode="MultiLine" Height="90"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right" valign="top">
                店铺二维码：
            </td>
            <td>
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td>
                            <table border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td width="120">
                                        <asp:Image ID="twoImage" runat="server" Width="160" Height="160" />
                                    </td>
                                    <td valign="bottom">
                                        <asp:Button ID="ButtonUpdateTwo" runat="server" Text="更新" CssClass="selpic" />
                                    </td>
                                </tr>
                            </table>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <span class="gray1">二维码所含信息为店铺首页链接，当前店铺链接：<a href="" id="currLink" runat="server"
                                target="_blank"><asp:Label ID="LabelCurrLink" runat="server" Text="Label"></asp:Label></a></span>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="right" valign="top">
                &nbsp;
            </td>
            <td style="padding: 10px 0px 10px 0px;">
                <asp:Button ID="ButtonSave" runat="server" Text="保存" CssClass="baocbtn" OnClientClick=" return funCheckButton() " />
            </td>
        </tr>
    </table>
</div>
<input id="hid_Area" type="hidden" runat="server" value="" />
<input id="hid_AreaCode" type="hidden" runat="server" value="" />
<input id="HiddenShopName" type="hidden" runat="server" value="" />
<input id="HiddenNameSure" type="hidden" runat="server" value="ok" />
<input id="HiddenIdentityCard" type="hidden" runat="server" value="ok" />
<input id="HiddenIdentityValue" type="hidden" runat="server" value="" />