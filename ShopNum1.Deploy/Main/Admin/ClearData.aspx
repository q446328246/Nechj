<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="ClearData.aspx.cs" Inherits="ShopNum1.Deploy.Main.Admin.ClearData" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link rel="stylesheet" type="text/css" href="style/css.css" />
    <title>�����������</title>
    <style type="text/css">
        <!
        -- body, td, th
        {
            font-size: 12px;
        }
        .welcome
        {
            margin:0;
        }
        .welcome .title
        {
            line-height: 30px;
            height: 30px;
            margin-left: 23px;
            background-color: #eeeeee;
            width: 80px;
            text-align: center;
            font-weight: bold;
            border: 1px solid #6699cc;
            border-bottom: none;
        }
        .welcome .describe
        {
            line-height: 30px;
            height: 30px;
        }
    
        .welcome .content .product
        {
            margin-bottom: 10px; 
        
        } 
        .welcome .content .product .product_title
        {
            background-color: #f2f9fd;
            font-weight: bold;
            padding-left: 6px;
        }
        -- >
        .orinput{border: 1px solid #DCDCDC;
    height: 22px;
    line-height: 22px;
    margin-right: 10px;
    width: 80px;}
        </style>
    <link type="text/css" rel="Stylesheet" href="css/index.css" />
    <script src="js/CommonJS.js" type="text/javascript"></script>
    <script src="../js/jquery-1.6.2.min.js" type="text/javascript"></script>
    <script>

        $(document).ready(function () {
            //var tables= $("#<%=hiddenFieldCheckedClearData.ClientID%>").val("");
            //$(":checkbox[name='ClearData']").change(function(){

            //WritehiddenFieldCheckedClearData();
            //})

            //$("#CheckboxCheckAll").change(function(){
            //var CheckboxCheckAll=$("#CheckboxCheckAll").get(0).checked; 
            //$(":checkbox[name='ClearData']").attr("checked",CheckboxCheckAll);


            $("#<%=CheckboxCheckAll.ClientID %>").change(function () {
                var checkbox = $("span[name='ClearData']").find(":checkbox");
                for (i = 0; i < checkbox.length; i++) {
                    checkbox[i].checked = true
                }

                //writehiddenfieldcheckedcleardata();

            })


            //��hiddenFieldCheckedClearData ��ֵ
            function WritehiddenFieldCheckedClearData() {
                var Checkedvalues = "";
                var checkbox = $(":checkbox[name='ClearData']");
                for (i = 0; i < checkbox.length; i++) {
                    if (checkbox[i].checked == true) {
                        Checkedvalues += checkbox[i].value + ";";
                    }
                }
                if (Checkedvalues.length > 0) {
                    Checkedvalues = Checkedvalues.substr(0, Checkedvalues.length - 1);

                }
                $("#<%=hiddenFieldCheckedClearData.ClientID%>").val(Checkedvalues);
            }
        })
        //�ж��Ƿ���ѡҪ���������
        function CheckClearData() {
            var tables = $("#<%=hiddenFieldCheckedClearData.ClientID%>").val();
            if (tables.length > 0) {
                return true;
            }
            alert("��ѡ��Ҫ���������");
            return false;
        }
    </script>
