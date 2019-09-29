<%@ Control Language="C#" AutoEventWireup="True" CodeBehind="M_AddProductComment.ascx.cs"
    Inherits="ShopNum1.Deploy.Main.Member.Skin.M_AddProductComment" %>
<%@ Import Namespace="ShopNum1.Deploy.Main.Member.Skin" %>
<%@ Import Namespace="System.Data" %>
<% DataTable dt = M_AddProductComment.dt_Continue; %>
<style type="text/css">
    input, img, label
    {
        cursor: pointer;
    }
</style>
<!--内容部分Content-->
<div id="content_bg">
    <div class="con_order">
        <div class="zjh1_1">
            <%-- <h1><a href="#" >评价须知</a></h1>--%>
            <div class="zjbk">
                <%if (dt != null)
                  {%>
                <%for (int i = 0; i < dt.Rows.Count; i++)
                  {%>
                <!--循环代码-->
                <dl class="zjpro">
                    <dt><a href="#">
                        <img src="<%=dt.Rows[i]["img"] %>" width="130" height="130" onerror="javascript:this,src='/ImgUpload/noImg.jpg_100x100.jpg'" /></a></dt>
                    <dd>
                        <a href="#" class="blue">
                            <%=dt.Rows[i]["productname"] %></a>
                    </dd>
                </dl>
                <div class="fabiaok1">
                    <div class="fbcommenttype">
                        <span class="commenttype">
                            <%=dt.Rows[i]["commenttype"]%></span><span class="commentcontent"><%=dt.Rows[i]["comment"]%></span><span
                                class="commentdate">[<%=Convert.ToDateTime(dt.Rows[i]["commenttime"]).ToString("yyyy-MM-dd")%>]</span></div>
                    <div class="fbtext">
                        <textarea name="TextBoxComment" rows="2" cols="20" class="text_fb" lang="<%=dt.Rows[i]["productguid"] %>"></textarea>
                    </div>
                </div>
                <div style="clear: both;">
                </div>
                <!--循环代码-->
                <%}
                  } %>
            </div>
            <div style="text-align: center;">
                <asp:Button ID="btnSave" CssClass="zhuijbtn1" OnClientClick="return subcheck()" runat="server"
                    OnClick="btnSave_Click" />
            </div>
        </div>
    </div>
</div>
<input type="hidden" id="hidCommentC" runat="server" />
<input type="hidden" id="hidPGuid" runat="server" />
<script type="text/javascript" language="javascript">
    $(function () {
        $(".commenttype").each(function () {
            switch ($(this).text()) {
                case "5": $(this).text("好评"); break;
                case "3": $(this).text("中评"); break;
                case "1": $(this).text("差评"); break;
            }
        });
        $("textarea[name='TextBoxComment']").focus(function () {
            if ($(this).val() == "宝贝用的好吗?来分享一下您的使用感受吧！") {
                $(this).val("");
            }
        });
    });
    function subcheck() {
        var specV = new Array();
        var xcheck = new Array();
        var pcontent = new Array();
        $("textarea[name='TextBoxComment']").each(function () {
            if ($(this).val().length > 500) {
                $(this).focus(); alert("评论内容不能超过500字！"); return false;
            }
            pcontent.push($(this).val().replace(",", ""));
            xcheck.push($(this).attr("lang"));
        });
        $("#<%=hidCommentC.ClientID%>").val(pcontent.join(","));
        $("#<%=hidPGuid.ClientID%>").val(xcheck.join(","));
        return true;
    }
</script>
