<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="M_MemberUpgrade5.ascx.cs"
    Inherits="ShopNum1.Deploy.Main.Member.Skin.M_MemberUpgrade5" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="t" %>
<%@ Import Namespace="ShopNum1.Common" %>
<!--    <asp:ScriptManager ID="ScriptManager1" EnableScriptGlobalization="true" EnableScriptLocalization="true"
                               runat="server">
            </asp:ScriptManager>-->
<div id="content" class="ordmain1">
    <script type="text/javascript" language="javascript">
        $(document).ready(
  function () {
      // 加载区域
      $("#p_local").LocationSelect();

  }
  );

  function funUpdateImage1() {
      var falt = false;
      var f1 = $("#M_MemberUpgrade5_FileUploadIdentityCardImage").val();
      //表示个人
      var HiddenIdentityCardValue = $("#M_MemberUpgrade5_FileUploadIdentityCardImage").val();
      if (HiddenIdentityCardValue == "") {
          if (f1 != "") {
              var fjcheck = f1.substring(f1.lastIndexOf(".") + 1); //获取后缀名
              if (fjcheck == "jpg" || fjcheck == "jpeg" || fjcheck == "png" || fjcheck == "gif") {
                  $("#errIdentityCardimage").html("");
                  falt = true;
              } else {
                  $("#errIdentityCardimage").html("图片格式必须为jpg、jpeg、png、gif！");
                  falt = false;
              }

          } else {
              $("#errIdentityCardimage").html("申请个人店铺必须上传身份证正反面图片！");
              falt = false;
          }
      } else {
          $("#errIdentityCardimage").html("");
          falt = true;
      }
      return falt;
  }

 
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            check();

            $(":radio").click(function () {
                check();
            });

            function check() {
                if ($("input[name='M_MemberUpgrade5$radbutton']").attr("checked") == 'checked') {

                    var Belongs = document.getElementById("<%=TextBoxBelongs.ClientID %>");
                    Belongs.disabled = true;
                    Belongs.style.display = "none";
                    $("span[name='belongs']").hide();
                    $("span[name='belong']").hide();

                } else {

                    var Belongs = document.getElementById("<%=TextBoxBelongs.ClientID %>");
                    Belongs.disabled = false;
                    Belongs.style.display = "block";
                    $("span[name='belongs']").show();
                    $("span[name='belong']").show();
                }
            }
        });  
