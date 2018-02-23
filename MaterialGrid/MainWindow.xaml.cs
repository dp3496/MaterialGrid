using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Data.OracleClient;

namespace MaterialGrid
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string Constr = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
        DatabaseUtil dbq = new DatabaseUtil("");
        public MainWindow()
        {
            InitializeComponent();
            ExecuteQuery();
            dgUsers.CanUserAddRows = false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (dgUsers.CanUserAddRows)
            {
                dgUsers.CanUserAddRows = false;
                var data = (dgUsers.SelectedItem as DataRowView).Row.ItemArray;
                int a = 0;
                string cmd = "Insert Into Test Values('" + data[1] + "','" + data[2] + "')";
                using (SqlConnection con = new SqlConnection(Constr))
                {
                    SqlCommand scmd = new SqlCommand(cmd, con);
                    con.Open();
                    a = scmd.ExecuteNonQuery();
                }
                if (a == 1)
                {
                    MessageBox.Show("Inserted");
                }
                else
                {
                    MessageBox.Show("Not Inserted");
                }
            }
            else
            {
                dgUsers.CanUserAddRows = true;
            }
        }

        private void ExecuteQuery()
        {
            string cmd = "SELECT * FROM Test";
            using (SqlConnection con = new SqlConnection(Constr))
            {
                SqlCommand scmd = new SqlCommand(cmd, con);
                SqlDataAdapter sda = new SqlDataAdapter(scmd);
                DataTable dt = new DataTable("Employee");
                sda.Fill(dt);
                dgUsers.ItemsSource = dt.DefaultView;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int a = 0;
            var data = (dgUsers.SelectedItem as DataRowView).Row.ItemArray;
            string cmd = "Delete From Test where Id =" + data[0].ToString();
            using(SqlConnection con = new SqlConnection(Constr))
            {
                SqlCommand scmd = new SqlCommand(cmd, con);
                con.Open();
                a = scmd.ExecuteNonQuery();
            }
            if (a == 1)
            {
                MessageBox.Show("Deleted");
            }
            else
            {
                MessageBox.Show("Failed to delete");
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            int a = 0;
            var data = (dgUsers.SelectedItem as DataRowView).Row.ItemArray;
            string cmd = "Update Test set Name = '" + data[1] + "', Address = '" + data[2] + "' where Id = " + data[0].ToString();
            using (SqlConnection con = new SqlConnection(Constr))
            {
                SqlCommand scmd = new SqlCommand(cmd, con);
                con.Open();
                a = scmd.ExecuteNonQuery();
            }
            if (a == 1)
            {
                MessageBox.Show("Updated");
            }
            else
            {
                MessageBox.Show("Failed to delete");
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            ExecuteQuery();
        }
    }
}
