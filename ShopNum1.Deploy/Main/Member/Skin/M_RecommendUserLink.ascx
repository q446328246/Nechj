<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="M_RecommendUserLink.ascx.cs"
    Inherits="ShopNum1.Deploy.Main.Member.Skin.M_RecommendUserLink" %>
<script src="../js/jquery-1.6.2.min.js" type="text/javascript"></script>
<script language="javascript">
    //function copyToClipBoard(){
    //var clipBoardContent="";
    //clipBoardContent+=$("#<%=inputShopurl.ClientID %>").val();
    //window.clipboardData.setData("Text",clipBoardContent);
    //alert("复制成功，请粘贴到你的QQ/MSN上推荐给你的好友");
    //}
    function copyToClipboard() {
        var txt = $("#<%=inputShopurl.ClientID %>").val();
        if (window.clipboardData) {
            window.clipboardData.clearData();
            clipboardData.setData("Text", txt);
            alert("复制成功！");

        } else if (navigator.userAgent.indexOf("Opera") != -1) {
            window.location = txt;
        } else if (window.netscape) {
            try {
                netscape.security.PrivilegeManager.enablePrivilege("UniversalXPConnect");
            } catch (e) {
                alert("被浏览器拒绝！\n请在浏览器地址栏输入'about:config'并回车\n然后将 'signed.applets.codebase_principal_support'设置为'true'");
            }
            var clip = Components.classes['@mozilla.org/widget/clipboard;1'].createInstance(Components.interfaces.nsIClipboard);
            if (!clip)
                return;
            var trans = Components.classes['@mozilla.org/widget/transferable;1'].createInstance(Components.interfaces.nsITransferable);
            if (!trans)
                return;
            trans.addDataFlavor("text/unicode");
            var str = new Object();
            var len = new Object();
            var str = Components.classes["@mozilla.org/supports-string;1"].createInstance(Components.interfaces.nsISupportsString);
            var copytext = txt;
            str.data = copytext;
            trans.setTransferData("text/unicode", str, copytext.length * 2);
            var clipid = Components.interfaces.nsIClipboard;
            if (!clip)
                return false;
            clip.setData(trans, null, clipid.kGlobalClipboard);
            alert("复制成功！");
        }
    }

    $(function () {
        $("#<%=inputShopurl.ClientID%>").val($("#<%=inputShopurl.ClientID%>").val() + escape($("#M_RecommendUserLink_ctl00_hidMemLoginId").val()) + "&userRecommend");
    });
</script>
<input type="hidden" id="hidMemLoginId" runat="server" />
<div id="content" class="ordmain1" style="height: 600px;">
    <table cellspacing="0" cellpadding="0" border="0" style="margin-top: 30px; border-left: 1px solid #C6DFFF;
        border-right: 1px solid #C6DFFF; border-bottom: 1px solid #C6DFFF; float: left;"
        class="biaod">
        <tr>
            <th width="130" scope="col" colspan="2">
                快捷推荐
            </th>
        </tr>
        <tr>
            <td style="padding: 10px 20px;">
                <div style="line-height: 20px; text-align: left;">
                    复制链接发给QQ/MSN上的好友：</div>
                <table cellpadding="0" cellspacing="0" border="0">
                    <tr>
                        <td>
                            <input type="text" class="ss_nr1" style="width: 430px;" runat="server" id="inputShopurl" />
                        </td>
                        <td>
                            <a href="javascript:void(0)" class="zf_bot" onclick="copyToClipboard()">复制地址</a>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</div>
