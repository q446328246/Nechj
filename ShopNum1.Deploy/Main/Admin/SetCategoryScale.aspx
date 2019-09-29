<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="SetCategoryScale.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.SetCategoryScale" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>���÷������</title>
    <link rel="stylesheet" type="text/css" href="style/css.css" />
    <script type="text/javascript" language="javascript" src="js/CommonJS.js"> </script>
    <script type="text/javascript" language="javascript">
        $(function () {
            $.get("?category=DD", null, function (data) {
                var data = data.toString().substring(0, data.toString().indexOf("<!"));
                if (data != "") {
                    var vdata = eval('(' + data + ')');
                    var xhtml = new Array("<option value='0'>-��ѡ��-</option>");
                    $.each(vdata, function (m, n) {
                        xhtml.push("<option value=\"" + n.code + "\">" + n.name + "</option>");
                    });
                    $("#selectPtype").html(xhtml.join(""));
                }
            });

            $("#selectPtype").change(function () {
                if ($(this).find("option:selected").val() != "0") {
                    $.get("?getdata=" + $(this).find("option:selected").val(), null, function (data) {
                        var data = data.toString().substring(0, data.toString().indexOf("<!"));
                        $("#txtSG").val(data.toString().split("|")[0]);
                        if (data.toString().split("|")[1] == 1) {
                            $("#cbIsOpen").attr("checked", true);
                        } else {
                            $("#cbIsOpen").removeAttr("checked");
                        }
                    });
                }
            });

            $("#btnConfirm").click(function () {
                $("span").removeAttr("style");
                var checkbool = false;
                if ($("#selectPtype").find("option:selected").val() == "0") {
                    $("#selectPtype").next().attr("style", "color:red");
                    checkbool = true;
                }
                if ($("#txtSG").val() == "") {
                    $("#txtSG").next().attr("style", "color:red");
                    checkbool = true;
                }
                if (!checkScale($("#txtSG").val())) {
                    $("#txtSG").next().attr("style", "color:red").html("��ɱ�����ʽ����ȷ��");
                    checkbool = true;
                }
                if (checkbool) {
                    return false;
                }
                var isopen = 0;
                if ($("#cbIsOpen").is(":checked")) {
                    isopen = 1;
                }
                $.get("?updateCode=" + $("#selectPtype").find("option:selected").val() + "&scale=" + $("#txtSG").val() + "&isopen=" + isopen + "", null, function (data) {
                    $("#msg").attr("style", "color:green").html("�޸ĳɹ���");
                });
            });
        });

        function checkScale(name) {
            var oo = /^\d{1,100}\w?$/;
            if (!oo.test(name)) {
                return false;
            } else {
                return true;
            }
        }

        function NumTxt_Int(o) {
            o.value = o.value.replace(/\D/g, '');
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="right">
        <div class="rhigth">
            <div class="rl">
            </div>
            <div class="rcon">
                <h3>
                    <asp:Label ID="LabelTitle" runat="server" Text="���÷������"></asp:Label></h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="inner_page_list">
                <table border="0" cellpadding="0" cellspacing="1">
                    <tr>
                        <th align="right">
                            ��Ʒ���ࣺ
                        </th>
                        <td>
                            <select id="selectPtype" class="tinput" style="width: 180px;">
                            </select><span>�������ѡ����ܹ�����</span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            ������
                        </th>
                        <td>
                            <input type="text" id="txtSG" maxlength="3" class="tinput" onkeyup=" NumTxt_Int(this) " />
                            %(<span>��ɱ���Ϊ1-100֮������</span>)
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            �Ƿ�����ɱ�����
                        </th>
                        <td>
                            <input type="checkbox" id="cbIsOpen" />��
                        </td>
                    </tr>
                </table>
            </div>
            <div class="tablebtn">
                <input type="button" id="btnConfirm" class="fanh" value="ȷ��" />
                <span id="msg" style="color: Green;"></span>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
