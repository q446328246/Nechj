<%@ Page AutoEventWireup="True" CodeBehind="TbProduct_List.aspx.cs" Inherits="ShopNum1.Deploy.Shop.ShopAdmin.TbTop.TbProduct_List"
    Language="C#" %>

<%@ Import Namespace="ShopNum1.Common" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>商品列表</title>
    <base href='<%= Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.LastIndexOf('/') + 1) %>' />
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <link rel="stylesheet" type="text/css" href="style/tbindex.css" />
    <link rel="stylesheet" type="text/css" href="style/index.css" />
    <script src="/Main/js/CommonJS.js" type="text/javascript"> </script>
    <script type="text/javascript" src="/js/jquery-1.6.2.min.js"> </script>
    <script language="javascript" type="text/javascript">
        function SelectAllCheckboxes(obj) {
            var theTable = obj.parentNode.parentNode.parentNode;
            var inputs = theTable.getElementsByTagName('input');
            for (var i = 0; i < inputs.length; i++) {
                if (inputs[i].type == "checkbox") {
                    inputs[i].checked = obj.checked;
                }
            }
        }

        function GetCheckedBoxValues() {
            var checkedBoxValues = "";
            var inputs = document.getElementsByTagName("input");
            for (var j = 0; j < inputs.length; j++) {
                if (inputs[j].type == "checkbox" && inputs[j].id != "checkboxAll") {
                    if (inputs[j].checked == true) {
                        checkedBoxValues += "'" + inputs[j].value + "',";
                    }
                }
            }
            if (checkedBoxValues.length > 0) {
                checkedBoxValues = checkedBoxValues.substring(0, checkedBoxValues.length - 1);
            }

            return checkedBoxValues;
        }

        function DeleteBt(msg) {
            var checkedBoxValues = GetCheckedBoxValues();
            if (checkedBoxValues == "") {
                alert("请选择要" + msg + "的记录！");
                return false;
            } else if (window.confirm("您确定要" + msg + "吗?")) {
                document.getElementById('<%= CheckGuid.ClientID %>').value = checkedBoxValues;
                return true;
            } else {
                return false;
            }
        }

        function EditBt() {
            var checkedBoxValues = GetCheckedBoxValues();
            if (checkedBoxValues == "") {
                alert("请选择要操作的记录！");
                return false;
            } else if (checkedBoxValues.split(",").length > 1) {
                alert("您每次只能选择一条记录操作！");
                return false;
            } else {
                document.getElementById('<%= CheckGuid.ClientID %>').value = checkedBoxValues;
                return true;
            }
        }
    </script>
