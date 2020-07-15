using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace ALLibrary
{
    class BRegistration_DAO
    {
        SqlDataReader reader = null;
        SqlCommand com = null;
        SqlConnection con = DB_Connection.getConnection();
        public void Save(BRegistration obj)
        {
            con.Open();
            com = new SqlCommand("SPBRegistrationInsert", con);
            com.CommandType = CommandType.StoredProcedure;

            com.Parameters.AddWithValue("@CategoryID", obj.CategoryID);
            com.Parameters.AddWithValue("@BNo", obj.BNo);
            com.Parameters.AddWithValue("@BName", obj.BName);
            com.Parameters.AddWithValue("@Language", obj.Language);
            com.Parameters.AddWithValue("@ISBN", obj.ISBN);
            com.Parameters.AddWithValue("@Author", obj.Author);
            com.Parameters.AddWithValue("@PublisherName", obj.PublisherName);
            com.Parameters.AddWithValue("@PublicationDate", obj.PublicationDate);
            com.Parameters.AddWithValue("@Edition", obj.Edition);
            com.Parameters.AddWithValue("@NoCopies", obj.NoCopies);
            com.Parameters.AddWithValue("@BPurchasingDate", obj.BPurchasingDate);
            com.Parameters.AddWithValue("@BillNo", obj.BillNo);
            com.Parameters.AddWithValue("@Price", obj.Price);
            com.Parameters.AddWithValue("@Status", obj.Status);


            com.ExecuteNonQuery();
            con.Close();
        }

        public void Update(BRegistration obj)
        {
            con.Open();
            com = new SqlCommand("SPBRegistrationUpdate", con);
            com.CommandType = CommandType.StoredProcedure;

            com.Parameters.AddWithValue("@CategoryID", obj.CategoryID);
            com.Parameters.AddWithValue("@BNo", obj.BNo);
            com.Parameters.AddWithValue("@BName", obj.BName);
            com.Parameters.AddWithValue("@Language", obj.Language);
            com.Parameters.AddWithValue("@ISBN", obj.ISBN);
            com.Parameters.AddWithValue("@Author", obj.Author);
            com.Parameters.AddWithValue("@PublisherName", obj.PublisherName);
            com.Parameters.AddWithValue("@PublicationDate", obj.PublicationDate);
            com.Parameters.AddWithValue("@Edition", obj.Edition);
            com.Parameters.AddWithValue("@NoCopies", obj.NoCopies);
            com.Parameters.AddWithValue("@BPurchasingDate", obj.BPurchasingDate);
            com.Parameters.AddWithValue("@BillNo", obj.BillNo);
            com.Parameters.AddWithValue("@Price", obj.Price);
            com.Parameters.AddWithValue("@Status", obj.Status);

            com.ExecuteNonQuery();
            con.Close();
        }

        public void Delete(BRegistration obj)
        {
            con.Open();
            com = new SqlCommand("SPBRegistrationDelete", con);
            com.CommandType = CommandType.StoredProcedure;

            com.Parameters.AddWithValue("@BNo", obj.BNo);

            com.ExecuteNonQuery();
            con.Close();
        }

        public BRegistration searchByID(BRegistration obj)
        {
            con.Open();
            com = new SqlCommand("BRegistrationID", con);
            com.CommandType = CommandType.StoredProcedure;

            com.Parameters.AddWithValue("@BNo", obj.BNo);

            BRegistration BR = new BRegistration();
            reader = com.ExecuteReader();

            while (reader.Read())
            {
                BR.CategoryID = int.Parse(reader[0].ToString());
                BR.BNo = int.Parse(reader[1].ToString());
                BR.BName = reader[2].ToString();
                BR.Language = int.Parse(reader[3].ToString());
                BR.ISBN = int.Parse(reader[4].ToString());
                BR.Author = int.Parse(reader[5].ToString());
                BR.PublisherName = int.Parse(reader[6].ToString());
                BR.PublicationDate = DateTime.Parse(reader[7].ToString());
                BR.Edition = int.Parse(reader[8].ToString());
                BR.NoCopies = int.Parse(reader[9].ToString());
                BR.BPurchasingDate = DateTime.Parse(reader[10].ToString());
                BR.BillNo = int.Parse(reader[11].ToString());
                BR.Price = decimal.Parse(reader[12].ToString());
                BR.Status = bool.Parse(reader[13].ToString());
            }

            reader.Dispose();
            return BR;
        }

        public BRegistration searchByID(string searchid)
        {
            con.Open();
            com = new SqlCommand("BRegistrationID", con);
            com.CommandType = CommandType.StoredProcedure;

            com.Parameters.AddWithValue("@BNo", searchid);

            BRegistration BR = new BRegistration();
            reader = com.ExecuteReader();

            while (reader.Read())
            {
                BR.CategoryID = int.Parse(reader[0].ToString());
                BR.BNo = int.Parse(reader[1].ToString());
                BR.BName = reader[2].ToString();
                BR.Language = int.Parse(reader[3].ToString());
                BR.ISBN = int.Parse(reader[4].ToString());
                BR.Author = int.Parse(reader[5].ToString());
                BR.PublisherName = int.Parse(reader[6].ToString());
                BR.PublicationDate = DateTime.Parse(reader[7].ToString());
                BR.Edition = int.Parse(reader[8].ToString());
                BR.NoCopies = int.Parse(reader[9].ToString());
                BR.BPurchasingDate = DateTime.Parse(reader[10].ToString());
                BR.BillNo = int.Parse(reader[11].ToString());
                BR.Price = decimal.Parse(reader[12].ToString());
                BR.Status = bool.Parse(reader[13].ToString());
            }

            reader.Dispose();
            return BR;
        }

        public List<BRegistration> DisplayAll()
        {
            con.Open();
            com = new SqlCommand("BRegistrationALL", con);
            com.CommandType = CommandType.StoredProcedure;
            List<BRegistration> BR = new List<BRegistration>();
            SqlDataReader reader = com.ExecuteReader();

            while (reader.Read())
            {
                BR.Add(new BRegistration(int.Parse(reader[0].ToString()), int.Parse(reader[1].ToString()), reader[2].ToString(),
                    int.Parse(reader[3].ToString()), int.Parse(reader[4].ToString()),int.Parse(reader[5].ToString()), int.Parse(reader[6].ToString()), 
                    DateTime.Parse(reader[7].ToString()),  int.Parse(reader[8].ToString()), int.Parse(reader[9].ToString()), 
                    DateTime.Parse(reader[10].ToString()), int.Parse(reader[11].ToString()), 
                    decimal.Parse(reader[12].ToString()), bool.Parse(reader[13].ToString())));
            }

            reader.Dispose();
            return BR;
        }

        public List<BRegistration> SearchAll(string search, string filter)
        {
            con.Open();
            com = new SqlCommand("SELECT * FROM BRegistration WHERE " + filter+ "Like %" +search+ "%", con);
            List<BRegistration> BR = new List<BRegistration>();
            SqlDataReader reader = com.ExecuteReader();

            while (reader.Read())
            {
                BR.Add(new BRegistration(int.Parse(reader[0].ToString()), int.Parse(reader[1].ToString()), reader[2].ToString(),
                    int.Parse(reader[3].ToString()), int.Parse(reader[4].ToString()), int.Parse(reader[5].ToString()), int.Parse(reader[6].ToString()),
                    DateTime.Parse(reader[7].ToString()), int.Parse(reader[8].ToString()), int.Parse(reader[9].ToString()),
                    DateTime.Parse(reader[10].ToString()), int.Parse(reader[11].ToString()),
                    decimal.Parse(reader[12].ToString()), bool.Parse(reader[13].ToString())));
            }

            reader.Dispose();
            return BR;
        }

        public string AutoNumber()
        {
            int i = 10;
            string result;
            com = new SqlCommand("SELECT COUNT(BNo) FROM BRegistration", con);
            con.Open();
            com.ExecuteNonQuery();
            i = Convert.ToInt32(com.ExecuteScalar());
            i++;
            result = "B/" + i.ToString();

            return result;
        }
    }
}
