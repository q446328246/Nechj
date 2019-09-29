<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="Specification_Operate.aspx.cs" Inherits="ShopNum1.Deploy.Main.Admin.Specification_Operate" %>

<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
    <head id="Head1" runat="server">
        <title>商品规格添加</title>
        <link rel="stylesheet" type="text/css" href="style/css.css" />

        <script type="text/javascript" language="javascript" src="js/CommonJS.js"> </script>
        <style type="text/css">
            .error {
                background: #0080ff;
                border: 1px solid red;
                color: #fff;
                height: 22px;
                line-height: 22px;
                width: 130px;
            }
        </style>
        <script type="text/javascript">
        /// 检查规格值添加
            function checkRowsLimit() {
                var rowLimit = 30;
                var len = document.getElementById('filearea').rows.length;
                if (len == rowLimit) {
                    alert('已达数量上限');
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
                    spec_html.push('onafterpaste="NumTxt_Int(this)"  type=text maxlength=30 name="orderSpec_Order" class="input1" value="" /></td>');
                    spec_html.push('<td align="left"><input type=text  maxlength=30 name="specificationValue" class="input1" value="" /></td>');
                    spec_html.push('<td style="width:500px;height:35px;line-height:35px;display:none;" name="tdpicshow"><div ID="divt"><a href="javascript:void(0)" onclick="SelectImage(this)"><input type=text size=20 maxlength=20 name="picUrl"  class="input1" value="" /> <img name="imgurl"  width="30" height="30" />选择图片</a></div></td>');
                    spec_html.push('<td align="left"><a href="javascript:void(0)" onclick="removeRow(this,0)">删除</a><input type="hidden" name="hidDG" value="0"/></td></tr>');
                    $("#filearea").append(spec_html.join(""));
                } else {

                    var spec_html = new Array();
                    spec_html.push('<tr><td align="left"><input onkeyup="NumTxt_Int(this)" maxlength="3" ');
                    spec_html.push('onafterpaste="NumTxt_Int(this)"  type=text maxlength=30 name="orderSpec_Order" class="input1" value="" /></td>');
                    spec_html.push('<td align="left"><input type=text  maxlength=30 name="specificationValue" class="input1" value="" /></td>');
                    spec_html.push('<td style="width:500px;height:35px;line-height:35px;" name="tdpicshow"><div><a href="javascript:void(0)" onclick="SelectImage(this)"><input type=text size=20 maxlength=20 name="picUrl"  class="input1" value=""   /> <img name="imgurl"  width="30" height="30" />选择图片</a></div></td>');
                    spec_html.push('<td align="left"><a href="javascript:void(0)" onclick="removeRow(this,0)">删除</a><input type="hidden" name="hidDG" value="0"/></td></tr>');
                    $("#filearea").append(spec_html.join(""));
                }
            }

            function ChangeInput() {
                var radioButton = document.getElementById("RadioButtonListShowType_0");
                var tb = document.getElementById('filearea');
                var divt = tb.getElementsByTagName("tdpicshow");
                if (radioButton.checked) {
                    $("td[name='tdpicshow']").hide();
                } else {
                    $("td[name='tdpicshow']").show();
                }
            }

            function GetInputValues() {
                var arrystr = new Array();
                if (document.getElementById("TextBoxSpecificationName").value == "") {
                    alert("规格名称不能为空！");
                    document.getElementById("TextBoxSpecificationName").focus();
                    return false;
                }
                var blorder = false, blname = false;
                var tb = document.getElementById('filearea');
                var inputs = tb.getElementsByTagName("input");
                var radioButton = document.getElementById("RadioButtonListShowType_0");
                for (var i = 0; i < inputs.length; i++) {
                    inputs[i].className = 'input1';
                    if (inputs[i].type == "text" && inputs[i].parentNode.style.display != "none" && inputs[i].value == "") {
                        if (inputs[i].name == "orderSpec_Order") {
                            alert("排序编号不能为空！");
                            inputs[i].focus();
                            inputs[i].className = 'error';
                            return false;
                        }
                        if (inputs[i].name == "specificationValue") {
                            alert("规格值不能为空！");
                            inputs[i].focus();
                            inputs[i].className = 'error';
                            return false;
                        }
                        if (inputs[i].name == "picUrl" && !radioButton.checked) {
                            alert("规格图片不能为空！");
                            inputs[i].focus();
                            inputs[i].className = 'error';
                            return false;
                        }
                    }
                }
                for (var i = 0; i < inputs.length; i++) {
                    if (inputs[i].type == "text" && inputs[i].parentNode.style.display != "none" && inputs[i].value != "") {
                        if (inputs[i].name == "orderSpec_Order") {
                            arrystr.push(inputs[i].value + ",");
                        }
                        if (inputs[i].name == "specificationValue" && radioButton.checked) {
                            arrystr.push(inputs[i].value + ",");
                        } else if (inputs[i].name != "picUrl" && inputs[i].name != "orderSpec_Order") {
                            arrystr.push(inputs[i].value + ",");
                        }
                        if (inputs[i].name == "picUrl" && !radioButton.checked) {
                            arrystr.push(inputs[i].value + ",");
                        }
                    }
                    if (inputs[i].name == "hidDG" && inputs[i].type == "hidden") {
                        arrystr.push(inputs[i].value + "|");
                    }
                }
                document.getElementById("HiddenFieldValues").value = arrystr.join("");
                return true;
            }

            function removeRow(fontobj, id) {
                if (confirm("确定删除该项吗2?")) {
                    var obj = document.getElementById('filearea');
                    var n = fontobj.parentNode.parentNode.rowIndex;
                    obj.deleteRow(n);
                    $.get("?id=" + id + "&sign=del", null, function(data) {
                    });
                }
            }

            var imglock = 0;

            function SelectImage(linkobject) {
                var imgName = window.showModalDialog("Image_List_Select.aspx", window, "dialogWidth:820px;location:yes;directories:yes;alwaysRaised:yes;status:no;menubar:yes;dialogHeight:650px");
                if (imgName == undefined) {
                    imgName = window.returnValue;
                }
                if (imgName != null && imgName != "") {
                    var inputs = linkobject.childNodes;
                    var imgUrl = imgName.split(",", 1)[0];
                    $(linkobject).find("input").val(imgUrl);
                    $(linkobject).find("img").attr("src", imgUrl.replace("~/", "/"));
                }
            }

            $(function() {
                ChangeInput();
            });
        </script>
    </head>
    <body>
        <form id="form1" runat="server">
            <div id="right">
                <div class="rhigth">
                    <div class="rl">
                    </div>
                    <div class="rcon">
                        <h3><asp:Label ID="lblSpec" runat="server" Text="添加商品规格"></asp:Label></h3>
                    </div>
                    <div class="rr">
                    </div>
                </div>
                <div class="welcon clearfix">
                    <div class="inner_page_list">
                        <table border="0" cellpadding="0" cellspacing="1">
                            <tr>
                                <th align="right" width="150px">
                        
                                    <asp:Label ID="LabelName" runat="server" Text="规格名称："></asp:Label>
                                </th>
                                <td valign="middle" colspan="2">
                                    <asp:TextBox ID="TextBoxSpecificationName" runat="server" CssClass="tinput"></asp:TextBox>
                                    <asp:Label ID="Label4" runat="server" ForeColor="#FF0066" Text="*"></asp:Label>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic"
                                                                ErrorMessage="不能为空" ControlToValidate="TextBoxSpecificationName"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidatorTitle" runat="server"
                                                                    ControlToValidate="TextBoxSpecificationName" Display="Dynamic" ErrorMessage="最多50个字符"
                                                                    ValidationExpression="^[\s\S]{0,50}$"></asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr>
                                <th align="right">
                                    <asp:Label ID="LabelOrderID" runat="server" Text="规格排序号："></asp:Label>
                                </th>
                                <td align="left" colspan="2">
                                    <asp:TextBox ID="TextBoxOrderID" runat="server" MaxLength="9" CssClass="tinput"></asp:TextBox>
                                    <asp:Label ID="Label1" runat="server" ForeColor="#FF0066" Text="*"></asp:Label>&nbsp;
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorSort" runat="server" ErrorMessage="不能为空"
                                                                ControlToValidate="TextBoxOrderID" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:RangeValidator ID="RangeValidatorSort" runat="server" ErrorMessage="格式不正确" Display="Dynamic"
                                                        MaximumValue="1000000" MinimumValue="1" Type="Integer" ControlToValidate="TextBoxOrderID"></asp:RangeValidator>
                                </td>
                            </tr>
                            <tr class="radiobtn">
                                <th align="right">
                                    <asp:Label ID="LabelShowType" runat="server" Text="显示类型："></asp:Label>
                       
                                </th>
                                <td align="left">
                                    <asp:RadioButtonList ID="RadioButtonListShowType" runat="server" RepeatDirection="Horizontal" Width="100%" RepeatLayout="Flow">
                                        <asp:ListItem Text="文字" Value="0" onclick="ChangeInput()" Selected="True"></asp:ListItem>
                                        <asp:ListItem Text="图片" Value="1" onclick="ChangeInput()"></asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                                <td></td>
                            </tr>
                            <tr>
                                <th align="right"  style="height: 115px;">
                                    <asp:Label ID="LabelMemo" runat="server" Text="规格备注："></asp:Label>
                                </th>
                                <td style="height: 115px;" colspan="2">
                                    <asp:TextBox ID="TextBoxMemo" TextMode="MultiLine" runat="server" CssClass="tinput txtarea"></asp:TextBox>
                                </td>
                            </tr>
                            <tr><th></th>
                                <td colspan="2">
                                    <input id="ButtonValueAdd" type="button" value="添加规格值" class="selpic" onclick=" if (checkRowsLimit()) {addNewRow();} "  style="margin-left: 10px;"/>
                                </td>
                            </tr>
                            <tr>
                                <th></th>
                                <td colspan="2">
                                    <table cellpadding="0" cellspacing="0" border="0" id="filearea" class="spetable">
                                        <tr><td>排序</td><td>名称</td><td></td><td>操作</td></tr>
                                        <% if (dt_Spec != null && dt_Spec.Rows.Count > 0)
                                           {
                                               for (int i = 0; i < dt_Spec.Rows.Count; i++)
                                               { %>
                                                <tr>
                                                    <td align="left"><input onkeyup=" NumTxt_Int(this) " maxlength="3" onafterpaste="NumTxt_Int(this)"  type=text maxlength=20 name="orderSpec_Order" class="input1" value='<%= dt_Spec.Rows[i]["oid"] %>'/></td>
                                                    <td align="left"><input type=text  maxlength=30 name="specificationValue" class="input1" value='<%= dt_Spec.Rows[i]["Name"] %>' /></td>
			                
                                                    <td style="width: 500px;" name="tdpicshow"><div style="height: 30px; line-height: 30px;"><a href="javascript:void(0)" onclick=" SelectImage(this) ">
                                                                                                                                                 <input type=text  maxlength=100 name="picUrl"  class="input1" value='<%= dt_Spec.Rows[i]["imagepath"] %>'   /> 
                                                                                                                                                 <img name="imgurl" src='<%= dt_Spec.Rows[i]["imagepath"].ToString().Replace("~/", "/") %>' width="30" height="30" />
                                                                                                                                                 选择图片</a>
                                                                                               </div></td>
                                                    <td align="left"><a href="javascript:void(0)" onclick=" removeRow(this, '<%= dt_Spec.Rows[i]["DGuid"] %>') ">删除</a><input type="hidden"  name="hidDG" value='<%= dt_Spec.Rows[i]["DGuid"] %>'/></td>
                                                </tr>
                                        <% }
                                           } %>
                               
                        
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="tablebtn">
                        <asp:Button ID="ButtonAdd" runat="server" CssClass="fanh" Text="确认添加" OnClientClick=" return GetInputValues(); "  OnClick="ButtonAdd_Click" />
                        <input type="button" value="返回列表" onclick=" window.location = 'Specification_List.aspx' "
                               class="fanh" />
                        <uc1:MessageShow ID="MessageShow" runat="server" Visible="False" />
                    </div>
                </div>
            </div>
            <asp:HiddenField ID="HiddenFieldValues" runat="server" Value="-1" />
        </form>
    </body>
</html>