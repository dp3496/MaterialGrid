using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MaterialGrid
{
    public class WorkspaceViewModel
    {
        DatabaseUtil dbq;
        DataTable _data;
        object[] _columns, _selectedItem;
        public WorkspaceViewModel(string tab_name)
        {
            dbq = new DatabaseUtil(tab_name);
            _data = Selected();
        }

        public object[] Columns
        {
            get
            {
                return _columns;
            }
            set
            {
                _columns = value;
            }
        }

        public object[] SelectedItem
        {
            get
            {
                return _selectedItem;
            }
            set
            {
                _selectedItem = value;
            }
        }

        public DataTable Data
        {
            get
            {
                return _data;
            }
            set
            {
                _data = value;
            }
        }

        public DataTable Selected()
        {
            return dbq.SelectCommand();
        }

        public int Insert()
        {
            dbq.SelectedRow = SelectedItem;
            dbq.Columns = Columns;
            return dbq.InsertCommand();
        }

        public int Update()
        {
            dbq.SelectedRow = SelectedItem;
            dbq.Columns = Columns;
            return dbq.UpdateCommand();
        }

        public int Delete()
        {
            dbq.SelectedRow = SelectedItem;
            dbq.Columns = Columns;
            return dbq.DeleteCommand();
        }
    }
}
