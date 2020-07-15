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

namespace ALLibrary
{
    /// <summary>
    /// Interaction logic for UC_MRegistration.xaml
    /// </summary>
    public partial class UC_MRegistration : UserControl
    {
        DataTable dt = new DataTable();
        public UC_MRegistration()
        {
            InitializeComponent();

            dt.Columns.Add("Member No", typeof(int));
            dt.Columns.Add("Member Name", typeof(string));
            dt.Columns.Add("Address", typeof(string));
            dt.Columns.Add("Gender", typeof(string));
            dt.Columns.Add("NIC", typeof(string));
            dt.Columns.Add("Telephone No", typeof(int));

            DisMembers();

            string val = new MRegistration_DAO().AutoNumber();
            txtMNo.Text = val;
            txtMNo.Tag = val;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            MRegistration MR = new MRegistration(int.Parse(txtMNo.Text),txtMName.Text,txtAddress.Text,txtGender.Text,txtNIC.Text, int.Parse(txtTpNo.Text));
            MRegistration_DAO MRDAO = new MRegistration_DAO();
            MRDAO.Save(MR);
            MessageBox.Show("Record Added", "Added");
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            MRegistration MR = new MRegistration(int.Parse(txtMNo.Text), txtMName.Text, txtAddress.Text, txtGender.Text, txtNIC.Text, int.Parse(txtTpNo.Text));
            MRegistration_DAO MRDAO = new MRegistration_DAO();
            MRDAO.Update(MR);
            MessageBox.Show("Record Added", "Update");
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            MRegistration MR = new MRegistration(int.Parse(txtMNo.Text));
            MRegistration_DAO MRDAO = new MRegistration_DAO();
            MRDAO.Delete(MR);
            MessageBox.Show("Record Added", "Delete");
        }

        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            txtAddress.Text = "";
            txtGender.Text = "";
            txtMName.Text = "";
            txtMNo.Text = "";
            txtNIC.Text = "";
            txtSearch.Text = "";
            txtTpNo.Text = "";
        }

        private void DisMembers()
        {
            dt.Clear();
            List<MRegistration> member = new MRegistration_DAO().DisplayAll();

            foreach (MRegistration mem in member)
            {
                dt.Rows.Add(mem.MNo, mem.MName, mem.Address, mem.Gender, mem.NIC, mem.TpNo);
            }
            dgvMain.ItemsSource = dt.DefaultView;
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

        private void dgvMain_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //DataRowView dv = (DataRowView)dgvMain.SelectedItem;
            MRegistration mr = new MRegistration();
            //mr.MNo = int.Parse(dv.Row.ItemArray[0].ToString());

            object item = dgvMain.SelectedItem;
            mr.MNo = int.Parse((dgvMain.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text);

            MRegistration MRDAO = new MRegistration_DAO().searchByID(mr.MNo);

            txtMNo.Text = MRDAO.MNo.ToString();
            txtMName.Text = MRDAO.MName.ToString();
            txtAddress.Text = MRDAO.Address.ToString();
            txtGender.Text = MRDAO.Gender.ToString();
            txtNIC.Text = MRDAO.NIC.ToString();
            txtTpNo.Text = MRDAO.TpNo.ToString();
        }
    }
}
