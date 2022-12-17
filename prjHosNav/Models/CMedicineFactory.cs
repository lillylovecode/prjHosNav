using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace prjHosNav.Models
{
    public class CMedicineFactory
    {
        public void update(CMedicineDetail p)
        {
            string sql = "UPDATE tMedicine SET ";
            sql += " fChName = @K_FCHNAME,";
            sql += " fEnName = @K_FENNAME,";
            sql += " fSymptoms = @K_FSYMPTOMS,";
            sql += " fCaution = @K_FCAUTION,";
            sql += " fImagePath = @K_FIMAGEPATH";
            sql += " WHERE fId =@K_FID";
            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@K_FID", (object)p.fId));
            list.Add(new SqlParameter("@K_FCHNAME", (object)p.fChName));
            list.Add(new SqlParameter("@K_FENNAME", (object)p.fEnName));
            list.Add(new SqlParameter("@K_FSYMPTOMS", (object)p.fSymptoms));
            list.Add(new SqlParameter("@K_FCAUTION", (object)p.fCaution));
            list.Add(new SqlParameter("@K_FIMAGEPATH", (object)p.fImagePath));
            executeSQL(sql, list);
        }

        public void delete(int fId)
        {
            string sql = "DELETE FROM tMedicine WHERE fId=@K_FID";
            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@K_FID", fId));
            executeSQL(sql, list);
        }

        public CMedicineDetail queryById(int fId)
        {
            string sql = "SELECT * FROM tMedicine WHERE fId=@K_FID";
            List<SqlParameter> paras = new List<SqlParameter>();
            paras.Add(new SqlParameter("@K_FID", fId));
            List<CMedicineDetail> list = queryBySql(sql, paras);
            if (list.Count > 0)
                return list[0];
            return null;

        }


        public List<CMedicineDetail> queryAll()
        {
            string sql = "SELECT * FROM tMedicine";

            return queryBySql(sql, null);
        }

        private List<CMedicineDetail> queryBySql(string sql, List<SqlParameter> paras)
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
            List<CMedicineDetail> list = new List<CMedicineDetail>();
            while (reader.Read())
            {
                CMedicineDetail x = new CMedicineDetail()
                {
                    fChName = reader["fChName"].ToString(),
                    fEnName = reader["fEnName"].ToString(),
                    fSymptoms = reader["fSymptoms"].ToString(),
                    fCaution = reader["fCaution"].ToString(),
                    fImagePath = reader["fImagePath"].ToString(),
                    fId = (int)reader["fId"]
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

        public void create(CMedicineDetail p)
        {
            List<SqlParameter> list = new List<SqlParameter>();
            string sql = "INSERT INTO tMedicine (";
            if (!string.IsNullOrEmpty(p.fChName))
                sql += "fChName,";
            if (!string.IsNullOrEmpty(p.fEnName))
                sql += "fEnName,";
            if (!string.IsNullOrEmpty(p.fSymptoms))
                sql += "fSymptoms,";
            if (!string.IsNullOrEmpty(p.fCaution))
                sql += "fCaution,";
            if (!string.IsNullOrEmpty(p.fImagePath))
                sql += "fImagePath,";

            //------------去除逗號  整條sql最後一碼------
            sql = sql.Trim();
            if (sql.Substring(sql.Length - 1, 1) == ",")
                sql = sql.Substring(0, sql.Length - 1);

            // cat  長度為3   Substring(0,sql.length)  cat
            //---------------到SQL整條句子的前一個字結束

            sql += " )VALUES( ";
            if (!string.IsNullOrEmpty(p.fChName))
            {
                list.Add(new SqlParameter("@K_FCHNAME", p.fChName));
                sql += "@K_FCHNAME,";
            }
            if (!string.IsNullOrEmpty(p.fEnName))
            {
                list.Add(new SqlParameter("@K_FENNAME", p.fEnName));
                sql += "@K_FENNAME,";
            }
            if (!string.IsNullOrEmpty(p.fSymptoms))
            {
                list.Add(new SqlParameter("@K_FSYMPTOMS", p.fSymptoms));
                sql += "@K_FSYMPTOMS,";
            }
            if (!string.IsNullOrEmpty(p.fCaution))
            {
                list.Add(new SqlParameter("@K_FCAUTION", p.fCaution));
                sql += "@K_FCAUTION,";
            }
            if (!string.IsNullOrEmpty(p.fImagePath))
            {
                list.Add(new SqlParameter("@K_fImagePath", p.fImagePath));
                sql += "@K_fImagePath,";
            }
            sql = sql.Trim();
            if (sql.Substring(sql.Length - 1, 1) == ",")
                sql = sql.Substring(0, sql.Length - 1);
            sql += ")";
            executeSQL(sql, list);

        }

        internal List<CMedicineDetail> queryByKeyword(string keyword)
        {
            string sql = "SELECT * FROM tMedicine WHERE ";
            sql += " fChName LIKE @K_KEYWORD OR";
            sql += " fEnName LIKE @K_KEYWORD OR";
            sql += " fSymptoms LIKE @K_KEYWORD OR";
            sql += " fCaution LIKE @K_KEYWORD";
            List<SqlParameter> paras = new List<SqlParameter>();
            paras.Add(new SqlParameter("K_KEYWORD", "%" + keyword + "%"));
            return queryBySql(sql, paras);
        }
    }
}