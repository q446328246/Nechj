<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="Image_List.aspx.cs" Inherits="ShopNum1.Deploy.Main.Admin.Image_List" %>

<%@ Import Namespace="ShopNum1.Common" %>
<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="ShopNum1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>图片管理</title>
    <link rel='stylesheet' type='text/css' href='style/css.css' />
    <link id="sizestylesheet" rel='stylesheet' type='text/css' href='style/css1.css' />
    <script src="js/CommonJS.js" type="text/javascript"> </script>
    <script type='text/javascript' src='js/resolution-test.js'> </script>
    <script src="js/tanchuDIV2.js" type="text/javascript"> </script>
    <script type="text/javascript">
        var MaxHeight = 80;
        var MaxWidth = 100;

        function AutoOperateImage(ImgD) {
            $(ImgD).parent().parent().find("#opflag").show();
            $(ImgD).parent().parent().find("#vflag").hide();
        }

        /***********************得到选中的CheckBox的行绑定的值，如Eval("Guid")******************************/

        function GetCheckedBoxValues() {
            var checkedBoxValues = "0";
            var inputs = document.getElementsByTagName("input");
            for (var j = 0; j < inputs.length; j++) {
                if (inputs[j].type == "checkbox" && inputs[j].id != "checkboxAll" && inputs[j].id != "CheckBoxListGroup_0") {
                    if (inputs[j].checked == true) {
                        checkedBoxValues += ("," + "'" + inputs[j].value + "'");
                    }
                }
            }
            return checkedBoxValues;
        }

        /***********************检查删除按钮******************************/

        function DeleteButton() {
            var checkedBoxValues = GetCheckedBoxValues();
            if (checkedBoxValues == "0,'on'") {
                alert("请选择要删除的记录！");
                return false;
            } else if (window.confirm("您确定要删除吗?")) {
                document.getElementById("CheckGuid").value = checkedBoxValues.replace('0,', '');
                return true;
                ;
            } else {
                return false;
            }
        }
    </script>
    <link href="js/uploadify/uploadify.css" type="text/css" rel="stylesheet" />
    <script type="text/javascript" src="js/uploadify/swfobject.js"> </script>
    <script type="text/javascript" src="js/uploadify/jquery.uploadify.v2.1.4.min.js"> </script>
    <link rel="stylesheet" href="style/lightbox.css" type="text/css" media="screen" />
    <script type="text/javascript" src="js/jquery.lightbox.js"> </script>
