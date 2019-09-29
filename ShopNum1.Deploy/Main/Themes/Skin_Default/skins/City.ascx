<%@ Control Language="C#" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="ShopNum1.Common" %>
<script language="javascript" type="text/javascript">
    function BindDropDownShopCategory2(dlist) {
        var ccode = dlist.options[dlist.selectedIndex].value;
        params = { 'cityid': ccode };
        $("#City_ctl00_dropdownlistCity").html("");
        $("#City_ctl00_dropdownlistCity").append("<option value=\"-1\">-请选择-</option>")
        $("#City_ctl00_dropdownlistCity").hide();
        $("#City_ctl00_dropdownlistArea").hide();

        $.getJSON("/Main/Api/AddressOpreateJson.aspx", params, function (json) {
            if (json == null || json == "") {
                return;
            }

            $("#City_ctl00_dropdownlistCity").show();
            $.each(json, function (i) { $("#City_ctl00_dropdownlistCity").append($("<option></option>").val(json[i].Value).html(json[i].Name)) });
        });
    }

    function BindDropDownShopCategory3(dlist) {

        var ccode = new String();

        var code = new Array();
        code = dlist.options[dlist.selectedIndex].value;
        ccode = code.split('/')[1];
        params = { 'cityid': ccode };
        $("#City_ctl00_dropdownlistArea").html("");
        $("#City_ctl00_dropdownlistArea").append("<option value=\"-1\">-请选择-</option>")
        $("#City_ctl00_dropdownlistArea").hide();

        $.getJSON("/Main/Api/AddressOpreateJson.aspx", params, function (json) {
            if (json == null || json == "") {
                return;
            }
            $("#City_ctl00_dropdownlistArea").show();
            $.each(json, function (i) { $("#City_ctl00_dropdownlistArea").append($("<option></option>").val(json[i].Value).html(json[i].Name)) });
        });
    }

    function goToShop() {
        var selectvalue = $("#<%=dropdownlistArea.ClientID %>").find(":selected").val();
        var shopur = new String();
        var addresscode = selectvalue.split('/')[0];

        //获取对应的市
        $.ajax({
            type: "GET",
            async: true,
            url: "/Main/Api/Address.ashx",
            data: "addresscode=" + addresscode + "&type=addresscode",
            success: function (result) {

                if (result != "") {

                    shopurl = result;
                    window.location.href = shopurl;
                }
            }
        });

    }


</script>
<script language="javascript" type="text/javascript">
    function chickCity() {

        var temp = false;
        var selectvalue = $("#<%=dropdownlistCity.ClientID %>").find(":selected").val();

        if (selectvalue != "-1") {
            window.location.href = "http://" + window.location.host + "/default.aspx?cityid=" + selectvalue.substr(selectvalue.indexOf('/') + 1) + "";
            temp = false;
        }
        if (selectvalue == "-1") {
            alert('请选择城市');
            temp = false;
        }

        return temp;
    }
</script>
<script type="text/javascript">
    var lodding = "<img  src='/Main/Themes/Skin_Default/Images/lodding.gif'/>";

    $(document).ready(
        function () {

            $(".cityod").hover(
                function () {
                    var e = this;
                    var cityid = $(this).attr("cityid"); //市
                    var cityul = $("#city" + cityid + "");
                    var _cityul = $("#_city" + cityid + "");
                    $(this).children("div").removeClass("hidden");

                    if (cityul.html() == "") {
                        _cityul.html(lodding);
                        //获取对应的市
                        $.ajax({
                            type: "GET",
                            async: true,
                            url: "/Main/Api/Address.ashx",
                            data: "cityid=" + cityid + "&type=SearchArea1",
                            success: function (result) {

                                if (result != "") {
                                    cityul.html(result.toString().replace("http://.pkcoo.com/", "javascript:void(0)"));
                                    $(this).children("div").addClass("cluetip  clearfix");

                                } else {
                                    cityul.html("");
                                }
                                _cityul.html("");
                            }
                        });
                    }
                },
            //鼠标移除时
                function () {
                    $(this).children("div").addClass("hidden");
                }
            );
        });

    function city1_hidden(element) {
        $(element).addClass("hidden");
    }
    function city2_show(e) {
        $(this).removeClass("hidden");
    }
    


