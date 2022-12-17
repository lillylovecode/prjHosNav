using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;


namespace prjHosNav.Models
{
    public class CMemberFactory
    {
        public List<CMember> queryAll()
        {
            string sql = "SELECT * FROM tMember";
            return queryBySql(sql, null);
        }

        private List<CMember> queryBySql(string sql, List<SqlParameter> paras)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=.;Initial Catalog=dbHospital;Integrated Security=True";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            if (paras != null)
            {
                foreach (SqlParameter p in paras)
                {
                    cmd.Parameters.Add(p);
                }
            }
            SqlDataReader reader = cmd.ExecuteReader();
            List<CMember> list = new List<CMember>();
            while (reader.Read())
            {
                CMember x = new CMember()
                {
                    mId = (int)reader["MId"],
                    mName = reader["MName"].ToString(),
                    mEmail = reader["MEmail"].ToString(),
                    mPassword = reader["MPassword"].ToString(),
                    mPhone = reader["MPhone"].ToString(),
                    mGender = reader["MGender"].ToString(),
                    mAddress = reader["MAddress"].ToString(),
                    mAuthority = reader["MAuthority"].ToString()
                };
                list.Add(x);
            }
            con.Close();
            return list;
        }

        public CMember queryById(int id)
        {
            string sql = "SELECT * FROM tMember WHERE MId = @mId";
            List<SqlParameter> paras = new List<SqlParameter>();
            paras.Add(new SqlParameter("mId", id));
            List<CMember> list = queryBySql(sql, paras);
            if (list.Count > 0)
            {
                return list[0];
            }
            return null;
        }

        internal CMember queryByEmail(string email)
        {
            string sql = "SELECT * FROM tMember WHERE MEmail = @mEmail";
            List<SqlParameter> paras = new List<SqlParameter>();
            paras.Add(new SqlParameter("mEmail", email));
            List<CMember> list = queryBySql(sql, paras);
            if (list.Count > 0)
            {
                return list[0];
            }
            return null;
        }

        internal bool queryByEmailCheck(string email)
        {
            string sql = "SELECT * FROM tMember WHERE MEmail = @mEmail";
            List<SqlParameter> paras = new List<SqlParameter>();
            paras.Add(new SqlParameter("mEmail", email));
            List<CMember> list = queryBySql(sql, paras);
            if (list.Count > 0)
            {
                return true;
            }
            return false;
        }

        private void executeSQL(string sql, List<SqlParameter> paras)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=.;Initial Catalog=dbHospital;Integrated Security=True";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            foreach (SqlParameter p in paras)
                cmd.Parameters.Add(p);
            cmd.ExecuteNonQuery();
        }

        public void update(CMember c)
        {
            string sql = "UPDATE tMember SET ";
            sql += " MName = @mName, ";            
            sql += " MPassword = @mPassword, ";
            sql += " MPhone = @mPhone, ";
            sql += " MGender=@mGender";
            //sql += " MAddress=@mAddress";
            sql += " WHERE MID = @mId";
            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@mName", c.mName));           
            list.Add(new SqlParameter("@mPassword", c.mPassword));
            list.Add(new SqlParameter("@mPhone", c.mPhone));
            list.Add(new SqlParameter("@mGender", c.mGender));
            /*list.Add(new SqlParameter("@mAddress", c.mAddress))*/;
            list.Add(new SqlParameter("@mId", c.mId));
            executeSQL(sql, list);
        }

        public void create(CMember c)
        {
            List<SqlParameter> list = new List<SqlParameter>();
            string sql = "INSERT INTO tMember (";
            if (!string.IsNullOrEmpty(c.mName))
                sql += "MName,";
            if (!string.IsNullOrEmpty(c.mEmail))
                sql += "MEmail,";
            if (!string.IsNullOrEmpty(c.mPassword))
                sql += "MPassword,";
            if (!string.IsNullOrEmpty(c.mPhone))
                sql += "MPhone,";
            if (!string.IsNullOrEmpty(c.mGender))
                sql += "MGender,";
            if (!string.IsNullOrEmpty(c.mAddress))
                sql += "MAddress,";
            if (!string.IsNullOrEmpty(c.mAuthority))
                sql += "MAuthority,";

            sql = sql.Trim();
            if (sql.Substring(sql.Length - 1, 1) == ",")
                sql = sql.Substring(0, sql.Length - 1);

            sql += " )VALUES( ";
            if (!string.IsNullOrEmpty(c.mName))
            {
                list.Add(new SqlParameter("@mName", c.mName));
                sql += "@mName,";
            }
            if (!string.IsNullOrEmpty(c.mEmail))
            {
                list.Add(new SqlParameter("@mEmail", c.mEmail));
                sql += "@mEmail,";
            }
            if (!string.IsNullOrEmpty(c.mPassword))
            {
                list.Add(new SqlParameter("@mPassword", c.mPassword));
                sql += "@mPassword,";
            }
            if (!string.IsNullOrEmpty(c.mPhone))
            {
                list.Add(new SqlParameter("@mPhone", c.mPhone));
                sql += "@mPhone,";
            }
            if (!string.IsNullOrEmpty(c.mGender))
            {
                list.Add(new SqlParameter("@mGender", c.mGender));
                sql += "@mGender,";
            }
            if (!string.IsNullOrEmpty(c.mAddress))
            {
                list.Add(new SqlParameter("@mAddress", c.mAddress));
                sql += "@mAddress,";
            }
            if (!string.IsNullOrEmpty(c.mAuthority))
            {
                list.Add(new SqlParameter("@mAuthority", c.mAuthority));
                sql += "@mAuthority,";
            }

            sql = sql.Trim();
            if (sql.Substring(sql.Length - 1, 1) == ",")
                sql = sql.Substring(0, sql.Length - 1);
            sql += ")";
            executeSQL(sql, list);
        }
    }
}