</script>
    <div class="pad">
        <table border="0" cellspacing="0" cellpadding="0" class="lineh">
            <tr class="up_spac">
                <td align="right">
                    请选会员类型：
                </td>
                <td width="150">
                    <asp:RadioButton GroupName="radbutton" ID="RadioButtonAgentMember" name="RadioButtonAgentMember" runat="server"
                        Checked="True" />&nbsp;&nbsp;<span style="font-size: 15px; color: red;">区代理</span>
                </td>
                <td>
                </td>
                <td width="150">
                    <asp:RadioButton GroupName="radbutton" ID="RadioButtonCommunityMember" 
                        name="RadioButtonCommunityMember" runat="server"  />&nbsp;&nbsp;<span
                        style="font-size: 15px; color: red;">社区店铺</span>
                </td>
                <td width="50">
                </td>
            </tr>
            <tr class="up_spac">
                <td align="right">
                    区代名称：
                </td>
                <td width="150">
                    <asp:TextBox ID="TextBoxShopNames" name="TextBoxShopNames" runat="server" 
                        class="ss_nr1" MaxLength="32"></asp:TextBox>
                </td>
                <td align="right"  id="belong" name="belong">
                   <span id="belongs" name="belongs">上级区代：</span>
                </td>
                <td width="150">
                    <asp:TextBox ID="TextBoxBelongs" name="TextBoxBelongs" runat="server" 
                        class="ss_nr1" MaxLength="32"></asp:TextBox>
                </td>
                <td width="50">
                </td>
            </tr>
            <tr class="up_spac">
                <td align="center" colspan="5" style="border-left: 1px solid #C6DFFF; border-top: 1px solid #C6DFFF;
                    border-right: 1px solid #C6DFFF;">
                    <span style="font-size: 15px; color: red;">申请人基本资料</span>
                </td>
            </tr>
            <tr class="up_spac">
                <td align="right" style="border-left: 1px solid #C6DFFF;">
                    姓名：
                </td>
                <td width="150">
                    <asp:TextBox ID="TextBoxName" runat="server" class="ss_nr1" MaxLength="32"></asp:TextBox>
                </td>
                <td align="right">
                    &nbsp;&nbsp;会员编号：
                </td>
                <td width="150">
                    <asp:TextBox ID="TextBoxMemLoginID" runat="server" class="ss_nr1" 
                        MaxLength="32"></asp:TextBox>
                </td>
                <td width="50" style="border-right: 1px solid #C6DFFF;">
                </td>
            </tr>
            <tr class="up_spac">
                <td align="right" style="border-left: 1px solid #C6DFFF;">
                    生日：
                </td>
                <td width="150">
                    <%--<asp:TextBox ID="TextBoxBirthday" runat="server" CssClass="ss_nr1" Width="198" 
                        MaxLength="32"></asp:TextBox>
                    <img id="imgCalendarSReplyTime1" alt="UserName" src="/ImgUpload/Calendar.png" style="height: 18px;
                        position: relative; top: 3px; width: 16px;" />
                    <t:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="TextBoxBirthday"
                        PopupButtonID="imgCalendarSReplyTime1" />--%>

                        
                                        <asp:TextBox ID="TextBoxBirthday" runat="server" CssClass="ss_nr1" Width="198" 
                        MaxLength="32"></asp:TextBox>
                                    
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidatorStartDate" runat="server"
                                            ControlToValidate="TextBoxBirthday" Display="Dynamic" ErrorMessage="时间格式不正确"
                                            ValidationExpression="^((((1[6-9]|[2-9]\d)\d{2})-(0?[13578]|1[02])-(0?[1-9]|[12]\d|3[01]))|(((1[6-9]|[2-9]\d)\d{2})-(0?[13456789]|1[012])-(0?[1-9]|[12]\d|30))|(((1[6-9]|[2-9]\d)\d{2})-0?2-(0?[1-9]|1\d|2[0-9]))|(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))-0?2-29-))( (20|21|22|23|[0-1]?\d):[0-5]?\d:[0-5]?\d)?$"></asp:RegularExpressionValidator>
                                    
                                    
                                        <img id="imgCalendarSReplyTime1" alt="" src="/ImgUpload/Calendar.png" style="width: 16px;
                                            height: 18px; position: relative; top: 3px;" />
                                    
                                        <t:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="TextBoxBirthday"
                                            PopupButtonID="imgCalendarSReplyTime1" CssClass="ajax__calendar" Format="yyyy-MM-dd">
                                        </t:CalendarExtender>
                                    
                </td>
                <td align="right">
                    &nbsp;&nbsp;身份证号：
                </td>
                <td width="150">
                    <asp:TextBox ID="TextBoxCardID" runat="server" class="ss_nr1" MaxLength="32"></asp:TextBox>
                </td>
                <td width="50" style="border-right: 1px solid #C6DFFF;">
                </td>
            </tr>
            <tr class="up_spac">
                <td align="right" style="border-left: 1px solid #C6DFFF;">
                    性别：
                </td>
                <td width="150">
                    <asp:TextBox ID="TextBoxSex" runat="server" class="ss_nr1" MaxLength="32"></asp:TextBox>
                </td>
                <td align="right">
                    &nbsp;&nbsp;电话：
                </td>
                <td width="150">
                    <asp:TextBox ID="TextBoxPhone" runat="server" class="ss_nr1" MaxLength="32"></asp:TextBox>
                </td>
                <td width="50" style="border-right: 1px solid #C6DFFF;">
                </td>
            </tr>
            <tr class="up_spac">
                <td align="right" style="border-left: 1px solid #C6DFFF;">
                    手机：
                </td>
                <td width="150">
                    <asp:TextBox ID="TextBoxMobile" runat="server" class="ss_nr1" MaxLength="32"></asp:TextBox>
                </td>
                <td align="right">
                    曾从事职业：
                </td>
                <td width="150">
                    <asp:TextBox ID="TextBoxOccupation" runat="server" class="ss_nr1" 
                        MaxLength="32"></asp:TextBox>
                </td>
                <td width="50" style="border-right: 1px solid #C6DFFF;">
                </td>
            </tr>
            <tr class="up_spac">
                <td align="right" style="border-left: 1px solid #C6DFFF;">
                    现居住地：
                </td>
                <td width="150" colspan="3">
                    <asp:TextBox ID="TextBoxAdress" runat="server" class="ss_nr1" Width="550" 
                        MaxLength="32"></asp:TextBox>
                </td>
                <td width="50" style="border-right: 1px solid #C6DFFF;">
                </td>
            </tr>
            <tr class="up_spac">
                <td align="right" style="border-left: 1px solid #C6DFFF; border-bottom: 1px solid #C6DFFF;">
                    拟申办代理地址：
                </td>
                <td width="150" colspan="2" style="border-bottom: 1px solid #C6DFFF;">
                    <div id="p_local" style="float: left;">
                    </div>
                    <span class="star" style="float: left;" id="diqu"></span>
                </td>
                <td style="border-bottom: 1px solid #C6DFFF;">
                    <asp:TextBox ID="TextBoxAdresss" runat="server" class="ss_nr1" MaxLength="32"></asp:TextBox>
                </td>
                <td width="50" style="border-right: 1px solid #C6DFFF; border-bottom: 1px solid #C6DFFF;">
                </td>
            </tr>
            <%--<tr class="up_spac">
                <td style="border-left: 1px solid #C6DFFF;border-top: 1px solid #C6DFFF; ">
                    上传身份证：
                </td>
                <td colspan="3" style="border-top: 1px solid #C6DFFF; ">
                    <asp:FileUpload ID="FileUploadIdentityCardImage" runat="server" onchange="funUpdateImage1()" /><span
                        class="gray1" id="errIdentityCardimage" style="color: red">&nbsp;</span>
                        
                </td>
                <td width="50" style="border-right: 1px solid #C6DFFF;border-top: 1px solid #C6DFFF;">
                </td>
            </tr>
            <tr class="up_spac">
                
                <td colspan="4" style="border-bottom: 1px solid #C6DFFF;border-left: 1px solid #C6DFFF;">
                    <span
                        class="gray1" id="errIdentityCardimage" style="color: red">&nbsp;格式jpg，jpeg，png，gif，请保证图片清晰且文件大小不超过500KB</span>
                        
                </td>
                <td width="50" style="border-right: 1px solid #C6DFFF; border-bottom: 1px solid #C6DFFF;">
                </td>
            </tr>--%>
            <tr class="up_spac">
                <td></td><td></td><td><asp:Button ID="ButtonUpgrade" runat="server" Text="申请" class="chax btn_spc" name="12"
        OnClick="ButtonUpgrade_Click" OnClientClick="return  checkSumbitDetil()" /></td><td>
                    <asp:Button ID="Button1" runat="server" class="chax btn_spc" name="12" 
                        onclick="Button1_Click" style="height: 21px" Text="重置" />
                </td><td></td>

            </tr>
        </table>
    </div>
