<%@ Control Language="C#" %>
<%@ Import Namespace="ShopNum1.ShopAdminWebControl" %>
<script type="text/javascript" charset="utf-8" src="/kindeditor/kindeditor.js"> </script>
<script type="text/javascript" charset="utf-8" src="/kindeditor/lang/zh_CN.js"> </script>
<script type="text/javascript" charset="utf-8" src="/kindeditor/plugins/code/prettify.js"> </script>
<script src="js/CommonJS.js" type="text/javascript"> </script>
<script type='text/javascript' src='js/resolution-test.js'> </script>
<script type="text/javascript">
    KindEditor.ready(function (K) {
        var editor = K.create('.Texteditor', {
            //上传管理
            uploadJson: '/kindeditor/file/upload_json.ashx',
            //文件管理
            fileManagerJson: '/kindeditor/file/file_manager_json.ashx',

            afterCreate: function () {
                var self = this;
                K.ctrl(document, 13, function () {
                    self.sync();
                    K('form[name=example]')[0].submit();
                });
                K.ctrl(self.edit.doc, 13, function () {
                    self.sync();
                    K('form[name=example]')[0].submit();
                });
            },
            allowFileManager: true,
            //编辑器高度
            width: '660px',
            //编辑器宽度
            height: '420px;',
            //配置编辑器的工具栏
            items: [
                'source', '|', 'undo', 'redo', '|', 'preview', 'print', 'template', 'code', 'cut', 'copy', 'paste',
                'plainpaste', 'wordpaste', '|', 'justifyleft', 'justifycenter', 'justifyright',
                'justifyfull', 'insertorderedlist', 'insertunorderedlist', 'indent', 'outdent', 'subscript',
                'superscript', 'clearhtml', 'quickformat', 'selectall', '|', 'fullscreen', '/',
                'formatblock', 'fontname', 'fontsize', '|', 'forecolor', 'hilitecolor', 'bold',
                'italic', 'underline', 'strikethrough', 'lineheight', 'removeformat', '|', 'image', 'multiimage',
                'flash', 'media', 'insertfile', 'table', 'hr', 'emoticons', 'baidumap', 'pagebreak',
                'anchor', 'link', 'unlink', '|', 'about'
            ]
        });
        prettyPrint();
    });
</script>
<script type="text/javascript" language="javascript" src="/js/DatePicker/WdatePicker.js"> </script>
<script src="/JS/jquery-1.6.2.min.js" type="text/javascript"> </script>
<script type="text/javascript">

    function funCheck() {
        var title = $("#S_ShopNewsEdit_ctl00_TextBoxTitle").val();
        if (title == "") {
            $("#errTitle").html("资讯标题不能为空！");
            return false;
        } else {
            $("#errTitle").html("*");
            return true;
        }
    }

    function funCheckType() {
        var NewsCategory = $("#S_ShopNewsEdit_ctl00_DropDownListNewsCategory").val();
        if (NewsCategory == "-1") {
            $("#errNewsCategory").html("资讯类别不能为空！");
            return false;
        } else {
            $("#errNewsCategory").html("*");
            return true;
        }
    }


    function funContent() {
        var Content = $("#S_ShopNewsEdit_ctl00_TexteditorContent").val();
        if (Content == "") {
            $("#errContent").html("资讯内容不能为空！");
            return false;
        } else {
            $("#errContent").html("*");
            return true;
        }
    }


    function funSEOTitle() {
        var SEOTitle = $("#S_ShopNewsEdit_ctl00_TextBoxSEOTitle").val();
        if (SEOTitle == "") {
            $("#errSEOTitle").html("SEO标题不能为空！");
            return false;
        } else {
            $("#errSEOTitle").html("*");
            return true;
        }
    }

    function funKeywords() {
        var Keywords = $("#S_ShopNewsEdit_ctl00_TextBoxKeywords").val();
        if (Keywords == "") {
            $("#errKeywords").html("SEO关键字不能为空！");
            return false;
        } else {
            $("#errKeywords").html("*");
            return true;
        }
    }

    function funDescription() {
        var Description = $("#S_ShopNewsEdit_ctl00_TextBoxDescription").val();
        if (Description == "") {
            $("#errDescription").html("SEO描述不能为空！");
            return false;
        } else {
            $("#errDescription").html("*");
            return true;
        }
    }

    function funCheckButton() {
        if (funCheck() && funCheckType() && funSEOTitle() && funKeywords() && funDescription()) {
            return true;
        }
        return false;
    }

