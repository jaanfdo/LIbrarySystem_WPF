using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace ALLibrary.DAO
{
    class Language
    {
        SqlDataReader reader = null;
        SqlCommand com = null;
        SqlConnection con = DB_Connection.getConnection();

        public int LanID { get; set; }
        public string Languages { get; set; }

        public Language()
        {

        }

        public Language(int LanID)
        {
            this.LanID = LanID;
        }

        public Language(int LanID, string Language)
        {
            this.LanID = LanID;
            this.Languages = Language;
        }


        public List<Language> AllLanguage()
        {
            con.Open();
            com = new SqlCommand("SELECT * FROM BLanguage", con);

            List<Language> BB = new List<Language>();
            reader = com.ExecuteReader();

            while (reader.Read())
            {
                BB.Add(new Language(int.Parse(reader[0].ToString()), reader[1].ToString()));
            }

            reader.Dispose();
            return BB;
        }

        public Language searchByLanguage(Language obj)
        {
            con.Open();
            com = new SqlCommand("SELECT * FROM BLanguage WHERE CatNo='" + obj.LanID + "'", con);

            Language BB = new Language();
            reader = com.ExecuteReader();

            while (reader.Read())
            {
                BB.LanID = int.Parse(reader[0].ToString());
                BB.Languages = reader[1].ToString();
            }

            reader.Dispose();
            return BB;
        }
    }
}
