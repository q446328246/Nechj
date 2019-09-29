<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="ShopNum1_ScoreProductCategory_Operate.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.ShopNum1_ScoreProductCategory_Operate" %>

<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="ShopNum1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>������Ʒ����</title>
    <link rel="stylesheet" type="text/css" href="style/css.css" />
    <script type="text/javascript">
        var spclock = 0;
        //ѡ��ͼ

        function SelectSalePro() {
            if (spclock == 0) {
                spclock = 1;
                var salePro = $("#openSalePro").attr("value");
                if (salePro == "������") {
                    if (!confirm("���Ƿ�Ҫ���ù������ܻ�Ӱ����Ʒ���Ƿ������")) {
                        return;
                    }
                }
                var k = window.showModalDialog("Specification_Show.aspx", window, "dialogWidth:820px;status:no;dialogHeight:650px");
                spclock = 0;
                var names = "";
                var values = "";
                if (k != null && k !== "") {
                    var ks = k.split(';');
                    for (var i = 0; i < ks.length; i++) {
                        if (i != ks.length - 1) {
                            names += ks[i].split(',')[1] + ',';
                            values += ks[i].split(',')[0] + ',';
                        } else {
                            names += ks[i].split(',')[1];
                            values += ks[i].split(',')[0];
                        }
                    }
                }
                if (names == "" || values == "") {
                    return;
                }
                $("#LabelSalePro").html(names);
                $("#hiddenFieldSpecification").attr("value", values);
                $("#trSale").show();
                $("#openSalePro").attr("value", "������");

            }
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
                    <asp:Label ID="LabelTitle" runat="server" Text="���������Ʒ����"></asp:Label></h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <table border="0" cellpadding="0" cellspacing="0" class="shoptable">
                <tr>
                    <th align="right">
                        <div class="shopth">
                            <asp:Localize ID="Localize1" runat="server" Text="�������ƣ�"></asp:Localize>
                        </div>
                    </th>
                    <td valign="middle">
                        <div class="shoptd">
                            <asp:TextBox ID="TextBoxName" runat="server" CssClass="tinput"></asp:TextBox>
                            <asp:Label ID="Label1" runat="server" Text="*" ForeColor="red"></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorName" runat="server" ControlToValidate="TextBoxName"
                                Display="Dynamic" ErrorMessage="��ֵ����Ϊ��"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorName" runat="server"
                                ControlToValidate="TextBoxName" Display="Dynamic" ErrorMessage="���50���ַ�" ValidationExpression="^[\s\S]{0,50}$"></asp:RegularExpressionValidator>
                        </div>
                    </td>
                </tr>
                <tr>
                    <th align="right">
                        <div class="shopth">
                            <asp:Localize ID="LocalizeFatherCateGory" runat="server" Text="�ϼ����ࣺ"></asp:Localize>
                        </div>
                    </th>
                    <td>
                        <div class="shoptd">
                            <asp:DropDownList ID="DropDownListFatherCateGory" Width="180px" runat="server" CssClass="tselect">
                            </asp:DropDownList>
                            <asp:CompareValidator ID="CompareFatherCateGory" runat="server" ControlToValidate="DropDownListFatherCateGory"
                                Display="Dynamic" ErrorMessage="��ֵ����ѡ��" Operator="NotEqual" ValueToCompare="-1"></asp:CompareValidator>
                            <span>�ϼ����ࡣ</span>
                        </div>
                    </td>
                </tr>
                <tr>
                    <th align="right">
                        <div class="shopth">
                            <asp:Localize ID="Localize2" runat="server" Text="����ؼ��֣�"></asp:Localize>
                        </div>
                    </th>
                    <td>
                        <div class="shoptd">
                            <asp:TextBox ID="TextBoxKeywords" runat="server" CssClass="tinput"></asp:TextBox><span>����ؼ���</span>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorKeywords" runat="server"
                                ControlToValidate="TextBoxKeywords" Display="Dynamic" ErrorMessage="���200���ַ�"
                                ValidationExpression="^[\s\S]{0,200}$"></asp:RegularExpressionValidator>
                        </div>
                    </td>
                </tr>
                <tr>
                    <th align="right">
                        <div class="shopth">
                            <asp:Localize ID="Localize4" runat="server" Text="��������"></asp:Localize>
                        </div>
                    </th>
                    <td>
                        <div class="shoptd">
                            <asp:TextBox ID="TextBoxOrderID" MaxLength="9" runat="server" CssClass="tinput"></asp:TextBox><span>(�Զ�����)</span>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorTextBoxOrderID" runat="server"
                                ControlToValidate="TextBoxOrderID" Display="Dynamic" ErrorMessage="��ֵ����Ϊ��"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorRepertoryOrderID" runat="server"
                                ControlToValidate="TextBoxOrderID" ErrorMessage="ֻ����������" ValidationExpression="^[0-9]*$"
                                Display="Dynamic"></asp:RegularExpressionValidator>
                        </div>
                    </td>
                </tr>
                <tr>
                    <th align="right">
                        <div class="shopth">
                            <asp:Localize ID="Localize5" runat="server" Text="�Ƿ�ǰ̨��ʾ��"></asp:Localize>
                            </td>
                        </div>
                    </th>
                    <td>
                        <div class="shoptd">
                            <asp:CheckBox ID="CheckBoxIsShow" runat="server" Checked="True" Text="��" />
                        </div>
                    </td>
                </tr>
                <tr>
                    <th align="right">
                        <div class="shopth" style="border-bottom: none; height: 115px;">
                            <asp:Localize ID="Localize3" runat="server" Text="����������"></asp:Localize>
                        </div>
                    </th>
                    <td>
                        <div class="shoptd" style="border-bottom: none; height: 115px;">
                            <asp:TextBox ID="TextBoxDescription" runat="server" TextMode="MultiLine" CssClass="tinput txtarea"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorDescription" runat="server"
                                ControlToValidate="TextBoxDescription" Display="Dynamic" ErrorMessage="���200���ַ�"
                                ValidationExpression="^[\s\S]{0,200}$"></asp:RegularExpressionValidator>
                        </div>
                    </td>
                </tr>
                <tr runat="server" id="trSale" style="display: none">
                    <td style="text-align: right;">
                        <asp:Localize ID="Localize7" runat="server" Text="�������ԣ�"></asp:Localize>
                    </td>
                    <td>
                        <asp:Label ID="LabelSalePro" runat="server" Text="���룬��ɫ"></asp:Label>
                    </td>
                </tr>
            </table>
            <div class="tablebtn">
                <asp:Button ID="ButtonConfirm" runat="server" Text="ȷ��" CssClass="qued" OnClick="ButtonConfirm_Click"
                    ToolTip="Submit" />
                <input id="openSalePro" value="�������" type="button" class="fanh" onclick="SelectSalePro()"
                    runat="server" visible="false" />
                <input type="button" value="�����б�" class="fanh" onclick=" window.location.href = 'ShopNum1_ScoreProductCategory_List.aspx' " />
                <ShopNum1:MessageShow ID="MessageShow" Visible="false" runat="server" />
            </div>
        </div>
    </div>
    <asp:HiddenField ID="hiddenFieldGuid" runat="server" Value="0" />
    <asp:HiddenField ID="hiddenFieldSpecification" runat="server" Value="-1" />
    </form>
    <!--js-->
    <script type="text/javascript" src="/js/jquery-1.6.2.min.js"> </script>
</body>
</html>
