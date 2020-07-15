using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace ALLibrary.DAO
{
    class BBooksDetails_DAO
    {
        SqlDataReader reader = null;
        SqlCommand com = null;
        SqlConnection con = DB_Connection.getConnection();
        public void Save(BBooks obj)
        {

            con.Open();
            com = new SqlCommand("SPBBookDetailsInsert", con);
            com.CommandType = CommandType.StoredProcedure;

            com.Parameters.AddWithValue("@BBID", obj.BBID);
            com.Parameters.AddWithValue("@BNo", obj.BNo);
            com.Parameters.AddWithValue("@NoCopies", obj.NoCopies);

            com.ExecuteNonQuery();
            con.Close();
        }

        public void Update(BBooks obj)
        {
            con.Open();
            com = new SqlCommand("SPBBookDetailsUpdate", con);
            com.CommandType = CommandType.StoredProcedure;

            com.Parameters.AddWithValue("@BBID", obj.BBID);
            com.Parameters.AddWithValue("@BNo", obj.BNo);
            com.Parameters.AddWithValue("@NoCopies", obj.NoCopies);

            com.ExecuteNonQuery();
            con.Close();
        }

        public void Delete(BBooks obj)
        {
            //con.Open();
            //com = new SqlCommand("CustomerDSP", con);
            //com.CommandType = CommandType.StoredProcedure;

            //com.ExecuteNonQuery();
            //con.Close();
        }

        public List<BBooks> DisplayAll()
        {
            con.Open();
            com = new SqlCommand("BBDetailsAll", con);
            com.CommandType = CommandType.StoredProcedure;
            List<BBooks> BB = new List<BBooks>();
            SqlDataReader reader = com.ExecuteReader();

            while (reader.Read())
            {
                BB.Add(new BBooks(int.Parse(reader[0].ToString()), int.Parse(reader[1].ToString()), int.Parse(reader[2].ToString())));
            }

            reader.Dispose();
            return BB;
        }
    }
}
