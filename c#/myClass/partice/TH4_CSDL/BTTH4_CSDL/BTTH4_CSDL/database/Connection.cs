using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace BTTH4_CSDL.database
{
    class Connection
    {

        private SqlConnection sqlConnection;
        private  string string_connect;


        private SqlDataAdapter dataAdapter; //cầu nối giữa db vs datatable, dataset

        private SqlCommand sqlCommand; //thực thi câu lệnh truy vấn

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
            }
        }



       

    }
}

