using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data;

namespace ALLibrary
{
    /// <summary>
    /// Interaction logic for Search.xaml
    /// </summary>
    public partial class Search : Window
    {
        //List<string> SearchIDs = new List<string>();
        int SearchID;
        DataTable dt = new DataTable();
        DataTable dt1 = new DataTable();
        public Search()
        {
            InitializeComponent();

            if (SearchID == 100)
            {
                dt1.Rows.Clear();
                dt1.Columns.Clear();
                dt.Clear();
                dt.Columns.Add("Category");
                dt.Columns.Add("Book ID");
                dt.Columns.Add("Book Name");
                dt.Columns.Add("Language");
                dt.Columns.Add("Author");
                dt.Columns.Add("Publisher");
                
                List<BRegistration> obj = new BRegistration_DAO().DisplayAll();

                foreach (BRegistration val in obj)
                {
                    dt.Rows.Add(val.CategoryID, val.BNo, val.BName, val.Language, val.Author, val.PublisherName);
                }
                dgv_Search.ItemsSource = dt.DefaultView;
            }
            else if (SearchID == 200)
            {
                dt.Rows.Clear();
                dt.Columns.Clear();
                dt.Clear();
                dt1.Columns.Add("Member ID");
                dt1.Columns.Add("Member Name");
                dt1.Columns.Add("Gender");
                
                List<MRegistration> member = new MRegistration_DAO().DisplayAll();

                foreach (MRegistration mem in member)
                {
                    dt1.Rows.Add(mem.MNo, mem.MName, mem.Gender);
                }
                dgv_Search.ItemsSource = dt1.DefaultView;
            }
        }

        public int Show(int id)
        {
            this.ShowDialog();
            SearchID = id;
            return SearchID;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void StackPanel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {

        }

        //public List<string> Search(string search)
        //{
        //    SearchIDs = search.ToList();
        //    this.ShowDialog();
        //    return SearchIDs;
        //}

    }
}
