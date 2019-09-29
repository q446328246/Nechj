using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using System.Web.SessionState;
using System.Data;
using ShopNum1.Common.ShopNum1.Common;

using ShopNum1.Deploy.Tj88Rank;


namespace ShopNum1.Deploy.Main.Admin
{
    public partial class UpdateCommunity :   PageBase, IRequiresSessionState
    {
        ServiceSlecetOrder sso = new ServiceSlecetOrder();
        ShopNum1_Member_Action sma = new ShopNum1_Member_Action();
        protected void Page_Load(object sender, EventArgs e)
        {

            base.CheckLogin();
             xianshi.Text = "";
        }
        
        protected void Button1_Click(object sender, EventArgs e)
        {
            string memberStart = TextBox1.Text;//(原来的哪个)
            string memberLast = TextBox2.Text;//(改后的哪个)
            try
            {
                var memberrankguid_Action = (ShopNum1_Member_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Member_Action();

                DataTable cc = memberrankguid_Action.GetCurrentMemberRankGuid_two(memberStart);
                if (cc.Rows.Count==0||cc==null)
                {
                     xianshi.Text = "原有会员不存在。";
                     return;
                }
                DataTable table = memberrankguid_Action.SelectMemberloginid_By_NO(memberStart);
                if (table.Rows.Count == 0 || table == null)
                {
                    xianshi.Text = "原有会员不存在。";
                    return;
                }

                DataTable table1 = memberrankguid_Action.SelectMemberloginid_By_NO(memberLast);
                if (table1.Rows.Count == 0 || table1 == null)
                {
                    xianshi.Text = "原有会员不存在。";
                    return;
                }
                string stratmemberloginid = table.Rows[0]["MemLoginID"].ToString();

                string lastmemberloginid = table1.Rows[0]["MemLoginID"].ToString();
                string memberGuid = cc.Rows[0]["MemberRankGuid"].ToString();
                int c = memberrankguid_Action.UpdateMemberRankGuid_NO(memberLast, memberGuid);
                int c1 = memberrankguid_Action.UpdateMemberRankGuid_NO(memberStart, "575B91F2-1B30-4ABD-AD2B-5EF33A36F9C0");
                
                if (c != 0 & c1 != 0)
                {
                    DataTable membership = memberrankguid_Action.GetMemberShip(memberStart);
                    string LevelNmae="";
                    if (memberGuid.ToUpper()==MemberLevel.AGENT_MEMBER_ID_three.ToUpper())
	              {
		               LevelNmae="区代二";
	              }
                    else if (memberGuid.ToUpper()==MemberLevel.AGENT_MEMBER_ID_two.ToUpper())
	              {
		               LevelNmae="区代一";
	              }
                    else if (memberGuid.ToUpper()==MemberLevel.COMMUNITY_MEMBER_ID_three.ToUpper())
	              {
		               LevelNmae="社区二";
	              }
                     else if (memberGuid.ToUpper()==MemberLevel.COMMUNITY_MEMBER_ID_two.ToUpper())
	              {
		               LevelNmae="社区一";
	              }
                    DateTime DT = System.DateTime.Now;

                    int c222 = memberrankguid_Action.UpdateMemberShipAdress(stratmemberloginid, lastmemberloginid);
                    int c22 = memberrankguid_Action.InsertUpdateRecordCommunity(memberStart, memberGuid, LevelNmae, DT, Convert.ToString(membership.Rows[0]["Upgrade_two_datatime"]), Convert.ToString(membership.Rows[0]["ExamineTime"]), Convert.ToString(membership.Rows[0]["Belongs"]));
                    int c2222 = memberrankguid_Action.UpdateShopNum1_MemberShip(stratmemberloginid, lastmemberloginid, memberLast);
                    
                    
                    string memberrank1 = sma.GetMemberRankGuid(TextBox1.Text);
                    string memberrank2 = sma.GetMemberRankGuid(TextBox2.Text);

                    string md5_one = ShopNum1.Common.MD5JiaMi.MyMd5JiaMi;
                    string privateKey_two = "RnkGuid=" + memberrank1 + "&MenberId=" + TextBox1.Text + md5_one + "";
                    string md5Check_two = ShopNum1.Common.MD5JiaMi.Md5JiaMi(privateKey_two);
                    sso.UpdateMenberRank_GZ(memberrank1, TextBox1.Text, md5Check_two);


                    string privateKey_three = "RnkGuid=" + memberrank2 + "&MenberId=" + TextBox2.Text + md5_one + "";
                    string md5Check_three = ShopNum1.Common.MD5JiaMi.Md5JiaMi(privateKey_three);
                    sso.UpdateMenberRank_GZ(memberrank2, TextBox2.Text, md5Check_three);

                    Page.ClientScript.RegisterClientScriptBlock(typeof(string), "alert", "<script>alert('修改成功！')</script>");

                }
                else if (c == 0 & c1 != 0)
                {
                    xianshi.Text = "原区代或社区修改失败，新区代或社区修改成功";
                }
                else if (c != 0 & c1 == 0)
                {
                    xianshi.Text = "原区代或社区修改成功，新区代或社区修改失败";
                }
                else if (c != 0 & c1 == 0)
                {
                    xianshi.Text = "原区代或社区修改失败，新区代或社区修改失败";
                }
            }
            catch (Exception ex)
            {
                
                throw;
              
            }
            
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string YuanLai = TextBox3.Text;
            string XinDe = TextBox4.Text;
          string  XinDeAdress="";
          string XinDeArea = "";
          string XinDeBelongs = "";
           string  YuanAdress = "";
            string  YuanArea = "";
            string YuanBelongs = "";
            var memberrankguid_Action = (ShopNum1_Member_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Member_Action();

            DataTable YuanTable = memberrankguid_Action.GetCurrentMemberRankGuid_two(YuanLai);
            DataTable XinDeTable = memberrankguid_Action.GetCurrentMemberRankGuid_two(XinDe);
            if (YuanTable.Rows.Count>0)
            {
                string YuanMemberRankGuid = YuanTable.Rows[0]["MemberRankGuid"].ToString();
            }
            else
            {
                Label1.Text = "修改失败";
                return;
            }
            if (XinDeTable.Rows.Count > 0)
            {
                string XinDeMemberRankGuid = XinDeTable.Rows[0]["MemberRankGuid"].ToString();
            }
            else
            {
                Label1.Text = "修改失败";
                return;
            }
            DataTable YuanIDtable = memberrankguid_Action.SelectMemberloginid_By_NO(YuanLai);
            DataTable XinDeIDtable = memberrankguid_Action.SelectMemberloginid_By_NO(XinDe);
            string YuanID = "";
            if (YuanIDtable.Rows.Count > 0)
            {
                 YuanID = YuanIDtable.Rows[0]["MemLoginID"].ToString();
            }
            else
            {
                Label1.Text = "修改失败";
                return;
            }
            string XinDeID = "";
            if (XinDeIDtable.Rows.Count > 0)
            {
                 XinDeID = XinDeIDtable.Rows[0]["MemLoginID"].ToString();
            }
            else
            {
                Label1.Text = "修改失败";
                return;
            }
            DataTable YuanBelongsTable = memberrankguid_Action.SelectMemberShipBelongs(YuanLai);
            DataTable XinDeBelongsTable = memberrankguid_Action.SelectMemberShipBelongs(XinDe);
            if (YuanBelongsTable.Rows.Count > 0)
            {
                 YuanBelongs = YuanBelongsTable.Rows[0]["Belongs"].ToString();
            }
            else
            {
                Label1.Text = "修改失败";
                return;
            }
            if (XinDeBelongsTable.Rows.Count > 0)
            {
                 XinDeBelongs = XinDeBelongsTable.Rows[0]["Belongs"].ToString();
            }
            else
            {
                Label1.Text = "修改失败";
                return;
            }
            DataTable YuanMemberShipAllTable = memberrankguid_Action.SelectMemberShip(YuanLai);
            DataTable XinDeMemberShipAllTable = memberrankguid_Action.SelectMemberShip(XinDe);
            if (YuanMemberShipAllTable.Rows.Count > 0)
            {
                 YuanAdress = YuanMemberShipAllTable.Rows[0]["Adress"].ToString();
                 YuanArea = YuanMemberShipAllTable.Rows[0]["Area"].ToString();
            }
            else
            {
                Label1.Text = "修改失败";
                return;
            }
            if (XinDeMemberShipAllTable.Rows.Count > 0)
            {
                 XinDeAdress = XinDeMemberShipAllTable.Rows[0]["Adress"].ToString();
                 XinDeArea = XinDeMemberShipAllTable.Rows[0]["Area"].ToString();
            }
            else
            {
                Label1.Text = "修改失败";
                return;
            }
            string XinDeProvince="";
            string XinDeCity="";
            string XinDeDistrict = "";
            string YuanProvince = "";
            string YuanCity = "";
            string YuanDistrict = "";
            DataTable YuanMemberShipAdressAllTable = memberrankguid_Action.SelectMemberShipAdress(YuanID);
            DataTable XinDeMemberShipAdressAllTable = memberrankguid_Action.SelectMemberShipAdress(XinDeID);
            if (YuanMemberShipAdressAllTable.Rows.Count > 0)
            {
                 YuanProvince = YuanMemberShipAdressAllTable.Rows[0]["Province"].ToString();
                 YuanCity = YuanMemberShipAdressAllTable.Rows[0]["City"].ToString();
                 YuanDistrict = YuanMemberShipAdressAllTable.Rows[0]["District"].ToString();
            }
            else
            {
               
            }
            if (XinDeMemberShipAdressAllTable.Rows.Count > 0)
            {
                 XinDeProvince = XinDeMemberShipAdressAllTable.Rows[0]["Province"].ToString();
                 XinDeCity = XinDeMemberShipAdressAllTable.Rows[0]["City"].ToString();
                 XinDeDistrict = XinDeMemberShipAdressAllTable.Rows[0]["District"].ToString();
            }
            else
            {
                
            }
            memberrankguid_Action.UpdateShopNum1_MemberShipAll(YuanLai, XinDeAdress, XinDeArea, XinDeBelongs);
            memberrankguid_Action.UpdateShopNum1_MemberShipAll(XinDe, YuanAdress, YuanArea, YuanBelongs);

            if (XinDeProvince==""&&XinDeCity==""&&XinDeDistrict=="")
            {
                
            }
            else
            {
                memberrankguid_Action.UpdateMemberShipAdressAll(YuanID, XinDeProvince, XinDeCity, XinDeDistrict);
            }
            if (YuanProvince == "" && YuanCity == "" && YuanDistrict == "")
            {

            }
            else
            {
                memberrankguid_Action.UpdateMemberShipAdressAll(XinDeID, YuanProvince, YuanCity, YuanDistrict);
            }
            string memberrank1 = sma.GetMemberRankGuid(TextBox1.Text);
            string memberrank2 = sma.GetMemberRankGuid(TextBox2.Text);

            string md5_one = ShopNum1.Common.MD5JiaMi.MyMd5JiaMi;
            string privateKey_two = "RnkGuid=" + memberrank1 + "&MenberId=" + TextBox1.Text + md5_one + "";
            string md5Check_two = ShopNum1.Common.MD5JiaMi.Md5JiaMi(privateKey_two);
            sso.UpdateMenberRank_GZ(memberrank1, TextBox1.Text, md5Check_two);


            string privateKey_three = "RnkGuid=" + memberrank2 + "&MenberId=" + TextBox2.Text + md5_one + "";
            string md5Check_three = ShopNum1.Common.MD5JiaMi.Md5JiaMi(privateKey_three);
            sso.UpdateMenberRank_GZ(memberrank2, TextBox2.Text, md5Check_three);

            Page.ClientScript.RegisterClientScriptBlock(typeof(string), "alert", "<script>alert('修改成功！')</script>");
            
        }
    }
}