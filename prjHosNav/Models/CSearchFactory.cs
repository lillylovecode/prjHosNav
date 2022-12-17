using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace prjHosNav.Models
{
    public class CSearchFactory
    {
        internal List<CSearch> queryByKeyword(string keyword)
        {
            string sql = "SELECT * FROM tSearch WHERE ";
            sql += " SType LIKE @K_KEYWORD OR";
            sql += " SDisease LIKE @K_KEYWORD OR";
            sql += " SSymptom LIKE @K_KEYWORD";
            List<SqlParameter> paras = new List<SqlParameter>();
            paras.Add(new SqlParameter("K_KEYWORD", "%" + keyword + "%"));
            return queryBySql(sql, paras);
        }

        public List<CSearch> queryAll()
        {
            string sql = "SELECT * FROM tSearch ";
            return queryBySql(sql, null);
        }

        private List<CSearch> queryBySql(string sql, List<SqlParameter> paras)
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
            List<CSearch> list = new List<CSearch>();
            while (reader.Read())
            {
                CSearch x = new CSearch()
                {
                    SType = reader["SType"].ToString(),
                    SDisease = reader["SDisease"].ToString(),
                    SSymptom = reader["SSymptom"].ToString(),
                    SId = (int)reader["SId"]
                };
                list.Add(x);
            }
            con.Close();
            return list;
        }

        public int create(CSearch p)
        {
            int i;
            List<SqlParameter> list = new List<SqlParameter>();
            string sql = "INSERT INTO tSearch (";
            if (!string.IsNullOrEmpty(p.SType))
                sql += "SType,";
            if (!string.IsNullOrEmpty(p.SDisease))
                sql += "SDisease,";
            if (!string.IsNullOrEmpty(p.SSymptom))
                sql += "SSymptom,";

            sql = sql.Trim();
            if (sql.Substring(sql.Length - 1, 1) == ",")
                sql = sql.Substring(0, sql.Length - 1);

            sql += " )VALUES( ";
            if (!string.IsNullOrEmpty(p.SType))
            {
                list.Add(new SqlParameter("@K_SType", p.SType));
                sql += "@K_SType,";
            }
            if (!string.IsNullOrEmpty(p.SDisease))
            {
                list.Add(new SqlParameter("@K_SDisease", p.SDisease));
                sql += "@K_SDisease,";
            }
            if (!string.IsNullOrEmpty(p.SSymptom))
            {
                list.Add(new SqlParameter("@K_SSymptom", p.SSymptom));
                sql += "@K_SSymptom,";
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
            string sql = "DELETE FROM tSearch WHERE SId=@K_SId";
            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@K_SId", id));
            i = executeSQL(sql, list);
            return i;
        }

        public int update(CSearch p)
        {
            int i;
            string sql = "UPDATE tSearch SET ";
            sql += " SType = @K_SType,";
            sql += " SDisease = @K_SDisease,";
            sql += " SSymptom = @K_SSymptom";
            sql += " WHERE SId = @K_SId";
            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@K_SType", (object)p.SType));
            list.Add(new SqlParameter("@K_SDisease", (object)p.SDisease));
            list.Add(new SqlParameter("@K_SSymptom", (object)p.SSymptom));
            list.Add(new SqlParameter("@K_SId", (object)p.SId));
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
    }
}