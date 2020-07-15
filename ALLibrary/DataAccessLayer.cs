using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ALLibrary
{
    class DataAccessLayer
    {
        private SqlConnection con;
        public SqlCommand com;

        public static string getConnection()
        {
            string con = @"Data Source=JANITH\JANITH;Initial Catalog=ALLibrary;Integrated Security=True";
            return con;
        }

        public Boolean executeNonQuery(string query)
        {

            try
            {
                if (con == null)
                {
                    con = new SqlConnection(getConnection());
                }

                con.Open();

                if (com == null)
                {
                    com = new SqlCommand(query, con);
                }
                com.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                com.Dispose();
                con.Close();
            }
        }

        public SqlDataReader executeQuery(string query)
        {
            try
            {
                if (con == null)
                {
                    con = new SqlConnection(getConnection());
                }

                con.Open();

                if (com == null)
                {
                    com = new SqlCommand(query, con);
                }

                SqlDataReader dr = com.ExecuteReader();
                return dr;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                com.Dispose();
                con.Close();
            }
        }
    }
}
