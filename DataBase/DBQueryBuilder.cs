using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaterialGrid
{
    public class DBQueryBuilder
    {
        string _tableName;
        object[] _columns, _selectedRow;

        public string TableName
        {
            get
            {
                return _tableName;
            }
            set
            {
                _tableName = value;
            }
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

        public object[] SelectedRow
        {
            get
            {
                return _selectedRow;
            }
            set
            {
                _selectedRow = value;
            }
        }

        public string SelectQuery
        {
            get
            {
                return "select * from " + _tableName;
            }
            set
            {
                this.SelectQuery = value;
            }
        }

        public string InsertQuery
        {
            get
            {
                string response = GetInsertQuery();
                return "Insert Into " + TableName + "(" + response;
            }
        }

        public string GetInsertQuery()
        {
            string col_name = "", col_val = "'";
            for (int i = 1; i < Columns.Length; i++)
            {
                col_name += (i != (Columns.Length-1)) ? (Columns[i]+",") : (Columns[i]);
                col_val += (i != Columns.Length-1) ? SelectedRow[i] + "','" : SelectedRow[i] + "'";
            }
            return col_name + ") VALUES(" + col_val + ")";
        }

        public string UpdateQuery
        {
            get
            {
                string response = GetUpdateQuery();
                return "Update " + TableName + " SET " + response;
            }
        }

        private string GetUpdateQuery()
        {
            string col_data = "";
            for (int i = 1; i < Columns.Length; i++)
            {
                col_data += (i != Columns.Length-1) ? Columns[i] + "='" + SelectedRow[i] + "'," : Columns[i] + "='" + SelectedRow[i] + "'";
            }
            return col_data + " where ID = " + SelectedRow[0];
        }

        public string DeleteQuery
        {
            get
            {
                return "Delete FROM " + TableName + " where ID = " + SelectedRow[0];
            }
        }
    }
}