</head>
<body style="padding: 0; background-image: url(images/Bg_right.gif); background-repeat: repeat;
    font-size: 12px">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div id="right">
        <div class="rhigth">
            <div class="rl">
            </div>
            <div class="rcon">
                <h3>
                    �����������</h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix" style="padding-left: 20px; padding-right: 20px;">
            <p style="color: #333333; margin-top: 0px; border-bottom: 1px dashed #cccccc; width: 100%;
                padding-bottom: 10px; font-size: 13px;">
                ������ͨ���˹��ܽ���װϵͳʱ����װ����������ȫ��ɾ��,ɾ�������ݰ�����Ʒ����,��Ʒ����,��Ʒ����,��Ѷ���ݵȡ�<br />
                ע�⣺<span style="color: #666666; font-size: 12px;">��������ӵ�����Ҳ��һ��ɾ��,������ʹ�ô˹���,�������������ݱ��ݡ�</span>
            </p>
            <div class="welcome">
                <div class="content">
                    <div class="product ">
                        <div class="product_content">
                            <table width="100%" border="0" cellspacing="1" cellpadding="0" bgcolor="ffffff">
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <tr>
                                            <td colspan="2" style="padding-left: 52px; color: #2672ac; padding-top: 10px;">
                                                ȫѡ/ȡ����<asp:CheckBox ID="CheckboxCheckAll" name="CheckAll" runat="server" Visible="false" />
                                                <input id="checkboxAll" onclick="javascript: SelectAllCheckboxes(this);" type="checkbox"
                                                    runat="server" />
                                                <%--   <input id="CheckboxCheckAll"   name="CheckAll" type="checkbox"  />--%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" style="padding-left: 52px; color: #2672ac;">
                                                <!--;ShopNum1_SpecificationManagement;ShopNum1_SpecificationDetails-->
                                                ��Ʒ���ݣ�<asp:CheckBox ID="CheckboxProduct" name="ClearData" runat="server" /><span style="color: #666666;">
                                                    <span style="color: #ff0000;">* </span>��Ʒ����,������Ʒ����,ͼƬ,����,��������,��Ʒ����,ֱͨ������,������,��Ʒ����</span>
                                                <%--  <input id="CheckboxProduct"  name="ClearData" type="checkbox" value="ShopNum1_Shop_Product;ShopNum1_ProductCategory;ShopNum1_Shop_ProductCategory;ShopNum1_ProductCategoryAndProductBranDrelation;ShopNum1_ShopProductProp;ShopNum1_ShopProductRelationProp;ShopNum1_ShopProductPropValue;ShopNum1_SpecificationProudct;ShopNum1_SpecificationProductImage;ShopNum1_TbItem;ShopNum1_TbSystem;ShopNum1_OrderInfo;ShopNum1_OrderProduct;ShopNum1_OrderOperateLog" /><span style=" color:#666666;"> <span style="color:#ff0000;">* </span>��Ʒ����,������Ʒ����,ͼƬ,����,��������</span>--%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" style="padding-left: 52px; color: #2672ac;">
                                                Ʒ�����ݣ�<asp:CheckBox ID="CheckboxCategoryAndBrand" name="ClearData" runat="server" /><span
                                                    style="color: #666666;"> <span style="color: #ff0000;">* </span>��ƷƷ��</span>
                                                <%--  <input id="CheckboxCategoryAndBrand"   name="ClearData"type="checkbox" value="ShopNum1_Brand;ShopNum1_ProductCategoryAndProductBranDrelation" /><span style=" color:#666666;"> <span style="color:#ff0000;">* </span>��ƷƷ��</span>--%>
                                            </td>
                                        </tr>
                                        <%-- <tr>
                        <td colspan="2"  style="padding-left:136px;color:#2f7ecc;">
                           �������ݣ�<input id="CheckboxOrder"  name="ClearData" type="checkbox" value="ShopNum1_OrderInfo;ShopNum1_OrderProduct;ShopNum1_OrderOperateLog" /><span style=" color:#666666;"> <span style="color:#ff0000;">* </span>��������������¼������</span>
                        </td>
                        </tr>--%>
                                        <tr>
                                            <td colspan="2" style="padding-left: 52px; color: #2672ac;">
                                                ��Ա���ݣ�<asp:CheckBox ID="CheckboxMem" name="ClearData" runat="server" /><span style="color: #666666;">
                                                    <span style="color: #ff0000;">* </span>��Ա��Ϣ,��ԱԤ����ʷ,ǩ��������Ϣ,�ȼ���������,���Ѻ�������,�������,������Ϣ,��������,ϵͳ��̨������־,����������־,�û��������¼,��Ʒ����,����������Ա�ȼ�</span>
                                                <%--<input id="CheckboxMem"  name="ClearData" type="checkbox" value="ShopNum1_Member;ShopNum1_MessageBoard;ShopNum1_Address;ShopNum1_AdvancePaymentFreezeLog;ShopNum1_AdvancePaymentApplyLog;ShopNum1_MemberGroup;ShopNum1_MemberAssignGroup;ShopNum1_AdvancePaymentModifyLog;ShopNum1_RankScoreModifyLog" /><span style=" color:#666666;"> <span style="color:#ff0000;">* </span>��Ա��Ϣ,����������Ա�ȼ�</span>--%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" style="padding-left: 52px; color: #2672ac;">
                                                �������ݣ�<asp:CheckBox ID="CheckboxShop" name="ClearData" runat="server" /><span style="color: #666666;">
                                                    <span style="color: #ff0000;">* </span>������Ϣ,��������,���̱�֤,�������뵣���б�,�����������̵ȼ�</span>
                                                <%--<input id="CheckboxShop"  name="ClearData" type="checkbox" value="ShopNum1_ShopInfo;ShopNum1_ShopRank;ShopNum1_ShopReputation;ShopNum1_ShopCategory;ShopNum1_ShopEnsure" /><span style=" color:#666666;"> <span style="color:#ff0000;">* </span>������Ϣ,���̵ȼ�,���̷���,��������,���̱�֤</span>--%>
                                            </td>
                                        </tr>
                                        <%-- <tr>
                        <td colspan="2"  style="padding-left:124px;color:#2f7ecc;">
                        ��չ�Ӧ�̣�<input id="CheckboxSupplier"  name="ClearData" type="checkbox" value="ShopNum1_SupplierFinancialManagement;ShopNum1_SupplierRepertoryRecord;ShopNum1_SupplierImagePath;ShopNum1_SupplierImage;ShopNum1_SupplierImage_Type;ShopNum1_Product;ShopNum1_SupplierProductCategory;ShopNum1_SupplierCategoryRelated;ShopNum1_SupplierImageCategory;ShopNum1_Supplier;ShopNum1_SupplierOrderProduct" /><span style=" color:#666666;"> <span style="color:#ff0000;">* </span>��Ӧ������,������Ӧ����Ʒ����Ʒ���ࡢ��ƷͼƬ</span>
                         </td>
                        </tr>--%>
                                        <tr>
                                            <td colspan="2" style="padding-left: 52px; color: #2672ac;">
                                                ͼƬ���ݣ�<asp:CheckBox ID="CheckboxImage" name="ClearData" runat="server" /><span style="color: #666666;">
                                                    <span style="color: #ff0000;">* </span>ͼƬ,ͼƬ����,ͼƬ·��</span>
                                                <%--<input id="CheckboxImage"  name="ClearData" type="checkbox" value="ShopNum1_Image;ShopNum1_Image_Type;ShopNum1_ImageCategory" /><span style="color:#666666;"> <span style="color:#ff0000;">* </span>ͼƬ,ͼƬ����,ͼƬ·��</span>--%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" style="padding-left: 52px; color: #2672ac;">
                                                ��Ѷ���ݣ�<asp:CheckBox ID="CheckboxArticle" name="ClearData" runat="server" /><span style="color: #666666;">
                                                    <span style="color: #ff0000;">* </span>��Ѷ,��Ѷ����,��Ѷ���,����</span>
                                                <%--<input id="CheckboxArticle"  name="ClearData" type="checkbox" value="ShopNum1_Article;ShopNum1_ArticleComment;ShopNum1_RelatedArticle" /><span style=" color:#666666;"> <span style="color:#ff0000;">* </span>��Ѷ,��Ѷ����,��Ѷ���</span>--%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" style="padding-left: 52px; color: #2672ac;">
                                                ��Ƶ���ݣ�<asp:CheckBox ID="CheckboxVideo" name="ClearData" runat="server" /><span style="color: #666666;">
                                                    <span style="color: #ff0000;">* </span>��Ƶ,��Ƶ����,��Ƶ����</span>
                                                <%--<input id="CheckboxVideo"  name="ClearData" type="checkbox" value="ShopNum1_Shop_Video;ShopNum1_Shop_VideoCategory;ShopNum1_Shop_VideoComment" /><span style="color:#666666;"> <span style="color:#ff0000;">* </span>��Ƶ,��Ƶ����,��Ƶ����</span>--%>
                                            </td>
                                        </tr>
                                        <%-- <tr>
                        <td colspan="2"  style="padding-left:136px;color:#2f7ecc;">
                            ����̳ǣ�<asp:CheckBox ID="CheckboxScore" runat="server" /><span style="color:#666666;"> <span style="color:#ff0000;">* </span>�������,�����Ʒ,������ﳵ,���������Ʒ,�����Ʒ����</span>
                            <%--<input id="CheckboxScore"  name="ClearData" type="checkbox" value="ShopNum1_Shop_ScoreProduct;ShopNum1_Shop_ScoreProductCategory" /><span style="color:#666666;"> <span style="color:#ff0000;">* </span>�������,�����Ʒ,������ﳵ,���������Ʒ,�����Ʒ����</span>
                         </td>
                        </tr>--%>
                                        <tr>
                                            <td colspan="2" style="padding-left: 52px; color: #2672ac;">
                                                վ����Ϣ��<asp:CheckBox ID="CheckboxAgentMessage" name="ClearData" runat="server" /><span
                                                    style="color: #666666;"> <span style="color: #ff0000;">* </span>��̨վ����Ϣ,��Ավ����Ϣ,ϵͳ������Ϣ</span>
                                                <%-- <input id="CheckboxAgentMessage"  name="ClearData" type="checkbox" value="ShopNum1_MessageInfo" /><span style="color:#666666;"> <span style="color:#ff0000;">* </span>��̨վ����Ϣ,��Ավ����Ϣ</span>--%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" style="padding-left: 52px; color: #2672ac;">
                                                �������ݣ�<asp:CheckBox ID="CheckboxAttachMent" name="ClearData" runat="server" /><span
                                                    style="color: #666666;"> <span style="color: #ff0000;">* </span>����,��������</span>
                                                <%-- <input id="CheckboxAttachMent"  name="ClearData" type="checkbox" value="ShopNum1_AttachMent;ShopNum1_AttachMentCategory" /><span style="color:#666666;"> <span style="color:#ff0000;">* </span>����,��������</span>--%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" style="padding-left: 52px; color: #2672ac;">
                                                ���ߵ��飺<asp:CheckBox ID="CheckboxSurveyOption" name="ClearData" runat="server" /><span
                                                    style="color: #666666;"> <span style="color: #ff0000;">* </span>���ߵ���,���ߵ���ѡ���</span>
                                                <%--  <input id="CheckboxSurveyOption"  name="ClearData" type="checkbox" value="ShopNum1_SurveyTheme;ShopNum1_SurveyOption" /><span style="color:#666666;"> <span style="color:#ff0000;">* </span>���ߵ���,���ߵ���ѡ���</span>--%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" style="padding-left: 52px; color: #2f7ecc;">
                                                �������ӣ�<asp:CheckBox ID="CheckboxLink" name="ClearData" runat="server" /><span style="color: #666666;">
                                                    <span style="color: #ff0000;">* </span>��������</span>
                                                <%-- <input id="CheckboxLink"  name="ClearData" type="checkbox" value="ShopNum1_Link" /><span style="color:#666666;"> <span style="color:#ff0000;">* </span>��������</span>--%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" style="padding-left: 52px; color: #2672ac;">
                                                ���߿ͷ���<asp:CheckBox ID="CheckboxService" name="ClearData" runat="server" /><span style="color: #666666;">
                                                    <span style="color: #ff0000;">* </span>���߿ͷ�</span>
                                                <%-- <input id="CheckboxService"  name="ClearData" type="checkbox" value="ShopNum1_OnlineService" /><span style="color:#666666;"> <span style="color:#ff0000;">* </span>���߿ͷ�</span>--%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" style="padding-left: 52px; color: #2672ac;">
                                                �����Ʒ��<asp:CheckBox ID="CheckboxScore" name="ClearData" runat="server" /><span style="color: #666666;">
                                                    <span style="color: #ff0000;">* </span>�����Ʒ,�����Ʒ����,�������,���������Ʒ</span>
                                            </td>
                                        </tr>
                                        <td colspan="2" style="padding-left: 52px; color: #2672ac;">
                                            ��ң�BV����Ϣ��<asp:CheckBox ID="CheckboxAdvancePayment" name="ClearData" runat="server" /><span
                                                style="color: #666666;"> <span style="color: #ff0000;">* </span>��ң�BV����ֵ,��ң�BV������,��ң�BV�����,ת����ʷ</span>
                                        </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" style="padding-left: 52px; color: #2672ac;">
                                                �������<asp:CheckBox ID="CheckboxLimtPackage" name="ClearData" runat="server" /><span
                                                    style="color: #666666;"> <span style="color: #ff0000;">* </span>�ۿۻ,��ʱ��Ʒ,�Ź��</span>
                                            </td>
                                        </tr>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </table>
                            <div style="border-top: 1px dashed #cccccc; margin-top: 21px; padding-top: 15px;
                                padding-bottom: 25px; width: 100%; background: #f1f5f8;">
                                <table width="100%" border="0" cellspacing="0" cellpadding="0" bgcolor="f1f5f8">
                                    <tr>
                                        <td align="right" style="color: #222222; width: 19%;">
                                            ���������Ա�û�����
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="TextBoxLoginID" runat="server" CssClass="orinput" Style="border: 1px solid #DCDCDC;
                                                height: 22px; line-height: 22px; margin-right: 10px; width: 240px;"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBoxLoginID"
                                                Display="Dynamic" ErrorMessage="��ֵ����Ϊ��"></asp:RequiredFieldValidator>
                                            <font color="red">*</font>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" style="color: #222222; padding-top: 10px;">
                                            ���������Ա���룺
                                        </td>
                                        <td style="padding-top: 10px;">
                                            <asp:TextBox ID="TextBoxPwd" runat="server" TextMode="Password" CssClass="orinput"
                                                Style="border: 1px solid #DCDCDC; height: 22px; line-height: 22px; margin-right: 10px;
                                                width: 240px;"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBoxPwd"
                                                Display="Dynamic" ErrorMessage="��ֵ����Ϊ��"></asp:RequiredFieldValidator>
                                            <font color="red">*</font>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                        </td>
                                        <td align="left">
                                            <div style="height: 22px; margin-top: 12px;">
                                                <asp:Button ID="ButtonClearExperienceData" runat="server" Text="�����������" CssClass="bt3_clear"
                                                    OnClick="ButtonClearExperienceData_Click" />
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <asp:HiddenField ID="hiddenFieldGuid" runat="server" Value="0" />
    <asp:HiddenField ID="hiddenFieldCheckedClearData" runat="server" Value="" />
    </form>
</body>
</html>
