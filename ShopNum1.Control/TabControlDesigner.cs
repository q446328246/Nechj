using System;
using System.ComponentModel.Design;
using System.IO;
using System.Text;
using System.Web.UI;
using System.Web.UI.Design;

namespace ShopNum1.Control
{
    public class TabControlDesigner : ControlDesigner
    {
        private DesignerVerbCollection designerVerbCollection_0;

        public override DesignerVerbCollection Verbs
        {
            get
            {
                if (designerVerbCollection_0 == null)
                {
                    designerVerbCollection_0 =
                        new DesignerVerbCollection(new[] {new DesignerVerb("创建新的属性页...", method_0)});
                }
                return designerVerbCollection_0;
            }
        }

        public override string GetDesignTimeHtml()
        {
            try
            {
                var component = (TabControl) base.Component;
                if ((component.Items == null) || (component.Items.Count == 0))
                {
                    return GetEmptyDesignTimeHtml();
                }
                var sb = new StringBuilder();
                var writer = new StringWriter(sb);
                var writer2 = new HtmlTextWriter(writer);
                component.method_0(writer2);
                writer2.Flush();
                writer.Flush();
                return sb.ToString();
            }
            catch (Exception exception)
            {
                return base.CreatePlaceHolderDesignTimeHtml("生成设计时代码错误:\n\n" + exception);
            }
        }

        protected override string GetEmptyDesignTimeHtml()
        {
            return base.CreatePlaceHolderDesignTimeHtml("右击选择创建新的属性页");
        }

        private void method_0(object sender, EventArgs e)
        {
            new Form0().EditComponent(base.Component);
        }
    }
}