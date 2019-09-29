<%@ Control Language="C#" %>
<%@ Import Namespace="ShopNum1.ShopAdminWebControl" %>
<script>
    function funCheckShopName() {
        var shopname = $("#<%= TextBoxShopName.ClientID %>").val();
        if (shopname != "") {
            if (shopname.length > 20) {
                $("#errShopName").html("店铺名称长度不能超过20的字符！");
                return false;
            } else {
                //求唯一店铺名称！
                $.ajax({
                    type: "get",
                    url: "/Api/ShopAdmin/S_AdminOpt.ashx",
                    async: true,
                    data: "type=ShopName&ShopName=" + shopname,
                    dataType: "html",
                    success: function (ajaxData) {
                        if (ajaxData != "") {
                            if (shopname != $("#<%= HiddenShopNameValue.ClientID %>").val()) {
                                if (ajaxData == "false") {
                                    $("#errShopName").html("");
                                    $("#S_ShopOpenStep2_ctl00_HiddenShopName").val("ok");
                                    return true;
                                } else if (ajaxData == "true") {
                                    $("#errShopName").html("店铺名称已存在！");
                                    return false;
                                }
                            } else {
                                $("#S_ShopOpenStep2_ctl00_HiddenShopName").val("ok");
                                return true;
                            }

                        }
                    }
                });
            }
        } else {
            $("#errShopName").html("店铺名称不能为空！");
            return false;
        }
    }


    //检查座机电话
    function funCheckTel() {
        var tel = $("#<%= TextBoxTel.ClientID %>").val();
        if (tel != "") {
            //表示座机电话
            var reg = /^((0\d{2,3})-)(\d{7,8})(-(\d{3,}))?$/;
            if (!reg.test(tel)) {
                $("#errTel").html("号码格式错误！");
                return false;
            } else {
                $("#errTel").html("");
                return true;
            }
        }
        $("#errTel").html("");
        return true;

    }

    //验证身份证
    function funCheckIDD() {
        var idd = $("#<%= TextBoxIdentityCard.ClientID %>").val();
        if (idd != "") {
            var partten = /^[\d]{6}((19[\d]{2})|(200[0-8]))((0[1-9])|(1[0-2]))((0[1-9])|([12][\d])|(3[01]))[\d]{3}[0-9xX]$/;
            if (partten.test(idd)) {
                //唯一
                $.ajax({
                    type: "get",
                    url: "/Api/ShopAdmin/S_AdminOpt.ashx",
                    async: true,
                    data: "type=IdentityCard&IdentityCard=" + idd,
                    dataType: "html",
                    success: function (ajaxData) {
                        if (ajaxData != "") {
                            if (idd != $("#<%= HiddenIdentityValue.ClientID %>").val()) {
                                if (ajaxData == "false") {
                                    $("#errIdentityCard").html("");
                                    $("#<%= HiddenIdentityCard.ClientID %>").val("ok");
                                    return true;
                                } else if (ajaxData == "true") {
                                   
                                    return true;
                                }
                            } else {
                                $("#<%= HiddenIdentityCard.ClientID %>").val("ok");
                                return true;
                            }

                        }
                    }
                });
                $("#errIdentityCard").html("");
                return true;
            } else {
                $("#errIdentityCard").html("身份证格式错误！");
                return false;
            }
        } else {
            $("#errIdentityCard").html("身份证不能为空！");
            return false;
        }
        return false;
    }



    function funButton() {
        funCheckShopName();
        funCheckShopCategory();
        checkSumbit();
        funCheckAdress();
        funCheckIDD();

        funCheckTextBoxAddress();
        funCheckPhone();
        if ($("#S_ShopOpenStep2_ctl00_RadioButtonPersonal").attr("checked") == "checked") {
            funUpdateImage1();
            funUpdateImage2();
            if (funUpdateImage1() && funUpdateImage2()) {

            }
            else {
                return false;
            }
        } else if ($("#S_ShopOpenStep2_ctl00_RadioButtonBusiness").attr("checked") == "checked") {
            funUpdateImage1();
            funUpdateImage2();
            funUpdateImage3();
            funUpdateImage4();
            if (funUpdateImage1() && funUpdateImage2() && funUpdateImage3() && funUpdateImage4()) {

            } else {
                return false;
            }
        }
        //        funUpdateImage();
        if (funCheckPhone() && funCheckTextBoxAddress() && funCheckTel() && funCheckIDD() && funCheckShopCategory() && $("#S_ShopOpenStep2_ctl00_hid_Area").val() != "" && funCheckAdress() && $("#S_ShopOpenStep2_ctl00_HiddenShopName").val() == "ok" && $("#<%= HiddenIdentityCard.ClientID %>").val() == "ok") {
            if ($("#selectAgress").attr("checked") != "checked") {
                alert("请同意协议！");
                return false;
            }
            return true;
        }
        return false;
    }


    function funCheckShopCategory() {
        if ($("#S_ShopOpenStep2_ctl00_HiddenShopCategoryValue").val() == "0") {
            $("#errShopCategory").html("店铺分类必填！");
            return false;
        }
        $("#errShopCategory").html("");
        return true;
    }


    function funCheckAdress() {
        if ($("#S_ShopOpenStep2_ctl00_hid_Area").val() == "") {
            $("#errAdress").html("所在地区必须选择！");
            return false;
        }
        $("#errAdress").html("");
        return true;
    }

