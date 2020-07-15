using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace ALLibrary.DAO
{
    class Authors
    {
        SqlDataReader reader = null;
        SqlCommand com = null;
        SqlConnection con = DB_Connection.getConnection();

        public int AutID { get; set; }
        public string Author { get; set; }

        public Authors()
        {

        }

        public Authors(int AutID)
        {
            this.AutID = AutID;
        }

        public Authors(int AutID, string Author)
        {
            this.AutID = AutID;
            this.Author = Author;
        }
        public List<Authors> AllAuthors()
        {
            con.Open();
            com = new SqlCommand("SELECT * FROM BAuthors", con);

            List<Authors> BB = new List<Authors>();
            reader = com.ExecuteReader();

            while (reader.Read())
            {
                BB.Add(new Authors(int.Parse(reader[0].ToString()), reader[1].ToString()));
            }

            reader.Dispose();
            return BB;
        }

        public Authors searchByAuthors(Authors obj)
        {
            con.Open();
            com = new SqlCommand("SELECT * FROM BAuthors WHERE CatNo='" + obj.AutID + "'", con);

            Authors BB = new Authors();
            reader = com.ExecuteReader();

            while (reader.Read())
            {
                BB.AutID = int.Parse(reader[0].ToString());
                BB.Author = reader[1].ToString();
            }

            reader.Dispose();
            return BB;
        }

    }
}
