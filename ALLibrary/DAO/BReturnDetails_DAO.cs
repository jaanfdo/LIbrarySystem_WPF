using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace ALLibrary.DAO
{
    class BReturnDetails_DAO
    {
        SqlDataReader reader = null;
        SqlCommand com = null;
        SqlConnection con = DB_Connection.getConnection();
        public void Save(BReturn obj)
        {

            con.Open();
            com = new SqlCommand("SPBReturnDetailsInsert", con);
            com.CommandType = CommandType.StoredProcedure;

            com.Parameters.AddWithValue("@BRID", obj.BRID);
            com.Parameters.AddWithValue("@BNo", obj.BNo);
            com.Parameters.AddWithValue("@NoRCopies", obj.NoRCopies);

            com.ExecuteNonQuery();
            con.Close();
        }

        public void Update(BReturn obj)
        {
            con.Open();
            com = new SqlCommand("SPBReturnDetailsUpdate", con);
            com.CommandType = CommandType.StoredProcedure;

            com.Parameters.AddWithValue("@BRID", obj.BRID);
            com.Parameters.AddWithValue("@BNo", obj.BNo);
            com.Parameters.AddWithValue("@NoRCopies", obj.NoRCopies);

            com.ExecuteNonQuery();
            con.Close();
        }

        public void Delete(BReturn obj)
        {
            //con.Open();
            //com = new SqlCommand("CustomerDSP", con);
            //com.CommandType = CommandType.StoredProcedure;

            //com.ExecuteNonQuery();
            //con.Close();
        }

        public BReturn searchByID(BReturn obj)
        {
            con.Open();
            com = new SqlCommand("BReturnID", con);
            com.CommandType = CommandType.StoredProcedure;

            com.Parameters.AddWithValue("@BRID", obj.BRID);

            BReturn BR = new BReturn();
            reader = com.ExecuteReader();

            while (reader.Read())
            {
                BR.BRID = int.Parse(reader[0].ToString());
                BR.BNo = int.Parse(reader[1].ToString());
                BR.NoRCopies = int.Parse(reader[2].ToString());
                BR.IssueDate = DateTime.Parse(reader[3].ToString());
                BR.DueDate = DateTime.Parse(reader[4].ToString());
                BR.LateEarly = reader[5].ToString();
                BR.Dates =  int.Parse(reader[6].ToString());
                BR.TotalFines = decimal.Parse(reader[7].ToString());
            }

            reader.Dispose();
            return BR;
        }

        public List<BReturn> DisplayAll()
        {
            con.Open();
            com = new SqlCommand("BRDetailsAll", con);
            com.CommandType = CommandType.StoredProcedure;
            List<BReturn> BB = new List<BReturn>();
            SqlDataReader reader = com.ExecuteReader();

            while (reader.Read())
            {
                BB.Add(new BReturn(int.Parse(reader[0].ToString()), int.Parse(reader[1].ToString()), int.Parse(reader[2].ToString()), DateTime.Parse(reader[3].ToString()), DateTime.Parse(reader[4].ToString()), reader[5].ToString(), int.Parse(reader[6].ToString()), decimal.Parse(reader[7].ToString())));
            }

            reader.Dispose();
            return BB;
        }
    }
}
