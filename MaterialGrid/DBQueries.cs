﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaterialGrid
{
    public class DBQueries
    {
        string str;
        object[] obj, obj1;

        public string TableName
        {
            get
            {
                return str;
            }
            set
            {
                str = value;
            }
        }

        public object[] col_name_data
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

        public object[] col_val_data
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

        public string Select
        {
            get
            {
                return "select * from " + str;
            }
            set
            {
                this.Select = value;
            }
        }

        public string Insert
        {
            get
            {
                string response = data_iterator_insert();
                return "Insert Into " + TableName + "(" + response;
            }
        }

        public string data_iterator_insert()
        {
            string col_name = "", col_val = "'";
            for (int i = 1; i < col_name_data.Length; i++)
            {
                col_name += (i != (col_name_data.Length-1)) ? (col_name_data[i]+",") : (col_name_data[i]);
                col_val += (i != col_name_data.Length-1) ? col_val_data[i] + "','" : col_val_data[i] + "'";
            }
            return col_name + ") VALUES(" + col_val + ")";
        }

        public string Update
        {
            get
            {
                string response = data_iterator_update();
                return "Update " + TableName + " SET " + response;
            }
        }

        private string data_iterator_update()
        {
            string col_data = "";
            for (int i = 1; i < col_name_data.Length; i++)
            {
                col_data += (i != col_name_data.Length-1) ? col_name_data[i] + "='" + col_val_data[i] + "'," : col_name_data[i] + "='" + col_val_data[i] + "'";
            }
            return col_data + " where ID = " + col_val_data[0];
        }

        public string Delete
        {
            get
            {
                return "Delete FROM " + TableName + " where ID = " + col_val_data[0];
            }
        }
    }
}
