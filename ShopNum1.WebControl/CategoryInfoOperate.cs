using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;
using ShopNum1MultiEntity;

namespace ShopNum1.WebControl
{
    [ParseChildren(true)]
    public class CategoryInfoOperate : BaseWebControl
    {
        private Button ButtonConfirm;
        private DropDownList DropDownListCategoryCf;
        private DropDownList DropDownListCategoryCs;
        private DropDownList DropDownListCategoryCt;
        private DropDownList DropDownListValidTime;
        private RadioButtonList RadioButtonListType;
        private TextBox TextBoxContent;
        private TextBox TextBoxEmail;
        private TextBox TextBoxKeywords;
        private TextBox TextBoxOtherWay;
        private TextBox TextBoxTel;
        private TextBox TextBoxTitle;
        private HiddenField hiddenGuid;
        private HtmlInputReset inputReset;
        private string skinFilename = "CategoryInfoOperate.ascx";

        public CategoryInfoOperate()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public string MemLoginID { get; set; }

        public void BindCategoryCf()
        {
            var action = (ShopNum1_ProductCategory_Action) LogicFactory.CreateShopNum1_ProductCategory_Action();
            action.TableName = "ShopNum1_Category";
            DataTable productCategoryName = action.GetProductCategoryName("0");
            DropDownListCategoryCf.Items.Clear();
            DropDownListCategoryCf.Items.Add(new ListItem("-全部-", "-1"));
            for (int i = 0; i < productCategoryName.Rows.Count; i++)
            {
                DropDownListCategoryCf.Items.Add(new ListItem(productCategoryName.Rows[i]["Name"].ToString(),
                    productCategoryName.Rows[i]["ID"].ToString()));
            }
            DropDownListCategoryCf_SelectedIndexChanged(null, null);
        }

        protected void BindValidTime()
        {
            DropDownListValidTime.Items.Clear();
            DropDownListValidTime.Items.Add(new ListItem("一周", "Day,7"));
            DropDownListValidTime.Items.Add(new ListItem("一个月", "Month,1"));
            DropDownListValidTime.Items.Add(new ListItem("三个月", "Month,3"));
            DropDownListValidTime.Items.Add(new ListItem("半年", "Month,6"));
            DropDownListValidTime.Items.Add(new ListItem("一年", "Year,1"));
            DropDownListValidTime.Items.Add(new ListItem("长期", "Year,100"));
        }

        public void ButtonBack_Click(object sender, EventArgs e)
        {
            Page.Response.Redirect("../CategoryCheckedList.aspx");
        }

        public void ButtonConfirm_Click(object sender, EventArgs e)
        {
            ShopNum1_CategoryInfo info;
            ShopNum1_CategoryChecked_Action action2;
            string sMessage = method_0(DropDownListCategoryCf, DropDownListCategoryCs, DropDownListCategoryCt);
            ((ShopNum1_Member_Action) LogicFactory.CreateShopNum1_Member_Action()).GetMemberQuery(MemLoginID);
            if (hiddenGuid.Value == "0")
            {
                info = new ShopNum1_CategoryInfo
                {
                    Title = TextBoxTitle.Text.Trim(),
                    Type = RadioButtonListType.SelectedValue,
                    Content = TextBoxContent.Text.Replace("'", "''"),
                    Keywords = TextBoxKeywords.Text.Trim(),
                    ValidTime = GetValidTime(DropDownListValidTime.SelectedValue),
                    CreateTime = Convert.ToDateTime(DateTime.Now.ToLongTimeString()),
                    Tel = TextBoxTel.Text,
                    Email = TextBoxEmail.Text,
                    OtherContactWay = TextBoxOtherWay.Text,
                    AssociatedCategoryGuid = sMessage,
                    AssociatedMemberID = MemLoginID
                };
                action2 = (ShopNum1_CategoryChecked_Action) LogicFactory.CreateShopNum1_CategoryChecked_Action();
                if (action2.AddCategoryInfo(info) > 0)
                {
                    MessageBox.Show("添加成功！");
                    MessageBox.Show(sMessage);
                }
            }
            else if (hiddenGuid.Value != "0")
            {
                info = new ShopNum1_CategoryInfo
                {
                    Guid = new Guid(hiddenGuid.Value)
                };
                MessageBox.Show(info.Guid.ToString());
                info.Title = TextBoxTitle.Text.Trim();
                info.Type = RadioButtonListType.SelectedValue;
                info.Content = TextBoxContent.Text.Replace("'", "''");
                info.Keywords = TextBoxKeywords.Text.Trim();
                info.ValidTime = GetValidTime(DropDownListValidTime.SelectedValue);
                info.Tel = TextBoxTel.Text;
                info.Email = TextBoxEmail.Text;
                info.OtherContactWay = TextBoxOtherWay.Text;
                info.AssociatedCategoryGuid = ViewState["cose"].ToString();
                action2 = (ShopNum1_CategoryChecked_Action) LogicFactory.CreateShopNum1_CategoryChecked_Action();
                if (action2.UpdateCategoryInfo(info) > 0)
                {
                    Page.Response.Redirect("CategoryInfoList.aspx");
                }
            }
        }

