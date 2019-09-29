using ShopNum1.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.SessionState;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class AAA_KCE_QuerySuperior : PageBase, IRequiresSessionState
    {
        ShopNum1_Member_Action memberaction = new ShopNum1_Member_Action();
        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            if (!Page.IsPostBack)
            {
               
            }
        }



        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                string memloginid = TextBox4.Text.Trim();
                DataTable memtable = memberaction.SearchSuperior(memloginid,base.checkadmin());//查询指定用户的RecoCode
                if (memtable.Rows.Count > 0)
                {
                    string RecoCode = memtable.Rows[0]["RecoCode"].ToString();
                    string RecoCodes = RecoCode.Substring(0, RecoCode.Length - 1);
                    string[] sArray = RecoCodes.Split(',');
                    string xunhuan = "";
                    foreach (string ID in sArray)
                    {
  
                            DataTable memtabletwo = memberaction.SearchSuperiorMemloginID(ID, base.checkadmin());//查询每个ID对应的MemLoginID
                            if (memtable.Rows.Count > 0)
                            {
                                string SuperiorID = memtabletwo.Rows[0]["MemLoginID"].ToString();
                                xunhuan = xunhuan + "," + SuperiorID;
                            }
                                              
                    }
                    string demo2 = xunhuan.Substring(1, xunhuan.Length - 1);

                    this.TextArea1.Value = demo2;
                }
                else
                {
                    Response.Write("<script>alert('工号错误或不存在！');</script>");
                }
            }
            catch
            {
                Response.Write("<script>alert('系统错误！');</script>");
            }

        }
    }
}