﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBanDienThoai.model
{
    internal class Connection
    {
        string strConnect = "Data Source=LAPTOP-LEDRJD7A\\SQLEXPRESS;Initial Catalog=QLBanDienThoai;Integrated Security=True";
        SqlConnection sqlConnect = null;

        public Connection(string strConnect)
        {
            this.strConnect = strConnect;
        }




        //Hàm mở kết nối CSDL
        private void KetNoiCSDL()
        {
            sqlConnect = new SqlConnection(strConnect);
            if (sqlConnect.State != ConnectionState.Open)
                sqlConnect.Open();
        }

        //Hàm đóng kết nối CSDL
        private void DongKetNoiCSDL()
        {
            if (sqlConnect.State != ConnectionState.Closed)
                sqlConnect.Close();
            sqlConnect.Dispose();
        }

        //Hàm thực thi câu lệnh dạng Select trả về một DataTable
        public DataTable DocBang(string sql)
        {
            DataTable dtBang = new DataTable();
            KetNoiCSDL();
            SqlDataAdapter sqldataAdapte = new SqlDataAdapter(sql, sqlConnect);
            sqldataAdapte.Fill(dtBang);
            DongKetNoiCSDL();
            sqldataAdapte.Dispose();
            dtBang.Dispose();
            return dtBang;
        }

        //Hàm thực lệnh insert hoặc update hoặc delete
        public void CapNhatDuLieu(string sql)
        {
            KetNoiCSDL();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.Connection = sqlConnect;
            sqlcommand.CommandText = sql;

            sqlcommand.ExecuteNonQuery();
            DongKetNoiCSDL();
            sqlcommand.Dispose();
        }

    }
}
