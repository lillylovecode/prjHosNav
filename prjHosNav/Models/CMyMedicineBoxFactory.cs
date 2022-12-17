using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace prjHosNav.Models
{
    public class CMyMedicineBoxFactory
    {
        public void update(CMyMedicineBoxDetail p)
        {
            string sql = "UPDATE tMyMedicineBox SET ";
            sql += " fChName = @K_FCHNAME,";
            sql += " fDayOfUse = @K_FDAYOFUSE,";
            sql += " fQuantityUse = @K_FQUANTITYUSE";
            sql += " WHERE fId =@K_FID  AND MId=@K_MID";
            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@K_FID", (object)p.fId));
            list.Add(new SqlParameter("@K_MID", (object)p.MId));
            list.Add(new SqlParameter("@K_FCHNAME", (object)p.fChName));
            list.Add(new SqlParameter("@K_FDAYOFUSE", (object)p.fDayOfUse));
            list.Add(new SqlParameter("@K_FQUANTITYUSE", (object)p.fQuantityUse));
            executeSQL(sql, list);
        }

        public void delete(int fId,int MId)
        {
            string sql = "DELETE FROM tMyMedicineBox WHERE fId=@K_FID AND MId=@K_MID";
            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@K_FID", fId));
            list.Add(new SqlParameter("@K_MID", MId));
            executeSQL(sql, list);
        }

        public CMyMedicineBoxDetail queryById(int fId)
        {
            string sql = "SELECT * FROM tMyMedicineBox WHERE fId=@K_FID";
            List<SqlParameter> paras = new List<SqlParameter>();
            paras.Add(new SqlParameter("@K_FID", fId));
            List<CMyMedicineBoxDetail> list = queryBySql(sql, paras);
            if (list.Count > 0)
                return list[0];
            return null;
        }

        public List<CMyMedicineBoxDetail> queryByMId(int MId)
        {
            string sql = "SELECT * FROM tMyMedicineBox WHERE MId=@K_MID";
            List<SqlParameter> paras = new List<SqlParameter>();
            paras.Add(new SqlParameter("@K_MID", MId));
            List<CMyMedicineBoxDetail> list = queryBySql(sql, paras);
            if (list.Count > 0)
                return list;
            return null;

        }

        public List<CMyMedicineBoxDetail> queryAll()
        {
            string sql = "SELECT * FROM tMyMedicineBox";

            return queryBySql(sql, null);
        }

        private List<CMyMedicineBoxDetail> queryBySql(string sql, List<SqlParameter> paras)
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
            List<CMyMedicineBoxDetail> list = new List<CMyMedicineBoxDetail>();
            while (reader.Read())
            {
                CMyMedicineBoxDetail x = new CMyMedicineBoxDetail()
                {
                    fChName = reader["fChName"].ToString(),
                    fImagePath = reader["fImagePath"].ToString(),
                    fDayOfUse = reader["fDayOfUse"].ToString(),
                    fQuantityUse = reader["fQuantityUse"].ToString(),
                    fId = (int)reader["fId"],
                    MId = reader["MId"].ToString()
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

        public void create(CMyMedicineBoxDetail p)
        {
            List<SqlParameter> list = new List<SqlParameter>();
            string sql = "INSERT INTO tMyMedicineBox (";
            if (!string.IsNullOrEmpty(p.fChName))
                sql += "fChName,";
            if (!string.IsNullOrEmpty(p.fImagePath))
                sql += "fImagePath,";
            if (!string.IsNullOrEmpty(p.fDayOfUse))
                sql += "fDayOfUse,";
            if (!string.IsNullOrEmpty(p.fQuantityUse))
                sql += "fQuantityUse, ";
            if (!string.IsNullOrEmpty(p.MId.ToString()))
                sql += "MId ";

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
            if (!string.IsNullOrEmpty(p.fImagePath))
            {
                list.Add(new SqlParameter("@K_fImagePath", p.fImagePath));
                sql += "@K_fImagePath,";
            }
            if (!string.IsNullOrEmpty(p.fDayOfUse))
            {
                list.Add(new SqlParameter("@K_fDayOfUse", p.fDayOfUse));
                sql += "@K_fDayOfUse,";
            }
            if (!string.IsNullOrEmpty(p.fQuantityUse))
            {
                list.Add(new SqlParameter("@K_fQuantityUse", p.fQuantityUse));
                sql += "@K_fQuantityUse,";
            }
            if (!string.IsNullOrEmpty(p.MId))
            {
                list.Add(new SqlParameter("@K_MId", p.MId));
                sql += "@K_MId,";
            }
            sql = sql.Trim();
            if (sql.Substring(sql.Length - 1, 1) == ",")
                sql = sql.Substring(0, sql.Length - 1);
            sql += ")";
            executeSQL(sql, list);
        }

    }
}