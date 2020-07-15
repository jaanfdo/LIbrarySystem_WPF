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

namespace ALLibrary
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string u = "admin";
            string p = "admin";

            if(txtUName.Text == u && txtPass.Text == p){
                MessageBox.Show("Correct User namd and Password", "AL Library", MessageBoxButton.OK);
                MainWindow frm = new MainWindow();
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Incorrect User namd and Password", "AL Library", MessageBoxButton.OK ,MessageBoxImage.Error);
            }
        }

        private void grdTop_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
