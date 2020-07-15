using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace ALLibrary
{
    class Function_DAO
    {
        SqlDataReader reader = null;
        SqlCommand com = null;
        SqlConnection con = DB_Connection.getConnection();

        public List<Functions> DisplayFunction()
        {
            con.Open();
            com = new SqlCommand("select FunctionID, FunctionName from Functions", con);
            List<Functions> fun = new List<Functions>();
            SqlDataReader reader = com.ExecuteReader();

            while (reader.Read())
            {
                fun.Add(new Functions(int.Parse(reader[0].ToString()), reader[1].ToString()));
            }

            reader.Dispose();
            return fun;
        }
    }
}
