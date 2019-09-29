using System.CodeDom.Compiler;
using System.Configuration;
using System.Runtime.CompilerServices;

[GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "9.0.0.0"),
 CompilerGenerated]
internal sealed class Class0 : ApplicationSettingsBase
{
    private static readonly Class0 class0_0 = ((Class0) Synchronized(new Class0()));

    public string BindData()
    {
        return (string) this["SendSMS_WebReference_ISmsService"];
    }

    public string method_1()
    {
        return (string) this["ShopNum1_Standard_VjWebservice_SDKService"];
    }

    public static Class0 sBindData()
    {
        return class0_0;
    }
}