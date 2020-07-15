using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace ALLibrary
{
    class BBooks_DAO
    {
        SqlDataReader reader = null;
        SqlCommand com = null;
        SqlConnection con = DB_Connection.getConnection();
        public void Save(BBooks obj)
        {

            con.Open();
            com = new SqlCommand("SPBBookInsert", con);
            com.CommandType = CommandType.StoredProcedure;

            com.Parameters.AddWithValue("@BBID", obj.BBID);
            com.Parameters.AddWithValue("@MNo", obj.MNo);
            com.Parameters.AddWithValue("@NofBB", obj.NofBB);
            com.Parameters.AddWithValue("@IssueDate", obj.IssueDate);
            com.Parameters.AddWithValue("@DueDate", obj.DueDate);

            com.ExecuteNonQuery();
            con.Close();
        }

        public void Update(BBooks obj)
        {
            con.Open();
            com = new SqlCommand("SPBBookUpdate", con);
            com.CommandType = CommandType.StoredProcedure;

            com.Parameters.AddWithValue("@BBID", obj.BBID);
            com.Parameters.AddWithValue("@NofBB", obj.NofBB);
            com.Parameters.AddWithValue("@DueDate", obj.DueDate);

            com.ExecuteNonQuery();
            con.Close();
        }

        public void Delete(BBooks obj)
        {
            con.Open();
            com = new SqlCommand("SPBBookDelete", con);
            com.CommandType = CommandType.StoredProcedure;

            com.Parameters.AddWithValue("@BBID", obj.BBID);

            com.ExecuteNonQuery();
            con.Close();
        }

        public BBooks searchByID(BBooks obj)
        {
            con.Open();
            com = new SqlCommand("BBorrowID", con);
            com.CommandType = CommandType.StoredProcedure;

            com.Parameters.AddWithValue("@BBID", obj.BBID);

            BBooks BB = new BBooks();
            reader = com.ExecuteReader();

            while (reader.Read())
            {
                BB.BBID = int.Parse(reader[0].ToString());
                BB.MNo =  int.Parse(reader[1].ToString());
                BB.NofBB = int.Parse(reader[2].ToString());
                BB.IssueDate = DateTime.Parse(reader[3].ToString());
                BB.DueDate = DateTime.Parse(reader[4].ToString());
            }

            reader.Dispose();
            return BB;
        }

        public BBooks searchByID(string id)
        {
            con.Open();
            com = new SqlCommand("BBorrowID", con);
            com.CommandType = CommandType.StoredProcedure;

            com.Parameters.AddWithValue("@BBID", id);

            BBooks BB = new BBooks();
            reader = com.ExecuteReader();

            while (reader.Read())
            {
                BB.BBID = int.Parse(reader[0].ToString());
                BB.MNo = int.Parse(reader[1].ToString());
                BB.NofBB = int.Parse(reader[2].ToString());
                BB.IssueDate = DateTime.Parse(reader[3].ToString());
                BB.DueDate = DateTime.Parse(reader[4].ToString());
            }

            reader.Dispose();
            return BB;
        }

        public List<BBooks> DisplayAll()
        {
            con.Open();
            com = new SqlCommand("BBorrowAll", con);
            com.CommandType = CommandType.StoredProcedure;
            List<BBooks> BB = new List<BBooks>();
            SqlDataReader reader = com.ExecuteReader();

            while (reader.Read())
            {
                BB.Add(new BBooks(int.Parse(reader[0].ToString()), int.Parse(reader[1].ToString()), int.Parse(reader[2].ToString())
                    , DateTime.Parse(reader[3].ToString()), DateTime.Parse(reader[4].ToString())));
            }

            reader.Dispose();
            return BB;
        }

        public string AutoNumber()
        {
            int i = 10;
            string result;
            com = new SqlCommand("SELECT COUNT(BBID) FROM BBooks", con);
            con.Open();
            com.ExecuteNonQuery();
            i = Convert.ToInt32(com.ExecuteScalar());
            i++;
            result = "BB/" + i.ToString();

            return result;
        }
    }
}
