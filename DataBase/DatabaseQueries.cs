using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MaterialGrid
{
    public class DatabaseUtil : DBQueryBuilder
    {
        string _connectionString = ConfigurationManager.ConnectionStrings["ConString1"].ConnectionString;
       
        OracleConnection oc;
        OracleCommand ocmd;
        OracleDataAdapter oda;

        public DatabaseUtil(string tableName)
        {
            TableName = tableName;
            oc = new OracleConnection(_connectionString);
            ocmd = new OracleCommand();
            SelectCommand();
        }

        public DataTable SelectCommand()
        {
            oc.Open();
            ocmd.Connection = oc;
            ocmd.CommandText = SelectQuery;
            oda = new OracleDataAdapter(ocmd);
            DataTable dt = new DataTable();
            oda.Fill(dt);
            oc.Close();
            return dt;
        }

        public int InsertCommand()
        {
            oc.Open();
            ocmd.Connection = oc;
            ocmd.CommandText = InsertQuery;
            int res = ocmd.ExecuteNonQuery();
            oc.Close();
            return res;
        }

        public int UpdateCommand()
        {
            oc.Open();
            ocmd.Connection = oc;
            ocmd.CommandText = UpdateQuery;
            int res = ocmd.ExecuteNonQuery();
            oc.Close();
            return res;
        }

        public int DeleteCommand()
        {
            oc.Open();
            ocmd.Connection = oc;
            ocmd.CommandText = DeleteQuery;
            int res = ocmd.ExecuteNonQuery();
            oc.Close();
            return res;
        }        
    }
}