        protected void DropDownListCategoryCf_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownListCategoryCs.Items.Clear();
            var action = (ShopNum1_ProductCategory_Action) LogicFactory.CreateShopNum1_ProductCategory_Action();
            action.TableName = "ShopNum1_Category";
            DropDownListCategoryCs.Items.Add(new ListItem("-全部-", "-1"));
            if (DropDownListCategoryCf.SelectedValue != "-1")
            {
                DataTable productCategoryName = action.GetProductCategoryName(DropDownListCategoryCf.SelectedValue);
                for (int i = 0; i < productCategoryName.Rows.Count; i++)
                {
                    DropDownListCategoryCs.Items.Add(new ListItem(productCategoryName.Rows[i]["Name"].ToString(),
                        productCategoryName.Rows[i]["ID"].ToString()));
                }
            }
            DropDownListCategoryCs_SelectedIndexChanged(null, null);
        }

        protected void DropDownListCategoryCs_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownListCategoryCt.Items.Clear();
            DropDownListCategoryCt.Items.Add(new ListItem("-全部-", "-1"));
            var action = (ShopNum1_ProductCategory_Action) LogicFactory.CreateShopNum1_ProductCategory_Action();
            action.TableName = "ShopNum1_Category";
            if (DropDownListCategoryCf.SelectedValue != "-1")
            {
                DataTable productCategoryName = action.GetProductCategoryName(DropDownListCategoryCs.SelectedValue);
                for (int i = 0; i < productCategoryName.Rows.Count; i++)
                {
                    DropDownListCategoryCt.Items.Add(new ListItem(productCategoryName.Rows[i]["Name"].ToString(),
                        productCategoryName.Rows[i]["Code"].ToString()));
                }
            }
        }

        protected void GetEditInfo()
        {
            var action = (ShopNum1_CategoryChecked_Action) LogicFactory.CreateShopNum1_CategoryChecked_Action();
            DataTable table = action.EditCategoryInfo(hiddenGuid.Value.Replace("'", ""));
            string code = table.Rows[0]["Code"].ToString();
            DataTable categoryByCode = action.GetCategoryByCode(code.Substring(0, 3));
            DropDownListCategoryCf.SelectedValue = categoryByCode.Rows[0]["ID"].ToString();
            DataTable table3 = action.GetCategoryByCode(code.Substring(0, 6));
            DropDownListCategoryCs.Items.Add(new ListItem(table3.Rows[0]["Name"].ToString(),
                table3.Rows[0]["ID"].ToString()));
            DropDownListCategoryCs.SelectedValue = table3.Rows[0]["ID"].ToString();
            DataTable table4 = action.GetCategoryByCode(code);
            DropDownListCategoryCt.Items.Add(new ListItem(table4.Rows[0]["Name"].ToString(),
                table4.Rows[0]["Code"].ToString()));
            DropDownListCategoryCt.SelectedValue = table.Rows[0]["Code"].ToString();
            ViewState["cose"] = method_0(DropDownListCategoryCf, DropDownListCategoryCs, DropDownListCategoryCt);
            RadioButtonListType.SelectedValue = table.Rows[0]["Type"].ToString();
            TextBoxTitle.Text = table.Rows[0]["Title"].ToString();
            TextBoxContent.Text = table.Rows[0]["Content"].ToString();
            TextBoxKeywords.Text = table.Rows[0]["Keywords"].ToString();
            TextBoxTel.Text = table.Rows[0]["Tel"].ToString();
            TextBoxEmail.Text = table.Rows[0]["Email"].ToString();
            TextBoxOtherWay.Text = table.Rows[0]["OtherContactWay"].ToString();
            ButtonConfirm.Text = "更新";
        }

        protected string GetValidTime(string validTime)
        {
            string str = "";
            DateTime time2 = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            string[] strArray = validTime.Split(new[] {','});
            string str2 = strArray[0];
            switch (str2)
            {
                case null:
                    return str;

                case "Year":
                    return time2.AddYears(int.Parse(strArray[1])).ToString("yyyy-MM-dd");
            }
            if (!(str2 == "Month"))
            {
                if (str2 == "Day")
                {
                    str = time2.AddDays(int.Parse(strArray[1])).ToString("yyyy-MM-dd");
                }
                return str;
            }
            return time2.AddMonths(int.Parse(strArray[1])).ToString("yyyy-MM-dd");
        }

        protected override void InitializeSkin(Control skin)
        {
            if (Page.Request.Cookies["MemberLoginCookie"] == null)
            {
                Page.Response.Write("<script> window.alert(\"对不起，请重新登陆！\");  window.location.href='Login.aspx'</script>");
            }
            else
            {
                HttpCookie cookie = Page.Request.Cookies["MemberLoginCookie"];
                HttpCookie cookie2 = HttpSecureCookie.Decode(cookie);
                MemLoginID = cookie2.Values["MemLoginID"];
            }
            RadioButtonListType = (RadioButtonList) skin.FindControl("RadioButtonListType");
            DropDownListValidTime = (DropDownList) skin.FindControl("DropDownListValidTime");
            TextBoxTitle = (TextBox) skin.FindControl("TextBoxTitle");
            TextBoxContent = (TextBox) skin.FindControl("TextBoxContent");
            TextBoxKeywords = (TextBox) skin.FindControl("TextBoxKeywords");
            TextBoxTel = (TextBox) skin.FindControl("TextBoxTel");
            TextBoxEmail = (TextBox) skin.FindControl("TextBoxEmail");
            TextBoxOtherWay = (TextBox) skin.FindControl("TextBoxOtherWay");
            ButtonConfirm = (Button) skin.FindControl("ButtonConfirm");
            hiddenGuid = (HiddenField) skin.FindControl("hiddenGuid");
            inputReset = (HtmlInputReset) skin.FindControl("inputReset");
            DropDownListCategoryCf = (DropDownList) skin.FindControl("DropDownListCategoryCf");
            DropDownListCategoryCf.SelectedIndexChanged += DropDownListCategoryCf_SelectedIndexChanged;
            DropDownListCategoryCs = (DropDownList) skin.FindControl("DropDownListCategoryCs");
            DropDownListCategoryCs.SelectedIndexChanged += DropDownListCategoryCs_SelectedIndexChanged;
            DropDownListCategoryCt = (DropDownList) skin.FindControl("DropDownListCategoryCt");
            var button = (Button) skin.FindControl("ButtonBack");
            button.Click += ButtonBack_Click;
            ButtonConfirm.Click += ButtonConfirm_Click;
            BindValidTime();
            BindCategoryCf();
            if (!Page.IsPostBack)
            {
                hiddenGuid.Value = (Page.Request.QueryString["guid"] == null)
                    ? "0"
                    : Page.Request.QueryString["guid"];
                if (hiddenGuid.Value != "0")
                {
                    GetEditInfo();
                }
            }
        }

        private string method_0(DropDownList dropDownList_4, DropDownList dropDownList_5, DropDownList dropDownList_6)
        {
            if (dropDownList_6.SelectedValue != "-1")
            {
                return dropDownList_6.SelectedValue;
            }
            if (dropDownList_5.SelectedValue != "-1")
            {
                return dropDownList_5.SelectedValue;
            }
            if (dropDownList_4.SelectedValue != "-1")
            {
                return dropDownList_4.SelectedValue;
            }
            return "-1";
        }
    }
}