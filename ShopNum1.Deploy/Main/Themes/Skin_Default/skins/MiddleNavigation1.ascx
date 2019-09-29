<%@ Control Language="C#" EnableViewState="true" %>
<style type="text/css">
    .browse
    {
        border: 1px solid #8c0000;
        padding: 4px;
        width: 250px;
        position: relative;
        z-index: 9999;
        left: -177px;
    }
    .jiathis_style_32x32
    {
        position: relative;
        z-index: 9999;
    }
    #ckepop .button, #ckepop .jiathis_txt
    {
        font-size: 14px;
        line-height: 30px !important;
    }
</style>
<!--我的商城 购物车 -->
<script language="javascript" type="text/javascript">
    $(document).ready(function () {
        $("#dchild").hide();

        $("#dparent1").hover(
			function () {
			    $("#dchild").show();
			    $("#dparent1").addClass("nap");

			},
			function () {
			    $("#dchild").hide();
			    $("#dparent1").removeAttr("class");

			}
		);

        $("#dchild2").hide();

        $("#dparent2").hover(
			function () {
			    $("#dchild2").show();
			    $("#dparent2").addClass("nap");

			},
			function () {
			    $("#dchild2").hide();
			    $("#dparent2").removeAttr("class");

			}
		);
    });
</script>
<div id="mallNav">
    <div class="mallNav_con">
        <div id="mallTextNav" class="clearfix">
            <div class="mallNav_main nall_hid" style="margin-left: 188px;">
                <asp:Literal ID="literLi" runat="server"></asp:Literal>
            </div>
        </div>
    </div>
</div>
