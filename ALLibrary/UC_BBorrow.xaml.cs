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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using ALLibrary.DAO;

namespace ALLibrary
{
    /// <summary>
    /// Interaction logic for UC_BBorrow.xaml
    /// </summary>
    public partial class UC_BBorrow : UserControl
    {
        DataTable dt = new DataTable();
        DataTable dtAdd = new DataTable();
        public UC_BBorrow()
        {
            InitializeComponent();

            dt.Columns.Add("Borrow Book ID", typeof(string));
            dt.Columns.Add("Member No", typeof(string));
            dt.Columns.Add("No of Borrow Books", typeof(string));
            dt.Columns.Add("Issue Date", typeof(string));
            dt.Columns.Add("Due Date", typeof(string));

            dtAdd.Columns.Add("BNo", typeof(int));
            dtAdd.Columns.Add("BName", typeof(string));
            dtAdd.Columns.Add("NoCopies", typeof(int));

            DisplayAll();

            string val = new BBooks_DAO().AutoNumber();
            txtBBID.Text = val;
            txtBBID.Tag = val;
        }

        private void DisplayAll()
        {
            dt.Clear();
            List<BBooks> obj = new BBooks_DAO().DisplayAll();

            foreach (BBooks val in obj)
            {
                string mname = "";
                foreach (MRegistration item in new MRegistration_DAO().DisplayAll().Where(o => o.MNo == val.MNo))
                {
                    mname += item.MName;
                }
                dt.Rows.Add(val.BBID, mname, val.NofBB, val.IssueDate, val.DueDate);
            }
            dgvMain.ItemsSource = dt.DefaultView;
        }

        private void AddBook()
        {
            dtAdd.Clear();
            int searchEnum = 100;
            Search RowDataSearch = new Search();
            int lstResult = RowDataSearch.Show(searchEnum);
            if (RowDataSearch.DialogResult == true)
            {
                List<BRegistration> obj = new BRegistration_DAO().DisplayAll();

                foreach (BRegistration val in obj)
                {
                    dtAdd.Rows.Add(val.CategoryID, val.BNo, val.BName, val.Language, val.Author, "");
                }
                dgv_Books.ItemsSource = dtAdd.DefaultView;
            }
        }

        private void Search()
        {
            dt.Clear();
            foreach (BBooks val in new BBooks_DAO().DisplayAll().Where(p => p.BBID == int.Parse(txtSearch.Text)))
            {
                string mname = "";
                foreach (MRegistration item in new MRegistration_DAO().DisplayAll().Where(o => o.MNo == val.MNo))
                {
                    mname += item.MName;
                }
                dt.Rows.Add(val.BBID, mname, val.NofBB, val.IssueDate, val.DueDate);
            }
            dgvMain.ItemsSource = dt.DefaultView;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            BBooks oBB = new BBooks(int.Parse(txtBBID.Tag.ToString()), int.Parse(txtMNo.Tag.ToString()), int.Parse(txtNofBB.Text), DateTime.Parse(dtpIssueDate.Text).Date, DateTime.Parse(dtpDueDate.Text).Date);
            BBooks_DAO BBDAO = new BBooks_DAO();
            BBDAO.Save(oBB);

            foreach (DataRow row in dt.Rows)
            {
                int bno = int.Parse(row["BNo"].ToString());
                int nocopies = int.Parse(row["NoCopies"].ToString());

                BBooks oBBDetails = new BBooks(int.Parse(txtBBID.Tag.ToString()), bno, nocopies,true);
                BBooksDetails_DAO BBDDAO = new BBooksDetails_DAO();
                BBDDAO.Save(oBBDetails);
            }

            MessageBox.Show("AL Library", "Record Added");
            DisplayAll();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            BBooks oBB = new BBooks(int.Parse(txtBBID.Tag.ToString()), int.Parse(txtNofBB.Text), DateTime.Parse(dtpDueDate.Text).Date);
            BBooks_DAO BBDAO = new BBooks_DAO();
            BBDAO.Update(oBB);

            foreach (DataRow row in dt.Rows)
            {
                int bno = int.Parse(row["BNo"].ToString());
                int nocopies = int.Parse(row["NoCopies"].ToString());

                BBooks oBBDetails = new BBooks(int.Parse(txtBBID.Tag.ToString()), bno, nocopies,true);
                BBooksDetails_DAO BBDDAO = new BBooksDetails_DAO();
                BBDDAO.Update(oBBDetails);
            }

            MessageBox.Show("AL Library", "Record Updated");
            DisplayAll();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            BBooks oBB = new BBooks(int.Parse(txtBBID.Tag.ToString()));
            BBooks_DAO BBDAO = new BBooks_DAO();
            BBDAO.Delete(oBB);

            MessageBox.Show("AL Library", "Record Deleted");
            DisplayAll();
        }

        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            txtBBID.Text = "";
            txtMNo.Text = "";
            txtNofBB.Text = "";
            dtpDueDate.Text = "";
            dtpIssueDate.Text = "";

            dtAdd.Clear();
        }

        private void AddBooks_Click(object sender, RoutedEventArgs e)
        {
            int searchEnum = 100;
            Search RowDataSearch = new Search();
            string BRid = RowDataSearch.Show(searchEnum).ToString();
            if (RowDataSearch.DialogResult == true)
            {
                string id = BRid.ToString();
                BRegistration Br = new BRegistration_DAO().searchByID(id);
                dtAdd.Rows.Add(Br.CategoryID, Br.BNo, Br.BName, Br.Language, Br.Author, "");
                dgv_Books.ItemsSource = dtAdd.DefaultView;
            }
        }

        private void DeleteBooks_Click(object sender, RoutedEventArgs e)
        {
            object selectedItem = dgv_Books.SelectedItem;
            ((DataRowView)(dgv_Books.SelectedItem)).Row.Delete();
        }

        private void dgvMain_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //DataRowView dv = (DataRowView)dgvMain.SelectedItem;
            //BBooks bb = new BBooks();
            //bb.BBID = int.Parse(dv.Row.ItemArray[0].ToString());

            dtAdd.Clear();

            object item = dgvMain.SelectedItem;
            string ID = (dgvMain.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;

            BBooks DAO = new BBooks_DAO().searchByID(ID);

            txtBBID.Text = DAO.BBID.ToString();
            txtMNo.Text = DAO.MNo.ToString();
            txtNofBB.Text = DAO.NofBB.ToString();
            dtpDueDate.Text = DAO.DueDate.ToString();
            dtpIssueDate.Text = DAO.IssueDate.ToString();

            string bname = "";
            foreach (BBooks BBooksDetails in new BBooksDetails_DAO().DisplayAll().Where(r => r.BBID == int.Parse(ID)))
            {
                foreach (BRegistration brdaos in new BRegistration_DAO().DisplayAll().Where(p => p.BNo == BBooksDetails.BNo))
                {
                    bname += brdaos.BName;
                }
                dtAdd.Rows.Add(BBooksDetails.BNo, bname, BBooksDetails.NoCopies);
            }
            dgv_Books.ItemsSource = dtAdd.DefaultView;
        }

        private void txtMNo_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            int searchEnum = 200;
            Search RowDataSearch = new Search();
            string BRid = RowDataSearch.Show(searchEnum).ToString();
            if (RowDataSearch.DialogResult == true)
            {
                //string id = BRid.ToString();
                BRegistration Br = new BRegistration_DAO().searchByID(BRid);
                dtAdd.Rows.Add(Br.BNo, Br.BName, 1);
                dgv_Books.ItemsSource = dtAdd.DefaultView;
            }
        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            Search();
        }    
    }
}
