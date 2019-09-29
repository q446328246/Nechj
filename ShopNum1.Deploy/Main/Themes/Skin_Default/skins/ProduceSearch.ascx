<%@ Control Language="C#" %>
<%@ Import Namespace="ShopNum1.Common" %>
<%@ Import Namespace="ShopNum1.WebControl" %>
<%@ Import Namespace="System.Data" %>
<div class="ks_panel" style="margin-top: 8px;">
    <div class="storn_hd">
        <h3>
            店内搜索</h3>
    </div>
    <div class="search_form">
        <ul>
            <li class="keyword">
                <label>
                    关键字：</label>
                <span>
                    <asp:TextBox ID="TextBoxKeywordsSearch" MaxLength="18" runat="server"></asp:TextBox>
                </span></li>
            <li class="price">
                <label>
                    价&nbsp;&nbsp;格：</label>
                <span>
                    <asp:TextBox ID="TextBoxPriceStartSearch" MaxLength="8" runat="server"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidatorPriceStart" runat="server"
                        ControlToValidate="TextBoxPriceStartSearch" ErrorMessage="只能输入数字" ValidationExpression="^[0-9]+(\.[0-9]{2})?$"
                        Display="Dynamic"></asp:RegularExpressionValidator>
                    到
                    <asp:TextBox ID="TextBoxPriceEndSearch" MaxLength="8" runat="server"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBoxPriceEndSearch"
                        ErrorMessage="只能输入数字" ValidationExpression="^[0-9]+(\.[0-9]{2})?$" Display="Dynamic"></asp:RegularExpressionValidator>
                </span></li>
            <li class="submit">
                <asp:Button ID="ButtonSearch" runat="server" Text="" CssClass="button" />
            </li>
        </ul>
    </div>
</div>
<script type="text/javascript" language="javascript">
    //搜索价格格式化方法
    function number_format(num, ext) {
        if (ext < 0) { return num; }
        num = Number(num);
        if (isNaN(num)) { num = 0; }
        var _str = num.toString();
        var _arr = _str.split('.');
        var _int = _arr[0];
        var _flt = _arr[1];
        if (_str.indexOf('.') == -1) {
            /* 找不到小数点，则添加 */
            if (ext == 0) { return _str; }
            var _tmp = '';
            for (var i = 0; i < ext; i++) { _tmp += '0'; }
            _str = _str + '.' + _tmp;
        } else {
            if (_flt.length == ext) { return _str; }
            /* 找得到小数点，则截取 */
            if (_flt.length > ext) {
                _str = _str.substr(0, _str.length - (_flt.length - ext));
                if (ext == 0) { _str = _int; }
            } else {
                for (var i = 0; i < ext - _flt.length; i++) {
                    _str += '0';
                }
            }
        }
        return _str;
    };


    // 计算价格
    function price_starttotal(obj) {
        var StartPrice = $(obj).val();
        $(obj).val(number_format(StartPrice, 2));
    };
    function onchangeprice(obj) {
        price_starttotal(obj);
    }
</script>
