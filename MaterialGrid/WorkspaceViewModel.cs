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
        DatabaseQueries dbq;
        DataTable dt;
        object[] obj, obj1;
        public WorkspaceViewModel(string tab_name)
        {
            dbq = new DatabaseQueries(tab_name);
            dt = Selected();
        }

        public object[] col_name
        {
            get
            {
                return obj;
            }
            set
            {
                obj = value;
            }
        }

        public object[] col_data
        {
            get
            {
                return obj1;
            }
            set
            {
                obj1 = value;
            }
        }

        public DataTable lists
        {
            get
            {
                return dt;
            }
            set
            {
                dt = value;
            }
        }

        public DataTable Selected()
        {
            return dbq.SelectCommand();
        }

        public int Insert()
        {
            dbq.col_val_data = col_data;
            dbq.col_name_data = col_name;
            return dbq.InsertCommand();
        }

        public int Update()
        {
            dbq.col_val_data = col_data;
            dbq.col_name_data = col_name;
            return dbq.UpdateCommand();
        }

        public int Delete()
        {
            dbq.col_val_data = col_data;
            dbq.col_name_data = col_name;
            return dbq.DeleteCommand();
        }
    }
}
