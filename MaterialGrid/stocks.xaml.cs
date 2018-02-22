using System;
using System.Collections.Generic;
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
    /// Interaction logic for stocks.xaml
    /// </summary>
    public partial class stocks : Window
    {
        DataTable dt;
        WorkspaceViewModel _workspaceViewModel;
        public stocks()
        {
            InitializeComponent();
            stockslist.CanUserAddRows = false;
            _workspaceViewModel = new WorkspaceViewModel("STOCKS");
            this.DataContext = _workspaceViewModel;
            _workspaceViewModel.col_name = stockslist.Columns.Select(e => e.Header).ToArray();
        }

        public bool col_val()
        {
            if (stockslist.SelectedItems.Count != 0)
            {
                _workspaceViewModel.col_data = (stockslist.SelectedItem as DataRowView).Row.ItemArray;
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
            if (stockslist.CanUserAddRows)
            {
                stockslist.CanUserAddRows = false;
                col_val();
                int res = _workspaceViewModel.Insert();
                Verify(res, "Insert");
            }
            else
            {
                stockslist.CanUserAddRows = true;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            col_val();
            int res = _workspaceViewModel.Update();
            Verify(res, "Updat");
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            col_val();
            int res = _workspaceViewModel.Delete();
            Verify(res, "Delet");
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            
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
