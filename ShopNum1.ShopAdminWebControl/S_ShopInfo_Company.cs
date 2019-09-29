using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.MultiBaseWebControl;

namespace ShopNum1.ShopAdminWebControl
{
    [ParseChildren(true)]
    public class S_ShopInfo_Company : BaseShopWebControl
    {
        private Button ButtonSave;
        private TextBox TextBoxBusinessLicense;
        private TextBox TextBoxBusinessScope;
        private TextBox TextBoxBusinessTerm;
        private TextBox TextBoxCompanName;
        private TextBox TextBoxLegalPerson;
        private TextBox TextBoxRegistrationNum;
        private string skinFilename = "S_ShopInfo_Company.ascx";

        public S_ShopInfo_Company()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        protected void ButtonSave_Click(object sender, EventArgs e)
        {
        }

        protected override void InitializeSkin(Control skin)
        {
            TextBoxCompanName = (TextBox) skin.FindControl("TextBoxCompanName");
            TextBoxLegalPerson = (TextBox) skin.FindControl("TextBoxLegalPerson");
            TextBoxRegistrationNum = (TextBox) skin.FindControl("TextBoxRegistrationNum");
            TextBoxBusinessTerm = (TextBox) skin.FindControl("TextBoxBusinessTerm");
            TextBoxBusinessScope = (TextBox) skin.FindControl("TextBoxBusinessScope");
            TextBoxBusinessLicense = (TextBox) skin.FindControl("TextBoxBusinessLicense");
            ButtonSave = (Button) skin.FindControl("ButtonSave");
            ButtonSave.Click += ButtonSave_Click;
        }
    }
}