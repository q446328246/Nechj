using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.SessionState;
using ShopNum1.BusinessLogic;
using System.Data;

namespace ShopNum1.Deploy.Main.Admin
{

    public partial class Team_LeaderShip : PageBase, IRequiresSessionState
    {
        ShopNum1_Member_Action memberaction = new ShopNum1_Member_Action();

        bool isadmin = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            isadmin = base.checkadmin();
            if (!Page.IsPostBack)
            {
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                string memloginid = TextBox1.Text.Trim();
                DataTable memtable = memberaction.SearchMembertwoWHJ(memloginid,isadmin);
                if (memtable.Rows.Count > 0)
                {
                    string RecoCode = memtable.Rows[0]["RecoCode"].ToString();
                    DataTable Superior = memberaction.SearchMembertwoMJC(memloginid);
                    if (Superior.Rows.Count > 0)
                    {
                        int SelectAddressByMemloginID = memberaction.UpdateLider(memloginid, RecoCode);
                        if (SelectAddressByMemloginID > 0)
                        {
                            Response.Write("<script>alert('修改成功！');</script>");
                            msg.InnerText = "修改作成功";
                        }
                        else
                        {
                            Response.Write("<script>alert('修改失败！');</script>");
                        }
                    }
                    else
                    {
                        Response.Write("<script>alert('该人下面没有团队');</script>");
                    }
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