</script>
<script type="text/javascript" language="javascript">

    function funSelectValue1(val) {
        //-------------------------------------------
        var id = $(val).val().split('|')[0];
        $.ajax(
            {
                type: "get",
                url: "/Api/ShopAdmin/S_AdminOpt.ashx",
                async: false,
                data: "FatherID=" + id + "&type=ShopCategory",
                dataType: "Json",
                success: function (ajaxData) {
                    var code = $("#S_ShopOpenStep2_ctl00_HiddenShopCategory").val();
                    var xhtml = new Array();
                    xhtml.push('<option value=\"-1\">-请选择-</option>');
                    if (ajaxData != null) {
                        $.each(ajaxData, function (m, n) {
                            var xcode = n.id + "|" + n.code;
                            if (code != "" && code.length >= 6) {
                                code = code.substring(0, 6);
                                if (code == n.code) {
                                    xhtml.push('<option value="' + xcode + '" selected="selected">' + n.name + '</option>');
                                } else {
                                    xhtml.push('<option value="' + xcode + '">' + n.name + '</option>');
                                }
                            } else {
                                xhtml.push('<option value="' + xcode + '">' + n.name + '</option>');
                            }
                        });
                        //                        if($("#S_ShopOpenStep2_ctl00_ButtonOpen").val()=="立即开店")
                        //                        {
                        $("#S_ShopOpenStep2_ctl00_HiddenShopCategoryValue").val($("#DropDownListShopCategory1").val()); //                        }

                        $("#DropDownListShopCategory2").html(xhtml.join(""));
                    } else {
                        $("#S_ShopOpenStep2_ctl00_HiddenShopCategoryValue").val("0");
                        $("#DropDownListShopCategory2").html(xhtml.join(""));
                        //                        $("#DropDownListShopCategory3").html(xhtml.join(""));
                    }
                    funSelectValue2($("#DropDownListShopCategory2"));
                }
            });

    }

    function funSelectValue2(val) {
        var id = $(val).val().split('|')[0];
        $.ajax(
            {
                type: "get",
                url: "/Api/ShopAdmin/S_AdminOpt.ashx",
                async: false,
                data: "FatherID=" + id + "&type=ShopCategory",
                dataType: "Json",
                success: function (ajaxData) {
                    var code = $("#S_ShopOpenStep2_ctl00_HiddenShopCategory").val();
                    var xhtml = new Array();
                    xhtml.push('<option value=\"-1\">-请选择-</option>');
                    if (ajaxData != null) {
                        $.each(ajaxData, function (m, n) {
                            var xcode = n.id + "|" + n.code;

                            if (code != "" && code.length >= 9) {
                                code = code.substring(0, 9);
                                //                                alert(n.code);
                                //                                alert(code);
                                if (code == n.code) {
                                    xhtml.push('<option value="' + xcode + '" selected="selected">' + n.name + '</option>');
                                } else {
                                    xhtml.push('<option value="' + xcode + '">' + n.name + '</option>');
                                }
                            } else {
                                xhtml.push('<option value="' + xcode + '">' + n.name + '</option>');
                            }
                        });
                        //                        if($("#S_ShopOpenStep2_ctl00_ButtonOpen").val()=="立即开店")
                        //                        {
                        $("#S_ShopOpenStep2_ctl00_HiddenShopCategoryValue").val($("#DropDownListShopCategory2").val()); //                        }
                        $("#DropDownListShopCategory3").html(xhtml.join(""));
                    } else {
                        //$("#S_ShopOpenStep2_ctl00_HiddenShopCategoryValue").val("0")
                        $("#DropDownListShopCategory3").html(xhtml.join(""));
                    }

                }
            });
    }

    function funSelectValue3(val) {
        var id = $(val).val().split('|')[0]; //ID
        if (id == "-1") {
            $("#S_ShopOpenStep2_ctl00_HiddenShopCategory").val($("#DropDownListShopCategory2").val());
        } else {
            $("#S_ShopOpenStep2_ctl00_HiddenShopCategory").val($(val).val());
        }
        //            if($("#S_ShopOpenStep2_ctl00_ButtonOpen").val()=="立即开店")
        //            {
        $("#S_ShopOpenStep2_ctl00_HiddenShopCategoryValue").val($("#DropDownListShopCategory3").val()); //            }
    }

