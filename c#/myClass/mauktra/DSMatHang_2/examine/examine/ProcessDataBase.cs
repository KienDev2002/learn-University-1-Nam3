using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace examine
{
    class ProcessDataBase
    {
        private string strConnect = @"Data Source=DESKTOP-OSRNAUL\SQLEXPRESS;Initial Catalog=Quanlybanhang;Integrated Security=True";
        private SqlConnection sqlConnect = null;
        private void KetNoiCSDL()
        {
            sqlConnect = new SqlConnection(strConnect);
            if (sqlConnect.State != ConnectionState.Open)
                // Kiểm tra connection đã mở chưa nếu chưa thì mở tương tự với hàm đóng
                sqlConnect.Open();
        }
        private void DongKetNoiCSDL()
        {
            if (sqlConnect.State != ConnectionState.Closed)
                sqlConnect.Close();
            //sqlConnect.Dispose();
        }
        public DataTable DocBang(string sql)//đường truyền thông tin
        {
            DataTable/**/ dtBang = new DataTable();
            KetNoiCSDL();
            SqlDataAdapter sqldataAdapte = new SqlDataAdapter(sql, sqlConnect);
            sqldataAdapte.Fill(dtBang);//đổ dữ liệu vào bảng
            DongKetNoiCSDL();
            return dtBang; ;
        }
        public void CapNhatDuLieu(string sql)//câu lệnh
        {
            KetNoiCSDL();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.Connection = sqlConnect;
            sqlcommand.CommandText = sql;
            sqlcommand.ExecuteNonQuery();//thực thi lệnh
            DongKetNoiCSDL();
        }

    }
}
