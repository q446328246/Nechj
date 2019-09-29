$(document).ready(function() {


    $("#form1").validate({
        rules: {
            TextBoxTitle: {
                maxlength: 20
            },
            TextBoxContent: {
                maxlength: 200
            },
            TextBoxKeywords: {
                maxlength: 60
            },
            TextBoxTel: {
                number: true,
                maxlength: 10
            },
            TextBoxEmail: {
                email: true,
                maxlength: 50
            },
            TextBoxDescription: {
                maxlength: 200
            },
            TextBoxCode: {
                maxlength: 4
            },
            TextBoxOrderID: {
                number: true
            },
            TextBoxName: {
                maxlength: 200
            },
            TextBoxRepertoryNumber: {
                number: true,
                maxlength: 10
            },
            TextBoxShopPrice1: {
                number: true,
                maxlength: 10
            },
            TextBoxShopPrice2: {
                number: true,
                maxlength: 10
            },
            TextBoxMemLoginID: {
                maxlength: 100
            },
            TextBoxFavourTickitName: {
                maxlength: 100
            },
            TextBox1: {
                number: true,
                maxlength: 100
            },
            TextBoxSendTime1: {
                dateISO: true
            },
            TextBoxSendTime2: {
                dateISO: true
            },
            TextBoxReplaytime1: {
                dateISO: true
            },
            TextBoxReplaytime2: {
                dateISO: true
            }
        },
        messages: {
            TextBoxTitle: "只能输入20个字符",
            TextBoxContent: "只能输入200个字符",
            TextBoxKeywords: "只能输入60个字符",
            TextBoxTel: { number: "电话号码数字", maxlength: "不得大于10" },
            TextBoxEmail: { email: "email不对", maxlength: "不得大于50" },
            TextBoxDescription: "只能输入200个字符",
            TextBoxCode: "验证码错误",
            TextBoxOrderID: { required: "不得为空", number: "只能输入数字" },
            TextBoxName: { maxlength: "只能输入200个字符" },
            TextBoxRepertoryNumber: { number: "编号为数字", maxlength: "只能输入10个字符" },
            TextBoxShopPrice1: { number: "编号为数字", maxlength: "只能输入10个字符" },
            TextBoxShopPrice2: { number: "编号为数字", maxlength: "只能输入10个字符" },
            TextBoxMemLoginID: { maxlength: "只能输入100个字符" },
            TextBoxFavourTickitName: { maxlength: "只能输入100个字符" },
            TextBox1: { number: "排序为数字", maxlength: "只能输入100个字符" },
            TextBoxSendTime1: { dateISO: "时间格式不对" },
            TextBoxSendTime2: { dateISO: "时间格式不对" },
            TextBoxReplaytime1: { dateISO: "时间格式不对" },
            TextBoxReplaytime2: { dateISO: "时间格式不对" }
        }
    });
})