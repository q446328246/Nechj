using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;

namespace ShopNum1.WebControl
{
    [ParseChildren(true)]
    public class CategoryInfoDetail : BaseWebControl
    {
        private Repeater RepeaterData;
        private Repeater RepeaterDataUpDown;
        private string skinFilename = "CategoryInfoDetail.ascx";
        private string string_1 = "上一篇：";
        private string string_2 = "下一篇：";

        public CategoryInfoDetail()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public string Guid { get; set; }

        public string NextCategoryName
        {
            get { return string_2; }
            set { string_2 = value; }
        }

        public string OnCategoryName
        {
            get { return string_1; }
            set { string_1 = value; }
        }

        protected override void InitializeSkin(Control skin)
        {
            RepeaterData = (Repeater) skin.FindControl("RepeaterData");
            RepeaterDataUpDown = (Repeater) skin.FindControl("RepeaterDataUpDown");
            if (!Page.IsPostBack)
            {
            }
            Guid = (Common.Common.ReqStr("guid") == "") ? "0" : Common.Common.ReqStr("guid");
            BindData();
        }

        protected void BindData()
        {
            var action = (ShopNum1_CategoryChecked_Action) LogicFactory.CreateShopNum1_CategoryChecked_Action();
            DataTable categoryDetails = action.GetCategoryDetails(Guid);
            if (categoryDetails.Rows.Count > 0)
            {
                RepeaterData.DataSource = categoryDetails.DefaultView;
                RepeaterData.DataBind();
                Page.Title = categoryDetails.Rows[0]["Title"] + "_分类信息";
            }
            DataTable table2 = action.GetCategoryOnAndNext(Guid, OnCategoryName, NextCategoryName);
            if ((table2 != null) && (table2.Rows.Count > 0))
            {
                RepeaterDataUpDown.DataSource = table2.DefaultView;
                RepeaterDataUpDown.DataBind();
            }
        }

        public static string returnType(object type)
        {
            string text = type.ToString();
            string result;
            switch (text)
            {
                case "1":
                    result = "卖";
                    return result;
                case "2":
                    result = "买";
                    return result;
                case "3":
                    result = "招聘";
                    return result;
                case "4":
                    result = "求职";
                    return result;
                case "5":
                    result = "出租";
                    return result;
                case "6":
                    result = "求租";
                    return result;
                case "7":
                    result = "合租";
                    return result;
                case "8":
                    result = "出售";
                    return result;
                case "9":
                    result = "求购";
                    return result;
                case "10":
                    result = "女找男";
                    return result;
                case "11":
                    result = "男找女";
                    return result;
                case "12":
                    result = "性别不限";
                    return result;
                case "13":
                    result = "提供";
                    return result;
                case "14":
                    result = "需求";
                    return result;
            }
            result = "无";
            return result;
        }

        public static string ShowAddress(object object_0)
        {
            string[] strArray = object_0.ToString().Split(new[] {' '});
            string str = "";
            for (int i = 0; i < strArray.Length; i++)
            {
                str = str + strArray[i] + ">>";
            }
            return str.Substring(0, str.Length - 2);
        }
    }
}