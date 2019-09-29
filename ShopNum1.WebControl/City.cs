using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;

namespace ShopNum1.WebControl
{
    [ParseChildren(true)]
    public class City : BaseWebControl
    {
        private Button ButtonEnter;
        private Repeater RepeaterCityLetter;
        private Repeater RepeaterHotCity;
        private DropDownList dropdownlistArea;
        private DropDownList dropdownlistCity;
        private DropDownList dropdownlistProvince;
        private string skinFilename = "City.ascx";
        private string string_1 = "11";

        public City()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public string ShowCount
        {
            get { return string_1; }
            set { string_1 = value; }
        }

        public int BandDropDownListArea(int FatherID, DropDownList dropDownList_3)
        {
            var action = (ShopNum1_City_Action) LogicFactory.CreateShopNum1_City_Action();
            DataView defaultView = action.Search(FatherID, 0).DefaultView;
            if (defaultView.Table.Rows.Count > 0)
            {
                foreach (DataRow row in defaultView.Table.Rows)
                {
                    var item = new ListItem
                    {
                        Text = row["CityName"].ToString().Trim(),
                        Value = row["ID"].ToString().Trim()
                    };
                    dropDownList_3.Items.Add(item);
                }
                return 1;
            }
            return 0;
        }

        public int BandDropDownListCity(int FatherID, DropDownList dropDownList_3)
        {
            var action = (ShopNum1_City_Action) LogicFactory.CreateShopNum1_City_Action();
            DataView defaultView = action.Search(FatherID, 0).DefaultView;
            if (defaultView.Table.Rows.Count > 0)
            {
                foreach (DataRow row in defaultView.Table.Rows)
                {
                    var item = new ListItem
                    {
                        Text = row["CityName"].ToString().Trim(),
                        Value = row["ID"].ToString().Trim()
                    };
                    dropDownList_3.Items.Add(item);
                }
                return 1;
            }
            return 0;
        }

        protected void ButtonEnter_Click(object sender, EventArgs e)
        {
            string addressCode = dropdownlistArea.SelectedValue.Split(new[] {'/'})[0];
            string str2 = string.Empty;
            DataTable shopUrlByAddressCode =
                ((ShopNum1_ShopInfoList_Action) LogicFactory.CreateShopNum1_ShopInfoList_Action())
                    .GetShopUrlByAddressCode(addressCode);
            if ((shopUrlByAddressCode != null) && (shopUrlByAddressCode.Rows.Count > 0))
            {
                str2 = shopUrlByAddressCode.Rows[0]["ShopUrl"].ToString();
            }
            string str3 = ShopSettings.siteDomain.Substring(ShopSettings.siteDomain.IndexOf("."));
            Page.Response.Redirect("http://" + str2 + str3);
        }

        protected void dropdownlistProvince_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!(dropdownlistProvince.SelectedValue == "-1"))
            {
                BandDropDownListCity(Convert.ToInt32(dropdownlistProvince.SelectedValue), dropdownlistCity);
            }
        }

        protected override void InitializeSkin(Control skin)
        {
            ButtonEnter = (Button) skin.FindControl("ButtonEnter");
            ButtonEnter.Click += ButtonEnter_Click;
            RepeaterHotCity = (Repeater) skin.FindControl("RepeaterHotCity");
            dropdownlistProvince = (DropDownList) skin.FindControl("dropdownlistProvince");
            dropdownlistCity = (DropDownList) skin.FindControl("dropdownlistCity");
            dropdownlistArea = (DropDownList) skin.FindControl("dropdownlistArea");
            RepeaterCityLetter = (Repeater) skin.FindControl("RepeaterCityLetter");
            RepeaterCityLetter.ItemDataBound += RepeaterCityLetter_ItemDataBound;
            dropdownlistProvince.SelectedIndexChanged += dropdownlistProvince_SelectedIndexChanged;
            method_1();
            BandDropDownListCity(0, dropdownlistProvince);
        }

        protected void method_0(object sender, RepeaterItemEventArgs e)
        {
            var panel = (Panel) e.Item.FindControl("PanelCityName");
            var field = (HiddenField) e.Item.FindControl("HiddenFieldID");
            var action = (ShopNum1_City_Action) LogicFactory.CreateShopNum1_City_Action();
            if (action.IsHost(field.Value).Rows.Count > 0)
            {
                panel.Style["color"] = "red";
            }
        }

        protected void method_1()
        {
            var action = (ShopNum1_City_Action) LogicFactory.CreateShopNum1_City_Action();
            DataTable table = action.SearchHotCity(string_1);
            RepeaterHotCity.DataSource = table.DefaultView;
            RepeaterHotCity.DataBind();
            DataTable table2 = action.SearchCityLetter();
            RepeaterCityLetter.DataSource = table2.DefaultView;
            RepeaterCityLetter.DataBind();
        }

        protected void RepeaterCityLetter_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            var repeater = (Repeater) e.Item.FindControl("RepeaterCityLetterChild");
            var field = (HiddenField) e.Item.FindControl("HiddenFieldLetter");
            repeater.ItemDataBound += method_0;
            DataTable table =
                ((ShopNum1_City_Action) LogicFactory.CreateShopNum1_City_Action()).SearchCityByLetter(field.Value);
            repeater.DataSource = table.DefaultView;
            repeater.DataBind();
        }
    }
}