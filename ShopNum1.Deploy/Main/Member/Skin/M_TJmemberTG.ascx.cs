using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.Common;
using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using System.Data;
using ShopNum1.Deploy.App_Code;
using ShopNum1.Common.ShopNum1.Common;

namespace ShopNum1.Deploy.Main.Member.Skin
{
    public partial class M_TJmemberTG1 : BaseMemberControl
    {
        public string MemID;
        protected void Page_Load(object sender, EventArgs e)
        {
            ShopNum1_Member_Action action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
            MemID = string.Empty;


            DataTable membertable = action.GetMemInfo(base.MemLoginID);
            MemID = membertable.Rows[0]["MemLoginNO"].ToString();
            HyperLink3.NavigateUrl = "http://" + ShopSettings.siteDomain + "/M_TJmemberTX.aspx?iscustomter=1&recommendid=" + MemID;
            //LabelTG.Text = "欢迎加入唐家巴巴顾客：<a href='http://" + ShopSettings.siteDomain + "/MemberRegisterMandarin.aspx?recommendid=" + MemID + "'>" + "http://" + ShopSettings.siteDomain + "/MemberRegisterMandarin.aspx?recommendid=" + MemID + "</a>";
            HyperLink3.Text = "注册顾客：http://" + ShopSettings.siteDomain + "/MemberRegisterMandarin.aspx?recommendid=" + MemID + "";
           
        }
    }
}