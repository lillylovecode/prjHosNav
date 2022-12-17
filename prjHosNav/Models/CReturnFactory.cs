using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

namespace prjHosNav.Models
{
    public class CReturnFactory
    {
        internal List<CReturn> queryByKeyword(string keyword)
        {
            string sql = "SELECT * FROM tReturn WHERE ";
            sql += " RType LIKE @K_KEYWORD OR";
            sql += " RHospital LIKE @K_KEYWORD OR";
            sql += " RDate LIKE @K_KEYWORD";
            List<SqlParameter> paras = new List<SqlParameter>();
            paras.Add(new SqlParameter("K_KEYWORD", "%" + keyword + "%"));
            return queryBySql(sql, paras);
        }

        public List<CReturn> queryByMId(int mid)
        {
            string sql = "SELECT * FROM tReturn WHERE MId=@K_MID";
            List<SqlParameter> paras = new List<SqlParameter>();
            paras.Add(new SqlParameter("@K_MID", mid));
            List<CReturn> list = queryBySql(sql, paras);
            if (list.Count > 0)
                return list;
            return null;
        }

        public List<CReturn> queryAll()
        {
            string sql = "SELECT * FROM tReturn ";
            return queryBySql(sql, null);
        }

        public List<CReturn> List()
        {
            string sql = "SELECT * FROM tReturn";
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=.;Initial Catalog=dbHospital;Integrated Security=True";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            List<CReturn> list = new List<CReturn>();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                CReturn o = new CReturn()
                {
                    RId = (int)reader["RId"],
                    MId = reader["MId"].ToString(),
                    RType = reader["RType"].ToString(),
                    RHospital = reader["RHospital"].ToString(),
                    RDate = reader["RDate"].ToString()
                };
                list.Add(o);
            }
            con.Close();
            return list;
        }

        public int create(CReturn p)
        {
            int i;
            List<SqlParameter> list = new List<SqlParameter>();
            string sql = "INSERT INTO tReturn (";
            if (!string.IsNullOrEmpty(p.MId))
                sql += "MId,";
            if (!string.IsNullOrEmpty(p.RType))
                sql += "RType,";
            if (!string.IsNullOrEmpty(p.RHospital))
                sql += "RHospital,";
            if (!string.IsNullOrEmpty(p.RDate))
                sql += "RDate,";

            sql = sql.Trim();
            if (sql.Substring(sql.Length - 1, 1) == ",")
                sql = sql.Substring(0, sql.Length - 1);

            sql += " )VALUES( ";
            if (!string.IsNullOrEmpty(p.MId))
            {
                list.Add(new SqlParameter("@K_MId", p.MId));
                sql += "@K_MId,";
            }
            if (!string.IsNullOrEmpty(p.RType))
            {
                list.Add(new SqlParameter("@K_RType", p.RType));
                sql += "@K_RType,";
            }
            if (!string.IsNullOrEmpty(p.RHospital))
            {
                list.Add(new SqlParameter("@K_RHospital", p.RHospital));
                sql += "@K_RHospital,";
            }
            if (!string.IsNullOrEmpty(p.RDate))
            {
                list.Add(new SqlParameter("@K_RDate", p.RDate));
                sql += "@K_RDate,";
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
            string sql = "DELETE FROM tReturn WHERE RId=@K_RId";
            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@K_RId", id));
            i = executeSQL(sql, list);
            return i;
        }

        public int update(CReturn p)
        {
            int i;
            string sql = "UPDATE tReturn SET ";
            sql += " MId = @K_MId,";
            sql += " RType = @K_RType,";
            sql += " RHospital = @K_RHospital,";
            sql += " RDate = @K_RDate ";            
            sql += " WHERE RId = @K_RId";
            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@K_MId", (object)p.MId));
            list.Add(new SqlParameter("@K_RType", (object)p.RType));
            list.Add(new SqlParameter("@K_RHospital", (object)p.RHospital));
            list.Add(new SqlParameter("@K_RDate", (object)p.RDate));
            list.Add(new SqlParameter("@K_RId", (object)p.RId));
            i = executeSQL(sql, list);
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
            i = cmd.ExecuteNonQuery();
            return i;
        }

        private List<CReturn> queryBySql(string sql, List<SqlParameter> paras)
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
            List<CReturn> list = new List<CReturn>();
            while (reader.Read())
            {
                CReturn x = new CReturn()
                {
                    RId = (int)reader["RId"],
                    MId = reader["MId"].ToString(),
                    RType = reader["RType"].ToString(),
                    RHospital = reader["RHospital"].ToString(),
                    RDate = reader["RDate"].ToString()
                };
                list.Add(x);
            }
            con.Close();
            return list;
        }
    }
}