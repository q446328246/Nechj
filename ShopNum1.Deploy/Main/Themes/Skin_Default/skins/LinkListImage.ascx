<%@ Control Language="C#" %>
<%@ Import Namespace="ShopNum1.WebControl" %>
<%@ Import Namespace="System.Data" %>
<div class="links_img clearfix">
    <asp:Repeater ID="RepeaterData" runat="server">
        <ItemTemplate>
            <a href=' <%#  Eval("Href","{0}") %>' target="_blank">
                <input type="hidden" name="hid_Img" value='<%#((DataRowView)Container.DataItem).Row["ImgADD"] %>' />
                <img alt='<%# ((DataRowView)Container.DataItem).Row["name"] %>' id="img1" src='<%#((DataRowView)Container.DataItem).Row["ImgADD"] %>'
                    height="31" width="88" onerror="javascript:this.src='/ImgUpload/noimg.jpg_60x60.jpg'"
                    runat="server" /></a></ItemTemplate>
    </asp:Repeater>
    <%-- LinkListImage.LinkUrl(--%>
</div>
<script type="text/javascript" language="javascript">
    $(function () {
        $(".links_img").find("img").each(function () {
            if ($(this).attr("src") == "") {
                $(this).parent().text($(this).attr("alt"));
            }
        });
    });
</script>