</script>
<script>
    $(function () {
        //求分类
        $.ajax(
            {
                type: "get",
                url: "/Api/ShopAdmin/S_AdminOpt.ashx",
                async: false,
                data: "FatherID=0&type=ShopCategory",
                dataType: "Json",
                success: function (ajaxData) {
                    var code = $("#S_ShopOpenStep2_ctl00_HiddenShopCategory").val();
                    var xhtml = new Array();
                    xhtml.push('<option value=\"-1\">-请选择-</option>');
                    $.each(ajaxData, function (m, n) {
                        var xcode = n.id + "|" + n.code;
                        if (code != "") {
                            code = code.substring(0, 3);
                            if (code == n.code) {
                                xhtml.push('<option value="' + xcode + '" selected="selected">' + n.name + '</option>');
                            } else {
                                xhtml.push('<option value="' + xcode + '">' + n.name + '</option>');
                            }
                        } else {
                            xhtml.push('<option value="' + xcode + '">' + n.name + '</option>');
                        }
                    });
                    if (ajaxData != "") {
                        $("#DropDownListShopCategory1").html(xhtml.join(""));
                    }
                }
            });
        funSelectValue1($("#DropDownListShopCategory1"));
        funSelectValue2($("#DropDownListShopCategory2"));
    })
</script>
<script language="javascript">
    $(function () {
        if ($("#<%= HiddenIdEdit.ClientID %>").val() == "1") {
            $("#returnBut").hide();
        }
    })

