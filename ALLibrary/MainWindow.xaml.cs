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
using System.Data.SqlClient;

namespace ALLibrary
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DataTable dt = new DataTable();
        
        public MainWindow()
        {
            InitializeComponent();

            dt.Columns.Add("FunctionID", typeof(int));
            dt.Columns.Add("FunctionName", typeof(string));

            Dis();
        }

        private void dis_Click(object sender, RoutedEventArgs e)
        {
            UC_BRegistration uc = new UC_BRegistration();
            UCTest.Children.Add(uc);
        }

        private void Dis()
        {
            List<Functions> fun = new Function_DAO().DisplayFunction();

            foreach (Functions dis in fun)
            {
                dt.Rows.Add(dis.FunctionID, dis.FunctionName);
            }
            disFunctions.ItemsSource = dt.DefaultView;
        }

        private void StackPanel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void disFunctions_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            UCTest.Children.Clear();
            DataRowView dv = (DataRowView)disFunctions.SelectedItem;

            //Customers cuss = new Customers();
            int id = int.Parse(dv.Row.ItemArray[0].ToString());
            //Customers customer = new Customer_DAO().searchByID(cuss);

            if (id == 1)
            {
                UC_MRegistration uc = new UC_MRegistration();
                UCTest.Children.Add(uc);
            }
            if (id == 2)
            {
                UC_BRegistration uc = new UC_BRegistration();
                UCTest.Children.Add(uc);
                
            }
            if (id == 3)
            {
                UC_BBorrow uc = new UC_BBorrow();
                UCTest.Children.Add(uc);
               
            }
            if (id == 4)
            {
                UC_BReturn uc = new UC_BReturn();
                UCTest.Children.Add(uc);
            }
            if (id == 5)
            {
                UC_BReserve uc = new UC_BReserve();
                UCTest.Children.Add(uc);
            }

        }

        private void btnMin_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnMax_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            
        }
    }
}
