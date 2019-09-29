using System.Collections;
using System.ComponentModel;

namespace ShopNum1.Control
{
    public class RequiredFieldTypeControlsConverter : StringConverter
    {
        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            var values = new ArrayList();
            values.Add("暂无校验");
            values.Add("数据校验");
            values.Add("电子邮箱");
            values.Add("移动手机");
            values.Add("家用电话");
            values.Add("身份证号码");
            values.Add("网页地址");
            values.Add("日期");
            values.Add("日期时间");
            values.Add("金额");
            values.Add("IP地址");
            values.Add("IP地址带端口");
            values.Add("邮政编码");
            values.Add("整数验证");
            return new StandardValuesCollection(values);
        }

        public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
        {
            return false;
        }

        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }
    }
}