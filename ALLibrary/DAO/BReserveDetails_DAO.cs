using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace ALLibrary.DAO
{
    class BReserveDetails_DAO
    {
        SqlDataReader reader = null;
        SqlCommand com = null;
        SqlConnection con = DB_Connection.getConnection();
        public void Save(BReserve obj)
        {
            con.Open();
            com = new SqlCommand("BReserveDetailsInsert", con);
            com.CommandType = CommandType.StoredProcedure;

            com.Parameters.AddWithValue("@BBID", obj.BResID);
            com.Parameters.AddWithValue("@BNo", obj.BNo);
            com.Parameters.AddWithValue("@NoCopies", obj.NoCopies);

            com.ExecuteNonQuery();
            con.Close();
        }

        public void Update(BReserve obj)
        {
            con.Open();
            com = new SqlCommand("BReserveDetailsUpdate", con);
            com.CommandType = CommandType.StoredProcedure;

            com.Parameters.AddWithValue("@BBID", obj.BResID);
            com.Parameters.AddWithValue("@BNo", obj.BNo);
            com.Parameters.AddWithValue("@NoCopies", obj.NoCopies);

            com.ExecuteNonQuery();
            con.Close();
        }

        public void Delete(BReserve obj)
        {
            //con.Open();
            //com = new SqlCommand("CustomerDSP", con);
            //com.CommandType = CommandType.StoredProcedure;

            //com.ExecuteNonQuery();
            //con.Close();
        }

        public BReserve searchByID(BReserve obj)
        {
            con.Open();
            com = new SqlCommand("BResDetailsID", con);
            com.CommandType = CommandType.StoredProcedure;

            com.Parameters.AddWithValue("@BResID", obj.BResID);

            BReserve BRes = new BReserve();
            reader = com.ExecuteReader();

            while (reader.Read())
            {
                BRes.BResID = int.Parse(reader[0].ToString());
                BRes.BNo = int.Parse(reader[1].ToString());
                BRes.NoCopies = int.Parse(reader[2].ToString());
            }

            reader.Dispose();
            return BRes;
        }

        public List<BReserve> DisplayAll()
        {
            con.Open();
            com = new SqlCommand("BResDetailsALL", con);
            com.CommandType = CommandType.StoredProcedure;
            List<BReserve> BRes = new List<BReserve>();
            SqlDataReader reader = com.ExecuteReader();

            while (reader.Read())
            {
                BRes.Add(new BReserve(int.Parse(reader[0].ToString()), int.Parse(reader[1].ToString()), int.Parse(reader[2].ToString())));
            }

            reader.Dispose();
            return BRes;
        }
    }
}