</head>
<body class="widthah">
    <form id="form1" runat="server">
    <div id="right">
        <div class="rhigth">
            <div class="rl">
            </div>
            <div class="rcon">
                <h3>
                    图片管理</h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="order_edit">
                <table cellpadding="0" cellspacing="0" border="0">
                    <tr style="height: 35px; vertical-align: top;">
                        <td>
                            <div id="uploadfile">
                                上传</div>
                            <script type="text/javascript" language="javascript">
                                $(function () {
                                    $("#uploadfile").uploadify({
                                        'uploader': 'js/uploadify/uploadify.swf',
                                        'script': '/Api/Main/ImageOp.ashx?albumid=<%= Common.ReqStr("category") == "" ? "1" : Common.ReqStr("category") %>',
                                        'cancelImg': 'js/uploadify/cancel.png',
                                        'fileExt': '*.jpg;*.gif;*.png',
                                        'fileDesc': 'Image Files',
                                        'auto': true,
                                        'multi': true,
                                        onAllComplete: function (e, data) {
                                            window.setTimeout(function () {
                                                alert("您成功上传了" + data.filesUploaded + "张图片！");
                                                window.location.reload();
                                            }, 1000);
                                        }
                                    });
                                    //全选
                                    $("#checkall").click(function () {
                                        var ischeck = $(this).is(":checked");
                                        ischeck = ischeck == true ? "反选" : "全选";
                                        $(this).next().text(ischeck);
                                        var checkboxs = document.getElementsByName("checksub");
                                        for (var i = 0; i < checkboxs.length; i++) {
                                            checkboxs[i].checked = $(this).is(":checked");
                                        }
                                    });
                                    //编辑信息
                                    $(".bianji").click(function () {
                                        $("#sp_" + $(this).attr("id")).attr("style", "display:none");
                                        $("#edit_" + $(this).attr("id")).attr("style", "display:block");
                                        $("#edit_" + $(this).attr("lang")).focus();
                                    });
                                    $(".editname").dblclick(function () {
                                        $("#sp_" + $(this).attr("lang")).attr("style", "display:none");
                                        $("#edit_" + $(this).attr("lang")).attr("style", "display:block");
                                        $("#edit_" + $(this).attr("lang")).focus();
                                    });
                                    //失去焦点进行编辑修改
                                    $(".blur_txt").blur(function () {
                                        var guid = $(this).attr("lang");
                                        $.get("?type=1&name=" + escape($(this).val()) + "&id=" + guid, null, function (data) {
                                        });
                                        $("#sp_" + $(this).attr("id")).attr("title", $(this).val());
                                        $("#sp_" + $(this).attr("id")).text(cut($(this).val(), 7));
                                        $("#sp_" + $(this).attr("id")).show();
                                        $("#edit_" + $(this).attr("id")).hide();
                                    });
                                    //标题提示效果处
                                    var sweetTitles = {
                                        x: 10,
                                        y: 20,
                                        tipElements: ".editname",
                                        init: function () {
                                            $(this.tipElements).mouseover(function (e) {
                                                this.myTitle = this.title;
                                                this.title = "";
                                                var tooltip = "";
                                                if (this.myTitle == "") {
                                                    tooltip = "";
                                                } else {
                                                    tooltip = "<div id='tooltip'><p>双击修改-" + this.myTitle + "</p></div>";
                                                }
                                                $('#tooltip').css({ "opacity": "0.8", "top": (e.pageY + 20) + "px", "left": (e.pageX + 10) + "px" }).show('fast');
                                                $('body').append(tooltip);
                                            }).mouseout(function () {
                                                this.title = this.myTitle;
                                                $('#tooltip').remove();
                                            }).mousemove(function (e) { $('#tooltip').css({ "top": (e.pageY + 20) + "px", "left": (e.pageX + 10) + "px" }); });
                                        }
                                    };
                                    sweetTitles.init();
                                    $(".lightbox").lightbox();
                                });

                                function cut(str, len) {
                                    if (str.toString().length >= len)
                                        return str.toString().substring(0, len);
                                    return str;
                                }

                                function DeleteCheck() {
                                    var arryid = new Array();
                                    var arrypath = new Array();
                                    var bflag = true;
                                    $("input[name='checksub']").each(function (m, n) {
                                        if ($(this).is(":checked")) {
                                            arryid.push("'" + $(this).val() + "'");
                                            arrypath.push($(this).attr("lang"));
                                            bflag = false;
                                        }
                                    });
                                    if (bflag) {
                                        alert("请勾选一条数据！");
                                        return false;
                                    } else if (confirm("是否确认删除？")) {
                                        document.getElementById("CheckGuid").value = arryid.join(",");
                                        document.getElementById("CheckImgPath").value = arrypath.join(",");
                                        return true;
                                    }
                                }
                            </script>
                        </td>
                        <td colspan="3" class="lmf_padding">
                            点击上传按钮进行图片上传，上传可以选择多个文件一起上传！
                        </td>
                    </tr>
                    <tr style="height: 35px; vertical-align: top;">
                        <td style="text-align: right;">
                            <asp:Label ID="LabelImageCategory" runat="server" Text="图片分类："></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="DropDownListImgCategory1" runat="server" CssClass="tselect"
                                Width="100" AutoPostBack="true" OnSelectedIndexChanged="DropDownListImgCategory1_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                        <td class="lmf_padding">
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
                <table border="0" cellpadding="0" cellspacing="0" class="shoptable" style="border: none;
                    width: 100%;">
                    <tr>
                        <td style="width: 100%" align="left">
                            <div class="vote" style="padding-left: 2px;">
                                <table cellpadding="0" cellspacing="0" border="0">
                                    <tr>
                                        <td valign="top">
                                            <input type="checkbox" id="checkall" /><label for="checkall">全选</label>
                                        </td>
                                        <td valign="top" style="display: none;">
                                            <asp:LinkButton ID="ButtonEdit" runat="server" CausesValidation="False" CssClass="bt2"
                                                Visible="False"><span>编辑</span></asp:LinkButton>
                                        </td>
                                        <td valign="top" class="lmf_app">
                                            <asp:LinkButton ID="ButtonDelete" runat="server" OnClick="ButtonDelete_Click" CausesValidation="False"
                                                OnClientClick=" return DeleteCheck() " CssClass="shanchu lmf_btn"><span>批量删除</span></asp:LinkButton>
                                        </td>
                                        <td>
                                            <ShopNum1:MessageShow ID="MessageShow" runat="server" Visible="False" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table border="0" cellpadding="0" cellspacing="0" class="list_table" style="border: 1px solid #DCDCDC;
                                margin-top: 10px; width: 100%;">
                                <tr>
                                    <td>
                                        <div style="margin: 10px 10px;">
                                            <asp:DataList ID="DataListShow" runat="server" RepeatDirection="Horizontal" RepeatColumns="7"
                                                Width="100%" HorizontalAlign="Center" RepeatLayout="Flow" OnItemCommand="DataListShow_ItemCommand">
                                                <ItemTemplate>
                                                    <div class="imgcon">
                                                        <div style="background: url(images/lmf_image.jpg) no-repeat 0 0; height: 120px; margin: 0 10px;
                                                            text-align: center; width: 120px;" onmouseover=" AutoOperateImage(this) ">
                                                            <div style="padding: 5px; text-align: center; vertical-align: middle;">
                                                                <a class="lightbox" href='<%# Page.ResolveUrl(Eval("ImagePath").ToString() == "" ? "/ImgUpload/noImage.gif" : Eval("ImagePath").ToString()) %>'
                                                                    title='<%#Eval("Name") %>'>
                                                                    <img id="loadImg" src='<%# Page.ResolveUrl(Eval("ImagePath").ToString() == "" ? "/ImgUpload/noImage.gif" : Eval("ImagePath").ToString()) %>'
                                                                        onerror=" javascript:this.src = '/ImgUpload/noImage.gif'; " width="110" height="110"
                                                                        style="cursor: pointer" />
                                                                </a>
                                                            </div>
                                                        </div>
                                                        <div style="margin: 0 16px;">
                                                            <table cellpadding="0" cellspacing="0" border="0">
                                                                <tr>
                                                                    <td>
                                                                        <input value='<%# Eval("Guid") %>' lang='<%#Eval("ImagePath") %>' type="checkbox"
                                                                            name="checksub" style="margin-right: 2px;" />
                                                                        <asp:HiddenField ID="HiddenFieldGuid" Value='<%# Eval("Guid") %>' runat="server" />
                                                                        <asp:HiddenField ID="HiddenFieldPath" Value='<%# Eval("ImagePath") %>' runat="server" />
                                                                    </td>
                                                                    <td>
                                                                        <span class="editname" title='<%#Eval("Name") %>' id="sp_<%#Container.ItemIndex %>"
                                                                            lang="<%#Container.ItemIndex %>">
                                                                            <%# Common.cut(Eval("Name").ToString(), 7) %></span> <span style="display: none"
                                                                                id="edit_<%#Container.ItemIndex %>">
                                                                                <input type="text" value="<%#Eval("Name") %>" lang='<%# Eval("Guid") %>' id="<%#Container.ItemIndex %>"
                                                                                    class="blur_txt" style="border: 1px solid #bfbfbf; width: 100px;" /></span>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </div>
                                                        <div class="editimg" id="opflag">
                                                            <a class="bianji popup" id="<%#Container.ItemIndex %>" style="cursor: pointer"></a>
                                                            <asp:LinkButton ID="LinkButtonDel" runat="server" CommandName="delete" OnClientClick=" return confirm('是否确认删除?') "
                                                                CssClass="deledte"></asp:LinkButton>
                                                        </div>
                                                    </div>
                                                </ItemTemplate>
                                            </asp:DataList>
                                            <% if (DataListShow.Items.Count == 0)
                                               { %>
                                            <div>
                                                <center>
                                                    <strong>没有搜索到相关数据！</strong></center>
                                            </div>
                                            <% } %>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 100%" align="left">
                                        <!-- 分页部分-->
                                        <div class="btnlist">
                                            <div class="fnum">
                                                每页显示数量：<asp:LinkButton ID="LinkButton10" runat="server" OnClick="LinkButton10_Click">10</asp:LinkButton><asp:LinkButton
                                                    ID="LinkButton20" OnClick="LinkButton20_Click" runat="server">20</asp:LinkButton><asp:LinkButton
                                                        ID="LinkButton100" OnClick="LinkButton100_Click" runat="server">100</asp:LinkButton>
                                            </div>
                                            <div id="pageDiv" runat="server" class="fpage">
                                            </div>
                                            <div style="display: none;">
                                                到第<asp:TextBox ID="TextBoxIndex" Style="width: 35px;" runat="server"></asp:TextBox>页<asp:Button
                                                    ID="ButtonIndex" runat="server" OnClick="ButtonIndex_Click" CssClass="quedbtn"
                                                    Text="确定" /></div>
                                            <div class="clear">
                                            </div>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
    <!--[if lte IE 6]>
                <iframe style="-moz-opacity: 0; filter: alpha(opacity=0); height: 87px; left: 300px; opacity: 0; position: absolute; top: 0px; width: 500px; z-index: 0;" border="0" frameborder="0"></iframe>
            <![endif]-->
    <asp:HiddenField ID="CheckGuid" runat="server" Value="0" />
    <asp:HiddenField ID="CheckImgPath" runat="server" Value="0" />
    <asp:HiddenField ID="HiddenFieldBianji" runat="server" Value="0" />
    <asp:HiddenField ID="HiddenFieldPath" runat="server" Value="0" />
    </form>
</body>
</html>
