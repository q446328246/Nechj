using System.CodeDom.Compiler;
using System.Configuration;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace ShopNum1.TbLinq.Properties
{
    [CompilerGenerated,
     GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "9.0.0.0")]
    internal sealed class Settings : ApplicationSettingsBase
    {
        private static readonly Settings defaultInstance = ((Settings) Synchronized(new Settings()));

        public static Settings Default
        {
            get { return defaultInstance; }
        }

        [DefaultSettingValue("Data Source=FC;Initial Catalog=ShopNum1_MultiV7.2;User ID=sa"), DebuggerNonUserCode,
         SpecialSetting(SpecialSetting.ConnectionString), ApplicationScopedSetting]
        public string ShopNum1_MultiV7_2ConnectionString
        {
            get { return (string) this["ShopNum1_MultiV7_2ConnectionString"]; }
        }

        [DefaultSettingValue("Data Source=FC;Initial Catalog=ShopNum1_MultiV7.2;User ID=sa;Password=sa"),
         ApplicationScopedSetting, DebuggerNonUserCode, SpecialSetting(SpecialSetting.ConnectionString)]
        public string ShopNum1_MultiV7_2ConnectionString1
        {
            get { return (string) this["ShopNum1_MultiV7_2ConnectionString1"]; }
        }

        [SpecialSetting(SpecialSetting.ConnectionString), ApplicationScopedSetting,
         DefaultSettingValue(
             "Data Source=.;Initial Catalog=ShopNum1_MultiV7.2;Persist Security Info=True;User ID=sa;Password=123456"),
         DebuggerNonUserCode]
        public string ShopNum1_MultiV7_2ConnectionString2
        {
            get { return (string) this["ShopNum1_MultiV7_2ConnectionString2"]; }
        }
    }
}