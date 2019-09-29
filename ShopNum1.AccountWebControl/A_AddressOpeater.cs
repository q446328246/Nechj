using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;
using ShopNum1MultiEntity;

namespace ShopNum1.AccountWebControl
{
    [ParseChildren(true)]
    public class A_AddressOpeater : BaseMemberWebControl
    {
        private Button btn_Save;
        private HtmlInputHidden hid_Area;
        private HtmlInputHidden hid_AreaCode;
        private string skinFilename = "A_AddressOpeater.cs";
        private HtmlInputText txt_Address;
        private HtmlInputText txt_Email;
        private HtmlInputText txt_Mobile;
        private HtmlInputText txt_Post;
        private HtmlInputText txt_Tel;
        private HtmlInputText txt_UserName;

        public A_AddressOpeater()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public string Guid { get; set; }

        protected void btn_Save_Click(object sender, EventArgs e)
        {
            var action = (ShopNum1_Address_Action) LogicFactory.CreateShopNum1_Address_Action();
            var address = new ShopNum1_Address
            {
                MemLoginID = base.MemLoginID
            };
            if (Guid != "")
            {
                address.Guid = new Guid(Guid);
                address.IsDefault = 0;
            }
            else
            {
                address.Guid = System.Guid.NewGuid();
            }
            address.Name = txt_UserName.Value;
            address.Email = txt_Email.Value;
            address.Postalcode = txt_Post.Value;
            address.Mobile = txt_Mobile.Value;
            address.Address = txt_Address.Value;
            address.ModifyTime = DateTime.Now;
            address.ModifyUser = base.MemLoginID;
            address.AddressCode = hid_AreaCode.Value;
            address.AddressValue = hid_Area.Value;
            address.Area = GetAddressDetil(address.AddressValue);
            address.Tel = txt_Tel.Value;
            address.CreateTime = DateTime.Now;
            try
            {
                if (Guid != "")
                {
                    action.Update(address);
                    MessageBox.Show("收货地址更新成功");
                }
                else
                {
                    action.Add(address);
                    MessageBox.Show("收货地址添加成功");
                }
                Page.Response.Redirect("A_ShipAddress.aspx");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string GetAddressDetil(string addressValue)
        {
            string[] strArray2 = addressValue.Split(new[] {'|'})[0].Split(new[] {','});
            string str = string.Empty;
            if (strArray2.Length > 2)
            {
                return (strArray2[0] + strArray2[1] + strArray2[2]);
            }
            if (strArray2.Length > 1)
            {
                return (strArray2[0] + strArray2[1]);
            }
            if (strArray2.Length > 0)
            {
                str = strArray2[0];
            }
            return str;
        }

        protected override void InitializeSkin(Control skin)
        {
            txt_UserName = (HtmlInputText) skin.FindControl("txt_UserName");
            txt_Email = (HtmlInputText) skin.FindControl("txt_Email");
            txt_Address = (HtmlInputText) skin.FindControl("txt_Address");
            txt_Post = (HtmlInputText) skin.FindControl("txt_Post");
            txt_Mobile = (HtmlInputText) skin.FindControl("txt_Mobile");
            btn_Save = (Button) skin.FindControl("btn_Save");
            btn_Save.Click += btn_Save_Click;
            hid_Area = (HtmlInputHidden) skin.FindControl("hid_Area");
            hid_AreaCode = (HtmlInputHidden) skin.FindControl("hid_AreaCode");
            txt_Tel = (HtmlInputText) skin.FindControl("txt_Tel");
            try
            {
                Guid = new Guid(Common.Common.ReqStr("Guid")).ToString();
            }
            catch
            {
                Guid = "";
            }
            if (!Page.IsPostBack && (Guid != ""))
            {
                method_0(Guid);
            }
        }

        private void method_0(string string_2)
        {
            var action = (ShopNum1_Address_Action) LogicFactory.CreateShopNum1_Address_Action();
            var table = new DataTable();
            try
            {
                table = action.Search(string_2);
                if (table.Rows.Count > 0)
                {
                    txt_UserName.Value = table.Rows[0]["Name"].ToString();
                    txt_Post.Value = table.Rows[0]["Postalcode"].ToString();
                    txt_Mobile.Value = table.Rows[0]["Mobile"].ToString();
                    txt_Address.Value = table.Rows[0]["Address"].ToString();
                    txt_Email.Value = table.Rows[0]["Email"].ToString();
                    hid_Area.Value = table.Rows[0]["AddressValue"].ToString();
                    hid_AreaCode.Value = table.Rows[0]["AddressCode"].ToString();
                    txt_Tel.Value = table.Rows[0]["Tel"].ToString();
                }
            }
            catch
            {
            }
        }
    }
}