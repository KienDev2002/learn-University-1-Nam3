using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;

namespace exercise.model
{
    class Connection
    {
        SqlConnection conn;
        string str_connect;
        SqlCommand cmd;
        SqlDataAdapter adapter;


        public Connection(string str_connect)
        {
            this.str_connect = str_connect;
        }

        public DataTable getTable(string query)
        {

            DataTable dataTable = new DataTable();
            using(SqlConnection conn = new SqlConnection(str_connect))
            {
                conn.Open();
                adapter = new SqlDataAdapter(query, conn);
                adapter.Fill(dataTable);
                conn.Close();
            }

            return dataTable;
        }



        public void Excute(string query)
        {
            using (SqlConnection conn = new SqlConnection(str_connect))
            {
                conn.Open();
                cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                conn.Close();

            }
        }

      
    }
}
