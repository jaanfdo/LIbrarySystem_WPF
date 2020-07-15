using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace ALLibrary.GetterSetter
{
    class Publisher
    {
        SqlDataReader reader = null;
        SqlCommand com = null;
        SqlConnection con = DB_Connection.getConnection();       
        
        public int PubID { get; set; }
        public string Publishers { get; set; }

        public Publisher()
        {

        }

        public Publisher(int PubID)
        {
            this.PubID = PubID;
        }

        public Publisher(int PubID, string Publisher)
        {
            this.PubID = PubID;
            this.Publishers = Publisher;
        }
        public List<Publisher> AllPublisher()
        {
            con.Open();
            com = new SqlCommand("SELECT * FROM BPublisher", con);

            List<Publisher> BB = new List<Publisher>();
            reader = com.ExecuteReader();

            while (reader.Read())
            {
                BB.Add(new Publisher(int.Parse(reader[0].ToString()), reader[1].ToString()));
            }

            reader.Dispose();
            return BB;
        }

        public Publisher searchByPublisher(Publisher obj)
        {
            con.Open();
            com = new SqlCommand("SELECT * FROM BPublisher WHERE CatNo='" + obj.PubID + "'", con);

            Publisher BB = new Publisher();
            reader = com.ExecuteReader();

            while (reader.Read())
            {
                BB.PubID = int.Parse(reader[0].ToString());
                BB.Publishers = reader[1].ToString();
            }

            reader.Dispose();
            return BB;
        }

        

        

    }
}