</head>
<body class="right_body">
    <form id="form1" runat="server">
    <div class="main">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="table1">
            <div class="title">
                商品列表
            </div>
            <div class="content">
                <table width="100%" cellpadding="0" cellspacing="0">
                    <tr>
                        <td style="text-align: right">
                            商品名称：
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxName" runat="server" CssClass="allinput1"></asp:TextBox>
                        </td>
                        <td style="text-align: right">
                            货号：
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxProductNum" runat="server" CssClass="allinput1"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right">
                            本店价：
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxBeginPrice" runat="server" CssClass="allinput1"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorCostPrice1" runat="server"
                                ControlToValidate="TextBoxBeginPrice" Display="Dynamic" ErrorMessage="价格格式不正确"
                                ValidationExpression="^[0-9]+(.[0-9]{1,3})?$"></asp:RegularExpressionValidator>—
                            <asp:TextBox ID="TextBoxEndPrice" runat="server" CssClass="allinput1"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBoxEndPrice"
                                Display="Dynamic" ErrorMessage="价格格式不正确" ValidationExpression="^[0-9]+(.[0-9]{1,3})?$"></asp:RegularExpressionValidator>
                        </td>
                        <td style="text-align: right">
                            商品类型：
                        </td>
                        <td>
                            <asp:DropDownList ID="DropDownListType" runat="server" Width="66px">
                                <asp:ListItem Value="-1" Selected="True">-全部-</asp:ListItem>
                                <asp:ListItem Value="IsNew">新品</asp:ListItem>
                                <asp:ListItem Value="IsHot">热卖</asp:ListItem>
                                <asp:ListItem Value="IsPromotion">促销</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right">
                            商品分类：
                        </td>
                        <td>
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="DropDownListProductSeriesCode1" runat="server" AutoPostBack="true">
                                    </asp:DropDownList>
                                    <asp:DropDownList ID="DropDownListProductSeriesCode2" runat="server" AutoPostBack="true">
                                    </asp:DropDownList>
                                    <asp:DropDownList ID="DropDownListProductSeriesCode3" runat="server">
                                    </asp:DropDownList>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                        <td style="text-align: right">
                            是否上架：
                        </td>
                        <td>
                            <asp:DropDownList ID="DropDownListIsSaled" runat="server" CssClass=" btbt2">
                                <asp:ListItem Text="-全部-" Value="-1"></asp:ListItem>
                                <asp:ListItem Text="未上架" Value="0"></asp:ListItem>
                                <asp:ListItem Text="已上架" Value="1"></asp:ListItem>
                                <asp:ListItem Text="下架" Value="2"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:Button ID="ButtonSearch" runat="server" Text="查询" CssClass="bt2" />
                        </td>
                    </tr>
                </table>
                <table cellpadding="0" cellspacing="0" width="100%" style="text-align: center">
                    <tr class="MemberTr">
                        <td width="30" style="text-align: center">
                            <input id="checkboxAll" onclick=" javascript:SelectAllCheckboxes(this); " type="checkbox" />
                        </td>
                        <td style="text-align: center">
                            商品名称
                        </td>
                        <td style="text-align: center">
                            商品分类
                        </td>
                        <td style="text-align: center">
                            货号
                        </td>
                        <td style="text-align: center">
                            库存
                        </td>
                        <td style="text-align: center">
                            本店价
                        </td>
                        <td style="text-align: center">
                            共赢价
                        </td>
                        <td style="text-align: center">
                            上架
                        </td>
                        <td style="text-align: center">
                            新品
                        </td>
                        <td style="text-align: center">
                            热卖
                        </td>
                        <td style="text-align: center">
                            促销
                        </td>
                        <td style="text-align: center">
                            添加时间
                        </td>
                        <td style="text-align: center">
                            是否审核
                        </td>
                        <td style="text-align: center">
                            同步状态
                        </td>
                    </tr>
                    <asp:Repeater EnableViewState="False" ID="RepeaterShow" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td style="text-align: center">
                                    <input id="checkboxItem" value='<%# Eval("Guid") %>' type="checkbox" />
                                </td>
                                <td style="text-align: center">
                                    <a href='<%#ShopUrlOperate.shopDetailHrefByShopID(Eval("Guid").ToString(), Eval("ShopID").ToString(), "ProductDetail") %>'
                                        target="_blank"><span title='<%# DataBinder.Eval(Container.DataItem, "Name") %>'>
                                            <%# Utils.GetUnicodeSubString(DataBinder.Eval(Container.DataItem, "Name").ToString(), 40, "") %></span></a>
                                </td>
                                <td style="text-align: center">
                                    <%# DataBinder.Eval(Container.DataItem, "ProductSeriesName") %>
                                </td>
                                <td style="text-align: center">
                                    <%# DataBinder.Eval(Container.DataItem, "ProductNum") %>
                                </td>
                                <td style="text-align: center">
                                    <%# DataBinder.Eval(Container.DataItem, "RepertoryCount") %>
                                </td>
                                <td style="text-align: center">
                                    <%# DataBinder.Eval(Container.DataItem, "ShopPrice") %>
                                </td>
                                <td style="text-align: center">
                                    <%# DataBinder.Eval(Container.DataItem, "GroupPrice") %>
                                </td>
                                <td style="color: Red; font-weight: bold; text-align: center;">
                                    <%--   <%# Product_List.ChangIsNew(Eval("IsSaled").ToString())%>--%>
                                </td>
                                <td style="color: Red; font-weight: bold; text-align: center;">
                                    <%--     <%# Product_List.ChangIsNew (Eval( "IsNew").ToString())%>--%>
                                </td>
                                <td style="color: Red; font-weight: bold; text-align: center;">
                                    <%--         <%# Product_List.ChangIsNew(Eval("IsHot").ToString())%>--%>
                                </td>
                                <td style="color: Red; font-weight: bold; text-align: center;">
                                    <%--  <%# Product_List.ChangIsNew(Eval("IsPromotion").ToString())%>--%>
                                </td>
                                <td style="text-align: center; width: 9%">
                                    <%# DataBinder.Eval(Container.DataItem, "CreateTime").ToString() %>
                                </td>
                                <td style="text-align: center; width: 7%">
                                    <%# DataBinder.Eval(Container.DataItem, "IsAudit").ToString() == "1" ? "审核通过" : (DataBinder.Eval(Container.DataItem, "IsAudit").ToString() == "2" ? "审核未通过" : "未审核") %>
                                </td>
                                <td style="text-align: center; width: 7%">
                                    <%# DataBinder.Eval(Container.DataItem, "IsAudit").ToString() == "1" ? "审核通过" : (DataBinder.Eval(Container.DataItem, "IsAudit").ToString() == "2" ? "审核未通过" : "未审核") %>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
            </div>
            <!-- 分页部分-->
            <div class="pager">
                <asp:Label ID="LabelPageMessage" runat="server"></asp:Label>
                &nbsp;<asp:HyperLink ID="lnkFirst" runat="server"><span class="fpager">[ 首页</span></asp:HyperLink>
                <asp:HyperLink ID="lnkPrev" runat="server"><span class="fpager">| 上一页</span></asp:HyperLink>
                <asp:HyperLink ID="lnkNext" runat="server"><span class="fpager">| 下一页</span></asp:HyperLink>
                <asp:HyperLink ID="lnkLast" runat="server"><span class="fpager">| 末页 ]</span></asp:HyperLink>
                &nbsp;<span class="fpager">转到
                    <asp:Literal ID="lnkTo" runat="server" />
                    页</span>
            </div>
        </div>
        <asp:HiddenField ID="CheckGuid" runat="server" />
        <asp:Button runat="server" ID="ButtonSearchDetail" Text="查看" CssClass="bt2 bt3" OnClientClick=" return EditBt() "
            OnClick="ButtonSearchDetail_Click" />
        <asp:Button ID="ButtonAdd" runat="server" Text="添加" CssClass="bt2 bt3" CausesValidation="false"
            OnClick="ButtonAdd_Click" />
        <asp:Button runat="server" ID="ButtonEdit" Text="编辑" CssClass="bt2" OnClientClick=" return EditBt() "
            OnClick="ButtonEdit_Click" />
        <asp:Button runat="server" ID="ButtonDelete" Text="删除" CssClass="bt2" OnClientClick=" return DeleteBt('删除') "
            OnClick="ButtonDelete_Click" />
        <asp:Button runat="server" ID="ButtonUpSaled" Text="上架" CssClass="bt2" OnClientClick=" return DeleteBt('上架') "
            OnClick="ButtonUpSaled_Click" />
        <asp:Button runat="server" ID="ButtonDownSaled" Text="下架" CssClass="bt2" OnClientClick=" return DeleteBt('下架') "
            OnClick="ButtonDownSaled_Click" />
    </div>
    </form>
</body>
</html>
