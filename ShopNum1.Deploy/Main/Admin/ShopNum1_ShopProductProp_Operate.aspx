<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="ShopNum1_ShopProductProp_Operate.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.ShopNum1_ShopProductProp_Operate" %>

<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>��Ʒ�������</title>
    <link rel="stylesheet" type="text/css" href="style/css.css" />
    <script type="text/javascript" language="javascript" src="js/CommonJS.js"> </script>
    <style type="text/css">
        .error
        {
            background: #0080ff;
            border: 1px solid red;
            color: #fff;
            height: 22px;
            line-height: 22px;
            width: 130px;
        }
    </style>
    <script type="text/javascript">
        /// �����ֵ���
        function checkRowsLimit() {
            var rowLimit = 30;
            var len = document.getElementById('filearea').rows.length;
            if (len == rowLimit) {
                alert('�Ѵ���������');
                return false;
            } else {
                return true;
            }
        }

        function NumTxt_Int(o) {
            o.value = o.value.replace(/\D/g, '');
        }

        function addNewRow() {
            var radioButton = document.getElementById("RadioButtonListShowType_0");
            if (radioButton.checked) {
                var spec_html = new Array();
                spec_html.push('<tr><td align="left"><input onkeyup="NumTxt_Int(this)" maxlength="3" ');
                spec_html.push('onafterpaste="NumTxt_Int(this)"  type=text maxlength=30 name="orderProp_Order" class="input1" value="" /></td>');
                spec_html.push('<td align="left"><input type=text  maxlength=20 name="propValue" class="input1" value="" /></td>');
                spec_html.push('<td align="left"><a href="javascript:void(0)" onclick="removeRow(this,0)">ɾ��</a><input type="hidden" name="hidDG" value="0"/></td></tr>');
                $("#filearea").append(spec_html.join(""));
            } else {
                var spec_html = new Array();
                spec_html.push('<tr><td align="left"><input onkeyup="NumTxt_Int(this)" maxlength="3" ');
                spec_html.push('onafterpaste="NumTxt_Int(this)"  type=text maxlength=30 name="orderProp_Order" class="input1" value="" /></td>');
                spec_html.push('<td align="left"><input type=text  maxlength=20 name="propValue" class="input1" value="" /></td>');
                spec_html.push('<td align="left"><a href="javascript:void(0)" onclick="removeRow(this,0)">ɾ��</a><input type="hidden" name="hidDG" value="0"/></td></tr>');
                $("#filearea").append(spec_html.join(""));
            }
        }

        function ChangeInput() {
            var radioButton = document.getElementById("RadioButtonListShowType_4");
            var tb = document.getElementById('filearea');
            if (radioButton.checked) {
                tb.style.display = "none";
                document.getElementById("ButtonValueAdd").style.display = "none";
            } else {
                tb.style.display = "block";
                document.getElementById("ButtonValueAdd").style.display = "block";
            }
        }

        function GetInputValues() {
            var radioButton = document.getElementById("RadioButtonListShowType_4");
            if (document.getElementById("TextBoxProductPropName").value == "") {
                alert("�������Ʋ���Ϊ�գ�");
                return false;
            }
            var arrystr = new Array();
            var inputs = document.getElementById("filearea").getElementsByTagName("input");
            for (var i = 0; i < inputs.length; i++) {
                inputs[i].className = 'input1';
                if (inputs[i].type == "text" && inputs[i].parentNode.style.display != "none" && inputs[i].value == "" && !radioButton.checked) {
                    if (inputs[i].name == "orderProp_Order") {
                        alert("�����Ų���Ϊ�գ�");
                        inputs[i].focus();
                        inputs[i].className = 'error';
                        return false;
                    }
                    if (inputs[i].name == "propValue") {
                        alert("����ֵ����Ϊ�գ�");
                        inputs[i].focus();
                        inputs[i].className = 'error';
                        return false;
                    }
                    arrystr.push(inputs[i].value);
                }
            }
            for (var i = 0; i < inputs.length; i++) {
                if (inputs[i].type == "text" && inputs[i].parentNode.style.display != "none" && inputs[i].value != "") {
                    arrystr.push(inputs[i].value + ",");
                }
                if (inputs[i].name == "hidDG" && inputs[i].value != "") {
                    arrystr.push(inputs[i].value + "|");
                }
            }
            document.getElementById("HiddenFieldValues").value = arrystr.join("");
            var radioButton = document.getElementById("RadioButtonListShowType_4");
            if (radioButton.checked) {
                document.getElementById("HiddenFieldValues").value = "0";
            }
            return true;
        }

        function removeRow(fontobj) {
            if (confirm("ȷ��ɾ��������?")) {
                var obj = document.getElementById('filearea');
                var n = fontobj.parentNode.parentNode.rowIndex;
                obj.deleteRow(n);
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div id="right">
        <div class="rhigth">
            <div class="rl">
            </div>
            <div class="rcon">
                <h3>
                    <asp:Label ID="LabelTitle" runat="server" Text="�����Ʒ����"></asp:Label></h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="inner_page_list">
                <table border="0" cellpadding="0" cellspacing="1">
                    <tr>
                        <th align="right" style="width: 200px;">
                            <asp:Label ID="LabelName" runat="server" Text="�������ƣ�"></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxProductPropName" runat="server" CssClass="tinput" Width="160px"></asp:TextBox>
                            <span style="color: Red">*</span>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic"
                                ErrorMessage="����Ϊ��" ControlToValidate="TextBoxProductPropName"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorTitle" runat="server"
                                ControlToValidate="TextBoxProductPropName" Display="Dynamic" ErrorMessage="���50���ַ�"
                                ValidationExpression="^[\s\S]{0,50}$"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <th align="right" style="height: 100px;">
                            <asp:Label ID="LabelMemo" runat="server" Text="���Ա�ע��"></asp:Label>
                        </th>
                        <td style="height: 100px;">
                            <asp:TextBox ID="TextBoxContent" TextMode="MultiLine" runat="server" CssClass="tinput"
                                Height="80"></asp:TextBox>
                        </td>
                    </tr>
                    <tr class="radiobtn">
                        <th align="right">
                            <asp:Label ID="LabelShowType" runat="server" Text="��ʾ���ͣ�"></asp:Label>
                        </th>
                        <td>
                            <asp:RadioButtonList ID="RadioButtonListShowType" runat="server" RepeatLayout="Flow"
                                RepeatDirection="Horizontal">
                                <asp:ListItem Text="��������" Value="0" onclick="ChangeInput()" Selected="True"></asp:ListItem>
                                <asp:ListItem Text="�б�ѡ" Value="1" onclick="ChangeInput()"></asp:ListItem>
                                <asp:ListItem Text="������ѡ" Value="2" onclick="ChangeInput()"></asp:ListItem>
                                <asp:ListItem Text="��ѡ" Value="3" onclick="ChangeInput()"></asp:ListItem>
                                <asp:ListItem Text="�Զ�������" Value="4" onclick="ChangeInput()"></asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelOrderID" runat="server" Text=" ��������ţ�"></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxOrderID" runat="server" MaxLength="9" CssClass="tinput" Width="156px"></asp:TextBox>
                            <asp:Label ID="Label1" runat="server" ForeColor="#FF0066" Text="*"></asp:Label>&nbsp;
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorSort" runat="server" ErrorMessage="����Ϊ��"
                                ControlToValidate="TextBoxOrderID" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:RangeValidator ID="RangeValidatorSort" runat="server" ErrorMessage="��ʽ����ȷ" Display="Dynamic"
                                MaximumValue="1000000" MinimumValue="1" Type="Integer" ControlToValidate="TextBoxOrderID"></asp:RangeValidator>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            &nbsp;
                        </th>
                        <td>
                            <input id="ButtonValueAdd" runat="server" type="button" value="�������ֵ" class="selpic"
                                onclick="if(checkRowsLimit()) {addNewRow();}" style="margin-left: 10px;" />
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            &nbsp;
                        </th>
                        <td colspan="2" id="trProp" runat="server">
                            <table cellpadding="0" cellspacing="0" border="0" id="filearea" class="spetable">
                                <tr>
                                    <td align="center" style="width: 150px;">
                                        ����
                                    </td>
                                    <td align="center" style="width: 200px;">
                                        ��������
                                    </td>
                                    <td align="center">
                                        ����
                                    </td>
                                </tr>
                                <% if (dt_Prop != null)
                                   {
                                       for (int i = 0; i < dt_Prop.Rows.Count; i++)
                                       { %>
                                <tr>
                                    <td align="left">
                                        <input onkeyup=" NumTxt_Int(this) " maxlength="3" onafterpaste="NumTxt_Int(this)"
                                            type="text" maxlength="30" name="orderProp_Order" class="input1" value='<%= dt_Prop.Rows[i]["orderid"] %>' />
                                    </td>
                                    <td align="left">
                                        <input type="text" maxlength="30" name="propValue" class="input1" value='<%= dt_Prop.Rows[i]["name"] %>' />
                                    </td>
                                    <td align="left">
                                        <a href="javascript:void(0)" onclick=" removeRow(this, 0) ">ɾ��</a><input type="hidden"
                                            name="hidDG" value='<%= dt_Prop.Rows[i]["id"] %>' />
                                    </td>
                                </tr>
                                <% }
                                           } %>
                            </table>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="tablebtn">
                <asp:Button ID="ButtonAdd" runat="server" ToolTip="submit" CssClass="fanh" Text="ȷ�����"
                    OnClick="ButtonAdd_Click" OnClientClick=" return GetInputValues(); " />&nbsp;
                <input type="button" value="�����б�" onclick=" window.location.href = 'ShopNum1_ShopProductProp_List.aspx' "
                    class="fanh" />
                <uc1:MessageShow ID="MessageShow" runat="server" Visible="False" />
                <asp:HiddenField ID="HiddenFieldCode" runat="server" Value="-1" />
                <asp:HiddenField ID="HiddenFieldID" runat="server" />
                <asp:HiddenField ID="HiddenFieldGuid" Value="-1" runat="server" />
                <asp:HiddenField ID="HiddenFieldValues" runat="server" Value="-1" />
            </div>
        </div>
    </div>
    </form>
</body>
</html>
