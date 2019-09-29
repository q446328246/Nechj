<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="TbProductCategory_Operate.aspx.cs" Inherits="ShopNum1.Deploy.Shop.ShopAdmin.TbTop.TbProductCategory_Operate" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
    <head id="Head1" runat="server">
        <title></title>
        <link rel='stylesheet' type='text/css' href='../style/style.css' />
    </head>
    <body>
        <form id="form1" runat="server">
            <div class="tjsp_mian">
                <p class="ptitle">
                    <a href="S_Welcome.aspx">我是卖家</a><span class="breadcrume_icon">>></span><a href="TbProductCategory_List.aspx">本地商品分类</a><span
                                                                                                                                                class="breadcrume_icon">>></span> <span class="breadcrume_text">商品分类操作</span></p>
                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="biaod" style="margin-top: 15px;">
                    <tr>
                        <th colspan="2" scope="col">
                            <asp:Label ID="LabelTitle" runat="server" Text="添加商品分类"></asp:Label>
                        </th>
                    </tr>
                    <tr>
                        <td class="bordleft" width="130">
                            <asp:Localize ID="Localize1" runat="server" Text="分类名称："></asp:Localize>
                        </td>
                        <td class="bordrig">
                            <asp:TextBox ID="TextBoxName" runat="server" CssClass="ss_nr1"></asp:TextBox>
                            <asp:Label ID="Label2" runat="server" Text="*" ForeColor="red"></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorName" runat="server" ControlToValidate="TextBoxName"
                                                        Display="Dynamic" ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorName" runat="server"
                                                            ControlToValidate="TextBoxName" Display="Dynamic" ErrorMessage="最多50个字符" ValidationExpression="^[\s\S]{0,50}$"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="bordleft" width="130">
                            <asp:Localize ID="LocalizeFatherCateGory" runat="server" Text="上级分类："></asp:Localize>
                        </td>
                        <td class="bordrig">
                            <asp:DropDownList ID="DropDownListFatherCateGory" runat="server" CssClass="tselect">
                            </asp:DropDownList>
                            <asp:CompareValidator ID="CompareFatherCateGory" runat="server" ControlToValidate="DropDownListFatherCateGory"
                                                  Display="Dynamic" ErrorMessage="该值必需选择" Operator="NotEqual" ValueToCompare="-1"></asp:CompareValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="bordleft">
                            <asp:Localize ID="Localize2" runat="server" Text="分类关键字："></asp:Localize>
                        </td>
                        <td class="bordrig">
                            <asp:TextBox ID="TextBoxKeywords" runat="server" CssClass="ss_nr1"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorKeywords" runat="server"
                                                            ControlToValidate="TextBoxKeywords" Display="Dynamic" ErrorMessage="最多200个字符"
                                                            ValidationExpression="^[\s\S]{0,200}$"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="bordleft">
                            <asp:Localize ID="Localize3" runat="server" Text="分类描述："></asp:Localize>
                        </td>
                        <td class="bordrig" style="padding-bottom: 10px; padding-top: 10px;">
                            <asp:TextBox ID="TextBoxDescription" runat="server" TextMode="MultiLine" Width="550px"
                                         Height="120px" CssClass="ss_nr1"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorDescription" runat="server"
                                                            ControlToValidate="TextBoxDescription" Display="Dynamic" ErrorMessage="最多200个字符"
                                                            ValidationExpression="^[\s\S]{0,200}$"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="bordleft">
                            <asp:Localize ID="Localize4" runat="server" Text="分类排序："></asp:Localize>
                        </td>
                        <td class="bordrig">
                            <asp:TextBox ID="TextBoxOrderID" runat="server" CssClass="ss_nr1"></asp:TextBox>(自动计算)
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorRepertoryOrderID" runat="server"
                                                            ControlToValidate="TextBoxOrderID" ErrorMessage="只能输入数字" ValidationExpression="^[0-9]*$"
                                                            Display="Dynamic"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="bordleft">
                            <asp:Localize ID="Localize5" runat="server" Text="是否前台显示："></asp:Localize>
                        </td>
                        <td class="bordrig">
                            <asp:CheckBox ID="CheckBoxIsShow" runat="server" Checked="True" Text="是" />
                        </td>
                    </tr>
                    <tr>
                        <td class="bordleft">
                            <asp:Localize ID="Localize6" runat="server" Text="是否同步淘宝："></asp:Localize>
                        </td>
                        <td class="bordrig">
                            <asp:CheckBox ID="CheckBoxTb" runat="server" Checked="false" Text="是否同步淘宝" AutoPostBack="true"
                                          OnCheckedChanged="CheckBoxTb_CheckedChanged" />
                            <span id="spanTb" runat="server" style="color: Red;">(未同步)</span>
                        </td>
                    </tr>
                </table>
                <div style="margin: 20px 0px 50px 0px; text-align: center;">
                    <%--<input type="button" class="baocbtn" onclick="if (!checkImport()) { return false; } document.form1.target = '_self'; this.disabled = 'disabled'; __doPostBack('btnOk', '')" value="确定" />
           <span id="spanImg" style="display:none;"><img src='/Images/load.gif'/></span>
           <span class="gray1">易趣提供的CSV可能不是标准的格式请注意转换 (上传文件大小不要超过50M)</span>--%>
                    <asp:Button ID="ButtonConfirm" runat="server" Text="确定" CssClass="baocbtn" ToolTip="Submit"
                                OnClick="ButtonConfirm_Click" OnClientClick=" " />
                    <input id="Reset1" type="reset" value="重置" class="baocbtn" style="display: none;" />
                    <asp:Button ID="ButtonBack" runat="server" CssClass="baocbtn" Text="返回列表" CausesValidation="False"
                                OnClientClick=" window.location.href = 'TbProductCategory_List.aspx' " PostBackUrl="TbProductCategory_List.aspx" />
                    <asp:HiddenField ID="hiddenFieldGuid" runat="server" Value="0" />
                </div>
            </div>
        </form>
    </body>
</html>