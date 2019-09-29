using System;
using System.Text;
using ShopNum1.DataAccess;
using ShopNum1.Second;

namespace ShopNum1_Second
{
    public class ShopNum1_SecondUserAccess
    {
        public bool Add(ShopNum1_SecondUser model)
        {
            var builder = new StringBuilder();
            builder.Append("insert into ShopNum1_SecondUser(");
            builder.Append("MemlogID,SecondID,Secondtype,isAvailable)");
            builder.Append(" values (");
            builder.Append("@MemlogID,@SecondID,@Secondtype,@isAvailable)");
            builder.Append(";select @@IDENTITY");
            var paraName = new string[4];
            var paraValue = new string[4];
            paraName[0] = "@MemlogID";
            paraName[1] = "@SecondID";
            paraName[2] = "@Secondtype";
            paraName[3] = "@isAvailable";
            paraValue[0] = model.MemlogID;
            paraValue[1] = model.SecondID;
            paraValue[2] = model.Secondtype;
            paraValue[3] = model.isAvailable.ToString();
            return (DatabaseExcetue.ReturnObject(builder.ToString(), paraName, paraValue) != null);
        }

        public bool Delete(int ID)
        {
            var builder = new StringBuilder();
            builder.Append("delete from ShopNum1_SecondUser ");
            builder.Append(" where ID=@ID ");
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@ID";
            paraValue[0] = ID.ToString();
            return (DatabaseExcetue.RunNonQuery(builder.ToString(), paraName, paraValue) > 0);
        }

        public bool Exists(int ID)
        {
            var builder = new StringBuilder();
            builder.Append("select count(1) from ShopNum1_SecondUser");
            builder.Append(" where ID=@ID ");
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@ID";
            paraValue[0] = ID.ToString();
            return (Convert.ToInt32(DatabaseExcetue.ReturnObject(builder.ToString(), paraName, paraValue)) > 0);
        }

        public int GetMaxId()
        {
            return DatabaseExcetue.ReturnMaxID("ID", "ShopNum1_SecondUser");
        }

        public object GetMemLogid(string SecondID, string Secondtype)
        {
            var builder = new StringBuilder();
            builder.Append("select top (1) MemlogID from ShopNum1_SecondUser");
            builder.Append(" where SecondID=@SecondID AND Secondtype=@Secondtype ");
            var paraName = new string[2];
            var paraValue = new string[2];
            paraName[0] = "@SecondID";
            paraValue[0] = SecondID;
            paraName[1] = "@Secondtype";
            paraValue[1] = Secondtype;
            return DatabaseExcetue.ReturnObject(builder.ToString(), paraName, paraValue);
        }

        public bool Update(ShopNum1_SecondUser model)
        {
            var builder = new StringBuilder();
            builder.Append("update ShopNum1_SecondUser set ");
            builder.Append("MemlogID=@MemlogID,");
            builder.Append("SecondID=@SecondID,");
            builder.Append("Secondtype=@Secondtype,");
            builder.Append("isAvailable=@isAvailable");
            builder.Append(" where ID=@ID ");
            var paraName = new string[5];
            var paraValue = new string[5];
            paraName[0] = "@MemlogID";
            paraName[1] = "@SecondID";
            paraName[2] = "@Secondtype";
            paraName[3] = "@isAvailable";
            paraName[4] = "@ID";
            paraValue[0] = model.MemlogID;
            paraValue[1] = model.SecondID;
            paraValue[2] = model.Secondtype;
            paraValue[3] = model.isAvailable.ToString();
            paraValue[4] = model.ID.ToString();
            return (DatabaseExcetue.RunNonQuery(builder.ToString(), paraName, paraValue) > 0);
        }
    }
}