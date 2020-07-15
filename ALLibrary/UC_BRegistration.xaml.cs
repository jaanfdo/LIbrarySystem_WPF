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
using ALLibrary.GetterSetter;

namespace ALLibrary
{
    /// <summary>
    /// Interaction logic for UC_BRegistration.xaml
    /// </summary>
    public partial class UC_BRegistration : UserControl
    {
        DataTable dt = new DataTable();
        public UC_BRegistration()
        {
            InitializeComponent();

            dt.Columns.Add("CategoryID", typeof(int));
            dt.Columns.Add("BNo", typeof(int));
            dt.Columns.Add("BName", typeof(string));
            dt.Columns.Add("Language", typeof(int));
            dt.Columns.Add("ISBN", typeof(int));
            dt.Columns.Add("AuthorID", typeof(int));
            dt.Columns.Add("PublisherName", typeof(int));
            dt.Columns.Add("PublicationDate", typeof(DateTime));
            dt.Columns.Add("Edition", typeof(int));
            dt.Columns.Add("NoCopies", typeof(int));
            dt.Columns.Add("BPurchasingDate", typeof(DateTime));
            dt.Columns.Add("BillNo", typeof(int));
            dt.Columns.Add("Price", typeof(decimal));
            dt.Columns.Add("Status", typeof(bool));

            string val = new BBooks_DAO().AutoNumber();
            txtBNo.Text = val;
            txtBNo.Tag = val;

            DisplayAll();
            Clear();
        }

        private void DisplayAll()
        {
            dt.Clear();
            List<BRegistration> obj = new BRegistration_DAO().DisplayAll();

            foreach (BRegistration val in obj)
            {
                dt.Rows.Add(val.CategoryID, val.BNo, val.BName, val.Language, val.ISBN, val.Author, val.PublisherName,
                    val.PublicationDate, val.Edition, val.NoCopies, val.BPurchasingDate, val.BillNo, val.Price, val.Status);
            }
            dgvMain.ItemsSource = dt.DefaultView;
        }

        private void Search()
        {
            dt.Clear();
            foreach (BRegistration val in new BRegistration_DAO().DisplayAll().Where(p => p.BNo == int.Parse(txtBNo.Text)))
            {
                dt.Rows.Add(val.CategoryID, val.BNo, val.BName, val.Language, val.ISBN, val.Author, val.PublisherName,
                    val.PublicationDate, val.Edition, val.NoCopies, val.BPurchasingDate, val.BillNo, val.Price, val.Status);
            }
            dgvMain.ItemsSource = dt.DefaultView;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            BRegistration oBR = new BRegistration(int.Parse(txtCategoryID.Tag.ToString()), int.Parse(txtBNo.Text), txtBName.Text, 
                int.Parse(txtLanguage.Tag.ToString()),int.Parse(txtISBN.Text), int.Parse(txtAuthor.Tag.ToString()),
                int.Parse(txtPublisherName.Tag.ToString()), DateTime.Parse(dtpPublicationDate.Text), int.Parse(txtEdition.Text), 
                int.Parse(txtNoCopies.Text), DateTime.Parse(dtpBPurchasingDate.Text).Date ,int.Parse(txtBillNo.Text),
                decimal.Parse(txtPrice.Text), bool.Parse("True"));
            BRegistration_DAO oDAO = new BRegistration_DAO();
            oDAO.Save(oBR);

            MessageBox.Show("AL Library", "Record Added");
            DisplayAll();
        }


        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            BRegistration oBR = new BRegistration(int.Parse(txtCategoryID.Tag.ToString()), int.Parse(txtBNo.Text), txtBName.Text, 
                int.Parse(txtLanguage.Tag.ToString()), int.Parse(txtISBN.Text), int.Parse(txtAuthor.Tag.ToString()), 
                int.Parse(txtPublisherName.Tag.ToString()), DateTime.Parse(dtpPublicationDate.Text), int.Parse(txtEdition.Text), 
                int.Parse(txtNoCopies.Text), DateTime.Parse(dtpBPurchasingDate.Text).Date, int.Parse(txtBillNo.Text), 
                decimal.Parse(txtPrice.Text), bool.Parse("True"));
            BRegistration_DAO oDAO = new BRegistration_DAO();
            oDAO.Update(oBR);

            MessageBox.Show("AL Library", "Record Updated");
            DisplayAll();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            BRegistration oBR = new BRegistration(int.Parse(txtBNo.Text));
            BRegistration_DAO oDAO = new BRegistration_DAO();
            oDAO.Delete(oBR);