</script>
<div class="moka_city clearfix">
    <div class="flw_city_head">
        <div class="hot_city" style="display: none;">
            <span>热门城市：</span>
            <asp:Repeater ID="RepeaterHotCity" runat="server">
                <ItemTemplate>
                    <%#((DataRowView)Container.DataItem).Row["CityName"]%>
                </ItemTemplate>
            </asp:Repeater>
        </div>
        <div class="select_city">
            按省份选择:
            <asp:DropDownList ID="dropdownlistProvince" runat="server" onchange="document.getElementById('HiddenRegion1').value=this.options[this.selectedIndex].text;BindDropDownShopCategory2(this);"
                CssClass="selected">
                <asp:ListItem Selected="True" Value="-1">-请选择-</asp:ListItem>
            </asp:DropDownList>
            <asp:DropDownList ID="dropdownlistCity" runat="server" CssClass="selected" onchange="document.getElementById('HiddenRegion2').value=this.options
[this.selectedIndex].text;BindDropDownShopCategory3(this);">
                <asp:ListItem Selected="True" Value="-1">-请选择-</asp:ListItem>
            </asp:DropDownList>
            <asp:DropDownList ID="dropdownlistArea" runat="server" CssClass="selected" onchange="document.getElementById('HiddenRegion3').value=this.options[this.selectedIndex].text;">
                <asp:ListItem Selected="True" Value="-1">-请选择-</asp:ListItem>
            </asp:DropDownList>
            <asp:Button ID="ButtonEnter" runat="server" Text="进入" Visible="false" OnClientClick="javascript:goToShop();return false;" />
            <img src="Themes/Skin_Default/Images/lambert_bg.gif" class="cityinto" onclick="javascript:goToShop();return false;" />
        </div>
    </div>
    <div class="hua_city_txt">
        <strong><span>按拼音首字母选择</span></strong>
    </div>
    <asp:Repeater ID="RepeaterCityLetter" runat="server">
        <ItemTemplate>
            <dl class="hua_city_con">
                <asp:HiddenField ID="HiddenFieldLetter" runat="server" Value='<%#((DataRowView)Container.DataItem).Row["Letter"] %>' />
                <dt><span>
                    <%#((DataRowView)Container.DataItem).Row["Letter"]%></span>|</dt>
                <dd>
                    <asp:Repeater ID="RepeaterCityLetterChild" runat="server">
                        <ItemTemplate>
                            <a>
                                <asp:Panel ID="PanelCityName" runat="server">
                                    <div>
                                        <div class="cityod" js="addshowevent" id="cityod" cityid='<%#Eval("ID")%>'>
                                            <%#((DataRowView)Container.DataItem).Row["CityName"]%>
                                            <!--二级-->
                                            <div id="city_area" js="addhideevent" class="cluetip hidden">
                                                <div class="cluetip_arrows">
                                                </div>
                                                <div class="city">
                                                    <ul id="city<%# Eval("ID")%>">
                                                    </ul>
                                                    <ul id="_city<%# Eval("ID")%>" style="text-align: center">
                                                    </ul>
                                                </div>
                                                <div class="cluetip_arrows1">
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </asp:Panel>
                            </a>
                            <asp:HiddenField ID="HiddenFieldID" runat="server" Value='<%# DataBinder.Eval(Container, "DataItem(ID)", "{0}")%>' />
                        </ItemTemplate>
                    </asp:Repeater>
                </dd>
            </dl>
        </ItemTemplate>
    </asp:Repeater>
</div>
<input id="hideCategory1" name="hideCategory1" type="hidden" />
<input id="hideCategory2" name="hideCategory2" type="hidden" />
<input id="hideCategory3" name="hideCategory3" type="hidden" />
<input id="HiddenRegion1" name="HiddenRegion1" type="hidden" />
<input id="HiddenRegion2" name="HiddenRegion2" type="hidden" />
<input id="HiddenRegion3" name="HiddenRegion3" type="hidden" />
<asp:HiddenField ID="HiddenFieldCode" runat="server" Value="-1" />
<asp:HiddenField ID="HiddenFieldRegionCode" runat="server" Value="-1" />
<asp:HiddenField ID="HiddenFieldRegion" runat="server" Value="-1" />
