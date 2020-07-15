using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace ALLibrary
{
    class MRegistration_DAO
    {
        SqlDataReader reader = null;
        SqlCommand com = null;
        SqlConnection con = DB_Connection.getConnection();
        public void Save(MRegistration obj)
        {
            con.Open();
            com = new SqlCommand("SPMRegistration", con);
            com.CommandType = CommandType.StoredProcedure;

            com.Parameters.AddWithValue("@MNo", obj.MNo);
            com.Parameters.AddWithValue("@MName", obj.MName);
            com.Parameters.AddWithValue("@Address", obj.Address);
            com.Parameters.AddWithValue("@Gender", obj.Gender);
            com.Parameters.AddWithValue("@NIC", obj.NIC);
            com.Parameters.AddWithValue("@TpNo", obj.TpNo);
            com.ExecuteNonQuery();
            con.Close();
        }

        public void Update(MRegistration obj)
        {
            con.Open();
            com = new SqlCommand("SPMRegistrationUpdate", con);
            com.CommandType = CommandType.StoredProcedure;

            com.Parameters.AddWithValue("@MNo", obj.MNo);
            com.Parameters.AddWithValue("@MName", obj.MName);
            com.Parameters.AddWithValue("@Address", obj.Address);
            com.Parameters.AddWithValue("@Gender", obj.Gender);
            com.Parameters.AddWithValue("@NIC", obj.NIC);
            com.Parameters.AddWithValue("@TpNo", obj.TpNo);

            com.ExecuteNonQuery();
            con.Close();
        }

        public void Delete(MRegistration obj)
        {
            con.Open();
            com = new SqlCommand("MRegistrationDelete", con);
            com.CommandType = CommandType.StoredProcedure;

            com.Parameters.AddWithValue("@cname", obj.MNo);
            com.ExecuteNonQuery();
            con.Close();
        }

        public MRegistration searchByID(int obj)
        {
            con.Open();
            com = new SqlCommand("MRegistrationID", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@MNo", obj);

            MRegistration MR = new MRegistration();
            reader = com.ExecuteReader();

            while (reader.Read())
            {
                MR.MNo = int.Parse(reader[0].ToString());
                MR.MName = reader[1].ToString();
                MR.Gender = reader[2].ToString();
                MR.NIC = reader[3].ToString();
                MR.Address = reader[4].ToString();
                MR.TpNo = int.Parse(reader[5].ToString());
            }

            reader.Dispose();
            return MR;
        }

        public MRegistration searchByID(string obj)
        {
            con.Open();
            com = new SqlCommand("MRegistrationID", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@MNo", obj);

            MRegistration MR = new MRegistration();
            reader = com.ExecuteReader();

            while (reader.Read())
            {
                MR.MNo = int.Parse(reader[0].ToString());
                MR.MName = reader[1].ToString();
                MR.Gender = reader[2].ToString();
                MR.NIC = reader[3].ToString();
                MR.Address = reader[4].ToString();
                MR.TpNo = int.Parse(reader[5].ToString());
            }

            reader.Dispose();
            return MR;
        }

        public List<MRegistration> DisplayAll()
        {
            con.Open();
            com = new SqlCommand("MRegistrationAll", con);
            com.CommandType = CommandType.StoredProcedure;
            List<MRegistration> MR = new List<MRegistration>();
            reader = com.ExecuteReader();

            while (reader.Read())
            {
                MR.Add(new MRegistration(int.Parse(reader[0].ToString()), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), reader[4].ToString(), int.Parse(reader[5].ToString())));
            }

            reader.Dispose();
            return MR;
        }

        public string AutoNumber()
        {
            int i = 10;
            string result;
            com = new SqlCommand("SELECT COUNT(MNo) FROM MRegistration", con);
            con.Open();
            com.ExecuteNonQuery();
            i = Convert.ToInt32(com.ExecuteScalar());
            i++;
            result = "M/" + i.ToString();

            return result;
        }

    }
}
