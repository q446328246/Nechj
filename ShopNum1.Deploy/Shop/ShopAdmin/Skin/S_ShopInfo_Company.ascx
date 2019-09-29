<%@ Control Language="C#"%>
<%@ Import Namespace="ShopNum1.ShopAdminWebControl" %>
<script>
    //企业名称
    function funCompanName() {
        var CompanName = $("#<%= TextBoxCompanName.ClientID %>").val();
        if (CompanName == "") {
            $("#errCompanName").html("企业名称不允许为空！");
            return false;
        }
        $("#errCompanName").html("*");
        return true;
    }

    //法人代表

    function funLegalPerson() {
        var TextBoxLegalPerson = $("#<%= TextBoxLegalPerson.ClientID %>").val();
        if (TextBoxLegalPerson == "") {
            $("#errLegalPerson").html("法人代表不允许为空！");
            return false;
        }
        $("#errLegalPerson").html("*");
        return true;
    }

    //注册号

    function funRegistrationNum() {
        var RegistrationNum = $("#<%= TextBoxRegistrationNum.ClientID %>").val();
        if (RegistrationNum == "") {
            $("#errRegistrationNum").html("注册号不允许为空！");
            return false;
        }
        $("#errRegistrationNum").html("*");
        return true;
    }

    //营业期限

    function funBusinessTerm() {
        var BusinessTerm = $("#<%= TextBoxBusinessTerm.ClientID %>").val();
        if (BusinessTerm == "") {
            $("#errBusinessTerm").html("营业期限不允许为空！");
            return false;
        } else {
            if (isNaN(BusinessTerm)) {
                $("#errBusinessTerm").html("营业期限必须为整数！");
                return false;
            }
            $("#errBusinessTerm").html("*");
            return true;
        }
    }

    //营业范围

    function funBusinessScope() {
        var BusinessScope = $("#<%= TextBoxBusinessScope.ClientID %>").val();
        if (BusinessScope == "") {
            $("#errBusinessScope").html("营业范围不允许为空！");
            return false;
        }
        $("#errBusinessScope").html("*");
        return true;
    }

    //上传营业执照

    function funBusinessLicense() {
        var BusinessLicense = $("#<%= TextBoxBusinessLicense.ClientID %>").val();
        if (BusinessLicense == "") {
            $("#errBusinessLicense").html("营业执照不允许为空！");
            return false;
        }
        $("#errBusinessLicense").html("*");
        return true;
    }

    //检查

    function funCheckButton() {
        if (funCompanName() && funLegalPerson() && funRegistrationNum() && funBusinessTerm() && funBusinessScope() && funBusinessLicense()) {
            return true;
        }
        return false;
    }

    function openSingleChild() {

        var k = window.showModalDialog("Image_List_Select.aspx", window, "dialogWidth:820px;dialogHeight:650px");
        if (k != null) {
            var imgvalue = new Array();
            imgvalue = k.split(",");
            $("#ImageBusinessLicense").src = imgvalue[1];
            $("#<%= TextBoxBusinessLicense.ClientID %>").val(imgvalue[0]);
        }
    }

</script>
<table width="100%" border="0" cellspacing="0" cellpadding="0" class="tabbiao">
    <tr>
        <td class="tab_r" width="160">
            企业名称：
        </td>
        <td>
            <asp:TextBox ID="TextBoxCompanName" runat="server" CssClass="textwb" onblur="funCompanName()"></asp:TextBox>
            <span class="red" id="errCompanName">*</span>
        </td>
    </tr>
    <tr>
        <td class="tab_r">
            法人代表：
        </td>
        <td>
            <asp:TextBox ID="TextBoxLegalPerson" runat="server" CssClass="textwb" onblur="funLegalPerson()"></asp:TextBox>
            <span class="red" id="errLegalPerson">*</span>
        </td>
    </tr>
    <tr>
        <td class="tab_r">
            注册号：
        </td>
        <td>
            <asp:TextBox ID="TextBoxRegistrationNum" runat="server" CssClass="textwb" onblur="funRegistrationNum()"></asp:TextBox>
            <span class="red" id="errRegistrationNum">*</span>
        </td>
    </tr>
    <tr>
        <td class="tab_r">
            营业期限：
        </td>
        <td>
            <asp:TextBox ID="TextBoxBusinessTerm" runat="server" CssClass="textwb" onblur="funBusinessTerm()"></asp:TextBox>
            <span class="red" id="errBusinessTerm">*</span>(年)
        </td>
    </tr>
    <tr>
        <td class="tab_r">
            营业范围：
        </td>
        <td>
            <asp:TextBox ID="TextBoxBusinessScope" runat="server" CssClass="textwb" TextMode="MultiLine"
                Width="450" Height="90" onblur="funBusinessScope()"></asp:TextBox>
            <span class="red" id="errBusinessScope">*</span>
        </td>
    </tr>
    <tr>
        <td class="tab_r">
            上传营业执照：
        </td>
        <td>
            <div>
                <img src="" width="200" height="200" id="ImageBusinessLicense" onerror=" javascript:this.src = '/ImgUpload/noImage.gif'; " />
            </div>
            <div>
                <asp:TextBox ID="TextBoxBusinessLicense" runat="server" CssClass="textwb" onblur="funBusinessLicense()"></asp:TextBox>
                <span class="red" id="errBusinessLicense">*</span>
                <input name="" type="button" class="selpic" value="选择图片" onclick=" openSingleChild() " />
                <span class="red"></span>
            </div>
        </td>
    </tr>
    <tr>
        <td class="tab_r">
            &nbsp;
        </td>
        <td style="padding: 10px 0px 10px 0px;">
            <asp:Button ID="ButtonSave" runat="server" Text="申请" CssClass="baocbtn" OnClientClick=" return funCheckButton() " />
        </td>
    </tr>
</table>
