using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.OracleClient;
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

namespace MaterialGrid
{
    /// <summary>
    /// Interaction logic for users.xaml
    /// </summary>
    public partial class users : Window
    {
        DataTable dt;
        WorkspaceViewModel _workspaceViewModel;
        public users()
        {
            InitializeComponent();
            userslist.CanUserAddRows = false;
            _workspaceViewModel = new WorkspaceViewModel("USERS");
            DataContext = _workspaceViewModel;
            _workspaceViewModel.Columns = userslist.Columns.Select(e => e.Header).ToArray();
        }

        public bool col_val()
        {
            if (userslist.SelectedItems.Count != 0)
            {
                _workspaceViewModel.SelectedItem = (userslist.SelectedItem as DataRowView).Row.ItemArray;
                return true;
            }
            else
            {
                MessageBox.Show("No item got selected!");
                return false;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (userslist.CanUserAddRows)
            {
                userslist.CanUserAddRows = false;
                if (col_val())
                {
                    int res = _workspaceViewModel.Insert();
                    Verify(res, "Insert");
                }
            }
            else
            {
                userslist.CanUserAddRows = true;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (col_val())
            {
                int res = _workspaceViewModel.Update();
                Verify(res, "Updat");
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (col_val())
            {
                int res = _workspaceViewModel.Delete();
                Verify(res, "Delet");
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            _workspaceViewModel.Data = _workspaceViewModel.Selected();
            //InitializeComponent();
            //userslist.Items.Refresh();
            userslist.ItemsSource = _workspaceViewModel.Selected().DefaultView;
            DataContext = _workspaceViewModel;
        }

        public void Verify(int res, string cmd)
        {
            if (res >= 1)
            {
                MessageBox.Show(cmd + "ed");
            }
            else
            {
                MessageBox.Show(cmd + "ion Failed");
            }
        }

    }
}
