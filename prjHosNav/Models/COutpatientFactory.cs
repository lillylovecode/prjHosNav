using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

namespace prjHosNav.Models
{
    public class COutpatientFactory
    {
        public List<COutpatient> queryAll()
        {
            string sql = "SELECT * FROM tOutpatient";
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=.;Initial Catalog=dbHospital;Integrated Security=True";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            List<COutpatient> list = new List<COutpatient>();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                COutpatient o = new COutpatient()
                {
                    oid = (int)reader["oid"],
                    oName = reader["outpatientName"].ToString(),
                    oDoctor = reader["doctor"].ToString(),
                    oPhoto = reader["photo"].ToString()
                };
                list.Add(o);
            }
            con.Close();
            return list;
        }


        public int create(COutpatient p)
        {
            int i;
            List<SqlParameter> list = new List<SqlParameter>();
            string sql = "INSERT INTO tOutpatient (";
            if (!string.IsNullOrEmpty(p.oName))
                sql += "outpatientName,";
            if (!string.IsNullOrEmpty(p.oDoctor))
                sql += "doctor,";

            //------------去除逗號  整條sql最後一碼------
            sql = sql.Trim();
            if (sql.Substring(sql.Length - 1, 1) == ",")
                sql = sql.Substring(0, sql.Length - 1);

            sql += " )VALUES( ";
            if (!string.IsNullOrEmpty(p.oName))
            {
                list.Add(new SqlParameter("@K_oName", p.oName));
                sql += "@K_oName,";
            }
            if (!string.IsNullOrEmpty(p.oDoctor))
            {
                list.Add(new SqlParameter("@K_oDoctor", p.oDoctor));
                sql += "@K_oDoctor,";
            }
            

            sql = sql.Trim();
            if (sql.Substring(sql.Length - 1, 1) == ",")
                sql = sql.Substring(0, sql.Length - 1);
            sql += ")";
            i = executeSQL(sql, list);
            return i;
        }

        public int delete(int id)
        {
            int i;
            string sql = "DELETE FROM tOutpatient WHERE oid=@K_OID";
            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@K_OID", id));
            i = executeSQL(sql, list);
            return i;
        }

        public int update(COutpatient p)
        {
            int i;
            string sql = "UPDATE tOutpatient SET ";
            sql += " outpatientName = @K_ONAME,";
            sql += " doctor = @K_ODOCTOR";
            sql += " WHERE oid = @K_OID";
            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@K_OID", (object)p.oid));
            list.Add(new SqlParameter("@K_ONAME", (object)p.oName));
            list.Add(new SqlParameter("@K_ODOCTOR", (object)p.oDoctor));            
            i=executeSQL(sql, list);
            return i;
        }

        private int executeSQL(string sql, List<SqlParameter> paras)
        {
            int i;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=.;Initial Catalog=dbHospital;Integrated Security=True";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            foreach (SqlParameter p in paras)
                cmd.Parameters.Add(p);
            i= cmd.ExecuteNonQuery();
            return i;
        }

        public List<COutpatient> queryById(int id)
        {
            string sql = "SELECT * FROM tOutpatient WHERE oid=@K_OID";
            List<SqlParameter> paras = new List<SqlParameter>();
            paras.Add(new SqlParameter("@K_OID", id));
            List<COutpatient> list = queryBySql(sql, paras);
            if (list.Count > 0)
                return list;
            return null;
        }

        public List<COutpatient> queryByhId(string hid)
        {
            string sql = "SELECT * FROM tOutpatient WHERE hId=@K_HID";
            List<SqlParameter> paras = new List<SqlParameter>();
            paras.Add(new SqlParameter("@K_HID", hid));
            List<COutpatient> list = queryBySql(sql, paras);
            if (list.Count > 0)
                return list;
            return null;
        }

        private List<COutpatient> queryBySql(string sql, List<SqlParameter> paras)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=.;Initial Catalog=dbHospital;Integrated Security=True";
            con.Open();

            SqlCommand cmd = new SqlCommand(sql, con);
            if (paras != null)
            {
                foreach (SqlParameter p in paras)
                    cmd.Parameters.Add(p);
            }
            SqlDataReader reader = cmd.ExecuteReader();
            List<COutpatient> list = new List<COutpatient>();
            while (reader.Read())
            {
                COutpatient x = new COutpatient()
                {
                    oid = (int)reader["oid"],
                    oName = reader["outpatientName"].ToString(),
                    oDoctor = reader["doctor"].ToString(),
                    oPhoto = reader["photo"].ToString()
                };
                list.Add(x);
            }
            con.Close();
            return list;
        }

    }
}