</script>
<script>
    //检查详细地址
    function funCheckTextBoxAddress() {
        var TextBoxAddress = $("#S_ShopOpenStep2_ctl00_TextBoxAddress").val();
        if (TextBoxAddress != "") {
            $("#errTextBoxAddress").html("");
            return true;
        } else {
            $("#errTextBoxAddress").css("color", "red");
            $("#errTextBoxAddress").html("详细地址不能为空！");
            return false;
        }
        return false;
    }

    //检查联系电话

    function funCheckPhone() {
        var phone = $("#<%= TextBoxPhone.ClientID %>").val();
        if (phone != "") {
            //表示手机
            var reg = /^1[3578]\d{9}$/;
            if (!reg.test(phone)) {
                $("#errPhone").html("号码格式错误！");
                return false;
            } else {
                $("#errPhone").html("");
                return true;
            }
        } else {
            $("#errPhone").html("联系电话不能为空！");
            return false;
        }
        return false;

    }

    //检查上传图片

    function funUpdateImage1() {
        var falt = false;
        var f1 = $("#S_ShopOpenStep2_ctl00_FileUploadIdentityCard").val();
        //表示个人
        var HiddenIdentityCardValue = $("#S_ShopOpenStep2_ctl00_HiddenIdentityCardValue").val();
        if (HiddenIdentityCardValue == "") {
            if (f1 != "") {
                var fjcheck = f1.substring(f1.lastIndexOf(".") + 1); //获取后缀名
                if (fjcheck == "jpg" || fjcheck == "jpeg" || fjcheck == "png" || fjcheck == "gif") {
                    $("#errIdentityCardimage").html("");
                    falt = true;
                } else {
                    $("#errIdentityCardimage").html("图片格式必须为jpg、jpeg、png、gif！");
                    falt = false;
                }

            } else {
                $("#errIdentityCardimage").html("申请个人店铺必须上传身份证正反面图片！");
                falt = false;
            }
        } else {
            $("#errIdentityCardimage").html("");
            falt = true;
        }
        return falt;
    }

    function funUpdateImage2() {
        var falt = false;
        var f2 = $("#S_ShopOpenStep2_ctl00_FileUploadBusinessLicense").val();
        //表示企业
        if ($("#S_ShopOpenStep2_ctl00_HiddenBusinessImageValue").val() == "") {
            if (f2 != "") {
                var fjcheck = f2.substring(f2.lastIndexOf(".") + 1).toLowerCase(); //获取后缀名
                if (fjcheck == "jpg" || fjcheck == "jpeg" || fjcheck == "png" || fjcheck == "gif") {
                    $("#errBusinessLicense").html("");
                    falt = true;
                } else {
                    $("#errBusinessLicense").html("图片格式必须为jpg、jpeg、png、gif！");
                    falt = false;
                }

            } else {
                $("#errBusinessLicense").html("申请企业店铺必须上传营业执照图片！");
                falt = false;
            }
        } else {
            $("#errBusinessLicense").html("");
            falt = true;
        }
        return falt;
    }
    function funUpdateImage3() {
        var falt = false;
        var f2 = $("#S_ShopOpenStep2_ctl00_FileUploadTaxRegistration").val();
        //表示企业
        if ($("#S_ShopOpenStep2_ctl00_HiddenTaxRegistration").val() == "") {
            if (f2 != "") {
                var fjcheck = f2.substring(f2.lastIndexOf(".") + 1).toLowerCase(); //获取后缀名
                if (fjcheck == "jpg" || fjcheck == "jpeg" || fjcheck == "png" || fjcheck == "gif") {
                    $("#eerTaxRegistration").html("");
                    falt = true;
                } else {
                    $("#eerTaxRegistration").html("图片格式必须为jpg、jpeg、png、gif！");
                    falt = false;
                }

            } else {
                $("#eerTaxRegistration").html("申请企业店铺必须上传税务登记证图片！");
                falt = false;
            }
        } else {
            $("#eerTaxRegistration").html("");
            falt = true;
        }
        return falt;
    }

    function funUpdateImage4() {
        var falt = false;
        var f2 = $("#S_ShopOpenStep2_ctl00_FileUploadOrganization").val();
        //表示企业
        if ($("#S_ShopOpenStep2_ctl00_HiddenOrganization").val() == "") {
            if (f2 != "") {
                var fjcheck = f2.substring(f2.lastIndexOf(".") + 1).toLowerCase(); //获取后缀名
                if (fjcheck == "jpg" || fjcheck == "jpeg" || fjcheck == "png" || fjcheck == "gif") {
                    $("#eerOrganization").html("");
                    falt = true;
                } else {
                    $("#eerOrganization").html("图片格式必须为jpg、jpeg、png、gif！");
                    falt = false;
                }

            } else {
                $("#eerOrganization").html("申请企业店铺必须上传组织机构代码图片！");
                falt = false;
            }
        } else {
            $("#eerOrganization").html("");
            falt = true;
        }
        return falt;
    }

    function funCheckGr() {
        $("#PanelTextBoxIdentityCardtr").show();
        $("#PanelBusinessLicensetr").show();
        $("#PanelTextBoxIdentityCardtrWz").show();
        $("#PanelBusinessLicensetrWz").show();


        $("#PanelTaxRegistrationtr").hide();
        $("#PanelTaxRegistrationWZ").hide();
        $("#S_ShopOpenStep2_ctl00_PanelTaxRegistration").val("");

        $("#PanelOrganizationtr").hide();
        $("#PanelOrganizationtrWZ").hide();
        $("#S_ShopOpenStep2_ctl00_PanelOrganization").val("");
    }

    function funCheckQy() {
        $("#PanelTextBoxIdentityCardtr").show();
        $("#PanelBusinessLicensetr").show();
        $("#PanelTextBoxIdentityCardtrWz").show();
        $("#PanelBusinessLicensetrWz").show();

        $("#PanelTaxRegistrationtr").show();
        $("#PanelTaxRegistrationWZ").show();

        $("#PanelOrganizationtr").show();
        $("#PanelOrganizationtrWZ").show();
    }

    $(function () {
        if ($("#S_ShopOpenStep2_ctl00_RadioButtonPersonal").attr("checked") == "checked") {
            $("#PanelTextBoxIdentityCardtr").show();
            $("#PanelBusinessLicensetr").show();
            $("#PanelTextBoxIdentityCardtrWz").show();
            $("#PanelBusinessLicensetrWz").show();

            $("#PanelTaxRegistrationtr").hide();
            $("#PanelTaxRegistrationWZ").hide();
            $("#S_ShopOpenStep2_ctl00_PanelTaxRegistration").val("");


            $("#PanelOrganizationtr").hide();
            $("#PanelOrganizationtrWZ").hide();
            $("#S_ShopOpenStep2_ctl00_PanelOrganization").val("");
        } else {
            $("#PanelTextBoxIdentityCardtr").show();
            $("#PanelBusinessLicensetr").show();
            $("#PanelTextBoxIdentityCardtrWz").show();
            $("#PanelBusinessLicensetrWz").show();

            $("#PanelTaxRegistrationtr").show();
            $("#PanelTaxRegistrationWZ").show();

            $("#PanelOrganizationtr").show();
            $("#PanelOrganizationtrWZ").show();

        }

    });
