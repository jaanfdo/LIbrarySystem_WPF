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
    /// Interaction logic for UC_BReturn.xaml
    /// </summary>
    public partial class UC_BReturn : UserControl
    {
        DataTable dt = new DataTable();
        DataTable dtAdd = new DataTable();
        public UC_BReturn()
        {
            InitializeComponent();

            dt.Columns.Add("BRID", typeof(int));
            dt.Columns.Add("MNo", typeof(string));
            dt.Columns.Add("NofRB", typeof(string));
            dt.Columns.Add("ReturnDate", typeof(string));
            dt.Columns.Add("TotalFines", typeof(int));

            dtAdd.Columns.Add("BNo", typeof(int));
            dtAdd.Columns.Add("BName", typeof(string));
            dtAdd.Columns.Add("NoCopies", typeof(int));
            dtAdd.Columns.Add("IssueDate", typeof(string));
            dtAdd.Columns.Add("DueDate", typeof(string));
            dtAdd.Columns.Add("LateEarly", typeof(int));
            dtAdd.Columns.Add("Dates", typeof(int));
            dtAdd.Columns.Add("Fines", typeof(int));

            DisplayAll();

            string val = new BReturn_DAO().AutoNumber();
            txtBRID.Text = val;
            txtBRID.Tag = val;
        }

        private void DisplayAll()
        {
            dt.Clear();
            List<BReturn> obj = new BReturn_DAO().DisplayAll();

            foreach (BReturn val in obj)
            {
                string mname = "";
                foreach (MRegistration item in new MRegistration_DAO().DisplayAll().Where(o => o.MNo == val.MNo))
                {
                    mname += item.MName;
                }
                dt.Rows.Add(val.BRID, mname, val.NoRCopies, val.ReturnDate, val.TotalFines);
            }
            dgvMain.ItemsSource = dt.DefaultView;
        }

        private void AddBook()
        {
            dtAdd.Clear();
            int searchEnum = 100;
            Search RowDataSearch = new Search();
            string lstResult = RowDataSearch.Show(searchEnum).ToString();
            if (RowDataSearch.DialogResult == true)
            {
                List<BRegistration> obj = new BRegistration_DAO().DisplayAll();
                List<BReturn> obj1 = new BReturn_DAO().DisplayAll();

                string bname = "";
                foreach (BReturn val2 in obj1)
                {
                    foreach (BRegistration val in obj)
                    {
                        bname += val.BName;
                    }
                    dtAdd.Rows.Add(val2.BNo, bname, val2.IssueDate, val2.DueDate, val2.LateEarly, val2.Dates, val2.Fines, 0);
                }
            }
        }

        private void Search()
        {
            dt.Clear();
            foreach (BReturn val in new BReturn_DAO().DisplayAll().Where(p => p.BRID == int.Parse(txtSearch.Text)))
            {
                string mname = "";
                foreach (MRegistration item in new MRegistration_DAO().DisplayAll().Where(o => o.MNo == val.MNo))
                {
                    mname += item.MName;
                }
                dt.Rows.Add(val.BRID, mname, val.NofRB, val.ReturnDate, val.TotalFines);
            }
            dgvMain.ItemsSource = dt.DefaultView;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            BReturn obj = new BReturn(int.Parse(txtBRID.Text.ToString()), int.Parse(txtMNo.Tag.ToString()), int.Parse(txtNofRB.Text), DateTime.Parse(dtpReturnDate.Text).Date, decimal.Parse(txtTotalFines.Text));
            BReturn_DAO cdao = new BReturn_DAO();
            cdao.Save(obj);

            foreach (DataRow row in dt.Rows)
            {
                int bno = int.Parse(row["BNo"].ToString());
                int nocopies = int.Parse(row["NoCopies"].ToString());
                DateTime issuedate = DateTime.Parse(row["IssuDate"].ToString());
                DateTime duedate = DateTime.Parse(row["DueDate"].ToString());
                string lateearly = row["LateEarly"].ToString();
                int days = int.Parse(row["Dates"].ToString());
                decimal fines = decimal.Parse(row["Fines"].ToString());

                BReturn oBBDetails = new BReturn(int.Parse(txtBRID.Text.ToString()), bno, nocopies, issuedate, duedate, lateearly, days, fines);
                BReturnDetails_DAO BRDDAO = new BReturnDetails_DAO();
                BRDDAO.Save(oBBDetails);
            }

            MessageBox.Show("AL Library", "Record Added");
            DisplayAll();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            BReturn obj = new BReturn(int.Parse(txtBRID.Text.ToString()), int.Parse(txtMNo.Tag.ToString()), int.Parse(txtNofRB.Text), DateTime.Parse(dtpReturnDate.Text).Date, decimal.Parse(txtTotalFines.Text));
            BReturn_DAO cdao = new BReturn_DAO();
            cdao.Update(obj);

            foreach (DataRow row in dt.Rows)
            {
                int bno = int.Parse(row["BNo"].ToString());
                int nocopies = int.Parse(row["NoCopies"].ToString());
                DateTime issuedate = DateTime.Parse(row["IssuDate"].ToString());
                DateTime duedate = DateTime.Parse(row["DueDate"].ToString());
                string lateearly = row["LateEarly"].ToString();
                int days = int.Parse(row["Dates"].ToString());
                decimal fines = decimal.Parse(row["Fines"].ToString());

                BReturn oBBDetails = new BReturn(int.Parse(txtBRID.Text.ToString()), bno, nocopies, issuedate, duedate, lateearly, days, fines);
                BReturnDetails_DAO BRDDAO = new BReturnDetails_DAO();
                BRDDAO.Update(oBBDetails);
            }

            MessageBox.Show("AL Library", "Record Updated");
            DisplayAll();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result =  MessageBox.Show("Confirmation","Are You Wants to Delete this Record??", MessageBoxButton.YesNo, MessageBoxImage.Error);
            if (result == MessageBoxResult.Yes)
            {
                BReturn obj = new BReturn(int.Parse(txtBRID.Tag.ToString()));
                BReturn_DAO cdao = new BReturn_DAO();
                cdao.Delete(obj);
                MessageBox.Show("AL Library", "Record Deleted");
            }           
            DisplayAll();
        }

        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            dtAdd.Clear();

            txtBRID.Text = "";
            txtMNo.Text = "";
            txtNofRB.Text = "";
            txtSearch.Text = "";
            txtTotalFines.Text = "";
        }

        private void AddBooks_Click(object sender, RoutedEventArgs e)
        {
            AddBook();
        }

        private void DeleteBooks_Click(object sender, RoutedEventArgs e)
        {
            DataRowView dv = (DataRowView)dgvMain.SelectedItem;
            dv.Delete();
        }

        private void dgvMain_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //DataRowView dv = (DataRowView)dgvMain.SelectedItem;
            //BReturn br = new BReturn();
            //br.BRID = int.Parse(dv.Row.ItemArray[0].ToString());

            dtAdd.Clear();
            object item = dgvMain.SelectedItem;
            string ID = (dgvMain.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;

            BReturn DAO = new BReturn_DAO().searchByID(ID);
            MRegistration mReg = new MRegistration_DAO().searchByID(DAO.MNo);

            txtBRID.Text = DAO.BRID.ToString();
            txtNofRB.Text = DAO.NofRB.ToString();
            txtMNo.Text = DAO.MNo.ToString();
            dtpReturnDate.Text = DAO.ReturnDate.ToString();
            txtTotalFines.Text = DAO.TotalFines.ToString();

            string bname = "";
            foreach (BReturn DAOs in new BReturnDetails_DAO().DisplayAll().Where(p => p.BRID == int.Parse(ID)))
            {
                foreach (BRegistration brdaos in new BRegistration_DAO().DisplayAll().Where(p => p.BNo == DAOs.BNo))
                {
                    bname += brdaos.BName;
                }
                dtAdd.Rows.Add(DAOs.BNo, bname, DAOs.IssueDate, DAOs.DueDate, DAOs.LateEarly, DAOs.Dates, DAOs.Fines, 0);
            }

            dgv_Books.ItemsSource = dtAdd.DefaultView;
        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            Search();
        }
    }
}