</script>
<div class="dpsc_mian">
    <p class="ptitle">
        <a href="S_Welcome.aspx">我是卖家</a><span class="breadcrume_icon">>></span><a href="S_ShopNews.aspx">资讯分类</a><span
            class="breadcrume_icon">>></span><asp:Label ID="LabelTitle" runat="server" Text=""
                CssClass="breadcrume_text"></asp:Label></p>
    <div class="biaogenr">
        <table width="100%" border="0" cellspacing="0" cellpadding="0" class="biaod">
            <tr>
                <th colspan="2">
                    资讯信息
                </th>
            </tr>
            <tr>
                <td class="bordleft">
                    资讯标题：
                </td>
                <td class="bordrig" style="padding-top: 8px;">
                    <asp:TextBox ID="TextBoxTitle" runat="server" CssClass="op_text" onblur="funCheck()"></asp:TextBox>
                    <span class="red" id="errTitle">*</span>
                </td>
            </tr>
            <tr>
                <td class="bordleft">
                    资讯类别：
                </td>
                <td class="bordrig" style="padding-top: 8px;">
                    <asp:DropDownList ID="DropDownListNewsCategory" runat="server" onchange="funCheckType()"
                        CssClass="op_select">
                    </asp:DropDownList>
                    <span class="red" id="errNewsCategory">*</span>
                </td>
            </tr>
            <tr>
                <td class="bordleft">
                    资讯内容：
                </td>
                <td class="bordrig" style="padding-right: 20px;">
                    <asp:TextBox ID="TexteditorContent" runat="server" CssClass="Texteditor" onblur="funContent()"></asp:TextBox>
                    <span class="red" id="errContent">*</span>
                </td>
            </tr>
            <tr>
                <td class="bordleft">
                    是否显示：
                </td>
                <td class="bordrig" style="padding-top: 8px;">
                    <asp:CheckBox ID="CheckBoxIsShow" runat="server" Checked="true" />
                </td>
            </tr>
            <tr>
                <td class="bordleft">
                    SEO标题：
                </td>
                <td class="bordrig" style="padding-top: 8px;">
                    <asp:TextBox ID="TextBoxSEOTitle" runat="server" CssClass="op_text" onblur="funSEOTitle()"></asp:TextBox>
                    <span class="red" id="errSEOTitle">*</span>
                </td>
            </tr>
            <tr>
                <td class="bordleft">
                    SEO关键字：
                </td>
                <td class="bordrig" style="padding-top: 8px;">
                    <asp:TextBox ID="TextBoxKeywords" runat="server" CssClass="op_text" onblur="funKeywords()"></asp:TextBox>
                    <span class="red" id="errKeywords">*</span>
                </td>
            </tr>
            <tr>
                <td class="bordleft">
                    SEO描述：
                </td>
                <td class="bordrig" style="padding-top: 8px;">
                    <asp:TextBox ID="TextBoxDescription" runat="server" TextMode="MultiLine" Width="500"
                        Height="100" CssClass="op_area" onblur="funDescription()"></asp:TextBox>
                    <span class="red" id="errDescription">*</span>
                </td>
            </tr>
        </table>
        <div class="op_btn">
            <asp:Button ID="ButtonSubmit" runat="server" Text="确定" CssClass="baocbtn" OnClientClick=" return funCheckButton() " />
            <asp:Button ID="ButtonBackList" runat="server" Text="返回" CssClass="baocbtn" />
        </div>
    </div>
</div>
<asp:HiddenField ID="HiddenFieldGuid" runat="server" Value="0" />
