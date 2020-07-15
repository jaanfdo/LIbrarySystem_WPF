using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace ALLibrary.DAO
{
    class Category
    {
        SqlDataReader reader = null;
        SqlCommand com = null;
        SqlConnection con = DB_Connection.getConnection();

        public int CatNo { get; set; }
        public string Categorys { get; set; }

        public Category()
        {

        }

        public Category(int CatNo)
        {
            this.CatNo = CatNo;
        }

        public Category(int CatNo, string Category)
        {
            this.CatNo = CatNo;
            this.Categorys = Category;
        }
        public List<Category> AllCategory()
        {
            con.Open();
            com = new SqlCommand("SELECT * FROM BCategory", con);

            List<Category> BB = new List<Category>();
            reader = com.ExecuteReader();

            while (reader.Read())
            {
                BB.Add(new Category(int.Parse(reader[0].ToString()), reader[1].ToString()));
            }

            reader.Dispose();
            return BB;
        }

        public Category searchByCategory(Category obj)
        {
            con.Open();
            com = new SqlCommand("SELECT * FROM BCategory WHERE CatNo='"+obj.CatNo+"'", con);

            Category BB = new Category();
            reader = com.ExecuteReader();

            while (reader.Read())
            {
                BB.CatNo = int.Parse(reader[0].ToString());
                BB.Categorys = reader[1].ToString();
            }

            reader.Dispose();
            return BB;
        }
    }
}
