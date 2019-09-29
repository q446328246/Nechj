using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.SessionState;
using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1MultiEntity;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class backupDB : PageBase, IRequiresSessionState
    {
        public List<string[]> bakinfo = new List<string[]>();

        protected void Page_Load(object sender, EventArgs e)
        {
            string str3;
            base.CheckLogin();
            if (!Page.IsPostBack)
            {
            }
            if ((Page.Request["action"] != null) && (Page.Request["action"] == "download"))
            {
                str3 = Page.Request["file"];
                base.Response.ContentType = "application/octet-stream";
                base.Response.Clear();
                base.Response.AddHeader("content-disposition", "attachment; filename=" + str3);
                base.Response.ContentType = "application/octet-stream";
                base.Response.WriteFile(base.Server.MapPath("/App_Data/") + str3);
                base.Response.End();
            }
            else
            {
                if ((Page.Request["action"] != null) && (Page.Request["action"] == "del"))
                {
                    var operateLog = new ShopNum1_OperateLog
                    {
                        Record = "删除成功",
                        OperatorID = base.ShopNum1LoginID,
                        IP = Globals.IPAddress,
                        PageName = "backupDB.aspx",
                        Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                    };
                    base.OperateLog(operateLog);
                    str3 = Page.Request["file"];
                    File.Delete(base.Server.MapPath("/App_Data/") + str3);
                }
                if ((Page.Request["action"] != null) && (Page.Request["action"] == "reduction"))
                {
                    str3 = Page.Request["file"];
                    string str2 = str3.Substring(0, str3.LastIndexOf('_'));
                    DataTable table =
                        DatabaseExcetue.ReturnDataTable(("select spid from master..sysprocesses where dbid=db_id( '" +
                                                         str2 + "') "));
                    string connectionString =
                        " Data Source=localhost;Initial Catalog=master;User Id=sa;Password=sa;Connect TimeOut=6000;Persist Security Info=True;";
                    var connection = new SqlConnection(connectionString);
                    connection.Open();
                    for (int i = 0; i <= (table.Rows.Count - 1); i++)
                    {
                        new SqlCommand(" use master kill " + table.Rows[i][0], connection).ExecuteNonQuery();
                    }
                    string cmdText = "backup log " + str2 + " to disk='" + base.Server.MapPath("/App_Data/") + str3 +
                                     "'  restore database " + str2 + "  from disk='" + base.Server.MapPath("/App_Data/") +
                                     str3 + "'";
                    try
                    {
                        new SqlCommand(cmdText, connection).ExecuteNonQuery();
                        MessageBox.Show("还原数据库成功。");
                        SqlConnection.ClearAllPools();
                        connection.Close();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("还原数据库失败");
                    }
                }
                bakinfo = GetDBfile();
            }
        }

        protected void ButtonBackup_Click(object sender, EventArgs e)
        {
            string str = DatabaseExcetue.GetConnstring().Split(new[] {';'})[1].Split(new[] {'='})[1];
            var builder = new StringBuilder();
            builder.Append(" backup database [" + str + "] to disk='" +
                           Page.Server.MapPath("/App_Data/" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".bak") + "';");
            try
            {
                var operateLog = new ShopNum1_OperateLog
                    {
                        Record = "备份数据库成功",
                        OperatorID = base.ShopNum1LoginID,
                        IP = Globals.IPAddress,
                        PageName = "backupDB.aspx",
                        Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                    };
                base.OperateLog(operateLog);
                DatabaseExcetue.RunNonQuery(builder.ToString());
                bakinfo = GetDBfile();
                MessageBox.Show("备份数据库成功");
            }
            catch (Exception)
            {
                MessageBox.Show("备份数据库失败");
            }
        }

        public List<string[]> GetDBfile()
        {
            FileInfo[] files = new DirectoryInfo(Page.Server.MapPath("/App_Data")).GetFiles();
            var list = new List<string[]>();
            foreach (FileInfo info2 in files)
            {
                var regex = new Regex(".bak");
                if (regex.IsMatch(info2.Name.ToLower()))
                {
                    var item = new[] {info2.Name, info2.CreationTime.ToString()};
                    list.Add(item);
                }
            }
            return list;
        }


    }
}