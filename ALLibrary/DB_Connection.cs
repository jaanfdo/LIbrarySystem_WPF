using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace ALLibrary
{
    class DB_Connection
    {
        public static SqlConnection getConnection()
        {
            string conString = @"Data Source=JANITH\JANITH;Initial Catalog=ALLibrary;Integrated Security=True";
            SqlConnection con = new SqlConnection(conString);
            return con;
        }
    }
}
