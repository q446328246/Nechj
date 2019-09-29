<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="Image_List_Select.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.Image_List_Select" %>

<%@ Import Namespace="ShopNum1.Common" %>
<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="t" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>图片选择框</title>
    <link rel="stylesheet" type="text/css" href="style/css.css" />
    <script type="text/javascript" language="javascript" src="js/CommonJS.js"></script>
    <base target="_self" />
    <script language="javascript" type="text/javascript">
        //设置返回到父窗口的值 
        function ReturnValue(str) {
            var imgsrc = str.src;
            imgsrc = imgsrc.substring(imgsrc.indexOf("ImgUpload") - 1, imgsrc.length);
            if (window.opener != undefined) {
                window.opener.returnValue = imgsrc + "," + imgsrc;
            }
            else {
                window.returnValue = imgsrc + "," + imgsrc;
            }
            window.close();
        } 
    </script>
    <script type="text/javascript">
        var MaxHeight = 80;
        var MaxWidth = 100;

        function AutoOperateImage(ImgD) {
            var image = new Image();
            image.src = ImgD.src;
            if (image.width > 0 && image.height > 0) {
                var rate = (MaxWidth / image.width < MaxHeight / image.height) ? MaxWidth / image.width : MaxHeight / image.height;
                if (rate <= 1) {
                    ImgD.width = image.width * rate;
                    ImgD.height = image.height * rate;
                }
                else {

                    ImgD.width = image.width;
                    ImgD.height = image.height;

                }
            }
        }
        /***********************得到选中的CheckBox的行绑定的值，如Eval("Guid")******************************/
        function GetCheckedBoxValues() {

            var checkedBoxValues = "0";
            var inputs = document.getElementsByTagName("input");
            for (var j = 0; j < inputs.length; j++) {
                if (inputs[j].type == "checkbox" && inputs[j].id != "checkboxAll") {
                    if (inputs[j].checked == true) {
                        checkedBoxValues += ("," + "'" + inputs[j].value + "'");
                    }
                }
            }

            return checkedBoxValues;
        }


        function GetCheckBox(obj) {
            var checkedBoxValues = "0";
            var ImgPath = new Array();
            $("input[type='checkbox']").attr("checked", $(obj).attr("checked"));
            $("input[type='checkbox']:checked").each(function () {
                var scolor = $(this).val();
                checkedBoxValues += ("," + "'" + scolor + "'");
                ImgPath.push($(this).attr("lang"));
            });
            $("#HiddenImgPath").val(ImgPath.join(","));
            return checkedBoxValues;
        }

        /***********************检查删除按钮******************************/
        function DeleteButton() {
            var checkedBoxValues = GetCheckedBoxValues();
            if (checkedBoxValues == "0,'on'") {
                alert("请选择要删除的记录！");
                return false;
            }
            else if (window.confirm("您确定要删除吗?")) {
                document.getElementById("CheckGuid").value = checkedBoxValues.replace('0,', '');
                return true;
            } else {
                return false;
            }
        }
        window.onerror = function () { return true; };
    </script>
    <link href="js/uploadify/uploadify.css" type="text/css" rel="stylesheet" />
    <script type="text/javascript" src="js/uploadify/jquery-1.4.2.min.js"></script>
    <script type="text/javascript" src="js/uploadify/swfobject.js"></script>
    <script type="text/javascript" src="js/uploadify/jquery.uploadify.v2.1.4.min.js"></script>
    <script type="text/javascript" src="js/imgpreview.min.0.22.jquery.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="layer" class="overlay">
    </div>
    <div id="right">
        <div class="rhigth">
            <div class="rl">
            </div>
            <div class="rcon">
                <h3>
                    图片选择框</h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="order_edit">
                <table cellpadding="0" cellspacing="0" border="0">
                    <tr style="height: 35px; vertical-align: middle;">
                        <td>
                            <div id="uploadfile">
                                上传</div>
                            <script type="text/javascript" language="javascript">
                                $(function () {
                                    $("#uploadfile").uploadify({
                                        'uploader': 'js/uploadify/uploadify.swf',
                                        'script': '/Api/Main/ImageOp.ashx?albumid=<%=Common.ReqStr("category") == "" ? "1" : Common.ReqStr("category")%>',
                                        'cancelImg': 'js/uploadify/cancel.png',
                                        'fileExt': '*.jpg;*.gif;*.png',
                                        'fileDesc': 'Image Files',
                                        'auto': true,
                                        'multi': true,
                                        onAllComplete: function (event, queueID, fileObj, response, data) {
                                            window.location.reload();
                                        }
                                    });
                                    //标题提示效果处
                                    var sweetTitles = {
                                        x: 10, y: 20, tipElements: ".editname", init: function () {
                                            $(this.tipElements).mouseover(function (e) {
                                                this.myTitle = this.title; this.title = ""; var tooltip = ""; if (this.myTitle == "") { tooltip = ""; }
                                                else { tooltip = "<div id='tooltip'><p>" + this.myTitle + "</p></div>"; }
                                                $('body').append(tooltip);
                                                $('#tooltip').css({ "opacity": "0.8", "top": (e.pageY + 20) + "px", "left": (e.pageX + 10) + "px" }).show('fast');
                                            }).mouseout(function () { this.title = this.myTitle; $('#tooltip').remove(); }).mousemove(function (e) { $('#tooltip').css({ "top": (e.pageY + 20) + "px", "left": (e.pageX + 10) + "px" }); });
                                        }
                                    };
                                    sweetTitles.init();
                                    $('a').imgPreview({ imgCSS: { width: 300} });
                                });
                            </script>
                        </td>
                        <td colspan="3" class="lmf_padding">
                            点击上传按钮进行图片上传，上传可以选择多个文件一起上传！
                        </td>
                    </tr>
                    <tr style="height: 35px; vertical-align: middle;">
                        <td colspan="2">
                            <asp:Label ID="LabelImageCategory" runat="server" Text="图片分类：" Style="position: relative;
                                *+top: -5px;"></asp:Label>
                            <asp:DropDownList ID="DropDownListImgCategory1" runat="server" CssClass="tselect"
                                Width="100" AutoPostBack="true" OnSelectedIndexChanged="DropDownListImgCategory1_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                        <td class="lmf_padding" style="width: 100px;">
                            <asp:Label ID="Label1" runat="server" Text="图片名称："></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxSName" runat="server" CssClass="tinput"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Button ID="ButtonSearch" runat="server" OnClick="ButtonSearch_Click" Text="查询"
                                CausesValidation="False" CssClass="dele" />
                        </td>
                    </tr>
                </table>
                <table style="width: 100%" cellspacing="1" cellpadding="0" border="0">
                    <tr>
                        <td style="width: 100%" align="left">
                            <asp:DataList ID="DataListShow" runat="server" RepeatDirection="Horizontal" RepeatColumns="6"
                                Width="100%">
                                <ItemTemplate>
                                    <table>
                                        <tr>
                                            <td>
                                                <div>
                                                    <a rel="<%# Page.ResolveUrl(Eval("ImagePath").ToString())%>">
                                                        <img id="loadImg" src='<%# Page.ResolveUrl(Eval("ImagePath").ToString())%>' onload="AutoOperateImage(this)"
                                                            style="width: 100px; height: 38px;" onclick='ReturnValue(this);' alt="" /></a>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" style="width: 90px">
                                                <input id="checkboxItem" value='<%# Eval("Guid") %>' lang='<%#Eval("ImagePath")%>'
                                                    type="checkbox" />
                                                <asp:Label ID="imgName" CssClass="editname" runat="server" ToolTip='<%# Eval("Name") %>'><%# Common.cut(Eval("Name").ToString(),7) %></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                            </asp:DataList>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100%" align="left">
                            <div style="float: left;">
                                <input id="checkboxAll" type="checkbox" onclick="GetCheckBox(this)" />
                                <asp:Button ID="ButtonDel" runat="server" CssClass="dele" Text="删除" OnClientClick="DeleteButton()"
                                    OnClick="ButtonDel_Click" />
                            </div>
                            <!-- 分页部分-->
                            <div class="btconfig" style="text-align: right; background: #e8e8e8; float: right;">
                                &nbsp;<span>转到
                                    <asp:Literal ID="lnkTo" runat="server" />
                                    <asp:DropDownList ID="DropDownListNumSelect" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropDownListNumSelect_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    页</span>
                            </div>
                            <div id="pageDiv" runat="server" class="fpage">
                            </div>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
    <asp:HiddenField ID="CheckGuid" runat="server" Value="0" />
    <asp:HiddenField ID="HiddenImgPath" runat="server" Value="0" />
    </form>
</body>
</html>
