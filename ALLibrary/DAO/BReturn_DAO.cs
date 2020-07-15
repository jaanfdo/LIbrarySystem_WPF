using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace ALLibrary
{
    class BReturn_DAO
    {
        SqlDataReader reader = null;
        SqlCommand com = null;
        SqlConnection con = DB_Connection.getConnection();
        public void Save(BReturn obj)
        {
            con.Open();
            com = new SqlCommand("SPBReturnInsert", con);
            com.CommandType = CommandType.StoredProcedure;

            com.Parameters.AddWithValue("@BRID", obj.BRID);
            com.Parameters.AddWithValue("@MNo", obj.MNo);
            com.Parameters.AddWithValue("@NofBB", obj.NofRB);
            com.Parameters.AddWithValue("@IssueDate", obj.IssueDate);
            com.Parameters.AddWithValue("@DueDate", obj.DueDate);
            com.Parameters.AddWithValue("@ReturnDate", obj.ReturnDate);
            com.Parameters.AddWithValue("@LateEarly", obj.LateEarly);
            com.Parameters.AddWithValue("@Dates", obj.Dates);
            com.Parameters.AddWithValue("@Fines", obj.Fines);

            com.ExecuteNonQuery();
            con.Close();
        }

        public void Update(BReturn obj)
        {  
            con.Open();
            com = new SqlCommand("SPBReturnUpdate", con);
            com.CommandType = CommandType.StoredProcedure;

            com.Parameters.AddWithValue("@BRID", obj.BRID);
            com.Parameters.AddWithValue("@NofBB", obj.NofRB);
            com.Parameters.AddWithValue("@ReturnDate", obj.ReturnDate);
            com.Parameters.AddWithValue("@LateEarly", obj.LateEarly);
            com.Parameters.AddWithValue("@Dates", obj.Dates);
            com.Parameters.AddWithValue("@Fines", obj.Fines);

            com.ExecuteNonQuery();
            con.Close();
        }

        public void Delete(BReturn obj)
        {
            con.Open();
            com = new SqlCommand("SPBReturnDelete", con);
            com.CommandType = CommandType.StoredProcedure;

            com.Parameters.AddWithValue("@BRID", obj.BRID);

            com.ExecuteNonQuery();
            con.Close();
        }

        public BReturn searchByID(BReturn obj)
        {
            con.Open();
            com = new SqlCommand("BReturnID", con);
            com.CommandType = CommandType.StoredProcedure;

            com.Parameters.AddWithValue("@BRID", obj.BRID);

            BReturn BR = new BReturn();
            reader = com.ExecuteReader();

            if (reader.Read())
            {
                BR.BRID = int.Parse(reader[0].ToString());
                BR.MNo = int.Parse(reader[1].ToString());
                BR.NofRB = int.Parse(reader[2].ToString());
                BR.ReturnDate = DateTime.Parse(reader[5].ToString());
                BR.TotalFines = decimal.Parse(reader[8].ToString());
            }

            reader.Dispose();
            return BR;
        }

        public BReturn searchByID(string id)
        {
            con.Open();
            com = new SqlCommand("BReturnID", con);
            com.CommandType = CommandType.StoredProcedure;

            com.Parameters.AddWithValue("@BRID", id);

            BReturn BR = new BReturn();
            reader = com.ExecuteReader();

            if (reader.Read())
            {
                BR.BRID = int.Parse(reader[0].ToString());
                BR.MNo = int.Parse(reader[1].ToString());
                BR.NofRB = int.Parse(reader[2].ToString());
                BR.ReturnDate = DateTime.Parse(reader[3].ToString());
                BR.TotalFines = decimal.Parse(reader[4].ToString());
            }

            reader.Dispose();
            return BR;
        }

        public List<BReturn> DisplayAll()
        {
            con.Open();
            com = new SqlCommand("BReturnAll", con);
            com.CommandType = CommandType.StoredProcedure;
            List<BReturn> cus = new List<BReturn>();
            SqlDataReader reader = com.ExecuteReader();

            while (reader.Read())
            {
                cus.Add(new BReturn(int.Parse(reader[0].ToString()), int.Parse(reader[1].ToString()), int.Parse(reader[2].ToString()),  
                    DateTime.Parse(reader[3].ToString()),decimal.Parse(reader[4].ToString())));
            }

            reader.Dispose();
            return cus;
        }

        public string AutoNumber()
        {
            int i = 10;
            string result;
            com = new SqlCommand("SELECT COUNT(BRID) FROM BReturn", con);
            con.Open();
            com.ExecuteNonQuery();
            i = Convert.ToInt32(com.ExecuteScalar());
            i++;
            result = "RB/" + i.ToString();

            return result;
        }
    }
}
