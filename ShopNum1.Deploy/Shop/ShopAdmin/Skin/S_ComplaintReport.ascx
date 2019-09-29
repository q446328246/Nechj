<%@ Control Language="C#" %>
<%@ Import Namespace="ShopNum1.ShopAdminWebControl" %>
<script src="../js/jquery-1.6.2.min.js" type="text/javascript"> </script>
<script type="text/javascript">
    //证据
    function funCheckEvidence() {
        var Evidence = $("#S_ComplaintReport_ctl00_TextBoxEvidence").val();
        if (Evidence != "") {
            $("#errEvidence").html("*");
            $("#errEvidence").css("color", "red");
            return true;
        } else {
            $("#errEvidence").html("证据不能为空！");
            $("#errEvidence").css("color", "red");
            return false;
        }
    }

    function FunCheckButton() {
        if (funCheckEvidence()) {
            return true;
        } else {
            return false;
        }
    }

</script>
<div class="biaogenr">
    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="biaod" style="margin-top: 15px;">
        <tr>
            <th colspan="2" scope="col">
                我要申诉
            </th>
        </tr>
        <tr>
            <td class="bordleft" colspan="2" style="text-align: left">
                &nbsp;&nbsp;&nbsp;举报信息：
            </td>
        </tr>
        <asp:Repeater ID="RepeaterShow" runat="server">
            <ItemTemplate>
                <tr>
                    <td class="bordleft" width="130">
                        举报编号：
                    </td>
                    <td class="bordrig">
                        <%#Eval("ID") %>
                    </td>
                </tr>
                <tr>
                    <td class="bordleft" width="130">
                        举报人：
                    </td>
                    <td class="bordrig">
                        <%#Eval("MemLoginID") %>
                    </td>
                </tr>
                <tr>
                    <td class="bordleft" width="130">
                        举报类型：
                    </td>
                    <td class="bordrig">
                        <%#Eval("ReportType") %>
                    </td>
                </tr>
                <tr>
                    <td class="bordleft" width="130">
                        举报证据：
                    </td>
                    <td class="bordrig">
                        <%#Eval("Evidence") %>
                    </td>
                </tr>
                <tr>
                    <td class="bordleft" width="130">
                        证据图片：
                    </td>
                    <td class="bordrig">
                        <asp:Image ID="ImageJB" runat="server" Width="260" Height="200" ImageUrl='<%#Eval("EvidenceImage") %>' />
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
        <tr>
            <td class="bordleft" colspan="2" style="text-align: left">
                &nbsp;&nbsp;&nbsp;申诉信息：
            </td>
        </tr>
        <tr>
            <td class="bordleft">
                申诉证据：
            </td>
            <td class="bordrig" style="padding-top: 8px;">
                <asp:TextBox ID="TextBoxEvidence" runat="server" TextMode="MultiLine" onblur="funCheckEvidence()"
                    CssClass="op_area"></asp:TextBox>
                <span class="red" id="errEvidence">*</span>
            </td>
        </tr>
        <tr>
            <td class="bordleft" style="border-bottom: solid 1px #c6dfff;">
                申诉图片：
            </td>
            <td class="bordrig" style="border-bottom: solid 1px #c6dfff;">
                <asp:FileUpload ID="FileUploadImage" runat="server" name="fileField" />
                <span class="red">*</span><span>上传图片不超过5M，上传图片支持gif、jpg、png、bmp格式。</span>
            </td>
        </tr>
        <tr runat="server" id="trResult" visible="false">
            <td colspan="2" style="color: Red; font-size: 16px; font-weight: bold; text-align: center">
                平台已经处理,处理结果请查看详细！
            </td>
        </tr>
    </table>
    <div class="op_btn">
        <asp:Button ID="ButtonSubmit" runat="server" Text="确定" CssClass="baocbtn" OnClientClick=" return FunCheckButton() " />
        <asp:Button ID="ButtonBackList" runat="server" Text="返回" CssClass="baocbtn" />
    </div>
</div>
<asp:HiddenField ID="HiddenFieldMember" runat="server" Value="no" />