</script>
<div class="dpsc_mian" style="width: 998px;">
    <div class="maijtitle2">
    </div>
    <table border="0" cellspacing="0" cellpadding="0" class="buzlb">
        <%--<tr>
    <td align="right" width="200">店铺等级：</td>
    <td>
        <asp:Label ID="LabelShopRank" runat="server" Text=""></asp:Label>
    </td>
  </tr>--%>
        <tr>
            <td align="right" width="200">
                <span class="red">*</span> 店铺类别：
            </td>
            <td>
                <asp:RadioButton ID="RadioButtonPersonal" runat="server" Width="60" onclick="funCheckGr()"
                    Text="个人" GroupName="type" Checked="true" AutoPostBack="false" />
                <asp:RadioButton ID="RadioButtonBusiness" runat="server" Width="60" onclick="funCheckQy()"
                    Text="企业" GroupName="type" AutoPostBack="false" />
            </td>
        </tr>
        <tr>
            <td align="right">
                <span class="red">*</span> 店铺名称：
            </td>
            <td>
                <asp:TextBox ID="TextBoxShopName" runat="server" CssClass="textwb" onblur="funCheckShopName()"></asp:TextBox>
                <span id="errShopName" style="color: Red"></span>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                <div class="gray1" style="line-height: 16px;">
                    店铺名称请控制在20个字符以内</div>
            </td>
        </tr>
        <tr>
            <td align="right">
                <span class="red">*</span> 店铺分类：
            </td>
            <td style="line-height: 40px;">
                <select id="DropDownListShopCategory1" onchange=" funSelectValue1(this) " class="textwb"
                    style="width: 130px">
                    <option value="-1">-请选择-</option>
                </select>
                <select id="DropDownListShopCategory2" onchange=" funSelectValue2(this) " class="textwb"
                    style="width: 130px">
                    <option value="-1">-请选择-</option>
                </select>
                <select id="DropDownListShopCategory3" onchange=" funSelectValue3(this) " class="textwb"
                    style="width: 130px">
                    <option value="-1">-请选择-</option>
                </select>
                <span id="errShopCategory" style="color: Red"></span>
            </td>
        </tr>
        <tr>
            <td align="right">
                主营商品：
            </td>
            <td>
                <asp:TextBox ID="TextBoxMainGoods" runat="server" TextMode="MultiLine" MaxLength="500"
                    Width="290" Height="90" CssClass="textwb" Font-Size="12px"></asp:TextBox>
                <br />
                <span class="gray1">主营商品关键字（Tag）有助于搜索店铺时找到您的店铺</span>
            </td>
        </tr>
        <tr>
            <td align="right">
                <span class="red">*</span> 所在地区：
            </td>
            <td>
                <table>
                    <tr>
                        <td>
                            <div id="p_local">
                            </div>
                        </td>
                        <td>
                            <span class="gray1" id="errAdress" style="color: red; float: right"></span>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="right">
                <span class="red">*</span> 详细地址：
            </td>
            <td>
                <asp:TextBox ID="TextBoxAddress" runat="server" CssClass="textwb" MaxLength="250"
                    onblur="funCheckTextBoxAddress()"></asp:TextBox>
                <span class="gray1" id="errTextBoxAddress"></span>
            </td>
        </tr>
        <tr>
            <td align="right">
                邮政编码：
            </td>
            <td>
                <asp:TextBox ID="TextBoxPostalCode" runat="server" CssClass="textwb" MaxLength="6"></asp:TextBox>
                <span class="gray1">&nbsp;</span>
            </td>
        </tr>
        <tr>
            <td align="right">
                <span class="red">*</span> 手机号码：
            </td>
            <td>
                <asp:TextBox ID="TextBoxPhone" runat="server" CssClass="textwb" onblur="funCheckPhone()"
                    MaxLength="11"></asp:TextBox>
                <span class="gray1" id="errPhone" style="color: red">&nbsp;</span>
            </td>
        </tr>
        <tr>
            <td align="right">
                座机号码：
            </td>
            <td>
                <asp:TextBox ID="TextBoxTel" runat="server" CssClass="textwb" onblur="funCheckTel()"></asp:TextBox>
                <span class="gray1" id="errTel" style="color: red">&nbsp;</span>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                <div class="gray1" style="line-height: 16px;">
                    注意座机号码格式(如027-88888888)！</div>
            </td>
        </tr>
        <tr>
            <td align="right">
                <span class="red">*</span> 身份证号：
            </td>
            <td>
                <asp:TextBox ID="TextBoxIdentityCard" runat="server" CssClass="textwb" onblur="funCheckIDD()"></asp:TextBox>
                <span class="gray1" id="errIdentityCard" style="color: red">&nbsp;</span>
            </td>
        </tr>
       <%-- <tr>
            <td align="right">
                <span class="red">*</span> 推荐人：
            </td>
            <td>
                <asp:TextBox ID="TextBoxReferral" runat="server" CssClass="textwb" onblur="funCheckIDD1()"></asp:TextBox>
                <span class="gray1" id="Referral1" style="color: red">&nbsp;</span>
            </td>
        </tr>--%>
        <asp:Panel ID="PanelTextBoxIdentityCard" runat="server">
            <tr id="PanelTextBoxIdentityCardtr">
                <td align="right">
                    <span class="red">*</span> 上传身份证：
                </td>
                <td>
                    <asp:FileUpload ID="FileUploadIdentityCard" runat="server" onchange="funUpdateImage1()" /><span
                        class="gray1" id="errIdentityCardimage" style="color: red">&nbsp;</span>
                    <%--//<asp:HiddenField ID="HiddenFieldIdentityCard" runat="server" />--%>
                </td>
            </tr>
            <tr id="PanelTextBoxIdentityCardtrWz">
                <td>
                </td>
                <td style="color: Silver">
                    身份证为正反面复印件，格式jpg，jpeg，png，gif，请保证图片清晰且文件大小不超过500KB
                </td>
            </tr>
        </asp:Panel>
        <asp:Panel ID="PanelBusinessLicense" runat="server">
            <tr id="PanelBusinessLicensetr">
                <td align="right">
                    <span class="red">*</span> 上传执照：
                </td>
                <td>
                    <asp:FileUpload ID="FileUploadBusinessLicense" runat="server" onchange="funUpdateImage2()" /><span
                        class="gray1" id="errBusinessLicense" style="color: red">&nbsp;</span>
                    <asp:HiddenField ID="HiddenField2" runat="server" />
                </td>
            </tr>
            <tr id="PanelBusinessLicensetrWz">
                <td>
                </td>
                <td style="color: Silver">
                    营业执照复印件，格式jpg，jpeg，png，gif，请保证图片清晰且文件大小不超过500KB
                </td>
            </tr>
        </asp:Panel>
        <asp:Panel ID="PanelTaxRegistration" runat="server">
            <tr id="PanelTaxRegistrationtr">
                <td align="right">
                    <span class="red">*</span> 上传税务登记证：
                </td>
                <td>
                    <asp:FileUpload ID="FileUploadTaxRegistration" runat="server" onchange="funUpdateImage3()" /><span
                        class="gray1" id="eerTaxRegistration" style="color: red">&nbsp;</span>
                    <asp:HiddenField ID="HiddenField1" runat="server" />
                </td>
            </tr>
            <tr id="PanelTaxRegistrationWZ">
                <td>
                </td>
                <td style="color: Silver">
                   税务登记证印件，格式jpg，jpeg，png，gif，请保证图片清晰且文件大小不超过500KB
                </td>
            </tr>
        </asp:Panel>
        <asp:Panel ID="PanelOrganization" runat="server">
            <tr id="PanelOrganizationtr">
                <td align="right">
                    <span class="red">*</span> 上传组织机构代码：
                </td>
                <td>
                    <asp:FileUpload ID="FileUploadOrganization" runat="server" onchange="funUpdateImage4()" /><span
                        class="gray1" id="eerOrganization" style="color: red">&nbsp;</span>
                    <asp:HiddenField ID="HiddenField3" runat="server" />
                </td>
            </tr>
            <tr id="PanelOrganizationtrWZ">
                <td>
                </td>
                <td style="color: Silver">
                    组织机构代码复印件，格式jpg，jpeg，png，gif，请保证图片清晰且文件大小不超过500KB
                </td>
            </tr>
        </asp:Panel>
        <tr>
            <td align="right">
            </td>
            <td>
                <input name="" type="checkbox" value="" id="selectAgress" checked="checked" />
                <span>我已认真阅读并同意<a target="_blank" style="color: blue" href='<%= ShopUrlOperate.RetUrl("ShopRegProtocol") %>'
                    class="blue">开店协议</a>中的所有条款</span>
            </td>
        </tr>
    </table>
    <div class="maijtitle1">
        <asp:Button ID="ButtonOpen" runat="server" Text="立即开店" OnClientClick=" return funButton() "
            CssClass="sqjdbzj" />
        <input name="12" type="button" class="sqjdbzj" value="返回重选" onclick=" javascript:location.href = 'S_ShopOpenStep1.aspx'; "
            id="returnBut" />
    </div>
</div>
<input id="hid_Area" type="hidden" runat="server" value="" />
<input id="hid_AreaCode" type="hidden" runat="server" value="" />
<input id="HiddenShopName" type="hidden" runat="server" value="" />
<input id="HiddenShopCategory" type="hidden" runat="server" value="0" />
<input id="HiddenShopCategoryValue" type="hidden" runat="server" value="0" />
<input id="HiddenIdentityCard" type="hidden" runat="server" value="" />
<input id="HiddenIdentityCardValue" type="hidden" runat="server" value="" />
<input id="HiddenBusinessImageValue" type="hidden" runat="server" value="" />
<input id="HiddenIdEdit" type="hidden" runat="server" value="0" />
<input id="HiddenShopNameValue" type="hidden" runat="server" value="" />
<input id="HiddenIdentityValue" type="hidden" runat="server" value="" />

<input id="HiddenTaxRegistration" type="hidden" runat="server" value="" />
<input id="HiddenOrganization" type="hidden" runat="server" value="" />
