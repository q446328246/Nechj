<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="TbSendGood.aspx.cs" Inherits="ShopNum1.Deploy.Shop.ShopAdmin.TbTop.TbSendGood" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
    <head id="Head1" runat="server">
        <title></title>
        <link rel="stylesheet" type="text/css" href="style/tbindex.css" />
    </head>
    <body>
        <form id="form1" runat="server">
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <div class="navigator">
                <asp:Label ID="LabelPageTitle" runat="server" Font-Bold="True" Text="【收货信息】"></asp:Label>
            </div>
            <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                <tr>
                    <td align="right" width="20%">
                        <asp:Label ID="LabelName" runat="server" Text="联系人："></asp:Label>
                    </td>
                    <td align="left" colspan="2">
                        <asp:TextBox ID="TextBoxeller_name" runat="server"></asp:TextBox>
                        <asp:Label ID="Label3" runat="server" ForeColor="#FF0066" Text="*"></asp:Label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorName" runat="server" ControlToValidate="TextBoxeller_name"
                                                    Display="Dynamic" ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidatorName" runat="server"
                                                        ControlToValidate="TextBoxeller_name" Display="Dynamic" ErrorMessage="标题最多50个字符"
                                                        ValidationExpression="^[\s\S]{0,50}$"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td align="right" width="20%">
                        地区：
                    </td>
                    <td colspan="2">
                        <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="ddlProvince" runat="server" Height="25px" AutoPostBack="true"
                                                  OnSelectedIndexChanged="ddlProvince_SelectedIndexChanged">
                                </asp:DropDownList>
                                <asp:DropDownList ID="ddlCity" runat="server" Height="25px">
                                </asp:DropDownList>
                                <span style="color: Red;">*</span>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="ddlProvince" EventName="SelectedIndexChanged" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </td>
                </tr>
                <tr>
                    <td align="right" width="20%">
                        <asp:Label ID="Labelseller_address" runat="server" Text="街道地址："></asp:Label>
                    </td>
                    <td align="left" colspan="2">
                        <asp:TextBox ID="TextBoxseller_address" runat="server" TextMode="MultiLine" Width="300"></asp:TextBox>
                        <asp:Label ID="Label2" runat="server" ForeColor="#FF0066" Text="*"></asp:Label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBoxseller_address"
                                                    Display="Dynamic" ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBoxseller_address"
                                                        Display="Dynamic" ErrorMessage="街道地址最多150个字符" ValidationExpression="^[\s\S]{0,50}$"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td align="right" width="20%">
                        <asp:Label ID="Labelseller_zip" runat="server" Text="邮政编码："></asp:Label>
                    </td>
                    <td align="left" colspan="2">
                        <asp:TextBox ID="TextBoxseller_zip" runat="server"></asp:TextBox>
                        <asp:Label ID="Label5" runat="server" ForeColor="#FF0066" Text="*"></asp:Label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBoxseller_zip"
                                                    Display="Dynamic" ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="TextBoxseller_zip"
                                                        Display="Dynamic" ErrorMessage="邮政编码最多50个字符" ValidationExpression="^[\s\S]{0,50}$"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td align="right" width="20%">
                        <asp:Label ID="Label6" runat="server" Text="电话号码："></asp:Label>
                    </td>
                    <td align="left" colspan="2">
                        <asp:TextBox ID="TextBoxseller_phone" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right" width="20%">
                        <asp:Label ID="Label7" runat="server" Text="手机号码："></asp:Label>
                    </td>
                    <td align="left" colspan="2">
                        <asp:TextBox ID="TextBoxseller_mobile" runat="server"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="TextBoxseller_mobile"
                                                        Display="Dynamic" ErrorMessage="手机号码最多50个字符" ValidationExpression="^[\s\S]{0,50}$"></asp:RegularExpressionValidator>
                    </td>
                </tr>
            </table>
            <div class="btconfig">
                <asp:Button ID="ButtonUpdate" runat="server" Text="更新" OnClick="ButtonUpdate_Click"
                            CssClass="bt2" />
            </div>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div class="navigator">
                        <asp:Label ID="Label10" runat="server" Font-Bold="True" Text="【选择物流服务】"></asp:Label>
                    </div>
                    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                        <tr id="nn" runat="server">
                            <td align="right" width="20%">
                                <asp:Label ID="Label11" runat="server" Text="物流公司："></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="DropDownListcompany_code" runat="server">
                                    <asp:ListItem>请选择一家物流公司</asp:ListItem>
                                    <asp:ListItem>EMS</asp:ListItem>
                                    <asp:ListItem>圆通快递</asp:ListItem>
                                    <asp:ListItem>中通速递</asp:ListItem>
                                    <asp:ListItem>宅急送</asp:ListItem>
                                    <asp:ListItem>韵达快运</asp:ListItem>
                                    <asp:ListItem>天天快递</asp:ListItem>
                                    <asp:ListItem>一邦速递</asp:ListItem>
                                    <asp:ListItem>德邦物流</asp:ListItem>
                                    <asp:ListItem>星晨急便</asp:ListItem>
                                    <asp:ListItem>中铁快运</asp:ListItem>
                                    <asp:ListItem>汇通快运</asp:ListItem>
                                    <asp:ListItem>联邦快递</asp:ListItem>
                                    <asp:ListItem>顺丰速运</asp:ListItem>
                                    <asp:ListItem>CCES</asp:ListItem>
                                    <asp:ListItem>申通E物流</asp:ListItem>
                                    <asp:ListItem>港中能达</asp:ListItem>
                                    <asp:ListItem>邮政平邮</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" width="20%">
                                <asp:Label ID="Label12" runat="server" Text="物流方式："></asp:Label>
                            </td>
                            <td>
                                <asp:RadioButtonList ID="RadioButtonorder_type" AutoPostBack="true" runat="server"
                                                     RepeatDirection="Horizontal" OnSelectedIndexChanged="RadioButtonorder_type_SelectedIndexChanged">
                                    <asp:ListItem Text="限时物流" Value="0"></asp:ListItem>
                                    <asp:ListItem Text="在线下单" Value="1" Selected="True"></asp:ListItem>
                                    <asp:ListItem Text="自己联系物流" Value="2"></asp:ListItem>
                                    <asp:ListItem Text="无需物流" Value="3"></asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                        <tr id="Tr1" visible="false" runat="server">
                            <td align="right" width="20%">
                                <asp:Label ID="Label18" runat="server" Text="限时方式："></asp:Label>
                            </td>
                            <td>
                                <asp:RadioButtonList ID="RadioButtonList1" RepeatDirection="Horizontal" runat="server">
                                    <asp:ListItem Value="0">次晨达</asp:ListItem>
                                    <asp:ListItem Value="1" Selected="True">次日达</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                        <tr id="date" runat="server">
                            <td align="right" width="20%">
                                <asp:Label ID="Label13" runat="server" Text="预约日期："></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox8" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr id="dateTime" runat="server">
                            <td align="right" width="20%">
                                <asp:Label ID="Label14" runat="server" Text="预约时段："></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="DropDownList2" runat="server">
                                    <asp:ListItem>8.00</asp:ListItem>
                                    <asp:ListItem>8.30</asp:ListItem>
                                    <asp:ListItem>9.00</asp:ListItem>
                                    <asp:ListItem>9.30</asp:ListItem>
                                    <asp:ListItem>10.00</asp:ListItem>
                                    <asp:ListItem>10.30</asp:ListItem>
                                    <asp:ListItem>11.00</asp:ListItem>
                                    <asp:ListItem>11.30</asp:ListItem>
                                    <asp:ListItem>12.00</asp:ListItem>
                                    <asp:ListItem>12.30</asp:ListItem>
                                    <asp:ListItem>13.00</asp:ListItem>
                                    <asp:ListItem>13.30</asp:ListItem>
                                    <asp:ListItem>14.00</asp:ListItem>
                                    <asp:ListItem>14.30</asp:ListItem>
                                    <asp:ListItem>15.00</asp:ListItem>
                                    <asp:ListItem>15.30</asp:ListItem>
                                    <asp:ListItem>16.00</asp:ListItem>
                                    <asp:ListItem>16.30</asp:ListItem>
                                    <asp:ListItem>17.00</asp:ListItem>
                                    <asp:ListItem>17.30</asp:ListItem>
                                    <asp:ListItem>18.00</asp:ListItem>
                                    <asp:ListItem>19.30</asp:ListItem>
                                    <asp:ListItem>20.00</asp:ListItem>
                                    <asp:ListItem>20.30</asp:ListItem>
                                </asp:DropDownList>
                                至
                                <asp:DropDownList ID="DropDownList3" runat="server">
                                    <asp:ListItem>8.00</asp:ListItem>
                                    <asp:ListItem>8.30</asp:ListItem>
                                    <asp:ListItem>9.00</asp:ListItem>
                                    <asp:ListItem>9.30</asp:ListItem>
                                    <asp:ListItem>10.00</asp:ListItem>
                                    <asp:ListItem>10.30</asp:ListItem>
                                    <asp:ListItem>11.00</asp:ListItem>
                                    <asp:ListItem>11.30</asp:ListItem>
                                    <asp:ListItem>12.00</asp:ListItem>
                                    <asp:ListItem>12.30</asp:ListItem>
                                    <asp:ListItem>13.00</asp:ListItem>
                                    <asp:ListItem>13.30</asp:ListItem>
                                    <asp:ListItem>14.00</asp:ListItem>
                                    <asp:ListItem>14.30</asp:ListItem>
                                    <asp:ListItem>15.00</asp:ListItem>
                                    <asp:ListItem>15.30</asp:ListItem>
                                    <asp:ListItem Selected="True">16.00</asp:ListItem>
                                    <asp:ListItem>16.30</asp:ListItem>
                                    <asp:ListItem>17.00</asp:ListItem>
                                    <asp:ListItem>17.30</asp:ListItem>
                                    <asp:ListItem>18.00</asp:ListItem>
                                    <asp:ListItem>19.30</asp:ListItem>
                                    <asp:ListItem>20.00</asp:ListItem>
                                    <asp:ListItem>20.30</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                    </table>
                    <asp:Panel ID="Panel1" runat="server">
                        <div class="navigator">
                            <asp:Label ID="Label15" runat="server" Font-Bold="True" Text="【确认收货信息并填写运单号】"></asp:Label>
                        </div>
                        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                            <tr id="mm" runat="server" visible="false">
                                <td align="right" width="20%">
                                    <asp:Label ID="Label17" runat="server" Text="物流公司："></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBox10" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" width="20%">
                                    <asp:Label ID="Label16" runat="server" Text="运单号码："></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBoxout_sid" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </ContentTemplate>
            </asp:UpdatePanel>
            <div class="btconfig">
                <asp:Button ID="btnOK" runat="server" Text="确定" OnClick="btnOK_Click" CssClass="bt2" />
                <asp:Button ID="btnCancel" runat="server" Text="返回订单列表" CssClass="bt2" OnClick="btnCancel_Click"
                            CausesValidation="false" />
            </div>
            <asp:HiddenField ID="hiddenFieldGuid" runat="server" Value="0" />
        </form>
    </body>
</html>