<%@ Control Language="C#" %>
<%@ Import Namespace="ShopNum1.ShopAdminWebControl" %>
<script type="text/javascript" charset="utf-8" src="/kindeditor/kindeditor.js"> </script>
<script type="text/javascript" charset="utf-8" src="/kindeditor/lang/zh_CN.js"> </script>
<script type="text/javascript" charset="utf-8" src="/kindeditor/plugins/code/prettify.js"> </script>
<script type="text/javascript">
    var editor;
    KindEditor.ready(function (K) {
        editor = K.create('.Texteditor', {
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
            width: '100%',
            //编辑器宽度
            height: '300px;',
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

    var editor2;
    KindEditor.ready(function (K) {
        editor2 = K.create('.Texteditor2', {
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
            width: '500px',
            //编辑器宽度
            height: '300px;',
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
<div class="pad">
    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="tabbiao">
        <tr>
            <td align="right" style="width: 130px;">
                商品分类：
            </td>
            <td align="left">
                <asp:UpdatePanel ID="UpdatePanelProdcutCate" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:DropDownList ID="DropDownListProductCategoryCode1" runat="server" AutoPostBack="true"
                            CssClass="textwb" Width="130">
                        </asp:DropDownList>
                        <asp:DropDownList ID="DropDownListProductCategoryCode2" runat="server" AutoPostBack="true"
                            CssClass="textwb" Width="130">
                        </asp:DropDownList>
                        <asp:DropDownList ID="DropDownListProductCategoryCode3" runat="server" AutoPostBack="true"
                            CssClass="textwb" Width="130">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td style="text-align: right">
                商品名称：
            </td>
            <td>
                <ShopNum1:TextBox ID="TextBoxName" runat="server" CssClass="textwb" CanBeNull="必填"
                    HintInfo="请填写该商品的名称,该项必填" HintTitle="请填写该商品的名称,该项必填" Width="405px">
                </ShopNum1:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidatorName" runat="server"
                    ControlToValidate="TextBoxName" Display="Dynamic" ErrorMessage="最多50个字符" ValidationExpression="^[\s\S]{0,50}$"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr style="display: none">
            <td style="text-align: right">
                商品类别：
            </td>
            <td>
                <asp:CheckBox ID="CheckBoxIsNew" runat="server" Text="新品" />&nbsp;&nbsp;&nbsp;
                <asp:CheckBox ID="CheckBoxIsHot" runat="server" Text="热卖" />
            </td>
        </tr>
        <tr>
            <td style="text-align: right">
                商品货号：
            </td>
            <td align="left">
                <asp:TextBox ID="TextBoxProductNum" runat="server" MaxLength="50" CssClass="textwb"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="text-align: right">
                商品单位：
            </td>
            <td align="left">
                <asp:TextBox ID="TextBoxUnitName" runat="server" CssClass="textwb" MaxLength="20"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="text-align: right">
                库存量：
            </td>
            <td align="left">
                <ShopNum1:TextBox ID="TextBoxRepertoryCount" runat="server" CssClass="textwb" CanBeNull="必填"
                    HintInfo="请填写该商品的库存量,该项必填" HintTitle="请填写该商品的库存量,该项必填" RequiredFieldType="整数验证"
                    MaxLength="9">
                </ShopNum1:TextBox>
            </td>
        </tr>
        <tr>
            <td style="text-align: right">
                市场价：
            </td>
            <td align="left">
                <ShopNum1:TextBox ID="TextBoxMarketPrice" runat="server" CssClass="textwb" CanBeNull="必填"
                    HintInfo="请填写该商品的市场价,该项必填" RequiredFieldType="金额" HintTitle="请填写该商品的市场价,该项必填"
                    MaxLength="10" Width="69" Text="0.00">
                </ShopNum1:TextBox>（元）
            </td>
        </tr>
        <tr>
            <td style="text-align: right">
                所需红包：
            </td>
            <td align="left">
                <ShopNum1:TextBox ID="TextBoxIntegral" runat="server" CssClass="textwb" CanBeNull="必填"
                    HintInfo="请填写该商品的所需红包,该项必填" RequiredFieldType="金额" HintTitle="请填写该商品的所需红包,该项必填"
                    MaxLength="10">
                </ShopNum1:TextBox>
            </td>
        </tr>
        <tr>
            <td style="text-align: right">
                商品详细：
            </td>
            <td align="left" style="padding-right: 20px;">
                <textarea name="FCKeditorRemark" id="FCKeditorDetail" runat="server" class="Texteditor tinput txtarea"></textarea>
            </td>
        </tr>
        <tr>
            <td style="text-align: right">
                商品图片：
            </td>
            <td align="left">
                <asp:HiddenField ID="HiddenFieldProduct" runat="server" />
                <img id="ImgOrganizImg" alt="" src="../images/noImage.gif" onerror="javascript:this.src='/ImgUpload/noImg.jpg'"
                    runat="server" width="110" height="110" />
                <input id="bt2" class="sqjdbzj1" style="bottom: -5px; position: relative;" type="button"
                    value="选择图片" onclick=" showDialog() " />
            </td>
        </tr>
        <tr>
            <td style="text-align: right">
                标题：
            </td>
            <td align="left">
                <ShopNum1:TextBox ID="TextBoxTitle" runat="server" CssClass="textwb" MaxLength="50"
                    HintInfo="商品标题,此功能是为了方便百度等搜索引擎,搜索到您的商品" HintTitle="商品标题,此功能,是为了方便百度等搜索引擎,搜索到您的商品">
                </ShopNum1:TextBox>
            </td>
        </tr>
        <tr>
            <td style="text-align: right">
                关键字：
            </td>
            <td style="left">
                <ShopNum1:TextBox ID="TextBoxKeywords" runat="server" CssClass="textwb" HintInfo="可以添加多个关键字,请用空格隔开"
                    HintTitle="可以添加多个关键字,请用空格隔开" MaxLength="50">
                </ShopNum1:TextBox>
            </td>
        </tr>
        <tr>
            <td style="text-align: right">
                描述：
            </td>
            <td align="left">
                <ShopNum1:TextBox ID="TextBoxDescription" runat="server" Height="120px" Width="500px"
                    TextMode="MultiLine" CssClass="textwb" HintInfo="商品描述,此功能是为了方便百度等搜索引擎,搜索到您的商品"
                    MaxLength="200" HintTitle="商品描述,此功能是为了方便百度等搜索引擎,搜索到您的商品">
                </ShopNum1:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2">
            </td>
        </tr>
        <tr>
            <td align="right" style="line-height: 50px;">
            </td>
            <td align="left">
                <asp:Button ID="ButtonAdd" runat="server" Text="上架商品" CssClass="baocbtn" />
                <input id="ResetGoBack" runat="server" type="button" onclick="javascript:window,location.href='S_ScoreProduct.aspx'"
                    value="返回列表" class="baocbtn" />
            </td>
        </tr>
    </table>
    <asp:HiddenField ID="hiddenGuid" runat="server" />
</div>
<!--弹出层-->
<div class="sp_dialog sp_dialog_out" style="display: none;" id="sp_dialog_outDiv">
    <div class="sp_dialog_cont" style="display: none;" id="sp_dialog_contDiv">
        <div class="sp_tan">
            <h4>
                选择图片</h4>
            <div class="sp_close">
                <a href="javascript:void(0)" onclick=" funClose() "></a>
            </div>
            <div class="clear">
            </div>
        </div>
        <div class="sp_tan_content">
            <iframe src="" id="showiframe" width="100%" height="470" frameborder="0" scrolling="no">
            </iframe>
        </div>
    </div>
</div>
<div>
</div>
<script>
    function showDialog() {
        funOpen();
        $("#showiframe").attr("src", "/Shop/ShopAdmin/S_ShowShopPhoto.aspx?txtid=<%= HiddenFieldProduct.ClientID %>&imgid=<%= ImgOrganizImg.ClientID %>");
    }
</script>
<!--弹出层-->
