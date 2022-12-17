using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace prjHosNav.Models
{
    public class CHospitalFactory
    {
        public List<CHospital> queryAll()
        {
            string sql = "SELECT * FROM tHospital";
            return queryBySql(sql, null);
        }

        private List<CHospital> queryBySql(string sql, List<SqlParameter> paras)
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
            List<CHospital> list = new List<CHospital>();
            while (reader.Read())
            {
                CHospital x = new CHospital()
                {
                    hId = reader["hId"].ToString(),
                    hName = reader["hName"].ToString(),
                    hKeyword = reader["hKeyword"].ToString(),
                    hPhone = reader["hPhone"].ToString(),
                    hAddress = reader["hAddress"].ToString(),
                    hWebsite = reader["hWebsite"].ToString(),
                    hProgress = reader["hProgress"].ToString(),
                    hOutpatient = reader["hOutpatient"].ToString(),
                    hPhoto = reader["hPhoto"].ToString()
                };
                list.Add(x);
            }
            con.Close();
            return list;
        }

        public CHospital queryById(string id)
        {
            string sql = "SELECT * FROM tHospital WHERE hId = @hId";
            List<SqlParameter> paras = new List<SqlParameter>();
            paras.Add(new SqlParameter("hId", id));
            List<CHospital> list = queryBySql(sql, paras);
            if (list.Count > 0)
            {
                return list[0];
            }
            return null;
        }

    }
}