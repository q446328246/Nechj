
using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1MultiEntity;
using System.Data;
using System.Data.Common;

namespace ShopNum1.BusinessLogic
{
    public class ShopNum1_MemberActivate_Action : IShopNum1_MemberActivate_Action
    {

        public DataTable SelectActivate(string mobile, string memLoginID)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(2);

            parms[0].ParameterName = "@memLoginID";
            parms[0].Value = memLoginID;
            parms[1].ParameterName = "@mobile";
            parms[1].Value = mobile; 
            return
                DatabaseExcetue.ReturnDataTable(" SELECT  *  FROM ShopNum1_MemberActivate  WHERE MemberID=@memLoginID and phone=@mobile", parms);
        }

        public DataTable GzSelectActivate(string mobile)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            
            parms[0].ParameterName = "@mobile";
            parms[0].Value = mobile;
            return
                DatabaseExcetue.ReturnDataTable(" SELECT  *  FROM ShopNum1_MemberActivate  WHERE  phone=@mobile", parms);
        }
        public DataTable GzSelectActivateIPAdress(string IPAdress)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);


            parms[0].ParameterName = "@IPAdress";
            parms[0].Value = IPAdress;
            return
                DatabaseExcetue.ReturnDataTable(" SELECT  *  FROM ShopNum1_MemberActivate  WHERE  IPAdress=@IPAdress and [CreateTime]>(select convert(DATE,dateadd(dd,0,GETDATE()))  as Date)", parms);
        }
        public DataTable GzSelectActivateIPAdressTwo(string IPAdress)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);


            parms[0].ParameterName = "@IPAdress";
            parms[0].Value = IPAdress;
            return
                DatabaseExcetue.ReturnDataTable(" SELECT  *  FROM ShopNum1_MemberActivate  WHERE  IPAdress=@IPAdress and (SELECT DATEADD(n, +1, [CreateTime]) )>GETDATE()", parms);
        }

        public bool CheckKey(string type, string MemberID, string string_0, string typeinfo)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(4);
            parms[0].ParameterName = "@type";
            parms[0].Value = type;
            parms[1].ParameterName = "@MemberID";
            parms[1].Value = MemberID;
            parms[2].ParameterName = "@string_0";
            parms[2].Value = string_0;
            parms[3].ParameterName = "@typeinfo";
            parms[3].Value = typeinfo;
            string strSql = ("SELECT * From ShopNum1_MemberActivate WHERE MemberID=@MemberID") + " AND [key]=@string_0";
            if (Operator.FilterString(type) != string.Empty)
            {
                if (type == "Email")
                {
                    strSql = strSql + " AND Email=@typeinfo";
                }
                if (type == "Mobile")
                {
                    strSql = strSql + " AND phone=@typeinfo";
                }
            }
            return (DatabaseExcetue.ReturnDataTable(strSql,parms).Rows.Count > 0);
        }

        public string CheckMobileCode(string strkey, string mobile, string Type)
        {
            return
                DatabaseExcetue.ReturnString("SELECT COUNT([key]) FROM ShopNum1_MemberActivate   WHERE [key]='" +
                                             Operator.FilterString(strkey) + "' and phone='" + mobile +
                                             "' AND ExtireTime>GETDATE()");
        }
        public int UpdateMobileCode(string mobile, string MemberID, string key ,string time)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(4);

            parms[0].ParameterName = "@mobile";
            parms[0].Value = mobile;

            parms[1].ParameterName = "@MemberID";
            parms[1].Value = MemberID;
            parms[2].ParameterName = "@key";
            parms[2].Value = key;
            parms[3].ParameterName = "@time";
            parms[3].Value = time;
            return
                DatabaseExcetue.RunNonQuery(" update  ShopNum1_MemberActivate set [key]=@key,ExtireTime=@time where phone=@mobile and MemberID=@MemberID", parms);
        }
        public int UpdateMobileCodetwo(string mobile, string MemberID, string key, string time, string IPAdress)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(5);

            parms[0].ParameterName = "@mobile";
            parms[0].Value = mobile;

            parms[1].ParameterName = "@MemberID";
            parms[1].Value = MemberID;
            parms[2].ParameterName = "@key";
            parms[2].Value = key;
            parms[3].ParameterName = "@time";
            parms[3].Value = time;
            parms[4].ParameterName = "@IPAdress";
            parms[4].Value = IPAdress;
            return
                DatabaseExcetue.RunNonQuery(" update  ShopNum1_MemberActivate set [IPAdress]=@IPAdress,[CreateTime]=getdate(), [key]=@key,ExtireTime=@time where phone=@mobile and MemberID=@MemberID", parms);
        }
        public int DeleteKey(string MemberID, string Key)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(2);

            parms[0].ParameterName = "@MemberID";
            parms[0].Value = MemberID;

            parms[1].ParameterName = "@Key";
            parms[1].Value = Key;
            return
                DatabaseExcetue.RunNonQuery(("Delete ShopNum1_MemberActivate WHERE MemberID=@MemberID") +
                                            " AND [key]=@Key",parms);
        }

        public int DeleteKey(string MemberID, string strPhoneEmail, string strType)
        {
            string strSql = "Delete ShopNum1_MemberActivate WHERE Isinvalid = '0' And MemberID='" + MemberID + "'";
            if (strType.Equals("phone"))
            {
                strSql = strSql + " AND Type= '1' AND Phone = '" + Operator.FilterString(strPhoneEmail) + "'";
            }
            else
            {
                strSql = strSql + " AND Type = '0' AND Email = '" + Operator.FilterString(strPhoneEmail) + "'";
            }
            return DatabaseExcetue.RunNonQuery(strSql);
        }

        public int InsertforGetMobileCode(ShopNum1_MemberActivate MemberActivate)
        {
            return DatabaseExcetue.RunNonQuery(string.Concat(new object[]
            {
                "insert into ShopNum1_MemberActivate([Guid],Phone,[key],MemberID,pwd ,Email,extireTime,isinvalid,type)Values('"
                , MemberActivate.Guid, "','", MemberActivate.Phone, "','", MemberActivate.Key, "','",
                MemberActivate.MemberID, "','", MemberActivate.Pwd, "','", MemberActivate.Email, "','",
                MemberActivate.extireTime, "',", MemberActivate.isinvalid,
                ",", MemberActivate.type, ")"
            }));
        }

        public int InsertforGetMobileCodeTwo(ShopNum1_MemberActivateTwo MemberActivate)
        {
            return DatabaseExcetue.RunNonQuery(string.Concat(new object[]
            {
                "insert into ShopNum1_MemberActivate([Guid],Phone,[key],MemberID,pwd ,Email,extireTime,isinvalid,type,IPAdress,CreateTime)Values('"
                , MemberActivate.Guid, "','", MemberActivate.Phone, "','", MemberActivate.Key, "','",
                MemberActivate.MemberID, "','", MemberActivate.Pwd, "','", MemberActivate.Email, "','",
                MemberActivate.extireTime, "',", MemberActivate.isinvalid,
                ",", MemberActivate.type, ",'", MemberActivate.IPAdress, "','", MemberActivate.CreateTime, "')"
            }));
        }
        public int UpdateIsinvalid(string mobile, string MemberID, string string_0)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(3);

            parms[0].ParameterName = "@mobile";
            parms[0].Value = mobile;

            parms[1].ParameterName = "@MemberID";
            parms[1].Value = MemberID;
            parms[2].ParameterName = "@string_0";
            parms[2].Value = string_0;
            return
                DatabaseExcetue.RunNonQuery(" update  ShopNum1_MemberActivate set Isinvalid=1 where  [key]=@string_0  and phone=@mobile AND ExtireTime>GETDATE()  and type=1   and MemberID=@MemberID",parms);
        }
    }
}