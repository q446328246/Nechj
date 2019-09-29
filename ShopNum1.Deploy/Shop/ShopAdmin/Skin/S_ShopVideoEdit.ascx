<%@ Control Language="C#" %>
<%@ Import Namespace="ShopNum1.ShopAdminWebControl" %>
<script type="text/javascript" language="javascript" src="/js/DatePicker/WdatePicker.js"> </script>
<script src="/JS/jquery-1.6.2.min.js" type="text/javascript"> </script>
<script type="text/javascript">

    //标题
    function funCheckTitle() {
        var title = $("#<%= TextBoxTitle.ClientID %>").val();
        if (title == "") {
            $("#errTitle").html("视频标题不能为空！");
            return false;
        } else {
            $("#errTitle").html("*");
            return true;
        }
    }

    //分类

    function funCheckCategory() {
        var Category = $("#<%= DropDownListCategory.ClientID %>").val();
        if (Category == "-1") {
            $("#errCategory").html("视频标题不能为空！");
            return false;
        } else {
            $("#errCategory").html("*");
            return true;
        }
    }

    //视频代码

    function funCheckVideoAdd() {
        var VideoAdd = $("#<%= TextBoxVideoAdd.ClientID %>").val();
        if (VideoAdd == "") {
            $("#errVideoAdd").html("视频代码不能为空！");
            return false;
        } else {
            $("#errVideoAdd").html("*");
            return true;
        }
    }


    //排序号

    function funCheckOrderID() {
        var OrderID = $("#<%= TextBoxOrderID.ClientID %>").val();
        if (OrderID == "") {
            $("#errOrderID").html("排序号不能为空！");
            return false;
        } else {
            var ex = /^\d+$/;
            if (ex.test(OrderID)) {
                $("#errOrderID").html("*");
                return true;
            } else {
                $("#errOrderID").html("请输入整数！");
                return false;
            }
        }
    }


    //关键字

    function funCheckKeyWords() {
        var KeyWords = $("#<%= TextBoxKeyWords.ClientID %>").val();
        if (KeyWords == "") {
            $("#errKeywords").html("关键字不能为空！");
            return false;
        } else {
            $("#errKeywords").html("*");
            return true;
        }
    }

    //SEO描述

    function funCheckDescription() {
        var Description = $("#<%= TextBoxDescription.ClientID %>").val();
        if (Description == "") {
            $("#errDescription").html("关键字不能为空！");
            return false;
        } else {
            $("#errDescription").html("*");
            return true;
        }
    }

    //视频信息

    function funCheckContent() {
        var Content = $("#<%= TextBoxContent.ClientID %>").val();
        if (Content == "") {
            $("#errContent").html("视频信息不能为空！");
            return false;
        } else {
            $("#errContent").html("*");
            return true;
        }
    }


    function funCheckButton() {
        if (funCheckTitle() && funCheckCategory() && funCheckVideoAdd() && funCheckOrderID() && funCheckKeyWords() && funCheckDescription() && funCheckContent()) {
            return true;
        }
        return false;
    }

</script>
<div class="dpsc_mian">
    <p class="ptitle">
        <a href="S_Welcome.aspx">我是卖家</a><span class="breadcrume_icon">>></span><a href="S_ShopVideo.aspx">视频管理</a><span
            class="breadcrume_icon">>></span><asp:Label ID="LabelTitle" runat="server" Text=""
                CssClass="breadcrume_text"></asp:Label></p>
    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="biaod" style="margin-top: 15px;">
        <tr>
            <th colspan="2" scope="col">
                视频信息
            </th>
        </tr>
        <tr>
            <td class="bordleft">
                视频标题：
            </td>
            <td class="bordrig" style="padding-top: 8px;">
                <asp:TextBox ID="TextBoxTitle" runat="server" CssClass="op_text" onblur="funCheckTitle()"></asp:TextBox>
                <span class="red" id="errTitle">*</span>
            </td>
        </tr>
        <tr>
            <td class="bordleft">
                视频分类：
            </td>
            <td class="bordrig" style="padding-top: 8px;">
                <asp:DropDownList ID="DropDownListCategory" runat="server" onchange="funCheckCategory()"
                    CssClass="op_select">
                </asp:DropDownList>
                <span class="red" id="errCategory">*</span>
            </td>
        </tr>
        <tr>
            <td class="bordleft">
                视频代码：
            </td>
            <td class="bordrig" style="padding-top: 8px;">
                <asp:TextBox ID="TextBoxVideoAdd" runat="server" CssClass="op_area" onblur="funCheckVideoAdd()"
                    TextMode="MultiLine"></asp:TextBox>
                <span class="star" id="errVideoAdd">*</span>
                <div class="gray">
                    视频代码可以到优酷视频去复制。具体操作方法请见文档说明。
                </div>
            </td>
        </tr>
        <tr>
            <td class="bordleft">
                视频图片：
            </td>
            <td class="bordrig" style="padding-top: 8px;">
                <asp:FileUpload ID="FileUploadImage" runat="server" />
                <asp:HiddenField ID="HiddenFieldImage" runat="server" />
            </td>
        </tr>
        <asp:Panel ID="PanelShow" runat="server" Visible="false">
            <tr>
                <td class="bordleft">
                    视频图片预览：
                </td>
                <td class="bordrig" style="padding-top: 8px;">
                    <asp:Image ID="ImageVideo" runat="server" Width="200" Height="200" />
                </td>
            </tr>
        </asp:Panel>
        <tr>
            <td class="bordleft">
                排序号：
            </td>
            <td class="bordrig" style="padding-top: 8px;">
                <asp:TextBox ID="TextBoxOrderID" runat="server" CssClass="op_text" onblur="funCheckOrderID()"></asp:TextBox>
                <span class="red" id="errOrderID">*</span>
            </td>
        </tr>
        <tr>
            <td class="bordleft">
                关键字：
            </td>
            <td class="bordrig" style="padding-top: 8px;">
                <asp:TextBox ID="TextBoxKeyWords" runat="server" CssClass="op_text" onblur="funCheckKeyWords()"></asp:TextBox>
                <span class="red" id="errKeywords">*</span>
            </td>
        </tr>
        <tr>
            <td class="bordleft">
                SEO描述：
            </td>
            <td class="bordrig" style="padding-top: 8px;">
                <asp:TextBox ID="TextBoxDescription" runat="server" TextMode="MultiLine" CssClass="op_area"
                    onblur="funCheckDescription()"></asp:TextBox>
                <span class="red" id="errDescription">*</span>
            </td>
        </tr>
        <tr>
            <td class="bordleft">
                视频信息：
            </td>
            <td class="bordrig" style="padding-top: 8px;">
                <asp:TextBox ID="TextBoxContent" runat="server" TextMode="MultiLine" CssClass="op_area"
                    onblur="funCheckContent()"></asp:TextBox>
                <span class="red" id="errContent">*</span>
            </td>
        </tr>
    </table>
    <div class="op_btn">
        <asp:Button ID="ButtonSubmit" runat="server" Text="确定" CssClass="baocbtn" OnClientClick=" return funCheckButton() " />
        <asp:Button ID="ButtonBackList" runat="server" Text="返回" CssClass="baocbtn" />
    </div>
</div>
<asp:HiddenField ID="HiddenFieldGuid" runat="server" Value="0" />