</div>
<script type="text/javascript" language="javascript">
    function checkSumbitDetil() {

        var info = $("#p_local").getLocation();
        if (info.pcode == "0") {
            $("#p_local").next().show();
        }
        $("#<%=hid_AreaValue.ClientID%>").val(info.province + "," + info.city + "," + info.district + "|" + info.pcode + "," + info.ccode + "," + info.dcode);
        if (info.dcode != "0") {
            $("#<%=hid_AreaCode.ClientID%>").val(info.dcode);

        }
        else {
            if (info.ccode != "0") {
                $("#<%=hid_AreaCode.ClientID%>").val(info.ccode);

            }
            else {
                $("#<%=hid_AreaCode.ClientID%>").val(info.pcode);
            }
        };

        if ($("#<%=hid_AreaValue.ClientID%>").val() == ",,|0,0,0") {
            $("#p_local").next().text("*请填写地区信息");
            return false;
        }
        else {
            if ($("#<%=hid_AreaCode.ClientID%>").val().length == 3 && $("select[name='city']").find("option").size() != 1) {
                $("#p_local").next().text("*请填写城市信息");
                return false;
            }
            if ($("#<%=hid_AreaCode.ClientID%>").val().length == 6 && $("select[name='district']").find("option").size() != 1) {
                $("#p_local").next().text("*请填写区域信息");
                return false;
            }
        };

    }
    </script>
    <script type="text/javascript" language="javascript">
    $(document).ready(
        function () {
            var area = $("#<%=hid_AreaValue.ClientID%>").val().split("|");
            var areaCode = $("#<%=hid_AreaCode.ClientID%>").val();
            var code1;
            var code2;
            var code3;
            if (areaCode.length > 8) {
                //areaCode 有三级
                code1 = areaCode.substring(0, 3);
                code2 = areaCode.substring(4, 6);
                code3 = areaCode.substring(7, 9);
            }
            if ($("#<%=hid_AreaValue.ClientID%>").val() != "") {
                var areacode = area[1].split(",");
                var areaname = area[0].split(",");
                if (areaname[0] != "")
                    $("select[name='province']").append("<option value=\"" + code1 + "\" selected=\"selected\">" + areaname[0] + "</option>");
                if (areaname[1] != "")
                    $("select[name='city']").append("<option value=\"" + code2 + "\" selected=\"selected\">" + areaname[1] + "</option>");
                if (areaname[2] != "")
                    $("select[name='district']").append("<option value=\"" + code3 + "\" selected=\"selected\">" + areaname[2] + "</option>");
            }

        });

       
</script>
<input id="hid_AreaCode" type="hidden" runat="server" value="" />
<input id="hid_AreaValue" type="hidden" runat="server" value="" />
