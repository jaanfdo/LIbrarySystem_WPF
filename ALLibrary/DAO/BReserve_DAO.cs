using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace ALLibrary
{
    class BReserve_DAO
    {
        SqlDataReader reader = null;
        SqlCommand com = null;
        SqlConnection con = DB_Connection.getConnection();
        public void Save(BReserve obj)
        {
            con.Open();
            com = new SqlCommand("BReserveInsert", con);
            com.CommandType = CommandType.StoredProcedure;

            com.Parameters.AddWithValue("@BResID", obj.BResID);
            com.Parameters.AddWithValue("@ResName", obj.ResName);
            com.Parameters.AddWithValue("@ResTpNo", obj.ResTpNo);
            com.Parameters.AddWithValue("@ResDateTime", obj.ResDateTime);
            com.Parameters.AddWithValue("@ResEDateTime", obj.ResEDateTime);
            com.Parameters.AddWithValue("@NofBB", obj.NofBB);

            com.ExecuteNonQuery();
            con.Close();
        }

        public void Update(BReserve obj)
        {
            con.Open();
            com = new SqlCommand("BReserveUpdate", con);
            com.CommandType = CommandType.StoredProcedure;

            com.Parameters.AddWithValue("@BResID", obj.BResID);
            com.Parameters.AddWithValue("@ResDateTime", obj.ResDateTime);
            com.Parameters.AddWithValue("@ResEDateTime", obj.ResEDateTime);
            com.Parameters.AddWithValue("@NofBB", obj.NofBB);

            com.ExecuteNonQuery();
            con.Close();
        }

        public void Delete(BReserve obj)
        {
            con.Open();
            com = new SqlCommand("BReserveDelete", con);
            com.CommandType = CommandType.StoredProcedure;

            com.Parameters.AddWithValue("@BResID", obj.BResID);

            com.ExecuteNonQuery();
            con.Close();
        }

        public BReserve searchByID(BReserve obj)
        {
            con.Open();
            com = new SqlCommand("BReserveID", con);
            com.CommandType = CommandType.StoredProcedure;

            com.Parameters.AddWithValue("@BResID", obj.BResID);

            BReserve BRes = new BReserve();
            reader = com.ExecuteReader();

            while (reader.Read())
            {
                int.Parse(reader[0].ToString());
                int.Parse(reader[1].ToString());
                int.Parse(reader[2].ToString()); 
                DateTime.Parse(reader[3].ToString());
                DateTime.Parse(reader[4].ToString());
                int.Parse(reader[5].ToString());
            }

            reader.Dispose();
            return BRes;
        }

        public BReserve searchByID(string id)
        {
            con.Open();
            com = new SqlCommand("BReserveID", con);
            com.CommandType = CommandType.StoredProcedure;

            com.Parameters.AddWithValue("@BResID", id);

            BReserve BRes = new BReserve();
            reader = com.ExecuteReader();

            while (reader.Read())
            {
                BRes.BResID = int.Parse(reader[0].ToString());
                BRes.ResName = reader[1].ToString();
                BRes.ResTpNo = int.Parse(reader[2].ToString());
                BRes.ResDateTime = DateTime.Parse(reader[3].ToString());
                BRes.ResEDateTime = DateTime.Parse(reader[4].ToString());
                BRes.NofBB = int.Parse(reader[5].ToString());
            }

            reader.Dispose();
            return BRes;
        }

        public List<BReserve> DisplayAll()
        {
            con.Open();
            com = new SqlCommand("BResrveALL", con);
            com.CommandType = CommandType.StoredProcedure;
            List<BReserve> BRes = new List<BReserve>();
            reader = com.ExecuteReader();

            while (reader.Read())
            {
                BRes.Add(new BReserve(int.Parse(reader[0].ToString()), reader[1].ToString(), int.Parse(reader[2].ToString())
                    , DateTime.Parse(reader[3].ToString()), DateTime.Parse(reader[4].ToString()), int.Parse(reader[5].ToString())));
            }

            reader.Dispose();
            return BRes;
        }

        public string AutoNumber()
        {
            int i = 10;
            string result;
            com = new SqlCommand("SELECT COUNT(BResID) FROM BReserve", con);
            con.Open();
            com.ExecuteNonQuery();
            i = Convert.ToInt32(com.ExecuteScalar());
            i++;
            result = "BR/" + i.ToString();

            return result;
        }
    }
}
