<%@ Control Language="C#" %>
<%@ Import Namespace="ShopNum1.ShopAdminWebControl" %>
<script type="text/javascript">
    $(function () {
        if ($("#<%= DropDownListCSV.ClientID %>").val() == "2" || $("#<%= DropDownListCSV.ClientID %>").val() == "3") {
            $("#mytable").children(":eq(0)").children("[type='taobao']").show();
        } else {
            $("#mytable").children(":eq(0)").children("[type='taobao']").hide();
        }

        if ($("#<%= DropDownListCSV.ClientID %>").val() == "3") {
            $("#<%= TextBoxColumn.ClientID %>").val("0");
            $("#<%= Label4.ClientID %>").val("");
        }
    });

    function JSonchange() {
        if ($("#<%= DropDownListCSV.ClientID %>").val() == "2" || $("#<%= DropDownListCSV.ClientID %>").val() == "3")//0为你要选中的项的value
        {
            $("#mytable").children(":eq(0)").children("[type='taobao']").show();
        } else {
            $("#mytable").children(":eq(0)").children("[type='taobao']").hide();
        }

        if ($("#<%= DropDownListCSV.ClientID %>").val() == "3") {
            $("#<%= TextBoxColumn.ClientID %>").val("10000000");
            $("#<%= Label4.ClientID %>").text("");
        } else if ($("#<%= DropDownListCSV.ClientID %>").val() == "2") {
            $("#<%= TextBoxColumn.ClientID %>").val("50011150");
            $("#<%= Label4.ClientID %>").text("(宝贝类目CID为淘宝商品类目CID，如若不确定,请填写50011150,代表商品类目为：其它-其它) ");
        }
    }

    function OnloadJS() {
        if ($("#<%= DropDownListCSV.ClientID %>").val() == "2" || $("#<%= DropDownListCSV.ClientID %>").val() == "3")//0为你要选中的项的value
        {

            $("#mytable").children(":eq(0)").children("[type='taobao']").show();
        } else {
            $("#mytable").children(":eq(0)").children("[type='taobao']").hide();
        }
    }

    function funSelect() {
        if ($("#<%= DropDownListProductCategoryID.ClientID %>").val() == "-1") {
            return false;
        }
        if ($("#<%= DropDownListCSV.ClientID %>").val() == "2" || $("#<%= DropDownListCSV.ClientID %>").val() == "3")//0为你要选中的项的value
        {
            if ($("#<%= ddlCity.ClientID %>").val() == "-1") {
                $("#errSF").text("省份和城市必须选择");
                return false;
            } else {
                $("#errSF").text("");
            }
        }
    }

</script>
<div class="main">
    <div class="table1">
        <div class="title">
            <span>导出商品</span> <span class="gwk" style="font-weight: normal;"></span>
        </div>
        <table id="mytable" cellpadding="0" cellspacing="0" border="0" style="width: 100%">
            <tr>
                <td align="right" style="width: 13%;">
                    <asp:Label ID="Label6" runat="server" Text="需要导出的数据类型："></asp:Label>
                </td>
                <td align="left">
                    <asp:DropDownList ID="DropDownListCSV" onchange="JSonchange()" runat="server">
                        <asp:ListItem Text="导出商品CSV数据" Value="1"></asp:ListItem>
                        <asp:ListItem Text="导出淘宝CSV数据" Value="2"></asp:ListItem>
                        <asp:ListItem Text="导出拍拍CSV数据" Value="3"></asp:ListItem>
                        <%--<asp:ListItem Text="导出易趣CSV数据" Value="4"></asp:ListItem>--%>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 13%;">
                    &nbsp;
                </td>
                <td align="left">
                    &nbsp;
                </td>
            </tr>
            <asp:Panel ID="PanelCategory" runat="server">
                <tr>
                    <td align="right" style="width: 13%;">
                        <asp:Label ID="LabelProductCategory" runat="server" Text="需要导出的商品分类："></asp:Label>
                    </td>
                    <td align="left">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="DropDownListProductCategoryID" runat="server" CssClass="select1"
                                    AutoPostBack="true">
                                    <asp:ListItem Selected="True" Value="-1">-请选择-</asp:ListItem>
                                </asp:DropDownList>
                                (当前导出<asp:Label ID="LabelCategoryIDTotalCount" runat="server" Text="0"></asp:Label>条商品数据)
                                <span style="color: Red">*</span>
                                <asp:CompareValidator ID="CompareDropDownListProductCategoryID" runat="server" ControlToValidate="DropDownListProductCategoryID"
                                    Display="Dynamic" ErrorMessage="该值必需选择" Operator="NotEqual" ValueToCompare="-1"></asp:CompareValidator>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="DropDownListProductCategoryID" EventName="SelectedIndexChanged" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </td>
                </tr>
            </asp:Panel>
            <tr type="taobao" style="display: none">
                <td align="right" style="width: 13%;">
                    &nbsp;
                </td>
                <td align="left">
                    &nbsp;
                </td>
            </tr>
            <tr type="taobao" style="display: none">
                <td align="right" style="width: 13%;">
                    <asp:Label ID="Label3" runat="server" Text="宝贝类目CID："></asp:Label>
                </td>
                <td align="left">
                    <asp:TextBox ID="TextBoxColumn" Text="50011150" runat="server"></asp:TextBox><asp:Label
                        ID="Label4" runat="server" Text="(宝贝类目CID为淘宝商品类目CID，如若不确定,请填写50011150,代表商品类目为：其它-其它)"></asp:Label>
                </td>
            </tr>
            <tr type="taobao" style="display: none">
                <td align="right" style="width: 13%;">
                    &nbsp;
                </td>
                <td align="left">
                    &nbsp;
                </td>
            </tr>
            <tr type="taobao" style="display: none">
                <td align="right" style="width: 13%;">
                    所在地：
                </td>
                <td align="left">
                    <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList ID="ddlProvince" runat="server" Height="25px" AutoPostBack="true">
                            </asp:DropDownList>
                            <asp:DropDownList ID="ddlCity" runat="server" Height="25px">
                                <asp:ListItem Value="-1" Text="-请选择-"></asp:ListItem>
                            </asp:DropDownList>
                            <span style="color: Red;">*</span> <span style="color: Red;" id="errSF"></span>
                            <%--<asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="ddlCity"
                                Display="Dynamic" ErrorMessage="该值必需选择" Operator="NotEqual" ValueToCompare="-1"></asp:CompareValidator>--%>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="ddlProvince" EventName="SelectedIndexChanged" />
                        </Triggers>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 13%;">
                    &nbsp;
                </td>
                <td align="left">
                    &nbsp;
                </td>
            </tr>
            <tr style="background-color: #EEEEEE; padding: 0 0">
                <td align="right" style="width: 16%;">
                    &nbsp;
                </td>
                <td align="left">
                    <div style="width: 80%;">
                        <asp:Button ID="ButtonSubmit" runat="server" CssClass="bt2" Text="导出" OnClientClick=" return funSelect() " />
                    </div>
                </td>
            </tr>
        </table>
    </div>
</div>