            MessageBox.Show("AL Library", "Record Delete");
            DisplayAll();
        }

        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            Clear();
        }

        private void Clear()
        {
            txtAuthor.Text = "";
            txtBillNo.Text = "";
            txtBName.Text = "";
            txtBNo.Text = "<Auto Generated>"; 
            txtCategoryID.Text = "";
            txtEdition.Text = "";
            txtISBN.Text = "";
            txtLanguage.Text = "";
            txtNoCopies.Text = "";
            txtPrice.Text = "";
            dtpPublicationDate.Text = "";
            txtPublisherName.Text = "";


            txtAuthor.Tag = null;
            txtBNo.Tag = null;
            txtCategoryID.Tag = null;
            txtLanguage.Tag = null;
            txtPublisherName.Tag = null;
        }

        private void dgvMain_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            object item = dgvMain.SelectedItem;
            string ID = (dgvMain.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;

            //DataRowView dv = (DataRowView)dgvMain.SelectedItem;
            //BRegistration br = new BRegistration();
            //br.BNo = int.Parse(dv.Row.ItemArray[0].ToString());


            BRegistration DAO = new BRegistration_DAO().searchByID(ID);

            txtAuthor.Text = DAO.Author.ToString();
            txtBillNo.Text = DAO.BillNo.ToString();
            txtBName.Text = DAO.BName.ToString();
            txtBNo.Text = DAO.BNo.ToString();
            txtCategoryID.Text = DAO.CategoryID.ToString();
            dtpBPurchasingDate.Text = DAO.BPurchasingDate.ToString();
            txtEdition.Text = DAO.Edition.ToString();
            txtISBN.Text = DAO.ISBN.ToString();
            txtLanguage.Text = DAO.Language.ToString();
            txtNoCopies.Text = DAO.NoCopies.ToString();
            txtPrice.Text = DAO.Price.ToString();
            dtpPublicationDate.Text = DAO.PublicationDate.ToString();
            txtPublisherName.Text = DAO.PublisherName.ToString();
        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            dt.Clear();
            Search();
            
            //string search = txtSearch.Text;
            //string filter = cmbFilter.SelectedItem.ToString();
            //foreach (BRegistration val in new BRegistration_DAO().SearchAll(filter, search))
            //{
            //    dt.Rows.Add(val.CategoryID, val.BNo, val.BName, val.Language, val.ISBN, val.Author, val.PublisherName,
            //        val.PublicationDate, val.Edition, val.NoCopies, val.BPurchasingDate, val.BillNo, val.Price, val.Status);
            //}
            //dgvMain.ItemsSource = dt.DefaultView;
        }

        private void txtCategoryID_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            pop_Event.PopupAnimation = System.Windows.Controls.Primitives.PopupAnimation.Slide;
            pop_Event.IsOpen = true;

            List<string> category = new List<string>();

            foreach (Category cat in new Category().AllCategory().OrderBy(o => o.CatNo))
            {
                category.Add(cat.Categorys);
            }
            lstCategory.ItemsSource = category;
            lstCategory.SelectedIndex = 0;
        }

        private void btn_PoPAdd_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btn_Close_Click(object sender, RoutedEventArgs e)
        {
            pop_Event.IsOpen = false;
        }

        

        private void txtLanguage_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            pop_Event2.PopupAnimation = System.Windows.Controls.Primitives.PopupAnimation.Slide;
            pop_Event2.IsOpen = true;

            List<string> language = new List<string>();

            foreach (Language lan in new Language().AllLanguage().OrderBy(o => o.LanID))
            {
                language.Add(lan.Languages);
            }
            lstLanguages.ItemsSource = language;
            lstLanguages.SelectedIndex = 0;
        }

        private void btn_PoPAdd2_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btn_Close2_Click(object sender, RoutedEventArgs e)
        {
            pop_Event2.IsOpen = false;
        }

        private void txtAuthor_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            pop_Event3.PopupAnimation = System.Windows.Controls.Primitives.PopupAnimation.Slide;
            pop_Event3.IsOpen = true;

            List<string> author = new List<string>();

            foreach (Authors aut in new Authors().AllAuthors().OrderBy(o => o.AutID))
            {
                author.Add(aut.Author);
            }
            lstAuthor.ItemsSource = author;
            lstAuthor.SelectedIndex = 0;
        }

        private void btn_PoPAdd3_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_Close3_Click(object sender, RoutedEventArgs e)
        {
            pop_Event3.IsOpen = false;
        }

        private void txtPublisherName_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            pop_Event4.PopupAnimation = System.Windows.Controls.Primitives.PopupAnimation.Slide;
            pop_Event4.IsOpen = true;

            List<string> publisher = new List<string>();

            foreach (Publisher pub in new Publisher().AllPublisher().OrderBy(o => o.PubID))
            {
                publisher.Add(pub.Publishers);
            }
            lstPublisher.ItemsSource = publisher;
            lstPublisher.SelectedIndex = 0;
        }

        private void btn_PoPAdd4_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_Clos4_Click(object sender, RoutedEventArgs e)
        {
            pop_Event4.IsOpen = false;
        }
        
    }
}
