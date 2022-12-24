using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace huongdan.model
{
    internal class Connection
    {
        private SqlConnection sqlConnection;
        private string string_connect;
        private SqlDataAdapter dataAdapter;
        private SqlCommand sqlCommand;



        public Connection(string str_connect)
        {
            this.string_connect = str_connect;
        }




        //show ra datatable
        public DataTable getTable(string query)
        {
            DataTable table = new DataTable();
            using (SqlConnection sqlConnection = new SqlConnection(string_connect))
            {
                sqlConnection.Open();
                dataAdapter = new SqlDataAdapter(query, sqlConnection);
                dataAdapter.Fill(table);
                sqlConnection.Close();
                dataAdapter.Dispose();
                table.Dispose();
                sqlConnection.Dispose();
            }

            return table;

        }

        //thuwjc hiện truy vấn insert, delete, update
        public void Excute(string query)
        {
            using (SqlConnection sqlConnection = new SqlConnection(string_connect))
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
                sqlCommand.Dispose();
            }
        }
    }
}
