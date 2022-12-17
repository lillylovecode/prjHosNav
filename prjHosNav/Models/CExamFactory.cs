using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace prjHosNav.Models
{
    public class CExamFactory
    {
        public List<CExamination> queryAll()
        {
            string sql = "SELECT * FROM tExamination";
            return queryBySql(sql, null);
        }

        private List<CExamination> queryBySql(string sql, List<SqlParameter> paras)
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
            List<CExamination> list = new List<CExamination>();
            while (reader.Read())
            {
                CExamination x = new CExamination()
                {
                    fEId = (int)reader["fEId"],
                    fEName = reader["fEName"].ToString(),
                    fENotice = reader["fENotice"].ToString()
                };
                list.Add(x);
            }
            con.Close();
            return list;
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

        internal List<CExamination> queryByKeyword(string keyword)
        {
            string sql = "SELECT * FROM tExamination WHERE ";
            sql += " fEName LIKE @K_KEYWORD ";
            List<SqlParameter> paras = new List<SqlParameter>();
            paras.Add(new SqlParameter("K_KEYWORD", "%" + keyword + "%"));
            return queryBySql(sql, paras);
        }

        public CExamination queryById(int id)
        {
            string sql = "SELECT * FROM tExamination WHERE fEId=@K_FID";
            List<SqlParameter> paras = new List<SqlParameter>();
            paras.Add(new SqlParameter("@K_FID", id));
            List<CExamination> list = queryBySql(sql, paras);
            if (list.Count > 0)
                return list[0];
            return null;
        }
    }

}