<%@ Control Language="C#" AutoEventWireup="True" CodeBehind="A_UpPayPwd.ascx.cs"
    Inherits="ShopNum1.Deploy.Main.Account.Skin.A_UpPayPwd" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="ShopNum1.Common" %>
<div class="zhszmian1" style="padding-left: 15px;">
    <ul class="mimbz">
        <%--<li class="bztwo">1.������֤��</li>--%>
        <li class="bzone">2.�����µĽ������� </li>
        <li class="bzthree">3.�����������óɹ� </li>
    </ul>
</div>
<div style="clear: both;">
</div>
<div class="masznr">
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <th scope="row" width="25%">
                ����ǰ���ʺţ�
            </th>
            <td>
                <asp:Label ID="Lab_MemLoginID" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr id="tr_pwd1">
            <th scope="row">
                <span class="red">*</span>���ý������룺
            </th>
            <td style="width: 150px;">
                <input type="password" class="textwb" id="Input_NewPayPwd" runat="server" maxlength="15"
                    onblur="existepwd()" />
            </td>
            <td>
                <span id="spanPwd"></span>
            </td>
        </tr>
        <tr>
            <th scope="row">
                <span class="red">*</span>ȷ�Ͻ������룺
            </th>
            <td style="width: 150px;">
                <input type="password" class="textwb" id="Input_NewSecondPayPwd" runat="server" maxlength="15"
                    onblur="existesurepwd()" />
            </td>
            <td>
                <span id="spanSurePwd"></span>
            </td>
        </tr>
        <tr>
            <th scope="row">
                &nbsp;
            </th>
            <td>
                <asp:LinkButton ID="LinkButton_Save" runat="server" CssClass="J_ftrack btn btn-green"
                    OnClientClick="return CheckSumbit()" onclick="LinkButton_Save_Click">ȷ��</asp:LinkButton>
            </td>
        </tr>
    </table>
    <asp:HiddenField ID="hid_CheckType" runat="server" />
</div>
<script type="text/javascript" language="javascript">
    function reloadcode() {
        var verify = document.getElementById('ImgCode');
        verify.setAttribute('src', '/Main/Admin/AdminImgCode.aspx?' + Math.random());
    }
</script>
<script type="text/javascript" language="javascript">
    $(function () {
        $("#<%= Input_NewPayPwd.ClientID %>").focus(function () {
            $("#spanPwd").get(0).className = "onTips1";
            $("#spanPwd").text("������6~15λ��������");
        });
        $("#<%= Input_NewSecondPayPwd.ClientID %>").focus(function () {
            $("#spanSurePwd").get(0).className = "onTips1";
            $("#spanSurePwd").text("������6~15λ��������");
        });
    });

    //��֤����
    function existepwd() {
        var boolresult = true;
        var inputcontrol = $("#<%= Input_NewPayPwd.ClientID %>").val();
        var context = document.getElementById("spanPwd");
        if (inputcontrol != "") {
            var reg = new RegExp("^[a-zA-Z0-9]{6,15}$");
            if (reg.test(inputcontrol)) {
                context.innerHTML = "";
                context.className = "onCorrect1";
                boolresult = true;
            }
            else {
                context.innerHTML = "�����ʽ����ȷ";
                context.className = "onError1";
                boolresult = false;
            }
        }
        else {
            context.innerHTML = "���벻��Ϊ��";
            context.className = "onError1";
            boolresult = false;
        }
        return boolresult;
    }

    //��֤ȷ������
    function existesurepwd() {
        var boolresult = true;
        var inputcontrol = $("#<%= Input_NewSecondPayPwd.ClientID %>").val();
        var context = document.getElementById("spanSurePwd");
        var pwd = $("#<%= Input_NewPayPwd.ClientID %>").val();
        if (inputcontrol != "") {
            var reg = new RegExp("^[a-zA-Z0-9]{6,15}$");
            if (reg.test(inputcontrol)) {
                context.innerHTML = "";
                context.className = "onCorrect1";
                boolresult = true;
            }
            else {
                context.innerHTML = "ȷ�������ʽ����ȷ";
                context.className = "onError1";
                boolresult = false;
                return boolresult;
            }
        }
        else {
            context.innerHTML = "���벻��Ϊ��";
            context.className = "onError1";
            boolresult = false;
            return boolresult;
        }

        if (inputcontrol != pwd) {
            context.innerHTML = "�������벻һ��";
            context.className = "onError1";
            boolresult = false;
        }
        return boolresult;
    }

    function CheckSumbit() {
        if (existepwd() & existesurepwd()) {
            return true;
        }
        return false;
    }     
</script>
