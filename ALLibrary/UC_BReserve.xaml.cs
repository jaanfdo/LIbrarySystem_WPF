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
    /// Interaction logic for UC_BReserve.xaml
    /// </summary>
    public partial class UC_BReserve : UserControl
    {
        DataTable dt = new DataTable();
        DataTable dtAdd = new DataTable();
        public UC_BReserve()
        {
            InitializeComponent();

            dt.Columns.Add("Book Reserve ID", typeof(int));
            dt.Columns.Add("Reserve Name", typeof(string));
            dt.Columns.Add("Telephone No", typeof(int));
            dt.Columns.Add("Reserve Date", typeof(string));
            dt.Columns.Add("End Date", typeof(string));
            dt.Columns.Add("No of Books", typeof(int));

            dtAdd.Columns.Add("BNo", typeof(int));
            dtAdd.Columns.Add("BName", typeof(string));
            dtAdd.Columns.Add("NoCopies", typeof(int));

            DisplayAll();

            string val = new BReserve_DAO().AutoNumber();
            txtResID.Text = val;
            txtResID.Tag = val;

        }

        private void DisplayAll()
        {
            dt.Clear();
            List<BReserve> obj = new BReserve_DAO().DisplayAll();

            foreach (BReserve val in obj)
            {
                dt.Rows.Add(val.BResID, val.ResName, val.ResTpNo, val.ResDateTime, val.ResEDateTime, val.NofBB);
            }
            dgvMain.ItemsSource = dt.DefaultView;
        }

        private void AddBook()
        {
            int searchEnum = 100;
            Search RowDataSearch = new Search();
            string lstResult = RowDataSearch.Show(searchEnum).ToString();
            if (RowDataSearch.DialogResult == true)
            {
                dtAdd.Clear();
                List<BRegistration> obj = new BRegistration_DAO().DisplayAll();

                foreach (BRegistration val in obj)
                {
                    dtAdd.Rows.Add(val.BNo, val.BName, 0);
                }
                dgv_Books.ItemsSource = dtAdd.DefaultView;
            }
        }

        private void Search()
        {
            dt.Clear();
            foreach (BRegistration val in new BRegistration_DAO().DisplayAll().Where(p => p.BNo == int.Parse(txtSearch.Text)))
            {
                dt.Rows.Add(val.CategoryID, val.BNo, val.BName, val.Language, val.ISBN, val.Author, val.PublisherName,
                    val.PublicationDate, val.Edition, val.NoCopies, val.BPurchasingDate, val.BillNo, val.Price, val.Status);
            }
            dgvMain.ItemsSource = dt.DefaultView;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            BReserve obj = new BReserve(int.Parse(txtResID.Tag.ToString()), txtResName.Text, int.Parse(txtResTpNo.Text), DateTime.Parse(dtpResDateTime.Text), DateTime.Parse(dtpResEDateTime.Text).Date, int.Parse(txtNofBB.Text));
            BReserve_DAO dao = new BReserve_DAO();
            dao.Save(obj);

            foreach (DataRow row in dt.Rows)
            {
                int bno = int.Parse(row["BNo"].ToString());
                int nocopies = int.Parse(row["NoCopies"].ToString());

                BReserve oBBDetails = new BReserve(int.Parse(txtResID.Tag.ToString()), bno, nocopies);
                BReserveDetails_DAO BResDDAO = new BReserveDetails_DAO();
                BResDDAO.Update(oBBDetails);
            }

            MessageBox.Show("AL Library", "Record Added");
            DisplayAll();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            BReserve obj = new BReserve(int.Parse(txtResID.Tag.ToString()), txtResName.Text, int.Parse(txtResTpNo.Text), DateTime.Parse(dtpResDateTime.Text), DateTime.Parse(dtpResEDateTime.Text).Date, int.Parse(txtNofBB.Text));
            BReserve_DAO dao = new BReserve_DAO();
            dao.Update(obj);

            foreach (DataRow row in dt.Rows)
            {
                int bno = int.Parse(row["BNo"].ToString());
                int nocopies = int.Parse(row["NoCopies"].ToString());

                BReserve oBBDetails = new BReserve(int.Parse(txtResID.Tag.ToString()), bno, nocopies);
                BReserveDetails_DAO BResDDAO = new BReserveDetails_DAO();
                BResDDAO.Update(oBBDetails);
            }

            MessageBox.Show("AL Library", "Record Update");
            DisplayAll();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            BReserve obj = new BReserve(int.Parse(txtNofBB.Text));
            BReserve_DAO dao = new BReserve_DAO();
            dao.Delete(obj);

            MessageBox.Show("AL Library", "Record Delete");
            DisplayAll();
        }

        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            dtAdd.Clear();
            txtNofBB.Text = "";
            txtResID.Text = "";
            txtResName.Text = "";
            txtResTpNo.Text = "";
            txtSearch.Text = "";
        }

        private void AddBooks_Click(object sender, RoutedEventArgs e)
        {
            AddBook();
        }

        private void DeleteBooks_Click(object sender, RoutedEventArgs e)
        {
            object selectedItem = dgv_Books.SelectedItem;
            ((DataRowView)(dgv_Books.SelectedItem)).Row.Delete();
        }

        private void dgvMain_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //DataRowView dv = (DataRowView)dgvMain.SelectedItem;
            //BReserve br = new BReserve();
            //br.BNo = int.Parse(dv.Row.ItemArray[0].ToString());

            dtAdd.Clear();
            object item = dgvMain.SelectedItem;
            string ID = (dgvMain.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;

            BReserve DAO = new BReserve_DAO().searchByID(ID);

            txtResID.Text = DAO.BResID.ToString();
            txtNofBB.Text = DAO.NofBB.ToString();
            txtResName.Text = DAO.ResName.ToString();
            txtResTpNo.Text = DAO.ResTpNo.ToString();
            dtpResDateTime.Text = DAO.ResDateTime.ToShortDateString();
            dtpResEDateTime.Text = DAO.ResEDateTime.ToShortDateString();

            string bname = "";
            foreach (BReserve DAOs in new BReserveDetails_DAO().DisplayAll().Where(p => p.BResID == int.Parse(ID)))
            {
                foreach (BRegistration brdaos in new BRegistration_DAO().DisplayAll().Where(p => p.BNo == DAOs.BNo))
                {
                    bname += brdaos.BName;
                }
                dtAdd.Rows.Add(DAOs.BNo, bname, DAOs.NoCopies);
            }
            dgv_Books.ItemsSource = dtAdd.DefaultView;
        }
    }
}
